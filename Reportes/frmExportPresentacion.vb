Imports Microsoft.Reporting.WinForms

Public Class frmExportPresentacion
    Private Sub frmExportPresentacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()

        Dim idPresentacion As String
        idPresentacion = "1"

        Dim param1 As New ReportParameter
        param1.Name = "idPresentacion"
        param1.Values.Add(idPresentacion)

        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {param1})
        Me.spRPT_PresentacionTableAdapter.Fill(Me.dsPresentaciones.spRPT_Presentacion, idPresentacion)
        Me.ReportViewer1.RefreshReport()
    End Sub

End Class