Imports System.IO
Imports ExcelDataReader
Imports Microsoft.ApplicationBlocks.Data
Imports Utiles
Imports Utiles.Util
Imports System.Data.SqlClient
Imports ReportesNet
Imports System.Data.OleDb
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.SuperGrid.Style

Public Class frmImportarExcel

    Dim idPresentacion As Long
    Dim tables As DataTableCollection
    Dim WorkingOnTemplate As Boolean = False
    Dim TemplateName = ""
    Dim ExcelTemplate

    ''VARIABLES PROVISORIAS
    Dim cmbTipoPago As ComboBox

    Public Sub New(idPresentacion As Long)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.idPresentacion = idPresentacion

    End Sub

    ''Ini


    Private Sub frmImportarExcel_Load(sender As Object, e As EventArgs) Handles Me.Load
        With grdDetalleLiquidacion
            .VirtualMode = False
            .EnableHeadersVisualStyles = False
            .ColumnHeadersBorderStyle = 1
            .AllowUserToAddRows = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .RowsDefaultCellStyle.BackColor = Color.White
            .AllowUserToOrderColumns = False
            '.SelectionMode = DataGridViewSelectionMode.CellSelect
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        End With

        With grdDetalleLiquidacion.ColumnHeadersDefaultCellStyle
            .BackColor = Color.LightBlue  'Color.BlueViolet
            .ForeColor = Color.Black
            .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        End With

        grdDetalleLiquidacion.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Regular)

        With grdDetalleLiquidacionFiltrada
            .VirtualMode = False
            .AllowUserToAddRows = False
            .EnableHeadersVisualStyles = False
            .ColumnHeadersBorderStyle = 1
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .RowsDefaultCellStyle.BackColor = Color.White
            .AllowUserToOrderColumns = False
            '.SelectionMode = DataGridViewSelectionMode.CellSelect
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        End With

        With grdDetalleLiquidacionFiltrada.ColumnHeadersDefaultCellStyle
            .BackColor = Color.LightBlue  'Color.BlueViolet
            .ForeColor = Color.Black
            .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        End With

        grdDetalleLiquidacionFiltrada.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Regular)

    End Sub

    Private Sub btnImportExcel_Click(sender As Object, e As EventArgs) Handles btnImportExcel.Click
        Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Excel Files |*.xls; *.xlsx"}
            If ofd.ShowDialog = DialogResult.OK Then

                FileName.Text = ofd.FileName
                TemplateName = ofd.SafeFileName.Split("-")(0).ToString
                Using stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read)
                    Using reader As IExcelDataReader = ExcelReaderFactory.CreateReader(stream)
                        Dim result As DataSet = reader.AsDataSet(New ExcelDataSetConfiguration() With {
                                                                 .ConfigureDataTable = Function(__) New ExcelDataTableConfiguration() With {
                                                                 .UseHeaderRow = True
                                                             }})
                        tables = result.Tables
                        cboSheet.Items.Clear()
                        For Each table As DataTable In tables
                            If table.Columns.Count > 0 Then
                                cboSheet.Items.Add(table.TableName)
                            End If
                        Next
                    End Using
                End Using

                grdDetalleLiquidacion.BringToFront()

                cboSheet.SelectedIndex = 0

                btnScan.Enabled = True

            End If
        End Using

    End Sub

    Private Sub CboSheet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSheet.SelectedIndexChanged
        Dim dt As DataTable = tables(cboSheet.SelectedItem.ToString())
        grdDetalleLiquidacion.DataSource = dt


        Dim discounts As String() = New String(6) {"", "Bonificacion", "N. Credito", "Debitos", "Ajustes", "Recupero Aj", "Recupero Gs"}

        Dim max As Integer = grdDetalleLiquidacion.Columns.Count - 1
        For Each obj As Object In GroupBox2.Controls
            If TypeOf obj Is NumericUpDown Then
                obj.Value = 0
                obj.Maximum = max
            End If
        Next

        For Each obj As Object In PanelDescuentos.Controls
            If TypeOf obj Is NumericUpDown Then
                obj.Value = 0
                obj.Maximum = max
            End If
            If TypeOf obj Is ComboBox Then
                obj.Items.Clear()
                For Each discount As String In discounts
                    obj.Items.add(discount)
                Next
                obj.SelectedIndex = 0
            End If
        Next
        Get_excel_templates()

    End Sub

    Private Sub grdDetalleLiquidacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdDetalleLiquidacion.CellContentClick
        FilaLabel.Text = e.RowIndex
        ColLabel.Text = e.ColumnIndex

    End Sub

    Private Sub Get_excel_templates()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            Dim SQL = $" SELECT Recetas, Recaudado, ACargoOS, Bonificacion, [N. Credito], Debitos, Ajustes, [Recupero Aj], [Recupero Gs] FROM ExcelTemplates as t where t.name = '{TemplateName}'"
            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, SQL)
            ds.Dispose()
            ExcelTemplate = ds

            If ds.Tables(0).Rows.Count > 0 Then
                WorkingOnTemplate = True
                RecognitionLabel.Visible = True
                RecognitionLabel.Text = $"Se reconoció: {TemplateName}"

                NumericUpDown1.Value = ds.Tables(0).Rows(0)(0)
                NumericUpDown2.Value = ds.Tables(0).Rows(0)(1)
                NumericUpDown3.Value = ds.Tables(0).Rows(0)(2)

                Dim cbolist As New List(Of ComboBox)
                Dim numericlist As New List(Of NumericUpDown)
                For Each obj As Object In PanelDescuentos.Controls
                    If TypeOf obj Is ComboBox Then
                        cbolist.Add(obj)
                        obj.SelectedIndex = 0
                    End If
                    If TypeOf obj Is NumericUpDown Then
                        numericlist.Add(obj)
                        obj.Value = 0
                    End If
                Next

                Dim i As Integer
                Dim j As Integer = 0
                For i = 3 To ds.Tables(0).Columns.Count - 1
                    If ds.Tables(0).Rows(0)(i) IsNot DBNull.Value Then
                        cbolist.Find(Function(x) x.Tag = j).SelectedItem = ds.Tables(0).Columns(i).ColumnName
                        numericlist.Find(Function(x) x.Tag = j).Value = ds.Tables(0).Rows(0)(i)
                        j += 1
                    End If
                Next

                Scan_columns()
            Else
                btnListo.Enabled = False
                WorkingOnTemplate = False
                RecognitionLabel.Visible = False
                grdDetalleLiquidacionFiltrada.Columns.Clear()
                grdDetalleLiquidacionFiltrada.Rows.Clear()
            End If

        Catch ex As Exception
            MsgBox("Se produjo un error al intentar completar las columnas " & ex.Message)
        End Try



    End Sub

    Public Sub Template_On_Sumbit()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds
        Dim cbolist As New List(Of ComboBox)
        Dim numericlist As New List(Of NumericUpDown)
        For Each obj As Object In PanelDescuentos.Controls
            If TypeOf obj Is ComboBox Then
                If obj.SelectedItem <> "" Then
                    cbolist.Add(obj)
                End If
            End If
            If TypeOf obj Is NumericUpDown Then
                If obj.Value <> 0 Then
                    numericlist.Add(obj)
                End If
            End If
        Next

        cbolist.Sort(Function(x, y) x.Tag.CompareTo(y.Tag))
        numericlist.Sort(Function(x, y) x.Tag.CompareTo(y.Tag))


        If WorkingOnTemplate Then
            Dim i
            Dim j = 0
            Dim cell_value
            Dim need_to_update = False
            Dim StrSet = ""
            ''con esta list me aseguro que los demas campos sin modificar sean null
            Dim fields2clean As New List(Of String) From {"Bonificacion", "N. Credito", "Debitos", "Ajustes", "Recupero Aj", "Recupero Gs"}

            Dim ExcelTemplate_len As Integer = 0
            For i = 3 To ExcelTemplate.Tables(0).Columns.Count - 1
                If ExcelTemplate.Tables(0).Rows(0)(i) IsNot DBNull.Value Then
                    ExcelTemplate_len += 1
                End If
            Next

            If ExcelTemplate_len <> cbolist.Count Then
                need_to_update = True
            Else
                For i = 0 To cbolist.Count - 1
                    cell_value = IIf(ExcelTemplate.Tables(0).Rows(0)(cbolist(i).SelectedItem) Is DBNull.Value, 0, ExcelTemplate.Tables(0).Rows(0)(cbolist(i).SelectedItem))

                    If numericlist(i).Value <> cell_value Then
                        need_to_update = True
                    End If
                Next
            End If

            If need_to_update Then
                For i = 0 To cbolist.Count - 1
                    If StrSet = "" Then
                        StrSet += $"[{cbolist(i).SelectedItem}] = {numericlist(i).Value}"
                    Else
                        StrSet += $", [{cbolist(i).SelectedItem}] = {numericlist(i).Value}"
                    End If
                    fields2clean.Remove(cbolist(i).SelectedItem)
                Next

                For Each field As String In fields2clean
                    If StrSet = "" Then
                        StrSet += $"[{field}] = NULL"
                    Else
                        StrSet += $", [{field}] = NULL"
                    End If
                Next

                SQL = $"UPDATE [CENPROFAR].[dbo].[ExcelTemplates] SET {StrSet} where [Name] = '{TemplateName}'"


                Try
                    connection = SqlHelper.GetConnection(ConnStringSEI)
                    ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, SQL)
                    ds.Dispose()
                Catch ex As Exception
                    MessageBox.Show($"No se pudo conectar con la base de datos {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                MsgBox($"Se actualizo template {TemplateName}")
            End If

        Else
            Dim StrCols = "Name, Recetas, Recaudado, ACargoOS"
            Dim StrValues = $"'{TemplateName}', {NumericUpDown1.Value}, {NumericUpDown2.Value}, {NumericUpDown3.Value}"

            Dim i As Integer
            For i = 0 To cbolist.Count - 1
                StrCols = StrCols + $", [{cbolist(i).SelectedItem}]"
                StrValues += $", {numericlist(i).Value}"
            Next

            Dim SQL = $"INSERT INTO [CENPROFAR].[dbo].[ExcelTemplates] ({StrCols}) VALUES ({StrValues})"

            Try
                connection = SqlHelper.GetConnection(ConnStringSEI)
                ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, SQL)
                ds.Dispose()
            Catch ex As Exception
                MessageBox.Show($"No se pudo conectar con la base de datos {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        End If
    End Sub

    Public Function GetSimilarity(string1 As String, string2 As String) As Single
        Dim dis As Single = ComputeDistance(string1, string2)
        Dim maxLen As Single = string1.Length
        If maxLen < string2.Length Then
            maxLen = string2.Length
        End If
        If maxLen = 0.0F Then
            Return 1.0F
        Else
            Return 1.0F - dis / maxLen
        End If
    End Function

    Private Function ComputeDistance(s As String, t As String) As Integer
        Dim n As Integer = s.Length
        Dim m As Integer = t.Length
        Dim distance As Integer(,) = New Integer(n, m) {}
        ' matrix
        Dim cost As Integer = 0
        If n = 0 Then
            Return m
        End If
        If m = 0 Then
            Return n
        End If
        'init1

        Dim i As Integer = 0
        While i <= n
            distance(i, 0) = System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        Dim j As Integer = 0
        While j <= m
            distance(0, j) = System.Math.Max(System.Threading.Interlocked.Increment(j), j - 1)
        End While
        'find min distance

        For i = 1 To n
            For j = 1 To m
                cost = (If(t.Substring(j - 1, 1) = s.Substring(i - 1, 1), 0, 1))
                distance(i, j) = Math.Min(distance(i - 1, j) + 1, Math.Min(distance(i, j - 1) + 1, distance(i - 1, j - 1) + cost))
            Next
        Next
        Return distance(n, m)
    End Function

    Private Function Buscar_FarmaciaByName(name As String, dtFarmacias As DataTable)
        Dim dt_ResultadoComparacionFarmacias As New DataTable
        Dim i As Integer
        dt_ResultadoComparacionFarmacias.Columns.Add("CodigoInterno")
        dt_ResultadoComparacionFarmacias.Columns.Add("Porcentaje")
        For i = 0 To dtFarmacias.Rows.Count - 1
            'comparo los nombres de las farmacias
            Dim farmaciaDb = dtFarmacias.Rows(i).Item(3).ToString
            Dim farmaciaGrd = name

            Dim porcentajeComparacion = GetSimilarity(farmaciaGrd, farmaciaDb)

            If porcentajeComparacion >= 0.7 Then

                Dim rowdt As DataRow = dt_ResultadoComparacionFarmacias.NewRow()
                rowdt("CodigoInterno") = dtFarmacias.Rows(i).Item(0)
                rowdt("Porcentaje") = porcentajeComparacion
                dt_ResultadoComparacionFarmacias.Rows.Add(rowdt)
                dt_ResultadoComparacionFarmacias.DefaultView.Sort = "Porcentaje DESC"
                dt_ResultadoComparacionFarmacias = dt_ResultadoComparacionFarmacias.DefaultView.ToTable

            End If
        Next
        'traigo el codigo interno de la farmacia con mayor porcentaje de aproximacion
        If dt_ResultadoComparacionFarmacias.Rows.Count > 0 Then
            For Each row As DataRow In dtFarmacias.Rows
                If dt_ResultadoComparacionFarmacias.Rows(0).Item("CodigoInterno") = row("Codigo") Then
                    Return row
                End If
            Next
        End If

        Return Nothing

    End Function

    Private Function getFarmacia(row As DataRow, dtFarmacias As DataTable) ''Recibe una fila y busca si es una farmacia dentro de una tabla dada
        Dim best_row
        Dim isCode As Boolean
        Dim Int As Integer

        If row(0) IsNot DBNull.Value Then
            isCode = False
            ''MODULO FACAF
            If row(0).ToString.Contains("F0") Then
                dtFarmacias.PrimaryKey = {
                    dtFarmacias.Columns("CodFACAF")
                }
                isCode = True
            End If

            'MODULO PAMI
            If row(0).ToString.Length = 9 And IsNumeric(row(0).ToString) And Integer.TryParse(row(0), Int) Then
                dtFarmacias.PrimaryKey = {
                    dtFarmacias.Columns("codpami")
                }
                isCode = True
            End If

            If isCode Then
                Dim farmacia = dtFarmacias.Rows.Find({row(0)})

                If farmacia IsNot Nothing Then
                    Return farmacia
                Else
                    best_row = Buscar_FarmaciaByName(row(2).ToString, dtFarmacias)
                    If best_row IsNot Nothing Then
                        Return best_row
                    Else
                        Return Nothing
                    End If
                End If
            End If
        End If

        Return Nothing

    End Function

    Private Sub Scan_columns()

        'toma las columnas
        Dim RecetasIndex As Integer = NumericUpDown1.Value
        Dim RecaudadoIndex As Integer = NumericUpDown2.Value
        Dim AcargoOSIndex As Integer = NumericUpDown3.Value

        Dim dt_filtrada As New DataTable()

        Dim DiscountIndex As Integer

        Dim cbolist As New List(Of ComboBox)
        Dim numericlist As New List(Of NumericUpDown)



        If grdDetalleLiquidacionFiltrada.Rows.Count <> 0 Then
            grdDetalleLiquidacionFiltrada.DataSource = Nothing
        End If


        If NumericUpDown1.Value = 0 Or NumericUpDown2.Value = 0 Or NumericUpDown3.Value = 0 Then
            btnListo.Enabled = False
            MsgBox($"Las columnas de receta, recaudado y a cargo son obligatorias")
            Return
        End If

        For Each obj As Object In PanelDescuentos.Controls
            If TypeOf obj Is ComboBox Then
                If obj.SelectedItem <> "" Then
                    cbolist.Add(obj)
                End If
            End If
            If TypeOf obj Is NumericUpDown Then
                numericlist.Add(obj)
            End If
        Next

        Dim ocupied As New List(Of String)
        For Each cbo As ComboBox In cbolist
            If Not ocupied.Contains(cbo.SelectedItem) Then
                ocupied.Add(cbo.SelectedItem)
            Else
                btnListo.Enabled = False
                MsgBox($"El descuento {cbo.SelectedItem} no puede repetirse más de una vez")
                Return
            End If
        Next

        cbolist.Sort(Function(x, y) x.Tag.CompareTo(y.Tag))
        numericlist.Sort(Function(x, y) x.Tag.CompareTo(y.Tag))
        Dim i As Integer

        For i = 0 To cbolist.Count() - 1
            If numericlist(i).Value = 0 Then
                btnListo.Enabled = False
                MsgBox($"No puede seleccionarse la columna 0 para {cbolist(i).SelectedItem}")
                Return
            End If
        Next
        ''revisar
        dt_filtrada.Columns.Add("IdDetalle", GetType(Long))
        dt_filtrada.Columns.Add("IdFarmacia", GetType(Long))
        dt_filtrada.Columns.Add("Codigo", GetType(String))
        dt_filtrada.Columns.Add("Nombre", GetType(String))
        dt_filtrada.Columns.Add("Recetas", GetType(Integer))
        dt_filtrada.Columns.Add("Recaudado", GetType(Decimal))
        dt_filtrada.Columns.Add("A cargo OS", GetType(Decimal))

        For Each cbo As ComboBox In cbolist
            With cbo
                dt_filtrada.Columns.Add(.SelectedItem, GetType(Decimal))
            End With
        Next

        dt_filtrada.Columns.Add("Total", GetType(Decimal))

        Dim j As Integer
        Dim FirstColumnCell As String
        Dim subtotal As Decimal
        Dim farmacia As DataRow
        Dim CurrentRow As DataRow
        'ARREGLAR ESTA PARTE - NECESITO ID DE LA PRESENTACION
        'Dim idPresentacion As Long = grd.Rows(0).Cells(0).Value
        'If grd.CurrentRow IsNot Nothing Then
        '    idPresentacion = grd.CurrentRow.Cells(0).Value
        'End If
        Dim connection = SqlHelper.GetConnection(ConnStringSEI)
        Dim ds_Farmacias As New DataSet

        Dim dtFarmacias As New DataTable
        ''nacho cambió: f.codigo -> f.id

        Dim SQL_Farmacias = $"SELECT pd.ID as IdDetalle, f.ID as IdFarmacia, f.Codigo, f.CodFACAF, f.codpami, f.Nombre, pd.IdPresentacion FROM Farmacias f INNER JOIN Presentaciones_det pd on f.Id = pd.IdFarmacia
                              WHERE pd.IdPresentacion = {idPresentacion}"

        Try
            ds_Farmacias = SqlHelper.ExecuteDataset(connection, CommandType.Text, SQL_Farmacias)
            ds_Farmacias.EnforceConstraints = False
            ds_Farmacias.Dispose()
            dtFarmacias = ds_Farmacias.Tables(0)
        Catch ex As Exception
            MessageBox.Show($"No se pudo conectar con la base de datos {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        For j = 0 To grdDetalleLiquidacion.Rows.Count - 1
            CurrentRow = (TryCast(grdDetalleLiquidacion.Rows(j).DataBoundItem, DataRowView)).Row

            subtotal = 0

            FirstColumnCell = IIf(grdDetalleLiquidacion.Rows(j).Cells(0).Value IsNot Nothing, grdDetalleLiquidacion.Rows(j).Cells(0).Value.ToString, "")

            farmacia = getFarmacia(CurrentRow, dtFarmacias)

            Try
                If farmacia IsNot Nothing Then
                    '//////Get a reference to the new row ///////
                    Dim Row As DataRow = dt_filtrada.NewRow()

                    'This won't fail since the columns exist 
                    'Row("Codigo") = grdDetalleLiquidacion.Rows(j).Cells(0).Value
                    Row("IdDetalle") = farmacia("IdDetalle")
                    Row("IdFarmacia") = farmacia("IdFarmacia")
                    Row("Codigo") = farmacia("Codigo")
                    Row("Nombre") = farmacia("Nombre")
                    Row("Recetas") = grdDetalleLiquidacion.Rows(j).Cells(RecetasIndex).Value
                    Row("Recaudado") = grdDetalleLiquidacion.Rows(j).Cells(RecaudadoIndex).Value
                    Row("A cargo OS") = grdDetalleLiquidacion.Rows(j).Cells(AcargoOSIndex).Value
                    subtotal = Decimal.Parse(grdDetalleLiquidacion.Rows(j).Cells(AcargoOSIndex).Value)

                    For i = 0 To cbolist.Count() - 1
                        DiscountIndex = numericlist(i).Value
                        subtotal -= Decimal.Parse(grdDetalleLiquidacion.Rows(j).Cells(DiscountIndex).Value)
                        Row(cbolist(i).SelectedItem) = grdDetalleLiquidacion.Rows(j).Cells(DiscountIndex).Value
                    Next

                    Row("Total") = subtotal

                    dt_filtrada.Rows.Add(Row)
                End If
            Catch ex As Exception
                MsgBox(ex)
            End Try

        Next

        Dim dt_grouped As New DataTable()
        dt_grouped = dt_filtrada.Clone()
        Dim added As Boolean = False
        Dim current_row_index As Integer

        For current_row_index = 0 To dt_filtrada.Rows.Count - 1
            Dim current_row As DataRow = dt_filtrada.Rows(current_row_index)
            added = False

            j = 0
            While (j < dt_grouped.Rows.Count And added = False)
                If current_row("Codigo") = dt_grouped.Rows(j)("Codigo") Then
                    added = True
                End If
                j += 1
            End While

            If Not added Then
                Dim new_row As DataRow = dt_grouped.NewRow()
                For i = current_row_index To dt_filtrada.Rows.Count - 1
                    If dt_filtrada.Rows(i)("Codigo") = current_row("Codigo") Then
                        new_row("IdDetalle") = current_row("IdDetalle")
                        new_row("IdFarmacia") = current_row("IdFarmacia")
                        new_row("Codigo") = current_row("Codigo")
                        new_row("Nombre") = current_row("Nombre")
                        For j = 4 To dt_filtrada.Columns.Count - 1
                            If i = current_row_index Then
                                new_row(j) = Decimal.Parse(dt_filtrada.Rows(i)(j))
                            Else
                                new_row(j) += Decimal.Parse(dt_filtrada.Rows(i)(j))
                            End If
                        Next
                    End If
                Next
                dt_grouped.Rows.Add(new_row)

            End If
        Next

        grdDetalleLiquidacionFiltrada.DataSource = dt_grouped

        btnListo.Enabled = True
        ' DataGridView1.BringToFront()
    End Sub

    Private Sub BtnScan_Click(sender As Object, e As EventArgs) Handles btnScan.Click
        Scan_columns()
    End Sub

    Private Sub btnListo_Click(sender As Object, e As EventArgs) Handles btnListo.Click
        Dim i As Integer
        Dim rowArray
        Dim dtGrdData As DataTable = grdDetalleLiquidacionFiltrada.DataSource

        Dim dtAceptados As New DataTable()
        dtAceptados.Columns.Add("IdDetalle", GetType(Long))
        dtAceptados.Columns.Add("Recetas", GetType(Integer))
        dtAceptados.Columns.Add("Recaudado", GetType(Decimal))
        dtAceptados.Columns.Add("A Cargo OS", GetType(Decimal))

        Dim dtConceptos As New DataTable()
        dtConceptos.Columns.Add("ID", GetType(Long))
        dtConceptos.Columns.Add("IdDetalle", GetType(Long))
        dtConceptos.Columns.Add("IdFarmacia", GetType(String))
        dtConceptos.Columns.Add("detalle", GetType(String))
        dtConceptos.Columns.Add("valor", GetType(Decimal))
        dtConceptos.Columns.Add("estado", GetType(String))
        dtConceptos.Columns.Add("edit")

        '---------------Recolección de aceptados----------------
        For Each item As DataRow In dtGrdData.Rows
            Dim row As DataRow = dtAceptados.NewRow()
            row("IdDetalle") = item("IdDetalle")
            row("Recetas") = item("Recetas")
            row("Recaudado") = item("Recaudado")
            row("A Cargo OS") = item("A Cargo OS")
            dtAceptados.Rows.Add(row)
        Next
        frmLiquidaciones.addAceptadosFromExcel(dtAceptados)


        '---------------Recolección de conceptos----------------

        ''CALCULO DE ERROR AJUSTE
        'For i = 0 To grdDetalleLiquidacionFiltrada.Rows.Count - 1
        '    Dim aceptado = Decimal.Parse(grdDetalleLiquidacionFiltrada.Rows(i).Cells("A cargo OS").Value)
        '    Dim aceptado_farmacia = grdDetalleLiquidacionFiltrada.Rows(i).Cells("IdFarmacia").Value

        '    'Se queda con la primera coincidencia de farmacia y detalle de la grilla de detalles
        '    Dim a_cargo As DataRow
        '    rowArray = Conceptos.Select($"IdFarmacia = '{aceptado_farmacia}' and detalle = 'A cargo OS'")
        '    If rowArray.Length > 0 Then
        '        a_cargo = rowArray(0)

        '        If a_cargo("valor") <> aceptado Then
        '            Dim error_ajuste As DataRow = Conceptos.NewRow()
        '            error_ajuste("IdDetalle") = a_cargo("IdDetalle")
        '            error_ajuste("IdFarmacia") = a_cargo("IdFarmacia")
        '            error_ajuste("estado") = "insert"
        '            If cmbTipoPago.Text = "Anticipo" Then
        '                error_ajuste("detalle") = "Pendiente de pago"
        '            Else
        '                error_ajuste("detalle") = "Error ajuste"
        '            End If

        '            error_ajuste("valor") = Decimal.Parse(aceptado - a_cargo("valor"))
        '            Conceptos.Rows.Add(error_ajuste)
        '        End If
        '    End If

        'Next

        Dim ColumnName As String
        Dim IdDetalle As Long

        Dim j As Integer = 0
        For i = 7 To grdDetalleLiquidacionFiltrada.Columns.Count - 2

            ColumnName = grdDetalleLiquidacionFiltrada.Columns(i).Name
            For j = 0 To grdDetalleLiquidacionFiltrada.Rows.Count - 1
                Dim row As DataRow = dtConceptos.NewRow()
                ''Se queda con la primera coincidencia de farmacia para obtener IdDetalle
                rowArray = dtGrdData.Select($"IdFarmacia = '{grdDetalleLiquidacionFiltrada.Rows(j).Cells("IdFarmacia").Value}'")
                If rowArray.Length > 0 Then
                    IdDetalle = rowArray(0)("IdDetalle")
                    row("IdDetalle") = IdDetalle
                    row("IdFarmacia") = grdDetalleLiquidacionFiltrada.Rows(j).Cells("IdFarmacia").Value
                    row("detalle") = ColumnName
                    row("valor") = Decimal.Parse(grdDetalleLiquidacionFiltrada.Rows(j).Cells(i).Value) * -1
                    row("edit") = True
                    row("estado") = "insert"
                    If (row("valor") <> 0) Then
                        dtConceptos.Rows.Add(row)
                    End If
                End If
            Next
        Next
        Template_On_Sumbit()

        frmLiquidaciones.addConceptosFromExcel(dtConceptos)

        frmLiquidaciones.UpdateGrdPrincipal()

        Me.Dispose()
        Me.Close()

    End Sub
End Class