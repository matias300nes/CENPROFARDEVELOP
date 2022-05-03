<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSelectConcepto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectConcepto))
        Me.btnListo = New DevComponents.DotNetBar.ButtonX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdConceptos = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkProfesional = New System.Windows.Forms.CheckBox()
        Me.lblProfesional = New DevComponents.DotNetBar.LabelX()
        Me.cmbProfesionales = New System.Windows.Forms.ComboBox()
        Me.cmbFrecuencia = New System.Windows.Forms.ComboBox()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grdConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnListo
        '
        Me.btnListo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnListo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnListo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnListo.Location = New System.Drawing.Point(295, 473)
        Me.btnListo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnListo.Name = "btnListo"
        Me.btnListo.Size = New System.Drawing.Size(119, 28)
        Me.btnListo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnListo.TabIndex = 2
        Me.btnListo.Text = "Listo"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnListo, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.grdConceptos, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(709, 517)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'grdConceptos
        '
        Me.grdConceptos.AllowUserToAddRows = False
        Me.grdConceptos.AllowUserToDeleteRows = False
        Me.grdConceptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdConceptos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConceptos.Location = New System.Drawing.Point(4, 99)
        Me.grdConceptos.Margin = New System.Windows.Forms.Padding(4)
        Me.grdConceptos.MultiSelect = False
        Me.grdConceptos.Name = "grdConceptos"
        Me.grdConceptos.ReadOnly = True
        Me.grdConceptos.RowHeadersVisible = False
        Me.grdConceptos.RowHeadersWidth = 51
        Me.grdConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdConceptos.Size = New System.Drawing.Size(701, 355)
        Me.grdConceptos.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkProfesional)
        Me.GroupBox1.Controls.Add(Me.lblProfesional)
        Me.GroupBox1.Controls.Add(Me.cmbProfesionales)
        Me.GroupBox1.Controls.Add(Me.cmbFrecuencia)
        Me.GroupBox1.Controls.Add(Me.LabelX2)
        Me.GroupBox1.Controls.Add(Me.LabelX1)
        Me.GroupBox1.Controls.Add(Me.txtValor)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(703, 91)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'chkProfesional
        '
        Me.chkProfesional.AutoSize = True
        Me.chkProfesional.Location = New System.Drawing.Point(337, 49)
        Me.chkProfesional.Name = "chkProfesional"
        Me.chkProfesional.Size = New System.Drawing.Size(101, 21)
        Me.chkProfesional.TabIndex = 5
        Me.chkProfesional.Text = "Profesional"
        Me.chkProfesional.UseVisualStyleBackColor = True
        '
        'lblProfesional
        '
        '
        '
        '
        Me.lblProfesional.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblProfesional.Location = New System.Drawing.Point(358, 26)
        Me.lblProfesional.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lblProfesional.Name = "lblProfesional"
        Me.lblProfesional.Size = New System.Drawing.Size(93, 17)
        Me.lblProfesional.TabIndex = 7
        Me.lblProfesional.Text = "Profesional"
        '
        'cmbProfesionales
        '
        Me.cmbProfesionales.FormattingEnabled = True
        Me.cmbProfesionales.Location = New System.Drawing.Point(358, 48)
        Me.cmbProfesionales.Name = "cmbProfesionales"
        Me.cmbProfesionales.Size = New System.Drawing.Size(121, 24)
        Me.cmbProfesionales.TabIndex = 6
        '
        'cmbFrecuencia
        '
        Me.cmbFrecuencia.AccessibleName = "*Frecuencia"
        Me.cmbFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFrecuencia.FormattingEnabled = True
        Me.cmbFrecuencia.Items.AddRange(New Object() {"MENSUAL"})
        Me.cmbFrecuencia.Location = New System.Drawing.Point(169, 48)
        Me.cmbFrecuencia.Name = "cmbFrecuencia"
        Me.cmbFrecuencia.Size = New System.Drawing.Size(139, 24)
        Me.cmbFrecuencia.TabIndex = 4
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(169, 26)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(93, 17)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "*Frecuencia"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(28, 26)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 17)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "*Valor"
        '
        'txtValor
        '
        Me.txtValor.AccessibleName = "*Valor"
        Me.txtValor.Location = New System.Drawing.Point(28, 48)
        Me.txtValor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(124, 22)
        Me.txtValor.TabIndex = 0
        '
        'frmSelectConcepto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 517)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(594, 420)
        Me.Name = "frmSelectConcepto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nuevo Concepto"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.grdConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnListo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents grdConceptos As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtValor As TextBox
    Friend WithEvents cmbFrecuencia As ComboBox
    Friend WithEvents chkProfesional As CheckBox
    Friend WithEvents lblProfesional As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbProfesionales As ComboBox
End Class
