<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRecepciones
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
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
        Me.cboDescuentos4 = New System.Windows.Forms.ComboBox()
        Me.cboDescuentos3 = New System.Windows.Forms.ComboBox()
        Me.cboDescuentos2 = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.numericDescuentos4 = New System.Windows.Forms.NumericUpDown()
        Me.numericDescuentos3 = New System.Windows.Forms.NumericUpDown()
        Me.numericDescuentos2 = New System.Windows.Forms.NumericUpDown()
        Me.numericDescuentos1 = New System.Windows.Forms.NumericUpDown()
        Me.cboDescuentos1 = New System.Windows.Forms.ComboBox()
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
        Me.grdItems = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdFarmacia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Farmacia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdPresentacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Recetas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Recaudado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AcargoOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bonificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblcuit = New System.Windows.Forms.Label()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.lblcmbObrasSociales = New System.Windows.Forms.Label()
        Me.cmbObraSocial = New System.Windows.Forms.ComboBox()
        Me.txtIdComprobante = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.txtIdMoneda = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.txtNroFacturaCompletoControl = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.txtNroRemitoControl = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grdImpuestos = New System.Windows.Forms.DataGridView()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbAlmacenes = New System.Windows.Forms.ComboBox()
        Me.btnOpenExcelWindow = New System.Windows.Forms.Button()
        Me.lblMontoIva = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtidpago = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.txtIdProveedor = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.txtID = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.txtNota = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnLlenarGrilla = New System.Windows.Forms.Button()
        Me.chkEliminado = New System.Windows.Forms.CheckBox()
        Me.txtCODIGO = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFECHA = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkAnuladas = New System.Windows.Forms.CheckBox()
        Me.txtIdGasto = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.chkGrillaInferior = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblCantidadFilas = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BorrarElItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarDescripcionToolStripMenuItem = New System.Windows.Forms.ToolStripComboBox()
        Me.ContextMenuStripIVA = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BorrarElItemToolStripMenuItemIVA = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        Me.GroupPanelDetalleLiquidacion.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numericDescuentos4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericDescuentos3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericDescuentos2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericDescuentos1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetalleLiquidacionFiltrada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetalleLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdImpuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStripIVA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupPanelDetalleLiquidacion)
        Me.GroupBox1.Controls.Add(Me.grdItems)
        Me.GroupBox1.Controls.Add(Me.lblTotal)
        Me.GroupBox1.Controls.Add(Me.lblcuit)
        Me.GroupBox1.Controls.Add(Me.lblPeriodo)
        Me.GroupBox1.Controls.Add(Me.lblcmbObrasSociales)
        Me.GroupBox1.Controls.Add(Me.cmbObraSocial)
        Me.GroupBox1.Controls.Add(Me.txtIdComprobante)
        Me.GroupBox1.Controls.Add(Me.txtIdMoneda)
        Me.GroupBox1.Controls.Add(Me.txtNroFacturaCompletoControl)
        Me.GroupBox1.Controls.Add(Me.txtNroRemitoControl)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.grdImpuestos)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cmbAlmacenes)
        Me.GroupBox1.Controls.Add(Me.btnOpenExcelWindow)
        Me.GroupBox1.Controls.Add(Me.lblMontoIva)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtidpago)
        Me.GroupBox1.Controls.Add(Me.txtIdProveedor)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.txtNota)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnLlenarGrilla)
        Me.GroupBox1.Controls.Add(Me.chkEliminado)
        Me.GroupBox1.Controls.Add(Me.txtCODIGO)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpFECHA)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkAnuladas)
        Me.GroupBox1.Controls.Add(Me.txtIdGasto)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(7, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(2029, 531)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
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
        Me.GroupPanelDetalleLiquidacion.Location = New System.Drawing.Point(-7, 0)
        Me.GroupPanelDetalleLiquidacion.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupPanelDetalleLiquidacion.Name = "GroupPanelDetalleLiquidacion"
        Me.GroupPanelDetalleLiquidacion.Size = New System.Drawing.Size(1370, 531)
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
        Me.GroupBox3.Location = New System.Drawing.Point(1078, 30)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(236, 125)
        Me.GroupBox3.TabIndex = 380
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Importar Archivo"
        '
        'btnImportExcel
        '
        Me.btnImportExcel.Location = New System.Drawing.Point(144, 41)
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
        Me.Label1.Location = New System.Drawing.Point(26, 26)
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
        Me.FileName.Location = New System.Drawing.Point(29, 43)
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
        Me.Label9.Location = New System.Drawing.Point(26, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 370
        Me.Label9.Text = "Hoja"
        '
        'cboSheet
        '
        Me.cboSheet.AccessibleName = "*OrdenCompra"
        Me.cboSheet.FormattingEnabled = True
        Me.cboSheet.Location = New System.Drawing.Point(29, 87)
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
        Me.btnListo.Location = New System.Drawing.Point(1141, 448)
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
        Me.GroupBox2.Controls.Add(Me.cboDescuentos4)
        Me.GroupBox2.Controls.Add(Me.cboDescuentos3)
        Me.GroupBox2.Controls.Add(Me.cboDescuentos2)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.numericDescuentos4)
        Me.GroupBox2.Controls.Add(Me.numericDescuentos3)
        Me.GroupBox2.Controls.Add(Me.numericDescuentos2)
        Me.GroupBox2.Controls.Add(Me.numericDescuentos1)
        Me.GroupBox2.Controls.Add(Me.cboDescuentos1)
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
        Me.GroupBox2.Location = New System.Drawing.Point(1078, 178)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(236, 255)
        Me.GroupBox2.TabIndex = 377
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Columnas a filtrar"
        '
        'cboDescuentos4
        '
        Me.cboDescuentos4.FormattingEnabled = True
        Me.cboDescuentos4.Items.AddRange(New Object() {"", "Bonificacion", "N. Credito", "Debitos", "Ajustes", "Recupero. Aj", "Recupero Gs"})
        Me.cboDescuentos4.Location = New System.Drawing.Point(52, 187)
        Me.cboDescuentos4.Name = "cboDescuentos4"
        Me.cboDescuentos4.Size = New System.Drawing.Size(90, 21)
        Me.cboDescuentos4.TabIndex = 389
        '
        'cboDescuentos3
        '
        Me.cboDescuentos3.FormattingEnabled = True
        Me.cboDescuentos3.Items.AddRange(New Object() {"", "Bonificacion", "N. Credito", "Debitos", "Ajustes", "Recupero. Aj", "Recupero Gs"})
        Me.cboDescuentos3.Location = New System.Drawing.Point(52, 161)
        Me.cboDescuentos3.Name = "cboDescuentos3"
        Me.cboDescuentos3.Size = New System.Drawing.Size(90, 21)
        Me.cboDescuentos3.TabIndex = 388
        '
        'cboDescuentos2
        '
        Me.cboDescuentos2.FormattingEnabled = True
        Me.cboDescuentos2.Items.AddRange(New Object() {"", "Bonificacion", "N. Credito", "Debitos", "Ajustes", "Recupero. Aj", "Recupero Gs"})
        Me.cboDescuentos2.Location = New System.Drawing.Point(52, 134)
        Me.cboDescuentos2.Name = "cboDescuentos2"
        Me.cboDescuentos2.Size = New System.Drawing.Size(90, 21)
        Me.cboDescuentos2.TabIndex = 387
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(156, 91)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(21, 13)
        Me.Label14.TabIndex = 386
        Me.Label14.Text = "col"
        '
        'numericDescuentos4
        '
        Me.numericDescuentos4.Location = New System.Drawing.Point(148, 188)
        Me.numericDescuentos4.Name = "numericDescuentos4"
        Me.numericDescuentos4.Size = New System.Drawing.Size(40, 20)
        Me.numericDescuentos4.TabIndex = 385
        '
        'numericDescuentos3
        '
        Me.numericDescuentos3.Location = New System.Drawing.Point(148, 161)
        Me.numericDescuentos3.Name = "numericDescuentos3"
        Me.numericDescuentos3.Size = New System.Drawing.Size(40, 20)
        Me.numericDescuentos3.TabIndex = 383
        '
        'numericDescuentos2
        '
        Me.numericDescuentos2.Location = New System.Drawing.Point(148, 134)
        Me.numericDescuentos2.Name = "numericDescuentos2"
        Me.numericDescuentos2.Size = New System.Drawing.Size(40, 20)
        Me.numericDescuentos2.TabIndex = 381
        '
        'numericDescuentos1
        '
        Me.numericDescuentos1.Location = New System.Drawing.Point(148, 107)
        Me.numericDescuentos1.Name = "numericDescuentos1"
        Me.numericDescuentos1.Size = New System.Drawing.Size(40, 20)
        Me.numericDescuentos1.TabIndex = 379
        '
        'cboDescuentos1
        '
        Me.cboDescuentos1.FormattingEnabled = True
        Me.cboDescuentos1.Items.AddRange(New Object() {"", "Bonificacion", "N. Credito", "Debitos", "Ajustes", "Recupero. Aj", "Recupero Gs"})
        Me.cboDescuentos1.Location = New System.Drawing.Point(52, 107)
        Me.cboDescuentos1.Name = "cboDescuentos1"
        Me.cboDescuentos1.Size = New System.Drawing.Size(90, 21)
        Me.cboDescuentos1.TabIndex = 378
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(12, 78)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(121, 13)
        Me.Label13.TabIndex = 377
        Me.Label13.Text = "Descuentos Adicionales"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 28)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 13)
        Me.Label18.TabIndex = 372
        Me.Label18.Text = "Recetas"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(15, 43)
        Me.NumericUpDown1.Margin = New System.Windows.Forms.Padding(2)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(42, 20)
        Me.NumericUpDown1.TabIndex = 357
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(218, 178)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(31, 13)
        Me.Label22.TabIndex = 376
        Me.Label22.Text = "Total"
        Me.Label22.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(76, 28)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 375
        Me.Label21.Text = "Recaudado"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(85, 43)
        Me.NumericUpDown2.Margin = New System.Windows.Forms.Padding(2)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(42, 20)
        Me.NumericUpDown2.TabIndex = 358
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(145, 28)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(62, 13)
        Me.Label20.TabIndex = 374
        Me.Label20.Text = "A cargo OS"
        '
        'NumericUpDown3
        '
        Me.NumericUpDown3.Location = New System.Drawing.Point(153, 43)
        Me.NumericUpDown3.Margin = New System.Windows.Forms.Padding(2)
        Me.NumericUpDown3.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericUpDown3.Name = "NumericUpDown3"
        Me.NumericUpDown3.Size = New System.Drawing.Size(42, 20)
        Me.NumericUpDown3.TabIndex = 359
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(218, 134)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 373
        Me.Label12.Text = "Bonificacion"
        Me.Label12.Visible = False
        '
        'NumericUpDown4
        '
        Me.NumericUpDown4.Location = New System.Drawing.Point(220, 149)
        Me.NumericUpDown4.Margin = New System.Windows.Forms.Padding(2)
        Me.NumericUpDown4.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericUpDown4.Name = "NumericUpDown4"
        Me.NumericUpDown4.Size = New System.Drawing.Size(63, 20)
        Me.NumericUpDown4.TabIndex = 360
        Me.NumericUpDown4.Visible = False
        '
        'NumericUpDown5
        '
        Me.NumericUpDown5.Location = New System.Drawing.Point(220, 193)
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
        Me.btnScan.Location = New System.Drawing.Point(79, 221)
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
        Me.Label11.Text = "Detalle Liquidacion Filtrada"
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
        Me.Label10.Text = "Detalle Liquidacion Sin Filtrar"
        '
        'grdDetalleLiquidacionFiltrada
        '
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
        'grdItems
        '
        Me.grdItems.AllowUserToAddRows = False
        Me.grdItems.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.grdItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.IdFarmacia, Me.Farmacia, Me.IdPresentacion, Me.Recetas, Me.Recaudado, Me.AcargoOS, Me.Bonificacion, Me.Total})
        Me.grdItems.Location = New System.Drawing.Point(3, 211)
        Me.grdItems.Name = "grdItems"
        Me.grdItems.RowHeadersWidth = 51
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdItems.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grdItems.Size = New System.Drawing.Size(1102, 245)
        Me.grdItems.TabIndex = 351
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 125
        '
        'IdFarmacia
        '
        Me.IdFarmacia.HeaderText = "IdFarmacia"
        Me.IdFarmacia.MinimumWidth = 6
        Me.IdFarmacia.Name = "IdFarmacia"
        Me.IdFarmacia.Width = 125
        '
        'Farmacia
        '
        Me.Farmacia.HeaderText = "Farmacia"
        Me.Farmacia.MinimumWidth = 6
        Me.Farmacia.Name = "Farmacia"
        Me.Farmacia.Width = 125
        '
        'IdPresentacion
        '
        Me.IdPresentacion.HeaderText = "IdPresentacion"
        Me.IdPresentacion.MinimumWidth = 6
        Me.IdPresentacion.Name = "IdPresentacion"
        Me.IdPresentacion.Width = 125
        '
        'Recetas
        '
        Me.Recetas.HeaderText = "Recetas"
        Me.Recetas.MinimumWidth = 6
        Me.Recetas.Name = "Recetas"
        Me.Recetas.Width = 125
        '
        'Recaudado
        '
        Me.Recaudado.HeaderText = "Recaudado"
        Me.Recaudado.MinimumWidth = 6
        Me.Recaudado.Name = "Recaudado"
        Me.Recaudado.Width = 125
        '
        'AcargoOS
        '
        Me.AcargoOS.HeaderText = "AcargoOS"
        Me.AcargoOS.MinimumWidth = 6
        Me.AcargoOS.Name = "AcargoOS"
        Me.AcargoOS.Width = 125
        '
        'Bonificacion
        '
        Me.Bonificacion.HeaderText = "Bonificacion"
        Me.Bonificacion.MinimumWidth = 6
        Me.Bonificacion.Name = "Bonificacion"
        Me.Bonificacion.Width = 125
        '
        'Total
        '
        Me.Total.HeaderText = "Total"
        Me.Total.MinimumWidth = 6
        Me.Total.Name = "Total"
        Me.Total.Width = 125
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(692, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(85, 20)
        Me.lblTotal.TabIndex = 24
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Location = New System.Drawing.Point(644, 0)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(43, 13)
        Me.lblPeriodo.TabIndex = 349
        Me.lblPeriodo.Text = "Periodo"
        '
        'lblcmbObrasSociales
        '
        Me.lblcmbObrasSociales.AutoSize = True
        Me.lblcmbObrasSociales.Location = New System.Drawing.Point(203, 16)
        Me.lblcmbObrasSociales.Name = "lblcmbObrasSociales"
        Me.lblcmbObrasSociales.Size = New System.Drawing.Size(78, 13)
        Me.lblcmbObrasSociales.TabIndex = 346
        Me.lblcmbObrasSociales.Text = "Obras Sociales"
        '
        'cmbObraSocial
        '
        Me.cmbObraSocial.AccessibleName = ""
        Me.cmbObraSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbObraSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbObraSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbObraSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbObraSocial.FormattingEnabled = True
        Me.cmbObraSocial.Location = New System.Drawing.Point(202, 31)
        Me.cmbObraSocial.Name = "cmbObraSocial"
        Me.cmbObraSocial.Size = New System.Drawing.Size(194, 21)
        Me.cmbObraSocial.TabIndex = 3
        '
        'txtIdComprobante
        '
        Me.txtIdComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdComprobante.Decimals = CType(2, Byte)
        Me.txtIdComprobante.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtIdComprobante.Enabled = False
        Me.txtIdComprobante.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtIdComprobante.Location = New System.Drawing.Point(533, -2)
        Me.txtIdComprobante.MaxLength = 8
        Me.txtIdComprobante.Name = "txtIdComprobante"
        Me.txtIdComprobante.Size = New System.Drawing.Size(23, 20)
        Me.txtIdComprobante.TabIndex = 297
        Me.txtIdComprobante.Text_1 = Nothing
        Me.txtIdComprobante.Text_2 = Nothing
        Me.txtIdComprobante.Text_3 = Nothing
        Me.txtIdComprobante.Text_4 = Nothing
        Me.txtIdComprobante.UserValues = Nothing
        Me.txtIdComprobante.Visible = False
        '
        'txtIdMoneda
        '
        Me.txtIdMoneda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdMoneda.Decimals = CType(2, Byte)
        Me.txtIdMoneda.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtIdMoneda.Enabled = False
        Me.txtIdMoneda.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtIdMoneda.Location = New System.Drawing.Point(824, 33)
        Me.txtIdMoneda.MaxLength = 8
        Me.txtIdMoneda.Name = "txtIdMoneda"
        Me.txtIdMoneda.Size = New System.Drawing.Size(23, 20)
        Me.txtIdMoneda.TabIndex = 296
        Me.txtIdMoneda.Text_1 = Nothing
        Me.txtIdMoneda.Text_2 = Nothing
        Me.txtIdMoneda.Text_3 = Nothing
        Me.txtIdMoneda.Text_4 = Nothing
        Me.txtIdMoneda.UserValues = Nothing
        Me.txtIdMoneda.Visible = False
        '
        'txtNroFacturaCompletoControl
        '
        Me.txtNroFacturaCompletoControl.AccessibleName = ""
        Me.txtNroFacturaCompletoControl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNroFacturaCompletoControl.Decimals = CType(2, Byte)
        Me.txtNroFacturaCompletoControl.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNroFacturaCompletoControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroFacturaCompletoControl.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtNroFacturaCompletoControl.Location = New System.Drawing.Point(616, 253)
        Me.txtNroFacturaCompletoControl.MaxLength = 20
        Me.txtNroFacturaCompletoControl.Name = "txtNroFacturaCompletoControl"
        Me.txtNroFacturaCompletoControl.ReadOnly = True
        Me.txtNroFacturaCompletoControl.Size = New System.Drawing.Size(121, 20)
        Me.txtNroFacturaCompletoControl.TabIndex = 287
        Me.txtNroFacturaCompletoControl.Text_1 = Nothing
        Me.txtNroFacturaCompletoControl.Text_2 = Nothing
        Me.txtNroFacturaCompletoControl.Text_3 = Nothing
        Me.txtNroFacturaCompletoControl.Text_4 = Nothing
        Me.txtNroFacturaCompletoControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtNroFacturaCompletoControl.UserValues = Nothing
        Me.txtNroFacturaCompletoControl.Visible = False
        '
        'txtNroRemitoControl
        '
        Me.txtNroRemitoControl.AccessibleName = ""
        Me.txtNroRemitoControl.BackColor = System.Drawing.SystemColors.Window
        Me.txtNroRemitoControl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNroRemitoControl.Decimals = CType(2, Byte)
        Me.txtNroRemitoControl.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtNroRemitoControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroRemitoControl.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtNroRemitoControl.Location = New System.Drawing.Point(598, 274)
        Me.txtNroRemitoControl.MaxLength = 25
        Me.txtNroRemitoControl.Name = "txtNroRemitoControl"
        Me.txtNroRemitoControl.Size = New System.Drawing.Size(139, 20)
        Me.txtNroRemitoControl.TabIndex = 286
        Me.txtNroRemitoControl.Text_1 = Nothing
        Me.txtNroRemitoControl.Text_2 = Nothing
        Me.txtNroRemitoControl.Text_3 = Nothing
        Me.txtNroRemitoControl.Text_4 = Nothing
        Me.txtNroRemitoControl.UserValues = Nothing
        Me.txtNroRemitoControl.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(865, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Detalle de Impuestos"
        '
        'grdImpuestos
        '
        Me.grdImpuestos.AllowUserToAddRows = False
        Me.grdImpuestos.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdImpuestos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grdImpuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdImpuestos.DefaultCellStyle = DataGridViewCellStyle5
        Me.grdImpuestos.Location = New System.Drawing.Point(657, 323)
        Me.grdImpuestos.Name = "grdImpuestos"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdImpuestos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.grdImpuestos.RowHeadersWidth = 51
        Me.grdImpuestos.Size = New System.Drawing.Size(448, 133)
        Me.grdImpuestos.TabIndex = 25
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(203, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 13)
        Me.Label16.TabIndex = 274
        Me.Label16.Text = "Depósito*"
        '
        'cmbAlmacenes
        '
        Me.cmbAlmacenes.AccessibleName = "*Depósito"
        Me.cmbAlmacenes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbAlmacenes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAlmacenes.DropDownHeight = 500
        Me.cmbAlmacenes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacenes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAlmacenes.FormattingEnabled = True
        Me.cmbAlmacenes.IntegralHeight = False
        Me.cmbAlmacenes.Location = New System.Drawing.Point(203, 31)
        Me.cmbAlmacenes.Name = "cmbAlmacenes"
        Me.cmbAlmacenes.Size = New System.Drawing.Size(91, 21)
        Me.cmbAlmacenes.TabIndex = 2
        '
        'btnOpenExcelWindow
        '
        Me.btnOpenExcelWindow.Location = New System.Drawing.Point(1236, 475)
        Me.btnOpenExcelWindow.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOpenExcelWindow.Name = "btnOpenExcelWindow"
        Me.btnOpenExcelWindow.Size = New System.Drawing.Size(83, 26)
        Me.btnOpenExcelWindow.TabIndex = 352
        Me.btnOpenExcelWindow.Text = "Importar Excel"
        Me.btnOpenExcelWindow.UseVisualStyleBackColor = True
        '
        'lblMontoIva
        '
        Me.lblMontoIva.BackColor = System.Drawing.Color.White
        Me.lblMontoIva.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMontoIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoIva.Location = New System.Drawing.Point(652, 300)
        Me.lblMontoIva.Name = "lblMontoIva"
        Me.lblMontoIva.Size = New System.Drawing.Size(85, 20)
        Me.lblMontoIva.TabIndex = 17
        Me.lblMontoIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblMontoIva.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(788, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 243
        Me.Label7.Text = "Total"
        '
        'txtidpago
        '
        Me.txtidpago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtidpago.Decimals = CType(2, Byte)
        Me.txtidpago.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtidpago.Enabled = False
        Me.txtidpago.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtidpago.Location = New System.Drawing.Point(1083, 234)
        Me.txtidpago.MaxLength = 8
        Me.txtidpago.Name = "txtidpago"
        Me.txtidpago.Size = New System.Drawing.Size(23, 20)
        Me.txtidpago.TabIndex = 192
        Me.txtidpago.Text_1 = Nothing
        Me.txtidpago.Text_2 = Nothing
        Me.txtidpago.Text_3 = Nothing
        Me.txtidpago.Text_4 = Nothing
        Me.txtidpago.UserValues = Nothing
        Me.txtidpago.Visible = False
        '
        'txtIdProveedor
        '
        Me.txtIdProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdProveedor.Decimals = CType(2, Byte)
        Me.txtIdProveedor.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtIdProveedor.Enabled = False
        Me.txtIdProveedor.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtIdProveedor.Location = New System.Drawing.Point(561, -2)
        Me.txtIdProveedor.MaxLength = 8
        Me.txtIdProveedor.Name = "txtIdProveedor"
        Me.txtIdProveedor.Size = New System.Drawing.Size(23, 20)
        Me.txtIdProveedor.TabIndex = 130
        Me.txtIdProveedor.Text_1 = Nothing
        Me.txtIdProveedor.Text_2 = Nothing
        Me.txtIdProveedor.Text_3 = Nothing
        Me.txtIdProveedor.Text_4 = Nothing
        Me.txtIdProveedor.UserValues = Nothing
        Me.txtIdProveedor.Visible = False
        '
        'txtID
        '
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.Decimals = CType(2, Byte)
        Me.txtID.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtID.Enabled = False
        Me.txtID.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtID.Location = New System.Drawing.Point(1020, 234)
        Me.txtID.MaxLength = 8
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(23, 20)
        Me.txtID.TabIndex = 50
        Me.txtID.Text_1 = Nothing
        Me.txtID.Text_2 = Nothing
        Me.txtID.Text_3 = Nothing
        Me.txtID.Text_4 = Nothing
        Me.txtID.UserValues = Nothing
        Me.txtID.Visible = False
        '
        'txtNota
        '
        Me.txtNota.AccessibleName = "Nota"
        Me.txtNota.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNota.Decimals = CType(2, Byte)
        Me.txtNota.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtNota.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtNota.Location = New System.Drawing.Point(418, 39)
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(574, 20)
        Me.txtNota.TabIndex = 8
        Me.txtNota.Text_1 = Nothing
        Me.txtNota.Text_2 = Nothing
        Me.txtNota.Text_3 = Nothing
        Me.txtNota.Text_4 = Nothing
        Me.txtNota.UserValues = Nothing
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(416, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 118
        Me.Label8.Text = "Nota"
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
        'txtCODIGO
        '
        Me.txtCODIGO.AccessibleName = "CODIGO"
        Me.txtCODIGO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCODIGO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCODIGO.Decimals = CType(2, Byte)
        Me.txtCODIGO.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtCODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCODIGO.Format = TextBoxConFormatoVB.tbFormats.SpacedAlphaNumeric
        Me.txtCODIGO.Location = New System.Drawing.Point(13, 31)
        Me.txtCODIGO.MaxLength = 25
        Me.txtCODIGO.Name = "txtCODIGO"
        Me.txtCODIGO.ReadOnly = True
        Me.txtCODIGO.Size = New System.Drawing.Size(76, 20)
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
        Me.Label2.Location = New System.Drawing.Point(10, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Nro Recepción"
        '
        'dtpFECHA
        '
        Me.dtpFECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFECHA.Location = New System.Drawing.Point(95, 31)
        Me.dtpFECHA.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        Me.dtpFECHA.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtpFECHA.Name = "dtpFECHA"
        Me.dtpFECHA.Size = New System.Drawing.Size(102, 20)
        Me.dtpFECHA.TabIndex = 1
        Me.dtpFECHA.Tag = "202"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(92, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Fecha"
        '
        'chkAnuladas
        '
        Me.chkAnuladas.AccessibleName = ""
        Me.chkAnuladas.AutoSize = True
        Me.chkAnuladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAnuladas.ForeColor = System.Drawing.Color.Red
        Me.chkAnuladas.Location = New System.Drawing.Point(652, 181)
        Me.chkAnuladas.Name = "chkAnuladas"
        Me.chkAnuladas.Size = New System.Drawing.Size(179, 17)
        Me.chkAnuladas.TabIndex = 28
        Me.chkAnuladas.Text = "Ver Recepciones Anuladas"
        Me.chkAnuladas.UseVisualStyleBackColor = True
        '
        'txtIdGasto
        '
        Me.txtIdGasto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdGasto.Decimals = CType(2, Byte)
        Me.txtIdGasto.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtIdGasto.Enabled = False
        Me.txtIdGasto.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtIdGasto.Location = New System.Drawing.Point(1071, 30)
        Me.txtIdGasto.MaxLength = 8
        Me.txtIdGasto.Name = "txtIdGasto"
        Me.txtIdGasto.Size = New System.Drawing.Size(35, 20)
        Me.txtIdGasto.TabIndex = 191
        Me.txtIdGasto.Text_1 = Nothing
        Me.txtIdGasto.Text_2 = Nothing
        Me.txtIdGasto.Text_3 = Nothing
        Me.txtIdGasto.Text_4 = Nothing
        Me.txtIdGasto.UserValues = Nothing
        Me.txtIdGasto.Visible = False
        '
        'chkGrillaInferior
        '
        Me.chkGrillaInferior.AutoSize = True
        Me.chkGrillaInferior.Location = New System.Drawing.Point(319, 562)
        Me.chkGrillaInferior.Name = "chkGrillaInferior"
        Me.chkGrillaInferior.Size = New System.Drawing.Size(132, 17)
        Me.chkGrillaInferior.TabIndex = 272
        Me.chkGrillaInferior.Text = "Aumentar Grilla Inferior"
        Me.chkGrillaInferior.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(152, 566)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 13)
        Me.Label19.TabIndex = 271
        Me.Label19.Text = "Cantidad de Ítems: "
        '
        'lblCantidadFilas
        '
        Me.lblCantidadFilas.AutoSize = True
        Me.lblCantidadFilas.Location = New System.Drawing.Point(255, 566)
        Me.lblCantidadFilas.Name = "lblCantidadFilas"
        Me.lblCantidadFilas.Size = New System.Drawing.Size(46, 13)
        Me.lblCantidadFilas.TabIndex = 270
        Me.lblCantidadFilas.Text = "Subtotal"
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
        'frmRecepciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 609)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkGrillaInferior)
        Me.Controls.Add(Me.lblCantidadFilas)
        Me.Controls.Add(Me.Label19)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmRecepciones"
        Me.Text = "frmRecepciones"
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.lblCantidadFilas, 0)
        Me.Controls.SetChildIndex(Me.chkGrillaInferior, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupPanelDetalleLiquidacion.ResumeLayout(False)
        Me.GroupPanelDetalleLiquidacion.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numericDescuentos4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericDescuentos3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericDescuentos2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericDescuentos1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetalleLiquidacionFiltrada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetalleLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdImpuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStripIVA.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNota As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkEliminado As System.Windows.Forms.CheckBox
    Friend WithEvents txtID As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents txtCODIGO As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFECHA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend Shadows WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BorrarElItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarDescripcionToolStripMenuItem As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnLlenarGrilla As System.Windows.Forms.Button
    Friend WithEvents txtIdProveedor As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents txtIdGasto As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents txtidpago As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblMontoIva As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkAnuladas As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStripIVA As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BorrarElItemToolStripMenuItemIVA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblCantidadFilas As System.Windows.Forms.Label
    Friend WithEvents chkGrillaInferior As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacenes As System.Windows.Forms.ComboBox
    Friend WithEvents grdImpuestos As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNroRemitoControl As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents txtNroFacturaCompletoControl As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents txtIdMoneda As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents txtIdComprobante As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents lblcmbObrasSociales As System.Windows.Forms.Label
    Friend WithEvents cmbObraSocial As System.Windows.Forms.ComboBox
    Friend WithEvents grdDetalleLiquidacionFiltrada As System.Windows.Forms.DataGridView
    Friend WithEvents btnListo As System.Windows.Forms.Button
    Friend WithEvents grdItems As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdFarmacia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Farmacia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdPresentacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Recetas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Recaudado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcargoOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bonificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblcuit As System.Windows.Forms.Label
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents btnOpenExcelWindow As System.Windows.Forms.Button
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
    Friend WithEvents Label14 As Label
    Friend WithEvents numericDescuentos4 As NumericUpDown
    Friend WithEvents numericDescuentos3 As NumericUpDown
    Friend WithEvents numericDescuentos2 As NumericUpDown
End Class
