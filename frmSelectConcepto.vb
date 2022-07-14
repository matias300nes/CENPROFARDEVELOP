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

Public Class frmSelectConcepto

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
        txtValor.Tag = "7"
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
        Dim dtConceptos As New DataTable
        Dim connection = Nothing
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
            ''Detalle de liquidacion
            Dim Sql = $"exec spConceptos_Select_All @eliminado = 0"

            Dim cmd As New SqlCommand(Sql, connection)
            Dim da As New SqlDataAdapter(cmd)

            da.Fill(dtConceptos)

            grdConceptos.DataSource = dtConceptos
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Sub

    Private Sub LlenarCmbProfesionales()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, $" SELECT fp.idprofesional AS ID, p.nombre+' '+p.Apellido  AS Profesional
                                                                            FROM Farmacias_Profesionales fp
                                                                            JOIN Profesionales p 
                                                                            ON p.Id = fp.idProfesional
                                                                            WHERE fp.idFarmacia = {frmFarmacias_Conceptos.txtID.Text}")
            ds.Dispose()

            With cmbProfesionales
                .DataSource = ds.Tables(0).DefaultView
                .DisplayMember = "Profesional"
                .ValueMember = "ID"
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
    End Sub

    Private Sub frmNuevaLiquidacion_Load(sender As Object, e As EventArgs) Handles Me.Load
        asignarTags()
        LlenarGrilla()
        LlenarCmbProfesionales()
        Permitir = True
        CargarCajas()
        cmbFrecuencia.SelectedIndex = 0

        cmbProfesionales.Visible = False
        lblProfesional.Visible = False

        With grdConceptos
            .Columns(ColumnasDelGrdConceptos.Id).Visible = False
            .Columns(ColumnasDelGrdConceptos.PerteneceA).Visible = False
            .Columns(ColumnasDelGrdConceptos.TipoDeValor).Visible = False
            .Columns(ColumnasDelGrdConceptos.ConceptoPago).Visible = False
            .Columns(ColumnasDelGrdConceptos.CampoAplicable).Visible = False

            .AutoResizeColumns()
        End With
    End Sub

    Private Sub btnListo_Click(sender As Object, e As EventArgs) Handles btnListo.Click

        If ReglasNegocio() Then

            If grdConceptos.CurrentRow IsNot Nothing Then
                ''Llenado de grdConceptosPanel
                With grdConceptos.CurrentRow

                    Dim idFarm_Concep = DBNull.Value
                    Dim id = .Cells(ColumnasDelGrdConceptos.Id).Value
                    Dim codigo = IIf(.Cells(ColumnasDelGrdConceptos.Codigo).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.Codigo).Value)
                    Dim nombre = IIf(.Cells(ColumnasDelGrdConceptos.Nombre).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.Nombre).Value)
                    Dim descripcion = IIf(.Cells(ColumnasDelGrdConceptos.Descripcion).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.Descripcion).Value)
                    Dim idProfesional = IIf(chkProfesional.Checked = True, cmbProfesionales.SelectedValue, DBNull.Value)
                    Dim profesional = IIf(chkProfesional.Checked = True, cmbProfesionales.Text, "")
                    Dim conceptopago = IIf(.Cells(ColumnasDelGrdConceptos.ConceptoPago).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.ConceptoPago).Value)
                    Dim pertenecea = IIf(.Cells(ColumnasDelGrdConceptos.PerteneceA).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.PerteneceA).Value)
                    If pertenecea = 1 Then
                        pertenecea = "LIQUIDACIONES"
                    ElseIf pertenecea = 2 Then
                        pertenecea = "SALDOS"
                    End If
                    Dim tipovalor = IIf(.Cells(ColumnasDelGrdConceptos.TipoDeValor).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.TipoDeValor).Value)
                    Dim valor = IIf(txtValor.Text = "", .Cells(ColumnasDelGrdConceptos.Valor).Value, txtValor.Text)
                    Dim frecuencia = cmbFrecuencia.Text
                    Dim campoaplicable = IIf(.Cells(ColumnasDelGrdConceptos.CampoAplicable).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.CampoAplicable).Value)

                    frmFarmacias_Conceptos.grdConceptosPanel.Rows.Add(idFarm_Concep, id, codigo, nombre, idProfesional, profesional, descripcion, conceptopago, pertenecea, tipovalor, valor, frecuencia, campoaplicable)
                End With


                Me.Dispose()
                Me.Close()

            Else
                MsgBox("Seleccione un concepto para poder continuar.")
            End If

        End If



    End Sub

    Private Sub chkAgrupar_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub CargarCajas()
        If Not (grdConceptos.CurrentRow Is Nothing) Then
            Util.GrillaATextBox(Me.Controls, grdConceptos)
        End If
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs)
        LlenarGrilla()
    End Sub

    Private Sub grdConceptos_CurrentCellChanged(sender As Object, e As EventArgs) Handles grdConceptos.CurrentCellChanged
        If Permitir Then
            CargarCajas()
        End If
        'InformarCantidadRegistros()
        'RaiseEvent ev_CellChanged(sender, e) 'por ahora lo usa el formulario entryline
    End Sub

    Private Sub chkProfesional_Click(sender As Object, e As EventArgs) Handles chkProfesional.Click
        If chkProfesional.Checked = True Then
            cmbProfesionales.Visible = True
            lblProfesional.Visible = True
            chkProfesional.Text = ""
        Else
            cmbProfesionales.Visible = False
            lblProfesional.Visible = False
            chkProfesional.Text = "Profesional"
        End If
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
    '          + Environment.NewLine + "Si el problema persiste contáctese con Kaizen Software a través del correo soporte@kaizensoftware.com.ar", errMessage),
    '          "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        If Not connection Is Nothing Then
    '            CType(connection, IDisposable).Dispose()
    '        End If
    '    End Try
    'End Sub
End Class