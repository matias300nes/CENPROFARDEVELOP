Public Class frmPresentacionRpt
    Dim idpresentacion As Long

    Public Sub New(idpresentacion As Long)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.idpresentacion = idpresentacion

    End Sub


    Private Sub frmPresentacionRpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'dsSistema.spRPT_Presentacion' Puede moverla o quitarla según sea necesario.
        Me.spRPT_PresentacionTableAdapter.Fill(Me.dsSistema.spRPT_Presentacion, idpresentacion)
        Dim ObraSocial = dsSistema.Tables(0).Rows(0).Item(0)
        Dim Periodo = dsSistema.Tables(0).Rows(0).Item(3)
        Dim FechaActual = Today.Date.ToString("dd/MM/yyyy")
        FechaActual = Replace(FechaActual, "/", "-")
        Me.ReportViewer1.LocalReport.DisplayName = "PRESENTACIÓN " + ObraSocial + "-" + Periodo
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class