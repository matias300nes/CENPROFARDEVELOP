<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPresentacionesAgregarItem
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
        Me.GbFarmaciaForm = New System.Windows.Forms.GroupBox()
        Me.btnCleanPlan = New DevComponents.DotNetBar.ButtonX()
        Me.lblNombrePorcentaje = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPorcentaje = New System.Windows.Forms.TextBox()
        Me.rdbACargoOS = New System.Windows.Forms.RadioButton()
        Me.rdbRecaudado = New System.Windows.Forms.RadioButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.cmbPlanes = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cmbFarmacias = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAgregar = New DevComponents.DotNetBar.ButtonX()
        Me.txtMensajeWeb = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtBonificacion = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtImpRecaudado = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.txtImpACargoOs = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRecetas = New TextBoxConFormatoVB.FormattedTextBoxVB()
        Me.GbFarmaciaForm.SuspendLayout()
        Me.SuspendLayout()
        '
        'GbFarmaciaForm
        '
        Me.GbFarmaciaForm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbFarmaciaForm.Controls.Add(Me.btnCleanPlan)
        Me.GbFarmaciaForm.Controls.Add(Me.lblNombrePorcentaje)
        Me.GbFarmaciaForm.Controls.Add(Me.Label1)
        Me.GbFarmaciaForm.Controls.Add(Me.txtPorcentaje)
        Me.GbFarmaciaForm.Controls.Add(Me.rdbACargoOS)
        Me.GbFarmaciaForm.Controls.Add(Me.rdbRecaudado)
        Me.GbFarmaciaForm.Controls.Add(Me.lblInfo)
        Me.GbFarmaciaForm.Controls.Add(Me.cmbPlanes)
        Me.GbFarmaciaForm.Controls.Add(Me.cmbFarmacias)
        Me.GbFarmaciaForm.Controls.Add(Me.lblTotal)
        Me.GbFarmaciaForm.Controls.Add(Me.txtObservacion)
        Me.GbFarmaciaForm.Controls.Add(Me.Label3)
        Me.GbFarmaciaForm.Controls.Add(Me.Label2)
        Me.GbFarmaciaForm.Controls.Add(Me.btnCerrar)
        Me.GbFarmaciaForm.Controls.Add(Me.btnAgregar)
        Me.GbFarmaciaForm.Controls.Add(Me.txtMensajeWeb)
        Me.GbFarmaciaForm.Controls.Add(Me.Label11)
        Me.GbFarmaciaForm.Controls.Add(Me.txtBonificacion)
        Me.GbFarmaciaForm.Controls.Add(Me.Label13)
        Me.GbFarmaciaForm.Controls.Add(Me.Label12)
        Me.GbFarmaciaForm.Controls.Add(Me.txtImpRecaudado)
        Me.GbFarmaciaForm.Controls.Add(Me.txtImpACargoOs)
        Me.GbFarmaciaForm.Controls.Add(Me.Label6)
        Me.GbFarmaciaForm.Controls.Add(Me.Label16)
        Me.GbFarmaciaForm.Controls.Add(Me.Label5)
        Me.GbFarmaciaForm.Controls.Add(Me.Label10)
        Me.GbFarmaciaForm.Controls.Add(Me.txtRecetas)
        Me.GbFarmaciaForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbFarmaciaForm.Location = New System.Drawing.Point(10, 9)
        Me.GbFarmaciaForm.Name = "GbFarmaciaForm"
        Me.GbFarmaciaForm.Size = New System.Drawing.Size(443, 451)
        Me.GbFarmaciaForm.TabIndex = 5
        Me.GbFarmaciaForm.TabStop = False
        Me.GbFarmaciaForm.Text = "Presentacion farmacia"
        '
        'btnCleanPlan
        '
        Me.btnCleanPlan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCleanPlan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCleanPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCleanPlan.Location = New System.Drawing.Point(391, 48)
        Me.btnCleanPlan.Name = "btnCleanPlan"
        Me.btnCleanPlan.Size = New System.Drawing.Size(24, 22)
        Me.btnCleanPlan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCleanPlan.TabIndex = 396
        Me.btnCleanPlan.Text = "X"
        Me.btnCleanPlan.Visible = False
        '
        'lblNombrePorcentaje
        '
        Me.lblNombrePorcentaje.AutoSize = True
        Me.lblNombrePorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombrePorcentaje.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblNombrePorcentaje.Location = New System.Drawing.Point(182, 146)
        Me.lblNombrePorcentaje.MaximumSize = New System.Drawing.Size(223, 0)
        Me.lblNombrePorcentaje.Name = "lblNombrePorcentaje"
        Me.lblNombrePorcentaje.Size = New System.Drawing.Size(44, 15)
        Me.lblNombrePorcentaje.TabIndex = 6
        Me.lblNombrePorcentaje.Text = "[PLAN]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(164, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 16)
        Me.Label1.TabIndex = 395
        Me.Label1.Text = "%"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.Location = New System.Drawing.Point(160, 166)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.ReadOnly = True
        Me.txtPorcentaje.Size = New System.Drawing.Size(43, 22)
        Me.txtPorcentaje.TabIndex = 394
        '
        'rdbACargoOS
        '
        Me.rdbACargoOS.AutoSize = True
        Me.rdbACargoOS.Checked = True
        Me.rdbACargoOS.Location = New System.Drawing.Point(315, 167)
        Me.rdbACargoOS.Name = "rdbACargoOS"
        Me.rdbACargoOS.Size = New System.Drawing.Size(97, 20)
        Me.rdbACargoOS.TabIndex = 393
        Me.rdbACargoOS.TabStop = True
        Me.rdbACargoOS.Text = "A Cargo OS"
        Me.rdbACargoOS.UseVisualStyleBackColor = True
        '
        'rdbRecaudado
        '
        Me.rdbRecaudado.AutoSize = True
        Me.rdbRecaudado.Location = New System.Drawing.Point(221, 167)
        Me.rdbRecaudado.Name = "rdbRecaudado"
        Me.rdbRecaudado.Size = New System.Drawing.Size(84, 20)
        Me.rdbRecaudado.TabIndex = 392
        Me.rdbRecaudado.Text = "Imp 100%"
        Me.rdbRecaudado.UseVisualStyleBackColor = True
        '
        'lblInfo
        '
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblInfo.Location = New System.Drawing.Point(277, 13)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(158, 15)
        Me.lblInfo.TabIndex = 391
        Me.lblInfo.Text = "INFO"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbPlanes
        '
        Me.cmbPlanes.DisplayMember = "Text"
        Me.cmbPlanes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPlanes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlanes.FormattingEnabled = True
        Me.cmbPlanes.ItemHeight = 16
        Me.cmbPlanes.Location = New System.Drawing.Point(251, 48)
        Me.cmbPlanes.Name = "cmbPlanes"
        Me.cmbPlanes.Size = New System.Drawing.Size(131, 22)
        Me.cmbPlanes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPlanes.TabIndex = 2
        '
        'cmbFarmacias
        '
        Me.cmbFarmacias.DisplayMember = "Text"
        Me.cmbFarmacias.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbFarmacias.FormattingEnabled = True
        Me.cmbFarmacias.ItemHeight = 16
        Me.cmbFarmacias.Location = New System.Drawing.Point(31, 49)
        Me.cmbFarmacias.Name = "cmbFarmacias"
        Me.cmbFarmacias.Size = New System.Drawing.Size(200, 22)
        Me.cmbFarmacias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbFarmacias.TabIndex = 1
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblTotal.Location = New System.Drawing.Point(131, 347)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(279, 24)
        Me.lblTotal.TabIndex = 390
        Me.lblTotal.Text = "$ [Total]"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(30, 223)
        Me.txtObservacion.MaxLength = 300
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(380, 22)
        Me.txtObservacion.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(27, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 348
        Me.Label3.Text = "Observación:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(28, 263)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 16)
        Me.Label2.TabIndex = 347
        Me.Label2.Text = "Mensaje para usuarios web:"
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(117, 392)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 32)
        Me.btnCerrar.TabIndex = 10
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregar.Location = New System.Drawing.Point(221, 392)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(117, 32)
        Me.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregar.TabIndex = 9
        Me.btnAgregar.Text = "Agregar (Enter)"
        Me.btnAgregar.TextColor = System.Drawing.SystemColors.ControlText
        '
        'txtMensajeWeb
        '
        Me.txtMensajeWeb.Location = New System.Drawing.Point(30, 282)
        Me.txtMensajeWeb.MaxLength = 300
        Me.txtMensajeWeb.Multiline = True
        Me.txtMensajeWeb.Name = "txtMensajeWeb"
        Me.txtMensajeWeb.Size = New System.Drawing.Size(380, 48)
        Me.txtMensajeWeb.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(247, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 16)
        Me.Label11.TabIndex = 342
        Me.Label11.Text = "Plan:"
        '
        'txtBonificacion
        '
        Me.txtBonificacion.AccessibleName = ""
        Me.txtBonificacion.BackColor = System.Drawing.Color.White
        Me.txtBonificacion.Decimals = CType(2, Byte)
        Me.txtBonificacion.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtBonificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBonificacion.Format = TextBoxConFormatoVB.tbFormats.UnsignedFloatingPointNumber
        Me.txtBonificacion.Location = New System.Drawing.Point(31, 166)
        Me.txtBonificacion.MaxLength = 100
        Me.txtBonificacion.Name = "txtBonificacion"
        Me.txtBonificacion.Size = New System.Drawing.Size(123, 22)
        Me.txtBonificacion.TabIndex = 6
        Me.txtBonificacion.Text_1 = Nothing
        Me.txtBonificacion.Text_2 = Nothing
        Me.txtBonificacion.Text_3 = Nothing
        Me.txtBonificacion.Text_4 = Nothing
        Me.txtBonificacion.UserValues = Nothing
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(31, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 16)
        Me.Label13.TabIndex = 304
        Me.Label13.Text = "Farmacia*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(127, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 16)
        Me.Label12.TabIndex = 305
        Me.Label12.Text = "Imp. 100%*"
        '
        'txtImpRecaudado
        '
        Me.txtImpRecaudado.AccessibleName = ""
        Me.txtImpRecaudado.BackColor = System.Drawing.Color.White
        Me.txtImpRecaudado.Decimals = CType(2, Byte)
        Me.txtImpRecaudado.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtImpRecaudado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImpRecaudado.Format = TextBoxConFormatoVB.tbFormats.UnsignedFloatingPointNumber
        Me.txtImpRecaudado.Location = New System.Drawing.Point(130, 104)
        Me.txtImpRecaudado.MaxLength = 100
        Me.txtImpRecaudado.Name = "txtImpRecaudado"
        Me.txtImpRecaudado.Size = New System.Drawing.Size(135, 22)
        Me.txtImpRecaudado.TabIndex = 4
        Me.txtImpRecaudado.Text_1 = Nothing
        Me.txtImpRecaudado.Text_2 = Nothing
        Me.txtImpRecaudado.Text_3 = Nothing
        Me.txtImpRecaudado.Text_4 = Nothing
        Me.txtImpRecaudado.UserValues = Nothing
        '
        'txtImpACargoOs
        '
        Me.txtImpACargoOs.AccessibleName = ""
        Me.txtImpACargoOs.Decimals = CType(2, Byte)
        Me.txtImpACargoOs.DecSeparator = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtImpACargoOs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImpACargoOs.Format = TextBoxConFormatoVB.tbFormats.UnsignedFloatingPointNumber
        Me.txtImpACargoOs.Location = New System.Drawing.Point(282, 104)
        Me.txtImpACargoOs.MaxLength = 100
        Me.txtImpACargoOs.Name = "txtImpACargoOs"
        Me.txtImpACargoOs.Size = New System.Drawing.Size(133, 22)
        Me.txtImpACargoOs.TabIndex = 5
        Me.txtImpACargoOs.Text_1 = Nothing
        Me.txtImpACargoOs.Text_2 = Nothing
        Me.txtImpACargoOs.Text_3 = Nothing
        Me.txtImpACargoOs.Text_4 = Nothing
        Me.txtImpACargoOs.UserValues = Nothing
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(28, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 16)
        Me.Label6.TabIndex = 339
        Me.Label6.Text = "Bonificación*"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(281, 84)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 16)
        Me.Label16.TabIndex = 330
        Me.Label16.Text = "Imp. A/c O.S*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(28, 352)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 337
        Me.Label5.Text = "Imp. A Pagar:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(30, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 16)
        Me.Label10.TabIndex = 335
        Me.Label10.Text = "N° recetas*"
        '
        'txtRecetas
        '
        Me.txtRecetas.AccessibleName = ""
        Me.txtRecetas.Decimals = CType(0, Byte)
        Me.txtRecetas.DecSeparator = Global.Microsoft.VisualBasic.ChrW(44)
        Me.txtRecetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecetas.Format = TextBoxConFormatoVB.tbFormats.UnsignedNumber
        Me.txtRecetas.Location = New System.Drawing.Point(30, 104)
        Me.txtRecetas.MaxLength = 4
        Me.txtRecetas.Name = "txtRecetas"
        Me.txtRecetas.Size = New System.Drawing.Size(86, 22)
        Me.txtRecetas.TabIndex = 3
        Me.txtRecetas.Text_1 = Nothing
        Me.txtRecetas.Text_2 = Nothing
        Me.txtRecetas.Text_3 = Nothing
        Me.txtRecetas.Text_4 = Nothing
        Me.txtRecetas.UserValues = Nothing
        '
        'frmPresentacionesAgregarItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 472)
        Me.Controls.Add(Me.GbFarmaciaForm)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(479, 511)
        Me.MinimumSize = New System.Drawing.Size(479, 511)
        Me.Name = "frmPresentacionesAgregarItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle presentación"
        Me.GbFarmaciaForm.ResumeLayout(False)
        Me.GbFarmaciaForm.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GbFarmaciaForm As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtBonificacion As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtImpRecaudado As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents txtImpACargoOs As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents Label6 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtRecetas As TextBoxConFormatoVB.FormattedTextBoxVB
    Friend WithEvents txtMensajeWeb As TextBox
    Friend WithEvents btnAgregar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As Button
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents cmbPlanes As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbFarmacias As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents lblInfo As Label
    Friend WithEvents btnCleanPlan As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblNombrePorcentaje As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPorcentaje As TextBox
    Friend WithEvents rdbACargoOS As RadioButton
    Friend WithEvents rdbRecaudado As RadioButton
End Class
