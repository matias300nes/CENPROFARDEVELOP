Public Class frmLiquidacionesTotConceptos
    Dim dtConceptos As DataTable
    Dim dtTotales As DataTable
    Public Sub New(dtConceptos As DataTable)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.dtConceptos = dtConceptos

    End Sub

    Private Sub frmLiquidacionesTotConceptos_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtTotales = New DataTable()
        dtTotales.Columns.Add("Concepto", GetType(String))
        dtTotales.Columns.Add("Total", GetType(Decimal))

        group_dt()


        With grdConceptos
            .DataSource = dtTotales
            .AutoResizeColumns()
        End With
    End Sub

    Private Function group_dt()
        Dim i, j As Integer
        Dim current_row_index As Integer
        Dim added As Boolean

        For current_row_index = 0 To dtConceptos.Rows.Count - 1

            Dim current_row As DataRow = dtConceptos.Rows(current_row_index)
            added = False

            j = 0
            While (j < dtTotales.Rows.Count And added = False)
                If current_row("detalle") = dtTotales.Rows(j)("Concepto") Then
                    added = True
                End If
                j += 1
            End While

            If Not added Then
                Dim new_row As DataRow = dtTotales.NewRow()
                For i = current_row_index To dtConceptos.Rows.Count - 1
                    If dtConceptos.Rows(i)("detalle") = current_row("detalle") Then
                        new_row("Concepto") = current_row("detalle")

                        If i = current_row_index Then
                            new_row("Total") = Decimal.Parse(dtConceptos.Rows(i)("valor"))
                        Else
                            new_row("Total") += Decimal.Parse(dtConceptos.Rows(i)("valor"))
                        End If

                    End If
                Next
                dtTotales.Rows.Add(new_row)

            End If
        Next

    End Function

End Class