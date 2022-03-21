<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddConceptosLiq
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
        Me.btnSelection = New System.Windows.Forms.Button()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.lblSeleccionados = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.btnAplicarConceptos = New DevComponents.DotNetBar.ButtonX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdFarmacias = New System.Windows.Forms.DataGridView()
        Me.grdConceptos = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnGenerar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.grdFarmacias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSelection
        '
        Me.btnSelection.Location = New System.Drawing.Point(12, 181)
        Me.btnSelection.Name = "btnSelection"
        Me.btnSelection.Size = New System.Drawing.Size(128, 23)
        Me.btnSelection.TabIndex = 407
        Me.btnSelection.Text = "Seleccionar todo"
        Me.btnSelection.UseVisualStyleBackColor = True
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(82, 13)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(46, 20)
        Me.txtID.TabIndex = 406
        '
        'lblSeleccionados
        '
        Me.lblSeleccionados.AutoSize = True
        Me.lblSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccionados.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSeleccionados.Location = New System.Drawing.Point(147, 186)
        Me.lblSeleccionados.Name = "lblSeleccionados"
        Me.lblSeleccionados.Size = New System.Drawing.Size(86, 13)
        Me.lblSeleccionados.TabIndex = 405
        Me.lblSeleccionados.Text = "0 Seleccionados"
        Me.lblSeleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(137, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 404
        Me.Label3.Text = "Buscar:"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(183, 11)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(167, 20)
        Me.txtBuscar.TabIndex = 403
        '
        'btnAplicarConceptos
        '
        Me.btnAplicarConceptos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAplicarConceptos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAplicarConceptos.BackColor = System.Drawing.SystemColors.Control
        Me.btnAplicarConceptos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAplicarConceptos.Location = New System.Drawing.Point(424, 194)
        Me.btnAplicarConceptos.Name = "btnAplicarConceptos"
        Me.btnAplicarConceptos.Size = New System.Drawing.Size(86, 25)
        Me.btnAplicarConceptos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAplicarConceptos.TabIndex = 402
        Me.btnAplicarConceptos.Text = "Aplicar"
        Me.btnAplicarConceptos.TextColor = System.Drawing.SystemColors.InfoText
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 210)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 16)
        Me.Label2.TabIndex = 400
        Me.Label2.Text = "Farmacias y conceptos:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 399
        Me.Label1.Text = "Concepto:"
        '
        'grdFarmacias
        '
        Me.grdFarmacias.AllowUserToAddRows = False
        Me.grdFarmacias.AllowUserToDeleteRows = False
        Me.grdFarmacias.AllowUserToResizeRows = False
        Me.grdFarmacias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdFarmacias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdFarmacias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFarmacias.Location = New System.Drawing.Point(12, 235)
        Me.grdFarmacias.MultiSelect = False
        Me.grdFarmacias.Name = "grdFarmacias"
        Me.grdFarmacias.ReadOnly = True
        Me.grdFarmacias.RowHeadersVisible = False
        Me.grdFarmacias.RowHeadersWidth = 51
        Me.grdFarmacias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFarmacias.Size = New System.Drawing.Size(500, 210)
        Me.grdFarmacias.TabIndex = 398
        '
        'grdConceptos
        '
        Me.grdConceptos.AllowUserToAddRows = False
        Me.grdConceptos.AllowUserToDeleteRows = False
        Me.grdConceptos.AllowUserToResizeRows = False
        Me.grdConceptos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdConceptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdConceptos.Location = New System.Drawing.Point(12, 40)
        Me.grdConceptos.Name = "grdConceptos"
        Me.grdConceptos.RowHeadersVisible = False
        Me.grdConceptos.RowHeadersWidth = 51
        Me.grdConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdConceptos.Size = New System.Drawing.Size(500, 135)
        Me.grdConceptos.TabIndex = 397
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnGenerar, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(11, 450)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(502, 44)
        Me.TableLayoutPanel1.TabIndex = 409
        '
        'btnGenerar
        '
        Me.btnGenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnGenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerar.Location = New System.Drawing.Point(184, 10)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(133, 27)
        Me.btnGenerar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGenerar.TabIndex = 2
        Me.btnGenerar.Text = "Generar conceptos"
        Me.btnGenerar.TextColor = System.Drawing.SystemColors.WindowText
        '
        'frmAddConceptosLiq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 496)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btnSelection)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.lblSeleccionados)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.btnAplicarConceptos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdFarmacias)
        Me.Controls.Add(Me.grdConceptos)
        Me.MinimumSize = New System.Drawing.Size(450, 450)
        Me.Name = "frmAddConceptosLiq"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Añadir conceptos"
        CType(Me.grdFarmacias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSelection As Button
    Friend WithEvents txtID As TextBox
    Friend WithEvents lblSeleccionados As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents btnAplicarConceptos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents grdFarmacias As DataGridView
    Friend WithEvents grdConceptos As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnGenerar As DevComponents.DotNetBar.ButtonX
End Class
