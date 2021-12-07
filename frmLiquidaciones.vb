Imports Microsoft.ApplicationBlocks.Data
Imports Utiles
Imports Utiles.Util
Imports System.Data.SqlClient
Imports ReportesNet
Imports System.Data.OleDb
Imports System.IO
Imports ExcelDataReader
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.SuperGrid.Style



Public Class frmLiquidaciones
    Dim IdObraSocial
    Dim bolIDOS As Boolean = False
    Dim DataBindingComplete As Boolean = False

    Dim bolpoliticas As Boolean
    Dim columnaprueba As Integer
    Dim permitir_evento_CellChanged As Boolean
    Dim RowofError As Integer 'Variable en la que guardo la fila con valores distintos
    'Variables para la grilla
    Dim editando_celda As Boolean

    Dim llenandoCombo As Boolean = False

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

    'constantes para identificar las columnas de la grilla por nombre 
    ' en vez de número


    '    IdObraSocial = "0"
    'Farmacia = "1"
    'Recetas = "2"
    'ImpTotal = "3"
    'Bonificacion = "4" 
    'PorPagar = "5"

    Enum ColumnasDelGridItems
        ID = 0
        IdFarmacia = 1
        CodigoFarmacia = 2
        Farmacia = 3
        IdPresentacion = 4
        Recetas = 5
        Recaudado = 6
        ACargoOS = 7
        Bonificacion = 8
        Total = 9
    End Enum

    'Enum ColumnasDelgrdDetLiquidacionOs
    '    ID = 0
    '    IdFarmacia = 1
    '    Farmacia = 2
    '    IdPresentacion = 3
    '    Recetas = 4
    '    Recaudado = 5
    '    ACargoOS = 6
    '    Bonificacion = 7
    '    Total = 8
    'End Enum

    Enum ColumnasDelGridItems1
        IDRecepcion_Det = 0
        Cod_RecepcionDet = 1
        IDMaterial = 2
        Cod_Material = 3
        Cod_Mat_Prov = 4
        Nombre_Material = 5
        IdUnidad = 6
        CodUnidad = 7
        Unidad = 8
        IdMoneda = 9
        CodMoneda = 10
        Moneda = 11
        ValorCambio = 12
        PrecioLista = 13
        IVA = 14
        Bonif1 = 15
        Bonif2 = 16
        Bonif3 = 17
        Bonif4 = 18
        Bonif5 = 19
        Ganancia = 20
        PrecioListaReal = 21
        QtyPedido = 22
        QtyRecep = 23
        PrecioCosto = 24
        PorcDif = 25
        Remito = 26
        ID_OrdenDeCompra = 27
        ID_OrdenDeCompra_Det = 28
        QtySaldo = 29
        Status = 30
        FechaCumplido = 31
        PrecioEnPesos = 32
        PrecioEnPesosNuevo = 33
        Nuevo = 34
        IdMaterial_Prov = 35
        item = 36
        PrecioMayorista = 37
        PrecioRevendedor = 38
        PrecioYamila = 39
        PrecioLista4 = 40
        PrecioPeron = 41
        PrecioMayoPeron = 42
        CantidadPack = 43
        IdMarca = 44
    End Enum

    'Enum ColumnasDelGridItems1IVA
    '    id = 0
    '    Subtotal = 1
    '    PorcIva = 2
    '    MontoIVA = 3
    'End Enum

    Enum ColumnasDelGridImpuestos
        Id = 0
        codigo = 1
        NroDocumento = 2
        Monto = 3
        IdIngreso = 4
        IdImpuestoxGasto = 5
    End Enum

    'Auxiliares para guardar
    Dim cod_aux As String

    'Auxiliares para chequear lo digitado en la columna cantidad
    Dim qty_digitada As String

    Dim band As Integer

    Dim tranWEB As New WS_Porkys.WS_PorkysSoapClient


#Region "   Eventos"

    Private Sub frmAjustes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnSalir_Click(sender, e)
    End Sub

    Private Sub frmRecepciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3 'nuevo
                If bolModo = True Then
                    If MessageBox.Show("No ha guardado la Recepción Nueva que está realizando. ¿Está seguro que desea continuar sin Grabar y hacer una Orde de Compra Nueva?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        btnNuevo_Click(sender, e)
                    End If
                Else
                    btnNuevo_Click(sender, e)
                End If
            Case Keys.F4 'grabar
                btnGuardar_Click(sender, e)
        End Select
    End Sub

    Private Sub frmRecepciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GroupPanelDetalleLiquidacion.Visible = False

        'lblTotal.Visible = False
        cmbObraSocial.Visible = True
        lblcmbObrasSociales.Visible = True
        Cursor = Cursors.WaitCursor

        ToolStrip_lblCodMaterial.Visible = True
        txtBusquedaMAT.Visible = True

        With grdDetalleLiquidacion
            .VirtualMode = False
            .EnableHeadersVisualStyles = False
            .ColumnHeadersBorderStyle = 1
            .AllowUserToAddRows = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .RowsDefaultCellStyle.BackColor = Color.White
            .AllowUserToOrderColumns = False
            '.SelectionMode = DataGridViewSelectionMode.CellSelect
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        End With

        With grdDetalleLiquidacion.ColumnHeadersDefaultCellStyle
            .BackColor = Color.LightBlue  'Color.BlueViolet
            .ForeColor = Color.Black
            .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        End With

        grdDetalleLiquidacion.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Regular)

        With grdDetalleLiquidacionFiltrada
            .VirtualMode = False
            .AllowUserToAddRows = False
            .EnableHeadersVisualStyles = False
            .ColumnHeadersBorderStyle = 1
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .RowsDefaultCellStyle.BackColor = Color.White
            .AllowUserToOrderColumns = False
            '.SelectionMode = DataGridViewSelectionMode.CellSelect
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        End With

        With grdDetalleLiquidacionFiltrada.ColumnHeadersDefaultCellStyle
            .BackColor = Color.LightBlue  'Color.BlueViolet
            .ForeColor = Color.Black
            .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        End With

        grdDetalleLiquidacionFiltrada.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Regular)

        'Try

        '    Dim sqlstring As String = "update [" & NameTable_NotificacionesWEB & "] set BloqueoR = 1 where idalmacen <> " & Util.numero_almacen
        '    tranWEB.Sql_Set(sqlstring)
        'Catch ex As Exception

        'End Try

        band = 0
        'Modifico botones del frmbase
        btnEliminar.Text = "Eliminar Liquidación"
        ToolStrip_lblCodMaterial.Text = "Cod. Liq."
        btnCancelar.Visible = False
        btnPrimero.Visible = False
        btnAnterior.Visible = False
        btnSiguiente.Visible = False
        btnUltimo.Visible = False
        PicConexion.Visible = False
        lblConexion.Visible = False
        ToolStripPagina.Visible = False
        btnActivar.Visible = False
        lblcuit.Visible = False
        ' LlenarGrid_grdDetLiquidacionOs()
        configurarform()
        asignarTags()
        rdPendientes.Checked = 1
        LlenarcmbUsuarioGasto()

        'IdObraSocial = cmbObraSocial.SelectedValue

        'SQL = $"exec spPresentaciones_Select_All @Pendientes = {rdPendientes.Checked} ,@Eliminado = {rdAnuladas.Checked} ,@Todos = {rdTodasOC.Checked}"
        SQL = $"exec spLiquidaciones_Select_All"
        LlenarGrilla()

        Permitir = True
        CargarCajas()
        PrepararBotones()

        'Setear_Grilla()

        If bolModo = True Then
            'LlenarGrid_Items()
            'LlenarGrid_IVA(0)
            'LlenarGrid_Impuestos()
            band = 1
            btnNuevo_Click(sender, e)
        Else
            btnLlenarGrilla.Enabled = bolModo
            ' LlenarGrid_Items2()
            'chkAsociarFacturaCargada.Enabled = bolModo
            'cmbAsociarFacturaCargada.Enabled = bolModo

            Try
                'LlenarGrid_IVA(CType(txtIdGasto.Text, Long))

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            'LlenarGrid_Impuestos()

        End If


        'cmbProveedor.SelectedIndex = 0



        'txtProveedor.Visible = Not bolModo
        'txtOC.Visible = Not bolModo

        permitir_evento_CellChanged = True

        'grd_CurrentCellChanged(sender, e)


        'Oculto las columnas en el grd
        'grd.Columns(3).Visible = False
        'grd.Columns(4).Visible = False
        'grd.Columns(5).Visible = False
        'grd.Columns(10).Visible = False
        'grd.Columns(23).Visible = False
        'grd.Columns(26).Visible = False
        'grd.Columns(27).Visible = False
        'grd.Columns(30).Visible = False
        'grd.Columns(31).Visible = False



        'If grd.RowCount > 0 Then
        '    txtCantIVA.Value = grd.CurrentRow.Cells(31).Value
        '    chkCargarFactura.Enabled = False
        '    chkCargarFactura_CheckedChanged(sender, e)
        'End If

        Contar_Filas()

        dtpFECHA.MaxDate = Today.Date

        band = 1

        Cursor = Cursors.Default

    End Sub

    Private Sub txtID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtID.TextChanged
        If txtID.Text <> "" And bolModo = False Then
            Presentacion_request(
                "exec spLiquidaciones_Det_Select_By_IDLiquidacion @IDLiquidacion = " & txtID.Text & "",
                "exec spConceptos_Select_By_IDLiquidacion @IDLiquidacion = " & txtID.Text & ""
            )
        End If
    End Sub

    Private Sub grdItems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        editando_celda = True
    End Sub

    Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txtID.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub dtpfecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
     Handles dtpFECHA.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub grditems_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Cell_X = e.ColumnIndex
        Cell_Y = e.RowIndex
    End Sub

    Private Sub grdItems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        'Dim columna As Integer = 0
        'columna = grdItems.CurrentCell.ColumnIndex

        ''If columna = ColumnasDelGridItems1.ID_OrdenDeCompra Then
        'If columna = 7 Then
        '    If e.KeyCode = Keys.F5 And bolModo Then
        '        Dim f As New ICYS.frmOrdenCompra
        '        LLAMADO_POR_FORMULARIO = True
        '        ARRIBA = 40
        '        IZQUIERDA = Me.Left - 150
        '        'texto_del_combo = cmbPROVEEDORES.Text.ToUpper.ToString
        '        f.ShowDialog()
        '        'MsgBox(ID_ORDEN_DE_COMPRA_DET.ToString)

        '        If STATUS_ORDEN_DE_COMPRA_DET = "CUMPLIDO" Then
        '            MsgBox("El item seleccionado esta cumplido. NO se puede cargar.", MsgBoxStyle.Information, "Atención")
        '        Else
        '            Me.grdItems.CurrentRow.Cells.Item(ColumnasDelGridItems1.ID_OrdenDeCompra).Value = ID_ORDEN_DE_COMPRA
        '            Me.grdItems.CurrentRow.Cells.Item(ColumnasDelGridItems1.ID_OrdenDeCompra_Det).Value = ID_ORDEN_DE_COMPRA_DET
        '            Me.grdItems.CurrentRow.Cells.Item(ColumnasDelGridItems1.IDMaterial).Value = ID_MATERIAL
        '            Me.grdItems.CurrentRow.Cells.Item(ColumnasDelGridItems1.Cod_Material).Value = CODIGO_MATERIAL
        '            Me.grdItems.CurrentRow.Cells.Item(ColumnasDelGridItems1.Nombre_Material).Value = NOMBRE_MATERIAL
        '            Me.grdItems.CurrentRow.Cells.Item(ColumnasDelGridItems1.IDUnidad).Value = ID_UNIDAD
        '            Me.grdItems.CurrentRow.Cells.Item(ColumnasDelGridItems1.Unidad).Value = UNIDAD_MATERIAL

        '        End If
        '    End If
        'End If

    End Sub

    Private Sub cmbOrdenDeCompra_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If band = 1 Then
            If llenandoCombo = False Then
                btnLlenarGrilla_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub cmbOrdenDeCompra_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        If band = 1 Then
            If llenandoCombo = False Then
                btnLlenarGrilla_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub cmbTipoComprobante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


        lblTotal.Text = "0"


        'If cmbTipoComprobante.Text = "FACTURAS A" Or _
        '    cmbTipoComprobante.Text = "NOTAS DE CREDITO A" Or _
        '    cmbTipoComprobante.Text = "NOTAS DE DEBITO A" Or _
        '    cmbTipoComprobante.Text = "RECIBOS A" Or _
        '    cmbTipoComprobante.Text = "FACTURAS M" Or _
        '    cmbTipoComprobante.Text = "NOTAS DE CREDITO M" Or _
        '    cmbTipoComprobante.Text = "NOTAS DE DEBITO M" Or _
        '    cmbTipoComprobante.Text = "RECIBOS M" Or _
        '    cmbTipoComprobante.Text = "TIQUE FACTURA A" Then
        '    txtCantIVA.Enabled = True
        '    txtCantIVA.Value = 1
        '    txtMontoIVA10.Enabled = True
        '    txtMontoIVA21.Enabled = True
        '    txtMontoIVA27.Enabled = True
        'Else
        '    txtCantIVA.Enabled = False
        '    txtCantIVA.Value = 0
        '    txtMontoIVA10.Enabled = False
        '    txtMontoIVA21.Enabled = False
        '    txtMontoIVA27.Enabled = False
        'End If

    End Sub

    Private Sub txtSubtotal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If band = 1 Then
            'If txtSubtotal.Text <> "" Then

            '    'If cmbTipoComprobante.Text = "FACTURAS A" Or _
            '    '    cmbTipoComprobante.Text = "NOTAS DE CREDITO A" Or _
            '    '    cmbTipoComprobante.Text = "NOTAS DE DEBITO A" Or _
            '    '    cmbTipoComprobante.Text = "RECIBOS A" Or _
            '    '    cmbTipoComprobante.Text = "FACTURAS M" Or _
            '    '    cmbTipoComprobante.Text = "NOTAS DE CREDITO M" Or _
            '    '    cmbTipoComprobante.Text = "NOTAS DE DEBITO M" Or _
            '    '    cmbTipoComprobante.Text = "RECIBOS M" Or _
            '    '    cmbTipoComprobante.Text = "TIQUE FACTURA A" Then

            '    '    txtMontoIVA21.Text = Format(txtSubtotal.Text * 0.21, "###0.00")

            '    '    CalcularMontoIVA()

            '    'End If

            '    If lblImpuestos.Text = "" Then lblImpuestos.Text = "0"
            '    If lblMontoIva.Text = "" Then lblMontoIva.Text = "0"
            '    If txtSubtotal.Text = "" Then txtSubtotal.Text = "0"
            '    If txtSubtotalExento.Text = "" Then txtSubtotalExento.Text = "0"

            '    lblTotal.Text = CDbl(txtSubtotalExento.Text) + CDbl(txtSubtotal.Text) + CDbl(lblMontoIva.Text) + CDbl(lblImpuestos.Text)

            'End If

        End If
    End Sub

    Private Sub txtsubtotalNoGravado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtSubtotalNoGravado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If band = 1 Then
            'If txtSubtotalExento.Text <> "" Then

            '    If lblImpuestos.Text = "" Then lblImpuestos.Text = "0"
            '    If lblMontoIva.Text = "" Then lblMontoIva.Text = "0"
            '    If txtSubtotal.Text = "" Then txtSubtotal.Text = "0"

            '    lblTotal.Text = CDbl(txtSubtotalExento.Text) + CDbl(txtSubtotal.Text) + CDbl(lblMontoIva.Text) + CDbl(lblImpuestos.Text)
            'End If
        End If
    End Sub

    Private Sub chkAnuladas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAnuladas.CheckedChanged
        btnGuardar.Enabled = Not chkAnuladas.Checked
        btnEliminar.Enabled = Not chkAnuladas.Checked
        btnNuevo.Enabled = Not chkAnuladas.Checked
        btnCancelar.Enabled = Not chkAnuladas.Checked

        If chkAnuladas.Checked = True Then
            'SQL = "exec spRecepciones_Select_All @Eliminado = 1"
        Else
            'SQL = "exec spRecepciones_Select_All @Eliminado = 0"
        End If

        LlenarGrilla()

    End Sub

    Private Sub chkGrillaInferior_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGrillaInferior.CheckedChanged
        Dim xgrd As Long, ygrd As Long, hgrd As Long, variableajuste As Long
        xgrd = grd.Location.X
        ygrd = grd.Location.Y
        hgrd = grd.Height

        variableajuste = 125

        'If chkGrillaInferior.Checked = True Then
        '    chkGrillaInferior.Text = "Disminuir Grilla Inferior"
        '    chkGrillaInferior.Location = New Point(chkGrillaInferior.Location.X, chkGrillaInferior.Location.Y - variableajuste)
        '    GroupBox1.Height = GroupBox1.Height - variableajuste
        '    grd.Location = New Point(xgrd, ygrd - variableajuste)
        '    grd.Height = hgrd + variableajuste
        '    grdItems.Height = grdItems.Height - variableajuste
        '    Label19.Location = New Point(Label19.Location.X, Label19.Location.Y - variableajuste)
        '    lblCantidadFilas.Location = New Point(lblCantidadFilas.Location.X, lblCantidadFilas.Location.Y - variableajuste)

        'Else
        '    chkGrillaInferior.Text = "Aumentar Grilla Inferior"
        '    chkGrillaInferior.Location = New Point(chkGrillaInferior.Location.X, chkGrillaInferior.Location.Y + variableajuste)
        '    GroupBox1.Height = GroupBox1.Height + variableajuste
        '    grd.Location = New Point(xgrd, ygrd + variableajuste)
        '    grd.Height = hgrd - variableajuste
        '    grdItems.Height = grdItems.Height + variableajuste
        '    Label19.Location = New Point(Label19.Location.X, Label19.Location.Y + variableajuste)
        '    lblCantidadFilas.Location = New Point(lblCantidadFilas.Location.X, lblCantidadFilas.Location.Y + variableajuste)

        'End If

        If chkGrillaInferior.Checked = True Then
            chkGrillaInferior.Text = "Disminuir Grilla Inferior"
            chkGrillaInferior.Location = New Point(chkGrillaInferior.Location.X, chkGrillaInferior.Location.Y - variableajuste)
            GroupBox1.Height = GroupBox1.Height - variableajuste
            grd.Location = New Point(xgrd, ygrd - variableajuste)
            grd.Height = hgrd + variableajuste
            Label19.Location = New Point(Label19.Location.X, Label19.Location.Y - variableajuste)
            lblCantidadFilas.Location = New Point(lblCantidadFilas.Location.X, lblCantidadFilas.Location.Y - variableajuste)

            rdPendientes.Location = New Point(rdPendientes.Location.X, rdPendientes.Location.Y - variableajuste)
            rdAnuladas.Location = New Point(rdAnuladas.Location.X, rdAnuladas.Location.Y - variableajuste)
            rdTodasOC.Location = New Point(rdTodasOC.Location.X, rdTodasOC.Location.Y - variableajuste)

        Else
            chkGrillaInferior.Text = "Aumentar Grilla Inferior"
            chkGrillaInferior.Location = New Point(chkGrillaInferior.Location.X, chkGrillaInferior.Location.Y + variableajuste)
            GroupBox1.Height = GroupBox1.Height + variableajuste
            grd.Location = New Point(xgrd, ygrd + variableajuste)
            grd.Height = hgrd - variableajuste
            Label19.Location = New Point(Label19.Location.X, Label19.Location.Y + variableajuste)
            lblCantidadFilas.Location = New Point(lblCantidadFilas.Location.X, lblCantidadFilas.Location.Y + variableajuste)

            rdPendientes.Location = New Point(rdPendientes.Location.X, rdPendientes.Location.Y + variableajuste)
            rdAnuladas.Location = New Point(rdAnuladas.Location.X, rdAnuladas.Location.Y + variableajuste)
            rdTodasOC.Location = New Point(rdTodasOC.Location.X, rdTodasOC.Location.Y + variableajuste)

        End If

    End Sub

    Private Sub txtMontoIVA21_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            CalcularMontoIVA()
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtMontoIVA10_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            CalcularMontoIVA()
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtMontoIVA27_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            CalcularMontoIVA()
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCantIVA_ValueChanged(sender As Object, e As EventArgs)
        'If cmbTipoComprobante.Text = "FACTURAS A" Or _
        '    cmbTipoComprobante.Text = "NOTAS DE CREDITO A" Or _
        '    cmbTipoComprobante.Text = "NOTAS DE DEBITO A" Or _
        '    cmbTipoComprobante.Text = "RECIBOS A" Or _
        '    cmbTipoComprobante.Text = "FACTURAS M" Or _
        '    cmbTipoComprobante.Text = "NOTAS DE CREDITO M" Or _
        '    cmbTipoComprobante.Text = "NOTAS DE DEBITO M" Or _
        '    cmbTipoComprobante.Text = "RECIBOS M" Or _
        '    cmbTipoComprobante.Text = "TIQUE FACTURA A" Then

        '    If txtCantIVA.Value = 0 Then
        '        txtCantIVA.Value = 1
        '    End If
        'End If
    End Sub







#End Region

#Region "   Procedimientos"

    Dim MasterGrdDetail As Boolean = False
    Dim gl_dataset As DataSet
    Friend Sub Presentacion_request(sqlDetalle As String, sqlConceptos As String)
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim sql_items As String
        Dim i As Integer
        Dim dtDetalle As New DataTable
        Dim dtConcepto As New DataTable()
        gl_dataset = Nothing
        gl_dataset = New DataSet()

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            ''Detalle de liquidacion
            sql_items = sqlDetalle

            Dim cmd As New SqlCommand(sql_items, connection)
            Dim da As New SqlDataAdapter(cmd)

            da.Fill(dtDetalle)

            ''Conceptos de liquidacion
            sql_items = sqlConceptos

            Dim cmd_conceptos As New SqlCommand(sql_items, connection)
            Dim da_conceptos As New SqlDataAdapter(cmd_conceptos)

            da_conceptos.Fill(dtConcepto)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try


        dtDetalle.PrimaryKey = {
                dtDetalle.Columns("ID")
        }
        gl_dataset.Tables.Add(dtDetalle)

        'dtConcepto.Columns.Add("ID", GetType(Long))
        'dtConcepto.Columns.Add("IdDetalle", GetType(Long))
        'dtConcepto.Columns.Add("IdFarmacia", GetType(String))
        'dtConcepto.Columns.Add("detalle", GetType(String))
        'dtConcepto.Columns.Add("valor", GetType(Decimal))
        dtConcepto.Columns.Add("edit")

        dtConcepto.PrimaryKey = {
                dtConcepto.Columns("IdDetalle"),
                dtConcepto.Columns("detalle")
        }

        If Not dtConcepto.Rows.Count > 0 Then
            For Each row As DataRow In dtDetalle.Rows()
                Dim concepto As DataRow = dtConcepto.NewRow()
                concepto("IdDetalle") = row("ID")
                concepto("IdFarmacia") = row("IdFarmacia")
                concepto("detalle") = "A Cargo OS"
                concepto("valor") = Decimal.Parse(row("A Cargo OS"))
                concepto("estado") = "insert"
                dtConcepto.Rows.Add(concepto)
            Next
        End If

        gl_dataset.Tables.Add(dtConcepto)

        gl_dataset.Relations.Add("MasterGridDetail",
                      gl_dataset.Tables(0).Columns("ID"),
                      gl_dataset.Tables(1).Columns("IdDetalle")
        )

        SuperGrdResultado.PrimaryGrid.DataSource = gl_dataset

        ''Una vez todo preparado actualizo la grilla principal
        UpdateGrdPrincipal()

    End Sub

    ''Esta funcion actualiza y autocalcula valores importantes de la grilla
    Private Sub UpdateGrdPrincipal()

        ''GRID PRINCIPAL
        Dim i As Integer
        If MasterGrdDetail Then
            If gl_dataset.Tables(0).Columns("Recetas A") Is Nothing Then
                gl_dataset.Tables(0).Columns.Add("Recetas A")
                gl_dataset.Tables(0).Columns.Add("Recaudado A")
                gl_dataset.Tables(0).Columns.Add("A Cargo OS A")
            End If

            Dim row As DataRow
            For i = 0 To grdDetalleLiquidacionFiltrada.Rows.Count - 1
                row = gl_dataset.Tables(0).Rows.Find(grdDetalleLiquidacionFiltrada.Rows(i).Cells("IdDetalle").Value)
                If row IsNot Nothing Then 'If a row is found
                    With row
                        .Item("Recetas A") = grdDetalleLiquidacionFiltrada.Rows(i).Cells("Recetas").Value
                        .Item("Recaudado A") = grdDetalleLiquidacionFiltrada.Rows(i).Cells("Recaudado").Value
                        .Item("A Cargo OS A") = grdDetalleLiquidacionFiltrada.Rows(i).Cells("A Cargo OS").Value
                    End With
                End If
            Next
        End If

        If gl_dataset.Tables(0).Columns("Subtotal") Is Nothing Then
            gl_dataset.Tables(0).Columns.Add("Subtotal", GetType(Decimal))

            AddHandler gl_dataset.Tables(0).ColumnChanged, AddressOf CalcularTotales
        End If

        'Calculo de subtotalMasterGridDetail
        For Each row As DataRow In gl_dataset.Tables(0).Rows
            row("Subtotal") = 0
            Dim childrows = row.GetChildRows(gl_dataset.Relations(0))
            For Each detail As DataRow In childrows
                If detail("estado") <> "delete" Then
                    row("Subtotal") += detail("valor")
                End If
            Next
        Next

        'actualizo superdatagrid con el dataset global
        SuperGrdResultado.PrimaryGrid.DataSource = gl_dataset
        SuperGrdResultado.Update()

    End Sub

    Private Sub CalcularTotales()
        ''CALCULA LOS TOTALES DE LA GRIDITEMS
        Dim i As Integer
        Dim count As Integer = 0
        Dim Recaudado As Decimal = 0
        Dim ACargoOS As Decimal = 0
        Dim Total As Decimal = 0

        With gl_dataset.Tables(0)
            If .Rows.Count > 0 Then
                For i = 0 To gl_dataset.Tables(0).Rows.Count - 1
                    If .Rows(i)("Subtotal") IsNot DBNull.Value Then
                        Total += .Rows(i)("Subtotal")
                        count += 1
                    End If
                Next
            End If
        End With

        'txtRecaudado.Text = String.Format("{0:N2}", Recaudado)
        'txtACargoOS.Text = String.Format("{0:N2}", ACargoOS)
        lblTotal.Text = String.Format("{0:N2}", Total)
        lblCantidadFilas.Text = count
    End Sub

    Private Sub btnExcelWindow_Click(sender As Object, e As EventArgs) Handles btnExcelWindow.Click
        GroupPanelDetalleLiquidacion.Visible = True
        GroupPanelDetalleLiquidacion.Location = New Point(0, 0)
        GroupPanelDetalleLiquidacion.BringToFront()
        chkGrillaInferior.BringToFront()
        Me.grd.Location = New Size(GroupBox1.Location.X, GroupBox1.Location.Y + GroupBox1.Size.Height + 5)
        Me.grd.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width - 27, Me.Size.Height - 3 - GroupBox1.Size.Height - GroupBox1.Location.Y - 62) '65)

    End Sub

    Dim tables As DataTableCollection
    Dim WorkingOnTemplate As Boolean = False
    Dim TemplateName = ""

    Private Sub btnImportExcel_Click(sender As Object, e As EventArgs) Handles btnImportExcel.Click
        Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Excel Files |*.xls; *.xlsx"}
            If ofd.ShowDialog = DialogResult.OK Then

                FileName.Text = ofd.FileName
                TemplateName = ofd.SafeFileName.Split("-")(0).ToString
                Using stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read)
                    Using reader As IExcelDataReader = ExcelReaderFactory.CreateReader(stream)
                        Dim result As DataSet = reader.AsDataSet(New ExcelDataSetConfiguration() With {
                                                                 .ConfigureDataTable = Function(__) New ExcelDataTableConfiguration() With {
                                                                 .UseHeaderRow = True
                                                             }})
                        tables = result.Tables
                        cboSheet.Items.Clear()
                        For Each table As DataTable In tables
                            If table.Columns.Count > 0 Then
                                cboSheet.Items.Add(table.TableName)
                            End If
                        Next
                    End Using
                End Using

                grdDetalleLiquidacion.BringToFront()

                cboSheet.SelectedIndex = 0

                btnScan.Enabled = True

            End If
        End Using

    End Sub

    Private Sub CalcularDetalleSuperGrd(datasetLiquidacion As DataSet)
        If DataBindingComplete = True Then
            'SuperGrdResultado.PrimaryGrid.Footer.Text = "Prueba"
            'SuperGrdResultado.PrimaryGrid.GetParentPanel().Footer.Text = "prueba"
            'SuperGrdResultado.PrimaryGrid.GridPanel.GetParentPanel.Footer.Text = "prueba"


        End If
    End Sub


    Private Sub CboSheet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSheet.SelectedIndexChanged
        Dim dt As DataTable = tables(cboSheet.SelectedItem.ToString())
        grdDetalleLiquidacion.DataSource = dt


        Dim discounts As String() = New String(6) {"", "Bonificacion", "N. Credito", "Debitos", "Ajustes", "Recupero Aj", "Recupero Gs"}

        Dim max As Integer = grdDetalleLiquidacion.Columns.Count - 1
        For Each obj As Object In GroupBox2.Controls
            If TypeOf obj Is NumericUpDown Then
                obj.Value = 0
                obj.Maximum = max
            End If
        Next

        For Each obj As Object In PanelDescuentos.Controls
            If TypeOf obj Is NumericUpDown Then
                obj.Value = 0
                obj.Maximum = max
            End If
            If TypeOf obj Is ComboBox Then
                obj.Items.Clear()
                For Each discount As String In discounts
                    obj.Items.add(discount)
                Next
                obj.SelectedIndex = 0
            End If
        Next
        Get_excel_templates()

    End Sub

    Private Sub grdDetalleLiquidacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdDetalleLiquidacion.CellContentClick
        FilaLabel.Text = e.RowIndex
        ColLabel.Text = e.ColumnIndex

    End Sub
    Dim ExcelTemplate
    Private Sub Get_excel_templates()
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            Dim SQL = $" SELECT Recetas, Recaudado, ACargoOS, Bonificacion, [N. Credito], Debitos, Ajustes, [Recupero Aj], [Recupero Gs] FROM ExcelTemplates as t where t.name = '{TemplateName}'"
            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, SQL)
            ds.Dispose()
            ExcelTemplate = ds

            If ds.Tables(0).Rows.Count > 0 Then
                WorkingOnTemplate = True
                RecognitionLabel.Visible = True
                RecognitionLabel.Text = $"Se reconoció: {TemplateName}"

                NumericUpDown1.Value = ds.Tables(0).Rows(0)(0)
                NumericUpDown2.Value = ds.Tables(0).Rows(0)(1)
                NumericUpDown3.Value = ds.Tables(0).Rows(0)(2)

                Dim cbolist As New List(Of ComboBox)
                Dim numericlist As New List(Of NumericUpDown)
                For Each obj As Object In PanelDescuentos.Controls
                    If TypeOf obj Is ComboBox Then
                        cbolist.Add(obj)
                        obj.SelectedIndex = 0
                    End If
                    If TypeOf obj Is NumericUpDown Then
                        numericlist.Add(obj)
                        obj.Value = 0
                    End If
                Next

                Dim i As Integer
                Dim j As Integer = 0
                For i = 3 To ds.Tables(0).Columns.Count - 1
                    If ds.Tables(0).Rows(0)(i) IsNot DBNull.Value Then
                        cbolist.Find(Function(x) x.Tag = j).SelectedItem = ds.Tables(0).Columns(i).ColumnName
                        numericlist.Find(Function(x) x.Tag = j).Value = ds.Tables(0).Rows(0)(i)
                        j += 1
                    End If
                Next

                Scan_columns()
            Else
                btnListo.Enabled = False
                WorkingOnTemplate = False
                RecognitionLabel.Visible = False
                grdDetalleLiquidacionFiltrada.Columns.Clear()
                grdDetalleLiquidacionFiltrada.Rows.Clear()
            End If

        Catch ex As Exception
            MsgBox("Se produjo un error al intentar completar las columnas " & ex.Message)
        End Try



    End Sub

    Public Sub Template_On_Sumbit()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim cbolist As New List(Of ComboBox)
        Dim numericlist As New List(Of NumericUpDown)
        For Each obj As Object In PanelDescuentos.Controls
            If TypeOf obj Is ComboBox Then
                If obj.SelectedItem <> "" Then
                    cbolist.Add(obj)
                End If
            End If
            If TypeOf obj Is NumericUpDown Then
                If obj.Value <> 0 Then
                    numericlist.Add(obj)
                End If
            End If
        Next

        cbolist.Sort(Function(x, y) x.Tag.CompareTo(y.Tag))
        numericlist.Sort(Function(x, y) x.Tag.CompareTo(y.Tag))


        If WorkingOnTemplate Then
            Dim i
            Dim j = 0
            Dim cell_value
            Dim need_to_update = False
            Dim StrSet = ""
            ''con esta list me aseguro que los demas campos sin modificar sean null
            Dim fields2clean As New List(Of String) From {"Bonificacion", "N. Credito", "Debitos", "Ajustes", "Recupero Aj", "Recupero Gs"}

            Dim ExcelTemplate_len As Integer = 0
            For i = 3 To ExcelTemplate.Tables(0).Columns.Count - 1
                If ExcelTemplate.Tables(0).Rows(0)(i) IsNot DBNull.Value Then
                    ExcelTemplate_len += 1
                End If
            Next

            If ExcelTemplate_len <> cbolist.Count Then
                need_to_update = True
            Else
                For i = 0 To cbolist.Count - 1
                    cell_value = IIf(ExcelTemplate.Tables(0).Rows(0)(cbolist(i).SelectedItem) Is DBNull.Value, 0, ExcelTemplate.Tables(0).Rows(0)(cbolist(i).SelectedItem))

                    If numericlist(i).Value <> cell_value Then
                        need_to_update = True
                    End If
                Next
            End If

            If need_to_update Then
                For i = 0 To cbolist.Count - 1
                    If StrSet = "" Then
                        StrSet += $"[{cbolist(i).SelectedItem}] = {numericlist(i).Value}"
                    Else
                        StrSet += $", [{cbolist(i).SelectedItem}] = {numericlist(i).Value}"
                    End If
                    fields2clean.Remove(cbolist(i).SelectedItem)
                Next

                For Each field As String In fields2clean
                    If StrSet = "" Then
                        StrSet += $"[{field}] = NULL"
                    Else
                        StrSet += $", [{field}] = NULL"
                    End If
                Next

                SQL = $"UPDATE [CENPROFAR].[dbo].[ExcelTemplates] SET {StrSet} where [Name] = '{TemplateName}'"


                Try
                    connection = SqlHelper.GetConnection(ConnStringSEI)
                    ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, SQL)
                    ds.Dispose()
                Catch ex As Exception
                    MessageBox.Show($"No se pudo conectar con la base de datos {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                MsgBox($"Se actualizo template {TemplateName}")
            End If

        Else
            Dim StrCols = "Name, Recetas, Recaudado, ACargoOS"
            Dim StrValues = $"'{TemplateName}', {NumericUpDown1.Value}, {NumericUpDown2.Value}, {NumericUpDown3.Value}"

            Dim i As Integer
            For i = 0 To cbolist.Count - 1
                StrCols = StrCols + $", [{cbolist(i).SelectedItem}]"
                StrValues += $", {numericlist(i).Value}"
            Next

            Dim SQL = $"INSERT INTO [CENPROFAR].[dbo].[ExcelTemplates] ({StrCols}) VALUES ({StrValues})"

            Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
                ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, SQL)
                ds.Dispose()
            Catch ex As Exception
                MessageBox.Show($"No se pudo conectar con la base de datos {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        End If
    End Sub

    Public Function GetSimilarity(string1 As String, string2 As String) As Single
        Dim dis As Single = ComputeDistance(string1, string2)
        Dim maxLen As Single = string1.Length
        If maxLen < string2.Length Then
            maxLen = string2.Length
        End If
        If maxLen = 0.0F Then
            Return 1.0F
        Else
            Return 1.0F - dis / maxLen
        End If
    End Function

    Private Function ComputeDistance(s As String, t As String) As Integer
        Dim n As Integer = s.Length
        Dim m As Integer = t.Length
        Dim distance As Integer(,) = New Integer(n, m) {}
        ' matrix
        Dim cost As Integer = 0
        If n = 0 Then
            Return m
        End If
        If m = 0 Then
            Return n
        End If
        'init1

        Dim i As Integer = 0
        While i <= n
            distance(i, 0) = System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        Dim j As Integer = 0
        While j <= m
            distance(0, j) = System.Math.Max(System.Threading.Interlocked.Increment(j), j - 1)
        End While
        'find min distance

        For i = 1 To n
            For j = 1 To m
                cost = (If(t.Substring(j - 1, 1) = s.Substring(i - 1, 1), 0, 1))
                distance(i, j) = Math.Min(distance(i - 1, j) + 1, Math.Min(distance(i, j - 1) + 1, distance(i - 1, j - 1) + cost))
            Next
        Next
        Return distance(n, m)
    End Function

    Private Function Buscar_FarmaciaByName(name As String, dtFarmacias As DataTable)
        Dim dt_ResultadoComparacionFarmacias As New DataTable
        Dim i As Integer
        dt_ResultadoComparacionFarmacias.Columns.Add("CodigoInterno")
        dt_ResultadoComparacionFarmacias.Columns.Add("Porcentaje")
        For i = 0 To dtFarmacias.Rows.Count - 1
            'comparo los nombres de las farmacias
            Dim farmaciaDb = dtFarmacias.Rows(i).Item(3).ToString
            Dim farmaciaGrd = name

            Dim porcentajeComparacion = GetSimilarity(farmaciaGrd, farmaciaDb)

            If porcentajeComparacion >= 0.7 Then

                Dim rowdt As DataRow = dt_ResultadoComparacionFarmacias.NewRow()
                rowdt("CodigoInterno") = dtFarmacias.Rows(i).Item(0)
                rowdt("Porcentaje") = porcentajeComparacion
                dt_ResultadoComparacionFarmacias.Rows.Add(rowdt)
                dt_ResultadoComparacionFarmacias.DefaultView.Sort = "Porcentaje DESC"
                dt_ResultadoComparacionFarmacias = dt_ResultadoComparacionFarmacias.DefaultView.ToTable

            End If
        Next
        'traigo el codigo interno de la farmacia con mayor porcentaje de aproximacion
        If dt_ResultadoComparacionFarmacias.Rows.Count > 0 Then
            For Each row As DataRow In dtFarmacias.Rows
                If dt_ResultadoComparacionFarmacias.Rows(0).Item("CodigoInterno") = row("Codigo") Then
                    Return row
                End If
            Next
        End If

        Return Nothing

    End Function

    Private Function getFarmacia(row As DataRow, dtFarmacias As DataTable) ''Recibe una fila y busca si es una farmacia dentro de una tabla dada
        Dim best_row
        Dim isCode As Boolean
        Dim Int As Integer

        If row(0) IsNot DBNull.Value Then
            isCode = False
            ''MODULO FACAF
            If row(0).ToString.Contains("F0") Then
                dtFarmacias.PrimaryKey = {
                    dtFarmacias.Columns("CodFACAF")
                }
                isCode = True
            End If

            'MODULO PAMI
            If row(0).ToString.Length = 9 And IsNumeric(row(0).ToString) And Integer.TryParse(row(0), Int) Then
                dtFarmacias.PrimaryKey = {
                    dtFarmacias.Columns("codpami")
                }
                isCode = True
            End If

            If isCode Then
                Dim farmacia = dtFarmacias.Rows.Find({row(0)})

                If farmacia IsNot Nothing Then
                    Return farmacia
                Else
                    best_row = Buscar_FarmaciaByName(row(2).ToString, dtFarmacias)
                    If best_row IsNot Nothing Then
                        Return best_row
                    Else
                        Return Nothing
                    End If
                End If
            End If
        End If

        Return Nothing

    End Function

    Private Sub Scan_columns()

        'toma las columnas
        Dim RecetasIndex As Integer = NumericUpDown1.Value
        Dim RecaudadoIndex As Integer = NumericUpDown2.Value
        Dim AcargoOSIndex As Integer = NumericUpDown3.Value

        Dim dt_filtrada As New DataTable()

        Dim DiscountIndex As Integer

        Dim cbolist As New List(Of ComboBox)
        Dim numericlist As New List(Of NumericUpDown)



        If grdDetalleLiquidacionFiltrada.Rows.Count <> 0 Then
            grdDetalleLiquidacionFiltrada.DataSource = Nothing
        End If


        If NumericUpDown1.Value = 0 Or NumericUpDown2.Value = 0 Or NumericUpDown3.Value = 0 Then
            btnListo.Enabled = False
            MsgBox($"Las columnas de receta, recaudado y a cargo son obligatorias")
            Return
        End If

        For Each obj As Object In PanelDescuentos.Controls
            If TypeOf obj Is ComboBox Then
                If obj.SelectedItem <> "" Then
                    cbolist.Add(obj)
                End If
            End If
            If TypeOf obj Is NumericUpDown Then
                numericlist.Add(obj)
            End If
        Next

        Dim ocupied As New List(Of String)
        For Each cbo As ComboBox In cbolist
            If Not ocupied.Contains(cbo.SelectedItem) Then
                ocupied.Add(cbo.SelectedItem)
            Else
                btnListo.Enabled = False
                MsgBox($"El descuento {cbo.SelectedItem} no puede repetirse más de una vez")
                Return
            End If
        Next

        cbolist.Sort(Function(x, y) x.Tag.CompareTo(y.Tag))
        numericlist.Sort(Function(x, y) x.Tag.CompareTo(y.Tag))
        Dim i As Integer

        For i = 0 To cbolist.Count() - 1
            If numericlist(i).Value = 0 Then
                btnListo.Enabled = False
                MsgBox($"No puede seleccionarse la columna 0 para {cbolist(i).SelectedItem}")
                Return
            End If
        Next
        ''revisar
        dt_filtrada.Columns.Add("IdDetalle", GetType(Long))
        dt_filtrada.Columns.Add("IdFarmacia", GetType(Long))
        dt_filtrada.Columns.Add("Codigo", GetType(String))
        dt_filtrada.Columns.Add("Nombre", GetType(String))
        dt_filtrada.Columns.Add("Recetas", GetType(Integer))
        dt_filtrada.Columns.Add("Recaudado", GetType(Decimal))
        dt_filtrada.Columns.Add("A cargo OS", GetType(Decimal))

        For Each cbo As ComboBox In cbolist
            With cbo
                dt_filtrada.Columns.Add(.SelectedItem, GetType(Decimal))
            End With
        Next

        dt_filtrada.Columns.Add("Total", GetType(Decimal))

        Dim j As Integer
        Dim FirstColumnCell As String
        Dim subtotal As Decimal
        Dim farmacia As DataRow
        Dim CurrentRow As DataRow
        Dim idPresentacion As Long = grd.Rows(0).Cells(0).Value
        If grd.CurrentRow IsNot Nothing Then
            idPresentacion = grd.CurrentRow.Cells(0).Value
        End If
        Dim connection = SqlHelper.GetConnection(ConnStringSEI)
        Dim ds_Farmacias As New DataSet

        Dim dtFarmacias As New DataTable
        ''nacho cambió: f.codigo -> f.id

        Dim SQL_Farmacias = $"SELECT pd.ID as IdDetalle, f.ID as IdFarmacia, f.Codigo, f.CodFACAF, f.codpami, f.Nombre, pd.IdPresentacion FROM Farmacias f INNER JOIN Presentaciones_det pd on f.Id = pd.IdFarmacia
                              WHERE pd.IdPresentacion = {idPresentacion}"

        Try
            ds_Farmacias = SqlHelper.ExecuteDataset(connection, CommandType.Text, SQL_Farmacias)
            ds_Farmacias.EnforceConstraints = False
            dtFarmacias = ds_Farmacias.Tables(0)
        Catch ex As Exception
            MessageBox.Show($"No se pudo conectar con la base de datos {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        For j = 0 To grdDetalleLiquidacion.Rows.Count - 1
            CurrentRow = (TryCast(grdDetalleLiquidacion.Rows(j).DataBoundItem, DataRowView)).Row

            subtotal = 0

            FirstColumnCell = IIf(grdDetalleLiquidacion.Rows(j).Cells(0).Value IsNot Nothing, grdDetalleLiquidacion.Rows(j).Cells(0).Value.ToString, "")

            farmacia = getFarmacia(CurrentRow, dtFarmacias)

            Try
                If farmacia IsNot Nothing Then
                    '//////Get a reference to the new row ///////
                    Dim Row As DataRow = dt_filtrada.NewRow()

                    'This won't fail since the columns exist 
                    'Row("Codigo") = grdDetalleLiquidacion.Rows(j).Cells(0).Value
                    Row("IdDetalle") = farmacia("IdDetalle")
                    Row("IdFarmacia") = farmacia("IdFarmacia")
                    Row("Codigo") = farmacia("Codigo")
                    Row("Nombre") = farmacia("Nombre")
                    Row("Recetas") = grdDetalleLiquidacion.Rows(j).Cells(RecetasIndex).Value
                    Row("Recaudado") = grdDetalleLiquidacion.Rows(j).Cells(RecaudadoIndex).Value
                    Row("A cargo OS") = grdDetalleLiquidacion.Rows(j).Cells(AcargoOSIndex).Value
                    subtotal = Decimal.Parse(grdDetalleLiquidacion.Rows(j).Cells(AcargoOSIndex).Value)

                    For i = 0 To cbolist.Count() - 1
                        DiscountIndex = numericlist(i).Value
                        subtotal -= Decimal.Parse(grdDetalleLiquidacion.Rows(j).Cells(DiscountIndex).Value)
                        Row(cbolist(i).SelectedItem) = grdDetalleLiquidacion.Rows(j).Cells(DiscountIndex).Value
                    Next

                    Row("Total") = subtotal

                    dt_filtrada.Rows.Add(Row)
                End If
            Catch ex As Exception
                MsgBox(ex)
            End Try

        Next

        ''Cierro conexion que use para consultar codigos
        ds.Dispose()

        Dim dt_grouped As New DataTable()
        dt_grouped = dt_filtrada.Clone()
        Dim added As Boolean = False
        Dim current_row_index As Integer

        For current_row_index = 0 To dt_filtrada.Rows.Count - 1
            Dim current_row As DataRow = dt_filtrada.Rows(current_row_index)
            added = False

            j = 0
            While (j < dt_grouped.Rows.Count And added = False)
                If current_row("Codigo") = dt_grouped.Rows(j)("Codigo") Then
                    added = True
                End If
                j += 1
            End While

            If Not added Then
                Dim new_row As DataRow = dt_grouped.NewRow()
                For i = current_row_index To dt_filtrada.Rows.Count - 1
                    If dt_filtrada.Rows(i)("Codigo") = current_row("Codigo") Then
                        new_row("IdDetalle") = current_row("IdDetalle")
                        new_row("IdFarmacia") = current_row("IdFarmacia")
                        new_row("Codigo") = current_row("Codigo")
                        new_row("Nombre") = current_row("Nombre")
                        For j = 4 To dt_filtrada.Columns.Count - 1
                            If i = current_row_index Then
                                new_row(j) = Decimal.Parse(dt_filtrada.Rows(i)(j))
                            Else
                                new_row(j) += Decimal.Parse(dt_filtrada.Rows(i)(j))
                            End If
                        Next
                    End If
                Next
                dt_grouped.Rows.Add(new_row)

            End If
        Next

        grdDetalleLiquidacionFiltrada.DataSource = dt_grouped

        btnListo.Enabled = True
        ' DataGridView1.BringToFront()
    End Sub


    Private Sub BtnScan_Click(sender As Object, e As EventArgs) Handles btnScan.Click
        Scan_columns()
    End Sub


    Private Sub configurarform()
        'Me.Text = "Liquidación"

        ''Me.grd.Location = New Size(GroupBox1.Location.X, GroupBox1.Location.Y + GroupBox1.Size.Height + 7)

        'Me.grd.Location = New Size(14, 65)
        'Me.grd.BringToFront()

        'If LLAMADO_POR_FORMULARIO Then
        '    LLAMADO_POR_FORMULARIO = False
        '    Me.Top = ARRIBA
        '    Me.Left = IZQUIERDA
        'Else
        '    Me.Top = 0
        '    Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2
        'End If

        'Me.WindowState = FormWindowState.Maximized

        ''Me.grd.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width - 27, Me.Size.Height - 7 - GroupBox1.Size.Height - GroupBox1.Location.Y - 65)
        ''Me.grd.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width - 27, Me.Size.Height - 3 - GroupBox1.Size.Height - GroupBox1.Location.Y - 62) '65)
        ''Me.grd.Size = New Size(4 / 6 * SuperGrdResultado.Width, 100) '65)
        'Me.grd.Size = New Size(3.5 / 6 * SuperGrdResultado.Width, 100) '65)

        Me.Text = "Emisión de Ordenes de Compra a Proveedores"

        'Me.grd.Location = New Size(GroupBox1.Location.X, GroupBox1.Location.Y + GroupBox1.Size.Height + 7)
        Me.grd.Location = New Size(GroupBox1.Location.X, GroupBox1.Location.Y + GroupBox1.Size.Height + 5)

        If LLAMADO_POR_FORMULARIO Then
            LLAMADO_POR_FORMULARIO = False
            Me.Top = ARRIBA
            Me.Left = IZQUIERDA
        Else
            Me.Top = 0
            Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2
        End If

        Me.WindowState = FormWindowState.Maximized

        'Me.grd.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width - 27, Me.Size.Height - 7 - GroupBox1.Size.Height - GroupBox1.Location.Y - 50)
        Me.grd.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width - 27, Me.Size.Height - 3 - GroupBox1.Size.Height - GroupBox1.Location.Y - 62) '65)

    End Sub

    Private Sub asignarTags()

        txtID.Tag = "0"
        txtCodigo.Tag = "1"
        txtIdPresentacion.Tag = "2"
        lblPresentacionCodigo.Tag = "3"
        lblObraSocial.Tag = "4"
        lblFecha_presentacion.Tag = "5"
        lblPeriodo_presentacion.Tag = "6"
        lblStatus_presentacion.Tag = "7"
        lblObservacion.Tag = "8"
        dtpFECHA.Tag = "9"
    End Sub

    Private Sub Verificar_Datos()

        'Dim i As Integer, j As Integer, filas As Integer ', state As Integer

        'Dim codigo, nombre, nombrelargo, tipo, ubicacion, observaciones As String

        'codigo = "" : nombre = "" : nombrelargo = "" : tipo = "" : ubicacion = "" : observaciones = ""


        'bolpoliticas = False

        'Util.MsgStatus(Status1, "Verificando los datos...", My.Resources.Resources.indicator_white)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''Verificar si se terminó de editar la celda...
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'If editando_celda Then
        '    Util.MsgStatus(Status1, "Use [Enter] o [Tab] para salir del modo edición, antes de guardar.", My.Resources.Resources.alert.ToBitmap)
        '    Util.MsgStatus(Status1, "Use [Enter] o [Tab] para salir del modo edición, antes de guardar.", My.Resources.Resources.alert.ToBitmap, True)
        '    Exit Sub
        'End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''verificar que no hay nada en la grilla sin datos
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'filas = 0
        'For i = 0 To j
        '    'state = grdItems.Rows.GetRowState(i)
        '    'la fila está vacía ?
        '    If fila_vacia(i) Then
        '        Try
        '            'encotramos una fila vacia...borrarla y ver si hay mas

        '            j = j - 1 ' se reduce la cantidad de filas en 1
        '            i = i - 1 ' se reduce para recorrer la fila que viene 
        '        Catch ex As Exception
        '        End Try

        '    Else
        '        filas = filas + 1
        '        'idmaterial es valido?
        '        If grdItems.Rows(i).Cells(ColumnasDelGridItems1.IDMaterial).Value Is System.DBNull.Value Then
        '            Util.MsgStatus(Status1, "Falta completar el material en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap)
        '            Util.MsgStatus(Status1, "Falta completar el material en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap, True)
        '            Exit Sub
        '        End If
        '        'Descripcion del material es válida ?
        '        If grdItems.Rows(i).Cells(ColumnasDelGridItems1.Nombre_Material).Value.ToString.ToLower = "No Existe".ToLower Then
        '            Util.MsgStatus(Status1, "El material ingresado no es válido en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap)
        '            Util.MsgStatus(Status1, "El material ingresado no es válido en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap, True)
        '            Exit Sub
        '        End If

        '        Try
        '            'qty es válida?
        '            If grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtyRecep).Value Is System.DBNull.Value Then
        '                Util.MsgStatus(Status1, "Falta completar la cantidad a Recepcionar en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap)
        '                Util.MsgStatus(Status1, "Falta completar la cantidad a Recepcionar en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap, True)
        '                Exit Sub
        '            End If

        '        Catch ex As Exception
        '            Util.MsgStatus(Status1, "La cantidad a Recepcionar debe ser válida en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap)
        '            Util.MsgStatus(Status1, "La cantidad a Recepcionar debe ser válida en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap, True)
        '            Exit Sub
        '        End Try

        '        'si tiene saldo, controlamos que no se pase..
        '        If Not grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtySaldo).Value Is DBNull.Value Then
        '            If grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtyRecep).Value > grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtySaldo).Value Then
        '                Util.MsgStatus(Status1, "La cantidad a Recepcionar no debe ser mayor al Saldo en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap)
        '                Util.MsgStatus(Status1, "La cantidad a Recepcionar no debe ser mayor al Saldo en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap, True)
        '                Exit Sub
        '            End If
        '        End If

        '    End If
        'Next i

        'Dim buscandoalgunmov As Boolean = False

        'For i = 0 To grdItems.RowCount - 1
        '    If grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtyRecep).Value > 0 Then
        '        buscandoalgunmov = True
        '        Exit For
        '    End If
        'Next

        'If buscandoalgunmov = False Then
        '    Util.MsgStatus(Status1, "No realizó ningún movimiento dentro de la grilla. Por favor, verifique antes de guardar.", My.Resources.Resources.alert.ToBitmap)
        '    Util.MsgStatus(Status1, "No realizó ningún movimiento dentro de la grilla. Por favor, verifique antes de guardar.", My.Resources.Resources.alert.ToBitmap, True)
        '    Exit Sub
        'End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '' controlar si al menos hay 1 fila
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'If filas > 0 Then
        '    bolpoliticas = True
        'Else
        '    Util.MsgStatus(Status1, "No hay filas de materiales para guardar.", My.Resources.Resources.alert.ToBitmap)
        '    Util.MsgStatus(Status1, "No hay filas de materiales para guardar.", My.Resources.Resources.alert.ToBitmap, True)
        '    Exit Sub
        'End If
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

    Private Sub NoValidar(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim caracter As Char = e.KeyChar
        Dim obj As System.Windows.Forms.DataGridViewTextBoxEditingControl = sender
        e.KeyChar = Convert.ToChar(e.KeyChar.ToString.ToUpper)
        e.Handled = False ' dejar escribir cualquier cosa
    End Sub

    Private Sub validarNumerosReales(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        'Controlar que el caracter ingresado sea un  numero real
        Dim caracter As Char = e.KeyChar
        Dim obj As System.Windows.Forms.DataGridViewTextBoxEditingControl = sender

        If caracter = "." Or caracter = "," Then
            If CuentaAparicionesDeCaracter(obj.Text, ".") = 0 Then
                If CuentaAparicionesDeCaracter(obj.Text, ",") = 0 Then
                    e.Handled = False ' dejar escribir
                Else
                    e.Handled = True 'no deja escribir
                End If
            Else
                e.Handled = True ' no deja escribir
            End If
        Else
            If caracter = "-" And obj.Text.Trim <> "" Then
                If CuentaAparicionesDeCaracter(obj.Text, caracter) < 1 Then
                    obj.Text = "-" + obj.Text
                    e.Handled = True ' no dejar escribir
                Else
                    obj.Text = Mid(obj.Text, 2, Len(obj.Text))
                    e.Handled = True ' no dejar escribir
                End If
            Else
                If Char.IsNumber(caracter) Or caracter = ChrW(Keys.Back) Or caracter = ChrW(Keys.Delete) Or caracter = ChrW(Keys.Enter) Then
                    e.Handled = False 'dejo escribir
                Else
                    e.Handled = True ' no dejar escribir
                End If
            End If
        End If
    End Sub

    Private Sub LlenarGrid_grdDetLiquidacionOs()

        If grdDetalleLiquidacionFiltrada.Columns.Count > 0 Then
            grdDetalleLiquidacionFiltrada.Columns.Clear()
        End If

        If txtID.Text = "" Then
            'SQL = "exec spRecepciones_Det_Select_By_IDRecepcion @idRecepcion = 1"
            'SQL = "select * from osdetalleliquidacion"
        Else
            ' SQL = "exec spRecepciones_Det_Select_By_IDRecepcion @idRecepcion = " & txtID.Text
            'SQL = "select * from osdetalleliquidacion"
        End If

        GetDatasetItems(grdDetalleLiquidacionFiltrada)

        grdDetalleLiquidacionFiltrada.Columns(ColumnasDelGridItems1.IDRecepcion_Det).Visible = False

        'grdFarmacias.Columns(ColumnasDelGridItems1.Cod_RecepcionDet).Visible = False

        grdDetalleLiquidacionFiltrada.Columns(ColumnasDelGridItems1.IDMaterial).Visible = False

        'grdFarmacias.Columns(ColumnasDelGridItems1.Cod_Material).ReadOnly = True 'Codigo material
        'grdFarmacias.Columns(ColumnasDelGridItems1.Cod_Material).Width = 110

        'grdFarmacias.Columns(4).ReadOnly = True
        'grdFarmacias.Columns(4).Width = 400

        'grdFarmacias.Columns(5).ReadOnly = True
        'grdFarmacias.Columns(5).Width = 60

        grdDetalleLiquidacionFiltrada.Columns(6).Visible = False
        'grdFarmacias.Columns(8).Visible = False
        grdDetalleLiquidacionFiltrada.Columns(9).Visible = False
        grdDetalleLiquidacionFiltrada.Columns(10).Visible = False

        With grdDetalleLiquidacionFiltrada
            .VirtualMode = False
            .AllowUserToAddRows = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .RowsDefaultCellStyle.BackColor = Color.White
            .AllowUserToOrderColumns = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .ForeColor = Color.Black
        End With
        With grdDetalleLiquidacionFiltrada.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Black  'Color.BlueViolet
            .ForeColor = Color.White
            .Font = New Font("TAHOMA", 8, FontStyle.Bold)
        End With
        grdDetalleLiquidacionFiltrada.Font = New Font("TAHOMA", 8, FontStyle.Regular)
        'grdEnsayos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

        'Volver la fuente de datos a como estaba...
        'SQL = "exec spRecepciones_Select_All @Eliminado = 0"
    End Sub

    'Private Sub LlenarGrid_Items2()

    '    If grdDetLiquidacionOs.Columns.Count > 0 Then
    '        grdDetLiquidacionOs.Columns.Clear()
    '    End If

    '    If txtID.Text = "" Then
    '        SQL = "exec spPresentaciones_Det_Select_By_IDPresentacion @IDPresentacion = '1'"
    '    Else
    '        SQL = "exec spPresentaciones_Det_Select_By_IDPresentacion @IDPresentacion = " & txtID.Text
    '    End If

    '    GetDatasetItems(grdDetLiquidacionOs)


    '    With grdDetLiquidacionOs
    '        .VirtualMode = False
    '        .AllowUserToAddRows = False
    '        .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
    '        .RowsDefaultCellStyle.BackColor = Color.White
    '        .AllowUserToOrderColumns = True
    '        .SelectionMode = DataGridViewSelectionMode.CellSelect
    '        .ForeColor = Color.Black
    '    End With
    '    With grdDetLiquidacionOs.ColumnHeadersDefaultCellStyle
    '        .BackColor = Color.Black  'Color.BlueViolet
    '        .ForeColor = Color.White
    '        .Font = New Font("TAHOMA", 8, FontStyle.Bold)
    '    End With
    '    grdDetLiquidacionOs.Font = New Font("TAHOMA", 8, FontStyle.Regular)
    '    'grdEnsayos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

    '    'Volver la fuente de datos a como estaba...
    '    SQL = "exec spPresentaciones_Select_All @Eliminado = 0"
    'End Sub


    Private Sub GetDatasetItems(ByVal grdchico As DataGridView)
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Sub




    Private Sub LlenarcmbUsuarioGasto()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, " SELECT ID, NOMBRE FROM OBRASSOCIALES WHERE ELIMINADO = 0")
            ds.Dispose()

            With cmbObraSocial
                .DataSource = ds.Tables(0).DefaultView
                .DisplayMember = "NOMBRE"
                .ValueMember = "ID"
                '.SelectedIndex = "ID"
            End With

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

        IdObraSocial = cmbObraSocial.SelectedValue
        bolIDOS = True
    End Sub



    'Private Sub LlenarComboFacturasAsociadas()

    '    Dim ds_FacturasCargadas As Data.DataSet
    '    Dim connection As SqlClient.SqlConnection = Nothing

    '    Try
    '        connection = SqlHelper.GetConnection(ConnStringSEI)
    '    Catch ex As Exception
    '        MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Sub
    '    End Try

    '    Try

    '        ds_FacturasCargadas = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT g.id, (c.descripcion + ' / ' + CONVERT(VARCHAR(50),NroFactura) + ' / ' + CONVERT(VARCHAR(10),Total)) as Factura FROM gastos g JOIN Comprobantes c ON c.id = g.comprobantetipo WHERE " & _
    '                                        " idproveedor = " & CType(cmbProveedor.SelectedValue, Long) & "  AND eliminado=0 order by g.id desc")
    '        ds_FacturasCargadas.Dispose()

    '        With Me.cmbAsociarFacturaCargada
    '            .DataSource = ds_FacturasCargadas.Tables(0).DefaultView
    '            .DisplayMember = "factura"
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

    '        MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
    '          + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage), _
    '          "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        If Not connection Is Nothing Then
    '            CType(connection, IDisposable).Dispose()
    '        End If
    '    End Try

    'End Sub

    Private Sub Contar_Filas()



    End Sub

    Private Sub CalcularMontoIVA()
        'If band = 1 Then
        '    If txtMontoIVA21.Text = "" Then txtMontoIVA21.Text = "0"
        '    If txtMontoIVA10.Text = "" Then txtMontoIVA10.Text = "0"
        '    If txtMontoIVA27.Text = "" Then txtMontoIVA27.Text = "0"
        '    If txtSubtotal.Text = "" Then txtSubtotal.Text = "0"
        '    If txtSubtotalExento.Text = "" Then txtSubtotalExento.Text = "0"
        '    lblMontoIva.Text = Format(CDbl(txtMontoIVA10.Text) + CDbl(txtMontoIVA21.Text) + CDbl(txtMontoIVA27.Text), "###0.00")
        '    lblTotal.Text = Format(CDbl(txtSubtotalExento.Text) + CDbl(txtSubtotal.Text) + CDbl(lblMontoIva.Text) + CDbl(lblImpuestos.Text), "###0.00")
        'End If
    End Sub


#End Region

#Region "   Funciones"
    Private Function GuardarLiquidacion()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim res As Integer = 0

        connection = SqlHelper.GetConnection(ConnStringSEI)
        'Abrir una transaccion para guardar y asegurar que se guarda todo
        If Abrir_Tran(connection) = False Then
            MessageBox.Show("No se pudo abrir una transaccion", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End If


        Try
            ''ID
            Dim param_id As New SqlClient.SqlParameter
            param_id.ParameterName = "@id"
            param_id.SqlDbType = SqlDbType.BigInt
            param_id.Value = IIf(txtID.Text <> "", txtID.Text, DBNull.Value)
            param_id.Direction = ParameterDirection.InputOutput

            ''codigo
            Dim param_codigo As New SqlClient.SqlParameter
            param_codigo.ParameterName = "@codigo"
            param_codigo.SqlDbType = SqlDbType.VarChar
            param_codigo.Size = 8
            param_codigo.Value = IIf(txtCodigo.Text <> "", txtCodigo.Text, DBNull.Value)
            param_codigo.Direction = ParameterDirection.Input

            ''IdPresentacion
            Dim param_idPresentacion As New SqlClient.SqlParameter
            param_idPresentacion.ParameterName = "@idPresentacion"
            param_idPresentacion.SqlDbType = SqlDbType.BigInt
            param_idPresentacion.Value = Long.Parse(txtIdPresentacion.Text)
            param_idPresentacion.Direction = ParameterDirection.Input

            ''fecha
            Dim param_fecha As New SqlClient.SqlParameter
            param_fecha.ParameterName = "@fecha"
            param_fecha.SqlDbType = SqlDbType.DateTime
            param_fecha.Value = Date.Parse(dtpFECHA.Value)
            param_fecha.Direction = ParameterDirection.Input

            ''total
            Dim param_total As New SqlClient.SqlParameter
            param_total.ParameterName = "@total"
            param_total.SqlDbType = SqlDbType.Decimal
            param_total.Value = Decimal.Parse(lblTotal.Text)
            param_total.Direction = ParameterDirection.Input

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


            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spLiquidaciones_Insert_Update",
                                      param_id, param_codigo, param_idPresentacion, param_fecha, param_total, param_user, param_res)

            txtID.Text = param_id.Value
            res = param_res.Value

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        GuardarLiquidacion = res
    End Function

    Private Function GuardarLiquidacion_det()
        Dim res As Integer = 0

        Try
            For Each detalle As DataRow In gl_dataset.Tables(0).Rows
                ''ID
                Dim param_id As New SqlClient.SqlParameter
                param_id.ParameterName = "@id"
                param_id.SqlDbType = SqlDbType.BigInt
                param_id.Value = detalle("IdLiquidacion_det")
                param_id.Direction = ParameterDirection.InputOutput

                ''ID Liquidacion
                Dim param_idLiquidacion As New SqlClient.SqlParameter
                param_idLiquidacion.ParameterName = "@idLiquidacion"
                param_idLiquidacion.SqlDbType = SqlDbType.BigInt
                param_idLiquidacion.Value = IIf(txtID.Text = "", DBNull.Value, txtID.Text)
                param_idLiquidacion.Direction = ParameterDirection.Input

                ''IdPresentacion_det
                Dim param_idPresentacion_det As New SqlClient.SqlParameter
                param_idPresentacion_det.ParameterName = "@idPresentacion_det"
                param_idPresentacion_det.SqlDbType = SqlDbType.BigInt
                param_idPresentacion_det.Value = detalle("id")
                param_idPresentacion_det.Direction = ParameterDirection.Input

                ''recetasA
                Dim param_recetasA As New SqlClient.SqlParameter
                param_recetasA.ParameterName = "@recetasA"
                param_recetasA.SqlDbType = SqlDbType.Decimal
                param_recetasA.Value = detalle("Recetas A")
                param_recetasA.Direction = ParameterDirection.Input

                ''recaudadoA
                Dim param_recaudadoA As New SqlClient.SqlParameter
                param_recaudadoA.ParameterName = "@recaudadoA"
                param_recaudadoA.SqlDbType = SqlDbType.Decimal
                param_recaudadoA.Value = detalle("Recaudado A")
                param_recaudadoA.Direction = ParameterDirection.Input

                ''aCargoOsA
                Dim param_aCargoOsA As New SqlClient.SqlParameter
                param_aCargoOsA.ParameterName = "@aCargoOsA"
                param_aCargoOsA.SqlDbType = SqlDbType.Decimal
                param_aCargoOsA.Value = detalle("A Cargo OS A")
                param_aCargoOsA.Direction = ParameterDirection.Input

                ''total
                Dim param_total As New SqlClient.SqlParameter
                param_total.ParameterName = "@total"
                param_total.SqlDbType = SqlDbType.Decimal
                param_total.Value = detalle("subtotal")
                param_total.Direction = ParameterDirection.Input

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


                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spLiquidaciones_Det_Insert_Update",
                                              param_id, param_idLiquidacion, param_idPresentacion_det, param_recetasA,
                                              param_recaudadoA, param_aCargoOsA, param_total, param_user, param_res)

                res = param_res.Value

                If (res <= 0) Then
                    Exit For
                End If

            Next

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        GuardarLiquidacion_det = res
    End Function

    Private Function GuardarConceptos()
        Dim res As Integer = 0

        Try
            For Each concepto As DataRow In gl_dataset.Tables(1).Rows
                ''ID
                Dim param_id As New SqlClient.SqlParameter
                param_id.ParameterName = "@id"
                param_id.SqlDbType = SqlDbType.BigInt
                param_id.Value = concepto("id")
                param_id.Direction = ParameterDirection.InputOutput

                ''ID Liquidacion
                Dim param_idLiquidacion As New SqlClient.SqlParameter
                param_idLiquidacion.ParameterName = "@idLiquidacion"
                param_idLiquidacion.SqlDbType = SqlDbType.BigInt
                param_idLiquidacion.Value = IIf(txtID.Text = "", DBNull.Value, txtID.Text)
                param_idLiquidacion.Direction = ParameterDirection.Input

                ''IdDetalle
                Dim param_idDetalle As New SqlClient.SqlParameter
                param_idDetalle.ParameterName = "@idDetalle"
                param_idDetalle.SqlDbType = SqlDbType.BigInt
                param_idDetalle.Value = concepto("IdDetalle")
                param_idDetalle.Direction = ParameterDirection.Input

                ''IdFarmacia
                Dim param_idFarmacia As New SqlClient.SqlParameter
                param_idFarmacia.ParameterName = "@idFarmacia"
                param_idFarmacia.SqlDbType = SqlDbType.BigInt
                param_idFarmacia.Value = concepto("IdFarmacia")
                param_idFarmacia.Direction = ParameterDirection.Input

                ''detalle
                Dim param_detalle As New SqlClient.SqlParameter
                param_detalle.ParameterName = "@detalle"
                param_detalle.SqlDbType = SqlDbType.VarChar
                param_detalle.Size = 100
                param_detalle.Value = concepto("detalle")
                param_detalle.Direction = ParameterDirection.Input

                ''valor
                Dim param_valor As New SqlClient.SqlParameter
                param_valor.ParameterName = "@valor"
                param_valor.SqlDbType = SqlDbType.Decimal
                param_valor.Value = concepto("valor")
                param_valor.Direction = ParameterDirection.Input

                ''estado
                Dim param_estado As New SqlClient.SqlParameter
                param_estado.ParameterName = "@estado"
                param_estado.SqlDbType = SqlDbType.VarChar
                param_estado.Size = 50
                param_estado.Value = concepto("estado")
                param_estado.Direction = ParameterDirection.Input

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


                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spConceptos_Insert_Delete",
                                              param_id, param_idLiquidacion, param_idDetalle, param_idFarmacia,
                                              param_detalle, param_valor, param_estado, param_user, param_res)

                res = param_res.Value

                If (res <= 0) Then
                    Exit For
                End If

            Next

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        GuardarConceptos = res
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

    'Private Function LiberarMPNro(ByVal propio As Long) As String
    '    Dim connection As SqlClient.SqlConnection = Nothing

    '    Try
    '        Try
    '            connection = SqlHelper.GetConnection(ConnStringSEI)
    '        Catch ex As Exception
    '            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            LiberarMPNro = "error"
    '            Return LiberarMPNro
    '            Exit Function
    '        End Try

    '        Try

    '            Dim param_nro As New SqlClient.SqlParameter
    '            param_nro.ParameterName = "@nro"
    '            param_nro.SqlDbType = SqlDbType.BigInt
    '            param_nro.Value = propio
    '            param_nro.Direction = ParameterDirection.Input

    '            Dim param_userupd As New SqlClient.SqlParameter
    '            param_userupd.ParameterName = "@user"
    '            param_userupd.SqlDbType = SqlDbType.Int
    '            param_userupd.Value = Util.UserID
    '            param_userupd.Direction = ParameterDirection.Input


    '            Dim param_mensaje As New SqlClient.SqlParameter
    '            param_mensaje.ParameterName = "@mensaje"
    '            param_mensaje.SqlDbType = SqlDbType.VarChar
    '            param_mensaje.Size = 500
    '            param_mensaje.Value = DBNull.Value
    '            param_mensaje.Direction = ParameterDirection.InputOutput

    '            Try
    '                SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spLiberarStockNro", param_nro, param_userupd, param_mensaje)
    '                LiberarMPNro = param_mensaje.Value
    '                Return LiberarMPNro

    '            Catch ex As Exception
    '                Throw ex
    '            End Try
    '        Finally

    '        End Try
    '    Catch ex As Exception
    '        Dim errMessage As String = ""
    '        Dim tempException As Exception = ex

    '        While (Not tempException Is Nothing)
    '            errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
    '            tempException = tempException.InnerException
    '        End While

    '        MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
    '          + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage), _
    '          "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '        LiberarMPNro = "error"
    '        Return LiberarMPNro

    '    Finally
    '        If Not connection Is Nothing Then
    '            CType(connection, IDisposable).Dispose()
    '        End If

    '    End Try

    'End Function

    ' Capturar los enter del formulario, descartar todos salvo los que 
    ' se dan dentro de la grilla. Es una sobre carga de un metodo existente.

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        '' Si la tecla presionada es distinta de la tecla Enter,
        '' abandonamos el procedimiento.
        ''
        'If keyData <> Keys.Return Then Return MyBase.ProcessCmdKey(msg, keyData)

        '' Igualmente, si el control DataGridView no tiene el foco,
        '' y si la celda actual no está siendo editada,
        '' abandonamos el procedimiento.
        'If (Not grdItems.Focused) AndAlso (Not grdItems.IsCurrentCellInEditMode) Then Return MyBase.ProcessCmdKey(msg, keyData)

        '' Obtenemos la celda actual
        'Dim cell As DataGridViewCell = grdItems.CurrentCell
        '' Índice de la columna.
        'Dim columnIndex As Int32 = cell.ColumnIndex
        '' Índice de la fila.
        'Dim rowIndex As Int32 = cell.RowIndex

        'Do
        '    If columnIndex = grdItems.Columns.Count - 1 Then
        '        If rowIndex = grdItems.Rows.Count - 1 Then
        '            ' Seleccionamos la primera columna de la primera fila.
        '            cell = grdItems.Rows(0).Cells(ColumnasDelGridItems1.IDRecepcion_Det)
        '        Else
        '            ' Selecionamos la primera columna de la siguiente fila.
        '            cell = grdItems.Rows(rowIndex + 1).Cells(ColumnasDelGridItems1.IDRecepcion_Det)
        '        End If
        '    Else
        '        ' Seleccionamos la celda de la derecha de la celda actual.
        '        cell = grdItems.Rows(rowIndex).Cells(columnIndex + 1)
        '    End If

        '    ' establecer la fila y la columna actual
        '    columnIndex = cell.ColumnIndex
        '    rowIndex = cell.RowIndex
        'Loop While (cell.Visible = False)

        'Try
        '    grdItems.CurrentCell = cell
        'Catch ex As Exception

        'End Try

        '' ... y la ponemos en modo de edición.
        'grdItems.BeginEdit(True)
        'Return True

    End Function


    Private Function TotalRows(ByVal rows As IEnumerable(Of GridElement), ByVal rowsEncabezado As IEnumerable(Of GridElement)) As Decimal
        Dim total As Decimal = 0
        Dim codigoDetalle As String
        Dim ACargoOSDetalle As Decimal
        Dim ACargoOSEncabezado As Decimal
        Dim codigoEncabezado As String

        For Each itemDetalle As GridContainer In rows
            If TypeOf itemDetalle Is GridRow Then
                Dim row As GridRow = CType(itemDetalle, GridRow)
                codigoDetalle = row("IDFarm").Value
                ACargoOSDetalle = row("ACargoOS").Value 'DirectCast(IIf(row("ACargoOS").Value Is Nothing, 0D, row("ACargoOS").Value), Decimal)

                For Each itemEncabezado As GridContainer In rowsEncabezado
                    If TypeOf itemEncabezado Is GridRow Then

                        Dim rowEncabezado As GridRow = CType(itemEncabezado, GridRow)
                        codigoEncabezado = rowEncabezado("IDFarmacia").Value

                        If codigoDetalle = codigoEncabezado Then
                            ACargoOSEncabezado = rowEncabezado("ACargoOS").Value
                        End If

                    End If

                Next itemEncabezado

            End If

        Next itemDetalle

        total = ACargoOSEncabezado - ACargoOSDetalle

        Return (total)
    End Function


#End Region

#Region "   Botones"

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click

        band = 0

        bolModo = True
        Util.MsgStatus(Status1, "Haga click en [Guardar] despues de completar los datos.")
        PrepararBotones()

        'dtpFECHA.Enabled = True
        'txtNota.Enabled = True

        Util.LimpiarTextBox(Me.Controls)

        ''Limpieza de labels
        lblPresentacionCodigo.Text = "No seleccionada"
        lblObraSocial.Text = "-"
        lblObservacion.Text = "-"
        lblPeriodo_presentacion.Text = "-"
        lblFecha_presentacion.Text = "-"
        lblStatus_presentacion.Text = "CONFECCIONANDO"


        SuperGrdResultado.PrimaryGrid.DataSource = Nothing

        dtpFECHA.Value = Date.Today
        dtpFECHA.Focus()

        band = 1

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If bolModo = False Then
            'MsgBox("No se permite la modificación de una recepción. Para modificar la factura vaya a Administración de Gastos en el menú Contabilidad", MsgBoxStyle.Information, "Control de Acceso")
            If MessageBox.Show("¿Está seguro que desea modificar la Liquidación seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        Dim res As Integer, res_item As Integer, res_concepto As Integer


        Util.MsgStatus(Status1, "Guardando el registro...", My.Resources.Resources.indicator_white)
        'res = AgregarActualizar_Registro_Recepciones(ControlFactura, ControlRemito)
        res = GuardarLiquidacion()
        Select Case res
            Case -1
                Cancelar_Tran()
                Util.MsgStatus(Status1, "No se pudo actualizar el registro (Encabezado).", My.Resources.Resources.stop_error.ToBitmap)
                Util.MsgStatus(Status1, "No se pudo actualizar el registro (Encabezado).", My.Resources.Resources.stop_error.ToBitmap, True)
                Exit Sub
            Case 0
                Cancelar_Tran()
                Util.MsgStatus(Status1, "No se pudo agregar el registro (Encabezado).", My.Resources.Resources.stop_error.ToBitmap)
                Util.MsgStatus(Status1, "No se pudo agregar el registro (Encabezado).", My.Resources.Resources.stop_error.ToBitmap, True)
                Exit Sub
            Case Else
                res_item = GuardarLiquidacion_det()
                Select Case res_item
                    Case -1
                        Cancelar_Tran()
                        Util.MsgStatus(Status1, "No se pudo actualizar el registro (Detalle).", My.Resources.Resources.stop_error.ToBitmap)
                        Util.MsgStatus(Status1, "No se pudo actualizar el registro (Detalle).", My.Resources.Resources.stop_error.ToBitmap, True)
                        Exit Sub
                    Case 0
                        Cancelar_Tran()
                        Util.MsgStatus(Status1, "No se pudo agregar el registro (Detalle).", My.Resources.Resources.stop_error.ToBitmap)
                        Util.MsgStatus(Status1, "No se pudo agregar el registro (Detalle).", My.Resources.Resources.stop_error.ToBitmap, True)
                        Exit Sub
                    Case Else
                        Util.MsgStatus(Status1, "Guardando los items...", My.Resources.Resources.indicator_white)
                        'res_item = AgregarRegistro_Recepciones_Items(txtID.Text)
                        res_concepto = GuardarConceptos()
                        Select Case res_concepto
                            Case -1
                                Cancelar_Tran()
                                Util.MsgStatus(Status1, "No se pudo registrar la recepción (Concepto).", My.Resources.Resources.stop_error.ToBitmap)
                                Util.MsgStatus(Status1, "No se pudo registrar la recepción (Concepto).", My.Resources.Resources.stop_error.ToBitmap, True)
                                Exit Sub
                            Case 0
                                Cancelar_Tran()
                                Util.MsgStatus(Status1, "No se pudo agregar el registro (Concepto).", My.Resources.Resources.stop_error.ToBitmap)
                                Util.MsgStatus(Status1, "No se pudo agregar el registro (Concepto).", My.Resources.Resources.stop_error.ToBitmap, True)
                                Exit Sub
                            Case Else
                                Cerrar_Tran()

                                bolModo = False
                                PrepararBotones()

                                MDIPrincipal.NoActualizarBase = False
                                btnActualizar_Click(sender, e)

                                Util.MsgStatus(Status1, "Se ha actualizado el registro.", My.Resources.Resources.ok.ToBitmap)

                        End Select
                End Select

        End Select




        '
        ' cerrar la conexion si está abierta.
        '
        If Not conn_del_form Is Nothing Then
            CType(conn_del_form, IDisposable).Dispose()
        End If

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        '
        ' Para borrar un vale hay que tener un permiso especial de eliminacion
        ' ademas, no se puede borrar un vale ya eliminado de antes.
        ' La eliminacion es lógica...y se reversan los items para ajustar el inventario

        'If chkFacturaCancelada.Checked = True Then
        '    Util.MsgStatus(Status1, "No se puede anular la recepción porque está asociada a un pago que se efectuó. Anule el pago asociado y luego anule esta recepción.", My.Resources.stop_error.ToBitmap)
        '    Util.MsgStatus(Status1, "No se puede anular la recepción porque está asociada a un pago que se efectuó." & vbCrLf & "Anule el pago asociado y luego anule esta recepción.", My.Resources.stop_error.ToBitmap, True)
        '    Exit Sub
        'End If

        'Dim res As Integer

        '''If BAJA Then
        'If chkEliminado.Checked = False Then
        '    If MessageBox.Show("Esta acción reversará las Recepciones de todos los items." + vbCrLf + "¿Está seguro que desea eliminar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '        Util.MsgStatus(Status1, "Eliminando el registro...", My.Resources.Resources.indicator_white)
        '        res = EliminarRegistro_Recepcion()
        '        Select Case res
        '            Case -3
        '                Cancelar_Tran()
        '                Util.MsgStatus(Status1, "No se registró el mov. de stock.", My.Resources.stop_error.ToBitmap)
        '                Util.MsgStatus(Status1, "No se registró el mov. de stock.", My.Resources.stop_error.ToBitmap, True)
        '            Case -2
        '                Cancelar_Tran()
        '                Util.MsgStatus(Status1, "El registro no existe.", My.Resources.stop_error.ToBitmap)
        '                Util.MsgStatus(Status1, "El registro no existe.", My.Resources.stop_error.ToBitmap, True)
        '            Case -1
        '                Cancelar_Tran()
        '                Util.MsgStatus(Status1, "No se pudo borrar el registro.", My.Resources.stop_error.ToBitmap)
        '                Util.MsgStatus(Status1, "No se pudo borrar el registro.", My.Resources.stop_error.ToBitmap, True)
        '            Case 0
        '                Cancelar_Tran()
        '                Util.MsgStatus(Status1, "No se pudo borrar el registro.", My.Resources.stop_error.ToBitmap)
        '                Util.MsgStatus(Status1, "No se pudo borrar el registro.", My.Resources.stop_error.ToBitmap, True)
        '            Case Else
        '                res = EliminarRegistro_Gasto()
        '                Select Case res
        '                    Case -8
        '                        Cancelar_Tran()
        '                        Util.MsgStatus(Status1, "El gasto está asociado a un Pago. Anule el pago al proveedor para luego anular el gasto.", My.Resources.Resources.stop_error.ToBitmap)
        '                        Util.MsgStatus(Status1, "El gasto está asociado a un Pago. Anule el pago al proveedor para luego anular el gasto.", My.Resources.Resources.stop_error.ToBitmap, True)
        '                    Case 0
        '                        Cancelar_Tran()
        '                        Util.MsgStatus(Status1, "No pudo realizarse la anulación.", My.Resources.Resources.stop_error.ToBitmap)
        '                        Util.MsgStatus(Status1, "No pudo realizarse la anulación.", My.Resources.Resources.stop_error.ToBitmap, True)
        '                    Case -1
        '                        Cancelar_Tran()
        '                        Util.MsgStatus(Status1, "No pudo realizarse la anulación.", My.Resources.Resources.stop_error.ToBitmap)
        '                        Util.MsgStatus(Status1, "No pudo realizarse la anulación.", My.Resources.Resources.stop_error.ToBitmap, True)
        '                    Case Else
        '                        Cerrar_Tran()
        '                        PrepararBotones()

        '                        'SQL = "exec spRecepciones_Select_All  @Eliminado = 0"

        '                        btnActualizar_Click(sender, e)
        '                        Util.MsgStatus(Status1, "Se ha borrado el registro.", My.Resources.ok.ToBitmap)
        '                        Util.MsgStatus(Status1, "Se ha borrado el registro.", My.Resources.ok.ToBitmap, True, True)
        '                End Select
        '        End Select
        '    Else
        '        Util.MsgStatus(Status1, "Acción de eliminar cancelada.", My.Resources.stop_error.ToBitmap)
        '        Util.MsgStatus(Status1, "Acción de eliminar cancelada.", My.Resources.stop_error.ToBitmap, True)
        '    End If
        'Else
        '    Util.MsgStatus(Status1, "El registro ya está eliminado.", My.Resources.stop_error.ToBitmap)
        '    Util.MsgStatus(Status1, "El registro ya está eliminado.", My.Resources.stop_error.ToBitmap, True)
        'End If
        '''Else
        '''Util.MsgStatus(Status1, "No tiene permiso para eliminar registros.", My.Resources.stop_error.ToBitmap)
        '''Util.MsgStatus(Status1, "No tiene permiso para eliminar registros.", My.Resources.stop_error.ToBitmap, True)
        '''End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        Dim rpt As New frmReportes()

        Dim param As New frmParametros
        Dim Cnn As New SqlConnection(ConnStringSEI)
        Dim codigo_recep As String = ""
        ''En esta Variable le paso la fecha actual

        nbreformreportes = "Recepción de Material"

        'param.AgregarParametros("Recepción Nro.:", "STRING", "", False, txtCODIGOunused.Text.ToString, "", Cnn)

        param.ShowDialog()

        If cerroparametrosconaceptar = True Then
            ''OBTENGO LOS PARAMETROS QUE LE VOY A PASAR A LA FUNCION..
            codigo_recep = param.ObtenerParametros(0)

            rpt.Recepciones_Maestro_App(codigo_recep, rpt, My.Application.Info.AssemblyName.ToString)

            cerroparametrosconaceptar = False
            param = Nothing
            Cnn = Nothing
        End If



    End Sub

    Private Sub btnLlenarGrilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLlenarGrilla.Click
        'Dim i As Integer

        If bolModo Then 'SOLO LLENA LA GRILLA EN MODO NUEVO...

        End If

    End Sub

    Private Overloads Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click


    End Sub

    Protected Overloads Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click

        'Try
        '    Dim sqlstring As String = "update [" & NameTable_NotificacionesWEB & "] set BloqueoR = 0"
        '    tranWEB.Sql_Set(sqlstring)


        'Catch ex As Exception

        'End Try

    End Sub

#End Region

#Region "   GridItems"



#End Region








    Private Sub btnListo_Click(sender As Object, e As EventArgs) Handles btnListo.Click
        Dim i As Integer
        Dim rowArray

        ''PONE EN CONCEPTOS EL A CARGO OS
        'For Each row As DataRow In dtDetalle.Rows
        '    Dim a_cargo As DataRow = gl_dataset.Tables(1).NewRow()
        '    a_cargo("codigo") = row("CodigoFarmacia")
        '    a_cargo("detalle") = "A cargo OS"
        '    a_cargo("valor") = row("A cargo OS")
        '    gl_dataset.Tables(1).Rows.Add(a_cargo)
        'Next

        ''CALCULO DE ERROR AJUSTE
        For i = 0 To grdDetalleLiquidacionFiltrada.Rows.Count - 1
            Dim aceptado = Decimal.Parse(grdDetalleLiquidacionFiltrada.Rows(i).Cells("A cargo OS").Value)
            Dim aceptado_farmacia = grdDetalleLiquidacionFiltrada.Rows(i).Cells("IdFarmacia").Value

            ''Se queda con la primera coincidencia de farmacia y detalle de la grilla de detalles
            Dim a_cargo As DataRow
            rowArray = gl_dataset.Tables(1).Select($"IdFarmacia = '{aceptado_farmacia}' and detalle = 'A cargo OS'")
            If rowArray.Length > 0 Then
                a_cargo = rowArray(0)

                If a_cargo("valor") <> aceptado Then
                    Dim error_ajuste As DataRow = gl_dataset.Tables(1).NewRow()
                    error_ajuste("IdDetalle") = a_cargo("IdDetalle")
                    error_ajuste("IdFarmacia") = a_cargo("IdFarmacia")
                    error_ajuste("estado") = "insert"
                    If cmbTipoPago.Text = "Anticipo" Then
                        error_ajuste("detalle") = "Pendiente de pago"
                    Else
                        error_ajuste("detalle") = "Error ajuste"
                    End If

                    error_ajuste("valor") = Decimal.Parse(aceptado - a_cargo("valor"))
                    gl_dataset.Tables(1).Rows.Add(error_ajuste)
                End If
            End If

        Next

        Dim ColumnName As String
        Dim IdDetalle As Long

        Dim j As Integer = 0
        For i = 7 To grdDetalleLiquidacionFiltrada.Columns.Count - 2


            ColumnName = grdDetalleLiquidacionFiltrada.Columns(i).Name
            For j = 0 To grdDetalleLiquidacionFiltrada.Rows.Count - 1
                Dim row As DataRow = gl_dataset.Tables(1).NewRow()
                ''Se queda con la primera coincidencia de farmacia para obtener IdDetalle
                rowArray = gl_dataset.Tables(1).Select($"IdFarmacia = '{grdDetalleLiquidacionFiltrada.Rows(j).Cells("IdFarmacia").Value}'")
                If rowArray.Length > 0 Then
                    IdDetalle = rowArray(0)("IdDetalle")
                    row("IdDetalle") = IdDetalle
                    row("IdFarmacia") = grdDetalleLiquidacionFiltrada.Rows(j).Cells("IdFarmacia").Value
                    row("detalle") = ColumnName
                    row("valor") = Decimal.Parse(grdDetalleLiquidacionFiltrada.Rows(j).Cells(i).Value) * -1
                    row("edit") = "x"
                    row("estado") = "insert"
                    If (row("valor") <> 0) Then
                        gl_dataset.Tables(1).Rows.Add(row)
                    End If
                End If
            Next
        Next

        MasterGrdDetail = True
        Template_On_Sumbit()
        UpdateGrdPrincipal()
        GroupPanelDetalleLiquidacion.Visible = False
        Me.grd.Location = New Size(14, 65)
        Me.grd.Size = New Size(4 / 6 * SuperGrdResultado.Width, 100)
        Me.grd.BringToFront()

    End Sub
    Dim panel As GridPanel
    Dim panelSuperior As GridPanel

    Private Class MyGridButtonXEditControl
        Inherits GridButtonXEditControl

        Public Sub New()
            ' We want to be notified when the user clicks the button
            ' so that we can change the underlying cell value to reflect
            ' the mouse click.

            AddHandler Click, AddressOf MyGridButtonXEditControlClick
        End Sub

        Public Overrides Sub InitializeContext(ByVal cell As GridCell, ByVal style As CellVisualStyle)
            MyBase.InitializeContext(cell, style)

            If Text IsNot DBNull.Value Then
                If Text <> "x" Then
                    Text = "x"
                    Enabled = False
                End If
            End If

        End Sub

        Private Sub MyGridButtonXEditControlClick(ByVal sender As Object, ByVal e As EventArgs)

            ''con editorcell puedo conocer info de el cellpanel
            Dim row_index = EditorCell.RowIndex
            Dim parent = EditorCell.GridPanel.Parent
            Dim panel = EditorCell.GridPanel
            Dim i As Integer
            Dim total As Decimal = 0
            Dim pendiente As String = ""
            Dim result As DialogResult = MessageBox.Show($"Desea eliminar {panel.GetCell(row_index, 3).Value}?",
                              "Eliminar",
                              MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then

                'panel.Rows.RemoveAt(row_index) ''Elimino la fila
                panel.Rows(row_index).visible = False ''Oculto la fila para luego eliminarla
                panel.Rows(row_index)("estado").Value = "delete"

                For i = 0 To panel.Rows.Count - 1
                    If panel.GetCell(i, 3).Value = "Pendiente de pago" Then
                        pendiente = $"<br/> Pendiente de pago: <font color=""Gray""><i>${Decimal.Parse(panel.GetCell(i, 4).Value * -1):N2}</i></font>"
                    End If

                    If panel.GetCell(i, 5).Value <> "delete" Then ''Sumo solo si la columna no está para eliminar
                        total += panel.GetCell(i, 4).Value
                    End If
                Next
                parent("Subtotal").Value = total

                panel.Footer = New GridFooter()
                panel.Footer.Text = String.Format("Total a pagar: <font color=""Green""><i>${0:N2}</i></font> {1:N2}", total, pendiente)
            End If

        End Sub
    End Class

    Private Sub SuperGrdResultado_DataBindingComplete(sender As Object, e As GridDataBindingCompleteEventArgs) Handles SuperGrdResultado.DataBindingComplete
        Dim RowsCount = SuperGrdResultado.PrimaryGrid.Rows.Count
        panel = e.GridPanel
        'SuperGrdResultado.PrimaryGrid.Columns("ID").Visible = False
        SuperGrdResultado.PrimaryGrid.Columns("IdFarmacia").Visible = False
        SuperGrdResultado.PrimaryGrid.Columns("IdLiquidacion").Visible = False
        SuperGrdResultado.PrimaryGrid.Columns("Bonificación").Visible = False

        'AddHandler SuperGrdResultado.PrimaryGrid.Columns("Subtotal"), AddressOf Totalchanged


        If panel.Name.Equals("") = True Then
            Dim Groupheaders = SuperGrdResultado.PrimaryGrid.ColumnHeader.GroupHeaders

            Dim GroupHeader1 As New ColumnGroupHeader()
            Dim GroupHeader2 As New ColumnGroupHeader()
            Dim i As Integer = 0

            'asignacion de displayindex a las columnas del grid
            While i <= panel.Columns.Count - 1
                panel.Columns(i).DisplayIndex = panel.Columns(i).ColumnIndex
                i += 1
            End While

            GroupHeader1.EndDisplayIndex = panel.Columns("A cargo OS").DisplayIndex
            GroupHeader1.StartDisplayIndex = panel.Columns("Recetas").DisplayIndex
            GroupHeader1.HeaderText = "Presentado"

            If Not Groupheaders.contains(GroupHeader1.Name) Then
                Groupheaders.Add(GroupHeader1)
            End If

            If MasterGrdDetail Then
                ''Envio el subtotal al final
                For i = panel.Columns("Subtotal").ColumnIndex + 1 To panel.Columns.Count - 1
                    panel.Columns(i).DisplayIndex -= 1
                Next
                panel.Columns("Subtotal").DisplayIndex = panel.Columns.Count - 1

                GroupHeader2.EndDisplayIndex = panel.Columns("A Cargo OS A").DisplayIndex
                GroupHeader2.StartDisplayIndex = panel.Columns("Recetas A").DisplayIndex
                GroupHeader2.HeaderText = "Aceptado"
                If Not Groupheaders.contains(GroupHeader2.Name) Then
                    Groupheaders.Add(GroupHeader2)
                End If


                'Pinto la fila con error

                If cmbTipoPago.Text = "Unico" Then
                    For Each fila As GridRow In panel.Rows
                        With fila
                            If .Cells("Recetas A").Value IsNot DBNull.Value Then
                                If .Cells("Recetas").Value <> .Cells("Recetas A").Value Then
                                    .CellStyles.Default.Background.Color1 = Color.SandyBrown
                                    .CellStyles.Default.TextColor = Color.White
                                End If
                            End If
                            If .Cells("A Cargo OS A").Value IsNot DBNull.Value Then
                                If .Cells("A Cargo Os").Value <> .Cells("A Cargo OS A").Value Then
                                    .CellStyles.Default.Background.Color1 = Color.SandyBrown
                                    .CellStyles.Default.TextColor = Color.White
                                End If
                            End If
                        End With

                    Next fila
                End If
            End If
        End If

        If panel.Name.Equals("") = True Then
            panelSuperior = panel
        End If

        RowsCount = RowsCount - 1

        'Verifico el nombre del subpanel

        If panel.Name.Equals("Table2") = True Then
            panel.Columns(0).Visible = False 'ID
            panel.Columns(1).Visible = False 'IdDetalle
            panel.Columns(2).Visible = False 'IdFarmacia
            panel.Columns(5).Visible = False 'estado
            panel.Columns(6).Width = 30 'hago el boton de eliminar mas pequeño

            'panel.Visible = IIf(panel.Rows.Count > 0, True, False)

            Dim i As Integer
            Dim total As Decimal = 0
            Dim pendiente As String = ""
            For i = 0 To panel.Rows.Count - 1
                If panel.GetCell(i, 3).Value = "Pendiente de pago" Then
                    pendiente = $"<br/> Pendiente de pago: <font color=""Gray""><i>${Decimal.Parse(panel.GetCell(i, 4).Value * -1):N2}</i></font>"
                End If

                If panel.GetCell(i, 5).Value <> "delete" Then ''Sumo solo si la columna no está para eliminar
                    total += panel.GetCell(i, 4).Value
                End If

                panel.GetCell(i, 6).EditorType = GetType(MyGridButtonXEditControl)

            Next

            Dim parent = panel.GridPanel.Parent
            parent("Subtotal").Value = total

            panel.Footer = New GridFooter()
            panel.Footer.Text = String.Format("Total a pagar: <font color=""Green""><i>${0:N2}</i></font> {1:N2}", total, pendiente)
        End If
    End Sub

    Private Sub UpdateDetailsFooter(ByVal panel As GridPanel, ByVal panelSuperior As GridPanel)
        If panel.Footer Is Nothing Then
            panel.Footer = New GridFooter()
        End If
        If panelSuperior.Footer Is Nothing Then
            panelSuperior.Footer = New GridFooter()
        End If

        'Dim total As Decimal = TotalRows(panel.Rows, panelSuperior.Rows)
        Dim total As Decimal = 999.99

        panel.Footer.Text = String.Format("Total a pagar: <font color=""Green""><i>${0}</i></font>", total)
    End Sub

    Private Sub chkIngresosBrutos_CheckedChanged(sender As Object, e As EventArgs) Handles chkIngresosBrutos.CheckedChanged
        If chkIngresosBrutos.Checked Then
            addConceptos("Ingresos Brutos", 0.025)
        Else
            deleteConceptos("Ingresos Brutos")
        End If

        UpdateGrdPrincipal()
    End Sub

    Private Sub chkImpCheque_CheckedChanged(sender As Object, e As EventArgs) Handles chkImpCheque.CheckedChanged
        If chkImpCheque.Checked Then
            addConceptos("Impuesto cheque", 0.00075)
        Else
            deleteConceptos("Impuesto cheque")
        End If

        UpdateGrdPrincipal()
    End Sub

    Private Sub chkComisionCentro_CheckedChanged(sender As Object, e As EventArgs) Handles chkComisionCentro.CheckedChanged
        If chkComisionCentro.Checked Then
            addConceptos("Comisión centro", 0.0075)
        Else
            deleteConceptos("Comisión centro")
        End If

        UpdateGrdPrincipal()
    End Sub

    Private Sub addConceptos(detalle As String, porcentaje As Decimal)
        Dim dtDetalle As DataTable = gl_dataset.Tables(0)
        Dim valor As Decimal = 0
        Dim concepto As DataRow

        For Each Farmacia As DataRow In dtDetalle.Rows
            valor = -Farmacia("subtotal") * Decimal.Parse(porcentaje)

            ''creo el concepto
            concepto = gl_dataset.Tables(1).NewRow ' <- dtConceptos

            concepto("IdDetalle") = Farmacia("ID")
            concepto("IdFarmacia") = Farmacia("IdFarmacia")
            concepto("detalle") = detalle
            concepto("valor") = valor
            concepto("edit") = New DataGridViewButtonXCell()
            concepto("edit") = "x"
            concepto("estado") = "insert"

            gl_dataset.Tables(1).Rows.Add(concepto)
        Next
    End Sub

    Private Sub deleteConceptos(detalle As String)
        Dim dtDetalle As DataTable = gl_dataset.Tables(1)
        Dim rows = dtDetalle.Select($"detalle = '{detalle}'")

        For Each row As DataRow In rows
            row.Delete()
        Next
    End Sub

    Private Sub btnCargarPresentacion_Click(sender As Object, e As EventArgs) Handles btnCargarPresentacion.Click
        Dim NuevoLiquidacion As New frmNuevaLiquidacion
        frmNuevaLiquidacion.ShowDialog()
    End Sub
End Class
