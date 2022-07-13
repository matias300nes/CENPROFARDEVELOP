Public Class frmDeveloper

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        lblStatus.Visible = True
        If txtUser.Text = "sa" And txtPassword.Text = "industrial" Then
            tbPanel.Visible = True
            lblStatus.Text = "Session started"
        Else
            tbPanel.Visible = False
            lblStatus.Text = "Wrong user"
        End If
    End Sub

    Private Sub frmDeveloper_Load(sender As Object, e As EventArgs) Handles Me.Load
        cmbTablasWeb.DataSource = WebServiceUtils.WebTables
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnActualizarTodo.Click
        Dim result As DialogResult = MessageBox.Show(
                              $"Está seguro que desea sincronizar las tablas con la web?",
                              "Confirmar sincronización",
                              MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            For Each table As String In WebServiceUtils.WebTables
                txtUtilsResponse.Text = WebServiceUtils.updateTable(table)
            Next
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnTruncateAll.Click
        Dim result As DialogResult = MessageBox.Show(
                              $"Está seguro que desea truncar las tablas con la web?",
                              "Confirmar truncar",
                              MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            txtUtilsResponse.Text = WebServiceUtils.truncateWeb()
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim result As DialogResult = MessageBox.Show(
                      $"Está seguro que desea sincronizar las tablas con la web?",
                      "Confirmar sincronización",
                      MessageBoxButtons.YesNo)

        If result = DialogResult.Yes And cmbTablasWeb.Text <> "" Then
            txtUtilsResponse.Text = WebServiceUtils.updateTable(cmbTablasWeb.Text)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnTruncate.Click
        Dim WebService As New CPFWebService.WS_CPFSoapClient()
        Dim result As DialogResult = MessageBox.Show(
                      $"Está seguro que desea truncar las tablas con la web?",
                      "Confirmar truncar",
                      MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            Try
                Dim query = $"truncate table {cmbTablasWeb.Text};"
                WebService.Sql_Get(query)
                txtUtilsResponse.Text = "Success"
            Catch ex As Exception
                txtUtilsResponse.Text = ex.Message
            End Try
        End If
    End Sub
End Class