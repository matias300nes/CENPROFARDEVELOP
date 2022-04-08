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

Public Class frmNuevoGrupo

    Dim dtConceptos_Created As Boolean
    Dim count As Integer = 0
    Dim Permitir As Boolean
    Dim tran As SqlClient.SqlTransaction

    Enum ColumnasGrupos
        ID = 0
        IdMandataria = 1
        Mandataria = 2
        Grupo = 3
    End Enum

    Private Sub asignarTags()
        'txtValor.Tag = "7"
    End Sub

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

    Protected Function ReglasNegocio() As Boolean
        Dim msg As String
        ReglasNegocio = False

        msg = CamposObligatorios(Me.TableLayoutPanel1.Controls)

        If msg <> "" Then
            Beep()
            MsgBox("Falta completar el campo " & msg)
            Exit Function
        End If

        ReglasNegocio = True
    End Function

    Private Sub LlenarGrilla()
        Dim dtObrasSociales As New DataTable
        Dim connection = Nothing
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
            ''Detalle de liquidacion
            Dim Sql = $"exec spGrupos_Select_All @Eliminado = 0, @IDMandataria = {frmGrupos.cmbMandataria.SelectedValue}"

            Dim cmd As New SqlCommand(Sql, connection)
            Dim da As New SqlDataAdapter(cmd)

            da.Fill(dtObrasSociales)

            grdGruposMandataria.DataSource = dtObrasSociales
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Sub

    Private Sub frmNuevaLiquidacion_Load(sender As Object, e As EventArgs) Handles Me.Load
        asignarTags()
        LlenarGrilla()
        Permitir = True
        CargarCajas()
        cmbMandataria.SelectedValue = frmGrupos.cmbMandataria.SelectedValue
        cmbMandataria.Text = frmGrupos.cmbMandataria.Text

        With grdGruposMandataria
            .Columns(ColumnasGrupos.ID).Visible = False
            .Columns(ColumnasGrupos.IdMandataria).Visible = False
            .AutoResizeColumns()
        End With

    End Sub

    Private Sub btnListo_Click(sender As Object, e As EventArgs) Handles btnListo.Click

        If ReglasNegocio() Then

            Dim idMandataria = frmGrupos.cmbMandataria.SelectedValue
            Dim grupo = CInt(txtGrupo.Text)
            'deberia insertar en tabla grupos_os el idOS y el idGrupo
            If controlarMandatariaGrupo(idMandataria, grupo) Then
                MsgBox("No puede cargar una relación ya existente, verifique.", MsgBoxStyle.Information, "Control de Errores")
                Exit Sub
            Else
                InsertarGrupo(idMandataria, grupo)
                MsgBox("¡Relación cargada con éxito!", MsgBoxStyle.MsgBoxRight, "Control de Errores")
                Me.Dispose()
                Me.Close()
            End If

        End If



    End Sub

    Private Function controlarMandatariaGrupo(ByVal idmandataia As Long, ByVal grupo As Long) As Boolean
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, $"SELECT IdMandataria, Nombre FROM Grupos WHERE IDMandataria = {idmandataia} AND Nombre = {grupo} AND eliminado = 0")
            ds.Dispose()

            If ds.Tables(0).Rows.Count = 1 Then
                Return 1
            Else
                Return 0
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
    End Function

    Private Sub InsertarGrupo(ByVal idMandataria As Long, ByVal Grupo As Long)

        Dim connection As SqlClient.SqlConnection = Nothing
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            If idMandataria > -0 And Grupo > -0 Then

                Dim param_idMandataria As New SqlClient.SqlParameter
                param_idMandataria.ParameterName = "@idMandataria"
                param_idMandataria.SqlDbType = SqlDbType.BigInt
                param_idMandataria.Value = idMandataria
                param_idMandataria.Direction = ParameterDirection.Input

                Dim param_grupo As New SqlClient.SqlParameter
                param_grupo.ParameterName = "@nombre"
                param_grupo.SqlDbType = SqlDbType.Int
                param_grupo.Value = Grupo
                param_grupo.Direction = ParameterDirection.Input

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

                ''antes de hacer el insert controlar que no se haya cargado antes 
                ''la misma mandataria y el mismo grupo

                Try
                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spGrupos_Insert", param_idMandataria, param_grupo, param_useradd, param_res)
                Catch ex As Exception
                    Throw ex
                End Try

                LlenarGrilla()
            Else
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


    Private Sub chkAgrupar_CheckedChanged(sender As Object, e As EventArgs)

    End Sub


    Protected Sub CargarCajas()
        If Not (grdGruposMandataria.CurrentRow Is Nothing) Then
            Util.GrillaATextBox(Me.Controls, grdGruposMandataria)
        End If
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs)
        LlenarGrilla()
    End Sub

    Private Sub grdConceptos_CurrentCellChanged(sender As Object, e As EventArgs) Handles grdGruposMandataria.CurrentCellChanged
        If Permitir Then
            CargarCajas()
        End If
        'InformarCantidadRegistros()
        'RaiseEvent ev_CellChanged(sender, e) 'por ahora lo usa el formulario entryline
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim ds_existenOS As Data.DataSet
        Dim ds_existenPeriodPresen As Data.DataSet
        Dim res As Integer
        Dim i As Integer
        Dim connection As SqlClient.SqlConnection = Nothing
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        If Abrir_Tran(connection) = False Then
            MessageBox.Show("No se pudo abrir una transaccion", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            'consulto si el grupo tiene os cargadas
            ds_existenOS = SqlHelper.ExecuteDataset(ConnStringSEI, CommandType.Text, $"SELECT idobrasocial, idgrupo  FROM grupos_os WHERE idgrupo = {grdGruposMandataria.CurrentRow.Cells(0).Value}")
            ds_existenOS.Dispose()

            If ds_existenOS.Tables(0).Rows.Count > 0 Then 'existen os en grupos
                'controlo que el grupo no se haya usado para cargar un periodopresentacion
                ds_existenPeriodPresen = SqlHelper.ExecuteDataset(ConnStringSEI, CommandType.Text, $"SELECT idgrupo, idmandataria FROM periodopresentaciones WHERE idgrupo = {grdGruposMandataria.CurrentRow.Cells(0).Value} AND idmandataria = {grdGruposMandataria.CurrentRow.Cells(1).Value}")
                ds_existenPeriodPresen.Dispose()

                If ds_existenPeriodPresen.Tables(0).Rows.Count > 0 Then 'existen periodopresentacion para ese grupo -> no puedo eliminar
                    MsgBox("No se puede eliminar un grupo que tenga un Periodo Presentacion ya asignado. Por favor verifique.", MsgBoxStyle.Information, "Atención")
                    Exit Sub
                Else 'no existen periodopresentacion -> puedo eliminar el grupo
                    MsgBox("Eliminando grupo...", MsgBoxStyle.Information, "Atención")
                    res = EliminarRegistro()
                    Select Case res
                        Case -2
                            Cancelar_Tran()
                            MsgBox("El grupo no existe.", MsgBoxStyle.Information, "Atención")
                        Case -1
                            Cancelar_Tran()
                            MsgBox("No se pudo borrar el grupo.", MsgBoxStyle.Information, "Atención")
                        Case 0
                            Cancelar_Tran()
                            MsgBox("No se pudo borrar el grupo.", MsgBoxStyle.Information, "Atención")
                        Case Else
                            MsgBox("Se ha borrado el grupo.", MsgBoxStyle.Information, "Atención")
                            MsgBox("Eliminando las obras sociales...", MsgBoxStyle.Information, "Atención")
                            For i = 0 To ds_existenOS.Tables(0).Rows.Count - 1
                                res = EliminarOSdeGrupo(ds_existenOS.Tables(0).Rows(i).Item(0), ds_existenOS.Tables(0).Rows(i).Item(1))
                                Select Case res
                                    Case -2
                                        Cancelar_Tran()
                                        MsgBox("La obra social no existe.", MsgBoxStyle.Information, "Atención")
                                    Case -1
                                        Cancelar_Tran()
                                        MsgBox("No se pudo borrar la obra social.", MsgBoxStyle.Information, "Atención")
                                    Case 0
                                        Cancelar_Tran()
                                        MsgBox("No se pudo borrar la obra social.", MsgBoxStyle.Information, "Atención")
                                    Case Else
                                End Select
                            Next
                            If res = 1 Then
                                MsgBox("Se ha borrado la obra social.", MsgBoxStyle.Information, "Atención")
                                LlenarGrilla()
                                Me.Close()
                            Else
                                Cancelar_Tran()
                                MsgBox("No se pudo borrar la obra social.", MsgBoxStyle.Information, "Atención")
                            End If

                    End Select
                End If

            Else ' no existen os en grupo -> puedo eliminar el grupo ya que no esta cargada ninguna presentacion
                MsgBox("Eliminando grupo...", MsgBoxStyle.Information, "Atención")
                res = EliminarRegistro()
                Select Case res
                    Case -2
                        Cancelar_Tran()
                        MsgBox("El grupo no existe.", MsgBoxStyle.Information, "Atención")
                    Case -1
                        Cancelar_Tran()
                        MsgBox("No se pudo borrar el grupo.", MsgBoxStyle.Information, "Atención")
                    Case 0
                        Cancelar_Tran()
                        MsgBox("No se pudo borrar el grupo.", MsgBoxStyle.Information, "Atención")
                    Case Else
                        MsgBox("Se ha borrado el grupo.", MsgBoxStyle.Information, "Atención")
                        LlenarGrilla()

                        Me.Close()
                End Select
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
        End Try
    End Sub

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
                param_id.Value = CType(grdGruposMandataria.CurrentRow.Cells(0).Value, Long)
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

                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spGrupos_Delete", param_id, param_userdel, param_res)
                    res = param_res.Value
                    LlenarGrilla()
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

    Private Function EliminarOSdeGrupo(ByVal idObraSocial As Long, ByVal idGrupo As Long) As Integer

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

                Dim param_idObraSocial As New SqlClient.SqlParameter
                param_idObraSocial.ParameterName = "@idobrasocial"
                param_idObraSocial.SqlDbType = SqlDbType.BigInt
                param_idObraSocial.Value = idObraSocial
                param_idObraSocial.Direction = ParameterDirection.Input

                Dim param_idGrupo As New SqlClient.SqlParameter
                param_idGrupo.ParameterName = "@idgrupo"
                param_idGrupo.SqlDbType = SqlDbType.BigInt
                param_idGrupo.Value = idGrupo
                param_idGrupo.Direction = ParameterDirection.Input

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

                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spGrupos_OS_Delete", param_idObraSocial, param_idGrupo, param_userdel, param_res)
                    res = param_res.Value
                    EliminarOSdeGrupo = res

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

End Class