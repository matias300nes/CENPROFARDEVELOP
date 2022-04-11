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
    Dim Cheques As DataTable
    Public Sub New(Cheques As DataTable)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Cheques = Cheques
    End Sub
    Private Sub frmRtpCheques_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'dsSistema.spRPT_Presentacion' Puede moverla o quitarla según sea necesario.
        'Me.spRPT_PresentacionTableAdapter.Fill(Me.dsSistema.spRPT_Presentacion)

        Dim i As Integer = 0
        For Each cheque As DataRow In Cheques.Rows
            Dim row As dsSistema.PagosRow = dsSistema.Pagos.NewPagosRow
            row.Id = i
            row.PagueseA = cheque(colsCheques.PagueseA)
            row.Monto = cheque(colsCheques.Monto)
            row.FechaPago = cheque(colsCheques.FechaPago)
            row.FechaEmision = DateTime.Today
            dsSistema.Pagos.AddPagosRow(row)
            i += 1
        Next
        MsgBox(dsSistema.Pagos.Rows.Count)
        'var reportDataSource1 = New ReportDataSource("NameOfReportDataSet", YourDataTable);
        'this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);

        Me.ReportViewer1.RefreshReport()
        'Me.ReportViewer1.RefreshReport()
    End Sub
End Class