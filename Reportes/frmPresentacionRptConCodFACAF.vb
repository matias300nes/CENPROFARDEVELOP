Imports System.ComponentModel

Public Class frmPresentacionRptConCodFACAF
    Dim idpresentacion As Long
    Dim estadoChek As Boolean

    Public Sub New(idpresentacion As Long, estadoCheck As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.idpresentacion = idpresentacion
        Me.estadoChek = estadoCheck

    End Sub

    Private Sub frmPresentacionRptConCodFACAF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'dsSistema.spRPT_Presentacion' Puede moverla o quitarla según sea necesario.
        chkCodFacaf.Checked = estadoChek
        Me.spRPT_PresentacionTableAdapter.Fill(Me.dsSistema.spRPT_Presentacion, idpresentacion, estadoChek)
        If dsSistema.Tables(0).Rows.Count > 0 Then
            Dim ObraSocial = dsSistema.Tables(0).Rows(0).Item(0)
            Dim Periodo = dsSistema.Tables(0).Rows(0).Item(3)
            Dim FechaActual = Today.Date.ToString("dd/MM/yyyy")
            FechaActual = Replace(FechaActual, "/", "-")
            Me.ReportViewer1.LocalReport.DisplayName = "PRESENTACIÓN " + ObraSocial + "-" + Periodo
            Me.ReportViewer1.RefreshReport()
        End If
    End Sub

    Private Sub chkCodFacaf_CheckedChanged(sender As Object, e As EventArgs) Handles chkCodFacaf.CheckedChanged
        If chkCodFacaf.Checked = False Then
            Dim frmPresentacionRpt As New frmPresentacionRpt(idpresentacion, chkCodFacaf.Checked)
            Dispose()
            Close()
            frmPresentacionRpt.ShowDialog()
        End If
    End Sub

    Private Sub frmPresentacionRptConCodFACAF_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmPresentaciones.btnActualizar_Click(sender, e)
        'fuerzo actualizado una vez cierro el frm, sino, al cambiar de fila
        '"borra" el registro insertado, necesita forzar actualizado
    End Sub
End Class