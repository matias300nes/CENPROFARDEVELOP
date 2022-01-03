<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLiquidaciones
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
        Dim Background8 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background9 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background10 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background11 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background12 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background13 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background14 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkAgrupado = New System.Windows.Forms.CheckBox()
        Me.lblCantidadItems = New System.Windows.Forms.Label()
        Me.lblCantLiq = New System.Windows.Forms.Label()
        Me.chkGrillaInferior = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.SuperGrdResultado = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.cmbTipoPago = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.pagoUnico = New DevComponents.Editors.ComboItem()
        Me.pagoAnticipo = New DevComponents.Editors.ComboItem()
        Me.chkComisionCentro = New System.Windows.Forms.CheckBox()
        Me.chkImpCheque = New System.Windows.Forms.CheckBox()
        Me.chkIngresosBrutos = New System.Windows.Forms.CheckBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnExcelWindow = New DevComponents.DotNetBar.ButtonX()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblFecha_presentacion = New System.Windows.Forms.Label()
        Me.lblPeriodo_presentacion = New System.Windows.Forms.Label()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.lblObraSocial = New System.Windows.Forms.Label()
        Me.lblStatus_presentacion = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblPresentacionCodigo = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btnCargarPresentacion = New DevComponents.DotNetBar.ButtonX()
        Me.txtIdPresentacion = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblcuit = New System.Windows.Forms.Label()
        Me.lblcmbObrasSociales = New System.Windows.Forms.Label()
        Me.dtpFECHA = New System.Windows.Forms.DateTimePicker()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BorrarElItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarDescripcionToolStripMenuItem = New System.Windows.Forms.ToolStripComboBox()
        Me.ContextMenuStripIVA = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BorrarElItemToolStripMenuItemIVA = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStripIVA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.chkAgrupado)
        Me.GroupBox1.Controls.Add(Me.lblCantidadItems)
        Me.GroupBox1.Controls.Add(Me.lblCantLiq)
        Me.GroupBox1.Controls.Add(Me.chkGrillaInferior)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.lblFecha_presentacion)
        Me.GroupBox1.Controls.Add(Me.lblPeriodo_presentacion)
        Me.GroupBox1.Controls.Add(Me.lblObservacion)
        Me.GroupBox1.Controls.Add(Me.lblObraSocial)
        Me.GroupBox1.Controls.Add(Me.lblStatus_presentacion)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.lblPresentacionCodigo)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.btnCargarPresentacion)
        Me.GroupBox1.Controls.Add(Me.txtIdPresentacion)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.lblID)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.lblcuit)
        Me.GroupBox1.Controls.Add(Me.lblcmbObrasSociales)
        Me.GroupBox1.Controls.Add(Me.dtpFECHA)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(0, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1724, 481)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'chkAgrupado
        '
        Me.chkAgrupado.AutoSize = True
        Me.chkAgrupado.Enabled = False
        Me.chkAgrupado.Location = New System.Drawing.Point(211, 69)
        Me.chkAgrupado.Name = "chkAgrupado"
        Me.chkAgrupado.Size = New System.Drawing.Size(133, 17)
        Me.chkAgrupado.TabIndex = 418
        Me.chkAgrupado.Text = "Agrupada por farmacia"
        Me.chkAgrupado.UseVisualStyleBackColor = True
        '
        'lblCantidadItems
        '
        Me.lblCantidadItems.AutoSize = True
        Me.lblCantidadItems.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCantidadItems.Location = New System.Drawing.Point(1017, 88)
        Me.lblCantidadItems.Name = "lblCantidadItems"
        Me.lblCantidadItems.Size = New System.Drawing.Size(52, 13)
        Me.lblCantidadItems.TabIndex = 270
        Me.lblCantidadItems.Text = "[Subtotal]"
        Me.lblCantidadItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCantLiq
        '
        Me.lblCantLiq.AutoSize = True
        Me.lblCantLiq.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCantLiq.Location = New System.Drawing.Point(102, 452)
        Me.lblCantLiq.Name = "lblCantLiq"
        Me.lblCantLiq.Size = New System.Drawing.Size(52, 13)
        Me.lblCantLiq.TabIndex = 387
        Me.lblCantLiq.Text = "[Subtotal]"
        '
        'chkGrillaInferior
        '
        Me.chkGrillaInferior.AutoSize = True
        Me.chkGrillaInferior.Location = New System.Drawing.Point(179, 452)
        Me.chkGrillaInferior.Name = "chkGrillaInferior"
        Me.chkGrillaInferior.Size = New System.Drawing.Size(132, 17)
        Me.chkGrillaInferior.TabIndex = 272
        Me.chkGrillaInferior.Text = "Aumentar Grilla Inferior"
        Me.chkGrillaInferior.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label19.Location = New System.Drawing.Point(12, 452)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 13)
        Me.Label19.TabIndex = 271
        Me.Label19.Text = "Cantidad de Ítems: "
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.34251!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.65748!))
        Me.TableLayoutPanel1.Controls.Add(Me.SuperGrdResultado, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox4, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 103)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1287, 346)
        Me.TableLayoutPanel1.TabIndex = 417
        '
        'SuperGrdResultado
        '
        Background8.Color1 = System.Drawing.Color.Transparent
        Background8.Color2 = System.Drawing.Color.Transparent
        Me.SuperGrdResultado.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = Background8
        Background9.Color1 = System.Drawing.Color.Transparent
        Me.SuperGrdResultado.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = Background9
        Background10.Color1 = System.Drawing.Color.Transparent
        Background10.Color2 = System.Drawing.Color.Transparent
        Me.SuperGrdResultado.DefaultVisualStyles.CellStyles.Default.Background = Background10
        Background11.Color1 = System.Drawing.Color.Transparent
        Me.SuperGrdResultado.DefaultVisualStyles.RowStyles.Default.Background = Background11
        Me.SuperGrdResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperGrdResultado.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.SuperGrdResultado.Location = New System.Drawing.Point(10, 10)
        Me.SuperGrdResultado.Margin = New System.Windows.Forms.Padding(10, 10, 12, 10)
        Me.SuperGrdResultado.Name = "SuperGrdResultado"
        '
        '
        '
        Me.SuperGrdResultado.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill
        Background12.Color1 = System.Drawing.Color.Transparent
        Me.SuperGrdResultado.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = Background12
        Me.SuperGrdResultado.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Background13.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.VerticalCenter
        Background13.Color1 = System.Drawing.Color.White
        Background13.Color2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SuperGrdResultado.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = Background13
        Background14.Color1 = System.Drawing.Color.Transparent
        Me.SuperGrdResultado.PrimaryGrid.DefaultVisualStyles.RowStyles.Default.Background = Background14
        Me.SuperGrdResultado.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row
        Me.SuperGrdResultado.Size = New System.Drawing.Size(1012, 326)
        Me.SuperGrdResultado.TabIndex = 381
        Me.SuperGrdResultado.Text = "SuperGridControl1"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblTotal)
        Me.GroupBox4.Controls.Add(Me.LabelX1)
        Me.GroupBox4.Controls.Add(Me.cmbTipoPago)
        Me.GroupBox4.Controls.Add(Me.chkComisionCentro)
        Me.GroupBox4.Controls.Add(Me.chkImpCheque)
        Me.GroupBox4.Controls.Add(Me.chkIngresosBrutos)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.btnExcelWindow)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(1044, 4)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(10, 4, 10, 10)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(233, 332)
        Me.GroupBox4.TabIndex = 386
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Resúmen"
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblTotal.Location = New System.Drawing.Point(7, 254)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(212, 24)
        Me.lblTotal.TabIndex = 389
        Me.lblTotal.Text = "$ [Total]"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelX1
        '
        Me.LabelX1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(22, 34)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(73, 19)
        Me.LabelX1.TabIndex = 394
        Me.LabelX1.Text = "Tipo de pago"
        '
        'cmbTipoPago
        '
        Me.cmbTipoPago.DisplayMember = "Text"
        Me.cmbTipoPago.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoPago.FormattingEnabled = True
        Me.cmbTipoPago.ItemHeight = 16
        Me.cmbTipoPago.Items.AddRange(New Object() {Me.pagoUnico, Me.pagoAnticipo})
        Me.cmbTipoPago.Location = New System.Drawing.Point(22, 54)
        Me.cmbTipoPago.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbTipoPago.Name = "cmbTipoPago"
        Me.cmbTipoPago.Size = New System.Drawing.Size(90, 22)
        Me.cmbTipoPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoPago.TabIndex = 393
        Me.cmbTipoPago.Text = "Unico"
        '
        'pagoUnico
        '
        Me.pagoUnico.Text = "Unico"
        '
        'pagoAnticipo
        '
        Me.pagoAnticipo.Text = "Anticipo"
        '
        'chkComisionCentro
        '
        Me.chkComisionCentro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkComisionCentro.AutoSize = True
        Me.chkComisionCentro.Location = New System.Drawing.Point(32, 203)
        Me.chkComisionCentro.Name = "chkComisionCentro"
        Me.chkComisionCentro.Size = New System.Drawing.Size(137, 17)
        Me.chkComisionCentro.TabIndex = 392
        Me.chkComisionCentro.Text = "Comisión CENPROFAR"
        Me.chkComisionCentro.UseVisualStyleBackColor = True
        '
        'chkImpCheque
        '
        Me.chkImpCheque.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkImpCheque.AutoSize = True
        Me.chkImpCheque.Location = New System.Drawing.Point(32, 172)
        Me.chkImpCheque.Name = "chkImpCheque"
        Me.chkImpCheque.Size = New System.Drawing.Size(109, 17)
        Me.chkImpCheque.TabIndex = 391
        Me.chkImpCheque.Text = "Impuesto Cheque"
        Me.chkImpCheque.UseVisualStyleBackColor = True
        '
        'chkIngresosBrutos
        '
        Me.chkIngresosBrutos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIngresosBrutos.AutoSize = True
        Me.chkIngresosBrutos.Location = New System.Drawing.Point(32, 142)
        Me.chkIngresosBrutos.Name = "chkIngresosBrutos"
        Me.chkIngresosBrutos.Size = New System.Drawing.Size(99, 17)
        Me.chkIngresosBrutos.TabIndex = 390
        Me.chkIngresosBrutos.Text = "Ingresos Brutos"
        Me.chkIngresosBrutos.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(20, 241)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(74, 13)
        Me.Label23.TabIndex = 388
        Me.Label23.Text = "Total a Pagar:"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.Label17.Location = New System.Drawing.Point(148, 103)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 13)
        Me.Label17.TabIndex = 387
        Me.Label17.Text = "No hay planilla"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnExcelWindow
        '
        Me.btnExcelWindow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExcelWindow.BackColor = System.Drawing.Color.Transparent
        Me.btnExcelWindow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnExcelWindow.Location = New System.Drawing.Point(22, 97)
        Me.btnExcelWindow.Name = "btnExcelWindow"
        Me.btnExcelWindow.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(3)
        Me.btnExcelWindow.Size = New System.Drawing.Size(93, 25)
        Me.btnExcelWindow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnExcelWindow.TabIndex = 382
        Me.btnExcelWindow.Text = "Importar Planilla"
        Me.btnExcelWindow.TextColor = System.Drawing.SystemColors.WindowText
        '
        'txtID
        '
        Me.txtID.AccessibleName = "ID"
        Me.txtID.Location = New System.Drawing.Point(75, -3)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(56, 20)
        Me.txtID.TabIndex = 416
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(15, 47)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(68, 20)
        Me.txtCodigo.TabIndex = 415
        '
        'lblFecha_presentacion
        '
        Me.lblFecha_presentacion.Location = New System.Drawing.Point(848, 51)
        Me.lblFecha_presentacion.Name = "lblFecha_presentacion"
        Me.lblFecha_presentacion.Size = New System.Drawing.Size(102, 13)
        Me.lblFecha_presentacion.TabIndex = 414
        Me.lblFecha_presentacion.Text = "[Fecha]"
        Me.lblFecha_presentacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPeriodo_presentacion
        '
        Me.lblPeriodo_presentacion.Location = New System.Drawing.Point(721, 51)
        Me.lblPeriodo_presentacion.Name = "lblPeriodo_presentacion"
        Me.lblPeriodo_presentacion.Size = New System.Drawing.Size(110, 46)
        Me.lblPeriodo_presentacion.TabIndex = 413
        Me.lblPeriodo_presentacion.Text = "[Período]"
        '
        'lblObservacion
        '
        Me.lblObservacion.Location = New System.Drawing.Point(526, 51)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(179, 46)
        Me.lblObservacion.TabIndex = 412
        Me.lblObservacion.Text = "[Observación]"
        '
        'lblObraSocial
        '
        Me.lblObraSocial.Location = New System.Drawing.Point(392, 51)
        Me.lblObraSocial.Name = "lblObraSocial"
        Me.lblObraSocial.Size = New System.Drawing.Size(127, 13)
        Me.lblObraSocial.TabIndex = 411
        Me.lblObraSocial.Text = "[Obra Social]"
        Me.lblObraSocial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus_presentacion
        '
        Me.lblStatus_presentacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus_presentacion.ForeColor = System.Drawing.Color.Green
        Me.lblStatus_presentacion.Location = New System.Drawing.Point(969, 47)
        Me.lblStatus_presentacion.Name = "lblStatus_presentacion"
        Me.lblStatus_presentacion.Size = New System.Drawing.Size(149, 21)
        Me.lblStatus_presentacion.TabIndex = 408
        Me.lblStatus_presentacion.Text = "[Estado]"
        Me.lblStatus_presentacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(848, 32)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(37, 13)
        Me.Label33.TabIndex = 406
        Me.Label33.Text = "Fecha"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(969, 32)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(40, 13)
        Me.Label29.TabIndex = 403
        Me.Label29.Text = "Estado"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(721, 32)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(45, 13)
        Me.Label28.TabIndex = 402
        Me.Label28.Text = "Período"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(526, 32)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(67, 13)
        Me.Label27.TabIndex = 400
        Me.Label27.Text = "Observación"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(94, 31)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(37, 13)
        Me.Label26.TabIndex = 399
        Me.Label26.Text = "Fecha"
        '
        'lblPresentacionCodigo
        '
        Me.lblPresentacionCodigo.AutoSize = True
        Me.lblPresentacionCodigo.Location = New System.Drawing.Point(208, 50)
        Me.lblPresentacionCodigo.Name = "lblPresentacionCodigo"
        Me.lblPresentacionCodigo.Size = New System.Drawing.Size(87, 13)
        Me.lblPresentacionCodigo.TabIndex = 397
        Me.lblPresentacionCodigo.Text = "No seleccionada"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(12, 29)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 13)
        Me.Label25.TabIndex = 396
        Me.Label25.Text = "Liquidación"
        '
        'btnCargarPresentacion
        '
        Me.btnCargarPresentacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCargarPresentacion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCargarPresentacion.Location = New System.Drawing.Point(301, 47)
        Me.btnCargarPresentacion.Name = "btnCargarPresentacion"
        Me.btnCargarPresentacion.Size = New System.Drawing.Size(73, 20)
        Me.btnCargarPresentacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCargarPresentacion.TabIndex = 394
        Me.btnCargarPresentacion.Text = "Cargar"
        '
        'txtIdPresentacion
        '
        Me.txtIdPresentacion.Enabled = False
        Me.txtIdPresentacion.Location = New System.Drawing.Point(301, 29)
        Me.txtIdPresentacion.Name = "txtIdPresentacion"
        Me.txtIdPresentacion.Size = New System.Drawing.Size(73, 20)
        Me.txtIdPresentacion.TabIndex = 393
        Me.txtIdPresentacion.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(208, 31)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(69, 13)
        Me.Label24.TabIndex = 391
        Me.Label24.Text = "Presentación"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(55, 0)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(18, 13)
        Me.lblID.TabIndex = 390
        Me.lblID.Text = "ID"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label15.Location = New System.Drawing.Point(921, 88)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 13)
        Me.Label15.TabIndex = 388
        Me.Label15.Text = "Cantidad de Ítems: "
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label14.Location = New System.Drawing.Point(6, 84)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(131, 18)
        Me.Label14.TabIndex = 384
        Me.Label14.Text = "Detalle Liquidación"
        '
        'lblcuit
        '
        Me.lblcuit.AutoSize = True
        Me.lblcuit.Location = New System.Drawing.Point(614, 0)
        Me.lblcuit.Name = "lblcuit"
        Me.lblcuit.Size = New System.Drawing.Size(25, 13)
        Me.lblcuit.TabIndex = 350
        Me.lblcuit.Text = "Cuit"
        '
        'lblcmbObrasSociales
        '
        Me.lblcmbObrasSociales.AutoSize = True
        Me.lblcmbObrasSociales.Location = New System.Drawing.Point(391, 32)
        Me.lblcmbObrasSociales.Name = "lblcmbObrasSociales"
        Me.lblcmbObrasSociales.Size = New System.Drawing.Size(62, 13)
        Me.lblcmbObrasSociales.TabIndex = 346
        Me.lblcmbObrasSociales.Text = "Obra Social"
        '
        'dtpFECHA
        '
        Me.dtpFECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFECHA.Location = New System.Drawing.Point(97, 47)
        Me.dtpFECHA.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        Me.dtpFECHA.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtpFECHA.Name = "dtpFECHA"
        Me.dtpFECHA.Size = New System.Drawing.Size(95, 20)
        Me.dtpFECHA.TabIndex = 1
        Me.dtpFECHA.Tag = "202"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BorrarElItemToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.BuscarDescripcionToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(361, 75)
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
        '
        'ContextMenuStripIVA
        '
        Me.ContextMenuStripIVA.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStripIVA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BorrarElItemToolStripMenuItemIVA})
        Me.ContextMenuStripIVA.Name = "ContextMenuStrip1"
        Me.ContextMenuStripIVA.Size = New System.Drawing.Size(146, 26)
        '
        'BorrarElItemToolStripMenuItemIVA
        '
        Me.BorrarElItemToolStripMenuItemIVA.Name = "BorrarElItemToolStripMenuItemIVA"
        Me.BorrarElItemToolStripMenuItemIVA.Size = New System.Drawing.Size(145, 22)
        Me.BorrarElItemToolStripMenuItemIVA.Text = "Borrar el Item"
        '
        'frmLiquidaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1282, 609)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmLiquidaciones"
        Me.Text = "frmRecepciones"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStripIVA.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFECHA As System.Windows.Forms.DateTimePicker
    Friend Shadows WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BorrarElItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarDescripcionToolStripMenuItem As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ContextMenuStripIVA As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BorrarElItemToolStripMenuItemIVA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblCantidadItems As System.Windows.Forms.Label
    Friend WithEvents chkGrillaInferior As System.Windows.Forms.CheckBox
    Friend WithEvents lblcmbObrasSociales As System.Windows.Forms.Label
    Friend WithEvents lblcuit As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents SuperGrdResultado As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents btnExcelWindow As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label14 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label17 As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents chkComisionCentro As CheckBox
    Friend WithEvents chkImpCheque As CheckBox
    Friend WithEvents chkIngresosBrutos As CheckBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbTipoPago As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents pagoUnico As DevComponents.Editors.ComboItem
    Friend WithEvents pagoAnticipo As DevComponents.Editors.ComboItem
    Friend WithEvents lblCantLiq As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblID As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents lblPresentacionCodigo As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents btnCargarPresentacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label27 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents lblStatus_presentacion As Label
    Friend WithEvents lblFecha_presentacion As Label
    Friend WithEvents lblPeriodo_presentacion As Label
    Friend WithEvents lblObservacion As Label
    Friend WithEvents lblObraSocial As Label
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents txtIdPresentacion As TextBox
    Friend WithEvents txtID As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents chkAgrupado As CheckBox
End Class
