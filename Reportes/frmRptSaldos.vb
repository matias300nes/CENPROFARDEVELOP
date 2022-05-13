Public Class frmRptSaldos

    Dim idFarmacia As Long
    Dim fechaInicio, fechaFin As String

    Public Sub New(idFarmacia As Long, fechaInicio As String, fechaFin As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.idFarmacia = idFarmacia
        Me.fechaInicio = fechaInicio
        Me.fechaFin = fechaFin

    End Sub

    Private Sub frmRptSaldos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'dsSistema.spRPT_Saldos_Prueba' Puede moverla o quitarla según sea necesario.
        Me.spRPT_Saldos_PruebaTableAdapter.Fill(Me.dsSistema.spRPT_Saldos_Prueba, idFarmacia, fechaInicio, fechaFin)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class