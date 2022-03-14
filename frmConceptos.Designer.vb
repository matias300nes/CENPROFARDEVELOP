
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConceptos

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConceptos))
        Me.chkEliminados = New System.Windows.Forms.CheckBox()
        Me.txtID = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCODIGO = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.cmbConceptoPago = New System.Windows.Forms.ComboBox()
        Me.cmbPerteneceA = New System.Windows.Forms.ComboBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.cmbTipoValor = New System.Windows.Forms.ComboBox()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.cmbCamposAplicables = New System.Windows.Forms.ComboBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
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
        Me.chkEliminados.Location = New System.Drawing.Point(640, 83)
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
        Me.txtID.Location = New System.Drawing.Point(89, -3)
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
        Me.Label1.Location = New System.Drawing.Point(67, 0)
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
        Me.GroupPanel1.Controls.Add(Me.Label4)
        Me.GroupPanel1.Controls.Add(Me.Label15)
        Me.GroupPanel1.Controls.Add(Me.Label14)
        Me.GroupPanel1.Controls.Add(Me.Label13)
        Me.GroupPanel1.Controls.Add(Me.chkEliminados)
        Me.GroupPanel1.Controls.Add(Me.Label12)
        Me.GroupPanel1.Controls.Add(Me.txtID)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.Label10)
        Me.GroupPanel1.Controls.Add(Me.Label9)
        Me.GroupPanel1.Controls.Add(Me.Label11)
        Me.GroupPanel1.Controls.Add(Me.txtCODIGO)
        Me.GroupPanel1.Controls.Add(Me.cmbConceptoPago)
        Me.GroupPanel1.Controls.Add(Me.cmbPerteneceA)
        Me.GroupPanel1.Controls.Add(Me.txtNombre)
        Me.GroupPanel1.Controls.Add(Me.cmbTipoValor)
        Me.GroupPanel1.Controls.Add(Me.txtValor)
        Me.GroupPanel1.Controls.Add(Me.cmbCamposAplicables)
        Me.GroupPanel1.Controls.Add(Me.txtDescripcion)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(11, 29)
        Me.GroupPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(795, 145)
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
        Me.Label4.Location = New System.Drawing.Point(23, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 276
        Me.Label4.Text = "Código"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(346, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 275
        Me.Label15.Text = "Descripción"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(612, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 13)
        Me.Label14.TabIndex = 274
        Me.Label14.Text = "Concepto de pago*"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(23, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 13)
        Me.Label13.TabIndex = 273
        Me.Label13.Text = "Pertenece a:*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(176, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 272
        Me.Label12.Text = "Tipo valor:*"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(300, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 271
        Me.Label10.Text = "Valor*"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(444, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 13)
        Me.Label9.TabIndex = 270
        Me.Label9.Text = "Campos aplicables:*"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(135, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 268
        Me.Label11.Text = "Nombre*"
        '
        'txtCODIGO
        '
        Me.txtCODIGO.AccessibleName = ""
        Me.txtCODIGO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCODIGO.Decimals = CType(2, Byte)
        Me.txtCODIGO.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCODIGO.Enabled = False
        Me.txtCODIGO.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtCODIGO.Location = New System.Drawing.Point(25, 38)
        Me.txtCODIGO.MaxLength = 25
        Me.txtCODIGO.Name = "txtCODIGO"
        Me.txtCODIGO.Size = New System.Drawing.Size(100, 20)
        Me.txtCODIGO.TabIndex = 0
        Me.txtCODIGO.Text_1 = Nothing
        Me.txtCODIGO.Text_2 = Nothing
        Me.txtCODIGO.Text_3 = Nothing
        Me.txtCODIGO.Text_4 = Nothing
        Me.txtCODIGO.UserValues = Nothing
        '
        'cmbConceptoPago
        '
        Me.cmbConceptoPago.AccessibleName = "*Concepto Pago"
        Me.cmbConceptoPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbConceptoPago.FormattingEnabled = True
        Me.cmbConceptoPago.Location = New System.Drawing.Point(614, 36)
        Me.cmbConceptoPago.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbConceptoPago.Name = "cmbConceptoPago"
        Me.cmbConceptoPago.Size = New System.Drawing.Size(135, 21)
        Me.cmbConceptoPago.TabIndex = 3
        '
        'cmbPerteneceA
        '
        Me.cmbPerteneceA.AccessibleName = "*Pertenece a"
        Me.cmbPerteneceA.FormattingEnabled = True
        Me.cmbPerteneceA.Location = New System.Drawing.Point(26, 82)
        Me.cmbPerteneceA.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbPerteneceA.Name = "cmbPerteneceA"
        Me.cmbPerteneceA.Size = New System.Drawing.Size(137, 21)
        Me.cmbPerteneceA.TabIndex = 4
        '
        'txtNombre
        '
        Me.txtNombre.AccessibleName = "*Nombre"
        Me.txtNombre.Location = New System.Drawing.Point(137, 37)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(197, 20)
        Me.txtNombre.TabIndex = 1
        '
        'cmbTipoValor
        '
        Me.cmbTipoValor.AccessibleName = "*Tipo Valor"
        Me.cmbTipoValor.FormattingEnabled = True
        Me.cmbTipoValor.Location = New System.Drawing.Point(178, 82)
        Me.cmbTipoValor.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbTipoValor.Name = "cmbTipoValor"
        Me.cmbTipoValor.Size = New System.Drawing.Size(109, 21)
        Me.cmbTipoValor.TabIndex = 5
        '
        'txtValor
        '
        Me.txtValor.AccessibleName = "*Valor"
        Me.txtValor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtValor.Location = New System.Drawing.Point(303, 81)
        Me.txtValor.Margin = New System.Windows.Forms.Padding(2)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(125, 20)
        Me.txtValor.TabIndex = 6
        '
        'cmbCamposAplicables
        '
        Me.cmbCamposAplicables.AccessibleName = "*Campos Aplicables"
        Me.cmbCamposAplicables.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCamposAplicables.FormattingEnabled = True
        Me.cmbCamposAplicables.Location = New System.Drawing.Point(444, 80)
        Me.cmbCamposAplicables.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbCamposAplicables.Name = "cmbCamposAplicables"
        Me.cmbCamposAplicables.Size = New System.Drawing.Size(173, 21)
        Me.cmbCamposAplicables.TabIndex = 7
        '
        'txtDescripcion
        '
        Me.txtDescripcion.AccessibleName = ""
        Me.txtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcion.Location = New System.Drawing.Point(348, 37)
        Me.txtDescripcion.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(251, 20)
        Me.txtDescripcion.TabIndex = 2
        '
        'frmConceptos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 504)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(750, 400)
        Me.Name = "frmConceptos"
        Me.Text = "Conceptos"
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
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbConceptoPago As ComboBox
    Friend WithEvents cmbPerteneceA As ComboBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents cmbTipoValor As ComboBox
    Friend WithEvents txtValor As TextBox
    Friend WithEvents cmbCamposAplicables As ComboBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCODIGO As TextBoxConFormatoVB.FormattedTextBoxVB
End Class