Imports Microsoft.ApplicationBlocks.Data
Imports Utiles
Imports System.Data.SqlClient
Imports ReportesNet


Public Class frmFarmacias_Conceptos
    Dim count As Integer
    Dim bolpoliticas As Boolean
    Public Origen As Integer
    Dim codigo As String
    Dim llenandoCombo As Boolean


#Region "Enums"
    Enum Codigos
        FACAF = 0
        PAMI = 1
        FARMALINK = 2
        FARMAPLUS = 3
        CSF = 4
    End Enum

    Enum ColumnasDelGrdConceptosPanel
        Id = 0
        Codigo = 1
        Nombre = 2
        Descripcion = 3
        ConceptoPago = 4
        PerteneceA = 5
        TipoValor = 6
        Valor = 7
        Frecuencia = 8
        CampoAplicable = 9
    End Enum

    Enum ColumnasDelGrdProfesionalesPanel
        Id = 0
        Codigo = 1
        Nombre = 2
        Apellido = 3
        Direccion = 4
        Celular = 5
        Email = 6
    End Enum
    Enum GridItemsCols
        ID = 0
        Codigo = 1
        CodPAMI = 2
        CodFACAF = 3
        CodFarmaLink = 4
        CodFarmaPlus = 5
        CodCSF = 6
        Farmacia = 7
        Cuit = 8
        RazonSocial = 9
        PreferenciaPago = 10
        Cbu = 11
        Domicilio = 12
        Telefono = 13
        Email = 14
        Contribuyente = 15
        EstadoFarmacia = 16
        MotivoBaja = 17
        IdProvincia = 18
        IdLocalidad = 19
        Localidad = 20
    End Enum
#End Region


#Region "Componentes Formulario"

    Private Sub frmProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3 'nuevo
                btnNuevo_Click(sender, e)
            Case Keys.F4 'grabar
                btnGuardar_Click(sender, e)
        End Select
    End Sub

    Private Sub frmFarmacias_Conceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dtPreferenciaPago As New DataTable
        With dtPreferenciaPago
            .Columns.Add("DisplayMember")
            .Columns.Add("ValueMember")

            Dim row1 As DataRow = .NewRow()
            row1("DisplayMember") = "Cheque"
            row1("ValueMember") = "CHEQUE"
            .Rows.Add(row1)

            Dim row2 As DataRow = .NewRow()
            row2("DisplayMember") = "Transferencia"
            row2("ValueMember") = "TRANSFERENCIA"
            .Rows.Add(row2)
        End With

        With cmbPreferenciaPago
            .DataSource = dtPreferenciaPago
            .DisplayMember = "DisplayMember"
            .ValueMember = "ValueMember"
        End With

        'AsignarPermisos(UserID, Me.Name, ALTA, MODIFICA, BAJA, BAJA_FISICA)
        configurarform()
        asignarTags()

        SQL = "exec spFarmacias_Select_All @Eliminado = 0"

        llenandoCombo = False
        LlenarCmbProvincias()
        llenandoCombo = True

        ''LLenar grdCodigos
        grdCodigos.Rows.Add("FACAF", DBNull.Value)
        grdCodigos.Rows.Add("PAMI", DBNull.Value)
        grdCodigos.Rows.Add("FARMALINK", DBNull.Value)
        grdCodigos.Rows.Add("FARM+", DBNull.Value)
        grdCodigos.Rows.Add("Compañia Servicios Farmaceuticos", DBNull.Value)

        LlenarGrilla()
        ''lleno la grilla dependiendo en que panel me encuentre
        Select Case SuperTabControl1.SelectedPanel.Name
            Case "SuperTabControlPanel1" 'Panel Conceptos
                LlenarGrdConceptosPanel()
            Case "SuperTabControlPanel2" 'Panel Profesionales
                LlenarGrdProfesionalesPanel()
        End Select

        setStyles()

        Permitir = True

        CargarCajas()

        PrepararBotones()

        grd_CurrentCellChanged(sender, e)
        grd.AutoResizeColumns()
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
        MyBase.btnEliminar.Enabled = Not chkEliminados.Checked

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

        Dim longitudCuit = txtCuit.Text.Length

        If longitudCuit < 11 Then
            MsgBox("El cuit debe ser de 11 dígitos.", MsgBoxStyle.Information, "Control de Errores")
            txtCuit.Focus()
        Else
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
                param_CodPAMI.SqlDbType = SqlDbType.NVarChar
                param_CodPAMI.Size = 300
                param_CodPAMI.Value = grdCodigos.Rows(Codigos.PAMI).Cells(1).Value
                param_CodPAMI.Direction = ParameterDirection.Input

                Dim param_CodFACAF As New SqlClient.SqlParameter
                param_CodFACAF.ParameterName = "@CodFACAF"
                param_CodFACAF.SqlDbType = SqlDbType.NVarChar
                param_CodFACAF.Size = 300
                param_CodFACAF.Value = grdCodigos.Rows(Codigos.FACAF).Cells(1).Value
                param_CodFACAF.Direction = ParameterDirection.Input

                Dim param_CodFarmaLink As New SqlClient.SqlParameter
                param_CodFarmaLink.ParameterName = "@CodFarmaLink"
                param_CodFarmaLink.SqlDbType = SqlDbType.NVarChar
                param_CodFarmaLink.Size = 300
                param_CodFarmaLink.Value = grdCodigos.Rows(Codigos.FARMALINK).Cells(1).Value
                param_CodFarmaLink.Direction = ParameterDirection.Input

                Dim param_CodFarmaPlus As New SqlClient.SqlParameter
                param_CodFarmaPlus.ParameterName = "@CodFarmaPlus"
                param_CodFarmaPlus.SqlDbType = SqlDbType.NVarChar
                param_CodFarmaPlus.Size = 300
                param_CodFarmaPlus.Value = grdCodigos.Rows(Codigos.FARMAPLUS).Cells(1).Value
                param_CodFarmaPlus.Direction = ParameterDirection.Input

                Dim param_CodCSF As New SqlClient.SqlParameter
                param_CodCSF.ParameterName = "@CodCSF"
                param_CodCSF.SqlDbType = SqlDbType.NVarChar
                param_CodCSF.Size = 300
                param_CodCSF.Value = grdCodigos.Rows(Codigos.CSF).Cells(1).Value
                param_CodCSF.Direction = ParameterDirection.Input

                Dim param_nombre As New SqlClient.SqlParameter
                param_nombre.ParameterName = "@nombre"
                param_nombre.SqlDbType = SqlDbType.NVarChar
                param_nombre.Size = 300
                param_nombre.Value = txtFarmacia.Text.ToUpper
                param_nombre.Direction = ParameterDirection.Input

                Dim param_razonSocial As New SqlClient.SqlParameter
                param_razonSocial.ParameterName = "@RazonSocial"
                param_razonSocial.SqlDbType = SqlDbType.VarChar
                param_razonSocial.Size = 100
                param_razonSocial.Value = txtRazonSocial.Text.ToUpper
                param_razonSocial.Direction = ParameterDirection.Input

                Dim param_preferenciaPago As New SqlClient.SqlParameter
                param_preferenciaPago.ParameterName = "@PreferenciaPago"
                param_preferenciaPago.SqlDbType = SqlDbType.VarChar
                param_preferenciaPago.Size = 100
                param_preferenciaPago.Value = cmbPreferenciaPago.Text.ToUpper
                param_preferenciaPago.Direction = ParameterDirection.Input

                Dim param_cbu As New SqlClient.SqlParameter
                param_cbu.ParameterName = "@Cbu"
                param_cbu.SqlDbType = SqlDbType.VarChar
                param_cbu.Size = 100
                param_cbu.Value = txtCBU.Text.ToUpper
                param_cbu.Direction = ParameterDirection.Input

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
                param_motivobaja.SqlDbType = SqlDbType.VarChar
                param_motivobaja.Size = 200
                param_motivobaja.Value = txtMotivoBaja.Text.ToUpper
                param_motivobaja.Direction = ParameterDirection.Input

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
                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spFarmacias_Insert", param_id,
                                          param_codigo, param_CodFACAF, param_CodPAMI, param_CodFarmaLink, param_CodFarmaPlus,
                                          param_CodCSF, param_nombre, param_razonSocial, param_preferenciaPago, param_cbu, param_cuit, param_domicilio, param_localidad,
                                          param_telefono, param_email, param_contribuyente, param_estadofarmacia, param_motivobaja,
                                          param_user, param_res)

                    txtID.Text = param_id.Value
                    codigo = param_codigo.Value

                    If param_res.Value = 1 Then
                        AgregarRelacionConcepto_Farmacia()
                        AgregarRelacionProfesional_Farmacia()
                    End If

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
                param_CodPAMI.SqlDbType = SqlDbType.NVarChar
                param_CodPAMI.Size = 300
                param_CodPAMI.Value = grdCodigos.Rows(Codigos.PAMI).Cells(1).Value
                param_CodPAMI.Direction = ParameterDirection.Input

                Dim param_CodFACAF As New SqlClient.SqlParameter
                param_CodFACAF.ParameterName = "@CodFACAF"
                param_CodFACAF.SqlDbType = SqlDbType.NVarChar
                param_CodFACAF.Size = 300
                param_CodFACAF.Value = grdCodigos.Rows(Codigos.FACAF).Cells(1).Value
                param_CodFACAF.Direction = ParameterDirection.Input

                Dim param_CodFarmaLink As New SqlClient.SqlParameter
                param_CodFarmaLink.ParameterName = "@CodFarmaLink"
                param_CodFarmaLink.SqlDbType = SqlDbType.NVarChar
                param_CodFarmaLink.Size = 300
                param_CodFarmaLink.Value = grdCodigos.Rows(Codigos.FARMALINK).Cells(1).Value
                param_CodFarmaLink.Direction = ParameterDirection.Input

                Dim param_CodFarmaPlus As New SqlClient.SqlParameter
                param_CodFarmaPlus.ParameterName = "@CodFarmaPlus"
                param_CodFarmaPlus.SqlDbType = SqlDbType.NVarChar
                param_CodFarmaPlus.Size = 300
                param_CodFarmaPlus.Value = grdCodigos.Rows(Codigos.FARMAPLUS).Cells(1).Value
                param_CodFarmaPlus.Direction = ParameterDirection.Input

                Dim param_CodCSF As New SqlClient.SqlParameter
                param_CodCSF.ParameterName = "@CodCSF"
                param_CodCSF.SqlDbType = SqlDbType.NVarChar
                param_CodCSF.Size = 300
                param_CodCSF.Value = grdCodigos.Rows(Codigos.CSF).Cells(1).Value
                param_CodCSF.Direction = ParameterDirection.Input

                Dim param_nombre As New SqlClient.SqlParameter
                param_nombre.ParameterName = "@nombre"
                param_nombre.SqlDbType = SqlDbType.VarChar
                param_nombre.Size = 300
                param_nombre.Value = txtFarmacia.Text.ToUpper
                param_nombre.Direction = ParameterDirection.Input

                Dim param_razonSocial As New SqlClient.SqlParameter
                param_razonSocial.ParameterName = "@RazonSocial"
                param_razonSocial.SqlDbType = SqlDbType.VarChar
                param_razonSocial.Size = 100
                param_razonSocial.Value = txtRazonSocial.Text.ToUpper
                param_razonSocial.Direction = ParameterDirection.Input

                Dim param_preferenciaPago As New SqlClient.SqlParameter
                param_preferenciaPago.ParameterName = "@PreferenciaPago"
                param_preferenciaPago.SqlDbType = SqlDbType.VarChar
                param_preferenciaPago.Size = 100
                param_preferenciaPago.Value = cmbPreferenciaPago.Text.ToUpper
                param_preferenciaPago.Direction = ParameterDirection.Input

                Dim param_cbu As New SqlClient.SqlParameter
                param_cbu.ParameterName = "@Cbu"
                param_cbu.SqlDbType = SqlDbType.VarChar
                param_cbu.Size = 100
                param_cbu.Value = txtCBU.Text.ToUpper
                param_cbu.Direction = ParameterDirection.Input

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
                param_motivobaja.SqlDbType = SqlDbType.VarChar
                param_motivobaja.Size = 200
                param_motivobaja.Value = txtMotivoBaja.Text.ToUpper
                param_motivobaja.Direction = ParameterDirection.Input

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
                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spFarmacias_Update", param_id, param_cod,
                                          param_nombre, param_CodFACAF, param_CodPAMI, param_CodFarmaLink, param_CodFarmaPlus,
                                          param_CodCSF, param_razonSocial, param_preferenciaPago, param_cbu, param_cuit, param_domicilio, param_localidad, param_telefono,
                                          param_email, param_contribuyente, param_estadofarmacia, param_motivobaja, param_user, param_res)

                    If param_res.Value = 1 Then
                        AgregarRelacionConcepto_Farmacia()
                        AgregarRelacionProfesional_Farmacia()
                    End If
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

    Private Sub setStyles()
        ''Ocultar columnas no necesarias
        With grd
            .Columns(GridItemsCols.CodPAMI).Visible = False
            .Columns(GridItemsCols.CodFarmaLink).Visible = False
            .Columns(GridItemsCols.CodFarmaPlus).Visible = False
            .Columns(GridItemsCols.CodCSF).Visible = False
            .Columns(GridItemsCols.Contribuyente).Visible = False
            .Columns(GridItemsCols.PreferenciaPago).Visible = False
            .Columns(GridItemsCols.Cbu).Visible = False
            .Columns(GridItemsCols.Telefono).Visible = False
            .Columns(GridItemsCols.Domicilio).Visible = False
            .Columns(GridItemsCols.EstadoFarmacia).Visible = False
            .Columns(GridItemsCols.IdLocalidad).Visible = False
            .Columns(GridItemsCols.IdProvincia).Visible = False
            .Columns(GridItemsCols.MotivoBaja).Visible = False
            .AutoResizeColumns()

        End With
        With grdConceptosPanel
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns(ColumnasDelGrdConceptosPanel.Id).Visible = False
            .Columns(ColumnasDelGrdConceptosPanel.Codigo).Visible = False
            .Columns(ColumnasDelGrdConceptosPanel.ConceptoPago).Visible = False
            .Columns(ColumnasDelGrdConceptosPanel.Frecuencia).Visible = False
            .Columns(ColumnasDelGrdConceptosPanel.PerteneceA).Visible = False
            .Columns(ColumnasDelGrdConceptosPanel.TipoValor).Visible = False
            .AutoResizeColumns()
        End With

        With grdProfesionalesPanel
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns(ColumnasDelGrdProfesionalesPanel.Id).Visible = False
            .Columns(ColumnasDelGrdProfesionalesPanel.Codigo).Visible = False
            .Columns(ColumnasDelGrdProfesionalesPanel.Direccion).Visible = False
            .Columns(ColumnasDelGrdProfesionalesPanel.Celular).Visible = False
            .AutoResizeColumns()
        End With


    End Sub

    Private Sub LlenarGrdConceptosPanel()
        grdConceptosPanel.Rows.Clear()

        Dim connection As SqlClient.SqlConnection = Nothing
        Dim query_FarmConcep As String
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            Dim dt As New DataTable

            If txtID.Text = "" Then
                query_FarmConcep = "exec spFarmacias_Conceptos_Select_By_IDFarmacia @IDFarmacia = '1'"
            Else
                query_FarmConcep = "exec spFarmacias_Conceptos_Select_By_IDFarmacia @IDFarmacia = " & txtID.Text & ""
            End If

            Dim cmd As New SqlCommand(query_FarmConcep, connection)
            Dim da As New SqlDataAdapter(cmd)
            Dim i As Integer

            da.Fill(dt)

            For i = 0 To dt.Rows.Count - 1
                grdConceptosPanel.Rows.Add(
                    dt.Rows(i)(ColumnasDelGrdConceptosPanel.Id).ToString(),
                    dt.Rows(i)(ColumnasDelGrdConceptosPanel.Codigo).ToString(),
                    dt.Rows(i)(ColumnasDelGrdConceptosPanel.Nombre).ToString(),
                    dt.Rows(i)(ColumnasDelGrdConceptosPanel.Descripcion).ToString(),
                    dt.Rows(i)(ColumnasDelGrdConceptosPanel.ConceptoPago).ToString(),
                    dt.Rows(i)(ColumnasDelGrdConceptosPanel.PerteneceA).ToString(),
                    dt.Rows(i)(ColumnasDelGrdConceptosPanel.TipoValor).ToString(),
                    dt.Rows(i)(ColumnasDelGrdConceptosPanel.Valor).ToString(),
                    dt.Rows(i)(ColumnasDelGrdConceptosPanel.Frecuencia).ToString(),
                    dt.Rows(i)(ColumnasDelGrdConceptosPanel.CampoAplicable).ToString())
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Sub

    Private Sub LlenarGrdProfesionalesPanel()
        grdProfesionalesPanel.Rows.Clear()

        Dim connection As SqlClient.SqlConnection = Nothing
        Dim query_FarmProf As String
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            Dim dt As New DataTable

            If txtID.Text = "" Then
                query_FarmProf = "exec spFarmacias_Profesionales_Select_By_IDFarmacia @IDFarmacia = '1'"
            Else
                query_FarmProf = "exec spFarmacias_Profesionales_Select_By_IDFarmacia @IDFarmacia = " & txtID.Text & ""
            End If

            Dim cmd As New SqlCommand(query_FarmProf, connection)
            Dim da As New SqlDataAdapter(cmd)
            Dim i As Integer

            da.Fill(dt)

            For i = 0 To dt.Rows.Count - 1
                grdProfesionalesPanel.Rows.Add(
                    dt.Rows(i)(ColumnasDelGrdProfesionalesPanel.Id).ToString(),
                    dt.Rows(i)(ColumnasDelGrdProfesionalesPanel.Codigo).ToString(),
                    dt.Rows(i)(ColumnasDelGrdProfesionalesPanel.Nombre).ToString(),
                    dt.Rows(i)(ColumnasDelGrdProfesionalesPanel.Apellido).ToString(),
                    dt.Rows(i)(ColumnasDelGrdProfesionalesPanel.Direccion).ToString(),
                    dt.Rows(i)(ColumnasDelGrdProfesionalesPanel.Celular).ToString(),
                    dt.Rows(i)(ColumnasDelGrdProfesionalesPanel.Email).ToString())
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Sub


    Private Sub EliminarRelacionProfesional_Farmacia()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds_coincidencia As Data.DataSet
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            Dim result As DialogResult = MessageBox.Show($"Está a punto de eliminar el profesional {grdProfesionalesPanel.CurrentRow.Cells(ColumnasDelGrdProfesionalesPanel.Nombre).Value} {grdProfesionalesPanel.CurrentRow.Cells(ColumnasDelGrdProfesionalesPanel.Apellido).Value}
¿Está seguro que desea continuar?",
                                  "Eliminar",
                                  MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                If grdProfesionalesPanel.CurrentRow IsNot Nothing Then
                    ds_coincidencia = SqlHelper.ExecuteDataset(connection, CommandType.Text, $"SELECT idprofesional, idFarmacia FROM Farmacias_Profesionales WHERE idprofesional = {grdProfesionalesPanel.CurrentRow.Cells(ColumnasDelGrdProfesionalesPanel.Id).Value} AND idFarmacia = {txtID.Text}") 'revisar
                    If ds_coincidencia.Tables(0).Rows.Count = 1 Then 'si encuentro esa relacion
                        Dim param_idProfesional As New SqlClient.SqlParameter
                        param_idProfesional.ParameterName = "@idprofesional"
                        param_idProfesional.SqlDbType = SqlDbType.BigInt
                        param_idProfesional.Value = grdProfesionalesPanel.CurrentRow.Cells(ColumnasDelGrdProfesionalesPanel.Id).Value
                        param_idProfesional.Direction = ParameterDirection.InputOutput

                        Dim param_idFarmacia As New SqlClient.SqlParameter
                        param_idFarmacia.ParameterName = "@idFarmacia"
                        param_idFarmacia.SqlDbType = SqlDbType.BigInt
                        param_idFarmacia.Value = txtID.Text
                        param_idFarmacia.Direction = ParameterDirection.Input

                        Dim param_res As New SqlClient.SqlParameter
                        param_res.ParameterName = "@res"
                        param_res.SqlDbType = SqlDbType.Int
                        param_res.Value = DBNull.Value
                        param_res.Direction = ParameterDirection.Output

                        Try
                            'elimino la relacion en la base de datos
                            ds_coincidencia.Dispose()
                            SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spFarmacias_Profesionales_Delete", param_idProfesional, param_idFarmacia, param_res)
                            Dim res = param_res.Value
                            'elimino el item del gridview si antes se eliminó la relacion
                            If res = 1 Then
                                grdProfesionalesPanel.Rows.Remove(grdProfesionalesPanel.CurrentRow)
                            End If
                        Catch ex As Exception
                            Throw ex
                        End Try
                    Else
                        ds_coincidencia.Dispose()

                    End If
                End If
            Else
                Exit Sub
            End If







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

    Private Sub EliminarRelacionConcepto_Farmacia()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds_coincidendia As Data.DataSet
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            Dim result As DialogResult = MessageBox.Show($"Está a punto de eliminar el concepto {grdConceptosPanel.CurrentRow.Cells(ColumnasDelGrdConceptosPanel.Nombre).Value}
¿Está seguro que desea continuar?",
                                  "Eliminar",
                                  MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                If grdConceptosPanel.CurrentRow IsNot Nothing Then
                    ds_coincidendia = SqlHelper.ExecuteDataset(connection, CommandType.Text, $"SELECT idConcepto, idFarmacia FROM Farmacias_Conceptos WHERE idConcepto = {grdConceptosPanel.CurrentRow.Cells(ColumnasDelGrdConceptosPanel.Id).Value} AND idFarmacia = {txtID.Text}")
                    If ds_coincidendia.Tables(0).Rows.Count = 1 Then 'si encuentro esa relacion
                        Dim param_idConcepto As New SqlClient.SqlParameter
                        param_idConcepto.ParameterName = "@idConcepto"
                        param_idConcepto.SqlDbType = SqlDbType.BigInt
                        param_idConcepto.Value = grdConceptosPanel.CurrentRow.Cells(ColumnasDelGrdConceptosPanel.Id).Value
                        param_idConcepto.Direction = ParameterDirection.InputOutput

                        Dim param_idFarmacia As New SqlClient.SqlParameter
                        param_idFarmacia.ParameterName = "@idFarmacia"
                        param_idFarmacia.SqlDbType = SqlDbType.BigInt
                        param_idFarmacia.Value = txtID.Text
                        param_idFarmacia.Direction = ParameterDirection.Input

                        Dim param_res As New SqlClient.SqlParameter
                        param_res.ParameterName = "@res"
                        param_res.SqlDbType = SqlDbType.Int
                        param_res.Value = DBNull.Value
                        param_res.Direction = ParameterDirection.Output

                        Try
                            'elimino la relacion en la base de datos
                            ds_coincidendia.Dispose()
                            SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spFarmacias_Conceptos_Delete", param_idConcepto, param_idFarmacia, param_res)
                            Dim res = param_res.Value
                            'elimino el item del gridview si antes se eliminó la relacion
                            If res = 1 Then
                                grdConceptosPanel.Rows.Remove(grdConceptosPanel.CurrentRow)
                            End If
                        Catch ex As Exception
                            Throw ex
                        End Try
                    Else
                        ds_coincidendia.Dispose()

                    End If
                End If
            Else
                Exit Sub
            End If







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

    Private Sub AgregarRelacionConcepto_Farmacia()

        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds_coincidencia As Data.DataSet
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'ds = SqlHelper.ExecuteDataset(conn_del_form, CommandType.Text, "select NombreEmpresaFactura, ModoPagoPredefinido, CUIT, HOMO, TA, PTOVTA, ISNULL(CorreoContador,''), ISNULL(TicketAcceso,''), ISNULL(Token,''), ISNULL(Sign,'')  from parametros")

        'ds.Dispose()

        Try
            For Each Row As DataGridViewRow In grdConceptosPanel.Rows
                If Row IsNot Nothing Then
                    ds_coincidencia = SqlHelper.ExecuteDataset(connection, CommandType.Text, $"SELECT idConcepto, idFarmacia FROM Farmacias_Conceptos WHERE idConcepto = {Row.Cells(ColumnasDelGrdConceptosPanel.Id).Value} AND idFarmacia = {txtID.Text}")
                    If ds_coincidencia.Tables(0).Rows.Count <> 1 Then
                        Dim param_idConcepto As New SqlClient.SqlParameter
                        param_idConcepto.ParameterName = "@idConcepto"
                        param_idConcepto.SqlDbType = SqlDbType.BigInt
                        param_idConcepto.Value = Row.Cells(ColumnasDelGrdConceptosPanel.Id).Value
                        param_idConcepto.Direction = ParameterDirection.InputOutput

                        Dim param_idFarmacia As New SqlClient.SqlParameter
                        param_idFarmacia.ParameterName = "@idFarmacia"
                        param_idFarmacia.SqlDbType = SqlDbType.BigInt
                        param_idFarmacia.Value = txtID.Text
                        param_idFarmacia.Direction = ParameterDirection.Input

                        Dim param_frecuencia As New SqlClient.SqlParameter
                        param_frecuencia.ParameterName = "@Frecuencia"
                        param_frecuencia.SqlDbType = SqlDbType.VarChar
                        param_frecuencia.Size = 50
                        param_frecuencia.Value = Row.Cells(ColumnasDelGrdConceptosPanel.Frecuencia).Value
                        param_frecuencia.Direction = ParameterDirection.Input

                        Dim param_valor As New SqlClient.SqlParameter
                        param_valor.ParameterName = "@Valor"
                        param_valor.SqlDbType = SqlDbType.Decimal
                        param_valor.Value = Row.Cells(ColumnasDelGrdConceptosPanel.Valor).Value
                        param_valor.Direction = ParameterDirection.Input

                        Try
                            ds_coincidencia.Dispose()
                            SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spFarmacias_Conceptos_Insert", param_idConcepto, param_idFarmacia, param_frecuencia, param_valor)
                        Catch ex As Exception
                            Throw ex
                        End Try
                    Else
                        ds_coincidencia.Dispose()
                        Continue For
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

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try


    End Sub

    Private Sub AgregarRelacionProfesional_Farmacia()

        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds_coincidencia As Data.DataSet
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'ds = SqlHelper.ExecuteDataset(conn_del_form, CommandType.Text, "select NombreEmpresaFactura, ModoPagoPredefinido, CUIT, HOMO, TA, PTOVTA, ISNULL(CorreoContador,''), ISNULL(TicketAcceso,''), ISNULL(Token,''), ISNULL(Sign,'')  from parametros")

        'ds.Dispose()

        Try
            For Each Row As DataGridViewRow In grdProfesionalesPanel.Rows
                If Row IsNot Nothing Then
                    ds_coincidencia = SqlHelper.ExecuteDataset(connection, CommandType.Text, $"SELECT idProfesional, idFarmacia FROM Farmacias_Profesionales WHERE idProfesional = {Row.Cells(ColumnasDelGrdProfesionalesPanel.Id).Value} AND idFarmacia = {txtID.Text}")
                    If ds_coincidencia.Tables(0).Rows.Count <> 1 Then
                        Dim param_idProfesional As New SqlClient.SqlParameter
                        param_idProfesional.ParameterName = "@idprofesional"
                        param_idProfesional.SqlDbType = SqlDbType.BigInt
                        param_idProfesional.Value = Row.Cells(ColumnasDelGrdProfesionalesPanel.Id).Value
                        param_idProfesional.Direction = ParameterDirection.InputOutput

                        Dim param_idFarmacia As New SqlClient.SqlParameter
                        param_idFarmacia.ParameterName = "@idFarmacia"
                        param_idFarmacia.SqlDbType = SqlDbType.BigInt
                        param_idFarmacia.Value = txtID.Text
                        param_idFarmacia.Direction = ParameterDirection.Input

                        Try
                            ds_coincidencia.Dispose()
                            SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spFarmacias_Profesionales_Insert", param_idProfesional, param_idFarmacia)
                        Catch ex As Exception
                            Throw ex
                        End Try
                    Else
                        ds_coincidencia.Dispose()
                        Continue For
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

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try


    End Sub

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
        txtFarmacia.Tag = "7"
        txtCuit.Tag = "8"
        txtRazonSocial.Tag = "9"
        cmbPreferenciaPago.Tag = "10"
        txtCBU.Tag = "11"
        txtDomicilio.Tag = "12"
        txtTelefono.Tag = "13"
        txtEmail.Tag = "14"
        txtTipoContribuyente.Tag = "15"
        cmbEstado.Text = "16"
        txtMotivoBaja.Text = "17"
        cmbProvincia.Tag = "18"
        cmbLocalidad.Tag = "19"

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

    Private Overloads Sub grd_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles grd.CurrentCellChanged 'comentar
        LlenarGrdConceptosPanel()
        LlenarGrdProfesionalesPanel()
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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Select Case SuperTabControl1.SelectedPanel.Name
            Case "SuperTabControlPanel1" 'Panel Conceptos
                Dim cargarConcepto As New frmSelectConcepto
                cargarConcepto.ShowDialog()
            Case "SuperTabControlPanel2" 'Panel Profesionales
                Dim cargarProfesional As New frmSelectProfesional
                cargarProfesional.ShowDialog()
        End Select

    End Sub

    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged
        If grd.CurrentRow IsNot Nothing Then
            grdCodigos.Rows(Codigos.FACAF).Cells(1).Value = grd.CurrentRow.Cells(GridItemsCols.CodFACAF).Value
            grdCodigos.Rows(Codigos.PAMI).Cells(1).Value = grd.CurrentRow.Cells(GridItemsCols.CodPAMI).Value
            grdCodigos.Rows(Codigos.FARMALINK).Cells(1).Value = grd.CurrentRow.Cells(GridItemsCols.CodFarmaLink).Value
            grdCodigos.Rows(Codigos.FARMAPLUS).Cells(1).Value = grd.CurrentRow.Cells(GridItemsCols.CodFarmaPlus).Value
            grdCodigos.Rows(Codigos.CSF).Cells(1).Value = grd.CurrentRow.Cells(GridItemsCols.CodCSF).Value
        End If
    End Sub

    Private Sub btnEliminarPanel_Click(sender As Object, e As EventArgs) Handles btnEliminarPanel.Click
        ''hacer un select case
        Select Case SuperTabControl1.SelectedPanel.Name
            Case "SuperTabControlPanel1" 'Panel Conceptos
                If grdConceptosPanel.CurrentRow IsNot Nothing Then
                    EliminarRelacionConcepto_Farmacia()
                End If
            Case "SuperTabControlPanel2" 'Panel Profesionales
                If grdProfesionalesPanel.CurrentRow IsNot Nothing Then
                    EliminarRelacionProfesional_Farmacia()
                End If
        End Select
    End Sub


#End Region

End Class