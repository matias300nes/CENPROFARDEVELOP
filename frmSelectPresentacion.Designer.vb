<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSelectPresentacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectPresentacion))
        Me.grdPresentaciones = New System.Windows.Forms.DataGridView()
        Me.btnListo = New DevComponents.DotNetBar.ButtonX()
        Me.chkAgrupar = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbPago = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.lblCantPagos = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbEstado = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        CType(Me.grdPresentaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdPresentaciones
        '
        Me.grdPresentaciones.AllowUserToAddRows = False
        Me.grdPresentaciones.AllowUserToDeleteRows = False
        Me.grdPresentaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPresentaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPresentaciones.Location = New System.Drawing.Point(4, 96)
        Me.grdPresentaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.grdPresentaciones.MultiSelect = False
        Me.grdPresentaciones.Name = "grdPresentaciones"
        Me.grdPresentaciones.ReadOnly = True
        Me.grdPresentaciones.RowHeadersVisible = False
        Me.grdPresentaciones.RowHeadersWidth = 51
        Me.grdPresentaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdPresentaciones.Size = New System.Drawing.Size(671, 358)
        Me.grdPresentaciones.TabIndex = 0
        '
        'btnListo
        '
        Me.btnListo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnListo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnListo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnListo.Location = New System.Drawing.Point(280, 473)
        Me.btnListo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnListo.Name = "btnListo"
        Me.btnListo.Size = New System.Drawing.Size(119, 28)
        Me.btnListo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnListo.TabIndex = 2
        Me.btnListo.Text = "Listo"
        '
        'chkAgrupar
        '
        Me.chkAgrupar.AutoSize = True
        Me.chkAgrupar.Location = New System.Drawing.Point(227, 47)
        Me.chkAgrupar.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAgrupar.Name = "chkAgrupar"
        Me.chkAgrupar.Size = New System.Drawing.Size(168, 21)
        Me.chkAgrupar.TabIndex = 0
        Me.chkAgrupar.Text = "Agrupar por Farmacia"
        Me.chkAgrupar.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.grdPresentaciones, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnListo, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(679, 517)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbPago)
        Me.GroupBox1.Controls.Add(Me.lblCantPagos)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbEstado)
        Me.GroupBox1.Controls.Add(Me.chkAgrupar)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(673, 88)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'cmbPago
        '
        Me.cmbPago.DisplayMember = "Text"
        Me.cmbPago.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPago.FormattingEnabled = True
        Me.cmbPago.ItemHeight = 14
        Me.cmbPago.Location = New System.Drawing.Point(235, 15)
        Me.cmbPago.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPago.Name = "cmbPago"
        Me.cmbPago.Size = New System.Drawing.Size(188, 20)
        Me.cmbPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPago.TabIndex = 8
        Me.cmbPago.Visible = False
        '
        'lblCantPagos
        '
        Me.lblCantPagos.AutoSize = True
        Me.lblCantPagos.Location = New System.Drawing.Point(587, 49)
        Me.lblCantPagos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCantPagos.Name = "lblCantPagos"
        Me.lblCantPagos.Size = New System.Drawing.Size(16, 17)
        Me.lblCantPagos.TabIndex = 7
        Me.lblCantPagos.Text = "0"
        Me.lblCantPagos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(427, 48)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Cant. pagos anteriores:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Estado:"
        '
        'cmbEstado
        '
        Me.cmbEstado.DisplayMember = "Text"
        Me.cmbEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.ItemHeight = 16
        Me.cmbEstado.Location = New System.Drawing.Point(23, 44)
        Me.cmbEstado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(165, 22)
        Me.cmbEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbEstado.TabIndex = 4
        '
        'frmSelectPresentacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 517)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmSelectPresentacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Seleccionar presentación"
        CType(Me.grdPresentaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdPresentaciones As DataGridView
    Friend WithEvents btnListo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents chkAgrupar As CheckBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbEstado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCantPagos As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbPago As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
