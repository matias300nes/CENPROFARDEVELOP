Imports Microsoft.ApplicationBlocks.Data
Imports Utiles
Imports Utiles.Util
Imports System.Data.SqlClient
Imports ReportesNet


Public Class frmPagodeGastos

    Dim bolpoliticas As Boolean

    Dim RemitosAsociados As String

    'Variables para la grilla
    Dim editando_celda As Boolean
    Dim FILA As Integer
    Dim COLUMNA As Integer
    Private RefrescarGrid As Boolean
    Private ds_2 As DataSet

    'Para el clic derecho sobre la grilla de materiales
    Dim Cell_X As Integer
    Dim Cell_Y As Integer

    'Para el combo de busqueda
    Dim ID_Buscado As Long
    Dim Nombre_Buscado As Long

    'Varible de transaccion
    Dim tran As SqlClient.SqlTransaction
    Dim conn_del_form As SqlClient.SqlConnection = Nothing

    Dim band As Integer, bandIVA As Boolean
    'BANDIVA SE UTILIZA PARA SABER SI EXISTEN VARIOS PORCENTAJES DE IVA DIFERENTES EN EL PAGO

    Dim IVA As Double, MontoChequesTerceros As Double = 0, MontoChequesPropios As Double = 0

    'constantes para identificar las columnas de la grilla por nombre 
    ' en vez de n�mero
    Enum ColumnasDelGridItems
        IdPresGes = 0
        Cod_Material = 1
        Nombre_Material = 2
        PrecioUni = 3
        Subtotal = 4
    End Enum

    Enum ColumnasDelGridGastos
        Id = 0
        NroFactura = 1
        FechaFactura = 2
        MontoIva = 4
        Subtotal = 3
        Total = 5
        Seleccionar = 6
        Deuda = 7
    End Enum

    Enum ColumnasDelGridCheques
        Id = 0
        Seleccionar = 1
        NroCheque = 2
        MontoCheque = 3
        FechaCobro = 4
        Banco = 5
        Cliente = 6
        Observaciones = 7
    End Enum

    'Enum ColumnasDelGridCheques_PropiosChequera
    '    Id = 0
    '    Seleccionar = 1
    '    NroCheque = 2
    '    'MontoCheque = 3
    '    'FechaCobro = 4
    '    Banco = 3
    '    'Observaciones = 6
    'End Enum

    Enum ColumnasDelGridChequesPropios
        Id = 0
        Seleccionar = 1
        NroCheque = 2
        MontoCheque = 3
        FechaCobro = 4
        Banco = 5
        Observaciones = 6
    End Enum

    'Auxiliares para guardar
    Dim cod_aux As String

    'Auxiliares para chequear lo digitado en la columna cantidad
    Dim qty_digitada As String

    Dim permitir_evento_CellChanged As Boolean


#Region "   Eventos"

    'Private Sub frmFacturacion_ev_CellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ev_CellChanged
    '    If permitir_evento_CellChanged Then
    '        If txtID.Text <> "" Then
    '            LlenarGridGastos(CType(cmbProveedor.SelectedValue, Long))
    '        End If
    '    End If
    'End Sub

    Private Sub frmFacturacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3 'nuevo
                If bolModo = True Then
                    If MessageBox.Show("No ha guardado la Factura Nueva que est� realizando. �Est� seguro que desea continuar sin Grabar y hacer una Nueva Factura?", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        btnNuevo_Click(sender, e)
                    End If
                Else
                    btnNuevo_Click(sender, e)
                End If
            Case Keys.F4 'grabar
                btnGuardar_Click(sender, e)
        End Select
    End Sub

    Private Sub frmFacturacion_Gestion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        btnEliminar.Text = "Anular Pago"

        band = 0
        configurarform()
        asignarTags()

        LlenarComboProveedores()
        'LlenarComboImpuestos()
        LlenarComboBancos()
        LlenarComboCuentasOrigen()

        SQL = "exec spPagos_Select_All @Eliminado = 0"

        LlenarGrilla()

        Permitir = True

        CargarCajas()

        PrepararBotones()

        'Setear_Grilla()

        If bolModo = True Then
            LlenarGridGastos(CType(cmbProveedores.SelectedValue, Long))
            btnNuevo_Click(sender, e)
        Else
            AgregarRemito_tmp()
            LlenarGridGastos(CType(grd.CurrentRow.Cells(15).Value, Long))
            grdFacturasConsumos.Columns(ColumnasDelGridGastos.Seleccionar).Visible = False
        End If

        txtProveedor.Visible = Not bolModo

        permitir_evento_CellChanged = True

        grd.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grd.Columns(15).Visible = False
        'grd.Columns(20).Visible = False

        permitir_evento_CellChanged = True

        grd_CurrentCellChanged(sender, e)

        dtpFECHA.MaxDate = Today.Date
        'dtpFechaCheque.MaxDate = Today.Date
        dtpFechaTransf.MaxDate = Today.Date

        band = 1
    End Sub

    'Private Sub txtID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtID.TextChanged
    '    If txtID.Text <> "" And bolModo = False Then
    '        'LlenarGridFacturas(CType(cmbCliente.SelectedValue, Long))
    '        LlenarGridGastos(CType(grd.CurrentRow.Cells(15).Value, Long))
    '    End If
    'End Sub

    Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txtCODIGO.KeyPress, _
         txtNroOpCliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txtMontoTransf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoTransf.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnAgregarTransf.Focus()
        End If
    End Sub

    Private Sub dtpfecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFECHA.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub grdRemitos_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdFacturasConsumos.CellMouseUp
        Cell_X = e.ColumnIndex
        Cell_Y = e.RowIndex
    End Sub

    Private Sub grdCheques_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Cell_X = e.ColumnIndex
        Cell_Y = e.RowIndex
    End Sub

    Private Sub cmbProveedores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProveedores.SelectedIndexChanged
        If band = 1 Then
            If cmbProveedores.Text <> "" Then
                txtIdProveedor.Text = cmbProveedores.SelectedValue
                LlenarGridGastos(CType(cmbProveedores.SelectedValue, Long))
                lblTotalaPagarSinIva.Text = "0"
                lblTotalaPagar.Text = "0"
                lblTotal.Text = "0"

                lblIVA.Text = "0"
                lblSubtotal.Text = "0"
            End If
        End If
    End Sub

    Private Sub grdFacturasConsumos_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFacturasConsumos.CurrentCellDirtyStateChanged
        If grdFacturasConsumos.IsCurrentCellDirty Then
            grdFacturasConsumos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub grdChequesTerceros_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdChequesTerceros.CurrentCellDirtyStateChanged
        If grdChequesTerceros.IsCurrentCellDirty Then
            grdChequesTerceros.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub grdChequesPropios_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdChequesPropios.CurrentCellDirtyStateChanged
        If grdChequesPropios.IsCurrentCellDirty Then
            grdChequesPropios.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub grdRemitos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFacturasConsumos.CellValueChanged
        Try

            If e.ColumnIndex = ColumnasDelGridGastos.Seleccionar Then

                AgregarRemito_tmp()

            End If

        Catch ex As Exception
            MsgBox("Error en Sub grdRemitos_CellClick", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub grdChequesTerceros_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdChequesTerceros.CellValueChanged
        Try

            If e.ColumnIndex = ColumnasDelGridCheques.Seleccionar Then
                Dim i As Integer
                'lblEntregaCheques.Text = "0"
                'Dim subtotal As Double = 0
                MontoChequesTerceros = 0

                For i = 0 To grdChequesTerceros.RowCount - 1

                    If CBool(grdChequesTerceros.Rows(i).Cells(ColumnasDelGridCheques.Seleccionar).Value) = True Then

                        MontoChequesTerceros = MontoChequesTerceros + grdChequesTerceros.Rows(i).Cells(ColumnasDelGridCheques.MontoCheque).Value

                        'Else
                        'If bolModo = False Then
                        ' subtotal = subtotal + grdCheques.Rows(i).Cells(ColumnasDelGridCheques.MontoCheque).Value
                        'End If
                    End If

                Next

                lblEntregaCheques.Text = MontoChequesPropios + MontoChequesTerceros  'subtotal.ToString

                Calcular_MontoEntregado()

            End If

        Catch ex As Exception
            MsgBox("Error en Sub Cheques Terceros Cell Click", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub grdChequesPropios_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdChequesPropios.CellValueChanged
        Try

            If e.ColumnIndex = ColumnasDelGridChequesPropios.Seleccionar Then
                Dim i As Integer
                'lblEntregaCheques.Text = "0"
                'Dim subtotal As Double = 0
                ' Dim MontoCheque As Double = 0

                MontoChequesPropios = 0

                For i = 0 To grdChequesPropios.RowCount - 1

                    If CBool(grdChequesPropios.Rows(i).Cells(ColumnasDelGridChequesPropios.Seleccionar).Value) = True Then

                        'If grdChequesPropios.Rows(i).Cells(ColumnasDelGridChequesPropios.MontoCheque).Value = "" Then
                        '    MontoCheque = 0
                        'End If

                        If grdChequesPropios.CurrentRow.Cells(ColumnasDelGridChequesPropios.MontoCheque).Value Is DBNull.Value Or _
                            grdChequesPropios.CurrentRow.Cells(ColumnasDelGridChequesPropios.MontoCheque).Value = Nothing Then
                            grdChequesPropios.CurrentRow.Cells(ColumnasDelGridChequesPropios.MontoCheque).Value = 0
                        End If

                        MontoChequesPropios = MontoChequesPropios + grdChequesPropios.Rows(i).Cells(ColumnasDelGridChequesPropios.MontoCheque).Value

                        'Else
                        'If bolModo = False Then
                        ' subtotal = subtotal + grdCheques.Rows(i).Cells(ColumnasDelGridCheques.MontoCheque).Value
                        'End If
                    End If

                Next

                lblEntregaCheques.Text = MontoChequesPropios + MontoChequesTerceros 'subtotal.ToString

                Calcular_MontoEntregado()

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("Error en Sub grdCheques_CellClick", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub grdChequesPropios_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grdChequesPropios.CellEndEdit
        Try
            If e.ColumnIndex = ColumnasDelGridChequesPropios.MontoCheque Then
                If grdChequesPropios.CurrentRow.Cells(ColumnasDelGridChequesPropios.MontoCheque).Value Is DBNull.Value Or _
                    grdChequesPropios.CurrentRow.Cells(ColumnasDelGridChequesPropios.MontoCheque).Value = Nothing Then
                    grdChequesPropios.CurrentRow.Cells(ColumnasDelGridChequesPropios.MontoCheque).Value = 0
                End If

                Dim i As Integer
                'lblEntregaCheques.Text = "0"
                'Dim subtotal As Double = 0
                'Dim MontoCheque As Double = 0

                MontoChequesPropios = 0

                For i = 0 To grdChequesPropios.RowCount - 1

                    If CBool(grdChequesPropios.Rows(i).Cells(ColumnasDelGridChequesPropios.Seleccionar).Value) = True Then

                        If grdChequesPropios.CurrentRow.Cells(ColumnasDelGridChequesPropios.MontoCheque).Value Is DBNull.Value Or _
                           grdChequesPropios.CurrentRow.Cells(ColumnasDelGridChequesPropios.MontoCheque).Value = Nothing Then
                            grdChequesPropios.CurrentRow.Cells(ColumnasDelGridChequesPropios.MontoCheque).Value = 0
                        End If

                        MontoChequesPropios = MontoChequesPropios + grdChequesPropios.Rows(i).Cells(ColumnasDelGridChequesPropios.MontoCheque).Value

                        'Else
                        'If bolModo = False Then
                        ' subtotal = subtotal + grdCheques.Rows(i).Cells(ColumnasDelGridCheques.MontoCheque).Value
                        'End If
                    End If

                Next

                lblEntregaCheques.Text = MontoChequesPropios + MontoChequesTerceros 'subtotal.ToString

                Calcular_MontoEntregado()

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Calcular_MontoEntregado()

        Dim redondeo As Double = 0

        Try
            redondeo = CDbl(IIf(txtRedondeo.Text = "", 0, txtRedondeo.Text))

            lblEntregado.Text = CDbl(IIf(txtEntregaContado.Text = "", 0, txtEntregaContado.Text)) + CDbl(IIf(lblEntregaCheques.Text = "", 0, lblEntregaCheques.Text)) + CDbl(IIf(lblEntregaTransferencias.Text = "", 0, lblEntregaTransferencias.Text)) + CDbl(IIf(lblEntregaChequesPropios.Text = "", 0, lblEntregaChequesPropios.Text)) + redondeo

        Catch ex As Exception

        End Try

        If band = 1 Then

            lblResto.Text = Math.Round(CDbl(lblTotalaPagar.Text) - CDbl(lblEntregado.Text), 2)

            If CDec(lblEntregado.Text) > CDec(lblTotalaPagar.Text) Then
                Util.MsgStatus(Status1, "Verifique el �ltimo Monto ingresado. El monto Total Entregado ahora es mayor al monto Total a Pagar.", My.Resources.Resources.stop_error.ToBitmap)
            Else
                Util.MsgStatus(Status1, "Pago verificado. Los montos coinciden.", My.Resources.Resources.ok.ToBitmap)
            End If
        End If

    End Sub

    Private Sub txtEntregaContado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEntregaContado.TextChanged
        If band = 1 Then
            Calcular_MontoEntregado()
        End If
    End Sub

    Private Sub txtRedondeo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRedondeo.TextChanged
        If band = 1 Then
            Calcular_MontoEntregado()
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        'If TabControl1.SelectedTab.Name Is "TabChequesPropios" Then
        '    txtNroCheque.Focus()
        'End If
        If TabControl1.SelectedTab.Name Is "TabTransferencias" Then
            txtNroOpCliente.Focus()
        End If
        'modificar = 0
    End Sub

    Protected Overloads Sub grd_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.CurrentCellChanged
        If Permitir Then

            LimpiarGrids()

            If bolModo = False Then
                Try
                    txtIdProveedor.Text = grd.CurrentRow.Cells(20).Value
                    LlenarGridGastos(CType(grd.CurrentRow.Cells(15).Value, Long))
                    'LlenarGridGastos(CType(cmbProveedor.SelectedValue, Long))
                Catch ex As Exception
                    ' MsgBox(ex.Message)
                End Try
            End If

            AgregarRemito_tmp()

            'MontoChequesPropios = 0
            'MontoChequesTerceros = 0

            'Dim i As Integer

            'For i = 0 To grdChequesPropios.RowCount - 1

            '    If CBool(grdChequesPropios.Rows(i).Cells(ColumnasDelGridChequesPropios.Seleccionar).Value) = True Then

            '        MontoChequesPropios = MontoChequesPropios + grdChequesPropios.CurrentRow.Cells(ColumnasDelGridChequesPropios.MontoCheque).Value

            '    End If

            'Next

            'For i = 0 To grdChequesTerceros.RowCount - 1

            '    If CBool(grdChequesTerceros.Rows(i).Cells(ColumnasDelGridChequesPropios.Seleccionar).Value) = True Then

            '        MontoChequesTerceros = MontoChequesTerceros + grdChequesTerceros.CurrentRow.Cells(ColumnasDelGridCheques.MontoCheque).Value

            '    End If

            'Next

            LlenarGridCheques_Propios()
            LlenarGridCheques_Terceros()

            LlenarGrid_Transferencias()

            Calcular_MontoEntregado()

        End If
    End Sub

    'Private Sub txtMontoCheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        e.Handled = True
    '        btnAgregarCheque.Focus()
    '    End If
    'End Sub

    Private Sub chkAnulados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAnulados.CheckedChanged
        btnGuardar.Enabled = Not chkAnulados.Checked
        btnEliminar.Enabled = Not chkAnulados.Checked
        btnNuevo.Enabled = Not chkAnulados.Checked
        btnCancelar.Enabled = Not chkAnulados.Checked

        If chkAnulados.Checked = True Then
            SQL = "exec spPagos_Select_All @Eliminado = 1"
        Else
            SQL = "exec spPagos_Select_All @Eliminado = 0"
        End If

        LlenarGrilla()

    End Sub

#End Region

#Region "   Procedimientos"

    Private Sub configurarform()
        Me.Text = "Pagos a Proveedores"

        Me.grd.Location = New Size(GroupBox1.Location.X, GroupBox1.Location.Y + GroupBox1.Size.Height + 7)
        'Dim p As New Size(GroupBox1.Size.Width, 300) 'AltoMinimoGrilla)
        'Me.grd.Size = New Size(p)

        'Me.Size = New Size(IIf(Me.Size.Width <= AnchoMinimoForm, AnchoMinimoForm, Me.Size.Width), Me.grd.Location.Y + Me.grd.Size.Height + 65)

        If LLAMADO_POR_FORMULARIO Then
            LLAMADO_POR_FORMULARIO = False
            Me.Top = ARRIBA
            Me.Left = IZQUIERDA
        Else
            Me.Top = 0
            Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2
        End If

        Me.WindowState = FormWindowState.Maximized

        Me.grd.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width - 27, Me.Size.Height - 7 - GroupBox1.Size.Height - GroupBox1.Location.Y - 65)

    End Sub

    Private Sub asignarTags()
        txtID.Tag = "0"
        txtCODIGO.Tag = "1"
        dtpFECHA.Tag = "2"
        cmbProveedores.Tag = "3"
        txtProveedor.Tag = "3"
        lblSubtotal.Tag = "4"
        lblIVA.Tag = "5"
        lblTotal.Tag = "6"
        lblTotalaPagarSinIva.Tag = "4"
        lblTotalaPagar.Tag = "6"
        txtEntregaContado.Tag = "8"
        lblEntregaCheques.Tag = "18"
        lblEntregaChequesPropios.Tag = "19"
        lblEntregaTransferencias.Tag = "12"
        lblEntregaTarjetas.Tag = "14"
        txtRedondeo.Tag = "16"
        txtNota.Tag = "17"
    End Sub

    Private Sub Verificar_Datos()

        bolpoliticas = False

        Util.MsgStatus(Status1, "Verificando los datos...", My.Resources.Resources.indicator_white)

        Dim i As Integer
        Dim unremito As Boolean = False

        For i = 0 To grdFacturasConsumos.RowCount - 1
            If CBool(grdFacturasConsumos.Rows(i).Cells(ColumnasDelGridGastos.Seleccionar).Value) = True Then
                unremito = True
            End If
        Next

        If unremito = False And bolModo = True Then
            Util.MsgStatus(Status1, "Seleccione al menos un remito para facturar.", My.Resources.Resources.alert.ToBitmap)
            Util.MsgStatus(Status1, "Seleccione al menos un remito para facturar.", My.Resources.Resources.alert.ToBitmap, True)
            Exit Sub
        End If

        If lblTotal.Text = "0" Or lblTotal.Text = "" Then
            Util.MsgStatus(Status1, "Debe ingresar el monto de cancelaci�n para el pago actual.", My.Resources.Resources.alert.ToBitmap)
            Util.MsgStatus(Status1, "Debe ingresar el monto de cancelaci�n para el pago actual.", My.Resources.Resources.alert.ToBitmap, True)
            Exit Sub
        End If

        bolpoliticas = True

    End Sub

    Private Sub Cerrar_Tran()
        'Cierra o finaliza la transaccion
        If Not (tran Is Nothing) Then
            tran.Commit()
            tran.Dispose()
            tran = Nothing
        End If
    End Sub

    Private Sub Cancelar_Tran()
        'Cancela la transaccion
        If Not (tran Is Nothing) Then
            tran.Rollback()
            tran.Dispose()
            tran = Nothing
        End If
    End Sub


    Private Sub LlenarGridGastos(ByVal IdProveedor As Long)

        SQL = "exec spPagos_Gastos @IdProveedor = " & IdProveedor & ", @modo = " & bolModo & ", @IdPago = " & IIf(txtID.Text = "", 0, txtID.Text)

        GetDatasetItems(grdFacturasConsumos)

        grdFacturasConsumos.Columns(ColumnasDelGridGastos.Id).Visible = False

        grdFacturasConsumos.Columns(ColumnasDelGridGastos.NroFactura).Width = 100
        grdFacturasConsumos.Columns(ColumnasDelGridGastos.NroFactura).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdFacturasConsumos.Columns(ColumnasDelGridGastos.FechaFactura).Width = 68
        grdFacturasConsumos.Columns(ColumnasDelGridGastos.FechaFactura).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grdFacturasConsumos.Columns(ColumnasDelGridGastos.MontoIva).Width = 75
        grdFacturasConsumos.Columns(ColumnasDelGridGastos.MontoIva).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdFacturasConsumos.Columns(ColumnasDelGridGastos.Subtotal).Width = 75
        grdFacturasConsumos.Columns(ColumnasDelGridGastos.Subtotal).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdFacturasConsumos.Columns(ColumnasDelGridGastos.Total).Width = 75
        grdFacturasConsumos.Columns(ColumnasDelGridGastos.Total).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdFacturasConsumos.Columns(ColumnasDelGridGastos.Seleccionar).Width = 58

        grdFacturasConsumos.Columns(ColumnasDelGridGastos.Deuda).Width = 70
        grdFacturasConsumos.Columns(ColumnasDelGridGastos.Deuda).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        With grdFacturasConsumos
            .VirtualMode = False
            .AllowUserToAddRows = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .RowsDefaultCellStyle.BackColor = Color.White
            .AllowUserToOrderColumns = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .ForeColor = Color.Black
        End With

        With grdFacturasConsumos.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Black  'Color.BlueViolet
            .ForeColor = Color.White
            .Font = New Font("TAHOMA", 8, FontStyle.Bold)
        End With

        grdFacturasConsumos.Font = New Font("TAHOMA", 8, FontStyle.Regular)

        'LlenarGridCheques()
        'LlenarGrid_Cheques_Propios()

        SQL = "spPagos_Select_All @Eliminado = 0"

    End Sub

    Private Sub LlenarGridCheques_Terceros()

        SQL = "exec spPagos_Cheques_Select_All @modo = " & bolModo & ", @IdPago = " & IIf(txtID.Text = "", 0, txtID.Text)

        GetDatasetItems(grdChequesTerceros)

        grdChequesTerceros.Columns(ColumnasDelGridCheques.Id).Visible = False

        grdChequesTerceros.Columns(ColumnasDelGridCheques.NroCheque).Width = 80
        grdChequesTerceros.Columns(ColumnasDelGridCheques.NroCheque).ReadOnly = True
        grdChequesTerceros.Columns(ColumnasDelGridCheques.NroCheque).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdChequesTerceros.Columns(ColumnasDelGridCheques.MontoCheque).Width = 75
        grdChequesTerceros.Columns(ColumnasDelGridCheques.MontoCheque).ReadOnly = True
        grdChequesTerceros.Columns(ColumnasDelGridCheques.MontoCheque).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdChequesTerceros.Columns(ColumnasDelGridCheques.FechaCobro).Width = 75
        grdChequesTerceros.Columns(ColumnasDelGridCheques.FechaCobro).ReadOnly = True
        grdChequesTerceros.Columns(ColumnasDelGridCheques.FechaCobro).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grdChequesTerceros.Columns(ColumnasDelGridCheques.Banco).Width = 80
        grdChequesTerceros.Columns(ColumnasDelGridCheques.Banco).ReadOnly = True

        grdChequesTerceros.Columns(ColumnasDelGridCheques.Cliente).Width = 80
        grdChequesTerceros.Columns(ColumnasDelGridCheques.Cliente).ReadOnly = True

        grdChequesTerceros.Columns(ColumnasDelGridCheques.Observaciones).Width = 80
        grdChequesTerceros.Columns(ColumnasDelGridCheques.Observaciones).ReadOnly = True

        grdChequesTerceros.Columns(ColumnasDelGridCheques.Seleccionar).Width = 80
        'grdCheques.Columns(ColumnasDelGridCheques.Seleccionar).Visible = bolModo
        'grdCheques.Columns(ColumnasDelGridCheques.Seleccionar).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        With grdChequesTerceros
            .VirtualMode = False
            .AllowUserToAddRows = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .RowsDefaultCellStyle.BackColor = Color.White
            .AllowUserToOrderColumns = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .ForeColor = Color.Black
        End With

        With grdChequesTerceros.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Black  'Color.BlueViolet
            .ForeColor = Color.White
            .Font = New Font("TAHOMA", 8, FontStyle.Bold)
        End With

        grdChequesTerceros.Font = New Font("TAHOMA", 8, FontStyle.Regular)

        SQL = "spPagos_Select_All @Eliminado = 0"

    End Sub

    Private Sub LlenarGridCheques_Propios()

        SQL = "exec spPagos_Cheques_Propios_Select_All  @modo = " & bolModo & ", @IdPago = " & IIf(txtID.Text = "", 0, txtID.Text)

        GetDatasetItems(grdChequesPropios)

        grdChequesPropios.Columns(ColumnasDelGridChequesPropios.Id).Visible = False

        grdChequesPropios.Columns(ColumnasDelGridChequesPropios.NroCheque).Width = 80
        grdChequesPropios.Columns(ColumnasDelGridChequesPropios.NroCheque).ReadOnly = True
        grdChequesPropios.Columns(ColumnasDelGridChequesPropios.NroCheque).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdChequesPropios.Columns(ColumnasDelGridChequesPropios.MontoCheque).Width = 75
        grdChequesPropios.Columns(ColumnasDelGridChequesPropios.MontoCheque).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdChequesPropios.Columns(ColumnasDelGridChequesPropios.FechaCobro).Width = 75
        grdChequesPropios.Columns(ColumnasDelGridChequesPropios.FechaCobro).DefaultCellStyle.Format = "dd/MM/yyyy"

        grdChequesPropios.Columns(ColumnasDelGridChequesPropios.Banco).Width = 80
        grdChequesPropios.Columns(ColumnasDelGridChequesPropios.Banco).ReadOnly = True

        'grdChequesPropios2.Columns(ColumnasDelGridCheques.Cliente).Width = 80

        grdChequesPropios.Columns(ColumnasDelGridChequesPropios.Seleccionar).Width = 80
        'grdCheques.Columns(ColumnasDelGridCheques.Seleccionar).Visible = bolModo
        'grdCheques.Columns(ColumnasDelGridCheques.Seleccionar).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        With grdChequesPropios
            .VirtualMode = False
            .AllowUserToAddRows = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .RowsDefaultCellStyle.BackColor = Color.White
            .AllowUserToOrderColumns = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .ForeColor = Color.Black
            .MultiSelect = False
        End With

        With grdChequesPropios.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Black  'Color.BlueViolet
            .ForeColor = Color.White
            .Font = New Font("TAHOMA", 8, FontStyle.Bold)
        End With

        grdChequesPropios.Font = New Font("TAHOMA", 8, FontStyle.Regular)

        SQL = "spPagos_Select_All @Eliminado = 0"

    End Sub

    Private Sub GetDatasetItems(ByVal grdchico As DataGridView)
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            ds_2 = SqlHelper.ExecuteDataset(connection, CommandType.Text, SQL)
            ds_2.Dispose()

            grdchico.DataSource = ds_2.Tables(0).DefaultView

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Sub

    Private Sub LlenarComboProveedores()
        Dim ds_Cli As Data.DataSet
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            'VERSION PARA CONTROLAR, USA EN TODOS LADOS EL C�DIGO
            ds_Cli = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT DISTINCT CONVERT(BIGINT, p.Codigo) AS Codigo, ltrim(rtrim(p.nombre)) as Nombre FROM Gastos g " & _
                                                                     " JOIN Proveedores p ON p.codigo = g.IdProveedor WHERE cancelado = 0 and g.eliminado = 0 order by ltrim(rtrim(p.nombre))")

            ds_Cli.Dispose()

            With Me.cmbProveedores
                .DataSource = ds_Cli.Tables(0).DefaultView
                .DisplayMember = "nombre"
                .ValueMember = "codigo"
            End With

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Sub

    'Private Sub LlenarComboImpuestos()
    '    Dim ds_Impuestos As Data.DataSet
    '    Dim connection As SqlClient.SqlConnection = Nothing

    '    Try
    '        connection = SqlHelper.GetConnection(ConnStringSEI)
    '    Catch ex As Exception
    '        MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Sub
    '    End Try

    '    Try
    '        ds_Impuestos = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT ID, CODIGO from Impuestos where eliminado=0 order by codigo")
    '        ds_Impuestos.Dispose()

    '        With Me.cmbImpuesto
    '            .DataSource = ds_Impuestos.Tables(0).DefaultView
    '            .DisplayMember = "codigo"
    '            .ValueMember = "id"
    '            '.AutoCompleteMode = AutoCompleteMode.Suggest
    '            '.AutoCompleteSource = AutoCompleteSource.ListItems
    '            '.DropDownStyle = ComboBoxStyle.DropDown
    '        End With

    '    Catch ex As Exception
    '        Dim errMessage As String = ""
    '        Dim tempException As Exception = ex

    '        While (Not tempException Is Nothing)
    '            errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
    '            tempException = tempException.InnerException
    '        End While

    '        MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
    '          + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
    '          "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        If Not connection Is Nothing Then
    '            CType(connection, IDisposable).Dispose()
    '        End If
    '    End Try

    'End Sub

    Private Sub LlenarComboBancos()
        'Dim ds_Bancos As Data.DataSet
        Dim ds_Bancos_Origen As Data.DataSet
        Dim ds_Bancos_Destino As Data.DataSet

        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            'ds_Bancos = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT * FROM (SELECT UPPER(Banco) as Banco FROM CHEQUES UNION SELECT UPPER(BancoOrigen) as Banco FROM TransferenciaBancaria " & _
            '                                        " UNION SELECT UPPER(BancoDestino) as Banco  FROM TransferenciaBancaria ) A ORDER BY Banco")
            'ds_Bancos.Dispose()

            ds_Bancos_Origen = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT * FROM (SELECT UPPER(Banco) as Banco FROM CHEQUES UNION SELECT UPPER(BancoOrigen) as Banco FROM TransferenciaBancaria " & _
                                                    " UNION SELECT UPPER(BancoDestino) as Banco  FROM TransferenciaBancaria ) A ORDER BY Banco")
            ds_Bancos_Origen.Dispose()

            ds_Bancos_Destino = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT * FROM (SELECT UPPER(Banco) as Banco FROM CHEQUES UNION SELECT UPPER(BancoOrigen) as Banco FROM TransferenciaBancaria " & _
                                                                " UNION SELECT UPPER(BancoDestino) as Banco  FROM TransferenciaBancaria ) A ORDER BY Banco")
            ds_Bancos_Destino.Dispose()

            'With Me.cmbBanco
            '    .DataSource = ds_Bancos.Tables(0).DefaultView
            '    .DisplayMember = "Banco"
            '    .ValueMember = "Banco"
            'End With

            With Me.cmbBancoDestino
                .DataSource = ds_Bancos_Destino.Tables(0).DefaultView
                .DisplayMember = "Banco"
                .ValueMember = "Banco"
            End With

            With Me.cmbBancoOrigen
                .DataSource = ds_Bancos_Origen.Tables(0).DefaultView
                .DisplayMember = "Banco"
                .ValueMember = "Banco"
            End With

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Sub

    Private Sub LlenarComboCuentasOrigen()
        Dim ds_Cuentas As Data.DataSet
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            ds_Cuentas = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT DISTINCT CuentaOrigen FROM TransferenciaBancaria ORDER BY CuentaOrigen ")

            ds_Cuentas.Dispose()

            With Me.cmbCuentaOrigen
                .DataSource = ds_Cuentas.Tables(0).DefaultView
                .DisplayMember = "CuentaOrigen"
                .ValueMember = "CuentaOrigen"
            End With

            ds_Cuentas = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT DISTINCT CuentaDestino FROM TransferenciaBancaria ORDER BY CuentaDestino ")

            ds_Cuentas.Dispose()

            With Me.cmbCuentaDestino
                .DataSource = ds_Cuentas.Tables(0).DefaultView
                .DisplayMember = "CuentaDestino"
                .ValueMember = "CuentaDestino"
            End With


        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Sub


    Private Sub Imprimir()
        nbreformreportes = "Comprobante de Pago"

        Dim cnn As New SqlConnection(ConnStringSEI)
        Dim Rpt As New frmReportes

        Imprimir_LlenarTMPs(txtCODIGO.Text)

        Rpt.PagoaProveedores_App(txtCODIGO.Text, Rpt, My.Application.Info.AssemblyName.ToString)

        cnn = Nothing

    End Sub

    'Private Sub LlenarGrid_Impuestos()

    '    Dim connection As SqlClient.SqlConnection = Nothing

    '    Try
    '        connection = SqlHelper.GetConnection(ConnStringSEI)
    '    Catch ex As Exception
    '        MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Sub
    '    End Try

    '    Try
    '        Dim dt As New DataTable
    '        Dim sqltxt2 As String

    '        sqltxt2 = "SELECT Codigo, NroDocumento, Monto, ISNULL(Ii.Observaciones ,'') AS Observaciones, Ii.IDimpuesto, ii.id FROM ImpuestosxPago ii " & _
    '                 " JOIN Impuestos I ON I.Id = ii.IdImpuesto WHERE IdPago = " & txtID.Text

    '        Dim cmd As New SqlCommand(sqltxt2, connection)
    '        Dim da As New SqlDataAdapter(cmd)
    '        Dim i As Integer

    '        da.Fill(dt)

    '        For i = 0 To dt.Rows.Count - 1
    '            grdImpuestos.Rows.Add(dt.Rows(i)("CODIGO").ToString(), dt.Rows(i)("NRODOCUMENTO").ToString(), dt.Rows(i)("monto").ToString(), dt.Rows(i)("OBSERVACIONES").ToString(), dt.Rows(i)("IdImpuesto").ToString(), dt.Rows(i)("Id").ToString())
    '        Next

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        If Not connection Is Nothing Then
    '            CType(connection, IDisposable).Dispose()
    '        End If
    '    End Try
    'End Sub

    'Private Sub LlenarGrid_Cheques_Propios()
    '    Dim connection As SqlClient.SqlConnection = Nothing

    '    Try
    '        connection = SqlHelper.GetConnection(ConnStringSEI)
    '    Catch ex As Exception
    '        MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Sub
    '    End Try

    '    Try
    '        Dim dt As New DataTable
    '        Dim sqltxt2 As String

    '        sqltxt2 = "SELECT NroCheque, banco, monto, fechacobro, clientechequebco, idmoneda, observaciones, c.id, utilizado " & _
    '                " FROM Cheques c JOIN pagos_cheques pc ON pc.idcheque = c.id " & _
    '                " where c.propio = 1 and  IdPago = " & IIf(txtID.Text = "", 0, txtID.Text) & " ORDER BY Monto ASC"

    '        Dim cmd As New SqlCommand(sqltxt2, connection)
    '        Dim da As New SqlDataAdapter(cmd)
    '        Dim i As Integer

    '        da.Fill(dt)

    '        For i = 0 To dt.Rows.Count - 1
    '            grdChequesPropios.Rows.Add(dt.Rows(i)("nrocheque").ToString(), dt.Rows(i)("banco").ToString(), dt.Rows(i)("monto").ToString(), dt.Rows(i)("fechacobro").ToString(), dt.Rows(i)("clientechequebco").ToString(), dt.Rows(i)("idmoneda").ToString(), dt.Rows(i)("Observaciones").ToString(), dt.Rows(i)("Id").ToString())
    '        Next

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        If Not connection Is Nothing Then
    '            CType(connection, IDisposable).Dispose()
    '        End If
    '    End Try
    'End Sub

    Private Sub LlenarGrid_Transferencias()
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            Dim dt As New DataTable
            Dim sqltxt2 As String

            sqltxt2 = " SELECT CuentaOrigen, CuentaDestino, BancoOrigen, BancoDestino, " & _
                        " IdMoneda, NroOperacionCliente, MontoTransferencia, Observaciones, FechaTransferencia, T.ID " & _
                        " from TransferenciaBancaria t " & _
                        " JOIN TransferenciaxIngresos ti ON ti.IdTransferencia = t.Id " & _
                        " WHERE IdPago = " & IIf(txtID.Text = "", 0, txtID.Text)

            Dim cmd As New SqlCommand(sqltxt2, connection)
            Dim da As New SqlDataAdapter(cmd)
            Dim i As Integer

            da.Fill(dt)

            For i = 0 To dt.Rows.Count - 1
                grdTransferencias.Rows.Add(dt.Rows(i)("NroOperacionCliente").ToString(), dt.Rows(i)("CuentaOrigen").ToString(), _
                                    dt.Rows(i)("MontoTransferencia").ToString(), dt.Rows(i)("CuentaDestino").ToString(), _
                                    dt.Rows(i)("FechaTransferencia").ToString(), dt.Rows(i)("idmoneda").ToString(), _
                                    dt.Rows(i)("BancoOrigen").ToString(), dt.Rows(i)("BancoDestino").ToString(), _
                                    dt.Rows(i)("Observaciones").ToString(), dt.Rows(i)("Id").ToString())
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub LimpiarGrids()

        'grdChequesPropios.Rows.Clear()
        grdTransferencias.Rows.Clear()
        grdTarjetas.Rows.Clear()

        'txtNroCheque.Text = ""
        'txtMontoCheque.Text = ""
        'dtpFechaCheque.Value = Date.Today  'grdCheques.CurrentRow.Cells(3).Value
        'txtPropietario.Text = "SEI SRL"
        'cmbMoneda.SelectedValue = grd.CurrentRow.Cells(5).Value
        'txtObservacionesCheque.Text = ""

        txtNroOpCliente.Text = ""
        txtMontoTransf.Text = ""
        cmbCuentaDestino.Text = ""
        cmbCuentaOrigen.Text = ""
        txtObservacionesTransf.Text = ""

    End Sub

    Private Sub Imprimir_LlenarTMPs(ByVal NroMov As String)

        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            Try

                Dim param_codigo As New SqlClient.SqlParameter
                param_codigo.ParameterName = "@idmov"
                param_codigo.SqlDbType = SqlDbType.BigInt
                'param_codigo.Size = 10
                param_codigo.Value = CLng(NroMov)
                param_codigo.Direction = ParameterDirection.Input

                Try
                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spRPT_Pagos_Tmp", _
                                               param_codigo)

                Catch ex As Exception
                    Throw ex
                End Try
            Finally

            End Try
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

#End Region

#Region "   Funciones"

    Private Function AgregarRegistro_Pagos() As Integer
        Dim res As Integer = 0

        Try
            Try
                conn_del_form = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End Try

            'Abrir una transaccion para guardar y asegurar que se guarda todo
            If Abrir_Tran(conn_del_form) = False Then
                MessageBox.Show("No se pudo abrir una transaccion", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If

            Try
                Dim param_id As New SqlClient.SqlParameter
                param_id.ParameterName = "@id"
                param_id.SqlDbType = SqlDbType.BigInt
                If bolModo = True Then
                    param_id.Value = DBNull.Value
                    param_id.Direction = ParameterDirection.InputOutput
                Else
                    param_id.Value = txtID.Text
                    param_id.Direction = ParameterDirection.Input
                End If

                Dim param_codigo As New SqlClient.SqlParameter
                param_codigo.ParameterName = "@codigo"
                param_codigo.SqlDbType = SqlDbType.BigInt
                param_codigo.Value = DBNull.Value
                If bolModo = True Then
                    param_codigo.Direction = ParameterDirection.InputOutput
                Else
                    param_codigo.Direction = ParameterDirection.Input
                End If

                Dim param_NOTA As New SqlClient.SqlParameter
                param_NOTA.ParameterName = "@Nota"
                param_NOTA.SqlDbType = SqlDbType.VarChar
                param_NOTA.Size = 300
                param_NOTA.Value = txtNota.Text
                param_NOTA.Direction = ParameterDirection.Input

                Dim param_idProveedor As New SqlClient.SqlParameter
                param_idProveedor.ParameterName = "@idProveedor"
                param_idProveedor.SqlDbType = SqlDbType.BigInt
                param_idProveedor.Value = txtIdProveedor.Text ' cmbProveedores.SelectedValue
                param_idProveedor.Direction = ParameterDirection.Input

                Dim param_fecha As New SqlClient.SqlParameter
                param_fecha.ParameterName = "@fechaPago"
                param_fecha.SqlDbType = SqlDbType.DateTime
                param_fecha.Value = dtpFECHA.Value
                param_fecha.Direction = ParameterDirection.Input

                Dim param_contado As New SqlClient.SqlParameter
                param_contado.ParameterName = "@contado"
                param_contado.SqlDbType = SqlDbType.Bit
                If txtEntregaContado.Text <> "" And txtEntregaContado.Text <> "0" Then
                    param_contado.Value = True
                Else
                    param_contado.Value = False
                End If
                param_contado.Direction = ParameterDirection.Input

                Dim param_montocontado As New SqlClient.SqlParameter
                param_montocontado.ParameterName = "@montocontado"
                param_montocontado.SqlDbType = SqlDbType.Decimal
                param_montocontado.Precision = 18
                param_montocontado.Scale = 2
                param_montocontado.Value = IIf(txtEntregaContado.Text = "", 0, txtEntregaContado.Text)
                param_montocontado.Direction = ParameterDirection.Input

                Dim param_tarjeta As New SqlClient.SqlParameter
                param_tarjeta.ParameterName = "@tarjeta"
                param_tarjeta.SqlDbType = SqlDbType.Bit
                If lblEntregaTarjetas.Text <> "" And lblEntregaTarjetas.Text <> "0" Then
                    param_tarjeta.Value = True
                Else
                    param_tarjeta.Value = False
                End If
                param_tarjeta.Direction = ParameterDirection.Input

                Dim param_montotarjeta As New SqlClient.SqlParameter
                param_montotarjeta.ParameterName = "@montotarjeta"
                param_montotarjeta.SqlDbType = SqlDbType.Decimal
                param_montotarjeta.Precision = 18
                param_montotarjeta.Scale = 2
                param_montotarjeta.Value = lblEntregaTarjetas.Text
                param_montotarjeta.Direction = ParameterDirection.Input

                Dim param_cheque As New SqlClient.SqlParameter
                param_cheque.ParameterName = "@cheque"
                param_cheque.SqlDbType = SqlDbType.Bit
                If (lblEntregaCheques.Text <> "" And lblEntregaCheques.Text <> "0") Or
                    (lblEntregaChequesPropios.Text <> "" And lblEntregaChequesPropios.Text <> "0") Then
                    param_cheque.Value = True
                Else
                    param_cheque.Value = False
                End If
                param_cheque.Direction = ParameterDirection.Input

                Dim param_montocheque As New SqlClient.SqlParameter
                param_montocheque.ParameterName = "@montocheque"
                param_montocheque.SqlDbType = SqlDbType.Decimal
                param_montocheque.Precision = 18
                param_montocheque.Scale = 2
                param_montocheque.Value = lblEntregaCheques.Text
                param_montocheque.Direction = ParameterDirection.Input

                Dim param_montochequepropios As New SqlClient.SqlParameter
                param_montochequepropios.ParameterName = "@montochequepropio"
                param_montochequepropios.SqlDbType = SqlDbType.Decimal
                param_montochequepropios.Precision = 18
                param_montochequepropios.Scale = 2
                param_montochequepropios.Value = lblEntregaChequesPropios.Text
                param_montochequepropios.Direction = ParameterDirection.Input

                Dim param_transferencia As New SqlClient.SqlParameter
                param_transferencia.ParameterName = "@transferencia"
                param_transferencia.SqlDbType = SqlDbType.Bit
                If lblEntregaTransferencias.Text <> "" And lblEntregaTransferencias.Text <> "0" Then
                    param_transferencia.Value = True
                Else
                    param_transferencia.Value = False
                End If
                param_transferencia.Direction = ParameterDirection.Input

                Dim param_montotransf As New SqlClient.SqlParameter
                param_montotransf.ParameterName = "@montotransf"
                param_montotransf.SqlDbType = SqlDbType.Decimal
                param_montotransf.Precision = 18
                param_montotransf.Scale = 2
                param_montotransf.Value = lblEntregaTransferencias.Text
                param_montotransf.Direction = ParameterDirection.Input

                Dim param_impuestos As New SqlClient.SqlParameter
                param_impuestos.ParameterName = "@impuestos"
                param_impuestos.SqlDbType = SqlDbType.Bit
                param_impuestos.Value = False
                param_impuestos.Direction = ParameterDirection.Input

                Dim param_montoimpuesto As New SqlClient.SqlParameter
                param_montoimpuesto.ParameterName = "@montoimpuesto"
                param_montoimpuesto.SqlDbType = SqlDbType.Decimal
                param_montoimpuesto.Precision = 18
                param_montoimpuesto.Scale = 2
                param_montoimpuesto.Value = 0
                param_montoimpuesto.Direction = ParameterDirection.Input

                Dim param_montoiva As New SqlClient.SqlParameter
                param_montoiva.ParameterName = "@montoiva"
                param_montoiva.SqlDbType = SqlDbType.Decimal
                param_montoiva.Precision = 18
                param_montoiva.Scale = 2
                param_montoiva.Value = CDbl(lblIVA.Text)
                param_montoiva.Direction = ParameterDirection.Input

                Dim param_subtotal As New SqlClient.SqlParameter
                param_subtotal.ParameterName = "@subtotal"
                param_subtotal.SqlDbType = SqlDbType.Decimal
                param_subtotal.Precision = 18
                param_subtotal.Scale = 2
                param_subtotal.Value = CDbl(lblSubtotal.Text)
                param_subtotal.Direction = ParameterDirection.Input

                Dim param_total As New SqlClient.SqlParameter
                param_total.ParameterName = "@total"
                param_total.SqlDbType = SqlDbType.Decimal
                param_total.Precision = 18
                param_total.Scale = 2
                param_total.Value = CDbl(lblTotal.Text)
                param_total.Direction = ParameterDirection.Input

                Dim param_Redondeo As New SqlClient.SqlParameter
                param_Redondeo.ParameterName = "@Redondeo"
                param_Redondeo.SqlDbType = SqlDbType.Decimal
                param_Redondeo.Precision = 18
                param_Redondeo.Scale = 2
                param_Redondeo.Value = CDbl(IIf(txtRedondeo.Text = "", 0, txtRedondeo.Text))
                param_Redondeo.Direction = ParameterDirection.Input

                Dim param_useradd As New SqlClient.SqlParameter
                If bolModo = True Then
                    param_useradd.ParameterName = "@useradd"
                Else
                    param_useradd.ParameterName = "@userupd"
                End If
                param_useradd.SqlDbType = SqlDbType.Int
                param_useradd.Value = UserID
                param_useradd.Direction = ParameterDirection.Input

                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.InputOutput

                Try
                    If bolModo = True Then

                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Insert", _
                                              param_id, param_codigo, param_idProveedor, param_fecha, param_contado, param_montocontado, _
                                              param_tarjeta, param_montotarjeta, param_cheque, param_montocheque, param_montochequepropios, _
                                              param_transferencia, param_montotransf, param_impuestos, param_montoimpuesto, _
                                              param_montoiva, param_subtotal, param_total, param_Redondeo, param_NOTA, _
                                              param_useradd, param_res)

                        txtID.Text = param_id.Value

                        txtCODIGO.Text = param_codigo.Value.ToString

                    Else

                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Update", _
                                              param_id, param_fecha, param_contado, param_montocontado, _
                                              param_tarjeta, param_montotarjeta, param_cheque, param_montocheque, param_montochequepropios, _
                                              param_transferencia, param_montotransf, param_impuestos, param_montoimpuesto, _
                                              param_montoiva, param_subtotal, param_total, param_Redondeo, param_NOTA, _
                                              param_useradd, param_res)

                    End If


                    AgregarRegistro_Pagos = param_res.Value

                Catch ex As Exception
                    Throw ex
                End Try
            Finally

            End Try
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Function

    Private Function AgregarRegistro_PagosGastos() As Integer
        Dim res As Integer = 0
        Dim i As Integer

        Try
            Try
                Dim Cancelartodo As Boolean = False
                Dim Deuda As Double, totalentregado As Double, DeudaGasto As Double

                totalentregado = CDbl(lblEntregado.Text)

                For i = 0 To grdFacturasConsumos.RowCount - 1

                    If CBool(grdFacturasConsumos.Rows(i).Cells(ColumnasDelGridGastos.Seleccionar).Value) = True Then

                        'Deuda = FormatNumber(totalentregado - grdFacturasConsumos.Rows(i).Cells(ColumnasDelGridGastos.Total).Value, 2)

                        Deuda = FormatNumber(totalentregado - grdFacturasConsumos.Rows(i).Cells(ColumnasDelGridGastos.Deuda).Value, 2)


                        If Deuda >= 0 Then
                            Cancelartodo = True
                            DeudaGasto = 0
                        Else
                            Cancelartodo = False
                            DeudaGasto = Deuda * -1
                        End If

                        totalentregado = Deuda

                        Dim param_idPago As New SqlClient.SqlParameter
                        param_idPago.ParameterName = "@idPago"
                        param_idPago.SqlDbType = SqlDbType.BigInt
                        param_idPago.Value = txtID.Text
                        param_idPago.Direction = ParameterDirection.Input

                        Dim param_idGasto As New SqlClient.SqlParameter
                        param_idGasto.ParameterName = "@idGasto"
                        param_idGasto.SqlDbType = SqlDbType.BigInt
                        param_idGasto.Value = grdFacturasConsumos.Rows(i).Cells(ColumnasDelGridGastos.Id).Value
                        param_idGasto.Direction = ParameterDirection.Input

                        Dim param_DEUDA As New SqlClient.SqlParameter
                        param_DEUDA.ParameterName = "@Deuda"
                        param_DEUDA.SqlDbType = SqlDbType.Decimal
                        param_DEUDA.Precision = 18
                        param_DEUDA.Scale = 2
                        param_DEUDA.Value = DeudaGasto
                        param_DEUDA.Direction = ParameterDirection.Input

                        Dim param_CancelarTodo As New SqlClient.SqlParameter
                        param_CancelarTodo.ParameterName = "@CancelarTodo"
                        param_CancelarTodo.SqlDbType = SqlDbType.Bit
                        param_CancelarTodo.Value = Cancelartodo
                        param_CancelarTodo.Direction = ParameterDirection.Input

                        Dim param_res As New SqlClient.SqlParameter
                        param_res.ParameterName = "@res"
                        param_res.SqlDbType = SqlDbType.Int
                        param_res.Value = DBNull.Value
                        param_res.Direction = ParameterDirection.InputOutput

                        Try
                            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Gastos_Insert", _
                                                      param_idPago, param_idGasto, param_DEUDA, param_CancelarTodo, param_res)

                            res = param_res.Value

                            If (res <= 0) Then
                                Exit For
                            End If

                            If Deuda < 0 Then
                                Exit For
                            End If

                        Catch ex As Exception
                            Throw ex
                        End Try
                    End If

                Next

                AgregarRegistro_PagosGastos = res

            Catch ex2 As Exception
                Throw ex2
            Finally

            End Try
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function AgregarRegistro_Cheques_Terceros() As Integer
        Dim res As Integer = 0
        Dim i As Integer

        Try

            Try

                For i = 0 To grdChequesTerceros.RowCount - 1

                    If CBool(grdChequesTerceros.Rows(i).Cells(ColumnasDelGridCheques.Seleccionar).Value) = True Then

                        Dim param_IdCheque As New SqlClient.SqlParameter
                        param_IdCheque.ParameterName = "@IdCheque"
                        param_IdCheque.SqlDbType = SqlDbType.BigInt
                        param_IdCheque.Value = grdChequesTerceros.Rows(i).Cells(ColumnasDelGridCheques.Id).Value
                        param_IdCheque.Direction = ParameterDirection.Input

                        Dim param_IdPago As New SqlClient.SqlParameter
                        param_IdPago.ParameterName = "@IdPago"
                        param_IdPago.SqlDbType = SqlDbType.BigInt
                        param_IdPago.Value = txtID.Text
                        param_IdPago.Direction = ParameterDirection.Input

                        Dim param_res As New SqlClient.SqlParameter
                        param_res.ParameterName = "@res"
                        param_res.SqlDbType = SqlDbType.Int
                        param_res.Value = 0
                        param_res.Direction = ParameterDirection.InputOutput

                        Try
                            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Cheques_Insert", _
                                param_IdPago, param_IdCheque, param_res)

                            res = param_res.Value

                            If res < 0 Then
                                AgregarRegistro_Cheques_Terceros = -1
                                Exit Function
                            End If

                        Catch ex As Exception
                            Throw ex
                            AgregarRegistro_Cheques_Terceros = -1
                            Exit Function
                        End Try
                    End If

                Next

                AgregarRegistro_Cheques_Terceros = 1
            Finally

            End Try
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Function

    Private Function AgregarRegistro_Cheques_Propios() As Integer
        Dim res As Integer = 0
        Dim i As Integer

        Try

            Try

                For i = 0 To grdChequesPropios.RowCount - 1

                    If CBool(grdChequesPropios.Rows(i).Cells(ColumnasDelGridChequesPropios.Seleccionar).Value) = True Then

                        Dim param_IdCheque As New SqlClient.SqlParameter
                        param_IdCheque.ParameterName = "@IdCheque"
                        param_IdCheque.SqlDbType = SqlDbType.BigInt
                        param_IdCheque.Value = grdChequesPropios.Rows(i).Cells(ColumnasDelGridChequesPropios.Id).Value
                        param_IdCheque.Direction = ParameterDirection.Input

                        Dim param_IdPago As New SqlClient.SqlParameter
                        param_IdPago.ParameterName = "@IdPago"
                        param_IdPago.SqlDbType = SqlDbType.BigInt
                        param_IdPago.Value = txtID.Text
                        param_IdPago.Direction = ParameterDirection.Input

                        Dim param_Monto As New SqlClient.SqlParameter
                        param_Monto.ParameterName = "@Monto"
                        param_Monto.SqlDbType = SqlDbType.Decimal
                        param_Monto.Precision = 18
                        param_Monto.Value = grdChequesPropios.Rows(i).Cells(ColumnasDelGridChequesPropios.MontoCheque).Value
                        param_Monto.Direction = ParameterDirection.Input

                        Dim param_Venc As New SqlClient.SqlParameter
                        param_Venc.ParameterName = "@Venc"
                        param_Venc.SqlDbType = SqlDbType.Date
                        param_Venc.Value = grdChequesPropios.Rows(i).Cells(ColumnasDelGridChequesPropios.FechaCobro).Value
                        param_Venc.Direction = ParameterDirection.Input

                        Dim param_res As New SqlClient.SqlParameter
                        param_res.ParameterName = "@res"
                        param_res.SqlDbType = SqlDbType.Int
                        param_res.Value = 0
                        param_res.Direction = ParameterDirection.InputOutput

                        Try
                            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Cheques_Propios_Insert", _
                                param_IdPago, param_IdCheque, param_Monto, param_Venc, param_res)

                            res = param_res.Value

                            If res < 0 Then
                                AgregarRegistro_Cheques_Propios = -1
                                Exit Function
                            End If

                        Catch ex As Exception
                            Throw ex
                            AgregarRegistro_Cheques_Propios = -1
                            Exit Function
                        End Try
                    End If

                Next

                AgregarRegistro_Cheques_Propios = 1
            Finally

            End Try
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Function

    'Private Function AgregarRegistro_Cheques_Propios() As Integer
    '    Dim res As Integer = 0
    '    Dim i As Integer

    '    Try

    '        Try

    '            For i = 0 To grdChequesPropios.RowCount - 1

    '                Dim param_Id As New SqlClient.SqlParameter
    '                param_Id.ParameterName = "@Id"
    '                param_Id.SqlDbType = SqlDbType.BigInt
    '                If grdChequesPropios.Rows(i).Cells(7).Value Is DBNull.Value Or grdChequesPropios.Rows(i).Cells(7).Value Is Nothing Then
    '                    param_Id.Value = DBNull.Value
    '                Else
    '                    param_Id.Value = grdChequesPropios.Rows(i).Cells(7).Value
    '                End If
    '                param_Id.Direction = ParameterDirection.Input

    '                Dim param_IdPago As New SqlClient.SqlParameter
    '                param_IdPago.ParameterName = "@IdPago"
    '                param_IdPago.SqlDbType = SqlDbType.BigInt
    '                param_IdPago.Value = txtID.Text
    '                param_IdPago.Direction = ParameterDirection.Input

    '                Dim param_NroCheque As New SqlClient.SqlParameter
    '                param_NroCheque.ParameterName = "@NroCheque"
    '                param_NroCheque.SqlDbType = SqlDbType.BigInt
    '                param_NroCheque.Value = grdChequesPropios.Rows(i).Cells(0).Value
    '                param_NroCheque.Direction = ParameterDirection.Input

    '                Dim param_IdCliente As New SqlClient.SqlParameter
    '                param_IdCliente.ParameterName = "@IdCliente"
    '                param_IdCliente.SqlDbType = SqlDbType.Int
    '                param_IdCliente.Value = 0
    '                param_IdCliente.Direction = ParameterDirection.Input

    '                Dim param_ClienteChequeBco As New SqlClient.SqlParameter
    '                param_ClienteChequeBco.ParameterName = "@ClienteChequeBco"
    '                param_ClienteChequeBco.SqlDbType = SqlDbType.NVarChar
    '                param_ClienteChequeBco.Size = 50
    '                param_ClienteChequeBco.Value = grdChequesPropios.Rows(i).Cells(4).Value
    '                param_ClienteChequeBco.Direction = ParameterDirection.Input

    '                Dim param_FechaCobro As New SqlClient.SqlParameter
    '                param_FechaCobro.ParameterName = "@FechaCobro"
    '                param_FechaCobro.SqlDbType = SqlDbType.DateTime
    '                param_FechaCobro.Value = grdChequesPropios.Rows(i).Cells(3).Value
    '                param_FechaCobro.Direction = ParameterDirection.Input

    '                Dim param_Moneda As New SqlClient.SqlParameter
    '                param_Moneda.ParameterName = "@IdMoneda"
    '                param_Moneda.SqlDbType = SqlDbType.Int
    '                param_Moneda.Value = 1 'grdChequesPropios.Rows(i).Cells(5).Value
    '                param_Moneda.Direction = ParameterDirection.Input

    '                Dim param_Monto As New SqlClient.SqlParameter
    '                param_Monto.ParameterName = "@Monto"
    '                param_Monto.SqlDbType = SqlDbType.Decimal
    '                param_Monto.Precision = 18
    '                param_Monto.Scale = 2
    '                param_Monto.Value = grdChequesPropios.Rows(i).Cells(2).Value
    '                param_Monto.Direction = ParameterDirection.Input

    '                Dim param_Banco As New SqlClient.SqlParameter
    '                param_Banco.ParameterName = "@Banco"
    '                param_Banco.SqlDbType = SqlDbType.NVarChar
    '                param_Banco.Size = 50
    '                param_Banco.Value = grdChequesPropios.Rows(i).Cells(1).Value
    '                param_Banco.Direction = ParameterDirection.Input

    '                Dim param_Observaciones As New SqlClient.SqlParameter
    '                param_Observaciones.ParameterName = "@Observaciones"
    '                param_Observaciones.SqlDbType = SqlDbType.NVarChar
    '                param_Observaciones.Size = 100
    '                param_Observaciones.Value = grdChequesPropios.Rows(i).Cells(6).Value
    '                param_Observaciones.Direction = ParameterDirection.Input

    '                Dim param_Propio As New SqlClient.SqlParameter
    '                param_Propio.ParameterName = "@Propio"
    '                param_Propio.SqlDbType = SqlDbType.Bit
    '                param_Propio.Value = True
    '                param_Propio.Direction = ParameterDirection.Input

    '                Dim param_Utilizado As New SqlClient.SqlParameter
    '                param_Utilizado.ParameterName = "@Utilizado"
    '                param_Utilizado.SqlDbType = SqlDbType.Bit
    '                param_Utilizado.Value = True
    '                param_Utilizado.Direction = ParameterDirection.Input

    '                Dim param_useradd As New SqlClient.SqlParameter
    '                If bolModo = True Then
    '                    param_useradd.ParameterName = "@useradd"
    '                Else
    '                    param_useradd.ParameterName = "@userupd"
    '                End If
    '                param_useradd.SqlDbType = SqlDbType.SmallInt
    '                param_useradd.Value = UserID
    '                param_useradd.Direction = ParameterDirection.Input

    '                Dim param_res As New SqlClient.SqlParameter
    '                param_res.ParameterName = "@res"
    '                param_res.SqlDbType = SqlDbType.Int
    '                param_res.Value = 0
    '                param_res.Direction = ParameterDirection.InputOutput

    '                Dim param_MENSAJE As New SqlClient.SqlParameter
    '                param_MENSAJE.ParameterName = "@MENSAJE"
    '                param_MENSAJE.SqlDbType = SqlDbType.VarChar
    '                param_MENSAJE.Size = 300
    '                param_MENSAJE.Value = DBNull.Value
    '                param_MENSAJE.Direction = ParameterDirection.InputOutput

    '                Try
    '                    If bolModo = True Then
    '                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spCheques_Insert2", _
    '                            param_IdPago, param_NroCheque, param_IdCliente, _
    '                            param_ClienteChequeBco, param_FechaCobro, param_Moneda, param_Monto, param_Utilizado, _
    '                            param_Banco, param_Observaciones, param_Propio, param_useradd, param_res)

    '                        res = param_res.Value
    '                    Else
    '                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spCheques_Update", _
    '                            param_Id, param_IdPago, param_NroCheque, param_IdCliente, _
    '                            param_ClienteChequeBco, param_FechaCobro, param_Moneda, param_Monto, _
    '                            param_Banco, param_Observaciones, param_Propio, param_useradd, param_MENSAJE, param_res)

    '                        'MsgBox(param_MENSAJE.Value.ToString)

    '                        res = param_res.Value

    '                    End If

    '                    If res < 0 Then
    '                        AgregarRegistro_Cheques_Propios = -1
    '                        Exit Function
    '                    End If

    '                Catch ex As Exception
    '                    Throw ex
    '                    AgregarRegistro_Cheques_Propios = -1
    '                    Exit Function
    '                End Try

    '            Next

    '            AgregarRegistro_Cheques_Propios = 1

    '        Finally

    '        End Try
    '    Catch ex As Exception
    '        Dim errMessage As String = ""
    '        Dim tempException As Exception = ex

    '        While (Not tempException Is Nothing)
    '            errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
    '            tempException = tempException.InnerException
    '        End While

    '        MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
    '          + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
    '          "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try
    'End Function

    'Private Function AgregarRegistro_Impuestos() As Integer
    '    Dim res As Integer = 0
    '    Dim i As Integer

    '    Try

    '        Try

    '            For i = 0 To grdImpuestos.RowCount - 1

    '                Dim param_Id As New SqlClient.SqlParameter
    '                param_Id.ParameterName = "@Id"
    '                param_Id.SqlDbType = SqlDbType.BigInt
    '                param_Id.Value = grdImpuestos.Rows(i).Cells(5).Value 'cmbImpuesto.SelectedValue
    '                param_Id.Direction = ParameterDirection.Input

    '                Dim param_IdPago As New SqlClient.SqlParameter
    '                param_IdPago.ParameterName = "@IdPago"
    '                param_IdPago.SqlDbType = SqlDbType.BigInt
    '                param_IdPago.Value = txtID.Text
    '                param_IdPago.Direction = ParameterDirection.Input

    '                Dim param_IdImpuesto As New SqlClient.SqlParameter
    '                param_IdImpuesto.ParameterName = "@IdImpuesto"
    '                param_IdImpuesto.SqlDbType = SqlDbType.BigInt
    '                param_IdImpuesto.Value = grdImpuestos.Rows(i).Cells(4).Value 'cmbImpuesto.SelectedValue
    '                param_IdImpuesto.Direction = ParameterDirection.Input

    '                Dim param_NroDocumento As New SqlClient.SqlParameter
    '                param_NroDocumento.ParameterName = "@NroDocumento"
    '                param_NroDocumento.SqlDbType = SqlDbType.NVarChar
    '                param_NroDocumento.Size = 30
    '                param_NroDocumento.Value = LTrim(RTrim(grdImpuestos.Rows(i).Cells(1).Value))
    '                param_NroDocumento.Direction = ParameterDirection.Input

    '                Dim param_Monto As New SqlClient.SqlParameter
    '                param_Monto.ParameterName = "@Monto"
    '                param_Monto.SqlDbType = SqlDbType.Decimal
    '                param_Monto.Precision = 18
    '                param_Monto.Scale = 2
    '                param_Monto.Value = grdImpuestos.Rows(i).Cells(2).Value
    '                param_Monto.Direction = ParameterDirection.Input

    '                Dim param_res As New SqlClient.SqlParameter
    '                param_res.ParameterName = "@res"
    '                param_res.SqlDbType = SqlDbType.Int
    '                param_res.Value = 0
    '                param_res.Direction = ParameterDirection.InputOutput

    '                Dim param_MENSAJE As New SqlClient.SqlParameter
    '                param_MENSAJE.ParameterName = "@MENSAJE"
    '                param_MENSAJE.SqlDbType = SqlDbType.VarChar
    '                param_MENSAJE.Size = 200
    '                param_MENSAJE.Value = DBNull.Value
    '                param_MENSAJE.Direction = ParameterDirection.InputOutput

    '                Try
    '                    If bolModo = True Then

    '                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Impuestos_Insert", _
    '                            param_IdPago, param_IdImpuesto, param_NroDocumento, _
    '                             param_Monto, param_res)

    '                        res = param_res.Value

    '                    Else

    '                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Impuestos_Update", _
    '                            param_Id, param_IdPago, param_IdImpuesto, param_NroDocumento, _
    '                             param_Monto, param_MENSAJE, param_res)

    '                        'MsgBox(param_MENSAJE.Value)

    '                        res = param_res.Value

    '                    End If

    '                    If res < 0 Then
    '                        AgregarRegistro_Impuestos = -1
    '                        Exit Function
    '                    End If

    '                Catch ex As Exception
    '                    Throw ex
    '                    AgregarRegistro_Impuestos = -1
    '                    Exit Function
    '                End Try

    '            Next

    '            AgregarRegistro_Impuestos = 1
    '        Finally

    '        End Try
    '    Catch ex As Exception
    '        Dim errMessage As String = ""
    '        Dim tempException As Exception = ex

    '        While (Not tempException Is Nothing)
    '            errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
    '            tempException = tempException.InnerException
    '        End While

    '        MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
    '          + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
    '          "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try
    'End Function

    Private Function AgregarRegistro_Transferencias() As Integer
        Dim res As Integer = 0
        Dim i As Integer

        Try

            Try

                For i = 0 To grdTransferencias.RowCount - 1

                    Dim param_Id As New SqlClient.SqlParameter
                    param_Id.ParameterName = "@Id"
                    param_Id.SqlDbType = SqlDbType.BigInt
                    If grdTransferencias.Rows(i).Cells(9).Value Is DBNull.Value Or grdTransferencias.Rows(i).Cells(9).Value Is Nothing Then
                        param_Id.Value = DBNull.Value
                    Else
                        param_Id.Value = CLng(grdTransferencias.Rows(i).Cells(9).Value)
                    End If
                    param_Id.Direction = ParameterDirection.Input

                    Dim param_IdPago As New SqlClient.SqlParameter
                    param_IdPago.ParameterName = "@IdPago"
                    param_IdPago.SqlDbType = SqlDbType.BigInt
                    param_IdPago.Value = txtID.Text
                    param_IdPago.Direction = ParameterDirection.Input

                    Dim param_CuentaOrigen As New SqlClient.SqlParameter
                    param_CuentaOrigen.ParameterName = "@CuentaOrigen"
                    param_CuentaOrigen.SqlDbType = SqlDbType.VarChar
                    param_CuentaOrigen.Size = 30
                    param_CuentaOrigen.Value = grdTransferencias.Rows(i).Cells(1).Value
                    param_CuentaOrigen.Direction = ParameterDirection.Input

                    Dim param_CuentaDestino As New SqlClient.SqlParameter
                    param_CuentaDestino.ParameterName = "@CuentaDestino"
                    param_CuentaDestino.SqlDbType = SqlDbType.VarChar
                    param_CuentaDestino.Size = 30
                    param_CuentaDestino.Value = grdTransferencias.Rows(i).Cells(3).Value
                    param_CuentaDestino.Direction = ParameterDirection.Input

                    Dim param_BancoOrigen As New SqlClient.SqlParameter
                    param_BancoOrigen.ParameterName = "@BancoOrigen"
                    param_BancoOrigen.SqlDbType = SqlDbType.VarChar
                    param_BancoOrigen.Size = 30
                    param_BancoOrigen.Value = grdTransferencias.Rows(i).Cells(6).Value
                    param_BancoOrigen.Direction = ParameterDirection.Input

                    Dim param_BancoDestino As New SqlClient.SqlParameter
                    param_BancoDestino.ParameterName = "@BancoDestino"
                    param_BancoDestino.SqlDbType = SqlDbType.VarChar
                    param_BancoDestino.Size = 30
                    param_BancoDestino.Value = grdTransferencias.Rows(i).Cells(7).Value
                    param_BancoDestino.Direction = ParameterDirection.Input

                    Dim param_Fecha As New SqlClient.SqlParameter
                    param_Fecha.ParameterName = "@FechaTransf"
                    param_Fecha.SqlDbType = SqlDbType.DateTime
                    param_Fecha.Value = grdTransferencias.Rows(i).Cells(4).Value
                    param_Fecha.Direction = ParameterDirection.Input

                    Dim param_Moneda As New SqlClient.SqlParameter
                    param_Moneda.ParameterName = "@IdMoneda"
                    param_Moneda.SqlDbType = SqlDbType.Int
                    param_Moneda.Value = 1 'grdTransferencias.Rows(i).Cells(5).Value
                    param_Moneda.Direction = ParameterDirection.Input

                    Dim param_Nroop As New SqlClient.SqlParameter
                    param_Nroop.ParameterName = "@NroOp"
                    param_Nroop.SqlDbType = SqlDbType.VarChar
                    param_Nroop.Size = 30
                    param_Nroop.Value = grdTransferencias.Rows(i).Cells(0).Value
                    param_Nroop.Direction = ParameterDirection.Input

                    Dim param_Monto As New SqlClient.SqlParameter
                    param_Monto.ParameterName = "@Monto"
                    param_Monto.SqlDbType = SqlDbType.Decimal
                    param_Monto.Precision = 18
                    param_Monto.Scale = 2
                    param_Monto.Value = grdTransferencias.Rows(i).Cells(2).Value
                    param_Monto.Direction = ParameterDirection.Input

                    Dim param_Observaciones As New SqlClient.SqlParameter
                    param_Observaciones.ParameterName = "@Observaciones"
                    param_Observaciones.SqlDbType = SqlDbType.NVarChar
                    param_Observaciones.Size = 100
                    param_Observaciones.Value = grdTransferencias.Rows(i).Cells(8).Value
                    param_Observaciones.Direction = ParameterDirection.Input

                    Dim param_res As New SqlClient.SqlParameter
                    param_res.ParameterName = "@res"
                    param_res.SqlDbType = SqlDbType.Int
                    param_res.Value = 0
                    param_res.Direction = ParameterDirection.InputOutput

                    Dim param_MENSAJE As New SqlClient.SqlParameter
                    param_MENSAJE.ParameterName = "@MENSAJE"
                    param_MENSAJE.SqlDbType = SqlDbType.VarChar
                    param_MENSAJE.Size = 200
                    param_MENSAJE.Value = DBNull.Value
                    param_MENSAJE.Direction = ParameterDirection.InputOutput

                    Try
                        If bolModo = True Then

                            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Transferencias_Insert", _
                                param_IdPago, param_BancoDestino, param_BancoOrigen, _
                                param_CuentaDestino, param_CuentaOrigen, param_Fecha, param_Moneda, _
                                param_Monto, param_Nroop, param_Observaciones, param_res)

                            res = param_res.Value

                        Else

                            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Transferencias_Update", _
                                param_Id, param_IdPago, param_BancoDestino, param_BancoOrigen, _
                                param_CuentaDestino, param_CuentaOrigen, param_Fecha, param_Moneda, _
                                param_Monto, param_Nroop, param_Observaciones, param_MENSAJE, param_res)

                            'MsgBox(param_MENSAJE.Value)

                            res = param_res.Value

                        End If

                        If res < 0 Then
                            AgregarRegistro_Transferencias = -1
                            Exit Function
                        End If

                    Catch ex As Exception
                        Throw ex
                        AgregarRegistro_Transferencias = -1
                        Exit Function
                    End Try

                Next

                AgregarRegistro_Transferencias = 1
            Finally
            End Try
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Function

    Private Function ControlarCantidad_Cheques() As Integer
        ' Dim connection As SqlClient.SqlConnection = Nothing
        Dim i As Integer

        Try
            'connection = SqlHelper.GetConnection(ConnStringSEI)

            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "DELETE FROM TMP_Cheques_Pagos")

            For i = 0 To grdChequesTerceros.RowCount - 1

                If CBool(grdChequesTerceros.Rows(i).Cells(ColumnasDelGridCheques.Seleccionar).Value) = True Then

                    Dim param_id As New SqlClient.SqlParameter
                    param_id.ParameterName = "@idPago"
                    param_id.SqlDbType = SqlDbType.BigInt
                    param_id.Value = txtID.Text
                    param_id.Direction = ParameterDirection.Input

                    Dim param_idcheque As New SqlClient.SqlParameter
                    param_idcheque.ParameterName = "@idcheque"
                    param_idcheque.SqlDbType = SqlDbType.BigInt
                    param_idcheque.Value = grdChequesTerceros.Rows(i).Cells(ColumnasDelGridCheques.Id).Value
                    param_idcheque.Direction = ParameterDirection.Input

                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Cheques_TMP", _
                                                param_id, param_idcheque)

                End If

            Next

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Finally
            '    If Not connection Is Nothing Then
            '        CType(connection, IDisposable).Dispose()
            '    End If
        End Try
    End Function

    Private Function ControlarCantidad_Cheques_Propios() As Integer
        ' Dim connection As SqlClient.SqlConnection = Nothing
        Dim i As Integer

        Try
            'connection = SqlHelper.GetConnection(ConnStringSEI)

            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "DELETE FROM TMP_Cheques_Propios_Pagos")

            For i = 0 To grdChequesTerceros.RowCount - 1
                Dim param_id As New SqlClient.SqlParameter
                param_id.ParameterName = "@idIngreso"
                param_id.SqlDbType = SqlDbType.BigInt
                param_id.Value = txtID.Text
                param_id.Direction = ParameterDirection.Input

                Dim param_idcheque As New SqlClient.SqlParameter
                param_idcheque.ParameterName = "@idcheque"
                param_idcheque.SqlDbType = SqlDbType.BigInt
                param_idcheque.Value = grdChequesTerceros.Rows(i).Cells(7).Value
                param_idcheque.Direction = ParameterDirection.Input

                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Cheques_Propios_TMP", _
                                            param_id, param_idcheque)

            Next

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Finally
            '    If Not connection Is Nothing Then
            '        CType(connection, IDisposable).Dispose()
            '    End If
        End Try
    End Function

    'Private Function ControlarCantidad_Impuestos() As Integer
    '    'Dim connection As SqlClient.SqlConnection = Nothing
    '    Dim i As Integer

    '    Try
    '        'connection = SqlHelper.GetConnection(ConnStringSEI)

    '        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "DELETE FROM TMP_Impuestos_Pagos")

    '        For i = 0 To grdImpuestos.RowCount - 1

    '            Dim param_id As New SqlClient.SqlParameter
    '            param_id.ParameterName = "@id"
    '            param_id.SqlDbType = SqlDbType.BigInt
    '            param_id.Value = grdImpuestos.Rows(i).Cells(5).Value
    '            param_id.Direction = ParameterDirection.Input

    '            Dim param_IdPago As New SqlClient.SqlParameter
    '            param_IdPago.ParameterName = "@idPago"
    '            param_IdPago.SqlDbType = SqlDbType.BigInt
    '            param_IdPago.Value = txtID.Text
    '            param_IdPago.Direction = ParameterDirection.Input

    '            Dim param_idImpuesto As New SqlClient.SqlParameter
    '            param_idImpuesto.ParameterName = "@IdImpuesto"
    '            param_idImpuesto.SqlDbType = SqlDbType.BigInt
    '            param_idImpuesto.Value = grdImpuestos.Rows(i).Cells(4).Value
    '            param_idImpuesto.Direction = ParameterDirection.Input

    '            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Impuestos_TMP", _
    '                                        param_id, param_IdPago, param_idImpuesto)

    '        Next

    '    Catch ex As Exception
    '        Dim errMessage As String = ""
    '        Dim tempException As Exception = ex

    '        While (Not tempException Is Nothing)
    '            errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
    '            tempException = tempException.InnerException
    '        End While

    '        MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
    '          + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
    '          "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        'Finally
    '        '    If Not connection Is Nothing Then
    '        '        CType(connection, IDisposable).Dispose()
    '        '    End If
    '    End Try
    'End Function

    Private Function ControlarCantidad_Transferencias() As Integer
        'Dim connection As SqlClient.SqlConnection = Nothing
        Dim i As Integer

        Try
            'connection = SqlHelper.GetConnection(ConnStringSEI)

            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "DELETE FROM TMP_Transferencias_Pagos")

            For i = 0 To grdTransferencias.RowCount - 1
                Dim param_id As New SqlClient.SqlParameter
                param_id.ParameterName = "@idPago"
                param_id.SqlDbType = SqlDbType.BigInt
                param_id.Value = txtID.Text
                param_id.Direction = ParameterDirection.Input

                Dim param_idtransferencia As New SqlClient.SqlParameter
                param_idtransferencia.ParameterName = "@Idtransferencia"
                param_idtransferencia.SqlDbType = SqlDbType.BigInt
                param_idtransferencia.Value = grdTransferencias.Rows(i).Cells(9).Value
                param_idtransferencia.Direction = ParameterDirection.Input

                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Transferencias_TMP", _
                                            param_id, param_idtransferencia)

            Next

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Finally
            '    If Not connection Is Nothing Then
            '        CType(connection, IDisposable).Dispose()
            '    End If
        End Try
    End Function

    Private Function EliminarItems_Impuestos() As Integer
        'Dim connection As SqlClient.SqlConnection = Nothing

        Try
            Dim param_id As New SqlClient.SqlParameter
            param_id.ParameterName = "@idPago"
            param_id.SqlDbType = SqlDbType.BigInt
            param_id.Value = CLng(txtID.Text)
            param_id.Direction = ParameterDirection.Input

            Dim param_res As New SqlClient.SqlParameter
            param_res.ParameterName = "@Res"
            param_res.SqlDbType = SqlDbType.Int
            param_res.Value = DBNull.Value
            param_res.Direction = ParameterDirection.InputOutput

            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Impuestos_EliminarItems", _
                                        param_id, param_res)

            EliminarItems_Impuestos = param_res.Value

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Finally
            '    If Not connection Is Nothing Then
            '        CType(connection, IDisposable).Dispose()
            '    End If
        End Try
    End Function

    Private Function EliminarItems_Cheques() As Integer
        'Dim connection As SqlClient.SqlConnection = Nothing

        Try
            Dim param_id As New SqlClient.SqlParameter
            param_id.ParameterName = "@idPago"
            param_id.SqlDbType = SqlDbType.BigInt
            param_id.Value = CLng(txtID.Text)
            param_id.Direction = ParameterDirection.Input

            Dim param_res As New SqlClient.SqlParameter
            param_res.ParameterName = "@Res"
            param_res.SqlDbType = SqlDbType.Int
            param_res.Value = DBNull.Value
            param_res.Direction = ParameterDirection.InputOutput

            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Cheques_EliminarItems", _
                                        param_id, param_res)

            EliminarItems_Cheques = param_res.Value

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Finally
            '    If Not connection Is Nothing Then
            '        CType(connection, IDisposable).Dispose()
            '    End If
        End Try
    End Function

    Private Function EliminarItems_Cheques_Propios() As Integer
        'Dim connection As SqlClient.SqlConnection = Nothing

        Try
            Dim param_id As New SqlClient.SqlParameter
            param_id.ParameterName = "@idPago"
            param_id.SqlDbType = SqlDbType.BigInt
            param_id.Value = CLng(txtID.Text)
            param_id.Direction = ParameterDirection.Input

            Dim param_res As New SqlClient.SqlParameter
            param_res.ParameterName = "@Res"
            param_res.SqlDbType = SqlDbType.Int
            param_res.Value = DBNull.Value
            param_res.Direction = ParameterDirection.InputOutput

            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Cheques_Propios_EliminarItems", _
                                        param_id, param_res)

            EliminarItems_Cheques_Propios = param_res.Value

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Finally
            '    If Not connection Is Nothing Then
            '        CType(connection, IDisposable).Dispose()
            '    End If
        End Try
    End Function

    Private Function EliminarItems_Transferencias() As Integer
        'Dim connection As SqlClient.SqlConnection = Nothing

        Try
            Dim param_id As New SqlClient.SqlParameter
            param_id.ParameterName = "@idPago"
            param_id.SqlDbType = SqlDbType.BigInt
            param_id.Value = CLng(txtID.Text)
            param_id.Direction = ParameterDirection.Input

            Dim param_res As New SqlClient.SqlParameter
            param_res.ParameterName = "@Res"
            param_res.SqlDbType = SqlDbType.Int
            param_res.Value = DBNull.Value
            param_res.Direction = ParameterDirection.InputOutput

            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Transferencias_EliminarItems", _
                                        param_id, param_res)

            EliminarItems_Transferencias = param_res.Value

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Finally
            '    If Not connection Is Nothing Then
            '        CType(connection, IDisposable).Dispose()
            '    End If
        End Try
    End Function

    Private Function AgregarRemito_tmp() As Integer
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim I As Integer
        Dim subtotal As Double = 0, MONTOiva As Double = 0, total As Double = 0

        Try

            Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End Try

            Try
                SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spGastos_DELETE_tmp")

            Catch ex As Exception
                Throw ex
            End Try

            lblSubtotal.Text = "0"
            lblIVA.Text = "0"
            lblTotal.Text = "0"

            lblTotalaPagarSinIva.Text = "0"
            lblTotalaPagar.Text = "0"

            IVA = 0

            For I = 0 To grdFacturasConsumos.RowCount - 1

                If bolModo = True And CBool(grdFacturasConsumos.Rows(I).Cells(ColumnasDelGridGastos.Seleccionar).Value) = True Then

                    'If IVA = 0 Then
                    '    IVA = grdFacturasConsumos.Rows(I).Cells(ColumnasDelGridGastos.Iva).Value
                    'End If

                    'If IVA <> grdFacturasConsumos.Rows(I).Cells(ColumnasDelGridGastos.Iva).Value Then
                    '    'MsgBox("Ha seleccionado Facturas con diferentes porcentajes de IVA. Por favor, verifique", MsgBoxStyle.Critical, "Atenci�n")
                    '    bandIVA = False
                    '    'Exit Function
                    'Else
                    '    bandIVA = True
                    'End If

                    Dim param_id As New SqlClient.SqlParameter
                    param_id.ParameterName = "@idgasto"
                    param_id.SqlDbType = SqlDbType.BigInt
                    param_id.Value = grdFacturasConsumos.Rows(I).Cells(ColumnasDelGridGastos.Id).Value
                    param_id.Direction = ParameterDirection.Input

                    subtotal = subtotal + grdFacturasConsumos.Rows(I).Cells(ColumnasDelGridGastos.Subtotal).Value
                    MONTOiva = MONTOiva + grdFacturasConsumos.Rows(I).Cells(ColumnasDelGridGastos.MontoIva).Value
                    'total = total + grdFacturasConsumos.Rows(I).Cells(ColumnasDelGridGastos.Total).Value
                    total = total + grdFacturasConsumos.Rows(I).Cells(ColumnasDelGridGastos.Deuda).Value

                    Try
                        SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spGastos_Insert_tmp", _
                                                  param_id)

                    Catch ex As Exception
                        Throw ex
                        Exit For
                    End Try
                Else
                    If bolModo = False Then
                        subtotal = subtotal + grdFacturasConsumos.Rows(I).Cells(ColumnasDelGridGastos.Subtotal).Value
                        MONTOiva = MONTOiva + grdFacturasConsumos.Rows(I).Cells(ColumnasDelGridGastos.MontoIva).Value
                        total = total + grdFacturasConsumos.Rows(I).Cells(ColumnasDelGridGastos.Total).Value
                        'total = CDbl(lblEntregado.Text)
                        Label14.Text = "Total"
                    Else
                        Label14.Text = "Total por Pagar"
                    End If
                End If
            Next

            lblSubtotal.Text = subtotal.ToString
            lblIVA.Text = MONTOiva.ToString
            lblTotal.Text = total.ToString

            lblTotalaPagarSinIva.Text = lblSubtotal.Text
            lblTotalaPagar.Text = lblTotal.Text

            Calcular_MontoEntregado()

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Function

    Private Function EliminarRegistro() As Integer
        Dim res As Integer = 0

        Try
            Try
                conn_del_form = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End Try

            'Abrir una transaccion para guardar y asegurar que se guarda todo
            If Abrir_Tran(conn_del_form) = False Then
                MessageBox.Show("No se pudo abrir una transaccion", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If

            Try

                Dim param_idPresGest As New SqlClient.SqlParameter("@id", SqlDbType.BigInt, ParameterDirection.Input)
                param_idPresGest.Value = CType(txtID.Text, Long)
                param_idPresGest.Direction = ParameterDirection.Input

                Dim param_userdel As New SqlClient.SqlParameter
                param_userdel.ParameterName = "@userdel"
                param_userdel.SqlDbType = SqlDbType.Int
                param_userdel.Value = UserID
                param_userdel.Direction = ParameterDirection.Input

                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.Output

                Try

                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Delete", _
                                              param_idPresGest, param_userdel, param_res)

                    EliminarRegistro = param_res.Value

                Catch ex As Exception
                    '' 


                    Throw ex
                End Try
            Finally
                ''
            End Try
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con Kaizen Software a trav�s del correo soporte@kaizensoftware.com.ar", errMessage), _
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Function

    Private Function Abrir_Tran(ByRef cnn As SqlClient.SqlConnection) As Boolean
        If tran Is Nothing Then
            Try
                tran = cnn.BeginTransaction
                Abrir_Tran = True
            Catch ex As Exception
                Abrir_Tran = False
                Exit Function
            End Try
        End If
    End Function

    ' Capturar los enter del formulario, descartar todos salvo los que 
    ' se dan dentro de la grilla. Es una sobre carga de un metodo existente.
    'Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

    '    ' Si la tecla presionada es distinta de la tecla Enter,
    '    ' abandonamos el procedimiento.
    '    '
    '    If keyData <> Keys.Return Then Return MyBase.ProcessCmdKey(msg, keyData)

    '    ' Igualmente, si el control DataGridView no tiene el foco,
    '    ' y si la celda actual no est� siendo editada,
    '    ' abandonamos el procedimiento.
    '    If (Not grdItems.Focused) AndAlso (Not grdItems.IsCurrentCellInEditMode) Then Return MyBase.ProcessCmdKey(msg, keyData)

    '    ' Obtenemos la celda actual
    '    Dim cell As DataGridViewCell = grdItems.CurrentCell
    '    ' �ndice de la columna.
    '    Dim columnIndex As Int32 = cell.ColumnIndex
    '    ' �ndice de la fila.
    '    Dim rowIndex As Int32 = cell.RowIndex

    '    'Do
    '    '    If columnIndex = grdItems.Columns.Count - 1 Then
    '    '        If rowIndex = grdItems.Rows.Count - 1 Then
    '    '            ' Seleccionamos la primera columna de la primera fila.
    '    '            cell = grdItems.Rows(0).Cells(ColumnasDelGridItems.IdPres_Ges_Det)
    '    '        Else
    '    '            ' Selecionamos la primera columna de la siguiente fila.
    '    '            cell = grdItems.Rows(rowIndex + 1).Cells(ColumnasDelGridItems.IdPres_Ges_Det)
    '    '        End If
    '    '    Else
    '    '        ' Seleccionamos la celda de la derecha de la celda actual.
    '    '        cell = grdItems.Rows(rowIndex).Cells(columnIndex + 1)
    '    '    End If
    '    '    ' establecer la fila y la columna actual
    '    '    columnIndex = cell.ColumnIndex
    '    '    rowIndex = cell.RowIndex
    '    'Loop While (cell.Visible = False)

    '    grdItems.CurrentCell = cell

    '    ' ... y la ponemos en modo de edici�n.
    '    grdItems.BeginEdit(True)
    '    Return True

    'End Function

#End Region

#Region "   Botones"

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        band = 0
        bolModo = True

        Label14.Text = "Total por Pagar"

        grdFacturasConsumos.Enabled = bolModo
        cmbProveedores.Enabled = bolModo
        txtOrdenPago.Enabled = bolModo
        dtpFECHA.Enabled = bolModo

        gpPago.Enabled = bolModo
        TabControl1.Enabled = bolModo

        Util.MsgStatus(Status1, "Haga click en [Guardar] despues de completar los datos.")
        PrepararBotones()

        Util.LimpiarTextBox(Me.Controls)

        dtpFechaTransf.Value = Date.Today

        txtProveedor.Visible = False

        lblTotal.Text = "0"
        lblSubtotal.Text = "0"
        lblIVA.Text = "0"
        lblEntregado.Text = "0"
        lblEntregaCheques.Text = "0"
        lblEntregaChequesPropios.Text = "0"
        lblEntregaTarjetas.Text = "0"
        lblEntregaTransferencias.Text = "0"
        lblResto.Text = "0"

        txtEntregaContado.Enabled = bolModo
        txtRedondeo.Enabled = bolModo

        LlenarComboBancos()
        LlenarComboCuentasOrigen()
        'LlenarComboImpuestos()

        grdFacturasConsumos.Columns(ColumnasDelGridGastos.Seleccionar).Visible = True

        LimpiarGrids()

        dtpFECHA.Value = Date.Today
        dtpFECHA.Focus()

        LlenarGridCheques_Terceros()
        LlenarGridCheques_Propios()

        band = 1

        cmbProveedores.SelectedIndex = 0

        cmbProveedores_SelectedIndexChanged(sender, e)

        cmbProveedores.Focus()

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim res As Integer

        Util.MsgStatus(Status1, "Controlando la informaci�n...", My.Resources.Resources.indicator_white)

        If txtOrdenPago.Text = "" Then
            If MessageBox.Show("No ha ingresado ninguna Orden de Pago del Proveedor. �Desea continuar sin este dato?", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                txtOrdenPago.Focus()
                Exit Sub
            End If
        End If

        If txtIdProveedor.Text = "" Then
            If MessageBox.Show("No ha ingresado un proveedor v�lido. Por favor, controle.", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                cmbProveedores.Focus()
                Exit Sub
            End If
        End If

        If ReglasNegocio() Then
            Verificar_Datos()
            If bolpoliticas Then
                Util.MsgStatus(Status1, "Guardando el registro...", My.Resources.Resources.indicator_white)
                res = AgregarRegistro_Pagos()
                Select Case res
                    Case -3
                        Cancelar_Tran()
                        Util.MsgStatus(Status1, "No se pudo realizar la insersi�n (Encabezado).", My.Resources.Resources.stop_error.ToBitmap)
                    Case -2
                        Cancelar_Tran()
                        Util.MsgStatus(Status1, "No se pudo actualizar el n�mero de Pago (Encabezado).", My.Resources.Resources.stop_error.ToBitmap)
                    Case -1
                        Cancelar_Tran()
                        Util.MsgStatus(Status1, "No se pudo actualizar el registro (Encabezado).", My.Resources.Resources.stop_error.ToBitmap)
                    Case 0
                        Cancelar_Tran()
                        Util.MsgStatus(Status1, "No se pudo agregar el registro (Encabezado).", My.Resources.Resources.stop_error.ToBitmap)
                    Case Else
                        Util.MsgStatus(Status1, "Guardando el detalle del pago...", My.Resources.Resources.indicator_white)
                        If bolModo = True Then
                            res = AgregarRegistro_PagosGastos()
                        End If
                        Select Case res
                            Case -3
                                Cancelar_Tran()
                                Util.MsgStatus(Status1, "No se pudo realizar la inserci�n del Pago (Detalle). Actualizaci�n en la tabla Gastos", My.Resources.Resources.stop_error.ToBitmap)
                            Case -2
                                Cancelar_Tran()
                                Util.MsgStatus(Status1, "No pudo registrar la inserci�n del Pago (Detalle).", My.Resources.Resources.stop_error.ToBitmap)
                            Case -1
                                Cancelar_Tran()
                                Util.MsgStatus(Status1, "Error Desconocido.", My.Resources.Resources.stop_error.ToBitmap)
                            Case 0
                                Cancelar_Tran()
                                Util.MsgStatus(Status1, "No pudo registrar la inserci�n del Pago (Detalle).", My.Resources.Resources.stop_error.ToBitmap)
                            Case Else

                                Util.MsgStatus(Status1, "Guardando la informaci�n sobre el detalle de los Cheques Propios...", My.Resources.Resources.indicator_white)

                                If bolModo = False Then
                                    ControlarCantidad_Cheques_Propios()
                                End If

                                res = AgregarRegistro_Cheques_Propios()

                                Select Case res
                                    Case -3
                                        Cancelar_Tran()
                                        Util.MsgStatus(Status1, "No se pudo actualizar la OC.", My.Resources.Resources.stop_error.ToBitmap)
                                    Case -1
                                        Cancelar_Tran()
                                        Util.MsgStatus(Status1, "No se pudo registrar los remitos.", My.Resources.Resources.stop_error.ToBitmap)
                                    Case 0
                                        Cancelar_Tran()
                                        Util.MsgStatus(Status1, "No se pudo regitrar los remitos.", My.Resources.Resources.stop_error.ToBitmap)
                                    Case Else
                                        Util.MsgStatus(Status1, "Guardando la informaci�n en la cuenta...", My.Resources.Resources.indicator_white)

                                        If bolModo = False Then
                                            EliminarItems_Cheques_Propios()
                                        End If

                                End Select

                                Util.MsgStatus(Status1, "Guardando la informaci�n sobre el detalle de los Cheques de Terceros...", My.Resources.Resources.indicator_white)

                                If bolModo = False Then
                                    ControlarCantidad_Cheques()
                                Else
                                    res = 1
                                End If

                                res = AgregarRegistro_Cheques_Terceros()
                                Select Case res
                                    Case -1
                                        Cancelar_Tran()
                                        Util.MsgStatus(Status1, "No se pudo registrar los cheques para este pago.", My.Resources.Resources.stop_error.ToBitmap)
                                    Case 0
                                        Cancelar_Tran()
                                        Util.MsgStatus(Status1, "No se pudo registrar los cheques para este pago.", My.Resources.Resources.stop_error.ToBitmap)
                                    Case Else
                                        Util.MsgStatus(Status1, "Cheques guardados correctamente...", My.Resources.Resources.indicator_white)

                                        If bolModo = False Then
                                            EliminarItems_Cheques()
                                        End If
                                End Select

                                Util.MsgStatus(Status1, "Guardando la informaci�n sobre el detalle de las Transferencias...", My.Resources.Resources.indicator_white)

                                If bolModo = False Then
                                    ControlarCantidad_Transferencias()
                                End If

                                res = AgregarRegistro_Transferencias()

                                Select Case res
                                    Case -3
                                        Cancelar_Tran()
                                        Util.MsgStatus(Status1, "No se pudo actualizar el detalle de las Transferencias.", My.Resources.Resources.stop_error.ToBitmap)
                                    Case -1
                                        Cancelar_Tran()
                                        Util.MsgStatus(Status1, "No se pudo registrar el detalle de las Transferencias.", My.Resources.Resources.stop_error.ToBitmap)
                                    Case 0
                                        Cancelar_Tran()
                                        Util.MsgStatus(Status1, "Error desconocido en la Inserci�n/Actualizaci�n de las Transferencias.", My.Resources.Resources.stop_error.ToBitmap)
                                    Case Else
                                        Util.MsgStatus(Status1, "Guardando la informaci�n en la cuenta...", My.Resources.Resources.indicator_white)

                                        If bolModo = False Then
                                            EliminarItems_Transferencias()
                                        End If

                                End Select

                                Util.MsgStatus(Status1, "Cerrando y generando el comprobante", My.Resources.Resources.indicator_white)
                                Cerrar_Tran()

                                'Imprimir()

                                bolModo = False
                                PrepararBotones()
                                btnActualizar_Click(sender, e)

                                txtProveedor.Visible = True

                                Me.Label5.Visible = False
                                Util.MsgStatus(Status1, "Se ha actualizado el registro.", My.Resources.Resources.ok.ToBitmap)

                                grdFacturasConsumos.Columns(ColumnasDelGridGastos.Seleccionar).Visible = False
                                txtCODIGO.Enabled = bolModo
                                dtpFECHA.Enabled = bolModo

                                LlenarComboProveedores()

                                grd_CurrentCellChanged(sender, e)

                        End Select
                End Select
                '
                ' cerrar la conexion si est� abierta.
                '
                If Not conn_del_form Is Nothing Then
                    CType(conn_del_form, IDisposable).Dispose()
                End If
            End If 'If bolpoliticas Then
        End If 'If ReglasNegocio() Then

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        nbreformreportes = "Comprobante de Pago"

        Dim paramConsumos As New frmParametros
        Dim cnn As New SqlConnection(ConnStringSEI)
        Dim codigo As String
        Dim Rpt As New frmReportes

        paramConsumos.AgregarParametros("N� de Mov:", "STRING", "", False, txtCODIGO.Text.ToString, "", cnn)

        paramConsumos.ShowDialog()

        If cerroparametrosconaceptar = True Then
            codigo = paramConsumos.ObtenerParametros(0)

            Imprimir_LlenarTMPs(codigo)

            Rpt.PagoaProveedores_App(codigo, Rpt, My.Application.Info.AssemblyName.ToString)

            cerroparametrosconaceptar = False
            paramConsumos = Nothing
            cnn = Nothing
        End If

    End Sub

    Private Overloads Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        LlenarGridGastos(CType(cmbProveedores.SelectedValue, Long))
        AgregarRemito_tmp()

        grdFacturasConsumos.Enabled = bolModo

        'cmbCliente.Visible = False

        grdFacturasConsumos.Columns(ColumnasDelGridGastos.Seleccionar).Visible = False

        txtProveedor.Visible = True
        txtOrdenPago.Enabled = bolModo
        dtpFECHA.Enabled = bolModo

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim res As Integer

        If MessageBox.Show("Esta acci�n anular� el Pago y actualizar� el estado del o los Gastos asociados." + vbCrLf + "Si existen Cheques Propios vinculados ser�n eliminados." + vbCrLf + "�Est� seguro que desea continuar?", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Util.MsgStatus(Status1, "Anulando el registro...", My.Resources.Resources.indicator_white)
            res = EliminarRegistro()
            Select Case res
                Case 0
                    Cancelar_Tran()
                    Util.MsgStatus(Status1, "No pudo realizarse la anulaci�n.", My.Resources.Resources.stop_error.ToBitmap)
                    Util.MsgStatus(Status1, "No pudo realizarse la anulaci�n.", My.Resources.Resources.stop_error.ToBitmap, True)
                Case -1
                    Cancelar_Tran()
                    Util.MsgStatus(Status1, "No pudo realizarse la anulaci�n.", My.Resources.Resources.stop_error.ToBitmap)
                    Util.MsgStatus(Status1, "No pudo realizarse la anulaci�n.", My.Resources.Resources.stop_error.ToBitmap, True)
                Case Else
                    Cerrar_Tran()
                    bolModo = False
                    PrepararBotones()
                    btnActualizar_Click(sender, e)
                    'Setear_Grilla()
                    Util.MsgStatus(Status1, "Se anul� correctamente el movimiento de Pago.", My.Resources.Resources.ok.ToBitmap)
                    Util.MsgStatus(Status1, "Se anul� correctamente el movimiento de Pago.", My.Resources.Resources.ok.ToBitmap, True, True)
            End Select
            '
            ' cerrar la conexion si est� abierta.
            '
            If Not conn_del_form Is Nothing Then
                CType(conn_del_form, IDisposable).Dispose()
            End If
        End If

    End Sub

#End Region

#Region "   Transferencias"

    Private Sub btnNuevoTransferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoTransferencia.Click
        txtNroOpCliente.Text = ""
        txtMontoTransf.Text = ""
        cmbCuentaDestino.Text = ""
        cmbCuentaOrigen.Text = ""
        txtObservacionesTransf.Text = ""

        txtNroOpCliente.Focus()
    End Sub

    Private Sub btnModificarTransf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarTransf.Click
        Dim I As Integer

        For I = 0 To grdTransferencias.RowCount - 1
            If I <> grdTransferencias.CurrentRow.Index Then
                If grdTransferencias.Rows(I).Cells(0).Value = txtNroOpCliente.Text Then
                    Util.MsgStatus(Status1, "Ya existe este nro de OpCliente para este pago. Por favor, revise esta informaci�n.", My.Resources.Resources.alert.ToBitmap, True)
                    Exit Sub
                End If
            End If
        Next

        grdTransferencias.CurrentRow.Cells(0).Value = txtNroOpCliente.Text
        grdTransferencias.CurrentRow.Cells(1).Value = cmbCuentaOrigen.Text
        grdTransferencias.CurrentRow.Cells(2).Value = CDec(txtMontoTransf.Text)
        grdTransferencias.CurrentRow.Cells(3).Value = cmbCuentaDestino.Text
        grdTransferencias.CurrentRow.Cells(4).Value = dtpFechaTransf.Value
        grdTransferencias.CurrentRow.Cells(5).Value = 1
        grdTransferencias.CurrentRow.Cells(6).Value = cmbBancoOrigen.Text
        grdTransferencias.CurrentRow.Cells(7).Value = cmbBancoDestino.Text
        grdTransferencias.CurrentRow.Cells(8).Value = txtObservacionesTransf.Text

        lblEntregaTransferencias.Text = "0"

        For I = 0 To grdTransferencias.RowCount - 1
            lblEntregaTransferencias.Text = CDbl(lblEntregaTransferencias.Text) + grdTransferencias.Rows(I).Cells(2).Value
        Next

        Calcular_MontoEntregado()

        btnAgregarTransf_Click(sender, e)

    End Sub

    Private Sub btnAgregarTransf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarTransf.Click

        If txtMontoTransf.Text = "" Then
            Util.MsgStatus(Status1, "Debe ingresar el Monto de la Transferencia.", My.Resources.Resources.alert.ToBitmap)
            Util.MsgStatus(Status1, "Debe ingresar el Monto de la Transferencia.", My.Resources.Resources.alert.ToBitmap, True)
            txtMontoTransf.Focus()
            Exit Sub
        End If

        Dim i As Integer

        For i = 0 To grdTransferencias.RowCount - 1
            If grdTransferencias.Rows(i).Cells(0).Value = txtNroOpCliente.Text And txtNroOpCliente.Text <> "" Then
                Util.MsgStatus(Status1, "Ya existe una transfernecia con este Nro de OP para este pago. Por favor, revise esta informaci�n.", My.Resources.Resources.alert.ToBitmap, True)
                Exit Sub
            End If
        Next

        Try
            grdTransferencias.Rows.Add(txtNroOpCliente.Text, cmbCuentaOrigen.Text, CDec(txtMontoTransf.Text), cmbCuentaDestino.Text, dtpFechaTransf.Value, 1, cmbBancoOrigen.Text, cmbBancoDestino.Text, txtObservacionesTransf.Text)
        Catch ex As Exception
            Exit Sub
        End Try

        lblEntregaTransferencias.Text = CDbl(lblEntregaTransferencias.Text) + CDbl(txtMontoTransf.Text)

        Calcular_MontoEntregado()

        btnNuevoTransferencia_Click(sender, e)

    End Sub

    Private Sub btnEliminarTransf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarTransf.Click
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)

            If Not grdTransferencias.CurrentRow.Cells(9).Value Is Nothing Then
                SqlHelper.ExecuteNonQuery(connection, CommandType.Text, "DELETE FROM TMP_Transferencias_Pagos where idtransferencia = " & grdTransferencias.CurrentRow.Cells(9).Value)
            End If

            grdTransferencias.Rows.Remove(grdTransferencias.CurrentRow)

            lblEntregaTransferencias.Text = "0"

            Dim i As Integer

            For i = 0 To grdTransferencias.RowCount - 1
                lblEntregaTransferencias.Text = CDbl(lblEntregaTransferencias.Text) + grdTransferencias.Rows(i).Cells(2).Value
            Next

            Calcular_MontoEntregado()

        Catch ex As Exception

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub grdTransferencias_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTransferencias.SelectionChanged
        If Not grdTransferencias.CurrentRow Is Nothing Then
            txtNroOpCliente.Text = grdTransferencias.CurrentRow.Cells(0).Value
            cmbCuentaOrigen.Text = grdTransferencias.CurrentRow.Cells(1).Value
            txtMontoTransf.Text = grdTransferencias.CurrentRow.Cells(2).Value
            cmbCuentaDestino.Text = grdTransferencias.CurrentRow.Cells(3).Value
            dtpFechaTransf.Value = grdTransferencias.CurrentRow.Cells(4).Value
            cmbMonedaTransf.SelectedValue = grdTransferencias.CurrentRow.Cells(5).Value
            cmbBancoOrigen.Text = grdTransferencias.CurrentRow.Cells(6).Value
            cmbBancoDestino.Text = grdTransferencias.CurrentRow.Cells(7).Value
            txtObservacionesTransf.Text = grdTransferencias.CurrentRow.Cells(8).Value
        Else
            txtNroOpCliente.Text = ""
            txtMontoTransf.Text = ""
            cmbCuentaDestino.Text = ""
            cmbCuentaOrigen.Text = ""
            txtObservacionesTransf.Text = ""
        End If
    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#Region "   Cheques"

    'Private Sub btnNuevoCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    txtNroCheque.Text = ""
    '    txtObservacionesCheque.Text = ""
    '    txtMontoCheque.Text = ""
    '    txtPropietario.Text = "SEI SRL"
    '    txtNroCheque.Focus()
    'End Sub

    'Private Sub btnModificarCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'modificar = 1
    '    'btnAgregarCheque_Click(sender, e)

    '    Dim I As Integer

    '    For I = 0 To grdChequesPropios.RowCount - 1
    '        If I <> grdChequesPropios.CurrentRow.Index Then
    '            If grdChequesPropios.Rows(I).Cells(0).Value = txtNroCheque.Text Then
    '                Util.MsgStatus(Status1, "Ya existe un cheque con este Nro para este pago. Por favor, revise esta informaci�n.", My.Resources.Resources.alert.ToBitmap, True)
    '                Exit Sub
    '            End If
    '        End If
    '    Next

    '    grdChequesPropios.CurrentRow.Cells(0).Value = txtNroCheque.Text
    '    grdChequesPropios.CurrentRow.Cells(1).Value = cmbBanco.Text
    '    grdChequesPropios.CurrentRow.Cells(2).Value = CDec(txtMontoCheque.Text)
    '    grdChequesPropios.CurrentRow.Cells(3).Value = dtpFechaCheque.Value
    '    grdChequesPropios.CurrentRow.Cells(4).Value = txtPropietario.Text
    '    grdChequesPropios.CurrentRow.Cells(5).Value = 1 'cmbMoneda.SelectedValue
    '    grdChequesPropios.CurrentRow.Cells(6).Value = txtObservacionesCheque.Text

    '    lblEntregaChequesPropios.Text = "0"

    '    For I = 0 To grdChequesPropios.RowCount - 1
    '        lblEntregaChequesPropios.Text = CDbl(lblEntregaChequesPropios.Text) + grdChequesPropios.Rows(I).Cells(2).Value
    '    Next

    '    Calcular_MontoEntregado()

    '    btnNuevoCheque_Click(sender, e)

    'End Sub

    'Private Sub btnAgregarCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If txtNroCheque.Text = "" Then
    '        Util.MsgStatus(Status1, "Debe ingresar el n�mero del cheque.", My.Resources.Resources.alert.ToBitmap)
    '        Util.MsgStatus(Status1, "Debe ingresar el n�mero del cheque.", My.Resources.Resources.alert.ToBitmap, True)
    '        txtNroCheque.Focus()
    '        Exit Sub
    '    End If

    '    If cmbBanco.Text = "" Then
    '        Util.MsgStatus(Status1, "Debe ingresar el nombre del Banco.", My.Resources.Resources.alert.ToBitmap)
    '        Util.MsgStatus(Status1, "Debe ingresar el nombre del Banco.", My.Resources.Resources.alert.ToBitmap, True)
    '        cmbBanco.Focus()
    '        Exit Sub
    '    End If

    '    If txtMontoCheque.Text = "" Then
    '        Util.MsgStatus(Status1, "Debe ingresar el monto del cheque.", My.Resources.Resources.alert.ToBitmap)
    '        Util.MsgStatus(Status1, "Debe ingresar el monto del cheque.", My.Resources.Resources.alert.ToBitmap, True)
    '        txtMontoCheque.Focus()
    '        Exit Sub
    '    End If

    '    Dim i As Integer

    '    For i = 0 To grdChequesPropios.RowCount - 1
    '        If grdChequesPropios.Rows(i).Cells(0).Value = txtNroCheque.Text Then
    '            Util.MsgStatus(Status1, "Ya existe un cheque con este Nro para este pago. Por favor, revise esta informaci�n.", My.Resources.Resources.alert.ToBitmap, True)
    '            Exit Sub
    '        End If
    '    Next

    '    Try
    '        grdChequesPropios.Rows.Add(txtNroCheque.Text, cmbBanco.Text, CDec(txtMontoCheque.Text), dtpFechaCheque.Value, "SEI SRL", 1, txtObservacionesCheque.Text)
    '    Catch ex As Exception
    '        Exit Sub
    '    End Try

    '    lblEntregaChequesPropios.Text = CDbl(lblEntregaChequesPropios.Text) + CDbl(txtMontoCheque.Text)

    '    Calcular_MontoEntregado()


    'End Sub

    'Private Sub btnEliminarCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim connection As SqlClient.SqlConnection = Nothing

    '    Try

    '        If grdChequesPropios.CurrentRow.Cells(8).Value Is DBNull.Value Or grdChequesPropios.CurrentRow.Cells(8).Value = False Then
    '            connection = SqlHelper.GetConnection(ConnStringSEI)

    '            If Not grdChequesPropios.CurrentRow.Cells(7).Value Is Nothing Then
    '                SqlHelper.ExecuteNonQuery(connection, CommandType.Text, "DELETE FROM TMP_Cheques_Ingreso where idCheque = " & grdChequesPropios.CurrentRow.Cells(7).Value)
    '            End If

    '            grdChequesPropios.Rows.Remove(grdChequesPropios.CurrentRow)

    '            lblEntregaChequesPropios.Text = "0"

    '            Dim i As Integer

    '            For i = 0 To grdChequesPropios.RowCount - 1
    '                lblEntregaChequesPropios.Text = CDbl(lblEntregaChequesPropios.Text) + grdChequesPropios.Rows(i).Cells(2).Value
    '            Next

    '            Calcular_MontoEntregado()

    '        Else
    '            MsgBox("El cheque que intenta eliminar se encuentra utilizado en otro proceso")
    '        End If

    '    Catch ex As Exception

    '    Finally
    '        If Not connection Is Nothing Then
    '            CType(connection, IDisposable).Dispose()
    '        End If
    '    End Try

    'End Sub

    'Private Sub grdChequesPropios2_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdChequesPropios.CellValueChanged
    '    Try

    '        If e.ColumnIndex = ColumnasDelGridCheques.Seleccionar Then
    '            'Dim i As Integer
    '            'lblEntregaCheques.Text = "0"
    '            'Dim subtotal As Double = 0

    '            'For i = 0 To grdCheques.RowCount - 1

    '            '    If CBool(grdCheques.Rows(i).Cells(ColumnasDelGridCheques.Seleccionar).Value) = True Then

    '            '        subtotal = subtotal + grdCheques.Rows(i).Cells(ColumnasDelGridCheques.MontoCheque).Value

    '            '        'Else
    '            '        'If bolModo = False Then
    '            '        ' subtotal = subtotal + grdCheques.Rows(i).Cells(ColumnasDelGridCheques.MontoCheque).Value
    '            '        'End If
    '            '    End If

    '            'Next

    '            'lblEntregaCheques.Text = subtotal.ToString

    '            'Calcular_MontoEntregado()


    '        End If

    '    Catch ex As Exception
    '        MsgBox("Error en Sub grdCheques_CellClick", MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub

#End Region

End Class