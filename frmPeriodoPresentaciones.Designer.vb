
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPeriodoPresentaciones

    Inherits frmBase

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub


    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPeriodoPresentaciones))
        Me.chkEliminados = New System.Windows.Forms.CheckBox()
        Me.txtID = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GbPeriodo = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.LbPeriodo_Mes = New System.Windows.Forms.ListBox()
        Me.LbPeriodo_año = New System.Windows.Forms.ListBox()
        Me.LbPeriodo_parte = New System.Windows.Forms.ListBox()
        Me.cmbGrupos = New System.Windows.Forms.ComboBox()
        Me.dtpFechaLimite = New System.Windows.Forms.DateTimePicker()
        Me.btnPeriodo = New DevComponents.DotNetBar.ButtonX()
        Me.txtPeriodo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCODIGO = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.cmbMandatarias = New System.Windows.Forms.ComboBox()
        Me.GroupPanel1.SuspendLayout()
        Me.GbPeriodo.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkEliminados
        '
        Me.chkEliminados.AutoSize = True
        Me.chkEliminados.BackColor = System.Drawing.Color.Transparent
        Me.chkEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEliminados.ForeColor = System.Drawing.Color.Red
        Me.chkEliminados.Location = New System.Drawing.Point(744, 71)
        Me.chkEliminados.Name = "chkEliminados"
        Me.chkEliminados.Size = New System.Drawing.Size(109, 17)
        Me.chkEliminados.TabIndex = 257
        Me.chkEliminados.Text = "Ver Eliminados"
        Me.chkEliminados.UseVisualStyleBackColor = False
        '
        'txtID
        '
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.Decimals = CType(2, Byte)
        Me.txtID.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtID.Enabled = False
        Me.txtID.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtID.Location = New System.Drawing.Point(111, 11)
        Me.txtID.MaxLength = 8
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(16, 20)
        Me.txtID.TabIndex = 50
        Me.txtID.Text_1 = Nothing
        Me.txtID.Text_2 = Nothing
        Me.txtID.Text_3 = Nothing
        Me.txtID.Text_4 = Nothing
        Me.txtID.UserValues = Nothing
        Me.txtID.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(112, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Id"
        Me.Label1.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.GbPeriodo)
        Me.GroupPanel1.Controls.Add(Me.cmbGrupos)
        Me.GroupPanel1.Controls.Add(Me.dtpFechaLimite)
        Me.GroupPanel1.Controls.Add(Me.btnPeriodo)
        Me.GroupPanel1.Controls.Add(Me.txtPeriodo)
        Me.GroupPanel1.Controls.Add(Me.Label4)
        Me.GroupPanel1.Controls.Add(Me.Label14)
        Me.GroupPanel1.Controls.Add(Me.Label13)
        Me.GroupPanel1.Controls.Add(Me.chkEliminados)
        Me.GroupPanel1.Controls.Add(Me.Label12)
        Me.GroupPanel1.Controls.Add(Me.txtID)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.Label11)
        Me.GroupPanel1.Controls.Add(Me.txtCODIGO)
        Me.GroupPanel1.Controls.Add(Me.cmbMandatarias)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 25)
        Me.GroupPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(876, 186)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 258
        '
        'GbPeriodo
        '
        Me.GbPeriodo.Controls.Add(Me.Button2)
        Me.GbPeriodo.Controls.Add(Me.LbPeriodo_Mes)
        Me.GbPeriodo.Controls.Add(Me.LbPeriodo_año)
        Me.GbPeriodo.Controls.Add(Me.LbPeriodo_parte)
        Me.GbPeriodo.Location = New System.Drawing.Point(446, 49)
        Me.GbPeriodo.Name = "GbPeriodo"
        Me.GbPeriodo.Size = New System.Drawing.Size(238, 128)
        Me.GbPeriodo.TabIndex = 360
        Me.GbPeriodo.TabStop = False
        Me.GbPeriodo.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(192, 99)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(35, 23)
        Me.Button2.TabIndex = 358
        Me.Button2.Text = "Ok"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'LbPeriodo_Mes
        '
        Me.LbPeriodo_Mes.FormattingEnabled = True
        Me.LbPeriodo_Mes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMPRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.LbPeriodo_Mes.Location = New System.Drawing.Point(83, 13)
        Me.LbPeriodo_Mes.Name = "LbPeriodo_Mes"
        Me.LbPeriodo_Mes.Size = New System.Drawing.Size(71, 82)
        Me.LbPeriodo_Mes.TabIndex = 357
        '
        'LbPeriodo_año
        '
        Me.LbPeriodo_año.FormattingEnabled = True
        Me.LbPeriodo_año.Items.AddRange(New Object() {"2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027"})
        Me.LbPeriodo_año.Location = New System.Drawing.Point(160, 13)
        Me.LbPeriodo_año.Name = "LbPeriodo_año"
        Me.LbPeriodo_año.Size = New System.Drawing.Size(72, 82)
        Me.LbPeriodo_año.TabIndex = 356
        '
        'LbPeriodo_parte
        '
        Me.LbPeriodo_parte.FormattingEnabled = True
        Me.LbPeriodo_parte.Items.AddRange(New Object() {"1°Q", "2°Q", "MENSUAL"})
        Me.LbPeriodo_parte.Location = New System.Drawing.Point(5, 13)
        Me.LbPeriodo_parte.Name = "LbPeriodo_parte"
        Me.LbPeriodo_parte.ScrollAlwaysVisible = True
        Me.LbPeriodo_parte.Size = New System.Drawing.Size(70, 82)
        Me.LbPeriodo_parte.TabIndex = 355
        '
        'cmbGrupos
        '
        Me.cmbGrupos.AccessibleName = "*Grupo"
        Me.cmbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupos.FormattingEnabled = True
        Me.cmbGrupos.Location = New System.Drawing.Point(355, 29)
        Me.cmbGrupos.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbGrupos.Name = "cmbGrupos"
        Me.cmbGrupos.Size = New System.Drawing.Size(80, 21)
        Me.cmbGrupos.TabIndex = 359
        '
        'dtpFechaLimite
        '
        Me.dtpFechaLimite.AccessibleName = "*Fecha"
        Me.dtpFechaLimite.Location = New System.Drawing.Point(702, 30)
        Me.dtpFechaLimite.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpFechaLimite.Name = "dtpFechaLimite"
        Me.dtpFechaLimite.Size = New System.Drawing.Size(151, 20)
        Me.dtpFechaLimite.TabIndex = 358
        '
        'btnPeriodo
        '
        Me.btnPeriodo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPeriodo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPeriodo.Image = CType(resources.GetObject("btnPeriodo.Image"), System.Drawing.Image)
        Me.btnPeriodo.Location = New System.Drawing.Point(664, 31)
        Me.btnPeriodo.Name = "btnPeriodo"
        Me.btnPeriodo.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btnPeriodo.Size = New System.Drawing.Size(16, 16)
        Me.btnPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPeriodo.TabIndex = 357
        '
        'txtPeriodo
        '
        Me.txtPeriodo.AccessibleName = "*Periodo"
        Me.txtPeriodo.BackColor = System.Drawing.SystemColors.Window
        Me.txtPeriodo.Location = New System.Drawing.Point(446, 28)
        Me.txtPeriodo.Multiline = True
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ReadOnly = True
        Me.txtPeriodo.Size = New System.Drawing.Size(238, 22)
        Me.txtPeriodo.TabIndex = 355
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(3, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 276
        Me.Label4.Text = "Código"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(352, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 274
        Me.Label14.Text = "Grupo*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(443, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 13)
        Me.Label13.TabIndex = 273
        Me.Label13.Text = "Periodo*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(700, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 13)
        Me.Label12.TabIndex = 272
        Me.Label12.Text = "Fecha Límite*"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(147, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 268
        Me.Label11.Text = "Mandataria*"
        '
        'txtCODIGO
        '
        Me.txtCODIGO.AccessibleName = ""
        Me.txtCODIGO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCODIGO.Decimals = CType(2, Byte)
        Me.txtCODIGO.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCODIGO.Enabled = False
        Me.txtCODIGO.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtCODIGO.Location = New System.Drawing.Point(5, 29)
        Me.txtCODIGO.MaxLength = 25
        Me.txtCODIGO.Name = "txtCODIGO"
        Me.txtCODIGO.Size = New System.Drawing.Size(140, 20)
        Me.txtCODIGO.TabIndex = 0
        Me.txtCODIGO.Text_1 = Nothing
        Me.txtCODIGO.Text_2 = Nothing
        Me.txtCODIGO.Text_3 = Nothing
        Me.txtCODIGO.Text_4 = Nothing
        Me.txtCODIGO.UserValues = Nothing
        '
        'cmbMandatarias
        '
        Me.cmbMandatarias.AccessibleName = "*Mandataria"
        Me.cmbMandatarias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMandatarias.FormattingEnabled = True
        Me.cmbMandatarias.Location = New System.Drawing.Point(149, 28)
        Me.cmbMandatarias.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbMandatarias.Name = "cmbMandatarias"
        Me.cmbMandatarias.Size = New System.Drawing.Size(199, 21)
        Me.cmbMandatarias.TabIndex = 7
        '
        'frmPeriodoPresentaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(893, 432)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmPeriodoPresentaciones"
        Me.Text = "Periodo Presentaciones"
        Me.Controls.SetChildIndex(Me.GroupPanel1, 0)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GbPeriodo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub



    Friend WithEvents txtID As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkEliminados As System.Windows.Forms.CheckBox
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbMandatarias As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCODIGO As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents txtPeriodo As TextBox
    Friend WithEvents btnPeriodo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dtpFechaLimite As DateTimePicker
    Friend WithEvents cmbGrupos As ComboBox
    Friend WithEvents GbPeriodo As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents LbPeriodo_Mes As ListBox
    Friend WithEvents LbPeriodo_año As ListBox
    Friend WithEvents LbPeriodo_parte As ListBox
End Class