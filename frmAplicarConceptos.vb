Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Utiles.Util

Public Class frmAplicarConceptos
    Enum dtCols
        idConcepto = 0
        idFarmacia = 1
        Farmacia = 2
        RazonSocial = 3
        Concepto = 4
        Importe = 5
        Conceptopago = 6
        Frecuencia = 7
        MesesSinCobrar = 8
        FechaCobrado = 9
        DateAdd = 10
    End Enum

    Enum grdCols
        idConcepto = 0
        idFarmacia = 1
        Farmacia = 2
        RazonSocial = 3
        Concepto = 4
        Periodo = 5
        Tipo = 6
        Importe = 7
    End Enum

    Enum FarmaciaCols
        ID = 0
        Seleccion = 1
        Codigo = 2
        Nombre = 3
        IdRazonSocial = 4
        RazonSocial = 5
        Cuit = 6
        CBU = 7
        Banco = 8
        NroCta = 9
        PreferenciaPago = 10
        Saldo = 11
        Telefono = 12
        Email = 13
    End Enum

    Dim dtConceptos As DataTable
    Dim idquery As String ''filtrar farmacias por id


    Public Sub New(farmacias As DataTable)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each item As DataRow In farmacias.Rows
            Me.idquery += $"{item(FarmaciaCols.ID)},"
        Next
        Me.idquery = Me.idquery.Remove(idquery.Length - 1)

    End Sub
    Private Sub frmAplicarConceptos_Load(sender As Object, e As EventArgs) Handles Me.Load
        ''dtConceptos creation
        dtConceptos = New DataTable()
        dtConceptos.Columns.Add("idConcepto", GetType(Long))
        dtConceptos.Columns.Add("idFarmacia", GetType(Long))
        dtConceptos.Columns.Add("Farmacia", GetType(String))
        dtConceptos.Columns.Add("Razón social", GetType(String))
        dtConceptos.Columns.Add("Concepto", GetType(String))
        dtConceptos.Columns.Add("Período", GetType(String))
        dtConceptos.Columns.Add("Tipo", GetType(String))
        dtConceptos.Columns.Add("Importe", GetType(String))

        requestGrdData()
        setStyles()
        setCantidadItems()
    End Sub

    Private Sub requestGrdData()
        Dim dt As DataTable = New DataTable()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim sql As String = "exec spFarmacias_Conceptos_ACobrar"
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim cmd As New SqlCommand(sql, connection)
        Dim da As New SqlDataAdapter(cmd)

        da.Fill(dt)

        Dim dv As New DataView(dt)
        dv.RowFilter = $"{dt.Columns(dtCols.idFarmacia).ColumnName} IN({Me.idquery})"

        dt = dv.ToTable

        For Each item As DataRow In dt.rows
            For i As Integer = 1 To item(dtCols.MesesSinCobrar)
                Dim newrow As DataRow = dtConceptos.NewRow
                newrow(grdCols.idConcepto) = item(dtCols.idConcepto)
                newrow(grdCols.idFarmacia) = item(dtCols.idFarmacia)
                newrow(grdCols.RazonSocial) = item(dtCols.RazonSocial)
                newrow(grdCols.Farmacia) = item(dtCols.Farmacia)
                newrow(grdCols.Concepto) = item(dtCols.Concepto)
                newrow(grdCols.Tipo) = item(dtCols.Conceptopago)
                newrow(grdCols.Importe) = item(dtCols.Importe)

                ''newrow(grdCols.Periodo) = item(dtCols.FechaCobrado)
                Dim fecha As DateTime
                If item(dtCols.FechaCobrado) IsNot DBNull.Value Then
                    fecha = item(dtCols.FechaCobrado)
                    newrow(grdCols.Periodo) = fecha.AddMonths(i).ToString("MMMM").ToUpper
                Else
                    fecha = item(dtCols.DateAdd)
                    newrow(grdCols.Periodo) = fecha.AddMonths(i - 1).ToString("MMMM").ToUpper
                End If


                dtConceptos.Rows.Add(newrow)
            Next
        Next

        grdConceptos.DataSource = dtConceptos
    End Sub

    Private Sub setStyles()
        With grdConceptos

            ''ocultar columnas
            .Columns(grdCols.idFarmacia).Visible = False
            .Columns(grdCols.idConcepto).Visible = False

            ''cambiar width
            .Columns(grdCols.RazonSocial).Width = 180
            .Columns(grdCols.Concepto).Width = 180

            .AutoResizeColumns()
            '.Columns(grdFarmaciaCols.Saldo).DefaultCellStyle.Format = "c"
        End With

        'For Each column As DataGridViewColumn In grdHistorial.Columns
        '    column.SortMode = DataGridViewColumnSortMode.NotSortable
        'Next
    End Sub

    Private Function setCantidadItems()
        Dim cant As Integer = dtConceptos.Rows.Count
        lblCantidad.Text = IIf(cant > 0, $"Conceptos aplicables: {cant}", "No hay conceptos aplicables")
        btnAplicar.Enabled = IIf(cant > 0, True, False)
    End Function

    Private Function GenerarPago() As Integer
        Dim res1 As Integer = 0
        Dim res2 As Integer = 0
        Dim connection As SqlClient.SqlConnection = Nothing
        connection = SqlHelper.GetConnection(ConnStringSEI)
        Dim tran As SqlClient.SqlTransaction = connection.BeginTransaction

        Try
            For Each concepto As DataRow In dtConceptos.Rows
                ''ID
                Dim param_id As New SqlClient.SqlParameter
                param_id.ParameterName = "@id"
                param_id.SqlDbType = SqlDbType.BigInt
                param_id.Value = DBNull.Value
                param_id.Direction = ParameterDirection.InputOutput

                ''IdFarmacia
                Dim param_idFarmacia As New SqlClient.SqlParameter
                param_idFarmacia.ParameterName = "@idFarmacia"
                param_idFarmacia.SqlDbType = SqlDbType.BigInt
                param_idFarmacia.Value = concepto(grdCols.idFarmacia)
                param_idFarmacia.Direction = ParameterDirection.Input

                ''IdConcepto
                Dim param_idConcepto As New SqlClient.SqlParameter
                param_idConcepto.ParameterName = "@idConcepto"
                param_idConcepto.SqlDbType = SqlDbType.BigInt
                param_idConcepto.Value = concepto(grdCols.idConcepto)
                param_idConcepto.Direction = ParameterDirection.Input

                ''detalle
                Dim param_detalle As New SqlClient.SqlParameter
                param_detalle.ParameterName = "@detalle"
                param_detalle.SqlDbType = SqlDbType.VarChar
                param_detalle.Size = 200
                param_detalle.Value = $"{concepto(grdCols.Concepto)} - {concepto(grdCols.Periodo)}".ToUpper
                param_detalle.Direction = ParameterDirection.Input

                ''debito
                Dim param_debito As New SqlClient.SqlParameter
                param_debito.ParameterName = "@debito"
                param_debito.SqlDbType = SqlDbType.Decimal
                param_debito.Value = concepto(grdCols.Importe)
                param_debito.Direction = ParameterDirection.Input

                ''credito
                Dim param_credito As New SqlClient.SqlParameter
                param_credito.ParameterName = "@credito"
                param_credito.SqlDbType = SqlDbType.Decimal
                param_credito.Value = DBNull.Value
                param_credito.Direction = ParameterDirection.Input

                ''valor segun credito/debito
                If concepto(grdCols.Tipo) = "DÉBITO" Then
                    param_debito.Value = concepto(grdCols.Importe)
                    param_credito.Value = DBNull.Value

                End If
                If concepto(grdCols.Tipo) = "CRÉDITO" Then
                    param_credito.Value = concepto(grdCols.Importe)
                    param_debito.Value = DBNull.Value
                End If

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


                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spHistorialCta_Insert",
                                              param_id, param_idFarmacia, param_detalle, param_debito, param_credito,
                                              param_user, param_res)

                res1 = param_res.Value

                If (res1 <= 0) Then
                    tran.Rollback()
                    GenerarPago = res1
                End If

                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spFarmacias_Conceptos_UpdFechaCobrado",
                                              param_idConcepto, param_idFarmacia, param_res)

                res2 = param_res.Value

                If (res2 <= 0) Then
                    tran.Rollback()
                    GenerarPago = res2
                End If
            Next

            If res1 >= 1 And res2 >= 1 Then
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

        If res1 <= 0 Then
            GenerarPago = res1
        End If
        If res2 <= 0 Then
            GenerarPago = res2
        End If
        GenerarPago = res1
    End Function

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        Dim res As Integer
        res = GenerarPago()
        If res >= 1 Then
            Me.Dispose()
            Me.Close()

            frmSaldos.refreshData()
        Else
            MessageBox.Show("Se produjo un problema al procesar la información en la Base de Datos",
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class