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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPresentaciones))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BorrarElItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarDescripcionToolStripMenuItem = New System.Windows.Forms.ToolStripComboBox()
        Me.BuscarDescripcionToolStripMenuItem2 = New System.Windows.Forms.ToolStripComboBox()
        Me.BuscarDescripcionToolStripMenuItem3 = New System.Windows.Forms.ToolStripComboBox()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmbUnidadVenta = New System.Windows.Forms.ToolStripComboBox()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmbMonedasCompra = New System.Windows.Forms.ToolStripComboBox()
        Me.ContextMenuMarcas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActivarNuevaMarcaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbMarcaCompra = New System.Windows.Forms.ToolStripComboBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ToolTipbtnSeparar = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipbtnUnificar = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbMain = New System.Windows.Forms.GroupBox()
        Me.btnOpenPeriodos = New System.Windows.Forms.Button()
        Me.gpTools = New System.Windows.Forms.GroupBox()
        Me.btnFacturar = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Line4 = New DevComponents.DotNetBar.Controls.Line()
        Me.btnImprimirRpt = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnPrescam = New System.Windows.Forms.Button()
        Me.Line3 = New DevComponents.DotNetBar.Controls.Line()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Line2 = New DevComponents.DotNetBar.Controls.Line()
        Me.btnRecetasWeb = New System.Windows.Forms.Button()
        Me.btnModificarItem = New System.Windows.Forms.Button()
        Me.btnAddFarmacia = New System.Windows.Forms.Button()
        Me.cmbPeriodos = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnUnificar = New System.Windows.Forms.Button()
        Me.btnSeparar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.grdItems = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdFarmacia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoFarmacia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdPlan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Plan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mensajeWeb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdPresentacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Recetas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Recaudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACargoOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bonificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodFacaf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodPlan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PorcentajePlan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Eliminar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtACargoOS = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtTotal = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkGrillaInferior = New System.Windows.Forms.CheckBox()
        Me.lblCantidadFilas = New System.Windows.Forms.Label()
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
        Me.BasicToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.ContextMenuMarcas.SuspendLayout()
        Me.gbMain.SuspendLayout()
        Me.gpTools.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BorrarElItemToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.BuscarDescripcionToolStripMenuItem, Me.BuscarDescripcionToolStripMenuItem2, Me.BuscarDescripcionToolStripMenuItem3})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(361, 148)
        '
        'BorrarElItemToolStripMenuItem
        '
        Me.BorrarElItemToolStripMenuItem.Name = "BorrarElItemToolStripMenuItem"
        Me.BorrarElItemToolStripMenuItem.Size = New System.Drawing.Size(360, 24)
        Me.BorrarElItemToolStripMenuItem.Text = "Borrar el Item"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(360, 24)
        Me.BuscarToolStripMenuItem.Text = "Buscar..."
        Me.BuscarToolStripMenuItem.Visible = False
        '
        'BuscarDescripcionToolStripMenuItem
        '
        Me.BuscarDescripcionToolStripMenuItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.BuscarDescripcionToolStripMenuItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.BuscarDescripcionToolStripMenuItem.DropDownWidth = 500
        Me.BuscarDescripcionToolStripMenuItem.Name = "BuscarDescripcionToolStripMenuItem"
        Me.BuscarDescripcionToolStripMenuItem.Size = New System.Drawing.Size(300, 28)
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
        Me.BuscarDescripcionToolStripMenuItem2.Size = New System.Drawing.Size(300, 28)
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
        Me.BuscarDescripcionToolStripMenuItem3.Size = New System.Drawing.Size(300, 28)
        Me.BuscarDescripcionToolStripMenuItem3.Sorted = True
        Me.BuscarDescripcionToolStripMenuItem3.Text = "Buscar Descripcion"
        Me.BuscarDescripcionToolStripMenuItem3.Visible = False
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
        Me.ContextMenuMarcas.Size = New System.Drawing.Size(361, 182)
        '
        'ActivarNuevaMarcaToolStripMenuItem
        '
        Me.ActivarNuevaMarcaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActivarNuevaMarcaToolStripMenuItem.Name = "ActivarNuevaMarcaToolStripMenuItem"
        Me.ActivarNuevaMarcaToolStripMenuItem.Size = New System.Drawing.Size(360, 24)
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
        'gbMain
        '
        Me.gbMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbMain.BackColor = System.Drawing.Color.Transparent
        Me.gbMain.Controls.Add(Me.btnOpenPeriodos)
        Me.gbMain.Controls.Add(Me.gpTools)
        Me.gbMain.Controls.Add(Me.cmbPeriodos)
        Me.gbMain.Controls.Add(Me.Label19)
        Me.gbMain.Controls.Add(Me.GroupBox2)
        Me.gbMain.Controls.Add(Me.Label9)
        Me.gbMain.Controls.Add(Me.cmbEstado)
        Me.gbMain.Controls.Add(Me.grdItems)
        Me.gbMain.Controls.Add(Me.Label2)
        Me.gbMain.Controls.Add(Me.txtCodigo)
        Me.gbMain.Controls.Add(Me.Label15)
        Me.gbMain.Controls.Add(Me.Label20)
        Me.gbMain.Controls.Add(Me.txtACargoOS)
        Me.gbMain.Controls.Add(Me.Label18)
        Me.gbMain.Controls.Add(Me.txtTotal)
        Me.gbMain.Controls.Add(Me.Label14)
        Me.gbMain.Controls.Add(Me.chkGrillaInferior)
        Me.gbMain.Controls.Add(Me.lblCantidadFilas)
        Me.gbMain.Controls.Add(Me.txtIdObrasocial)
        Me.gbMain.Controls.Add(Me.Label4)
        Me.gbMain.Controls.Add(Me.txtRecaudado)
        Me.gbMain.Controls.Add(Me.lblStatus)
        Me.gbMain.Controls.Add(Me.cmbObraSocial)
        Me.gbMain.Controls.Add(Me.lblEstadoPresentacion)
        Me.gbMain.Controls.Add(Me.txtObservacion)
        Me.gbMain.Controls.Add(Me.Label8)
        Me.gbMain.Controls.Add(Me.chkEliminado)
        Me.gbMain.Controls.Add(Me.Label7)
        Me.gbMain.Controls.Add(Me.txtID)
        Me.gbMain.Controls.Add(Me.dtpFECHA)
        Me.gbMain.Controls.Add(Me.Label3)
        Me.gbMain.ForeColor = System.Drawing.Color.Blue
        Me.gbMain.Location = New System.Drawing.Point(4, 37)
        Me.gbMain.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbMain.Size = New System.Drawing.Size(2141, 591)
        Me.gbMain.TabIndex = 1
        Me.gbMain.TabStop = False
        '
        'btnOpenPeriodos
        '
        Me.btnOpenPeriodos.Image = Global.CENPROFAR.My.Resources.Resources.ver
        Me.btnOpenPeriodos.Location = New System.Drawing.Point(1213, 14)
        Me.btnOpenPeriodos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOpenPeriodos.Name = "btnOpenPeriodos"
        Me.btnOpenPeriodos.Size = New System.Drawing.Size(35, 28)
        Me.btnOpenPeriodos.TabIndex = 360
        Me.BasicToolTip.SetToolTip(Me.btnOpenPeriodos, "Ir a pantalla de periodos de presentaci�n.")
        Me.btnOpenPeriodos.UseVisualStyleBackColor = True
        '
        'gpTools
        '
        Me.gpTools.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpTools.Controls.Add(Me.btnFacturar)
        Me.gpTools.Controls.Add(Me.Label10)
        Me.gpTools.Controls.Add(Me.Line4)
        Me.gpTools.Controls.Add(Me.btnImprimirRpt)
        Me.gpTools.Controls.Add(Me.Label6)
        Me.gpTools.Controls.Add(Me.btnPrescam)
        Me.gpTools.Controls.Add(Me.Line3)
        Me.gpTools.Controls.Add(Me.Label5)
        Me.gpTools.Controls.Add(Me.Label1)
        Me.gpTools.Controls.Add(Me.Line2)
        Me.gpTools.Controls.Add(Me.btnRecetasWeb)
        Me.gpTools.Controls.Add(Me.btnModificarItem)
        Me.gpTools.Controls.Add(Me.btnAddFarmacia)
        Me.gpTools.Location = New System.Drawing.Point(1095, 107)
        Me.gpTools.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gpTools.Name = "gpTools"
        Me.gpTools.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gpTools.Size = New System.Drawing.Size(285, 396)
        Me.gpTools.TabIndex = 359
        Me.gpTools.TabStop = False
        Me.gpTools.Text = "Cuadro de herramientas"
        '
        'btnFacturar
        '
        Me.btnFacturar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFacturar.Image = CType(resources.GetObject("btnFacturar.Image"), System.Drawing.Image)
        Me.btnFacturar.Location = New System.Drawing.Point(97, 332)
        Me.btnFacturar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnFacturar.Name = "btnFacturar"
        Me.btnFacturar.Size = New System.Drawing.Size(101, 38)
        Me.btnFacturar.TabIndex = 367
        Me.btnFacturar.Text = "Facturar"
        Me.btnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFacturar.UseVisualStyleBackColor = True
        Me.btnFacturar.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label10.Location = New System.Drawing.Point(23, 46)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(127, 17)
        Me.Label10.TabIndex = 366
        Me.Label10.Text = "Items presentaci�n"
        '
        'Line4
        '
        Me.Line4.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Line4.Location = New System.Drawing.Point(161, 43)
        Me.Line4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Line4.Name = "Line4"
        Me.Line4.Size = New System.Drawing.Size(96, 23)
        Me.Line4.TabIndex = 365
        Me.Line4.Text = "Line4"
        '
        'btnImprimirRpt
        '
        Me.btnImprimirRpt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnImprimirRpt.Image = Global.CENPROFAR.My.Resources.Resources.printing
        Me.btnImprimirRpt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimirRpt.Location = New System.Drawing.Point(19, 274)
        Me.btnImprimirRpt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnImprimirRpt.Name = "btnImprimirRpt"
        Me.btnImprimirRpt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnImprimirRpt.Size = New System.Drawing.Size(112, 38)
        Me.btnImprimirRpt.TabIndex = 364
        Me.btnImprimirRpt.Text = "Imprimir"
        Me.btnImprimirRpt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImprimirRpt.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label6.Location = New System.Drawing.Point(23, 249)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 17)
        Me.Label6.TabIndex = 363
        Me.Label6.Text = "Reportes"
        '
        'btnPrescam
        '
        Me.btnPrescam.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrescam.Image = Global.CENPROFAR.My.Resources.Resources.facaf
        Me.btnPrescam.Location = New System.Drawing.Point(161, 276)
        Me.btnPrescam.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPrescam.Name = "btnPrescam"
        Me.btnPrescam.Size = New System.Drawing.Size(101, 38)
        Me.btnPrescam.TabIndex = 347
        Me.btnPrescam.Text = "Prescam"
        Me.btnPrescam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrescam.UseVisualStyleBackColor = True
        '
        'Line3
        '
        Me.Line3.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Line3.Location = New System.Drawing.Point(97, 246)
        Me.Line3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Line3.Name = "Line3"
        Me.Line3.Size = New System.Drawing.Size(160, 23)
        Me.Line3.TabIndex = 362
        Me.Line3.Text = "Line3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label5.Location = New System.Drawing.Point(23, 149)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 17)
        Me.Label5.TabIndex = 361
        Me.Label5.Text = "Presentaciones web"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(169, 186)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 360
        Me.Label1.Text = "0 Registros"
        '
        'Line2
        '
        Me.Line2.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Line2.Location = New System.Drawing.Point(161, 146)
        Me.Line2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(96, 23)
        Me.Line2.TabIndex = 359
        Me.Line2.Text = "Line2"
        '
        'btnRecetasWeb
        '
        Me.btnRecetasWeb.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRecetasWeb.Image = Global.CENPROFAR.My.Resources.Resources.web
        Me.btnRecetasWeb.Location = New System.Drawing.Point(19, 175)
        Me.btnRecetasWeb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRecetasWeb.Name = "btnRecetasWeb"
        Me.btnRecetasWeb.Size = New System.Drawing.Size(140, 38)
        Me.btnRecetasWeb.TabIndex = 355
        Me.btnRecetasWeb.Text = "Recetas web"
        Me.btnRecetasWeb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRecetasWeb.UseVisualStyleBackColor = True
        '
        'btnModificarItem
        '
        Me.btnModificarItem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnModificarItem.Image = Global.CENPROFAR.My.Resources.Resources.change
        Me.btnModificarItem.Location = New System.Drawing.Point(161, 70)
        Me.btnModificarItem.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnModificarItem.Name = "btnModificarItem"
        Me.btnModificarItem.Size = New System.Drawing.Size(101, 38)
        Me.btnModificarItem.TabIndex = 358
        Me.btnModificarItem.Text = "Modificar"
        Me.btnModificarItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BasicToolTip.SetToolTip(Me.btnModificarItem, "Modificar presentaci�n de recetas.")
        Me.btnModificarItem.UseVisualStyleBackColor = True
        '
        'btnAddFarmacia
        '
        Me.btnAddFarmacia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddFarmacia.Image = Global.CENPROFAR.My.Resources.Resources.add
        Me.btnAddFarmacia.Location = New System.Drawing.Point(19, 70)
        Me.btnAddFarmacia.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAddFarmacia.Name = "btnAddFarmacia"
        Me.btnAddFarmacia.Size = New System.Drawing.Size(132, 38)
        Me.btnAddFarmacia.TabIndex = 357
        Me.btnAddFarmacia.Text = "Agregar (F2)"
        Me.btnAddFarmacia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BasicToolTip.SetToolTip(Me.btnAddFarmacia, "A�adir presentaci�n de recetas.")
        Me.btnAddFarmacia.UseVisualStyleBackColor = True
        '
        'cmbPeriodos
        '
        Me.cmbPeriodos.AccessibleName = "*Periodo"
        Me.cmbPeriodos.DisplayMember = "Text"
        Me.cmbPeriodos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPeriodos.FormattingEnabled = True
        Me.cmbPeriodos.ItemHeight = 14
        Me.cmbPeriodos.Location = New System.Drawing.Point(1135, 44)
        Me.cmbPeriodos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbPeriodos.Name = "cmbPeriodos"
        Me.cmbPeriodos.Size = New System.Drawing.Size(283, 20)
        Me.cmbPeriodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodos.TabIndex = 356
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(689, 89)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(129, 17)
        Me.Label19.TabIndex = 186
        Me.Label19.Text = "Cantidad de �tems: "
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnUnificar)
        Me.GroupBox2.Controls.Add(Me.btnSeparar)
        Me.GroupBox2.Location = New System.Drawing.Point(604, 510)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(313, 71)
        Me.GroupBox2.TabIndex = 347
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Separar / Unificar Presentaci�nes"
        '
        'btnUnificar
        '
        Me.btnUnificar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnUnificar.Location = New System.Drawing.Point(31, 22)
        Me.btnUnificar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnUnificar.Name = "btnUnificar"
        Me.btnUnificar.Size = New System.Drawing.Size(101, 38)
        Me.btnUnificar.TabIndex = 340
        Me.btnUnificar.Text = "Unificar"
        Me.btnUnificar.UseVisualStyleBackColor = True
        '
        'btnSeparar
        '
        Me.btnSeparar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSeparar.Location = New System.Drawing.Point(179, 22)
        Me.btnSeparar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSeparar.Name = "btnSeparar"
        Me.btnSeparar.Size = New System.Drawing.Size(101, 38)
        Me.btnSeparar.TabIndex = 346
        Me.btnSeparar.Text = "Separar"
        Me.btnSeparar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(259, 521)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 17)
        Me.Label9.TabIndex = 345
        Me.Label9.Text = "Estado"
        '
        'cmbEstado
        '
        Me.cmbEstado.AccessibleName = ""
        Me.cmbEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEstado.DropDownHeight = 300
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.IntegralHeight = False
        Me.cmbEstado.Items.AddRange(New Object() {"TODAS", "PENDIENTES", "PARA LIQUIDAR", "LIQUIDADAS", "PAGAS"})
        Me.cmbEstado.Location = New System.Drawing.Point(261, 540)
        Me.cmbEstado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(279, 28)
        Me.cmbEstado.TabIndex = 343
        '
        'grdItems
        '
        Me.grdItems.AllowUserToAddRows = False
        Me.grdItems.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.grdItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.IdFarmacia, Me.CodigoFarmacia, Me.Nombre, Me.IdPlan, Me.Plan, Me.Observacion, Me.mensajeWeb, Me.IdPresentacion, Me.Recetas, Me.Recaudad, Me.ACargoOS, Me.Bonificacion, Me.Total, Me.CodFacaf, Me.CodPlan, Me.PorcentajePlan, Me.Eliminar})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdItems.DefaultCellStyle = DataGridViewCellStyle6
        Me.grdItems.Location = New System.Drawing.Point(16, 116)
        Me.grdItems.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grdItems.Name = "grdItems"
        Me.grdItems.RowHeadersVisible = False
        Me.grdItems.RowHeadersWidth = 51
        Me.grdItems.Size = New System.Drawing.Size(1060, 388)
        Me.grdItems.TabIndex = 13
        '
        'Id
        '
        Me.Id.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Id.HeaderText = "Id"
        Me.Id.MinimumWidth = 6
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'IdFarmacia
        '
        Me.IdFarmacia.HeaderText = "IdFarmacia"
        Me.IdFarmacia.MinimumWidth = 6
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
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Farmacia"
        Me.Nombre.MinimumWidth = 6
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'IdPlan
        '
        Me.IdPlan.HeaderText = "IdPlan"
        Me.IdPlan.MinimumWidth = 6
        Me.IdPlan.Name = "IdPlan"
        Me.IdPlan.ReadOnly = True
        Me.IdPlan.Visible = False
        '
        'Plan
        '
        Me.Plan.HeaderText = "Plan"
        Me.Plan.MinimumWidth = 6
        Me.Plan.Name = "Plan"
        Me.Plan.ReadOnly = True
        '
        'Observacion
        '
        Me.Observacion.HeaderText = "Observaci�n"
        Me.Observacion.MinimumWidth = 6
        Me.Observacion.Name = "Observacion"
        Me.Observacion.ReadOnly = True
        '
        'mensajeWeb
        '
        Me.mensajeWeb.HeaderText = "mensajeWeb"
        Me.mensajeWeb.MinimumWidth = 6
        Me.mensajeWeb.Name = "mensajeWeb"
        Me.mensajeWeb.ReadOnly = True
        Me.mensajeWeb.Visible = False
        '
        'IdPresentacion
        '
        DataGridViewCellStyle3.NullValue = Nothing
        Me.IdPresentacion.DefaultCellStyle = DataGridViewCellStyle3
        Me.IdPresentacion.HeaderText = "Id Presentaci�n"
        Me.IdPresentacion.MinimumWidth = 6
        Me.IdPresentacion.Name = "IdPresentacion"
        Me.IdPresentacion.ReadOnly = True
        Me.IdPresentacion.Visible = False
        '
        'Recetas
        '
        Me.Recetas.HeaderText = "Recetas"
        Me.Recetas.MinimumWidth = 6
        Me.Recetas.Name = "Recetas"
        Me.Recetas.ReadOnly = True
        '
        'Recaudad
        '
        Me.Recaudad.HeaderText = "Recaudado"
        Me.Recaudad.MinimumWidth = 6
        Me.Recaudad.Name = "Recaudad"
        Me.Recaudad.ReadOnly = True
        '
        'ACargoOS
        '
        Me.ACargoOS.HeaderText = "A Cargo OS"
        Me.ACargoOS.MinimumWidth = 6
        Me.ACargoOS.Name = "ACargoOS"
        Me.ACargoOS.ReadOnly = True
        '
        'Bonificacion
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Bonificacion.DefaultCellStyle = DataGridViewCellStyle4
        Me.Bonificacion.HeaderText = "Bonificaci�n"
        Me.Bonificacion.MinimumWidth = 6
        Me.Bonificacion.Name = "Bonificacion"
        Me.Bonificacion.ReadOnly = True
        '
        'Total
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Total.DefaultCellStyle = DataGridViewCellStyle5
        Me.Total.HeaderText = "Total"
        Me.Total.MinimumWidth = 6
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'CodFacaf
        '
        Me.CodFacaf.HeaderText = "CodFacaf"
        Me.CodFacaf.MinimumWidth = 6
        Me.CodFacaf.Name = "CodFacaf"
        Me.CodFacaf.ReadOnly = True
        Me.CodFacaf.Visible = False
        '
        'CodPlan
        '
        Me.CodPlan.HeaderText = "CodPlan"
        Me.CodPlan.MinimumWidth = 6
        Me.CodPlan.Name = "CodPlan"
        Me.CodPlan.ReadOnly = True
        Me.CodPlan.Visible = False
        '
        'PorcentajePlan
        '
        Me.PorcentajePlan.HeaderText = "Porc Plan"
        Me.PorcentajePlan.MinimumWidth = 6
        Me.PorcentajePlan.Name = "PorcentajePlan"
        Me.PorcentajePlan.ReadOnly = True
        Me.PorcentajePlan.Visible = False
        '
        'Eliminar
        '
        Me.Eliminar.HeaderText = "Eliminar"
        Me.Eliminar.MinimumWidth = 6
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.ToolTipText = "Eliminar Registro"
        Me.Eliminar.UseColumnTextForButtonValue = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(15, 17)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 20)
        Me.Label2.TabIndex = 341
        Me.Label2.Text = "C�digo"
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(16, 43)
        Me.txtCodigo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(129, 22)
        Me.txtCodigo.TabIndex = 340
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(1131, 17)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 20)
        Me.Label15.TabIndex = 296
        Me.Label15.Text = "Per�odo*"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(1139, 517)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 18)
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
        Me.txtACargoOS.Location = New System.Drawing.Point(1143, 539)
        Me.txtACargoOS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtACargoOS.Name = "txtACargoOS"
        Me.txtACargoOS.ReadOnly = True
        Me.txtACargoOS.Size = New System.Drawing.Size(132, 24)
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
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(1289, 516)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 18)
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
        Me.txtTotal.Location = New System.Drawing.Point(1292, 539)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(132, 24)
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
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(665, 17)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(103, 20)
        Me.Label14.TabIndex = 197
        Me.Label14.Text = "Observaci�n"
        '
        'chkGrillaInferior
        '
        Me.chkGrillaInferior.AutoSize = True
        Me.chkGrillaInferior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGrillaInferior.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkGrillaInferior.Location = New System.Drawing.Point(43, 544)
        Me.chkGrillaInferior.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkGrillaInferior.Name = "chkGrillaInferior"
        Me.chkGrillaInferior.Size = New System.Drawing.Size(200, 21)
        Me.chkGrillaInferior.TabIndex = 187
        Me.chkGrillaInferior.Text = "Aumentar Grilla Inferior"
        Me.chkGrillaInferior.UseVisualStyleBackColor = True
        '
        'lblCantidadFilas
        '
        Me.lblCantidadFilas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCantidadFilas.AutoSize = True
        Me.lblCantidadFilas.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCantidadFilas.Location = New System.Drawing.Point(823, 89)
        Me.lblCantidadFilas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCantidadFilas.Name = "lblCantidadFilas"
        Me.lblCantidadFilas.Size = New System.Drawing.Size(60, 17)
        Me.lblCantidadFilas.TabIndex = 185
        Me.lblCantidadFilas.Text = "Subtotal"
        Me.lblCantidadFilas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIdObrasocial
        '
        Me.txtIdObrasocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdObrasocial.Decimals = CType(2, Byte)
        Me.txtIdObrasocial.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtIdObrasocial.Enabled = False
        Me.txtIdObrasocial.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtIdObrasocial.Location = New System.Drawing.Point(623, 17)
        Me.txtIdObrasocial.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIdObrasocial.MaxLength = 8
        Me.txtIdObrasocial.Name = "txtIdObrasocial"
        Me.txtIdObrasocial.Size = New System.Drawing.Size(29, 22)
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
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(988, 517)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 18)
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
        Me.txtRecaudado.Location = New System.Drawing.Point(992, 539)
        Me.txtRecaudado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRecaudado.Name = "txtRecaudado"
        Me.txtRecaudado.ReadOnly = True
        Me.txtRecaudado.Size = New System.Drawing.Size(132, 24)
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
        Me.lblStatus.Location = New System.Drawing.Point(1432, 42)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(171, 28)
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
        Me.cmbObraSocial.Location = New System.Drawing.Point(327, 42)
        Me.cmbObraSocial.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbObraSocial.Name = "cmbObraSocial"
        Me.cmbObraSocial.Size = New System.Drawing.Size(325, 28)
        Me.cmbObraSocial.TabIndex = 1
        '
        'lblEstadoPresentacion
        '
        Me.lblEstadoPresentacion.AutoSize = True
        Me.lblEstadoPresentacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoPresentacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEstadoPresentacion.Location = New System.Drawing.Point(1432, 17)
        Me.lblEstadoPresentacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEstadoPresentacion.Name = "lblEstadoPresentacion"
        Me.lblEstadoPresentacion.Size = New System.Drawing.Size(61, 20)
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
        Me.txtObservacion.Location = New System.Drawing.Point(669, 43)
        Me.txtObservacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(448, 26)
        Me.txtObservacion.TabIndex = 2
        Me.txtObservacion.Text_1 = Nothing
        Me.txtObservacion.Text_2 = Nothing
        Me.txtObservacion.Text_3 = Nothing
        Me.txtObservacion.Text_4 = Nothing
        Me.txtObservacion.UserValues = Nothing
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(-96, 69)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 17)
        Me.Label8.TabIndex = 118
        Me.Label8.Text = "Nota"
        '
        'chkEliminado
        '
        Me.chkEliminado.AccessibleName = "Eliminado"
        Me.chkEliminado.AutoSize = True
        Me.chkEliminado.Enabled = False
        Me.chkEliminado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkEliminado.Location = New System.Drawing.Point(19, 81)
        Me.chkEliminado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkEliminado.Name = "chkEliminado"
        Me.chkEliminado.Size = New System.Drawing.Size(91, 21)
        Me.chkEliminado.TabIndex = 6
        Me.chkEliminado.Text = "Eliminado"
        Me.chkEliminado.UseVisualStyleBackColor = True
        Me.chkEliminado.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(323, 17)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 20)
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
        Me.txtID.Location = New System.Drawing.Point(120, 20)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtID.MaxLength = 8
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(25, 22)
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
        Me.dtpFECHA.Location = New System.Drawing.Point(169, 43)
        Me.dtpFECHA.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpFECHA.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        Me.dtpFECHA.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtpFECHA.Name = "dtpFECHA"
        Me.dtpFECHA.Size = New System.Drawing.Size(135, 26)
        Me.dtpFECHA.TabIndex = 0
        Me.dtpFECHA.Tag = "202"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(165, 17)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 20)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Fecha"
        '
        'frmPresentaciones
        '
        Me.AccessibleName = "OrdenDeCompra"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1371, 750)
        Me.Controls.Add(Me.gbMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "frmPresentaciones"
        Me.ShowIcon = False
        Me.Text = "Presentaciones"
        Me.Controls.SetChildIndex(Me.gbMain, 0)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.ContextMenuMarcas.ResumeLayout(False)
        Me.gbMain.ResumeLayout(False)
        Me.gbMain.PerformLayout()
        Me.gpTools.ResumeLayout(False)
        Me.gpTools.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grdItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend Shadows WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BorrarElItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarDescripcionToolStripMenuItem As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents BuscarDescripcionToolStripMenuItem2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents BuscarDescripcionToolStripMenuItem3 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmbUnidadVenta As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ContextMenuStrip3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmbMonedasCompra As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ContextMenuMarcas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ActivarNuevaMarcaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbMarcaCompra As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolTipbtnSeparar As ToolTip
    Friend WithEvents ToolTipbtnUnificar As ToolTip
    Friend WithEvents gbMain As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnUnificar As Button
    Friend WithEvents btnSeparar As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents grdItems As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtACargoOS As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label18 As Label
    Friend WithEvents txtTotal As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label14 As Label
    Friend WithEvents chkGrillaInferior As CheckBox
    Friend WithEvents Label19 As Label
    Friend WithEvents lblCantidadFilas As Label
    Friend WithEvents txtIdObrasocial As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRecaudado As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents lblStatus As Label
    Friend WithEvents cmbObraSocial As ComboBox
    Friend WithEvents lblEstadoPresentacion As Label
    Friend WithEvents txtObservacion As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label8 As Label
    Friend WithEvents chkEliminado As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtID As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents dtpFECHA As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents btnPrescam As Button
    Friend WithEvents btnRecetasWeb As Button
    Friend WithEvents cmbPeriodos As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents btnAddFarmacia As Button
    Friend WithEvents btnModificarItem As Button
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents IdFarmacia As DataGridViewTextBoxColumn
    Friend WithEvents CodigoFarmacia As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents IdPlan As DataGridViewTextBoxColumn
    Friend WithEvents Plan As DataGridViewTextBoxColumn
    Friend WithEvents Observacion As DataGridViewTextBoxColumn
    Friend WithEvents mensajeWeb As DataGridViewTextBoxColumn
    Friend WithEvents IdPresentacion As DataGridViewTextBoxColumn
    Friend WithEvents Recetas As DataGridViewTextBoxColumn
    Friend WithEvents Recaudad As DataGridViewTextBoxColumn
    Friend WithEvents ACargoOS As DataGridViewTextBoxColumn
    Friend WithEvents Bonificacion As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents CodFacaf As DataGridViewTextBoxColumn
    Friend WithEvents CodPlan As DataGridViewTextBoxColumn
    Friend WithEvents PorcentajePlan As DataGridViewTextBoxColumn
    Friend WithEvents Eliminar As DataGridViewButtonColumn
    Friend WithEvents gpTools As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Line4 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents btnImprimirRpt As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Line3 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Line2 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents btnOpenPeriodos As Button
    Friend WithEvents BasicToolTip As ToolTip
    Friend WithEvents btnFacturar As Button
End Class
