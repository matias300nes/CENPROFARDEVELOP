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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkGrillaInferior = New System.Windows.Forms.CheckBox()
        Me.rdTodasOC = New System.Windows.Forms.RadioButton()
        Me.rdPendientes = New System.Windows.Forms.RadioButton()
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
        Me.rdAnuladas = New System.Windows.Forms.RadioButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupPanelDetalleLiquidacion = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnImportExcel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FileName = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboSheet = New System.Windows.Forms.ComboBox()
        Me.ColLabel = New System.Windows.Forms.Label()
        Me.btnListo = New System.Windows.Forms.Button()
        Me.FilaLabel = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PanelDescuentos = New System.Windows.Forms.Panel()
        Me.cboDescuentos1 = New System.Windows.Forms.ComboBox()
        Me.cboDescuentos4 = New System.Windows.Forms.ComboBox()
        Me.numericDescuentos4 = New System.Windows.Forms.NumericUpDown()
        Me.numericDescuentos1 = New System.Windows.Forms.NumericUpDown()
        Me.numericDescuentos3 = New System.Windows.Forms.NumericUpDown()
        Me.cboDescuentos3 = New System.Windows.Forms.ComboBox()
        Me.cboDescuentos2 = New System.Windows.Forms.ComboBox()
        Me.numericDescuentos2 = New System.Windows.Forms.NumericUpDown()
        Me.RecognitionLabel = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.NumericUpDown3 = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.NumericUpDown4 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown5 = New System.Windows.Forms.NumericUpDown()
        Me.btnScan = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.grdDetalleLiquidacionFiltrada = New System.Windows.Forms.DataGridView()
        Me.grdDetalleLiquidacion = New System.Windows.Forms.DataGridView()
        Me.chkAnuladas = New System.Windows.Forms.CheckBox()
        Me.lblCantidadFilas = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.SuperGrdResultado = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.lblcuit = New System.Windows.Forms.Label()
        Me.lblcmbObrasSociales = New System.Windows.Forms.Label()
        Me.cmbObraSocial = New System.Windows.Forms.ComboBox()
        Me.btnLlenarGrilla = New System.Windows.Forms.Button()
        Me.chkEliminado = New System.Windows.Forms.CheckBox()
        Me.dtpFECHA = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BorrarElItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarDescripcionToolStripMenuItem = New System.Windows.Forms.ToolStripComboBox()
        Me.ContextMenuStripIVA = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BorrarElItemToolStripMenuItemIVA = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupPanelDetalleLiquidacion.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.PanelDescuentos.SuspendLayout()
        CType(Me.numericDescuentos4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericDescuentos1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericDescuentos3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericDescuentos2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetalleLiquidacionFiltrada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetalleLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStripIVA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
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
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.chkGrillaInferior)
        Me.GroupBox1.Controls.Add(Me.rdTodasOC)
        Me.GroupBox1.Controls.Add(Me.rdPendientes)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.rdAnuladas)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.GroupPanelDetalleLiquidacion)
        Me.GroupBox1.Controls.Add(Me.chkAnuladas)
        Me.GroupBox1.Controls.Add(Me.lblCantidadFilas)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.SuperGrdResultado)
        Me.GroupBox1.Controls.Add(Me.lblcuit)
        Me.GroupBox1.Controls.Add(Me.lblcmbObrasSociales)
        Me.GroupBox1.Controls.Add(Me.cmbObraSocial)
        Me.GroupBox1.Controls.Add(Me.btnLlenarGrilla)
        Me.GroupBox1.Controls.Add(Me.chkEliminado)
        Me.GroupBox1.Controls.Add(Me.dtpFECHA)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(0, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1551, 507)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(15, 41)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(68, 20)
        Me.txtCodigo.TabIndex = 415
        '
        'lblFecha_presentacion
        '
        Me.lblFecha_presentacion.Location = New System.Drawing.Point(848, 45)
        Me.lblFecha_presentacion.Name = "lblFecha_presentacion"
        Me.lblFecha_presentacion.Size = New System.Drawing.Size(102, 13)
        Me.lblFecha_presentacion.TabIndex = 414
        Me.lblFecha_presentacion.Text = "[Fecha]"
        Me.lblFecha_presentacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPeriodo_presentacion
        '
        Me.lblPeriodo_presentacion.Location = New System.Drawing.Point(721, 45)
        Me.lblPeriodo_presentacion.Name = "lblPeriodo_presentacion"
        Me.lblPeriodo_presentacion.Size = New System.Drawing.Size(110, 13)
        Me.lblPeriodo_presentacion.TabIndex = 413
        Me.lblPeriodo_presentacion.Text = "[Período]"
        Me.lblPeriodo_presentacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblObservacion
        '
        Me.lblObservacion.Location = New System.Drawing.Point(526, 45)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(179, 13)
        Me.lblObservacion.TabIndex = 412
        Me.lblObservacion.Text = "[Observación]"
        Me.lblObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblObraSocial
        '
        Me.lblObraSocial.Location = New System.Drawing.Point(392, 45)
        Me.lblObraSocial.Name = "lblObraSocial"
        Me.lblObraSocial.Size = New System.Drawing.Size(127, 13)
        Me.lblObraSocial.TabIndex = 411
        Me.lblObraSocial.Text = "[Obra Social]"
        Me.lblObraSocial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatus_presentacion
        '
        Me.lblStatus_presentacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus_presentacion.ForeColor = System.Drawing.Color.Green
        Me.lblStatus_presentacion.Location = New System.Drawing.Point(969, 41)
        Me.lblStatus_presentacion.Name = "lblStatus_presentacion"
        Me.lblStatus_presentacion.Size = New System.Drawing.Size(149, 21)
        Me.lblStatus_presentacion.TabIndex = 408
        Me.lblStatus_presentacion.Text = "[Estado]"
        Me.lblStatus_presentacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(848, 26)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(37, 13)
        Me.Label33.TabIndex = 406
        Me.Label33.Text = "Fecha"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(969, 26)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(40, 13)
        Me.Label29.TabIndex = 403
        Me.Label29.Text = "Estado"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(721, 26)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(45, 13)
        Me.Label28.TabIndex = 402
        Me.Label28.Text = "Período"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(526, 26)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(67, 13)
        Me.Label27.TabIndex = 400
        Me.Label27.Text = "Observación"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(94, 25)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(37, 13)
        Me.Label26.TabIndex = 399
        Me.Label26.Text = "Fecha"
        '
        'lblPresentacionCodigo
        '
        Me.lblPresentacionCodigo.AutoSize = True
        Me.lblPresentacionCodigo.Location = New System.Drawing.Point(208, 44)
        Me.lblPresentacionCodigo.Name = "lblPresentacionCodigo"
        Me.lblPresentacionCodigo.Size = New System.Drawing.Size(87, 13)
        Me.lblPresentacionCodigo.TabIndex = 397
        Me.lblPresentacionCodigo.Text = "No seleccionada"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(12, 23)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 13)
        Me.Label25.TabIndex = 396
        Me.Label25.Text = "Liquidación"
        '
        'btnCargarPresentacion
        '
        Me.btnCargarPresentacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCargarPresentacion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCargarPresentacion.Location = New System.Drawing.Point(301, 41)
        Me.btnCargarPresentacion.Name = "btnCargarPresentacion"
        Me.btnCargarPresentacion.Size = New System.Drawing.Size(73, 20)
        Me.btnCargarPresentacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCargarPresentacion.TabIndex = 394
        Me.btnCargarPresentacion.Text = "Cargar"
        '
        'txtIdPresentacion
        '
        Me.txtIdPresentacion.Enabled = False
        Me.txtIdPresentacion.Location = New System.Drawing.Point(301, 23)
        Me.txtIdPresentacion.Name = "txtIdPresentacion"
        Me.txtIdPresentacion.Size = New System.Drawing.Size(73, 20)
        Me.txtIdPresentacion.TabIndex = 393
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(208, 25)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(69, 13)
        Me.Label24.TabIndex = 391
        Me.Label24.Text = "Presentación"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(12, 72)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(18, 13)
        Me.lblID.TabIndex = 390
        Me.lblID.Text = "ID"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label7.Location = New System.Drawing.Point(1022, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 387
        Me.Label7.Text = "[Subtotal]"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label15.Location = New System.Drawing.Point(923, 117)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 13)
        Me.Label15.TabIndex = 388
        Me.Label15.Text = "Cantidad de Ítems: "
        '
        'chkGrillaInferior
        '
        Me.chkGrillaInferior.AutoSize = True
        Me.chkGrillaInferior.Location = New System.Drawing.Point(179, 483)
        Me.chkGrillaInferior.Name = "chkGrillaInferior"
        Me.chkGrillaInferior.Size = New System.Drawing.Size(132, 17)
        Me.chkGrillaInferior.TabIndex = 272
        Me.chkGrillaInferior.Text = "Aumentar Grilla Inferior"
        Me.chkGrillaInferior.UseVisualStyleBackColor = True
        '
        'rdTodasOC
        '
        Me.rdTodasOC.AutoSize = True
        Me.rdTodasOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdTodasOC.Location = New System.Drawing.Point(626, 483)
        Me.rdTodasOC.Name = "rdTodasOC"
        Me.rdTodasOC.Size = New System.Drawing.Size(60, 17)
        Me.rdTodasOC.TabIndex = 275
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
        Me.rdPendientes.TabIndex = 274
        Me.rdPendientes.TabStop = True
        Me.rdPendientes.Text = "Pendientes"
        Me.rdPendientes.UseVisualStyleBackColor = True
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
        Me.GroupBox4.Location = New System.Drawing.Point(1081, 142)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(253, 293)
        Me.GroupBox4.TabIndex = 386
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Resúmen"
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblTotal.Location = New System.Drawing.Point(6, 260)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(241, 24)
        Me.lblTotal.TabIndex = 389
        Me.lblTotal.Text = "$ [Total]"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(21, 40)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(74, 19)
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
        Me.cmbTipoPago.Location = New System.Drawing.Point(21, 60)
        Me.cmbTipoPago.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbTipoPago.Name = "cmbTipoPago"
        Me.cmbTipoPago.Size = New System.Drawing.Size(102, 22)
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
        Me.chkComisionCentro.AutoSize = True
        Me.chkComisionCentro.Location = New System.Drawing.Point(32, 208)
        Me.chkComisionCentro.Name = "chkComisionCentro"
        Me.chkComisionCentro.Size = New System.Drawing.Size(137, 17)
        Me.chkComisionCentro.TabIndex = 392
        Me.chkComisionCentro.Text = "Comisión CENPROFAR"
        Me.chkComisionCentro.UseVisualStyleBackColor = True
        '
        'chkImpCheque
        '
        Me.chkImpCheque.AutoSize = True
        Me.chkImpCheque.Location = New System.Drawing.Point(32, 181)
        Me.chkImpCheque.Name = "chkImpCheque"
        Me.chkImpCheque.Size = New System.Drawing.Size(109, 17)
        Me.chkImpCheque.TabIndex = 391
        Me.chkImpCheque.Text = "Impuesto Cheque"
        Me.chkImpCheque.UseVisualStyleBackColor = True
        '
        'chkIngresosBrutos
        '
        Me.chkIngresosBrutos.AutoSize = True
        Me.chkIngresosBrutos.Location = New System.Drawing.Point(32, 154)
        Me.chkIngresosBrutos.Name = "chkIngresosBrutos"
        Me.chkIngresosBrutos.Size = New System.Drawing.Size(99, 17)
        Me.chkIngresosBrutos.TabIndex = 390
        Me.chkIngresosBrutos.Text = "Ingresos Brutos"
        Me.chkIngresosBrutos.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(19, 247)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(74, 13)
        Me.Label23.TabIndex = 388
        Me.Label23.Text = "Total a Pagar:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.Label17.Location = New System.Drawing.Point(148, 103)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 13)
        Me.Label17.TabIndex = 387
        Me.Label17.Text = "No hay planilla"
        '
        'btnExcelWindow
        '
        Me.btnExcelWindow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExcelWindow.BackColor = System.Drawing.Color.Transparent
        Me.btnExcelWindow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnExcelWindow.Location = New System.Drawing.Point(21, 103)
        Me.btnExcelWindow.Name = "btnExcelWindow"
        Me.btnExcelWindow.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(3)
        Me.btnExcelWindow.Size = New System.Drawing.Size(105, 25)
        Me.btnExcelWindow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnExcelWindow.TabIndex = 382
        Me.btnExcelWindow.Text = "Importar Planilla"
        Me.btnExcelWindow.TextColor = System.Drawing.SystemColors.WindowText
        '
        'rdAnuladas
        '
        Me.rdAnuladas.AutoSize = True
        Me.rdAnuladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdAnuladas.Location = New System.Drawing.Point(522, 483)
        Me.rdAnuladas.Name = "rdAnuladas"
        Me.rdAnuladas.Size = New System.Drawing.Size(77, 17)
        Me.rdAnuladas.TabIndex = 273
        Me.rdAnuladas.TabStop = True
        Me.rdAnuladas.Text = "Anuladas"
        Me.rdAnuladas.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label14.Location = New System.Drawing.Point(6, 112)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(131, 18)
        Me.Label14.TabIndex = 384
        Me.Label14.Text = "Detalle Liquidación"
        '
        'GroupPanelDetalleLiquidacion
        '
        Me.GroupPanelDetalleLiquidacion.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanelDetalleLiquidacion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanelDetalleLiquidacion.Controls.Add(Me.GroupBox3)
        Me.GroupPanelDetalleLiquidacion.Controls.Add(Me.ColLabel)
        Me.GroupPanelDetalleLiquidacion.Controls.Add(Me.btnListo)
        Me.GroupPanelDetalleLiquidacion.Controls.Add(Me.FilaLabel)
        Me.GroupPanelDetalleLiquidacion.Controls.Add(Me.GroupBox2)
        Me.GroupPanelDetalleLiquidacion.Controls.Add(Me.Label11)
        Me.GroupPanelDetalleLiquidacion.Controls.Add(Me.Label6)
        Me.GroupPanelDetalleLiquidacion.Controls.Add(Me.Label5)
        Me.GroupPanelDetalleLiquidacion.Controls.Add(Me.Label10)
        Me.GroupPanelDetalleLiquidacion.Controls.Add(Me.grdDetalleLiquidacionFiltrada)
        Me.GroupPanelDetalleLiquidacion.Controls.Add(Me.grdDetalleLiquidacion)
        Me.GroupPanelDetalleLiquidacion.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanelDetalleLiquidacion.Location = New System.Drawing.Point(1339, 75)
        Me.GroupPanelDetalleLiquidacion.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupPanelDetalleLiquidacion.Name = "GroupPanelDetalleLiquidacion"
        Me.GroupPanelDetalleLiquidacion.Size = New System.Drawing.Size(2000, 531)
        '
        '
        '
        Me.GroupPanelDetalleLiquidacion.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanelDetalleLiquidacion.Style.BackColorGradientAngle = 90
        Me.GroupPanelDetalleLiquidacion.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanelDetalleLiquidacion.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDetalleLiquidacion.Style.BorderBottomWidth = 1
        Me.GroupPanelDetalleLiquidacion.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanelDetalleLiquidacion.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDetalleLiquidacion.Style.BorderLeftWidth = 1
        Me.GroupPanelDetalleLiquidacion.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDetalleLiquidacion.Style.BorderRightWidth = 1
        Me.GroupPanelDetalleLiquidacion.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelDetalleLiquidacion.Style.BorderTopWidth = 1
        Me.GroupPanelDetalleLiquidacion.Style.CornerDiameter = 4
        Me.GroupPanelDetalleLiquidacion.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelDetalleLiquidacion.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelDetalleLiquidacion.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanelDetalleLiquidacion.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelDetalleLiquidacion.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelDetalleLiquidacion.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelDetalleLiquidacion.TabIndex = 369
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnImportExcel)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.FileName)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.cboSheet)
        Me.GroupBox3.Location = New System.Drawing.Point(1046, 28)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(269, 125)
        Me.GroupBox3.TabIndex = 380
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Importar Archivo"
        '
        'btnImportExcel
        '
        Me.btnImportExcel.Location = New System.Drawing.Point(159, 41)
        Me.btnImportExcel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnImportExcel.Name = "btnImportExcel"
        Me.btnImportExcel.Size = New System.Drawing.Size(61, 23)
        Me.btnImportExcel.TabIndex = 370
        Me.btnImportExcel.Text = "Importar Excel"
        Me.btnImportExcel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 356
        Me.Label1.Text = "Ruta "
        '
        'FileName
        '
        Me.FileName.AccessibleName = ""
        Me.FileName.BackColor = System.Drawing.SystemColors.Window
        Me.FileName.Decimals = CType(2, Byte)
        Me.FileName.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.FileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileName.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.FileName.Location = New System.Drawing.Point(44, 43)
        Me.FileName.MaxLength = 25
        Me.FileName.Name = "FileName"
        Me.FileName.ReadOnly = True
        Me.FileName.Size = New System.Drawing.Size(112, 20)
        Me.FileName.TabIndex = 353
        Me.FileName.Text_1 = Nothing
        Me.FileName.Text_2 = Nothing
        Me.FileName.Text_3 = Nothing
        Me.FileName.Text_4 = Nothing
        Me.FileName.UserValues = Nothing
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(41, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 370
        Me.Label9.Text = "Hoja"
        '
        'cboSheet
        '
        Me.cboSheet.AccessibleName = "*OrdenCompra"
        Me.cboSheet.FormattingEnabled = True
        Me.cboSheet.Location = New System.Drawing.Point(44, 87)
        Me.cboSheet.Name = "cboSheet"
        Me.cboSheet.Size = New System.Drawing.Size(176, 21)
        Me.cboSheet.TabIndex = 354
        '
        'ColLabel
        '
        Me.ColLabel.AutoSize = True
        Me.ColLabel.Location = New System.Drawing.Point(996, 253)
        Me.ColLabel.Name = "ColLabel"
        Me.ColLabel.Size = New System.Drawing.Size(13, 13)
        Me.ColLabel.TabIndex = 379
        Me.ColLabel.Text = "0"
        '
        'btnListo
        '
        Me.btnListo.Enabled = False
        Me.btnListo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.3!)
        Me.btnListo.Location = New System.Drawing.Point(1130, 448)
        Me.btnListo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnListo.Name = "btnListo"
        Me.btnListo.Size = New System.Drawing.Size(105, 36)
        Me.btnListo.TabIndex = 348
        Me.btnListo.Text = "Listo"
        Me.btnListo.UseVisualStyleBackColor = True
        '
        'FilaLabel
        '
        Me.FilaLabel.AutoSize = True
        Me.FilaLabel.Location = New System.Drawing.Point(934, 253)
        Me.FilaLabel.Name = "FilaLabel"
        Me.FilaLabel.Size = New System.Drawing.Size(13, 13)
        Me.FilaLabel.TabIndex = 378
        Me.FilaLabel.Text = "0"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PanelDescuentos)
        Me.GroupBox2.Controls.Add(Me.RecognitionLabel)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown3)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown4)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown5)
        Me.GroupBox2.Controls.Add(Me.btnScan)
        Me.GroupBox2.Location = New System.Drawing.Point(1046, 178)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(269, 255)
        Me.GroupBox2.TabIndex = 377
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Columnas a filtrar"
        '
        'PanelDescuentos
        '
        Me.PanelDescuentos.Controls.Add(Me.cboDescuentos1)
        Me.PanelDescuentos.Controls.Add(Me.cboDescuentos4)
        Me.PanelDescuentos.Controls.Add(Me.numericDescuentos4)
        Me.PanelDescuentos.Controls.Add(Me.numericDescuentos1)
        Me.PanelDescuentos.Controls.Add(Me.numericDescuentos3)
        Me.PanelDescuentos.Controls.Add(Me.cboDescuentos3)
        Me.PanelDescuentos.Controls.Add(Me.cboDescuentos2)
        Me.PanelDescuentos.Controls.Add(Me.numericDescuentos2)
        Me.PanelDescuentos.Location = New System.Drawing.Point(63, 96)
        Me.PanelDescuentos.Name = "PanelDescuentos"
        Me.PanelDescuentos.Size = New System.Drawing.Size(146, 117)
        Me.PanelDescuentos.TabIndex = 381
        '
        'cboDescuentos1
        '
        Me.cboDescuentos1.FormattingEnabled = True
        Me.cboDescuentos1.Location = New System.Drawing.Point(5, 8)
        Me.cboDescuentos1.Name = "cboDescuentos1"
        Me.cboDescuentos1.Size = New System.Drawing.Size(90, 21)
        Me.cboDescuentos1.TabIndex = 378
        Me.cboDescuentos1.Tag = "0"
        '
        'cboDescuentos4
        '
        Me.cboDescuentos4.FormattingEnabled = True
        Me.cboDescuentos4.Location = New System.Drawing.Point(5, 88)
        Me.cboDescuentos4.Name = "cboDescuentos4"
        Me.cboDescuentos4.Size = New System.Drawing.Size(90, 21)
        Me.cboDescuentos4.TabIndex = 389
        Me.cboDescuentos4.Tag = "3"
        '
        'numericDescuentos4
        '
        Me.numericDescuentos4.Location = New System.Drawing.Point(101, 89)
        Me.numericDescuentos4.Name = "numericDescuentos4"
        Me.numericDescuentos4.Size = New System.Drawing.Size(40, 20)
        Me.numericDescuentos4.TabIndex = 385
        Me.numericDescuentos4.Tag = "3"
        '
        'numericDescuentos1
        '
        Me.numericDescuentos1.Location = New System.Drawing.Point(101, 8)
        Me.numericDescuentos1.Name = "numericDescuentos1"
        Me.numericDescuentos1.Size = New System.Drawing.Size(40, 20)
        Me.numericDescuentos1.TabIndex = 379
        Me.numericDescuentos1.Tag = "0"
        '
        'numericDescuentos3
        '
        Me.numericDescuentos3.Location = New System.Drawing.Point(101, 62)
        Me.numericDescuentos3.Name = "numericDescuentos3"
        Me.numericDescuentos3.Size = New System.Drawing.Size(40, 20)
        Me.numericDescuentos3.TabIndex = 383
        Me.numericDescuentos3.Tag = "2"
        '
        'cboDescuentos3
        '
        Me.cboDescuentos3.FormattingEnabled = True
        Me.cboDescuentos3.Location = New System.Drawing.Point(5, 62)
        Me.cboDescuentos3.Name = "cboDescuentos3"
        Me.cboDescuentos3.Size = New System.Drawing.Size(90, 21)
        Me.cboDescuentos3.TabIndex = 388
        Me.cboDescuentos3.Tag = "2"
        '
        'cboDescuentos2
        '
        Me.cboDescuentos2.FormattingEnabled = True
        Me.cboDescuentos2.Location = New System.Drawing.Point(5, 35)
        Me.cboDescuentos2.Name = "cboDescuentos2"
        Me.cboDescuentos2.Size = New System.Drawing.Size(90, 21)
        Me.cboDescuentos2.TabIndex = 387
        Me.cboDescuentos2.Tag = "1"
        '
        'numericDescuentos2
        '
        Me.numericDescuentos2.Location = New System.Drawing.Point(101, 35)
        Me.numericDescuentos2.Name = "numericDescuentos2"
        Me.numericDescuentos2.Size = New System.Drawing.Size(40, 20)
        Me.numericDescuentos2.TabIndex = 381
        Me.numericDescuentos2.Tag = "1"
        '
        'RecognitionLabel
        '
        Me.RecognitionLabel.AutoSize = True
        Me.RecognitionLabel.ForeColor = System.Drawing.Color.Gray
        Me.RecognitionLabel.Location = New System.Drawing.Point(9, 19)
        Me.RecognitionLabel.MaximumSize = New System.Drawing.Size(260, 0)
        Me.RecognitionLabel.Name = "RecognitionLabel"
        Me.RecognitionLabel.Size = New System.Drawing.Size(151, 13)
        Me.RecognitionLabel.TabIndex = 381
        Me.RecognitionLabel.Text = "Se reconoció: Template Name"
        Me.RecognitionLabel.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(12, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(121, 13)
        Me.Label13.TabIndex = 377
        Me.Label13.Text = "Descuentos Adicionales"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(38, 37)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 13)
        Me.Label18.TabIndex = 372
        Me.Label18.Text = "Recetas"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(41, 52)
        Me.NumericUpDown1.Margin = New System.Windows.Forms.Padding(2)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(42, 20)
        Me.NumericUpDown1.TabIndex = 357
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(236, 178)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(31, 13)
        Me.Label22.TabIndex = 376
        Me.Label22.Text = "Total"
        Me.Label22.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(102, 37)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 375
        Me.Label21.Text = "Recaudado"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(111, 52)
        Me.NumericUpDown2.Margin = New System.Windows.Forms.Padding(2)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(42, 20)
        Me.NumericUpDown2.TabIndex = 358
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(171, 37)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(62, 13)
        Me.Label20.TabIndex = 374
        Me.Label20.Text = "A cargo OS"
        '
        'NumericUpDown3
        '
        Me.NumericUpDown3.Location = New System.Drawing.Point(179, 52)
        Me.NumericUpDown3.Margin = New System.Windows.Forms.Padding(2)
        Me.NumericUpDown3.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericUpDown3.Name = "NumericUpDown3"
        Me.NumericUpDown3.Size = New System.Drawing.Size(42, 20)
        Me.NumericUpDown3.TabIndex = 359
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(236, 134)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 373
        Me.Label12.Text = "Bonificacion"
        Me.Label12.Visible = False
        '
        'NumericUpDown4
        '
        Me.NumericUpDown4.Location = New System.Drawing.Point(238, 149)
        Me.NumericUpDown4.Margin = New System.Windows.Forms.Padding(2)
        Me.NumericUpDown4.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericUpDown4.Name = "NumericUpDown4"
        Me.NumericUpDown4.Size = New System.Drawing.Size(63, 20)
        Me.NumericUpDown4.TabIndex = 360
        Me.NumericUpDown4.Visible = False
        '
        'NumericUpDown5
        '
        Me.NumericUpDown5.Location = New System.Drawing.Point(238, 193)
        Me.NumericUpDown5.Margin = New System.Windows.Forms.Padding(2)
        Me.NumericUpDown5.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericUpDown5.Name = "NumericUpDown5"
        Me.NumericUpDown5.Size = New System.Drawing.Size(63, 20)
        Me.NumericUpDown5.TabIndex = 361
        Me.NumericUpDown5.Visible = False
        '
        'btnScan
        '
        Me.btnScan.Enabled = False
        Me.btnScan.Location = New System.Drawing.Point(95, 221)
        Me.btnScan.Margin = New System.Windows.Forms.Padding(2)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(83, 26)
        Me.btnScan.TabIndex = 371
        Me.btnScan.Text = "Escanear"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 263)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(134, 13)
        Me.Label11.TabIndex = 372
        Me.Label11.Text = "Detalle Liquidación Filtrada"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(974, 253)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 13)
        Me.Label6.TabIndex = 367
        Me.Label6.Text = "Col"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(911, 253)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 366
        Me.Label5.Text = "Fila"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(143, 13)
        Me.Label10.TabIndex = 371
        Me.Label10.Text = "Detalle Liquidación Sin Filtrar"
        '
        'grdDetalleLiquidacionFiltrada
        '
        Me.grdDetalleLiquidacionFiltrada.AllowUserToAddRows = False
        Me.grdDetalleLiquidacionFiltrada.AllowUserToDeleteRows = False
        Me.grdDetalleLiquidacionFiltrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDetalleLiquidacionFiltrada.Location = New System.Drawing.Point(17, 291)
        Me.grdDetalleLiquidacionFiltrada.Margin = New System.Windows.Forms.Padding(2)
        Me.grdDetalleLiquidacionFiltrada.Name = "grdDetalleLiquidacionFiltrada"
        Me.grdDetalleLiquidacionFiltrada.RowHeadersWidth = 51
        Me.grdDetalleLiquidacionFiltrada.RowTemplate.Height = 24
        Me.grdDetalleLiquidacionFiltrada.Size = New System.Drawing.Size(1007, 219)
        Me.grdDetalleLiquidacionFiltrada.TabIndex = 347
        '
        'grdDetalleLiquidacion
        '
        Me.grdDetalleLiquidacion.AllowUserToAddRows = False
        Me.grdDetalleLiquidacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDetalleLiquidacion.Location = New System.Drawing.Point(17, 28)
        Me.grdDetalleLiquidacion.Margin = New System.Windows.Forms.Padding(2)
        Me.grdDetalleLiquidacion.Name = "grdDetalleLiquidacion"
        Me.grdDetalleLiquidacion.RowHeadersWidth = 51
        Me.grdDetalleLiquidacion.RowTemplate.Height = 24
        Me.grdDetalleLiquidacion.Size = New System.Drawing.Size(1007, 219)
        Me.grdDetalleLiquidacion.TabIndex = 355
        '
        'chkAnuladas
        '
        Me.chkAnuladas.AccessibleName = ""
        Me.chkAnuladas.AutoSize = True
        Me.chkAnuladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAnuladas.ForeColor = System.Drawing.Color.Red
        Me.chkAnuladas.Location = New System.Drawing.Point(758, 4)
        Me.chkAnuladas.Name = "chkAnuladas"
        Me.chkAnuladas.Size = New System.Drawing.Size(179, 17)
        Me.chkAnuladas.TabIndex = 28
        Me.chkAnuladas.Text = "Ver Recepciones Anuladas"
        Me.chkAnuladas.UseVisualStyleBackColor = True
        Me.chkAnuladas.Visible = False
        '
        'lblCantidadFilas
        '
        Me.lblCantidadFilas.AutoSize = True
        Me.lblCantidadFilas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCantidadFilas.Location = New System.Drawing.Point(111, 483)
        Me.lblCantidadFilas.Name = "lblCantidadFilas"
        Me.lblCantidadFilas.Size = New System.Drawing.Size(46, 13)
        Me.lblCantidadFilas.TabIndex = 270
        Me.lblCantidadFilas.Text = "Subtotal"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label19.Location = New System.Drawing.Point(12, 483)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 13)
        Me.Label19.TabIndex = 271
        Me.Label19.Text = "Cantidad de Ítems: "
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
        Me.SuperGrdResultado.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.SuperGrdResultado.Location = New System.Drawing.Point(7, 136)
        Me.SuperGrdResultado.Margin = New System.Windows.Forms.Padding(2)
        Me.SuperGrdResultado.Name = "SuperGrdResultado"
        '
        '
        '
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
        Me.SuperGrdResultado.Size = New System.Drawing.Size(1067, 325)
        Me.SuperGrdResultado.TabIndex = 381
        Me.SuperGrdResultado.Text = "SuperGridControl1"
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
        Me.lblcmbObrasSociales.Location = New System.Drawing.Point(391, 26)
        Me.lblcmbObrasSociales.Name = "lblcmbObrasSociales"
        Me.lblcmbObrasSociales.Size = New System.Drawing.Size(62, 13)
        Me.lblcmbObrasSociales.TabIndex = 346
        Me.lblcmbObrasSociales.Text = "Obra Social"
        '
        'cmbObraSocial
        '
        Me.cmbObraSocial.AccessibleName = ""
        Me.cmbObraSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbObraSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbObraSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbObraSocial.Enabled = False
        Me.cmbObraSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbObraSocial.FormattingEnabled = True
        Me.cmbObraSocial.Location = New System.Drawing.Point(97, 69)
        Me.cmbObraSocial.Name = "cmbObraSocial"
        Me.cmbObraSocial.Size = New System.Drawing.Size(162, 21)
        Me.cmbObraSocial.TabIndex = 3
        Me.cmbObraSocial.Visible = False
        '
        'btnLlenarGrilla
        '
        Me.btnLlenarGrilla.Location = New System.Drawing.Point(40, 234)
        Me.btnLlenarGrilla.Name = "btnLlenarGrilla"
        Me.btnLlenarGrilla.Size = New System.Drawing.Size(115, 23)
        Me.btnLlenarGrilla.TabIndex = 12
        Me.btnLlenarGrilla.Text = "Llenar Grilla"
        Me.btnLlenarGrilla.UseVisualStyleBackColor = True
        Me.btnLlenarGrilla.Visible = False
        '
        'chkEliminado
        '
        Me.chkEliminado.AccessibleName = "Eliminado"
        Me.chkEliminado.AutoSize = True
        Me.chkEliminado.Enabled = False
        Me.chkEliminado.Location = New System.Drawing.Point(170, 240)
        Me.chkEliminado.Name = "chkEliminado"
        Me.chkEliminado.Size = New System.Drawing.Size(71, 17)
        Me.chkEliminado.TabIndex = 116
        Me.chkEliminado.Text = "Eliminado"
        Me.chkEliminado.UseVisualStyleBackColor = True
        Me.chkEliminado.Visible = False
        '
        'dtpFECHA
        '
        Me.dtpFECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFECHA.Location = New System.Drawing.Point(97, 41)
        Me.dtpFECHA.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        Me.dtpFECHA.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtpFECHA.Name = "dtpFECHA"
        Me.dtpFECHA.Size = New System.Drawing.Size(95, 20)
        Me.dtpFECHA.TabIndex = 1
        Me.dtpFECHA.Tag = "202"
        '
        'GroupBox5
        '
        Me.GroupBox5.Location = New System.Drawing.Point(590, 80)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(277, 65)
        Me.GroupBox5.TabIndex = 389
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Campos no utilizados"
        Me.GroupBox5.Visible = False
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
        'txtID
        '
        Me.txtID.AccessibleName = "ID"
        Me.txtID.Location = New System.Drawing.Point(32, 69)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(51, 20)
        Me.txtID.TabIndex = 416
        '
        'frmLiquidaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1364, 609)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmLiquidaciones"
        Me.Text = "frmRecepciones"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupPanelDetalleLiquidacion.ResumeLayout(False)
        Me.GroupPanelDetalleLiquidacion.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.PanelDescuentos.ResumeLayout(False)
        CType(Me.numericDescuentos4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericDescuentos1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericDescuentos3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericDescuentos2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetalleLiquidacionFiltrada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetalleLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStripIVA.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEliminado As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFECHA As System.Windows.Forms.DateTimePicker
    Friend Shadows WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BorrarElItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarDescripcionToolStripMenuItem As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnLlenarGrilla As System.Windows.Forms.Button
    Friend WithEvents chkAnuladas As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStripIVA As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BorrarElItemToolStripMenuItemIVA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblCantidadFilas As System.Windows.Forms.Label
    Friend WithEvents chkGrillaInferior As System.Windows.Forms.CheckBox
    Friend WithEvents lblcmbObrasSociales As System.Windows.Forms.Label
    Friend WithEvents cmbObraSocial As System.Windows.Forms.ComboBox
    Friend WithEvents grdDetalleLiquidacionFiltrada As System.Windows.Forms.DataGridView
    Friend WithEvents btnListo As System.Windows.Forms.Button
    Friend WithEvents lblcuit As System.Windows.Forms.Label
    Friend WithEvents FileName As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents grdDetalleLiquidacion As System.Windows.Forms.DataGridView
    Friend WithEvents cboSheet As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown5 As NumericUpDown
    Friend WithEvents NumericUpDown4 As NumericUpDown
    Friend WithEvents NumericUpDown3 As NumericUpDown
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupPanelDetalleLiquidacion As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnScan As Button
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ColLabel As Label
    Friend WithEvents FilaLabel As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnImportExcel As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents numericDescuentos1 As NumericUpDown
    Friend WithEvents cboDescuentos1 As ComboBox
    Friend WithEvents cboDescuentos4 As ComboBox
    Friend WithEvents cboDescuentos3 As ComboBox
    Friend WithEvents cboDescuentos2 As ComboBox
    Friend WithEvents numericDescuentos4 As NumericUpDown
    Friend WithEvents numericDescuentos3 As NumericUpDown
    Friend WithEvents numericDescuentos2 As NumericUpDown
    Friend WithEvents RecognitionLabel As Label
    Friend WithEvents PanelDescuentos As Panel
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
    Friend WithEvents rdTodasOC As RadioButton
    Friend WithEvents rdPendientes As RadioButton
    Friend WithEvents rdAnuladas As RadioButton
    Friend WithEvents Label7 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblID As Label
    Friend WithEvents GroupBox5 As GroupBox
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
End Class
