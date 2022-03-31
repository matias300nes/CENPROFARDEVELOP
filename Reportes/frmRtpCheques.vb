Public Class frmRtpCheques
    Private Sub frmRtpCheques_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'dsSistema.spRPT_Presentacion' Puede moverla o quitarla según sea necesario.
        'Me.spRPT_PresentacionTableAdapter.Fill(Me.dsSistema.spRPT_Presentacion)

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport
    End Sub
End Class