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
    Enum ColumnasDelGrdConceptos
        Id = 0
        Nombre = 2
        Descripcion = 3
        ConceptoPago = 4
        PerteneceA = 5
        TipoDeValor = 6
        Valor = 7
        CampoAplicable = 8
    End Enum

    Private Sub LlenarGrilla()
        Dim dtPresentaciones As New DataTable
        Dim connection = Nothing
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
            ''Detalle de liquidacion
            Dim Sql = $"exec spConceptos_Select_Valor @eliminado = 0"

            Dim cmd As New SqlCommand(Sql, connection)
            Dim da As New SqlDataAdapter(cmd)

            da.Fill(dtPresentaciones)

            grdConceptos.DataSource = dtPresentaciones
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Sub



    Private Sub frmNuevaLiquidacion_Load(sender As Object, e As EventArgs) Handles Me.Load
        LlenarGrilla()

        crearDtConceptos()
    End Sub


    Dim dtConceptos_Clone As New DataTable



    Private Sub crearDtConceptos()
        If count < 1 Then

        End If

        count += 1
        dtConceptos_Created = True
    End Sub

    Private Sub btnListo_Click(sender As Object, e As EventArgs) Handles btnListo.Click

        If grdConceptos.CurrentRow IsNot Nothing Then
            ''Llenado de labels en frmLiquidaciones
            With grdConceptos.CurrentRow

                Dim id = .Cells(ColumnasDelGrdConceptos.Id).Value
                Dim nombre = IIf(.Cells(ColumnasDelGrdConceptos.Nombre).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.Nombre).Value)
                Dim descripcion = IIf(.Cells(ColumnasDelGrdConceptos.Descripcion).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.Descripcion).Value)
                Dim conceptopago = IIf(.Cells(ColumnasDelGrdConceptos.ConceptoPago).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.ConceptoPago).Value)
                Dim pertenecea = IIf(.Cells(ColumnasDelGrdConceptos.PerteneceA).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.PerteneceA).Value)
                Dim tipovalor = IIf(.Cells(ColumnasDelGrdConceptos.TipoDeValor).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.TipoDeValor).Value)
                Dim valor = IIf(.Cells(ColumnasDelGrdConceptos.Valor).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.Valor).Value)
                Dim campoaplicable = IIf(.Cells(ColumnasDelGrdConceptos.CampoAplicable).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.CampoAplicable).Value)

                frmFarmacias_Conceptos.grdConceptosPanel.Rows.Add(id, nombre, descripcion, conceptopago, pertenecea, tipovalor, valor, campoaplicable)
            End With


            Me.Dispose()
            Me.Close()

        Else
            MsgBox("Seleccione una presentación para poder continuar.")
        End If


        'Dim dtConceptos As New DataTable
        'dtConceptos.Columns.Add("Id")
        'dtConceptos.Columns.Add("Nombre")
        'dtConceptos.Columns.Add("Descripcion")
        'dtConceptos.Columns.Add("Concepto Pago")
        'dtConceptos.Columns.Add("Pertenece a")
        'dtConceptos.Columns.Add("Tipo de valor")
        'dtConceptos.Columns.Add("Valor")
        'dtConceptos.Columns.Add("Campo Aplicable")

        'If grdConceptos.CurrentRow IsNot Nothing Then
        '    ''Llenado de labels en frmLiquidaciones
        '    With grdConceptos.CurrentRow
        '        Dim row As DataRow = dtConceptos.NewRow
        '        row("Id") = .Cells(ColumnasDelGrdConceptos.Id).Value
        '        row("Nombre") = IIf(.Cells(ColumnasDelGrdConceptos.Nombre).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.Nombre).Value)
        '        row("Descripcion") = IIf(.Cells(ColumnasDelGrdConceptos.Descripcion).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.Descripcion).Value)
        '        row("Concepto Pago") = IIf(.Cells(ColumnasDelGrdConceptos.ConceptoPago).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.ConceptoPago).Value)
        '        row("Pertenece a") = IIf(.Cells(ColumnasDelGrdConceptos.PerteneceA).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.PerteneceA).Value)
        '        row("Tipo de valor") = IIf(.Cells(ColumnasDelGrdConceptos.TipoDeValor).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.TipoDeValor).Value)
        '        row("Valor") = IIf(.Cells(ColumnasDelGrdConceptos.Valor).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.Valor).Value)
        '        row("Campo Aplicable") = IIf(.Cells(ColumnasDelGrdConceptos.CampoAplicable).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdConceptos.CampoAplicable).Value)
        '        dtConceptos.Rows.Add(row)
        '    End With
        '    dtConceptos_Clone = dtConceptos.Clone()

        '    frmFarmacias_Conceptos.grdConceptosPanel.DataSource = dtConceptos

        'Me.Dispose()
        '    Me.Close()

        'Else
        '    MsgBox("Seleccione una presentación para poder continuar.")
        'End If



    End Sub

    Private Sub chkAgrupar_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs)
        LlenarGrilla()
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