<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportarExcel
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
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
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnImportExcel)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.FileName)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.cboSheet)
        Me.GroupBox3.Location = New System.Drawing.Point(1038, 30)
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
        Me.ColLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ColLabel.AutoSize = True
        Me.ColLabel.Location = New System.Drawing.Point(990, 255)
        Me.ColLabel.Name = "ColLabel"
        Me.ColLabel.Size = New System.Drawing.Size(13, 13)
        Me.ColLabel.TabIndex = 379
        Me.ColLabel.Text = "0"
        '
        'btnListo
        '
        Me.btnListo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnListo.Enabled = False
        Me.btnListo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.3!)
        Me.btnListo.Location = New System.Drawing.Point(1122, 450)
        Me.btnListo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnListo.Name = "btnListo"
        Me.btnListo.Size = New System.Drawing.Size(105, 36)
        Me.btnListo.TabIndex = 348
        Me.btnListo.Text = "Listo"
        Me.btnListo.UseVisualStyleBackColor = True
        '
        'FilaLabel
        '
        Me.FilaLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FilaLabel.AutoSize = True
        Me.FilaLabel.Location = New System.Drawing.Point(928, 255)
        Me.FilaLabel.Name = "FilaLabel"
        Me.FilaLabel.Size = New System.Drawing.Size(13, 13)
        Me.FilaLabel.TabIndex = 378
        Me.FilaLabel.Text = "0"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.GroupBox2.Location = New System.Drawing.Point(1038, 180)
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
        Me.Label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 265)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(134, 13)
        Me.Label11.TabIndex = 372
        Me.Label11.Text = "Detalle Liquidación Filtrada"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(968, 255)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 13)
        Me.Label6.TabIndex = 367
        Me.Label6.Text = "Col"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(905, 255)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 366
        Me.Label5.Text = "Fila"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(143, 13)
        Me.Label10.TabIndex = 371
        Me.Label10.Text = "Detalle Liquidación Sin Filtrar"
        '
        'grdDetalleLiquidacionFiltrada
        '
        Me.grdDetalleLiquidacionFiltrada.AllowUserToAddRows = False
        Me.grdDetalleLiquidacionFiltrada.AllowUserToDeleteRows = False
        Me.grdDetalleLiquidacionFiltrada.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDetalleLiquidacionFiltrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDetalleLiquidacionFiltrada.Location = New System.Drawing.Point(11, 293)
        Me.grdDetalleLiquidacionFiltrada.Margin = New System.Windows.Forms.Padding(2)
        Me.grdDetalleLiquidacionFiltrada.Name = "grdDetalleLiquidacionFiltrada"
        Me.grdDetalleLiquidacionFiltrada.ReadOnly = True
        Me.grdDetalleLiquidacionFiltrada.RowHeadersWidth = 51
        Me.grdDetalleLiquidacionFiltrada.RowTemplate.Height = 24
        Me.grdDetalleLiquidacionFiltrada.Size = New System.Drawing.Size(1007, 219)
        Me.grdDetalleLiquidacionFiltrada.TabIndex = 347
        '
        'grdDetalleLiquidacion
        '
        Me.grdDetalleLiquidacion.AllowUserToAddRows = False
        Me.grdDetalleLiquidacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDetalleLiquidacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDetalleLiquidacion.Location = New System.Drawing.Point(11, 30)
        Me.grdDetalleLiquidacion.Margin = New System.Windows.Forms.Padding(2)
        Me.grdDetalleLiquidacion.Name = "grdDetalleLiquidacion"
        Me.grdDetalleLiquidacion.ReadOnly = True
        Me.grdDetalleLiquidacion.RowHeadersWidth = 51
        Me.grdDetalleLiquidacion.RowTemplate.Height = 24
        Me.grdDetalleLiquidacion.Size = New System.Drawing.Size(1007, 219)
        Me.grdDetalleLiquidacion.TabIndex = 355
        '
        'frmImportarExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1321, 534)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.ColLabel)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnListo)
        Me.Controls.Add(Me.grdDetalleLiquidacion)
        Me.Controls.Add(Me.FilaLabel)
        Me.Controls.Add(Me.grdDetalleLiquidacionFiltrada)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmImportarExcel"
        Me.Text = "frmImportarExcel"
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnImportExcel As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents FileName As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label9 As Label
    Friend WithEvents cboSheet As ComboBox
    Friend WithEvents ColLabel As Label
    Friend WithEvents btnListo As Button
    Friend WithEvents FilaLabel As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents PanelDescuentos As Panel
    Friend WithEvents cboDescuentos1 As ComboBox
    Friend WithEvents cboDescuentos4 As ComboBox
    Friend WithEvents numericDescuentos4 As NumericUpDown
    Friend WithEvents numericDescuentos1 As NumericUpDown
    Friend WithEvents numericDescuentos3 As NumericUpDown
    Friend WithEvents cboDescuentos3 As ComboBox
    Friend WithEvents cboDescuentos2 As ComboBox
    Friend WithEvents numericDescuentos2 As NumericUpDown
    Friend WithEvents RecognitionLabel As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents Label20 As Label
    Friend WithEvents NumericUpDown3 As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents NumericUpDown4 As NumericUpDown
    Friend WithEvents NumericUpDown5 As NumericUpDown
    Friend WithEvents btnScan As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents grdDetalleLiquidacionFiltrada As DataGridView
    Friend WithEvents grdDetalleLiquidacion As DataGridView
End Class
