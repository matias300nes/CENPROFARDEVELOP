Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Microsoft.Reporting.WinForms
Imports Utiles.Util

Public Class frmRtpCheques
    Enum colsCheques
        id = 0
        seleccion = 1
        PagueseA = 2
        FechaCreacion = 3
        FechaEmision = 4
        FechaPago = 5
        Monto = 6
        IdFarmacia = 7
    End Enum
    Dim Cheques As DataTable
    Public Sub New(Cheques As DataTable)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Cheques = Cheques
    End Sub

#Region "Eventos"
    Private Sub frmRtpCheques_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each cheque As DataRow In Cheques.Rows
            Dim row As dsSistema.PagosRow = dsSistema.Pagos.NewPagosRow
            row.Id = cheque(colsCheques.id)
            row.PagueseA = cheque(colsCheques.PagueseA)
            row.Monto = cheque(colsCheques.Monto)
            row.FechaPago = cheque(colsCheques.FechaPago)
            row.FechaEmision = DateTime.Today
            dsSistema.Pagos.AddPagosRow(row)
        Next

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_PrintingBegin(sender As Object, e As ReportPrintEventArgs) Handles ReportViewer1.PrintingBegin
        MsgBox("Print begin!!!!")
    End Sub

#End Region

End Class