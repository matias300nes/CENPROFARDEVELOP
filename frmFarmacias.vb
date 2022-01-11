Imports Microsoft.ApplicationBlocks.Data
Imports Utiles
Imports System.Data.SqlClient
Imports ReportesNet


Public Class frmFarmacias

    Dim bolpoliticas As Boolean
    Public Origen As Integer
    Dim codigo As String
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

    Private Sub frmFarmacias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AsignarPermisos(UserID, Me.Name, ALTA, MODIFICA, BAJA, BAJA_FISICA)
        configurarform()
        asignarTags()

        SQL = "exec spFarmacias_Select_All @Eliminado = 0"

        llenandoCombo = False
        LlenarCmbProvincias()
        llenandoCombo = True

        LlenarGrilla()

        Permitir = True

        CargarCajas()

        PrepararBotones()

    End Sub

    Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
     Handles txtID.KeyPress, txtCODIGO.KeyPress, txtFarmacia.KeyPress
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

        If chkEliminados.Checked Then
            SQL = "exec spFarmacias_Select_All @Eliminado = 1"
        Else
            SQL = "exec spFarmacias_Select_All @Eliminado = 0"
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
            If MessageBox.Show("Está seguro que desea modificar la Farmacia seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
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
                    '    Else
                    '    Util.MsgStatus(Status1, "No tiene permiso para modificar registros.", My.Resources.stop_error.ToBitmap)
                    'End If
                End If

                bolModo = False
                PrepararBotones()
                LlenarCmbProvincias()
                MDIPrincipal.NoActualizarBase = False
                btnActualizar_Click(sender, e)

            End If
        End If

        If Origen = 1 Then
            Me.Close()
        End If

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim res As Integer

        If MessageBox.Show("Está seguro que desea eliminar la Farmacia seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
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

        If MessageBox.Show("Está por activar nuevamente la Farmacia: " & grd.CurrentRow.Cells(2).Value.ToString & ". Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
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

            ds_Update = SqlHelper.ExecuteDataset(connection, CommandType.Text, "UPDATE Farmacias SET Eliminado = 0 WHERE id = " & grd.CurrentRow.Cells(0).Value)
            ds_Update.Dispose()


            'If MDIPrincipal.NoActualizar = False Then 'Not SystemInformation.ComputerName.ToString.ToUpper = "SAMBA-PC" Then
            'Try
            '    Dim sqlstring As String

            '    sqlstring = "UPDATE [dbo].[" & NameTable_Marcas & "] SET [Eliminado] = 0 WHERE Codigo = '" & grd.CurrentRow.Cells(1).Value & "'"
            '    tranWEB.Sql_Set(sqlstring)

            'Catch ex As Exception
            '    'MsgBox(ex.Message)
            '    MsgBox("No se puede Activa en la Web la Marca seleccionada. Ejecute el botón sincronizar para actualizar el servidor WEB.")
            'End Try
            'End If

            SQL = "exec spFarmacias_Select_All @Eliminado = 1"

            LlenarGrilla()

            If grd.RowCount = 0 Then
                btnActivar.Enabled = False
            End If

            Util.MsgStatus(Status1, "La Farmacia se activó correctamente.", My.Resources.ok.ToBitmap)

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


    ''hice back
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

                Dim param_CodPAMI As New SqlClient.SqlParameter
                param_CodPAMI.ParameterName = "@CodPAMI"
                param_CodPAMI.SqlDbType = SqlDbType.BigInt
                param_CodPAMI.Value = IIf(txtCodPAMI.Text = "", DBNull.Value, txtCodPAMI.Text) ''IIf(txtCodPAMI.Text = "", DBNull.Value, Long.Parse(txtCodPAMI.Text))
                param_CodPAMI.Direction = ParameterDirection.Input

                Dim param_CodFACAF As New SqlClient.SqlParameter
                param_CodFACAF.ParameterName = "@CodFACAF"
                param_CodFACAF.SqlDbType = SqlDbType.NVarChar
                param_CodFACAF.Size = 300
                param_CodFACAF.Value = IIf(txtCodFACAF.Text = "", DBNull.Value, txtCodFACAF.Text) ''IIf(txtCodFACAF.Text = "", DBNull.Value, Long.Parse(txtCodFACAF.Text))
                param_CodFACAF.Direction = ParameterDirection.Input

                Dim param_nombre As New SqlClient.SqlParameter
                param_nombre.ParameterName = "@nombre"
                param_nombre.SqlDbType = SqlDbType.NVarChar
                param_nombre.Size = 300
                param_nombre.Value = txtFarmacia.Text.ToUpper
                param_nombre.Direction = ParameterDirection.Input

                Dim param_cuit As New SqlClient.SqlParameter
                param_cuit.ParameterName = "@Cuit"
                param_cuit.SqlDbType = SqlDbType.BigInt
                param_cuit.Value = Long.Parse(txtCuit.Text)
                param_cuit.Direction = ParameterDirection.Input

                Dim param_domicilio As New SqlClient.SqlParameter
                param_domicilio.ParameterName = "@Domicilio"
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
                param_telefono.ParameterName = "@Telefono"
                param_telefono.SqlDbType = SqlDbType.VarChar
                param_telefono.Size = 50
                param_telefono.Value = txtTelefono.Text.ToUpper
                param_telefono.Direction = ParameterDirection.Input

                Dim param_email As New SqlClient.SqlParameter
                param_email.ParameterName = "@email"
                param_email.SqlDbType = SqlDbType.VarChar
                param_email.Size = 100
                param_email.Value = txtEmail.Text.ToUpper
                param_email.Direction = ParameterDirection.Input

                Dim param_contribuyente As New SqlClient.SqlParameter
                param_contribuyente.ParameterName = "@Contribuyente"
                param_contribuyente.SqlDbType = SqlDbType.VarChar
                param_contribuyente.Size = 100
                param_contribuyente.Value = txtTipoContribuyente.Text.ToUpper
                param_contribuyente.Direction = ParameterDirection.Input

                Dim param_estadofarmacia As New SqlClient.SqlParameter
                param_estadofarmacia.ParameterName = "@EstadoFarmacia"
                param_estadofarmacia.SqlDbType = SqlDbType.VarChar
                param_estadofarmacia.Size = 10
                param_estadofarmacia.Value = cmbEstado.Text.ToUpper
                param_estadofarmacia.Direction = ParameterDirection.Input

                Dim param_motivobaja As New SqlClient.SqlParameter
                param_motivobaja.ParameterName = "@MotivoBaja"
                param_motivobaja.SqlDbType = SqlDbType.NVarChar
                param_motivobaja.Size = 200
                param_motivobaja.Value = txtMotivoBaja.Text.ToUpper
                param_motivobaja.Direction = ParameterDirection.Input

                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.InputOutput

                Try
                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spFarmacias_Insert", param_id,
                                          param_codigo, param_CodFACAF, param_CodPAMI, param_nombre, param_cuit,
                                          param_domicilio, param_localidad, param_telefono, param_email, param_contribuyente,
                                          param_estadofarmacia, param_motivobaja, param_res)

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

                Dim param_cod As New SqlClient.SqlParameter
                param_cod.ParameterName = "@codigo"
                param_cod.SqlDbType = SqlDbType.VarChar
                param_cod.Size = 10
                param_cod.Value = txtCODIGO.Text
                param_cod.Direction = ParameterDirection.Input

                Dim param_CodPAMI As New SqlClient.SqlParameter
                param_CodPAMI.ParameterName = "@CodPAMI"
                param_CodPAMI.SqlDbType = SqlDbType.BigInt
                param_CodPAMI.Value = IIf(txtCodPAMI.Text = "", DBNull.Value, txtCodPAMI.Text)
                param_CodPAMI.Direction = ParameterDirection.Input

                Dim param_CodFACAF As New SqlClient.SqlParameter
                param_CodFACAF.ParameterName = "@CodFACAF"
                param_CodFACAF.SqlDbType = SqlDbType.NVarChar
                param_CodFACAF.Size = 300
                param_CodFACAF.Value = IIf(txtCodFACAF.Text = "", DBNull.Value, txtCodFACAF.Text)
                param_CodFACAF.Direction = ParameterDirection.Input

                Dim param_nombre As New SqlClient.SqlParameter
                param_nombre.ParameterName = "@nombre"
                param_nombre.SqlDbType = SqlDbType.VarChar
                param_nombre.Size = 300
                param_nombre.Value = txtFarmacia.Text.ToUpper
                param_nombre.Direction = ParameterDirection.Input

                Dim param_cuit As New SqlClient.SqlParameter
                param_cuit.ParameterName = "@Cuit"
                param_cuit.SqlDbType = SqlDbType.BigInt
                param_cuit.Size = 11
                param_cuit.Value = Long.Parse(txtCuit.Text)
                param_cuit.Direction = ParameterDirection.Input

                Dim param_domicilio As New SqlClient.SqlParameter
                param_domicilio.ParameterName = "@Domicilio"
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
                param_telefono.ParameterName = "@Telefono"
                param_telefono.SqlDbType = SqlDbType.VarChar
                param_telefono.Size = 50
                param_telefono.Value = txtTelefono.Text.ToUpper
                param_telefono.Direction = ParameterDirection.Input

                Dim param_email As New SqlClient.SqlParameter
                param_email.ParameterName = "@Email"
                param_email.SqlDbType = SqlDbType.VarChar
                param_email.Size = 100
                param_email.Value = txtEmail.Text.ToUpper
                param_email.Direction = ParameterDirection.Input

                Dim param_contribuyente As New SqlClient.SqlParameter
                param_contribuyente.ParameterName = "@Contribuyente"
                param_contribuyente.SqlDbType = SqlDbType.VarChar
                param_contribuyente.Size = 100
                param_contribuyente.Value = txtTipoContribuyente.Text.ToUpper
                param_contribuyente.Direction = ParameterDirection.Input

                Dim param_estadofarmacia As New SqlClient.SqlParameter
                param_estadofarmacia.ParameterName = "@EstadoFarmacia"
                param_estadofarmacia.SqlDbType = SqlDbType.VarChar
                param_estadofarmacia.Size = 10
                param_estadofarmacia.Value = cmbEstado.Text.ToUpper
                param_estadofarmacia.Direction = ParameterDirection.Input

                Dim param_motivobaja As New SqlClient.SqlParameter
                param_motivobaja.ParameterName = "@MotivoBaja"
                param_motivobaja.SqlDbType = SqlDbType.NVarChar
                param_motivobaja.Size = 200
                param_motivobaja.Value = txtMotivoBaja.Text.ToUpper
                param_motivobaja.Direction = ParameterDirection.Input

                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.InputOutput

                Try
                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spFarmacias_Update", param_id, param_cod,
                                          param_nombre, param_CodFACAF, param_CodPAMI, param_cuit, param_domicilio, param_localidad, param_telefono,
                                          param_email, param_contribuyente, param_estadofarmacia, param_motivobaja, param_res)

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

                SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spFarmacias_Delete", param_id, param_res)
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
        Me.Text = "Farmacias"

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
        txtCodPAMI.Tag = "2"
        txtCodFACAF.Tag = "3"
        txtFarmacia.Tag = "4"
        txtCuit.Tag = "5"
        txtDomicilio.Tag = "6"
        txtTelefono.Tag = "7"
        txtEmail.Tag = "8"
        txtTipoContribuyente.Tag = "9"
        cmbEstado.Text = "10"
        txtMotivoBaja.Text = "11"
        cmbProvincia.Tag = "12"
        cmbLocalidad.Tag = "13"

    End Sub

    Private Sub Verificar_Datos()

        bolpoliticas = True

    End Sub


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


    Private Sub cmbLocalidad_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbLocalidad.SelectedValueChanged

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


    Private Sub cmbProvincia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProvincia.SelectedValueChanged
        If llenandoCombo = True Then
            ''LLENAR COMBOBOX LOCALIDADES

            llenandoCombo = False
            LlenarCmbLocalidades(cmbProvincia.SelectedValue)
            llenandoCombo = True

        End If

    End Sub

    Private Sub txtCodigoPostal_LostFocus(sender As Object, e As EventArgs) Handles txtCodigoPostal.LostFocus
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