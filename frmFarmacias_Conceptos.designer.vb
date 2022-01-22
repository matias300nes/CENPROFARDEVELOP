<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFarmacias_Conceptos

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
        Me.txtID = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCODIGO = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFarmacia = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.FormattedTextBoxVB2 = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.cmbPreferenciaPago = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FormattedTextBoxVB1 = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.cmbEstado = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.txtCodigoPostal = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtMotivoBaja = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.cmbLocalidad = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbProvincia = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.SuperTabControl = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.grdCodigos = New System.Windows.Forms.DataGridView()
        Me.mandatariaNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mandatariaCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stiCodigos = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.stiConceptos = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.stiProfesionales = New DevComponents.DotNetBar.SuperTabItem()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkEliminados = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTipoContribuyente = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCuit = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTelefono = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEmail = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SuperTabControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        CType(Me.grdCodigos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtID
        '
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.Decimals = CType(2, Byte)
        Me.txtID.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtID.Enabled = False
        Me.txtID.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtID.Location = New System.Drawing.Point(264, -4)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtID.MaxLength = 8
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(91, 22)
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
        Me.Label1.Location = New System.Drawing.Point(557, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 17)
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
        Me.txtCODIGO.Location = New System.Drawing.Point(21, 33)
        Me.txtCODIGO.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCODIGO.MaxLength = 25
        Me.txtCODIGO.Name = "txtCODIGO"
        Me.txtCODIGO.ReadOnly = True
        Me.txtCODIGO.Size = New System.Drawing.Size(103, 22)
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
        Me.Label2.Location = New System.Drawing.Point(19, 14)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Código"
        '
        'txtFarmacia
        '
        Me.txtFarmacia.AccessibleName = "*Nombre"
        Me.txtFarmacia.Decimals = CType(2, Byte)
        Me.txtFarmacia.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtFarmacia.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtFarmacia.Location = New System.Drawing.Point(135, 33)
        Me.txtFarmacia.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFarmacia.MaxLength = 50
        Me.txtFarmacia.Name = "txtFarmacia"
        Me.txtFarmacia.Size = New System.Drawing.Size(285, 22)
        Me.txtFarmacia.TabIndex = 3
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
        Me.Label3.Location = New System.Drawing.Point(131, 14)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 17)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Nombre*"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.FormattedTextBoxVB2)
        Me.GroupBox1.Controls.Add(Me.cmbPreferenciaPago)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.FormattedTextBoxVB1)
        Me.GroupBox1.Controls.Add(Me.cmbEstado)
        Me.GroupBox1.Controls.Add(Me.txtCodigoPostal)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtMotivoBaja)
        Me.GroupBox1.Controls.Add(Me.cmbLocalidad)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.cmbProvincia)
        Me.GroupBox1.Controls.Add(Me.SuperTabControl)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.chkEliminados)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtTipoContribuyente)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDomicilio)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtCuit)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtTelefono)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.txtCODIGO)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtFarmacia)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupBox1.Location = New System.Drawing.Point(16, 34)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1520, 358)
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
        'Label14
        '
        Me.Label14.AccessibleName = ""
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(484, 79)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 17)
        Me.Label14.TabIndex = 291
        Me.Label14.Text = "CBU*"
        '
        'FormattedTextBoxVB2
        '
        Me.FormattedTextBoxVB2.AccessibleName = "*Cuit"
        Me.FormattedTextBoxVB2.Decimals = CType(0, Byte)
        Me.FormattedTextBoxVB2.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.FormattedTextBoxVB2.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.FormattedTextBoxVB2.Location = New System.Drawing.Point(488, 98)
        Me.FormattedTextBoxVB2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FormattedTextBoxVB2.MaxLength = 22
        Me.FormattedTextBoxVB2.Name = "FormattedTextBoxVB2"
        Me.FormattedTextBoxVB2.Size = New System.Drawing.Size(236, 22)
        Me.FormattedTextBoxVB2.TabIndex = 290
        Me.FormattedTextBoxVB2.Text_1 = Nothing
        Me.FormattedTextBoxVB2.Text_2 = Nothing
        Me.FormattedTextBoxVB2.Text_3 = Nothing
        Me.FormattedTextBoxVB2.Text_4 = Nothing
        Me.FormattedTextBoxVB2.UserValues = Nothing
        '
        'cmbPreferenciaPago
        '
        Me.cmbPreferenciaPago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPreferenciaPago.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPreferenciaPago.DisplayMember = "Text"
        Me.cmbPreferenciaPago.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPreferenciaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPreferenciaPago.FormattingEnabled = True
        Me.cmbPreferenciaPago.ItemHeight = 14
        Me.cmbPreferenciaPago.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.cmbPreferenciaPago.Location = New System.Drawing.Point(317, 100)
        Me.cmbPreferenciaPago.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbPreferenciaPago.Name = "cmbPreferenciaPago"
        Me.cmbPreferenciaPago.Size = New System.Drawing.Size(155, 20)
        Me.cmbPreferenciaPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPreferenciaPago.TabIndex = 288
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Cheque"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Transferencia"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(313, 80)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 17)
        Me.Label5.TabIndex = 289
        Me.Label5.Text = "Preferencia de pago"
        '
        'Label4
        '
        Me.Label4.AccessibleName = "*RazonSocial"
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(428, 14)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 17)
        Me.Label4.TabIndex = 287
        Me.Label4.Text = "Razon Social*"
        '
        'FormattedTextBoxVB1
        '
        Me.FormattedTextBoxVB1.AccessibleName = "*Nombre"
        Me.FormattedTextBoxVB1.Decimals = CType(2, Byte)
        Me.FormattedTextBoxVB1.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.FormattedTextBoxVB1.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.FormattedTextBoxVB1.Location = New System.Drawing.Point(432, 33)
        Me.FormattedTextBoxVB1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FormattedTextBoxVB1.MaxLength = 50
        Me.FormattedTextBoxVB1.Name = "FormattedTextBoxVB1"
        Me.FormattedTextBoxVB1.Size = New System.Drawing.Size(292, 22)
        Me.FormattedTextBoxVB1.TabIndex = 286
        Me.FormattedTextBoxVB1.Text_1 = Nothing
        Me.FormattedTextBoxVB1.Text_2 = Nothing
        Me.FormattedTextBoxVB1.Text_3 = Nothing
        Me.FormattedTextBoxVB1.Text_4 = Nothing
        Me.FormattedTextBoxVB1.UserValues = Nothing
        '
        'cmbEstado
        '
        Me.cmbEstado.DisplayMember = "Text"
        Me.cmbEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.ItemHeight = 16
        Me.cmbEstado.Location = New System.Drawing.Point(23, 300)
        Me.cmbEstado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(179, 22)
        Me.cmbEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbEstado.TabIndex = 0
        '
        'txtCodigoPostal
        '
        Me.txtCodigoPostal.Decimals = CType(2, Byte)
        Me.txtCodigoPostal.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCodigoPostal.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtCodigoPostal.Location = New System.Drawing.Point(271, 230)
        Me.txtCodigoPostal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCodigoPostal.MaxLength = 4
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        Me.txtCodigoPostal.Size = New System.Drawing.Size(77, 22)
        Me.txtCodigoPostal.TabIndex = 1
        Me.txtCodigoPostal.Text_1 = Nothing
        Me.txtCodigoPostal.Text_2 = Nothing
        Me.txtCodigoPostal.Text_3 = Nothing
        Me.txtCodigoPostal.Text_4 = Nothing
        Me.txtCodigoPostal.UserValues = Nothing
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(217, 279)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 17)
        Me.Label13.TabIndex = 278
        Me.Label13.Text = "Motivo Baja"
        '
        'txtMotivoBaja
        '
        Me.txtMotivoBaja.AccessibleName = ""
        Me.txtMotivoBaja.Decimals = CType(2, Byte)
        Me.txtMotivoBaja.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtMotivoBaja.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtMotivoBaja.Location = New System.Drawing.Point(221, 300)
        Me.txtMotivoBaja.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtMotivoBaja.MaxLength = 100
        Me.txtMotivoBaja.Name = "txtMotivoBaja"
        Me.txtMotivoBaja.Size = New System.Drawing.Size(199, 22)
        Me.txtMotivoBaja.TabIndex = 1
        Me.txtMotivoBaja.Text_1 = Nothing
        Me.txtMotivoBaja.Text_2 = Nothing
        Me.txtMotivoBaja.Text_3 = Nothing
        Me.txtMotivoBaja.Text_4 = Nothing
        Me.txtMotivoBaja.UserValues = Nothing
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
        Me.cmbLocalidad.Location = New System.Drawing.Point(551, 230)
        Me.cmbLocalidad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbLocalidad.Name = "cmbLocalidad"
        Me.cmbLocalidad.Size = New System.Drawing.Size(173, 20)
        Me.cmbLocalidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbLocalidad.TabIndex = 3
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(19, 279)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 17)
        Me.Label17.TabIndex = 272
        Me.Label17.Text = "Estado:"
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
        Me.cmbProvincia.Location = New System.Drawing.Point(365, 230)
        Me.cmbProvincia.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(172, 20)
        Me.cmbProvincia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbProvincia.TabIndex = 2
        '
        'SuperTabControl
        '
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl.ControlBox.Name = ""
        Me.SuperTabControl.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl.ControlBox.MenuBox, Me.SuperTabControl.ControlBox.CloseBox})
        Me.SuperTabControl.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl.Location = New System.Drawing.Point(760, 14)
        Me.SuperTabControl.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SuperTabControl.Name = "SuperTabControl"
        Me.SuperTabControl.ReorderTabsEnabled = True
        Me.SuperTabControl.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl.SelectedTabIndex = 0
        Me.SuperTabControl.Size = New System.Drawing.Size(709, 314)
        Me.SuperTabControl.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl.TabIndex = 65
        Me.SuperTabControl.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.stiConceptos, Me.stiCodigos, Me.stiProfesionales, Me.btnAdd, Me.btnEliminar})
        Me.SuperTabControl.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.grdCodigos)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(709, 287)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.stiCodigos
        '
        'grdCodigos
        '
        Me.grdCodigos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdCodigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCodigos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.mandatariaNombre, Me.mandatariaCodigo})
        Me.grdCodigos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCodigos.Location = New System.Drawing.Point(0, 0)
        Me.grdCodigos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grdCodigos.Name = "grdCodigos"
        Me.grdCodigos.RowHeadersWidth = 51
        Me.grdCodigos.RowTemplate.Height = 24
        Me.grdCodigos.Size = New System.Drawing.Size(709, 287)
        Me.grdCodigos.TabIndex = 1
        '
        'mandatariaNombre
        '
        Me.mandatariaNombre.HeaderText = "Mandataria"
        Me.mandatariaNombre.MinimumWidth = 6
        Me.mandatariaNombre.Name = "mandatariaNombre"
        Me.mandatariaNombre.ReadOnly = True
        '
        'mandatariaCodigo
        '
        Me.mandatariaCodigo.HeaderText = "Código"
        Me.mandatariaCodigo.MinimumWidth = 6
        Me.mandatariaCodigo.Name = "mandatariaCodigo"
        '
        'stiCodigos
        '
        Me.stiCodigos.AttachedControl = Me.SuperTabControlPanel3
        Me.stiCodigos.GlobalItem = False
        Me.stiCodigos.Name = "stiCodigos"
        Me.stiCodigos.Text = "Códigos"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.DataGridView1)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(709, 287)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.stiConceptos
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(709, 287)
        Me.DataGridView1.TabIndex = 0
        '
        'stiConceptos
        '
        Me.stiConceptos.AttachedControl = Me.SuperTabControlPanel1
        Me.stiConceptos.GlobalItem = False
        Me.stiConceptos.Name = "stiConceptos"
        Me.stiConceptos.Text = "Conceptos"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 32)
        Me.SuperTabControlPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(709, 282)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.stiProfesionales
        '
        'stiProfesionales
        '
        Me.stiProfesionales.AttachedControl = Me.SuperTabControlPanel2
        Me.stiProfesionales.GlobalItem = False
        Me.stiProfesionales.Name = "stiProfesionales"
        Me.stiProfesionales.Text = "Profesionales"
        '
        'btnAdd
        '
        Me.btnAdd.BeginGroup = True
        Me.btnAdd.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Text = "Agregar"
        '
        'btnEliminar
        '
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Text = "Eliminar"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(361, 210)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 17)
        Me.Label9.TabIndex = 268
        Me.Label9.Text = "Provincia*"
        '
        'chkEliminados
        '
        Me.chkEliminados.AutoSize = True
        Me.chkEliminados.BackColor = System.Drawing.Color.Transparent
        Me.chkEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEliminados.ForeColor = System.Drawing.Color.Red
        Me.chkEliminados.Location = New System.Drawing.Point(580, 300)
        Me.chkEliminados.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkEliminados.Name = "chkEliminados"
        Me.chkEliminados.Size = New System.Drawing.Size(138, 21)
        Me.chkEliminados.TabIndex = 256
        Me.chkEliminados.Text = "Ver Eliminados"
        Me.chkEliminados.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(267, 208)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 17)
        Me.Label7.TabIndex = 264
        Me.Label7.Text = "Cód. Postal"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(156, 80)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 17)
        Me.Label10.TabIndex = 285
        Me.Label10.Text = "Tipo Contribuyente"
        '
        'Label8
        '
        Me.Label8.AccessibleName = ""
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(548, 210)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 17)
        Me.Label8.TabIndex = 266
        Me.Label8.Text = "Localidad*"
        '
        'txtTipoContribuyente
        '
        Me.txtTipoContribuyente.AccessibleName = ""
        Me.txtTipoContribuyente.Decimals = CType(2, Byte)
        Me.txtTipoContribuyente.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtTipoContribuyente.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtTipoContribuyente.Location = New System.Drawing.Point(159, 100)
        Me.txtTipoContribuyente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTipoContribuyente.MaxLength = 50
        Me.txtTipoContribuyente.Name = "txtTipoContribuyente"
        Me.txtTipoContribuyente.Size = New System.Drawing.Size(141, 22)
        Me.txtTipoContribuyente.TabIndex = 9
        Me.txtTipoContribuyente.Text_1 = Nothing
        Me.txtTipoContribuyente.Text_2 = Nothing
        Me.txtTipoContribuyente.Text_3 = Nothing
        Me.txtTipoContribuyente.Text_4 = Nothing
        Me.txtTipoContribuyente.UserValues = Nothing
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(19, 209)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 17)
        Me.Label6.TabIndex = 262
        Me.Label6.Text = "Domicilio"
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Location = New System.Drawing.Point(23, 230)
        Me.txtDomicilio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDomicilio.MaxLength = 200
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(233, 22)
        Me.txtDomicilio.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AccessibleName = ""
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(19, 80)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 17)
        Me.Label15.TabIndex = 283
        Me.Label15.Text = "Cuit*"
        '
        'txtCuit
        '
        Me.txtCuit.AccessibleName = "*Cuit"
        Me.txtCuit.Decimals = CType(2, Byte)
        Me.txtCuit.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCuit.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtCuit.Location = New System.Drawing.Point(23, 100)
        Me.txtCuit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuit.MaxLength = 11
        Me.txtCuit.Name = "txtCuit"
        Me.txtCuit.Size = New System.Drawing.Size(121, 22)
        Me.txtCuit.TabIndex = 4
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
        Me.Label12.Location = New System.Drawing.Point(19, 145)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 17)
        Me.Label12.TabIndex = 269
        Me.Label12.Text = "Teléfono"
        '
        'txtTelefono
        '
        Me.txtTelefono.AccessibleName = ""
        Me.txtTelefono.Decimals = CType(2, Byte)
        Me.txtTelefono.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtTelefono.Format = TextBoxConFormatoVB.tbFormats.SignedNumber
        Me.txtTelefono.Location = New System.Drawing.Point(21, 166)
        Me.txtTelefono.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTelefono.MaxLength = 50
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(155, 22)
        Me.txtTelefono.TabIndex = 7
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
        Me.Label11.Location = New System.Drawing.Point(192, 145)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 17)
        Me.Label11.TabIndex = 267
        Me.Label11.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.AccessibleName = ""
        Me.txtEmail.Decimals = CType(2, Byte)
        Me.txtEmail.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtEmail.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtEmail.Location = New System.Drawing.Point(193, 166)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(293, 22)
        Me.txtEmail.TabIndex = 8
        Me.txtEmail.Text_1 = Nothing
        Me.txtEmail.Text_2 = Nothing
        Me.txtEmail.Text_3 = Nothing
        Me.txtEmail.Text_4 = Nothing
        Me.txtEmail.UserValues = Nothing
        '
        'frmFarmacias_Conceptos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1529, 534)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.MaximizeBox = False
        Me.Name = "frmFarmacias_Conceptos"
        Me.Text = "Farmacias"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.SuperTabControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        CType(Me.grdCodigos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmbEstado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label13 As Label
    Friend WithEvents txtMotivoBaja As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label17 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTelefono As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label11 As Label
    Friend WithEvents txtEmail As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label10 As Label
    Friend WithEvents txtTipoContribuyente As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label15 As Label
    Friend WithEvents txtCuit As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents SuperTabControl As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents stiConceptos As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents stiProfesionales As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents grdCodigos As DataGridView
    Friend WithEvents stiCodigos As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents txtCodigoPostal As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents cmbLocalidad As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbProvincia As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDomicilio As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents FormattedTextBoxVB2 As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents cmbPreferenciaPago As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents FormattedTextBoxVB1 As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents mandatariaNombre As DataGridViewTextBoxColumn
    Friend WithEvents mandatariaCodigo As DataGridViewTextBoxColumn
End Class
