Public Class frmRptSaldos

    Dim idFarmacia As Long
    Dim desde, hasta As String

    Public Sub New(idFarmacia As Long, desde As String, hasta As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.idFarmacia = idFarmacia
        Me.desde = desde
        Me.hasta = hasta

    End Sub

    Private Sub frmRptSaldos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'dsSistema.spRPT_Saldos_Prueba' Puede moverla o quitarla según sea necesario.
        Me.spRPT_Saldos_PruebaTableAdapter.Fill(Me.dsSistema.spRPT_Saldos_Prueba, 20137, "08-05-2022 15:00", "09-05-2022 15:56:00")

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class