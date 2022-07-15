<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmComisionCenprofarPorFarmacia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComisionCenprofarPorFarmacia))
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
        Me.chkNotaCredito = New System.Windows.Forms.CheckBox()
        Me.PicConexion = New System.Windows.Forms.PictureBox()
        Me.lblModo = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.cmbNroComprobanteNotaCred = New System.Windows.Forms.ComboBox()
        Me.lblNroComprobanteNotaCred = New System.Windows.Forms.Label()
        Me.chkVerFacturasEmitidas = New System.Windows.Forms.CheckBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.cmbAnio = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.grdFarmacia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicConexion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdFarmacia
        '
        Me.grdFarmacia.AllowUserToAddRows = False
        Me.grdFarmacia.AllowUserToDeleteRows = False
        Me.grdFarmacia.AllowUserToResizeRows = False
        Me.grdFarmacia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdFarmacia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFarmacia.Location = New System.Drawing.Point(13, 199)
        Me.grdFarmacia.Margin = New System.Windows.Forms.Padding(4)
        Me.grdFarmacia.Name = "grdFarmacia"
        Me.grdFarmacia.RowHeadersVisible = False
        Me.grdFarmacia.RowHeadersWidth = 51
        Me.grdFarmacia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFarmacia.Size = New System.Drawing.Size(1086, 323)
        Me.grdFarmacia.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(405, 168)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Farmacias"
        Me.Label1.Visible = False
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(95, 165)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(302, 22)
        Me.txtBuscar.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 169)
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
        Me.lblSeleccionados.Location = New System.Drawing.Point(235, 540)
        Me.lblSeleccionados.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSeleccionados.Name = "lblSeleccionados"
        Me.lblSeleccionados.Size = New System.Drawing.Size(112, 17)
        Me.lblSeleccionados.TabIndex = 391
        Me.lblSeleccionados.Text = "0 Seleccionados"
        Me.lblSeleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(502, 165)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(86, 22)
        Me.txtID.TabIndex = 392
        Me.txtID.Visible = False
        '
        'btnSelection
        '
        Me.btnSelection.Location = New System.Drawing.Point(10, 533)
        Me.btnSelection.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSelection.Name = "btnSelection"
        Me.btnSelection.Size = New System.Drawing.Size(182, 28)
        Me.btnSelection.TabIndex = 396
        Me.btnSelection.Text = "Seleccionar todo"
        Me.btnSelection.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrint.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = Global.CENPROFAR.My.Resources.Resources.btnimprimir
        Me.btnPrint.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.btnPrint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.btnPrint.Location = New System.Drawing.Point(963, 155)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(123, 30)
        Me.btnPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrint.TabIndex = 398
        Me.btnPrint.Text = "Imprimir"
        Me.btnPrint.TextColor = System.Drawing.SystemColors.InfoText
        Me.btnPrint.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(602, 168)
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
        Me.Label5.Location = New System.Drawing.Point(788, 165)
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
        Me.dtpFechaInicio.Location = New System.Drawing.Point(688, 165)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(93, 22)
        Me.dtpFechaInicio.TabIndex = 403
        Me.dtpFechaInicio.Visible = False
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(855, 164)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(87, 22)
        Me.dtpFechaFin.TabIndex = 404
        Me.dtpFechaFin.Visible = False
        '
        'btnGenerarFE
        '
        Me.btnGenerarFE.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerarFE.BackColor = System.Drawing.SystemColors.Control
        Me.btnGenerarFE.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerarFE.Location = New System.Drawing.Point(977, 551)
        Me.btnGenerarFE.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGenerarFE.Name = "btnGenerarFE"
        Me.btnGenerarFE.Size = New System.Drawing.Size(124, 31)
        Me.btnGenerarFE.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGenerarFE.TabIndex = 405
        Me.btnGenerarFE.Text = "Generar FE"
        Me.btnGenerarFE.TextColor = System.Drawing.SystemColors.InfoText
        '
        'chkConexion
        '
        Me.chkConexion.AutoSize = True
        Me.chkConexion.Location = New System.Drawing.Point(384, 540)
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
        Me.Label2.Location = New System.Drawing.Point(13, 135)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 17)
        Me.Label2.TabIndex = 407
        Me.Label2.Text = "FACTURAS A EMITIR"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkNotaCredito
        '
        Me.chkNotaCredito.AutoSize = True
        Me.chkNotaCredito.Location = New System.Drawing.Point(240, 127)
        Me.chkNotaCredito.Name = "chkNotaCredito"
        Me.chkNotaCredito.Size = New System.Drawing.Size(109, 21)
        Me.chkNotaCredito.TabIndex = 424
        Me.chkNotaCredito.Text = "Nota Crédito"
        Me.chkNotaCredito.UseVisualStyleBackColor = True
        Me.chkNotaCredito.Visible = False
        '
        'PicConexion
        '
        Me.PicConexion.Location = New System.Drawing.Point(928, 554)
        Me.PicConexion.Name = "PicConexion"
        Me.PicConexion.Size = New System.Drawing.Size(47, 31)
        Me.PicConexion.TabIndex = 429
        Me.PicConexion.TabStop = False
        '
        'lblModo
        '
        Me.lblModo.AutoSize = True
        Me.lblModo.BackColor = System.Drawing.Color.Transparent
        Me.lblModo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModo.ForeColor = System.Drawing.Color.Red
        Me.lblModo.Location = New System.Drawing.Point(503, 540)
        Me.lblModo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblModo.Name = "lblModo"
        Me.lblModo.Size = New System.Drawing.Size(232, 24)
        Me.lblModo.TabIndex = 957
        Me.lblModo.Text = "MODO HOMOLOGACIÓN"
        Me.lblModo.Visible = False
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(988, 522)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(111, 22)
        Me.txtTotal.TabIndex = 972
        '
        'cmbNroComprobanteNotaCred
        '
        Me.cmbNroComprobanteNotaCred.FormattingEnabled = True
        Me.cmbNroComprobanteNotaCred.Location = New System.Drawing.Point(467, 125)
        Me.cmbNroComprobanteNotaCred.Name = "cmbNroComprobanteNotaCred"
        Me.cmbNroComprobanteNotaCred.Size = New System.Drawing.Size(157, 24)
        Me.cmbNroComprobanteNotaCred.TabIndex = 975
        Me.cmbNroComprobanteNotaCred.Visible = False
        '
        'lblNroComprobanteNotaCred
        '
        Me.lblNroComprobanteNotaCred.AutoSize = True
        Me.lblNroComprobanteNotaCred.Location = New System.Drawing.Point(352, 127)
        Me.lblNroComprobanteNotaCred.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNroComprobanteNotaCred.Name = "lblNroComprobanteNotaCred"
        Me.lblNroComprobanteNotaCred.Size = New System.Drawing.Size(120, 17)
        Me.lblNroComprobanteNotaCred.TabIndex = 974
        Me.lblNroComprobanteNotaCred.Text = "Nro Comprobante"
        Me.lblNroComprobanteNotaCred.Visible = False
        '
        'chkVerFacturasEmitidas
        '
        Me.chkVerFacturasEmitidas.AutoSize = True
        Me.chkVerFacturasEmitidas.Location = New System.Drawing.Point(918, 123)
        Me.chkVerFacturasEmitidas.Name = "chkVerFacturasEmitidas"
        Me.chkVerFacturasEmitidas.Size = New System.Drawing.Size(168, 21)
        Me.chkVerFacturasEmitidas.TabIndex = 977
        Me.chkVerFacturasEmitidas.Text = "Ver Facturas Emitidas"
        Me.chkVerFacturasEmitidas.UseVisualStyleBackColor = True
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(17, 101)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(110, 22)
        Me.dtpFecha.TabIndex = 978
        '
        'cmbMes
        '
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cmbMes.Location = New System.Drawing.Point(16, 44)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(195, 24)
        Me.cmbMes.TabIndex = 981
        '
        'cmbAnio
        '
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.Location = New System.Drawing.Point(238, 44)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(195, 24)
        Me.cmbAnio.TabIndex = 982
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(237, 24)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 17)
        Me.Label6.TabIndex = 983
        Me.Label6.Text = "Año"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 24)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 17)
        Me.Label7.TabIndex = 984
        Me.Label7.Text = "Mes"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Location = New System.Drawing.Point(449, 37)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(86, 31)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 985
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextColor = System.Drawing.SystemColors.InfoText
        '
        'frmComisionCenprofarPorFarmacia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1112, 607)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbAnio)
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.chkVerFacturasEmitidas)
        Me.Controls.Add(Me.cmbNroComprobanteNotaCred)
        Me.Controls.Add(Me.lblNroComprobanteNotaCred)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblModo)
        Me.Controls.Add(Me.PicConexion)
        Me.Controls.Add(Me.chkNotaCredito)
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
        Me.Name = "frmComisionCenprofarPorFarmacia"
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
    Friend WithEvents chkNotaCredito As CheckBox
    Friend WithEvents PicConexion As PictureBox
    Friend WithEvents lblModo As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents cmbNroComprobanteNotaCred As ComboBox
    Friend WithEvents lblNroComprobanteNotaCred As Label
    Friend WithEvents chkVerFacturasEmitidas As CheckBox
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents cmbMes As ComboBox
    Friend WithEvents cmbAnio As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
End Class
