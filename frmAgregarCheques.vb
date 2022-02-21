Imports Microsoft.ApplicationBlocks.Data
Imports Utiles.Util

Public Class frmAgregarCheques
    Enum gridColumns
        razonSocial = 0
        tipoPago = 1
        importe = 2
    End Enum

    Enum FarmaciaCols
        ID = 0
        Seleccion = 1
        Codigo = 2
        RazonSocial = 3
        Nombre = 4
        PreferenciaPago = 5
        Saldo = 6
        Cuit = 7
        Telefono = 8
        Email = 9
    End Enum

    Dim farmacias As DataTable
    Dim dt As DataTable

    Public Sub New(farmacias As DataTable)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.farmacias = farmacias

    End Sub

    Private Sub frmAgregarCheques_Load(sender As Object, e As EventArgs) Handles Me.Load
        dt = New DataTable()
        dt.Columns.Add("Razón Social", GetType(String))
        dt.Columns.Add("Tipo de pago", GetType(String))
        dt.Columns.Add("Importe", GetType(Decimal))

        With grdPagos
            grdPagos.DataSource = dt

            .Columns(gridColumns.importe).DefaultCellStyle.Format = "N2"
        End With


        cmbTipoPago.DataSource = {"Cheque", "Transferencia", "Echeq"}

        If farmacias.Rows.Count > 1 Then
            Dim saldototal As Decimal = 0
            For Each farmacia As DataRow In farmacias.Rows
                Dim newRow As DataRow = dt.NewRow
                newRow(gridColumns.razonSocial) = farmacia(FarmaciaCols.RazonSocial)
                newRow(gridColumns.tipoPago) = farmacia(FarmaciaCols.PreferenciaPago)
                newRow(gridColumns.importe) = Decimal.Parse(farmacia(FarmaciaCols.Saldo))
                dt.Rows.Add(newRow)

                saldototal += Decimal.Parse(farmacia(FarmaciaCols.Saldo))
            Next
            lblRazonSocial.Text = $"{farmacias.Rows.Count} Seleccionadas"

            lblSaldoActual.Text = String.Format("{0:C}", saldototal)
        Else
            lblRazonSocial.Text = $"{Me.farmacias.Rows(0)(FarmaciaCols.RazonSocial)} - {Me.farmacias.Rows(0)(FarmaciaCols.Nombre)}"

            lblSaldoActual.Text = String.Format("{0:C}", Me.farmacias.Rows()(FarmaciaCols.Saldo))

        End If

        CalcularTotal()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim newRow As DataRow = dt.NewRow
        newRow(gridColumns.tipoPago) = cmbTipoPago.SelectedValue.ToString.ToUpper
        newRow(gridColumns.importe) = Decimal.Parse(txtImporte.Text)
        dt.Rows.Add(newRow)

        CalcularTotal()
    End Sub

    Private Sub CalcularTotal()
        Dim total As Decimal = 0
        Dim totalActual As Decimal = 0
        For Each pago As DataRow In dt.Rows
            total += pago(gridColumns.importe)
        Next

        For Each farmacia As DataRow In farmacias.Rows
            totalActual += farmacia(FarmaciaCols.Saldo)
        Next

        lblSaldoCubierto.Text = String.Format("{0:C}", total)
        If total < totalActual Then
            lblSaldoCubierto.ForeColor = Color.Red
        Else
            lblSaldoCubierto.ForeColor = Color.Green
        End If
    End Sub

    Private Function GenerarPago() As Integer
        Dim res As Integer = 0

        Dim connection As SqlClient.SqlConnection = Nothing
        connection = SqlHelper.GetConnection(ConnStringSEI)
        Dim tran As SqlClient.SqlTransaction = connection.BeginTransaction

        Try
            For Each pago As DataRow In dt.Rows
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
                param_idFarmacia.Value = Me.farmacias.Rows(0)(FarmaciaCols.ID)
                param_idFarmacia.Direction = ParameterDirection.Input

                ''detalle
                Dim param_detalle As New SqlClient.SqlParameter
                param_detalle.ParameterName = "@detalle"
                param_detalle.SqlDbType = SqlDbType.VarChar
                param_detalle.Size = 200
                param_detalle.Value = pago(gridColumns.tipoPago).ToString.ToUpper
                param_detalle.Direction = ParameterDirection.Input

                ''debito
                Dim param_debito As New SqlClient.SqlParameter
                param_debito.ParameterName = "@debito"
                param_debito.SqlDbType = SqlDbType.Decimal
                param_debito.Value = pago(gridColumns.importe)
                param_debito.Direction = ParameterDirection.Input

                ''credito
                Dim param_credito As New SqlClient.SqlParameter
                param_credito.ParameterName = "@credito"
                param_credito.SqlDbType = SqlDbType.Decimal
                param_credito.Value = DBNull.Value
                param_credito.Direction = ParameterDirection.Input

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

                res = param_res.Value

                If (res <= 0) Then
                    GenerarPago = res
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
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If connection IsNot Nothing Then
            connection.Dispose()
        End If

        GenerarPago = res
    End Function

    Private Sub btnListo_Click(sender As Object, e As EventArgs) Handles btnListo.Click
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
End Class