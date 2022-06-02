<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFacturaElectronica
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturaElectronica))
        Me.grdFarmacia = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSeleccionados = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.btnSelection = New System.Windows.Forms.Button()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.btnGenerarFE = New DevComponents.DotNetBar.ButtonX()
        Me.chkConexion = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCuit = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNroComprobante = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPuntoVta = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.chkNotaCredito = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNroComprobanteNotaCred = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbCondicionIVA = New System.Windows.Forms.ComboBox()
        Me.PicConexion = New System.Windows.Forms.PictureBox()
        Me.dtpFECHA = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblModo = New System.Windows.Forms.Label()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbConceptosFE = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbFormaPago = New System.Windows.Forms.ComboBox()
        Me.dtpVtoPago = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmbDocTipo = New System.Windows.Forms.ComboBox()
        Me.lblObraSocial = New System.Windows.Forms.Label()
        CType(Me.grdFarmacia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicConexion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdFarmacia
        '
        Me.grdFarmacia.AllowUserToAddRows = False
        Me.grdFarmacia.AllowUserToDeleteRows = False
        Me.grdFarmacia.AllowUserToResizeRows = False
        Me.grdFarmacia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdFarmacia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdFarmacia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFarmacia.Location = New System.Drawing.Point(23, 351)
        Me.grdFarmacia.Margin = New System.Windows.Forms.Padding(4)
        Me.grdFarmacia.Name = "grdFarmacia"
        Me.grdFarmacia.RowHeadersVisible = False
        Me.grdFarmacia.RowHeadersWidth = 51
        Me.grdFarmacia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFarmacia.Size = New System.Drawing.Size(1064, 258)
        Me.grdFarmacia.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Farmacias"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(89, 324)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(291, 22)
        Me.txtBuscar.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 327)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Buscar:"
        '
        'lblSeleccionados
        '
        Me.lblSeleccionados.AutoSize = True
        Me.lblSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccionados.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSeleccionados.Location = New System.Drawing.Point(201, 624)
        Me.lblSeleccionados.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSeleccionados.Name = "lblSeleccionados"
        Me.lblSeleccionados.Size = New System.Drawing.Size(112, 17)
        Me.lblSeleccionados.TabIndex = 391
        Me.lblSeleccionados.Text = "0 Seleccionados"
        Me.lblSeleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(101, 15)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(75, 22)
        Me.txtID.TabIndex = 392
        '
        'btnSelection
        '
        Me.btnSelection.Location = New System.Drawing.Point(21, 618)
        Me.btnSelection.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSelection.Name = "btnSelection"
        Me.btnSelection.Size = New System.Drawing.Size(171, 28)
        Me.btnSelection.TabIndex = 396
        Me.btnSelection.Text = "Seleccionar todo"
        Me.btnSelection.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrint.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = Global.CENPROFAR.My.Resources.Resources.btnimprimir
        Me.btnPrint.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.btnPrint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.btnPrint.Location = New System.Drawing.Point(973, 320)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(112, 30)
        Me.btnPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrint.TabIndex = 398
        Me.btnPrint.Text = "Imprimir"
        Me.btnPrint.TextColor = System.Drawing.SystemColors.InfoText
        Me.btnPrint.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(548, 325)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 17)
        Me.Label4.TabIndex = 400
        Me.Label4.Text = "Fecha Inicio:"
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(764, 325)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 17)
        Me.Label5.TabIndex = 402
        Me.Label5.Text = "Fecha Fin:"
        Me.Label5.Visible = False
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(642, 322)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(111, 22)
        Me.dtpFechaInicio.TabIndex = 403
        Me.dtpFechaInicio.Visible = False
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(845, 322)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(111, 22)
        Me.dtpFechaFin.TabIndex = 404
        Me.dtpFechaFin.Visible = False
        '
        'btnGenerarFE
        '
        Me.btnGenerarFE.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerarFE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerarFE.BackColor = System.Drawing.SystemColors.Control
        Me.btnGenerarFE.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerarFE.Location = New System.Drawing.Point(974, 626)
        Me.btnGenerarFE.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGenerarFE.Name = "btnGenerarFE"
        Me.btnGenerarFE.Size = New System.Drawing.Size(113, 31)
        Me.btnGenerarFE.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGenerarFE.TabIndex = 405
        Me.btnGenerarFE.Text = "Generar FE"
        Me.btnGenerarFE.TextColor = System.Drawing.SystemColors.InfoText
        '
        'chkConexion
        '
        Me.chkConexion.AutoSize = True
        Me.chkConexion.Location = New System.Drawing.Point(320, 624)
        Me.chkConexion.Name = "chkConexion"
        Me.chkConexion.Size = New System.Drawing.Size(88, 21)
        Me.chkConexion.TabIndex = 406
        Me.chkConexion.Text = "Conexion"
        Me.chkConexion.UseVisualStyleBackColor = True
        Me.chkConexion.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(23, 300)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 17)
        Me.Label2.TabIndex = 407
        Me.Label2.Text = "Facturas Emitidas"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 64)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 17)
        Me.Label6.TabIndex = 409
        Me.Label6.Text = "Obra Social"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(320, 64)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 17)
        Me.Label7.TabIndex = 411
        Me.Label7.Text = "Cuit"
        '
        'txtCuit
        '
        Me.txtCuit.Location = New System.Drawing.Point(323, 86)
        Me.txtCuit.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCuit.Name = "txtCuit"
        Me.txtCuit.Size = New System.Drawing.Size(158, 22)
        Me.txtCuit.TabIndex = 410
        Me.txtCuit.Text = "30654855168"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(487, 64)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 17)
        Me.Label8.TabIndex = 413
        Me.Label8.Text = "Domicilio"
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Location = New System.Drawing.Point(490, 86)
        Me.txtDomicilio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(345, 22)
        Me.txtDomicilio.TabIndex = 412
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(811, 130)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 17)
        Me.Label9.TabIndex = 415
        Me.Label9.Text = "Tipo Comprobante"
        '
        'cmbTipoComprobante
        '
        Me.cmbTipoComprobante.FormattingEnabled = True
        Me.cmbTipoComprobante.Location = New System.Drawing.Point(814, 150)
        Me.cmbTipoComprobante.Name = "cmbTipoComprobante"
        Me.cmbTipoComprobante.Size = New System.Drawing.Size(226, 24)
        Me.cmbTipoComprobante.TabIndex = 414
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(750, 15)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 17)
        Me.Label10.TabIndex = 419
        Me.Label10.Text = "Nro Comprobante"
        '
        'txtNroComprobante
        '
        Me.txtNroComprobante.Enabled = False
        Me.txtNroComprobante.Location = New System.Drawing.Point(878, 15)
        Me.txtNroComprobante.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNroComprobante.Name = "txtNroComprobante"
        Me.txtNroComprobante.Size = New System.Drawing.Size(162, 22)
        Me.txtNroComprobante.TabIndex = 418
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(551, 18)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 17)
        Me.Label11.TabIndex = 417
        Me.Label11.Text = "Punto Vta"
        '
        'txtPuntoVta
        '
        Me.txtPuntoVta.Enabled = False
        Me.txtPuntoVta.Location = New System.Drawing.Point(629, 15)
        Me.txtPuntoVta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPuntoVta.Name = "txtPuntoVta"
        Me.txtPuntoVta.Size = New System.Drawing.Size(113, 22)
        Me.txtPuntoVta.TabIndex = 416
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(890, 188)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 17)
        Me.Label12.TabIndex = 421
        Me.Label12.Text = "Importe"
        '
        'txtImporte
        '
        Me.txtImporte.Location = New System.Drawing.Point(893, 209)
        Me.txtImporte.Margin = New System.Windows.Forms.Padding(4)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(147, 22)
        Me.txtImporte.TabIndex = 420
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(322, 189)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 17)
        Me.Label13.TabIndex = 423
        Me.Label13.Text = "Observación"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(325, 211)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(560, 21)
        Me.TextBox2.TabIndex = 422
        '
        'chkNotaCredito
        '
        Me.chkNotaCredito.AutoSize = True
        Me.chkNotaCredito.Location = New System.Drawing.Point(31, 211)
        Me.chkNotaCredito.Name = "chkNotaCredito"
        Me.chkNotaCredito.Size = New System.Drawing.Size(109, 21)
        Me.chkNotaCredito.TabIndex = 424
        Me.chkNotaCredito.Text = "Nota Crédito"
        Me.chkNotaCredito.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(144, 189)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 17)
        Me.Label14.TabIndex = 426
        Me.Label14.Text = "Nro Comprobante"
        '
        'txtNroComprobanteNotaCred
        '
        Me.txtNroComprobanteNotaCred.Location = New System.Drawing.Point(147, 210)
        Me.txtNroComprobanteNotaCred.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNroComprobanteNotaCred.Name = "txtNroComprobanteNotaCred"
        Me.txtNroComprobanteNotaCred.Size = New System.Drawing.Size(162, 22)
        Me.txtNroComprobanteNotaCred.TabIndex = 425
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(545, 130)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(95, 17)
        Me.Label15.TabIndex = 428
        Me.Label15.Text = "Condición IVA"
        '
        'cmbCondicionIVA
        '
        Me.cmbCondicionIVA.FormattingEnabled = True
        Me.cmbCondicionIVA.Location = New System.Drawing.Point(543, 150)
        Me.cmbCondicionIVA.Name = "cmbCondicionIVA"
        Me.cmbCondicionIVA.Size = New System.Drawing.Size(265, 24)
        Me.cmbCondicionIVA.TabIndex = 427
        '
        'PicConexion
        '
        Me.PicConexion.Location = New System.Drawing.Point(935, 629)
        Me.PicConexion.Name = "PicConexion"
        Me.PicConexion.Size = New System.Drawing.Size(36, 31)
        Me.PicConexion.TabIndex = 429
        Me.PicConexion.TabStop = False
        '
        'dtpFECHA
        '
        Me.dtpFECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFECHA.Location = New System.Drawing.Point(426, 15)
        Me.dtpFECHA.Name = "dtpFECHA"
        Me.dtpFECHA.Size = New System.Drawing.Size(111, 22)
        Me.dtpFECHA.TabIndex = 431
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(372, 18)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 17)
        Me.Label16.TabIndex = 430
        Me.Label16.Text = "Fecha"
        '
        'lblModo
        '
        Me.lblModo.AutoSize = True
        Me.lblModo.BackColor = System.Drawing.Color.Transparent
        Me.lblModo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModo.ForeColor = System.Drawing.Color.Red
        Me.lblModo.Location = New System.Drawing.Point(415, 624)
        Me.lblModo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblModo.Name = "lblModo"
        Me.lblModo.Size = New System.Drawing.Size(232, 24)
        Me.lblModo.TabIndex = 957
        Me.lblModo.Text = "MODO HOMOLOGACIÓN"
        Me.lblModo.Visible = False
        '
        'dtpHasta
        '
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(147, 152)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(111, 22)
        Me.dtpHasta.TabIndex = 961
        '
        'dtpDesde
        '
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(26, 152)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(111, 22)
        Me.dtpDesde.TabIndex = 960
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(23, 130)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 17)
        Me.Label17.TabIndex = 958
        Me.Label17.Text = "Desde"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(144, 130)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 17)
        Me.Label18.TabIndex = 959
        Me.Label18.Text = "Hasta"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(839, 64)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(75, 17)
        Me.Label19.TabIndex = 963
        Me.Label19.Text = "Conceptos"
        '
        'cmbConceptosFE
        '
        Me.cmbConceptosFE.FormattingEnabled = True
        Me.cmbConceptosFE.Location = New System.Drawing.Point(842, 86)
        Me.cmbConceptosFE.Name = "cmbConceptosFE"
        Me.cmbConceptosFE.Size = New System.Drawing.Size(198, 24)
        Me.cmbConceptosFE.TabIndex = 962
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(390, 130)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(104, 17)
        Me.Label20.TabIndex = 965
        Me.Label20.Text = "Forma de pago"
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.Items.AddRange(New Object() {"CONTADO", "T. DÉBITO", "T. CRÉDITO", "CUENTA CORRIENTE", "CHEQUE", "TICKET", "OTRA"})
        Me.cmbFormaPago.Location = New System.Drawing.Point(388, 150)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(149, 24)
        Me.cmbFormaPago.TabIndex = 964
        '
        'dtpVtoPago
        '
        Me.dtpVtoPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVtoPago.Location = New System.Drawing.Point(271, 152)
        Me.dtpVtoPago.Name = "dtpVtoPago"
        Me.dtpVtoPago.Size = New System.Drawing.Size(111, 22)
        Me.dtpVtoPago.TabIndex = 967
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(268, 130)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(66, 17)
        Me.Label21.TabIndex = 966
        Me.Label21.Text = "Vto Pago"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(198, 64)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(69, 17)
        Me.Label22.TabIndex = 969
        Me.Label22.Text = "Tipo Doc."
        '
        'cmbDocTipo
        '
        Me.cmbDocTipo.FormattingEnabled = True
        Me.cmbDocTipo.Items.AddRange(New Object() {"CONTADO", "T. DÉBITO", "T. CRÉDITO", "CUENTA CORRIENTE", "CHEQUE", "TICKET", "OTRA"})
        Me.cmbDocTipo.Location = New System.Drawing.Point(201, 86)
        Me.cmbDocTipo.Name = "cmbDocTipo"
        Me.cmbDocTipo.Size = New System.Drawing.Size(118, 24)
        Me.cmbDocTipo.TabIndex = 968
        '
        'lblObraSocial
        '
        Me.lblObraSocial.AutoSize = True
        Me.lblObraSocial.Location = New System.Drawing.Point(23, 89)
        Me.lblObraSocial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblObraSocial.Name = "lblObraSocial"
        Me.lblObraSocial.Size = New System.Drawing.Size(82, 17)
        Me.lblObraSocial.TabIndex = 970
        Me.lblObraSocial.Text = "Obra Social"
        '
        'frmFacturaElectronica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1112, 670)
        Me.Controls.Add(Me.lblObraSocial)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.cmbDocTipo)
        Me.Controls.Add(Me.dtpVtoPago)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.cmbFormaPago)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cmbConceptosFE)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.dtpDesde)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblModo)
        Me.Controls.Add(Me.dtpFECHA)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.PicConexion)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmbCondicionIVA)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtNroComprobanteNotaCred)
        Me.Controls.Add(Me.chkNotaCredito)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtImporte)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNroComprobante)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtPuntoVta)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmbTipoComprobante)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtDomicilio)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCuit)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkConexion)
        Me.Controls.Add(Me.btnGenerarFE)
        Me.Controls.Add(Me.dtpFechaFin)
        Me.Controls.Add(Me.dtpFechaInicio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnSelection)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.lblSeleccionados)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdFarmacia)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(994, 47)
        Me.Name = "frmFacturaElectronica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Factura Electrónica"
        CType(Me.grdFarmacia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicConexion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grdFarmacia As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblSeleccionados As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents btnSelection As Button
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents btnGenerarFE As DevComponents.DotNetBar.ButtonX
    Friend WithEvents chkConexion As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCuit As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtDomicilio As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbTipoComprobante As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtNroComprobante As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtPuntoVta As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtImporte As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents chkNotaCredito As CheckBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtNroComprobanteNotaCred As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cmbCondicionIVA As ComboBox
    Friend WithEvents PicConexion As PictureBox
    Friend WithEvents dtpFECHA As DateTimePicker
    Friend WithEvents Label16 As Label
    Friend WithEvents lblModo As Label
    Friend WithEvents dtpHasta As DateTimePicker
    Friend WithEvents dtpDesde As DateTimePicker
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents cmbConceptosFE As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents cmbFormaPago As ComboBox
    Friend WithEvents dtpVtoPago As DateTimePicker
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents cmbDocTipo As ComboBox
    Friend WithEvents lblObraSocial As Label
End Class
