<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPresentacionRptConCodFACAF
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.spRPT_PresentacionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsSistema = New CENPROFAR.dsSistema()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.spRPT_PresentacionTableAdapter = New CENPROFAR.dsSistemaTableAdapters.spRPT_PresentacionTableAdapter()
        Me.chkCodFacaf = New System.Windows.Forms.CheckBox()
        CType(Me.spRPT_PresentacionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsSistema, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'spRPT_PresentacionBindingSource
        '
        Me.spRPT_PresentacionBindingSource.DataMember = "spRPT_Presentacion"
        Me.spRPT_PresentacionBindingSource.DataSource = Me.dsSistema
        '
        'dsSistema
        '
        Me.dsSistema.DataSetName = "dsSistema"
        Me.dsSistema.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource5.Name = "dsPresentacion"
        ReportDataSource5.Value = Me.spRPT_PresentacionBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource5)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CENPROFAR.rptPresentacionConCodFACAF.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1067, 554)
        Me.ReportViewer1.TabIndex = 0
        '
        'spRPT_PresentacionTableAdapter
        '
        Me.spRPT_PresentacionTableAdapter.ClearBeforeFill = True
        '
        'chkCodFacaf
        '
        Me.chkCodFacaf.AutoSize = True
        Me.chkCodFacaf.Location = New System.Drawing.Point(875, 5)
        Me.chkCodFacaf.Name = "chkCodFacaf"
        Me.chkCodFacaf.Size = New System.Drawing.Size(150, 21)
        Me.chkCodFacaf.TabIndex = 2
        Me.chkCodFacaf.Text = "Con Código FACAF"
        Me.chkCodFacaf.UseVisualStyleBackColor = True
        '
        'frmPresentacionRptConCodFACAF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.chkCodFacaf)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmPresentacionRptConCodFACAF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmPresentacionRptConCodFACAF"
        CType(Me.spRPT_PresentacionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsSistema, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents spRPT_PresentacionBindingSource As BindingSource
    Friend WithEvents dsSistema As dsSistema
    Friend WithEvents spRPT_PresentacionTableAdapter As dsSistemaTableAdapters.spRPT_PresentacionTableAdapter
    Friend WithEvents chkCodFacaf As CheckBox
End Class
