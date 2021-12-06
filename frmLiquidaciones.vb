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
        cmbAlmacenes.Visible = False
        Label16.Visible = False
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
        LlenarcmbAlmacenes()
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

    Private Sub grdItems_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)

        'controlar lo que se ingresa en la grilla
        'en este caso, que no se ingresen letras en el lote    
        If Me.grdItems.CurrentCell.ColumnIndex = 7 Then
            AddHandler e.Control.KeyPress, AddressOf validarNumerosReales
        Else
            AddHandler e.Control.KeyPress, AddressOf NoValidar
        End If
        'End If
    End Sub

    Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txtID.KeyPress, txtCODIGOunused.KeyPress, txtNota.KeyPress
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

    Private Sub grdItems_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim Valor As String
        Valor = ""
        If e.Button = Windows.Forms.MouseButtons.Right And bolModo Then
            If grdItems.RowCount <> 0 Then
                If Cell_Y <> -1 Then
                    Try
                        Valor = grdItems.Rows(Cell_Y).Cells(ColumnasDelGridItems1.Cod_Material).Value.ToString & " " & grdItems.Rows(Cell_Y).Cells(ColumnasDelGridItems1.Nombre_Material).Value.ToString
                    Catch ex As Exception
                    End Try
                End If
            End If
            If Valor <> "" Then
                Dim p As Point = New Point(e.X, e.Y)
                ContextMenuStrip1.Show(grdItems, p)
                ContextMenuStrip1.Items(0).Text = "Borrar el Item " & Valor
            End If
        End If
    End Sub

    Private Sub BorrarElItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BorrarElItemToolStripMenuItem.Click
        Dim cell As DataGridViewCell = grdItems.CurrentCell
        'Borrar la fila actual
        If cell.RowIndex <> 0 Then
            grdItems.Rows.RemoveAt(cell.RowIndex)
        End If
    End Sub

    Private Sub BuscarDescripcionToolStripMenuItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BuscarDescripcionToolStripMenuItem.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            BuscarDescripcionToolStripMenuItem_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub BuscarDescripcionToolStripMenuItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarDescripcionToolStripMenuItem.SelectedIndexChanged
        Dim cell As DataGridViewCell = grdItems.Rows(Cell_Y).Cells(ColumnasDelGridItems1.Cod_Material)
        grdItems.CurrentCell = cell
        grdItems.CurrentCell.Value = BuscarDescripcionToolStripMenuItem.ComboBox.SelectedValue
        ContextMenuStrip1.Close()
        grdItems.BeginEdit(True)
    End Sub

    Private Sub chkEliminado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEliminado.CheckedChanged
        If Not bolModo Then
            'cmbProveedores.Enabled = Not chkEliminado.Checked
            grdItems.Enabled = Not chkEliminado.Checked
            dtpFECHA.Enabled = Not chkEliminado.Checked
            txtNota.Enabled = Not chkEliminado.Checked
        End If
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

    Private Sub cmbProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If band = 1 And bolModo = True Then
            LimpiarGridItems(grdItems)


            btnLlenarGrilla_Click(sender, e)
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

        LlenarGrid_IVA(CType(txtIdGasto.Text, Long))
        LlenarGrid_Impuestos()

    End Sub

    Private Sub validar_NumerosReales_Impuestos(
       ByVal sender As Object,
       ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna  
        Dim columna As Integer = grdImpuestos.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a la columna 1 o 3  
        If columna = ColumnasDelGridImpuestos.Monto Then

            Dim caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  
            If (Char.IsNumber(caracter)) Or
               (caracter = ChrW(Keys.Back)) Or
               (caracter = ".") And
               (txt.Text.Contains(".") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
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
            grdItems.Height = grdItems.Height - variableajuste
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
            grdItems.Height = grdItems.Height + variableajuste
            Label19.Location = New Point(Label19.Location.X, Label19.Location.Y + variableajuste)
            lblCantidadFilas.Location = New Point(lblCantidadFilas.Location.X, lblCantidadFilas.Location.Y + variableajuste)

            rdPendientes.Location = New Point(rdPendientes.Location.X, rdPendientes.Location.Y + variableajuste)
            rdAnuladas.Location = New Point(rdAnuladas.Location.X, rdAnuladas.Location.Y + variableajuste)
            rdTodasOC.Location = New Point(rdTodasOC.Location.X, rdTodasOC.Location.Y + variableajuste)

        End If

    End Sub

    Private Sub grdImpuestos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grdImpuestos.CellEndEdit
        Try
            If e.ColumnIndex = ColumnasDelGridImpuestos.Monto Then
                If grdImpuestos.CurrentRow.Cells(ColumnasDelGridImpuestos.Monto).Value Is DBNull.Value Or
                    grdImpuestos.CurrentRow.Cells(ColumnasDelGridImpuestos.Monto).Value = Nothing Then
                    grdImpuestos.CurrentRow.Cells(ColumnasDelGridImpuestos.Monto).Value = 0
                End If

                Dim i As Integer

                'lblImpuestos.Text = "0"

                For i = 0 To grdImpuestos.Rows.Count - 1
                    'lblImpuestos.Text = CDbl(lblImpuestos.Text) + CDbl(grdImpuestos.Rows(i).Cells(ColumnasDelGridImpuestos.Monto).Value)
                Next



            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdImpuestos_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdImpuestos.EditingControlShowing

        ' referencia a la celda  
        Dim validar As TextBox = CType(e.Control, TextBox)

        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_NumerosReales_Impuestos

    End Sub

    Private Sub txtMontoIVA21_LostFocus(sender As Object, e As EventArgs)
        CalcularMontoIVA()
    End Sub

    Private Sub txtMontoIVA10_LostFocus(sender As Object, e As EventArgs)
        CalcularMontoIVA()
    End Sub

    Private Sub txtMontoIVA27_LostFocus(sender As Object, e As EventArgs)
        CalcularMontoIVA()
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

        Dim i As Integer, j As Integer, filas As Integer ', state As Integer

        Dim codigo, nombre, nombrelargo, tipo, ubicacion, observaciones As String

        codigo = "" : nombre = "" : nombrelargo = "" : tipo = "" : ubicacion = "" : observaciones = ""


        bolpoliticas = False

        Util.MsgStatus(Status1, "Verificando los datos...", My.Resources.Resources.indicator_white)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Verificar si se terminó de editar la celda...
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If editando_celda Then
            Util.MsgStatus(Status1, "Use [Enter] o [Tab] para salir del modo edición, antes de guardar.", My.Resources.Resources.alert.ToBitmap)
            Util.MsgStatus(Status1, "Use [Enter] o [Tab] para salir del modo edición, antes de guardar.", My.Resources.Resources.alert.ToBitmap, True)
            Exit Sub
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'verificar que no hay nada en la grilla sin datos
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        j = grdItems.RowCount - 1
        filas = 0
        For i = 0 To j
            'state = grdItems.Rows.GetRowState(i)
            'la fila está vacía ?
            If fila_vacia(i) Then
                Try
                    'encotramos una fila vacia...borrarla y ver si hay mas
                    grdItems.Rows.RemoveAt(i)

                    j = j - 1 ' se reduce la cantidad de filas en 1
                    i = i - 1 ' se reduce para recorrer la fila que viene 
                Catch ex As Exception
                End Try

            Else
                filas = filas + 1
                'idmaterial es valido?
                If grdItems.Rows(i).Cells(ColumnasDelGridItems1.IDMaterial).Value Is System.DBNull.Value Then
                    Util.MsgStatus(Status1, "Falta completar el material en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap)
                    Util.MsgStatus(Status1, "Falta completar el material en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap, True)
                    Exit Sub
                End If
                'Descripcion del material es válida ?
                If grdItems.Rows(i).Cells(ColumnasDelGridItems1.Nombre_Material).Value.ToString.ToLower = "No Existe".ToLower Then
                    Util.MsgStatus(Status1, "El material ingresado no es válido en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap)
                    Util.MsgStatus(Status1, "El material ingresado no es válido en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap, True)
                    Exit Sub
                End If

                Try
                    'qty es válida?
                    If grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtyRecep).Value Is System.DBNull.Value Then
                        Util.MsgStatus(Status1, "Falta completar la cantidad a Recepcionar en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap)
                        Util.MsgStatus(Status1, "Falta completar la cantidad a Recepcionar en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap, True)
                        Exit Sub
                    End If

                Catch ex As Exception
                    Util.MsgStatus(Status1, "La cantidad a Recepcionar debe ser válida en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap)
                    Util.MsgStatus(Status1, "La cantidad a Recepcionar debe ser válida en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap, True)
                    Exit Sub
                End Try

                'si tiene saldo, controlamos que no se pase..
                If Not grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtySaldo).Value Is DBNull.Value Then
                    If grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtyRecep).Value > grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtySaldo).Value Then
                        Util.MsgStatus(Status1, "La cantidad a Recepcionar no debe ser mayor al Saldo en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap)
                        Util.MsgStatus(Status1, "La cantidad a Recepcionar no debe ser mayor al Saldo en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap, True)
                        Exit Sub
                    End If
                End If

            End If
        Next i

        Dim buscandoalgunmov As Boolean = False

        For i = 0 To grdItems.RowCount - 1
            If grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtyRecep).Value > 0 Then
                buscandoalgunmov = True
                Exit For
            End If
        Next

        If buscandoalgunmov = False Then
            Util.MsgStatus(Status1, "No realizó ningún movimiento dentro de la grilla. Por favor, verifique antes de guardar.", My.Resources.Resources.alert.ToBitmap)
            Util.MsgStatus(Status1, "No realizó ningún movimiento dentro de la grilla. Por favor, verifique antes de guardar.", My.Resources.Resources.alert.ToBitmap, True)
            Exit Sub
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' controlar si al menos hay 1 fila
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If filas > 0 Then
            bolpoliticas = True
        Else
            Util.MsgStatus(Status1, "No hay filas de materiales para guardar.", My.Resources.Resources.alert.ToBitmap)
            Util.MsgStatus(Status1, "No hay filas de materiales para guardar.", My.Resources.Resources.alert.ToBitmap, True)
            Exit Sub
        End If
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

    Private Sub PrepararGridItems()
        Util.LimpiarGridItems(grdItems)
        With (grdItems)
            '.AllowUserToAddRows = True
            .Columns(ColumnasDelGridItems1.Cod_Material).ReadOnly = False 'Codigo material  
            .ScrollBars = ScrollBars.Both
        End With
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

    Private Sub LlenarGridItemsPorOC(ByVal idoc As Long)

        If grdItems.Columns.Count > 0 Then
            grdItems.Columns.Clear()
        End If

        'SQL = "exec spRecepciones_Det_Select_By_IDOrdenDeCompra @IdOrdenDeCompra = " & idoc

        GetDatasetItems(grdItems)



        grdItems.Columns(ColumnasDelGridItems1.IDRecepcion_Det).Width = 70
        grdItems.Columns(ColumnasDelGridItems1.IDRecepcion_Det).Visible = False

        grdItems.Columns(ColumnasDelGridItems1.Cod_RecepcionDet).Width = 50
        grdItems.Columns(ColumnasDelGridItems1.Cod_RecepcionDet).Visible = False

        grdItems.Columns(ColumnasDelGridItems1.IDMaterial).Width = 80
        grdItems.Columns(ColumnasDelGridItems1.IDMaterial).Visible = False


        grdItems.Columns(ColumnasDelGridItems1.Cod_Material).Visible = False '3
        grdItems.Columns(ColumnasDelGridItems1.Cod_Material).ReadOnly = True '3
        grdItems.Columns(ColumnasDelGridItems1.Cod_Material).Width = 70

        grdItems.Columns(ColumnasDelGridItems1.Cod_Mat_Prov).Visible = False '3
        grdItems.Columns(ColumnasDelGridItems1.Cod_Mat_Prov).ReadOnly = True '3

        grdItems.Columns(ColumnasDelGridItems1.Nombre_Material).ReadOnly = True '4
        grdItems.Columns(ColumnasDelGridItems1.Nombre_Material).Width = 300

        grdItems.Columns(ColumnasDelGridItems1.IdUnidad).Visible = False '4

        grdItems.Columns(ColumnasDelGridItems1.IdMoneda).Visible = False '4

        grdItems.Columns(ColumnasDelGridItems1.CodMoneda).Visible = False '4

        grdItems.Columns(ColumnasDelGridItems1.Moneda).Visible = False

        grdItems.Columns(ColumnasDelGridItems1.CodUnidad).Visible = False
        grdItems.Columns(ColumnasDelGridItems1.CodUnidad).ReadOnly = True
        grdItems.Columns(ColumnasDelGridItems1.CodUnidad).Width = 55
        grdItems.Columns(ColumnasDelGridItems1.CodUnidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grdItems.Columns(ColumnasDelGridItems1.Unidad).ReadOnly = True
        grdItems.Columns(ColumnasDelGridItems1.Unidad).Width = 60

        grdItems.Columns(ColumnasDelGridItems1.ValorCambio).Visible = False '4

        grdItems.Columns(ColumnasDelGridItems1.Bonif1).Width = 50
        grdItems.Columns(ColumnasDelGridItems1.Bonif1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'grdItems.Columns(ColumnasDelGridItems1.Bonif2).Width = 50
        'grdItems.Columns(ColumnasDelGridItems1.Bonif2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grdItems.Columns(ColumnasDelGridItems1.Bonif2).Visible = chkMostarColumnas.Checked

        'grdItems.Columns(ColumnasDelGridItems1.Bonif3).Width = 50
        'grdItems.Columns(ColumnasDelGridItems1.Bonif3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grdItems.Columns(ColumnasDelGridItems1.Bonif3).Visible = chkMostarColumnas.Checked

        'grdItems.Columns(ColumnasDelGridItems1.Bonif4).Width = 50
        'grdItems.Columns(ColumnasDelGridItems1.Bonif4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grdItems.Columns(ColumnasDelGridItems1.Bonif4).Visible = chkMostarColumnas.Checked

        'grdItems.Columns(ColumnasDelGridItems1.Bonif5).Width = 50
        'grdItems.Columns(ColumnasDelGridItems1.Bonif5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grdItems.Columns(ColumnasDelGridItems1.Bonif5).Visible = chkMostarColumnas.Checked

        grdItems.Columns(ColumnasDelGridItems1.IVA).Visible = False
        grdItems.Columns(ColumnasDelGridItems1.IVA).ReadOnly = True
        grdItems.Columns(ColumnasDelGridItems1.IVA).Width = 45
        grdItems.Columns(ColumnasDelGridItems1.IVA).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        grdItems.Columns(ColumnasDelGridItems1.Ganancia).Visible = False
        grdItems.Columns(ColumnasDelGridItems1.Ganancia).Width = 50
        grdItems.Columns(ColumnasDelGridItems1.Ganancia).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'grdItems.Columns(ColumnasDelGridItems1.PrecioxMt).Width = 65
        'grdItems.Columns(ColumnasDelGridItems1.PrecioxMt).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grdItems.Columns(ColumnasDelGridItems1.PrecioxMt).Visible = False

        'grdItems.Columns(ColumnasDelGridItems1.PrecioxKg).Width = 65
        'grdItems.Columns(ColumnasDelGridItems1.PrecioxKg).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grdItems.Columns(ColumnasDelGridItems1.PrecioxKg).Visible = False

        'grdItems.Columns(ColumnasDelGridItems1.PesoxUnidad).Width = 65
        'grdItems.Columns(ColumnasDelGridItems1.PesoxUnidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grdItems.Columns(ColumnasDelGridItems1.PesoxUnidad).Visible = False

        'grdItems.Columns(ColumnasDelGridItems1.CantxLongitud).Width = 65
        'grdItems.Columns(ColumnasDelGridItems1.CantxLongitud).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grdItems.Columns(ColumnasDelGridItems1.CantxLongitud).Visible = False

        grdItems.Columns(ColumnasDelGridItems1.QtyPedido).ReadOnly = True 'cantidad pedida 5
        grdItems.Columns(ColumnasDelGridItems1.QtyPedido).Width = 80
        grdItems.Columns(ColumnasDelGridItems1.QtyPedido).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grdItems.Columns(ColumnasDelGridItems1.PrecioLista).Visible = False '4
        grdItems.Columns(ColumnasDelGridItems1.PrecioLista).ReadOnly = True
        grdItems.Columns(ColumnasDelGridItems1.PrecioLista).Width = 60
        grdItems.Columns(ColumnasDelGridItems1.PrecioLista).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdItems.Columns(ColumnasDelGridItems1.PrecioCosto).ReadOnly = False  'precio pedido 6
        grdItems.Columns(ColumnasDelGridItems1.PrecioCosto).Width = 80
        grdItems.Columns(ColumnasDelGridItems1.PrecioCosto).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdItems.Columns(ColumnasDelGridItems1.QtyRecep).ReadOnly = False 'cantidad a recibir 7
        grdItems.Columns(ColumnasDelGridItems1.QtyRecep).Width = 80
        grdItems.Columns(ColumnasDelGridItems1.QtyRecep).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grdItems.Columns(ColumnasDelGridItems1.PorcDif).ReadOnly = True 'cantidad a recibir 7
        grdItems.Columns(ColumnasDelGridItems1.PorcDif).Width = 50
        grdItems.Columns(ColumnasDelGridItems1.PorcDif).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grdItems.Columns(ColumnasDelGridItems1.ID_OrdenDeCompra).Visible = False
        grdItems.Columns(ColumnasDelGridItems1.ID_OrdenDeCompra_Det).Visible = False
        grdItems.Columns(ColumnasDelGridItems1.Remito).Visible = False

        grdItems.Columns(ColumnasDelGridItems1.Status).ReadOnly = True 'precio real
        grdItems.Columns(ColumnasDelGridItems1.Status).Width = 60
        grdItems.Columns(ColumnasDelGridItems1.Status).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grdItems.Columns(ColumnasDelGridItems1.PrecioListaReal).ReadOnly = True 'precio real
        grdItems.Columns(ColumnasDelGridItems1.PrecioListaReal).Width = 60
        grdItems.Columns(ColumnasDelGridItems1.PrecioListaReal).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdItems.Columns(ColumnasDelGridItems1.PrecioListaReal).Visible = False

        grdItems.Columns(ColumnasDelGridItems1.QtySaldo).ReadOnly = True  'precio real
        grdItems.Columns(ColumnasDelGridItems1.QtySaldo).Width = 60
        grdItems.Columns(ColumnasDelGridItems1.QtySaldo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdItems.Columns(ColumnasDelGridItems1.FechaCumplido).ReadOnly = True 'precio real
        grdItems.Columns(ColumnasDelGridItems1.FechaCumplido).Width = 80
        grdItems.Columns(ColumnasDelGridItems1.FechaCumplido).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        grdItems.Columns(ColumnasDelGridItems1.item).ReadOnly = True 'precio real
        grdItems.Columns(ColumnasDelGridItems1.item).Width = 60
        grdItems.Columns(ColumnasDelGridItems1.item).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grdItems.Columns(ColumnasDelGridItems1.PrecioEnPesos).Visible = False '4
        grdItems.Columns(ColumnasDelGridItems1.PrecioEnPesos).ReadOnly = True '4

        grdItems.Columns(ColumnasDelGridItems1.PrecioEnPesosNuevo).Visible = False '4
        grdItems.Columns(ColumnasDelGridItems1.PrecioEnPesosNuevo).ReadOnly = True '4

        grdItems.Columns(ColumnasDelGridItems1.Nuevo).Visible = False '4

        grdItems.Columns(ColumnasDelGridItems1.IdMaterial_Prov).Visible = False '4

        grdItems.Columns(ColumnasDelGridItems1.PrecioMayorista).ReadOnly = False  'precio pedido 6
        grdItems.Columns(ColumnasDelGridItems1.PrecioMayorista).Width = 100
        grdItems.Columns(ColumnasDelGridItems1.PrecioMayorista).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdItems.Columns(ColumnasDelGridItems1.PrecioPeron).ReadOnly = False  'precio pedido 6
        grdItems.Columns(ColumnasDelGridItems1.PrecioPeron).Width = 100
        grdItems.Columns(ColumnasDelGridItems1.PrecioPeron).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdItems.Columns(ColumnasDelGridItems1.PrecioMayoPeron).ReadOnly = False  'precio pedido 6
        grdItems.Columns(ColumnasDelGridItems1.PrecioMayoPeron).Width = 100
        grdItems.Columns(ColumnasDelGridItems1.PrecioMayoPeron).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdItems.Columns(ColumnasDelGridItems1.CantidadPack).HeaderText = "QtyxPack"
        grdItems.Columns(ColumnasDelGridItems1.CantidadPack).ReadOnly = False  'precio pedido 6
        grdItems.Columns(ColumnasDelGridItems1.CantidadPack).Width = 50
        grdItems.Columns(ColumnasDelGridItems1.CantidadPack).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdItems.Columns(ColumnasDelGridItems1.IdMarca).Visible = False  'precio pedido 6

        With grdItems
            .VirtualMode = False
            .AllowUserToAddRows = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .RowsDefaultCellStyle.BackColor = Color.White
            .AllowUserToOrderColumns = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .ForeColor = Color.Black
            .ScrollBars = ScrollBars.Both
        End With
        With grdItems.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Black  'Color.BlueViolet
            .ForeColor = Color.White
            .Font = New Font("TAHOMA", 8, FontStyle.Bold)
        End With
        grdItems.Font = New Font("TAHOMA", 8, FontStyle.Regular)
        'grdEnsayos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

        'Volver la fuente de datos a como estaba...
        'SQL = "exec spRecepciones_Select_All  @Eliminado = 0"

        Dim i As Integer

        For i = 0 To grdItems.RowCount - 1
            grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioLista).Style.BackColor = Color.LightGreen
            grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtyRecep).Style.BackColor = Color.LightBlue
            grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioListaReal).Style.BackColor = Color.LightBlue
        Next

    End Sub

    Private Sub LlenarGrid_IVA(ByVal Id As Long)

        Dim ds_IVAs As Data.DataSet
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds_IVAs = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT gd.PorcIva, gd.MontoIva " &
                                                                            " FROM Gastos g JOIN Gastos_det gd ON gd.idgasto = g.id WHERE IdGasto = " & IIf(txtIdGasto.Text = "", 0, txtIdGasto.Text))

            ds_IVAs.Dispose()

            Dim i As Integer
            Dim valor As Double

            For i = 0 To ds_IVAs.Tables(0).Rows.Count - 1
                valor = ds_IVAs.Tables(0).Rows(i)(1)
                'If CDbl(ds_IVAs.Tables(0).Rows(i)(0)) < 11 Then
                '    'txtMontoIVA10.Text = valor
                'Else
                '    If CDbl(ds_IVAs.Tables(0).Rows(i)(0)) = 21 Then
                '        txtMontoIVA21.Text = ds_IVAs.Tables(0).Rows(i)(1)
                '    Else
                '        If CDbl(ds_IVAs.Tables(0).Rows(i)(0)) > 21 Then
                '            txtMontoIVA27.Text = valor
                '        End If
                '    End If
                'End If
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
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Sub

    Private Sub LlenarGrid_Impuestos()

        If bolModo = False Then
            If grd.CurrentRow.Cells(14).Value = "0.00" Then
                'SQL = "exec spImpuestos_Gastos_Select_by_IdGasto @IdGasto = " & IIf(txtIdGasto.Text = "", 0, txtIdGasto.Text) & ", @Bolmodo = 1" '& bolModo
            Else
                'SQL = "exec spImpuestos_Gastos_Select_by_IdGasto @IdGasto = " & IIf(txtIdGasto.Text = "", 0, txtIdGasto.Text) & ", @Bolmodo = 0" '& bolModo
            End If
        Else
            'SQL = "exec spImpuestos_Gastos_Select_by_IdGasto @IdGasto = " & IIf(txtIdGasto.Text = "", 0, txtIdGasto.Text) & ", @Bolmodo = " & bolModo
        End If

        GetDatasetItems(grdImpuestos)

        grdImpuestos.Columns(ColumnasDelGridImpuestos.Id).Visible = False

        grdImpuestos.Columns(ColumnasDelGridImpuestos.codigo).ReadOnly = True
        grdImpuestos.Columns(ColumnasDelGridImpuestos.codigo).Width = 180

        grdImpuestos.Columns(ColumnasDelGridImpuestos.NroDocumento).Width = 110

        grdImpuestos.Columns(ColumnasDelGridImpuestos.Monto).Width = 70
        grdImpuestos.Columns(ColumnasDelGridImpuestos.Monto).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdImpuestos.Columns(ColumnasDelGridImpuestos.IdIngreso).Visible = False

        grdImpuestos.Columns(ColumnasDelGridImpuestos.IdImpuestoxGasto).Visible = False

        With grdImpuestos
            .VirtualMode = False
            .AllowUserToAddRows = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .RowsDefaultCellStyle.BackColor = Color.White
            .AllowUserToOrderColumns = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .ForeColor = Color.Black
        End With

        With grdImpuestos.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Black  'Color.BlueViolet
            .ForeColor = Color.White
            .Font = New Font("TAHOMA", 7, FontStyle.Bold)
        End With

        grdImpuestos.Font = New Font("TAHOMA", 7, FontStyle.Regular)

        'SQL = "exec spGastos_Select_All @Eliminado = 0"

    End Sub

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

        lblCantidadFilas.Text = grdItems.RowCount

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



    Private Sub LlenarcmbAlmacenes()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds_Marcas As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds_Marcas = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT 0 AS 'Codigo', '' AS 'Nombre' Union SELECT Codigo, rtrim(Nombre) as Nombre FROM Almacenes WHERE Codigo <> 4 AND Eliminado = 0 ORDER BY Nombre")
            ds_Marcas.Dispose()

            With Me.cmbAlmacenes
                .DataSource = ds_Marcas.Tables(0).DefaultView
                .DisplayMember = "Nombre"
                .ValueMember = "Codigo"
                '.AutoCompleteMode = AutoCompleteMode.Suggest
                '.AutoCompleteSource = AutoCompleteSource.ListItems
                '.DropDownStyle = ComboBoxStyle.DropDown
                '.BindingContext = Me.BindingContext
                '.SelectedIndex = 0
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

    Private Function AgregarActualizar_Registro_Recepciones(ByVal ControlFactura As Boolean, ByVal ControlRemito As Boolean) As Integer
        Dim res As Integer = 0

        Try
            Try
                conn_del_form = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End Try

            'Abrir una transaccion para guardar y asegurar que se guarda todo
            If Abrir_Tran(conn_del_form) = False Then
                MessageBox.Show("No se pudo abrir una transaccion", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                param_codigo.SqlDbType = SqlDbType.VarChar
                param_codigo.Size = 25
                param_codigo.Value = DBNull.Value
                param_codigo.Direction = ParameterDirection.InputOutput

                Dim param_idAlmacen As New SqlClient.SqlParameter
                param_idAlmacen.ParameterName = "@IdAlmacen"
                param_idAlmacen.SqlDbType = SqlDbType.BigInt
                param_idAlmacen.Value = cmbAlmacenes.SelectedValue
                param_idAlmacen.Direction = ParameterDirection.Input

                Dim param_idMoneda As New SqlClient.SqlParameter
                param_idMoneda.ParameterName = "@IdMoneda"
                param_idMoneda.SqlDbType = SqlDbType.BigInt
                param_idMoneda.Value = If(txtIdMoneda.Text = "", 0, txtIdMoneda.Text)
                param_idMoneda.Direction = ParameterDirection.Input





                Dim param_fecha As New SqlClient.SqlParameter
                param_fecha.ParameterName = "@fecha"
                param_fecha.SqlDbType = SqlDbType.DateTime
                param_fecha.Value = dtpFECHA.Value
                param_fecha.Direction = ParameterDirection.Input


                Dim param_nota As New SqlClient.SqlParameter
                param_nota.ParameterName = "@nota"
                param_nota.SqlDbType = SqlDbType.VarChar
                param_nota.Size = 150
                param_nota.Value = txtNota.Text
                param_nota.Direction = ParameterDirection.Input



                Dim param_ControlRemito As New SqlClient.SqlParameter
                param_ControlRemito.ParameterName = "@ControlRemito"
                param_ControlRemito.SqlDbType = SqlDbType.Bit
                param_ControlRemito.Value = ControlRemito
                param_ControlRemito.Direction = ParameterDirection.Input

                Dim param_ControlFactura As New SqlClient.SqlParameter
                param_ControlFactura.ParameterName = "@ControlFactura"
                param_ControlFactura.SqlDbType = SqlDbType.Bit
                param_ControlFactura.Value = ControlFactura
                param_ControlFactura.Direction = ParameterDirection.Input

                Dim param_user As New SqlClient.SqlParameter
                If bolModo = True Then
                    param_user.ParameterName = "@user"
                Else
                    param_user.ParameterName = "@userupd"
                End If
                param_user.SqlDbType = SqlDbType.Int
                param_user.Value = UserID
                param_user.Direction = ParameterDirection.Input

                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.InputOutput

                Try
                    If bolModo = True Then
                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spRecepciones_Insert",
                                              param_id, param_codigo, param_idAlmacen, param_idMoneda,
                                               param_fecha, param_nota, param_user, param_res)

                        txtID.Text = param_id.Value
                        txtCODIGOunused.Text = param_codigo.Value
                    Else
                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spRecepciones_Update",
                                              param_id, param_ControlRemito, param_ControlFactura,
                                              param_fecha, param_nota, param_user, param_res)
                    End If

                    AgregarActualizar_Registro_Recepciones = param_res.Value

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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Function

    Private Function AgregarRegistro_Recepciones_Items(ByVal idRecepcion As Long) As Integer
        Dim res As Integer = 0
        Dim msg As String
        Dim i As Integer
        Dim ActualizarPrecio As Boolean = False

        Dim ValorActual As Double
        'Dim IdStockMov As Long
        'Dim Stock As Double


        Dim Comprob As String

        Try
            Try
                i = 0

                For i = 0 To grdItems.Rows.Count - 1
                    If grdItems.Rows(i).Cells(ColumnasDelGridItems1.PorcDif).Value <> 0 Then
                        ActualizarPrecio = True
                    End If
                Next

                If ActualizarPrecio = True Then
                    ActualizarPrecio = False
                    If MessageBox.Show("Existen productos cuyos precios son diferentes. Desea actualizarlos de manera individual?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        ActualizarPrecio = True
                    End If
                End If

                i = 0

                Do While i < grdItems.Rows.Count

                    If CType(grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtyRecep).Value, Decimal) > 0 Then

                        ValorActual = grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtyRecep).Value


                        Dim param_id As New SqlClient.SqlParameter
                        param_id.ParameterName = "@id"
                        param_id.SqlDbType = SqlDbType.BigInt
                        param_id.Value = DBNull.Value
                        param_id.Direction = ParameterDirection.InputOutput

                        Dim param_codigo As New SqlClient.SqlParameter
                        param_codigo.ParameterName = "@codigo"
                        param_codigo.SqlDbType = SqlDbType.VarChar
                        param_codigo.Size = 25
                        param_codigo.Value = DBNull.Value
                        param_codigo.Direction = ParameterDirection.InputOutput

                        Dim param_idAlmacen As New SqlClient.SqlParameter
                        param_idAlmacen.ParameterName = "@IdAlmacen"
                        param_idAlmacen.SqlDbType = SqlDbType.BigInt
                        param_idAlmacen.Value = cmbAlmacenes.SelectedValue
                        param_idAlmacen.Direction = ParameterDirection.Input

                        Dim param_idRecepcion As New SqlClient.SqlParameter
                        param_idRecepcion.ParameterName = "@idrecepcion"
                        param_idRecepcion.SqlDbType = SqlDbType.BigInt
                        param_idRecepcion.Value = idRecepcion
                        param_idRecepcion.Direction = ParameterDirection.Input

                        Dim param_idmaterial As New SqlClient.SqlParameter
                        param_idmaterial.ParameterName = "@idmaterial"
                        param_idmaterial.SqlDbType = SqlDbType.VarChar
                        param_idmaterial.Size = 25
                        param_idmaterial.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems1.IDMaterial).Value
                        param_idmaterial.Direction = ParameterDirection.Input

                        Dim param_idmaterial_prov As New SqlClient.SqlParameter
                        param_idmaterial_prov.ParameterName = "@idmaterial_prov"
                        param_idmaterial_prov.SqlDbType = SqlDbType.BigInt
                        param_idmaterial_prov.Value = CType(grdItems.Rows(i).Cells(ColumnasDelGridItems1.IdMaterial_Prov).Value, Long)
                        param_idmaterial_prov.Direction = ParameterDirection.Input

                        Dim param_Codigo_Mat_Prov As New SqlClient.SqlParameter
                        param_Codigo_Mat_Prov.ParameterName = "@codigo_mat_prov"
                        param_Codigo_Mat_Prov.SqlDbType = SqlDbType.VarChar
                        param_Codigo_Mat_Prov.Size = 25
                        param_Codigo_Mat_Prov.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems1.Cod_Mat_Prov).Value
                        param_Codigo_Mat_Prov.Direction = ParameterDirection.Input



                        Dim param_qty As New SqlClient.SqlParameter
                        param_qty.ParameterName = "@qty"
                        param_qty.SqlDbType = SqlDbType.Decimal
                        param_qty.Precision = 18
                        param_qty.Scale = 2
                        param_qty.Value = CType(grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtyRecep).Value, Decimal)
                        param_qty.Direction = ParameterDirection.Input

                        Dim param_idunidad As New SqlClient.SqlParameter
                        param_idunidad.ParameterName = "@idunidad"
                        param_idunidad.SqlDbType = SqlDbType.VarChar
                        param_idunidad.Size = 25
                        param_idunidad.Value = IIf(grdItems.Rows(i).Cells(ColumnasDelGridItems1.IdUnidad).Value Is DBNull.Value, "U", grdItems.Rows(i).Cells(ColumnasDelGridItems1.IdUnidad).Value)
                        param_idunidad.Direction = ParameterDirection.Input



                        Dim param_user As New SqlClient.SqlParameter
                        param_user.ParameterName = "@user"
                        param_user.SqlDbType = SqlDbType.Int
                        param_user.Value = UserID
                        param_user.Direction = ParameterDirection.Input

                        Dim param_Nuevo As New SqlClient.SqlParameter
                        param_Nuevo.ParameterName = "@Nuevo"
                        param_Nuevo.SqlDbType = SqlDbType.Bit
                        param_Nuevo.Value = CType(grdItems.Rows(i).Cells(ColumnasDelGridItems1.Nuevo).Value, Boolean)
                        param_Nuevo.Direction = ParameterDirection.Input

                        Dim param_idordendecompra As New SqlClient.SqlParameter
                        param_idordendecompra.ParameterName = "@idordendecompra"
                        param_idordendecompra.SqlDbType = SqlDbType.BigInt
                        If grdItems.Rows(i).Cells(ColumnasDelGridItems1.ID_OrdenDeCompra).Value Is DBNull.Value Then
                            param_idordendecompra.Value = 0
                        Else
                            param_idordendecompra.Value = CType(grdItems.Rows(i).Cells(ColumnasDelGridItems1.ID_OrdenDeCompra).Value, Long)
                        End If
                        param_idordendecompra.Direction = ParameterDirection.Input

                        Dim param_idordendecompradet As New SqlClient.SqlParameter
                        param_idordendecompradet.ParameterName = "@idordendecompradet"
                        param_idordendecompradet.SqlDbType = SqlDbType.BigInt
                        If grdItems.Rows(i).Cells(ColumnasDelGridItems1.ID_OrdenDeCompra_Det).Value Is DBNull.Value Then
                            param_idordendecompradet.Value = 0
                        Else
                            param_idordendecompradet.Value = CType(grdItems.Rows(i).Cells(ColumnasDelGridItems1.ID_OrdenDeCompra_Det).Value, Long)
                        End If
                        param_idordendecompradet.Direction = ParameterDirection.Input

                        Dim param_material As New SqlClient.SqlParameter
                        param_material.ParameterName = "@material"
                        param_material.SqlDbType = SqlDbType.VarChar
                        param_material.Size = 300
                        param_material.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems1.Nombre_Material).Value
                        param_material.Direction = ParameterDirection.Input

                        Dim param_idmoneda As New SqlClient.SqlParameter
                        param_idmoneda.ParameterName = "@idmoneda"
                        param_idmoneda.SqlDbType = SqlDbType.BigInt
                        param_idmoneda.Value = IIf(grdItems.Rows(i).Cells(ColumnasDelGridItems1.IdMoneda).Value Is DBNull.Value, 1, grdItems.Rows(i).Cells(ColumnasDelGridItems1.IdMoneda).Value)
                        param_idmoneda.Direction = ParameterDirection.Input

                        Dim param_bonificacion1 As New SqlClient.SqlParameter
                        param_bonificacion1.ParameterName = "@bonif1"
                        param_bonificacion1.SqlDbType = SqlDbType.Decimal
                        param_bonificacion1.Precision = 18
                        param_bonificacion1.Scale = 2
                        param_bonificacion1.Value = IIf(grdItems.Rows(i).Cells(ColumnasDelGridItems1.Bonif1).Value Is DBNull.Value, 0, grdItems.Rows(i).Cells(ColumnasDelGridItems1.Bonif1).Value)
                        param_bonificacion1.Direction = ParameterDirection.Input

                        Dim param_bonificacion2 As New SqlClient.SqlParameter
                        param_bonificacion2.ParameterName = "@bonif2"
                        param_bonificacion2.SqlDbType = SqlDbType.Decimal
                        param_bonificacion2.Precision = 18
                        param_bonificacion2.Scale = 2
                        param_bonificacion2.Value = IIf(grdItems.Rows(i).Cells(ColumnasDelGridItems1.Bonif2).Value Is DBNull.Value, 0, grdItems.Rows(i).Cells(ColumnasDelGridItems1.Bonif2).Value)
                        param_bonificacion2.Direction = ParameterDirection.Input

                        Dim param_bonificacion3 As New SqlClient.SqlParameter
                        param_bonificacion3.ParameterName = "@bonif3"
                        param_bonificacion3.SqlDbType = SqlDbType.Decimal
                        param_bonificacion3.Precision = 18
                        param_bonificacion3.Scale = 2
                        param_bonificacion3.Value = IIf(grdItems.Rows(i).Cells(ColumnasDelGridItems1.Bonif3).Value Is DBNull.Value, 0, grdItems.Rows(i).Cells(ColumnasDelGridItems1.Bonif3).Value)
                        param_bonificacion3.Direction = ParameterDirection.Input

                        Dim param_bonificacion4 As New SqlClient.SqlParameter
                        param_bonificacion4.ParameterName = "@bonif4"
                        param_bonificacion4.SqlDbType = SqlDbType.Decimal
                        param_bonificacion4.Precision = 18
                        param_bonificacion4.Scale = 2
                        param_bonificacion4.Value = IIf(grdItems.Rows(i).Cells(ColumnasDelGridItems1.Bonif4).Value Is DBNull.Value, 0, grdItems.Rows(i).Cells(ColumnasDelGridItems1.Bonif4).Value)
                        param_bonificacion4.Direction = ParameterDirection.Input

                        Dim param_bonificacion5 As New SqlClient.SqlParameter
                        param_bonificacion5.ParameterName = "@bonif5"
                        param_bonificacion5.SqlDbType = SqlDbType.Decimal
                        param_bonificacion5.Precision = 18
                        param_bonificacion5.Scale = 2
                        param_bonificacion5.Value = IIf(grdItems.Rows(i).Cells(ColumnasDelGridItems1.Bonif5).Value Is DBNull.Value, 0, grdItems.Rows(i).Cells(ColumnasDelGridItems1.Bonif5).Value)
                        param_bonificacion5.Direction = ParameterDirection.Input

                        Dim param_ganancia As New SqlClient.SqlParameter
                        param_ganancia.ParameterName = "@ganancia"
                        param_ganancia.SqlDbType = SqlDbType.Decimal
                        param_ganancia.Precision = 18
                        param_ganancia.Scale = 2
                        param_ganancia.Value = CType(grdItems.Rows(i).Cells(ColumnasDelGridItems1.Ganancia).Value, Double)
                        param_ganancia.Direction = ParameterDirection.Input

                        Dim param_precioventa As New SqlClient.SqlParameter
                        param_precioventa.ParameterName = "@precioventa"
                        param_precioventa.SqlDbType = SqlDbType.Decimal
                        param_precioventa.Precision = 18
                        param_precioventa.Scale = 2
                        param_precioventa.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioMayorista).Value
                        param_precioventa.Direction = ParameterDirection.Input

                        'Dim param_precioxkg As New SqlClient.SqlParameter
                        'param_precioxkg.ParameterName = "@precioxkg"
                        'param_precioxkg.SqlDbType = SqlDbType.Decimal
                        'param_precioxkg.Precision = 18
                        'param_precioxkg.Scale = 2
                        'param_precioxkg.Value = 0 'grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioxKg).Value
                        'param_precioxkg.Direction = ParameterDirection.Input

                        'Dim param_pesoxmetro As New SqlClient.SqlParameter
                        'param_pesoxmetro.ParameterName = "@pesoxmetro"
                        'param_pesoxmetro.SqlDbType = SqlDbType.Decimal
                        'param_pesoxmetro.Precision = 18
                        'param_pesoxmetro.Scale = 2
                        'param_pesoxmetro.Value = 0 'grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioxMt).Value
                        'param_pesoxmetro.Direction = ParameterDirection.Input

                        'Dim param_cantxlongitud As New SqlClient.SqlParameter
                        'param_cantxlongitud.ParameterName = "@cantxlongitud"
                        'param_cantxlongitud.SqlDbType = SqlDbType.Decimal
                        'param_cantxlongitud.Precision = 18
                        'param_cantxlongitud.Scale = 2
                        'param_cantxlongitud.Value = 0 'grdItems.Rows(i).Cells(ColumnasDelGridItems1.CantxLongitud).Value
                        'param_cantxlongitud.Direction = ParameterDirection.Input

                        Dim param_pesoxunidad As New SqlClient.SqlParameter
                        param_pesoxunidad.ParameterName = "@pesoxunidad"
                        param_pesoxunidad.SqlDbType = SqlDbType.Decimal
                        param_pesoxunidad.Precision = 18
                        param_pesoxunidad.Scale = 2
                        param_pesoxunidad.Value = 0 'grdItems.Rows(i).Cells(ColumnasDelGridItems1.PesoxUnidad).Value
                        param_pesoxunidad.Direction = ParameterDirection.Input

                        Dim param_preciolista As New SqlClient.SqlParameter
                        param_preciolista.ParameterName = "@preciolista"
                        param_preciolista.SqlDbType = SqlDbType.Decimal
                        param_preciolista.Precision = 18
                        param_preciolista.Scale = 2
                        param_preciolista.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioListaReal).Value
                        param_preciolista.Direction = ParameterDirection.Input

                        Dim param_preciovtasiniva As New SqlClient.SqlParameter
                        param_preciovtasiniva.ParameterName = "@PrecioCosto"
                        param_preciovtasiniva.SqlDbType = SqlDbType.Decimal
                        param_preciovtasiniva.Precision = 18
                        param_preciovtasiniva.Scale = 2
                        param_preciovtasiniva.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioCosto).Value 'grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioEnPesosNuevo).Value / grdItems.Rows(i).Cells(ColumnasDelGridItems1.ValorCambio).Value
                        param_preciovtasiniva.Direction = ParameterDirection.Input

                        Dim param_preciorevendedor As New SqlClient.SqlParameter
                        param_preciorevendedor.ParameterName = "@PrecioRevendedor"
                        param_preciorevendedor.SqlDbType = SqlDbType.Decimal
                        param_preciorevendedor.Precision = 18
                        param_preciorevendedor.Scale = 2
                        param_preciorevendedor.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioRevendedor).Value 'grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioEnPesosNuevo).Value / grdItems.Rows(i).Cells(ColumnasDelGridItems1.ValorCambio).Value
                        param_preciorevendedor.Direction = ParameterDirection.Input

                        Dim param_precioyamila As New SqlClient.SqlParameter
                        param_precioyamila.ParameterName = "@PrecioYamila"
                        param_precioyamila.SqlDbType = SqlDbType.Decimal
                        param_precioyamila.Precision = 18
                        param_precioyamila.Scale = 2
                        param_precioyamila.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioYamila).Value 'grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioEnPesosNuevo).Value / grdItems.Rows(i).Cells(ColumnasDelGridItems1.ValorCambio).Value
                        param_precioyamila.Direction = ParameterDirection.Input

                        Dim param_preciolista4 As New SqlClient.SqlParameter
                        param_preciolista4.ParameterName = "@PrecioLista4"
                        param_preciolista4.SqlDbType = SqlDbType.Decimal
                        param_preciolista4.Precision = 18
                        param_preciolista4.Scale = 2
                        param_preciolista4.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioLista4).Value 'grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioEnPesosNuevo).Value / grdItems.Rows(i).Cells(ColumnasDelGridItems1.ValorCambio).Value
                        param_preciolista4.Direction = ParameterDirection.Input

                        Dim param_precioperon As New SqlClient.SqlParameter
                        param_precioperon.ParameterName = "@PrecioPeron"
                        param_precioperon.SqlDbType = SqlDbType.Decimal
                        param_precioperon.Precision = 18
                        param_precioperon.Scale = 2
                        param_precioperon.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioPeron).Value 'grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioEnPesosNuevo).Value / grdItems.Rows(i).Cells(ColumnasDelGridItems1.ValorCambio).Value
                        param_precioperon.Direction = ParameterDirection.Input

                        Dim param_precioperonmayo As New SqlClient.SqlParameter
                        param_precioperonmayo.ParameterName = "@PrecioMayoristaPeron"
                        param_precioperonmayo.SqlDbType = SqlDbType.Decimal
                        param_precioperonmayo.Precision = 18
                        param_precioperonmayo.Scale = 2
                        param_precioperonmayo.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioMayoPeron).Value 'grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioEnPesosNuevo).Value / grdItems.Rows(i).Cells(ColumnasDelGridItems1.ValorCambio).Value
                        param_precioperonmayo.Direction = ParameterDirection.Input

                        Dim param_iva As New SqlClient.SqlParameter
                        param_iva.ParameterName = "@Iva"
                        param_iva.SqlDbType = SqlDbType.Decimal
                        param_iva.Precision = 18
                        param_iva.Scale = 2
                        param_iva.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems1.IVA).Value
                        param_iva.Direction = ParameterDirection.Input

                        Dim param_ActualizarPrecio As New SqlClient.SqlParameter
                        param_ActualizarPrecio.ParameterName = "@ActualizarPrecio"
                        param_ActualizarPrecio.SqlDbType = SqlDbType.Bit
                        param_ActualizarPrecio.Value = ActualizarPrecio
                        param_ActualizarPrecio.Direction = ParameterDirection.Input
                        '---------------------------------------agregue--------------------------------------------'
                        Dim param_IdStockMov As New SqlClient.SqlParameter
                        param_IdStockMov.ParameterName = "@IdStockMov"
                        param_IdStockMov.SqlDbType = SqlDbType.Int
                        param_IdStockMov.Value = DBNull.Value
                        param_IdStockMov.Direction = ParameterDirection.InputOutput

                        Dim param_Comprob As New SqlClient.SqlParameter
                        param_Comprob.ParameterName = "@Comprob"
                        param_Comprob.SqlDbType = SqlDbType.VarChar
                        param_Comprob.Size = 50
                        param_Comprob.Value = DBNull.Value
                        param_Comprob.Direction = ParameterDirection.InputOutput

                        Dim param_Stock As New SqlClient.SqlParameter
                        param_Stock.ParameterName = "@Stock"
                        param_Stock.SqlDbType = SqlDbType.Decimal
                        param_Stock.Precision = 18
                        param_Stock.Scale = 2
                        param_Stock.Value = DBNull.Value
                        param_Stock.Direction = ParameterDirection.InputOutput
                        '------------------------------------agregue-----------------------------------------'
                        Dim param_res As New SqlClient.SqlParameter
                        param_res.ParameterName = "@res"
                        param_res.SqlDbType = SqlDbType.Int
                        param_res.Value = DBNull.Value
                        param_res.Direction = ParameterDirection.InputOutput

                        Dim param_msg As New SqlClient.SqlParameter
                        param_msg.ParameterName = "@mensaje"
                        param_msg.SqlDbType = SqlDbType.VarChar
                        param_msg.Size = 150
                        param_msg.Value = DBNull.Value
                        param_msg.Direction = ParameterDirection.InputOutput

                        Try
                            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spRecepciones_Det_Insert2",
                                                    param_id, param_codigo, param_idAlmacen, param_idRecepcion, param_idmaterial, param_idmaterial_prov,
                                                    param_Codigo_Mat_Prov, param_preciorevendedor, param_precioyamila, param_preciolista4,
                                                    param_qty, param_idunidad, param_user, param_Nuevo,
                                                    param_idordendecompra, param_idordendecompradet, param_material,
                                                    param_idmoneda, param_bonificacion1, param_bonificacion2, param_bonificacion3,
                                                    param_bonificacion4, param_bonificacion5, param_ganancia, param_pesoxunidad, param_precioventa,
                                                    param_preciolista, param_preciovtasiniva, param_iva, param_ActualizarPrecio,
                                                    param_precioperon, param_precioperonmayo,
                                                    param_IdStockMov, param_Comprob, param_Stock, param_res, param_msg)

                            'MsgBox(param_msg.Value.ToString)

                            res = param_res.Value
                            If Not (param_msg.Value Is System.DBNull.Value) Then
                                msg = param_msg.Value
                            Else
                                msg = ""
                            End If
                            If (res <= 0) Then
                                Exit Do
                            End If
                            Comprob = param_Comprob.Value


                        Catch ex As Exception
                            Throw ex
                        End Try

                    End If

                    i = i + 1

                Loop

                AgregarRegistro_Recepciones_Items = res

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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function AgregarActualizar_Registro_Gastos(ByVal ControlFactura As Boolean, ByVal ControlRemito As Boolean) As Integer
        Dim res As Integer = 0
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            Try
                Dim param_id As New SqlClient.SqlParameter
                param_id.ParameterName = "@id"
                param_id.SqlDbType = SqlDbType.BigInt
                If bolModo = True Then
                    param_id.Value = DBNull.Value
                    param_id.Direction = ParameterDirection.InputOutput
                Else
                    param_id.Value = txtIdGasto.Text
                    param_id.Direction = ParameterDirection.Input
                End If

                Dim param_idrecepcion As New SqlClient.SqlParameter
                param_idrecepcion.ParameterName = "@idrecepcion"
                param_idrecepcion.SqlDbType = SqlDbType.BigInt
                param_idrecepcion.Value = txtID.Text
                param_idrecepcion.Direction = ParameterDirection.Input

                Dim param_codigo As New SqlClient.SqlParameter
                param_codigo.ParameterName = "@codigo"
                param_codigo.SqlDbType = SqlDbType.BigInt
                If bolModo = True Then
                    param_codigo.Value = DBNull.Value
                    param_codigo.Direction = ParameterDirection.InputOutput
                Else
                    param_codigo.Value = txtCODIGOunused.Text
                    param_codigo.Direction = ParameterDirection.Input
                End If

                Dim param_fechagasto As New SqlClient.SqlParameter
                param_fechagasto.ParameterName = "@fechagasto"
                param_fechagasto.SqlDbType = SqlDbType.DateTime
                param_fechagasto.Value = dtpFECHA.Value
                param_fechagasto.Direction = ParameterDirection.Input

                Dim param_tipogasto As New SqlClient.SqlParameter
                param_tipogasto.ParameterName = "@tipogasto"
                param_tipogasto.SqlDbType = SqlDbType.BigInt
                param_tipogasto.Value = 2
                param_tipogasto.Direction = ParameterDirection.Input



                Dim param_IdMoneda As New SqlClient.SqlParameter
                param_IdMoneda.ParameterName = "@idmoneda"
                param_IdMoneda.SqlDbType = SqlDbType.BigInt
                param_IdMoneda.Value = IIf(txtIdMoneda.Text = "", 0, txtIdMoneda.Text)
                param_IdMoneda.Direction = ParameterDirection.Input




                Dim param_MontoIVA As New SqlClient.SqlParameter
                param_MontoIVA.ParameterName = "@MontoIVA"
                param_MontoIVA.SqlDbType = SqlDbType.Decimal
                param_MontoIVA.Size = 18
                param_MontoIVA.Value = IIf(lblMontoIva.Text = "", 0, lblMontoIva.Text)
                param_MontoIVA.Direction = ParameterDirection.Input


                Dim param_Total As New SqlClient.SqlParameter
                param_Total.ParameterName = "@Total"
                param_Total.SqlDbType = SqlDbType.Decimal
                param_Total.Size = 18
                param_Total.Value = IIf(lblTotal.Text = "", 0, lblTotal.Text)
                param_Total.Direction = ParameterDirection.Input

                Dim param_totalPesos As New SqlClient.SqlParameter
                param_totalPesos.ParameterName = "@TotalPesos"
                param_totalPesos.SqlDbType = SqlDbType.Decimal
                param_totalPesos.Precision = 18
                param_totalPesos.Scale = 2
                param_totalPesos.Value = lblTotal.Text
                param_totalPesos.Direction = ParameterDirection.Input




                Dim param_descripcion As New SqlClient.SqlParameter
                param_descripcion.ParameterName = "@descripcion"
                param_descripcion.SqlDbType = SqlDbType.VarChar
                param_descripcion.Size = 200
                param_descripcion.Value = txtNota.Text
                param_descripcion.Direction = ParameterDirection.Input

                Dim param_imputarotroperiodo As New SqlClient.SqlParameter
                param_imputarotroperiodo.ParameterName = "@ImputaraOtroPeriodo"
                param_imputarotroperiodo.SqlDbType = SqlDbType.Bit
                param_imputarotroperiodo.Value = 0
                param_imputarotroperiodo.Direction = ParameterDirection.Input

                Dim param_periodo As New SqlClient.SqlParameter
                param_periodo.ParameterName = "@periodoimputacion"
                param_periodo.SqlDbType = SqlDbType.DateTime
                param_periodo.Value = DBNull.Value
                param_periodo.Direction = ParameterDirection.Input

                Dim param_ControlRemito As New SqlClient.SqlParameter
                param_ControlRemito.ParameterName = "@ControlRemito"
                param_ControlRemito.SqlDbType = SqlDbType.Bit
                param_ControlRemito.Value = ControlRemito
                param_ControlRemito.Direction = ParameterDirection.Input

                Dim param_ControlFactura As New SqlClient.SqlParameter
                param_ControlFactura.ParameterName = "@ControlFactura"
                param_ControlFactura.SqlDbType = SqlDbType.Bit
                param_ControlFactura.Value = ControlFactura
                param_ControlFactura.Direction = ParameterDirection.Input



                Dim param_UsuarioGasto As New SqlClient.SqlParameter
                param_UsuarioGasto.ParameterName = "@UsuarioGasto"
                param_UsuarioGasto.SqlDbType = SqlDbType.VarChar
                param_UsuarioGasto.Size = 200
                param_UsuarioGasto.Value = cmbObraSocial.Text
                param_UsuarioGasto.Direction = ParameterDirection.Input

                Dim param_user As New SqlClient.SqlParameter
                If bolModo = True Then
                    param_user.ParameterName = "@user"
                Else
                    param_user.ParameterName = "@userupd"
                End If
                param_user.SqlDbType = SqlDbType.Int
                param_user.Value = UserID
                param_user.Direction = ParameterDirection.Input

                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.InputOutput

                Try

                    If bolModo = True Then
                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spGastos_Insert",
                                            param_id, param_idrecepcion, param_codigo, param_fechagasto,
                                            param_tipogasto, param_IdMoneda,
                                            param_MontoIVA,
                                            param_Total, param_totalPesos, param_descripcion,
                                            param_imputarotroperiodo, param_periodo,
                                            param_UsuarioGasto,
                                            param_user, param_res)

                        txtCODIGOunused.Text = param_codigo.Value

                    Else
                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spGastos_Update",
                                            param_id, param_fechagasto,
                                            param_tipogasto, param_IdMoneda,
                                            param_MontoIVA,
                                            param_Total, param_totalPesos, param_descripcion,
                                            param_imputarotroperiodo, param_periodo,
                                            param_ControlFactura, param_ControlRemito,
                                            param_user, param_res)

                    End If

                    txtIdGasto.Text = param_id.Value
                    res = param_res.Value

                    AgregarActualizar_Registro_Gastos = res

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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Function AgregarActualizar_Pago() As Integer
        Dim res As Integer = 0

        Try
            Dim param_id As New SqlClient.SqlParameter
            param_id.ParameterName = "@id"
            param_id.SqlDbType = SqlDbType.BigInt
            If bolModo = True Then
                param_id.Value = DBNull.Value
            Else
                param_id.Value = IIf(txtidpago.Text = "", DBNull.Value, txtidpago.Text)
            End If
            param_id.Direction = ParameterDirection.InputOutput

            Dim param_codigo As New SqlClient.SqlParameter
            param_codigo.ParameterName = "@codigo"
            param_codigo.SqlDbType = SqlDbType.VarChar
            param_codigo.Size = 25
            param_codigo.Value = DBNull.Value
            param_codigo.Direction = ParameterDirection.InputOutput

            Dim param_idGasto As New SqlClient.SqlParameter
            param_idGasto.ParameterName = "@idgasto"
            param_idGasto.SqlDbType = SqlDbType.BigInt
            param_idGasto.Value = txtIdGasto.Text
            param_idGasto.Direction = ParameterDirection.Input

            Dim param_fecha As New SqlClient.SqlParameter
            param_fecha.ParameterName = "@fechaPago"
            param_fecha.SqlDbType = SqlDbType.DateTime
            param_fecha.Value = dtpFECHA.Value
            param_fecha.Direction = ParameterDirection.Input



            Dim param_nota As New SqlClient.SqlParameter
            param_nota.ParameterName = "@Nota"
            param_nota.SqlDbType = SqlDbType.VarChar
            param_nota.Size = 300
            param_nota.Value = txtNota.Text
            param_nota.Direction = ParameterDirection.Input

            Dim param_contado As New SqlClient.SqlParameter
            param_contado.ParameterName = "@Contado"
            param_contado.SqlDbType = SqlDbType.Bit
            param_contado.Value = True
            param_contado.Direction = ParameterDirection.Input

            Dim param_montoContado As New SqlClient.SqlParameter
            param_montoContado.ParameterName = "@MontoContado"
            param_montoContado.SqlDbType = SqlDbType.Decimal
            param_montoContado.Precision = 18
            param_montoContado.Scale = 2
            param_montoContado.Value = IIf(lblTotal.Text = "", 0, lblTotal.Text)
            param_montoContado.Direction = ParameterDirection.Input

            Dim param_tarjeta As New SqlClient.SqlParameter
            param_tarjeta.ParameterName = "@tarjeta"
            param_tarjeta.SqlDbType = SqlDbType.Bit
            param_tarjeta.Value = False
            param_tarjeta.Direction = ParameterDirection.Input

            Dim param_nombretarjeta As New SqlClient.SqlParameter
            param_nombretarjeta.ParameterName = "@NombreTarjeta"
            param_nombretarjeta.SqlDbType = SqlDbType.VarChar
            param_nombretarjeta.Size = 50
            param_nombretarjeta.Value = ""
            param_nombretarjeta.Direction = ParameterDirection.Input

            Dim param_montotarjeta As New SqlClient.SqlParameter
            param_montotarjeta.ParameterName = "@montotarjeta"
            param_montotarjeta.SqlDbType = SqlDbType.Decimal
            param_montotarjeta.Precision = 18
            param_montotarjeta.Scale = 2
            param_montotarjeta.Value = 0
            param_montotarjeta.Direction = ParameterDirection.Input

            Dim param_cheque As New SqlClient.SqlParameter
            param_cheque.ParameterName = "@cheque"
            param_cheque.SqlDbType = SqlDbType.Bit
            param_cheque.Value = False
            param_cheque.Direction = ParameterDirection.Input

            Dim param_montocheque As New SqlClient.SqlParameter
            param_montocheque.ParameterName = "@montocheque"
            param_montocheque.SqlDbType = SqlDbType.Decimal
            param_montocheque.Precision = 18
            param_montocheque.Scale = 2
            param_montocheque.Value = 0
            param_montocheque.Direction = ParameterDirection.Input

            Dim param_montochequepropio As New SqlClient.SqlParameter
            param_montochequepropio.ParameterName = "@montochequepropio"
            param_montochequepropio.SqlDbType = SqlDbType.Decimal
            param_montochequepropio.Precision = 18
            param_montochequepropio.Scale = 2
            param_montochequepropio.Value = 0
            param_montochequepropio.Direction = ParameterDirection.Input

            Dim param_transferencia As New SqlClient.SqlParameter
            param_transferencia.ParameterName = "@transferencia"
            param_transferencia.SqlDbType = SqlDbType.Bit
            param_transferencia.Value = False
            param_transferencia.Direction = ParameterDirection.Input

            Dim param_montotransf As New SqlClient.SqlParameter
            param_montotransf.ParameterName = "@montotransf"
            param_montotransf.SqlDbType = SqlDbType.Decimal
            param_montotransf.Precision = 18
            param_montotransf.Scale = 2
            param_montotransf.Value = 0
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
            param_montoiva.Value = IIf(lblMontoIva.Text = "", 0, lblMontoIva.Text)
            param_montoiva.Direction = ParameterDirection.Input


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
            param_Redondeo.Value = 0
            param_Redondeo.Direction = ParameterDirection.Input

            Dim param_user As New SqlClient.SqlParameter
            If bolModo = True Then
                param_user.ParameterName = "@user"
            Else
                param_user.ParameterName = "@userupd"
            End If
            param_user.SqlDbType = SqlDbType.Int
            param_user.Value = UserID
            param_user.Direction = ParameterDirection.Input

            Dim param_res As New SqlClient.SqlParameter
            param_res.ParameterName = "@res"
            param_res.SqlDbType = SqlDbType.Int
            param_res.Value = DBNull.Value
            param_res.Direction = ParameterDirection.InputOutput

            Try

                If bolModo = True Then
                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Insert",
                                            param_id, param_codigo, param_fecha, param_contado, param_montoContado,
                                            param_tarjeta, param_montotarjeta, param_cheque, param_montocheque, param_montochequepropio,
                                            param_transferencia, param_montotransf, param_impuestos, param_montoimpuesto,
                                            param_montoiva, param_total, param_Redondeo, param_nota,
                                            param_user, param_res)

                Else
                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Update",
                                            param_id, param_codigo, param_fecha, param_contado, param_montoContado,
                                            param_tarjeta, param_montotarjeta, param_cheque, param_montocheque, param_montochequepropio,
                                            param_transferencia, param_montotransf, param_impuestos, param_montoimpuesto,
                                            param_montoiva, param_total, param_Redondeo, param_nota,
                                            param_user, param_res)

                End If

                txtidpago.Text = param_id.Value

                AgregarActualizar_Pago = param_res.Value

            Catch ex As Exception
                Throw ex
            End Try

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

    End Function

    Private Function AgregarRegistro_PagosGastos() As Integer
        Dim res As Integer = 0

        Try

            Dim param_idPago As New SqlClient.SqlParameter
            param_idPago.ParameterName = "@idPago"
            param_idPago.SqlDbType = SqlDbType.BigInt
            param_idPago.Value = txtidpago.Text
            param_idPago.Direction = ParameterDirection.Input

            Dim param_idGasto As New SqlClient.SqlParameter
            param_idGasto.ParameterName = "@idGasto"
            param_idGasto.SqlDbType = SqlDbType.BigInt
            param_idGasto.Value = txtIdGasto.Text
            param_idGasto.Direction = ParameterDirection.Input

            Dim param_DEUDA As New SqlClient.SqlParameter
            param_DEUDA.ParameterName = "@Deuda"
            param_DEUDA.SqlDbType = SqlDbType.Decimal
            param_DEUDA.Precision = 18
            param_DEUDA.Scale = 2
            param_DEUDA.Value = 0
            param_DEUDA.Direction = ParameterDirection.Input

            Dim param_CancelarTodo As New SqlClient.SqlParameter
            param_CancelarTodo.ParameterName = "@CancelarTodo"
            param_CancelarTodo.SqlDbType = SqlDbType.Bit
            param_CancelarTodo.Value = 1
            param_CancelarTodo.Direction = ParameterDirection.Input

            Dim param_res As New SqlClient.SqlParameter
            param_res.ParameterName = "@res"
            param_res.SqlDbType = SqlDbType.Int
            param_res.Value = DBNull.Value
            param_res.Direction = ParameterDirection.InputOutput

            Try
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPagos_Gastos_Insert",
                                          param_idPago, param_idGasto, param_DEUDA, param_CancelarTodo, param_res)

                res = param_res.Value

            Catch ex As Exception
                Throw ex
            End Try

            AgregarRegistro_PagosGastos = res

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
    End Function

    Private Function AgregarRegistro_Impuestos() As Integer
        Dim res As Integer = 0
        Dim i As Integer

        Try

            Try

                For i = 0 To grdImpuestos.RowCount - 1

                    Dim param_Id As New SqlClient.SqlParameter
                    param_Id.ParameterName = "@Id"
                    param_Id.SqlDbType = SqlDbType.BigInt
                    param_Id.Value = grdImpuestos.Rows(i).Cells(ColumnasDelGridImpuestos.IdImpuestoxGasto).Value
                    param_Id.Direction = ParameterDirection.Input

                    Dim param_IdGasto As New SqlClient.SqlParameter
                    param_IdGasto.ParameterName = "@IdGasto"
                    param_IdGasto.SqlDbType = SqlDbType.BigInt
                    param_IdGasto.Value = txtIdGasto.Text
                    param_IdGasto.Direction = ParameterDirection.Input

                    Dim param_CodigoImpuesto As New SqlClient.SqlParameter
                    param_CodigoImpuesto.ParameterName = "@CodigoImpuesto"
                    param_CodigoImpuesto.SqlDbType = SqlDbType.NVarChar
                    param_CodigoImpuesto.Size = 50
                    param_CodigoImpuesto.Value = grdImpuestos.Rows(i).Cells(ColumnasDelGridImpuestos.codigo).Value
                    param_CodigoImpuesto.Direction = ParameterDirection.Input

                    Dim param_NroDocumento As New SqlClient.SqlParameter
                    param_NroDocumento.ParameterName = "@NroDocumento"
                    param_NroDocumento.SqlDbType = SqlDbType.NVarChar
                    param_NroDocumento.Size = 30
                    param_NroDocumento.Value = LTrim(RTrim(grdImpuestos.Rows(i).Cells(ColumnasDelGridImpuestos.NroDocumento).Value))
                    param_NroDocumento.Direction = ParameterDirection.Input

                    Dim param_Monto As New SqlClient.SqlParameter
                    param_Monto.ParameterName = "@Monto"
                    param_Monto.SqlDbType = SqlDbType.Decimal
                    param_Monto.Precision = 18
                    param_Monto.Scale = 2
                    param_Monto.Value = grdImpuestos.Rows(i).Cells(ColumnasDelGridImpuestos.Monto).Value
                    param_Monto.Direction = ParameterDirection.Input

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

                            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spGastos_Impuestos_Insert",
                                param_IdGasto, param_CodigoImpuesto, param_NroDocumento,
                                 param_Monto, param_res)

                            res = param_res.Value

                        Else

                            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spGastos_Impuestos_Update",
                                 param_Id, param_NroDocumento, param_Monto, param_MENSAJE, param_res)

                            'MsgBox(param_MENSAJE.Value)

                            res = param_res.Value

                        End If

                        If res < 0 Then
                            AgregarRegistro_Impuestos = -1
                            Exit Function
                        End If

                    Catch ex As Exception
                        Throw ex
                        AgregarRegistro_Impuestos = -1
                        Exit Function
                    End Try

                Next

                AgregarRegistro_Impuestos = 1
            Finally

            End Try
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
    End Function

    Private Function EliminarRegistro_Recepcion() As Integer
        Dim res As Integer = 0
        Dim msg As String
        Try
            Try
                conn_del_form = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End Try

            'Abrir una transaccion para guardar y asegurar que se guarda todo
            If Abrir_Tran(conn_del_form) = False Then
                MessageBox.Show("No se pudo abrir una transaccion", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If

            Try

                Dim param_idRecepcion As New SqlClient.SqlParameter("@id", SqlDbType.BigInt, ParameterDirection.Input)
                param_idRecepcion.Value = CType(txtID.Text, Long)
                param_idRecepcion.Direction = ParameterDirection.Input

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

                Dim param_msg As New SqlClient.SqlParameter
                param_msg.ParameterName = "@mensaje"
                param_msg.SqlDbType = SqlDbType.VarChar
                param_msg.Size = 250
                param_msg.Value = DBNull.Value
                param_msg.Direction = ParameterDirection.Output

                Try

                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spRecepciones_Delete_All", param_idRecepcion, param_userdel, param_res, param_msg)
                    res = param_res.Value

                    If Not (param_msg.Value Is System.DBNull.Value) Then
                        msg = param_msg.Value
                    Else
                        msg = ""
                    End If

                    EliminarRegistro_Recepcion = res

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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Function

    Private Function EliminarRegistro_Gasto() As Integer
        Dim res As Integer = 0

        Try

            Dim param_idGasto As New SqlClient.SqlParameter("@id", SqlDbType.BigInt, ParameterDirection.Input)
            param_idGasto.Value = CType(txtIdGasto.Text, Long)
            param_idGasto.Direction = ParameterDirection.Input

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

                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spGastos_Delete",
                                          param_idGasto, param_userdel, param_res)

                EliminarRegistro_Gasto = param_res.Value

            Catch ex As Exception
                '' 
                Throw ex
            End Try
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

    End Function

    Private Function AgregarActualizar_Registro_Items_IVA() As Integer
        Dim res As Integer = 0 ', res_del As Integer
        Dim i As Integer

        Try

            Try

                For i = 0 To 2

                    Dim param_idGasto As New SqlClient.SqlParameter
                    param_idGasto.ParameterName = "@idgasto"
                    param_idGasto.SqlDbType = SqlDbType.BigInt
                    param_idGasto.Value = txtIdGasto.Text
                    param_idGasto.Direction = ParameterDirection.Input

                    Dim param_subtotal As New SqlClient.SqlParameter
                    param_subtotal.ParameterName = "@subtotal"
                    param_subtotal.SqlDbType = SqlDbType.Decimal
                    param_subtotal.Precision = 18
                    param_subtotal.Scale = 2
                    Select Case i
                        Case 0
                            ' param_subtotal.Value = CDbl(txtMontoIVA10.Text) / 0.105
                        Case 1
                            'param_subtotal.Value = CDbl(txtMontoIVA21.Text) / 0.21
                        Case 2
                            'param_subtotal.Value = CDbl(txtMontoIVA27.Text) / 0.27
                    End Select
                    param_subtotal.Direction = ParameterDirection.Input

                    Dim param_PorcIva As New SqlClient.SqlParameter
                    param_PorcIva.ParameterName = "@PorcIva"
                    param_PorcIva.SqlDbType = SqlDbType.Decimal
                    param_PorcIva.Precision = 18
                    param_PorcIva.Scale = 2
                    Select Case i
                        Case 0
                            param_PorcIva.Value = 10.5
                        Case 1
                            param_PorcIva.Value = 21
                        Case 2
                            param_PorcIva.Value = 27
                    End Select
                    param_PorcIva.Direction = ParameterDirection.Input

                    Dim param_MontoIva As New SqlClient.SqlParameter
                    param_MontoIva.ParameterName = "@MontoIva"
                    param_MontoIva.SqlDbType = SqlDbType.Decimal
                    param_MontoIva.Precision = 18
                    param_MontoIva.Scale = 2
                    Select Case i
                        Case 0
                            'param_MontoIva.Value = CDbl(txtMontoIVA10.Text)
                        Case 1
                            'param_MontoIva.Value = CDbl(txtMontoIVA21.Text)
                        Case 2
                            'param_MontoIva.Value = CDbl(txtMontoIVA27.Text)
                    End Select
                    param_MontoIva.Direction = ParameterDirection.Input

                    Dim param_res As New SqlClient.SqlParameter
                    param_res.ParameterName = "@res"
                    param_res.SqlDbType = SqlDbType.Int
                    param_res.Value = DBNull.Value
                    param_res.Direction = ParameterDirection.InputOutput

                    Try
                        If bolModo = True Then
                            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spGastos_Det_Insert",
                                                 param_idGasto, param_subtotal, param_PorcIva, param_MontoIva,
                                                 param_res)
                        Else
                            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spGastos_Det_Update",
                                                 param_idGasto, param_PorcIva, param_MontoIva,
                                                 param_res)
                        End If

                        res = param_res.Value

                        If res < 0 Then
                            Exit For
                        End If

                    Catch ex As Exception
                        Throw ex
                    End Try

                Next

                AgregarActualizar_Registro_Items_IVA = res

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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function EliminarItems_Gastos_Det() As Integer
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            Dim param_idGasto As New SqlClient.SqlParameter
            param_idGasto.ParameterName = "@idGasto"
            param_idGasto.SqlDbType = SqlDbType.BigInt
            param_idGasto.Value = CLng(txtIdGasto.Text)
            param_idGasto.Direction = ParameterDirection.Input

            Dim param_res As New SqlClient.SqlParameter
            param_res.ParameterName = "@Res"
            param_res.SqlDbType = SqlDbType.Int
            param_res.Value = DBNull.Value
            param_res.Direction = ParameterDirection.InputOutput

            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spGastos_Det_Delete",
                                        param_idGasto, param_res)

            EliminarItems_Gastos_Det = param_res.Value

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
            'Finally
            '    If Not connection Is Nothing Then
            '        CType(connection, IDisposable).Dispose()
            '    End If
        End Try
    End Function

    Private Function fila_vacia(ByVal i) As Boolean
        If (grdItems.Rows(i).Cells(ColumnasDelGridItems1.IDMaterial).Value Is System.DBNull.Value Or grdItems.Rows(i).Cells(ColumnasDelGridItems1.IDMaterial).Value Is Nothing) _
                    And (grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtyRecep).Value Is System.DBNull.Value Or grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtyRecep).Value Is Nothing) _
                    And (grdItems.Rows(i).Cells(ColumnasDelGridItems1.IdUnidad).Value Is System.DBNull.Value Or grdItems.Rows(i).Cells(ColumnasDelGridItems1.IdUnidad).Value Is Nothing) Then
            fila_vacia = True
        Else
            fila_vacia = False
        End If
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

        ' Si la tecla presionada es distinta de la tecla Enter,
        ' abandonamos el procedimiento.
        '
        If keyData <> Keys.Return Then Return MyBase.ProcessCmdKey(msg, keyData)

        ' Igualmente, si el control DataGridView no tiene el foco,
        ' y si la celda actual no está siendo editada,
        ' abandonamos el procedimiento.
        If (Not grdItems.Focused) AndAlso (Not grdItems.IsCurrentCellInEditMode) Then Return MyBase.ProcessCmdKey(msg, keyData)

        ' Obtenemos la celda actual
        Dim cell As DataGridViewCell = grdItems.CurrentCell
        ' Índice de la columna.
        Dim columnIndex As Int32 = cell.ColumnIndex
        ' Índice de la fila.
        Dim rowIndex As Int32 = cell.RowIndex

        Do
            If columnIndex = grdItems.Columns.Count - 1 Then
                If rowIndex = grdItems.Rows.Count - 1 Then
                    ' Seleccionamos la primera columna de la primera fila.
                    cell = grdItems.Rows(0).Cells(ColumnasDelGridItems1.IDRecepcion_Det)
                Else
                    ' Selecionamos la primera columna de la siguiente fila.
                    cell = grdItems.Rows(rowIndex + 1).Cells(ColumnasDelGridItems1.IDRecepcion_Det)
                End If
            Else
                ' Seleccionamos la celda de la derecha de la celda actual.
                cell = grdItems.Rows(rowIndex).Cells(columnIndex + 1)
            End If

            ' establecer la fila y la columna actual
            columnIndex = cell.ColumnIndex
            rowIndex = cell.RowIndex
        Loop While (cell.Visible = False)

        Try
            grdItems.CurrentCell = cell
        Catch ex As Exception

        End Try

        ' ... y la ponemos en modo de edición.
        grdItems.BeginEdit(True)
        Return True

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

        param.AgregarParametros("Recepción Nro.:", "STRING", "", False, txtCODIGOunused.Text.ToString, "", Cnn)

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

        'chkAnulados.Enabled = Not bolModo
        grd_CurrentCellChanged(sender, e)

        LlenarGrid_IVA(CType(txtIdGasto.Text, Long))



        LlenarGrid_Impuestos()

    End Sub

    Private Sub btnRecibirTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If MessageBox.Show("Está seguro que desea copiar los valores de la columna Cant. Saldo y Precio Pedido a las columnas Cant. Recepc y Precio Real?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        If MessageBox.Show("Está seguro que desea copiar los valores de la columna Cant. Saldo a la columna Cant. Recepc?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim i As Integer

            For i = 0 To grdItems.RowCount - 1
                grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtyRecep).Value = grdItems.Rows(i).Cells(ColumnasDelGridItems1.QtySaldo).Value
                'grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioReal).Value = grdItems.Rows(i).Cells(ColumnasDelGridItems1.PrecioPedido).Value
            Next

        End If
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

    Private Sub grdItems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        editando_celda = False

        Try

            If e.ColumnIndex = ColumnasDelGridItems1.CodUnidad Then
                Dim cell As DataGridViewCell = grdItems.CurrentCell
                Dim cod_unidad As String, nombre As String = "", codunidad As String = ""
                Dim idunidad As Long

                cod_unidad = grdItems.Rows(cell.RowIndex).Cells(cell.ColumnIndex).Value

                cell = grdItems.Rows(cell.RowIndex).Cells(cell.ColumnIndex + 1)
                If ObtenerUnidad_App(cod_unidad, idunidad, nombre, codunidad, ConnStringSEI) = 0 Then
                    cell.Value = nombre
                    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.IdUnidad).Value = idunidad
                    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.CodUnidad).Value = codunidad
                    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Unidad).Value = nombre

                    SendKeys.Send("{TAB}")

                Else
                    cell.Value = "NO EXISTE"
                End If

            End If

            If e.ColumnIndex = ColumnasDelGridItems1.CodMoneda Then
                Dim cell As DataGridViewCell = grdItems.CurrentCell
                Dim cod_moneda As String, nombre As String = "", codmoneda As String = ""
                Dim idmoneda As Long
                Dim valorcambio As Double

                cod_moneda = grdItems.Rows(cell.RowIndex).Cells(cell.ColumnIndex).Value

                cell = grdItems.Rows(cell.RowIndex).Cells(cell.ColumnIndex + 1)
                If ObtenerMoneda_App(cod_moneda, idmoneda, nombre, codmoneda, valorcambio, ConnStringSEI) = 0 Then
                    cell.Value = nombre
                    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.IdMoneda).Value = idmoneda
                    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.CodMoneda).Value = codmoneda
                    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Moneda).Value = nombre
                    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.ValorCambio).Value = valorcambio

                    SendKeys.Send("{TAB}")

                Else
                    cell.Value = "NO EXISTE"
                End If

            End If

            If e.ColumnIndex = ColumnasDelGridItems1.Bonif1 Or e.ColumnIndex = ColumnasDelGridItems1.Bonif2 Or
                e.ColumnIndex = ColumnasDelGridItems1.Bonif3 Or e.ColumnIndex = ColumnasDelGridItems1.Bonif4 Or
                e.ColumnIndex = ColumnasDelGridItems1.Bonif5 Or
                e.ColumnIndex = ColumnasDelGridItems1.Ganancia Or
                e.ColumnIndex = ColumnasDelGridItems1.PrecioListaReal Then

                Dim Bonif1 As Double, Bonif2 As Double, Bonif3 As Double, Bonif4 As Double, Bonif5 As Double
                Dim preciolista As Double
                Dim preciobonif1 As Double = 0, preciobonif2 As Double = 0, preciobonif3 As Double = 0, preciobonif4 As Double = 0, preciobonif5 As Double = 0
                Dim preciosinivabonif As Double = 0

                Dim Ganancia As Double
                Dim cell As DataGridViewCell = grdItems.CurrentCell

                If grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif1).Value Is DBNull.Value Then
                    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif1).Value = 0
                End If

                If grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif2).Value Is DBNull.Value Then
                    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif2).Value = 0
                End If

                If grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif3).Value Is DBNull.Value Then
                    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif3).Value = 0
                End If

                If grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif4).Value Is DBNull.Value Then
                    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif4).Value = 0
                End If

                If grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif5).Value Is DBNull.Value Then
                    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif5).Value = 0
                End If

                Ganancia = 1 + (CType(IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Ganancia).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Ganancia).Value), Double)) / 100

                'precioxmt = IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioxMt).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioxMt).Value)
                'precioxkg = IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioxKg).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioxKg).Value)
                'cantxlongitud = IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.CantxLongitud).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.CantxLongitud).Value)
                'pesoxunidad = IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PesoxUnidad).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PesoxUnidad).Value)

                'If precioxkg = 0 And cantxlongitud = 0 And pesoxunidad = 0 And precioxmt = 0 Then

                '    Bonif1 = 1 + (CType(IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif1).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif1).Value), Double)) / 100
                '    Bonif2 = 1 + (CType(IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif2).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif2).Value), Double)) / 100
                '    Bonif3 = 1 + (CType(IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif3).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif3).Value), Double)) / 100
                '    Bonif4 = 1 + (CType(IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif4).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif4).Value), Double)) / 100
                '    Bonif5 = 1 + (CType(IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif5).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif5).Value), Double)) / 100

                'Else

                '    Bonif1 = 1 + (CType(IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif1).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif1).Value), Double)) / 100
                '    Bonif2 = 1 + (CType(IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif2).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif2).Value), Double)) / 100
                '    Bonif3 = 1 + (CType(IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif3).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif3).Value), Double)) / 100
                '    Bonif4 = 1 + (CType(IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif4).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif4).Value), Double)) / 100
                '    Bonif5 = 1 + (CType(IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif5).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif5).Value), Double)) / 100

                '    Dim CalcPesoxUnidad As Double = 0, Calcprecioxunidad As Double = 0, Calcprecioxkg As Double = 0, CalcPrecioxMt As Double = 0

                '    If precioxkg <> 0 Then
                '        Calcprecioxkg = IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioxKg).Value = Nothing, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioxKg).Value)
                '        preciobonif1 = precioxkg / Bonif1
                '    Else
                '        CalcPrecioxMt = IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioxMt).Value = Nothing, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioxMt).Value)
                '        preciobonif1 = precioxmt / Bonif1
                '    End If

                '    'MsgBox(preciobonif1)

                '    preciobonif1 = preciobonif1 / Bonif2
                '    preciobonif1 = preciobonif1 / Bonif3
                '    preciobonif1 = preciobonif1 / Bonif4
                '    preciobonif1 = preciobonif1 / Bonif5

                '    If grdItems.CurrentRow.Cells(ColumnasDelGridItems1.IVA).Value Is DBNull.Value Then
                '        grdItems.CurrentRow.Cells(ColumnasDelGridItems1.IVA).Value = 0
                '    End If

                '    preciosinivabonif = preciobonif1 / (1 + (grdItems.CurrentRow.Cells(ColumnasDelGridItems1.IVA).Value / 100))

                '    'MsgBox(preciobonif1)

                '    'MsgBox(preciosinivabonif)

                '    If precioxkg <> 0 Then
                '        Calcprecioxunidad = preciosinivabonif * IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PesoxUnidad).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PesoxUnidad).Value)
                '    Else
                '        Calcprecioxunidad = preciosinivabonif * IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioxMt).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.CantxLongitud).Value)
                '    End If

                '    'MsgBox(Calcprecioxunidad)

                '    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioLista).Value = Math.Round(Calcprecioxunidad, 2)

                '    'grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioReal).Value = Math.Round(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioLista).Value * Ganancia, 2)

                '    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioEnPesosNuevo).Value = Math.Round((Math.Round(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioLista).Value * Ganancia, 2)) * grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.ValorCambio).Value, 2)

                '    Exit Sub
                'End If

                Bonif1 = 1 - (CType(IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif1).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif1).Value), Double)) / 100
                Bonif2 = 1 - (CType(IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif2).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif2).Value), Double)) / 100
                Bonif3 = 1 - (CType(IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif3).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif3).Value), Double)) / 100
                Bonif4 = 1 - (CType(IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif4).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif4).Value), Double)) / 100
                Bonif5 = 1 - (CType(IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif5).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.Bonif5).Value), Double)) / 100


                preciolista = IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioCosto).Value Is DBNull.Value, 0, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioCosto).Value)

                preciobonif1 = preciolista * Bonif1
                preciobonif1 = preciobonif1 * Bonif2
                preciobonif1 = preciobonif1 * Bonif3
                preciobonif1 = preciobonif1 * Bonif4
                preciobonif1 = preciobonif1 * Bonif5

                If grdItems.CurrentRow.Cells(ColumnasDelGridItems1.IVA).Value Is DBNull.Value Then
                    grdItems.CurrentRow.Cells(ColumnasDelGridItems1.IVA).Value = 0
                End If

                preciosinivabonif = preciobonif1 ' / (1 + (grdItems.CurrentRow.Cells(ColumnasDelGridItems1.IVA).Value / 100))

                'grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioReal).Value = Math.Round(preciosinivabonif * Ganancia, 2)

                grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioEnPesosNuevo).Value = Math.Round((Math.Round(preciosinivabonif * Ganancia, 2)) * grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.ValorCambio).Value, 2)

                If grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioLista).Value <> grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioListaReal).Value Then
                    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PorcDif).Value = Format(100 - Format(CDbl(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioLista).Value * 100 / grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PrecioListaReal).Value), "###0.00"), "###0.00")
                Else
                    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PorcDif).Value = 0
                End If

                If grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PorcDif).Value <> 0 Then
                    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PorcDif).Style.BackColor = Color.Red
                Else
                    grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems1.PorcDif).Style.BackColor = Color.White
                End If

            End If

        Catch ex As Exception
            MsgBox("error en Sub grdItems_CellEndEdit", MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

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
