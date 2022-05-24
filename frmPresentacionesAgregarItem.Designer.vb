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
        Me.GbFarmaciaForm.Size = New System.Drawing.Size(399, 446)
        Me.GbFarmaciaForm.TabIndex = 5
        Me.GbFarmaciaForm.TabStop = False
        Me.GbFarmaciaForm.Text = "Presentacion farmacia"
        '
        'lblInfo
        '
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblInfo.Location = New System.Drawing.Point(233, 17)
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
        Me.cmbPlanes.Location = New System.Drawing.Point(166, 156)
        Me.cmbPlanes.Name = "cmbPlanes"
        Me.cmbPlanes.Size = New System.Drawing.Size(201, 22)
        Me.cmbPlanes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPlanes.TabIndex = 6
        '
        'cmbFarmacias
        '
        Me.cmbFarmacias.DisplayMember = "Text"
        Me.cmbFarmacias.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbFarmacias.FormattingEnabled = True
        Me.cmbFarmacias.ItemHeight = 16
        Me.cmbFarmacias.Location = New System.Drawing.Point(31, 49)
        Me.cmbFarmacias.Name = "cmbFarmacias"
        Me.cmbFarmacias.Size = New System.Drawing.Size(203, 22)
        Me.cmbFarmacias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbFarmacias.TabIndex = 1
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblTotal.Location = New System.Drawing.Point(131, 348)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(235, 24)
        Me.lblTotal.TabIndex = 390
        Me.lblTotal.Text = "$ [Total]"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(30, 213)
        Me.txtObservacion.MaxLength = 300
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(336, 22)
        Me.txtObservacion.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(27, 194)
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
        Me.Label2.Location = New System.Drawing.Point(28, 253)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 16)
        Me.Label2.TabIndex = 347
        Me.Label2.Text = "Mensaje para usuarios web:"
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(92, 394)
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
        Me.btnAgregar.Location = New System.Drawing.Point(196, 394)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(117, 32)
        Me.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregar.TabIndex = 9
        Me.btnAgregar.Text = "Agregar (Enter)"
        Me.btnAgregar.TextColor = System.Drawing.SystemColors.ControlText
        '
        'txtMensajeWeb
        '
        Me.txtMensajeWeb.Location = New System.Drawing.Point(30, 272)
        Me.txtMensajeWeb.MaxLength = 300
        Me.txtMensajeWeb.Multiline = True
        Me.txtMensajeWeb.Name = "txtMensajeWeb"
        Me.txtMensajeWeb.Size = New System.Drawing.Size(337, 48)
        Me.txtMensajeWeb.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(162, 136)
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
        Me.txtBonificacion.Location = New System.Drawing.Point(31, 156)
        Me.txtBonificacion.MaxLength = 100
        Me.txtBonificacion.Name = "txtBonificacion"
        Me.txtBonificacion.Size = New System.Drawing.Size(118, 22)
        Me.txtBonificacion.TabIndex = 5
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
        Me.Label12.Location = New System.Drawing.Point(113, 85)
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
        Me.txtImpRecaudado.Location = New System.Drawing.Point(116, 104)
        Me.txtImpRecaudado.MaxLength = 100
        Me.txtImpRecaudado.Name = "txtImpRecaudado"
        Me.txtImpRecaudado.Size = New System.Drawing.Size(118, 22)
        Me.txtImpRecaudado.TabIndex = 3
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
        Me.txtImpACargoOs.Location = New System.Drawing.Point(249, 104)
        Me.txtImpACargoOs.MaxLength = 100
        Me.txtImpACargoOs.Name = "txtImpACargoOs"
        Me.txtImpACargoOs.Size = New System.Drawing.Size(118, 22)
        Me.txtImpACargoOs.TabIndex = 4
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
        Me.Label6.Location = New System.Drawing.Point(28, 136)
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
        Me.Label16.Location = New System.Drawing.Point(248, 84)
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
        Me.Label5.Location = New System.Drawing.Point(28, 353)
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
        Me.txtRecetas.Size = New System.Drawing.Size(70, 22)
        Me.txtRecetas.TabIndex = 2
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
        Me.ClientSize = New System.Drawing.Size(420, 464)
        Me.Controls.Add(Me.GbFarmaciaForm)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(436, 503)
        Me.MinimumSize = New System.Drawing.Size(436, 503)
        Me.Name = "frmPresentacionesAgregarItem"
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
End Class
