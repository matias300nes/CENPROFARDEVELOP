Imports Microsoft.ApplicationBlocks.Data
Imports Utiles.Util

Public Class frmAgregarPagos
    Enum gridColumns
        idFarmacia = 0
        razonSocial = 1
        farmacia = 2
        tipoPago = 3
        importe = 4
        eliminar = 5
    End Enum

    'Enum FarmaciaCols
    '    ID = 0
    '    Seleccion = 1
    '    Codigo = 2
    '    RazonSocial = 3
    '    Nombre = 4
    '    PreferenciaPago = 5
    '    Saldo = 6
    '    Cuit = 7
    '    Telefono = 8
    '    Email = 9
    'End Enum

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
        Sociedad = 10
        PreferenciaPago = 11
        Saldo = 12
        Telefono = 13
        Email = 14
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
        dt.Columns.Add("IdFarmacia", GetType(Long))
        dt.Columns.Add("Razón Social", GetType(String))
        dt.Columns.Add("Farmacia", GetType(String))
        dt.Columns.Add("Tipo de pago", GetType(String))
        dt.Columns.Add("Importe", GetType(Decimal))

        With grdPagos
            grdPagos.DataSource = dt

            Dim btnColumn As New DataGridViewButtonColumn()
            .Columns.Add(btnColumn)
            btnColumn.HeaderText = "Eliminar"
            btnColumn.Text = "Eliminar"
            btnColumn.Name = "btnColumn"
            btnColumn.UseColumnTextForButtonValue = True

            .Columns(gridColumns.importe).DefaultCellStyle.Format = "N2"
            .Columns(gridColumns.idFarmacia).Visible = False
            '.Columns(gridColumns.razonSocial).Width = 180
            '.Columns(gridColumns.eliminar).Width = 70
            .AutoResizeColumns()
        End With

        With cmbFarmacia
            .DataSource = farmacias
            .ValueMember = farmacias.Columns(FarmaciaCols.ID).ColumnName
            .DisplayMember = farmacias.Columns(FarmaciaCols.Nombre).ColumnName
        End With

        cmbTipoPago.DataSource = {"Cheque", "Transferencia", "Echeq"}


        Dim saldototal As Decimal = 0
        For Each farmacia As DataRow In farmacias.Rows
            If farmacia(FarmaciaCols.Saldo) > 0 Then
                Dim newRow As DataRow = dt.NewRow
                newRow(gridColumns.razonSocial) = farmacia(FarmaciaCols.RazonSocial)
                newRow(gridColumns.farmacia) = farmacia(FarmaciaCols.Nombre)
                newRow(gridColumns.tipoPago) = farmacia(FarmaciaCols.PreferenciaPago)
                newRow(gridColumns.importe) = Decimal.Parse(farmacia(FarmaciaCols.Saldo))
                dt.Rows.Add(newRow)
                saldototal += Decimal.Parse(farmacia(FarmaciaCols.Saldo))
            End If
        Next

        If farmacias.Rows.Count > 1 Then
            lblRazonSocial.Text = $"{farmacias.Rows.Count} Seleccionadas"
            lblSaldoActual.Text = String.Format("{0:C}", saldototal)
        Else
            lblRazonSocial.Text = $"{Me.farmacias.Rows(0)(FarmaciaCols.RazonSocial)} - {Me.farmacias.Rows(0)(FarmaciaCols.Nombre)}"
            lblSaldoActual.Text = String.Format("{0:C}", Me.farmacias.Rows(0)(FarmaciaCols.Saldo))
            grdPagos.Columns(gridColumns.razonSocial).Visible = False
            cmbFarmacia.Enabled = False
        End If

        CalcularTotal()

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        If cmbFarmacia.SelectedValue Is Nothing Then
            MsgBox($"no se encontró la razón social {cmbFarmacia.Text}.")
            cmbFarmacia.SelectedIndex = 0
            cmbFarmacia.Focus()
            Exit Sub
        End If

        If txtImporte.Text = "" Then
            MsgBox($"El importe no puede estar vacio.")
            txtImporte.Focus()
            Exit Sub
        End If

        If Decimal.Parse(txtImporte.Text) < 0 Then
            MsgBox($"El importe debe ser positivo.")
            txtImporte.Focus()
            Exit Sub
        End If

        Dim newRow As DataRow = dt.NewRow
        newRow(gridColumns.idFarmacia) = cmbFarmacia.SelectedValue
        newRow(gridColumns.razonSocial) = cmbFarmacia.SelectedItem.Row(FarmaciaCols.RazonSocial)
        newRow(gridColumns.farmacia) = cmbFarmacia.SelectedItem.Row(FarmaciaCols.Nombre)
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

        btnListo.Enabled = IIf(total <= 0, False, True)
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
                param_idFarmacia.Value = pago(gridColumns.idFarmacia)
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

                If res = 1 Then
                    agregarRegistro(pago(gridColumns.idFarmacia), pago(gridColumns.tipoPago).ToString.ToUpper, pago(gridColumns.importe), pago(gridColumns.farmacia), pago(gridColumns.razonSocial))
                End If

                If (res <= 0) Then
                    tran.Rollback()
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

    Private Function agregarRegistro(ByVal idFarmacia As Long, ByVal tipopago As String, ByVal importe As Decimal, ByVal farmacia As String, ByVal razonSocial As String) As Integer
        Dim res As Integer = 0

        Dim connection As SqlClient.SqlConnection = Nothing
        connection = SqlHelper.GetConnection(ConnStringSEI)
        Dim tran As SqlClient.SqlTransaction = connection.BeginTransaction
        Dim sociedad As Boolean = cmbFarmacia.SelectedItem.Row(FarmaciaCols.Sociedad)
        Try

            ''ID
            Dim param_id As New SqlClient.SqlParameter
            param_id.ParameterName = "@id"
            param_id.SqlDbType = SqlDbType.BigInt
            param_id.Value = DBNull.Value
            param_id.Direction = ParameterDirection.InputOutput

            ''fecha emision
            Dim param_FechaEmision As New SqlClient.SqlParameter
            param_FechaEmision.ParameterName = "@fechaemision"
            param_FechaEmision.SqlDbType = SqlDbType.DateTime
            param_FechaEmision.Value = DBNull.Value
            param_FechaEmision.Direction = ParameterDirection.Input

            ''fecha pago
            Dim param_FechaPago As New SqlClient.SqlParameter
            param_FechaPago.ParameterName = "@fechapago"
            param_FechaPago.SqlDbType = SqlDbType.DateTime
            param_FechaPago.Value = DBNull.Value
            param_FechaPago.Direction = ParameterDirection.Input

            ''monto
            Dim param_monto As New SqlClient.SqlParameter
            param_monto.ParameterName = "@monto"
            param_monto.SqlDbType = SqlDbType.Decimal
            param_monto.Value = importe
            param_monto.Direction = ParameterDirection.Input

            ''paguese a
            Dim param_pagueseA As New SqlClient.SqlParameter
            param_pagueseA.ParameterName = "@pagueseA"
            param_pagueseA.SqlDbType = SqlDbType.VarChar
            param_pagueseA.Size = 100
            param_pagueseA.Value = IIf(sociedad = True, razonSocial, farmacia + " y/o " + razonSocial)
            param_pagueseA.Direction = ParameterDirection.Input

            ''IdFarmacia
            Dim param_idFarmacia As New SqlClient.SqlParameter
            param_idFarmacia.ParameterName = "@idFarmacia"
            param_idFarmacia.SqlDbType = SqlDbType.BigInt
            param_idFarmacia.Value = idFarmacia
            param_idFarmacia.Direction = ParameterDirection.Input

            ''tipo pago
            Dim param_Tipo As New SqlClient.SqlParameter
            param_Tipo.ParameterName = "@tipo"
            param_Tipo.SqlDbType = SqlDbType.VarChar
            param_Tipo.Size = 100
            param_Tipo.Value = tipopago
            param_Tipo.Direction = ParameterDirection.Input

            ''user
            Dim param_user As New SqlClient.SqlParameter
            param_user.ParameterName = "@useradd"
            param_user.SqlDbType = SqlDbType.Int
            param_user.Value = UserID
            param_user.Direction = ParameterDirection.Input

            ''res
            Dim param_res As New SqlClient.SqlParameter
            param_res.ParameterName = "@res"
            param_res.SqlDbType = SqlDbType.Int
            param_res.Value = DBNull.Value
            param_res.Direction = ParameterDirection.InputOutput


            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Insert",
                                          param_id, param_FechaEmision, param_FechaPago, param_monto, param_pagueseA,
                                          param_idFarmacia, param_Tipo, param_user, param_res)

            res = param_res.Value

            If (res <= 0) Then
                tran.Rollback()
                agregarRegistro = res
            End If


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

        agregarRegistro = res
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

    Private Sub grdPagos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPagos.CellContentClick
        If TypeOf grdPagos.Columns(e.ColumnIndex) Is DataGridViewButtonColumn And e.RowIndex > -1 Then
            grdPagos.Rows.RemoveAt(e.RowIndex)
            CalcularTotal()
        End If
    End Sub

    Private Sub cmbRazonSocial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFarmacia.SelectedIndexChanged
        Dim saldo As Decimal = cmbFarmacia.SelectedItem.Row(FarmaciaCols.Saldo)
        lblSaldoIndividual.Text = String.Format("{0:C}", saldo)
    End Sub

End Class