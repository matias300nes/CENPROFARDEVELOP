<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmObraSocial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmObraSocial))
        Me.txtID = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCODIGO = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombre = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.cmbAplicarBonificacionA = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.grdPlanesPanel = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Porcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stiPlanes = New DevComponents.DotNetBar.SuperTabItem()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEliminarPanel = New DevComponents.DotNetBar.ButtonItem()
        Me.txtCodigoPostal = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.txtCuit = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.cmbLocalidad = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.txtTelefono = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.cmbProvincia = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.txtCodigoFacaf = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nudBonificacion = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.labelCuit = New System.Windows.Forms.Label()
        Me.chkEliminados = New System.Windows.Forms.CheckBox()
        Me.stiCodigos = New DevComponents.DotNetBar.SuperTabItem()
        Me.stiProfesionales = New DevComponents.DotNetBar.SuperTabItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.grdPlanesPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudBonificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtID
        '
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.Decimals = CType(2, Byte)
        Me.txtID.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtID.Enabled = False
        Me.txtID.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtID.Location = New System.Drawing.Point(113, 9)
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
        Me.Label1.Location = New System.Drawing.Point(84, 12)
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
        Me.txtCODIGO.Location = New System.Drawing.Point(27, 42)
        Me.txtCODIGO.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCODIGO.MaxLength = 25
        Me.txtCODIGO.Name = "txtCODIGO"
        Me.txtCODIGO.ReadOnly = True
        Me.txtCODIGO.Size = New System.Drawing.Size(107, 22)
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
        Me.Label2.Location = New System.Drawing.Point(23, 23)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Código"
        '
        'txtNombre
        '
        Me.txtNombre.AccessibleName = "*Nombre"
        Me.txtNombre.Decimals = CType(2, Byte)
        Me.txtNombre.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtNombre.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtNombre.Location = New System.Drawing.Point(155, 43)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombre.MaxLength = 99
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(281, 22)
        Me.txtNombre.TabIndex = 0
        Me.txtNombre.Text_1 = Nothing
        Me.txtNombre.Text_2 = Nothing
        Me.txtNombre.Text_3 = Nothing
        Me.txtNombre.Text_4 = Nothing
        Me.txtNombre.UserValues = Nothing
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(151, 23)
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
        Me.GroupBox1.Controls.Add(Me.cmbAplicarBonificacionA)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.SuperTabControl1)
        Me.GroupBox1.Controls.Add(Me.txtCodigoPostal)
        Me.GroupBox1.Controls.Add(Me.txtCuit)
        Me.GroupBox1.Controls.Add(Me.cmbLocalidad)
        Me.GroupBox1.Controls.Add(Me.txtTelefono)
        Me.GroupBox1.Controls.Add(Me.cmbProvincia)
        Me.GroupBox1.Controls.Add(Me.txtCodigoFacaf)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.nudBonificacion)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDomicilio)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.labelCuit)
        Me.GroupBox1.Controls.Add(Me.chkEliminados)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.txtCODIGO)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupBox1.Location = New System.Drawing.Point(16, 34)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1195, 295)
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
        'cmbAplicarBonificacionA
        '
        Me.cmbAplicarBonificacionA.AccessibleName = "*Aplicar bonificacion a"
        Me.cmbAplicarBonificacionA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAplicarBonificacionA.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAplicarBonificacionA.DisplayMember = "Text"
        Me.cmbAplicarBonificacionA.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAplicarBonificacionA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAplicarBonificacionA.FormattingEnabled = True
        Me.cmbAplicarBonificacionA.ItemHeight = 14
        Me.cmbAplicarBonificacionA.Location = New System.Drawing.Point(389, 256)
        Me.cmbAplicarBonificacionA.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbAplicarBonificacionA.Name = "cmbAplicarBonificacionA"
        Me.cmbAplicarBonificacionA.Size = New System.Drawing.Size(192, 20)
        Me.cmbAplicarBonificacionA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAplicarBonificacionA.TabIndex = 397
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(237, 257)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(151, 17)
        Me.Label4.TabIndex = 396
        Me.Label4.Text = "Aplicar bonificación a:*"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        Me.SuperTabControl1.Location = New System.Drawing.Point(611, 23)
        Me.SuperTabControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(559, 219)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 273
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.stiPlanes, Me.btnAdd, Me.btnEliminarPanel})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.grdPlanesPanel)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(559, 192)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.stiPlanes
        '
        'grdPlanesPanel
        '
        Me.grdPlanesPanel.AllowUserToAddRows = False
        Me.grdPlanesPanel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdPlanesPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPlanesPanel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.cod, Me.Nombre, Me.Porcentaje})
        Me.grdPlanesPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPlanesPanel.Location = New System.Drawing.Point(0, 0)
        Me.grdPlanesPanel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grdPlanesPanel.MultiSelect = False
        Me.grdPlanesPanel.Name = "grdPlanesPanel"
        Me.grdPlanesPanel.RowHeadersVisible = False
        Me.grdPlanesPanel.RowHeadersWidth = 51
        Me.grdPlanesPanel.RowTemplate.Height = 24
        Me.grdPlanesPanel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdPlanesPanel.Size = New System.Drawing.Size(559, 192)
        Me.grdPlanesPanel.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.MinimumWidth = 6
        Me.Id.Name = "Id"
        '
        'cod
        '
        Me.cod.HeaderText = "Código"
        Me.cod.MinimumWidth = 6
        Me.cod.Name = "cod"
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.MinimumWidth = 6
        Me.Nombre.Name = "Nombre"
        '
        'Porcentaje
        '
        Me.Porcentaje.HeaderText = "Porcentaje"
        Me.Porcentaje.MinimumWidth = 6
        Me.Porcentaje.Name = "Porcentaje"
        '
        'stiPlanes
        '
        Me.stiPlanes.AttachedControl = Me.SuperTabControlPanel1
        Me.stiPlanes.GlobalItem = False
        Me.stiPlanes.Name = "stiPlanes"
        Me.stiPlanes.Text = "Planes"
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
        'txtCodigoPostal
        '
        Me.txtCodigoPostal.Decimals = CType(2, Byte)
        Me.txtCodigoPostal.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCodigoPostal.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtCodigoPostal.Location = New System.Drawing.Point(285, 162)
        Me.txtCodigoPostal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigoPostal.MaxLength = 4
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        Me.txtCodigoPostal.Size = New System.Drawing.Size(89, 22)
        Me.txtCodigoPostal.TabIndex = 1
        Me.txtCodigoPostal.Text_1 = Nothing
        Me.txtCodigoPostal.Text_2 = Nothing
        Me.txtCodigoPostal.Text_3 = Nothing
        Me.txtCodigoPostal.Text_4 = Nothing
        Me.txtCodigoPostal.UserValues = Nothing
        '
        'txtCuit
        '
        Me.txtCuit.AccessibleName = "*Cuit"
        Me.txtCuit.Decimals = CType(2, Byte)
        Me.txtCuit.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCuit.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtCuit.Location = New System.Drawing.Point(459, 100)
        Me.txtCuit.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCuit.MaxLength = 11
        Me.txtCuit.Name = "txtCuit"
        Me.txtCuit.Size = New System.Drawing.Size(123, 22)
        Me.txtCuit.TabIndex = 4
        Me.txtCuit.Text_1 = Nothing
        Me.txtCuit.Text_2 = Nothing
        Me.txtCuit.Text_3 = Nothing
        Me.txtCuit.Text_4 = Nothing
        Me.txtCuit.UserValues = Nothing
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
        Me.cmbLocalidad.Location = New System.Drawing.Point(28, 222)
        Me.cmbLocalidad.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbLocalidad.Name = "cmbLocalidad"
        Me.cmbLocalidad.Size = New System.Drawing.Size(160, 20)
        Me.cmbLocalidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbLocalidad.TabIndex = 3
        '
        'txtTelefono
        '
        Me.txtTelefono.Decimals = CType(2, Byte)
        Me.txtTelefono.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtTelefono.Format = TextBoxConFormatoVB.tbFormats.SignedNumber
        Me.txtTelefono.Location = New System.Drawing.Point(27, 100)
        Me.txtTelefono.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTelefono.MaxLength = 20
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(145, 22)
        Me.txtTelefono.TabIndex = 2
        Me.txtTelefono.Text_1 = Nothing
        Me.txtTelefono.Text_2 = Nothing
        Me.txtTelefono.Text_3 = Nothing
        Me.txtTelefono.Text_4 = Nothing
        Me.txtTelefono.UserValues = Nothing
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
        Me.cmbProvincia.Location = New System.Drawing.Point(396, 160)
        Me.cmbProvincia.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(185, 20)
        Me.cmbProvincia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbProvincia.TabIndex = 2
        '
        'txtCodigoFacaf
        '
        Me.txtCodigoFacaf.Decimals = CType(2, Byte)
        Me.txtCodigoFacaf.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCodigoFacaf.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtCodigoFacaf.Location = New System.Drawing.Point(459, 43)
        Me.txtCodigoFacaf.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigoFacaf.MaxLength = 3
        Me.txtCodigoFacaf.Name = "txtCodigoFacaf"
        Me.txtCodigoFacaf.Size = New System.Drawing.Size(125, 22)
        Me.txtCodigoFacaf.TabIndex = 1
        Me.txtCodigoFacaf.Text_1 = Nothing
        Me.txtCodigoFacaf.Text_2 = Nothing
        Me.txtCodigoFacaf.Text_3 = Nothing
        Me.txtCodigoFacaf.Text_4 = Nothing
        Me.txtCodigoFacaf.UserValues = Nothing
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(392, 142)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 17)
        Me.Label9.TabIndex = 268
        Me.Label9.Text = "Provincia*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(456, 23)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(99, 17)
        Me.Label13.TabIndex = 272
        Me.Label13.Text = "Código FACAF"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(283, 142)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 17)
        Me.Label7.TabIndex = 264
        Me.Label7.Text = "Código postal"
        '
        'nudBonificacion
        '
        Me.nudBonificacion.DecimalPlaces = 2
        Me.nudBonificacion.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudBonificacion.Location = New System.Drawing.Point(134, 256)
        Me.nudBonificacion.Margin = New System.Windows.Forms.Padding(4)
        Me.nudBonificacion.Name = "nudBonificacion"
        Me.nudBonificacion.Size = New System.Drawing.Size(97, 22)
        Me.nudBonificacion.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AccessibleName = ""
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(25, 199)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 17)
        Me.Label8.TabIndex = 266
        Me.Label8.Text = "Localidad*"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(207, 199)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 17)
        Me.Label11.TabIndex = 267
        Me.Label11.Text = "Descripción"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(24, 142)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 17)
        Me.Label6.TabIndex = 262
        Me.Label6.Text = "Domicilio"
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Location = New System.Drawing.Point(28, 162)
        Me.txtDomicilio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDomicilio.MaxLength = 200
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(233, 22)
        Me.txtDomicilio.TabIndex = 0
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(211, 220)
        Me.txtDescripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDescripcion.MaxLength = 200
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(375, 22)
        Me.txtDescripcion.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(23, 256)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(104, 17)
        Me.Label12.TabIndex = 269
        Me.Label12.Text = "Bonificación %:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(189, 80)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 17)
        Me.Label10.TabIndex = 265
        Me.Label10.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(193, 100)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(243, 22)
        Me.txtEmail.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(23, 80)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 17)
        Me.Label5.TabIndex = 263
        Me.Label5.Text = "Teléfono"
        '
        'labelCuit
        '
        Me.labelCuit.AutoSize = True
        Me.labelCuit.BackColor = System.Drawing.Color.Transparent
        Me.labelCuit.ForeColor = System.Drawing.Color.Blue
        Me.labelCuit.Location = New System.Drawing.Point(456, 80)
        Me.labelCuit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelCuit.Name = "labelCuit"
        Me.labelCuit.Size = New System.Drawing.Size(37, 17)
        Me.labelCuit.TabIndex = 258
        Me.labelCuit.Text = "Cuit*"
        '
        'chkEliminados
        '
        Me.chkEliminados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkEliminados.AutoSize = True
        Me.chkEliminados.BackColor = System.Drawing.Color.Transparent
        Me.chkEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEliminados.ForeColor = System.Drawing.Color.Red
        Me.chkEliminados.Location = New System.Drawing.Point(1047, 260)
        Me.chkEliminados.Margin = New System.Windows.Forms.Padding(4)
        Me.chkEliminados.Name = "chkEliminados"
        Me.chkEliminados.Size = New System.Drawing.Size(138, 21)
        Me.chkEliminados.TabIndex = 256
        Me.chkEliminados.Text = "Ver Eliminados"
        Me.chkEliminados.UseVisualStyleBackColor = False
        '
        'stiCodigos
        '
        Me.stiCodigos.GlobalItem = False
        Me.stiCodigos.Name = "stiCodigos"
        Me.stiCodigos.Text = "Códigos"
        '
        'stiProfesionales
        '
        Me.stiProfesionales.GlobalItem = False
        Me.stiProfesionales.Name = "stiProfesionales"
        Me.stiProfesionales.Text = "Profesionales"
        '
        'frmObraSocial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1227, 534)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1093, 419)
        Me.Name = "frmObraSocial"
        Me.Text = "Obras Sociales"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.grdPlanesPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudBonificacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub




    Friend WithEvents txtID As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Friend WithEvents txtCODIGO As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label2 As System.Windows.Forms.Label

    Friend WithEvents txtNombre As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents chkEliminados As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDomicilio As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbProvincia As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbLocalidad As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents nudBonificacion As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtTelefono As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents txtCodigoFacaf As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents txtCuit As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents labelCuit As Label
    Friend WithEvents txtCodigoPostal As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents grdPlanesPanel As DataGridView
    Friend WithEvents stiPlanes As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents stiCodigos As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents stiProfesionales As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEliminarPanel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents cod As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents Porcentaje As DataGridViewTextBoxColumn
    Friend WithEvents cmbAplicarBonificacionA As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label4 As Label
End Class
