<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSelectPlan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectPlan))
        Me.btnListo = New DevComponents.DotNetBar.ButtonX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdPlanes = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grdPlanes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnListo
        '
        Me.btnListo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnListo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnListo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnListo.Location = New System.Drawing.Point(295, 473)
        Me.btnListo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnListo.Name = "btnListo"
        Me.btnListo.Size = New System.Drawing.Size(119, 28)
        Me.btnListo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnListo.TabIndex = 2
        Me.btnListo.Text = "Listo"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnListo, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.grdPlanes, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(709, 517)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'grdPlanes
        '
        Me.grdPlanes.AllowUserToAddRows = False
        Me.grdPlanes.AllowUserToDeleteRows = False
        Me.grdPlanes.AllowUserToResizeColumns = False
        Me.grdPlanes.AllowUserToResizeRows = False
        Me.grdPlanes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPlanes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPlanes.Location = New System.Drawing.Point(4, 66)
        Me.grdPlanes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grdPlanes.MultiSelect = False
        Me.grdPlanes.Name = "grdPlanes"
        Me.grdPlanes.ReadOnly = True
        Me.grdPlanes.RowHeadersVisible = False
        Me.grdPlanes.RowHeadersWidth = 51
        Me.grdPlanes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdPlanes.Size = New System.Drawing.Size(701, 388)
        Me.grdPlanes.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(703, 58)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccionar Plan"
        '
        'frmSelectPlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 517)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MinimumSize = New System.Drawing.Size(594, 481)
        Me.Name = "frmSelectPlan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Carga Plan"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.grdPlanes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnListo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents grdPlanes As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
End Class
