
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPlanes

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanes))
        Me.chkEliminados = New System.Windows.Forms.CheckBox()
        Me.txtID = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCODIGO = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtPorcentaje = New System.Windows.Forms.TextBox()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkEliminados
        '
        Me.chkEliminados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkEliminados.AutoSize = True
        Me.chkEliminados.BackColor = System.Drawing.Color.Transparent
        Me.chkEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEliminados.ForeColor = System.Drawing.Color.Red
        Me.chkEliminados.Location = New System.Drawing.Point(464, 57)
        Me.chkEliminados.Margin = New System.Windows.Forms.Padding(4)
        Me.chkEliminados.Name = "chkEliminados"
        Me.chkEliminados.Size = New System.Drawing.Size(138, 21)
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
        Me.txtID.Location = New System.Drawing.Point(121, 4)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtID.MaxLength = 8
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(20, 22)
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
        Me.Label1.Location = New System.Drawing.Point(91, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 17)
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
        Me.GroupPanel1.Controls.Add(Me.Label4)
        Me.GroupPanel1.Controls.Add(Me.Label15)
        Me.GroupPanel1.Controls.Add(Me.chkEliminados)
        Me.GroupPanel1.Controls.Add(Me.txtID)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.Label11)
        Me.GroupPanel1.Controls.Add(Me.txtCODIGO)
        Me.GroupPanel1.Controls.Add(Me.txtNombre)
        Me.GroupPanel1.Controls.Add(Me.txtPorcentaje)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(15, 36)
        Me.GroupPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(645, 91)
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(31, 9)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 17)
        Me.Label4.TabIndex = 276
        Me.Label4.Text = "Código"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(461, 8)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 17)
        Me.Label15.TabIndex = 275
        Me.Label15.Text = "Porcentaje"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(180, 8)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 17)
        Me.Label11.TabIndex = 268
        Me.Label11.Text = "Nombre*"
        '
        'txtCODIGO
        '
        Me.txtCODIGO.AccessibleName = ""
        Me.txtCODIGO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCODIGO.Decimals = CType(2, Byte)
        Me.txtCODIGO.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCODIGO.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtCODIGO.Location = New System.Drawing.Point(33, 30)
        Me.txtCODIGO.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCODIGO.MaxLength = 25
        Me.txtCODIGO.Name = "txtCODIGO"
        Me.txtCODIGO.Size = New System.Drawing.Size(132, 22)
        Me.txtCODIGO.TabIndex = 0
        Me.txtCODIGO.Text_1 = Nothing
        Me.txtCODIGO.Text_2 = Nothing
        Me.txtCODIGO.Text_3 = Nothing
        Me.txtCODIGO.Text_4 = Nothing
        Me.txtCODIGO.UserValues = Nothing
        '
        'txtNombre
        '
        Me.txtNombre.AccessibleName = "*Nombre"
        Me.txtNombre.Location = New System.Drawing.Point(183, 29)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(261, 22)
        Me.txtNombre.TabIndex = 1
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.AccessibleName = ""
        Me.txtPorcentaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPorcentaje.Location = New System.Drawing.Point(464, 29)
        Me.txtPorcentaje.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(104, 22)
        Me.txtPorcentaje.TabIndex = 2
        '
        'frmPlanes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 620)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MinimumSize = New System.Drawing.Size(600, 600)
        Me.Name = "frmPlanes"
        Me.Text = "Planes"
        Me.Controls.SetChildIndex(Me.GroupPanel1, 0)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub



    Friend WithEvents txtID As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkEliminados As System.Windows.Forms.CheckBox
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label15 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtPorcentaje As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCODIGO As TextBoxConFormatoVB.FormattedTextBoxVB
End Class