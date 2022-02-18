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
        ''agrego los controles para cada 
        For Each arg As Object In args
            Dim label As New Label()
            label.Text = arg

            Dim numeric As New NumericUpDown()

            pnlForm.Controls.Add(label)
            pnlForm.Controls.Add(numeric)
        Next
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

            End If
        End Using
    End Sub
End Class