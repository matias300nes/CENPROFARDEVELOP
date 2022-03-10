Imports ExcelDataReader
Imports System.IO

Public Class frmExcelFilter

    Dim storeProcedureName As String

    Dim args As List(Of String)

    Dim tables As DataTableCollection

    Public Sub New(storeProcedureName As String, args As List(Of String))

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.storeProcedureName = storeProcedureName

        Me.args = args

    End Sub

    Private Sub frmExcelFilter_Load(sender As Object, e As EventArgs) Handles Me.Load


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Excel Files |*.xls; *.xlsx"}
            If ofd.ShowDialog = DialogResult.OK Then

                'FileName.Text = ofd.FileName
                'TemplateName = ofd.SafeFileName.Split("-")(0).ToString
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

                cboSheet.SelectedIndex = 0

                Dim dt As DataTable = tables(cboSheet.SelectedItem.ToString())
                grdExcel.DataSource = dt

                Dim ComboBoxHeader As ComboBox
                For i As Integer = 0 To dt.Columns.Count - 1
                    ComboBoxHeader = New ComboBox()
                    ComboBoxHeader.DropDownStyle = ComboBoxStyle.DropDownList
                    ComboBoxHeader.Visible = True
                    ComboBoxHeader.Items.Add("Column1")
                    ComboBoxHeader.Items.Add("Column2")

                    grdExcel.Controls.Add(ComboBoxHeader)
                    ComboBoxHeader.Location = grdExcel.GetCellDisplayRectangle(i, -1, True).Location
                    ComboBoxHeader.Size = grdExcel.Columns(0).HeaderCell.Size
                    ComboBoxHeader.Text = "Column1"
                Next

                ''agrego los controles para cada 
                ''// Create a ComboBox which will be host in column1's cell
                'Dim comboBoxHeaderCell1 As ComboBox = New ComboBox()
                'comboBoxHeaderCell1.DropDownStyle = ComboBoxStyle.DropDownList
                'comboBoxHeaderCell1.Visible = True
                'comboBoxHeaderCell1.Items.Add("Column1")
                'comboBoxHeaderCell1.Items.Add("Column2")

                ''// Add the ComboBox to the header cell of column1
                'grdExcel.Controls.Add(comboBoxHeaderCell1)
                'comboBoxHeaderCell1.Location = grdExcel.GetCellDisplayRectangle(0, -1, True).Location
                'comboBoxHeaderCell1.Size = grdExcel.Columns(0).HeaderCell.Size
                'comboBoxHeaderCell1.Text = "Column1"

            End If
        End Using
    End Sub
End Class