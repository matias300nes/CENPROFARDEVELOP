Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Microsoft.Reporting.WinForms
Imports Utiles.Util

Public Class frmRtpCheques
    Enum colsCheques
        id = 0
        seleccion = 1
        FechaCreacion = 2
        NroCheque = 3
        PagueseA = 4
        FechaEmision = 5
        FechaPago = 6
        Monto = 7
        IdFarmacia = 8
    End Enum
    Dim Cheques As DataTable
    Public Sub New(Cheques As DataTable)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Cheques = Cheques
    End Sub

#Region "Funciones y procedimientos"
    Private Function UpdateFechas() As Integer
        Dim res As Integer = 0
        Dim FechaPago = Date.Parse(frmCheques.dtpPago.Value)
        Dim FechaEmision = Date.Parse(frmCheques.dtpEmision.Value)

        Dim connection As SqlClient.SqlConnection = Nothing
        connection = SqlHelper.GetConnection(ConnStringSEI)
        Dim tran As SqlClient.SqlTransaction = connection.BeginTransaction

        Try
            For Each cheque As DataRow In Cheques.Rows
                ''ID
                Dim param_id As New SqlClient.SqlParameter
                param_id.ParameterName = "@id"
                param_id.SqlDbType = SqlDbType.BigInt
                param_id.Value = cheque(colsCheques.id)
                param_id.Direction = ParameterDirection.InputOutput

                ''fechaEmision
                Dim param_fechaEmision As New SqlClient.SqlParameter
                param_fechaEmision.ParameterName = "@FechaEmision"
                param_fechaEmision.SqlDbType = SqlDbType.Date
                param_fechaEmision.Value = FechaEmision
                param_fechaEmision.Direction = ParameterDirection.Input

                ''fechaPago
                Dim param_fechaPago As New SqlClient.SqlParameter
                param_fechaPago.ParameterName = "@FechaPago"
                param_fechaPago.SqlDbType = SqlDbType.Date
                param_fechaPago.Value = FechaPago
                param_fechaPago.Direction = ParameterDirection.Input

                ''user
                Dim param_user As New SqlClient.SqlParameter
                param_user.ParameterName = "@user"
                param_user.SqlDbType = SqlDbType.Int
                param_user.Value = UserID
                param_user.Direction = ParameterDirection.Input

                ''res
                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.InputOutput


                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Update",
                                              param_id, param_fechaEmision, param_fechaPago,
                                              param_user, param_res)

                res = param_res.Value

                If (res <= 0) Then
                    tran.Rollback()
                    Return res
                End If
            Next

            If res >= 1 Then
                tran.Commit()
            Else
                tran.Rollback()
            End If

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            tran.Rollback()

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con Kaizen Software a través del correo soporte@kaizensoftware.com.ar", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If connection IsNot Nothing Then
            connection.Dispose()
        End If

        Return res
    End Function
#End Region

#Region "Eventos"
    Private Sub frmRtpCheques_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each cheque As DataRow In Cheques.Rows
            Dim row As dsSistema.PagosRow = dsSistema.Pagos.NewPagosRow
            row.Id = cheque(colsCheques.id)
            row.PagueseA = cheque(colsCheques.PagueseA)
            row.Monto = cheque(colsCheques.Monto)
            row.FechaPago = frmCheques.dtpPago.Value
            row.FechaEmision = frmCheques.dtpEmision.Value
            dsSistema.Pagos.AddPagosRow(row)
        Next

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_PrintingBegin(sender As Object, e As ReportPrintEventArgs) Handles ReportViewer1.PrintingBegin
        If UpdateFechas() < 1 Then
            MessageBox.Show("Se produjo un problema al procesar la información en la Base de Datos",
          "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        frmCheques.refreshData()
    End Sub

#End Region

End Class