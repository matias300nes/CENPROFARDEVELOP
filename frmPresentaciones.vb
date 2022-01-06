Imports Microsoft.ApplicationBlocks.Data
Imports Utiles
Imports Utiles.Util
Imports System.Data.SqlClient
Imports ReportesNet
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Imports System.Threading

Public Class frmPresentaciones
    Dim IdObraSocial
    Dim bolpoliticas As Boolean
    Dim llenandoCombo As Boolean = False
    Dim llenandoCombo2 As Boolean = False
    Dim CodigoUsuario As String
    Dim bolIDOS As Boolean = False
    Dim permitir_evento_CellChanged As Boolean

    Dim FILA As Integer
    Dim COLUMNA As Integer
    Private RefrescarGrid As Boolean
    Private ds_2 As DataSet

    'Para el clic derecho sobre la grilla de materiales
    Dim Cell_X As Integer
    Dim Cell_Y As Integer

    'Para el combo de busqueda
    'Dim ID_Buscado As Long
    'Dim Nombre_Buscado As Long

    'Varible de transaccion
    Dim tran As SqlClient.SqlTransaction
    Dim conn_del_form As SqlClient.SqlConnection = Nothing

    '  Public UltBusqueda As String

    Dim band As Integer

    Dim trd As Thread

    'constantes para identificar las columnas de la grilla por nombre 
    ' en vez de número

    Dim btnBand_Copiar As Boolean = True

    Dim ds_Empresa As Data.DataSet


    Dim porceniva As Double = 21

    Enum ColumnasDelGridItems
        ''NACHO
        ID = 0
        IdFarmacia = 1
        CodigoFarmacia = 2
        Nombre = 3
        IdPresentacion = 4
        Recetas = 5
        Recaudado = 6
        ACargoOS = 7
        Bonificacion = 8
        Total = 9
    End Enum

    'Auxiliares para guardar
    Dim cod_aux As String

    'Auxiliares para chequear lo digitado en la columna cantidad
    Dim qty_digitada As String

#Region "   Eventos"

    'Private Sub frmPresentaciones_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    '    'If bolModo = False Then
    '    '    rdTodasOC.Checked = True
    '    '    SQL = "exec spOrdenDeCompra_Select_All @Eliminado = " & IIf(rdAnuladas.Checked = True, 1, 0) & ", @Pendientes = " & IIf(rdPendientes.Checked = True, 1, 0) & ", @PendientesyCumplidas = " & rdTodasOC.Checked
    '    '    btnActualizar_Click(sender, e)
    '    'End If

    'End Sub

    Private Sub frmPresentaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3 'nuevo
                If bolModo = True Then
                    If MessageBox.Show("No ha guardado la Orden de Compra Nueva que está realizando. ¿Está seguro que desea continuar sin Grabar y hacer una Orde de Compra Nueva?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        btnNuevo_Click(sender, e)
                    End If
                Else
                    btnNuevo_Click(sender, e)
                End If
            Case Keys.F4 'grabar
                If cmbEstado.Text = "PRESENTADO" Then
                    btnGuardar_Click(sender, e)
                End If
        End Select
    End Sub

    Private Sub frmPresentaciones_ev_CellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ev_CellChanged
        If permitir_evento_CellChanged Then
            If txtID.Text <> "" Then
                LlenarGrid_Items()
            End If
        End If
    End Sub

    Private Sub grd_SelectionChanged(sender As Object, e As EventArgs) Handles grd.SelectionChanged
        ''DataGridView1.SelectedRows.Count().ToString()
        If grd.SelectedRows.Count() > 1 Then
            btnUnificar.Enabled = True
        Else
            btnUnificar.Enabled = False
        End If
    End Sub

    Private Sub frmPresentaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''prueba nacho
        Cursor = Cursors.WaitCursor

        ToolStrip_lblCodMaterial.Visible = True
        txtBusquedaMAT.Visible = True

        band = 0

        Me.ToolTipbtnSeparar.SetToolTip(btnSeparar, "Separa la(s) farmacias seleccionadas creando una nueva presentación con esas farmacias")
        Me.ToolTipbtnUnificar.SetToolTip(btnUnificar, "Unifica varias presentaciones con distinto o igual periodo")

        configurarform()
        asignarTags()

        btnEliminar.Text = "Anular Presentación"
        'rdPendientes.Checked = 1

        llenarCmbEstados()
        LlenarCmbFarmacia()
        LlenarCmbObraSocial()

        If cmbEstado.Text = "" Then
            cmbEstado.Text = "PRESENTADO"
        End If

        ''Traigo los encabezados de presentacion
        'SQL = $"exec spPresentaciones_Select_All @Pendientes = {rdPendientes.Checked} ,@Eliminado = {rdAnuladas.Checked} ,@Todos = {rdTodasOC.Checked}"
        SQL = $"exec spPresentaciones_Select_All @Estado = {cmbEstado.Text.Replace(" ", "")} ,@Eliminado = 0"

        LlenarGrilla()
        Permitir = True
        CargarCajas()
        PrepararBotones()
        'HiloOcultarColumnasGridItems()
        EstiloGrdItems()

        permitir_evento_CellChanged = True

        band = 1

        If grd.RowCount > 0 Then
            grd.Rows(0).Selected = True
            grd.CurrentCell = grd.Rows(0).Cells(1)
            txtID.Text = grd.Rows(0).Cells(0).Value
            txtCodigo.Text = grd.Rows(0).Cells(1).Value
            dtpFECHA.Value = grd.Rows(0).Cells(2).Value
            cmbObraSocial.SelectedValue = grd.Rows(0).Cells(3).Value
            cmbObraSocial.Text = grd.Rows(0).Cells(4).Value
            txtPeriodo.Text = grd.Rows(0).Cells(5).Value
            lblStatus.Text = grd.Rows(0).Cells(6).Value
            txtTotal.Text = grd.Rows(0).Cells(7).Value
            txtObservacion.Text = grd.Rows(0).Cells(8).Value
        End If

        If bolModo = True Then
            LlenarGrid_Items()
            btnNuevo_Click(sender, e)
        Else
            LlenarGrid_Items()
        End If


        'grd.Columns(0).Visible = False
        'grd.Columns(1).Visible = False
        'grd.Columns(2).Visible = False
        'grd.Columns(3).Visible = False
        'grd.Columns(4).Visible = False
        'grd.Columns(5).Visible = False
        'grd.Columns(6).Visible = False
        'grd.Columns(7).Visible = False
        'grd.Columns(8).Visible = False
        'grd.Columns(9).Visible = False
        'grd.Columns(10).Visible = False
        'grd.Columns(11).Visible = False
        'grd.Columns(12).Visible = False
        'grd.Columns(13).Visible = False
        'grd.Columns(14).Visible = False
        'grd.Columns(15).Visible = False
        'grd.Columns(16).Visible = False
        'grd.Columns(17).Visible = False
        'grd.Columns(18).Visible = False
        'grd.Columns(19).Visible = False
        'grd.Columns(20).Visible = False

        grd.MultiSelect = True
        btnUnificar.Enabled = False
        Cursor = Cursors.Default

    End Sub

    Private Sub cmbFarmacias_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbFarmacias.KeyDown
        If e.KeyData = Keys.Enter Then
            txtRecetas.Focus()
        End If
    End Sub

    Private Sub txtImpACargoOs_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImpACargoOs.KeyDown
        If e.KeyData = Keys.Enter Then
            If cmbEstado.Text = "PRESENTADO" Or bolModo = True Then
                AñadirGridItem()
            End If

        End If
    End Sub

    Private Sub nudBonificacion_KeyDown(sender As Object, e As KeyEventArgs) Handles nudBonificacion.KeyDown
        If e.KeyData = Keys.Enter Then
            If cmbEstado.Text = "PRESENTADO" Or bolModo = True Then
                AñadirGridItem()
            End If
        End If
    End Sub

    Private Sub txtImpACargoOs_LostFocus(sender As Object, e As EventArgs) Handles txtImpACargoOs.LostFocus
        If txtImpACargoOs.Text <> "" Then
            Dim subtotal As Decimal = 0
            Dim aCargoOS As Decimal = Decimal.Parse(txtImpACargoOs.Text)
            Dim Bonificacion As Decimal = Decimal.Parse(nudBonificacion.Value)
            subtotal = aCargoOS - (aCargoOS * Bonificacion)

            txtImpACargoOs.Text = String.Format("{0:N2}", aCargoOS)
            txtImpTotalAPagar.Text = String.Format("{0:N2}", Math.Round(subtotal, 2))
        End If

    End Sub

    Private Sub txtImpRecaudado_LostFocus(sender As Object, e As EventArgs) Handles txtImpRecaudado.LostFocus
        If txtImpRecaudado.Text <> "" Then
            txtImpRecaudado.Text = String.Format("{0:N2}", Decimal.Parse(txtImpRecaudado.Text))
        End If
    End Sub

    Private Sub nudBonificacion_ValueChanged(sender As Object, e As EventArgs) Handles nudBonificacion.ValueChanged
        Dim subtotal As Decimal = 0
        Dim impBonificacion As Decimal = 0
        If txtImpACargoOs.Text <> "" Then
            impBonificacion = Decimal.Parse(txtImpACargoOs.Text) * (Decimal.Parse(nudBonificacion.Value))
            subtotal = Decimal.Parse(txtImpACargoOs.Text) - (Decimal.Parse(txtImpACargoOs.Text) * (Decimal.Parse(nudBonificacion.Value)))
        End If
        txtBonificacion.Text = String.Format("{0:N2}", impBonificacion)
        txtImpTotalAPagar.Text = String.Format("{0:N2}", subtotal)
    End Sub

    Private Sub txtBonificacion_LostFocus(sender As Object, e As EventArgs) Handles txtBonificacion.LostFocus
        If txtBonificacion.Text <> "" And txtImpACargoOs.Text <> "" And txtImpACargoOs.Text <> "0" Then
            Dim bonificacion As Decimal = 0
            Dim AcargoOS = Decimal.Parse(txtImpACargoOs.Text)
            Dim impBonificacion = Decimal.Parse(txtBonificacion.Text)

            bonificacion = impBonificacion / AcargoOS
            If bonificacion >= 0 And bonificacion <= 1 Then
                nudBonificacion.Value = bonificacion
            End If
        End If
    End Sub

    Private Sub CalcularTotales()
        ''CALCULA LOS TOTALES DE LA GRIDITEMS
        Dim i As Integer
        Dim count As Integer = 0
        Dim Recaudado As Decimal = 0
        Dim ACargoOS As Decimal = 0
        Dim Total As Decimal = 0

        For i = 0 To grdItems.Rows.Count - 1
            With grdItems.Rows(i)
                If .Visible = True Then
                    Recaudado += .Cells(ColumnasDelGridItems.Recaudado).Value
                    ACargoOS += .Cells(ColumnasDelGridItems.ACargoOS).Value
                    Total += .Cells(ColumnasDelGridItems.Total).Value
                    count += 1
                End If
            End With
        Next

        txtRecaudado.Text = String.Format("{0:N2}", Recaudado)
        txtACargoOS.Text = String.Format("{0:N2}", ACargoOS)
        txtTotal.Text = String.Format("{0:N2}", Total)
        lblCantidadFilas.Text = count
    End Sub

    'Private Sub grdItems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdItems.CellBeginEdit
    '    editando_celda = True
    'End Sub

    'Private Sub grdItems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItems.CellEndEdit

    '    editando_celda = False

    '    'Cuando terminamos la edicion hay que buscar la descripcion del material y las unidad,
    '    'con esos datos completar la grilla. En este caso es la columna 2

    '    If e.ColumnIndex = ColumnasDelGridItems.Cod_material Then
    '        'completar la descripcion del   material
    '        Dim cell As DataGridViewCell = grdItems.CurrentCell

    '        Dim codigo As String, codigo_mat_prov As String = "", codunidad As String = "", codMoneda As String = ""

    '        Dim IdMoneda As Long, id As Long, idunidad As Long, idproveedor As Long, IdMat_Prov As Long

    '        Dim stock As Double = 0, preciovta As Double = 0, ganancia As Double = 0, preciolista As Double = 0, valorcambio As Double, iva As Double, montoiva As Double

    '        Dim proveedor As String = "", unidad As String = "", nombre As String = "", Pasillo As String = "", Estante As String = "", Fila As String = ""

    '        Dim fecha As Date = Nothing

    '        If grdItems.Rows(cell.RowIndex).Cells(cell.ColumnIndex).Value Is DBNull.Value Then Exit Sub
    '        codigo = grdItems.Rows(cell.RowIndex).Cells(cell.ColumnIndex).Value
    '        cell = grdItems.Rows(cell.RowIndex).Cells(cell.ColumnIndex + 1)

    '        If ObtenerMaterial_App(codigo, codigo_mat_prov, id, nombre, idunidad, unidad, codunidad, stock, 0, 0, preciolista, ganancia, preciovta, 0, 0, iva, fecha, idproveedor, proveedor, 0, "", "", IdMoneda, codMoneda, valorcambio, montoiva, IdMat_Prov, 0, ConnStringSEI, "", Pasillo, Estante, Fila) = 0 Then

    '            grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.IdMaterial).Value = id
    '            grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Nombre_Material).Value = nombre
    '            grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.IdUnidad).Value = idunidad
    '            grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Cod_Unidad).Value = codunidad
    '            grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Unidad).Value = unidad

    '            'grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.PrecioProvPesos).Value = preciolista * ValorCambioDO

    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif1).Value = 0.0
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif2).Value = 0.0
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif3).Value = 0.0
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif4).Value = 0.0
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif5).Value = 0.0

    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Qty).Value = 0.0

    '            grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Proveedor).Value = proveedor

    '            grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.QtyStock).Value = stock

    '            grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.IdMaterial_Prov).Value = IdMat_Prov
    '            grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Cod_Material_Prov).Value = codigo_mat_prov

    '            grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Iva).Value = iva

    '            grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Subtotal).Value = 0

    '            grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Ubicacion).Value = Pasillo + " - " + Estante + " - " + Fila

    '            If Pasillo.Length > 0 Then
    '                grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Cod_material).Style.BackColor = Color.LightGreen
    '                grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Cod_Material_Prov).Style.BackColor = Color.LightGreen
    '                grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Nombre_Material).Style.BackColor = Color.LightGreen
    '            End If

    '            Contar_Filas()

    '        Else
    '            cell.Value = "NO EXISTE"
    '        End If
    '    End If

    '    If grdItems.CurrentRow.Cells(ColumnasDelGridItems.Cod_material).Value Is DBNull.Value Then
    '        If grdItems.CurrentRow.Cells(ColumnasDelGridItems.PrecioLista).Value Is DBNull.Value Then
    '            grdItems.Rows(grdItems.CurrentRow.Index).Cells(ColumnasDelGridItems.PrecioLista).Value = FormatNumber(0, 2)
    '            grdItems.Rows(grdItems.CurrentRow.Index).Cells(ColumnasDelGridItems.Qty).Value = FormatNumber(0, 2)
    '            grdItems.Rows(grdItems.CurrentRow.Index).Cells(ColumnasDelGridItems.Subtotal).Value = FormatNumber(CDbl(0.0), 2)
    '        End If
    '    End If

    '    If e.ColumnIndex = ColumnasDelGridItems.Nombre_Material And _
    '        grdItems.CurrentRow.Cells(ColumnasDelGridItems.Cod_material).Value Is DBNull.Value Then

    '        Dim cell As DataGridViewCell = grdItems.CurrentCell
    '        Dim cod_unidad As String, nombreUNIDAD As String = "", codunidad As String = ""
    '        Dim idunidad As Long

    '        cod_unidad = "U"

    '        If ObtenerUnidad_App(cod_unidad, idunidad, nombreUNIDAD, codunidad, ConnStringSEI) = 0 Then
    '            grdItems.Rows(grdItems.CurrentRow.Index).Cells(ColumnasDelGridItems.IdUnidad).Value = idunidad
    '            grdItems.Rows(grdItems.CurrentRow.Index).Cells(ColumnasDelGridItems.Cod_Unidad).Value = cod_unidad
    '            grdItems.Rows(grdItems.CurrentRow.Index).Cells(ColumnasDelGridItems.Unidad).Value = nombreUNIDAD

    '            SendKeys.Send("{TAB}")

    '        Else
    '            cell.Value = "NO EXISTE"
    '            Exit Sub
    '        End If

    '        If grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif1).Value Is Nothing Or
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif1).Value Is DBNull.Value Then
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif1).Value = 0.0
    '        End If

    '        If grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif2).Value Is Nothing Or
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif2).Value Is DBNull.Value Then
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif2).Value = 0.0
    '        End If

    '        If grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif3).Value Is Nothing Or
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif3).Value Is DBNull.Value Then
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif3).Value = 0.0
    '        End If

    '        If grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif4).Value Is Nothing Or
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif4).Value Is DBNull.Value Then
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif4).Value = 0.0
    '        End If

    '        If grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif5).Value Is Nothing Or
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif5).Value Is DBNull.Value Then
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Bonif5).Value = 0.0
    '        End If

    '        If grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Qty).Value Is Nothing Or
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Qty).Value Is DBNull.Value Then
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Qty).Value = 0.0
    '        End If

    '        If grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Iva).Value Is Nothing Or
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Iva).Value Is DBNull.Value Then
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.Iva).Value = 0.0
    '        End If

    '        If grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.MontoIVA).Value Is Nothing Or
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.MontoIVA).Value Is DBNull.Value Then
    '            grdItems.Rows(cell.RowIndex).Cells(frmPresentaciones.ColumnasDelGridItems.MontoIVA).Value = 0.0
    '        End If


    '    End If

    '    If e.ColumnIndex = ColumnasDelGridItems.Cod_Unidad Then ' And _
    '        'grdItems.CurrentRow.Cells(ColumnasDelGridItems.Cod_material).Value Is DBNull.Value Then

    '        Dim cell As DataGridViewCell = grdItems.CurrentCell
    '        Dim cod_unidad As String, nombre As String = "", codunidad As String = ""
    '        Dim idunidad As Long

    '        cod_unidad = grdItems.Rows(cell.RowIndex).Cells(cell.ColumnIndex).Value

    '        cell = grdItems.Rows(cell.RowIndex).Cells(cell.ColumnIndex + 1)
    '        If ObtenerUnidad_App(cod_unidad, idunidad, nombre, codunidad, ConnStringSEI) = 0 Then
    '            cell.Value = nombre
    '            grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.IdUnidad).Value = idunidad
    '            grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Cod_Unidad).Value = cod_unidad
    '            grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Unidad).Value = nombre

    '            SendKeys.Send("{TAB}")

    '        Else

    '            cell.Value = "NO EXISTE"
    '            Exit Sub
    '        End If
    '    End If

    '    If e.ColumnIndex = ColumnasDelGridItems.PrecioLista Or e.ColumnIndex = ColumnasDelGridItems.Iva Then

    '        Dim cell As DataGridViewCell = grdItems.CurrentCell

    '        If Not (grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.PrecioLista).Value Is DBNull.Value) And _
    '             Not (grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Qty).Value Is DBNull.Value) And _
    '             Not (grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Iva).Value Is DBNull.Value) Then

    '            CalcularPrecio(cell)

    '        End If

    '        grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.PrecioVta).Value = grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.PrecioLista).Value

    '    End If

    '    If e.ColumnIndex = ColumnasDelGridItems.Bonif1 Or e.ColumnIndex = ColumnasDelGridItems.Bonif2 Or _
    '           e.ColumnIndex = ColumnasDelGridItems.Bonif3 Or e.ColumnIndex = ColumnasDelGridItems.Bonif4 Or _
    '           e.ColumnIndex = ColumnasDelGridItems.Bonif5 Then

    '        Dim cell As DataGridViewCell = grdItems.CurrentCell

    '        CalcularPrecio(cell)

    '    End If

    '    If e.ColumnIndex = ColumnasDelGridItems.Qty Then

    '        Dim cell As DataGridViewCell = grdItems.CurrentCell

    '        CalcularPrecio(cell)

    '        'Contar_Filas()

    '    End If

    'End Sub

    Private Sub grdItems_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)

        'controlar lo que se ingresa en la grilla
        'en este caso, que no se ingresen letras en el lote
        'If Me.grdItems.CurrentCell.ColumnIndex = ColumnasDelGridItems.PrecioVenta Then
        '    AddHandler e.Control.KeyPress, AddressOf validarNumerosReales
        'Else
        'If Me.grdItems.CurrentCell.ColumnIndex = ColumnasDelGridItems.PrecioUni Then
        '    AddHandler e.Control.KeyPress, AddressOf validarNumerosReales
        'Else
        '    If Me.grdItems.CurrentCell.ColumnIndex = ColumnasDelGridItems.Cantidad Then
        '        AddHandler e.Control.KeyPress, AddressOf validarNumerosReales
        '    Else
        '        If Me.grdItems.CurrentCell.ColumnIndex = ColumnasDelGridItems.Bonif1 Then
        '            AddHandler e.Control.KeyPress, AddressOf validarNumerosReales
        '        Else
        '            If Me.grdItems.CurrentCell.ColumnIndex = ColumnasDelGridItems.Bonif2 Then
        '                AddHandler e.Control.KeyPress, AddressOf validarNumerosReales
        '            Else
        '                If Me.grdItems.CurrentCell.ColumnIndex = ColumnasDelGridItems.Bonif3 Then
        '                    AddHandler e.Control.KeyPress, AddressOf validarNumerosReales
        '                    'Else
        '                    '    If Me.grdItems.CurrentCell.ColumnIndex = ColumnasDelGridItems.Iva Then
        '                    '        AddHandler e.Control.KeyPress, AddressOf validarNumerosReales
        '                    '    Else
        '                    '        AddHandler e.Control.KeyPress, AddressOf NoValidar
        '                    '    End If
        '                End If
        '            End If
        '        End If
        '    End If
        'End If
        'End If

    End Sub

    Private Sub chkEliminado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEliminado.CheckedChanged
        If Not bolModo Then
            cmbObraSocial.Enabled = Not chkEliminado.Checked
            grdItems.Enabled = Not chkEliminado.Checked
            dtpFECHA.Enabled = Not chkEliminado.Checked
            txtObservacion.Enabled = Not chkEliminado.Checked
        End If
    End Sub

    Private Sub PicProveedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New frmProveedores
        LLAMADO_POR_FORMULARIO = True
        ARRIBA = 90
        IZQUIERDA = Me.Left + 20
        texto_del_combo = cmbObraSocial.Text.ToUpper.ToString
        f.ShowDialog()
        LlenarcmbProveedores_App(cmbObraSocial, ConnStringSEI, 0, 0)
        cmbObraSocial.Text = texto_del_combo
    End Sub

    Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtID.KeyPress, txtObservacion.KeyPress
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

    'Private Sub grditems_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdItems.CellMouseUp
    '    Cell_X = e.ColumnIndex
    '    Cell_Y = e.RowIndex
    'End Sub

    'Private Sub grdItems_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdItems.CurrentCellChanged
    '    If band = 0 Then Exit Sub
    '    Try
    '        Cell_Y = grdItems.CurrentRow.Index
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub grdItems_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim columna As Integer = 0
        Dim Valor As String

        Try
            columna = grdItems.CurrentCell.ColumnIndex
        Catch ex As Exception

        End Try


        Valor = ""


    End Sub


    Private Sub llenarCmbEstados()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, " select distinct [estado] as Estado from Presentaciones")
            ds.Dispose()

            With Me.cmbEstado
                .DataSource = ds.Tables(0).DefaultView
                .DisplayMember = "estado"
                '.ValueMember = "ID"
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
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

    Private Sub LlenarCmbFarmacia()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, $" SELECT ID, NOMBRE FROM FARMACIAS WHERE ELIMINADO = 0")
            ds.Dispose()

            With cmbFarmacias
                .DataSource = ds.Tables(0).DefaultView
                .DisplayMember = "NOMBRE"
                .ValueMember = "ID"
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
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

    Private Sub LlenarCmbObraSocial()
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

    'Private Sub grdItems_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdItems.CellMouseDoubleClick

    '    If e.Button = Windows.Forms.MouseButtons.Right Then
    '        Exit Sub
    '    End If

    '    If Cell_Y < 0 Then
    '        Exit Sub
    '    End If

    '    BuscarProducto()
    '    grdItems.Columns(ColumnasDelGridItems.Marca).ReadOnly = True

    'End Sub

    Private Sub BorrarElItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BorrarElItemToolStripMenuItem.Click
        MsgBox($"Hello world: {sender.ToString}")
        'Dim cell As DataGridViewCell = grdItems.CurrentCell
        'Dim res As Integer

        'Try
        '    If bolModo Then
        '        grdItems.Rows.RemoveAt(cell.RowIndex) 'la borramos directamente
        '        Contar_Filas()
        '    Else
        '        'If bolModo = False And grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.IdMaterial).Value Is DBNull.Value Then
        '        ' grdItems.Rows.RemoveAt(cell.RowIndex) 'la borramos directamente
        '        'Contar_Filas()
        '        'Else
        '        If grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Status).Value.ToString = "CUMPLIDO" Then
        '            Util.MsgStatus(Status1, "No se puede borrar el registro. Ya está Cumplido.", My.Resources.stop_error.ToBitmap)
        '            Util.MsgStatus(Status1, "No se puede borrar el registro. Ya está Cumplido.", My.Resources.stop_error.ToBitmap, True)
        '        Else
        '            If grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Cantidad).Value <> IIf(grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Saldo).Value Is DBNull.Value, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Cantidad).Value, grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.Saldo).Value) Then
        '                Util.MsgStatus(Status1, "No se puede borrar el registro. Ya tiene Recepciones realizadas.", My.Resources.stop_error.ToBitmap)
        '                Util.MsgStatus(Status1, "No se puede borrar el registro. Ya tiene Recepciones realizadas.", My.Resources.stop_error.ToBitmap, True)
        '            Else
        '                If MessageBox.Show("Esta acción Eliminará el item de forma permanente." + vbCrLf + "¿Está seguro que desea eliminar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '                    Util.MsgStatus(Status1, "Eliminando el registro...", My.Resources.Resources.indicator_white)

        '                    Dim item As Long = grdItems.Rows(cell.RowIndex).Cells(ColumnasDelGridItems.IdOrdenDeCompra_Det).Value

        '                    grdItems.Rows.RemoveAt(cell.RowIndex) 'la borramos directamente de la grilla..
        '                    Contar_Filas()

        '                    res = EliminarRegistroItem(CType(txtID.Text, Long), item)

        '                    Select Case res
        '                        Case -1
        '                            Util.MsgStatus(Status1, "No se pudo borrar el Item.", My.Resources.stop_error.ToBitmap)
        '                            Util.MsgStatus(Status1, "No se pudo borrar el Item.", My.Resources.stop_error.ToBitmap, True)
        '                        Case Else
        '                            PrepararBotones()
        '                            btnActualizar_Click(sender, e)
        '                            'Setear_Grilla()
        '                            Util.MsgStatus(Status1, "Se ha borrado el Item.", My.Resources.ok.ToBitmap)
        '                            Util.MsgStatus(Status1, "Se ha borrado el Item.", My.Resources.ok.ToBitmap, True, True)
        '                    End Select
        '                Else
        '                    Util.MsgStatus(Status1, "Acción de eliminar Item cancelada.", My.Resources.stop_error.ToBitmap)
        '                    Util.MsgStatus(Status1, "Acción de eliminar Item cancelada.", My.Resources.stop_error.ToBitmap, True)
        '                End If
        '            End If
        '        End If
        '    End If
        '    'End If
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub BuscarDescripcionToolStripMenuItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BuscarDescripcionToolStripMenuItem.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            BuscarDescripcionToolStripMenuItem_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub BuscarDescripcionToolStripMenuItem2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BuscarDescripcionToolStripMenuItem2.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            BuscarDescripcionToolStripMenuItem2_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub BuscarDescripcionToolStripMenuItem3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BuscarDescripcionToolStripMenuItem3.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            BuscarDescripcionToolStripMenuItem3_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub BuscarDescripcionToolStripMenuItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarDescripcionToolStripMenuItem.SelectedIndexChanged

        Dim columna As Integer = 0
        columna = grdItems.CurrentCell.ColumnIndex

        Dim cell As DataGridViewCell = grdItems.Rows(Cell_Y).Cells(columna)
        grdItems.CurrentCell = cell
        grdItems.CurrentCell.Value = BuscarDescripcionToolStripMenuItem.ComboBox.SelectedValue

        ContextMenuStrip1.Close()
        grdItems.BeginEdit(True)

    End Sub

    Private Sub BuscarDescripcionToolStripMenuItem2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarDescripcionToolStripMenuItem2.SelectedIndexChanged

        Dim columna As Integer = 0
        columna = grdItems.CurrentCell.ColumnIndex

        Dim cell As DataGridViewCell = grdItems.Rows(Cell_Y).Cells(columna)
        grdItems.CurrentCell = cell
        grdItems.CurrentCell.Value = BuscarDescripcionToolStripMenuItem2.ComboBox.Text

        ContextMenuStrip1.Close()
        grdItems.BeginEdit(True)

    End Sub

    Private Sub BuscarDescripcionToolStripMenuItem3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarDescripcionToolStripMenuItem3.SelectedIndexChanged

        Dim columna As Integer = 0
        columna = grdItems.CurrentCell.ColumnIndex

        Dim cell As DataGridViewCell = grdItems.Rows(Cell_Y).Cells(columna)
        grdItems.CurrentCell = cell
        grdItems.CurrentCell.Value = BuscarDescripcionToolStripMenuItem3.ComboBox.Text

        ContextMenuStrip1.Close()
        grdItems.BeginEdit(True)

    End Sub


    Private Sub cmbObraSocial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbObraSocial.SelectedIndexChanged
        If band = 1 Then
            If cmbObraSocial.SelectedValue IsNot Nothing Then
                txtIdObrasocial.Text = cmbObraSocial.SelectedValue.ToString
            End If

        End If
    End Sub

    '(currentcellchanged)
    Protected Overloads Sub grd_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Permitir Then
            'band = 0
            Try

                'lblCantidadFilas.Text = grdItems.Rows.Count
                'txtID.Text = grd.CurrentRow.Cells(0).Value
                'txtRecaudado.Text = grd.CurrentRow.Cells(4).Value
                'txtObservacion.Text = grd.CurrentRow.Cells(6).Value
                'Dim filasGrd = grd.Rows.Count - 1
                'If filasGrd = 0 Then
                '    lblStatus.Text = "-"
                'End If

                'cmbObraSocial.SelectedValue = grd.CurrentRow.Cells(13).Value
                'txtPeriodo.Text = grd.CurrentRow.Cells(14).Value

                'LlenarGrid_Items()

            Catch ex As Exception
                'band = 1
            End Try
        End If
    End Sub

    'Private Sub rdAnuladas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdAnuladas.CheckedChanged
    '    btnGuardar.Enabled = Not rdAnuladas.Checked
    '    btnEliminar.Enabled = Not rdAnuladas.Checked
    '    btnNuevo.Enabled = Not rdAnuladas.Checked
    '    btnCancelar.Enabled = Not rdAnuladas.Checked

    '    SQL = $"exec spPresentaciones_Select_All @Pendientes = {rdPendientes.Checked} ,@Eliminado = {rdAnuladas.Checked} ,@Todos = {rdTodasOC.Checked}"
    '    Try
    '        LlenarGrilla()

    '        If grd.Rows.Count > 0 Then
    '            grdItems.Columns(16).Visible = False
    '        End If
    '    Catch ex As Exception

    '    End Try



    'End Sub

    'Private Sub rdPendientes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdPendientes.CheckedChanged

    '    If band = 1 Then
    '        SQL = $"exec spPresentaciones_Select_All @Pendientes = {rdPendientes.Checked} ,@Eliminado = {rdAnuladas.Checked} ,@Todos = {rdTodasOC.Checked}"

    '        Try
    '            LlenarGrilla()

    '            If grd.Rows.Count > 0 Then

    '                grd.Rows(0).Selected = True
    '                txtID.Text = grd.Rows(0).Cells(0).Value
    '                LlenarGrid_Items()
    '                grdItems.Columns(16).Visible = True
    '            End If

    '        Catch ex As Exception

    '        End Try

    '    End If

    'End Sub

    'Private Sub rdTodasOC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTodasOC.CheckedChanged

    '    If band = 1 Then
    '        SQL = $"exec spPresentaciones_Select_All @Pendientes = {rdPendientes.Checked} ,@Eliminado = {rdAnuladas.Checked} ,@Todos = {rdTodasOC.Checked}"

    '        Try
    '            LlenarGrilla()

    '            If grd.Rows.Count > 0 Then
    '                grdItems.Columns(16).Visible = True
    '                LlenarGrid_Items()
    '            End If
    '        Catch ex As Exception

    '        End Try


    '    End If

    'End Sub

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
            grdItems.Height = grdItems.Height - variableajuste
            GbFarmaciaForm.Height = GbFarmaciaForm.Height - variableajuste
            Label19.Location = New Point(Label19.Location.X, Label19.Location.Y - variableajuste)
            lblCantidadFilas.Location = New Point(lblCantidadFilas.Location.X, lblCantidadFilas.Location.Y - variableajuste)

            'rdPendientes.Location = New Point(rdPendientes.Location.X, rdPendientes.Location.Y - variableajuste)
            'rdAnuladas.Location = New Point(rdAnuladas.Location.X, rdAnuladas.Location.Y - variableajuste)
            'rdTodasOC.Location = New Point(rdTodasOC.Location.X, rdTodasOC.Location.Y - variableajuste)

            Label4.Location = New Point(Label4.Location.X, Label4.Location.Y - variableajuste)
            txtRecaudado.Location = New Point(txtRecaudado.Location.X, txtRecaudado.Location.Y - variableajuste)

            Label18.Location = New Point(Label18.Location.X, Label18.Location.Y - variableajuste)
            txtTotal.Location = New Point(txtTotal.Location.X, txtTotal.Location.Y - variableajuste)

            Label20.Location = New Point(Label20.Location.X, Label20.Location.Y - variableajuste)
            txtACargoOS.Location = New Point(txtACargoOS.Location.X, txtACargoOS.Location.Y - variableajuste)

        Else
            chkGrillaInferior.Text = "Aumentar Grilla Inferior"
            chkGrillaInferior.Location = New Point(chkGrillaInferior.Location.X, chkGrillaInferior.Location.Y + variableajuste)
            GroupBox1.Height = GroupBox1.Height + variableajuste
            grd.Location = New Point(xgrd, ygrd + variableajuste)
            grd.Height = hgrd - variableajuste
            grdItems.Height = grdItems.Height + variableajuste
            GbFarmaciaForm.Height = GbFarmaciaForm.Height + variableajuste
            Label19.Location = New Point(Label19.Location.X, Label19.Location.Y + variableajuste)
            lblCantidadFilas.Location = New Point(lblCantidadFilas.Location.X, lblCantidadFilas.Location.Y + variableajuste)

            'rdPendientes.Location = New Point(rdPendientes.Location.X, rdPendientes.Location.Y + variableajuste)
            'rdAnuladas.Location = New Point(rdAnuladas.Location.X, rdAnuladas.Location.Y + variableajuste)
            'rdTodasOC.Location = New Point(rdTodasOC.Location.X, rdTodasOC.Location.Y + variableajuste)

            Label4.Location = New Point(Label4.Location.X, Label4.Location.Y + variableajuste)
            txtRecaudado.Location = New Point(txtRecaudado.Location.X, txtRecaudado.Location.Y + variableajuste)

            Label18.Location = New Point(Label18.Location.X, Label18.Location.Y + variableajuste)
            txtTotal.Location = New Point(txtTotal.Location.X, txtTotal.Location.Y + variableajuste)

            Label20.Location = New Point(Label20.Location.X, Label20.Location.Y + variableajuste)
            txtACargoOS.Location = New Point(txtACargoOS.Location.X, txtACargoOS.Location.Y + variableajuste)

        End If

    End Sub


    Private Sub grdItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdItems.CellContentClick
        If grdItems.Columns(e.ColumnIndex).Name = "Eliminar" And e.RowIndex > -1 Then
            If cmbEstado.Text = "PRESENTADO" Then
                Dim result As DialogResult = MessageBox.Show($"Desea eliminar el item {grdItems.Rows(e.RowIndex).Cells(ColumnasDelGridItems.Nombre).Value}?",
                                  "Eliminar",
                                  MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    'MsgBox(bolModo)
                    If grdItems.Rows(e.RowIndex).Cells(ColumnasDelGridItems.ID).Value = 0 Then
                        grdItems.Rows.RemoveAt(e.RowIndex) 'la borramos directamente
                    Else
                        grdItems.Rows(e.RowIndex).Visible = False
                    End If
                    CalcularTotales()
                End If
            Else
                MsgBox("No puede eliminar un item que ya tiene una liquidación asociada.")
            End If
        End If


    End Sub

#End Region

#Region "   Procedimientos"

    Private Sub configurarform()

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

    Private Sub filtrarPorEstado(estado)

        If band = 1 Then
            SQL = $"exec spPresentaciones_Select_All @Estado = {estado}, @Eliminado = 0"

            Try
                LlenarGrilla()

                If bolModo = True Then

                End If

                If grd.Rows.Count > 0 Then
                    grd.Rows(0).Selected = True
                    txtID.Text = grd.Rows(0).Cells(0).Value
                    LlenarGrid_Items()
                Else
                    lblStatus.Text = "-"
                    grdItems.DataSource = Nothing
                    LimpiarGridItems(grdItems)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            bloquearPresentacion(estado)
        End If
    End Sub





    Private Sub bloquearPresentacion(cmbstatus)


        If cmbstatus = "PRESENTADO" Then
            'GbFarmaciaForm.Enabled = True
            'grdItems.Enabled = True
            btnAgregarItem.Enabled = True
            btnGuardar.Enabled = True
            btnNuevo.Enabled = True
        End If

        If cmbstatus = "" Then
            btnAgregarItem.Enabled = True
            btnGuardar.Enabled = True
            btnNuevo.Enabled = True


        End If

        If cmbstatus <> "PRESENTADO" And cmbstatus <> "" Then
            btnAgregarItem.Enabled = False
            'grdItems.ReadOnly = True

            btnGuardar.Enabled = False
            btnNuevo.Enabled = True
        End If

    End Sub


    Private Sub asignarTags()
        txtID.Tag = "0"
        txtCodigo.Tag = "1"
        dtpFECHA.Tag = "2"
        txtIdObrasocial.Tag = "3"
        cmbObraSocial.Tag = "3" ''nacho mati
        txtPeriodo.Tag = "5"
        lblStatus.Tag = "6"
        txtTotal.Tag = "7"
        txtObservacion.Tag = "8"

    End Sub

    Private Sub Verificar_Datos()

        Dim i As Integer, j As Integer, filas As Integer ', res As Integer ', state As Integer

        bolpoliticas = False

        Util.MsgStatus(Status1, "Verificando los datos...", My.Resources.Resources.indicator_white)

        'Verificar si todos los combox tienen algo válido
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not (cmbObraSocial.SelectedIndex > -1) Then
            Util.MsgStatus(Status1, "Ingrese un valor válido en el campo 'Proveedor'.", My.Resources.Resources.alert.ToBitmap)
            Util.MsgStatus(Status1, "Ingrese un valor válido en el campo 'Proveedor'.", My.Resources.Resources.alert.ToBitmap, True)
            cmbObraSocial.Focus()
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
            filas = filas + 1

        Next i
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

    Private Sub PrepararGridItems()
        Util.LimpiarGridItems(grdItems)
    End Sub

    Private Sub AñadirGridItem()
        ''CONTROL DE INPUTS
        If cmbFarmacias.SelectedValue Is DBNull.Value Or cmbFarmacias.SelectedValue = 0 Or cmbFarmacias.Text = "" Then
            Util.MsgStatus(Status1, "Debe ingresar una farmacia VÁLIDA.", My.Resources.Resources.stop_error.ToBitmap)
            Util.MsgStatus(Status1, "Debe ingresar una farmacia VÁLIDA.", My.Resources.Resources.stop_error.ToBitmap, True)
            '               GoTo Continuar
            Exit Sub
        End If

        If txtRecetas.Text = "" Or txtRecetas.Text = "0" Then
            Util.MsgStatus(Status1, "Debe ingresar la cantidad de recetas.", My.Resources.Resources.stop_error.ToBitmap)
            Util.MsgStatus(Status1, "Debe ingresar la cantidad de recetas.", My.Resources.Resources.stop_error.ToBitmap, True)
            Exit Sub
        End If

        If txtImpRecaudado.Text = "" Or txtImpRecaudado.Text = "0" Then
            Util.MsgStatus(Status1, "Debe ingresar el importe 100%.", My.Resources.Resources.stop_error.ToBitmap)
            Util.MsgStatus(Status1, "Debe ingresar el importe 100%.", My.Resources.Resources.stop_error.ToBitmap, True)
            Exit Sub
        End If

        If txtImpACargoOs.Text = "" Or txtImpACargoOs.Text = "0" Then
            Util.MsgStatus(Status1, "Debe ingresar el importe a cargo de la Obra Social.", My.Resources.Resources.stop_error.ToBitmap)
            Util.MsgStatus(Status1, "Debe ingresar el importe a cargo de la Obra Social.", My.Resources.Resources.stop_error.ToBitmap, True)
            Exit Sub
        End If

        'EVITAR REPETIDOS
        'Dim i As Integer
        'For i = 0 To grdItems.RowCount - 1
        '    If cmbFarmacias.Text = grdItems.Rows(i).Cells(ColumnasDelGridItems.Nombre).Value Then
        '        'Util.MsgStatus(Status1, "La Farmacia '" & cmbFarmacias.Text & "' está repetido en la fila: " & (i + 1).ToString & ".", My.Resources.Resources.alert.ToBitmap, True)
        '        Util.MsgStatus(Status1, $"La Farmacia {cmbFarmacias.Text} está repetido en la fila: {(i + 1)}.", My.Resources.Resources.alert.ToBitmap, True)
        '        Exit Sub
        '    End If
        'Next

        Dim row As New DataGridViewRow()
        row.CreateCells(grdItems)

        With row
            .Cells(ColumnasDelGridItems.ID).Value = 0
            .Cells(ColumnasDelGridItems.Nombre).Value = cmbFarmacias.Text
            .Cells(ColumnasDelGridItems.IdFarmacia).Value = cmbFarmacias.SelectedValue
            .Cells(ColumnasDelGridItems.Recetas).Value = txtRecetas.Text
            .Cells(ColumnasDelGridItems.Recaudado).Value = txtImpRecaudado.Text
            .Cells(ColumnasDelGridItems.ACargoOS).Value = txtImpACargoOs.Text
            .Cells(ColumnasDelGridItems.Bonificacion).Value = nudBonificacion.Text
            .Cells(ColumnasDelGridItems.Total).Value = txtImpTotalAPagar.Text

        End With

        grdItems.Rows.Add(row)

        CalcularTotales()

        cmbFarmacias.Text = ""
        cmbFarmacias.SelectedValue = DBNull.Value
        txtRecetas.Text = ""
        txtImpRecaudado.Text = ""
        txtImpACargoOs.Text = ""
        nudBonificacion.Value = 0
        txtImpTotalAPagar.Text = ""
        cmbFarmacias.Focus()
    End Sub

    Private Sub LlenarGrid_Items()

        grdItems.Rows.Clear()

        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            Dim dt As New DataTable

            'SQL = "exec spOrdenDeCompra_Det_Select_By_IDOrdenDeCompra @IDOrdenDeCompra = " & IIf(txtID.Text = "", 0, txtID.Text) & ", @Anulado = " & rdAnuladas.Checked

            'SQL = "exec spPresentaciones_Det_Select_By_IDPresentacion @IDPresentacion = 1"

            If txtID.Text = "" Then
                SQL = "exec spPresentaciones_Det_Select_By_IDPresentacion @IDPresentacion = '1'"
            Else
                SQL = "exec spPresentaciones_Det_Select_By_IDPresentacion @IDPresentacion = " & txtID.Text & ""
            End If

            Dim cmd As New SqlCommand(SQL, connection)
            Dim da As New SqlDataAdapter(cmd)
            Dim i As Integer

            da.Fill(dt)

            For i = 0 To dt.Rows.Count - 1

                ''MATI
                grdItems.Rows.Add(
                    dt.Rows(i)(ColumnasDelGridItems.ID).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.IdFarmacia).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.CodigoFarmacia).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.Nombre).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.IdPresentacion).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.Recetas).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.Recaudado).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.ACargoOS).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.Bonificacion).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.Total).ToString())
                ' rodrigo 

            Next

            Dim data As New GroupedDataTable(dt, "IdFarmacia")

            'grdDebug.DataSource = data.grouped

            CalcularTotales()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try


        'GetDatasetItems()

        'CheckForIllegalCrossThreadCalls = False

        'trd = New Thread(AddressOf HiloOcultarColumnasGridItems)
        'trd.IsBackground = True
        'trd.Start()

        'HiloOcultarColumnasGridItems()

        'SQL = "exec spOrdenDeCompra_Select_All @Eliminado = " & rdAnuladas.Checked & ", @Pendientes = " & rdPendientes.Checked & ", @PendientesyCumplidas = " & rdTodasOC.Checked

    End Sub

    Private Sub GetDatasetItems()
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds_2 = SqlHelper.ExecuteDataset(connection, CommandType.Text, SQL)
            ds_2.Dispose()

            grdItems.DataSource = ds_2.Tables(0).DefaultView

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

    Private Sub NoValidar(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim caracter As Char = e.KeyChar
        Dim obj As System.Windows.Forms.DataGridViewTextBoxEditingControl = sender
        e.KeyChar = Convert.ToChar(e.KeyChar.ToString)
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

    Private Sub validarNumeros(ByVal sender As Object,
       ByVal e As System.Windows.Forms.KeyPressEventArgs)

        'Controlar que el caracter ingresado sea un  numero
        Dim caracter As Char = e.KeyChar
        If caracter = "." Or caracter = "," Then
            e.Handled = True ' no dejar escribir
        Else
            If Char.IsNumber(caracter) Or caracter = ChrW(Keys.Back) Or caracter = ChrW(Keys.Delete) Or caracter = ChrW(Keys.Enter) Then
                e.Handled = False 'dejo escribir
            Else
                e.Handled = True ' no dejar escribir
            End If
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

    Private Sub Imprimir(ByVal Presupuesto As Boolean)
        'nbreformreportes = "Orden de Compra / Presupuesto"

        'Dim cnn As New SqlConnection(ConnStringSEI)
        'Dim Rpt As New frmReportes

        'If Presupuesto Then
        '    Rpt.NombreArchivoPDF = "Solicitud de Cotización " & txtCODIGO.Text & " - " & cmbPROVEEDORES.Text.ToString
        'Else
        '    Rpt.NombreArchivoPDF = "Orden de Compra " & txtCODIGO.Text & " - " & cmbPROVEEDORES.Text.ToString
        'End If

        'Rpt.OrdenesDeCompra_Maestro_App(txtCODIGO.Text, 0, Rpt, My.Application.Info.AssemblyName.ToString, Presupuesto)

        'cnn = Nothing

    End Sub


    Private Sub EstiloGrdItems()
        With grdItems
            .VirtualMode = False
            .AllowUserToAddRows = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine
            .RowsDefaultCellStyle.BackColor = Color.White
            .AllowUserToOrderColumns = False
            '.SelectionMode = DataGridViewSelectionMode.CellSelect
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        End With

        With grdItems.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Black  'Color.BlueViolet
            .ForeColor = Color.White
            .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        End With

        grdItems.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
    End Sub



    Private Sub HiloOcultarColumnasGridItems()
        Try

            With grdItems
                .VirtualMode = False
                .AllowUserToAddRows = False 'True
                .AllowUserToDeleteRows = False 'True
                .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
                .RowsDefaultCellStyle.BackColor = Color.White
                .AllowUserToOrderColumns = False
                '.SelectionMode = DataGridViewSelectionMode.CellSelect
                .ForeColor = Color.Black
                .MultiSelect = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            End With


            With grdItems.ColumnHeadersDefaultCellStyle
                .BackColor = Color.Black  'Color.BlueViolet
                .ForeColor = Color.White
                .Font = New Font("TAHOMA", 8, FontStyle.Bold)
            End With

            grdItems.Font = New Font("TAHOMA", 8, FontStyle.Regular)

        Catch ex As Exception

        End Try
    End Sub

    'Private Sub LlenarcmbMarcasProductos()
    '    Dim connection As SqlClient.SqlConnection = Nothing
    '    Dim ds_Marcas As Data.DataSet

    '    Try
    '        connection = SqlHelper.GetConnection(ConnStringSEI)
    '    Catch ex As Exception
    '        MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Sub
    '    End Try

    '    Try

    '        ds_Marcas = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT id, rtrim(nombre) as Marca FROM Marcas")
    '        ds_Marcas.Dispose()

    '        With Me.cmbMarcaCompra.ComboBox
    '            .DataSource = ds_Marcas.Tables(0).DefaultView
    '            .DisplayMember = "Marca"
    '            .ValueMember = "Id"
    '            .AutoCompleteMode = AutoCompleteMode.Suggest
    '            .AutoCompleteSource = AutoCompleteSource.ListItems
    '            .DropDownStyle = ComboBoxStyle.DropDown
    '            .BindingContext = Me.BindingContext
    '            .SelectedIndex = 0
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


#End Region

#Region "   Funciones"

    Private Function AgregarActualizar_Registro() As Integer
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim res As Integer = 0
        Dim prueba
        Try

            connection = SqlHelper.GetConnection(ConnStringSEI)
            'Abrir una transaccion para guardar y asegurar que se guarda todo
            If Abrir_Tran(connection) = False Then
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
                param_codigo.Size = 10
                If bolModo = True Then
                    param_codigo.Value = DBNull.Value
                    param_codigo.Direction = ParameterDirection.InputOutput
                Else
                    param_codigo.Value = txtCodigo.Text
                    param_codigo.Direction = ParameterDirection.Input
                End If

                Dim param_fecha As New SqlClient.SqlParameter
                param_fecha.ParameterName = "@fecha"
                param_fecha.SqlDbType = SqlDbType.DateTime
                param_fecha.Value = dtpFECHA.Value
                param_fecha.Direction = ParameterDirection.Input

                Dim param_IdObraSocial As New SqlClient.SqlParameter
                param_IdObraSocial.ParameterName = "@idObraSocial"
                param_IdObraSocial.SqlDbType = SqlDbType.BigInt
                param_IdObraSocial.Value = cmbObraSocial.SelectedValue
                param_IdObraSocial.Direction = ParameterDirection.Input

                Dim param_observacion As New SqlClient.SqlParameter
                param_observacion.ParameterName = "@observaciones"
                param_observacion.SqlDbType = SqlDbType.VarChar
                param_observacion.Size = 300
                param_observacion.Value = txtObservacion.Text
                param_observacion.Direction = ParameterDirection.Input

                Dim param_periodo As New SqlClient.SqlParameter
                param_periodo.ParameterName = "@periodo"
                param_periodo.SqlDbType = SqlDbType.VarChar
                param_periodo.Size = 100
                param_periodo.Value = txtPeriodo.Text
                param_periodo.Direction = ParameterDirection.Input

                Dim param_total As New SqlClient.SqlParameter
                param_total.ParameterName = "@Total"
                param_total.SqlDbType = SqlDbType.Decimal
                param_total.Precision = 18
                param_total.Scale = 2
                param_total.Value = 0 'Decimal.Parse(txtSubtotal.Text)
                param_total.Direction = ParameterDirection.Input

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
                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPresentaciones_Insert",
                                                param_id, param_codigo, param_fecha, param_IdObraSocial, param_observacion,
                                                param_periodo, param_total, param_useradd, param_res)

                        txtID.Text = param_id.Value
                        prueba = param_codigo.Value
                        txtCodigo.Text = param_codigo.Value
                    Else
                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPresentaciones_Update",
                                                param_id, param_codigo, param_fecha, param_IdObraSocial, param_observacion,
                                                param_periodo, param_total, param_useradd, param_res)

                    End If

                    AgregarActualizar_Registro = param_res.Value

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
            'Finally
            '    'If Not connection Is Nothing Then
            '    CType(connection, IDisposable).Dispose()
            'End If
        End Try
    End Function

    Private Function AgregarActualizar_Registro_Items() As Integer
        Dim res As Integer = 0
        Dim i As Integer

        Try

            For i = 0 To grdItems.RowCount - 1 'CantidadFilas

                Dim param_id As New SqlClient.SqlParameter
                param_id.ParameterName = "@id"
                param_id.SqlDbType = SqlDbType.BigInt
                param_id.Value = CType(grdItems.Rows(i).Cells(ColumnasDelGridItems.ID).Value, Long)
                param_id.Direction = ParameterDirection.Input

                Dim param_IdFarmacia As New SqlClient.SqlParameter
                param_IdFarmacia.ParameterName = "@idFarmacia"
                param_IdFarmacia.SqlDbType = SqlDbType.BigInt
                param_IdFarmacia.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems.IdFarmacia).Value
                param_IdFarmacia.Direction = ParameterDirection.Input

                Dim param_IdPresentacion As New SqlClient.SqlParameter
                param_IdPresentacion.ParameterName = "@idPresentacion"
                param_IdPresentacion.SqlDbType = SqlDbType.BigInt
                param_IdPresentacion.Value = Long.Parse(txtID.Text)
                param_IdPresentacion.Direction = ParameterDirection.Input

                Dim param_Recetas As New SqlClient.SqlParameter
                param_Recetas.ParameterName = "@recetas"
                param_Recetas.SqlDbType = SqlDbType.Int
                param_Recetas.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems.Recetas).Value
                param_Recetas.Direction = ParameterDirection.Input

                Dim param_Recaudado As New SqlClient.SqlParameter
                param_Recaudado.ParameterName = "@recaudado"
                param_Recaudado.SqlDbType = SqlDbType.Decimal
                param_Recaudado.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems.Recaudado).Value
                param_Recaudado.Direction = ParameterDirection.Input

                Dim param_AcargoOS As New SqlClient.SqlParameter
                param_AcargoOS.ParameterName = "@acargoOS"
                param_AcargoOS.SqlDbType = SqlDbType.Decimal
                param_AcargoOS.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems.ACargoOS).Value
                param_AcargoOS.Direction = ParameterDirection.Input

                Dim param_Bonificacion As New SqlClient.SqlParameter
                param_Bonificacion.ParameterName = "@bonificacion"
                param_Bonificacion.SqlDbType = SqlDbType.Decimal
                param_Bonificacion.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems.Bonificacion).Value
                param_Bonificacion.Direction = ParameterDirection.Input

                Dim param_Total As New SqlClient.SqlParameter
                param_Total.ParameterName = "@total"
                param_Total.SqlDbType = SqlDbType.Decimal
                param_Total.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems.Total).Value
                param_Total.Direction = ParameterDirection.Input

                Dim param_eliminado As New SqlClient.SqlParameter
                param_eliminado.ParameterName = "@eliminado"
                param_eliminado.SqlDbType = SqlDbType.Bit
                param_eliminado.Value = IIf(grdItems.Rows(i).Visible = True, 0, 1)
                param_eliminado.Direction = ParameterDirection.Input

                Dim param_user As New SqlClient.SqlParameter
                param_user.ParameterName = "@user"
                param_user.SqlDbType = SqlDbType.Int
                param_user.Value = UserID
                param_user.Direction = ParameterDirection.Input


                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.InputOutput

                Try

                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPresentaciones_Det_Insert_Update",
                                                  param_id, param_IdFarmacia, param_IdPresentacion, param_Recetas,
                                                  param_Recaudado, param_AcargoOS, param_Bonificacion, param_Total,
                                                  param_eliminado, param_user, param_res)

                    res = param_res.Value


                    'If res = -20 Then
                    '    MsgBox("La cantidad ingresada para el Item " & grdItems.Rows(i).Cells(ColumnasDelGridItems.Producto).Value & " es menor al saldo actual.", MsgBoxStyle.Critical, "Atención")
                    'End If

                    'If res = -10 Then
                    '    Util.MsgStatus(Status1, "No se puede modificar el material '" & grdItems.Rows(i).Cells(ColumnasDelGridItems.Producto).Value.ToString.Substring(0, 30) & "...'" & vbCrLf &
                    '                   "La unidad ingresada es diferente a la unidad dentro de los movimientos de Stock.", My.Resources.Resources.stop_error.ToBitmap, True)
                    'End If

                    If (res <= 0) Then
                        Exit For
                    End If

                Catch ex As Exception
                    Throw ex
                End Try

            Next

            AgregarActualizar_Registro_Items = res

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

    Private Function EliminarRegistro(ByVal Estado As String) As Integer

        Dim connection As SqlClient.SqlConnection = Nothing
        Dim res As Integer = 0

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
            ''Abrir una transaccion para guardar y asegurar que se guarda todo
            'If Abrir_Tran(connection) = False Then
            '    MessageBox.Show("No se pudo abrir una transaccion", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Exit Function
            'End If

            Try

                Dim param_idordendecompra As New SqlClient.SqlParameter("@idordendecompra", SqlDbType.BigInt, ParameterDirection.Input)
                param_idordendecompra.Value = CType(txtID.Text, Long)
                param_idordendecompra.Direction = ParameterDirection.Input

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
                    If Estado = "Anular" Then
                        SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spOrdenDeCompra_Delete_All", param_idordendecompra, param_userdel, param_res)
                    Else
                        SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spOrdenDeCompra_Delete_Finalizar", param_idordendecompra, param_userdel, param_res)
                    End If

                    res = param_res.Value

                    EliminarRegistro = res

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
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
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



    Private Function CuentaRecepcionesPorOrdenDeCompra(ByVal IDoc As String) As Integer
        Dim res As Integer = 0
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End Try

        Try
            Try

                Dim param_idoc As New SqlClient.SqlParameter
                param_idoc.ParameterName = "@idoc"
                param_idoc.SqlDbType = SqlDbType.BigInt
                param_idoc.Value = IDoc
                param_idoc.Direction = ParameterDirection.Input

                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.Output

                Try
                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spCuentaRecepcionesPorOrdenDeCompra", param_idoc, param_res)
                    res = param_res.Value

                    CuentaRecepcionesPorOrdenDeCompra = res

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
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Function

    'Private Function BuscarProveedor(ByVal codigoOC As String, ByRef Solicitud As Boolean) As String
    '    Dim connection As SqlClient.SqlConnection = Nothing
    '    Dim dsProveedor As Data.DataSet

    '    Try
    '        connection = SqlHelper.GetConnection(ConnStringSEI)
    '    Catch ex As Exception
    '        MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        BuscarProveedor = ""
    '        Exit Function
    '    End Try

    '    Try

    '        dsProveedor = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT p.nombre, solicitud FROM OrdenDeCompra o JOIN Proveedores p	ON P.id = o.IdProveedor WHERE o.codigo = " & codigoOC)

    '        dsProveedor.Dispose()

    '        If dsProveedor.Tables(0).Rows.Count > 0 Then
    '            BuscarProveedor = dsProveedor.Tables(0).Rows(0).Item(0)
    '            Solicitud = dsProveedor.Tables(0).Rows(0).Item(1)
    '        Else
    '            BuscarProveedor = ""
    '        End If

    '    Catch ex As Exception
    '        Dim errMessage As String = ""
    '        Dim tempException As Exception = ex

    '        While (Not tempException Is Nothing)
    '            errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
    '            tempException = tempException.InnerException
    '        End While

    '        MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
    '          + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
    '          "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '        BuscarProveedor = ""

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
                    'cell = grdItems.Rows(0).Cells(ColumnasDelGridItems.IdOrdenDeCompra_Det)
                Else
                    ' Selecionamos la primera columna de la siguiente fila.
                    'cell = grdItems.Rows(rowIndex + 1).Cells(ColumnasDelGridItems.IdOrdenDeCompra_Det)
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

        Try
            'If grdItems.CurrentCell.ColumnIndex - 1 = ColumnasDelGridItems.Qty Then
            '    grdItems.CurrentCell = grdItems(ColumnasDelGridItems.Cod_material, grdItems.CurrentRow.Index + 1)
            '    Return True
            'End If

            'If grdItems.CurrentCell.ColumnIndex - 1 = ColumnasDelGridItems.Cod_material Then
            '    grdItems.CurrentCell = grdItems(ColumnasDelGridItems.Qty, grdItems.CurrentRow.Index)
            '    Return True
            'End If

        Catch ex As Exception

        End Try

        ' ... y la ponemos en modo de edición.
        grdItems.BeginEdit(True)
        Return True

    End Function

#End Region

#Region "   Botones"

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click


        'If MessageBox.Show("Desea generar una nueva Presentación?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
        '    LimpiarGridItems(grdItems)
        '    'bolModo = False
        '    Exit Sub
        'End If
        bloquearPresentacion(cmbEstado.Text)
        band = 0
        bolModo = True
        Util.MsgStatus(Status1, "Haga click en [Guardar] despues de completar los datos.")
        PrepararBotones()

        chkEliminado.Checked = False
        cmbObraSocial.Enabled = True

        grdItems.Enabled = True
        dtpFECHA.Enabled = True
        txtObservacion.Enabled = True

        'Try
        '    grdItems.Columns(ColumnasDelGridItems.Status).Visible = Not bolModo

        '    grdItems.Columns(ColumnasDelGridItems.Saldo).Visible = Not bolModo
        'Catch ex As Exception

        'End Try
        Util.LimpiarTextBox(Me.Controls)
        'If btnBand_Copiar = True Then
        '    Util.LimpiarTextBox(Me.Controls)
        'End If

        PrepararGridItems()

        lblCantidadFilas.Text = "0"

        'cmbAutoriza.SelectedValue = 2

        lblStatus.Text = "EN PROCESO"

        'btnCopiarOC.Enabled = False
        'btnFinalizar.Enabled = False

        dtpFECHA.Focus()

        band = 1

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim res As Integer, res_item As Integer
        Dim registro As Integer

        Util.MsgStatus(Status1, "Guardando el registro...", My.Resources.Resources.indicator_white)

        'If chkEliminado.Checked = True Then
        '    Util.MsgStatus(Status1, "No se puede actualizar el registo. Está Eliminado", My.Resources.Resources.stop_error.ToBitmap, True)
        '    Exit Sub
        'End If

        ''''''''''''''''para posicionarme en la fila actual...
        If Not (bolModo) Then
            registro = grd.CurrentRow.Index
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If ReglasNegocio() Then
            Verificar_Datos()
            If bolpoliticas Then
                Util.MsgStatus(Status1, "Guardando el registro...", My.Resources.Resources.indicator_white)
                res = AgregarActualizar_Registro()
                Select Case res
                    Case -3
                        Cancelar_Tran()
                        Util.MsgStatus(Status1, "No pudo realizarse la inserción (Encabezado).", My.Resources.Resources.stop_error.ToBitmap)
                        Util.MsgStatus(Status1, "No pudo realizarse la inserción (Encabezado).", My.Resources.Resources.stop_error.ToBitmap, True)
                    Case -2
                        Cancelar_Tran()
                        Util.MsgStatus(Status1, "No se pudo actualizar el número de Orden de Compra (Encabezado).", My.Resources.Resources.stop_error.ToBitmap)
                        Util.MsgStatus(Status1, "No se pudo actualizar el número de Orden de Compra (Encabezado).", My.Resources.Resources.stop_error.ToBitmap, True)
                    Case -1
                        Cancelar_Tran()
                        Util.MsgStatus(Status1, "No se pudo actualizar el registro (Encabezado).", My.Resources.Resources.stop_error.ToBitmap)
                        Util.MsgStatus(Status1, "No se pudo actualizar el registro (Encabezado).", My.Resources.Resources.stop_error.ToBitmap, True)
                    Case 0
                        Cancelar_Tran()
                        Util.MsgStatus(Status1, "No se pudo agregar el registro (Encabezado).", My.Resources.Resources.stop_error.ToBitmap)
                        Util.MsgStatus(Status1, "No se pudo agregar el registro (Encabezado).", My.Resources.Resources.stop_error.ToBitmap, True)
                    Case Else
                        Util.MsgStatus(Status1, "Guardando los items...", My.Resources.Resources.indicator_white)
                        res_item = AgregarActualizar_Registro_Items()
                        Select Case res_item
                            Case -30
                                Cancelar_Tran()
                                Util.MsgStatus(Status1, "No se puedo el producto en el stock.", My.Resources.Resources.stop_error.ToBitmap)
                                Util.MsgStatus(Status1, "No se puedo el producto en el stock. '" & cod_aux & "'", My.Resources.Resources.stop_error.ToBitmap, True)
                            Case -10
                                Cancelar_Tran()
                                Util.MsgStatus(Status1, "No se puede modificar el material. La unidad ingresada es diferente a la unidad dentro de los movimientos de Stock.", My.Resources.Resources.stop_error.ToBitmap)
                            Case -3
                                Cancelar_Tran()
                                Util.MsgStatus(Status1, "No se puedo insertar en stock el codigo '" & cod_aux & "'", My.Resources.Resources.stop_error.ToBitmap)
                                Util.MsgStatus(Status1, "No se puedo insertar en stock el codigo '" & cod_aux & "'", My.Resources.Resources.stop_error.ToBitmap, True)
                            Case -2
                                Cancelar_Tran()
                                Util.MsgStatus(Status1, "El registro ya existe (Items).", My.Resources.Resources.stop_error.ToBitmap)
                                Util.MsgStatus(Status1, "El registro ya existe (Items).", My.Resources.Resources.stop_error.ToBitmap, True)
                            Case -1
                                Cancelar_Tran()
                                Util.MsgStatus(Status1, "No se pudo registrar el ajuste (Items).", My.Resources.Resources.stop_error.ToBitmap)
                                Util.MsgStatus(Status1, "No se pudo registrar el ajuste (Items).", My.Resources.Resources.stop_error.ToBitmap, True)
                            Case 0
                                Cancelar_Tran()
                                Util.MsgStatus(Status1, "No se pudo agregar el registro (Items).", My.Resources.Resources.stop_error.ToBitmap)
                                Util.MsgStatus(Status1, "No se pudo agregar el registro (Items).", My.Resources.Resources.stop_error.ToBitmap, True)

                            Case Else
                                Cerrar_Tran()

                                'rdPendientes.Checked = 1
                                cmbEstado.Text = "PRESENTADO"
                                'SQL = $"exec spPresentaciones_Select_All @Pendientes = {rdPendientes.Checked} ,@Eliminado = {rdAnuladas.Checked} ,@Todos = {rdTodasOC.Checked}"
                                SQL = $"exec spPresentaciones_Select_All @Estado = {cmbEstado.Text.Replace(" ", "")} ,@Eliminado = 0"
                                bolModo = False
                                PrepararBotones()
                                MDIPrincipal.NoActualizarBase = False
                                btnActualizar_Click(sender, e)

                                'btnCopiarOC.Enabled = True
                                'btnFinalizar.Enabled = True

                                Util.MsgStatus(Status1, "Se ha actualizado el registro.", My.Resources.Resources.ok.ToBitmap)
                        End Select
                End Select
                '
                ' cerrar la conexion si está abierta.
                '
                If Not conn_del_form Is Nothing Then
                    CType(conn_del_form, IDisposable).Dispose()
                End If
            End If 'if ALTa
        End If 'If bolpoliticas Then

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        '
        ' Para borrar un vale hay que tener un permiso especial de eliminacion
        ' ademas, no se puede borrar un vale ya eliminado de antes.
        ' La eliminacion es lógica...y se reversan los items para ajustar el inventario
        '
        Dim res As Integer

        If MessageBox.Show("¿Está seguro que desea Anular la Presentación seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        If chkEliminado.Checked = False Then

            'si tiene al menos una recepcion cargada no se puede eliminar ...
            res = CuentaRecepcionesPorOrdenDeCompra(CType(txtID.Text, Long))
            If res >= 1 Then
                Util.MsgStatus(Status1, "No se puede Anular la Orden de Compra ya que tiene 'Recepciones' efectuadas.", My.Resources.stop_error.ToBitmap)
                Util.MsgStatus(Status1, "No se puede Anular la Orden de Compra ya que tiene 'Recepciones' efectuadas.", My.Resources.stop_error.ToBitmap, True)
                Exit Sub
            End If

            If MessageBox.Show("Esta acción Anulará todos los items." + vbCrLf + "¿Está seguro que desea Anular?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Util.MsgStatus(Status1, "Anulando el registro...", My.Resources.Resources.indicator_white)
                res = EliminarRegistro("Anular")
                Select Case res
                    Case -1
                        Util.MsgStatus(Status1, "No se pudo Anular la OC.", My.Resources.stop_error.ToBitmap)
                        Util.MsgStatus(Status1, "No se pudo Anular la OC.", My.Resources.stop_error.ToBitmap, True)
                    Case 0
                        Util.MsgStatus(Status1, "No se pudo Anular la OC.", My.Resources.stop_error.ToBitmap)
                        Util.MsgStatus(Status1, "No se pudo Anular la OC.", My.Resources.stop_error.ToBitmap, True)
                    Case Else
                        PrepararBotones()
                        btnActualizar_Click(sender, e)
                        Util.MsgStatus(Status1, "Se ha Anulado la OC.", My.Resources.ok.ToBitmap)
                        Util.MsgStatus(Status1, "Se ha Anulado la OC.", My.Resources.ok.ToBitmap, True, True)
                End Select
            Else
                Util.MsgStatus(Status1, "Acción de Anulado cancelada.", My.Resources.stop_error.ToBitmap)
                Util.MsgStatus(Status1, "Acción de Anulado cancelada.", My.Resources.stop_error.ToBitmap, True)
            End If
        Else
            Util.MsgStatus(Status1, "El registro ya está Anulado.", My.Resources.stop_error.ToBitmap)
            Util.MsgStatus(Status1, "El registro ya está Anulado.", My.Resources.stop_error.ToBitmap, True)
        End If
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim res As Integer

        If MessageBox.Show("¿Está seguro que desea Finalizar la OC seleccionada?" & vbCrLf & "Todos los items pendientes con saldo MENOR a la cantidad pedida quedarán con el estado Finalizado", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        If chkEliminado.Checked = False Then

            'si tiene al menos una recepcion puede finalizar la OC
            res = CuentaRecepcionesPorOrdenDeCompra(CType(txtID.Text, Long))

            If res = 0 Then
                Util.MsgStatus(Status1, "No se puede Finalizar la Orden de Compra ya que no tiene 'Recepciones' efectuadas." & vbCrLf & "Si desea puede Anular la OC seleccionada.", My.Resources.stop_error.ToBitmap)
                Util.MsgStatus(Status1, "No se puede Finalizar la Orden de Compra ya que no tiene 'Recepciones' efectuadas." & vbCrLf & "Si desea puede Anular la OC seleccionada.", My.Resources.stop_error.ToBitmap, True)
                Exit Sub
            End If

            'If MessageBox.Show("Esta acción Finalizará el proceso en todos los items." + vbCrLf + "¿Está seguro que desea Finalizar la OC?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Util.MsgStatus(Status1, "Finalizando el registro...", My.Resources.Resources.indicator_white)
            res = EliminarRegistro("Finalizar")
            Select Case res
                Case -1
                    Util.MsgStatus(Status1, "No se pudo Finalizar la OC.", My.Resources.stop_error.ToBitmap)
                    Util.MsgStatus(Status1, "No se pudo Finalizar la OC.", My.Resources.stop_error.ToBitmap, True)
                Case 0
                    Util.MsgStatus(Status1, "No se pudo Finalizar la OC.", My.Resources.stop_error.ToBitmap)
                    Util.MsgStatus(Status1, "No se pudo Finalizar la OC.", My.Resources.stop_error.ToBitmap, True)
                Case Else
                    PrepararBotones()
                    btnActualizar_Click(sender, e)
                    Util.MsgStatus(Status1, "Se ha Finalizado la OC.", My.Resources.ok.ToBitmap)
                    Util.MsgStatus(Status1, "Se ha Finalizado la OC.", My.Resources.ok.ToBitmap, True, True)
            End Select
            'Else
            '    Util.MsgStatus(Status1, "Acción de Finalizado cancelada.", My.Resources.stop_error.ToBitmap)
            '    Util.MsgStatus(Status1, "Acción de Finalizado cancelada.", My.Resources.stop_error.ToBitmap, True)
            'End If
        Else
            Util.MsgStatus(Status1, "El registro ya está Finalizado.", My.Resources.stop_error.ToBitmap)
            Util.MsgStatus(Status1, "El registro ya está Finalizado.", My.Resources.stop_error.ToBitmap, True)
        End If

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        'Dim rpt As New frmReportes()
        'Dim param As New frmParametros
        'Dim cnn As New SqlConnection(ConnStringSEI)
        'Dim codigo As String
        'Dim Solicitud As Boolean

        'nbreformreportes = "Ordenes de Compra"

        'param.AgregarParametros("Código :", "STRING", "", False, txtCODIGO.Text.ToString, "", cnn)
        'param.ShowDialog()

        'If cerroparametrosconaceptar = True Then

        '    codigo = param.ObtenerParametros(0)

        '    rpt.NombreArchivoPDF = "Orden de Compra " & codigo & " - " & BuscarProveedor(codigo, Solicitud)

        '    rpt.OrdenesDeCompraPorkys_Maestro_App(codigo, rpt, My.Application.Info.AssemblyName.ToString, Solicitud)

        '    cerroparametrosconaceptar = False
        '    param = Nothing
        '    cnn = Nothing
        'End If

    End Sub

    Private Overloads Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Util.LimpiarTextBox(Me.Controls)
        LimpiarGridItems(grdItems)
        grd.ClearSelection()
        bolModo = False
    End Sub

    Private Sub btnCopiarOC_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim UltId As Long

        If MessageBox.Show("Desea copiar la Orden de Compra actual, para generar una nueva?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            UltId = txtID.Text

            btnBand_Copiar = False
            btnNuevo_Click(sender, e)

            txtID.Text = UltId

            LlenarGrid_Items()

            txtID.Text = ""
        End If

    End Sub

    Private Sub btnAgregarItem_Click(sender As Object, e As EventArgs) Handles btnAgregarItem.Click
        AñadirGridItem()
    End Sub


    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        Dim estado = cmbEstado.Text
        If estado <> "" Then
            filtrarPorEstado(estado.replace(" ", ""))
        End If

    End Sub

    Private Sub lblStatus_TextChanged(sender As Object, e As EventArgs) Handles lblStatus.TextChanged

        bloquearPresentacion(cmbEstado.Text)

    End Sub

    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged

    End Sub

    Private Class GroupedDataTable
        Public notGrouped As DataTable
        Public grouped As DataTable

        Public primaryColumn As String

        Public Sub New(dt As DataTable, GroupColumn As String)
            primaryColumn = GroupColumn
            notGrouped = dt
            grouped = group(dt, GroupColumn)
        End Sub

        Private Function group(dt As DataTable, groupColumn As String) As DataTable
            Dim dt_grouped As New DataTable()
            dt_grouped = dt.Clone()
            Dim added As Boolean = False
            Dim current_row_index As Integer
            Dim j
            Dim i

            For current_row_index = 0 To dt.Rows.Count - 1
                Dim current_row As DataRow = dt.Rows(current_row_index)
                added = False

                j = 0
                While (j < dt_grouped.Rows.Count And added = False)
                    If current_row(groupColumn) = dt_grouped.Rows(j)(groupColumn) Then
                        added = True
                    End If
                    j += 1
                End While

                If Not added Then
                    Dim new_row As DataRow = dt_grouped.NewRow()
                    For i = current_row_index To dt.Rows.Count - 1
                        If dt.Rows(i)(groupColumn) = current_row(groupColumn) Then
                            'new_row("IdDetalle") = current_row("IdDetalle")
                            'new_row("IdFarmacia") = current_row("IdFarmacia")
                            'new_row("Codigo") = current_row("Codigo")
                            'new_row("Nombre") = current_row("Nombre")
                            'For j = 4 To dt.Columns.Count - 1
                            '    If i = current_row_index Then
                            '        new_row(j) = Decimal.Parse(dt.Rows(i)(j))
                            '    Else
                            '        new_row(j) += Decimal.Parse(dt.Rows(i)(j))
                            '    End If
                            'Next
                            For j = 0 To dt.Columns.Count - 1

                                If TypeOf current_row(j) Is Decimal Then

                                    If i = current_row_index Then
                                        new_row(j) = dt.Rows(i)(j)
                                    Else
                                        new_row(j) += dt.Rows(i)(j)
                                    End If
                                Else
                                    ''Valor comun
                                    If i = current_row_index Then
                                        new_row(j) = current_row(j)
                                    End If
                                End If
                            Next
                        End If
                    Next
                    dt_grouped.Rows.Add(new_row)

                End If
            Next

            Return dt_grouped
        End Function
    End Class

    Private Sub btnUnificar_Click(sender As Object, e As EventArgs) Handles btnUnificar.Click
        Dim confirma As DialogResult = MessageBox.Show(
                                  $"Está apunto de unificar varias presentaciones en una nueva presentación. 
                                  ¿Está seguro que desea continuar?",
                                  "Confirmar",
                                  MessageBoxButtons.YesNo)

        If confirma = DialogResult.Yes Then

            Dim connection As SqlClient.SqlConnection = Nothing
            Dim dsRowsSelected As Data.DataSet
            Dim FilasSeleccionadas As DataGridViewSelectedRowCollection = grd.SelectedRows
            Dim condicion As String = ""
            Dim sql As String = ""
            Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            Try



                For Each fila As DataGridViewRow In FilasSeleccionadas
                    Dim id As String = fila.Cells(0).Value.ToString
                    If condicion = "" Then
                        condicion = $"p.id = {id} "
                    Else
                        condicion += $"or p.id = {id} "
                    End If
                Next

                Dim result As DialogResult = MessageBox.Show(
                                      $"¿Desea agrupar los items por farmacia?",
                                      "Confirmar",
                                      MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    sql = $"select
	                                                                                0					as ID,			   -- 0
	                                                                                pd.IdFarmacia			As IdFarmacia,	   -- 1
	                                                                                f.Codigo				AS CodigoFarmacia, -- 2
	                                                                                f.nombre				As Farmacia,       -- 3
	                                                                                null					As IdPresentacion, -- 4
	                                                                                sum(pd.recetas)			as Recetas,        -- 5
	                                                                                sum(pd.Recaudado)		as Recaudado,	   -- 6
	                                                                                sum(pd.AcargoOS)		as 'A Cargo Os',   -- 7
	                                                                                sum(pd.Bonificacion)	as Bonificación,   -- 8
	                                                                                sum(pd.total)			As Total           -- 9	
                                                                                from Presentaciones_det Pd
	                                                                                JOIN Presentaciones p ON pd.IdPresentacion = p.id
	                                                                                join Farmacias f on f.ID = pd.IdFarmacia
                                                                                where pd.Eliminado = 0 and ({condicion})
                                                                                group by
	                                                                                pd.IdFarmacia,
	                                                                                f.Codigo,
	                                                                                f.Nombre"


                Else
                    sql = $"select
	                                                                                0				as ID,			   -- 0
	                                                                                pd.IdFarmacia		As IdFarmacia,	   -- 1
	                                                                                f.Codigo			AS CodigoFarmacia, -- 2
	                                                                                f.nombre			As Farmacia,       -- 3
	                                                                                null				As IdPresentacion, -- 4
	                                                                                pd.recetas			as Recetas,        -- 5
	                                                                                pd.Recaudado		as Recaudado,	   -- 6
	                                                                                pd.AcargoOS			as 'A Cargo Os',   -- 7
	                                                                                pd.Bonificacion		as Bonificación,   -- 8
	                                                                                pd.total			As Total           -- 9	
                                                                                from Presentaciones_det Pd
	                                                                                JOIN Presentaciones p ON pd.IdPresentacion = p.id
	                                                                                join Farmacias f on f.ID = pd.IdFarmacia
                                                                                where pd.Eliminado = 0 and ({condicion})"
                End If
                dsRowsSelected = SqlHelper.ExecuteDataset(connection, CommandType.Text, sql)
                dsRowsSelected.Dispose()
                btnNuevo_Click(sender, e)
                Dim dt = dsRowsSelected.Tables(0)
                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1

                    grdItems.Rows.Add(
                        dt.Rows(i)(ColumnasDelGridItems.ID).ToString(),
                        dt.Rows(i)(ColumnasDelGridItems.IdFarmacia).ToString(),
                        dt.Rows(i)(ColumnasDelGridItems.CodigoFarmacia).ToString(),
                        dt.Rows(i)(ColumnasDelGridItems.Nombre).ToString(),
                        dt.Rows(i)(ColumnasDelGridItems.IdPresentacion).ToString(),
                        dt.Rows(i)(ColumnasDelGridItems.Recetas).ToString(),
                        dt.Rows(i)(ColumnasDelGridItems.Recaudado).ToString(),
                        dt.Rows(i)(ColumnasDelGridItems.ACargoOS).ToString(),
                        dt.Rows(i)(ColumnasDelGridItems.Bonificacion).ToString(),
                        dt.Rows(i)(ColumnasDelGridItems.Total).ToString())


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

        Else
            Exit Sub
        End If




    End Sub

    Private Sub btnSeparar_Click(sender As Object, e As EventArgs) Handles btnSeparar.Click

        Dim confirma As DialogResult = MessageBox.Show(
                                  $"Está apunto de separar varias farmacias para insertarla en una nueva presentación. 
                                  ¿Está seguro que desea continuar?",
                                  "Confirmar",
                                  MessageBoxButtons.YesNo)

        If confirma = DialogResult.Yes Then

            Dim connection As SqlClient.SqlConnection = Nothing
            Dim dsRowsSelected As Data.DataSet
            Dim FilasSeleccionadas As DataGridViewSelectedRowCollection = grdItems.SelectedRows
            Dim condicion As String = ""
            Dim sql As String = ""
            Dim dt_Items As New DataTable
            Dim obrasocial = cmbObraSocial.Text

            dt_Items.Columns.Add("Id")
            dt_Items.Columns.Add("IdFarmacia")
            dt_Items.Columns.Add("CodigoFarmacia")
            dt_Items.Columns.Add("Nombre")
            dt_Items.Columns.Add("IdPresentacion")
            dt_Items.Columns.Add("Recetas")
            dt_Items.Columns.Add("Recaudado")
            dt_Items.Columns.Add("ACargoOs")
            dt_Items.Columns.Add("Bonificacion")
            dt_Items.Columns.Add("Total")

            Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            Try



                For Each fila As DataGridViewRow In FilasSeleccionadas
                    Dim row As DataRow = dt_Items.NewRow
                    row("Id") = 0 'fila.Cells(ColumnasDelGridItems.ID).Value.ToString
                    row("IdFarmacia") = fila.Cells(ColumnasDelGridItems.IdFarmacia).Value.ToString
                    row("CodigoFarmacia") = fila.Cells(ColumnasDelGridItems.CodigoFarmacia).Value.ToString
                    row("Nombre") = fila.Cells(ColumnasDelGridItems.Nombre).Value.ToString
                    row("Idpresentacion") = 0 'fila.Cells(ColumnasDelGridItems.IdPresentacion).Value.ToString
                    row("Recetas") = fila.Cells(ColumnasDelGridItems.Recetas).Value.ToString
                    row("Recaudado") = fila.Cells(ColumnasDelGridItems.Recaudado).Value.ToString
                    row("ACargoOS") = fila.Cells(ColumnasDelGridItems.ACargoOS).Value.ToString
                    row("Bonificacion") = fila.Cells(ColumnasDelGridItems.Bonificacion).Value.ToString
                    row("Total") = fila.Cells(ColumnasDelGridItems.Total).Value.ToString

                    dt_Items.Rows.Add(row)

                    ''Elimino de la grilla las filas que quiero desagrupar
                    If cmbEstado.Text = "PRESENTADO" Then
                        If grdItems.Rows(fila.Index).Cells(ColumnasDelGridItems.ID).Value = 0 Then
                            grdItems.Rows.RemoveAt(fila.Index) 'la borramos directamente
                        Else
                            grdItems.Rows(fila.Index).Visible = False
                        End If
                        CalcularTotales()
                    Else
                        MsgBox("No puede eliminar un item que ya tiene una liquidación asociada.")
                    End If



                Next

                bolModo = False
                btnGuardar_Click(sender, e)

                btnNuevo_Click(sender, e)

                For Each row As DataRow In dt_Items.Rows
                    grdItems.Rows.Add(
                        row("Id"),
                        row("IdFarmacia"),
                        row("CodigoFarmacia"),
                        row("Nombre"),
                        row("Idpresentacion"),
                        row("Recetas"),
                        row("Recaudado"),
                        row("ACargoOS"),
                        row("Bonificacion"),
                        row("Total"))
                Next

                cmbObraSocial.Text = obrasocial

                btnGuardar_Click(sender, e)

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

        Else
            Exit Sub
        End If

    End Sub



#End Region


End Class