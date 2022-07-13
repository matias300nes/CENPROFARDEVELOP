<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeveloper
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbUser = New System.Windows.Forms.GroupBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnIniciar = New System.Windows.Forms.Button()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TCResults = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.grdResult = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQuery = New System.Windows.Forms.TextBox()
        Me.tbPanel = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.pgProgreso = New System.Windows.Forms.ProgressBar()
        Me.btnTruncate = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtUtilsResponse = New System.Windows.Forms.TextBox()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.cmbTablasWeb = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnTruncateAll = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnActualizarTodo = New System.Windows.Forms.Button()
        Me.grdCambios = New System.Windows.Forms.DataGridView()
        Me.btnReloadCambios = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbUser.SuspendLayout()
        Me.TCResults.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.grdResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.tbPanel.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.grdCambios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbUser
        '
        Me.gbUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbUser.Controls.Add(Me.lblStatus)
        Me.gbUser.Controls.Add(Me.btnIniciar)
        Me.gbUser.Controls.Add(Me.lblPassword)
        Me.gbUser.Controls.Add(Me.lblUser)
        Me.gbUser.Controls.Add(Me.txtPassword)
        Me.gbUser.Controls.Add(Me.txtUser)
        Me.gbUser.Location = New System.Drawing.Point(12, 12)
        Me.gbUser.Name = "gbUser"
        Me.gbUser.Size = New System.Drawing.Size(776, 64)
        Me.gbUser.TabIndex = 0
        Me.gbUser.TabStop = False
        Me.gbUser.Text = "User"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(440, 35)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 13)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "Label1"
        Me.lblStatus.Visible = False
        '
        'btnIniciar
        '
        Me.btnIniciar.Location = New System.Drawing.Point(339, 30)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(75, 23)
        Me.btnIniciar.TabIndex = 4
        Me.btnIniciar.Text = "Iniciar"
        Me.btnIniciar.UseVisualStyleBackColor = True
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(183, 16)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = "Password"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(19, 16)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(29, 13)
        Me.lblUser.TabIndex = 2
        Me.lblUser.Text = "User"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(186, 32)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(143, 20)
        Me.txtPassword.TabIndex = 1
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(22, 32)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(143, 20)
        Me.txtUser.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(506, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Method"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(368, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Server"
        '
        'ComboBox2
        '
        Me.ComboBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Sql_Get"})
        Me.ComboBox2.Location = New System.Drawing.Point(509, 24)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox2.TabIndex = 7
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Local", "Web"})
        Me.ComboBox1.Location = New System.Drawing.Point(371, 24)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 6
        '
        'TCResults
        '
        Me.TCResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TCResults.Controls.Add(Me.TabPage1)
        Me.TCResults.Controls.Add(Me.TabPage2)
        Me.TCResults.Location = New System.Drawing.Point(10, 236)
        Me.TCResults.Name = "TCResults"
        Me.TCResults.SelectedIndex = 0
        Me.TCResults.Size = New System.Drawing.Size(745, 169)
        Me.TCResults.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grdResult)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(737, 143)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Table"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grdResult
        '
        Me.grdResult.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.grdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdResult.Location = New System.Drawing.Point(3, 3)
        Me.grdResult.Name = "grdResult"
        Me.grdResult.Size = New System.Drawing.Size(731, 137)
        Me.grdResult.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtResult)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(737, 143)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "XML"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtResult
        '
        Me.txtResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtResult.Location = New System.Drawing.Point(3, 3)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(731, 137)
        Me.txtResult.TabIndex = 10
        '
        'btnRun
        '
        Me.btnRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRun.Location = New System.Drawing.Point(681, 22)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(49, 23)
        Me.btnRun.TabIndex = 4
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Query"
        '
        'txtQuery
        '
        Me.txtQuery.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuery.Location = New System.Drawing.Point(17, 49)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQuery.Size = New System.Drawing.Size(731, 167)
        Me.txtQuery.TabIndex = 0
        '
        'tbPanel
        '
        Me.tbPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPanel.Controls.Add(Me.TabPage4)
        Me.tbPanel.Controls.Add(Me.TabPage3)
        Me.tbPanel.Location = New System.Drawing.Point(12, 82)
        Me.tbPanel.Name = "tbPanel"
        Me.tbPanel.SelectedIndex = 0
        Me.tbPanel.Size = New System.Drawing.Size(776, 451)
        Me.tbPanel.TabIndex = 2
        Me.tbPanel.Visible = False
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Label3)
        Me.TabPage4.Controls.Add(Me.Label2)
        Me.TabPage4.Controls.Add(Me.Label1)
        Me.TabPage4.Controls.Add(Me.ComboBox2)
        Me.TabPage4.Controls.Add(Me.txtQuery)
        Me.TabPage4.Controls.Add(Me.ComboBox1)
        Me.TabPage4.Controls.Add(Me.btnRun)
        Me.TabPage4.Controls.Add(Me.TCResults)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(768, 425)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Sql Query"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.btnReloadCambios)
        Me.TabPage3.Controls.Add(Me.grdCambios)
        Me.TabPage3.Controls.Add(Me.pgProgreso)
        Me.TabPage3.Controls.Add(Me.btnTruncate)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.txtUtilsResponse)
        Me.TabPage3.Controls.Add(Me.btnActualizar)
        Me.TabPage3.Controls.Add(Me.cmbTablasWeb)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.btnTruncateAll)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.btnActualizarTodo)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(768, 425)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "DB Web utils"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'pgProgreso
        '
        Me.pgProgreso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgProgreso.Location = New System.Drawing.Point(39, 273)
        Me.pgProgreso.Name = "pgProgreso"
        Me.pgProgreso.Size = New System.Drawing.Size(664, 13)
        Me.pgProgreso.TabIndex = 10
        '
        'btnTruncate
        '
        Me.btnTruncate.Location = New System.Drawing.Point(252, 119)
        Me.btnTruncate.Name = "btnTruncate"
        Me.btnTruncate.Size = New System.Drawing.Size(70, 23)
        Me.btnTruncate.TabIndex = 9
        Me.btnTruncate.Text = "Truncate"
        Me.btnTruncate.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(36, 169)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Response:"
        '
        'txtUtilsResponse
        '
        Me.txtUtilsResponse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUtilsResponse.Location = New System.Drawing.Point(39, 185)
        Me.txtUtilsResponse.Multiline = True
        Me.txtUtilsResponse.Name = "txtUtilsResponse"
        Me.txtUtilsResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtUtilsResponse.Size = New System.Drawing.Size(682, 101)
        Me.txtUtilsResponse.TabIndex = 7
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(177, 119)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(70, 23)
        Me.btnActualizar.TabIndex = 6
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'cmbTablasWeb
        '
        Me.cmbTablasWeb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTablasWeb.FormattingEnabled = True
        Me.cmbTablasWeb.Location = New System.Drawing.Point(39, 120)
        Me.cmbTablasWeb.Name = "cmbTablasWeb"
        Me.cmbTablasWeb.Size = New System.Drawing.Size(131, 21)
        Me.cmbTablasWeb.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(100, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Truncar tablas de la web:"
        '
        'btnTruncateAll
        '
        Me.btnTruncateAll.Location = New System.Drawing.Point(233, 78)
        Me.btnTruncateAll.Name = "btnTruncateAll"
        Me.btnTruncateAll.Size = New System.Drawing.Size(90, 23)
        Me.btnTruncateAll.TabIndex = 2
        Me.btnTruncateAll.Text = "Truncate"
        Me.btnTruncateAll.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(46, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(181, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Actualizar todas las tablas de la web:"
        '
        'btnActualizarTodo
        '
        Me.btnActualizarTodo.Location = New System.Drawing.Point(233, 39)
        Me.btnActualizarTodo.Name = "btnActualizarTodo"
        Me.btnActualizarTodo.Size = New System.Drawing.Size(90, 23)
        Me.btnActualizarTodo.TabIndex = 0
        Me.btnActualizarTodo.Text = "Actualizar todo"
        Me.btnActualizarTodo.UseVisualStyleBackColor = True
        '
        'grdCambios
        '
        Me.grdCambios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdCambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCambios.Location = New System.Drawing.Point(361, 39)
        Me.grdCambios.Name = "grdCambios"
        Me.grdCambios.ReadOnly = True
        Me.grdCambios.RowHeadersVisible = False
        Me.grdCambios.Size = New System.Drawing.Size(360, 102)
        Me.grdCambios.TabIndex = 11
        '
        'btnReloadCambios
        '
        Me.btnReloadCambios.FlatAppearance.BorderSize = 0
        Me.btnReloadCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReloadCambios.Image = Global.CENPROFAR.My.Resources.Resources.change
        Me.btnReloadCambios.Location = New System.Drawing.Point(695, 11)
        Me.btnReloadCambios.Name = "btnReloadCambios"
        Me.btnReloadCambios.Size = New System.Drawing.Size(26, 25)
        Me.btnReloadCambios.TabIndex = 12
        Me.btnReloadCambios.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(358, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Cambios"
        '
        'frmDeveloper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 546)
        Me.Controls.Add(Me.tbPanel)
        Me.Controls.Add(Me.gbUser)
        Me.Name = "frmDeveloper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pantalla Desarrollador"
        Me.gbUser.ResumeLayout(False)
        Me.gbUser.PerformLayout()
        Me.TCResults.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.grdResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.tbPanel.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.grdCambios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbUser As GroupBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnIniciar As Button
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblUser As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUser As TextBox
    Friend WithEvents btnRun As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtQuery As TextBox
    Friend WithEvents TCResults As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents grdResult As DataGridView
    Friend WithEvents txtResult As TextBox
    Friend WithEvents tbPanel As TabControl
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label4 As Label
    Friend WithEvents btnActualizarTodo As Button
    Friend WithEvents btnTruncateAll As Button
    Friend WithEvents btnActualizar As Button
    Friend WithEvents cmbTablasWeb As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtUtilsResponse As TextBox
    Friend WithEvents btnTruncate As Button
    Friend WithEvents pgProgreso As ProgressBar
    Friend WithEvents Label5 As Label
    Friend WithEvents btnReloadCambios As Button
    Friend WithEvents grdCambios As DataGridView
End Class
