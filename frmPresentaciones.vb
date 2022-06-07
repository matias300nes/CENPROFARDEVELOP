Imports Microsoft.ApplicationBlocks.Data
Imports Utiles
Imports Utiles.Util
Imports System.Data.SqlClient
Imports ReportesNet
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Imports System.Threading
Imports System.IO

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
    ' en vez de n�mero

    Dim btnBand_Copiar As Boolean = True

    Dim ds_Empresa As Data.DataSet


    Dim porceniva As Double = 21

    Enum ColumnasDelGrd
        ''NACHO
        ID = 0
        Codigo = 1
        Fecha = 2
        IDObraSocial = 3
        ObraSocial = 4
        idPeriodo = 5
        Periodo = 6
        Estado = 7
        total = 8
        Observaciones = 9
    End Enum

    Enum ColumnasDelGridItems
        ''NACHO
        ID = 0
        IdFarmacia = 1
        CodigoFarmacia = 2
        Nombre = 3
        IdPlan = 4
        Plan = 5
        Observacion = 6
        mensajeWeb = 7
        IdPresentacion = 8
        Recetas = 9
        Recaudado = 10
        ACargoOS = 11
        Bonificacion = 12
        Total = 13
        CodFacaf_Farm = 14
        CodPlan = 15
        PorcenPlan = 16
        'CodPlan = 14
        'PorcenPlan = 13
    End Enum

    'Auxiliares para guardar
    Dim cod_aux As String

    'Auxiliares para chequear lo digitado en la columna cantidad
    Dim qty_digitada As String

#Region "   Eventos"

    Private Sub frmPresentaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                btnAddFarmacia_Click(sender, e)
            Case Keys.F3 'nuevo
                If bolModo = True Then
                    If MessageBox.Show("No ha guardado la Orden de Compra Nueva que est� realizando. �Est� seguro que desea continuar sin Grabar y hacer una Orde de Compra Nueva?", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
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

    Private Function ExistePlanEnFarmacia() As Boolean
        Dim idPlan
        For Each grdItemsRow As DataGridViewRow In grdItems.Rows
            IdPlan = grdItemsRow.Cells(ColumnasDelGridItems.IdPlan).Value
            If IdPlan Is Nothing Or IdPlan = "" Then 'si alguna farmacia no tiene plan bloqueo el prescam
                Return 0
                Exit Function
            End If
            ExistePlanEnFarmacia = 1
        Next
    End Function


    Private Sub grd_SelectionChanged(sender As Object, e As EventArgs) Handles grd.SelectionChanged 'comentar cuando se necesite ver el dise�ador
        ''DataGridView1.SelectedRows.Count().ToString()
        If grd.SelectedRows.Count() > 1 Then
            btnUnificar.Enabled = True
        Else
            btnUnificar.Enabled = False
        End If

    End Sub

    Private Sub frmPresentaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''prueba nacho
        'btnCancelar.Enabled = False comentado
        btnEliminar.Enabled = False

        Cursor = Cursors.WaitCursor

        ToolStrip_lblCodMaterial.Visible = True
        txtBusquedaMAT.Visible = True

        band = 0

        Me.ToolTipbtnSeparar.SetToolTip(btnSeparar, "Separa la(s) farmacias seleccionadas creando una nueva presentaci�n con esas farmacias")
        Me.ToolTipbtnUnificar.SetToolTip(btnUnificar, "Unifica varias presentaciones con distinto o igual periodo")

        configurarform()
        asignarTags()

        btnEliminar.Text = "Anular"
        'rdPendientes.Checked = 1

        llenarCmbEstados()
        'LlenarCmbFarmacia()
        LlenarCmbObraSocial()
        'LlenarCmbPlanes()

        If cmbEstado.Text = "" Then 'esta vacio porque no hay registros
            cmbEstado.Text = "PRESENTADO"
        Else 'existen registros
            cmbEstado.Text = "PRESENTADO" 'fuerzo la seleccion de presentaciones con estado PRESENTADO
        End If

        ''Traigo los encabezados de presentacion
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
            txtID.Text = grd.Rows(0).Cells(ColumnasDelGrd.ID).Value
            txtCodigo.Text = grd.Rows(0).Cells(ColumnasDelGrd.Codigo).Value
            dtpFECHA.Value = grd.Rows(0).Cells(ColumnasDelGrd.Fecha).Value
            cmbObraSocial.SelectedValue = grd.Rows(0).Cells(ColumnasDelGrd.IDObraSocial).Value
            cmbObraSocial.Text = grd.Rows(0).Cells(ColumnasDelGrd.ObraSocial).Value
            LlenarCmbPeriodos()
            'cmbPeriodos.SelectedValue = grd.Rows(0).Cells(ColumnasDelGrd.idPeriodo).Value
            With grd.Rows(0).Cells(ColumnasDelGrd.idPeriodo)
                If .Value.ToString <> "" Then
                    cmbPeriodos.SelectedValue = grd.Rows(0).Cells(ColumnasDelGrd.idPeriodo).Value
                Else
                    cmbPeriodos.SelectedItem = Nothing
                End If
            End With
            'cmbPeriodos.Text = grd.Rows(0).Cells(5).Value
            lblStatus.Text = grd.Rows(0).Cells(ColumnasDelGrd.Estado).Value
            txtTotal.Text = grd.Rows(0).Cells(ColumnasDelGrd.total).Value
            txtObservacion.Text = grd.Rows(0).Cells(ColumnasDelGrd.Observaciones).Value
        End If



        If bolModo = True Then
            LlenarGrid_Items()
            btnNuevo_Click(sender, e)
        Else
            LlenarGrid_Items()
        End If



        With grd
            .Columns(ColumnasDelGrd.IDObraSocial).Visible = False
            .Columns(ColumnasDelGrd.idPeriodo).Visible = False
        End With

        'For Each fila As DataGridViewRow In grdItems.Rows
        '    If fila.Cells(ColumnasDelGridItems.Plan).Value = "" Then

        '    End If
        'Next

        'With grdItems
        '    .Columns(ColumnasDelGridItems.IdPlan).Visible = False
        'End With

        grd.MultiSelect = True
        btnUnificar.Enabled = False
        Cursor = Cursors.Default

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

    Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtID.KeyPress

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


    Private Sub grdItems_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdItems.MouseUp

        'Dim columna As Integer = 0
        'Dim Valor As String

        'Try
        '    columna = grdItems.CurrentCell.ColumnIndex
        'Catch ex As Exception

        'End Try


        'Valor = ""


    End Sub


    Private Sub llenarCmbEstados()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

        IdObraSocial = cmbObraSocial.SelectedValue
        bolIDOS = True
    End Sub

    'Private Sub LlenarCmbFarmacia()
    '    Dim connection As SqlClient.SqlConnection = Nothing
    '    Dim ds As Data.DataSet

    '    Try
    '        connection = SqlHelper.GetConnection(ConnStringSEI)
    '    Catch ex As Exception
    '        MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Sub
    '    End Try

    '    Try

    '        ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, $" SELECT ID, NOMBRE FROM FARMACIAS WHERE ELIMINADO = 0")
    '        ds.Dispose()

    '        With cmbFarmacias
    '            .DataSource = ds.Tables(0).DefaultView
    '            .DisplayMember = "NOMBRE"
    '            .ValueMember = "ID"
    '            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '            .AutoCompleteSource = AutoCompleteSource.ListItems
    '            '.SelectedIndex = "ID"
    '        End With

    '    Catch ex As Exception
    '        Dim errMessage As String = ""
    '        Dim tempException As Exception = ex

    '        While (Not tempException Is Nothing)
    '            errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
    '            tempException = tempException.InnerException
    '        End While

    '        MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
    '          + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
    '          "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        If Not connection Is Nothing Then
    '            CType(connection, IDisposable).Dispose()
    '        End If
    '    End Try

    '    IdObraSocial = cmbObraSocial.SelectedValue
    '    bolIDOS = True
    'End Sub

    Private Sub LlenarCmbObraSocial()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

        IdObraSocial = cmbObraSocial.SelectedValue
        bolIDOS = True
    End Sub


    'Private Sub LlenarCmbPlanes()
    '    Dim connection As SqlClient.SqlConnection = Nothing
    '    Dim ds As Data.DataSet

    '    Try
    '        connection = SqlHelper.GetConnection(ConnStringSEI)
    '    Catch ex As Exception
    '        MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Sub
    '    End Try

    '    Try

    '        ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, $" SELECT p.id as Id, p.nombre as Nombre 
    '                                                                        FROM Planes p 
    '                                                                        INNER JOIN ObrasSociales_Planes osp ON osp.IdPlan = p.Id 
    '                                                                        WHERE osp.IdObraSocial = {cmbObraSocial.SelectedValue} AND p.eliminado = 0")
    '        ds.Dispose()

    '        With cmbPlanes
    '            .DataSource = ds.Tables(0).DefaultView
    '            .DisplayMember = "NOMBRE"
    '            .ValueMember = "ID"
    '            '.SelectedIndex = "ID"
    '        End With

    '    Catch ex As Exception
    '        Dim errMessage As String = ""
    '        Dim tempException As Exception = ex

    '        While (Not tempException Is Nothing)
    '            errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
    '            tempException = tempException.InnerException
    '        End While

    '        MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
    '          + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
    '          "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        If Not connection Is Nothing Then
    '            CType(connection, IDisposable).Dispose()
    '        End If
    '    End Try

    'End Sub

    Private Sub LlenarCmbPeriodos()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, $"spPeriodosWeb_SelectAll @idObraSocial = {cmbObraSocial.SelectedValue}")
            ds.Dispose()

            With cmbPeriodos
                .DataSource = ds.Tables(0).DefaultView
                .DisplayMember = "Periodo"
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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
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
                'LlenarCmbPlanes()
                LlenarCmbPeriodos()
            End If


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
            gbMain.Height = gbMain.Height - variableajuste
            grd.Location = New Point(xgrd, ygrd - variableajuste)
            grd.Height = hgrd + variableajuste
            grdItems.Height = grdItems.Height - variableajuste
            Label19.Location = New Point(Label19.Location.X, Label19.Location.Y - variableajuste)
            GroupBox2.Location = New Point(GroupBox2.Location.X, GroupBox2.Location.Y - variableajuste)
            cmbEstado.Location = New Point(cmbEstado.Location.X, cmbEstado.Location.Y - variableajuste)
            Label9.Location = New Point(Label9.Location.X, Label9.Location.Y - variableajuste)
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
            gbMain.Height = gbMain.Height + variableajuste
            grd.Location = New Point(xgrd, ygrd + variableajuste)
            grd.Height = hgrd - variableajuste
            grdItems.Height = grdItems.Height + variableajuste
            Label19.Location = New Point(Label19.Location.X, Label19.Location.Y + variableajuste)
            GroupBox2.Location = New Point(GroupBox2.Location.X, GroupBox2.Location.Y + variableajuste)
            cmbEstado.Location = New Point(cmbEstado.Location.X, cmbEstado.Location.Y + variableajuste)
            Label9.Location = New Point(Label9.Location.X, Label9.Location.Y + variableajuste)
            lblCantidadFilas.Location = New Point(lblCantidadFilas.Location.X, lblCantidadFilas.Location.Y + variableajuste)


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
                MsgBox("No puede eliminar un item que ya tiene una liquidaci�n asociada.")
            End If
        End If


    End Sub

#End Region

#Region "   Procedimientos"

    Private Sub configurarform()
        'Me.grd.Location = New Size(TableLayoutPanel1.Location.X, TableLayoutPanel1.Location.Y + TableLayoutPanel1.Size.Height + 7)
        Me.grd.Location = New Size(gbMain.Location.X, gbMain.Location.Y + gbMain.Size.Height + 5)

        If LLAMADO_POR_FORMULARIO Then
            LLAMADO_POR_FORMULARIO = False
            Me.Top = ARRIBA
            Me.Left = IZQUIERDA
        Else
            Me.Top = 0
            Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2
        End If

        Me.WindowState = FormWindowState.Maximized

        'Me.grd.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width - 27, Me.Size.Height - 7 - TableLayoutPanel1.Size.Height - TableLayoutPanel1.Location.Y - 50)
        Me.grd.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width - 27, Me.Size.Height - 3 - gbMain.Size.Height - gbMain.Location.Y - 62) '65)

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
            btnAddFarmacia.Enabled = True
            btnGuardar.Enabled = True
            btnNuevo.Enabled = True
        End If

        If cmbstatus = "" Then
            btnAddFarmacia.Enabled = True
            btnGuardar.Enabled = True
            btnNuevo.Enabled = False
        End If

        ''edited
        If cmbstatus = "PAGO PARCIAL" Or cmbstatus = "PAGADA" Then
            btnAddFarmacia.Enabled = False
            btnGuardar.Enabled = False
            btnNuevo.Enabled = True
        End If
        ''edited

    End Sub


    Private Sub asignarTags()
        txtID.Tag = "0"
        txtCodigo.Tag = "1"
        dtpFECHA.Tag = "2"
        txtIdObrasocial.Tag = "3"
        cmbObraSocial.Tag = "3" ''nacho mati
        cmbPeriodos.Tag = "5"
        lblStatus.Tag = "7"
        txtTotal.Tag = "8"
        txtObservacion.Tag = "9"

    End Sub

    Private Sub Verificar_Datos()

        Dim i As Integer, j As Integer, filas As Integer ', res As Integer ', state As Integer

        bolpoliticas = False

        Util.MsgStatus(Status1, "Verificando los datos...", My.Resources.Resources.indicator_white)

        'Verificar si todos los combox tienen algo v�lido
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not (cmbObraSocial.SelectedIndex > -1) Then
            Util.MsgStatus(Status1, "Ingrese un valor v�lido en el campo 'Obra social'.", My.Resources.Resources.alert.ToBitmap)
            Util.MsgStatus(Status1, "Ingrese un valor v�lido en el campo 'Obra social'.", My.Resources.Resources.alert.ToBitmap, True)
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
            'la fila est� vac�a ?
            filas = filas + 1

        Next i
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' controlar si al menos hay 1 fila
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If filas > 0 Then
            bolpoliticas = True
        Else
            Util.MsgStatus(Status1, "No hay filas de farmacias para guardar.", My.Resources.Resources.alert.ToBitmap)
            Util.MsgStatus(Status1, "No hay filas de farmacias para guardar.", My.Resources.Resources.alert.ToBitmap, True)
            Exit Sub
        End If
    End Sub

    Private Sub PrepararGridItems()
        Util.LimpiarGridItems(grdItems)
        'Util.LimpiarGridItems(grd)
    End Sub


    Friend Sub newItem(
                      nombre As String,
                      idFarmacia As Long,
                      idPlan As Long,
                      plan As String,
                      recetas As Integer,
                      recaudado As Decimal,
                      aCargoOS As Decimal,
                      bonificacion As Decimal,
                      observacion As String,
                      mensajeWeb As String
                      )

        Dim row As New DataGridViewRow()
        row.CreateCells(grdItems)

        With row
            .Cells(ColumnasDelGridItems.ID).Value = 0
            .Cells(ColumnasDelGridItems.Nombre).Value = nombre
            .Cells(ColumnasDelGridItems.IdFarmacia).Value = idFarmacia
            .Cells(ColumnasDelGridItems.IdPlan).Value = IIf(idPlan = 0, "", idPlan)
            .Cells(ColumnasDelGridItems.Plan).Value = plan
            .Cells(ColumnasDelGridItems.Recetas).Value = recetas
            .Cells(ColumnasDelGridItems.Recaudado).Value = recaudado
            .Cells(ColumnasDelGridItems.ACargoOS).Value = aCargoOS
            .Cells(ColumnasDelGridItems.Bonificacion).Value = bonificacion
            .Cells(ColumnasDelGridItems.Total).Value = aCargoOS - bonificacion
            .Cells(ColumnasDelGridItems.Observacion).Value = observacion
            .Cells(ColumnasDelGridItems.mensajeWeb).Value = mensajeWeb
        End With

        grdItems.Rows.Add(row)

        CalcularTotales()
    End Sub

    Private Sub LlenarGrid_Items()

        grdItems.Rows.Clear()

        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                    dt.Rows(i)(ColumnasDelGridItems.IdPlan).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.Plan).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.Observacion).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.mensajeWeb).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.IdPresentacion).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.Recetas).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.Recaudado).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.ACargoOS).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.Bonificacion).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.Total).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.CodFacaf_Farm).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.CodPlan).ToString(),
                    dt.Rows(i)(ColumnasDelGridItems.PorcenPlan).ToString())
                ' rodrigo 

            Next
            If grd.CurrentRow IsNot Nothing Then
                With grd.CurrentRow.Cells(ColumnasDelGrd.idPeriodo)
                    If .Value.ToString <> "" Then
                        cmbPeriodos.SelectedValue = grd.CurrentRow.Cells(ColumnasDelGrd.idPeriodo).Value
                    Else
                        cmbPeriodos.SelectedItem = Nothing
                    End If
                End With
            End If

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
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub ImprimirPresentacion()
        If txtID.Text <> "" Then
            Dim frmPresentacionRpt As New frmPresentacionRpt(Long.Parse(txtID.Text))
            frmPresentacionRpt.ShowDialog()
        Else
            MessageBox.Show("Para poder imprimir un reporte, debe guardar la presentaci�n.", "Presentaci�n sin guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
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
    '        MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    '        MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
    '          + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage), _
    '          "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

                Dim param_idPeriodo As New SqlClient.SqlParameter
                param_idPeriodo.ParameterName = "@idPeriodo"
                param_idPeriodo.SqlDbType = SqlDbType.BigInt
                param_idPeriodo.Value = cmbPeriodos.SelectedValue
                param_idPeriodo.Direction = ParameterDirection.Input

                Dim param_periodo As New SqlClient.SqlParameter
                param_periodo.ParameterName = "@periodo"
                param_periodo.SqlDbType = SqlDbType.VarChar
                param_periodo.Size = 100
                param_periodo.Value = cmbPeriodos.Text
                param_periodo.Direction = ParameterDirection.Input

                Dim param_total As New SqlClient.SqlParameter
                param_total.ParameterName = "@Total"
                param_total.SqlDbType = SqlDbType.Decimal
                param_total.Precision = 18
                param_total.Scale = 2
                param_total.Value = Decimal.Parse(txtTotal.Text)
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
                                                param_idPeriodo, param_periodo, param_total, param_useradd, param_res)

                        txtID.Text = param_id.Value
                        prueba = param_codigo.Value
                        txtCodigo.Text = param_codigo.Value
                    Else
                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "spPresentaciones_Update",
                                                param_id, param_codigo, param_fecha, param_IdObraSocial, param_observacion,
                                                param_idPeriodo, param_periodo, param_total, param_useradd, param_res)

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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

                Dim param_idPlan As New SqlClient.SqlParameter
                param_idPlan.ParameterName = "@idPlan"
                param_idPlan.SqlDbType = SqlDbType.BigInt
                param_idPlan.Value = DBNull.Value
                If grdItems.Rows(i).Cells(ColumnasDelGridItems.IdPlan).Value Is Nothing Then
                    If grdItems.Rows(i).Cells(ColumnasDelGridItems.IdPlan).Value <> "" Then
                        param_idPlan.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems.IdPlan).Value
                    End If
                End If
                param_idPlan.Direction = ParameterDirection.Input

                Dim param_Observacion As New SqlClient.SqlParameter
                param_Observacion.ParameterName = "@observacion"
                param_Observacion.SqlDbType = SqlDbType.VarChar
                param_Observacion.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems.Observacion).Value
                param_Observacion.Direction = ParameterDirection.Input

                Dim param_MensajeWeb As New SqlClient.SqlParameter
                param_MensajeWeb.ParameterName = "@mensajeWeb"
                param_MensajeWeb.SqlDbType = SqlDbType.VarChar
                param_MensajeWeb.Value = grdItems.Rows(i).Cells(ColumnasDelGridItems.mensajeWeb).Value
                param_MensajeWeb.Direction = ParameterDirection.Input

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
                                                  param_id, param_IdFarmacia, param_idPlan, param_Observacion, param_MensajeWeb,
                                                  param_IdPresentacion, param_Recetas, param_Recaudado, param_AcargoOS, param_Bonificacion,
                                                  param_Total, param_eliminado, param_user, param_res)

                    res = param_res.Value


                    'If res = -20 Then
                    '    MsgBox("La cantidad ingresada para el Item " & grdItems.Rows(i).Cells(ColumnasDelGridItems.Producto).Value & " es menor al saldo actual.", MsgBoxStyle.Critical, "Atenci�n")
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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function EliminarRegistro(ByVal Estado As String) As Integer

        Dim connection As SqlClient.SqlConnection = Nothing
        Dim res As Integer = 0

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
            ''Abrir una transaccion para guardar y asegurar que se guarda todo
            'If Abrir_Tran(connection) = False Then
            '    MessageBox.Show("No se pudo abrir una transaccion", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    '        MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    '        MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
    '          + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
    '          "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)

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
        ' y si la celda actual no est� siendo editada,
        ' abandonamos el procedimiento.
        If (Not grdItems.Focused) AndAlso (Not grdItems.IsCurrentCellInEditMode) Then Return MyBase.ProcessCmdKey(msg, keyData)

        ' Obtenemos la celda actual
        Dim cell As DataGridViewCell = grdItems.CurrentCell
        ' �ndice de la columna.
        Dim columnIndex As Int32 = cell.ColumnIndex
        ' �ndice de la fila.
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

        ' ... y la ponemos en modo de edici�n.
        grdItems.BeginEdit(True)
        Return True

    End Function

#End Region

#Region "   Botones"

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click


        'If MessageBox.Show("Desea generar una nueva Presentaci�n?", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
        '    LimpiarGridItems(grdItems)
        '    'bolModo = False
        '    Exit Sub
        'End If
        cmbEstado.Enabled = False
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

        Util.LimpiarTextBox(Me.Controls)
        'PrepararGridItems()

        'solucion momentanea revisar
        txtObservacion.Text = ""
        cmbPeriodos.Text = ""
        cmbPeriodos.SelectedItem = Nothing
        txtCodigo.Text = ""
        cmbObraSocial.Text = ""
        Util.LimpiarGridItems(grdItems)

        lblCantidadFilas.Text = "0"

        lblStatus.Text = "EN PROCESO"

        dtpFECHA.Focus()

        band = 1

    End Sub

    Private Overloads Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        If MDIPrincipal.NoActualizarBase = False Then
            'SQL = $"exec spPresentaciones_Select_All @Estado = {cmbEstado.Text.Replace(" ", "")} ,@Eliminado = 0"
            SQL = $"exec spPresentaciones_Select_All @Estado = {cmbEstado.Text.Replace(" ", "")} ,@Eliminado = 0"
            Me.Cursor = Cursors.WaitCursor
            LlenarGrilla()
            Permitir = True
            CargarCajas()
            PrepararBotones()
            Me.Cursor = Cursors.Default
            'GrillaActualizar()
        End If


    End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim res As Integer, res_item As Integer
        Dim registro As Integer

        Util.MsgStatus(Status1, "Guardando el registro...", My.Resources.Resources.indicator_white)

        'If chkEliminado.Checked = True Then
        '    Util.MsgStatus(Status1, "No se puede actualizar el registo. Est� Eliminado", My.Resources.Resources.stop_error.ToBitmap, True)
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
                        Util.MsgStatus(Status1, "No pudo realizarse la inserci�n (Encabezado).", My.Resources.Resources.stop_error.ToBitmap)
                        Util.MsgStatus(Status1, "No pudo realizarse la inserci�n (Encabezado).", My.Resources.Resources.stop_error.ToBitmap, True)
                    Case -2
                        Cancelar_Tran()
                        Util.MsgStatus(Status1, "No se pudo actualizar el n�mero de Orden de Compra (Encabezado).", My.Resources.Resources.stop_error.ToBitmap)
                        Util.MsgStatus(Status1, "No se pudo actualizar el n�mero de Orden de Compra (Encabezado).", My.Resources.Resources.stop_error.ToBitmap, True)
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
                ' cerrar la conexion si est� abierta.
                '
                If Not conn_del_form Is Nothing Then
                    CType(conn_del_form, IDisposable).Dispose()
                End If
            End If 'if ALTa
        End If 'If bolpoliticas Then

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        Dim ds_liquidaciones As Data.DataSet
        Dim res As Integer
        If MessageBox.Show("Est� seguro que desea eliminar la presentaci�n seleccionada?", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Try
            ds_liquidaciones = SqlHelper.ExecuteDataset(ConnStringSEI, CommandType.Text, "SELECT  IDPresentacion FROM Liquidaciones where IDPresentacion = '" & txtID.Text & "'")
            ds_liquidaciones.Dispose()

            If ds_liquidaciones.Tables(0).Rows.Count > 0 Then
                MsgBox("No se puede eliminar una presentaci�n que tenga una o m�s liquidaciones. Por favor verifique.", MsgBoxStyle.Information, "Atenci�n")
                Exit Sub

            Else
                Util.MsgStatus(Status1, "Eliminando el registro...", My.Resources.Resources.indicator_white)
                res = EliminarRegistro()
                Select Case res
                    Case -2
                        Util.MsgStatus(Status1, "El registro no existe.", My.Resources.stop_error.ToBitmap)
                    Case -1
                        Util.MsgStatus(Status1, "No se pudo borrar el registro.", My.Resources.stop_error.ToBitmap)
                    Case 0
                        Util.MsgStatus(Status1, "No se pudo borrar el registro.", My.Resources.stop_error.ToBitmap)
                    Case Else
                        Util.MsgStatus(Status1, "Se ha borrado el registro.", My.Resources.ok.ToBitmap)
                        If Me.grd.RowCount = 0 Then
                            bolModo = True
                            PrepararBotones()
                            Util.LimpiarTextBox(Me.Controls)
                        End If
                End Select
            End If

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        ''
        '' Para borrar un vale hay que tener un permiso especial de eliminacion
        '' ademas, no se puede borrar un vale ya eliminado de antes.
        '' La eliminacion es l�gica...y se reversan los items para ajustar el inventario
        ''
        'Dim res As Integer

        'If MessageBox.Show("�Est� seguro que desea Anular la Presentaci�n seleccionada?", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
        '    Exit Sub
        'End If

        'If chkEliminado.Checked = False Then

        '    'si tiene al menos una recepcion cargada no se puede eliminar ...
        '    res = CuentaRecepcionesPorOrdenDeCompra(CType(txtID.Text, Long))
        '    If res >= 1 Then
        '        Util.MsgStatus(Status1, "No se puede Anular la Orden de Compra ya que tiene 'Recepciones' efectuadas.", My.Resources.stop_error.ToBitmap)
        '        Util.MsgStatus(Status1, "No se puede Anular la Orden de Compra ya que tiene 'Recepciones' efectuadas.", My.Resources.stop_error.ToBitmap, True)
        '        Exit Sub
        '    End If

        '    If MessageBox.Show("Esta acci�n Anular� todos los items." + vbCrLf + "�Est� seguro que desea Anular?", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '        Util.MsgStatus(Status1, "Anulando el registro...", My.Resources.Resources.indicator_white)
        '        res = EliminarRegistro("Anular")
        '        Select Case res
        '            Case -1
        '                Util.MsgStatus(Status1, "No se pudo Anular la OC.", My.Resources.stop_error.ToBitmap)
        '                Util.MsgStatus(Status1, "No se pudo Anular la OC.", My.Resources.stop_error.ToBitmap, True)
        '            Case 0
        '                Util.MsgStatus(Status1, "No se pudo Anular la OC.", My.Resources.stop_error.ToBitmap)
        '                Util.MsgStatus(Status1, "No se pudo Anular la OC.", My.Resources.stop_error.ToBitmap, True)
        '            Case Else
        '                PrepararBotones()
        '                btnActualizar_Click(sender, e)
        '                Util.MsgStatus(Status1, "Se ha Anulado la OC.", My.Resources.ok.ToBitmap)
        '                Util.MsgStatus(Status1, "Se ha Anulado la OC.", My.Resources.ok.ToBitmap, True, True)
        '        End Select
        '    Else
        '        Util.MsgStatus(Status1, "Acci�n de Anulado cancelada.", My.Resources.stop_error.ToBitmap)
        '        Util.MsgStatus(Status1, "Acci�n de Anulado cancelada.", My.Resources.stop_error.ToBitmap, True)
        '    End If
        'Else
        '    Util.MsgStatus(Status1, "El registro ya est� Anulado.", My.Resources.stop_error.ToBitmap)
        '    Util.MsgStatus(Status1, "El registro ya est� Anulado.", My.Resources.stop_error.ToBitmap, True)
        'End If
    End Sub


    Private Function EliminarRegistro() As Integer

        Dim connection As SqlClient.SqlConnection = Nothing
        Dim res As Integer = 0


        Try
            Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End Try


            Try

                Dim param_id As New SqlClient.SqlParameter("@id", SqlDbType.BigInt, ParameterDirection.Input)
                param_id.Value = CType(txtID.Text, Long)
                param_id.Direction = ParameterDirection.Input

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

                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spPresentacionesEnc_Det_Delete", param_id, param_userdel, param_res)
                    res = param_res.Value

                    If res > 0 Then Util.BorrarGrilla(grd)
                    If res > 0 Then Util.BorrarGrilla(grdItems)
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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Function


    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim res As Integer

        If MessageBox.Show("�Est� seguro que desea Finalizar la OC seleccionada?" & vbCrLf & "Todos los items pendientes con saldo MENOR a la cantidad pedida quedar�n con el estado Finalizado", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
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

            'If MessageBox.Show("Esta acci�n Finalizar� el proceso en todos los items." + vbCrLf + "�Est� seguro que desea Finalizar la OC?", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
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
            '    Util.MsgStatus(Status1, "Acci�n de Finalizado cancelada.", My.Resources.stop_error.ToBitmap)
            '    Util.MsgStatus(Status1, "Acci�n de Finalizado cancelada.", My.Resources.stop_error.ToBitmap, True)
            'End If
        Else
            Util.MsgStatus(Status1, "El registro ya est� Finalizado.", My.Resources.stop_error.ToBitmap)
            Util.MsgStatus(Status1, "El registro ya est� Finalizado.", My.Resources.stop_error.ToBitmap, True)
        End If

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        ImprimirPresentacion()
    End Sub

    Private Overloads Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        cmbEstado.Enabled = True
        grd.Rows(0).Selected = True
        grd_CurrentCellChanged(sender, e)
        btnNuevo.Enabled = True
        llenarCmbEstados()

        'bolModo = False
    End Sub

    Private Sub btnCopiarOC_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim UltId As Long

        If MessageBox.Show("Desea copiar la Orden de Compra actual, para generar una nueva?", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            UltId = txtID.Text

            btnBand_Copiar = False
            btnNuevo_Click(sender, e)

            txtID.Text = UltId

            LlenarGrid_Items()

            txtID.Text = ""
        End If

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
                                  $"Est� apunto de unificar varias presentaciones en una nueva presentaci�n. 
                                  �Est� seguro que desea continuar?",
                                  "Confirmar",
                                  MessageBoxButtons.YesNo)

        If confirma = DialogResult.Yes Then

            Dim connection As SqlClient.SqlConnection = Nothing
            Dim dsRowsSelected As Data.DataSet
            Dim FilasSeleccionadas As DataGridViewSelectedRowCollection = grd.SelectedRows
            Dim condicion As String = ""
            Dim sql As String = ""
            Dim obrasocial = cmbObraSocial.Text
            Dim periodo = cmbPeriodos.SelectedValue
            Dim observacion = txtObservacion.Text
            Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                                      $"�Desea agrupar los items por farmacia?",
                                      "Confirmar",
                                      MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    sql = $"select
	                            0					as ID,			   -- 0
	                            pd.IdFarmacia			As IdFarmacia,	   -- 1
	                            f.Codigo				AS CodigoFarmacia, -- 2
	                            f.nombre				As Farmacia,       -- 3
                                pl.Id				    as idPlan,			-- 4	
	                            pl.Nombre			    as 'Plan',			-- 5
	                            max(pd.Observacion)		    as Observacion,	-- 6
	                            max(pd.MensajeWeb)		    as MensajeWeb,	-- 7
	                            null					As IdPresentacion, -- 8
	                            sum(pd.recetas)			as Recetas,        -- 9
	                            sum(pd.Recaudado)		as Recaudado,	   -- 10
	                            sum(pd.AcargoOS)		as 'A Cargo Os',   -- 11
	                            sum(pd.Bonificacion)	as Bonificaci�n,   -- 12
	                            sum(pd.total)			As Total,           -- 13
                                f.CodFACAF			As CodFacaf,			-- 14
	                            pl.Codigo			As CodPlan				-- 15
                            from Presentaciones_det Pd
	                            JOIN Presentaciones p ON pd.IdPresentacion = p.id
	                            join Farmacias f on f.ID = pd.IdFarmacia
                                LEFT JOIN Planes pl 
	                                ON pl.ID = pd.IdPlan
                            where pd.Eliminado = 0 and ({condicion})
                            group by
	                            pd.IdFarmacia,
	                            f.Codigo,
	                            f.Nombre,
                                pl.id,
                                pl.nombre,
                                f.CodFACAF,
                                pl.Codigo"


                Else
                    sql = $"select
	                            0					as ID,			   -- 0
	                            pd.IdFarmacia			As IdFarmacia,	   -- 1
	                            f.Codigo				AS CodigoFarmacia, -- 2
	                            f.nombre				As Farmacia,       -- 3
                                pl.Id				    as idPlan,			-- 4	
	                            pl.Nombre			    as 'Plan',			-- 5
	                            pd.Observacion	    as Observacion,	-- 6
	                            pd.MensajeWeb		    as MensajeWeb,	-- 7
	                            null					As IdPresentacion, -- 8
	                            pd.recetas			as Recetas,        -- 9
	                            pd.Recaudado		as Recaudado,	   -- 10
	                            pd.AcargoOS		as 'A Cargo Os',   -- 11
	                            pd.Bonificacion	as Bonificaci�n,   -- 12
	                            pd.total			As Total,           -- 13
                                f.CodFACAF			As CodFacaf,			-- 14
	                            pl.Codigo			As CodPlan				-- 15
                            from Presentaciones_det Pd
	                            JOIN Presentaciones p ON pd.IdPresentacion = p.id
	                            join Farmacias f on f.ID = pd.IdFarmacia
                                LEFT JOIN Planes pl 
	                                ON pl.ID = pd.IdPlan
                            where pd.Eliminado = 0 and ({condicion})"
                End If
                dsRowsSelected = SqlHelper.ExecuteDataset(connection, CommandType.Text, sql)
                dsRowsSelected.Dispose()
                btnNuevo_Click(sender, e)
                cmbObraSocial.Text = obrasocial
                cmbPeriodos.SelectedValue = periodo
                txtObservacion.Text = "UNIFICADA - " + obrasocial
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
                CalcularTotales()
            Catch ex As Exception
                Dim errMessage As String = ""
                Dim tempException As Exception = ex

                While (Not tempException Is Nothing)
                    errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                    tempException = tempException.InnerException
                End While

                MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
                  + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
                  "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                                  $"Est� apunto de separar varias farmacias para insertarla en una nueva presentaci�n. 
                                  �Est� seguro que desea continuar?",
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
            Dim observaciones = txtObservacion.Text
            Dim periodo = cmbPeriodos.SelectedValue

            dt_Items.Columns.Add("Id")
            dt_Items.Columns.Add("IdFarmacia")
            dt_Items.Columns.Add("CodigoFarmacia")
            dt_Items.Columns.Add("Nombre")

            dt_Items.Columns.Add("IdPlan")
            dt_Items.Columns.Add("Plan")
            dt_Items.Columns.Add("observacion")
            dt_Items.Columns.Add("MensajeWeb")

            dt_Items.Columns.Add("IdPresentacion")
            dt_Items.Columns.Add("Recetas")
            dt_Items.Columns.Add("Recaudado")
            dt_Items.Columns.Add("ACargoOs")
            dt_Items.Columns.Add("Bonificacion")
            dt_Items.Columns.Add("Total")

            Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            Try



                For Each fila As DataGridViewRow In FilasSeleccionadas
                    Dim row As DataRow = dt_Items.NewRow
                    row("Id") = 0 'fila.Cells(ColumnasDelGridItems.ID).Value.ToString
                    row("IdFarmacia") = fila.Cells(ColumnasDelGridItems.IdFarmacia).Value.ToString
                    row("CodigoFarmacia") = fila.Cells(ColumnasDelGridItems.CodigoFarmacia).Value.ToString
                    row("Nombre") = fila.Cells(ColumnasDelGridItems.Nombre).Value.ToString

                    row("IdPlan") = fila.Cells(ColumnasDelGridItems.IdPlan).Value
                    row("Plan") = fila.Cells(ColumnasDelGridItems.Plan).Value.ToString
                    row("observacion") = fila.Cells(ColumnasDelGridItems.Observacion).Value.ToString
                    row("MensajeWeb") = fila.Cells(ColumnasDelGridItems.mensajeWeb).Value.ToString

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
                        MsgBox("No puede eliminar un item que ya tiene una liquidaci�n asociada.")
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
                        row("IdPlan"),
                        row("Plan"),
                        row("observacion"),
                        row("MensajeWeb"),
                        row("Idpresentacion"),
                        row("Recetas"),
                        row("Recaudado"),
                        row("ACargoOS"),
                        row("Bonificacion"),
                        row("Total"))
                Next

                cmbObraSocial.Text = obrasocial
                cmbPeriodos.SelectedValue = periodo
                txtObservacion.Text = observaciones
                CalcularTotales()
                'btnGuardar_Click(sender, e)

            Catch ex As Exception
                Dim errMessage As String = ""
                Dim tempException As Exception = ex

                While (Not tempException Is Nothing)
                    errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                    tempException = tempException.InnerException
                End While

                MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
                  + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
                  "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Finally
                '    If Not connection Is Nothing Then
                '        CType(connection, IDisposable).Dispose()
                '    End If
            End Try

        Else
            Exit Sub
        End If

    End Sub

    'Private Sub ButtonX1_Click(sender As Object, e As EventArgs)
    '    GbPeriodo.Visible = Not GbPeriodo.Visible
    'End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs)
    '    txtPeriodo.Text = IIf(LbPeriodo_parte.Text <> "MENSUAL",
    '                            $"{LbPeriodo_parte.Text} {LbPeriodo_Mes.Text}-{LbPeriodo_a�o.Text}",
    '                            $"{LbPeriodo_Mes.Text}-{LbPeriodo_a�o.Text}"
    '                            )
    '    GbPeriodo.Visible = Not GbPeriodo.Visible
    'End Sub

    Private Sub btnPrescam_Click(sender As Object, e As EventArgs) Handles btnPrescam.Click
        Dim dt_txt As New DataTable
        Dim frmPrescam As New frmGenerarTxtPrescam
        frmPrescam.ShowDialog()
    End Sub

    Private Sub btnRecetasWeb_Click(sender As Object, e As EventArgs) Handles btnRecetasWeb.Click
        If cmbObraSocial.SelectedValue IsNot Nothing And cmbPeriodos.SelectedValue IsNot Nothing Then
            Dim frmRecetasWeb As New frmRecetasWeb(cmbObraSocial.SelectedValue, cmbPeriodos.SelectedValue)
            frmRecetasWeb.ShowDialog()
        Else
            MessageBox.Show("Para importar cargas de presentacion web debe seleccionar Obra Social y Per�odo.",
              "Seleccione OS-Per�odo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub grdItems_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdItems.CellDoubleClick
        btnModificarItem.PerformClick()
    End Sub

    Private Sub btnAddFarmacia_Click(sender As Object, e As EventArgs) Handles btnAddFarmacia.Click
        Dim presentacionesAgregarItem As New frmPresentacionesAgregarItem(
            idObraSocial:=cmbObraSocial.SelectedValue,
            selectedRow:=Nothing
        )
        presentacionesAgregarItem.ShowDialog()
    End Sub

    Private Sub btnModificarItem_Click(sender As Object, e As EventArgs) Handles btnModificarItem.Click
        Dim selectedRow = grdItems.CurrentRow()

        Dim presentacionesAgregarItem As New frmPresentacionesAgregarItem(
            idObraSocial:=cmbObraSocial.SelectedValue,
            selectedRow:=selectedRow
        )

        presentacionesAgregarItem.ShowDialog()
    End Sub

    Private Sub btnOpenPeriodos_Click(sender As Object, e As EventArgs) Handles btnOpenPeriodos.Click
        Dim frmPeriodos As New frmPeriodoPresentaciones()
        frmPeriodos.ShowDialog()

    End Sub

    Private Sub btnImprimirRpt_Click(sender As Object, e As EventArgs) Handles btnImprimirRpt.Click
        ImprimirPresentacion()
    End Sub

    Private Sub btnFacturar_Click(sender As Object, e As EventArgs) Handles btnFacturar.Click
        Dim frmFacturaElectronica As New frmFacturaElectronica(idOrigen:=txtID.Text,
                                               IdObraSocial:=cmbObraSocial.SelectedValue,
                                               Periodo:=cmbPeriodos.Text,
                                               TotalACargoOS:=txtACargoOS.Text)
        frmFacturaElectronica.ShowDialog()
    End Sub



#End Region


End Class