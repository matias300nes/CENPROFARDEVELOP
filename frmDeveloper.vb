Public Class frmDeveloper

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        lblStatus.Visible = True
        If txtUser.Text = "sa" And txtPassword.Text = "industrial" Then
            gbPanel.Visible = True
            lblStatus.Text = "Session started"
        Else
            gbPanel.Visible = False
            lblStatus.Text = "Wrong user"
        End If
    End Sub

    Private Sub frmDeveloper_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        Dim WebService As New CPFWebService.WS_CPFSoapClient()
        Dim data As New DataSet
        Try
            data = WebService.Sql_Get(txtQuery.Text)
            grdResult.DataSource = data.Tables(0)
            txtResult.Text = data.GetXml()
        Catch ex As Exception
            txtResult.Text = ex.ToString
        End Try
    End Sub

End Class