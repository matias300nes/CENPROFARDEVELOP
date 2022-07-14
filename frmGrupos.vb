Imports Microsoft.ApplicationBlocks.Data
Imports Utiles
Imports Utiles.Util
Imports System.Data.SqlClient
Imports ReportesNet


Public Class frmGrupos
    Dim cmbLlenado As Boolean = False
    Dim bolpoliticas As Boolean
    Dim Sql As String
    Dim dtGrupos_Os As New DataTable
    Dim grdFilled As Boolean = False
    Dim ds As DataSet
    Dim dv As DataView

    Enum columnasDelGrdGrupos_OS
        IdMandataria = 0
        Mandataria = 1
        ObraSocial = 2
        Grupo = 3
    End Enum

#Region "Procedimientos Formularios"

    Private Sub frmConceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AsignarPermisos(UserID, Me.Name, ALTA, MODIFICA, BAJA, BAJA_FISICA)
        configurarform()
        LlenarCmbMandatarias()

        If cmbGrupo.Text = "" Then
            btnAgregarOS.Enabled = False
        Else
            btnAgregarOS.Enabled = True
        End If

        asignarTags()


        If cmbMandataria.Items.Count > 0 Then
            cmbMandataria.SelectedIndex = 0
        End If





        cmbMandataria_SelectedValueChanged(sender, e)
        grdGrupos_Os.DataSource = Nothing 'comentar
        dtGrupos_Os.Clear() 'comentar
        LlenarGrilla()
        GrillaStyles()
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

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles btnEliminar.Click
        'Dim res As Integer
        'Dim ds_Almacen As Data.DataSet
        'If MessageBox.Show("Está seguro que desea eliminar el Depósito seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
        '    Exit Sub
        'End If

        'Try
        '    ds_Almacen = SqlHelper.ExecuteDataset(ConnStringSEI, CommandType.Text, "SELECT  IDAlmacen FROM Materiales where IDAlmacen = '" & txtID.Text & "'")
        '    ds_Almacen.Dispose()

        '    If ds_Almacen.Tables(0).Rows.Count > 0 Then
        '        MsgBox("No se puede eliminar un Depósito que esté asociado a un material. Por favor verifique.", MsgBoxStyle.Information, "Atención")
        '        Exit Sub
        '    End If

        'Catch ex As Exception
        '    Dim errMessage As String = ""
        '    Dim tempException As Exception = ex

        '    While (Not tempException Is Nothing)
        '        errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
        '        tempException = tempException.InnerException
        '    End While

        '    MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
        '      + Environment.NewLine + "Si el problema persiste contáctese con Kaizen Software a través del correo soporte@kaizensoftware.com.ar", errMessage),
        '      "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        ''If BAJA_FISICA Then
        'Util.MsgStatus(Status1, "Eliminando el registro...", My.Resources.Resources.indicator_white)
        'res = EliminarRegistro()
        'Select Case res
        '    Case -2
        '        Util.MsgStatus(Status1, "El registro no existe.", My.Resources.stop_error.ToBitmap)
        '    Case -1
        '        Util.MsgStatus(Status1, "No se pudo borrar el registro.", My.Resources.stop_error.ToBitmap)
        '    Case 0
        '        Util.MsgStatus(Status1, "No se pudo borrar el registro.", My.Resources.stop_error.ToBitmap)
        '    Case Else
        '        Util.MsgStatus(Status1, "Se ha borrado el registro.", My.Resources.ok.ToBitmap)
        '        If Me.grd.RowCount = 0 Then
        '            bolModo = True
        '            PrepararBotones()
        '            Util.LimpiarTextBox(Me.Controls)
        '        End If
        'End Select
        ''Else
        '' Util.MsgStatus(Status1, "No tiene permiso para eliminar registros.", My.Resources.stop_error.ToBitmap)
        ''End If
    End Sub

#End Region

#Region "Procedimientos"

    Private Sub configurarform()

        'Me.grdGrupos_Os.Location = New Size(GroupPanel1.Location.X, GroupPanel1.Location.Y + GroupPanel1.Size.Height + 7)
        ''Me.Size = New Size(Me.Size.Width, 500)
        'Me.Size = New Size(Me.Size.Width, (Screen.PrimaryScreen.WorkingArea.Height - 65))
        'Dim p As New Size(GroupPanel1.Size.Width, Me.Size.Height - 7 - GroupPanel1.Size.Height - GroupPanel1.Location.Y - 65)
        'Me.grdGrupos_Os.Size = New Size(p)

        'Me.Top = 0
        'Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2
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
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, $"SELECT Id, Nombre FROM Grupos WHERE IdMandataria = {cmbMandataria.SelectedValue} AND eliminado = 0")
            ds.Dispose()

            With cmbGrupo
                .DataSource = ds.Tables(0).DefaultView
                .DisplayMember = "Nombre"
                .ValueMember = "Id"
                '.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                '.AutoCompleteSource = AutoCompleteSource.ListItems
                '.SelectedIndex = "ID"
            End With

        Catch ex As Exception

        End Try
        cmbLlenado = True
    End Sub


#End Region

#Region "Funciones"

    Protected Sub GetDataset()
        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, Sql)

            ds.Dispose()

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con Kaizen Software a través del correo soporte@kaizensoftware.com.ar", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Protected Sub LlenarGrilla()
        Dim o(1) As String
        If cmbMandataria.SelectedValue IsNot Nothing Then
            Sql = $"exec spGrupos_GruposOS_Select_All_By_IDMandataria @idmandataria = {cmbMandataria.SelectedValue}"
            'GetDataset()

            Dim connection = Nothing
            Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
                ''Detalle de liquidacion
                'Dim Sql = $"exec spObrasSociales_Select_All_By_IDMandataria @IDMandataria = {frmGrupos.cmbMandataria.SelectedValue}"

                Dim cmd As New SqlCommand(Sql, connection)
                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dtGrupos_Os)
                If dtGrupos_Os.Rows.Count > 0 Then
                    dv = New DataView(dtGrupos_Os)
                    dv.RowFilter = $"[Grupo] = {cmbGrupo.Text}"
                    grdGrupos_Os.DataSource = dv
                    'grdGrupos_Os.DataSource = dtGrupos_Os
                Else
                    grdGrupos_Os.DataSource = Nothing
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If Not connection Is Nothing Then
                    CType(connection, IDisposable).Dispose()
                End If
            End Try
        End If

        With grdGrupos_Os
            .VirtualMode = False
            .AllowUserToAddRows = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine
            .RowsDefaultCellStyle.BackColor = Color.White
            .AllowUserToOrderColumns = False
            '.SelectionMode = DataGridViewSelectionMode.CellSelect
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoResizeColumns()
        End With

        With grdGrupos_Os.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Black  'Color.BlueViolet
            .ForeColor = Color.White
            .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        End With

        grdGrupos_Os.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)

        grdFilled = True
    End Sub

    Protected Sub GrillaStyles()

        If grdGrupos_Os.RowCount > 0 Then
            grdGrupos_Os.Columns(columnasDelGrdGrupos_OS.IdMandataria).Visible = False
            grdGrupos_Os.Columns(columnasDelGrdGrupos_OS.Mandataria).Visible = False
            grdGrupos_Os.AutoResizeColumns()
        End If


    End Sub

    Private Function EliminarRegistro() As Integer

        'Dim connection As SqlClient.SqlConnection = Nothing
        'Dim res As Integer = 0


        'Try
        '    Try
        '        connection = SqlHelper.GetConnection(ConnStringSEI)
        '    Catch ex As Exception
        '        MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Exit Function
        '    End Try


        '    Try

        '        Dim param_id As New SqlClient.SqlParameter("@id", SqlDbType.BigInt, ParameterDirection.Input)
        '        param_id.Value = CType(txtID.Text, Long)
        '        param_id.Direction = ParameterDirection.Input

        '        Dim param_userdel As New SqlClient.SqlParameter
        '        param_userdel.ParameterName = "@userdel"
        '        param_userdel.SqlDbType = SqlDbType.Int
        '        param_userdel.Value = UserID
        '        param_userdel.Direction = ParameterDirection.Input

        '        Dim param_res As New SqlClient.SqlParameter
        '        param_res.ParameterName = "@res"
        '        param_res.SqlDbType = SqlDbType.Int
        '        param_res.Value = DBNull.Value
        '        param_res.Direction = ParameterDirection.Output

        '        Try

        '            SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spConceptos_Delete", param_id, param_userdel, param_res)
        '            res = param_res.Value

        '            If res > 0 Then Util.BorrarGrilla(grd)

        '            EliminarRegistro = res

        '        Catch ex As Exception
        '            '' 


        '            Throw ex
        '        End Try
        '    Finally
        '        ''
        '    End Try
        'Catch ex As Exception
        '    Dim errMessage As String = ""
        '    Dim tempException As Exception = ex

        '    While (Not tempException Is Nothing)
        '        errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
        '        tempException = tempException.InnerException
        '    End While

        '    MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
        '      + Environment.NewLine + "Si el problema persiste contáctese con Kaizen Software a través del correo soporte@kaizensoftware.com.ar", errMessage),
        '      "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'Finally
        '    If Not connection Is Nothing Then
        '        CType(connection, IDisposable).Dispose()
        '    End If
        'End Try
    End Function

    Private Sub btnAgregarOS_Click(sender As Object, e As EventArgs) Handles btnAgregarOS.Click
        Dim cargarObraSocial As New frmSelectObraSocial
        cargarObraSocial.ShowDialog()
        cmbMandataria_SelectedValueChanged(sender, e)
        grdGrupos_Os.DataSource = Nothing 'comentar
        dtGrupos_Os.Clear() 'comentar
        LlenarGrilla()
        GrillaStyles()
    End Sub

    Private Sub LlenarCmbMandatarias()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, $" SELECT ID, NOMBRE FROM Mandatarias WHERE ELIMINADO = 0")
            ds.Dispose()

            With cmbMandataria
                .DataSource = ds.Tables(0).DefaultView
                .DisplayMember = "NOMBRE"
                .ValueMember = "ID"
                '.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                '.AutoCompleteSource = AutoCompleteSource.ListItems
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
              + Environment.NewLine + "Si el problema persiste contáctese con Kaizen Software a través del correo soporte@kaizensoftware.com.ar", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        cmbMandataria_SelectedValueChanged(sender, e)
        LlenarCmbGrupos()
    End Sub

    Private Sub cmbMandataria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMandataria.SelectedValueChanged
        If cmbLlenado = True Then
            cmbGrupo.Text = ""
            LlenarCmbGrupos()

            If cmbGrupo.Text = "" Then
                btnAgregarOS.Enabled = False
            Else
                btnAgregarOS.Enabled = True
            End If

            If cmbMandataria.SelectedValue IsNot Nothing Then
                grdGrupos_Os.DataSource = Nothing 'comentar
                dtGrupos_Os.Clear() 'comentar
                Sql = $"exec spGrupos_GruposOS_Select_All_By_IDMandataria @idmandataria = {cmbMandataria.SelectedValue}"
                LlenarGrilla()
                GrillaStyles()
            End If
        End If
    End Sub

    Private Sub cmbGrupo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbGrupo.SelectedValueChanged
        If cmbGrupo.Text = "" Then
            btnAgregarOS.Enabled = False
        Else
            btnAgregarOS.Enabled = True
        End If

        If grdFilled = True Then
            dv.RowFilter = $"[Grupo] = {cmbGrupo.Text}"

            grdGrupos_Os.DataSource = dv
        End If

    End Sub

#End Region


End Class