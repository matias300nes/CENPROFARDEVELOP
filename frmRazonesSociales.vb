
Imports Microsoft.ApplicationBlocks.Data
Imports Utiles
Imports Utiles.Util
Imports System.Data.SqlClient
Imports ReportesNet


Public Class frmRazonesSociales
    Dim llenandoCombo As Boolean
    Dim bolpoliticas As Boolean

    Enum gridcols
        Id = 0
        Codigo = 1
        Nombre = 2
        Sociedad = 3
        PreferenciaPago = 4
        Cbu = 5
        Cuit = 6
        NroCuenta = 7
        Banco = 8
        Email = 9
        Celular = 10
        Domicilio = 11
        IdLocalidad = 12
        IdProvincia = 13
        Localidad = 14
        Provincia = 15
    End Enum

#Region "Procedimientos Formularios"

    Private Sub frmAlmacenes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3 'nuevo
                If bolModo = True Then
                    If MessageBox.Show("No ha guardado el Rubro Nuevo que está realizando. ¿Está seguro que desea continuar sin Grabar y hacer un Nuevo Rubro?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
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


        Dim dtPreferenciaPago As New DataTable
        With dtPreferenciaPago
            .Columns.Add("DisplayMember")
            .Columns.Add("ValueMember")

            Dim row1 As DataRow = .NewRow()
            row1("DisplayMember") = "Cheque"
            row1("ValueMember") = "CHEQUE"
            .Rows.Add(row1)

            Dim row2 As DataRow = .NewRow()
            row2("DisplayMember") = "ECheq"
            row2("ValueMember") = "ECHEQ"
            .Rows.Add(row2)

            Dim row3 As DataRow = .NewRow()
            row3("DisplayMember") = "Transferencia"
            row3("ValueMember") = "TRANSFERENCIA"
            .Rows.Add(row3)
        End With

        With cmbPreferenciaPago
            .DataSource = dtPreferenciaPago
            .DisplayMember = "DisplayMember"
            .ValueMember = "ValueMember"
        End With

        'AsignarPermisos(UserID, Me.Name, ALTA, MODIFICA, BAJA, BAJA_FISICA)
        configurarform()
        asignarTags()
        llenandoCombo = False
        LlenarCmbProvincias()
        llenandoCombo = True
        SQL = "exec spRazonesSociales_Select_All 0"
        LlenarGrilla()
        Permitir = True
        CargarCajas()
        PrepararBotones()

        With grd
            .Columns(gridcols.Id).Visible = False
            .Columns(gridcols.IdLocalidad).Visible = False
            .Columns(gridcols.IdProvincia).Visible = False
            .Columns(gridcols.Sociedad).Visible = False
            .Columns(gridcols.Banco).Visible = False
            .Columns(gridcols.Cbu).Visible = False
            .Columns(gridcols.Celular).Visible = False
            .Columns(gridcols.Email).Visible = False
            .Columns(gridcols.Localidad).Visible = False
            .Columns(gridcols.Provincia).Visible = False
            .Columns(gridcols.PreferenciaPago).Visible = False
            .Columns(gridcols.NroCuenta).Visible = False
            'comentado
            '.Columns(gridcols.CampoAplicable).Visible = False
            '.Columns(gridcols.Pertenece).Visible = False
            '.Columns(gridcols.TipoDeValor).Visible = False
            '.Columns(gridcols.ConceptoPago).Visible = False
            .AutoResizeColumns()
        End With
    End Sub

    Private Sub chkEliminados_CheckedChanged(sender As Object, e As EventArgs) Handles chkEliminados.CheckedChanged

        btnNuevo.Enabled = Not chkEliminados.Checked
        btnGuardar.Enabled = Not chkEliminados.Checked
        btnCancelar.Enabled = Not chkEliminados.Checked
        btnEliminar.Enabled = Not chkEliminados.Checked

        txtID.Text = ""
        If chkEliminados.Checked = True Then
            SQL = "exec spRazonesSociales_Select_All @Eliminado = 1"
        Else
            SQL = "exec spRazonesSociales_Select_All @Eliminado = 0"
        End If

        LlenarGrilla()

        CargarCajas()

        If grd.RowCount = 0 Then
            btnActivar.Enabled = False
        Else
            btnActivar.Enabled = chkEliminados.Checked
        End If


    End Sub

#End Region

#Region "Componentes Formulario"


    Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
     Handles txtID.KeyPress, txtCODIGO.KeyPress
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
                            Util.MsgStatus(Status1, "Ya existe otro Registro con este mismo Código.", My.Resources.stop_error.ToBitmap)
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
                btnActualizar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        'If ALTA Then
        bolModo = True
        Util.MsgStatus(Status1, "Haga click en [Guardar] despues de completar los datos.")
        PrepararBotones()
        Util.LimpiarTextBox(Me.Controls)
        txtCODIGO.Focus()
        ' Else
        'Util.MsgStatus(Status1, "No tiene permiso para generar registros nuevos.", My.Resources.stop_error.ToBitmap)
        'End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        'REVISAR

        Dim res As Integer

        If MessageBox.Show("Está seguro que desea eliminar la razón social seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

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

        'nbreformreportes = "Listado de Almacenes por Código"

        paramalmacenes.AgregarParametros("Código :", "STRING", "", False, txtCODIGO.Text.ToString, "", cnn)
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

        If MessageBox.Show("Está por activar nuevamente la razón social: " & grd.CurrentRow.Cells(gridcols.Nombre).Value.ToString & ". Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            'llenandoCombo = False
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds_Update = SqlHelper.ExecuteDataset(connection, CommandType.Text, "UPDATE RazonesSociales SET Eliminado = 0 WHERE id = " & grd.CurrentRow.Cells(0).Value)
            ds_Update.Dispose()

            txtID.Text = ""

            SQL = "exec spRazonesSociales_Select_All @Eliminado = 1"

            LlenarGrilla()

            CargarCajas()

            If grd.RowCount = 0 Then
                btnActivar.Enabled = False
            End If

            Util.MsgStatus(Status1, "La razón social se activó correctamente.", My.Resources.ok.ToBitmap)

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

#Region "Procedimientos"

    Private Sub configurarform()
        'Me.Text = "Conceptos"
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
        txtCODIGO.Tag = "1"
        txtNombre.Tag = "2"
        chkSociedad.Tag = "3"
        cmbPreferenciaPago.Tag = "4"
        txtCbu.Tag = "5"
        txtCuit.Tag = "6"
        txtNroCuenta.Tag = "7"
        txtBanco.Tag = "8"
        txtEmail.Tag = "9"
        txtTelefono.Tag = "10"
        txtDomicilio.Tag = "11"
        cmbProvincia.Tag = "13"
        cmbLocalidad.Tag = "12"
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
        Dim IdLocalidad As Integer

        Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End Try

        IdLocalidad = AgregarLocalidad() ''ME RETORNA EL ID DE LA LOCALIDAD

        If IdLocalidad <> -1 Then

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
                param_codigo.Value = txtCODIGO.Text
                param_codigo.Direction = ParameterDirection.Input

                Dim param_nombre As New SqlClient.SqlParameter
                param_nombre.ParameterName = "@nombre"
                param_nombre.SqlDbType = SqlDbType.VarChar
                param_nombre.Size = 100
                param_nombre.Value = txtNombre.Text.ToUpper
                param_nombre.Direction = ParameterDirection.Input

                Dim param_cuit As New SqlClient.SqlParameter
                param_cuit.ParameterName = "@cuit"
                param_cuit.SqlDbType = SqlDbType.BigInt
                param_cuit.Value = Long.Parse(txtCuit.Text)
                param_cuit.Direction = ParameterDirection.Input

                Dim param_preferenciaPago As New SqlClient.SqlParameter
                param_preferenciaPago.ParameterName = "@preferenciapago"
                param_preferenciaPago.SqlDbType = SqlDbType.VarChar
                param_preferenciaPago.Size = 100
                param_preferenciaPago.Value = cmbPreferenciaPago.Text.ToUpper
                param_preferenciaPago.Direction = ParameterDirection.Input

                Dim param_cbu As New SqlClient.SqlParameter
                param_cbu.ParameterName = "@cbu"
                param_cbu.SqlDbType = SqlDbType.VarChar
                param_cbu.Size = 100
                param_cbu.Value = txtCbu.Text.ToUpper
                param_cbu.Direction = ParameterDirection.Input

                Dim param_nroCuenta As New SqlClient.SqlParameter
                param_nroCuenta.ParameterName = "@nroCuenta"
                param_nroCuenta.SqlDbType = SqlDbType.VarChar
                param_nroCuenta.Size = 100
                param_nroCuenta.Value = txtNroCuenta.Text.ToUpper
                param_nroCuenta.Direction = ParameterDirection.Input

                Dim param_banco As New SqlClient.SqlParameter
                param_banco.ParameterName = "@banco"
                param_banco.SqlDbType = SqlDbType.VarChar
                param_banco.Size = 100
                param_banco.Value = txtBanco.Text.ToUpper
                param_banco.Direction = ParameterDirection.Input

                Dim param_email As New SqlClient.SqlParameter
                param_email.ParameterName = "@email"
                param_email.SqlDbType = SqlDbType.VarChar
                param_email.Size = 100
                param_email.Value = txtEmail.Text.ToUpper
                param_email.Direction = ParameterDirection.Input

                Dim param_celular As New SqlClient.SqlParameter
                param_celular.ParameterName = "@celular"
                param_celular.SqlDbType = SqlDbType.VarChar
                param_celular.Size = 50
                param_celular.Value = txtTelefono.Text.ToUpper
                param_celular.Direction = ParameterDirection.Input

                Dim param_domicilio As New SqlClient.SqlParameter
                param_domicilio.ParameterName = "@domicilio"
                param_domicilio.SqlDbType = SqlDbType.VarChar
                param_domicilio.Size = 200
                param_domicilio.Value = txtDomicilio.Text.ToUpper
                param_domicilio.Direction = ParameterDirection.Input

                Dim param_idLocalidad As New SqlClient.SqlParameter
                param_idLocalidad.ParameterName = "@idLocalidad"
                param_idLocalidad.SqlDbType = SqlDbType.BigInt
                param_idLocalidad.Value = IdLocalidad 'cambiar por idlocalidad
                param_idLocalidad.Direction = ParameterDirection.Input

                Dim param_sociedad As New SqlClient.SqlParameter
                param_sociedad.ParameterName = "@sociedad"
                param_sociedad.SqlDbType = SqlDbType.Bit
                param_sociedad.Value = chkSociedad.Checked
                param_sociedad.Direction = ParameterDirection.Input

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
                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spRazonesSociales_Insert", param_id, param_codigo, param_nombre,
                                              param_cuit, param_preferenciaPago, param_cbu, param_nroCuenta, param_banco, param_email, param_celular,
                                              param_domicilio, param_idLocalidad, param_sociedad, param_useradd, param_res)
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

        End If

    End Function

    Private Function ActualizarRegistro() As Integer
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim res As Integer = 0
        Dim IdLocalidad As Integer

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End Try


        IdLocalidad = AgregarLocalidad() ''ME RETORNA EL ID DE LA LOCALIDAD

            If IdLocalidad <> -1 Then

            Try
                Dim param_id As New SqlClient.SqlParameter
                param_id.ParameterName = "@id"
                param_id.SqlDbType = SqlDbType.BigInt
                param_id.Value = txtID.Text
                param_id.Direction = ParameterDirection.InputOutput

                Dim param_nombre As New SqlClient.SqlParameter
                param_nombre.ParameterName = "@nombre"
                param_nombre.SqlDbType = SqlDbType.VarChar
                param_nombre.Size = 100
                param_nombre.Value = txtNombre.Text.ToUpper
                param_nombre.Direction = ParameterDirection.Input

                Dim param_cuit As New SqlClient.SqlParameter
                param_cuit.ParameterName = "@cuit"
                param_cuit.SqlDbType = SqlDbType.BigInt
                param_cuit.Value = Long.Parse(txtCuit.Text)
                param_cuit.Direction = ParameterDirection.Input

                Dim param_preferenciaPago As New SqlClient.SqlParameter
                param_preferenciaPago.ParameterName = "@preferenciapago"
                param_preferenciaPago.SqlDbType = SqlDbType.VarChar
                param_preferenciaPago.Size = 100
                param_preferenciaPago.Value = cmbPreferenciaPago.Text.ToUpper
                param_preferenciaPago.Direction = ParameterDirection.Input

                Dim param_cbu As New SqlClient.SqlParameter
                param_cbu.ParameterName = "@cbu"
                param_cbu.SqlDbType = SqlDbType.VarChar
                param_cbu.Size = 100
                param_cbu.Value = txtCbu.Text.ToUpper
                param_cbu.Direction = ParameterDirection.Input

                Dim param_nroCuenta As New SqlClient.SqlParameter
                param_nroCuenta.ParameterName = "@nroCuenta"
                param_nroCuenta.SqlDbType = SqlDbType.VarChar
                param_nroCuenta.Size = 100
                param_nroCuenta.Value = txtNroCuenta.Text.ToUpper
                param_nroCuenta.Direction = ParameterDirection.Input

                Dim param_banco As New SqlClient.SqlParameter
                param_banco.ParameterName = "@banco"
                param_banco.SqlDbType = SqlDbType.VarChar
                param_banco.Size = 100
                param_banco.Value = txtBanco.Text.ToUpper
                param_banco.Direction = ParameterDirection.Input

                Dim param_email As New SqlClient.SqlParameter
                param_email.ParameterName = "@email"
                param_email.SqlDbType = SqlDbType.VarChar
                param_email.Size = 100
                param_email.Value = txtEmail.Text.ToUpper
                param_email.Direction = ParameterDirection.Input

                Dim param_celular As New SqlClient.SqlParameter
                param_celular.ParameterName = "@celular"
                param_celular.SqlDbType = SqlDbType.VarChar
                param_celular.Size = 50
                param_celular.Value = txtTelefono.Text.ToUpper
                param_celular.Direction = ParameterDirection.Input

                Dim param_domicilio As New SqlClient.SqlParameter
                param_domicilio.ParameterName = "@domicilio"
                param_domicilio.SqlDbType = SqlDbType.VarChar
                param_domicilio.Size = 200
                param_domicilio.Value = txtDomicilio.Text.ToUpper
                param_domicilio.Direction = ParameterDirection.Input

                Dim param_idLocalidad As New SqlClient.SqlParameter
                param_idLocalidad.ParameterName = "@idLocalidad"
                param_idLocalidad.SqlDbType = SqlDbType.BigInt
                param_idLocalidad.Value = IdLocalidad 'cambiar por idlocalidad
                param_idLocalidad.Direction = ParameterDirection.Input

                Dim param_sociedad As New SqlClient.SqlParameter
                param_sociedad.ParameterName = "@sociedad"
                param_sociedad.SqlDbType = SqlDbType.Bit
                param_sociedad.Value = chkSociedad.Checked
                param_sociedad.Direction = ParameterDirection.Input

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


                SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spRazonesSociales_Update", param_id, param_nombre,
                                              param_cuit, param_preferenciaPago, param_cbu, param_nroCuenta, param_banco, param_email, param_celular,
                                              param_domicilio, param_idLocalidad, param_sociedad, param_userupd, param_res)
                res = param_res.Value


                PrepararBotones()
                ActualizarRegistro = res
                If res > 0 Then ActualizarGrilla(grd, Me)


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
        End If



    End Function

    Private Function EliminarRegistro() As Integer

        Dim connection As SqlClient.SqlConnection = Nothing
        Dim res As Integer = 0


        Try
            Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spRazonesSociales_Delete", param_id, param_userdel, param_res)
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

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Function

    Dim dsGeo

    Private Sub LlenarCmbProvincias()
        Dim da As New SqlDataAdapter
        Dim command As SqlCommand
        dsGeo = New DataSet()
        ''LLENAR COMBOBOX PROVINCIAS
        Dim connection As SqlClient.SqlConnection = Nothing
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim sql_provincias As String = "select ID, Nombre from provincias where eliminado = 0"
        Dim sql_localidades As String = "select ID, Nombre, idProvincia, CodArea from Localidades where eliminado = 0"

        Try

            command = New SqlCommand(sql_provincias, connection)
            da.SelectCommand = command
            da.Fill(dsGeo, "Provincias")


            da.SelectCommand.CommandText = sql_localidades
            da.Fill(dsGeo, "Localidades")


            da.Dispose()
            command.Dispose()
            connection.Close()

            With Me.cmbProvincia
                .DataSource = dsGeo.Tables("Provincias").DefaultView
                .DisplayMember = "Nombre"
                .ValueMember = "ID"
            End With

            LlenarCmbLocalidades(cmbProvincia.SelectedValue)

        Catch ex As Exception
            MessageBox.Show("Hubo un error al comunicarse con la base de datos.", "Error de Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


    End Sub

    Private Sub LlenarCmbLocalidades(ByVal idprovincia As Integer)
        ''LLENAR COMBOBOX PROVINCIAS
        Dim dv As New DataView(dsGeo.Tables("Localidades"))

        If idprovincia <> 0 Then
            dv.RowFilter = $"idProvincia = {cmbProvincia.SelectedValue}"
            ''dsGeo.Tables("Localidades").Select($"idprovincia = {cmbProvincia.SelectedValue}")
        End If

        With Me.cmbLocalidad
            .DataSource = dv
            .DisplayMember = "Nombre"
            .ValueMember = "ID"
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With
        'End If

        If dv.Count = 0 Then
            cmbLocalidad.Text = ""
        End If


    End Sub

    Private Sub cmbLocalidad_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbLocalidad.SelectedValueChanged 'comentar

        If TypeOf cmbLocalidad.SelectedValue Is Long Then

            Dim dv As New DataView(dsGeo.Tables("Localidades"))

            dv.RowFilter = $"ID = {cmbLocalidad.SelectedValue}"

            Dim dt = dv.ToTable()

            If dt.rows.Count > 0 Then
                If cmbProvincia.Text.Equals("") Then
                    cmbProvincia.SelectedValue = dt.Rows(0)("ID")
                End If
                txtCodigoPostal.Text = IIf(dt.Rows(0)("CodArea") IsNot DBNull.Value, dt.Rows(0)("CodArea"), "")
            End If
        End If


    End Sub


    Private Sub cmbProvincia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProvincia.SelectedValueChanged 'comentar
        If llenandoCombo = True Then
            ''LLENAR COMBOBOX LOCALIDADES

            llenandoCombo = False
            LlenarCmbLocalidades(cmbProvincia.SelectedValue)
            llenandoCombo = True

        End If

    End Sub

    Private Function AgregarLocalidad() As Integer
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try

        Try
            Dim param_id As New SqlClient.SqlParameter
            param_id.ParameterName = "@id"
            param_id.SqlDbType = SqlDbType.BigInt
            param_id.Value = cmbLocalidad.SelectedValue
            param_id.Direction = ParameterDirection.InputOutput

            Dim param_nombre As New SqlClient.SqlParameter
            param_nombre.ParameterName = "@Nombre"
            param_nombre.SqlDbType = SqlDbType.VarChar
            param_nombre.Size = 100
            param_nombre.Value = cmbLocalidad.Text.ToUpper
            param_nombre.Direction = ParameterDirection.Input

            Dim param_codArea As New SqlClient.SqlParameter
            param_codArea.ParameterName = "@CodArea"
            param_codArea.SqlDbType = SqlDbType.Int
            param_codArea.Value = IIf(txtCodigoPostal.Text = "", DBNull.Value, txtCodigoPostal.Text)
            param_codArea.Direction = ParameterDirection.Input

            Dim param_IdProvincia As New SqlClient.SqlParameter
            param_IdProvincia.ParameterName = "@IdProvincia"
            param_IdProvincia.SqlDbType = SqlDbType.Int
            param_IdProvincia.Value = cmbProvincia.SelectedValue
            param_IdProvincia.Direction = ParameterDirection.Input


            Dim param_res As New SqlClient.SqlParameter
            param_res.ParameterName = "@res"
            param_res.SqlDbType = SqlDbType.Int
            param_res.Value = DBNull.Value
            param_res.Direction = ParameterDirection.InputOutput


            Try
                SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spLocalidades_Insert", param_id,
                                          param_nombre, param_codArea, param_IdProvincia, param_res)

                'AgregarLocalidad = param_res.Value
                AgregarLocalidad = IIf(param_id.Value IsNot DBNull.Value, param_id.Value, -1)

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

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Function

    Private Sub txtCodigoPostal_LostFocus(sender As Object, e As EventArgs) Handles txtCodigoPostal.LostFocus 'comentar
        If txtCodigoPostal.Text.Length = 4 Then

            Dim dv As New DataView(dsGeo.Tables("Localidades"))

            dv.RowFilter = $"CodArea = {txtCodigoPostal.Text}"

            Dim dt = dv.ToTable()

            If dt.rows.Count > 0 Then
                cmbProvincia.SelectedValue = dt.Rows(0)("IdProvincia")
                cmbLocalidad.SelectedValue = dt.Rows(0)("ID")
            End If

        End If
    End Sub

#End Region



End Class