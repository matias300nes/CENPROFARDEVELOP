


Public Class frmRptFacturaC

    Dim eliminado, mes, anio, nroidentificador As String
    Dim IdOrigen As Long

    Public Sub New(eliminado As String, nroidentificador As String, mes As String, anio As String, idorigen As Long)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.nroidentificador = nroidentificador
        Me.mes = mes
        Me.anio = anio
        Me.IdOrigen = idorigen
        Me.eliminado = eliminado
    End Sub

    Private Sub frmRptFacturaC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'dsSistema.spRPT_FacturasElectronicas_Emitidas' Puede moverla o quitarla según sea necesario.
        Me.spRPT_FacturasElectronicas_EmitidasTableAdapter.Fill(Me.dsSistema.spRPT_FacturasElectronicas_Emitidas, eliminado, nroidentificador, mes, anio, IdOrigen)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class