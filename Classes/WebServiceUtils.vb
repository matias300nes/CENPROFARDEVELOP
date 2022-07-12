Imports Utiles.Util
Imports Microsoft.ApplicationBlocks.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Globalization

Module WebServiceUtils
    Public Function updateTable(listTableNames() As String) As String
        If Not On_Production Then
            Return "App is not configured as production"
        End If
        Dim status As String
        For Each tableName As String In listTableNames
            status += updateTable(tableName) + ", "
        Next
        Return status
    End Function
    Public Function updateTable(tableName As String) As String
        If Not On_Production Then
            Return "App is not configured as production"
        End If
        Dim WebService As New CPFWebService.WS_CPFSoapClient()
        Dim Sql As String
        Dim connection As SqlConnection
        Dim tran As SqlTransaction
        Dim dsInsert As DataSet
        Dim dsUpdate As DataSet
        Dim dt As DataTable = Nothing
        Dim webStatus As String

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
            tran = connection.BeginTransaction()

            Sql = $"select * from {tableName} where webSyncStatus = 1" 'records to insert
            dsInsert = SqlHelper.ExecuteDataset(tran, CommandType.Text, Sql)
            dsInsert.Dispose()

            Sql = $"select * from {tableName} where webSyncStatus = 2" 'records to update
            dsUpdate = SqlHelper.ExecuteDataset(tran, CommandType.Text, Sql)
            dsUpdate.Dispose()
        Catch ex As Exception
            If ex.Message.Contains("webSyncStatus") Then
                createColumnSync(tableName)
                tran?.Commit()
                Return updateTable(tableName)
            End If
            tran?.Rollback()
            Return $"Error, {ex.Message}."
        End Try

        ''INSERT
        dt = dsInsert.Tables(0)
        If dt.Rows.Count > 0 Then
            Dim query As String = ""
            Dim columns As String = ""
            Dim values As String = ""
            Dim currentValue

            For i As Integer = 0 To dt.Rows.Count - 1
                query = ""
                columns = ""
                values = ""
                For j As Integer = 0 To dt.Columns.Count - 1
                    columns += $"{dt.Columns(j).ColumnName}" + IIf(j < dt.Columns.Count - 1, ",", "")
                    If dt.Rows(i)(j) IsNot DBNull.Value Then
                        currentValue = $"'{dt.Rows(i)(j).ToString}'"
                        If dt.Rows(i)(j).GetType() = GetType(DateTime) Then
                            currentValue = $"'{DateTime.Parse(dt.Rows(i)(j)).ToString("MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture)}'"
                        End If
                    Else
                        currentValue = "null"
                    End If
                    If dt.Columns(j).ColumnName = "webSyncStatus" Then
                        currentValue = "'0'" ''synced
                    End If
                    values += $"{currentValue}" + IIf(j < dt.Columns.Count - 1, ",", "")
                Next
                query = $"SET IDENTITY_INSERT {tableName} ON; INSERT INTO {tableName} ({columns}) VALUES ({values}); SET IDENTITY_INSERT {tableName} OFF;"
                webStatus = WebService.Sql_Set(query)

                If webStatus = "Success" Then
                    Sql = $"UPDATE {tableName} SET webSyncStatus = 0 WHERE ID = {dt.Rows(i)(0)}"
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Sql)
                End If
            Next
        End If

        ''UPDATE
        dt = dsUpdate.Tables(0)
        If dt.Rows.Count > 0 Then
            Dim query As String = ""
            Dim pairs As String = ""
            Dim currentValue

            For i As Integer = 0 To dt.Rows.Count - 1
                query = ""
                pairs = ""
                For j As Integer = 0 To dt.Columns.Count - 1
                    If dt.Rows(i)(j) IsNot DBNull.Value Then
                        currentValue = $"'{dt.Rows(i)(j).ToString}'"
                        If dt.Rows(i)(j).GetType() = GetType(DateTime) Then
                            currentValue = $"'{DateTime.Parse(dt.Rows(i)(j)).ToString("MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture)}'"
                        End If
                    Else
                        currentValue = "null"
                    End If
                    If dt.Columns(j).ColumnName = "webSyncStatus" Then
                        currentValue = "'0'" ''synced
                    End If
                    pairs += $"{dt.Columns(j).ColumnName} = {currentValue}" + IIf(j < dt.Columns.Count - 1, ",", "")
                Next
                query = $"SET IDENTITY_INSERT {tableName} ON;UPDATE {tableName} SET {pairs} WHERE ID = {dt.Rows(i)(0)};SET IDENTITY_INSERT {tableName} OFF"
                webStatus = WebService.Sql_Set(query)

                If webStatus = "Success" Then
                    Sql = $"UPDATE {tableName} SET webSyncStatus = 0 WHERE ID = {dt.Rows(i)(0)}"
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Sql)
                End If
            Next

        End If

        tran.Commit()
        Return "Success"

    End Function

    Private Sub createColumnSync(tableName As String)
        Dim Sql = $"ALTER TABLE [dbo].[{tableName}]
                        ADD [webSyncStatus] INT NOT NULL DEFAULT(1);

                    IF NOT EXISTS(SELECT * FROM SYS.triggers WHERE name = 'tr_{tableName}_WebSync')
                    BEGIN
	                    CREATE TRIGGER [dbo].[tr_{tableName}_WebSync] ON [dbo].[{tableName}]
                        FOR UPDATE
	                    AS 
	                    SELECT * INTO #Tmp_Inserted FROM Inserted 
	                    SELECT * INTO #Tmp_Deleted FROM Deleted  
	                    exec spSyncWebStauts_needUpdate [{tableName}]
	                    Drop Table #Tmp_Inserted 
	                    Drop Table #Tmp_Deleted
                    END"
        Dim connection As SqlConnection
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
            Dim ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, Sql)
            ds.Dispose()
        Catch ex As Exception

        End Try
    End Sub
End Module
