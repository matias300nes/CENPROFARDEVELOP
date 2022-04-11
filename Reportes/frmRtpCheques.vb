Public Class frmRtpCheques
    Enum colsCheques
        id = 0
        seleccion = 1
        PagueseA = 2
        FechaEmision = 3
        FechaPago = 4
        Monto = 5
        IdFarmacia = 6
    End Enum
    Public Sub New(Cheques As DataTable)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each cheque As DataRow In Cheques.Rows
            Dim row As dsSistema.PagosRow = dsSistema.Pagos.NewPagosRow
            row.PagueseA = cheque(colsCheques.PagueseA)
            row.Monto = cheque(colsCheques.Monto)
            row.FechaPago = cheque(colsCheques.FechaPago)
            row.FechaEmision = DateTime.Today
        Next
    End Sub
    Private Sub frmRtpCheques_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'dsSistema.spRPT_Presentacion' Puede moverla o quitarla según sea necesario.
        'Me.spRPT_PresentacionTableAdapter.Fill(Me.dsSistema.spRPT_Presentacion)

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class