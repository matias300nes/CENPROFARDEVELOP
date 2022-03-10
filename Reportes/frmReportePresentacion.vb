Public Class frmReportePresentacion
    Private Sub frmReportePresentacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'dsPresentacion.spRPT_Presentacion' Puede moverla o quitarla según sea necesario.
        Me.spRPT_PresentacionTableAdapter.Fill(Me.dsPresentacion.spRPT_Presentacion, 1)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class