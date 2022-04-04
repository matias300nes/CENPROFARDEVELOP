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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFarmacias_Conceptos))
        Me.txtID = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCODIGO = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFarmacia = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.txtIdRazonSocial = New System.Windows.Forms.TextBox()
        Me.btnSeleccionar = New DevComponents.DotNetBar.ButtonX()
        Me.cmbPreferenciaPago = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.cmbEstado = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.txtCodigoPostal = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtMotivoBaja = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.cmbLocalidad = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbProvincia = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.grdConceptosPanel = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConceptoPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pertenecea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Frecuencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CampoAplicable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stiConceptos = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.grdCodigos = New System.Windows.Forms.DataGridView()
        Me.mandatariaNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mandatariaCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stiCodigos = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.grdProfesionalesPanel = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stiProfesionales = New DevComponents.DotNetBar.SuperTabItem()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEliminarPanel = New DevComponents.DotNetBar.ButtonItem()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkEliminados = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTelefono = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEmail = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.grdConceptosPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel3.SuspendLayout()
        CType(Me.grdCodigos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.grdProfesionalesPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtID
        '
        Me.txtID.AccessibleName = ""
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.Decimals = CType(2, Byte)
        Me.txtID.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtID.Enabled = False
        Me.txtID.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtID.Location = New System.Drawing.Point(228, 3)
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
        Me.txtCODIGO.Location = New System.Drawing.Point(29, 27)
        Me.txtCODIGO.MaxLength = 25
        Me.txtCODIGO.Name = "txtCODIGO"
        Me.txtCODIGO.ReadOnly = True
        Me.txtCODIGO.Size = New System.Drawing.Size(100, 20)
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
        Me.Label2.Location = New System.Drawing.Point(27, 11)
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
        Me.txtFarmacia.Location = New System.Drawing.Point(149, 27)
        Me.txtFarmacia.MaxLength = 50
        Me.txtFarmacia.Name = "txtFarmacia"
        Me.txtFarmacia.Size = New System.Drawing.Size(384, 20)
        Me.txtFarmacia.TabIndex = 0
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
        Me.Label3.Location = New System.Drawing.Point(146, 11)
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
        Me.GroupBox1.Controls.Add(Me.txtIdRazonSocial)
        Me.GroupBox1.Controls.Add(Me.btnSeleccionar)
        Me.GroupBox1.Controls.Add(Me.cmbPreferenciaPago)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtRazonSocial)
        Me.GroupBox1.Controls.Add(Me.cmbEstado)
        Me.GroupBox1.Controls.Add(Me.txtCodigoPostal)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtMotivoBaja)
        Me.GroupBox1.Controls.Add(Me.cmbLocalidad)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.cmbProvincia)
        Me.GroupBox1.Controls.Add(Me.SuperTabControl1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.chkEliminados)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDomicilio)
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1219, 291)
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
        'txtIdRazonSocial
        '
        Me.txtIdRazonSocial.AccessibleName = "*Razón social"
        Me.txtIdRazonSocial.Location = New System.Drawing.Point(225, 55)
        Me.txtIdRazonSocial.Name = "txtIdRazonSocial"
        Me.txtIdRazonSocial.ReadOnly = True
        Me.txtIdRazonSocial.Size = New System.Drawing.Size(72, 20)
        Me.txtIdRazonSocial.TabIndex = 293
        Me.txtIdRazonSocial.Visible = False
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSeleccionar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSeleccionar.Location = New System.Drawing.Point(301, 80)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(76, 22)
        Me.btnSeleccionar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSeleccionar.TabIndex = 292
        Me.btnSeleccionar.Text = "Seleccionar"
        '
        'cmbPreferenciaPago
        '
        Me.cmbPreferenciaPago.AccessibleName = "*PreferenciaPago"
        Me.cmbPreferenciaPago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPreferenciaPago.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPreferenciaPago.DisplayMember = "Text"
        Me.cmbPreferenciaPago.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPreferenciaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPreferenciaPago.FormattingEnabled = True
        Me.cmbPreferenciaPago.ItemHeight = 14
        Me.cmbPreferenciaPago.Location = New System.Drawing.Point(397, 81)
        Me.cmbPreferenciaPago.Name = "cmbPreferenciaPago"
        Me.cmbPreferenciaPago.Size = New System.Drawing.Size(136, 20)
        Me.cmbPreferenciaPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPreferenciaPago.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(394, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 13)
        Me.Label5.TabIndex = 289
        Me.Label5.Text = "Preferencia de pago*"
        '
        'Label4
        '
        Me.Label4.AccessibleName = ""
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(26, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 287
        Me.Label4.Text = "Razon Social*"
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.AccessibleName = ""
        Me.txtRazonSocial.BackColor = System.Drawing.SystemColors.Window
        Me.txtRazonSocial.Decimals = CType(2, Byte)
        Me.txtRazonSocial.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtRazonSocial.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtRazonSocial.Location = New System.Drawing.Point(29, 81)
        Me.txtRazonSocial.MaxLength = 50
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(268, 20)
        Me.txtRazonSocial.TabIndex = 1
        Me.txtRazonSocial.Text_1 = Nothing
        Me.txtRazonSocial.Text_2 = Nothing
        Me.txtRazonSocial.Text_3 = Nothing
        Me.txtRazonSocial.Text_4 = Nothing
        Me.txtRazonSocial.UserValues = Nothing
        '
        'cmbEstado
        '
        Me.cmbEstado.DisplayMember = "Text"
        Me.cmbEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.ItemHeight = 16
        Me.cmbEstado.Location = New System.Drawing.Point(30, 244)
        Me.cmbEstado.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(135, 22)
        Me.cmbEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbEstado.TabIndex = 12
        '
        'txtCodigoPostal
        '
        Me.txtCodigoPostal.Decimals = CType(2, Byte)
        Me.txtCodigoPostal.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCodigoPostal.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtCodigoPostal.Location = New System.Drawing.Point(197, 191)
        Me.txtCodigoPostal.MaxLength = 4
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        Me.txtCodigoPostal.Size = New System.Drawing.Size(59, 20)
        Me.txtCodigoPostal.TabIndex = 9
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
        Me.Label13.Location = New System.Drawing.Point(176, 227)
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
        Me.txtMotivoBaja.Location = New System.Drawing.Point(179, 244)
        Me.txtMotivoBaja.MaxLength = 100
        Me.txtMotivoBaja.Name = "txtMotivoBaja"
        Me.txtMotivoBaja.Size = New System.Drawing.Size(238, 20)
        Me.txtMotivoBaja.TabIndex = 13
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
        Me.cmbLocalidad.Location = New System.Drawing.Point(402, 191)
        Me.cmbLocalidad.Name = "cmbLocalidad"
        Me.cmbLocalidad.Size = New System.Drawing.Size(131, 20)
        Me.cmbLocalidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbLocalidad.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(27, 227)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 13)
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
        Me.cmbProvincia.Location = New System.Drawing.Point(266, 191)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(130, 20)
        Me.cmbProvincia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbProvincia.TabIndex = 10
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Location = New System.Drawing.Point(570, 11)
        Me.SuperTabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(596, 255)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 65
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.stiConceptos, Me.stiCodigos, Me.stiProfesionales, Me.btnAdd, Me.btnEliminarPanel})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.grdConceptosPanel)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.SuperTabControlPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(596, 229)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.stiConceptos
        '
        'grdConceptosPanel
        '
        Me.grdConceptosPanel.AllowUserToAddRows = False
        Me.grdConceptosPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdConceptosPanel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.cod, Me.Nombre, Me.Descripcion, Me.ConceptoPago, Me.Pertenecea, Me.TipoValor, Me.Valor, Me.Frecuencia, Me.CampoAplicable})
        Me.grdConceptosPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConceptosPanel.Location = New System.Drawing.Point(0, 0)
        Me.grdConceptosPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.grdConceptosPanel.MultiSelect = False
        Me.grdConceptosPanel.Name = "grdConceptosPanel"
        Me.grdConceptosPanel.RowHeadersVisible = False
        Me.grdConceptosPanel.RowHeadersWidth = 51
        Me.grdConceptosPanel.RowTemplate.Height = 24
        Me.grdConceptosPanel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdConceptosPanel.Size = New System.Drawing.Size(596, 229)
        Me.grdConceptosPanel.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.MinimumWidth = 6
        Me.Id.Name = "Id"
        Me.Id.Width = 125
        '
        'cod
        '
        Me.cod.HeaderText = "Codigo"
        Me.cod.MinimumWidth = 6
        Me.cod.Name = "cod"
        Me.cod.Width = 125
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.MinimumWidth = 6
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Width = 125
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.MinimumWidth = 6
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Width = 125
        '
        'ConceptoPago
        '
        Me.ConceptoPago.HeaderText = "Concepto Pago"
        Me.ConceptoPago.MinimumWidth = 6
        Me.ConceptoPago.Name = "ConceptoPago"
        Me.ConceptoPago.Width = 125
        '
        'Pertenecea
        '
        Me.Pertenecea.HeaderText = "Pertenece A"
        Me.Pertenecea.MinimumWidth = 6
        Me.Pertenecea.Name = "Pertenecea"
        Me.Pertenecea.Width = 125
        '
        'TipoValor
        '
        Me.TipoValor.HeaderText = "Tipo de Valor"
        Me.TipoValor.MinimumWidth = 6
        Me.TipoValor.Name = "TipoValor"
        Me.TipoValor.Width = 125
        '
        'Valor
        '
        Me.Valor.HeaderText = "Valor"
        Me.Valor.MinimumWidth = 6
        Me.Valor.Name = "Valor"
        Me.Valor.Width = 125
        '
        'Frecuencia
        '
        Me.Frecuencia.HeaderText = "Frecuencia"
        Me.Frecuencia.MinimumWidth = 6
        Me.Frecuencia.Name = "Frecuencia"
        Me.Frecuencia.Width = 125
        '
        'CampoAplicable
        '
        Me.CampoAplicable.HeaderText = "Campo Aplicable"
        Me.CampoAplicable.MinimumWidth = 6
        Me.CampoAplicable.Name = "CampoAplicable"
        Me.CampoAplicable.Width = 125
        '
        'stiConceptos
        '
        Me.stiConceptos.AttachedControl = Me.SuperTabControlPanel1
        Me.stiConceptos.GlobalItem = False
        Me.stiConceptos.Name = "stiConceptos"
        Me.stiConceptos.Text = "Conceptos"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.grdCodigos)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 22)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(532, 233)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.stiCodigos
        '
        'grdCodigos
        '
        Me.grdCodigos.AllowUserToAddRows = False
        Me.grdCodigos.AllowUserToDeleteRows = False
        Me.grdCodigos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdCodigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCodigos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.mandatariaNombre, Me.mandatariaCodigo})
        Me.grdCodigos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCodigos.Location = New System.Drawing.Point(0, 0)
        Me.grdCodigos.Margin = New System.Windows.Forms.Padding(2)
        Me.grdCodigos.MultiSelect = False
        Me.grdCodigos.Name = "grdCodigos"
        Me.grdCodigos.RowHeadersVisible = False
        Me.grdCodigos.RowHeadersWidth = 51
        Me.grdCodigos.RowTemplate.Height = 24
        Me.grdCodigos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdCodigos.Size = New System.Drawing.Size(532, 233)
        Me.grdCodigos.TabIndex = 1
        '
        'mandatariaNombre
        '
        Me.mandatariaNombre.HeaderText = "Mandataria"
        Me.mandatariaNombre.MinimumWidth = 6
        Me.mandatariaNombre.Name = "mandatariaNombre"
        Me.mandatariaNombre.ReadOnly = True
        Me.mandatariaNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'mandatariaCodigo
        '
        Me.mandatariaCodigo.HeaderText = "Código"
        Me.mandatariaCodigo.MaxInputLength = 30
        Me.mandatariaCodigo.MinimumWidth = 6
        Me.mandatariaCodigo.Name = "mandatariaCodigo"
        Me.mandatariaCodigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'stiCodigos
        '
        Me.stiCodigos.AttachedControl = Me.SuperTabControlPanel3
        Me.stiCodigos.GlobalItem = False
        Me.stiCodigos.Name = "stiCodigos"
        Me.stiCodigos.Text = "Códigos"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.grdProfesionalesPanel)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 22)
        Me.SuperTabControlPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(532, 233)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.stiProfesionales
        '
        'grdProfesionalesPanel
        '
        Me.grdProfesionalesPanel.AllowUserToAddRows = False
        Me.grdProfesionalesPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdProfesionalesPanel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.grdProfesionalesPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProfesionalesPanel.Location = New System.Drawing.Point(0, 0)
        Me.grdProfesionalesPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.grdProfesionalesPanel.MultiSelect = False
        Me.grdProfesionalesPanel.Name = "grdProfesionalesPanel"
        Me.grdProfesionalesPanel.RowHeadersVisible = False
        Me.grdProfesionalesPanel.RowHeadersWidth = 51
        Me.grdProfesionalesPanel.RowTemplate.Height = 24
        Me.grdProfesionalesPanel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdProfesionalesPanel.Size = New System.Drawing.Size(532, 233)
        Me.grdProfesionalesPanel.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 125
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 125
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 125
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Apellido"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 125
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Dirección"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 125
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Celular"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 125
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Email"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 125
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
        'btnEliminarPanel
        '
        Me.btnEliminarPanel.Name = "btnEliminarPanel"
        Me.btnEliminarPanel.Text = "Eliminar"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(263, 175)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 268
        Me.Label9.Text = "Provincia*"
        '
        'chkEliminados
        '
        Me.chkEliminados.AutoSize = True
        Me.chkEliminados.BackColor = System.Drawing.Color.Transparent
        Me.chkEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEliminados.ForeColor = System.Drawing.Color.Red
        Me.chkEliminados.Location = New System.Drawing.Point(435, 244)
        Me.chkEliminados.Name = "chkEliminados"
        Me.chkEliminados.Size = New System.Drawing.Size(109, 17)
        Me.chkEliminados.TabIndex = 256
        Me.chkEliminados.Text = "Ver Eliminados"
        Me.chkEliminados.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(194, 175)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 264
        Me.Label7.Text = "Cód. Postal"
        '
        'Label8
        '
        Me.Label8.AccessibleName = ""
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(400, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 266
        Me.Label8.Text = "Localidad*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(27, 174)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 262
        Me.Label6.Text = "Domicilio"
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Location = New System.Drawing.Point(30, 191)
        Me.txtDomicilio.MaxLength = 200
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(161, 20)
        Me.txtDomicilio.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(27, 118)
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
        Me.txtTelefono.Location = New System.Drawing.Point(29, 135)
        Me.txtTelefono.MaxLength = 50
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(162, 20)
        Me.txtTelefono.TabIndex = 6
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
        Me.Label11.Location = New System.Drawing.Point(198, 118)
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
        Me.txtEmail.Location = New System.Drawing.Point(199, 135)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(221, 20)
        Me.txtEmail.TabIndex = 7
        Me.txtEmail.Text_1 = Nothing
        Me.txtEmail.Text_2 = Nothing
        Me.txtEmail.Text_3 = Nothing
        Me.txtEmail.Text_4 = Nothing
        Me.txtEmail.UserValues = Nothing
        '
        'frmFarmacias_Conceptos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1192, 434)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(999, 349)
        Me.Name = "frmFarmacias_Conceptos"
        Me.Text = "Farmacias"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.grdConceptosPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel3.ResumeLayout(False)
        CType(Me.grdCodigos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.grdProfesionalesPanel, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents stiConceptos As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents grdConceptosPanel As DataGridView
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents stiProfesionales As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEliminarPanel As DevComponents.DotNetBar.ButtonItem
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
    Friend WithEvents cmbPreferenciaPago As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRazonSocial As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents mandatariaNombre As DataGridViewTextBoxColumn
    Friend WithEvents mandatariaCodigo As DataGridViewTextBoxColumn
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents cod As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents ConceptoPago As DataGridViewTextBoxColumn
    Friend WithEvents Pertenecea As DataGridViewTextBoxColumn
    Friend WithEvents TipoValor As DataGridViewTextBoxColumn
    Friend WithEvents Valor As DataGridViewTextBoxColumn
    Friend WithEvents Frecuencia As DataGridViewTextBoxColumn
    Friend WithEvents CampoAplicable As DataGridViewTextBoxColumn
    Friend WithEvents grdProfesionalesPanel As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents btnSeleccionar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtIdRazonSocial As TextBox
End Class
