<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSaldos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSaldos))
        Me.grdFarmacia = New System.Windows.Forms.DataGridView()
        Me.grdHistorial = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPago = New DevComponents.DotNetBar.ButtonX()
        Me.btnAplicarConceptos = New DevComponents.DotNetBar.ButtonX()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSeleccionados = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.btnSelection = New System.Windows.Forms.Button()
        CType(Me.grdFarmacia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdFarmacia
        '
        Me.grdFarmacia.AllowUserToAddRows = False
        Me.grdFarmacia.AllowUserToDeleteRows = False
        Me.grdFarmacia.AllowUserToResizeRows = False
        Me.grdFarmacia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdFarmacia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdFarmacia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFarmacia.Location = New System.Drawing.Point(17, 45)
        Me.grdFarmacia.Name = "grdFarmacia"
        Me.grdFarmacia.RowHeadersVisible = False
        Me.grdFarmacia.RowHeadersWidth = 51
        Me.grdFarmacia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFarmacia.Size = New System.Drawing.Size(798, 210)
        Me.grdFarmacia.TabIndex = 0
        '
        'grdHistorial
        '
        Me.grdHistorial.AllowUserToAddRows = False
        Me.grdHistorial.AllowUserToDeleteRows = False
        Me.grdHistorial.AllowUserToResizeRows = False
        Me.grdHistorial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdHistorial.Location = New System.Drawing.Point(17, 311)
        Me.grdHistorial.MultiSelect = False
        Me.grdHistorial.Name = "grdHistorial"
        Me.grdHistorial.ReadOnly = True
        Me.grdHistorial.RowHeadersVisible = False
        Me.grdHistorial.RowHeadersWidth = 51
        Me.grdHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdHistorial.Size = New System.Drawing.Size(798, 210)
        Me.grdHistorial.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Farmacias"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 286)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Historial Cta. Corriente"
        '
        'btnPago
        '
        Me.btnPago.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPago.BackColor = System.Drawing.SystemColors.Control
        Me.btnPago.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPago.Location = New System.Drawing.Point(557, 270)
        Me.btnPago.Name = "btnPago"
        Me.btnPago.Size = New System.Drawing.Size(133, 25)
        Me.btnPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPago.TabIndex = 6
        Me.btnPago.Text = "Cheques/Transferencia"
        Me.btnPago.TextColor = System.Drawing.SystemColors.InfoText
        '
        'btnAplicarConceptos
        '
        Me.btnAplicarConceptos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAplicarConceptos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAplicarConceptos.BackColor = System.Drawing.SystemColors.Control
        Me.btnAplicarConceptos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAplicarConceptos.Location = New System.Drawing.Point(706, 270)
        Me.btnAplicarConceptos.Name = "btnAplicarConceptos"
        Me.btnAplicarConceptos.Size = New System.Drawing.Size(107, 25)
        Me.btnAplicarConceptos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAplicarConceptos.TabIndex = 7
        Me.btnAplicarConceptos.Text = "Aplicar conceptos"
        Me.btnAplicarConceptos.TextColor = System.Drawing.SystemColors.InfoText
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(188, 12)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(219, 20)
        Me.txtBuscar.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(139, 15)
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
        Me.lblSeleccionados.Location = New System.Drawing.Point(151, 260)
        Me.lblSeleccionados.Name = "lblSeleccionados"
        Me.lblSeleccionados.Size = New System.Drawing.Size(86, 13)
        Me.lblSeleccionados.TabIndex = 391
        Me.lblSeleccionados.Text = "0 Seleccionados"
        Me.lblSeleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(76, 12)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(57, 20)
        Me.txtID.TabIndex = 392
        '
        'btnSelection
        '
        Me.btnSelection.Location = New System.Drawing.Point(16, 255)
        Me.btnSelection.Name = "btnSelection"
        Me.btnSelection.Size = New System.Drawing.Size(128, 23)
        Me.btnSelection.TabIndex = 396
        Me.btnSelection.Text = "Seleccionar todo"
        Me.btnSelection.UseVisualStyleBackColor = True
        '
        'frmSaldos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 544)
        Me.Controls.Add(Me.btnSelection)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.lblSeleccionados)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.btnAplicarConceptos)
        Me.Controls.Add(Me.btnPago)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdHistorial)
        Me.Controls.Add(Me.grdFarmacia)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(750, 45)
        Me.Name = "frmSaldos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saldos"
        CType(Me.grdFarmacia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grdFarmacia As DataGridView
    Friend WithEvents grdHistorial As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnPago As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAplicarConceptos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblSeleccionados As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents btnSelection As Button
End Class
