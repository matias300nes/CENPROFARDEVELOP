<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmExcelFilter
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
        Me.grdExcel = New System.Windows.Forms.DataGridView()
        Me.btnListo = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pnlForm = New System.Windows.Forms.FlowLayoutPanel()
        Me.cboSheet = New System.Windows.Forms.ComboBox()
        CType(Me.grdExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdExcel
        '
        Me.grdExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdExcel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdExcel.Location = New System.Drawing.Point(3, 3)
        Me.grdExcel.Name = "grdExcel"
        Me.grdExcel.Size = New System.Drawing.Size(494, 444)
        Me.grdExcel.TabIndex = 0
        '
        'btnListo
        '
        Me.btnListo.Location = New System.Drawing.Point(112, 403)
        Me.btnListo.Name = "btnListo"
        Me.btnListo.Size = New System.Drawing.Size(75, 23)
        Me.btnListo.TabIndex = 1
        Me.btnListo.Text = "Listo"
        Me.btnListo.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.grdExcel, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 450)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboSheet)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.btnListo)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.pnlForm)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(503, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(294, 444)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "File"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(38, 41)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(137, 20)
        Me.TextBox1.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(178, 40)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(61, 21)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Importar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'pnlForm
        '
        Me.pnlForm.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.pnlForm.Location = New System.Drawing.Point(6, 76)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.Padding = New System.Windows.Forms.Padding(40, 40, 0, 0)
        Me.pnlForm.Size = New System.Drawing.Size(279, 305)
        Me.pnlForm.TabIndex = 2
        '
        'cboSheet
        '
        Me.cboSheet.AccessibleName = "*OrdenCompra"
        Me.cboSheet.FormattingEnabled = True
        Me.cboSheet.Location = New System.Drawing.Point(109, 13)
        Me.cboSheet.Name = "cboSheet"
        Me.cboSheet.Size = New System.Drawing.Size(130, 21)
        Me.cboSheet.TabIndex = 355
        '
        'frmExcelFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmExcelFilter"
        Me.Text = "frmExcelFilter"
        CType(Me.grdExcel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grdExcel As DataGridView
    Friend WithEvents btnListo As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents pnlForm As FlowLayoutPanel
    Friend WithEvents cboSheet As ComboBox
End Class
