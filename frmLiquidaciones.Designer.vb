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
        Dim Background1 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background2 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background3 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background4 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background5 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background6 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background7 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLiquidaciones))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblFecha_liquidado = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFecha_creacion = New System.Windows.Forms.Label()
        Me.chkLiquidado = New System.Windows.Forms.CheckBox()
        Me.chkAgrupado = New System.Windows.Forms.CheckBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.cmbTipoPago = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.lblCantidadItems = New System.Windows.Forms.Label()
        Me.lblCantLiq = New System.Windows.Forms.Label()
        Me.chkGrillaInferior = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.SuperGrdResultado = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblTransferencia = New System.Windows.Forms.Label()
        Me.btnLiquidar = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
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
        Me.lblStatus = New System.Windows.Forms.Label()
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
        Me.GroupBox1.Controls.Add(Me.lblFecha_liquidado)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblFecha_creacion)
        Me.GroupBox1.Controls.Add(Me.chkLiquidado)
        Me.GroupBox1.Controls.Add(Me.chkAgrupado)
        Me.GroupBox1.Controls.Add(Me.LabelX1)
        Me.GroupBox1.Controls.Add(Me.cmbTipoPago)
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
        Me.GroupBox1.Controls.Add(Me.lblStatus)
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
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(0, 33)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(2733, 592)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblFecha_liquidado
        '
        Me.lblFecha_liquidado.Location = New System.Drawing.Point(1579, 63)
        Me.lblFecha_liquidado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFecha_liquidado.Name = "lblFecha_liquidado"
        Me.lblFecha_liquidado.Size = New System.Drawing.Size(136, 16)
        Me.lblFecha_liquidado.TabIndex = 422
        Me.lblFecha_liquidado.Text = "[Fecha]"
        Me.lblFecha_liquidado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1579, 38)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 17)
        Me.Label2.TabIndex = 421
        Me.Label2.Text = "Fecha liquidado"
        '
        'lblFecha_creacion
        '
        Me.lblFecha_creacion.Location = New System.Drawing.Point(125, 63)
        Me.lblFecha_creacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFecha_creacion.Name = "lblFecha_creacion"
        Me.lblFecha_creacion.Size = New System.Drawing.Size(136, 16)
        Me.lblFecha_creacion.TabIndex = 420
        Me.lblFecha_creacion.Text = "[Fecha]"
        Me.lblFecha_creacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkLiquidado
        '
        Me.chkLiquidado.AutoSize = True
        Me.chkLiquidado.Enabled = False
        Me.chkLiquidado.Location = New System.Drawing.Point(119, -1)
        Me.chkLiquidado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkLiquidado.Name = "chkLiquidado"
        Me.chkLiquidado.Size = New System.Drawing.Size(92, 21)
        Me.chkLiquidado.TabIndex = 419
        Me.chkLiquidado.Text = "Liquidado"
        Me.chkLiquidado.UseVisualStyleBackColor = True
        '
        'chkAgrupado
        '
        Me.chkAgrupado.AutoSize = True
        Me.chkAgrupado.Enabled = False
        Me.chkAgrupado.Location = New System.Drawing.Point(425, 85)
        Me.chkAgrupado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkAgrupado.Name = "chkAgrupado"
        Me.chkAgrupado.Size = New System.Drawing.Size(175, 21)
        Me.chkAgrupado.TabIndex = 418
        Me.chkAgrupado.Text = "Agrupada por farmacia"
        Me.chkAgrupado.UseVisualStyleBackColor = True
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(280, 33)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(103, 23)
        Me.LabelX1.TabIndex = 394
        Me.LabelX1.Text = "Tipo de pago"
        '
        'cmbTipoPago
        '
        Me.cmbTipoPago.AccessibleName = "*TipoDePago"
        Me.cmbTipoPago.DisplayMember = "Text"
        Me.cmbTipoPago.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoPago.FormattingEnabled = True
        Me.cmbTipoPago.ItemHeight = 16
        Me.cmbTipoPago.Location = New System.Drawing.Point(280, 57)
        Me.cmbTipoPago.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbTipoPago.Name = "cmbTipoPago"
        Me.cmbTipoPago.Size = New System.Drawing.Size(119, 22)
        Me.cmbTipoPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoPago.TabIndex = 393
        Me.cmbTipoPago.WatermarkEnabled = False
        '
        'lblCantidadItems
        '
        Me.lblCantidadItems.AutoSize = True
        Me.lblCantidadItems.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCantidadItems.Location = New System.Drawing.Point(1356, 108)
        Me.lblCantidadItems.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCantidadItems.Name = "lblCantidadItems"
        Me.lblCantidadItems.Size = New System.Drawing.Size(68, 17)
        Me.lblCantidadItems.TabIndex = 270
        Me.lblCantidadItems.Text = "[Subtotal]"
        Me.lblCantidadItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCantLiq
        '
        Me.lblCantLiq.AutoSize = True
        Me.lblCantLiq.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCantLiq.Location = New System.Drawing.Point(136, 556)
        Me.lblCantLiq.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCantLiq.Name = "lblCantLiq"
        Me.lblCantLiq.Size = New System.Drawing.Size(68, 17)
        Me.lblCantLiq.TabIndex = 387
        Me.lblCantLiq.Text = "[Subtotal]"
        '
        'chkGrillaInferior
        '
        Me.chkGrillaInferior.AutoSize = True
        Me.chkGrillaInferior.Location = New System.Drawing.Point(239, 556)
        Me.chkGrillaInferior.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkGrillaInferior.Name = "chkGrillaInferior"
        Me.chkGrillaInferior.Size = New System.Drawing.Size(176, 21)
        Me.chkGrillaInferior.TabIndex = 272
        Me.chkGrillaInferior.Text = "Aumentar Grilla Inferior"
        Me.chkGrillaInferior.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label19.Location = New System.Drawing.Point(16, 556)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(129, 17)
        Me.Label19.TabIndex = 271
        Me.Label19.Text = "Cantidad de �tems: "
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 127)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1833, 426)
        Me.TableLayoutPanel1.TabIndex = 417
        '
        'SuperGrdResultado
        '
        Background1.Color1 = System.Drawing.Color.Transparent
        Background1.Color2 = System.Drawing.Color.Transparent
        Me.SuperGrdResultado.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = Background1
        Background2.Color1 = System.Drawing.Color.Transparent
        Me.SuperGrdResultado.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = Background2
        Background3.Color1 = System.Drawing.Color.Transparent
        Background3.Color2 = System.Drawing.Color.Transparent
        Me.SuperGrdResultado.DefaultVisualStyles.CellStyles.Default.Background = Background3
        Background4.Color1 = System.Drawing.Color.Transparent
        Me.SuperGrdResultado.DefaultVisualStyles.RowStyles.Default.Background = Background4
        Me.SuperGrdResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperGrdResultado.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.SuperGrdResultado.Location = New System.Drawing.Point(13, 12)
        Me.SuperGrdResultado.Margin = New System.Windows.Forms.Padding(13, 12, 16, 12)
        Me.SuperGrdResultado.Name = "SuperGrdResultado"
        '
        '
        '
        Me.SuperGrdResultado.PrimaryGrid.AllowEdit = False
        Me.SuperGrdResultado.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill
        Me.SuperGrdResultado.PrimaryGrid.ColumnDragBehavior = DevComponents.DotNetBar.SuperGrid.ColumnDragBehavior.None
        Background5.Color1 = System.Drawing.Color.Transparent
        Me.SuperGrdResultado.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = Background5
        Me.SuperGrdResultado.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Background6.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.VerticalCenter
        Background6.Color1 = System.Drawing.Color.White
        Background6.Color2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SuperGrdResultado.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = Background6
        Background7.Color1 = System.Drawing.Color.Transparent
        Me.SuperGrdResultado.PrimaryGrid.DefaultVisualStyles.RowStyles.Default.Background = Background7
        Me.SuperGrdResultado.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row
        Me.SuperGrdResultado.Size = New System.Drawing.Size(1443, 402)
        Me.SuperGrdResultado.TabIndex = 381
        Me.SuperGrdResultado.Text = "SuperGridControl1"
        '
        'GroupBox4
        '
        Me.GroupBox4.CausesValidation = False
        Me.GroupBox4.Controls.Add(Me.lblTransferencia)
        Me.GroupBox4.Controls.Add(Me.btnLiquidar)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.lblTotal)
        Me.GroupBox4.Controls.Add(Me.chkComisionCentro)
        Me.GroupBox4.Controls.Add(Me.chkImpCheque)
        Me.GroupBox4.Controls.Add(Me.chkIngresosBrutos)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.btnExcelWindow)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(1485, 5)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(13, 5, 13, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(335, 409)
        Me.GroupBox4.TabIndex = 386
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Res�men"
        '
        'lblTransferencia
        '
        Me.lblTransferencia.AutoSize = True
        Me.lblTransferencia.Location = New System.Drawing.Point(131, 236)
        Me.lblTransferencia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTransferencia.Name = "lblTransferencia"
        Me.lblTransferencia.Size = New System.Drawing.Size(112, 17)
        Me.lblTransferencia.TabIndex = 424
        Me.lblTransferencia.Text = "$[Transferencia]"
        '
        'btnLiquidar
        '
        Me.btnLiquidar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLiquidar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLiquidar.BackColor = System.Drawing.Color.Transparent
        Me.btnLiquidar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLiquidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLiquidar.Location = New System.Drawing.Point(75, 338)
        Me.btnLiquidar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnLiquidar.Name = "btnLiquidar"
        Me.btnLiquidar.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(3)
        Me.btnLiquidar.Size = New System.Drawing.Size(199, 34)
        Me.btnLiquidar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLiquidar.TabIndex = 393
        Me.btnLiquidar.Text = "Liquidar"
        Me.btnLiquidar.TextColor = System.Drawing.SystemColors.WindowText
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 235)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 17)
        Me.Label1.TabIndex = 423
        Me.Label1.Text = "Transferencia:"
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblTotal.Location = New System.Drawing.Point(9, 290)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(307, 30)
        Me.lblTotal.TabIndex = 389
        Me.lblTotal.Text = "$ [Total]"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkComisionCentro
        '
        Me.chkComisionCentro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkComisionCentro.AutoSize = True
        Me.chkComisionCentro.Location = New System.Drawing.Point(43, 190)
        Me.chkComisionCentro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkComisionCentro.Name = "chkComisionCentro"
        Me.chkComisionCentro.Size = New System.Drawing.Size(176, 21)
        Me.chkComisionCentro.TabIndex = 392
        Me.chkComisionCentro.Text = "Comisi�n CENPROFAR"
        Me.chkComisionCentro.UseVisualStyleBackColor = True
        '
        'chkImpCheque
        '
        Me.chkImpCheque.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkImpCheque.AutoSize = True
        Me.chkImpCheque.Location = New System.Drawing.Point(43, 151)
        Me.chkImpCheque.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkImpCheque.Name = "chkImpCheque"
        Me.chkImpCheque.Size = New System.Drawing.Size(140, 21)
        Me.chkImpCheque.TabIndex = 391
        Me.chkImpCheque.Text = "Impuesto Cheque"
        Me.chkImpCheque.UseVisualStyleBackColor = True
        '
        'chkIngresosBrutos
        '
        Me.chkIngresosBrutos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIngresosBrutos.AutoSize = True
        Me.chkIngresosBrutos.Location = New System.Drawing.Point(43, 114)
        Me.chkIngresosBrutos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkIngresosBrutos.Name = "chkIngresosBrutos"
        Me.chkIngresosBrutos.Size = New System.Drawing.Size(129, 21)
        Me.chkIngresosBrutos.TabIndex = 390
        Me.chkIngresosBrutos.Text = "Ingresos Brutos"
        Me.chkIngresosBrutos.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(27, 274)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 17)
        Me.Label23.TabIndex = 388
        Me.Label23.Text = "Total a Pagar:"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.Label17.Location = New System.Drawing.Point(221, 66)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(101, 17)
        Me.Label17.TabIndex = 387
        Me.Label17.Text = "No hay planilla"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnExcelWindow
        '
        Me.btnExcelWindow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExcelWindow.BackColor = System.Drawing.Color.Transparent
        Me.btnExcelWindow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnExcelWindow.Location = New System.Drawing.Point(29, 59)
        Me.btnExcelWindow.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelWindow.Name = "btnExcelWindow"
        Me.btnExcelWindow.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(3)
        Me.btnExcelWindow.Size = New System.Drawing.Size(124, 31)
        Me.btnExcelWindow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnExcelWindow.TabIndex = 382
        Me.btnExcelWindow.Text = "Importar Planilla"
        Me.btnExcelWindow.TextColor = System.Drawing.SystemColors.WindowText
        '
        'txtID
        '
        Me.txtID.AccessibleName = "ID"
        Me.txtID.Location = New System.Drawing.Point(36, -4)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(73, 22)
        Me.txtID.TabIndex = 416
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(20, 58)
        Me.txtCodigo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(89, 22)
        Me.txtCodigo.TabIndex = 415
        '
        'lblFecha_presentacion
        '
        Me.lblFecha_presentacion.Location = New System.Drawing.Point(991, 62)
        Me.lblFecha_presentacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFecha_presentacion.Name = "lblFecha_presentacion"
        Me.lblFecha_presentacion.Size = New System.Drawing.Size(136, 16)
        Me.lblFecha_presentacion.TabIndex = 414
        Me.lblFecha_presentacion.Text = "[Fecha]"
        Me.lblFecha_presentacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPeriodo_presentacion
        '
        Me.lblPeriodo_presentacion.Location = New System.Drawing.Point(844, 62)
        Me.lblPeriodo_presentacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPeriodo_presentacion.Name = "lblPeriodo_presentacion"
        Me.lblPeriodo_presentacion.Size = New System.Drawing.Size(147, 43)
        Me.lblPeriodo_presentacion.TabIndex = 413
        Me.lblPeriodo_presentacion.Text = "[Per�odo]"
        '
        'lblObservacion
        '
        Me.lblObservacion.Location = New System.Drawing.Point(1156, 62)
        Me.lblObservacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(239, 43)
        Me.lblObservacion.TabIndex = 412
        Me.lblObservacion.Text = "[Observaci�n]"
        '
        'lblObraSocial
        '
        Me.lblObraSocial.Location = New System.Drawing.Point(667, 63)
        Me.lblObraSocial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblObraSocial.Name = "lblObraSocial"
        Me.lblObraSocial.Size = New System.Drawing.Size(169, 16)
        Me.lblObraSocial.TabIndex = 411
        Me.lblObraSocial.Text = "[Obra Social]"
        Me.lblObraSocial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Green
        Me.lblStatus.Location = New System.Drawing.Point(1396, 57)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(169, 26)
        Me.lblStatus.TabIndex = 408
        Me.lblStatus.Text = "[Estado]"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(991, 38)
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(123, 17)
        Me.Label33.TabIndex = 406
        Me.Label33.Text = "Fecha presentado"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(1396, 38)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(52, 17)
        Me.Label29.TabIndex = 403
        Me.Label29.Text = "Estado"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(844, 38)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(57, 17)
        Me.Label28.TabIndex = 402
        Me.Label28.Text = "Per�odo"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(1156, 38)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(88, 17)
        Me.Label27.TabIndex = 400
        Me.Label27.Text = "Observaci�n"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(125, 38)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(105, 17)
        Me.Label26.TabIndex = 399
        Me.Label26.Text = "Fecha creaci�n"
        '
        'lblPresentacionCodigo
        '
        Me.lblPresentacionCodigo.AutoSize = True
        Me.lblPresentacionCodigo.Location = New System.Drawing.Point(421, 62)
        Me.lblPresentacionCodigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPresentacionCodigo.Name = "lblPresentacionCodigo"
        Me.lblPresentacionCodigo.Size = New System.Drawing.Size(113, 17)
        Me.lblPresentacionCodigo.TabIndex = 397
        Me.lblPresentacionCodigo.Text = "No seleccionada"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(16, 36)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(80, 17)
        Me.Label25.TabIndex = 396
        Me.Label25.Text = "Liquidaci�n"
        '
        'btnCargarPresentacion
        '
        Me.btnCargarPresentacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCargarPresentacion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCargarPresentacion.Location = New System.Drawing.Point(545, 58)
        Me.btnCargarPresentacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCargarPresentacion.Name = "btnCargarPresentacion"
        Me.btnCargarPresentacion.Size = New System.Drawing.Size(97, 25)
        Me.btnCargarPresentacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCargarPresentacion.TabIndex = 394
        Me.btnCargarPresentacion.Text = "Cargar"
        '
        'txtIdPresentacion
        '
        Me.txtIdPresentacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdPresentacion.Enabled = False
        Me.txtIdPresentacion.Location = New System.Drawing.Point(545, 36)
        Me.txtIdPresentacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIdPresentacion.Name = "txtIdPresentacion"
        Me.txtIdPresentacion.Size = New System.Drawing.Size(96, 22)
        Me.txtIdPresentacion.TabIndex = 393
        Me.txtIdPresentacion.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(421, 38)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(91, 17)
        Me.Label24.TabIndex = 391
        Me.Label24.Text = "Presentaci�n"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(16, 0)
        Me.lblID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(21, 17)
        Me.lblID.TabIndex = 390
        Me.lblID.Text = "ID"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label15.Location = New System.Drawing.Point(1228, 108)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(129, 17)
        Me.Label15.TabIndex = 388
        Me.Label15.Text = "Cantidad de �tems: "
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label14.Location = New System.Drawing.Point(8, 103)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(169, 24)
        Me.Label14.TabIndex = 384
        Me.Label14.Text = "Detalle Liquidaci�n"
        '
        'lblcuit
        '
        Me.lblcuit.AutoSize = True
        Me.lblcuit.Location = New System.Drawing.Point(819, 0)
        Me.lblcuit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblcuit.Name = "lblcuit"
        Me.lblcuit.Size = New System.Drawing.Size(32, 17)
        Me.lblcuit.TabIndex = 350
        Me.lblcuit.Text = "Cuit"
        '
        'lblcmbObrasSociales
        '
        Me.lblcmbObrasSociales.AutoSize = True
        Me.lblcmbObrasSociales.Location = New System.Drawing.Point(665, 39)
        Me.lblcmbObrasSociales.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblcmbObrasSociales.Name = "lblcmbObrasSociales"
        Me.lblcmbObrasSociales.Size = New System.Drawing.Size(82, 17)
        Me.lblcmbObrasSociales.TabIndex = 346
        Me.lblcmbObrasSociales.Text = "Obra Social"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BorrarElItemToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.BuscarDescripcionToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(361, 84)
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
        '
        'ContextMenuStripIVA
        '
        Me.ContextMenuStripIVA.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStripIVA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BorrarElItemToolStripMenuItemIVA})
        Me.ContextMenuStripIVA.Name = "ContextMenuStrip1"
        Me.ContextMenuStripIVA.Size = New System.Drawing.Size(170, 28)
        '
        'BorrarElItemToolStripMenuItemIVA
        '
        Me.BorrarElItemToolStripMenuItemIVA.Name = "BorrarElItemToolStripMenuItemIVA"
        Me.BorrarElItemToolStripMenuItemIVA.Size = New System.Drawing.Size(169, 24)
        Me.BorrarElItemToolStripMenuItemIVA.Text = "Borrar el Item"
        '
        'frmLiquidaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1827, 750)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "frmLiquidaciones"
        Me.Text = "Liquidaciones"
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
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblFecha_presentacion As Label
    Friend WithEvents lblPeriodo_presentacion As Label
    Friend WithEvents lblObservacion As Label
    Friend WithEvents lblObraSocial As Label
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents txtIdPresentacion As TextBox
    Friend WithEvents txtID As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents chkAgrupado As CheckBox
    Friend WithEvents btnLiquidar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents chkLiquidado As CheckBox
    Friend WithEvents lblFecha_creacion As Label
    Friend WithEvents lblFecha_liquidado As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTransferencia As Label
    Friend WithEvents Label1 As Label
End Class
