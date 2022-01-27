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

    Enum GrdColumns
        ID = 0
        Codigo = 1
        IdPresentacion = 2
        PresentacionCodigo = 3
        ObraSocial = 4
        Periodo = 5
        TipoPago = 6
        Liquidado = 7
        Estado = 8
        Fecha_presentacion = 9
        Fecha_creacion = 10
        Fecha_liquidacion = 11
        Observacion = 12
        total = 13
        Agrupado = 14
    End Enum

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

        'lblTotal.Visible = False
        lblcmbObrasSociales.Visible = True
        Cursor = Cursors.WaitCursor

        ToolStrip_lblCodMaterial.Visible = True
        txtBusquedaMAT.Visible = True

        'With grdDetalleLiquidacion
        '    .VirtualMode = False
        '    .EnableHeadersVisualStyles = False
        '    .ColumnHeadersBorderStyle = 1
        '    .AllowUserToAddRows = False
        '    .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
        '    .RowsDefaultCellStyle.BackColor = Color.White
        '    .AllowUserToOrderColumns = False
        '    '.SelectionMode = DataGridViewSelectionMode.CellSelect
        '    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        'End With

        'With grdDetalleLiquidacion.ColumnHeadersDefaultCellStyle
        '    .BackColor = Color.LightBlue  'Color.BlueViolet
        '    .ForeColor = Color.Black
        '    .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        'End With

        'grdDetalleLiquidacion.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Regular)

        'With grdDetalleLiquidacionFiltrada
        '    .VirtualMode = False
        '    .AllowUserToAddRows = False
        '    .EnableHeadersVisualStyles = False
        '    .ColumnHeadersBorderStyle = 1
        '    .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
        '    .RowsDefaultCellStyle.BackColor = Color.White
        '    .AllowUserToOrderColumns = False
        '    '.SelectionMode = DataGridViewSelectionMode.CellSelect
        '    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        'End With

        'With grdDetalleLiquidacionFiltrada.ColumnHeadersDefaultCellStyle
        '    .BackColor = Color.LightBlue  'Color.BlueViolet
        '    .ForeColor = Color.Black
        '    .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        'End With

        ''Agrego tipos de pago al combobox
        Dim dtTipoPago As New DataTable
        With dtTipoPago
            .Columns.Add("DisplayMember")
            .Columns.Add("ValueMember")

            Dim row1 As DataRow = .NewRow()
            row1("DisplayMember") = "Final"
            row1("ValueMember") = "FINAL"
            .Rows.Add(row1)

            Dim row2 As DataRow = .NewRow()
            row2("DisplayMember") = "Parcial"
            row2("ValueMember") = "PARCIAL"
            .Rows.Add(row2)
        End With

        With cmbTipoPago
            .DataSource = dtTipoPago
            .DisplayMember = "DisplayMember"
            .ValueMember = "ValueMember"
        End With


        band = 0
        'Modifico botones del frmbase
        btnEliminar.Text = "Cancelar Liquidación"
        btnEliminar.Enabled = False
        ToolStrip_lblCodMaterial.Text = "Cod. Liq."
        'btnCancelar.Visible = False
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

        'IdObraSocial = cmbObraSocial.SelectedValue

        'SQL = $"exec spPresentaciones_Select_All @Pendientes = {rdPendientes.Checked} ,@Eliminado = {rdAnuladas.Checked} ,@Todos = {rdTodasOC.Checked}"
        SQL = $"exec spLiquidaciones_Select_All"
        LlenarGrilla()

        Permitir = True
        CargarCajas()
        PrepararBotones()
        btnEliminar.Enabled = Not chkLiquidado.Checked


        With grd
            ''autosize mode
            .AutoSizeColumnsMode = .AutoSizeColumnsMode.Fill

            ''Hide not needed columns from grd
            .Columns(GrdColumns.IdPresentacion).Visible = False
            .Columns(GrdColumns.PresentacionCodigo).Visible = False
            .Columns(GrdColumns.Agrupado).Visible = False
            .Columns(GrdColumns.Liquidado).Visible = False
            '.Columns(GrdColumns.Fecha_creacion).Visible = False

            ''resize some columns
            .Columns(GrdColumns.Codigo).Width = 80
            .Columns(GrdColumns.Fecha_presentacion).Width = 180

            .Columns(GrdColumns.Fecha_presentacion).DefaultCellStyle.Alignment =
                .Columns(GrdColumns.Fecha_presentacion).DefaultCellStyle.Alignment.MiddleCenter

            .Columns(GrdColumns.Fecha_liquidacion).Width = 180

            .Columns(GrdColumns.Fecha_liquidacion).DefaultCellStyle.Alignment =
                .Columns(GrdColumns.Fecha_liquidacion).DefaultCellStyle.Alignment.MiddleCenter

            .Columns(GrdColumns.Fecha_liquidacion).Width = 180
            .Columns(GrdColumns.Estado).Width = 120
            .Columns(GrdColumns.total).Width = 120
        End With

        If bolModo = True Then
            band = 1
            btnNuevo_Click(sender, e)
        Else
            btnCargarPresentacion.Enabled = False
        End If

        permitir_evento_CellChanged = True

        Contar_Filas()

        'dtpFECHA.MaxDate = Today.Date

        band = 1

        Cursor = Cursors.Default

    End Sub

    Private Sub txtID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtID.TextChanged
        If txtID.Text <> "" And bolModo = False Then
            Presentacion_request(
                "exec spLiquidaciones_Det_Select_By_IDLiquidacion @IDLiquidacion = " & txtID.Text & "",
                "exec spLiquidaciones_det_Conceptos_Select_By_IDLiquidacion @IDLiquidacion = " & txtID.Text & ""
            )
        End If
    End Sub

    Private Sub grdItems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        editando_celda = True
    End Sub

    Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub dtpfecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub grditems_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Cell_X = e.ColumnIndex
        Cell_Y = e.RowIndex
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

    Private Sub txtsubtotalNoGravado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub chkGrillaInferior_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGrillaInferior.CheckedChanged
        Dim xgrd As Long, ygrd As Long, hgrd As Long, variableajuste As Long
        xgrd = grd.Location.X
        ygrd = grd.Location.Y
        hgrd = grd.Height

        variableajuste = 125

        If chkGrillaInferior.Checked = True Then
            chkGrillaInferior.Text = "Disminuir Grilla Inferior"
            chkGrillaInferior.Location = New Point(chkGrillaInferior.Location.X, chkGrillaInferior.Location.Y - variableajuste)
            GroupBox1.Height = GroupBox1.Height - variableajuste
            grd.Location = New Point(xgrd, ygrd - variableajuste)
            grd.Height = hgrd + variableajuste
            Label19.Location = New Point(Label19.Location.X, Label19.Location.Y - variableajuste)
            lblCantLiq.Location = New Point(lblCantLiq.Location.X, lblCantLiq.Location.Y - variableajuste)

        Else
            chkGrillaInferior.Text = "Aumentar Grilla Inferior"
            chkGrillaInferior.Location = New Point(chkGrillaInferior.Location.X, chkGrillaInferior.Location.Y + variableajuste)
            GroupBox1.Height = GroupBox1.Height + variableajuste
            grd.Location = New Point(xgrd, ygrd + variableajuste)
            grd.Height = hgrd - variableajuste
            Label19.Location = New Point(Label19.Location.X, Label19.Location.Y + variableajuste)
            lblCantLiq.Location = New Point(lblCantLiq.Location.X, lblCantLiq.Location.Y + variableajuste)

        End If

    End Sub


#End Region

#Region "   Procedimientos"

    Dim MasterGrdDetail As Boolean = False
    Dim gl_dataset As DataSet
    Friend Sub Presentacion_request(sqlDetalle As String, sqlConceptos As String)
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim sql_items As String
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
            If sqlDetalle IsNot Nothing Then
                sql_items = sqlDetalle

                Dim cmd As New SqlCommand(sql_items, connection)
                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dtDetalle)
            End If

            ''Conceptos de liquidacion
            If sqlConceptos IsNot Nothing Then
                sql_items = sqlConceptos

                Dim cmd_conceptos As New SqlCommand(sql_items, connection)
                Dim da_conceptos As New SqlDataAdapter(cmd_conceptos)

                da_conceptos.Fill(dtConcepto)
            Else
                dtConcepto.Columns.Add("ID", GetType(Long))
                dtConcepto.Columns.Add("IdDetalle", GetType(Long))
                dtConcepto.Columns.Add("IdFarmacia", GetType(String))
                dtConcepto.Columns.Add("detalle", GetType(String))
                dtConcepto.Columns.Add("valor", GetType(Decimal))
                dtConcepto.Columns.Add("estado", GetType(String))
                dtConcepto.Columns.Add("edit")
            End If


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

        ''Chequeo que el tipo de dato sea decimal
        'Try
        '    dtDetalle.Columns("A Cargo OS A").DataType = GetType(Decimal)
        'Catch ex As Exception
        '    MsgBox(ex)
        'End Try

        gl_dataset.Tables.Add(dtDetalle)

        'dtConcepto.Columns.Add("ID", GetType(Long))
        'dtConcepto.Columns.Add("IdDetalle", GetType(Long))
        'dtConcepto.Columns.Add("IdFarmacia", GetType(String))
        'dtConcepto.Columns.Add("detalle", GetType(String))
        'dtConcepto.Columns.Add("valor", GetType(Decimal))
        'dtConcepto.Columns.Add("edit")

        dtConcepto.PrimaryKey = {
                dtConcepto.Columns("IdDetalle"),
                dtConcepto.Columns("detalle")
        }

        'If Not dtConcepto.Rows.Count > 0 Then
        '    For Each row As DataRow In dtDetalle.Rows()
        '        Dim concepto As DataRow = dtConcepto.NewRow()
        '        concepto("IdDetalle") = row("ID")
        '        concepto("IdFarmacia") = row("IdFarmacia")
        '        concepto("detalle") = "A Cargo OS"
        '        concepto("valor") = Decimal.Parse(row("A Cargo OS"))
        '        concepto("estado") = "insert"
        '        dtConcepto.Rows.Add(concepto)
        '    Next
        'End If

        gl_dataset.Tables.Add(dtConcepto)

        gl_dataset.Relations.Add("MasterGridDetail",
                      gl_dataset.Tables(0).Columns("nº"),
                      gl_dataset.Tables(1).Columns("IdDetalle")
        )

        SuperGrdResultado.PrimaryGrid.DataSource = gl_dataset

        ''Una vez todo preparado actualizo la grilla principal
        UpdateGrdPrincipal()

    End Sub

    ''Esta funcion actualiza y autocalcula valores importantes de la grilla
    Friend Sub UpdateGrdPrincipal()

        ''GRID PRINCIPAL
        Dim i As Integer
        'If MasterGrdDetail Then
        '    If gl_dataset.Tables(0).Columns("Recetas A") Is Nothing Then
        '        gl_dataset.Tables(0).Columns.Add("Recetas A")
        '        gl_dataset.Tables(0).Columns.Add("Recaudado A")
        '        gl_dataset.Tables(0).Columns.Add("A Cargo OS A")
        '    End If

        '    Dim row As DataRow
        '    For i = 0 To grdDetalleLiquidacionFiltrada.Rows.Count - 1
        '        row = gl_dataset.Tables(0).Rows.Find(grdDetalleLiquidacionFiltrada.Rows(i).Cells("IdDetalle").Value)
        '        If row IsNot Nothing Then 'If a row is found
        '            With row
        '                .Item("Recetas A") = grdDetalleLiquidacionFiltrada.Rows(i).Cells("Recetas").Value
        '                .Item("Recaudado A") = grdDetalleLiquidacionFiltrada.Rows(i).Cells("Recaudado").Value
        '                .Item("A Cargo OS A") = grdDetalleLiquidacionFiltrada.Rows(i).Cells("A Cargo OS").Value
        '            End With
        '        End If
        '    Next
        'End If

        If gl_dataset.Tables(0).Columns("Subtotal") Is Nothing Then
            gl_dataset.Tables(0).Columns.Add("Subtotal", GetType(Decimal))

            AddHandler gl_dataset.Tables(0).ColumnChanged, AddressOf CalcularTotales
        End If

        'Calculo de subtotalMasterGridDetail
        Dim ajusteExists As Boolean = False
        Dim valorInicial As Decimal = 0.00
        For Each row As DataRow In gl_dataset.Tables(0).Rows
            Dim childrows = row.GetChildRows(gl_dataset.Relations(0))
            For Each detail As DataRow In childrows
                If detail("detalle") = "Error ajuste" Then
                    ajusteExists = True
                End If
            Next

            If ajusteExists Or row("A Cargo OS A") Is DBNull.Value Then
                Dim pagado = IIf(row("A Cargo OS P") Is DBNull.Value, 0, row("A Cargo OS P"))
                valorInicial = row("A Cargo OS") - pagado
            Else
                valorInicial = row("A Cargo OS A")
            End If

            row("Subtotal") = valorInicial

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
        Dim Recaudado As Decimal = 0
        Dim ACargoOS As Decimal = 0
        Dim ACargoOS_A As Decimal = 0
        Dim ACargoOS_P As Decimal = 0
        Dim Total As Decimal = 0
        Dim Transferencia As Decimal = 0

        With gl_dataset.Tables(0)
            If .Rows.Count > 0 Then
                For i = 0 To gl_dataset.Tables(0).Rows.Count - 1
                    If .Rows(i)("Subtotal") IsNot DBNull.Value Then
                        Total += .Rows(i)("Subtotal")
                    End If

                    If .Rows(i)("A Cargo OS") IsNot DBNull.Value Then
                        ACargoOS += .Rows(i)("A Cargo OS")
                    End If

                    If .Rows(i)("A Cargo OS A") IsNot DBNull.Value Then
                        ACargoOS_A += .Rows(i)("A Cargo OS A")
                    End If

                    If .Rows(i)("A Cargo OS P") IsNot DBNull.Value Then
                        ACargoOS_P += .Rows(i)("A Cargo OS P")
                    End If

                Next
            End If
        End With

        With gl_dataset.Tables(1)
            Transferencia = Total
            If .Rows.Count > 0 Then
                For Each concepto As DataRow In gl_dataset.Tables(1).Rows
                    If concepto("detalle") = "Impuesto cheque" Or
                       concepto("detalle") = "Comisión centro" Or
                       concepto("detalle") = "Ingresos Brutos" Then

                        Transferencia -= concepto("valor")

                    End If
                Next
            End If
        End With

        'If (ACargoOS <= ACargoOS_A + ACargoOS_P Or ACargoOS <= ACargoOS_A + Total) And
        '    cmbTipoPago.Text = "Parcial" And
        '    chkLiquidado.Checked = False Then

        '    MsgBox("Los importes presentados y aceptados son iguales, se configurará la liquidación como pago final")
        '    cmbTipoPago.SelectedValue = "FINAL"
        '    UpdateGrdPrincipal()
        'End If

        lblTotal.Text = "$ " + String.Format("{0:N2}", Total)
        lblTransferencia.Text = "$ " + String.Format("{0:N2}", Transferencia)
        lblCantidadItems.Text = gl_dataset.Tables(0).Rows.Count
    End Sub

    Private Sub btnExcelWindow_Click(sender As Object, e As EventArgs) Handles btnExcelWindow.Click
        Dim ImportExcel As New frmImportarExcel(txtIdPresentacion.Text)
        ImportExcel.ShowDialog()
    End Sub

    Friend Sub addAceptadosFromExcel(dtAceptados As DataTable)
        Dim currentDetalle As DataRow
        Dim currentConcepto As DataRow
        For Each item As DataRow In dtAceptados.Rows
            Dim collection = gl_dataset.Tables(0).Select($"IdFarmacia = '{item("IdFarmacia")}'")
            If collection.Length > 0 Then
                currentDetalle = collection(0)

                collection = gl_dataset.Tables(1).Select($"IdDetalle = '{currentDetalle("nº")}' and detalle = 'A Cargo OS'")

                If collection.Length > 0 Then
                    currentConcepto = collection(0)
                End If
            End If


            'Dim currentConcepto = gl_dataset.Tables(1).Select($"IdDetalle = '{item("IdDetalle")}' and detalle = 'A Cargo OS'")
            ''nacho
            If currentDetalle IsNot Nothing Then 'If currentDetalle Is DBNull.Value Then
                currentDetalle("Recetas A") = item("Recetas")
                currentDetalle("Recaudado A") = item("Recaudado")
                currentDetalle("A Cargo OS A") = item("A Cargo OS")


                ''Genero el concepto que contempla diferencia entre aceptado y presentado
                If cmbTipoPago.Text = "Final" Then
                    If currentDetalle("A Cargo OS A") IsNot DBNull.Value Then
                        Dim row As DataRow = gl_dataset.Tables(1).NewRow()
                        Dim pagado = IIf(currentDetalle("A Cargo OS P") IsNot DBNull.Value, currentDetalle("A Cargo OS P"), 0)
                        row("IdDetalle") = currentDetalle("nº")
                        row("IdFarmacia") = item("IdFarmacia")
                        row("detalle") = "Error ajuste"
                        row("valor") = currentDetalle("A Cargo OS A") - (currentDetalle("A Cargo OS") - pagado)
                        row("edit") = False

                        If row("valor") <> 0 Then
                            añadirConcepto(row)
                        End If
                    End If
                End If
            End If
            ''nacho 
            If currentConcepto IsNot Nothing Then ' If currentConcepto Is DBNull.Value Then
                'currentConcepto("valor") = item("A Cargo OS")
                'currentConcepto("estado") = "update"
            End If


        Next
    End Sub

    Friend Sub addConceptosFromExcel(dtConceptos As DataTable)

        For Each item As DataRow In dtConceptos.Rows
            Dim currentDetalle = gl_dataset.Tables(0).Select($"IdFarmacia = '{item("IdFarmacia")}'")(0)
            item("IdDetalle") = currentDetalle("nº")
            añadirConcepto(item)
        Next
    End Sub


    Private Sub CalcularDetalleSuperGrd(datasetLiquidacion As DataSet)
        If DataBindingComplete = True Then
            'SuperGrdResultado.PrimaryGrid.Footer.Text = "Prueba"
            'SuperGrdResultado.PrimaryGrid.GetParentPanel().Footer.Text = "prueba"
            'SuperGrdResultado.PrimaryGrid.GridPanel.GetParentPanel.Footer.Text = "prueba"


        End If
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

        Me.Text = "Liquidación"

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
        lblPeriodo_presentacion.Tag = "5"
        cmbTipoPago.Tag = "6"
        chkLiquidado.Tag = "7"
        lblStatus.Tag = "8"
        lblFecha_presentacion.Tag = "9"
        lblFecha_creacion.Tag = "10"
        lblFecha_liquidado.Tag = "11"
        lblObservacion.Tag = "12"
        chkAgrupado.Tag = "14"

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
        lblCantLiq.Text = grd.Rows.Count
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
            GuardarLiquidacion = -1
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

            ''TipoPago
            Dim param_TipoPago As New SqlClient.SqlParameter
            param_TipoPago.ParameterName = "@tipoPago"
            param_TipoPago.SqlDbType = SqlDbType.VarChar
            param_TipoPago.Value = cmbTipoPago.SelectedValue.ToString
            param_TipoPago.Direction = ParameterDirection.Input

            '''fecha
            'Dim param_fecha As New SqlClient.SqlParameter
            'param_fecha.ParameterName = "@fecha"
            'param_fecha.SqlDbType = SqlDbType.DateTime
            'param_fecha.Value = Date.Parse(lblFecha_liquidado.Text)
            'param_fecha.Direction = ParameterDirection.Input

            ''total
            Dim param_total As New SqlClient.SqlParameter
            param_total.ParameterName = "@total"
            param_total.SqlDbType = SqlDbType.Decimal
            param_total.Value = Decimal.Parse(lblTotal.Text)
            param_total.Direction = ParameterDirection.Input

            Dim param_agrupado As New SqlClient.SqlParameter
            param_agrupado.ParameterName = "@agrupado"
            param_agrupado.SqlDbType = SqlDbType.Bit
            param_agrupado.Value = chkAgrupado.Checked
            param_agrupado.Direction = ParameterDirection.Input

            Dim param_liquidado As New SqlClient.SqlParameter
            param_liquidado.ParameterName = "@liquidado"
            param_liquidado.SqlDbType = SqlDbType.Bit
            param_liquidado.Value = chkLiquidado.Checked
            param_liquidado.Direction = ParameterDirection.Input

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
                                      param_id, param_codigo, param_idPresentacion, param_TipoPago, param_total,
                                      param_agrupado, param_liquidado, param_user, param_res)

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

                ''index
                Dim param_index As New SqlClient.SqlParameter
                param_index.ParameterName = "@index"
                param_index.SqlDbType = SqlDbType.Int
                param_index.Value = detalle("nº")
                param_index.Direction = ParameterDirection.Input

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
                param_idPresentacion_det.Value = detalle("idPresentacion_det")
                param_idPresentacion_det.Direction = ParameterDirection.Input

                ''idFarmacia
                Dim param_idFarmacia As New SqlClient.SqlParameter
                param_idFarmacia.ParameterName = "@idFarmacia"
                param_idFarmacia.SqlDbType = SqlDbType.BigInt
                param_idFarmacia.Value = detalle("IdFarmacia")
                param_idFarmacia.Direction = ParameterDirection.Input

                ''Pagado
                Dim param_pagadoACargoOS As New SqlClient.SqlParameter
                param_pagadoACargoOS.ParameterName = "@pagadoACargoOS"
                param_pagadoACargoOS.SqlDbType = SqlDbType.Decimal
                param_pagadoACargoOS.Value = detalle("A Cargo OS P")
                param_pagadoACargoOS.Direction = ParameterDirection.Input

                ''Pagado
                Dim param_pagadoFinal As New SqlClient.SqlParameter
                param_pagadoFinal.ParameterName = "@pagadoFinal"
                param_pagadoFinal.SqlDbType = SqlDbType.Decimal
                param_pagadoFinal.Value = detalle("Final")
                param_pagadoFinal.Direction = ParameterDirection.Input

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
                                              param_id, param_index, param_idLiquidacion, param_idPresentacion_det,
                                              param_idFarmacia, param_pagadoACargoOS, param_pagadoFinal, param_recetasA,
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
        Dim res As Integer = 1

        Try
            For Each concepto As DataRow In gl_dataset.Tables(1).Rows
                If concepto("estado") <> "saved" Then
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

                    ''eliminable
                    Dim param_eliminable As New SqlClient.SqlParameter
                    param_eliminable.ParameterName = "@eliminable"
                    param_eliminable.SqlDbType = SqlDbType.Bit
                    param_eliminable.Value = concepto("edit")
                    param_eliminable.Direction = ParameterDirection.Input

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


                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spLiquidaciones_det_Conceptos_Insert_Delete",
                                                  param_id, param_idLiquidacion, param_idDetalle, param_idFarmacia,
                                                  param_detalle, param_valor, param_estado, param_eliminable,
                                                  param_user, param_res)

                    res = param_res.Value

                    If (res <= 0) Then
                        GuardarConceptos = res
                    End If
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

        Util.LimpiarTextBox(Me.Controls)

        ''Enable buttons
        btnCargarPresentacion.Enabled = True
        btnEliminar.Enabled = False
        btnExcelWindow.Enabled = False
        btnLiquidar.Enabled = False

        ''Limpieza de labels
        lblPresentacionCodigo.Text = "No seleccionada"
        cmbTipoPago.SelectedValue = "FINAL"
        lblObraSocial.Text = "-"
        lblObservacion.Text = "-"
        lblPeriodo_presentacion.Text = "-"
        lblFecha_presentacion.Text = "-"
        lblFecha_creacion.Text = Today.Date.ToString
        lblFecha_liquidado.Text = "-"
        lblStatus.Text = "CONFECCIONANDO"
        lblCantidadItems.Text = "0"
        lblTotal.Text = "$ 0"
        lblTransferencia.Text = "$ 0"


        SuperGrdResultado.PrimaryGrid.DataSource = Nothing
        gl_dataset = Nothing
        lblFecha_creacion.Text = Date.Today.ToString

        'dtpFECHA.Value = Date.Today
        'dtpFECHA.Focus()

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

        If ReglasNegocio() Then
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

                                    ''disable buttons
                                    btnCargarPresentacion.Enabled = False

                                    MDIPrincipal.NoActualizarBase = False
                                    btnActualizar_Click(sender, e)
                                    btnEliminar.Enabled = Not chkLiquidado.Checked

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
        End If

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        If MessageBox.Show("¿Está seguro que desea cancelar la Liquidación seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Dim connection As SqlClient.SqlConnection = Nothing
        Dim res As Integer = 0

        connection = SqlHelper.GetConnection(ConnStringSEI)
        'Abrir una transaccion para guardar y asegurar que se guarda todo
        If Abrir_Tran(connection) = False Then
            MessageBox.Show("No se pudo abrir una transaccion", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        Try
            ''ID
            Dim param_id As New SqlClient.SqlParameter
            param_id.ParameterName = "@idLiquidacion"
            param_id.SqlDbType = SqlDbType.BigInt
            param_id.Value = IIf(txtID.Text <> "", txtID.Text, DBNull.Value)
            param_id.Direction = ParameterDirection.Input

            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spLiquidaciones_Cancelar", param_id)

            Cerrar_Tran()

            bolModo = False
            PrepararBotones()

            ''disable buttons
            btnCargarPresentacion.Enabled = False

            MDIPrincipal.NoActualizarBase = False
            btnActualizar_Click(sender, e)
            btnEliminar.Enabled = Not chkLiquidado.Checked

            Util.MsgStatus(Status1, "Se ha cancelado la liquidacion.", My.Resources.Resources.ok.ToBitmap)
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            Cancelar_Tran()

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If Not conn_del_form Is Nothing Then
            CType(conn_del_form, IDisposable).Dispose()
        End If

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

    Private Sub btnLlenarGrilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim i As Integer

        If bolModo Then 'SOLO LLENA LA GRILLA EN MODO NUEVO...

        End If

    End Sub

    Private Overloads Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        ''Disable buttons
        btnCargarPresentacion.Enabled = False

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








    'Private Sub btnListo_Click(sender As Object, e As EventArgs) Handles btnListo.Click
    '    Dim i As Integer
    '    Dim rowArray

    '    ''PONE EN CONCEPTOS EL A CARGO OS
    '    'For Each row As DataRow In dtDetalle.Rows
    '    '    Dim a_cargo As DataRow = gl_dataset.Tables(1).NewRow()
    '    '    a_cargo("codigo") = row("CodigoFarmacia")
    '    '    a_cargo("detalle") = "A cargo OS"
    '    '    a_cargo("valor") = row("A cargo OS")
    '    '    gl_dataset.Tables(1).Rows.Add(a_cargo)
    '    'Next

    '    ''CALCULO DE ERROR AJUSTE
    '    For i = 0 To grdDetalleLiquidacionFiltrada.Rows.Count - 1
    '        Dim aceptado = Decimal.Parse(grdDetalleLiquidacionFiltrada.Rows(i).Cells("A cargo OS").Value)
    '        Dim aceptado_farmacia = grdDetalleLiquidacionFiltrada.Rows(i).Cells("IdFarmacia").Value

    '        ''Se queda con la primera coincidencia de farmacia y detalle de la grilla de detalles
    '        Dim a_cargo As DataRow
    '        rowArray = gl_dataset.Tables(1).Select($"IdFarmacia = '{aceptado_farmacia}' and detalle = 'A cargo OS'")
    '        If rowArray.Length > 0 Then
    '            a_cargo = rowArray(0)

    '            If a_cargo("valor") <> aceptado Then
    '                Dim error_ajuste As DataRow = gl_dataset.Tables(1).NewRow()
    '                error_ajuste("IdDetalle") = a_cargo("IdDetalle")
    '                error_ajuste("IdFarmacia") = a_cargo("IdFarmacia")
    '                error_ajuste("estado") = "insert"
    '                If cmbTipoPago.Text = "Anticipo" Then
    '                    error_ajuste("detalle") = "Pendiente de pago"
    '                Else
    '                    error_ajuste("detalle") = "Error ajuste"
    '                End If

    '                error_ajuste("valor") = Decimal.Parse(aceptado - a_cargo("valor"))
    '                gl_dataset.Tables(1).Rows.Add(error_ajuste)
    '            End If
    '        End If

    '    Next

    '    Dim ColumnName As String
    '    Dim IdDetalle As Long

    '    Dim j As Integer = 0
    '    For i = 7 To grdDetalleLiquidacionFiltrada.Columns.Count - 2


    '        ColumnName = grdDetalleLiquidacionFiltrada.Columns(i).Name
    '        For j = 0 To grdDetalleLiquidacionFiltrada.Rows.Count - 1
    '            Dim row As DataRow = gl_dataset.Tables(1).NewRow()
    '            ''Se queda con la primera coincidencia de farmacia para obtener IdDetalle
    '            rowArray = gl_dataset.Tables(1).Select($"IdFarmacia = '{grdDetalleLiquidacionFiltrada.Rows(j).Cells("IdFarmacia").Value}'")
    '            If rowArray.Length > 0 Then
    '                IdDetalle = rowArray(0)("IdDetalle")
    '                row("IdDetalle") = IdDetalle
    '                row("IdFarmacia") = grdDetalleLiquidacionFiltrada.Rows(j).Cells("IdFarmacia").Value
    '                row("detalle") = ColumnName
    '                row("valor") = Decimal.Parse(grdDetalleLiquidacionFiltrada.Rows(j).Cells(i).Value) * -1
    '                row("edit") = "x"
    '                row("estado") = "insert"
    '                If (row("valor") <> 0) Then
    '                    gl_dataset.Tables(1).Rows.Add(row)
    '                End If
    '            End If
    '        Next
    '    Next

    '    MasterGrdDetail = True
    '    Template_On_Sumbit()
    '    UpdateGrdPrincipal()
    '    GroupPanelDetalleLiquidacion.Visible = False
    '    Me.grd.Location = New Size(14, 65)
    '    Me.grd.Size = New Size(4 / 6 * SuperGrdResultado.Width, 100)
    '    Me.grd.BringToFront()

    'End Sub
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
                If Text = "False" Then
                    Text = "x"
                    Enabled = False
                Else
                    Text = "x"
                End If
            End If

        End Sub

        Private Sub MyGridButtonXEditControlClick(ByVal sender As Object, ByVal e As EventArgs)

            ''con editorcell puedo conocer info de el cellpanel
            Dim row_index = EditorCell.RowIndex
            Dim parent = EditorCell.GridPanel.Parent
            Dim panel = EditorCell.GridPanel
            Dim i As Integer
            Dim pendiente As String = ""
            Dim result As DialogResult = MessageBox.Show($"Desea eliminar {panel.GetCell(row_index, 3).Value}?",
                              "Eliminar",
                              MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then

                'panel.Rows.RemoveAt(row_index) ''Elimino la fila

                If panel.Rows(row_index)("estado").Value = "saved" Then
                    panel.Rows(row_index)("estado").Value = "delete"
                    panel.Rows(row_index).visible = False ''Oculto la fila para luego eliminarla
                Else
                    panel.Rows.RemoveAt(row_index)
                End If

                Dim ajusteExists As Boolean = False
                Dim valorInicial As Decimal = 0.00
                For i = 0 To panel.rows.count - 1
                    If panel.GetCell(i, 3).Value = "Error ajuste" Then
                        ajusteExists = True
                    End If
                Next

                ''De esta manera identifico que valor tomar como inicial
                If ajusteExists Or parent("A Cargo OS A").Value Is DBNull.Value Then
                    Dim pagado = IIf(parent("A Cargo OS P").Value Is DBNull.Value, 0, parent("A Cargo OS P").Value)
                    valorInicial = parent("A Cargo OS").Value - pagado
                Else
                    valorInicial = parent("A Cargo OS A").Value
                End If

                Dim total As Decimal = valorInicial
                For i = 0 To panel.Rows.Count - 1
                    'If panel.GetCell(i, 3).Value = "Pendiente de pago" Then
                    '    pendiente = $"<br/> Pendiente de pago: <font color=""Gray""><i>${Decimal.Parse(panel.GetCell(i, 4).Value * -1):N2}</i></font>"
                    'End If

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
        SuperGrdResultado.PrimaryGrid.Columns("IdPresentacion_det").Visible = False
        SuperGrdResultado.PrimaryGrid.Columns("IdLiquidacion_det").Visible = False
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

            ''HEADER 1
            GroupHeader1.EndDisplayIndex = panel.Columns("A cargo OS").DisplayIndex
            GroupHeader1.StartDisplayIndex = panel.Columns("Recetas").DisplayIndex
            GroupHeader1.HeaderText = "Presentado"

            If Not Groupheaders.contains(GroupHeader1.Name) Then
                Groupheaders.Add(GroupHeader1)
            End If

            ''HEADER 2
            GroupHeader2.EndDisplayIndex = panel.Columns("A Cargo OS A").DisplayIndex
            GroupHeader2.StartDisplayIndex = panel.Columns("Recetas A").DisplayIndex
            GroupHeader2.HeaderText = "Aceptado"
            If Not Groupheaders.contains(GroupHeader2.Name) Then
                Groupheaders.Add(GroupHeader2)
            End If

            ''HEADER 3
            Dim GroupHeader3 As New ColumnGroupHeader()
            GroupHeader3.EndDisplayIndex = panel.Columns("Final").DisplayIndex
            GroupHeader3.StartDisplayIndex = panel.Columns("A Cargo OS P").DisplayIndex
            GroupHeader3.HeaderText = "Pagado"
            If Not Groupheaders.contains(GroupHeader3.Name) Then
                Groupheaders.Add(GroupHeader3)
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
            panel.ColumnDragBehavior = False
            'panel.Columns(0).Visible = False 'ID
            'panel.Columns(1).Visible = False 'IdDetalle
            'panel.Columns(2).Visible = False 'IdFarmacia
            'panel.Columns(5).Visible = False 'estado
            panel.Columns(6).Width = 30 'hago el boton de eliminar mas pequeño

            panel.Columns(3).AllowEdit = False
            panel.Columns(4).AllowEdit = False
            panel.Columns(6).AllowEdit = True 'Permito interaccion con el boton de eliminar

            'panel.Visible = IIf(panel.Rows.Count > 0, True, False)

            Dim i As Integer
            Dim pendiente As String = ""
            Dim ajusteExists As Boolean = False
            Dim valorInicial As Decimal = 0.00
            Dim parent = panel.GridPanel.Parent
            For i = 0 To panel.Rows.Count - 1
                If panel.GetCell(i, 3).Value = "Error ajuste" Then
                    ajusteExists = True
                End If
                If panel.GetCell(i, 5).Value = "delete" Then
                    panel.Rows(i).Visible = False
                End If
            Next

            ''De esta manera identifico que valor tomar como inicial
            If ajusteExists Or parent("A Cargo OS A").Value Is DBNull.Value Then
                Dim pagado = IIf(parent("A Cargo OS P").Value Is DBNull.Value, 0, parent("A Cargo OS P").Value)
                valorInicial = parent("A Cargo OS").Value - pagado
            Else
                valorInicial = parent("A Cargo OS A").Value
            End If

            Dim total As Decimal = valorInicial
            For i = 0 To panel.Rows.Count - 1
                'If panel.GetCell(i, 3).Value = "Pendiente de pago" Then
                '    pendiente = $"<br/> Pendiente de pago: <font color=""Gray""><i>${Decimal.Parse(panel.GetCell(i, 4).Value * -1):N2}</i></font>"
                'End If

                If panel.GetCell(i, 5).Value <> "delete" Then ''Sumo solo si la columna no está para eliminar
                    total += panel.GetCell(i, 4).Value
                End If

                panel.GetCell(i, 6).EditorType = GetType(MyGridButtonXEditControl)
            Next
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
        Dim valor As Decimal = 0
        Dim concepto As DataRow

        For Each Farmacia As DataRow In gl_dataset.Tables(0).Rows
            valor = -Farmacia("subtotal") * Decimal.Parse(porcentaje)

            'Dim CurrentConcepto = gl_dataset.Tables(1).Select($"IdDetalle = '{Farmacia("ID")}' and detalle = '{detalle}'")(0)
            Dim CurrentConcepto = gl_dataset.Tables(1).Select($"IdDetalle = '{Farmacia("nº")}' and detalle = '{detalle}'")
            If CurrentConcepto Is DBNull.Value Then ' If CurrentConcepto IsNot Nothing Then
                CurrentConcepto("valor") = valor
                If CurrentConcepto("estado") = "saved" Then
                    CurrentConcepto("estado") = "update"
                Else
                    CurrentConcepto("estado") = "insert"
                End If
            Else
                ''creo el concepto
                concepto = gl_dataset.Tables(1).NewRow ' <- dtConceptos

                concepto("IdDetalle") = Farmacia("nº")
                concepto("IdFarmacia") = Farmacia("IdFarmacia")
                concepto("detalle") = detalle
                concepto("valor") = valor
                'concepto("edit") = New DataGridViewButtonXCell()
                concepto("edit") = True
                concepto("estado") = "insert"

                gl_dataset.Tables(1).Rows.Add(concepto)
            End If


        Next
    End Sub

    Private Sub deleteConceptos(detalle As String)
        Dim dtDetalle As DataTable = gl_dataset.Tables(1)
        Dim rows = dtDetalle.Select($"detalle = '{detalle}'")

        For Each row As DataRow In rows
            row.Delete()
        Next
    End Sub

    Private Sub añadirConcepto(concepto As DataRow)
        Dim collection = gl_dataset.Tables(1).Select($"IdDetalle = '{concepto("IdDetalle")}' and detalle = '{concepto("detalle")}'")
        If collection.Length > 0 Then
            'UPDATE
            Dim CurrentConcepto = collection(0)

            CurrentConcepto("valor") = concepto("valor")
            CurrentConcepto("edit") = concepto("edit")
            If CurrentConcepto("estado") <> "insert" Then
                CurrentConcepto("estado") = "update"
            End If

        Else
            'INSERT
            Dim new_concepto As DataRow = gl_dataset.Tables(1).NewRow ' <- dtConceptos

            new_concepto("IdDetalle") = concepto("IdDetalle")
            new_concepto("IdFarmacia") = concepto("IdFarmacia")
            new_concepto("detalle") = concepto("detalle")
            new_concepto("valor") = concepto("valor")
            new_concepto("edit") = concepto("edit")
            new_concepto("estado") = "insert"

            gl_dataset.Tables(1).Rows.Add(new_concepto)
        End If
    End Sub

    Private Sub eliminarConcepto(concepto As DataRow)
        Dim collection = gl_dataset.Tables(1).Select($"IdDetalle = '{concepto("IdDetalle")}' and detalle = '{concepto("detalle")}'")
        If collection.Length > 0 Then
            Dim CurrentConcepto = collection(0)

            If CurrentConcepto("estado") = "insert" Then
                CurrentConcepto.delete()
            Else
                CurrentConcepto("estado") = "delete"
            End If
        End If
    End Sub

    Private Sub btnCargarPresentacion_Click(sender As Object, e As EventArgs) Handles btnCargarPresentacion.Click
        Dim NuevaLiquidacion As New frmSelectPresentacion
        NuevaLiquidacion.ShowDialog()
    End Sub

    Private Sub btnLiquidar_Click(sender As Object, e As EventArgs) Handles btnLiquidar.Click
        Dim result As DialogResult = MessageBox.Show(
                              $"¿Desea confirmar la liquidación {txtCodigo.Text}?{vbLf}Se generará el pago correspondiente sobre el saldo de profesionales{vbLf}Monto: ${lblTotal.Text}",
                              "Confirmar liquidación",
                              MessageBoxButtons.YesNo)

        If result = DialogResult.Yes And ReglasNegocio() Then
            Dim res As Integer, res_item As Integer, res_concepto As Integer, res_pago As Integer

            ''Cambio bit de liquidado
            chkLiquidado.Checked = True

            ''Hago que todos los conceptos no puedan ser eliminados
            For Each concepto As DataRow In gl_dataset.Tables(1).Rows
                If concepto("edit") = True Then
                    concepto("edit") = False
                    añadirConcepto(concepto)
                End If
            Next

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
                                    Util.MsgStatus(Status1, "No se pudo registrar el registro (Concepto).", My.Resources.Resources.stop_error.ToBitmap)
                                    Util.MsgStatus(Status1, "No se pudo registrar el registro (Concepto).", My.Resources.Resources.stop_error.ToBitmap, True)
                                    Exit Sub
                                Case 0
                                    Cancelar_Tran()
                                    Util.MsgStatus(Status1, "No se pudo agregar el registro (Concepto).", My.Resources.Resources.stop_error.ToBitmap)
                                    Util.MsgStatus(Status1, "No se pudo agregar el registro (Concepto).", My.Resources.Resources.stop_error.ToBitmap, True)
                                    Exit Sub
                                Case Else
                                    res_pago = GenerarPago()
                                    Select Case res_pago
                                        Case Else
                                            Cerrar_Tran()

                                            bolModo = False
                                            PrepararBotones()

                                            ''disable buttons
                                            btnCargarPresentacion.Enabled = False

                                            MDIPrincipal.NoActualizarBase = False
                                            btnActualizar_Click(sender, e)
                                            btnEliminar.Enabled = Not chkLiquidado.Checked

                                            Util.MsgStatus(Status1, "Se ha actualizado el registro.", My.Resources.Resources.ok.ToBitmap)
                                    End Select
                            End Select
                    End Select
            End Select
            '
            ' cerrar la conexion si está abierta.
            '
            If Not conn_del_form Is Nothing Then
                CType(conn_del_form, IDisposable).Dispose()
            End If
        End If
    End Sub

    Private Function GenerarPago() As Integer
        Dim res As Integer = 0

        Try
            For Each farmacia As DataRow In gl_dataset.Tables(0).Rows
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
                param_idFarmacia.Value = farmacia("IdFarmacia")
                param_idFarmacia.Direction = ParameterDirection.Input

                ''detalle
                Dim param_detalle As New SqlClient.SqlParameter
                param_detalle.ParameterName = "@detalle"
                param_detalle.SqlDbType = SqlDbType.VarChar
                param_detalle.Size = 200
                param_detalle.Value = $"LIQ. {lblObraSocial.Text} {lblPeriodo_presentacion}"
                param_detalle.Direction = ParameterDirection.Input

                ''debito
                Dim param_debito As New SqlClient.SqlParameter
                param_debito.ParameterName = "@debito"
                param_debito.SqlDbType = SqlDbType.Decimal
                param_debito.Value = DBNull.Value
                param_debito.Direction = ParameterDirection.Input

                ''credito
                Dim param_credito As New SqlClient.SqlParameter
                param_credito.ParameterName = "@credito"
                param_credito.SqlDbType = SqlDbType.Decimal
                param_credito.Value = DBNull.Value
                param_credito.Direction = ParameterDirection.Input

                If farmacia("subtotal") >= 0 Then
                    param_credito.Value = farmacia("subtotal")
                Else
                    param_debito.Value = farmacia("subtotal")
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

                res = param_res.Value

                If (res <= 0) Then
                    GenerarPago = res
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

        GenerarPago = res
    End Function

    Private Sub chkLiquidado_CheckedChanged(sender As Object, e As EventArgs) Handles chkLiquidado.CheckedChanged
        If chkLiquidado.Checked = True Then
            btnGuardar.Enabled = False
            btnLiquidar.Enabled = False
            btnExcelWindow.Enabled = False
            btnEliminar.Enabled = False
        Else
            btnGuardar.Enabled = True
            btnLiquidar.Enabled = True
            btnExcelWindow.Enabled = True
            btnEliminar.Enabled = True
        End If
    End Sub

    Private Sub cmbTipoPago_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbTipoPago.SelectionChangeCommitted
        ''Genero el concepto que contempla diferencia entre aceptado y presentado
        If gl_dataset IsNot Nothing Then
            If sender.selectedvalue = "FINAL" Then ''uso not porque el evento me trae el estado anterior a la seleccion
                For Each detalle As DataRow In gl_dataset.Tables(0).Rows
                    If detalle("A Cargo OS A") IsNot DBNull.Value Then
                        Dim row As DataRow = gl_dataset.Tables(1).NewRow()
                        Dim pagado = IIf(detalle("A Cargo OS P") IsNot DBNull.Value, detalle("A Cargo OS P"), 0)
                        row("IdDetalle") = detalle("nº")
                        row("IdFarmacia") = detalle("IdFarmacia")
                        row("detalle") = "Error ajuste"
                        row("valor") = detalle("A Cargo OS A") - (detalle("A Cargo OS") - pagado)
                        row("edit") = False

                        If row("valor") <> 0 Then
                            añadirConcepto(row)
                        End If
                    End If
                Next
            ElseIf sender.selectedvalue = "PARCIAL" Then
                Dim selection = gl_dataset.Tables(1).Select("detalle = 'Error ajuste'")
                For Each concepto As DataRow In selection
                    eliminarConcepto(concepto)
                Next
            End If

            UpdateGrdPrincipal()
        End If
    End Sub
End Class
