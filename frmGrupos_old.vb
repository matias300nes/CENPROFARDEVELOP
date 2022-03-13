
Imports Microsoft.ApplicationBlocks.Data
Imports Utiles
Imports Utiles.Util
Imports System.Data.SqlClient
Imports ReportesNet


Public Class frmGrupos_old
    Dim cmbLlenado As Boolean = False
    Dim bolpoliticas As Boolean

#Region "Procedimientos Formularios"

    Private Sub frmAlmacenes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3 'nuevo
                If bolModo = True Then
                    If MessageBox.Show("No ha guardado el Rubro Nuevo que est� realizando. �Est� seguro que desea continuar sin Grabar y hacer un Nuevo Rubro?", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        btnNuevo_Click(sender, e)
                    End If
                Else
                    btnNuevo_Click(sender, e)
                End If
            Case Keys.F4 'grabar
                btnGuardar_Click(sender, e)
        End Select
    End Sub

    Private Sub frmConceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AsignarPermisos(UserID, Me.Name, ALTA, MODIFICA, BAJA, BAJA_FISICA)
        configurarform()
        LlenarCmbMandatarias()
        'LlenarCmbGrupos()

        asignarTags()
        SQL = $"exec spGrupos_GruposOS_Select_All_By_IDMandataria @idmandataria = {cmbMandataria.SelectedValue}"
        LlenarGrilla()
        Permitir = True
        CargarCajas()
        PrepararBotones()
    End Sub

    Private Sub chkEliminados_CheckedChanged(sender As Object, e As EventArgs) Handles chkEliminados.CheckedChanged

        btnNuevo.Enabled = Not chkEliminados.Checked
        btnGuardar.Enabled = Not chkEliminados.Checked
        btnCancelar.Enabled = Not chkEliminados.Checked
        btnEliminar.Enabled = Not chkEliminados.Checked

        If chkEliminados.Checked = True Then
            SQL = "exec spAlmacenes_Select_All @Eliminado = 1"
        Else
            SQL = "exec spAlmacenes_Select_All @Eliminado = 0"
        End If

        LlenarGrilla()

        'LlenarGridItems()

        If grd.RowCount = 0 Then
            btnActivar.Enabled = False
        Else
            btnActivar.Enabled = chkEliminados.Checked
        End If
    End Sub

#End Region

#Region "Componentes Formulario"


    Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
     Handles txtID.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region

#Region "Botones"

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim res As Integer

        Util.MsgStatus(Status1, "Guardando el registro...", My.Resources.Resources.indicator_white)

        If ReglasNegocio() Then
            Verificar_Datos()
            If bolpoliticas Then
                If bolModo Then
                    ' If ALTA Then
                    res = AgregarRegistro()
                    Select Case res
                        Case -2
                            Util.MsgStatus(Status1, "El registro ya existe.", My.Resources.Resources.stop_error.ToBitmap)
                        Case -1
                            Util.MsgStatus(Status1, "No se pudo actualizar el registro.", My.Resources.Resources.stop_error.ToBitmap)
                        Case 0
                            Util.MsgStatus(Status1, "No se pudo agregar el registro.", My.Resources.Resources.stop_error.ToBitmap)
                        Case Else
                            Util.MsgStatus(Status1, "Se ha actualizado el registro.", My.Resources.Resources.ok.ToBitmap)
                            btnActualizar_Click(sender, e)
                    End Select
                    'Else
                    ' Util.MsgStatus(Status1, "No tiene permiso para Agregar registros.", My.Resources.stop_error.ToBitmap)
                    'End If
                Else
                    'If MODIFICA Then
                    res = ActualizarRegistro()
                    Select Case res
                        Case -3
                            Util.MsgStatus(Status1, "Ya existe otro Registro con este mismo C�digo.", My.Resources.stop_error.ToBitmap)
                        Case -2
                            Util.MsgStatus(Status1, "El registro ya existe.", My.Resources.Resources.stop_error.ToBitmap)
                        Case -1
                            Util.MsgStatus(Status1, "No se pudo actualizar el registro.", My.Resources.Resources.stop_error.ToBitmap)
                        Case 0
                            Util.MsgStatus(Status1, "No se pudo agregar el registro.", My.Resources.Resources.stop_error.ToBitmap)
                        Case Else
                            Util.MsgStatus(Status1, "Se ha actualizado el registro.", My.Resources.Resources.ok.ToBitmap)
                    End Select
                    '    Else
                    '    Util.MsgStatus(Status1, "No tiene permiso para modificar registros.", My.Resources.stop_error.ToBitmap)
                    'End If
                End If
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        'If ALTA Then
        bolModo = True
        cmbLlenado = False
        Util.MsgStatus(Status1, "Haga click en [Guardar] despues de completar los datos.")
        PrepararBotones()
        Util.LimpiarTextBox(Me.Controls)
        'txtCODIGO.Focus()
        ' Else
        'Util.MsgStatus(Status1, "No tiene permiso para generar registros nuevos.", My.Resources.stop_error.ToBitmap)
        'End If
        cmbLlenado = True 'permito que se llene el cmbGrupos
        cmbMandataria.SelectedIndex = 0 'fuerzo a seleccionar el primer item
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim res As Integer
        Dim ds_Almacen As Data.DataSet
        If MessageBox.Show("Est� seguro que desea eliminar el Dep�sito seleccionado?", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Try
            ds_Almacen = SqlHelper.ExecuteDataset(ConnStringSEI, CommandType.Text, "SELECT  IDAlmacen FROM Materiales where IDAlmacen = '" & txtID.Text & "'")
            ds_Almacen.Dispose()

            If ds_Almacen.Tables(0).Rows.Count > 0 Then
                MsgBox("No se puede eliminar un Dep�sito que est� asociado a un material. Por favor verifique.", MsgBoxStyle.Information, "Atenci�n")
                Exit Sub
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
        'If BAJA_FISICA Then
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
        'Else
        ' Util.MsgStatus(Status1, "No tiene permiso para eliminar registros.", My.Resources.stop_error.ToBitmap)
        'End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        Dim paramalmacenes As New frmParametros
        Dim cnn As New SqlConnection(ConnStringSEI)
        Dim codigo As String
        Dim reportealmacenes As New frmReportes

        'nbreformreportes = "Listado de Almacenes por C�digo"

        'paramalmacenes.AgregarParametros("C�digo :", "STRING", "", False, txtCODIGO.Text.ToString, "", cnn)
        paramalmacenes.ShowDialog()
        ''cerroparametrosconaceptar VARIABLE GLOBAL PARA SABER SI EL FORMULARIO PARAMETROS
        ''SE CERRO DESDE EL BOTON Cerrar o DESDE EL BOTON ACEPTAR SIEMPRE QUE SE UTILICEN PARAMETROS USAR EL IF DE MAS ABAJO
        If cerroparametrosconaceptar = True Then
            ''OBTENGO LOS PARAMETROS QUE LE VOY A PASAR A LA FUNCION..
            codigo = paramalmacenes.ObtenerParametros(0)
            'reportealmacenes.MostrarMaestroAlmacenes(codigo, reportealmacenes)
            cerroparametrosconaceptar = False
            paramalmacenes = Nothing
            'cnn = Nothing
        End If

    End Sub

    Private Sub btnActivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivar.Click
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds_Update As Data.DataSet

        If MessageBox.Show("Est� por activar nuevamente el dep�sito: " & grd.CurrentRow.Cells(2).Value.ToString & ". Desea continuar?", "Atenci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            'llenandoCombo = False
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds_Update = SqlHelper.ExecuteDataset(connection, CommandType.Text, "UPDATE Almacenes SET Eliminado = 0 WHERE id = " & grd.CurrentRow.Cells(0).Value)
            ds_Update.Dispose()

            SQL = "exec spAlmacenes_Select_All @Eliminado = 1"

            LlenarGrilla()

            If grd.RowCount = 0 Then
                btnActivar.Enabled = False
            End If

            Util.MsgStatus(Status1, "El dep�sito se activ� correctamente.", My.Resources.ok.ToBitmap)

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

#End Region

#Region "Procedimientos"

    Private Sub configurarform()

        Me.grd.Location = New Size(GroupPanel1.Location.X, GroupPanel1.Location.Y + GroupPanel1.Size.Height + 7)
        'Me.Size = New Size(Me.Size.Width, 500)
        Me.Size = New Size(Me.Size.Width, (Screen.PrimaryScreen.WorkingArea.Height - 65))
        Dim p As New Size(GroupPanel1.Size.Width, Me.Size.Height - 7 - GroupPanel1.Size.Height - GroupPanel1.Location.Y - 65)
        Me.grd.Size = New Size(p)

        If LLAMADO_POR_FORMULARIO Then
            LLAMADO_POR_FORMULARIO = False
        End If

        Me.Top = 0
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2
    End Sub

    Private Sub asignarTags()
        txtID.Tag = "0"
        'txtCODIGO.Tag = "1"
        'txtNombre.Tag = "2"
    End Sub


    Private Sub LlenarCmbGrupos()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, $"SELECT Id, Nombre FROM Grupos WHERE IdMandataria = {cmbMandataria.SelectedValue}")
            ds.Dispose()

            With cmbGrupo
                .DataSource = ds.Tables(0).DefaultView
                .DisplayMember = "Nombre"
                .ValueMember = "Id"
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
                '.SelectedIndex = "ID"
            End With

        Catch ex As Exception

        End Try
        cmbLlenado = True
    End Sub

    Private Sub Verificar_Datos()

        bolpoliticas = False

        bolpoliticas = True

    End Sub

#End Region

#Region "Funciones"

    Private Function AgregarRegistro() As Integer

        Dim connection As SqlClient.SqlConnection = Nothing
        Dim res As Integer = 0

        Try
            Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End Try

            Try
                Dim param_id As New SqlClient.SqlParameter
                param_id.ParameterName = "@id"
                param_id.SqlDbType = SqlDbType.BigInt
                param_id.Value = DBNull.Value
                param_id.Direction = ParameterDirection.InputOutput

                Dim param_codigo As New SqlClient.SqlParameter
                param_codigo.ParameterName = "@codigo"
                param_codigo.SqlDbType = SqlDbType.VarChar
                param_codigo.Size = 25
                'param_codigo.Value = txtCODIGO.Text
                param_codigo.Direction = ParameterDirection.Input

                Dim param_nombre As New SqlClient.SqlParameter
                param_nombre.ParameterName = "@nombre"
                param_nombre.SqlDbType = SqlDbType.VarChar
                param_nombre.Size = 50
                'param_nombre.Value = txtNombre.Text.ToUpper
                param_nombre.Direction = ParameterDirection.Input

                Dim param_descripcion As New SqlClient.SqlParameter
                param_descripcion.ParameterName = "@descripcion"
                param_descripcion.SqlDbType = SqlDbType.VarChar
                param_descripcion.Size = 100
                'param_descripcion.Value = txtDescripcion.Text.ToUpper
                param_descripcion.Direction = ParameterDirection.Input

                Dim param_idConceptoPago As New SqlClient.SqlParameter
                param_idConceptoPago.ParameterName = "@IdConceptoPago"
                param_idConceptoPago.SqlDbType = SqlDbType.BigInt
                param_idConceptoPago.Value = cmbMandataria.SelectedValue
                param_idConceptoPago.Direction = ParameterDirection.Input

                Dim param_idPerteneceA As New SqlClient.SqlParameter
                param_idPerteneceA.ParameterName = "@IdPerteneceA"
                param_idPerteneceA.SqlDbType = SqlDbType.BigInt
                param_idPerteneceA.Value = cmbGrupo.SelectedValue
                param_idPerteneceA.Direction = ParameterDirection.Input

                Dim param_idTipoValor As New SqlClient.SqlParameter
                param_idTipoValor.ParameterName = "@IdTipoValor"
                param_idTipoValor.SqlDbType = SqlDbType.BigInt
                'param_idTipoValor.Value = cmbTipoValor.SelectedValue
                param_idTipoValor.Direction = ParameterDirection.Input

                Dim param_valor As New SqlClient.SqlParameter
                param_valor.ParameterName = "@Valor"
                param_valor.SqlDbType = SqlDbType.Decimal
                'param_valor.Value = txtValor.Text.ToUpper
                param_valor.Direction = ParameterDirection.Input

                Dim param_IdCamposAplicables As New SqlClient.SqlParameter
                param_IdCamposAplicables.ParameterName = "@IdCamposAplicables"
                param_IdCamposAplicables.SqlDbType = SqlDbType.BigInt
                'param_IdCamposAplicables.Value = cmbCamposAplicables.SelectedValue
                param_IdCamposAplicables.Direction = ParameterDirection.Input

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
                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spConceptos_Insert", param_id, param_codigo, param_nombre, param_descripcion, param_idConceptoPago,
                                              param_idPerteneceA, param_idTipoValor, param_valor,
                                              param_IdCamposAplicables, param_useradd, param_res)
                    txtID.Text = param_id.Value
                    res = param_res.Value

                    If res = 1 Then
                        Util.AgregarGrilla(grd, Me, Permitir)
                        bolModo = False
                        PrepararBotones()
                    End If
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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Function

    Private Function ActualizarRegistro() As Integer
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim res As Integer = 0

        Try
            Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End Try

            Try
                Dim param_id As New SqlClient.SqlParameter
                param_id.ParameterName = "@id"
                param_id.SqlDbType = SqlDbType.BigInt
                param_id.Value = txtID.Text
                param_id.Direction = ParameterDirection.InputOutput

                Dim param_nombre As New SqlClient.SqlParameter
                param_nombre.ParameterName = "@nombre"
                param_nombre.SqlDbType = SqlDbType.VarChar
                param_nombre.Size = 50
                'param_nombre.Value = txtNombre.Text.ToUpper
                param_nombre.Direction = ParameterDirection.Input

                Dim param_descripcion As New SqlClient.SqlParameter
                param_descripcion.ParameterName = "@descripcion"
                param_descripcion.SqlDbType = SqlDbType.VarChar
                param_descripcion.Size = 100
                'param_descripcion.Value = txtDescripcion.Text.ToUpper
                param_descripcion.Direction = ParameterDirection.Input

                Dim param_idConceptoPago As New SqlClient.SqlParameter
                param_idConceptoPago.ParameterName = "@IdConceptoPago"
                param_idConceptoPago.SqlDbType = SqlDbType.BigInt
                param_idConceptoPago.Value = cmbMandataria.SelectedValue
                param_idConceptoPago.Direction = ParameterDirection.Input

                Dim param_idPerteneceA As New SqlClient.SqlParameter
                param_idPerteneceA.ParameterName = "@IdPerteneceA"
                param_idPerteneceA.SqlDbType = SqlDbType.BigInt
                param_idPerteneceA.Value = cmbGrupo.SelectedValue
                param_idPerteneceA.Direction = ParameterDirection.Input

                Dim param_idTipoValor As New SqlClient.SqlParameter
                param_idTipoValor.ParameterName = "@IdTipoValor"
                param_idTipoValor.SqlDbType = SqlDbType.BigInt
                'param_idTipoValor.Value = cmbTipoValor.SelectedValue
                param_idTipoValor.Direction = ParameterDirection.Input

                Dim param_valor As New SqlClient.SqlParameter
                param_valor.ParameterName = "@Valor"
                param_valor.SqlDbType = SqlDbType.Decimal
                'param_valor.Value = txtValor.Text.ToUpper
                param_valor.Direction = ParameterDirection.Input

                Dim param_IdCamposAplicables As New SqlClient.SqlParameter
                param_IdCamposAplicables.ParameterName = "@IdCamposAplicables"
                param_IdCamposAplicables.SqlDbType = SqlDbType.BigInt
                'param_IdCamposAplicables.Value = cmbCamposAplicables.SelectedValue
                param_IdCamposAplicables.Direction = ParameterDirection.Input

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
                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spConceptos_Update", param_id, param_nombre, param_descripcion, param_idConceptoPago,
                                              param_idPerteneceA, param_idTipoValor, param_valor,
                                              param_IdCamposAplicables, param_userupd, param_res)
                    res = param_res.Value


                    PrepararBotones()
                    ActualizarRegistro = res
                    If res > 0 Then ActualizarGrilla(grd, Me)


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

                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spConceptos_Delete", param_id, param_userdel, param_res)
                    res = param_res.Value

                    If res > 0 Then Util.BorrarGrilla(grd)

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

    Private Sub btnAgregarOS_Click(sender As Object, e As EventArgs) Handles btnAgregarOS.Click
        Dim cargarObraSocial As New frmSelectObraSocial
        cargarObraSocial.ShowDialog()
        LlenarGrilla()
    End Sub

    Private Sub LlenarCmbMandatarias()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, $" SELECT ID, NOMBRE FROM Mandatarias WHERE ELIMINADO = 0")
            ds.Dispose()

            With cmbMandataria
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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la informaci�n en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste cont�ctese con MercedesIt a trav�s del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
        cmbLlenado = True

    End Sub

    Private Sub btnAgregarGrupo_Click(sender As Object, e As EventArgs) Handles btnAgregarGrupo.Click
        Dim cargarNuevoGrupo As New frmNuevoGrupo
        cargarNuevoGrupo.ShowDialog()
        LlenarCmbGrupos()
    End Sub

    Private Sub cmbMandataria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMandataria.SelectedValueChanged
        If cmbLlenado = True Then
            cmbGrupo.Text = ""
            LlenarCmbGrupos()
            If cmbMandataria.SelectedValue IsNot Nothing Then
                SQL = $"exec spGrupos_GruposOS_Select_All_By_IDMandataria @idmandataria = {cmbMandataria.SelectedValue}"
                LlenarGrilla()
            End If
        End If
    End Sub

#End Region











End Class