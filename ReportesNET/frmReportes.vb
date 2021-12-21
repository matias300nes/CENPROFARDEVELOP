﻿Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports System.Windows.Forms
Imports Utiles
Imports System.IO
Imports Microsoft.Office.Interop
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports Microsoft.Office.Interop.Word


Public Class frmReportes

    Public NombreArchivoPDF As String
    Public rpt1 As frmReportes
    Public TieneCodigoBarra As Boolean = False

    Public MailDestinatario As String

#Region "FUNCIONES PRINCIPALES"

    Private Sub frmReportes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = Utiles.nbreformreportes
        Me.crvReportes.ShowRefreshButton = False
        Me.Cursor = Cursors.Default
    End Sub

    Public Function LoguearReporte(ByVal reporte As frmReportes, ByVal nbrereporte As String) As Boolean
        ''VARIABLE DE PARAMETROS DE CONECCION
        Dim myConnectionInfo As New ConnectionInfo
        ''RUTA DEL REPORTE
        Dim reportFilePath As String = Utiles.pathrpt & nbrereporte
        ''DEFINO LOS PARAMETROS DE CONECCION

        ''''''''''''''''''''''''''''''''''''''''''
        ''LEVANTARLOS DE UN INI
        ''''''''''''''''''''''''''''''''''''''''''
        ''NUEVO MS 19-07-2010
        Dim strLocation As String
        ''FIN NUEVO

        ''NUEVO MS 13-04-2011
        Dim nombre As String
        nombre = Mid$(nbrereporte, 1, InStr(Trim$(nbrereporte), "_") - 1).ToUpper
        'If nombre <> "RN" And nombre <> "TM3" Then
        '    nombre = ""
        '    nombre = Mid$(nbrereporte, 1, 4)

        '    myConnectionInfo = ObtenermyConnectionInfo(nombre)
        'Else
        '    myConnectionInfo = ObtenermyConnectionInfo(nombre)
        'End If

        myConnectionInfo = ObtenermyConnectionInfo(nombre)

        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim CrTables As CrystalDecisions.CrystalReports.Engine.Tables
        Dim CrTable As CrystalDecisions.CrystalReports.Engine.Table

        Try
            reporte.rdReportes.Load(reportFilePath)
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("No se pudo encontrar el Reporte en  " + reportFilePath & vbCrLf & _
                    "Comuniquese con Mercedes IT, enviando un correo a soporte@mercedesit.com", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Advertencia")
            Return False
            Exit Function
        End Try

        Try
            CrTables = reporte.rdReportes.Database.Tables

            For Each CrTable In CrTables

                crtableLogoninfo = CrTable.LogOnInfo

                crtableLogoninfo.ConnectionInfo = myConnectionInfo

                CrTable.ApplyLogOnInfo(crtableLogoninfo)
                ''NUEVO MS DG 19-07-2010
                Dim aux As String
                aux = Replace(CrTable.Location.ToString.ToLower, "proc(", "")
                aux = Replace(aux, ";1)", "")
                aux = Replace(aux, ",1)", "")

                strLocation = myConnectionInfo.DatabaseName & ".dbo." & aux
                Try
                    CrTable.Location = strLocation
                Catch ex As Exception
                    MsgBox(ex.Message.ToString)
                End Try
                ''FIN NUEVO

            Next

            ''SETEA EL LOGON INFO PARA CUALQUIER SUBREPORTE DEL REPORTE PRINCIPAL
            'For Each subReportDocument As ReportDocument In reporte.rdReportes.Subreports
            '    For Each subReportTable As CrystalDecisions.CrystalReports.Engine.Table In subReportDocument.Database.Tables
            '        Try
            '            subReportTable.ApplyLogOnInfo(crtableLogoninfo)
            '            ''NUEVO MS DG 19-07-2010
            '            Dim aux As String
            '            aux = Replace(subReportTable.Location.ToString.ToLower, "proc(", "")
            '            aux = Replace(aux, ";1)", "")
            '            aux = Replace(aux, ",1)", "")

            '            strLocation = myConnectionInfo.DatabaseName & ".dbo." & aux
            '            Try
            '                subReportTable.Location = strLocation
            '                subReportDocument.VerifyDatabase()

            '            Catch ex As Exception
            '                MsgBox(ex.Message.ToString)
            '            End Try
            '            ''FIN NUEVO
            '        Catch ex As Exception
            '            '
            '        End Try
            '    Next
            'Next

            reporte.rdReportes.VerifyDatabase()


            reporte.crvReportes.ReportSource = reporte.rdReportes

            Return True
        Catch ex2 As Exception
            MsgBox(ex2.Message.ToString)
        End Try

    End Function

    Public Function ObtenermyConnectionInfo(ByVal nombre As String) As ConnectionInfo
        Try
            Dim myConnectionInfo As New ConnectionInfo

            nombre = UCase(nombre)
            If nombre = "ICYS" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionICYS.server
                    .DatabaseName = Utiles.TipoConexionICYS.base
                    .UserID = Utiles.TipoConexionICYS.usuario
                    .Password = Utiles.TipoConexionICYS.contrasena
                End With
            ElseIf nombre = "PERFORACIONES" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionPERFO.server
                    .DatabaseName = Utiles.TipoConexionPERFO.base
                    .UserID = Utiles.TipoConexionPERFO.usuario
                    .Password = Utiles.TipoConexionPERFO.contrasena
                End With
            ElseIf nombre = "USUARIOS" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionUSUARIOS.server
                    .DatabaseName = Utiles.TipoConexionUSUARIOS.base
                    .UserID = Utiles.TipoConexionUSUARIOS.usuario
                    .Password = Utiles.TipoConexionUSUARIOS.contrasena
                End With
            ElseIf nombre = "ACER" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionACER.server
                    .DatabaseName = Utiles.TipoConexionACER.base
                    .UserID = Utiles.TipoConexionACER.usuario
                    .Password = Utiles.TipoConexionACER.contrasena
                End With
            ElseIf nombre = "ROTI" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionROTI.server
                    .DatabaseName = Utiles.TipoConexionROTI.base
                    .UserID = Utiles.TipoConexionROTI.usuario
                    .Password = Utiles.TipoConexionROTI.contrasena
                End With
            ElseIf nombre = "FINANCIERA" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionFINANCIERA.server
                    .DatabaseName = Utiles.TipoConexionFINANCIERA.base
                    .UserID = Utiles.TipoConexionFINANCIERA.usuario
                    .Password = Utiles.TipoConexionFINANCIERA.contrasena
                End With
            ElseIf nombre = "SEI" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionSEI.server
                    .DatabaseName = Utiles.TipoConexionSEI.base
                    .UserID = Utiles.TipoConexionSEI.usuario
                    .Password = Utiles.TipoConexionSEI.contrasena
                End With
            ElseIf nombre = "HOLLMAN" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionMOTO_HOLLMAN.server
                    .DatabaseName = Utiles.TipoConexionMOTO_HOLLMAN.base
                    .UserID = Utiles.TipoConexionMOTO_HOLLMAN.usuario
                    .Password = Utiles.TipoConexionMOTO_HOLLMAN.contrasena
                End With
            ElseIf nombre = "FEAFIP" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionFEAFIP.server
                    .DatabaseName = Utiles.TipoConexionFEAFIP.base
                    .UserID = Utiles.TipoConexionFEAFIP.usuario
                    .Password = Utiles.TipoConexionFEAFIP.contrasena
                End With
            ElseIf nombre = "MIT" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionMIT.server
                    .DatabaseName = Utiles.TipoConexionMIT.base
                    .UserID = Utiles.TipoConexionMIT.usuario
                    .Password = Utiles.TipoConexionMIT.contrasena
                End With
            ElseIf nombre = "CONVERFLEX" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionSEI.server
                    .DatabaseName = Utiles.TipoConexionSEI.base
                    .UserID = Utiles.TipoConexionSEI.usuario
                    .Password = Utiles.TipoConexionSEI.contrasena
                End With
            ElseIf nombre = "TURNOS" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionCLINICA.server
                    .DatabaseName = Utiles.TipoConexionCLINICA.base
                    .UserID = Utiles.TipoConexionCLINICA.usuario
                    .Password = Utiles.TipoConexionCLINICA.contrasena
                End With
            ElseIf nombre = "PROPIEDADES" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionACER.server
                    .DatabaseName = Utiles.TipoConexionACER.base
                    .UserID = Utiles.TipoConexionACER.usuario
                    .Password = Utiles.TipoConexionACER.contrasena
                End With
            ElseIf nombre = "CARTOCOR" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionHOLLMAN.server
                    .DatabaseName = Utiles.TipoConexionHOLLMAN.base
                    .UserID = Utiles.TipoConexionHOLLMAN.usuario
                    .Password = Utiles.TipoConexionHOLLMAN.contrasena
                End With
            ElseIf nombre = "CAMELIAS" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionSEI.server
                    .DatabaseName = Utiles.TipoConexionSEI.base
                    .UserID = Utiles.TipoConexionSEI.usuario
                    .Password = Utiles.TipoConexionSEI.contrasena
                End With
            ElseIf nombre = "BIANCO" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionSEI.server
                    .DatabaseName = Utiles.TipoConexionSEI.base
                    .UserID = Utiles.TipoConexionSEI.usuario
                    .Password = Utiles.TipoConexionSEI.contrasena
                End With
            ElseIf nombre = "ROCHA" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionSEI.server
                    .DatabaseName = Utiles.TipoConexionSEI.base
                    .UserID = Utiles.TipoConexionSEI.usuario
                    .Password = Utiles.TipoConexionSEI.contrasena
                End With
            ElseIf nombre = "PORKYS" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionSEI.server
                    .DatabaseName = Utiles.TipoConexionSEI.base
                    .UserID = Utiles.TipoConexionSEI.usuario
                    .Password = Utiles.TipoConexionSEI.contrasena
                End With
            ElseIf nombre = "DISHERNAN" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionSEI.server
                    .DatabaseName = Utiles.TipoConexionSEI.base
                    .UserID = Utiles.TipoConexionSEI.usuario
                    .Password = Utiles.TipoConexionSEI.contrasena
                End With
            ElseIf nombre = "CENPROFAR" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionSEI.server
                    .DatabaseName = Utiles.TipoConexionSEI.base
                    .UserID = Utiles.TipoConexionSEI.usuario
                    .Password = Utiles.TipoConexionSEI.contrasena
                End With
            ElseIf nombre = "SAMBA" Then
                With myConnectionInfo
                    .ServerName = Utiles.TipoConexionSEI.server
                    .DatabaseName = Utiles.TipoConexionSEI.base
                    .UserID = Utiles.TipoConexionSEI.usuario
                    .Password = Utiles.TipoConexionSEI.contrasena
                End With
            End If

            ObtenermyConnectionInfo = myConnectionInfo

        Catch ex As Exception
            MsgBox("No se pudo conectar a la Base de Datos." & vbCrLf & _
                   "Es posible que la cadena de conexion no se encuentre en el INI." + ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Advertencia")
            ObtenermyConnectionInfo = Nothing

        End Try
    End Function

    'Public Function ExportToPDF() As String
    '    Dim vFileName As String
    '    Dim diskOpts As New DiskFileDestinationOptions()

    '    Try
    '        'With rpt.ExportOptions
    '        With Me.rdReportes.ExportOptions
    '            .ExportDestinationType = ExportDestinationType.DiskFile
    '            .ExportFormatType = ExportFormatType.PortableDocFormat

    '        End With

    '        vFileName = "C:\Temp_PDF_MIT\" & NombreArchivoPDF & ".pdf"
    '        If File.Exists(vFileName) Then File.Delete(vFileName)
    '        diskOpts.DiskFileName = vFileName
    '        'rpt.ExportOptions.DestinationOptions = diskOpts
    '        Me.rdReportes.ExportOptions.DestinationOptions = diskOpts
    '        'rpt.Export()
    '        Me.rdReportes.Export()

    '        Dim objOutlk As New Outlook.Application 'Outlook
    '        Const olMailItem As Integer = 0
    '        Dim objMail As New System.Object

    '        objMail = objOutlk.CreateItem(olMailItem) 'Email item

    '        ''Insert your "To" address...it can by dynamically populated
    '        'objMail.To = "mmm@yyy.com"

    '        ''Insert your "CC" address...it can by dynamically populated
    '        'objMail.cc = "ooo@yyy.com" 'Enter an address here To include a carbon copy; bcc is For blind carbon copy's

    '        'Set up Subject Line
    '        objMail.subject = NombreArchivoPDF

    '        'To add an attachment, use:
    '        objMail.attachments.add(vFileName)
    '        ''otherwise, if no attachment, you can comment the objMail.attachments.add("") out with an apostrophe

    '        'Set up your message body
    '        Dim msg As String

    '        msg = ""
    '        objMail.body = msg

    '        'Use this To display before sending, otherwise call (use) objMail.Send to send without reviewing
    '        objMail.display()

    '        'Clean up
    '        objMail = Nothing
    '        objOutlk = Nothing

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    '    Return vFileName

    'End Function

    Public Sub ExportToPDF_Propiedades(ByVal NombreArchivo As String)
        Dim vFileName As String
        Dim diskOpts As New DiskFileDestinationOptions()

        Try
            'With rpt.ExportOptions
            With Me.rdReportes.ExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat

            End With

            vFileName = "C:\MIT\" & NombreArchivo & ".pdf"
            If File.Exists(vFileName) Then File.Delete(vFileName)
            diskOpts.DiskFileName = vFileName
            'rpt.ExportOptions.DestinationOptions = diskOpts
            Me.rdReportes.ExportOptions.DestinationOptions = diskOpts
            'rpt.Export()
            Me.rdReportes.Export()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    'Private Sub btnOutlook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOutlook.Click
    '    Dim vFileName As String
    '    Dim diskOpts As New DiskFileDestinationOptions()

    '    Try
    '        'With rpt.ExportOptions
    '        With Me.rdReportes.ExportOptions
    '            .ExportDestinationType = ExportDestinationType.DiskFile
    '            .ExportFormatType = ExportFormatType.PortableDocFormat

    '        End With
    '        If NombreArchivoPDF = "" Then
    '            NombreArchivoPDF = Me.Text
    '        End If

    '        'Dim myStream As Stream
    '        'Dim openFileDialog1 As New OpenFileDialog()
    '        Dim openFileDialog1 As New SaveFileDialog

    '        openFileDialog1.InitialDirectory = "C:\MIT\"
    '        openFileDialog1.Filter = "Archivos PDF (*.pdf)|*.pdf"
    '        openFileDialog1.FilterIndex = 2
    '        openFileDialog1.RestoreDirectory = True
    '        openFileDialog1.FileName = NombreArchivoPDF

    '        If openFileDialog1.ShowDialog() = DialogResult.OK Then
    '            'myStream = openFileDialog1.OpenFile()
    '            'If Not (myStream Is Nothing) Then
    '            '    ' Insert code to read the stream here.
    '            '    vFileName = openFileDialog1.FileName
    '            '    myStream.Close()
    '            'End If
    '        Else
    '            Exit Sub
    '        End If

    '        'vFileName = "C:\Temp_PDF_MIT\" & NombreArchivoPDF & ".pdf"
    '        vFileName = openFileDialog1.FileName
    '        If File.Exists(vFileName) Then File.Delete(vFileName)
    '        diskOpts.DiskFileName = vFileName
    '        'rpt.ExportOptions.DestinationOptions = diskOpts
    '        Me.rdReportes.ExportOptions.DestinationOptions = diskOpts
    '        'rpt.Export()
    '        Me.rdReportes.Export()

    '        Dim objOutlk As New Outlook.Application 'Outlook
    '        Const olMailItem As Integer = 0
    '        Dim objMail As New System.Object

    '        objMail = objOutlk.CreateItem(olMailItem) 'Email item

    '        ''Insert your "To" address...it can by dynamically populated
    '        objMail.To = MailDestinatario

    '        ''Insert your "CC" address...it can by dynamically populated
    '        'objMail.cc = "ooo@yyy.com" 'Enter an address here To include a carbon copy; bcc is For blind carbon copy's

    '        'Set up Subject Line
    '        objMail.subject = NombreArchivoPDF

    '        'To add an attachment, use:
    '        objMail.attachments.add(vFileName)
    '        ''otherwise, if no attachment, you can comment the objMail.attachments.add("") out with an apostrophe

    '        'Set up your message body
    '        Dim msg As String

    '        msg = "Estimado, atento a lo solicitado, le adjunto el presupuesto correspondiente." & vbCrLf & vbCrLf & "Ante cualquier consulta, estamos a su disposición." & vbCrLf & vbCrLf & "Saludos Cordiales."
    '        objMail.body = msg

    '        'Use this To display before sending, otherwise call (use) objMail.Send to send without reviewing
    '        objMail.display()

    '        'Clean up
    '        objMail = Nothing
    '        objOutlk = Nothing

    '    Catch ex As Exception
    '        'Throw ex
    '        Dim errMessage As String = ""
    '        Dim tempException As Exception = ex

    '        While (Not tempException Is Nothing)
    '            errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
    '            tempException = tempException.InnerException
    '        End While

    '        MessageBox.Show(String.Format("Se produjo un problema al procesar el archivo, por favor, valide el siguiente mensaje de error: {0}" _
    '          + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage), _
    '          "Error en la Aplicación - Nombre de Archivo No Admitido", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    Public Sub btnPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPDF.Click
        Dim vFileName As String
        Dim diskOpts As New DiskFileDestinationOptions()

        Try
            With Me.rdReportes.ExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                If TieneCodigoBarra = True Then
                    .ExportFormatType = ExportFormatType.WordForWindows
                Else
                    .ExportFormatType = ExportFormatType.PortableDocFormat
                End If
            End With

            If NombreArchivoPDF = "" Then
                NombreArchivoPDF = Me.Text
            End If

            Dim openFileDialog1 As New SaveFileDialog

            If Utiles.Empresa = "ANCOA" Then
                openFileDialog1.InitialDirectory = pathComprobantesAFIP
            Else
                openFileDialog1.InitialDirectory = "C:\MIT\"
            End If

            If TieneCodigoBarra = True Then
                openFileDialog1.Filter = "Archivos PDF (*.doc)|*.doc"
            Else
                openFileDialog1.Filter = "Archivos PDF (*.pdf)|*.pdf"
            End If

            openFileDialog1.FilterIndex = 2
            openFileDialog1.RestoreDirectory = True
            openFileDialog1.FileName = RTrim(LTrim(NombreArchivoPDF))

            If openFileDialog1.ShowDialog() = DialogResult.OK Then

            Else
                Exit Sub
            End If

            vFileName = openFileDialog1.FileName
            If File.Exists(vFileName) Then File.Delete(vFileName)
            diskOpts.DiskFileName = vFileName
            Me.rdReportes.ExportOptions.DestinationOptions = diskOpts
            Me.rdReportes.Export()

            If TieneCodigoBarra = True Then
                Dim wordApplication As ApplicationClass = New ApplicationClass()
                Dim wordDocument As Document = Nothing

                Dim paramSourceDocPath As String = vFileName

                Dim paramExportFilePath As String = vFileName.Replace("doc", "pdf")
                Dim paramExportFormat As WdExportFormat = _
                WdExportFormat.wdExportFormatPDF
                Dim paramOpenAfterExport As Boolean = False
                Dim paramExportOptimizeFor As WdExportOptimizeFor = _
                WdExportOptimizeFor.wdExportOptimizeForPrint
                Dim paramExportRange As WdExportRange = _
                WdExportRange.wdExportAllDocument
                Dim paramStartPage As Int32 = 0
                Dim paramEndPage As Int32 = 0
                Dim paramExportItem As WdExportItem = _
                WdExportItem.wdExportDocumentContent
                Dim paramIncludeDocProps As Boolean = True
                Dim paramKeepIRM As Boolean = True
                Dim paramCreateBookmarks As WdExportCreateBookmarks = _
                WdExportCreateBookmarks.wdExportCreateWordBookmarks
                Dim paramDocStructureTags As Boolean = True
                Dim paramBitmapMissingFonts As Boolean = True
                Dim paramUseISO19005_1 As Boolean = False

                Try
                    'Abrir documento basados en el que selecciono
                    wordDocument = wordApplication.Documents.Open(paramSourceDocPath)

                    ' Exportar al formato deseado
                    If Not wordDocument Is Nothing Then
                        wordDocument.ExportAsFixedFormat(paramExportFilePath, _
                        paramExportFormat, paramOpenAfterExport, _
                        paramExportOptimizeFor, paramExportRange, paramStartPage, _
                        paramEndPage, paramExportItem, paramIncludeDocProps, _
                        paramKeepIRM, paramCreateBookmarks, _
                        paramDocStructureTags, paramBitmapMissingFonts, _
                        paramUseISO19005_1)
                    End If
                Catch ex As Exception
                    'Aqui una exepcion no controlada
                Finally
                    'cerrar documento
                    If Not wordDocument Is Nothing Then
                        wordDocument.Close(False)
                        wordDocument = Nothing
                    End If

                    'Quit a la aplicacion WinWord
                    If Not wordApplication Is Nothing Then
                        wordApplication.Quit()
                        wordApplication = Nothing
                    End If

                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                End Try

                File.Delete(vFileName)
            End If

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar el archivo, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicación - Nombre de Archivo No Admitido", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub ConvertirPDF()

        Dim vFileName As String
        Dim diskOpts As New DiskFileDestinationOptions()

        Try
            With Me.rdReportes.ExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                If TieneCodigoBarra = True Then
                    .ExportFormatType = ExportFormatType.WordForWindows
                Else
                    .ExportFormatType = ExportFormatType.PortableDocFormat
                End If
            End With

            If NombreArchivoPDF = "" Then
                NombreArchivoPDF = Me.Text
            End If

            'Dim openFileDialog1 As New SaveFileDialog

            'If Utiles.Empresa = "ANCOA" Then
            '    openFileDialog1.InitialDirectory = pathComprobantesAFIP
            'Else
            '    openFileDialog1.InitialDirectory = "C:\MIT\"
            'End If

            'If TieneCodigoBarra = True Then
            '    openFileDialog1.Filter = "Archivos PDF (*.doc)|*.doc"
            'Else
            '    openFileDialog1.Filter = "Archivos PDF (*.pdf)|*.pdf"
            'End If

            'openFileDialog1.FilterIndex = 2
            'openFileDialog1.RestoreDirectory = True
            'openFileDialog1.FileName = RTrim(LTrim(NombreArchivoPDF))

            'If openFileDialog1.ShowDialog() = DialogResult.OK Then

            'Else
            '    Exit Sub
            'End If

            'vFileName = openFileDialog1.FileName
            vFileName = "C:\Users\Administrador.WIN-329T72SKG6E\Dropbox\Deposito\" + NombreArchivoPDF + ".pdf"
            If File.Exists(vFileName) Then File.Delete(vFileName)
            diskOpts.DiskFileName = vFileName
            Me.rdReportes.ExportOptions.DestinationOptions = diskOpts
            Me.rdReportes.Export()

            If TieneCodigoBarra = True Then
                Dim wordApplication As ApplicationClass = New ApplicationClass()
                Dim wordDocument As Document = Nothing

                Dim paramSourceDocPath As String = vFileName

                Dim paramExportFilePath As String = vFileName.Replace("doc", "pdf")
                Dim paramExportFormat As WdExportFormat = _
                WdExportFormat.wdExportFormatPDF
                Dim paramOpenAfterExport As Boolean = False
                Dim paramExportOptimizeFor As WdExportOptimizeFor = _
                WdExportOptimizeFor.wdExportOptimizeForPrint
                Dim paramExportRange As WdExportRange = _
                WdExportRange.wdExportAllDocument
                Dim paramStartPage As Int32 = 0
                Dim paramEndPage As Int32 = 0
                Dim paramExportItem As WdExportItem = _
                WdExportItem.wdExportDocumentContent
                Dim paramIncludeDocProps As Boolean = True
                Dim paramKeepIRM As Boolean = True
                Dim paramCreateBookmarks As WdExportCreateBookmarks = _
                WdExportCreateBookmarks.wdExportCreateWordBookmarks
                Dim paramDocStructureTags As Boolean = True
                Dim paramBitmapMissingFonts As Boolean = True
                Dim paramUseISO19005_1 As Boolean = False

                Try
                    'Abrir documento basados en el que selecciono
                    wordDocument = wordApplication.Documents.Open(paramSourceDocPath)

                    ' Exportar al formato deseado
                    If Not wordDocument Is Nothing Then
                        wordDocument.ExportAsFixedFormat(paramExportFilePath, _
                        paramExportFormat, paramOpenAfterExport, _
                        paramExportOptimizeFor, paramExportRange, paramStartPage, _
                        paramEndPage, paramExportItem, paramIncludeDocProps, _
                        paramKeepIRM, paramCreateBookmarks, _
                        paramDocStructureTags, paramBitmapMissingFonts, _
                        paramUseISO19005_1)
                    End If
                Catch ex As Exception
                    'Aqui una exepcion no controlada
                Finally
                    'cerrar documento
                    If Not wordDocument Is Nothing Then
                        wordDocument.Close(False)
                        wordDocument = Nothing
                    End If

                    'Quit a la aplicacion WinWord
                    If Not wordApplication Is Nothing Then
                        wordApplication.Quit()
                        wordApplication = Nothing
                    End If

                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                End Try

                File.Delete(vFileName)
            End If

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar el archivo, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage), _
              "Error en la Aplicación - Nombre de Archivo No Admitido", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region 'Funciones principalesSEI_Stock_porRubroySubrubro.rpt

#Region "PROCEDIMIENTOS PARA MOSTRAR REPORTES GENERALES (APP)"

    Public Sub Proveedores_Maestro_App(ByVal codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Maestro_Proveedores.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@codigo", codigo)

                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub Proveedores_Maestro_Listado(ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Maestro_Proveedores2.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@codigo", "")
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub Rubros_Subrubros_Maestro_App(ByVal codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Maestro_Rubros_Subrubros.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@codigo", codigo)

                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub Clientes_Maestro_App(ByVal codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Maestro_Clientes.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@codigo", codigo)

                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub Materiales_App(ByVal codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String)
        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Maestro_Materiales.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                Select Case Sistema
                    Case "ACER"
                        rpt.rdReportes.SetParameterValue("@Busqueda", codigo)
                    Case "SEI"
                        rpt.rdReportes.SetParameterValue("@Busqueda", codigo)
                    Case "HOLLMAN"
                        rpt.rdReportes.SetParameterValue("@Busqueda", codigo)
                    Case Else
                        rpt.rdReportes.SetParameterValue("@codigo_materiales", codigo)
                End Select

                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub Productos_App(ByVal codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String)
        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Maestro_Productos.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@codigo", codigo)

                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub OrdenesDeCompra_Maestro_App(ByVal Codigo As String, ByVal Saldoparam As Double, ByVal rpt As frmReportes, ByVal Sistema As String, ByVal Presupuesto As Boolean)

        Dim nbrereporte As String = ""

        If Presupuesto = False Then
            nbrereporte = Sistema & "_OrdenDeCompra.rpt"
        Else
            nbrereporte = Sistema & "_OrdenDeCompra_presupuesto.rpt"
        End If

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@codigo_Ordendecompra", Codigo)
                rpt.rdReportes.SetParameterValue("@saldoparam", Saldoparam)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If

    End Sub

    Public Sub OrdenesDeCompraPorkys_Maestro_App(ByVal Codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String, ByVal Presupuesto As Boolean)

        Dim nbrereporte As String = ""

        If Presupuesto = False Then
            nbrereporte = Sistema & "_PorkysOrdenDeCompra.rpt"
        Else
            nbrereporte = Sistema & "_PorkysOrdenDeCompra_presupuesto.rpt"
        End If

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@codigo_Ordendecompra", Codigo)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If

    End Sub

    Public Sub Transferencias_Maestro_App(ByVal Codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String, ByVal Presupuesto As Boolean)

        Dim nbrereporte As String = ""

        If Presupuesto = False Then
            nbrereporte = Sistema & "_Transferencias.rpt"
        Else
            nbrereporte = Sistema & "_OrdenDeCompra_presupuesto.rpt"
        End If

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@codigo_Ordendecompra", Codigo)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If

    End Sub

    Public Sub VentasClientes_Maestro_App(ByVal Codigo As String, ByVal repartidor As String, ByVal Desde As Date, ByVal Hasta As Date, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_VentasClientes.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@cliente", Codigo)
                rpt.rdReportes.SetParameterValue("@repartidor", repartidor)
                rpt.rdReportes.SetParameterValue("@desde", Desde)
                rpt.rdReportes.SetParameterValue("@hasta", Hasta)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If

    End Sub

    Public Sub DevolucionesProveedor_Maestro_App(ByVal Codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String, ByVal Presupuesto As Boolean)

        Dim nbrereporte As String = ""

        If Presupuesto = False Then
            nbrereporte = Sistema & "_DevolucionesProveedor.rpt"
        Else
            nbrereporte = Sistema & "_OrdenDeCompra_presupuesto.rpt"
        End If

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@codigo_Ordendecompra", Codigo)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If

    End Sub

    Public Sub Recaudacion_Maestro_App(ByVal Empleado As String, ByVal Zona As String, ByVal Fecha As Date, ByVal Hasta As Date, ByVal rpt As frmReportes, ByVal Sistema As String)
        Dim nbrereporte As String

        nbrereporte = Sistema & "_RecaudacionRepartidor.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Empleado", Empleado)
                rpt.rdReportes.SetParameterValue("@Zona", Zona)
                rpt.rdReportes.SetParameterValue("@Fecha", Fecha)
                rpt.rdReportes.SetParameterValue("@Hasta", Hasta)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If

    End Sub

    Public Sub PlanillaCargaRepartidor_Maestro_App(ByVal Empleado As String, ByVal Zona As String, ByVal Fecha As Date, ByVal Hasta As Date, ByVal rpt As frmReportes, ByVal Sistema As String)
        Dim nbrereporte As String

        nbrereporte = Sistema & "_PlanillaCargaRepartidor.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Empleado", Empleado)
                rpt.rdReportes.SetParameterValue("@Zona", Zona)
                rpt.rdReportes.SetParameterValue("@Fecha", Fecha)
                rpt.rdReportes.SetParameterValue("@Hasta", Hasta)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If

    End Sub

    Public Sub Recaudacion_Anexo_Maestro_App(ByVal Empleado As String, ByVal Zona As String, ByVal Fecha As Date, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = Sistema & "_RecaudacionRepartidorAnexo.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Empleado", Empleado)
                rpt.rdReportes.SetParameterValue("@Zona", Zona)
                rpt.rdReportes.SetParameterValue("@Fecha", Fecha)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If

    End Sub

    Public Sub DevolucionesClientes_Maestro_App(ByVal Desde As Date, ByVal Hasta As Date, ByVal Norte As Boolean, ByVal Deposito As Boolean, ByVal rpt As frmReportes, ByVal Sistema As String)
        Dim nbrereporte As String = Sistema & "_DevolucionesClientes.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", Desde)
                rpt.rdReportes.SetParameterValue("@Hasta", Hasta)
                rpt.rdReportes.SetParameterValue("@Norte", Norte)
                rpt.rdReportes.SetParameterValue("@Deposito", Deposito)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub OrdenesdeCompra_Pendientes_App(ByVal inicio As Date, ByVal fin As Date, ByVal Proveedor As String, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_OrdendeCompra_Pendiente.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.rdReportes.SetParameterValue("@Proveedor", Proveedor)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub PrespuestosAprobados_Pendientes_App(ByVal inicio As Date, ByVal fin As Date, ByVal Cliente As String, ByVal Estado As String, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Presupuestos_Aprobados_Pendiente.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.rdReportes.SetParameterValue("@Cliente", Cliente)
                rpt.rdReportes.SetParameterValue("@Estado", Estado)

                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub Recepciones_Maestro_App(ByVal codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Recepcion.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@codigo_Recepcion", codigo)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub Empleados_Maestro_App(ByVal codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String)
        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Maestro_Empleados.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@codigo", codigo)

                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub MostrarListadoPrecio_Productos_App(ByVal rpt As frmReportes, ByVal Sistema As String)
        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Maestro_Productos_Precios.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor

                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub Presupuesto_App(ByVal idpresupuesto As String, ByVal rpt As frmReportes, ByVal Sistema As String)
        Dim nbrereporte As String

        nbrereporte = Sistema & "_Presupuesto.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.SetParameterValue("@id", idpresupuesto)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If

    End Sub

    Public Sub Remito_App(ByVal codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String, ByVal Tipo As String, ByVal ImprimirRPT As Boolean)
        Dim nbrereporte As String = ""

        If Tipo = "Material" Then
            nbrereporte = Sistema & "_Remito.rpt"
        Else
            If Tipo = "Equipo" Then
                nbrereporte = Sistema & "_Remito_EquiposHerramientas.rpt"
            Else
                If Tipo = "Equipo Vacio" Then
                    nbrereporte = Sistema & "_Remito_EquiposHerramientas_Vacio.rpt"
                End If
            End If
        End If

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.SetParameterValue("@codigo", codigo)
                If ImprimirRPT = True Then
                    If Tipo = "Equipo Vacio" Then
                        rpt.rdReportes.PrintToPrinter(1, False, 1, 100)
                    Else
                        rpt.rdReportes.PrintToPrinter(2, False, 1, 100)
                    End If
                Else
                    rpt.Show()
                End If
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If
    End Sub

    Public Sub Factura_App(ByVal nrofactura As String, ByVal rpt As frmReportes, ByVal NC As Long, ByVal Sistema As String, ByVal Tipo As String, ByVal TipoComprobante As String, ByVal Empresa As String, Optional ByVal Previsualizar As Boolean = False, Optional IdTMP As String = "", Optional ImpresionDirecta As Boolean = False)
        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_" & TipoComprobante.Replace(" ", "_") & "_" & Empresa.ToUpper & ".rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try

                rpt.rdReportes.SetParameterValue("@Codigo", nrofactura)
                rpt.rdReportes.SetParameterValue("@Tipo", Tipo)
                rpt.rdReportes.SetParameterValue("@TipoComprobante", TipoComprobante)
                rpt.rdReportes.SetParameterValue("@Previsualizar", Previsualizar)
                rpt.rdReportes.SetParameterValue("@Idtmp", IdTMP)

                If ImpresionDirecta = False Then
                    rpt.Show()
                Else
                    rpt.rdReportes.PrintToPrinter(1, False, 1, 100)
                End If
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If
    End Sub

    Public Sub Comprobante_Santina(ByVal nrofactura As String, ByVal rpt As frmReportes, ByVal NC As Long, ByVal Sistema As String, ByVal Tipo As String, ByVal TipoComprobante As String, ByVal Empresa As String, Optional ByVal Previsualizar As Boolean = False, Optional IdTMP As String = "", Optional ImpresionDirecta As Boolean = False)
        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Comprobante_" & Empresa.ToUpper & ".rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try

                rpt.rdReportes.SetParameterValue("@Codigo", nrofactura)
                rpt.rdReportes.SetParameterValue("@Tipo", Tipo)
                rpt.rdReportes.SetParameterValue("@TipoComprobante", TipoComprobante)
                rpt.rdReportes.SetParameterValue("@Previsualizar", Previsualizar)
                rpt.rdReportes.SetParameterValue("@Idtmp", IdTMP)

                If ImpresionDirecta = False Then
                    rpt.Show()
                Else
                    rpt.rdReportes.PrintToPrinter(2, False, 1, 100)
                End If
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If
    End Sub

    Public Sub Comanda_Santina(ByVal IdComanda As String, ByVal rpt As frmReportes, ByVal Sistema As String, ByVal Empresa As String, Optional ImpresionDirecta As Boolean = False)
        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Comanda_" & Empresa.ToUpper & ".rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try

                rpt.rdReportes.SetParameterValue("@IdComanda", IdComanda)

                If ImpresionDirecta = False Then
                    rpt.Show()
                Else
                    rpt.rdReportes.PrintToPrinter(1, False, 1, 100)
                End If

            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
                '    Finally
                Utiles.filtradopor = ""
            End Try
        End If
    End Sub

    Public Sub CierreCaja_Santina(ByVal rpt As frmReportes, ByVal Sistema As String)
        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_CierreCaja.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If
    End Sub

    Public Sub Stock_RubroySubrubro_App(ByVal Rubro As String, ByVal Subrubro As String, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Stock_porRubroySubrubro.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Idfamilia", Rubro)
                rpt.rdReportes.SetParameterValue("@IdSubrubro", Subrubro)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub Stock_FiltroPersonalizado_App(ByVal filtro As String, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Stock_FiltroPersonalizado.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Busqueda", filtro)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub Ajustes_Maestro_App(ByVal codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String)
        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Maestro_Ajustes.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@codigo", codigo)

                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub Stock_Actual_Valorizado_App(ByVal Rubro As String, ByVal Subrubro As String, ByVal rpt As frmReportes, ByVal Sistema As String)
        Dim nbrereporte As String

        nbrereporte = Sistema & "_Stock_Actual_Valorizado.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Idfamilia", Rubro)
                rpt.rdReportes.SetParameterValue("@IdSubrubro", Subrubro)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If

    End Sub

    Public Sub RemitosDuplicados_App(ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String '= "ACER_RemitosDuplicados.rpt"

        nbrereporte = Sistema & "_RemitosDuplicados.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    'Public Sub HistoriaPresupuestos_App(ByVal inicio As Date, ByVal fin As Date, ByVal Cliente As String, ByVal Cancelado As String, ByVal rpt As frmReportes, ByVal Sistema As String)

    '    Dim nbrereporte As String

    '    nbrereporte = Sistema + "_HistoriaPresupuestos.rpt"

    '    If (LoguearReporte(rpt, nbrereporte)) Then
    '        Try
    '            rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
    '            rpt.rdReportes.SetParameterValue("@Desde", inicio)
    '            rpt.rdReportes.SetParameterValue("@Hasta", fin)
    '            rpt.rdReportes.SetParameterValue("@Cliente", Cliente)
    '            rpt.rdReportes.SetParameterValue("@Cancelada", Cancelado)
    '            rpt.Show()
    '        Catch ex As Exception
    '            Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
    '        Finally
    '            Utiles.filtradopor = ""
    '        End Try

    '    End If
    'End Sub

    Public Sub RankingProductosPresupuestados_App(ByVal inicio As Date, ByVal fin As Date, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = Sistema & "_RankingProductosPresupuestados.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub RankingProductosVendidos_App(ByVal inicio As Date, ByVal fin As Date, ByVal Cliente As String, ByVal rpt As frmReportes, ByVal Sistema As String, ByVal Moneda As String)
        Dim nbrereporte As String = Sistema & "_RankingProductosVendidos.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.rdReportes.SetParameterValue("@Cliente", Cliente)
                rpt.rdReportes.SetParameterValue("@Moneda", Moneda)


                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub HistorialdeFacturas_App(ByVal inicio As Date, ByVal fin As Date, ByVal Cliente As String, ByVal Cancelada As String, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = "" '"ACER_HistorialdeFacturas.rpt"

        nbrereporte = Sistema & "_HistorialdeFacturas.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.rdReportes.SetParameterValue("@Cliente", Cliente)
                rpt.rdReportes.SetParameterValue("@Cancelada", Cancelada)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub HistorialdeComandas_App(ByVal inicio As Date, ByVal fin As Date, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = "" '"ACER_HistorialdeFacturas.rpt"

        nbrereporte = Sistema & "_HistorialdeComandas.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub Gastos_App(ByVal inicio As Date, ByVal fin As Date, ByVal Cliente As String, ByVal Gasto As String, ByVal Cancelado As String, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = Sistema & "_Gastos.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.rdReportes.SetParameterValue("@Proveedor", Cliente)
                rpt.rdReportes.SetParameterValue("@TipoGasto", Gasto)
                rpt.rdReportes.SetParameterValue("@Cancelado", Cancelado)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub GastosTipos_App(ByVal inicio As Date, ByVal fin As Date, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = Sistema & "_Gastos_Tipo.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub GastosProveedores_App(ByVal inicio As Date, ByVal fin As Date, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = Sistema & "_Gastos_Proveedores.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub DeudaClientes_App(ByVal inicio As Date, ByVal fin As Date, ByVal Cliente As String, ByVal Estado As String, ByVal rpt As frmReportes, ByVal Sistema As String, ByVal Resumen As Boolean)

        Dim nbrereporte As String = "" 'Sistema & "_DeudaClientes.rpt"

        If Sistema = "CAMELIAS" Then
            nbrereporte = Sistema & "_DeudaFranquicias.rpt"
        Else
            If Resumen = True Then
                nbrereporte = Sistema & "_ResumenCuenta.rpt"
            Else
                nbrereporte = Sistema & "_DeudaClientes.rpt"
            End If

        End If

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.rdReportes.SetParameterValue("@Cliente", Cliente)
                rpt.rdReportes.SetParameterValue("@Estado", Estado)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub DeudaClientes_CENPROFAR(ByVal inicio As Date, ByVal fin As Date, ByVal Cliente As String, ByVal Estado As String, ByVal Repartidor As String, ByVal rpt As frmReportes, ByVal Sistema As String, ByVal Resumen As Boolean)

        Dim nbrereporte As String = "" 'Sistema & "_DeudaClientes.rpt"

        If Sistema = "CAMELIAS" Then
            nbrereporte = Sistema & "_DeudaFranquicias.rpt"
        Else
            If Resumen = True Then
                nbrereporte = Sistema & "_ResumenCuenta.rpt"
            Else
                nbrereporte = Sistema & "_DeudaClientes.rpt"
            End If

        End If

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.rdReportes.SetParameterValue("@Repartidor", Repartidor)
                rpt.rdReportes.SetParameterValue("@Cliente", Cliente)
                rpt.rdReportes.SetParameterValue("@Estado", Estado)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub InformeGeneral_CENPROFAR(ByVal inicio As Date, ByVal fin As Date, ByVal rpt As frmReportes)

        Dim nbrereporte As String = "" 'Sistema & "_DeudaClientes.rpt"

        nbrereporte = "CENPROFAR_InformeGral.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub HistoriaProducto_App(ByVal codigoProducto As String, ByVal rpt As frmReportes, ByVal Formulario As String, ByVal Sistema As String)
        Dim nbrereporte As String

        If Formulario = "Presupuestos" Or Formulario = "OrdenDeCompra" Then
            nbrereporte = Sistema & "_BuscarProductos.rpt"
        Else
            nbrereporte = Sistema & "_BuscarProductosRecepciones.rpt"
        End If

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.SetParameterValue("@codigo", codigoProducto)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If

    End Sub

    Public Sub Consolidaciones_App(ByVal Codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_ConsolidacionHS.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@CodigoConsolidado", Codigo)
                'rpt.rdReportes.SetParameterValue("@Inicio", inicio)
                'rpt.rdReportes.SetParameterValue("@Fin", fin)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub TarjetasAcceso_App(ByVal codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Tarjeta.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@DNI", codigo)

                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub PagodeClientes_App(ByVal codigo As String, ByVal reporte_factura As frmReportes, ByVal Sistema As String)
        Dim nbrereporte As String

        nbrereporte = Sistema & "_PagodeClientes.rpt"

        If (LoguearReporte(reporte_factura, nbrereporte)) Then
            Try
                reporte_factura.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                reporte_factura.rdReportes.SetParameterValue("@idmov", codigo)
                reporte_factura.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If
    End Sub

    Public Sub MostrarReporte_PagodeClientes(ByVal codigo As String, ByVal reporte_factura As frmReportes)
        Dim nbrereporte As String

        nbrereporte = "ACER_PagodeClientes.rpt"

        If (LoguearReporte(reporte_factura, nbrereporte)) Then
            Try
                reporte_factura.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                reporte_factura.rdReportes.SetParameterValue("@idmov", codigo)
                reporte_factura.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If
    End Sub

    Public Sub GastosVencidosPorVencer_App(ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = Sistema & "_GastoVencidos_porVencer.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

#End Region

#Region "ACER"

    Public Sub MostrarReporte_VentaConsumo(ByVal idpresupuesto As String, ByVal OCA_Vacia As Boolean, ByVal reporte_Presupuesto As frmReportes)
        Dim nbrereporte As String

        'nbrereporte = "ACER_VentaConsumo.rpt"
        If OCA_Vacia = True Then
            nbrereporte = "ACER_Presupuesto_OCA_Vacia.rpt"
        Else
            nbrereporte = "ACER_Presupuesto_OCA.rpt"
        End If

        If (LoguearReporte(reporte_Presupuesto, nbrereporte)) Then
            Try
                reporte_Presupuesto.rdReportes.SetParameterValue("@id", idpresupuesto)
                reporte_Presupuesto.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If
    End Sub

    Public Sub Facturacion_Sobre(ByVal codigo As String, ByVal reporte_factura As frmReportes, ByVal Sistema As String)
        Dim nbrereporte As String

        nbrereporte = Sistema & "_Sobre.rpt"

        If (LoguearReporte(reporte_factura, nbrereporte)) Then
            Try
                'reporte_factura.rdReportes.ParameterFields.Clear()
                reporte_factura.rdReportes.SetParameterValue("@codigo", codigo)
                reporte_factura.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If
    End Sub

    Public Sub PagoaProveedores_App(ByVal codigo As String, ByVal reporte_factura As frmReportes, ByVal Sistema As String)
        Dim nbrereporte As String

        nbrereporte = Sistema & "_PagoaProveedores.rpt"

        If (LoguearReporte(reporte_factura, nbrereporte)) Then
            Try
                reporte_factura.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                reporte_factura.rdReportes.SetParameterValue("@idmov", codigo)
                reporte_factura.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If
    End Sub

    Public Sub ACER_InformeRetenciones(ByVal inicio As Date, ByVal fin As Date, ByVal Cliente As String, ByVal rpt As frmReportes)
        Dim nbrereporte As String = "ACER_Retenciones.rpt"
        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.rdReportes.SetParameterValue("@Cliente", Cliente)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub ACER_InformeImpuestos(ByVal inicio As Date, ByVal fin As Date, ByVal Cliente As String, ByVal rpt As frmReportes)
        Dim nbrereporte As String = "ACER_InformeImpuestos.rpt"
        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.rdReportes.SetParameterValue("@Cliente", Cliente)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub ACER_HistoriaPresupuestos(ByVal inicio As Date, ByVal fin As Date, ByVal Cliente As String, ByVal rpt As frmReportes)
        Dim nbrereporte As String = "ACER_HistoriaPresupuestos.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.rdReportes.SetParameterValue("@Cliente", Cliente)
                'rpt.rdReportes.SetParameterValue("@Cancelada", Cancelado)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub ACER_Stock201314(ByVal filtro As String, ByVal rpt As frmReportes)
        Dim nbrereporte As String = "ACER_Stock2014.rpt"
        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Busqueda", filtro)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

#End Region

#Region "SEI"

    Public Sub MostrarEtiquetaMaterial(ByVal codigo As String, ByVal rpt As frmReportes)

        Dim nbrereporte As String = ""

        nbrereporte = "SEI_EtiquetaMaterial.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                'rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@codigo_material", codigo)
                'rpt.rdReportes.SetParameterValue("@codigo_almacen", codigoalmacen)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            End Try
        End If
    End Sub

    Public Sub SEI_OfertaComercial(ByVal idpresupuesto As String, ByVal rpt As frmReportes, ByVal ManoObra As Boolean)
        Dim nbrereporte As String

        If ManoObra = False Then
            nbrereporte = "SEI_Presupuesto_OfertaComercial.rpt"
        Else
            nbrereporte = "SEI_Presupuesto_ManoObra.rpt"
        End If

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.SetParameterValue("@id", idpresupuesto)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If

    End Sub

    Public Sub BIANCO_OfertaComercial(ByVal idpresupuesto As String, ByVal rpt As frmReportes, ByVal ManoObra As Boolean)
        Dim nbrereporte As String

        If ManoObra = False Then
            nbrereporte = "BIANCO_Presupuesto_OfertaComercial.rpt"
        Else
            nbrereporte = "BIANCO_Presupuesto_ManoObra.rpt"
        End If

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.SetParameterValue("@id", idpresupuesto)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If

    End Sub

    Public Sub SEI_Trafos(ByVal idpresupuesto As String, ByVal rpt As frmReportes)
        Dim nbrereporte As String

        nbrereporte = "SEI_Presupuesto_Trafo.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.SetParameterValue("@id", idpresupuesto)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If

    End Sub

    Public Sub SEI_Trafos_Ensayos(ByVal idpresupuesto As String, ByVal rpt As frmReportes)
        Dim nbrereporte As String

        nbrereporte = "SEI_Presupuesto_Trafo_Ensayos.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.SetParameterValue("@codigo", idpresupuesto)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If

    End Sub

    Public Sub HistoriaPresupuestos_APP(ByVal inicio As Date, ByVal fin As Date, ByVal Cliente As String, ByVal Estado As String, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String

        nbrereporte = Sistema + "_HistoriaPresupuestos.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.rdReportes.SetParameterValue("@Cliente", Cliente)
                rpt.rdReportes.SetParameterValue("@Estado", Estado)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub SEI_Devoluciones_Remito(ByVal codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Devoluciones.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.SetParameterValue("@codigo", codigo)
                rpt.Show()

            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub SEI_MaquinasHerramientas_SGI(ByVal rpt As frmReportes)
        Dim nbrereporte As String

        nbrereporte = "SEI_MaquinasHerramientasSGI.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                'rpt.rdReportes.SetParameterValue("@id", idpresupuesto)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If

    End Sub

#End Region

#Region "LAS CAMELIAS"

    Public Sub Remito_Sucursales_Mov(ByVal codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String, ByVal ImprimirRPT As Boolean, ByVal TipoRemito As String)
        Dim nbrereporte As String = ""

        Select Case TipoRemito
            Case "ORIGINAL"
                nbrereporte = Sistema & "_Remito_Sucursales_Mov_ORIGINAL.rpt"
            Case "DUPLICADO"
                nbrereporte = Sistema & "_Remito_Sucursales_Mov_DUPLICADO.rpt"
            Case Else
                nbrereporte = Sistema & "_Remito_Sucursales_Mov_TRIPLICADO.rpt"
        End Select

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.SetParameterValue("@codigo", codigo)
                If ImprimirRPT = True Then
                    rpt.rdReportes.PrintToPrinter(1, False, 1, 100)
                Else
                    rpt.Show()
                End If
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
                Exit Sub
            Finally
                Utiles.filtradopor = ""
            End Try
        End If
    End Sub

    Public Sub DeudaClientes_Camelias(ByVal inicio As Date, ByVal fin As Date, ByVal Cliente As String, ByVal ConsumoDiario As String, ByVal Cancelado As String, ByVal rpt As frmReportes)

        Dim nbrereporte As String = ""

        nbrereporte = "Camelias_DeudaFranquicias.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.rdReportes.SetParameterValue("@Cliente", Cliente)
                rpt.rdReportes.SetParameterValue("@ConsumoDiario", ConsumoDiario)
                rpt.rdReportes.SetParameterValue("@Cancelado", Cancelado)

                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub Franquicias_MovimientosStock_Camelias(ByVal inicio As Date, ByVal fin As Date, ByVal Cliente As String, ByVal rpt As frmReportes)

        Dim nbrereporte As String = ""

        nbrereporte = "CAMELIAS_Sucursales_Mov.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Desde", inicio)
                rpt.rdReportes.SetParameterValue("@Hasta", fin)
                rpt.rdReportes.SetParameterValue("@Franquicia", Cliente)

                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub Ajustes_Camelias(ByVal codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String)
        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Ajustes_Stock_Detallado.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@codigo", codigo)

                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub ListadoProductoTipo_Camelias(ByVal Tipo As String, ByVal rpt As frmReportes)

        Dim nbrereporte As String = ""

        nbrereporte = "CAMELIAS_MaterialesporTipo.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@ConsumoDiario", Tipo)

                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

#End Region

#Region "CARTOCOR"

    Public Sub MostrarPlanillaPesadas(ByVal codigo As String, ByVal NroPesada As Integer, ByVal rpt As frmReportes)

        Dim nbrereporte As String = ""

        nbrereporte = "CONVERFLEX_Informe.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Id", codigo)
                rpt.rdReportes.SetParameterValue("@NroPesada", NroPesada)
                'rpt.Show()
                rpt.rdReportes.PrintToPrinter(1, False, 1, 100)
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            End Try
        End If
    End Sub

    Public Sub ImprimirEtiqueta(ByVal codigo As String, ByVal NroBobina As Integer, ByVal NroPesada As Integer, ByVal TipoProducto As String, ByVal rpt As frmReportes)

        Dim nbrereporte As String = ""

        nbrereporte = "CONVERFLEX_Etiqueta" & TipoProducto & ".rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.SetParameterValue("@Id", codigo)
                rpt.rdReportes.SetParameterValue("@NroBobina", NroBobina)
                rpt.rdReportes.SetParameterValue("@NroPesada", NroPesada)
                rpt.rdReportes.PrintToPrinter(1, False, 1, 100)

                'rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            End Try
        End If
    End Sub

#End Region

#Region "Clinica"

    Public Sub HistoriaClinica(ByVal idPaciente As String, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_HistoriaClinica.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@IdPaciente", idPaciente)

                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub Embarazadas(ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = ""

        nbrereporte = Sistema & "_Embarazadas.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

    Public Sub ListadodeTurnos(ByVal Profesional As String, ByVal Fecha As Date, ByVal rpt As frmReportes, ByVal Sistema As String)

        Dim nbrereporte As String = Sistema & "_ListadoTurnos.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Profesional", Profesional)
                rpt.rdReportes.SetParameterValue("@Fecha", Fecha)
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

#End Region

#Region "Propiedades"

    Public Sub Propiedades_Expensas(ByVal CodEdificio As Integer, ByVal Periodo As String, ByVal Todos As Boolean, ByVal Particular As Boolean, ByVal PH As String, ByVal Desde As Integer, ByVal Hasta As Integer, ByVal rpt As frmReportes)

        Dim nbrereporte As String = ""

        nbrereporte = "PROPIEDADES_Expensas.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@CodEdificio", CodEdificio)
                rpt.rdReportes.SetParameterValue("@Periodo", Periodo)
                rpt.rdReportes.SetParameterValue("@Todos", Todos)
                rpt.rdReportes.SetParameterValue("@Particular", Particular)
                rpt.rdReportes.SetParameterValue("@PH", PH)
                rpt.rdReportes.SetParameterValue("@Desde", Desde)
                rpt.rdReportes.SetParameterValue("@Hasta", Hasta)
                'rpt.ExportToPDF_Propiedades("")
                rpt.Show()
                'rpt.rdReportes.PrintToPrinter(1, False, 1, 100)
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            End Try
        End If
    End Sub

    Public Sub Propiedades_Expensas_paraCorreo(ByVal Edificio As String, ByVal Depto As String, ByVal CodEdificio As Integer, ByVal Periodo As String, ByVal Todos As Boolean, ByVal Particular As Boolean, ByVal PH As String, ByVal Desde As Integer, ByVal Hasta As Integer, ByVal rpt As frmReportes)

        Dim nbrereporte As String = ""

        nbrereporte = "PROPIEDADES_Expensas.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@CodEdificio", CodEdificio)
                rpt.rdReportes.SetParameterValue("@Periodo", Periodo)
                rpt.rdReportes.SetParameterValue("@Todos", Todos)
                rpt.rdReportes.SetParameterValue("@Particular", Particular)
                rpt.rdReportes.SetParameterValue("@PH", PH)
                rpt.rdReportes.SetParameterValue("@Desde", Desde)
                rpt.rdReportes.SetParameterValue("@Hasta", Hasta)
                rpt.ExportToPDF_Propiedades(Edificio + "-" + Depto)
                'rpt.Show()
                'rpt.rdReportes.PrintToPrinter(1, False, 1, 100)
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            End Try
        End If
    End Sub

    Public Sub Propiedades_ExpensasPago(ByVal CodDepto As Integer, ByVal Periodo As String, ByVal Letras As String, ByVal rpt As frmReportes)

        Dim nbrereporte As String = ""

        nbrereporte = "PROPIEDADES_PagoExpensa.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@CodDepto", CodDepto)
                rpt.rdReportes.SetParameterValue("@Periodo", Periodo)
                rpt.rdReportes.SetParameterValue("@Letras", Letras)

                rpt.Show()
                'rpt.rdReportes.PrintToPrinter(1, False, 1, 100)
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            End Try
        End If
    End Sub

    Public Sub Propiedades_Alquileres(ByVal CodPago As Integer, ByVal Letras As String, ByVal Monto As Double, ByVal Tipo As String, ByVal Destino As Boolean, ByVal rpt As frmReportes)

        Dim nbrereporte As String = ""

        nbrereporte = "PROPIEDADES_CobroAlquiler.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try

                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@CodPago", CodPago)
                rpt.rdReportes.SetParameterValue("@Letras", Letras)
                rpt.rdReportes.SetParameterValue("@Monto", Monto)
                rpt.rdReportes.SetParameterValue("@Tipo", Tipo)

                If Destino = True Then
                    rpt.Show()
                Else
                    rpt.rdReportes.PrintToPrinter(1, False, 1, 100)
                End If

            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            End Try
        End If
    End Sub

    Public Sub Propiedades_Listado(ByVal Tipo As String, ByVal rpt As frmReportes)

        Dim nbrereporte As String = ""

        nbrereporte = "PROPIEDADES_Propiedades.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try

                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Tipo", Tipo)

                rpt.Show()

            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            End Try
        End If
    End Sub

    Public Sub Propiedades_DepartamentosporEdificio(ByVal Tipo As String, ByVal rpt As frmReportes)

        Dim nbrereporte As String = ""

        nbrereporte = "PROPIEDADES_DepartamentosporEdificio.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try

                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Edificio", Tipo)

                rpt.Show()

            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            End Try
        End If
    End Sub

    Public Sub Propiedades_Alquileres_Listado(ByVal rpt As frmReportes)

        Dim nbrereporte As String = ""

        nbrereporte = "PROPIEDADES_Alquileres_Listado.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try

                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.Show()

            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            End Try
        End If
    End Sub

#End Region

#Region "ROCHA"

    Public Sub Rocha_RetiroContenedores(ByVal rpt As frmReportes)

        Dim nbrereporte As String = ""

        nbrereporte = "ROCHA_RetiroContenedores.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.Show()
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            End Try
        End If
    End Sub

#End Region

#Region "SAMBA"

    Public Sub Distribuciones(Codigo As String, ByVal rpt As frmReportes, ByVal Sistema As String, ByVal Tipo As String)

        Dim nbrereporte As String = Sistema & "_Distribuciones.rpt"

        If (LoguearReporte(rpt, nbrereporte)) Then
            Try
                rpt.rdReportes.DataDefinition.FormulaFields("filtradopor").Text = Utiles.filtradopor
                rpt.rdReportes.SetParameterValue("@Codigo", Codigo)
                If Tipo = "Mostrar" Then
                    rpt.Show()
                End If
            Catch ex As Exception
                Utiles.ControladorDeExepcionesReportes(ex, nbrereporte)
            Finally
                Utiles.filtradopor = ""
            End Try

        End If
    End Sub

#End Region

End Class