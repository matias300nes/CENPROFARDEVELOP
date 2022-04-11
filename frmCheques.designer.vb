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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSeleccionados = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.btnSelection = New System.Windows.Forms.Button()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.grdCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdCheques
        '
        Me.grdCheques.AllowUserToAddRows = False
        Me.grdCheques.AllowUserToDeleteRows = False
        Me.grdCheques.AllowUserToResizeRows = False
        Me.grdCheques.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdCheques.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCheques.Location = New System.Drawing.Point(23, 83)
        Me.grdCheques.Margin = New System.Windows.Forms.Padding(4)
        Me.grdCheques.Name = "grdCheques"
        Me.grdCheques.RowHeadersVisible = False
        Me.grdCheques.RowHeadersWidth = 51
        Me.grdCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdCheques.Size = New System.Drawing.Size(1064, 258)
        Me.grdCheques.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Farmacias"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(387, 39)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(291, 22)
        Me.txtBuscar.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(384, 18)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Buscar:"
        '
        'lblSeleccionados
        '
        Me.lblSeleccionados.AutoSize = True
        Me.lblSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccionados.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSeleccionados.Location = New System.Drawing.Point(201, 348)
        Me.lblSeleccionados.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSeleccionados.Name = "lblSeleccionados"
        Me.lblSeleccionados.Size = New System.Drawing.Size(112, 17)
        Me.lblSeleccionados.TabIndex = 391
        Me.lblSeleccionados.Text = "0 Seleccionados"
        Me.lblSeleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(26, 39)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(75, 22)
        Me.txtID.TabIndex = 392
        '
        'btnSelection
        '
        Me.btnSelection.Location = New System.Drawing.Point(21, 342)
        Me.btnSelection.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSelection.Name = "btnSelection"
        Me.btnSelection.Size = New System.Drawing.Size(171, 28)
        Me.btnSelection.TabIndex = 396
        Me.btnSelection.Text = "Seleccionar todo"
        Me.btnSelection.UseVisualStyleBackColor = True
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX1.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(956, 30)
        Me.ButtonX1.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(131, 31)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 397
        Me.ButtonX1.Text = "Imprimir"
        Me.ButtonX1.TextColor = System.Drawing.SystemColors.InfoText
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(111, 16)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 17)
        Me.Label2.TabIndex = 399
        Me.Label2.Text = "Desde:"
        '
        'dtpDesde
        '
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(114, 39)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(120, 22)
        Me.dtpDesde.TabIndex = 400
        '
        'dtpHasta
        '
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(251, 39)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(120, 22)
        Me.dtpHasta.TabIndex = 402
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(248, 18)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 17)
        Me.Label4.TabIndex = 401
        Me.Label4.Text = "Hasta:"
        '
        'frmCheques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1112, 396)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpDesde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.btnSelection)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.lblSeleccionados)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdCheques)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(994, 47)
        Me.Name = "frmCheques"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cheques"
        CType(Me.grdCheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grdCheques As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblSeleccionados As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents btnSelection As Button
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpDesde As DateTimePicker
    Friend WithEvents dtpHasta As DateTimePicker
    Friend WithEvents Label4 As Label
End Class
