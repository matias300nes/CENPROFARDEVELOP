<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNuevoGrupo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevoGrupo))
        Me.btnListo = New DevComponents.DotNetBar.ButtonX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdGruposMandataria = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbMandataria = New System.Windows.Forms.ComboBox()
        Me.txtGrupo = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.btnEliminar = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbTipoGrupo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grdGruposMandataria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnListo
        '
        Me.btnListo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnListo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnListo.Location = New System.Drawing.Point(33, 91)
        Me.btnListo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnListo.Name = "btnListo"
        Me.btnListo.Size = New System.Drawing.Size(140, 28)
        Me.btnListo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnListo.TabIndex = 2
        Me.btnListo.Text = "Añadir"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grdGruposMandataria, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 148.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(619, 446)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'grdGruposMandataria
        '
        Me.grdGruposMandataria.AllowUserToAddRows = False
        Me.grdGruposMandataria.AllowUserToDeleteRows = False
        Me.grdGruposMandataria.AllowUserToResizeColumns = False
        Me.grdGruposMandataria.AllowUserToResizeRows = False
        Me.grdGruposMandataria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdGruposMandataria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdGruposMandataria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdGruposMandataria.Location = New System.Drawing.Point(4, 152)
        Me.grdGruposMandataria.Margin = New System.Windows.Forms.Padding(4)
        Me.grdGruposMandataria.MultiSelect = False
        Me.grdGruposMandataria.Name = "grdGruposMandataria"
        Me.grdGruposMandataria.ReadOnly = True
        Me.grdGruposMandataria.RowHeadersVisible = False
        Me.grdGruposMandataria.RowHeadersWidth = 51
        Me.grdGruposMandataria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdGruposMandataria.Size = New System.Drawing.Size(611, 253)
        Me.grdGruposMandataria.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbTipoGrupo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbMandataria)
        Me.GroupBox1.Controls.Add(Me.txtGrupo)
        Me.GroupBox1.Controls.Add(Me.btnListo)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(613, 144)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'cmbMandataria
        '
        Me.cmbMandataria.AccessibleName = "*Mandataria"
        Me.cmbMandataria.Enabled = False
        Me.cmbMandataria.FormattingEnabled = True
        Me.cmbMandataria.Location = New System.Drawing.Point(33, 47)
        Me.cmbMandataria.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbMandataria.Name = "cmbMandataria"
        Me.cmbMandataria.Size = New System.Drawing.Size(201, 24)
        Me.cmbMandataria.TabIndex = 279
        '
        'txtGrupo
        '
        Me.txtGrupo.AccessibleName = "*Grupo"
        Me.txtGrupo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtGrupo.Decimals = CType(2, Byte)
        Me.txtGrupo.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtGrupo.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtGrupo.Location = New System.Drawing.Point(241, 49)
        Me.txtGrupo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGrupo.MaxLength = 11
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.Size = New System.Drawing.Size(130, 22)
        Me.txtGrupo.TabIndex = 278
        Me.txtGrupo.Text_1 = Nothing
        Me.txtGrupo.Text_2 = Nothing
        Me.txtGrupo.Text_3 = Nothing
        Me.txtGrupo.Text_4 = Nothing
        Me.txtGrupo.UserValues = Nothing
        '
        'btnEliminar
        '
        Me.btnEliminar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEliminar.Location = New System.Drawing.Point(433, 91)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(140, 28)
        Me.btnEliminar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEliminar.TabIndex = 277
        Me.btnEliminar.Text = "Eliminar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(241, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 17)
        Me.Label1.TabIndex = 276
        Me.Label1.Text = "Grupo*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(29, 25)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 17)
        Me.Label13.TabIndex = 274
        Me.Label13.Text = "Mandataria*"
        '
        'cmbTipoGrupo
        '
        Me.cmbTipoGrupo.AccessibleName = "*Tipo Grupo"
        Me.cmbTipoGrupo.FormattingEnabled = True
        Me.cmbTipoGrupo.Items.AddRange(New Object() {"1°Q", "2°Q", "MENSUAL"})
        Me.cmbTipoGrupo.Location = New System.Drawing.Point(378, 47)
        Me.cmbTipoGrupo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbTipoGrupo.Name = "cmbTipoGrupo"
        Me.cmbTipoGrupo.Size = New System.Drawing.Size(201, 24)
        Me.cmbTipoGrupo.TabIndex = 281
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(374, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 17)
        Me.Label2.TabIndex = 280
        Me.Label2.Text = "Tipo Grupo*"
        '
        'frmNuevoGrupo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 446)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximumSize = New System.Drawing.Size(661, 605)
        Me.MinimumSize = New System.Drawing.Size(394, 483)
        Me.Name = "frmNuevoGrupo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nuevo Grupo"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.grdGruposMandataria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnListo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents grdGruposMandataria As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnEliminar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtGrupo As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents cmbMandataria As ComboBox
    Friend WithEvents cmbTipoGrupo As ComboBox
    Friend WithEvents Label2 As Label
End Class
