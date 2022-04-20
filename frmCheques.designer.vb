<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCheques
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheques))
        Me.grdCheques = New System.Windows.Forms.DataGridView()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSeleccionados = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.btnSelection = New System.Windows.Forms.Button()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpPago = New System.Windows.Forms.DateTimePicker()
        Me.dtpEmision = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnIntervalo = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtLastCheque = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSerieCheque = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFirstCheque = New System.Windows.Forms.TextBox()
        CType(Me.grdCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdCheques
        '
        Me.grdCheques.AllowUserToAddRows = False
        Me.grdCheques.AllowUserToDeleteRows = False
        Me.grdCheques.AllowUserToResizeRows = False
        Me.grdCheques.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdCheques.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCheques.Location = New System.Drawing.Point(17, 62)
        Me.grdCheques.Name = "grdCheques"
        Me.grdCheques.RowHeadersVisible = False
        Me.grdCheques.RowHeadersWidth = 51
        Me.grdCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdCheques.Size = New System.Drawing.Size(764, 260)
        Me.grdCheques.TabIndex = 0
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(68, 22)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(219, 20)
        Me.txtBuscar.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Buscar:"
        '
        'lblSeleccionados
        '
        Me.lblSeleccionados.AutoSize = True
        Me.lblSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccionados.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSeleccionados.Location = New System.Drawing.Point(300, 25)
        Me.lblSeleccionados.Name = "lblSeleccionados"
        Me.lblSeleccionados.Size = New System.Drawing.Size(86, 13)
        Me.lblSeleccionados.TabIndex = 391
        Me.lblSeleccionados.Text = "0 Seleccionados"
        Me.lblSeleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtID
        '
        Me.txtID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtID.Location = New System.Drawing.Point(133, 155)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(54, 20)
        Me.txtID.TabIndex = 392
        Me.txtID.Visible = False
        '
        'btnSelection
        '
        Me.btnSelection.Location = New System.Drawing.Point(27, 20)
        Me.btnSelection.Name = "btnSelection"
        Me.btnSelection.Size = New System.Drawing.Size(128, 23)
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
        Me.btnPrint.Location = New System.Drawing.Point(223, 37)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(98, 32)
        Me.btnPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrint.TabIndex = 397
        Me.btnPrint.Text = "Imprimir"
        Me.btnPrint.TextColor = System.Drawing.SystemColors.InfoText
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(298, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 399
        Me.Label2.Text = "Desde:"
        '
        'dtpDesde
        '
        Me.dtpDesde.CustomFormat = "--/--/----"
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.Location = New System.Drawing.Point(342, 23)
        Me.dtpDesde.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(102, 20)
        Me.dtpDesde.TabIndex = 400
        Me.dtpDesde.Value = New Date(2022, 4, 14, 0, 0, 0, 0)
        '
        'dtpHasta
        '
        Me.dtpHasta.CustomFormat = "--/--/----"
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.Location = New System.Drawing.Point(496, 23)
        Me.dtpHasta.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(103, 20)
        Me.dtpHasta.TabIndex = 402
        Me.dtpHasta.Value = New Date(2022, 4, 14, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(455, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 401
        Me.Label4.Text = "Hasta:"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(604, 21)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(56, 23)
        Me.btnLimpiar.TabIndex = 403
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        Me.btnLimpiar.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 410
        Me.Label5.Text = "Fecha emisión:"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 411
        Me.Label6.Text = "Fecha de pago:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtpPago)
        Me.GroupBox1.Controls.Add(Me.dtpEmision)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnPrint)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(437, 326)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(344, 96)
        Me.GroupBox1.TabIndex = 412
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Imprimir Cheques"
        '
        'dtpPago
        '
        Me.dtpPago.CustomFormat = "--/--/----"
        Me.dtpPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPago.Location = New System.Drawing.Point(100, 61)
        Me.dtpPago.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpPago.Name = "dtpPago"
        Me.dtpPago.Size = New System.Drawing.Size(101, 20)
        Me.dtpPago.TabIndex = 415
        Me.dtpPago.Value = New Date(2022, 4, 14, 0, 0, 0, 0)
        '
        'dtpEmision
        '
        Me.dtpEmision.CustomFormat = "--/--/----"
        Me.dtpEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEmision.Location = New System.Drawing.Point(100, 30)
        Me.dtpEmision.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpEmision.Name = "dtpEmision"
        Me.dtpEmision.Size = New System.Drawing.Size(101, 20)
        Me.dtpEmision.TabIndex = 414
        Me.dtpEmision.Value = New Date(2022, 4, 14, 0, 0, 0, 0)
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txtBuscar)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnLimpiar)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.dtpHasta)
        Me.GroupBox2.Controls.Add(Me.dtpDesde)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(764, 60)
        Me.GroupBox2.TabIndex = 413
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtrar Cheques"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnIntervalo)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtLastCheque)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtSerieCheque)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtFirstCheque)
        Me.GroupBox3.Controls.Add(Me.btnSelection)
        Me.GroupBox3.Controls.Add(Me.lblSeleccionados)
        Me.GroupBox3.Location = New System.Drawing.Point(19, 326)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(412, 96)
        Me.GroupBox3.TabIndex = 414
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Selección"
        '
        'btnIntervalo
        '
        Me.btnIntervalo.Enabled = False
        Me.btnIntervalo.Location = New System.Drawing.Point(267, 61)
        Me.btnIntervalo.Name = "btnIntervalo"
        Me.btnIntervalo.Size = New System.Drawing.Size(126, 23)
        Me.btnIntervalo.TabIndex = 404
        Me.btnIntervalo.Text = "Seleccionar intervalo"
        Me.btnIntervalo.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(170, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 403
        Me.Label7.Text = "Hasta:"
        '
        'txtLastCheque
        '
        Me.txtLastCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastCheque.Location = New System.Drawing.Point(174, 63)
        Me.txtLastCheque.MaxLength = 8
        Me.txtLastCheque.Name = "txtLastCheque"
        Me.txtLastCheque.Size = New System.Drawing.Size(85, 20)
        Me.txtLastCheque.TabIndex = 402
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 401
        Me.Label8.Text = "Serie:"
        '
        'txtSerieCheque
        '
        Me.txtSerieCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerieCheque.Location = New System.Drawing.Point(30, 63)
        Me.txtSerieCheque.MaxLength = 1
        Me.txtSerieCheque.Name = "txtSerieCheque"
        Me.txtSerieCheque.Size = New System.Drawing.Size(29, 20)
        Me.txtSerieCheque.TabIndex = 397
        Me.txtSerieCheque.Text = "R"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(73, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 400
        Me.Label1.Text = "Desde:"
        '
        'txtFirstCheque
        '
        Me.txtFirstCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFirstCheque.Location = New System.Drawing.Point(76, 63)
        Me.txtFirstCheque.MaxLength = 8
        Me.txtFirstCheque.Name = "txtFirstCheque"
        Me.txtFirstCheque.Size = New System.Drawing.Size(85, 20)
        Me.txtFirstCheque.TabIndex = 398
        '
        'frmCheques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 428)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.grdCheques)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtID)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(720, 350)
        Me.Name = "frmCheques"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cheques"
        CType(Me.grdCheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grdCheques As DataGridView
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblSeleccionados As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents btnSelection As Button
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpDesde As DateTimePicker
    Friend WithEvents dtpHasta As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtpPago As DateTimePicker
    Friend WithEvents dtpEmision As DateTimePicker
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtLastCheque As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSerieCheque As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFirstCheque As TextBox
    Friend WithEvents btnIntervalo As Button
End Class
