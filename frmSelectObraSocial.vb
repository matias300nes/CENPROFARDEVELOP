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

Public Class frmSelectObraSocial

    Dim dtConceptos_Created As Boolean
    Dim count As Integer = 0
    Dim Permitir As Boolean
    Enum ColumnasDelGrdObrasSociales
        IdOS = 0
        ObraSocial = 1
        Mandataria = 2
        Grupo = 3
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
    End Sub

    Private Sub btnListo_Click(sender As Object, e As EventArgs) Handles btnListo.Click

        If ReglasNegocio() Then

            If grdObrasSociales.CurrentRow IsNot Nothing Then
                ''Llenado de grdConceptosPanel
                With grdObrasSociales.CurrentRow

                    Dim idObraSocial = .Cells(ColumnasDelGrdObrasSociales.IdOS).Value
                    Dim mandataria = frmGrupos.cmbMandataria.SelectedValue
                    Dim grupo = frmGrupos.cmbGrupo.SelectedValue
                    'deberia insertar en tabla grupos_os el idOS y el idGrupo
                    InsertarGrupos_OS(idObraSocial, grupo)

                    'frmFarmacias_Conceptos.grdConceptosPanel.Rows.Add(id)
                End With


                Me.Dispose()
                Me.Close()

            Else
                MsgBox("Seleccione una Obra Social para poder continuar.")
            End If

        End If



    End Sub

    Private Sub InsertarGrupos_OS(ByVal idOS As Long, ByVal idGrupo As Long)

        Dim connection As SqlClient.SqlConnection = Nothing
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
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

                Try
                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spGrupos_OS_Insert", param_idGrupo, param_idOS)
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



    'Private Sub grdPresentaciones_SelectionChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grdPresentaciones.SelectionChanged
    '    Dim connection As SqlClient.SqlConnection = Nothing
    '    Dim ds As Data.DataSet

    '    Try
    '        connection = SqlHelper.GetConnection(ConnStringSEI)
    '    Catch ex As Exception
    '        MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Sub
    '    End Try

    '    Try

    '        ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, " Select distinct [estado] As Estado from Presentaciones where estado = 'PRESENTADO' or estado = 'PAGO PARCIAL'")
    '        ds.Dispose()

    '        With Me.cmbEstado
    '            .DataSource = ds.Tables(0).DefaultView
    '            .DisplayMember = "estado"
    '            '.ValueMember = "ID"
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

    '        MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
    '          + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
    '          "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        If Not connection Is Nothing Then
    '            CType(connection, IDisposable).Dispose()
    '        End If
    '    End Try
    'End Sub
End Class