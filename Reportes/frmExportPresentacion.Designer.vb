<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmExportPresentacion
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
        Me.components = New System.ComponentModel.Container()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.spRPT_PresentacionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsPresentaciones = New CENPROFAR.dsPresentaciones()
        Me.spRPT_PresentacionTableAdapter = New CENPROFAR.dsPresentacionesTableAdapters.spRPT_PresentacionTableAdapter()
        CType(Me.spRPT_PresentacionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsPresentaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CENPROFAR.rptPresentaciones.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 0
        '
        'spRPT_PresentacionBindingSource
        '
        Me.spRPT_PresentacionBindingSource.DataMember = "spRPT_Presentacion"
        Me.spRPT_PresentacionBindingSource.DataSource = Me.dsPresentaciones
        '
        'dsPresentaciones
        '
        Me.dsPresentaciones.DataSetName = "dsPresentaciones"
        Me.dsPresentaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'spRPT_PresentacionTableAdapter
        '
        Me.spRPT_PresentacionTableAdapter.ClearBeforeFill = True
        '
        'frmExportPresentacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmExportPresentacion"
        Me.Text = "frmExportPresentacion"
        CType(Me.spRPT_PresentacionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsPresentaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents spRPT_PresentacionBindingSource As BindingSource
    Friend WithEvents dsPresentaciones As dsPresentaciones
    Friend WithEvents spRPT_PresentacionTableAdapter As dsPresentacionesTableAdapters.spRPT_PresentacionTableAdapter
End Class
