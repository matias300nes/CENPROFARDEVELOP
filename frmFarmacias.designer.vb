<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFarmacias

    Inherits frmBase

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub


    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtID = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCODIGO = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFarmacia = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.cmbProvincia = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.chkEliminados = New System.Windows.Forms.CheckBox()
        Me.cmbLocalidad = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCodigoPostal = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDomicilio = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTipoContribuyente = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCuit = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbEstado = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtMotivoBaja = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTelefono = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEmail = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodFACAF = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.txtCodPAMI = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtID
        '
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.Decimals = CType(2, Byte)
        Me.txtID.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtID.Enabled = False
        Me.txtID.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtID.Location = New System.Drawing.Point(414, -2)
        Me.txtID.MaxLength = 8
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(69, 20)
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
        Me.Label1.Location = New System.Drawing.Point(418, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Id"
        Me.Label1.Visible = False
        '
        'txtCODIGO
        '
        Me.txtCODIGO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCODIGO.Decimals = CType(2, Byte)
        Me.txtCODIGO.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCODIGO.Enabled = False
        Me.txtCODIGO.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtCODIGO.Location = New System.Drawing.Point(5, 27)
        Me.txtCODIGO.MaxLength = 25
        Me.txtCODIGO.Name = "txtCODIGO"
        Me.txtCODIGO.ReadOnly = True
        Me.txtCODIGO.Size = New System.Drawing.Size(78, 20)
        Me.txtCODIGO.TabIndex = 0
        Me.txtCODIGO.Text_1 = Nothing
        Me.txtCODIGO.Text_2 = Nothing
        Me.txtCODIGO.Text_3 = Nothing
        Me.txtCODIGO.Text_4 = Nothing
        Me.txtCODIGO.UserValues = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(3, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Código"
        '
        'txtFarmacia
        '
        Me.txtFarmacia.AccessibleName = "*Nombre"
        Me.txtFarmacia.Decimals = CType(2, Byte)
        Me.txtFarmacia.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtFarmacia.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtFarmacia.Location = New System.Drawing.Point(254, 27)
        Me.txtFarmacia.MaxLength = 50
        Me.txtFarmacia.Name = "txtFarmacia"
        Me.txtFarmacia.Size = New System.Drawing.Size(266, 20)
        Me.txtFarmacia.TabIndex = 1
        Me.txtFarmacia.Text_1 = Nothing
        Me.txtFarmacia.Text_2 = Nothing
        Me.txtFarmacia.Text_3 = Nothing
        Me.txtFarmacia.Text_4 = Nothing
        Me.txtFarmacia.UserValues = Nothing
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(251, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Nombre*"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupBox1.Controls.Add(Me.cmbProvincia)
        Me.GroupBox1.Controls.Add(Me.chkEliminados)
        Me.GroupBox1.Controls.Add(Me.cmbLocalidad)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtCodigoPostal)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDomicilio)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtTipoContribuyente)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtCuit)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtTelefono)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCodFACAF)
        Me.GroupBox1.Controls.Add(Me.txtCodPAMI)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.txtCODIGO)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtFarmacia)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1147, 134)
        '
        '
        '
        Me.GroupBox1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupBox1.Style.BackColorGradientAngle = 90
        Me.GroupBox1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupBox1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox1.Style.BorderBottomWidth = 1
        Me.GroupBox1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupBox1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox1.Style.BorderLeftWidth = 1
        Me.GroupBox1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox1.Style.BorderRightWidth = 1
        Me.GroupBox1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox1.Style.BorderTopWidth = 1
        Me.GroupBox1.Style.CornerDiameter = 4
        Me.GroupBox1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupBox1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupBox1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupBox1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupBox1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupBox1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupBox1.TabIndex = 64
        '
        'cmbProvincia
        '
        Me.cmbProvincia.DisplayMember = "Text"
        Me.cmbProvincia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.ItemHeight = 16
        Me.cmbProvincia.Location = New System.Drawing.Point(525, 76)
        Me.cmbProvincia.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(195, 22)
        Me.cmbProvincia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbProvincia.TabIndex = 293
        '
        'chkEliminados
        '
        Me.chkEliminados.AutoSize = True
        Me.chkEliminados.BackColor = System.Drawing.Color.Transparent
        Me.chkEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEliminados.ForeColor = System.Drawing.Color.Red
        Me.chkEliminados.Location = New System.Drawing.Point(1000, 109)
        Me.chkEliminados.Name = "chkEliminados"
        Me.chkEliminados.Size = New System.Drawing.Size(109, 17)
        Me.chkEliminados.TabIndex = 256
        Me.chkEliminados.Text = "Ver Eliminados"
        Me.chkEliminados.UseVisualStyleBackColor = False
        '
        'cmbLocalidad
        '
        Me.cmbLocalidad.AccessibleName = "*Localidad"
        Me.cmbLocalidad.DisplayMember = "Text"
        Me.cmbLocalidad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbLocalidad.FormattingEnabled = True
        Me.cmbLocalidad.ItemHeight = 16
        Me.cmbLocalidad.Location = New System.Drawing.Point(724, 77)
        Me.cmbLocalidad.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbLocalidad.Name = "cmbLocalidad"
        Me.cmbLocalidad.Size = New System.Drawing.Size(194, 22)
        Me.cmbLocalidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbLocalidad.TabIndex = 292
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(824, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 291
        Me.Label9.Text = "Código Postal"
        '
        'txtCodigoPostal
        '
        Me.txtCodigoPostal.AccessibleName = ""
        Me.txtCodigoPostal.Decimals = CType(2, Byte)
        Me.txtCodigoPostal.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCodigoPostal.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtCodigoPostal.Location = New System.Drawing.Point(826, 27)
        Me.txtCodigoPostal.MaxLength = 50
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        Me.txtCodigoPostal.Size = New System.Drawing.Size(91, 20)
        Me.txtCodigoPostal.TabIndex = 290
        Me.txtCodigoPostal.Text_1 = Nothing
        Me.txtCodigoPostal.Text_2 = Nothing
        Me.txtCodigoPostal.Text_3 = Nothing
        Me.txtCodigoPostal.Text_4 = Nothing
        Me.txtCodigoPostal.UserValues = Nothing
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(722, 61)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 289
        Me.Label8.Text = "Localidad*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(523, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 288
        Me.Label7.Text = "Provincia*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(635, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 287
        Me.Label6.Text = "Domicilio"
        '
        'txtDomicilio
        '
        Me.txtDomicilio.AccessibleName = ""
        Me.txtDomicilio.Decimals = CType(2, Byte)
        Me.txtDomicilio.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtDomicilio.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtDomicilio.Location = New System.Drawing.Point(638, 27)
        Me.txtDomicilio.MaxLength = 100
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(183, 20)
        Me.txtDomicilio.TabIndex = 286
        Me.txtDomicilio.Text_1 = Nothing
        Me.txtDomicilio.Text_2 = Nothing
        Me.txtDomicilio.Text_3 = Nothing
        Me.txtDomicilio.Text_4 = Nothing
        Me.txtDomicilio.UserValues = Nothing
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(394, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 13)
        Me.Label10.TabIndex = 285
        Me.Label10.Text = "Tipo Contribuyente"
        '
        'txtTipoContribuyente
        '
        Me.txtTipoContribuyente.AccessibleName = ""
        Me.txtTipoContribuyente.Decimals = CType(2, Byte)
        Me.txtTipoContribuyente.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtTipoContribuyente.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtTipoContribuyente.Location = New System.Drawing.Point(396, 76)
        Me.txtTipoContribuyente.MaxLength = 50
        Me.txtTipoContribuyente.Name = "txtTipoContribuyente"
        Me.txtTipoContribuyente.Size = New System.Drawing.Size(120, 20)
        Me.txtTipoContribuyente.TabIndex = 284
        Me.txtTipoContribuyente.Text_1 = Nothing
        Me.txtTipoContribuyente.Text_2 = Nothing
        Me.txtTipoContribuyente.Text_3 = Nothing
        Me.txtTipoContribuyente.Text_4 = Nothing
        Me.txtTipoContribuyente.UserValues = Nothing
        '
        'Label15
        '
        Me.Label15.AccessibleName = ""
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(523, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 13)
        Me.Label15.TabIndex = 283
        Me.Label15.Text = "Cuit*"
        '
        'txtCuit
        '
        Me.txtCuit.AccessibleName = "*Cuit"
        Me.txtCuit.Decimals = CType(2, Byte)
        Me.txtCuit.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCuit.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtCuit.Location = New System.Drawing.Point(525, 27)
        Me.txtCuit.MaxLength = 11
        Me.txtCuit.Name = "txtCuit"
        Me.txtCuit.Size = New System.Drawing.Size(108, 20)
        Me.txtCuit.TabIndex = 282
        Me.txtCuit.Text_1 = Nothing
        Me.txtCuit.Text_2 = Nothing
        Me.txtCuit.Text_3 = Nothing
        Me.txtCuit.Text_4 = Nothing
        Me.txtCuit.UserValues = Nothing
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.cmbEstado)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.txtMotivoBaja)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Location = New System.Drawing.Point(921, 2)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(183, 101)
        Me.Panel3.TabIndex = 281
        '
        'cmbEstado
        '
        Me.cmbEstado.DisplayMember = "Text"
        Me.cmbEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.ItemHeight = 16
        Me.cmbEstado.Location = New System.Drawing.Point(13, 24)
        Me.cmbEstado.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(160, 22)
        Me.cmbEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbEstado.TabIndex = 281
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(10, 57)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 278
        Me.Label13.Text = "Motivo Baja"
        '
        'txtMotivoBaja
        '
        Me.txtMotivoBaja.AccessibleName = ""
        Me.txtMotivoBaja.Decimals = CType(2, Byte)
        Me.txtMotivoBaja.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtMotivoBaja.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtMotivoBaja.Location = New System.Drawing.Point(13, 73)
        Me.txtMotivoBaja.MaxLength = 100
        Me.txtMotivoBaja.Name = "txtMotivoBaja"
        Me.txtMotivoBaja.Size = New System.Drawing.Size(160, 20)
        Me.txtMotivoBaja.TabIndex = 277
        Me.txtMotivoBaja.Text_1 = Nothing
        Me.txtMotivoBaja.Text_2 = Nothing
        Me.txtMotivoBaja.Text_3 = Nothing
        Me.txtMotivoBaja.Text_4 = Nothing
        Me.txtMotivoBaja.UserValues = Nothing
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(10, 6)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 13)
        Me.Label17.TabIndex = 272
        Me.Label17.Text = "Estado:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(3, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 269
        Me.Label12.Text = "Teléfono"
        '
        'txtTelefono
        '
        Me.txtTelefono.AccessibleName = ""
        Me.txtTelefono.Decimals = CType(2, Byte)
        Me.txtTelefono.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtTelefono.Format = TextBoxConFormatoVB.tbFormats.SignedNumber
        Me.txtTelefono.Location = New System.Drawing.Point(5, 77)
        Me.txtTelefono.MaxLength = 50
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(162, 20)
        Me.txtTelefono.TabIndex = 268
        Me.txtTelefono.Text_1 = Nothing
        Me.txtTelefono.Text_2 = Nothing
        Me.txtTelefono.Text_3 = Nothing
        Me.txtTelefono.Text_4 = Nothing
        Me.txtTelefono.UserValues = Nothing
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(169, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 13)
        Me.Label11.TabIndex = 267
        Me.Label11.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.AccessibleName = ""
        Me.txtEmail.Decimals = CType(2, Byte)
        Me.txtEmail.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtEmail.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtEmail.Location = New System.Drawing.Point(170, 77)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(221, 20)
        Me.txtEmail.TabIndex = 266
        Me.txtEmail.Text_1 = Nothing
        Me.txtEmail.Text_2 = Nothing
        Me.txtEmail.Text_3 = Nothing
        Me.txtEmail.Text_4 = Nothing
        Me.txtEmail.UserValues = Nothing
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(88, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 260
        Me.Label5.Text = "Cod. Facaf"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(169, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 259
        Me.Label4.Text = "Cod. Pami"
        '
        'txtCodFACAF
        '
        Me.txtCodFACAF.AccessibleName = ""
        Me.txtCodFACAF.Decimals = CType(2, Byte)
        Me.txtCodFACAF.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCodFACAF.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtCodFACAF.Location = New System.Drawing.Point(88, 27)
        Me.txtCodFACAF.MaxLength = 50
        Me.txtCodFACAF.Name = "txtCodFACAF"
        Me.txtCodFACAF.Size = New System.Drawing.Size(78, 20)
        Me.txtCodFACAF.TabIndex = 258
        Me.txtCodFACAF.Text_1 = Nothing
        Me.txtCodFACAF.Text_2 = Nothing
        Me.txtCodFACAF.Text_3 = Nothing
        Me.txtCodFACAF.Text_4 = Nothing
        Me.txtCodFACAF.UserValues = Nothing
        '
        'txtCodPAMI
        '
        Me.txtCodPAMI.AccessibleName = ""
        Me.txtCodPAMI.Decimals = CType(2, Byte)
        Me.txtCodPAMI.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCodPAMI.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtCodPAMI.Location = New System.Drawing.Point(170, 27)
        Me.txtCodPAMI.MaxLength = 50
        Me.txtCodPAMI.Name = "txtCodPAMI"
        Me.txtCodPAMI.Size = New System.Drawing.Size(78, 20)
        Me.txtCodPAMI.TabIndex = 257
        Me.txtCodPAMI.Text_1 = Nothing
        Me.txtCodPAMI.Text_2 = Nothing
        Me.txtCodPAMI.Text_3 = Nothing
        Me.txtCodPAMI.Text_4 = Nothing
        Me.txtCodPAMI.UserValues = Nothing
        '
        'frmFarmacias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 434)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frmFarmacias"
        Me.Text = "Farmacias"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub




    Friend WithEvents txtID As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Friend WithEvents txtCODIGO As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label2 As System.Windows.Forms.Label

    Friend WithEvents txtFarmacia As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents chkEliminados As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCodFACAF As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents txtCodPAMI As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmbEstado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label13 As Label
    Friend WithEvents txtMotivoBaja As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label17 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTelefono As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label11 As Label
    Friend WithEvents txtEmail As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents cmbProvincia As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbLocalidad As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCodigoPostal As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDomicilio As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label10 As Label
    Friend WithEvents txtTipoContribuyente As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label15 As Label
    Friend WithEvents txtCuit As TextBoxConFormatoVB.FormattedTextBoxVB






End Class
