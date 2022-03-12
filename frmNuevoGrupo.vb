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
    Enum ColumnasDelGrdConceptos
        Id = 0
        Codigo = 1
        Nombre = 2
        Descripcion = 3
        ConceptoPago = 4
        PerteneceA = 5
        TipoDeValor = 6
        Valor = 7
        CampoAplicable = 8
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
            Dim Sql = $"exec spGrupos_Select_All @IDMandataria = {frmGrupos.cmbMandataria.SelectedValue}"

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

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, $"SELECT IdMandataria, Nombre FROM Grupos WHERE IDMandataria = {idmandataia} AND Nombre = {grupo}")
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

                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.InputOutput

                ''antes de hacer el insert controlar que no se haya cargado antes 
                ''la misma mandataria y el mismo grupo

                Try
                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spGrupos_Insert", param_idMandataria, param_grupo, param_res)
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