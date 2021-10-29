Imports Microsoft.ApplicationBlocks.Data
Imports Utiles
Imports System.Data.SqlClient
Imports ReportesNet


Public Class frmObraSocial

    Dim bolpoliticas As Boolean
    Public Origen As Integer
    Dim codigo As String
    Dim tranWEB As New WS_Porkys.WS_PorkysSoapClient
    Dim llenandoCombo As Boolean

#Region "Componentes Formulario"

    Private Sub frmProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3 'nuevo
                btnNuevo_Click(sender, e)
            Case Keys.F4 'grabar
                btnGuardar_Click(sender, e)
        End Select
    End Sub

    Private Sub frmObraSocial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AsignarPermisos(UserID, Me.Name, ALTA, MODIFICA, BAJA, BAJA_FISICA)
        configurarform()
        asignarTags()

        SQL = "exec spObrasSociales_Select_All @Eliminado = 0"

        llenandoCombo = False
        LlenarCmbProvincias()
        llenandoCombo = True

        LlenarGrilla()

        Permitir = True

        CargarCajas()

        PrepararBotones()

        'fuerzo a que los cmblocalidades tomen el primer valor de la grilla
        grd_CurrentCellChanged(sender, e)

    End Sub

    Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
     Handles txtID.KeyPress, txtCODIGO.KeyPress, txtObservaciones.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub chkEliminados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEliminados.CheckedChanged
        btnNuevo.Enabled = Not chkEliminados.Checked
        btnGuardar.Enabled = Not chkEliminados.Checked
        btnCancelar.Enabled = Not chkEliminados.Checked
        btnEliminar.Enabled = Not chkEliminados.Checked

        If chkEliminados.Checked = True Then
            SQL = "exec spObrasSociales_Select_All @Eliminado = 1"
        Else
            SQL = "exec spObrasSociales_Select_All @Eliminado = 0"
        End If

        LlenarGrilla()

        If grd.RowCount = 0 Then
            btnActivar.Enabled = False
        Else
            btnActivar.Enabled = chkEliminados.Checked
        End If
    End Sub

#End Region

#Region "Botones"

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        bolModo = True
        Util.MsgStatus(Status1, "Haga click en [Guardar] despues de completar los datos.")
        PrepararBotones()
        Util.LimpiarTextBox(Me.Controls)

        txtCODIGO.Focus()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim res As Integer

        If bolModo = False Then
            If MessageBox.Show("Está seguro que desea modificar la obra social seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        Util.MsgStatus(Status1, "Guardando el registro...", My.Resources.Resources.indicator_white)

        If ReglasNegocio() Then
            Verificar_Datos()
            If bolpoliticas Then
                If bolModo Then
                    'If ALTA Then
                    res = AgregarRegistro()
                    Select Case res
                        Case -2
                            Util.MsgStatus(Status1, "El registro ya existe.", My.Resources.Resources.stop_error.ToBitmap)
                            Exit Sub
                        Case -1
                            Util.MsgStatus(Status1, "No se pudo actualizar el registro.", My.Resources.Resources.stop_error.ToBitmap)
                            Exit Sub
                        Case 0
                            Util.MsgStatus(Status1, "No se pudo agregar el registro.", My.Resources.Resources.stop_error.ToBitmap)
                            Exit Sub
                        Case Else
                            Util.MsgStatus(Status1, "Se ha actualizado el registro.", My.Resources.Resources.ok.ToBitmap)
                    End Select
                    'Else
                    '    Util.MsgStatus(Status1, "No tiene permiso para Agregar registros.", My.Resources.stop_error.ToBitmap)
                    'End If
                Else
                    'If MODIFICA Then
                    res = ActualizarRegistro()
                    Select Case res
                        Case -3
                            Util.MsgStatus(Status1, "Ya existe otro Registro con este mismo Código.", My.Resources.stop_error.ToBitmap)
                            Exit Sub
                        Case -2
                            Util.MsgStatus(Status1, "El registro ya existe.", My.Resources.Resources.stop_error.ToBitmap)
                            Exit Sub
                        Case -1
                            Util.MsgStatus(Status1, "No se pudo actualizar el registro.", My.Resources.Resources.stop_error.ToBitmap)
                            Exit Sub
                        Case 0
                            Util.MsgStatus(Status1, "No se pudo agregar el registro.", My.Resources.Resources.stop_error.ToBitmap)
                            Exit Sub
                        Case Else
                            Util.MsgStatus(Status1, "Se ha actualizado el registro.", My.Resources.Resources.ok.ToBitmap)



                    End Select

                End If

                'End If
                bolModo = False
                PrepararBotones()
                MDIPrincipal.NoActualizarBase = False
                btnActualizar_Click(sender, e)

                grd_CurrentCellChanged(sender, e)

            End If
        End If

        If Origen = 1 Then
            Me.Close()
        End If

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim res As Integer

        If MessageBox.Show("Está seguro que desea eliminar la obra social seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        'If BAJA_FISICA Then
        Util.MsgStatus(Status1, "Eliminando el registro...", My.Resources.Resources.indicator_white)
        res = EliminarRegistro()
        Select Case res
            Case -2
                Util.MsgStatus(Status1, "El registro no existe.", My.Resources.stop_error.ToBitmap)
                Exit Sub
            Case -1
                Util.MsgStatus(Status1, "No se pudo borrar el registro.", My.Resources.stop_error.ToBitmap)
                Exit Sub
            Case 0
                Util.MsgStatus(Status1, "No se pudo borrar el registro.", My.Resources.stop_error.ToBitmap)
                Exit Sub
            Case Else
                Util.MsgStatus(Status1, "Se ha borrado el registro.", My.Resources.ok.ToBitmap)
                If Me.grd.RowCount = 0 Then
                    bolModo = True
                    PrepararBotones()
                    Util.LimpiarTextBox(Me.Controls)
                End If


        End Select


        'Else
        'Util.MsgStatus(Status1, "No tiene permiso para eliminar registros.", My.Resources.stop_error.ToBitmap)
        'End If
    End Sub

    Private Sub btnActivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivar.Click
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds_Update As Data.DataSet

        If MessageBox.Show("Está por activar nuevamente la obra social: " & grd.CurrentRow.Cells(2).Value.ToString & ". Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
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

            ds_Update = SqlHelper.ExecuteDataset(connection, CommandType.Text, "UPDATE ObrasSociales SET Eliminado = 0 WHERE id = " & grd.CurrentRow.Cells(0).Value)
            ds_Update.Dispose()

            SQL = "exec spObrasSociales_Select_All @Eliminado = 1"

            LlenarGrilla()

            If grd.RowCount = 0 Then
                btnActivar.Enabled = False
            End If

            Util.MsgStatus(Status1, "La obra social se activó correctamente.", My.Resources.ok.ToBitmap)

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

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        'Dim paramproveedores As New frmParametros
        'Dim Cnn As New SqlConnection(ConnStringSEI)
        'Dim codigo As String
        'Dim reporteproveedores As New frmReportes


        ''nbreformreportes = "Listado de Proveedores por Código"

        'paramproveedores.AgregarParametros("Código :", "STRING", "", False, txtCODIGO.Text.ToString, "", Cnn)
        'paramproveedores.ShowDialog()
        ' ''cerroparametrosconaceptar VARIABLE GLOBAL PARA SABER SI EL FORMULARIO PARAMETROS
        ' ''SE CERRO DESDE EL BOTON Cerrar o DESDE EL BOTON ACEPTAR SIEMPRE QUE SE UTILICEN PARAMETROS USAR EL IF DE MAS ABAJO
        'If cerroparametrosconaceptar = True Then
        '    ''OBTENGO LOS PARAMETROS QUE LE VOY A PASAR A LA FUNCION..
        '    codigo = paramproveedores.ObtenerParametros(0)
        '    reporteproveedores.MostrarMaestroProveedores(codigo, reporteproveedores, "ACER")
        '    cerroparametrosconaceptar = False
        '    paramproveedores = Nothing
        '    Cnn = Nothing
        'End If
    End Sub

#End Region

#Region "Funciones"

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

                'codigo = param_codigo.Value

                Select Case param_id.Value
                    Case -3
                        Util.MsgStatus(Status1, "El registro ya existe.", My.Resources.Resources.stop_error.ToBitmap)
                        Return -1
                    Case 0
                        Util.MsgStatus(Status1, "No se pudo actualizar el registro.", My.Resources.Resources.stop_error.ToBitmap)
                        Return -1
                    Case -1
                        Util.MsgStatus(Status1, "No se pudo agregar el registro.", My.Resources.Resources.stop_error.ToBitmap)
                        Return -1
                    Case Else
                        Util.MsgStatus(Status1, "Se ha actualizado el registro.", My.Resources.Resources.ok.ToBitmap)
                End Select

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



    Private Function AgregarRegistro() As Integer
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim IdLocalidad As Integer
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                param_codigo.Size = 10
                param_codigo.Value = DBNull.Value
                param_codigo.Direction = ParameterDirection.InputOutput

                Dim param_codFACAF As New SqlClient.SqlParameter
                param_codFACAF.ParameterName = "@codFACAF"
                param_codFACAF.SqlDbType = SqlDbType.VarChar
                param_codFACAF.Size = 3
                param_codFACAF.Value = txtCodigoFacaf.Text
                param_codFACAF.Direction = ParameterDirection.Input

                Dim param_nombre As New SqlClient.SqlParameter
                param_nombre.ParameterName = "@nombre"
                param_nombre.SqlDbType = SqlDbType.VarChar
                param_nombre.Size = 100
                param_nombre.Value = txtObservaciones.Text.ToUpper
                param_nombre.Direction = ParameterDirection.Input

                Dim param_descripcion As New SqlClient.SqlParameter
                param_descripcion.ParameterName = "@descripcion"
                param_descripcion.SqlDbType = SqlDbType.VarChar
                param_descripcion.Size = 200
                param_descripcion.Value = txtDescripcion.Text
                param_descripcion.Direction = ParameterDirection.Input

                Dim param_domicilio As New SqlClient.SqlParameter
                param_domicilio.ParameterName = "@domicilio"
                param_domicilio.SqlDbType = SqlDbType.VarChar
                param_domicilio.Size = 200
                param_domicilio.Value = txtDomicilio.Text.ToUpper
                param_domicilio.Direction = ParameterDirection.Input

                Dim param_localidad As New SqlClient.SqlParameter
                param_localidad.ParameterName = "@localidad"
                param_localidad.SqlDbType = SqlDbType.BigInt
                param_localidad.Value = IdLocalidad
                param_localidad.Direction = ParameterDirection.Input

                Dim param_telefono As New SqlClient.SqlParameter
                param_telefono.ParameterName = "@telefono"
                param_telefono.SqlDbType = SqlDbType.VarChar
                param_telefono.Size = 20
                param_telefono.Value = txtTelefono.Text
                param_telefono.Direction = ParameterDirection.Input

                Dim param_email As New SqlClient.SqlParameter
                param_email.ParameterName = "@email"
                param_email.SqlDbType = SqlDbType.VarChar
                param_email.Size = 50
                param_email.Value = txtEmail.Text
                param_email.Direction = ParameterDirection.Input

                Dim param_cuit As New SqlClient.SqlParameter
                param_cuit.ParameterName = "@cuit"
                param_cuit.SqlDbType = SqlDbType.BigInt
                param_cuit.Size = 11
                param_cuit.Value = Long.Parse(txtCuit.Text)
                param_cuit.Direction = ParameterDirection.Input

                Dim param_bonificacion As New SqlClient.SqlParameter
                param_bonificacion.ParameterName = "@bonificacion"
                param_bonificacion.SqlDbType = SqlDbType.Decimal
                param_bonificacion.Size = 10
                param_bonificacion.Value = Decimal.Parse(nudBonificacion.Value)
                param_bonificacion.Direction = ParameterDirection.Input

                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.InputOutput

                Try
                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spObrasSociales_Insert", param_id,
                                              param_codigo, param_codFACAF, param_nombre, param_descripcion, param_domicilio,
                                              param_localidad, param_telefono, param_email, param_cuit, param_bonificacion,
                                              param_res)

                    txtID.Text = param_id.Value
                    codigo = param_codigo.Value

                    AgregarRegistro = param_res.Value


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
        Dim res As Integer = 0
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim IdLocalidad As Integer

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End Try

        IdLocalidad = AgregarLocalidad() ''ME RETORNA EL ID DE LA LOCALIDAD

        If IdLocalidad <> -1 Then
            Try
                Dim param_id As New SqlClient.SqlParameter
                param_id.ParameterName = "@id"
                param_id.SqlDbType = SqlDbType.BigInt
                param_id.Value = CType(txtID.Text, Long)
                param_id.Direction = ParameterDirection.Input

                Dim param_nombre As New SqlClient.SqlParameter
                param_nombre.ParameterName = "@nombre"
                param_nombre.SqlDbType = SqlDbType.VarChar
                param_nombre.Size = 300
                param_nombre.Value = txtObservaciones.Text.ToUpper
                param_nombre.Direction = ParameterDirection.Input

                Dim param_cuit As New SqlClient.SqlParameter
                param_cuit.ParameterName = "@cuit"
                param_cuit.SqlDbType = SqlDbType.BigInt
                param_cuit.Value = Long.Parse(txtCuit.Text)
                param_cuit.Direction = ParameterDirection.Input

                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.InputOutput

                ''-------------------------------------------------

                Dim param_codFACAF As New SqlClient.SqlParameter
                param_codFACAF.ParameterName = "@codFACAF"
                param_codFACAF.SqlDbType = SqlDbType.VarChar
                param_codFACAF.Size = 3
                param_codFACAF.Value = txtCodigoFacaf.Text
                param_codFACAF.Direction = ParameterDirection.Input

                Dim param_descripcion As New SqlClient.SqlParameter
                param_descripcion.ParameterName = "@descripcion"
                param_descripcion.SqlDbType = SqlDbType.VarChar
                param_descripcion.Size = 200
                param_descripcion.Value = txtDescripcion.Text
                param_descripcion.Direction = ParameterDirection.Input

                Dim param_domicilio As New SqlClient.SqlParameter
                param_domicilio.ParameterName = "@domicilio"
                param_domicilio.SqlDbType = SqlDbType.VarChar
                param_domicilio.Size = 200
                param_domicilio.Value = txtDomicilio.Text.ToUpper
                param_domicilio.Direction = ParameterDirection.Input

                Dim param_localidad As New SqlClient.SqlParameter
                param_localidad.ParameterName = "@localidad"
                param_localidad.SqlDbType = SqlDbType.BigInt
                param_localidad.Value = IdLocalidad
                param_localidad.Direction = ParameterDirection.Input

                Dim param_telefono As New SqlClient.SqlParameter
                param_telefono.ParameterName = "@telefono"
                param_telefono.SqlDbType = SqlDbType.VarChar
                param_telefono.Size = 20
                param_telefono.Value = txtTelefono.Text
                param_telefono.Direction = ParameterDirection.Input

                Dim param_email As New SqlClient.SqlParameter
                param_email.ParameterName = "@email"
                param_email.SqlDbType = SqlDbType.VarChar
                param_email.Size = 50
                param_email.Value = txtEmail.Text
                param_email.Direction = ParameterDirection.Input

                Dim param_bonificacion As New SqlClient.SqlParameter
                param_bonificacion.ParameterName = "@bonificacion"
                param_bonificacion.SqlDbType = SqlDbType.Decimal
                param_bonificacion.Size = 10
                param_bonificacion.Value = Decimal.Parse(nudBonificacion.Value)
                param_bonificacion.Direction = ParameterDirection.Input

                ''------------------------------------------------


                SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spObrasSociales_Update", param_id,
                                              param_nombre, param_codFACAF, param_telefono, param_email, param_cuit,
                                              param_descripcion, param_domicilio, param_localidad, param_bonificacion, param_res)

                ActualizarRegistro = param_res.Value


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
        Dim res As Integer = 0
        Dim connection As SqlClient.SqlConnection = Nothing


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

            Dim param_res As New SqlClient.SqlParameter
            param_res.ParameterName = "@res"
            param_res.SqlDbType = SqlDbType.Int
            param_res.Value = DBNull.Value
            param_res.Direction = ParameterDirection.Output

            Try

                SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spObrasSociales_Delete", param_id, param_res)
                res = param_res.Value

                If res > 0 Then
                    'If MDIPrincipal.NoActualizar = False Then 'Not SystemInformation.ComputerName.ToString.ToUpper = "SAMBA-PC" Then
                    'Try
                    '    Dim sqlstring As String

                    '    sqlstring = "UPDATE [dbo].[" & NameTable_Marcas & "] SET [Eliminado] = 1 WHERE Codigo = '" & txtCODIGO.Text & "'"
                    '    tranWEB.Sql_Set(sqlstring)

                    'Catch ex As Exception
                    '    'MsgBox(ex.Message)
                    '    MsgBox("No se puede actualizar en la Web la lista de Marcas. Ejecute el botón sincronizar para actualizar el servidor WEB.")
                    'End Try
                    'End If
                    Util.BorrarGrilla(grd)

                End If

                EliminarRegistro = res

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
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Function

#End Region

#Region "Procedimientos"

    Private Sub configurarform()
        Me.Text = "Obras Sociales"

        Me.grd.Location = New Size(GroupBox1.Location.X, GroupBox1.Location.Y + GroupBox1.Size.Height + 7)

        'Me.Size = New Size(IIf(Me.Size.Width <= AnchoMinimoForm, AnchoMinimoForm, Me.Size.Width), Me.grd.Location.Y + Me.grd.Size.Height + 65)
        Me.Size = New Size(Me.Size.Width, (Screen.PrimaryScreen.WorkingArea.Height - 65))
        '65-7-65
        Dim p As New Size(GroupBox1.Size.Width, Me.Size.Height - 7 - GroupBox1.Size.Height - GroupBox1.Location.Y - 65)
        Me.grd.Size = New Size(p)

        If LLAMADO_POR_FORMULARIO Then
            LLAMADO_POR_FORMULARIO = False
            'Me.Top = ARRIBA
            'Me.Left = IZQUIERDA
            'Else
            '    Me.Top = 0
            '    Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2
        End If

        Me.Top = 0
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2

    End Sub

    Private Sub asignarTags()
        txtID.Tag = "0"
        txtCODIGO.Tag = "1"
        txtObservaciones.Tag = "2"
        txtCodigoFacaf.Tag = "3"
        txtTelefono.Tag = "4"
        txtEmail.Tag = "5"
        txtCuit.Tag = "6"
        txtDescripcion.Tag = "7"
        nudBonificacion.Tag = "8"
        txtDomicilio.Tag = "9"
        cmbLocalidad.Tag = "10"
        cmbProvincia.Tag = "11"

    End Sub

    Private Sub Verificar_Datos()

        bolpoliticas = False

        bolpoliticas = True

    End Sub




    Private Sub LlenarCmbProvincias()
        ''LLENAR COMBOBOX PROVINCIAS
        Dim connection As SqlClient.SqlConnection = Nothing
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim sql_provincias As String = "select ID, Nombre from provincias where eliminado = 0"

        Try
            Dim ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, sql_provincias)

            ds.Dispose()

            With Me.cmbProvincia
                .DataSource = ds.Tables(0).DefaultView
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
        Dim connection As SqlClient.SqlConnection = Nothing
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        Dim sql_localidades As String
        If idprovincia = 0 Then
            sql_localidades = "select ID, Nombre from Localidades where eliminado = 0"
        Else
            sql_localidades = $"select ID, Nombre from Localidades where eliminado = 0 and idprovincia = {cmbProvincia.SelectedValue}"
        End If


        Try
            Dim ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, sql_localidades)

            ds.Dispose()

            If ds.Tables(0).Rows.Count > 0 Then
                With Me.cmbLocalidad
                    .DataSource = ds.Tables(0).DefaultView
                    .DisplayMember = "Nombre"
                    .ValueMember = "ID"
                    .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                    .AutoCompleteSource = AutoCompleteSource.ListItems
                End With
            End If

        Catch ex As Exception
            MessageBox.Show("Hubo un error al comunicarse con la base de datos.", "Error de Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


    End Sub


    Private Sub cmbLocalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLocalidad.SelectedIndexChanged

        If llenandoCombo = True Then
            ''LLENAR COMBOBOX LOCALIDADES
            Dim connection As SqlClient.SqlConnection = Nothing
            Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            Dim sql_postal As String = $"select ID, CodArea from Localidades
                                        where ID = '{cmbLocalidad.SelectedValue}'"

            Try
                Dim ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, sql_postal)
                ds.dispose()
                If ds.Tables(0).Rows.Count > 0 Then
                    txtCodigoPostal.Text = IIf(ds.Tables(0).Rows(0)("CodArea") IsNot DBNull.Value, ds.Tables(0).Rows(0)("CodArea"), "")
                End If


            Catch ex As Exception
                MessageBox.Show($"Hubo un error al comunicarse con la base de datos. {ex}", "Error de Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If


    End Sub


    Private Sub cmbProvincia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProvincia.SelectedValueChanged
        If llenandoCombo = True Then
            ''LLENAR COMBOBOX LOCALIDADES

            llenandoCombo = False
            LlenarCmbLocalidades(cmbProvincia.SelectedValue)
            llenandoCombo = True

        End If



    End Sub

    Private Sub txtCodigoPostal_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoPostal.TextChanged
        If txtCodigoPostal.Text.Length = 4 Then
            Dim connection As SqlClient.SqlConnection = Nothing
            Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
            Catch ex As Exception
                MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            Dim sql_postal As String = $"select ID, IdProvincia, CodArea from Localidades
                                        where CodArea = {txtCodigoPostal.Text}"

            Try
                Dim ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, sql_postal)
                ds.Dispose()
                If ds.Tables(0).Rows.Count > 0 Then
                    cmbProvincia.SelectedValue = ds.Tables(0).Rows(0)("IdProvincia")
                    cmbLocalidad.SelectedValue = ds.Tables(0).Rows(0)("ID")
                End If
            Catch ex As Exception
                MessageBox.Show($"Hubo un error al comunicarse con la base de datos.{ex}", "Error de Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
    End Sub

    Protected Overloads Sub grd_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.CurrentCellChanged

        If Not grd.CurrentRow Is Nothing Then
            cmbProvincia.SelectedValue = grd.CurrentRow.Cells(11).Value


            cmbLocalidad.SelectedValue = grd.CurrentRow.Cells(10).Value
            cmbLocalidad.Text = grd.CurrentRow.Cells(12).Value
        End If

    End Sub


#End Region


End Class