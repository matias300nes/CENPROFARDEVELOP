<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGrupos
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
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.btnAgregarOS = New DevComponents.DotNetBar.ButtonX()
        Me.btnAgregarGrupo = New DevComponents.DotNetBar.ButtonX()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkEliminados = New System.Windows.Forms.CheckBox()
        Me.txtID = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbMandataria = New System.Windows.Forms.ComboBox()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.grdGrupos_Os = New System.Windows.Forms.DataGridView()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.grdGrupos_Os, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.btnAgregarOS)
        Me.GroupPanel1.Controls.Add(Me.btnAgregarGrupo)
        Me.GroupPanel1.Controls.Add(Me.Label14)
        Me.GroupPanel1.Controls.Add(Me.Label13)
        Me.GroupPanel1.Controls.Add(Me.chkEliminados)
        Me.GroupPanel1.Controls.Add(Me.txtID)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.cmbMandataria)
        Me.GroupPanel1.Controls.Add(Me.cmbGrupo)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 22)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(645, 125)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 259
        '
        'btnAgregarOS
        '
        Me.btnAgregarOS.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregarOS.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregarOS.Location = New System.Drawing.Point(539, 88)
        Me.btnAgregarOS.Name = "btnAgregarOS"
        Me.btnAgregarOS.Size = New System.Drawing.Size(97, 28)
        Me.btnAgregarOS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregarOS.TabIndex = 276
        Me.btnAgregarOS.Text = "Agregar OS"
        '
        'btnAgregarGrupo
        '
        Me.btnAgregarGrupo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregarGrupo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregarGrupo.Location = New System.Drawing.Point(405, 36)
        Me.btnAgregarGrupo.Name = "btnAgregarGrupo"
        Me.btnAgregarGrupo.Size = New System.Drawing.Size(75, 27)
        Me.btnAgregarGrupo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregarGrupo.TabIndex = 275
        Me.btnAgregarGrupo.Text = "+ Grupo"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(4, 19)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 17)
        Me.Label14.TabIndex = 274
        Me.Label14.Text = "Mandataria"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(192, 19)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 17)
        Me.Label13.TabIndex = 273
        Me.Label13.Text = "Grupo"
        '
        'chkEliminados
        '
        Me.chkEliminados.AutoSize = True
        Me.chkEliminados.BackColor = System.Drawing.Color.Transparent
        Me.chkEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEliminados.ForeColor = System.Drawing.Color.Red
        Me.chkEliminados.Location = New System.Drawing.Point(487, 40)
        Me.chkEliminados.Margin = New System.Windows.Forms.Padding(4)
        Me.chkEliminados.Name = "chkEliminados"
        Me.chkEliminados.Size = New System.Drawing.Size(138, 21)
        Me.chkEliminados.TabIndex = 257
        Me.chkEliminados.Text = "Ver Eliminados"
        Me.chkEliminados.UseVisualStyleBackColor = False
        '
        'txtID
        '
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.Decimals = CType(2, Byte)
        Me.txtID.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtID.Enabled = False
        Me.txtID.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtID.Location = New System.Drawing.Point(148, 14)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtID.MaxLength = 8
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(20, 22)
        Me.txtID.TabIndex = 50
        Me.txtID.Text_1 = Nothing
        Me.txtID.Text_2 = Nothing
        Me.txtID.Text_3 = Nothing
        Me.txtID.Text_4 = Nothing
        Me.txtID.UserValues = Nothing
        Me.txtID.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(149, -3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 17)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Id"
        Me.Label1.Visible = False
        '
        'cmbMandataria
        '
        Me.cmbMandataria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMandataria.FormattingEnabled = True
        Me.cmbMandataria.Location = New System.Drawing.Point(7, 40)
        Me.cmbMandataria.Name = "cmbMandataria"
        Me.cmbMandataria.Size = New System.Drawing.Size(179, 24)
        Me.cmbMandataria.TabIndex = 3
        '
        'cmbGrupo
        '
        Me.cmbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Location = New System.Drawing.Point(192, 40)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(204, 24)
        Me.cmbGrupo.TabIndex = 4
        '
        'grdGrupos_Os
        '
        Me.grdGrupos_Os.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdGrupos_Os.Location = New System.Drawing.Point(12, 164)
        Me.grdGrupos_Os.Name = "grdGrupos_Os"
        Me.grdGrupos_Os.RowHeadersWidth = 51
        Me.grdGrupos_Os.RowTemplate.Height = 24
        Me.grdGrupos_Os.Size = New System.Drawing.Size(645, 346)
        Me.grdGrupos_Os.TabIndex = 260
        '
        'frmGrupos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 522)
        Me.Controls.Add(Me.grdGrupos_Os)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Name = "frmGrupos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grupos"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.grdGrupos_Os, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnAgregarOS As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAgregarGrupo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents chkEliminados As CheckBox
    Friend WithEvents txtID As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbMandataria As ComboBox
    Friend WithEvents cmbGrupo As ComboBox
    Friend WithEvents grdGrupos_Os As DataGridView
End Class
