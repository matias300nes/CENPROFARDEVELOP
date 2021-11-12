<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPresentaciones
    Inherits frmBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grdItems = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BorrarElItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarDescripcionToolStripMenuItem = New System.Windows.Forms.ToolStripComboBox()
        Me.BuscarDescripcionToolStripMenuItem2 = New System.Windows.Forms.ToolStripComboBox()
        Me.BuscarDescripcionToolStripMenuItem3 = New System.Windows.Forms.ToolStripComboBox()
        Me.IdFarmacia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoFarmacia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdPresentacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Recetas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Recaudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACargoOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bonificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Eliminar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GbFarmaciaForm = New System.Windows.Forms.GroupBox()
        Me.txtBonificacion = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.nudBonificacion = New System.Windows.Forms.NumericUpDown()
        Me.cmbFarmacias = New System.Windows.Forms.ComboBox()
        Me.btnAgregarItem = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtImpRecaudado = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.txtImpACargoOs = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtImpTotalAPagar = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.txtRecetas = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.chkMaterialesProveedor = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPeriodo = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtACargoOS = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtTotal = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkGrillaInferior = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblCantidadFilas = New System.Windows.Forms.Label()
        Me.rdTodasOC = New System.Windows.Forms.RadioButton()
        Me.rdPendientes = New System.Windows.Forms.RadioButton()
        Me.rdAnuladas = New System.Windows.Forms.RadioButton()
        Me.txtIdObrasocial = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRecaudado = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbObraSocial = New System.Windows.Forms.ComboBox()
        Me.lblEstadoPresentacion = New System.Windows.Forms.Label()
        Me.txtObservacion = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkEliminado = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtID = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.dtpFECHA = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmbUnidadVenta = New System.Windows.Forms.ToolStripComboBox()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmbMonedasCompra = New System.Windows.Forms.ToolStripComboBox()
        Me.ContextMenuMarcas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActivarNuevaMarcaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbMarcaCompra = New System.Windows.Forms.ToolStripComboBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GbFarmaciaForm.SuspendLayout()
        CType(Me.nudBonificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.ContextMenuMarcas.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.grdItems)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.chkMaterialesProveedor)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtPeriodo)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtACargoOS)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtTotal)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.chkGrillaInferior)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.lblCantidadFilas)
        Me.GroupBox1.Controls.Add(Me.rdTodasOC)
        Me.GroupBox1.Controls.Add(Me.rdPendientes)
        Me.GroupBox1.Controls.Add(Me.rdAnuladas)
        Me.GroupBox1.Controls.Add(Me.txtIdObrasocial)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtRecaudado)
        Me.GroupBox1.Controls.Add(Me.lblStatus)
        Me.GroupBox1.Controls.Add(Me.cmbObraSocial)
        Me.GroupBox1.Controls.Add(Me.lblEstadoPresentacion)
        Me.GroupBox1.Controls.Add(Me.txtObservacion)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.chkEliminado)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.dtpFECHA)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.GbFarmaciaForm)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(7, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(2134, 511)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'grdItems
        '
        Me.grdItems.AllowUserToAddRows = False
        Me.grdItems.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.grdItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.IdFarmacia, Me.CodigoFarmacia, Me.Nombre, Me.IdPresentacion, Me.Recetas, Me.Recaudad, Me.ACargoOS, Me.Bonificacion, Me.Total, Me.Eliminar})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdItems.DefaultCellStyle = DataGridViewCellStyle6
        Me.grdItems.Location = New System.Drawing.Point(346, 111)
        Me.grdItems.Name = "grdItems"
        Me.grdItems.RowHeadersWidth = 51
        Me.grdItems.Size = New System.Drawing.Size(989, 321)
        Me.grdItems.TabIndex = 13
        '
        'Id
        '
        Me.Id.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Id.HeaderText = "Id"
        Me.Id.MinimumWidth = 6
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        Me.Id.Width = 125
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BorrarElItemToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.BuscarDescripcionToolStripMenuItem, Me.BuscarDescripcionToolStripMenuItem2, Me.BuscarDescripcionToolStripMenuItem3})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(361, 129)
        '
        'BorrarElItemToolStripMenuItem
        '
        Me.BorrarElItemToolStripMenuItem.Name = "BorrarElItemToolStripMenuItem"
        Me.BorrarElItemToolStripMenuItem.Size = New System.Drawing.Size(360, 22)
        Me.BorrarElItemToolStripMenuItem.Text = "Borrar el Item"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(360, 22)
        Me.BuscarToolStripMenuItem.Text = "Buscar..."
        Me.BuscarToolStripMenuItem.Visible = False
        '
        'BuscarDescripcionToolStripMenuItem
        '
        Me.BuscarDescripcionToolStripMenuItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.BuscarDescripcionToolStripMenuItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.BuscarDescripcionToolStripMenuItem.DropDownWidth = 500
        Me.BuscarDescripcionToolStripMenuItem.Name = "BuscarDescripcionToolStripMenuItem"
        Me.BuscarDescripcionToolStripMenuItem.Size = New System.Drawing.Size(300, 23)
        Me.BuscarDescripcionToolStripMenuItem.Sorted = True
        Me.BuscarDescripcionToolStripMenuItem.Text = "Buscar Descripcion"
        Me.BuscarDescripcionToolStripMenuItem.Visible = False
        '
        'BuscarDescripcionToolStripMenuItem2
        '
        Me.BuscarDescripcionToolStripMenuItem2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.BuscarDescripcionToolStripMenuItem2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.BuscarDescripcionToolStripMenuItem2.DropDownWidth = 500
        Me.BuscarDescripcionToolStripMenuItem2.Name = "BuscarDescripcionToolStripMenuItem2"
        Me.BuscarDescripcionToolStripMenuItem2.Size = New System.Drawing.Size(300, 23)
        Me.BuscarDescripcionToolStripMenuItem2.Sorted = True
        Me.BuscarDescripcionToolStripMenuItem2.Text = "Buscar Descripcion"
        Me.BuscarDescripcionToolStripMenuItem2.Visible = False
        '
        'BuscarDescripcionToolStripMenuItem3
        '
        Me.BuscarDescripcionToolStripMenuItem3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.BuscarDescripcionToolStripMenuItem3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.BuscarDescripcionToolStripMenuItem3.DropDownWidth = 500
        Me.BuscarDescripcionToolStripMenuItem3.Name = "BuscarDescripcionToolStripMenuItem3"
        Me.BuscarDescripcionToolStripMenuItem3.Size = New System.Drawing.Size(300, 23)
        Me.BuscarDescripcionToolStripMenuItem3.Sorted = True
        Me.BuscarDescripcionToolStripMenuItem3.Text = "Buscar Descripcion"
        Me.BuscarDescripcionToolStripMenuItem3.Visible = False
        '
        'IdFarmacia
        '
        Me.IdFarmacia.HeaderText = "IdFarmacia"
        Me.IdFarmacia.Name = "IdFarmacia"
        Me.IdFarmacia.ReadOnly = True
        Me.IdFarmacia.Visible = False
        '
        'CodigoFarmacia
        '
        Me.CodigoFarmacia.HeaderText = "Cod. Farmacia"
        Me.CodigoFarmacia.MinimumWidth = 6
        Me.CodigoFarmacia.Name = "CodigoFarmacia"
        Me.CodigoFarmacia.ReadOnly = True
        Me.CodigoFarmacia.Visible = False
        Me.CodigoFarmacia.Width = 125
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Farmacia"
        Me.Nombre.MinimumWidth = 6
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 300
        '
        'IdPresentacion
        '
        DataGridViewCellStyle3.NullValue = Nothing
        Me.IdPresentacion.DefaultCellStyle = DataGridViewCellStyle3
        Me.IdPresentacion.HeaderText = "Id Presentación"
        Me.IdPresentacion.MinimumWidth = 6
        Me.IdPresentacion.Name = "IdPresentacion"
        Me.IdPresentacion.ReadOnly = True
        Me.IdPresentacion.Visible = False
        Me.IdPresentacion.Width = 120
        '
        'Recetas
        '
        Me.Recetas.HeaderText = "Recetas"
        Me.Recetas.MinimumWidth = 6
        Me.Recetas.Name = "Recetas"
        Me.Recetas.Width = 125
        '
        'Recaudad
        '
        Me.Recaudad.HeaderText = "Recaudado"
        Me.Recaudad.MinimumWidth = 6
        Me.Recaudad.Name = "Recaudad"
        Me.Recaudad.Width = 125
        '
        'ACargoOS
        '
        Me.ACargoOS.HeaderText = "A Cargo OS"
        Me.ACargoOS.MinimumWidth = 6
        Me.ACargoOS.Name = "ACargoOS"
        Me.ACargoOS.Width = 125
        '
        'Bonificacion
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Bonificacion.DefaultCellStyle = DataGridViewCellStyle4
        Me.Bonificacion.HeaderText = "Bonificación"
        Me.Bonificacion.MinimumWidth = 6
        Me.Bonificacion.Name = "Bonificacion"
        Me.Bonificacion.ReadOnly = True
        Me.Bonificacion.Width = 90
        '
        'Total
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Total.DefaultCellStyle = DataGridViewCellStyle5
        Me.Total.HeaderText = "Total"
        Me.Total.MinimumWidth = 6
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Width = 90
        '
        'Eliminar
        '
        Me.Eliminar.HeaderText = "Eliminar"
        Me.Eliminar.MinimumWidth = 6
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.ToolTipText = "Eliminar Registro"
        Me.Eliminar.UseColumnTextForButtonValue = True
        Me.Eliminar.Width = 80
        '
        'GbFarmaciaForm
        '
        Me.GbFarmaciaForm.Controls.Add(Me.txtBonificacion)
        Me.GbFarmaciaForm.Controls.Add(Me.Label13)
        Me.GbFarmaciaForm.Controls.Add(Me.nudBonificacion)
        Me.GbFarmaciaForm.Controls.Add(Me.cmbFarmacias)
        Me.GbFarmaciaForm.Controls.Add(Me.btnAgregarItem)
        Me.GbFarmaciaForm.Controls.Add(Me.Label12)
        Me.GbFarmaciaForm.Controls.Add(Me.txtImpRecaudado)
        Me.GbFarmaciaForm.Controls.Add(Me.txtImpACargoOs)
        Me.GbFarmaciaForm.Controls.Add(Me.Label6)
        Me.GbFarmaciaForm.Controls.Add(Me.Label16)
        Me.GbFarmaciaForm.Controls.Add(Me.Label5)
        Me.GbFarmaciaForm.Controls.Add(Me.Label10)
        Me.GbFarmaciaForm.Controls.Add(Me.txtImpTotalAPagar)
        Me.GbFarmaciaForm.Controls.Add(Me.txtRecetas)
        Me.GbFarmaciaForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbFarmaciaForm.Location = New System.Drawing.Point(15, 105)
        Me.GbFarmaciaForm.Name = "GbFarmaciaForm"
        Me.GbFarmaciaForm.Size = New System.Drawing.Size(335, 327)
        Me.GbFarmaciaForm.TabIndex = 342
        Me.GbFarmaciaForm.TabStop = False
        Me.GbFarmaciaForm.Text = "Añadir farmacia"
        '
        'txtBonificacion
        '
        Me.txtBonificacion.AccessibleName = ""
        Me.txtBonificacion.BackColor = System.Drawing.Color.White
        Me.txtBonificacion.Decimals = CType(2, Byte)
        Me.txtBonificacion.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtBonificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBonificacion.Format = TextBoxConFormatoVB.tbFormats.UnsignedFloatingPointNumber
        Me.txtBonificacion.Location = New System.Drawing.Point(132, 165)
        Me.txtBonificacion.MaxLength = 100
        Me.txtBonificacion.Name = "txtBonificacion"
        Me.txtBonificacion.Size = New System.Drawing.Size(175, 22)
        Me.txtBonificacion.TabIndex = 340
        Me.txtBonificacion.Text_1 = Nothing
        Me.txtBonificacion.Text_2 = Nothing
        Me.txtBonificacion.Text_3 = Nothing
        Me.txtBonificacion.Text_4 = Nothing
        Me.txtBonificacion.UserValues = Nothing
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(38, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 304
        Me.Label13.Text = "Farmacias"
        '
        'nudBonificacion
        '
        Me.nudBonificacion.DecimalPlaces = 2
        Me.nudBonificacion.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.nudBonificacion.Location = New System.Drawing.Point(38, 166)
        Me.nudBonificacion.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudBonificacion.Name = "nudBonificacion"
        Me.nudBonificacion.Size = New System.Drawing.Size(88, 22)
        Me.nudBonificacion.TabIndex = 9
        '
        'cmbFarmacias
        '
        Me.cmbFarmacias.AccessibleName = ""
        Me.cmbFarmacias.DropDownHeight = 450
        Me.cmbFarmacias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFarmacias.FormattingEnabled = True
        Me.cmbFarmacias.IntegralHeight = False
        Me.cmbFarmacias.Location = New System.Drawing.Point(38, 54)
        Me.cmbFarmacias.Name = "cmbFarmacias"
        Me.cmbFarmacias.Size = New System.Drawing.Size(195, 24)
        Me.cmbFarmacias.TabIndex = 5
        '
        'btnAgregarItem
        '
        Me.btnAgregarItem.Location = New System.Drawing.Point(126, 269)
        Me.btnAgregarItem.Name = "btnAgregarItem"
        Me.btnAgregarItem.Size = New System.Drawing.Size(78, 32)
        Me.btnAgregarItem.TabIndex = 10
        Me.btnAgregarItem.Text = "Agregar"
        Me.btnAgregarItem.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(35, 90)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 16)
        Me.Label12.TabIndex = 305
        Me.Label12.Text = "Imp. 100%"
        '
        'txtImpRecaudado
        '
        Me.txtImpRecaudado.AccessibleName = ""
        Me.txtImpRecaudado.BackColor = System.Drawing.Color.White
        Me.txtImpRecaudado.Decimals = CType(2, Byte)
        Me.txtImpRecaudado.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtImpRecaudado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImpRecaudado.Format = TextBoxConFormatoVB.tbFormats.UnsignedFloatingPointNumber
        Me.txtImpRecaudado.Location = New System.Drawing.Point(38, 110)
        Me.txtImpRecaudado.MaxLength = 100
        Me.txtImpRecaudado.Name = "txtImpRecaudado"
        Me.txtImpRecaudado.Size = New System.Drawing.Size(140, 22)
        Me.txtImpRecaudado.TabIndex = 7
        Me.txtImpRecaudado.Text_1 = Nothing
        Me.txtImpRecaudado.Text_2 = Nothing
        Me.txtImpRecaudado.Text_3 = Nothing
        Me.txtImpRecaudado.Text_4 = Nothing
        Me.txtImpRecaudado.UserValues = Nothing
        '
        'txtImpACargoOs
        '
        Me.txtImpACargoOs.AccessibleName = ""
        Me.txtImpACargoOs.Decimals = CType(2, Byte)
        Me.txtImpACargoOs.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtImpACargoOs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImpACargoOs.Format = TextBoxConFormatoVB.tbFormats.UnsignedFloatingPointNumber
        Me.txtImpACargoOs.Location = New System.Drawing.Point(184, 110)
        Me.txtImpACargoOs.MaxLength = 100
        Me.txtImpACargoOs.Name = "txtImpACargoOs"
        Me.txtImpACargoOs.Size = New System.Drawing.Size(123, 22)
        Me.txtImpACargoOs.TabIndex = 8
        Me.txtImpACargoOs.Text_1 = Nothing
        Me.txtImpACargoOs.Text_2 = Nothing
        Me.txtImpACargoOs.Text_3 = Nothing
        Me.txtImpACargoOs.Text_4 = Nothing
        Me.txtImpACargoOs.UserValues = Nothing
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(34, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 16)
        Me.Label6.TabIndex = 339
        Me.Label6.Text = "Bonificación"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(181, 90)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 16)
        Me.Label16.TabIndex = 330
        Me.Label16.Text = "Imp. A/c O.S"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(35, 217)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 337
        Me.Label5.Text = "Imp. A Pagar:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(246, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 16)
        Me.Label10.TabIndex = 335
        Me.Label10.Text = "Recetas"
        '
        'txtImpTotalAPagar
        '
        Me.txtImpTotalAPagar.AccessibleName = ""
        Me.txtImpTotalAPagar.Decimals = CType(2, Byte)
        Me.txtImpTotalAPagar.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtImpTotalAPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImpTotalAPagar.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtImpTotalAPagar.Location = New System.Drawing.Point(126, 214)
        Me.txtImpTotalAPagar.MaxLength = 100
        Me.txtImpTotalAPagar.Name = "txtImpTotalAPagar"
        Me.txtImpTotalAPagar.ReadOnly = True
        Me.txtImpTotalAPagar.Size = New System.Drawing.Size(179, 22)
        Me.txtImpTotalAPagar.TabIndex = 336
        Me.txtImpTotalAPagar.Text_1 = Nothing
        Me.txtImpTotalAPagar.Text_2 = Nothing
        Me.txtImpTotalAPagar.Text_3 = Nothing
        Me.txtImpTotalAPagar.Text_4 = Nothing
        Me.txtImpTotalAPagar.UserValues = Nothing
        '
        'txtRecetas
        '
        Me.txtRecetas.AccessibleName = ""
        Me.txtRecetas.Decimals = CType(0, Byte)
        Me.txtRecetas.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtRecetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecetas.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtRecetas.Location = New System.Drawing.Point(246, 54)
        Me.txtRecetas.MaxLength = 4
        Me.txtRecetas.Name = "txtRecetas"
        Me.txtRecetas.Size = New System.Drawing.Size(60, 22)
        Me.txtRecetas.TabIndex = 6
        Me.txtRecetas.Text_1 = Nothing
        Me.txtRecetas.Text_2 = Nothing
        Me.txtRecetas.Text_3 = Nothing
        Me.txtRecetas.Text_4 = Nothing
        Me.txtRecetas.UserValues = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 341
        Me.Label2.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(12, 36)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(98, 20)
        Me.txtCodigo.TabIndex = 340
        '
        'chkMaterialesProveedor
        '
        Me.chkMaterialesProveedor.AutoSize = True
        Me.chkMaterialesProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMaterialesProveedor.Location = New System.Drawing.Point(90, 65)
        Me.chkMaterialesProveedor.Margin = New System.Windows.Forms.Padding(2)
        Me.chkMaterialesProveedor.Name = "chkMaterialesProveedor"
        Me.chkMaterialesProveedor.Size = New System.Drawing.Size(104, 19)
        Me.chkMaterialesProveedor.TabIndex = 331
        Me.chkMaterialesProveedor.Text = "Por Proveedor"
        Me.chkMaterialesProveedor.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(905, 13)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 16)
        Me.Label15.TabIndex = 296
        Me.Label15.Text = "Período"
        '
        'txtPeriodo
        '
        Me.txtPeriodo.AccessibleName = "Nota"
        Me.txtPeriodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPeriodo.Decimals = CType(2, Byte)
        Me.txtPeriodo.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtPeriodo.Location = New System.Drawing.Point(909, 36)
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(194, 22)
        Me.txtPeriodo.TabIndex = 4
        Me.txtPeriodo.Text_1 = Nothing
        Me.txtPeriodo.Text_2 = Nothing
        Me.txtPeriodo.Text_3 = Nothing
        Me.txtPeriodo.Text_4 = Nothing
        Me.txtPeriodo.UserValues = Nothing
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(998, 484)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(80, 15)
        Me.Label20.TabIndex = 214
        Me.Label20.Text = "A Cargo OS"
        '
        'txtACargoOS
        '
        Me.txtACargoOS.AccessibleName = "Nota"
        Me.txtACargoOS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtACargoOS.Decimals = CType(2, Byte)
        Me.txtACargoOS.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtACargoOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtACargoOS.Format = TextBoxConFormatoVB.tbFormats.SignedFloatingPointNumber
        Me.txtACargoOS.Location = New System.Drawing.Point(1080, 481)
        Me.txtACargoOS.Name = "txtACargoOS"
        Me.txtACargoOS.ReadOnly = True
        Me.txtACargoOS.Size = New System.Drawing.Size(100, 21)
        Me.txtACargoOS.TabIndex = 213
        Me.txtACargoOS.Text_1 = Nothing
        Me.txtACargoOS.Text_2 = Nothing
        Me.txtACargoOS.Text_3 = Nothing
        Me.txtACargoOS.Text_4 = Nothing
        Me.txtACargoOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtACargoOS.UserValues = Nothing
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(1193, 484)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 15)
        Me.Label18.TabIndex = 212
        Me.Label18.Text = "Total"
        '
        'txtTotal
        '
        Me.txtTotal.AccessibleName = "Nota"
        Me.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotal.Decimals = CType(2, Byte)
        Me.txtTotal.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Format = TextBoxConFormatoVB.tbFormats.SignedFloatingPointNumber
        Me.txtTotal.Location = New System.Drawing.Point(1235, 481)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(100, 21)
        Me.txtTotal.TabIndex = 211
        Me.txtTotal.Text_1 = Nothing
        Me.txtTotal.Text_2 = Nothing
        Me.txtTotal.Text_3 = Nothing
        Me.txtTotal.Text_4 = Nothing
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotal.UserValues = Nothing
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(526, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 16)
        Me.Label14.TabIndex = 197
        Me.Label14.Text = "Observación"
        '
        'chkGrillaInferior
        '
        Me.chkGrillaInferior.AutoSize = True
        Me.chkGrillaInferior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGrillaInferior.Location = New System.Drawing.Point(179, 483)
        Me.chkGrillaInferior.Name = "chkGrillaInferior"
        Me.chkGrillaInferior.Size = New System.Drawing.Size(156, 17)
        Me.chkGrillaInferior.TabIndex = 187
        Me.chkGrillaInferior.Text = "Aumentar Grilla Inferior"
        Me.chkGrillaInferior.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 484)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 13)
        Me.Label19.TabIndex = 186
        Me.Label19.Text = "Cantidad de Ítems: "
        '
        'lblCantidadFilas
        '
        Me.lblCantidadFilas.AutoSize = True
        Me.lblCantidadFilas.Location = New System.Drawing.Point(108, 484)
        Me.lblCantidadFilas.Name = "lblCantidadFilas"
        Me.lblCantidadFilas.Size = New System.Drawing.Size(46, 13)
        Me.lblCantidadFilas.TabIndex = 185
        Me.lblCantidadFilas.Text = "Subtotal"
        '
        'rdTodasOC
        '
        Me.rdTodasOC.AutoSize = True
        Me.rdTodasOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdTodasOC.Location = New System.Drawing.Point(626, 483)
        Me.rdTodasOC.Name = "rdTodasOC"
        Me.rdTodasOC.Size = New System.Drawing.Size(60, 17)
        Me.rdTodasOC.TabIndex = 184
        Me.rdTodasOC.TabStop = True
        Me.rdTodasOC.Text = "Todas"
        Me.rdTodasOC.UseVisualStyleBackColor = True
        '
        'rdPendientes
        '
        Me.rdPendientes.AutoSize = True
        Me.rdPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdPendientes.Location = New System.Drawing.Point(407, 483)
        Me.rdPendientes.Name = "rdPendientes"
        Me.rdPendientes.Size = New System.Drawing.Size(88, 17)
        Me.rdPendientes.TabIndex = 183
        Me.rdPendientes.TabStop = True
        Me.rdPendientes.Text = "Pendientes"
        Me.rdPendientes.UseVisualStyleBackColor = True
        '
        'rdAnuladas
        '
        Me.rdAnuladas.AutoSize = True
        Me.rdAnuladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdAnuladas.Location = New System.Drawing.Point(522, 483)
        Me.rdAnuladas.Name = "rdAnuladas"
        Me.rdAnuladas.Size = New System.Drawing.Size(77, 17)
        Me.rdAnuladas.TabIndex = 182
        Me.rdAnuladas.TabStop = True
        Me.rdAnuladas.Text = "Anuladas"
        Me.rdAnuladas.UseVisualStyleBackColor = True
        '
        'txtIdObrasocial
        '
        Me.txtIdObrasocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdObrasocial.Decimals = CType(2, Byte)
        Me.txtIdObrasocial.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtIdObrasocial.Enabled = False
        Me.txtIdObrasocial.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtIdObrasocial.Location = New System.Drawing.Point(485, 14)
        Me.txtIdObrasocial.MaxLength = 8
        Me.txtIdObrasocial.Name = "txtIdObrasocial"
        Me.txtIdObrasocial.Size = New System.Drawing.Size(23, 20)
        Me.txtIdObrasocial.TabIndex = 179
        Me.txtIdObrasocial.Text_1 = Nothing
        Me.txtIdObrasocial.Text_2 = Nothing
        Me.txtIdObrasocial.Text_3 = Nothing
        Me.txtIdObrasocial.Text_4 = Nothing
        Me.txtIdObrasocial.UserValues = Nothing
        Me.txtIdObrasocial.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(778, 484)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 15)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "Importe 100%"
        '
        'txtRecaudado
        '
        Me.txtRecaudado.AccessibleName = "Nota"
        Me.txtRecaudado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRecaudado.Decimals = CType(2, Byte)
        Me.txtRecaudado.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtRecaudado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecaudado.Format = TextBoxConFormatoVB.tbFormats.SignedFloatingPointNumber
        Me.txtRecaudado.Location = New System.Drawing.Point(877, 481)
        Me.txtRecaudado.Name = "txtRecaudado"
        Me.txtRecaudado.ReadOnly = True
        Me.txtRecaudado.Size = New System.Drawing.Size(100, 21)
        Me.txtRecaudado.TabIndex = 130
        Me.txtRecaudado.Text_1 = Nothing
        Me.txtRecaudado.Text_2 = Nothing
        Me.txtRecaudado.Text_3 = Nothing
        Me.txtRecaudado.Text_4 = Nothing
        Me.txtRecaudado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRecaudado.UserValues = Nothing
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Green
        Me.lblStatus.Location = New System.Drawing.Point(1129, 35)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(194, 23)
        Me.lblStatus.TabIndex = 127
        Me.lblStatus.Text = "-------------"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbObraSocial
        '
        Me.cmbObraSocial.AccessibleName = "*ObraSocial"
        Me.cmbObraSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbObraSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbObraSocial.DropDownHeight = 300
        Me.cmbObraSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbObraSocial.FormattingEnabled = True
        Me.cmbObraSocial.IntegralHeight = False
        Me.cmbObraSocial.Location = New System.Drawing.Point(245, 34)
        Me.cmbObraSocial.Name = "cmbObraSocial"
        Me.cmbObraSocial.Size = New System.Drawing.Size(263, 24)
        Me.cmbObraSocial.TabIndex = 2
        '
        'lblEstadoPresentacion
        '
        Me.lblEstadoPresentacion.AutoSize = True
        Me.lblEstadoPresentacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoPresentacion.Location = New System.Drawing.Point(1129, 16)
        Me.lblEstadoPresentacion.Name = "lblEstadoPresentacion"
        Me.lblEstadoPresentacion.Size = New System.Drawing.Size(51, 16)
        Me.lblEstadoPresentacion.TabIndex = 123
        Me.lblEstadoPresentacion.Text = "Estado"
        '
        'txtObservacion
        '
        Me.txtObservacion.AccessibleName = "Observacion"
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Decimals = CType(2, Byte)
        Me.txtObservacion.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtObservacion.Location = New System.Drawing.Point(526, 36)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(366, 22)
        Me.txtObservacion.TabIndex = 3
        Me.txtObservacion.Text_1 = Nothing
        Me.txtObservacion.Text_2 = Nothing
        Me.txtObservacion.Text_3 = Nothing
        Me.txtObservacion.Text_4 = Nothing
        Me.txtObservacion.UserValues = Nothing
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(-72, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 118
        Me.Label8.Text = "Nota"
        '
        'chkEliminado
        '
        Me.chkEliminado.AccessibleName = "Eliminado"
        Me.chkEliminado.AutoSize = True
        Me.chkEliminado.Enabled = False
        Me.chkEliminado.Location = New System.Drawing.Point(14, 66)
        Me.chkEliminado.Name = "chkEliminado"
        Me.chkEliminado.Size = New System.Drawing.Size(71, 17)
        Me.chkEliminado.TabIndex = 6
        Me.chkEliminado.Text = "Eliminado"
        Me.chkEliminado.UseVisualStyleBackColor = True
        Me.chkEliminado.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(242, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 16)
        Me.Label7.TabIndex = 108
        Me.Label7.Text = "Obra Social*"
        '
        'txtID
        '
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.Decimals = CType(2, Byte)
        Me.txtID.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtID.Enabled = False
        Me.txtID.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtID.Location = New System.Drawing.Point(90, 17)
        Me.txtID.MaxLength = 8
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(20, 20)
        Me.txtID.TabIndex = 50
        Me.txtID.Text_1 = Nothing
        Me.txtID.Text_2 = Nothing
        Me.txtID.Text_3 = Nothing
        Me.txtID.Text_4 = Nothing
        Me.txtID.UserValues = Nothing
        Me.txtID.Visible = False
        '
        'dtpFECHA
        '
        Me.dtpFECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFECHA.Location = New System.Drawing.Point(127, 36)
        Me.dtpFECHA.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        Me.dtpFECHA.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtpFECHA.Name = "dtpFECHA"
        Me.dtpFECHA.Size = New System.Drawing.Size(102, 22)
        Me.dtpFECHA.TabIndex = 1
        Me.dtpFECHA.Tag = "202"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(128, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 16)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Fecha"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmbUnidadVenta})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(361, 158)
        '
        'cmbUnidadVenta
        '
        Me.cmbUnidadVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbUnidadVenta.DropDownWidth = 500
        Me.cmbUnidadVenta.Name = "cmbUnidadVenta"
        Me.cmbUnidadVenta.Size = New System.Drawing.Size(300, 150)
        Me.cmbUnidadVenta.Text = "Unidad de Venta"
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmbMonedasCompra})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(361, 158)
        '
        'cmbMonedasCompra
        '
        Me.cmbMonedasCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbMonedasCompra.DropDownWidth = 500
        Me.cmbMonedasCompra.Name = "cmbMonedasCompra"
        Me.cmbMonedasCompra.Size = New System.Drawing.Size(300, 150)
        Me.cmbMonedasCompra.Text = "Buscar Moneda"
        '
        'ContextMenuMarcas
        '
        Me.ContextMenuMarcas.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuMarcas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActivarNuevaMarcaToolStripMenuItem, Me.cmbMarcaCompra})
        Me.ContextMenuMarcas.Name = "ContextMenuStrip1"
        Me.ContextMenuMarcas.Size = New System.Drawing.Size(361, 180)
        '
        'ActivarNuevaMarcaToolStripMenuItem
        '
        Me.ActivarNuevaMarcaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActivarNuevaMarcaToolStripMenuItem.Name = "ActivarNuevaMarcaToolStripMenuItem"
        Me.ActivarNuevaMarcaToolStripMenuItem.Size = New System.Drawing.Size(360, 22)
        Me.ActivarNuevaMarcaToolStripMenuItem.Text = "Activar Nueva Marca"
        '
        'cmbMarcaCompra
        '
        Me.cmbMarcaCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbMarcaCompra.DropDownWidth = 500
        Me.cmbMarcaCompra.Name = "cmbMarcaCompra"
        Me.cmbMarcaCompra.Size = New System.Drawing.Size(300, 150)
        Me.cmbMarcaCompra.Text = "Buscar Marca"
        '
        'frmPresentaciones
        '
        Me.AccessibleName = "OrdenDeCompra"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 609)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmPresentaciones"
        Me.Text = "frmOrdenCompra"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GbFarmaciaForm.ResumeLayout(False)
        Me.GbFarmaciaForm.PerformLayout()
        CType(Me.nudBonificacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.ContextMenuMarcas.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservacion As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkEliminado As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtID As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents dtpFECHA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend Shadows WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BorrarElItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarDescripcionToolStripMenuItem As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents lblEstadoPresentacion As System.Windows.Forms.Label
    Friend WithEvents cmbObraSocial As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents BuscarDescripcionToolStripMenuItem2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents BuscarDescripcionToolStripMenuItem3 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRecaudado As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmbUnidadVenta As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ContextMenuStrip3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmbMonedasCompra As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents txtIdObrasocial As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents rdAnuladas As System.Windows.Forms.RadioButton
    Friend WithEvents rdTodasOC As System.Windows.Forms.RadioButton
    Friend WithEvents rdPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblCantidadFilas As System.Windows.Forms.Label
    Friend WithEvents chkGrillaInferior As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtACargoOS As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodo As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents ContextMenuMarcas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ActivarNuevaMarcaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbMarcaCompra As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents txtImpRecaudado As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbFarmacias As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents grdItems As System.Windows.Forms.DataGridView
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtImpACargoOs As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents chkMaterialesProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents txtRecetas As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label10 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtImpTotalAPagar As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents btnAgregarItem As Button
    Friend WithEvents nudBonificacion As NumericUpDown
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents IdFarmacia As DataGridViewTextBoxColumn
    Friend WithEvents CodigoFarmacia As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents IdPresentacion As DataGridViewTextBoxColumn
    Friend WithEvents Recetas As DataGridViewTextBoxColumn
    Friend WithEvents Recaudad As DataGridViewTextBoxColumn
    Friend WithEvents ACargoOS As DataGridViewTextBoxColumn
    Friend WithEvents Bonificacion As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents Eliminar As DataGridViewButtonColumn
    Friend WithEvents GbFarmaciaForm As GroupBox
    Friend WithEvents txtBonificacion As TextBoxConFormatoVB.FormattedTextBoxVB
End Class
