<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAgregarPagos_Copia
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
        Me.cmbRazonSocial = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtImporte = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.btnAgregar = New DevComponents.DotNetBar.ButtonX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbTipoPago = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(629, 359)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.grdPagos, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pControls, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 73)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(623, 235)
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
        Me.grdPagos.Location = New System.Drawing.Point(185, 3)
        Me.grdPagos.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.grdPagos.MultiSelect = False
        Me.grdPagos.Name = "grdPagos"
        Me.grdPagos.ReadOnly = True
        Me.grdPagos.RowHeadersVisible = False
        Me.grdPagos.RowHeadersWidth = 51
        Me.grdPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdPagos.Size = New System.Drawing.Size(428, 229)
        Me.grdPagos.TabIndex = 5
        '
        'pControls
        '
        Me.pControls.Controls.Add(Me.lblSaldoIndividual)
        Me.pControls.Controls.Add(Me.label4)
        Me.pControls.Controls.Add(Me.cmbRazonSocial)
        Me.pControls.Controls.Add(Me.Label3)
        Me.pControls.Controls.Add(Me.txtImporte)
        Me.pControls.Controls.Add(Me.btnAgregar)
        Me.pControls.Controls.Add(Me.Label7)
        Me.pControls.Controls.Add(Me.cmbTipoPago)
        Me.pControls.Controls.Add(Me.Label6)
        Me.pControls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pControls.Location = New System.Drawing.Point(3, 3)
        Me.pControls.Name = "pControls"
        Me.pControls.Size = New System.Drawing.Size(176, 229)
        Me.pControls.TabIndex = 1
        '
        'lblSaldoIndividual
        '
        Me.lblSaldoIndividual.AutoSize = True
        Me.lblSaldoIndividual.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblSaldoIndividual.Location = New System.Drawing.Point(55, 55)
        Me.lblSaldoIndividual.Name = "lblSaldoIndividual"
        Me.lblSaldoIndividual.Size = New System.Drawing.Size(38, 13)
        Me.lblSaldoIndividual.TabIndex = 14
        Me.lblSaldoIndividual.Text = "[saldo]"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.label4.Location = New System.Drawing.Point(19, 55)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(37, 13)
        Me.label4.TabIndex = 13
        Me.label4.Text = "Saldo:"
        '
        'cmbRazonSocial
        '
        Me.cmbRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRazonSocial.DisplayMember = "Text"
        Me.cmbRazonSocial.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbRazonSocial.FormattingEnabled = True
        Me.cmbRazonSocial.ItemHeight = 14
        Me.cmbRazonSocial.Location = New System.Drawing.Point(19, 32)
        Me.cmbRazonSocial.Name = "cmbRazonSocial"
        Me.cmbRazonSocial.Size = New System.Drawing.Size(135, 20)
        Me.cmbRazonSocial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbRazonSocial.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Razón social"
        '
        'txtImporte
        '
        Me.txtImporte.AccessibleName = ""
        Me.txtImporte.Decimals = CType(2, Byte)
        Me.txtImporte.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporte.Format = TextBoxConFormatoVB.tbFormats.UnsignedFloatingPointNumber
        Me.txtImporte.Location = New System.Drawing.Point(19, 150)
        Me.txtImporte.MaxLength = 15
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(135, 20)
        Me.txtImporte.TabIndex = 2
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
        Me.btnAgregar.Location = New System.Drawing.Point(51, 193)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(68, 20)
        Me.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregar.TabIndex = 3
        Me.btnAgregar.Text = "Agregar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 134)
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
        Me.cmbTipoPago.Location = New System.Drawing.Point(19, 95)
        Me.cmbTipoPago.Name = "cmbTipoPago"
        Me.cmbTipoPago.Size = New System.Drawing.Size(135, 20)
        Me.cmbTipoPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoPago.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Tipo de pago"
        '
        'GroupBox1
        '
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
        Me.GroupBox1.Size = New System.Drawing.Size(625, 66)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
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
        Me.lblSaldoCubierto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSaldoCubierto.AutoSize = True
        Me.lblSaldoCubierto.CausesValidation = False
        Me.lblSaldoCubierto.Location = New System.Drawing.Point(438, 40)
        Me.lblSaldoCubierto.Name = "lblSaldoCubierto"
        Me.lblSaldoCubierto.Size = New System.Drawing.Size(22, 13)
        Me.lblSaldoCubierto.TabIndex = 4
        Me.lblSaldoCubierto.Text = "$ 0"
        Me.lblSaldoCubierto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSaldoActual
        '
        Me.lblSaldoActual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSaldoActual.AutoSize = True
        Me.lblSaldoActual.Location = New System.Drawing.Point(423, 19)
        Me.lblSaldoActual.Name = "lblSaldoActual"
        Me.lblSaldoActual.Size = New System.Drawing.Size(22, 13)
        Me.lblSaldoActual.TabIndex = 3
        Me.lblSaldoActual.Text = "$ 0"
        Me.lblSaldoActual.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(359, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Saldo cubierto:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(359, 18)
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
        Me.btnListo.Location = New System.Drawing.Point(270, 323)
        Me.btnListo.Name = "btnListo"
        Me.btnListo.Size = New System.Drawing.Size(89, 23)
        Me.btnListo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnListo.TabIndex = 4
        Me.btnListo.Text = "Generar"
        '
        'frmAgregarCheques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 359)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmAgregarCheques"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Personalizar pago"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.grdPagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pControls.ResumeLayout(False)
        Me.pControls.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents cmbRazonSocial As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label3 As Label
    Friend WithEvents lblSaldoIndividual As Label
    Friend WithEvents label4 As Label
End Class
