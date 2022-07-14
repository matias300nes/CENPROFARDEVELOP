


Imports System.Drawing.Imaging
Imports System.IO

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

        'QRCoder.QRCodeGenerator qRCodeGenerator = New QRCoder.QRCodeGenerator();
        'QRCoder.QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(textBox1.Text, QRCoder.QRCodeGenerator.ECCLevel.Q);
        'QRCoder.QRCode qRCode = New QRCoder.QRCode(qRCodeData);
        'Bitmap bmp = qRCode.GetGraphic(5);
        'Using (MemoryStream ms = New MemoryStream())
        '{
        '    bmp.Save(MS, ImageFormat.Bmp);
        '    ReportData reportData = New ReportData();
        '    ReportData.QRCodeRow qRCodeRow = reportData.QRCode.NewQRCodeRow();
        '    qRCodeRow.Image = MS.ToArray();
        '    reportData.QRCode.AddQRCodeRow(qRCodeRow);

        '    ReportDataSource reportDataSource = New ReportDataSource();
        '    reportDataSource.Name = "ReportData";
        '    reportDataSource.Value = reportData.QRCode;
        '    ReportViewer1.LocalReport.DataSources.Clear();
        '    ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
        '    ReportViewer1.RefreshReport();
        '}

        'Dim qRCodeGenerator As QRCoder.QRCodeGenerator = New QRCoder.QRCodeGenerator()
        'Dim qRCodeData As QRCoder.QRCodeData = qRCodeGenerator.CreateQrCode(textBox1.Text, QRCoder.QRCodeGenerator.ECCLevel.Q)
        'Dim qRCode As QRCoder.QRCode = New QRCoder.QRCode(qRCodeData)
        'Dim bmp As Bitmap = qRCode.GetGraphic(5)

        'Dim ms As New MemoryStream
        'bmp.Save(ms, ImageFormat.Bmp)
        'Dim reportData As New ReportData


        Me.spRPT_FacturasElectronicas_EmitidasTableAdapter.Fill(Me.dsSistema.spRPT_FacturasElectronicas_Emitidas, eliminado, nroidentificador, mes, anio, IdOrigen)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class