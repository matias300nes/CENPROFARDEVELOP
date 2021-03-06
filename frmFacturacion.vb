Imports Microsoft.ApplicationBlocks.Data
Imports Utiles
Imports Utiles.Util
Imports System.Data.SqlClient
Imports ReportesNet


Public Class frmFacturacion

    Dim bolpoliticas As Boolean

    Dim RemitosAsociados As String

    Dim llenandoCombo As Boolean = False

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

    Dim band As Integer

    Dim IVA As Double
    Dim NroPresup As Integer
    Dim OC_x_Remito As String, banOC_x_Remito As Boolean = True

    Dim bandIVA As Boolean = True ', bandPresup As Boolean = True ', bandValorDolar As Boolean = True

    Dim NroFacturaTentativo As Long

    Dim IdFacturaAnulada As Long

    Public Origen As Integer = 0
    Public Origen_IdCliente As Long
    Public Origen_IdPresupuesto As Long
    Public Origen_NroRemito As String

    'VARIABLES PARA LA AFIP
    Dim wsfev1 As Object
    Dim WSAA As Object
    Dim PathAfip As String
    Dim tra As String, cms As String, ta As String
    Dim wsdl As String, proxy As String, cache As String = ""
    Dim certificado As String, claveprivada As String
    Dim ok

    Dim concepto, tipo_doc, nro_doc, tipo_cbte, punto_vta, _
            cbt_desde, cbt_hasta, imp_total, imp_tot_conc, imp_neto, _
            imp_iva, imp_trib, imp_op_ex, fecha_cbte, fecha_venc_pago, _
            fecha_serv_desde, fecha_serv_hasta, _
            moneda_id, moneda_ctz
    Dim tipo, pto_vta, nro, fecha, cbte_nro
    Dim id, Desc, base_imp, alic, importe
    Dim cae

    Dim cae2

    'VALORES DE REFERENCIA
    Dim ref_email As String, ref_direccion As String

    Dim HOMO As Boolean '= False
    Dim TicketAcceso As Boolean '= False
    Dim PTOVTA As String '= False

    Dim cuitEmpresa As String = ""
    Dim ModoPagoPredefinido As String

    'constantes para identificar las columnas de la grilla por nombre 
    ' en vez de n?mero

    Enum ColumnasDelGrid
        Id = 0
        Codigo = 1
        FechaFactura = 2
        IdCliente = 3
        Cliente = 4
        TipoComprobante = 5
        PtoVta = 6
        NroFactura = 7
        NroComprobante = 8
        Total = 9
        CondicionVta = 10
        CondicionIVA = 11
        Presup = 12
        NroOC = 13
        Nota = 14
        Remitos = 15
        Cancelada = 16
        MovIngreso = 17
        IdFacturaAnulada = 18
        TipoConcepto = 19
        VtoPago = 20
        ServDesde = 21
        ServHasta = 22
        Cae = 23
        VencCae = 24
        TipoDoc = 25
        ComprFacturacion = 26
        NroCuit = 27
        ValorCambio = 28
    End Enum

    Enum ColumnasDelGridItems
        IdPresGes = 0
        Cod_Material = 1
        Nombre_Material = 2
        PrecioUni = 3
        Qty = 4
        Subtotal = 5
        TipoRemito = 6
    End Enum

    Enum ColumnasDelGridRemitos
        IdPresGes = 0
        IdPres = 1
        NroPres = 2
        NroRemito = 3
        Especial = 4
        CodMonedaPres = 5
        SubtotalDO = 6
        Iva = 7
        MontoIvaDO = 8
        TotalDO = 9
        SubtotalPE = 10
        MontoIvaPE = 11
        TotalPE = 12
        OCRemito = 13
        Seleccionar = 14
        EntregaPendiente = 15
        'ValorCambio = 16
        Nota_Gestion = 16
        IdMonedaPres = 17
    End Enum

    Enum ColumnasDelGridNC
        IdNC = 0
        IdFacturacion = 1
        NC = 2
        NroFactura = 3
        Subtotal = 4
        Iva = 5
        TotalIva = 6
        Total = 7
        Seleccionar = 8
    End Enum

    Enum TipoComp
        FacturaA = 1
        NotaDebitoA = 2
        NotaCreditoA = 3
        FacturaB = 6
        NotaDebitoB = 7
        NotaCreditoB = 8
    End Enum

    'Auxiliares para guardar
    Dim cod_aux As String

    'Auxiliares para chequear lo digitado en la columna cantidad
    Dim qty_digitada As String

    Dim permitir_evento_CellChanged As Boolean

#Region "   Eventos"

    Private Sub frmFacturacion_ev_CellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ev_CellChanged
        If permitir_evento_CellChanged Then
            If txtID.Text <> "" Then
                LlenarGrid_Remitos(CType(cmbCliente.SelectedValue, Long), bolModo, txtID.Text, txtIdFacturaAnulada.Text)
                grdRemitos.Columns(ColumnasDelGridRemitos.Seleccionar).Visible = False

            End If
        End If
    End Sub

    Private Sub frmFacturacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not conn_del_form Is Nothing Then
            CType(conn_del_form, IDisposable).Dispose()
        End If
    End Sub

    Private Sub frmFacturacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3 'nuevo
                If bolModo = True Then
                    If MessageBox.Show("No ha guardado la Factura Nueva que est? realizando. ?Est? seguro que desea continuar sin Grabar y hacer una Nueva Factura?", "Atenci?n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
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

        'btnEliminar.Text = "Anular Factura L?gica"
        btnEliminar.Visible = False

        band = 0
        configurarform()
        asignarTags()

        LlenarComboClientes()
        'LlenarcmbClientes2()
        LlenarcmbTipoFacturas_APP(cmbTipoComprobante, ConnStringSEI)
        LlenarcmbConceptos_APP(cmbConceptos, ConnStringSEI)

        SQL = "exec spFacturacion_Select_All @Eliminado = 0"

        LlenarGrilla()

        Permitir = True

        CargarCajas()

        PrepararBotones()

        If Origen = 0 Then
            If bolModo = True Then
                LlenarGrid_Remitos(CType(cmbCliente.SelectedValue, Long), bolModo, txtID.Text, txtIdFacturaAnulada.Text)
                btnNuevo_Click(sender, e)
            Else
                LlenarGrid_Remitos(CType(cmbCliente.SelectedValue, Long), bolModo, txtID.Text, txtIdFacturaAnulada.Text)
                grdRemitos.Columns(ColumnasDelGridRemitos.Seleccionar).Visible = False

                AgregarRemito_tmp()

                LlenarGrid_Items()
            End If
        Else
            btnNuevo_Click(sender, e)
            cmbCliente.SelectedValue = Origen_IdCliente
            LlenarGrid_Remitos(CType(cmbCliente.SelectedValue, Long), bolModo, txtID.Text, txtIdFacturaAnulada.Text)
            grdRemitos.Columns(ColumnasDelGridRemitos.Seleccionar).Visible = False

            Dim i As Integer
            For i = 0 To grdRemitos.RowCount - 1
                If Origen_IdPresupuesto = grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.IdPres).Value And Origen_NroRemito = grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.NroRemito).Value Then
                    grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.Seleccionar).Value = True
                End If
            Next
            bolModo = True
            Exit Sub
        End If


        grdRemitos.Enabled = bolModo

        grd.Columns(ColumnasDelGrid.IdCliente).Visible = False
        grd.Columns(ColumnasDelGrid.PtoVta).Visible = False
        grd.Columns(ColumnasDelGrid.NroFactura).Visible = False
        grd.Columns(ColumnasDelGrid.CondicionVta).Visible = False
        grd.Columns(ColumnasDelGrid.CondicionIVA).Visible = False
        grd.Columns(ColumnasDelGrid.Nota).Visible = False
        grd.Columns(ColumnasDelGrid.Cancelada).Visible = False
        grd.Columns(ColumnasDelGrid.IdFacturaAnulada).Visible = False
        grd.Columns(ColumnasDelGrid.TipoConcepto).Visible = False
        grd.Columns(ColumnasDelGrid.VtoPago).Visible = False
        grd.Columns(ColumnasDelGrid.ServDesde).Visible = False
        grd.Columns(ColumnasDelGrid.ServHasta).Visible = False
        grd.Columns(ColumnasDelGrid.Cae).Visible = False
        grd.Columns(ColumnasDelGrid.VencCae).Visible = False
        grd.Columns(ColumnasDelGrid.TipoDoc).Visible = False
        grd.Columns(ColumnasDelGrid.ComprFacturacion).Visible = False
        grd.Columns(ColumnasDelGrid.NroCuit).Visible = False
        grd.Columns(ColumnasDelGrid.ValorCambio).Visible = False

        txtCliente.Visible = Not bolModo

        txtNota.Enabled = True

        grdRemitos.Enabled = bolModo

        cmbCondVTA.Enabled = bolModo

        chkAnulados.Enabled = Not bolModo

        permitir_evento_CellChanged = True

        If grd.RowCount > 0 Then
            If grd.CurrentRow.Cells(18).Value > 0 Then
                lblNotaCredito.Visible = True
                btnAnular.Enabled = False
            Else
                lblNotaCredito.Visible = False
                btnAnular.Enabled = True
            End If
        End If

        Try
            'MsgBox("aca")
            cmbTipoComprobante.Text = "FACTURAS A"
            cmbTipoComprobante_SelectedIndexChanged(sender, e)

            cmbConceptos.SelectedIndex = 0
            cmbConceptos_SelectedIndexChanged(sender, e)

            cmbCondVTA.SelectedIndex = 0

        Catch ex As Exception

        End Try

        Try
            conn_del_form = SqlHelper.GetConnection(ConnStringSEI)

            Dim ds As Data.DataSet

            ds = SqlHelper.ExecuteDataset(conn_del_form, CommandType.Text, "select NombreEmpresaFactura, ModoPagoPredefinido, CUIT, HOMO, TA, PTOVTA from parametros")

            ds.Dispose()

            Utiles.Empresa = ds.Tables(0).Rows(0).Item(0)
            ModoPagoPredefinido = ds.Tables(0).Rows(0).Item(1)
            cuitEmpresa = ds.Tables(0).Rows(0).Item(2)
            HOMO = CBool(ds.Tables(0).Rows(0).Item(3))
            TicketAcceso = CBool(ds.Tables(0).Rows(0).Item(4))
            PTOVTA = ds.Tables(0).Rows(0).Item(5)

        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        lblModo.Visible = HOMO

        'If ConexionAfip() = True Then
        '    imgConexion.Image = My.Resources.Green_Ball_icon
        'Else
        '    MessageBox.Show("La conexi?n con el servidor de la AFIP no ha sido exitosa, por favor intente nuevamente mas tarde.", "Error de conexi?n", MessageBoxButtons.OK)
        '    imgConexion.Image = My.Resources.Red_Ball_icon
        '    Exit Sub
        'End If

        cmbTipoComprobante.Enabled = bolModo
        cmbComprobantes.Enabled = bolModo
        cmbConceptos.Enabled = bolModo

        txtValorCambio.Enabled = bolModo

        dtpFECHA.Enabled = bolModo
        dtpServicioDesde.Enabled = bolModo
        dtpServicioHasta.Enabled = bolModo
        dtpVtoPago.Enabled = bolModo

        dtpFECHA.MaxDate = Today.Date

        band = 1

    End Sub

    Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txtID.KeyPress, txtCODIGO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub dtpfecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFECHA.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub grdRemitos_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdRemitos.CellMouseUp
        Cell_X = e.ColumnIndex
        Cell_Y = e.RowIndex
    End Sub

    Private Sub cmbCliente_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCliente.SelectedValueChanged
        If band = 1 Then
            'If llenandoCombo = False Then
            LlenarGrid_Remitos(CType(cmbCliente.SelectedValue, Long), bolModo, txtID.Text, txtIdFacturaAnulada.Text)

            txtIdCliente.Text = CType(cmbCliente.SelectedValue, Long)

            If grdItems.Columns.Count > 0 Then
                grdItems.Columns.Clear()
            End If

            lblCantidadFilas.Text = "0 / 16"

            OC_x_Remito = ""
            banOC_x_Remito = True

            If bolModo = True Then

                Buscar_DatosClientes()

                'Dim cuit, iva
                'Dim Padron As Object, ok As Object

                ''Dim digito As String = "", dni As String = ""

                ''If cmbDocTipo.SelectedValue = 80 Then
                'If txtDocTipo.Text = "CUIT" Then

                '    '    'picCargando.Visible = True
                '    Padron = CreateObject("PadronAFIP")

                '    cuit = txtCUITCliente.Text

                '    ok = Padron.Conectar()
                '    ok = Padron.Consultar(cuit)

                '    If Not Padron.denominacion = "" Then
                '        'cmbCliente.Text = Padron.denominacion
                '        'txtDIRECCION.Text = Padron.direccion + " - " + Padron.localidad + " - " + Padron.provincia

                '        ok = Padron.Buscar(cuit)

                '        Select Case Padron.imp_iva
                '            Case "AC"
                '                iva = "IVA Responsable Inscripto (Activo)"
                '            Case "NI"
                '                iva = "No inscripto"
                '                If Padron.monotributo <> "NI" Then
                '                    iva = iva + " (Monotributo CAT " & Padron.monotributo & ")"
                '                End If
                '            Case "EX"
                '                iva = "Exento"
                '            Case Else
                '                iva = Padron.imp_iva
                '        End Select

                '        txtCondicionIVA.Text = iva

                '    Else
                '        'cmbCliente.Text = ""
                '        txtCondicionIVA.Text = ""
                '    End If

                'End If

            End If

        End If

    End Sub

    Private Sub grdRemitos_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRemitos.CurrentCellDirtyStateChanged
        If grdRemitos.IsCurrentCellDirty Then
            grdRemitos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    'Private Sub grdRemitos_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdRemitos.CellBeginEdit
    '    editando_celda = True
    '    'Contar_Filas()
    'End Sub

    'Private Sub grdRemitos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdRemitos.CellEndEdit
    '    editando_celda = False
    '    Try
    '        If e.ColumnIndex = ColumnasDelGridRemitos.OCRemito Then
    '            Dim i As Integer
    '            txtOC.Text = ""
    '            For i = 0 To grdRemitos.RowCount - 1
    '                If CBool(grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.Seleccionar).Value) = True Then
    '                    If txtOC.Text = "" Then
    '                        txtOC.Text = IIf(grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.OCRemito).Value Is DBNull.Value, "", grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.OCRemito).Value).ToString
    '                    Else
    '                        txtOC.Text = RTrim(LTrim(txtOC.Text)) + " - " + IIf(grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.OCRemito).Value Is DBNull.Value, "", grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.OCRemito).Value)
    '                    End If
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub grdRemitos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdRemitos.CellValueChanged
        Try

            If e.ColumnIndex = ColumnasDelGridRemitos.Seleccionar Then

                AgregarRemito_tmp()

                LlenarGrid_Items()

                grdRemitos.Refresh()

            End If

        Catch ex As Exception
            MsgBox("Error en Sub grdRemitos_CellClick", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub PicAnularFacturas_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicAnularFacturas.MouseHover
        Dim a As New ToolTip
        a.SetToolTip(Me.PicAnularFacturas, "El sistema permite la anulaci?n f?sica o l?gica de la Factura. " & vbCrLf & "La primera implica que el nro de factura ingresada no podr? volver a ser utilizado, " & vbCrLf & "mientras que con la segunda, el nro de factura sigue disponible." & vbCrLf & "Para la eliminaci?n l?gica del registro utilice la opci?n Anular Factura en la parte superior de la pantalla")
        a.IsBalloon = True
        a.UseAnimation = True
    End Sub

    'Private Sub chkAnulados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAnulados.CheckedChanged
    '    btnGuardar.Enabled = Not chkAnulados.Checked
    '    btnEliminar.Enabled = Not chkAnulados.Checked
    '    btnNuevo.Enabled = Not chkAnulados.Checked
    '    btnCancelar.Enabled = Not chkAnulados.Checked

    '    If chkAnulados.Checked = True Then
    '        SQL = "exec spFacturacion_Select_All @Eliminado = 1"
    '    Else
    '        SQL = "exec spFacturacion_Select_All @Eliminado = 0"
    '    End If

    '    'LlenarcmbClientes2()

    '    LlenarGrilla()

    '    chkBuscarClientes.Checked = False
    '    chkBuscarClientes_CheckedChanged(sender, e)

    'End Sub

    Private Sub chkBuscarClientes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBuscarClientes.CheckedChanged
        If band = 1 Then
            cmbCliente2.Enabled = chkBuscarClientes.Checked
            If chkBuscarClientes.Checked = True Then
                If cmbCliente2.Text <> "" Then
                    QuitarElFitroToolStripMenuItem_Click(sender, e)
                    ColumnName = "Cliente"
                    ColumnType = "system.string"
                    Filtrarpor(cmbCliente2.Text)
                End If
            Else
                QuitarElFitroToolStripMenuItem_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub cmbCliente2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCliente2.SelectedIndexChanged
        If band = 1 Then
            If cmbCliente2.Text <> "" Then
                QuitarElFitroToolStripMenuItem_Click(sender, e)
                ColumnName = "Cliente"
                ColumnType = "system.string"
                Filtrarpor(cmbCliente2.Text)
                'If grd.RowCount > 0 Then
                '    '    cmbFAMILIAS.SelectedValue = grd.CurrentRow.Cells(8).Value
                '    '    cmbSubRubro.SelectedValue = grd.CurrentRow.Cells(10).Value
                '    '    cmbMonedas.SelectedValue = grd.CurrentRow.Cells(3).Value
                '    '    cmbUNIDADES.SelectedValue = grd.CurrentRow.Cells(23).Value
                'End If
            Else
                QuitarElFitroToolStripMenuItem_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub cmbTipoComprobante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoComprobante.SelectedIndexChanged
        If bolModo = True Then
            Try
                'Dim cbte_nro, tipo_cbte, punto_vta

                tipo_cbte = cmbTipoComprobante.SelectedValue
                punto_vta = PTOVTA '1002
                'cbte_nro = wsfev1.CompUltimoAutorizado(tipo_cbte, punto_vta)

                'If cbte_nro = "" Then
                ' cbte_nro = 0                ' no hay comprobantes emitidos
                'Else
                'cbte_nro = CLng(cbte_nro) ' convertir a entero largo
                'End If

                txtptovta.Text = PTOVTA
                'txtNroFactura.Text = cbte_nro + 1 'Format(cbte_nro + 1, "0000000000")

            Catch ex As Exception

            End Try

            Try
                If CInt(cmbTipoComprobante.SelectedValue) = TipoComp.NotaDebitoA Or _
                    CInt(cmbTipoComprobante.SelectedValue) = TipoComp.NotaCreditoA Or _
                    CInt(cmbTipoComprobante.SelectedValue) = TipoComp.NotaDebitoB Or _
                    CInt(cmbTipoComprobante.SelectedValue) = TipoComp.NotaCreditoB Then

                    LlenarCmbComprobantes()
                    cmbComprobantes.Enabled = True

                    If llenandoCombo = False Then
                        If cmbComprobantes.Items.Count > 0 Then
                            cmbComprobantes.SelectedIndex = 0
                            CmbComprobantes_SelectedIndexChanged(sender, e)
                        End If
                    End If

                    cmbCliente.Visible = False
                    txtCliente.Visible = True

                    grdItems.Enabled = False
                    grdRemitos.Enabled = False

                Else
                    cmbComprobantes.Enabled = False
                    Me.cmbComprobantes.DataSource = Nothing
                    Me.cmbComprobantes.Items.Clear()
                    Me.cmbComprobantes.Refresh()

                    cmbCliente.Visible = True
                    txtCliente.Visible = False

                    grdItems.Enabled = True
                    grdRemitos.Enabled = True

                End If

            Catch ex As Exception

            End Try

            BuscarProximaFactura()

            Try
                If cmbTipoComprobante.SelectedValue = TipoComp.FacturaA Or cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoA Or _
                        cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoA Then

                    cmbCondVTA.Text = "CTA. CTE"

                End If

                If cmbTipoComprobante.SelectedValue = TipoComp.FacturaB Or cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoB Or _
                        cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoB Then

                    cmbCondVTA.Text = "CONTADO"

                End If
            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub CmbComprobantes_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbComprobantes.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            grdItems.Focus()
        End If

        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub CmbComprobantes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbComprobantes.SelectedIndexChanged
        Try
            If llenandoCombo = False And bolModo = True Then
                LlenarCamposConsumo(cmbComprobantes.Text.ToString, cmbComprobantes.SelectedValue)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbConceptos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbConceptos.SelectedIndexChanged
        Try
            If cmbConceptos.SelectedValue = 1 Then
                'boxPeriodoFacturado.Enabled = False
                dtpServicioDesde.Enabled = False
                dtpServicioHasta.Enabled = False
                'dtpVtoPago.Enabled = False
            Else
                'boxPeriodoFacturado.Enabled = True
                dtpServicioDesde.Enabled = True
                dtpServicioHasta.Enabled = True
                'dtpVtoPago.Enabled = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtValorCambio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValorCambio.KeyPress
        If bolModo = True Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                If txtValorCambio.Text = "" Then
                    txtValorCambio.Text = "1"
                Else
                    If CDbl(txtValorCambio.Text) < 1 Then
                        txtValorCambio.Text = "1"
                    End If
                End If

                CalcularMontos()

            End If
        End If

    End Sub

    Private Sub txtValorCambio_LostFocus(sender As Object, e As EventArgs) Handles txtValorCambio.LostFocus
        If bolModo = True Then
            If txtValorCambio.Text = "" Then
                txtValorCambio.Text = "1"
            Else
                If CDbl(txtValorCambio.Text) < 1 Then
                    txtValorCambio.Text = "1"
                End If
            End If

            CalcularMontos()
        End If
    End Sub

    Protected Overloads Sub grd_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.CurrentCellChanged

        If Permitir Then

            AgregarRemito_tmp()

            LlenarGrid_Items()

            If IIf(txtIdFacturaAnulada.Text = "", 0, txtIdFacturaAnulada.Text) > 0 Then
                lblNotaCredito.Visible = True
                btnAnular.Enabled = False
            Else
                lblNotaCredito.Visible = False
                btnAnular.Enabled = True
            End If

        End If

    End Sub

    Private Sub chkVerNotaGestion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVerNotaGestion.CheckedChanged
        If chkVerNotaGestion.Checked = False Then
            grdRemitos.Width = 732
            grdItems.Width = grdItems.Width + 168
            grdItems.Location = New Point(grdItems.Location.X - 168, grdItems.Location.Y)
            Label6.Location = New Point(Label6.Location.X - 168, Label6.Location.Y)
            Label19.Location = New Point(Label19.Location.X - 168, Label19.Location.Y)
            lblCantidadFilas.Location = New Point(lblCantidadFilas.Location.X - 168, lblCantidadFilas.Location.Y)
        Else
            grdRemitos.Width = 900
            grdItems.Width = grdItems.Width - 168
            grdItems.Location = New Point(grdItems.Location.X + 168, grdItems.Location.Y)
            Label6.Location = New Point(Label6.Location.X + 168, Label6.Location.Y)
            Label19.Location = New Point(Label19.Location.X + 168, Label19.Location.Y)
            lblCantidadFilas.Location = New Point(lblCantidadFilas.Location.X + 168, lblCantidadFilas.Location.Y)
        End If

    End Sub

#End Region

#Region "   Procedimientos"

    Private Sub configurarform()
        Me.Text = "Facturaci?n"

        Me.grd.Location = New Size(GroupBox1.Location.X, GroupBox1.Location.Y + GroupBox1.Size.Height + 7)
        'Dim p As New Size(GroupBox1.Size.Width, 200) 'AltoMinimoGrilla)
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
        txtID.Tag = CStr(ColumnasDelGrid.Id)
        txtCODIGO.Tag = CStr(ColumnasDelGrid.Codigo)
        dtpFECHA.Tag = CStr(ColumnasDelGrid.FechaFactura)
        cmbCliente.Tag = CStr(ColumnasDelGrid.Cliente)
        txtCliente.Tag = CStr(ColumnasDelGrid.Cliente)
        txtIdCliente.Tag = CStr(ColumnasDelGrid.IdCliente)
        cmbComprobantes.Tag = CStr(ColumnasDelGrid.TipoComprobante)
        txtptovta.Tag = CStr(ColumnasDelGrid.PtoVta)
        txtNroFactura.Tag = CStr(ColumnasDelGrid.NroFactura)
        cmbCondVTA.Tag = CStr(ColumnasDelGrid.CondicionVta)
        txtCondicionIVA.Tag = CStr(ColumnasDelGrid.CondicionIVA)

        txtNota.Tag = CStr(ColumnasDelGrid.Nota)
        txtIdFacturaAnulada.Tag = CStr(ColumnasDelGrid.IdFacturaAnulada)

        txtDocTipo.Tag = CStr(ColumnasDelGrid.TipoDoc)
        txtComprobanteFacturacion.Tag = CStr(ColumnasDelGrid.ComprFacturacion)
        txtCUITCliente.Tag = CStr(ColumnasDelGrid.NroCuit)

        txtValorCambio.Tag = CStr(ColumnasDelGrid.ValorCambio)

    End Sub

    Private Sub Verificar_Datos()

        bolpoliticas = False

        Util.MsgStatus(Status1, "Verificando los datos...", My.Resources.Resources.indicator_white)

        Dim i As Integer
        Dim unremito As Boolean = False

        If editando_celda Then
            Util.MsgStatus(Status1, "Use [Enter] o [Tab] para salir del modo edici?n, antes de guardar.", My.Resources.Resources.alert.ToBitmap)
            Util.MsgStatus(Status1, "Use [Enter] o [Tab] para salir del modo edici?n, antes de guardar.", My.Resources.Resources.alert.ToBitmap, True)
            Exit Sub
        End If

        For i = 0 To grdRemitos.RowCount - 1
            If CBool(grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.Seleccionar).Value) = True Then
                unremito = True
            End If
        Next

        If unremito = False Then
            Util.MsgStatus(Status1, "Seleccione al menos un remito para facturar.", My.Resources.Resources.alert.ToBitmap)
            Util.MsgStatus(Status1, "Seleccione al menos un remito para facturar.", My.Resources.Resources.alert.ToBitmap, True)
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

    Private Sub PrepararGridItems()
        Util.LimpiarGridItems(grdItems)
        With (grdItems)
            .AllowUserToAddRows = False
        End With
    End Sub

    Private Sub LlenarGrid_Items()

        If grdItems.Columns.Count > 0 Then
            grdItems.Columns.Clear()
        End If

        SQL = "exec spFacturacion_ItemsporRemito "

        GetDatasetItems(grdItems)

        grdItems.Columns(ColumnasDelGridItems.IdPresGes).Visible = False  'Codigo material

        grdItems.Columns(ColumnasDelGridItems.Cod_Material).ReadOnly = True  'Codigo material
        grdItems.Columns(ColumnasDelGridItems.Cod_Material).Width = 70

        'grdItems.Columns(ColumnasDelGridItems.Nombre_Material).ReadOnly = True  'Codigo material
        grdItems.Columns(ColumnasDelGridItems.Nombre_Material).Width = 250

        grdItems.Columns(ColumnasDelGridItems.PrecioUni).ReadOnly = True 'precio unitario
        grdItems.Columns(ColumnasDelGridItems.PrecioUni).Width = 70
        grdItems.Columns(ColumnasDelGridItems.PrecioUni).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdItems.Columns(ColumnasDelGridItems.Qty).ReadOnly = True 'precio unitario
        grdItems.Columns(ColumnasDelGridItems.Qty).Width = 60
        grdItems.Columns(ColumnasDelGridItems.Qty).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdItems.Columns(ColumnasDelGridItems.Subtotal).ReadOnly = True 'subtotal
        grdItems.Columns(ColumnasDelGridItems.Subtotal).Width = 70
        grdItems.Columns(ColumnasDelGridItems.Subtotal).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdItems.Columns(ColumnasDelGridItems.TipoRemito).ReadOnly = True 'subtotal
        grdItems.Columns(ColumnasDelGridItems.TipoRemito).Width = 30

        lblCantidadFilas.Text = grdItems.RowCount.ToString + " / 16"

        With grdItems
            .VirtualMode = False
            .AllowUserToAddRows = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .RowsDefaultCellStyle.BackColor = Color.White
            .AllowUserToOrderColumns = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .ForeColor = Color.Black
        End With

        With grdItems.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Black  'Color.BlueViolet
            .ForeColor = Color.White
            .Font = New Font("TAHOMA", 8, FontStyle.Bold)
        End With
        grdItems.Font = New Font("TAHOMA", 8, FontStyle.Regular)

        'If chkAnulados.Checked = True Then
        'SQL = "spFacturacion_Select_All @Eliminado = 1"
        'Else
        SQL = "spFacturacion_Select_All @Eliminado = 0"
        'End If
    End Sub

    Private Sub LlenarGrid_Remitos(ByVal IdCliente As Long, ByVal Modo As Boolean, ByVal IdFacturacion As String, ByVal IdFacturaAnulada As String)

        SQL = "exec spRemitos_por_Presupuesto @IdCliente = " & IdCliente & ", @modo = " & Modo & ", @IdFacturacion = " & IIf(IdFacturacion = "", 0, IdFacturacion) & ", @IdFacturaAnulada = " & IIf(IdFacturaAnulada = "", 0, IdFacturaAnulada)

        GetDatasetItems(grdRemitos)

        grdRemitos.Columns(ColumnasDelGridRemitos.IdPresGes).Visible = False
        grdRemitos.Columns(ColumnasDelGridRemitos.IdPres).Visible = False

        grdRemitos.Columns(ColumnasDelGridRemitos.NroPres).Width = 55
        grdRemitos.Columns(ColumnasDelGridRemitos.NroPres).ReadOnly = True

        grdRemitos.Columns(ColumnasDelGridRemitos.NroRemito).Width = 55
        grdRemitos.Columns(ColumnasDelGridRemitos.NroRemito).ReadOnly = True

        'grdRemitos.Columns(ColumnasDelGridRemitos.Especial).Width = 35
        'grdRemitos.Columns(ColumnasDelGridRemitos.Especial).ReadOnly = True
        grdRemitos.Columns(ColumnasDelGridRemitos.Especial).Visible = False

        grdRemitos.Columns(ColumnasDelGridRemitos.CodMonedaPres).ReadOnly = True
        grdRemitos.Columns(ColumnasDelGridRemitos.CodMonedaPres).Width = 40
        grdRemitos.Columns(ColumnasDelGridRemitos.CodMonedaPres).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grdRemitos.Columns(ColumnasDelGridRemitos.Iva).Width = 40
        grdRemitos.Columns(ColumnasDelGridRemitos.Iva).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdRemitos.Columns(ColumnasDelGridRemitos.Iva).ReadOnly = True

        grdRemitos.Columns(ColumnasDelGridRemitos.SubtotalDO).Width = 75
        grdRemitos.Columns(ColumnasDelGridRemitos.SubtotalDO).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdRemitos.Columns(ColumnasDelGridRemitos.SubtotalDO).ReadOnly = True

        grdRemitos.Columns(ColumnasDelGridRemitos.SubtotalPE).Visible = False

        grdRemitos.Columns(ColumnasDelGridRemitos.MontoIvaDO).Width = 75
        grdRemitos.Columns(ColumnasDelGridRemitos.MontoIvaDO).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdRemitos.Columns(ColumnasDelGridRemitos.MontoIvaDO).ReadOnly = True

        grdRemitos.Columns(ColumnasDelGridRemitos.MontoIvaPE).Visible = False

        grdRemitos.Columns(ColumnasDelGridRemitos.TotalDO).Width = 75
        grdRemitos.Columns(ColumnasDelGridRemitos.TotalDO).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdRemitos.Columns(ColumnasDelGridRemitos.TotalDO).ReadOnly = True

        grdRemitos.Columns(ColumnasDelGridRemitos.TotalPE).Visible = False

        grdRemitos.Columns(ColumnasDelGridRemitos.OCRemito).Width = 75
        'grdRemitos.Columns(ColumnasDelGridRemitos.OCRemito).ReadOnly = True

        grdRemitos.Columns(ColumnasDelGridRemitos.Seleccionar).Width = 70

        grdRemitos.Columns(ColumnasDelGridRemitos.Nota_Gestion).Width = 300

        grdRemitos.Columns(ColumnasDelGridRemitos.EntregaPendiente).ReadOnly = True
        grdRemitos.Columns(ColumnasDelGridRemitos.EntregaPendiente).Width = 80

        grdRemitos.Columns(ColumnasDelGridRemitos.IdMonedaPres).Visible = False

        'grdRemitos.Columns(ColumnasDelGridRemitos.ValorCambio).ReadOnly = True
        'grdRemitos.Columns(ColumnasDelGridRemitos.ValorCambio).Width = 60
        'grdRemitos.Columns(ColumnasDelGridRemitos.ValorCambio).Width = 60

        With grdRemitos
            .VirtualMode = False
            .AllowUserToAddRows = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .RowsDefaultCellStyle.BackColor = Color.White
            .AllowUserToOrderColumns = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .ForeColor = Color.Black
        End With

        With grdRemitos.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Black  'Color.BlueViolet
            .ForeColor = Color.White
            .Font = New Font("TAHOMA", 8, FontStyle.Bold)
        End With

        grdRemitos.Font = New Font("TAHOMA", 8, FontStyle.Regular)

        'If chkAnulados.Checked = True Then
        'SQL = "EXEC spFacturacion_Select_All @Eliminado = 1 "
        'Else
        SQL = "EXEC spFacturacion_Select_All @Eliminado = 0 "

        Dim i As Integer

        For i = 0 To grdRemitos.RowCount - 1
            grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.Seleccionar).Style.BackColor = Color.Blue
        Next

        'End If

    End Sub

    Private Sub LlenarGrid_NC(ByVal IdCliente As Long)

        'If grdRemitos.Columns.Count > 0 Then
        '    grdRemitos.Columns.Clear()
        'End If

        SQL = "exec spNC_por_Cliente @IdCliente = " & IdCliente & ", @modo = " & bolModo & ", @IdFacturacion = " & IIf(txtID.Text = "", 0, txtID.Text)

        GetDatasetItems(grdRemitos)

        grdRemitos.Columns(ColumnasDelGridNC.IdNC).Visible = False
        grdRemitos.Columns(ColumnasDelGridNC.IdNC).Visible = False

        grdRemitos.Columns(ColumnasDelGridNC.IdFacturacion).Visible = False
        grdRemitos.Columns(ColumnasDelGridNC.IdFacturacion).Visible = False

        grdRemitos.Columns(ColumnasDelGridNC.NC).Width = 70

        grdRemitos.Columns(ColumnasDelGridNC.NroFactura).Width = 70

        grdRemitos.Columns(ColumnasDelGridNC.Subtotal).Width = 70
        grdRemitos.Columns(ColumnasDelGridNC.Subtotal).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdRemitos.Columns(ColumnasDelGridNC.Iva).Width = 50
        grdRemitos.Columns(ColumnasDelGridNC.Iva).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdRemitos.Columns(ColumnasDelGridNC.TotalIva).Width = 70
        grdRemitos.Columns(ColumnasDelGridNC.TotalIva).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdRemitos.Columns(ColumnasDelGridNC.Total).Width = 70
        grdRemitos.Columns(ColumnasDelGridNC.Total).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdRemitos.Columns(ColumnasDelGridNC.Seleccionar).Width = 70

        With grdRemitos
            .VirtualMode = False
            .AllowUserToAddRows = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .RowsDefaultCellStyle.BackColor = Color.White
            .AllowUserToOrderColumns = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .ForeColor = Color.Black
        End With

        With grdRemitos.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Black  'Color.BlueViolet
            .ForeColor = Color.White
            .Font = New Font("TAHOMA", 8, FontStyle.Bold)
        End With

        grdRemitos.Font = New Font("TAHOMA", 8, FontStyle.Regular)

        'If chkAnulados.Checked = True Then
        'SQL = "EXEC spFacturacion_Select_All @Eliminado = 1 "
        'Else
        SQL = "EXEC spFacturacion_Select_All @Eliminado = 0 "
        'End If

    End Sub

    Private Sub GetDatasetItems(ByVal grdchico As DataGridView)
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexi?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Sub

    Private Sub LlenarComboClientes()
        Dim ds_Cli As Data.DataSet
        Dim connection As SqlClient.SqlConnection = Nothing

        llenandoCombo = True

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexi?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            llenandoCombo = False
            Exit Sub
        End Try

        Try
            'ds_Cli = SqlHelper.ExecuteDataset(connection, CommandType.Text, "select DISTINCT c.id, c.nombre " & _
            '                " from Presupuestos_Gestion pg JOIN Presupuestos p ON p.id = pg.idPresupuesto " & _
            '                " JOIN Clientes c ON c.id = p.idcliente where p.eliminado=0 and Facturado= 0 and pg.eliminado = 0 order by C.NOMBRE")

            ds_Cli = SqlHelper.ExecuteDataset(connection, CommandType.Text, "select DISTINCT c.id,  RTRIM(LTRIM(c.nombre)) AS NOMBRE  " & _
                                                                            " from presupuestos_gestion pg LEFT JOIN Presupuestos p ON p.id = pg.idpresupuesto JOIN Clientes c " & _
                                                                            " ON c.id = pg.idcliente " & _
                                                                            " WHERE pg.eliminado = 0 And pg.Facturado = 0 And pg.ParaFacturacion = 1 " & _
                                                                            " AND ISNULL(P.FechaPresupuesto, '01/03/2016 00:00:00')  >= '01/03/2016 00:00:00' " & _
                                                                            " and c.Eliminado = 0 ORDER BY nombre")

            ds_Cli.Dispose()

            With Me.cmbCliente
                .DataSource = ds_Cli.Tables(0).DefaultView
                .DisplayMember = "nombre"
                .ValueMember = "id"
                '.AutoCompleteMode = AutoCompleteMode.Suggest
                '.AutoCompleteSource = AutoCompleteSource.ListItems
                '.DropDownStyle = ComboBoxStyle.DropDown
            End With

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            llenandoCombo = False

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

        llenandoCombo = False

    End Sub

    'Private Sub LlenarcmbClientes2()
    '    Dim ds_Clientes As Data.DataSet
    '    Dim connection As SqlClient.SqlConnection = Nothing

    '    llenandoCombo = True

    '    Try
    '        connection = SqlHelper.GetConnection(ConnStringSEI)
    '    Catch ex As Exception
    '        MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        llenandoCombo = False
    '        Exit Sub
    '    End Try

    '    Try
    '        'ds_Clientes = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT DISTINCT c.id, RTRIM(LTRIM(c.nombre)) AS NOMBRE FROM Clientes c JOIN Facturacion f on f.IDCLIENTE = C.ID" & _
    '        '                                      " WHERE f.eliminado = " & IIf(chkAnulados.Checked = False, 0, 1) & " AND manual = 0 and c.Eliminado = 0 ORDER BY nombre")

    '        ds_Clientes = SqlHelper.ExecuteDataset(connection, CommandType.Text, "select DISTINCT c.id,  RTRIM(LTRIM(c.nombre)) AS NOMBRE  " & _
    '                                                                            " from presupuestos_gestion pg JOIN Presupuestos p ON p.id = pg.idpresupuesto JOIN Clientes c " & _
    '                                                                            " ON c.id = p.idcliente " & _
    '                                                                            " WHERE pg.eliminado = 0 And pg.Facturado = 0 And pg.ParaFacturacion = 1 " & _
    '                                                                            " AND P.FechaPresupuesto >= '01/03/2016 00:00:00' " & _
    '                                                                            " and c.Eliminado = 0 ORDER BY nombre")

    '        '" AND f.eliminado = " & IIf(chkAnulados.Checked = False, 0, 1) & " AND manual = 0 and c.Eliminado = 0 ORDER BY nombre")

    '        ds_Clientes.Dispose()

    '        With cmbCliente2
    '            .DataSource = ds_Clientes.Tables(0).DefaultView
    '            .DisplayMember = "nombre"
    '            .ValueMember = "id"
    '            .AutoCompleteMode = AutoCompleteMode.Suggest
    '            .AutoCompleteSource = AutoCompleteSource.ListItems
    '            .TabStop = True
    '        End With

    '    Catch ex As Exception
    '        Dim errMessage As String = ""
    '        Dim tempException As Exception = ex

    '        llenandoCombo = False

    '        While (Not tempException Is Nothing)
    '            errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
    '            tempException = tempException.InnerException
    '        End While

    '        MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
    '          + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
    '          "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        If Not connection Is Nothing Then
    '            CType(connection, IDisposable).Dispose()
    '        End If
    '    End Try

    '    llenandoCombo = False

    'End Sub

    Private Sub Imprimir(ByVal NroComprobante As String, ByVal tipocomprobante As String)

        nbreformreportes = "Comprobante"

        Cursor = Cursors.WaitCursor

        Dim Rpt As New frmReportes
        Dim Rpt1 As New frmReportes

        Rpt1.NombreArchivoPDF = PTOVTA.ToString + "-" + NroComprobante.PadLeft(10, "0") + " - Comprobante Duplicado"
        Rpt1.MailDestinatario = txtemail.Text

        Rpt1.Factura_App(NroComprobante, Rpt1, 0, My.Application.Info.AssemblyName.ToString, "DUPLICADO", tipocomprobante, Empresa)

        Rpt.NombreArchivoPDF = PTOVTA.ToString + "-" + NroComprobante.PadLeft(10, "0") + " - Comprobante Original"
        Rpt.MailDestinatario = txtemail.Text

        Rpt.Factura_App(NroComprobante, Rpt, 0, My.Application.Info.AssemblyName.ToString, "ORIGINAL", tipocomprobante, Empresa)

        Cursor = Cursors.Default

    End Sub

    Private Sub Buscar_DatosClientes()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT CUIT, TD.Descripcion, td.codigo as CodDocTipo, c.email FROM CLIENTES c JOIN tipodocumento TD on TD.codigo = c.tipodocumento WHERE c.id = " & CType(cmbCliente.SelectedValue, Long))

            ds.Dispose()

            txtCUITCliente.Text = ds.Tables(0).Rows(0).Item(0).ToString
            txtDocTipo.Text = ds.Tables(0).Rows(0).Item(1).ToString
            txtCodDocTipo.Text = ds.Tables(0).Rows(0).Item(2).ToString
            txtemail.Text = ds.Tables(0).Rows(0).Item(3).ToString

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Public Sub LlenarCmbComprobantes()
        Dim connection As SqlClient.SqlConnection = Nothing

        llenandoCombo = True

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            Dim ds As Data.DataSet = Nothing

            If cmbTipoComprobante.SelectedValue = 2 Or cmbTipoComprobante.SelectedValue = 3 Then
                ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT ComprobanteTipo, Nrofactura FROM Facturacion WHERE ComprobanteTipo = 1 AND Ptovta = " & PTOVTA & " AND ID NOT IN ( SELECT IdFacturaAnulada FROM Facturacion WHERE IdFacturaAnulada IS NOT NULL) ORDER BY Nrofactura DESC")
                'ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT Id, Nrofactura FROM Facturacion WHERE ComprobanteTipo = 1 AND Ptovta = " & PTOVTA & " AND ID NOT IN ( SELECT IdFacturaAnulada FROM Facturacion WHERE IdFacturaAnulada IS NOT NULL) ORDER BY Nrofactura DESC")
                ds.Dispose()
            End If

            If cmbTipoComprobante.SelectedValue = 7 Or cmbTipoComprobante.SelectedValue = 8 Then
                ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT ComprobanteTipo, Nrofactura FROM Facturacion WHERE ComprobanteTipo = 6 AND Ptovta = " & PTOVTA & " AND ID NOT IN ( SELECT IdFacturaAnulada FROM Facturacion WHERE IdFacturaAnulada IS NOT NULL) ORDER BY Nrofactura DESC")
                'ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT id, Nrofactura FROM Facturacion WHERE ComprobanteTipo = 6 AND Ptovta = " & PTOVTA & " AND ID NOT IN ( SELECT IdFacturaAnulada FROM Facturacion WHERE IdFacturaAnulada IS NOT NULL) ORDER BY Nrofactura DESC")
                ds.Dispose()
            End If


            With Me.cmbComprobantes
                .DataSource = ds.Tables(0).DefaultView
                .DisplayMember = "Nrofactura"
                '.ValueMember = "Id"
                .ValueMember = "ComprobanteTipo"
            End With

            If ds.Tables(0).Rows.Count > 0 Then
                cmbComprobantes.SelectedIndex = 0
            End If

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

        llenandoCombo = False

    End Sub

    Public Sub LlenarCamposConsumo(ByVal NroFactura As Integer, ByVal TipoFactura As String)
        'Public Sub LlenarCamposConsumo(ByVal IdFactura As Long)
        Dim ds As Data.DataSet

        Try

            ds = SqlHelper.ExecuteDataset(conn_del_form, CommandType.Text, "SELECT CO.id, C.Nombre, tp.Descripcion, C.cuit, co.condicioniva, C.Direccion, " + _
                                                "   CO.CondicionVta, CO.ConceptoTipo, CO.Fecha_Serv_Desde, CO.Fecha_Serv_Hasta, CO.Fecha_Vto_Pago, " + _
                                                "   Co.MontoIva, CO.SubTotal, CO.Total, c.id as IdCliente " + _
                                                "   FROM Facturacion CO " + _
                                                "       JOIN Clientes C ON C.ID = CO.IDCliente " + _
                                                "       JOIN Comprobantes cp ON convert(int, cp.codigo) = co.comprobantetipo " + _
                                                "       JOIN TipoDocumento tp ON tp.Codigo = C.TipoDocumento " + _
                                                "   WHERE CO.Nrofactura = " & NroFactura.ToString + _
                                                "       AND cp.codigo = " & TipoFactura)

            '"   WHERE CO.ID = " & IdFactura.ToString)
            ds.Dispose()

            If ds.Tables(0).Rows.Count = 0 Then
                Exit Sub
            Else

                LlenarGrid_Remitos(ds.Tables(0).Rows(0).Item(14).ToString, False, ds.Tables(0).Rows(0).Item(0).ToString, "")

                AgregarRemito_tmp()

                LlenarGrid_Items()

                IdFacturaAnulada = ds.Tables(0).Rows(0).Item(0).ToString
                txtCliente.Text = ds.Tables(0).Rows(0).Item(1).ToString
                txtIdCliente.Text = ds.Tables(0).Rows(0).Item(14).ToString
                txtDocTipo.Text = ds.Tables(0).Rows(0).Item(2).ToString
                txtCUITCliente.Text = ds.Tables(0).Rows(0).Item(3).ToString
                txtCondicionIVA.Text = ds.Tables(0).Rows(0).Item(4).ToString
                txtDireccion.Text = ds.Tables(0).Rows(0).Item(5).ToString
                cmbCondVTA.Text = ds.Tables(0).Rows(0).Item(6).ToString
                cmbConceptos.Text = ds.Tables(0).Rows(0).Item(7).ToString

                dtpServicioDesde.Value = ds.Tables(0).Rows(0).Item(8).ToString
                dtpServicioHasta.Value = ds.Tables(0).Rows(0).Item(9).ToString
                dtpVtoPago.Value = ds.Tables(0).Rows(0).Item(10).ToString

                txtptovta.Text = PTOVTA

            End If

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub CalcularMontos()

        Dim I As Integer
        Dim subtotal As Double = 0, total As Double = 0, MONTOiva As Double = 0

        For I = 0 To grdRemitos.RowCount - 1
            If CBool(grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.Seleccionar).Value) = True Then

                If grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.IdMonedaPres).Value = 0 Then
                    If CDbl(grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.SubtotalPE).Value) = 0 Then
                        subtotal = subtotal + Format(grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.SubtotalDO).Value * txtValorCambio.Text, "####0.00")
                    Else
                        subtotal = subtotal + grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.SubtotalPE).Value
                    End If
                Else
                    If grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.CodMonedaPres).Value = "Do" Then
                        subtotal = subtotal + Format(grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.SubtotalDO).Value * txtValorCambio.Text, "####0.00")
                    Else
                        subtotal = subtotal + Format(grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.SubtotalDO).Value, "####0.00")
                    End If
                End If
            End If
        Next

        MONTOiva = subtotal * (IVA / 100)
        total = subtotal + MONTOiva

        lblSubtotal.Text = Format(subtotal, "####0.00")
        lblPorcIva.Text = IVA.ToString
        lblIVA.Text = Format(MONTOiva, "####0.00")
        lblTotal.Text = Format(total, "####0.00")

    End Sub

#End Region

#Region "   Funciones"

    '    Private Function FEAFIP() As Integer

    '        Dim CaeGenerado As String
    '        Dim FechaGenerado As String

    '        Try

    '            tipo_cbte = CInt(cmbTipoComprobante.SelectedValue)
    '            cbte_nro = CInt(txtNroFactura.Text) 'param

    '            punto_vta = CInt(txtptovta.Text) 'param

    '            fecha = Format(dtpFECHA.Value.Date, "yyyyMMdd") 'param
    '            concepto = CInt(cmbConceptos.SelectedValue) 'param
    '            tipo_doc = CInt(txtCodDocTipo.Text) 'param
    '            nro_doc = txtCUITCliente.Text 'param

    '            cbt_desde = cbte_nro 'param
    '            cbt_hasta = cbte_nro 'param

    '            imp_trib = "0.00"
    '            imp_op_ex = "0.00"

    '            If cmbTipoComprobante.SelectedValue = TipoComp.FacturaA Or cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoA Or _
    '                cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoA Then

    '                imp_tot_conc = "0.00"
    '                imp_neto = Replace(lblSubtotal.Text, ",", "") 'param 
    '            End If

    '            If cmbTipoComprobante.SelectedValue = TipoComp.FacturaB Or cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoB Or _
    '                cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoB Then

    '                imp_tot_conc = Replace(lblSubtotal.Text, ",", "") 'param
    '                imp_neto = "0.00"
    '            End If

    '            imp_iva = FormatNumber(lblIVA.Text, 2) 'FormatNumber(CDec(txtIva21.Text) + CDec(txtIva10.Text), 2) 'param
    '            imp_iva = Replace(imp_iva, ",", "")

    '            imp_total = Replace(lblTotal.Text, ",", "") 'param

    '            fecha_cbte = fecha

    '            ' Fechas del per?odo del servicio facturado (solo si concepto = 1?)
    '            If CInt(cmbConceptos.SelectedValue) = 2 Or CInt(cmbConceptos.SelectedValue) = 3 Then
    '                fecha_venc_pago = Format(dtpVtoPago.Value.Date, "yyyyMMdd")
    '                fecha_serv_desde = Format(dtpServicioDesde.Value.Date, "yyyyMMdd")
    '                fecha_serv_hasta = Format(dtpServicioHasta.Value.Date, "yyyyMMdd")
    '            Else
    '                fecha_venc_pago = ""
    '                fecha_serv_desde = ""
    '                fecha_serv_hasta = ""
    '            End If

    '            moneda_id = "PES" : moneda_ctz = "1.000"

    '            ok = wsfev1.CrearFactura(concepto, tipo_doc, nro_doc, tipo_cbte, punto_vta, _
    '                    cbt_desde, cbt_hasta, imp_total, imp_tot_conc, imp_neto, _
    '                    imp_iva, imp_trib, imp_op_ex, fecha_cbte, fecha_venc_pago, _
    '                    fecha_serv_desde, fecha_serv_hasta, _
    '                    moneda_id, moneda_ctz)

    '            Dim i As Integer
    '            Dim CantidadFilas As Integer

    '            If grdItems.RowCount = 16 Then
    '                CantidadFilas = grdRemitos.Rows.Count
    '            Else
    '                CantidadFilas = grdRemitos.Rows.Count - 1
    '            End If

    '            Dim total10 As Decimal
    '            Dim total21 As Decimal

    '            If cmbTipoComprobante.SelectedValue = TipoComp.FacturaA Or cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoA Or _
    '                cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoA Then

    '                ' Agrego tasas de IVA
    '                i = 0
    '                Do While i <= CantidadFilas
    '                    If CBool(grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.Seleccionar).Value) = True Then
    '                        If CDbl(grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.Iva).Value) = 10.5 Then
    '                            total10 += grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.SubtotalDO).Value
    '                        End If
    '                        If CDbl(grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.Iva).Value) = 21 Then
    '                            total21 += grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.SubtotalDO).Value
    '                        End If
    '                    End If
    '                    i += 1
    '                Loop

    '                If total10 > 0 Then
    '                    id = 4 ' 10.5%
    '                    base_imp = total10.ToString 'param
    '                    importe = Replace(lblIVA.Text, ",", "") 'param
    '                    ok = wsfev1.AgregarIva(id, base_imp, importe)
    '                End If

    '                If total21 > 0 Then
    '                    id = 5 ' 21%
    '                    base_imp = total21.ToString 'param
    '                    importe = Replace(lblIVA.Text, ",", "") 'param
    '                    ok = wsfev1.AgregarIva(id, base_imp, importe)
    '                End If

    '            End If


    '            ' Agrego los comprobantes asociados: ' solo nc/nd
    '            If CInt(cmbTipoComprobante.SelectedValue) = TipoComp.NotaDebitoA Or _
    '                CInt(cmbTipoComprobante.SelectedValue) = TipoComp.NotaCreditoA Or _
    '                CInt(cmbTipoComprobante.SelectedValue) = TipoComp.NotaDebitoB Or _
    '                CInt(cmbTipoComprobante.SelectedValue) = TipoComp.NotaCreditoB Then
    '                tipo = CInt(cmbComprobantes.SelectedValue)
    '                pto_vta = CInt(txtptovta.Text) 'param
    '                nro = CInt(cmbComprobantes.Text)
    '                ok = wsfev1.AgregarCmpAsoc(tipo, pto_vta, nro)
    '            End If

    '            ' Habilito reprocesamiento autom?tico (predeterminado):
    '            wsfev1.Reprocesar = True

    '            ' Solicito CAE:
    '            cae = wsfev1.CAESolicitar()

    '            If wsfev1.Resultado = "A" Then

    '                CaeGenerado = wsfev1.CAE.ToString
    '                FechaGenerado = wsfev1.Vencimiento.ToString

    'ContinuarFactura:
    '                Cerrar_Tran()

    '                'MsgBox("Factura Aceptada" + Chr(13) + "CAE: " + wsfev1.CAE.ToString + Chr(13) + "Vencimiento: " + wsfev1.Vencimiento.ToString)

    '                MsgBox("Factura Aceptada" + Chr(13) + "CAE: " + CaeGenerado + Chr(13) + "Vencimiento: " + FechaGenerado)

    '                'Select Case ActualizarFacturacion_FEAFIP(wsfev1.CAE.ToString, wsfev1.Vencimiento.ToString)
    '                Select Case ActualizarFacturacion_FEAFIP(CaeGenerado, FechaGenerado)
    '                    Case Is <= 0
    '                        FEAFIP = -1
    '                    Case Else
    '                        FEAFIP = 1
    '                End Select

    '            Else

    '                'Error/obs
    '                If wsfev1.ErrMsg <> "" Then
    '                    MsgBox(wsfev1.ErrMsg, vbExclamation, "Errores")
    '                End If

    '                If wsfev1.Obs <> "" Then
    '                    MsgBox(wsfev1.Obs, vbExclamation, "Observaciones")
    '                End If

    '                MsgBox(wsfev1.resultado.ToString)
    '                FEAFIP = -2

    '            End If

    '        Catch ex As Exception

    '            cae2 = wsfev1.Compconsultar(Me.cmbTipoComprobante.SelectedValue, PTOVTA, txtNroFactura.Text)

    '            If cae2.ToString <> "" And wsfev1.vencimiento <> "" Then
    '                CaeGenerado = cae2.ToString
    '                FechaGenerado = wsfev1.vencimiento
    '                GoTo ContinuarFactura
    '            End If

    '            If wsfev1.Traceback <> "" Then
    '                MsgBox(wsfev1.Traceback, vbExclamation, "Error")
    '            End If
    '            FEAFIP = -2

    '        End Try

    '    End Function

    'Public Function ConexionAfip() As Boolean

    '    'FACTURA ELECTRONICA
    '    '
    '    ' Crear objeto interface Web Service Autenticaci?n y Autorizaci?n
    '    WSAA = CreateObject("WSAA")

    '    Try
    '        tra = WSAA.CreateTRA("wsfe")

    '        Path = Application.StartupPath + "\AFIP\"

    '        ' Certificado: certificado es el firmado por la AFIP
    '        ' ClavePrivada: la clave privada usada para crear el certificado
    '        If HOMO = True Then
    '            certificado = Empresa + "_homo.crt"
    '            claveprivada = Empresa + "_homo.key"
    '        Else
    '            certificado = Empresa + ".crt"
    '            claveprivada = Empresa + ".key"
    '        End If

    '        cms = WSAA.SignTRA(tra, Path + certificado, Path + claveprivada)

    '        cache = ""
    '        proxy = ""

    '        If HOMO = True Then
    '            wsdl = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms?wsdl"
    '        Else
    '            wsdl = "https://wsaa.afip.gov.ar/ws/services/LoginCms?wsdl"
    '        End If

    '        WSAA.Conectar(cache, wsdl, proxy)
    '        ta = WSAA.LoginCMS(cms)

    '        'MessageBox.Show(ta, "Ticket de Acceso")
    '        If TicketAcceso = True Then
    '            MsgBox(ta.ToString)
    '        End If

    '    Catch
    '        ' Muestro los errores
    '        If WSAA.Excepcion <> "" Then
    '            MsgBox(WSAA.Traceback, vbExclamation, WSAA.Excepcion)
    '            'MsgBox(WSAA.Excepcion, vbExclamation, WSAA.Excepcion)
    '        End If
    '    End Try

    '    wsfev1 = CreateObject("WSFEv1")

    '    Try

    '        ' Setear tocken y sing de autorizaci?n (pasos previos)
    '        wsfev1.Token = WSAA.Token
    '        wsfev1.Sign = WSAA.Sign

    '        wsfev1.Cuit = cuitEmpresa

    '        ' Conectar al Servicio Web de Facturaci?n
    '        proxy = "" ' "usuario:clave@localhost:8000"

    '        If HOMO = True Then
    '            wsdl = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx?WSDL"
    '        Else
    '            wsdl = "https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL"
    '        End If

    '        cache = "" 'Path
    '        ok = wsfev1.Conectar(cache, wsdl, proxy) ' homologaci?n

    '        REM ' Llamo a un servicio nulo, para obtener el estado del servidor (opcional)
    '        Try
    '            wsfev1.Dummy()
    '            imgConexion.Image = My.Resources.Green_Ball_icon
    '        Catch ex As Exception
    '            imgConexion.Image = My.Resources.Red_Ball_icon
    '            ConexionAfip = False
    '            Exit Function
    '        End Try

    '        If wsfev1.ErrMsg <> "" Then
    '            MsgBox(wsfev1.ErrMsg, vbExclamation, "Errores")
    '            'ConexionAfip = False
    '            'Exit Function
    '        End If

    '        If wsfev1.Obs <> "" Then
    '            MsgBox(wsfev1.Obs, vbExclamation, "Observaciones")
    '            'ConexionAfip = False
    '            'Exit Function
    '        End If

    '    Catch

    '        ' Muestro los errores
    '        If wsfev1.Traceback <> "" Then
    '            MsgBox(wsfev1.Traceback, vbExclamation, "Error")
    '            ConexionAfip = False
    '            Exit Function
    '        End If

    '    End Try

    '    ConexionAfip = True

    'End Function

    'Public Function ProbarConexion() As Boolean

    '    Try
    '        wsfev1.Dummy()
    '        imgConexion.Image = My.Resources.Green_Ball_icon
    '        Return True
    '    Catch ex As Exception
    '        imgConexion.Image = My.Resources.Red_Ball_icon
    '        Return False
    '    End Try

    'End Function

    Private Function AgregarRegistro(ByVal Reutilizar As Boolean) As Integer
        Dim res As Integer = 0

        Try
            Try
                conn_del_form = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End Try

            'Abrir una transaccion para guardar y asegurar que se guarda todo
            If Abrir_Tran(conn_del_form) = False Then
                MessageBox.Show("No se pudo abrir una transaccion", "Error de conexi?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If

            Try
                Dim param_id As New SqlClient.SqlParameter
                param_id.ParameterName = "@id"
                param_id.SqlDbType = SqlDbType.BigInt
                param_id.Value = DBNull.Value
                param_id.Direction = ParameterDirection.InputOutput

                Dim param_codigo As New SqlClient.SqlParameter
                param_codigo.ParameterName = "@codigo"
                param_codigo.SqlDbType = SqlDbType.BigInt
                param_codigo.Value = DBNull.Value
                param_codigo.Direction = ParameterDirection.InputOutput

                Dim param_nrofactura As New SqlClient.SqlParameter
                param_nrofactura.ParameterName = "@nrofactura"
                param_nrofactura.SqlDbType = SqlDbType.BigInt
                param_nrofactura.Value = txtNroFactura.Text
                param_nrofactura.Direction = ParameterDirection.Input

                Dim param_fecha As New SqlClient.SqlParameter
                param_fecha.ParameterName = "@fechafactura"
                param_fecha.SqlDbType = SqlDbType.DateTime
                param_fecha.Value = dtpFECHA.Value
                param_fecha.Direction = ParameterDirection.Input

                Dim param_idcliente As New SqlClient.SqlParameter
                param_idcliente.ParameterName = "@idcliente"
                param_idcliente.SqlDbType = SqlDbType.BigInt
                param_idcliente.Value = txtIdCliente.Text 'cmbCliente.SelectedValue
                param_idcliente.Direction = ParameterDirection.Input

                Dim param_iva As New SqlClient.SqlParameter
                param_iva.ParameterName = "@iva"
                param_iva.SqlDbType = SqlDbType.Decimal
                param_iva.Precision = 18
                param_iva.Scale = 2
                param_iva.Value = IVA '21
                param_iva.Direction = ParameterDirection.Input

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

                Dim param_condicionVta As New SqlClient.SqlParameter
                param_condicionVta.ParameterName = "@CondicionVta"
                param_condicionVta.SqlDbType = SqlDbType.VarChar
                param_condicionVta.Size = 20
                param_condicionVta.Value = cmbCondVTA.Text
                param_condicionVta.Direction = ParameterDirection.Input

                Dim param_condicionIVA As New SqlClient.SqlParameter
                param_condicionIVA.ParameterName = "@CondicionIVA"
                param_condicionIVA.SqlDbType = SqlDbType.VarChar
                param_condicionIVA.Size = 50
                param_condicionIVA.Value = txtCondicionIVA.Text
                param_condicionIVA.Direction = ParameterDirection.Input

                Dim param_remitos As New SqlClient.SqlParameter
                param_remitos.ParameterName = "@remitos"
                param_remitos.SqlDbType = SqlDbType.VarChar
                param_remitos.Size = 300
                param_remitos.Value = RemitosAsociados
                param_remitos.Direction = ParameterDirection.Input

                Dim param_remitos1 As New SqlClient.SqlParameter
                param_remitos1.ParameterName = "@remitos1"
                param_remitos1.SqlDbType = SqlDbType.VarChar
                param_remitos1.Size = 300
                param_remitos1.Value = RemitosAsociados
                param_remitos1.Direction = ParameterDirection.Input

                Dim param_nrocomprobante As New SqlClient.SqlParameter
                param_nrocomprobante.ParameterName = "@nrocomprobante"
                param_nrocomprobante.SqlDbType = SqlDbType.VarChar
                param_nrocomprobante.Size = 100
                param_nrocomprobante.Value = txtComprobanteFacturacion.Text ', DBNull.Value, txtComprobante.Text)
                param_nrocomprobante.Direction = ParameterDirection.Input

                Dim param_nota As New SqlClient.SqlParameter
                param_nota.ParameterName = "@nota"
                param_nota.SqlDbType = SqlDbType.VarChar
                param_nota.Size = 300
                param_nota.Value = txtNota.Text ', DBNull.Value, txtComprobante.Text)
                param_nota.Direction = ParameterDirection.Input

                Dim param_Manual As New SqlClient.SqlParameter
                param_Manual.ParameterName = "@Manual"
                param_Manual.SqlDbType = SqlDbType.Bit
                param_Manual.Value = False
                param_Manual.Direction = ParameterDirection.Input

                Dim param_FacturadaAnulada As New SqlClient.SqlParameter
                param_FacturadaAnulada.ParameterName = "@FacturaAnulada"
                param_FacturadaAnulada.SqlDbType = SqlDbType.Bit
                If cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoA Or cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoB Or _
                        cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoA Or cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoB Then
                    param_FacturadaAnulada.Value = True
                Else
                    param_FacturadaAnulada.Value = False
                End If
                param_FacturadaAnulada.Direction = ParameterDirection.Input

                Dim param_idFacturaAnulada As New SqlClient.SqlParameter
                param_idFacturaAnulada.ParameterName = "@idfacturaAnulada"
                param_idFacturaAnulada.SqlDbType = SqlDbType.BigInt
                If cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoA Or cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoB Or _
                       cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoA Or cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoB Then
                    param_idFacturaAnulada.Value = IdFacturaAnulada 'cmbComprobantes.SelectedValue
                Else
                    param_idFacturaAnulada.Value = DBNull.Value
                End If
                param_idFacturaAnulada.Direction = ParameterDirection.Input

                Dim param_ValorCambioFacturado As New SqlClient.SqlParameter
                param_ValorCambioFacturado.ParameterName = "@ValorCambio"
                param_ValorCambioFacturado.SqlDbType = SqlDbType.Decimal
                param_ValorCambioFacturado.Precision = 18
                param_ValorCambioFacturado.Scale = 3
                param_ValorCambioFacturado.Value = txtValorCambio.Text
                param_ValorCambioFacturado.Direction = ParameterDirection.Input

                Dim param_ComprobanteTipo As New SqlClient.SqlParameter
                param_ComprobanteTipo.ParameterName = "@ComprobanteTipo"
                param_ComprobanteTipo.SqlDbType = SqlDbType.Int
                param_ComprobanteTipo.Value = cmbTipoComprobante.SelectedValue
                param_ComprobanteTipo.Direction = ParameterDirection.Input

                Dim param_ComprobanteNroNCND As New SqlClient.SqlParameter
                param_ComprobanteNroNCND.ParameterName = "@ComprobanteNroNCND"
                param_ComprobanteNroNCND.SqlDbType = SqlDbType.BigInt
                If cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoA Or cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoB Or _
                        cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoA Or cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoB Then
                    param_ComprobanteNroNCND.Value = CInt(cmbComprobantes.Text.ToString)
                Else
                    param_ComprobanteNroNCND.Value = DBNull.Value
                End If
                param_ComprobanteNroNCND.Direction = ParameterDirection.Input

                Dim param_ptovta As New SqlClient.SqlParameter
                param_ptovta.ParameterName = "@ptovta"
                param_ptovta.SqlDbType = SqlDbType.Int
                param_ptovta.Value = CInt(txtptovta.Text)
                param_ptovta.Direction = ParameterDirection.Input

                Dim param_conceptotipo As New SqlClient.SqlParameter
                param_conceptotipo.ParameterName = "@conceptotipo"
                param_conceptotipo.SqlDbType = SqlDbType.Int
                param_conceptotipo.Value = CInt(cmbConceptos.SelectedValue)
                param_conceptotipo.Direction = ParameterDirection.Input

                Dim param_formapago As New SqlClient.SqlParameter
                param_formapago.ParameterName = "@formapago"
                param_formapago.SqlDbType = SqlDbType.VarChar
                param_formapago.Size = 50
                param_formapago.Value = cmbCondVTA.Text
                param_formapago.Direction = ParameterDirection.Input

                Dim param_Fecha_Vto_Pago As New SqlClient.SqlParameter
                param_Fecha_Vto_Pago.ParameterName = "@Fecha_Vto_Pago"
                param_Fecha_Vto_Pago.SqlDbType = SqlDbType.Date
                param_Fecha_Vto_Pago.Value = dtpVtoPago.Value.Date
                param_Fecha_Vto_Pago.Direction = ParameterDirection.Input

                Dim param_Fecha_Serv_Desde As New SqlClient.SqlParameter
                param_Fecha_Serv_Desde.ParameterName = "@Fecha_Serv_Desde"
                param_Fecha_Serv_Desde.SqlDbType = SqlDbType.Date
                param_Fecha_Serv_Desde.Value = dtpServicioDesde.Value.Date
                param_Fecha_Serv_Desde.Direction = ParameterDirection.Input

                Dim param_Fecha_Serv_Hasta As New SqlClient.SqlParameter
                param_Fecha_Serv_Hasta.ParameterName = "@Fecha_Serv_Hasta"
                param_Fecha_Serv_Hasta.SqlDbType = SqlDbType.Date
                param_Fecha_Serv_Hasta.Value = dtpServicioHasta.Value.Date
                param_Fecha_Serv_Hasta.Direction = ParameterDirection.Input

                Dim param_Reutilizar As New SqlClient.SqlParameter
                param_Reutilizar.ParameterName = "@Reutilizar"
                param_Reutilizar.SqlDbType = SqlDbType.Bit
                param_Reutilizar.Value = Reutilizar
                param_Reutilizar.Direction = ParameterDirection.Input

                Dim param_useradd As New SqlClient.SqlParameter
                param_useradd.ParameterName = "@useradd"
                param_useradd.SqlDbType = SqlDbType.Int
                param_useradd.Value = UserID
                param_useradd.Direction = ParameterDirection.Input

                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.InputOutput

                Try
                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spFacturacion_Insert", _
                                            param_id, param_codigo, param_nrofactura, param_ComprobanteNroNCND, param_fecha, param_idcliente, _
                                            param_iva, param_montoiva, param_subtotal, param_total, param_condicionVta, param_condicionIVA, _
                                            param_remitos, param_remitos1, param_nrocomprobante, param_nota, _
                                            param_Manual, param_FacturadaAnulada, param_idFacturaAnulada, _
                                            param_ComprobanteTipo, param_ptovta, param_conceptotipo, param_Fecha_Vto_Pago, _
                                            param_Fecha_Serv_Desde, param_Fecha_Serv_Hasta, param_ValorCambioFacturado, _
                                            param_Reutilizar, param_useradd, param_res)

                    txtID.Text = param_id.Value

                    txtCODIGO.Text = param_codigo.Value

                    res = param_res.Value

                    AgregarRegistro = res

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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Function

    Private Function ActualizarRegistro() As Integer
        Dim res As Integer = 0
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End Try

        'Abrir una transaccion para guardar y asegurar que se guarda todo
        If Abrir_Tran(connection) = False Then
            MessageBox.Show("No se pudo abrir una transaccion", "Error de conexi?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End If

        Try
            Dim param_id As New SqlClient.SqlParameter
            param_id.ParameterName = "@id"
            param_id.SqlDbType = SqlDbType.BigInt
            param_id.Value = txtID.Text
            param_id.Direction = ParameterDirection.Input

            'Dim param_nrofactura As New SqlClient.SqlParameter
            'param_nrofactura.ParameterName = "@nrofactura"
            'param_nrofactura.SqlDbType = SqlDbType.BigInt
            'param_nrofactura.Value = txtNroFactura.Text
            'param_nrofactura.Direction = ParameterDirection.Input

            'Dim param_fecha As New SqlClient.SqlParameter
            'param_fecha.ParameterName = "@fechafactura"
            'param_fecha.SqlDbType = SqlDbType.DateTime
            'param_fecha.Value = dtpFECHA.Value
            'param_fecha.Direction = ParameterDirection.Input

            'Dim param_idcliente As New SqlClient.SqlParameter
            'param_idcliente.ParameterName = "@idcliente"
            'param_idcliente.SqlDbType = SqlDbType.BigInt
            'param_idcliente.Value = cmbCliente.SelectedValue
            'param_idcliente.Direction = ParameterDirection.Input

            'Dim param_condicionVta As New SqlClient.SqlParameter
            'param_condicionVta.ParameterName = "@CondicionVta"
            'param_condicionVta.SqlDbType = SqlDbType.VarChar
            'param_condicionVta.Size = 20
            'param_condicionVta.Value = cmbCondVTA.Text
            'param_condicionVta.Direction = ParameterDirection.Input

            'Dim param_condicionIVA As New SqlClient.SqlParameter
            'param_condicionIVA.ParameterName = "@CondicionIVA"
            'param_condicionIVA.SqlDbType = SqlDbType.VarChar
            'param_condicionIVA.Size = 50
            'param_condicionIVA.Value = txtCondicionIVA.Text
            'param_condicionIVA.Direction = ParameterDirection.Input

            Dim param_nrocomprobante As New SqlClient.SqlParameter
            param_nrocomprobante.ParameterName = "@nrocomprobante"
            param_nrocomprobante.SqlDbType = SqlDbType.VarChar
            param_nrocomprobante.Size = 50
            param_nrocomprobante.Value = txtComprobanteFacturacion.Text ', DBNull.Value, txtComprobante.Text)
            param_nrocomprobante.Direction = ParameterDirection.Input

            Dim param_nroOC As New SqlClient.SqlParameter
            param_nroOC.ParameterName = "@nroOC"
            param_nroOC.SqlDbType = SqlDbType.VarChar
            param_nroOC.Size = 50
            param_nroOC.Value = txtOC.Text ', DBNull.Value, txtComprobante.Text)
            param_nroOC.Direction = ParameterDirection.Input

            Dim param_nota As New SqlClient.SqlParameter
            param_nota.ParameterName = "@nota"
            param_nota.SqlDbType = SqlDbType.VarChar
            param_nota.Size = 300
            param_nota.Value = txtNota.Text ', DBNull.Value, txtComprobante.Text)
            param_nota.Direction = ParameterDirection.Input

            Dim param_userupd As New SqlClient.SqlParameter
            param_userupd.ParameterName = "@userupd"
            param_userupd.SqlDbType = SqlDbType.Int
            param_userupd.Value = UserID
            param_userupd.Direction = ParameterDirection.Input

            Dim param_res As New SqlClient.SqlParameter
            param_res.ParameterName = "@res"
            param_res.SqlDbType = SqlDbType.Int
            param_res.Value = DBNull.Value
            param_res.Direction = ParameterDirection.InputOutput

            Try
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spFacturacion_Update", _
                                          param_id, param_nrocomprobante, param_nroOC, param_nota, param_userupd, param_res)
                'param_TextoSobre, param_MasLineas, param_Linea1, param_Linea2, 
                'param_nrofactura, param_fecha, param_condicionIVA,

                ActualizarRegistro = param_res.Value

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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function ActualizarRegistro_Presupuestos() As Integer
        Dim res As Integer = 0
        Dim i As Integer

        Try
            Try
                For i = 0 To grdRemitos.RowCount - 1

                    Dim param_idpresges As New SqlClient.SqlParameter
                    param_idpresges.ParameterName = "@idpresges"
                    param_idpresges.SqlDbType = SqlDbType.BigInt
                    param_idpresges.Value = grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.IdPresGes).Value
                    param_idpresges.Direction = ParameterDirection.Input

                    Dim param_nrocomprobante As New SqlClient.SqlParameter
                    param_nrocomprobante.ParameterName = "@nrocomprobante"
                    param_nrocomprobante.SqlDbType = SqlDbType.VarChar
                    param_nrocomprobante.Size = 50
                    param_nrocomprobante.Value = txtOC.Text '= "", DBNull.Value, txtComprobante.Text)
                    param_nrocomprobante.Direction = ParameterDirection.Input

                    Dim param_userupd As New SqlClient.SqlParameter
                    param_userupd.ParameterName = "@userupd"
                    param_userupd.SqlDbType = SqlDbType.Int
                    param_userupd.Value = UserID
                    param_userupd.Direction = ParameterDirection.Input

                    Dim param_res As New SqlClient.SqlParameter
                    param_res.ParameterName = "@res"
                    param_res.SqlDbType = SqlDbType.Int
                    param_res.Value = DBNull.Value
                    param_res.Direction = ParameterDirection.InputOutput

                    Try
                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spFacturacion_Update_Presupuestos", _
                                                  param_idpresges, param_nrocomprobante, param_userupd, param_res)

                        res = param_res.Value

                        If (res <= 0) Then
                            Exit For
                        End If

                    Catch ex As Exception
                        Throw ex
                    End Try

                Next

                ActualizarRegistro_Presupuestos = res

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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function AgregarRegistro_RemitosAsociados() As Integer
        Dim res As Integer = 0
        Dim i As Integer

        Try
            Try
                For i = 0 To grdRemitos.RowCount - 1

                    If CBool(grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.Seleccionar).Value) = True Then

                        Dim param_idfacturacion As New SqlClient.SqlParameter
                        param_idfacturacion.ParameterName = "@idfacturacion"
                        param_idfacturacion.SqlDbType = SqlDbType.BigInt
                        param_idfacturacion.Value = txtID.Text
                        param_idfacturacion.Direction = ParameterDirection.Input

                        Dim param_idpresges As New SqlClient.SqlParameter
                        param_idpresges.ParameterName = "@idpresges"
                        param_idpresges.SqlDbType = SqlDbType.BigInt
                        param_idpresges.Value = grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.IdPresGes).Value
                        param_idpresges.Direction = ParameterDirection.Input

                        Dim param_nroremito As New SqlClient.SqlParameter
                        param_nroremito.ParameterName = "@nroremito"
                        param_nroremito.SqlDbType = SqlDbType.VarChar
                        param_nroremito.Size = 30
                        param_nroremito.Value = LTrim(RTrim(grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.NroRemito).Value))
                        param_nroremito.Direction = ParameterDirection.Input

                        Dim param_nrocomprobante As New SqlClient.SqlParameter
                        param_nrocomprobante.ParameterName = "@nrocomprobante"
                        param_nrocomprobante.SqlDbType = SqlDbType.VarChar
                        param_nrocomprobante.Size = 100
                        param_nrocomprobante.Value = grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.OCRemito).Value 'txtComprobanteFacturacion.Text '= "", DBNull.Value, txtComprobante.Text)
                        param_nrocomprobante.Direction = ParameterDirection.Input

                        Dim param_nrofactura As New SqlClient.SqlParameter
                        param_nrofactura.ParameterName = "@nrofactura"
                        param_nrofactura.SqlDbType = SqlDbType.BigInt
                        param_nrofactura.Value = txtNroFactura.Text
                        param_nrofactura.Direction = ParameterDirection.Input

                        Dim param_nota As New SqlClient.SqlParameter
                        param_nota.ParameterName = "@nota_gestion"
                        param_nota.SqlDbType = SqlDbType.VarChar
                        param_nota.Size = 300
                        param_nota.Value = grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.Nota_Gestion).Value
                        param_nota.Direction = ParameterDirection.Input

                        Dim param_SinPresupuesto As New SqlClient.SqlParameter
                        param_SinPresupuesto.ParameterName = "@SinPresupuesto"
                        param_SinPresupuesto.SqlDbType = SqlDbType.Bit
                        param_SinPresupuesto.Value = IIf(grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.NroPres).Value = 0, True, False)
                        param_SinPresupuesto.Direction = ParameterDirection.Input

                        Dim param_res As New SqlClient.SqlParameter
                        param_res.ParameterName = "@res"
                        param_res.SqlDbType = SqlDbType.Int
                        param_res.Value = DBNull.Value
                        param_res.Direction = ParameterDirection.InputOutput

                        Try
                            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spFacturacion_Remitos_Insert", _
                                                    param_idfacturacion, param_idpresges, param_nroremito, _
                                                    param_nota, param_nrofactura, param_nrocomprobante, param_SinPresupuesto, param_res)

                            res = param_res.Value

                            If (res <= 0) Then
                                Exit For
                            End If

                        Catch ex As Exception
                            Throw ex
                        End Try
                    End If

                Next

                AgregarRegistro_RemitosAsociados = res

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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function AgregarRegistro_CtaCte() As Integer
        Dim res As Integer = 0

        Try

            Try

                Dim param_codigo As New SqlClient.SqlParameter
                param_codigo.ParameterName = "@codigo"
                param_codigo.SqlDbType = SqlDbType.VarChar
                param_codigo.Size = 25
                param_codigo.Value = DBNull.Value
                param_codigo.Direction = ParameterDirection.Input

                Dim param_idcliente As New SqlClient.SqlParameter
                param_idcliente.ParameterName = "@idcliente"
                param_idcliente.SqlDbType = SqlDbType.BigInt
                param_idcliente.Value = cmbCliente.SelectedValue
                param_idcliente.Direction = ParameterDirection.Input

                Dim param_tipooperacion As New SqlClient.SqlParameter
                param_tipooperacion.ParameterName = "@tipooperacion"
                param_tipooperacion.SqlDbType = SqlDbType.VarChar
                param_tipooperacion.Size = 25
                param_tipooperacion.Value = "VENTA"
                param_tipooperacion.Direction = ParameterDirection.Input

                Dim param_IDFACTURACIONPAGO As New SqlClient.SqlParameter
                param_IDFACTURACIONPAGO.ParameterName = "@IdFacturacionPago"
                param_IDFACTURACIONPAGO.SqlDbType = SqlDbType.BigInt
                param_IDFACTURACIONPAGO.Value = txtID.Text
                param_IDFACTURACIONPAGO.Direction = ParameterDirection.Input

                Dim param_fechaFACTURA As New SqlClient.SqlParameter
                param_fechaFACTURA.ParameterName = "@FechaMovCtaCte"
                param_fechaFACTURA.SqlDbType = SqlDbType.VarChar
                param_fechaFACTURA.Size = 10
                param_fechaFACTURA.Value = dtpFECHA.Value.ToString
                param_fechaFACTURA.Direction = ParameterDirection.Input

                Dim param_montoMov As New SqlClient.SqlParameter
                param_montoMov.ParameterName = "@montomovctacte"
                param_montoMov.SqlDbType = SqlDbType.Decimal
                param_montoMov.Precision = 18
                param_montoMov.Scale = 2
                param_montoMov.Value = CDbl(lblTotal.Text)
                param_montoMov.Direction = ParameterDirection.Input

                Dim param_useradd As New SqlClient.SqlParameter
                param_useradd.ParameterName = "@useradd"
                param_useradd.SqlDbType = SqlDbType.Int
                param_useradd.Value = UserID
                param_useradd.Direction = ParameterDirection.Input

                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.InputOutput

                Try
                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spCtaCteMovimientos_Insert", _
                                              param_codigo, param_idcliente, param_tipooperacion, param_IDFACTURACIONPAGO, _
                                              param_fechaFACTURA, param_montoMov, param_useradd, param_res)


                    AgregarRegistro_CtaCte = param_res.Value

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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Function

    Private Function AgregarRegistroItems() As Integer
        Dim res As Integer = 0
        Dim i As Integer

        Try
            Try
                For i = 0 To grdItems.RowCount - 1

                    Dim param_idPRESGES As New SqlClient.SqlParameter
                    param_idPRESGES.ParameterName = "@idPRESGES"
                    param_idPRESGES.SqlDbType = SqlDbType.BigInt
                    param_idPRESGES.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems.IdPresGes).Value
                    param_idPRESGES.Direction = ParameterDirection.Input

                    Dim param_idfacturacion As New SqlClient.SqlParameter
                    param_idfacturacion.ParameterName = "@idfacturacion"
                    param_idfacturacion.SqlDbType = SqlDbType.BigInt
                    param_idfacturacion.Value = txtID.Text
                    param_idfacturacion.Direction = ParameterDirection.Input

                    Dim param_userupd As New SqlClient.SqlParameter
                    param_userupd.ParameterName = "@userupd"
                    param_userupd.SqlDbType = SqlDbType.Int
                    param_userupd.Value = UserID
                    param_userupd.Direction = ParameterDirection.Input

                    Dim param_tiporemito As New SqlClient.SqlParameter
                    param_tiporemito.ParameterName = "@tiporemito"
                    param_tiporemito.SqlDbType = SqlDbType.Int
                    param_tiporemito.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems.tiporemito).Value
                    param_tiporemito.Direction = ParameterDirection.Input

                    Dim param_res As New SqlClient.SqlParameter
                    param_res.ParameterName = "@res"
                    param_res.SqlDbType = SqlDbType.Int
                    param_res.Value = DBNull.Value
                    param_res.Direction = ParameterDirection.InputOutput

                    Try
                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spFacturacion_Items_Update", _
                                                  param_idPRESGES, param_idfacturacion, param_userupd, param_tiporemito, param_res)

                        res = param_res.Value

                        If (res <= 0) Then
                            Exit For
                        End If

                    Catch ex As Exception
                        Throw ex
                    End Try

                Next

                AgregarRegistroItems = res

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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function ActualizarFacturacion_FEAFIP(ByVal numeroCAE As String, ByVal vtoCAE As String) As Integer
        Dim res As Integer = 0
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexi?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End Try

        Try
            Try
                Dim param_id As New SqlClient.SqlParameter
                param_id.ParameterName = "@id"
                param_id.SqlDbType = SqlDbType.BigInt
                param_id.Value = txtID.Text
                param_id.Direction = ParameterDirection.Input

                Dim param_cae As New SqlClient.SqlParameter
                param_cae.ParameterName = "@cae"
                param_cae.SqlDbType = SqlDbType.VarChar
                param_cae.Size = 50
                param_cae.Value = numeroCAE
                param_cae.Direction = ParameterDirection.Input

                Dim param_Venc_CAE As New SqlClient.SqlParameter
                param_Venc_CAE.ParameterName = "@Venc_CAE"
                param_Venc_CAE.SqlDbType = SqlDbType.VarChar
                param_Venc_CAE.Size = 10
                param_Venc_CAE.Value = vtoCAE
                param_Venc_CAE.Direction = ParameterDirection.Input

                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.InputOutput

                Try
                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spFacturacion_Update_FEAFIP", _
                                              param_id, param_cae, param_Venc_CAE, param_res)

                    res = param_res.Value

                Catch ex As Exception
                    Throw ex
                End Try

                ActualizarFacturacion_FEAFIP = res

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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Function

    Private Function AgregarRemito_tmp() As Integer
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim I As Integer
        Dim subtotal As Double = 0, total As Double = 0, MONTOiva As Double = 0
        Dim ds_TipoPago As DataSet             'Dataset de uso general

        Try

            Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexi?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End Try

            Try
                SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spRemitos_DELETE_tmp")

            Catch ex As Exception
                Throw ex
            End Try

            IVA = 0
            txtOC.Text = ""
            NroPresup = 0
            bandIVA = True
            RemitosAsociados = ""

            Dim j As Integer

            For j = 0 To grdRemitos.RowCount - 1
                If CBool(grdRemitos.Rows(j).Cells(ColumnasDelGridRemitos.Seleccionar).Value) = True Then
                    OC_x_Remito = IIf(grdRemitos.Rows(j).Cells(ColumnasDelGridRemitos.OCRemito).Value Is DBNull.Value, "", grdRemitos.Rows(j).Cells(ColumnasDelGridRemitos.OCRemito).Value)
                    IVA = grdRemitos.Rows(j).Cells(ColumnasDelGridRemitos.Iva).Value
                    RemitosAsociados = grdRemitos.Rows(j).Cells(ColumnasDelGridRemitos.NroRemito).Value.ToString
                    Exit For
                End If
            Next

            Dim t As Integer

            For t = j To grdRemitos.RowCount - 1
                If CBool(grdRemitos.Rows(t).Cells(ColumnasDelGridRemitos.Seleccionar).Value) = True Then
                    If Not grdRemitos.Rows(t).Cells(ColumnasDelGridRemitos.OCRemito).Value Is DBNull.Value Then
                        If grdRemitos.Rows(t).Cells(ColumnasDelGridRemitos.OCRemito).Value <> "" Then
                            If LTrim(RTrim(OC_x_Remito)) <> LTrim(RTrim(IIf(grdRemitos.Rows(t).Cells(ColumnasDelGridRemitos.OCRemito).Value Is DBNull.Value, "", grdRemitos.Rows(t).Cells(ColumnasDelGridRemitos.OCRemito).Value))) Then
                                MsgBox("Ha seleccionado Remitos con diferentes OCs. Por favor, verifique", MsgBoxStyle.Critical, "Atenci?n")
                                banOC_x_Remito = False
                                Exit Function
                            Else
                                banOC_x_Remito = True
                            End If
                        End If
                    End If

                    If IVA <> grdRemitos.Rows(t).Cells(ColumnasDelGridRemitos.Iva).Value Then
                        MsgBox("Ha seleccionado Presupuestos/Remitos con diferentes porcentajes de IVA. Por favor, verifique", MsgBoxStyle.Critical, "Atenci?n")
                        bandIVA = False
                        Exit Function
                    Else
                        bandIVA = True
                    End If

                End If
            Next

            For I = j To grdRemitos.RowCount - 1

                If CBool(grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.Seleccionar).Value) = True Then

                    If bolModo = True Then

                        If NroPresup = 0 Then
                            NroPresup = grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.NroPres).Value
                        End If

                        If RemitosAsociados <> grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.NroRemito).Value.ToString Then
                            RemitosAsociados = RemitosAsociados + " - " + grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.NroRemito).Value.ToString
                        End If

                    End If

                    Dim param_id As New SqlClient.SqlParameter
                    param_id.ParameterName = "@idPRESUPUESTO"
                    param_id.SqlDbType = SqlDbType.BigInt
                    param_id.Value = grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.IdPresGes).Value
                    param_id.Direction = ParameterDirection.Input

                    Try
                        SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spRemitos_Insert_tmp", _
                                                  param_id)

                    Catch ex As Exception
                        Throw ex
                        Exit For
                    End Try

                    If grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.IdMonedaPres).Value = 0 Then
                        If CDbl(grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.SubtotalPE).Value) = 0 Then
                            txtValorCambio.Text = CDbl(ObtenerMoneda_ValorCambioDolar(ConnStringSEI))
                            txtValorCambio.ReadOnly = False
                            subtotal = subtotal + Format(grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.SubtotalDO).Value * txtValorCambio.Text, "####0.00")
                        Else
                            txtValorCambio.Text = "1"
                            txtValorCambio.ReadOnly = True
                            subtotal = subtotal + grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.SubtotalPE).Value
                        End If
                    Else
                        If grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.CodMonedaPres).Value = "Do" Then
                            txtValorCambio.Text = CDbl(ObtenerMoneda_ValorCambioDolar(ConnStringSEI))
                            txtValorCambio.ReadOnly = False
                            subtotal = subtotal + Format(grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.SubtotalDO).Value * txtValorCambio.Text, "####0.00")
                        Else
                            txtValorCambio.Text = "1"
                            txtValorCambio.ReadOnly = True
                            subtotal = subtotal + Format(grdRemitos.Rows(I).Cells(ColumnasDelGridRemitos.SubtotalDO).Value, "####0.00")
                        End If
                    End If
                End If

            Next

            MONTOiva = subtotal * (IVA / 100)
            total = subtotal + MONTOiva

            ds_TipoPago = SqlHelper.ExecuteDataset(connection, CommandType.Text, "select c.nombre from presupuestos p " & _
                            " JOIN CondiciondePago c ON c.id = p.idformapago " & _
                            " where p.codigo = '" & NroPresup & "' and c.nombre like '%contado%'")

            ds_TipoPago.Dispose()

            If ds_TipoPago.Tables(0).Rows.Count > 0 Then
                cmbCondVTA.Text = "Contado/Efectivo"
            Else
                cmbCondVTA.Text = "Cta Cte"
            End If

            lblSubtotal.Text = Format(subtotal, "####0.00")
            lblPorcIva.Text = IVA.ToString
            lblIVA.Text = Format(MONTOiva, "####0.00")
            lblTotal.Text = Format(total, "####0.00")

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Function

    Private Sub BuscarProximaFactura()
        'Dim res As Integer = 0

        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            Dim param_proxfactura As New SqlClient.SqlParameter
            param_proxfactura.ParameterName = "@proxfactura"
            param_proxfactura.SqlDbType = SqlDbType.BigInt
            param_proxfactura.Value = DBNull.Value
            param_proxfactura.Direction = ParameterDirection.InputOutput

            Dim param_tipocomprobante As New SqlClient.SqlParameter
            param_tipocomprobante.ParameterName = "@tipocomprobante"
            param_tipocomprobante.SqlDbType = SqlDbType.Int
            param_tipocomprobante.Value = cmbTipoComprobante.SelectedValue
            param_tipocomprobante.Direction = ParameterDirection.Input

            Try
                SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spFacturacion_Select_All_ProxFactura", _
                                          param_proxfactura, param_tipocomprobante)

                If bolModo = True Then
                    txtNroFactura.Text = param_proxfactura.Value

                    NroFacturaTentativo = param_proxfactura.Value
                End If

                lblNroPosible.Text = param_proxfactura.Value

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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Function AnularFisico_Registro(ByVal logico As Boolean, ByVal fisico As Boolean, ByVal nc As Boolean, ByVal NvaFactura As String) As Integer
        Dim res As Integer = 0

        Try
            Try
                conn_del_form = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexi?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End Try

            'Abrir una transaccion para guardar y asegurar que se guarda todo
            If Abrir_Tran(conn_del_form) = False Then
                MessageBox.Show("No se pudo abrir una transaccion", "Error de conexi?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If

            Try

                Dim param_idFacturacion As New SqlClient.SqlParameter("@idFacturacion", SqlDbType.BigInt, ParameterDirection.Input)
                param_idFacturacion.Value = CType(txtID.Text, Long)
                param_idFacturacion.Direction = ParameterDirection.Input

                Dim param_userdel As New SqlClient.SqlParameter
                param_userdel.ParameterName = "@userdel"
                param_userdel.SqlDbType = SqlDbType.Int
                param_userdel.Value = UserID
                param_userdel.Direction = ParameterDirection.Input

                Dim param_nrofactura As New SqlClient.SqlParameter
                param_nrofactura.ParameterName = "@nrofactura"
                param_nrofactura.SqlDbType = SqlDbType.BigInt
                param_nrofactura.Value = IIf(NvaFactura = "", 0, NvaFactura)
                param_nrofactura.Direction = ParameterDirection.Input

                Dim param_FISICO As New SqlClient.SqlParameter
                param_FISICO.ParameterName = "@fisico"
                param_FISICO.SqlDbType = SqlDbType.Bit
                param_FISICO.Value = fisico
                param_FISICO.Direction = ParameterDirection.Input

                Dim param_logico As New SqlClient.SqlParameter
                param_logico.ParameterName = "@logico"
                param_logico.SqlDbType = SqlDbType.Bit
                param_logico.Value = logico
                param_logico.Direction = ParameterDirection.Input

                Dim param_NC As New SqlClient.SqlParameter
                param_NC.ParameterName = "@NotaCredito"
                param_NC.SqlDbType = SqlDbType.Bit
                param_NC.Value = nc
                param_NC.Direction = ParameterDirection.Input

                Dim param_Cliente As New SqlClient.SqlParameter
                param_Cliente.ParameterName = "@IdCliente"
                param_Cliente.SqlDbType = SqlDbType.BigInt
                param_Cliente.Value = cmbCliente.SelectedValue
                param_Cliente.Direction = ParameterDirection.Input

                Dim param_Monto As New SqlClient.SqlParameter
                param_Monto.ParameterName = "@Monto"
                param_Monto.SqlDbType = SqlDbType.Decimal
                param_Monto.Precision = 18
                param_Monto.Scale = 2
                param_Monto.Value = lblTotal.Text
                param_Monto.Direction = ParameterDirection.Input

                Dim param_nota As New SqlClient.SqlParameter
                param_nota.ParameterName = "@nota"
                param_nota.SqlDbType = SqlDbType.VarChar
                param_nota.Size = 300
                param_nota.Value = txtNota.Text ', DBNull.Value, txtComprobante.Text)
                param_nota.Direction = ParameterDirection.Input

                Dim param_MENSAJE As New SqlClient.SqlParameter
                param_MENSAJE.ParameterName = "@MENSAJE"
                param_MENSAJE.SqlDbType = SqlDbType.VarChar
                param_MENSAJE.Size = 300
                param_MENSAJE.Value = DBNull.Value
                param_MENSAJE.Direction = ParameterDirection.InputOutput


                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.Output

                Try

                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spFacturacion_Delete", _
                                            param_nrofactura, param_idFacturacion, param_userdel, param_FISICO, _
                                            param_logico, param_NC, param_Cliente, param_Monto, param_nota, _
                                            param_MENSAJE, param_res)

                    ' param_nota, param_res)

                    'MsgBox(param_MENSAJE.Value.ToString)


                    AnularFisico_Registro = param_res.Value

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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Function

    Private Function AnularFisico_RegistroItems(ByVal IdPres_Ges As Long) As Integer
        Dim res As Integer

        Try

            Dim param_id As New SqlClient.SqlParameter
            param_id.ParameterName = "@IdFacturacion"
            param_id.SqlDbType = SqlDbType.BigInt
            param_id.Value = txtID.Text
            param_id.Direction = ParameterDirection.Input

            Dim param_res As New SqlClient.SqlParameter
            param_res.ParameterName = "@res"
            param_res.SqlDbType = SqlDbType.Int
            param_res.Value = DBNull.Value
            param_res.Direction = ParameterDirection.InputOutput

            Try
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spFacturacion_Remitos_Delete", _
                                          param_id, param_res)

                res = param_res.Value

                AnularFisico_RegistroItems = res

            Catch ex2 As Exception
                Throw ex2
            End Try

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci?n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont?ctese con MercedesIt a trav?s del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicaci?n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        ' Si la tecla presionada es distinta de la tecla Enter,
        ' abandonamos el procedimiento.
        '
        If keyData <> Keys.Return Then Return MyBase.ProcessCmdKey(msg, keyData)

        ' Igualmente, si el control DataGridView no tiene el foco,
        ' y si la celda actual no est? siendo editada,
        ' abandonamos el procedimiento.
        If (Not grdItems.Focused) AndAlso (Not grdItems.IsCurrentCellInEditMode) Then Return MyBase.ProcessCmdKey(msg, keyData)

        ' Obtenemos la celda actual
        Dim cell As DataGridViewCell = grdItems.CurrentCell
        ' ?ndice de la columna.
        Dim columnIndex As Int32 = cell.ColumnIndex
        ' ?ndice de la fila.
        Dim rowIndex As Int32 = cell.RowIndex

        'Do
        '    If columnIndex = grdItems.Columns.Count - 1 Then
        '        If rowIndex = grdItems.Rows.Count - 1 Then
        '            ' Seleccionamos la primera columna de la primera fila.
        '            cell = grdItems.Rows(0).Cells(ColumnasDelGridItems.IdPres_Ges_Det)
        '        Else
        '            ' Selecionamos la primera columna de la siguiente fila.
        '            cell = grdItems.Rows(rowIndex + 1).Cells(ColumnasDelGridItems.IdPres_Ges_Det)
        '        End If
        '    Else
        '        ' Seleccionamos la celda de la derecha de la celda actual.
        '        cell = grdItems.Rows(rowIndex).Cells(columnIndex + 1)
        '    End If
        '    ' establecer la fila y la columna actual
        '    columnIndex = cell.ColumnIndex
        '    rowIndex = cell.RowIndex
        'Loop While (cell.Visible = False)

        grdItems.CurrentCell = cell

        ' ... y la ponemos en modo de edici?n.
        grdItems.BeginEdit(True)
        Return True

    End Function

#End Region

#Region "   Botones"

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click

        'If ProbarConexion() = False Then
        '    If MessageBox.Show("La conexi?n con el servidor de la AFIP no ha sido exitosa por consiguiente no puede generar una nueva factura. ?Desea volver a intentar conectarse con el servidor?", "Error de conexi?n", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        '        If ConexionAfip() = True Then
        '            imgConexion.Image = My.Resources.Green_Ball_icon
        '        Else
        '            MessageBox.Show("La conexi?n con el servidor de la AFIP no ha sido exitosa, por favor intente nuevamente mas tarde.", "Error de conexi?n", MessageBoxButtons.OK)
        '            imgConexion.Image = My.Resources.Red_Ball_icon
        '            Exit Sub
        '        End If
        '    Else
        '        Exit Sub
        '    End If
        'End If

        bolModo = True

        band = 0

        lblNotaCredito.Visible = False

        'chkAnulados.Checked = False
        'chkAnulados_CheckedChanged(sender, e)
        'chkAnulados.Enabled = Not bolModo

        lblNotaCredito.Visible = False

        bolModo = True

        Util.MsgStatus(Status1, "Haga click en [Guardar] despues de completar los datos.")
        PrepararBotones()

        llenandoCombo = True
        Util.LimpiarTextBox(Me.Controls)

        PrepararGridItems()

        cmbCondVTA.Text = "Cta Cte"
        'cmbCondIVA.Text = "RI"

        grdRemitos.Columns(ColumnasDelGridRemitos.Seleccionar).Visible = True

        cmbCliente.SelectedIndex = 0
        lblTotal.Text = ""
        lblCantidadFilas.Text = "0 / 16"
        lblSubtotal.Text = ""
        lblIVA.Text = ""
        txtComprobanteFacturacion.Text = ""
        txtOC.Text = ""

        IVA = 0
        NroPresup = 0
        OC_x_Remito = ""
        banOC_x_Remito = True
        bandIVA = True
        RemitosAsociados = ""

        grdRemitos.Enabled = bolModo
        cmbCondVTA.Enabled = bolModo
        chkAnulados.Enabled = Not bolModo

        cmbCliente.Visible = bolModo
        txtCliente.Visible = Not bolModo
        'lblNroPosible.Visible = True

        cmbComprobantes.Enabled = bolModo
        txtCondicionIVA.Enabled = bolModo
        cmbCondVTA.Enabled = bolModo

        cmbTipoComprobante.Enabled = bolModo
        cmbComprobantes.Enabled = bolModo
        cmbConceptos.Enabled = bolModo

        dtpVtoPago.Enabled = bolModo

        band = 1

        cmbCliente_SelectedValueChanged(sender, e)

        Try
            'cmbTipoComprobante.Text = "FACTURAS A"
            cmbTipoComprobante.SelectedIndex = 0
            cmbTipoComprobante_SelectedIndexChanged(sender, e)

            cmbConceptos.SelectedIndex = 0
            cmbConceptos_SelectedIndexChanged(sender, e)

            cmbCondVTA.SelectedIndex = 0

            'cmbDocTipo_SelectedIndexChanged(sender, e)

        Catch ex As Exception

        End Try

        Label6.Text = "Items por Facturar"

        dtpFECHA.Value = Date.Today

        dtpVtoPago.Value = Today.AddMonths(1)

        txtValorCambio.Text = CDbl(ObtenerMoneda_ValorCambioDolar(ConnStringSEI))

        txtValorCambio.Enabled = bolModo

        dtpFECHA.Enabled = bolModo
        dtpServicioDesde.Enabled = bolModo
        dtpServicioHasta.Enabled = bolModo
        dtpVtoPago.Enabled = bolModo

        dtpFECHA.Focus()

        'BuscarProximaFactura()

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim res As Integer

        Dim NotaCredito As Boolean = False

        If bandIVA = False Then
            MsgBox("Ha seleccionado Remitos con diferentes porcentajes de IVA. Por favor, verifique", MsgBoxStyle.Critical, "Atenci?n")
            Exit Sub
        End If

        'If bandPresup = False Then
        ' MsgBox("Ha seleccionado Remitos provenientes de diferentes Presupuestos. Por favor, verifique", MsgBoxStyle.Critical, "Atenci?n")
        ' Exit Sub
        ' End If

        If banOC_x_Remito = False Then
            MsgBox("Ha seleccionado Remitos con diferentes OCs. Por favor, verifique", MsgBoxStyle.Critical, "Atenci?n")
            Exit Sub
        End If

        'If bandValorDolar = False Then
        ' MsgBox("Ha seleccionado Presupuestos con diferentes Valor de Dolar al momento de ser confeccionado. Por favor, verifique", MsgBoxStyle.Critical, "Atenci?n")
        ' Exit Sub
        ' End If

        'If InStr(RemitosAsociados1, "*") > 0 And bolModo = True Then
        '    If MessageBox.Show("Est? por facturar presupuestos sin Remitos. Desea Continuar?", "Atenci?n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
        '        MsgBox("Para modificar el n?mero de remito debe ir a la pantalla de Presupuestos", MsgBoxStyle.Information, "Atenci?n")
        '        Exit Sub
        '    End If
        'End If

        If bolModo = True Then
            If CLng(txtNroFactura.Text) <> NroFacturaTentativo Then
                If MessageBox.Show("El nro de factura ingresado (" & txtNroFactura.Text & ") es diferente al nro tentativo que infiere el sistema (" & NroFacturaTentativo & "). " & vbCrLf & _
                                    "?Desea continuar con el n?mero ingresado?", "Atenci?n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    txtNroFactura.Text = NroFacturaTentativo
                    lblNroPosible.Visible = True
                    lblNroPosible.Text = NroFacturaTentativo
                    txtNroFactura.Focus()
                    Exit Sub
                End If
            End If
            'Else
            '    If CLng(txtNroFactura.Text) <> CLng(grd.CurrentRow.Cells(6).Value) Then
            '        If MessageBox.Show("El nro de factura ingresado (" & txtNroFactura.Text & ") es diferente al nro de Factura original (" & grd.CurrentRow.Cells(10).Value & "). " & vbCrLf & _
            '                            "?Desea continuar con el n?mero ingresado?", "Atenci?n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            '            'txtfactura.Text = NroFacturaTentativo
            '            'lblNroPosible.Visible = True
            '            'lblNroPosible.Text = NroFacturaTentativo
            '            txtNroFactura.Focus()
            '            Exit Sub
            '        End If
            '    End If
        End If

        If CDbl(txtValorCambio.Text) > 1 Then
            If MessageBox.Show("Desea facturar con el tipo de moneda en DOLAR? Cambio Actual: " & txtValorCambio.Text, "Atenci?n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                txtValorCambio.Focus()
                Exit Sub
            End If
        End If


        Dim Reutilizar As Boolean = False

        If cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoA Or cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoB Or _
                                     cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoA Or cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoB Then
            If MessageBox.Show("Desea reutilizar el/los remitos asociados?", "Atenci?n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Reutilizar = True
            End If
        End If

        Util.MsgStatus(Status1, "Controlando la informaci?n...", My.Resources.Resources.indicator_white)

        If ReglasNegocio() Then
            Verificar_Datos()
            If bolpoliticas Then
                If bolModo Then
                    Util.MsgStatus(Status1, "Guardando el registro...", My.Resources.Resources.indicator_white)
                    res = AgregarRegistro(Reutilizar)
                    Select Case res
                        Case -4
                            Cancelar_Tran()
                            Util.MsgStatus(Status1, "El nro de Factura ya existe en el sistema, por favor, verifique esta informaci?n.", My.Resources.Resources.stop_error.ToBitmap)
                            Util.MsgStatus(Status1, "El nro de Factura ya existe en el sistema, por favor, verifique esta informaci?n.", My.Resources.Resources.stop_error.ToBitmap, True)
                            Exit Sub
                        Case -3
                            Cancelar_Tran()
                            Util.MsgStatus(Status1, "No pudo realizarse la insersi?n (Encabezado).", My.Resources.Resources.stop_error.ToBitmap)
                            Util.MsgStatus(Status1, "No pudo realizarse la insersi?n (Encabezado).", My.Resources.Resources.stop_error.ToBitmap, True)
                            Exit Sub
                        Case -2
                            Cancelar_Tran()
                            Util.MsgStatus(Status1, "No se pudo actualizar el n?mero de Facturaci?n (Encabezado).", My.Resources.Resources.stop_error.ToBitmap)
                            Util.MsgStatus(Status1, "No se pudo actualizar el n?mero de Facturaci?n (Encabezado).", My.Resources.Resources.stop_error.ToBitmap, True)
                            Exit Sub
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

                            If cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoA Or cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoB Or _
                                cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoA Or cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoB Then
                                GoTo ContinuarDespuesdeNCNB
                            End If

                            Util.MsgStatus(Status1, "Guardando los remitos asociados...", My.Resources.Resources.indicator_white)
                            res = AgregarRegistro_RemitosAsociados()
                            Select Case res
                                Case -3
                                    Cancelar_Tran()
                                    Util.MsgStatus(Status1, "No se pudo actualizar la OC.", My.Resources.Resources.stop_error.ToBitmap)
                                    Util.MsgStatus(Status1, "No se pudo actualizar la OC.", My.Resources.Resources.stop_error.ToBitmap, True)
                                    Exit Sub
                                Case -1
                                    Cancelar_Tran()
                                    Util.MsgStatus(Status1, "No se pudo registrar los remitos.", My.Resources.Resources.stop_error.ToBitmap)
                                    Util.MsgStatus(Status1, "No se pudo registrar los remitos.", My.Resources.Resources.stop_error.ToBitmap, True)
                                    Exit Sub
                                Case 0
                                    Cancelar_Tran()
                                    Util.MsgStatus(Status1, "No se pudo regitrar los remitos.", My.Resources.Resources.stop_error.ToBitmap)
                                    Util.MsgStatus(Status1, "No se pudo regitrar los remitos.", My.Resources.Resources.stop_error.ToBitmap, True)
                                    Exit Sub
                                Case Else
                                    'Util.MsgStatus(Status1, "Guardando la informaci?n en la cuenta...", My.Resources.Resources.indicator_white)
                                    'res = AgregarRegistro_CtaCte()
                                    'Select Case res
                                    '    Case -1
                                    '        Cancelar_Tran()
                                    '        Util.MsgStatus(Status1, "No se pudo registrar la informaci?n en la cuenta.", My.Resources.Resources.stop_error.ToBitmap)
                                    '        Util.MsgStatus(Status1, "No se pudo registrar la informaci?n en la cuenta.", My.Resources.Resources.stop_error.ToBitmap, True)
                                    '        Exit Sub
                                    '    Case 0
                                    '        Cancelar_Tran()
                                    '        Util.MsgStatus(Status1, "No se pudo registrar la informaci?n en la cuenta.", My.Resources.Resources.stop_error.ToBitmap)
                                    '        Util.MsgStatus(Status1, "No se pudo registrar la informaci?n en la cuenta.", My.Resources.Resources.stop_error.ToBitmap, True)
                                    '        Exit Sub
                                    '    Case Else
                                    Util.MsgStatus(Status1, "Actualizando los items facturados...", My.Resources.Resources.indicator_white)
                                    res = AgregarRegistroItems()
                                    Select Case res
                                        Case -1
                                            Cancelar_Tran()
                                            Util.MsgStatus(Status1, "No se pudo actualizar los items facturados.", My.Resources.Resources.stop_error.ToBitmap)
                                            Util.MsgStatus(Status1, "No se pudo actualizar los items facturados.", My.Resources.Resources.stop_error.ToBitmap, True)
                                            Exit Sub
                                        Case 0
                                            Cancelar_Tran()
                                            Util.MsgStatus(Status1, "No se pudo actualizar los items facturados.", My.Resources.Resources.stop_error.ToBitmap)
                                            Util.MsgStatus(Status1, "No se pudo actualizar los items facturados.", My.Resources.Resources.stop_error.ToBitmap, True)
                                            Exit Sub
                                        Case Else
                                            'Util.MsgStatus(Status1, "Cerrando, conectando con AFIP y generando la factura electr?nica", My.Resources.Resources.indicator_white)
                                            'Dim ImprimirSinCAE As Boolean = False
ContinuarDespuesdeNCNB:
                                            Cerrar_Tran()
                                            'Select Case FEAFIP()
                                            '    Case -1
                                            '        Util.MsgStatus(Status1, "No se pudo actualizar el CAE y Vto en el sistema local.", My.Resources.Resources.stop_error.ToBitmap)
                                            '        Util.MsgStatus(Status1, "No se pudo actualizar el CAE y Vto en el sistema local.", My.Resources.Resources.stop_error.ToBitmap, True)
                                            '        ImprimirSinCAE = True
                                            '    Case -2
                                            '        Cancelar_Tran()
                                            '        Util.MsgStatus(Status1, "No se pudo realizar la factura electr?nica.", My.Resources.Resources.stop_error.ToBitmap)
                                            '        Util.MsgStatus(Status1, "No se pudo realizar la factura electr?nica.", My.Resources.Resources.stop_error.ToBitmap, True)
                                            '        Exit Sub
                                            'End Select

                                            If cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoA Or cmbTipoComprobante.SelectedValue = TipoComp.NotaCreditoB Or _
                                                cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoA Or cmbTipoComprobante.SelectedValue = TipoComp.NotaDebitoB Then
                                                NotaCredito = True
                                                GoTo ContinuarSinPagoCliente
                                            End If

                                            If cmbCondVTA.Text = "Contado/Efectivo" Then

                                                frmPagodeClientes_Contado.btnNuevo_Click(sender, e)

                                                frmPagodeClientes_Contado.lblTotalaPagar.Text = lblTotal.Text  ' totalfactura.ToString
                                                frmPagodeClientes_Contado.lblTotalaPagarSinIva.Text = lblSubtotal.Text 'subtotal.ToString
                                                frmPagodeClientes_Contado.IdCliente = cmbCliente.SelectedValue
                                                frmPagodeClientes_Contado.FechaVta = dtpFECHA.Value
                                                frmPagodeClientes_Contado.MontoIva = lblIVA.Text  'totaliva.ToString
                                                frmPagodeClientes_Contado.PorcIva = IVA.ToString
                                                frmPagodeClientes_Contado.txtIdFacturacion.Text = txtID.Text ' idfactura.ToString
                                                frmPagodeClientes_Contado.ShowDialog(Me)

                                            End If

                                            'If ImprimirSinCAE = False Then
                                            '    Imprimir(txtNroFactura.Text, cmbTipoComprobante.Text.ToString)
                                            'Else
                                            '    MsgBox("La factura no podr? ser impresa porque no tiene un CAE V?lido", MsgBoxStyle.Information, "Control de Facturaci?n")
                                            'End If
ContinuarSinPagoCliente:
                                            bolModo = False
                                            PrepararBotones()

                                            If NotaCredito = True And Reutilizar = False Then
                                                Dim NroRemito As String = ""
                                                Dim i As Integer

                                                For i = 0 To grdRemitos.Rows.Count - 1
                                                    If NroRemito = "" Then
                                                        NroRemito = grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.NroRemito).Value.ToString
                                                    Else
                                                        NroRemito = NroRemito + "-" + grdRemitos.Rows(i).Cells(ColumnasDelGridRemitos.NroRemito).Value.ToString
                                                    End If
                                                Next

                                                MsgBox("Debe anular el o los remitos asociados ( " & NroRemito & " ) a la factura Anulada", MsgBoxStyle.Information, "Atenci?n")
                                            End If

                                            btnActualizar_Click(sender, e)

                                            LlenarComboClientes()

                                            Me.Label5.Visible = False
                                            Me.cmbCliente.Visible = False
                                            txtCliente.Visible = True

                                            Util.MsgStatus(Status1, "Se ha actualizado el registro.", My.Resources.Resources.ok.ToBitmap)

                                            grdRemitos.Enabled = bolModo

                                            cmbCondVTA.Enabled = bolModo

                                            chkAnulados.Enabled = Not bolModo

                                            lblNroPosible.Visible = False

                                            cmbTipoComprobante.Enabled = bolModo

                                    End Select
                            End Select
                            'End Select
                    End Select
                    '                   
                Else
                    If MessageBox.Show("Est? seguro que desea modificar la informaci?n del Comprobante seleccionado?", "Atenci?n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        res = ActualizarRegistro()
                        Select Case res
                            Case -1
                                Cancelar_Tran()
                                Util.MsgStatus(Status1, "No se pudo actualizar la facturaci?n.", My.Resources.Resources.stop_error.ToBitmap)
                                Util.MsgStatus(Status1, "No se pudo actualizar la facturaci?n.", My.Resources.Resources.stop_error.ToBitmap, True)
                            Case 0
                                Cancelar_Tran()
                                Util.MsgStatus(Status1, "No se pudo actualizar la facturaci?n.", My.Resources.Resources.stop_error.ToBitmap)
                                Util.MsgStatus(Status1, "No se pudo actualizar la facturaci?n.", My.Resources.Resources.stop_error.ToBitmap, True)
                            Case Else
                                res = ActualizarRegistro_Presupuestos()
                                Select Case res
                                    Case -1
                                        Cancelar_Tran()
                                        Util.MsgStatus(Status1, "No se pudo actualizar la informaci?n en el presupuesto.", My.Resources.Resources.stop_error.ToBitmap)
                                        Util.MsgStatus(Status1, "No se pudo actualizar la informaci?n en el presupuesto.", My.Resources.Resources.stop_error.ToBitmap, True)
                                    Case 0
                                        Cancelar_Tran()
                                        Util.MsgStatus(Status1, "No se pudo actualizar la informaci?n en el presupuesto.", My.Resources.Resources.stop_error.ToBitmap)
                                        Util.MsgStatus(Status1, "No se pudo actualizar la informaci?n en el presupuesto.", My.Resources.Resources.stop_error.ToBitmap, True)
                                    Case Else
                                        Cerrar_Tran()
                                        Util.MsgStatus(Status1, "Se actualiz? correctamente el Comprobante.", My.Resources.Resources.ok.ToBitmap)

                                        'Imprimir(txtNroFactura.Text, cmbTipoComprobante.Text.ToString)

                                        bolModo = False
                                        PrepararBotones()

                                        btnActualizar_Click(sender, e)
                                        Me.Label5.Visible = False
                                        Me.cmbCliente.Visible = False
                                        txtCliente.Visible = True

                                        lblNroPosible.Text = ""
                                        lblNroPosible.Visible = False

                                End Select
                        End Select
                    End If ' If bolModo Then
                End If 'If bolpoliticas Then
            End If
        End If 'If ReglasNegocio() Then

    End Sub

    'Private Sub btnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnular.Click
    '    Dim res As Integer, res_item As Integer
    '    Dim nc As Boolean = False
    '    Dim NvaFactura As String = Nothing

    '    If CBool(grd.CurrentRow.Cells(14).Value) = True Then
    '        MsgBox("La factura seleccionada est? asociada al Pago Nro " & grd.CurrentRow.Cells(17).Value.ToString & " y no podr? ser anulada", MsgBoxStyle.Information, "Factura Cancelada")
    '        Exit Sub
    '    End If

    '    If MessageBox.Show("Esta acci?n anular? la Factura F?sica (no podr? usar el mismo nro de factura en el sistema) " + vbCrLf + _
    '                       "y actualizar? el estado de los remitos asociados a No Facturados." + vbCrLf + "?Est? seguro que desea Anular?", "Atenci?n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


    '        If MessageBox.Show("?Desea generar una Nota de Cr?dito para la factura que est? por anular?", "Atenci?n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '            nc = True

    '            BuscarProximaFactura()

    '            NvaFactura = InputBox("Ingrese el nro de la factura (el sistema muestra el n?mero de factura tentativo)", "Comprobante de NC", lblNroPosible.Text)

    '        End If

    '        If txtNota.Text = "" Then
    '            If MessageBox.Show("No ha ingresado ninguna Nota de Gesti?n, desea continuar?", "Atenci?n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
    '                txtNota.Focus()
    '                Exit Sub
    '            End If
    '        End If

    '        Util.MsgStatus(Status1, "Anulando el registro...", My.Resources.Resources.indicator_white)
    '        res = AnularFisico_Registro(False, True, nc, NvaFactura)
    '        Select Case res
    '            Case -1
    '                Cancelar_Tran()
    '                Util.MsgStatus(Status1, "No pudo realizarse la anulaci?n (Encabezado).", My.Resources.Resources.stop_error.ToBitmap)
    '                Util.MsgStatus(Status1, "No pudo realizarse la anulaci?n (Encabezado).", My.Resources.Resources.stop_error.ToBitmap, True)
    '            Case 0
    '                Cancelar_Tran()
    '                Util.MsgStatus(Status1, "No pudo realizarse la anulaci?n (Encabezado) - 0.", My.Resources.Resources.stop_error.ToBitmap)
    '                Util.MsgStatus(Status1, "No pudo realizarse la anulaci?n (Encabezado) - 0.", My.Resources.Resources.stop_error.ToBitmap, True)
    '            Case Else
    '                Util.MsgStatus(Status1, "Actualizando los items...", My.Resources.Resources.indicator_white)
    '                res_item = AnularFisico_RegistroItems(CType(txtID.Text, Long))
    '                Select Case res_item
    '                    Case -1
    '                        Cancelar_Tran()
    '                        Util.MsgStatus(Status1, "No se pudieron anular los remitos asociados a la factura.", My.Resources.Resources.stop_error.ToBitmap)
    '                        Util.MsgStatus(Status1, "No se pudieron anular los remitos asociados a la factura.", My.Resources.Resources.stop_error.ToBitmap, True)
    '                    Case 0
    '                        Cancelar_Tran()
    '                        Util.MsgStatus(Status1, "No se pudieron anular los remitos asociados a la factura - 0.", My.Resources.Resources.stop_error.ToBitmap)
    '                        Util.MsgStatus(Status1, "No se pudieron anular los remitos asociados a la factura - 0.", My.Resources.Resources.stop_error.ToBitmap, True)
    '                    Case Else
    '                        Cerrar_Tran()
    '                        bolModo = False
    '                        PrepararBotones()

    '                        'LlenarComboClientes()
    '                        btnActualizar_Click(sender, e)

    '                        If txtIdFacturaAnulada.Text <> "0" Then
    '                            Imprimir(txtNroFactura.Text, cmbTipoComprobante.Text.ToString)
    '                        End If

    '                        Util.MsgStatus(Status1, "Se actualiz? el estado de la factura.", My.Resources.Resources.ok.ToBitmap)
    '                        Util.MsgStatus(Status1, "Se actualiz? el estado de la factura.", My.Resources.Resources.ok.ToBitmap, True, True)
    '                End Select
    '        End Select
    '        '
    '        ' cerrar la conexion si est? abierta.
    '        '
    '        If Not conn_del_form Is Nothing Then
    '            CType(conn_del_form, IDisposable).Dispose()
    '        End If
    '    End If

    'End Sub

    'Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
    '    Dim res As Integer, res_item As Integer

    '    If CBool(grd.CurrentRow.Cells(14).Value) = True Then
    '        MsgBox("La factura seleccionada est? asociada al Pago Nro " & grd.CurrentRow.Cells(15).Value.ToString & " y no podr? ser anulada", MsgBoxStyle.Information, "Factura Cancelada")
    '        Exit Sub
    '    End If

    '    If MessageBox.Show("Esta acci?n anular? la Factura de manera L?gica (podr? usar el mismo nro de Factura en el sistema) " + vbCrLf + _
    '                       "?Est? seguro que desea Anular?", "Atenci?n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

    '        Util.MsgStatus(Status1, "Anulando el registro...", My.Resources.Resources.indicator_white)
    '        res = AnularFisico_Registro(True, False, False, "")
    '        Select Case res
    '            Case -1
    '                Cancelar_Tran()
    '                Util.MsgStatus(Status1, "No pudo realizarse la anulaci?n (Encabezado).", My.Resources.Resources.stop_error.ToBitmap)
    '                Util.MsgStatus(Status1, "No pudo realizarse la anulaci?n (Encabezado).", My.Resources.Resources.stop_error.ToBitmap, True)
    '            Case 0
    '                Cancelar_Tran()
    '                Util.MsgStatus(Status1, "No pudo realizarse la anulaci?n (Encabezado) - 0.", My.Resources.Resources.stop_error.ToBitmap)
    '                Util.MsgStatus(Status1, "No pudo realizarse la anulaci?n (Encabezado) - 0.", My.Resources.Resources.stop_error.ToBitmap, True)
    '            Case Else
    '                Util.MsgStatus(Status1, "Actualizando los items...", My.Resources.Resources.indicator_white)
    '                res_item = AnularFisico_RegistroItems(CType(txtID.Text, Long))
    '                Select Case res_item
    '                    Case -1
    '                        Cancelar_Tran()
    '                        Util.MsgStatus(Status1, "No se pudieron anular los remitos asociados a la factura.", My.Resources.Resources.stop_error.ToBitmap)
    '                        Util.MsgStatus(Status1, "No se pudieron anular los remitos asociados a la factura.", My.Resources.Resources.stop_error.ToBitmap, True)
    '                    Case 0
    '                        Cancelar_Tran()
    '                        Util.MsgStatus(Status1, "No se pudieron anular los remitos asociados a la factura - 0.", My.Resources.Resources.stop_error.ToBitmap)
    '                        Util.MsgStatus(Status1, "No se pudieron anular los remitos asociados a la factura - 0.", My.Resources.Resources.stop_error.ToBitmap, True)
    '                    Case Else
    '                        Cerrar_Tran()
    '                        bolModo = False

    '                        'LlenarComboClientes()

    '                        PrepararBotones()
    '                        btnActualizar_Click(sender, e)
    '                        Util.MsgStatus(Status1, "Se actualiz? el estado de la factura.", My.Resources.Resources.ok.ToBitmap)
    '                        Util.MsgStatus(Status1, "Se actualiz? el estado de la factura.", My.Resources.Resources.ok.ToBitmap, True, True)
    '                End Select
    '        End Select
    '        '
    '        ' cerrar la conexion si est? abierta.
    '        '
    '        If Not conn_del_form Is Nothing Then
    '            CType(conn_del_form, IDisposable).Dispose()
    '        End If
    '    End If

    'End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        'Denuevo:

        '        Dim paramConsumos As New frmParametros
        '        Dim cnn As New SqlConnection(ConnStringSEI)
        '        Dim nrofactura As String
        '        Dim Rpt As New frmReportes
        '        Dim TipoComprobante As String

        '        Dim consulta As String = "select * from (select DISTINCT LTRIM(RTRIM(CP.Descripcion)) as descripcion from Comprobantes cp JOIN facturacion f on f.comprobantetipo = convert(int, cp.codigo)) zz order by descripcion"

        '        paramConsumos.AgregarParametros("Tipo Comprobante:", "STRING", "", True, "FACTURAS A", consulta, cnn)
        '        paramConsumos.AgregarParametros("Nro Factura(s/ptovta):", "STRING", "", True, txtNroFactura.Text.ToString, "", cnn)

        '        paramConsumos.ShowDialog()

        '        If cerroparametrosconaceptar = True Then

        '            TipoComprobante = paramConsumos.ObtenerParametros(0)
        '            nrofactura = paramConsumos.ObtenerParametros(1)

        '            'If BuscarFactura(ConnStringSEI, nrofactura, TipoComprobante, "SEI") = False Then
        '            '    Util.MsgStatus(Status1, "El n?mero y/o tipo de factura ingresado no es correcto, o no posee un CAE V?lido. Por favor, revise los datos ingresados.", My.Resources.Resources.stop_error.ToBitmap)
        '            '    Util.MsgStatus(Status1, "El n?mero y/o tipo de factura ingresado no es correcto, o no posee un CAE V?lido. Por favor, revise los datos ingresados", My.Resources.Resources.stop_error.ToBitmap, True)

        '            '    cerroparametrosconaceptar = False
        '            '    paramConsumos = Nothing
        '            '    cnn = Nothing

        '            '    GoTo Denuevo
        '            'End If

        '            nbreformreportes = "Factura"

        '            Dim Rpt1 As New frmReportes

        '            Rpt1.NombreArchivoPDF = PTOVTA.ToString + "-" + nrofactura.ToString.PadLeft(8, "0") + " - Comprobante Duplicado"
        '            Rpt1.MailDestinatario = txtemail.Text

        '            Rpt1.Factura_App(nrofactura, Rpt1, 0, My.Application.Info.AssemblyName.ToString, "DUPLICADO", TipoComprobante, Empresa)

        '            Rpt.NombreArchivoPDF = PTOVTA.ToString + "-" + nrofactura.ToString.PadLeft(8, "0").ToString + " - Comprobante Original"
        '            Rpt.MailDestinatario = txtemail.Text

        '            Rpt.Factura_App(nrofactura, Rpt, 0, My.Application.Info.AssemblyName.ToString, "ORIGINAL", TipoComprobante, Empresa)

        '            cerroparametrosconaceptar = False
        '            paramConsumos = Nothing
        '            cnn = Nothing
        '        End If

    End Sub

    Private Overloads Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        'LlenarComboClientes()

        LlenarGrid_Remitos(CType(cmbCliente.SelectedValue, Long), bolModo, txtID.Text, txtIdFacturaAnulada.Text)
        AgregarRemito_tmp()
        LlenarGrid_Items()

        grdRemitos.Columns(ColumnasDelGridRemitos.Seleccionar).Visible = False

        If IIf(txtIdFacturaAnulada.Text = "", 0, txtIdFacturaAnulada.Text) > 0 Then
            lblNotaCredito.Visible = True
            btnAnular.Enabled = False
        Else
            lblNotaCredito.Visible = False
            btnAnular.Enabled = True
        End If

        grdRemitos.Enabled = bolModo
        cmbCondVTA.Enabled = bolModo
        chkAnulados.Enabled = Not bolModo

        cmbTipoComprobante.Enabled = bolModo
        cmbComprobantes.Enabled = bolModo
        cmbConceptos.Enabled = bolModo

        cmbCliente.Visible = False
        txtCliente.Visible = True

        Label6.Text = "Items Facturados"

        txtValorCambio.Enabled = bolModo

        dtpFECHA.Enabled = bolModo
        dtpServicioDesde.Enabled = bolModo
        dtpServicioHasta.Enabled = bolModo
        dtpVtoPago.Enabled = bolModo

        lblNroPosible.Text = ""

    End Sub

    Private Sub btnRecuperar_Click(sender As Object, e As EventArgs) Handles btnRecuperar.Click
        cae2 = wsfev1.Compconsultar(Me.cmbTipoComprobante.SelectedValue, PTOVTA, txtNroRecuperar.Text)

        MsgBox("CAE: " & cae2.ToString)
        MsgBox("CAE: " & wsfev1.vencimiento)

    End Sub

#End Region

End Class