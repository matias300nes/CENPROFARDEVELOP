<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectPresentacion
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
        Me.grdPresentaciones = New System.Windows.Forms.DataGridView()
        Me.btnListo = New DevComponents.DotNetBar.ButtonX()
        Me.chkAgrupar = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
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
        Me.grdPresentaciones.RowHeadersWidth = 51
        Me.grdPresentaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdPresentaciones.Size = New System.Drawing.Size(692, 358)
        Me.grdPresentaciones.TabIndex = 0
        '
        'btnListo
        '
        Me.btnListo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnListo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnListo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnListo.Location = New System.Drawing.Point(290, 473)
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
        Me.chkAgrupar.Location = New System.Drawing.Point(206, 45)
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
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(700, 517)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbEstado)
        Me.GroupBox1.Controls.Add(Me.chkAgrupar)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(694, 86)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 23)
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
        Me.cmbEstado.Location = New System.Drawing.Point(23, 45)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(165, 22)
        Me.cmbEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbEstado.TabIndex = 4
        '
        'frmSelectPresentacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 517)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmSelectPresentacion"
        Me.Text = "frmNuevaLiquidacion"
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
End Class
