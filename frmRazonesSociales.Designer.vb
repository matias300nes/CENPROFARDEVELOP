
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRazonesSociales

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRazonesSociales))
        Me.chkEliminados = New System.Windows.Forms.CheckBox()
        Me.txtID = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.chkSociedad = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCbu = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBanco = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNroCuenta = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.txtCodigoPostal = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.cmbLocalidad = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cmbProvincia = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCuit = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTelefono = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmail = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.cmbPreferenciaPago = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCODIGO = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.txtNombre = New System.Windows.Forms.TextBox()
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
        Me.chkEliminados.Location = New System.Drawing.Point(835, 198)
        Me.chkEliminados.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
        Me.txtID.Location = New System.Drawing.Point(112, -4)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
        Me.Label1.Location = New System.Drawing.Point(83, 0)
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
        Me.GroupPanel1.Controls.Add(Me.chkSociedad)
        Me.GroupPanel1.Controls.Add(Me.Label13)
        Me.GroupPanel1.Controls.Add(Me.txtCbu)
        Me.GroupPanel1.Controls.Add(Me.Label10)
        Me.GroupPanel1.Controls.Add(Me.txtBanco)
        Me.GroupPanel1.Controls.Add(Me.Label14)
        Me.GroupPanel1.Controls.Add(Me.txtNroCuenta)
        Me.GroupPanel1.Controls.Add(Me.txtCodigoPostal)
        Me.GroupPanel1.Controls.Add(Me.cmbLocalidad)
        Me.GroupPanel1.Controls.Add(Me.cmbProvincia)
        Me.GroupPanel1.Controls.Add(Me.Label9)
        Me.GroupPanel1.Controls.Add(Me.Label7)
        Me.GroupPanel1.Controls.Add(Me.Label8)
        Me.GroupPanel1.Controls.Add(Me.Label6)
        Me.GroupPanel1.Controls.Add(Me.txtDomicilio)
        Me.GroupPanel1.Controls.Add(Me.Label2)
        Me.GroupPanel1.Controls.Add(Me.txtCuit)
        Me.GroupPanel1.Controls.Add(Me.Label12)
        Me.GroupPanel1.Controls.Add(Me.txtTelefono)
        Me.GroupPanel1.Controls.Add(Me.Label3)
        Me.GroupPanel1.Controls.Add(Me.txtEmail)
        Me.GroupPanel1.Controls.Add(Me.cmbPreferenciaPago)
        Me.GroupPanel1.Controls.Add(Me.Label5)
        Me.GroupPanel1.Controls.Add(Me.Label4)
        Me.GroupPanel1.Controls.Add(Me.chkEliminados)
        Me.GroupPanel1.Controls.Add(Me.txtID)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.Label11)
        Me.GroupPanel1.Controls.Add(Me.txtCODIGO)
        Me.GroupPanel1.Controls.Add(Me.txtNombre)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(15, 36)
        Me.GroupPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(993, 235)
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
        'chkSociedad
        '
        Me.chkSociedad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSociedad.AutoSize = True
        Me.chkSociedad.BackColor = System.Drawing.Color.Transparent
        Me.chkSociedad.Location = New System.Drawing.Point(867, 162)
        Me.chkSociedad.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkSociedad.Name = "chkSociedad"
        Me.chkSociedad.Size = New System.Drawing.Size(89, 21)
        Me.chkSociedad.TabIndex = 12
        Me.chkSociedad.Text = "Sociedad"
        Me.chkSociedad.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AccessibleName = ""
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(421, 142)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 17)
        Me.Label13.TabIndex = 311
        Me.Label13.Text = "CBU*"
        '
        'txtCbu
        '
        Me.txtCbu.AccessibleName = "*Cbu"
        Me.txtCbu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCbu.Decimals = CType(0, Byte)
        Me.txtCbu.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCbu.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtCbu.Location = New System.Drawing.Point(425, 161)
        Me.txtCbu.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCbu.MaxLength = 22
        Me.txtCbu.Name = "txtCbu"
        Me.txtCbu.Size = New System.Drawing.Size(199, 22)
        Me.txtCbu.TabIndex = 10
        Me.txtCbu.Text_1 = Nothing
        Me.txtCbu.Text_2 = Nothing
        Me.txtCbu.Text_3 = Nothing
        Me.txtCbu.Text_4 = Nothing
        Me.txtCbu.UserValues = Nothing
        '
        'Label10
        '
        Me.Label10.AccessibleName = ""
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(633, 142)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 17)
        Me.Label10.TabIndex = 309
        Me.Label10.Text = "Banco*"
        '
        'txtBanco
        '
        Me.txtBanco.AccessibleName = "*Banco"
        Me.txtBanco.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBanco.Decimals = CType(0, Byte)
        Me.txtBanco.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtBanco.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtBanco.Location = New System.Drawing.Point(637, 161)
        Me.txtBanco.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBanco.MaxLength = 22
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.Size = New System.Drawing.Size(209, 22)
        Me.txtBanco.TabIndex = 11
        Me.txtBanco.Text_1 = Nothing
        Me.txtBanco.Text_2 = Nothing
        Me.txtBanco.Text_3 = Nothing
        Me.txtBanco.Text_4 = Nothing
        Me.txtBanco.UserValues = Nothing
        '
        'Label14
        '
        Me.Label14.AccessibleName = ""
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(188, 142)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(105, 17)
        Me.Label14.TabIndex = 307
        Me.Label14.Text = "Nro de Cuenta*"
        '
        'txtNroCuenta
        '
        Me.txtNroCuenta.AccessibleName = "*Nro Cuenta"
        Me.txtNroCuenta.Decimals = CType(0, Byte)
        Me.txtNroCuenta.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtNroCuenta.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtNroCuenta.Location = New System.Drawing.Point(191, 161)
        Me.txtNroCuenta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNroCuenta.MaxLength = 22
        Me.txtNroCuenta.Name = "txtNroCuenta"
        Me.txtNroCuenta.Size = New System.Drawing.Size(219, 22)
        Me.txtNroCuenta.TabIndex = 9
        Me.txtNroCuenta.Text_1 = Nothing
        Me.txtNroCuenta.Text_2 = Nothing
        Me.txtNroCuenta.Text_3 = Nothing
        Me.txtNroCuenta.Text_4 = Nothing
        Me.txtNroCuenta.UserValues = Nothing
        '
        'txtCodigoPostal
        '
        Me.txtCodigoPostal.AccessibleName = "*Cod Postal"
        Me.txtCodigoPostal.Decimals = CType(2, Byte)
        Me.txtCodigoPostal.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCodigoPostal.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtCodigoPostal.Location = New System.Drawing.Point(28, 103)
        Me.txtCodigoPostal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCodigoPostal.MaxLength = 4
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        Me.txtCodigoPostal.Size = New System.Drawing.Size(77, 22)
        Me.txtCodigoPostal.TabIndex = 3
        Me.txtCodigoPostal.Text_1 = Nothing
        Me.txtCodigoPostal.Text_2 = Nothing
        Me.txtCodigoPostal.Text_3 = Nothing
        Me.txtCodigoPostal.Text_4 = Nothing
        Me.txtCodigoPostal.UserValues = Nothing
        '
        'cmbLocalidad
        '
        Me.cmbLocalidad.AccessibleName = "*Localidad"
        Me.cmbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLocalidad.DisplayMember = "Text"
        Me.cmbLocalidad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbLocalidad.FormattingEnabled = True
        Me.cmbLocalidad.ItemHeight = 14
        Me.cmbLocalidad.Location = New System.Drawing.Point(296, 103)
        Me.cmbLocalidad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbLocalidad.Name = "cmbLocalidad"
        Me.cmbLocalidad.Size = New System.Drawing.Size(173, 20)
        Me.cmbLocalidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbLocalidad.TabIndex = 5
        '
        'cmbProvincia
        '
        Me.cmbProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProvincia.DisplayMember = "Text"
        Me.cmbProvincia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.ItemHeight = 14
        Me.cmbProvincia.Location = New System.Drawing.Point(113, 103)
        Me.cmbProvincia.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(172, 20)
        Me.cmbProvincia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbProvincia.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(109, 84)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 17)
        Me.Label9.TabIndex = 304
        Me.Label9.Text = "Provincia*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(24, 84)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 17)
        Me.Label7.TabIndex = 301
        Me.Label7.Text = "Cód. Postal*"
        '
        'Label8
        '
        Me.Label8.AccessibleName = ""
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(292, 84)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 17)
        Me.Label8.TabIndex = 302
        Me.Label8.Text = "Localidad*"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(592, 25)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 17)
        Me.Label6.TabIndex = 300
        Me.Label6.Text = "Domicilio"
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDomicilio.Location = New System.Drawing.Point(597, 46)
        Me.txtDomicilio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDomicilio.MaxLength = 200
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(355, 22)
        Me.txtDomicilio.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AccessibleName = ""
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(433, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 17)
        Me.Label2.TabIndex = 306
        Me.Label2.Text = "Cuit*"
        '
        'txtCuit
        '
        Me.txtCuit.AccessibleName = "*Cuit"
        Me.txtCuit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCuit.Decimals = CType(2, Byte)
        Me.txtCuit.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCuit.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtCuit.Location = New System.Drawing.Point(437, 46)
        Me.txtCuit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuit.MaxLength = 11
        Me.txtCuit.Name = "txtCuit"
        Me.txtCuit.Size = New System.Drawing.Size(145, 22)
        Me.txtCuit.TabIndex = 1
        Me.txtCuit.Text_1 = Nothing
        Me.txtCuit.Text_2 = Nothing
        Me.txtCuit.Text_3 = Nothing
        Me.txtCuit.Text_4 = Nothing
        Me.txtCuit.UserValues = Nothing
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(481, 82)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 17)
        Me.Label12.TabIndex = 305
        Me.Label12.Text = "Teléfono"
        '
        'txtTelefono
        '
        Me.txtTelefono.AccessibleName = ""
        Me.txtTelefono.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTelefono.Decimals = CType(2, Byte)
        Me.txtTelefono.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtTelefono.Format = TextBoxConFormatoVB.tbFormats.SignedNumber
        Me.txtTelefono.Location = New System.Drawing.Point(483, 103)
        Me.txtTelefono.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTelefono.MaxLength = 50
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(183, 22)
        Me.txtTelefono.TabIndex = 6
        Me.txtTelefono.Text_1 = Nothing
        Me.txtTelefono.Text_2 = Nothing
        Me.txtTelefono.Text_3 = Nothing
        Me.txtTelefono.Text_4 = Nothing
        Me.txtTelefono.UserValues = Nothing
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(681, 82)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 17)
        Me.Label3.TabIndex = 303
        Me.Label3.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.AccessibleName = ""
        Me.txtEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.Decimals = CType(2, Byte)
        Me.txtEmail.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtEmail.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtEmail.Location = New System.Drawing.Point(683, 103)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(271, 22)
        Me.txtEmail.TabIndex = 7
        Me.txtEmail.Text_1 = Nothing
        Me.txtEmail.Text_2 = Nothing
        Me.txtEmail.Text_3 = Nothing
        Me.txtEmail.Text_4 = Nothing
        Me.txtEmail.UserValues = Nothing
        '
        'cmbPreferenciaPago
        '
        Me.cmbPreferenciaPago.AccessibleName = "*Preferencia Pago"
        Me.cmbPreferenciaPago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPreferenciaPago.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPreferenciaPago.DisplayMember = "Text"
        Me.cmbPreferenciaPago.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPreferenciaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPreferenciaPago.FormattingEnabled = True
        Me.cmbPreferenciaPago.ItemHeight = 14
        Me.cmbPreferenciaPago.Location = New System.Drawing.Point(25, 162)
        Me.cmbPreferenciaPago.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbPreferenciaPago.Name = "cmbPreferenciaPago"
        Me.cmbPreferenciaPago.Size = New System.Drawing.Size(155, 20)
        Me.cmbPreferenciaPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPreferenciaPago.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(23, 142)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 17)
        Me.Label5.TabIndex = 291
        Me.Label5.Text = "Preferencia de Pago*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(24, 26)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 17)
        Me.Label4.TabIndex = 276
        Me.Label4.Text = "Código"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(160, 25)
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
        Me.txtCODIGO.Enabled = False
        Me.txtCODIGO.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtCODIGO.Location = New System.Drawing.Point(27, 47)
        Me.txtCODIGO.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCODIGO.MaxLength = 25
        Me.txtCODIGO.Name = "txtCODIGO"
        Me.txtCODIGO.Size = New System.Drawing.Size(129, 22)
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
        Me.txtNombre.Location = New System.Drawing.Point(164, 46)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(261, 22)
        Me.txtNombre.TabIndex = 0
        '
        'frmRazonesSociales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = False
        Me.ClientSize = New System.Drawing.Size(1023, 620)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.MinimumSize = New System.Drawing.Size(994, 478)
        Me.Name = "frmRazonesSociales"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Razones Sociales"
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
    Friend WithEvents Label11 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCODIGO As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents cmbPreferenciaPago As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label5 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtNroCuenta As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents txtCodigoPostal As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents cmbLocalidad As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbProvincia As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDomicilio As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCuit As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTelefono As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmail As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label13 As Label
    Friend WithEvents txtCbu As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label10 As Label
    Friend WithEvents txtBanco As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents chkSociedad As CheckBox
End Class