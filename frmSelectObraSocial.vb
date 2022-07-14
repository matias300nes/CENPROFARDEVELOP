﻿Imports Microsoft.ApplicationBlocks.Data
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

Public Class frmSelectObraSocial

    Dim dtConceptos_Created As Boolean
    Dim count As Integer = 0
    Dim Permitir As Boolean
    Enum ColumnasDelGrdObrasSociales
        IdOS = 0
        ObraSocial = 1
        Mandataria = 2
        Grupo = 3
        IdGrupo = 4
    End Enum

    Private Sub asignarTags()
        'txtValor.Tag = "7"
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
            Dim Sql = $"exec spObrasSociales_Select_All_By_IDMandataria @IDMandataria = {frmGrupos.cmbMandataria.SelectedValue}"

            Dim cmd As New SqlCommand(Sql, connection)
            Dim da As New SqlDataAdapter(cmd)

            da.Fill(dtObrasSociales)

            grdObrasSociales.DataSource = dtObrasSociales
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

        With grdObrasSociales
            .Columns(ColumnasDelGrdObrasSociales.IdOS).Visible = False
            .Columns(ColumnasDelGrdObrasSociales.IdGrupo).Visible = False
            .AutoResizeColumns()
        End With
    End Sub

    Private Sub btnListo_Click(sender As Object, e As EventArgs) Handles btnAñadir.Click
        Dim Res As Integer

        If ReglasNegocio() Then

            If grdObrasSociales.CurrentRow IsNot Nothing Then
                ''Llenado de grdConceptosPanel
                With grdObrasSociales.CurrentRow

                    Dim idObraSocial = .Cells(ColumnasDelGrdObrasSociales.IdOS).Value
                    Dim mandataria = frmGrupos.cmbMandataria.SelectedValue
                    Dim grupo = frmGrupos.cmbGrupo.SelectedValue
                    'deberia insertar en tabla grupos_os el idOS y el idGrupo
                    Res = InsertarGrupos_OS(idObraSocial, grupo)
                    Select Case Res
                        Case -2
                            MsgBox("El registro ya existe.", MsgBoxStyle.Information, "Atención")
                        Case -1
                            MsgBox("No se pudo borrar el registro.", MsgBoxStyle.Information, "Atención")
                        Case 0
                            MsgBox("El registro se insertó de forma correcta.", MsgBoxStyle.Information, "Atención")
                        Case 1
                            MsgBox("El registro se insertó de forma correcta.", MsgBoxStyle.Information, "Atención")
                        Case Else
                            'MsgBox("Se ha borrado el registro.", MsgBoxStyle.Information, "Atención")
                            LlenarGrilla()
                    End Select



                    'frmFarmacias_Conceptos.grdConceptosPanel.Rows.Add(id)
                End With


                'Me.Dispose()
                'Me.Close()
                LlenarGrilla()

            Else
                MsgBox("Seleccione una Obra Social para poder continuar.")
            End If

        End If



    End Sub

    Private Function InsertarGrupos_OS(ByVal idOS As Long, ByVal idGrupo As Long) As Integer

        Dim connection As SqlClient.SqlConnection = Nothing
        Dim Res As Integer
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End Try


        Try

            If idOS > -1 And idGrupo > -1 Then

                Dim param_idOS As New SqlClient.SqlParameter
                param_idOS.ParameterName = "@idObraSocial"
                param_idOS.SqlDbType = SqlDbType.BigInt
                param_idOS.Value = idOS
                param_idOS.Direction = ParameterDirection.InputOutput

                Dim param_idGrupo As New SqlClient.SqlParameter
                param_idGrupo.ParameterName = "@idGrupo"
                param_idGrupo.SqlDbType = SqlDbType.BigInt
                param_idGrupo.Value = idGrupo
                param_idGrupo.Direction = ParameterDirection.Input

                Dim param_useradd As New SqlClient.SqlParameter
                param_useradd.ParameterName = "@useradd"
                param_useradd.SqlDbType = SqlDbType.BigInt
                param_useradd.Value = UserID
                param_useradd.Direction = ParameterDirection.Input

                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.InputOutput

                Try
                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spGrupos_OS_Insert", param_idGrupo, param_idOS, param_useradd, param_res)
                    Res = param_res.Value
                    Return Res
                Catch ex As Exception
                    Throw ex
                End Try
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
          + Environment.NewLine + "Si el problema persiste contáctese con Kaizen Software a través del correo soporte@kaizensoftware.com.ar", errMessage),
          "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try


    End Function


    Private Sub chkAgrupar_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub CargarCajas()
        If Not (grdObrasSociales.CurrentRow Is Nothing) Then
            Util.GrillaATextBox(Me.Controls, grdObrasSociales)
        End If
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs)
        LlenarGrilla()
    End Sub

    Private Sub grdConceptos_CurrentCellChanged(sender As Object, e As EventArgs) Handles grdObrasSociales.CurrentCellChanged
        If Permitir Then
            CargarCajas()
        End If
        'InformarCantidadRegistros()
        'RaiseEvent ev_CellChanged(sender, e) 'por ahora lo usa el formulario entryline
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click


        Dim res As Integer
        If MessageBox.Show($"Está seguro que desea eliminar la obra social {grdObrasSociales.CurrentRow.Cells(1).Value} del grupo {grdObrasSociales.CurrentRow.Cells(3).Value}?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Try

            MsgBox("Eliminando el registro...", MsgBoxStyle.Information, "Atención")

                res = EliminarRegistro()
                Select Case res
                    Case -2
                        MsgBox("El registro no existe.", MsgBoxStyle.Information, "Atención")
                    Case -1
                        MsgBox("No se pudo borrar el registro.", MsgBoxStyle.Information, "Atención")
                    Case 0
                        MsgBox("No se pudo borrar el registro.", MsgBoxStyle.Information, "Atención")
                    Case Else
                    MsgBox("Se ha borrado el registro.", MsgBoxStyle.Information, "Atención")
                    LlenarGrilla()
            End Select


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

                Dim param_idObraSocial As New SqlClient.SqlParameter
                param_idObraSocial.ParameterName = "@idobrasocial"
                param_idObraSocial.SqlDbType = SqlDbType.BigInt
                param_idObraSocial.Value = grdObrasSociales.CurrentRow.Cells(0).Value
                param_idObraSocial.Direction = ParameterDirection.Input

                Dim param_idGrupo As New SqlClient.SqlParameter
                param_idGrupo.ParameterName = "@idgrupo"
                param_idGrupo.SqlDbType = SqlDbType.BigInt
                param_idGrupo.Value = grdObrasSociales.CurrentRow.Cells(ColumnasDelGrdObrasSociales.IdGrupo).Value
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
              + Environment.NewLine + "Si el problema persiste contáctese con Kaizen Software a través del correo soporte@kaizensoftware.com.ar", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Function

    Private Sub btnAñadir_Click(sender As Object, e As EventArgs) Handles btnAñadir.Click

    End Sub
End Class