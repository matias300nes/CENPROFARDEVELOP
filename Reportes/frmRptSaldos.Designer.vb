<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptSaldos
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.spRPT_Saldos_PruebaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsSistema = New CENPROFAR.dsSistema()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.spRPT_Saldos_PruebaTableAdapter = New CENPROFAR.dsSistemaTableAdapters.spRPT_Saldos_PruebaTableAdapter()
        CType(Me.spRPT_Saldos_PruebaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsSistema, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'spRPT_Saldos_PruebaBindingSource
        '
        Me.spRPT_Saldos_PruebaBindingSource.DataMember = "spRPT_Saldos_Prueba"
        Me.spRPT_Saldos_PruebaBindingSource.DataSource = Me.dsSistema
        '
        'dsSistema
        '
        Me.dsSistema.DataSetName = "dsSistema"
        Me.dsSistema.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsSaldos"
        ReportDataSource1.Value = Me.spRPT_Saldos_PruebaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CENPROFAR.rptSaldos.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 0
        '
        'spRPT_Saldos_PruebaTableAdapter
        '
        Me.spRPT_Saldos_PruebaTableAdapter.ClearBeforeFill = True
        '
        'frmRptSaldos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmRptSaldos"
        Me.Text = "frmRptSaldos"
        CType(Me.spRPT_Saldos_PruebaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsSistema, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents spRPT_Saldos_PruebaBindingSource As BindingSource
    Friend WithEvents dsSistema As dsSistema
    Friend WithEvents spRPT_Saldos_PruebaTableAdapter As dsSistemaTableAdapters.spRPT_Saldos_PruebaTableAdapter
End Class
