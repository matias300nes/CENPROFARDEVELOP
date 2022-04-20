<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAgregarPagos
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdPagos = New System.Windows.Forms.DataGridView()
        Me.pControls = New System.Windows.Forms.Panel()
        Me.lblSaldoIndividual = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.cmbFarmacia = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtImporte = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.btnAgregar = New DevComponents.DotNetBar.ButtonX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbTipoPago = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSerieCheque = New System.Windows.Forms.TextBox()
        Me.btnAplicar = New DevComponents.DotNetBar.ButtonX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNroCheque = New System.Windows.Forms.TextBox()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.lblSaldoCubierto = New System.Windows.Forms.Label()
        Me.lblSaldoActual = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnListo = New DevComponents.DotNetBar.ButtonX()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.grdPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pControls.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnListo, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(734, 390)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.grdPagos, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pControls, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 103)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(728, 236)
        Me.TableLayoutPanel2.TabIndex = 10
        '
        'grdPagos
        '
        Me.grdPagos.AllowUserToAddRows = False
        Me.grdPagos.AllowUserToDeleteRows = False
        Me.grdPagos.AllowUserToResizeRows = False
        Me.grdPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPagos.Location = New System.Drawing.Point(169, 3)
        Me.grdPagos.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.grdPagos.MultiSelect = False
        Me.grdPagos.Name = "grdPagos"
        Me.grdPagos.ReadOnly = True
        Me.grdPagos.RowHeadersVisible = False
        Me.grdPagos.RowHeadersWidth = 51
        Me.grdPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdPagos.Size = New System.Drawing.Size(549, 230)
        Me.grdPagos.TabIndex = 8
        '
        'pControls
        '
        Me.pControls.Controls.Add(Me.lblSaldoIndividual)
        Me.pControls.Controls.Add(Me.label4)
        Me.pControls.Controls.Add(Me.cmbFarmacia)
        Me.pControls.Controls.Add(Me.Label3)
        Me.pControls.Controls.Add(Me.txtImporte)
        Me.pControls.Controls.Add(Me.btnAgregar)
        Me.pControls.Controls.Add(Me.Label7)
        Me.pControls.Controls.Add(Me.cmbTipoPago)
        Me.pControls.Controls.Add(Me.Label6)
        Me.pControls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pControls.Location = New System.Drawing.Point(3, 3)
        Me.pControls.Name = "pControls"
        Me.pControls.Size = New System.Drawing.Size(160, 230)
        Me.pControls.TabIndex = 1
        '
        'lblSaldoIndividual
        '
        Me.lblSaldoIndividual.AutoSize = True
        Me.lblSaldoIndividual.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblSaldoIndividual.Location = New System.Drawing.Point(51, 55)
        Me.lblSaldoIndividual.Name = "lblSaldoIndividual"
        Me.lblSaldoIndividual.Size = New System.Drawing.Size(38, 13)
        Me.lblSaldoIndividual.TabIndex = 14
        Me.lblSaldoIndividual.Text = "[saldo]"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.label4.Location = New System.Drawing.Point(13, 55)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(37, 13)
        Me.label4.TabIndex = 13
        Me.label4.Text = "Saldo:"
        '
        'cmbFarmacia
        '
        Me.cmbFarmacia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFarmacia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFarmacia.DisplayMember = "Text"
        Me.cmbFarmacia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbFarmacia.FormattingEnabled = True
        Me.cmbFarmacia.ItemHeight = 14
        Me.cmbFarmacia.Location = New System.Drawing.Point(13, 33)
        Me.cmbFarmacia.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbFarmacia.Name = "cmbFarmacia"
        Me.cmbFarmacia.Size = New System.Drawing.Size(135, 20)
        Me.cmbFarmacia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbFarmacia.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Farmacia"
        '
        'txtImporte
        '
        Me.txtImporte.AccessibleName = ""
        Me.txtImporte.Decimals = CType(2, Byte)
        Me.txtImporte.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporte.Format = TextBoxConFormatoVB.tbFormats.UnsignedFloatingPointNumber
        Me.txtImporte.Location = New System.Drawing.Point(13, 150)
        Me.txtImporte.MaxLength = 15
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(135, 20)
        Me.txtImporte.TabIndex = 5
        Me.txtImporte.Text_1 = Nothing
        Me.txtImporte.Text_2 = Nothing
        Me.txtImporte.Text_3 = Nothing
        Me.txtImporte.Text_4 = Nothing
        Me.txtImporte.UserValues = Nothing
        '
        'btnAgregar
        '
        Me.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregar.Location = New System.Drawing.Point(46, 193)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(68, 20)
        Me.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregar.TabIndex = 6
        Me.btnAgregar.Text = "Agregar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 134)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Importe"
        '
        'cmbTipoPago
        '
        Me.cmbTipoPago.DisplayMember = "Text"
        Me.cmbTipoPago.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPago.FormattingEnabled = True
        Me.cmbTipoPago.ItemHeight = 14
        Me.cmbTipoPago.Location = New System.Drawing.Point(13, 95)
        Me.cmbTipoPago.Name = "cmbTipoPago"
        Me.cmbTipoPago.Size = New System.Drawing.Size(135, 20)
        Me.cmbTipoPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoPago.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Tipo de pago"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.lblRazonSocial)
        Me.GroupBox1.Controls.Add(Me.lblSaldoCubierto)
        Me.GroupBox1.Controls.Add(Me.lblSaldoActual)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(730, 96)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtSerieCheque)
        Me.GroupBox2.Controls.Add(Me.btnAplicar)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtNroCheque)
        Me.GroupBox2.Location = New System.Drawing.Point(474, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(241, 75)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Configurar 1er Cheque"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Serie"
        '
        'txtSerieCheque
        '
        Me.txtSerieCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerieCheque.Location = New System.Drawing.Point(23, 40)
        Me.txtSerieCheque.MaxLength = 1
        Me.txtSerieCheque.Name = "txtSerieCheque"
        Me.txtSerieCheque.Size = New System.Drawing.Size(29, 20)
        Me.txtSerieCheque.TabIndex = 0
        Me.txtSerieCheque.Text = "R"
        '
        'btnAplicar
        '
        Me.btnAplicar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAplicar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAplicar.Location = New System.Drawing.Point(154, 40)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(68, 20)
        Me.btnAplicar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAplicar.TabIndex = 2
        Me.btnAplicar.Text = "Aplicar"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(63, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Numero"
        '
        'txtNroCheque
        '
        Me.txtNroCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNroCheque.Location = New System.Drawing.Point(60, 40)
        Me.txtNroCheque.MaxLength = 8
        Me.txtNroCheque.Name = "txtNroCheque"
        Me.txtNroCheque.Size = New System.Drawing.Size(88, 20)
        Me.txtNroCheque.TabIndex = 1
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazonSocial.Location = New System.Drawing.Point(10, 16)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(86, 16)
        Me.lblRazonSocial.TabIndex = 6
        Me.lblRazonSocial.Text = "Razon social"
        '
        'lblSaldoCubierto
        '
        Me.lblSaldoCubierto.AutoSize = True
        Me.lblSaldoCubierto.CausesValidation = False
        Me.lblSaldoCubierto.Location = New System.Drawing.Point(100, 66)
        Me.lblSaldoCubierto.Name = "lblSaldoCubierto"
        Me.lblSaldoCubierto.Size = New System.Drawing.Size(22, 13)
        Me.lblSaldoCubierto.TabIndex = 4
        Me.lblSaldoCubierto.Text = "$ 0"
        Me.lblSaldoCubierto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSaldoActual
        '
        Me.lblSaldoActual.AutoSize = True
        Me.lblSaldoActual.Location = New System.Drawing.Point(84, 45)
        Me.lblSaldoActual.Name = "lblSaldoActual"
        Me.lblSaldoActual.Size = New System.Drawing.Size(22, 13)
        Me.lblSaldoActual.TabIndex = 3
        Me.lblSaldoActual.Text = "$ 0"
        Me.lblSaldoActual.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Saldo cubierto:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Saldo total:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnListo
        '
        Me.btnListo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnListo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnListo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnListo.Location = New System.Drawing.Point(322, 354)
        Me.btnListo.Name = "btnListo"
        Me.btnListo.Size = New System.Drawing.Size(89, 23)
        Me.btnListo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnListo.TabIndex = 7
        Me.btnListo.Text = "Generar"
        '
        'frmAgregarPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 390)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmAgregarPagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Personalizar pago"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.grdPagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pControls.ResumeLayout(False)
        Me.pControls.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents grdPagos As DataGridView
    Friend WithEvents btnListo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label7 As Label
    Friend WithEvents btnAgregar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label6 As Label
    Friend WithEvents lblRazonSocial As Label
    Friend WithEvents lblSaldoCubierto As Label
    Friend WithEvents lblSaldoActual As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbTipoPago As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pControls As Panel
    Friend WithEvents txtImporte As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents cmbFarmacia As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label3 As Label
    Friend WithEvents lblSaldoIndividual As Label
    Friend WithEvents label4 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnAplicar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNroCheque As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSerieCheque As TextBox
End Class
