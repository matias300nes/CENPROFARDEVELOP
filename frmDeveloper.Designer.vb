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
        Me.gbPanel = New System.Windows.Forms.GroupBox()
        Me.TCResults = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQuery = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.grdResult = New System.Windows.Forms.DataGridView()
        Me.gbUser.SuspendLayout()
        Me.gbPanel.SuspendLayout()
        Me.TCResults.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdResult, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'gbPanel
        '
        Me.gbPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPanel.Controls.Add(Me.Label3)
        Me.gbPanel.Controls.Add(Me.Label2)
        Me.gbPanel.Controls.Add(Me.ComboBox2)
        Me.gbPanel.Controls.Add(Me.ComboBox1)
        Me.gbPanel.Controls.Add(Me.TCResults)
        Me.gbPanel.Controls.Add(Me.btnRun)
        Me.gbPanel.Controls.Add(Me.Label1)
        Me.gbPanel.Controls.Add(Me.txtQuery)
        Me.gbPanel.Location = New System.Drawing.Point(12, 95)
        Me.gbPanel.Name = "gbPanel"
        Me.gbPanel.Size = New System.Drawing.Size(776, 426)
        Me.gbPanel.TabIndex = 1
        Me.gbPanel.TabStop = False
        Me.gbPanel.Text = "Panel"
        Me.gbPanel.Visible = False
        '
        'TCResults
        '
        Me.TCResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TCResults.Controls.Add(Me.TabPage1)
        Me.TCResults.Controls.Add(Me.TabPage2)
        Me.TCResults.Location = New System.Drawing.Point(22, 239)
        Me.TCResults.Name = "TCResults"
        Me.TCResults.SelectedIndex = 0
        Me.TCResults.Size = New System.Drawing.Size(730, 169)
        Me.TCResults.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grdResult)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(722, 143)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Table"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtResult)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(722, 143)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "XML"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnRun
        '
        Me.btnRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRun.Location = New System.Drawing.Point(702, 27)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(49, 23)
        Me.btnRun.TabIndex = 4
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Query"
        '
        'txtQuery
        '
        Me.txtQuery.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuery.Location = New System.Drawing.Point(22, 55)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.Size = New System.Drawing.Size(730, 167)
        Me.txtQuery.TabIndex = 0
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Local", "Web"})
        Me.ComboBox1.Location = New System.Drawing.Point(426, 29)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 6
        '
        'ComboBox2
        '
        Me.ComboBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Sql_Get"})
        Me.ComboBox2.Location = New System.Drawing.Point(564, 29)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox2.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(423, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Server"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(561, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Method"
        '
        'txtResult
        '
        Me.txtResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtResult.Location = New System.Drawing.Point(3, 3)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(716, 137)
        Me.txtResult.TabIndex = 10
        '
        'grdResult
        '
        Me.grdResult.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.grdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdResult.Location = New System.Drawing.Point(3, 3)
        Me.grdResult.Name = "grdResult"
        Me.grdResult.Size = New System.Drawing.Size(716, 137)
        Me.grdResult.TabIndex = 0
        '
        'frmDeveloper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 546)
        Me.Controls.Add(Me.gbPanel)
        Me.Controls.Add(Me.gbUser)
        Me.Name = "frmDeveloper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pantalla Desarrollador"
        Me.gbUser.ResumeLayout(False)
        Me.gbUser.PerformLayout()
        Me.gbPanel.ResumeLayout(False)
        Me.gbPanel.PerformLayout()
        Me.TCResults.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.grdResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbUser As GroupBox
    Friend WithEvents gbPanel As GroupBox
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
End Class
