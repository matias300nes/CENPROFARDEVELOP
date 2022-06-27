Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports Microsoft.ApplicationBlocks.Data
Imports Utiles.Util

Public Class frmGenerarTxtPrescam
    Enum ColumnasDelGridItems
        ''NACHO
        'ID = 0
        'IdFarmacia = 1
        'CodigoFarmacia = 2
        'Nombre = 3
        'IdPlan = 4
        'Plan = 5
        'IdPresentacion = 6
        'Recetas = 7
        'Recaudado = 8
        'ACargoOS = 9
        'Bonificacion = 10
        'Total = 11
        'CodFacaf_Farm = 12
        'CodPlan = 13
        'PorcenPlan = 14
        ID = 0
        IdFarmacia = 1
        CodigoFarmacia = 2
        Nombre = 3
        IdPlan = 4
        Plan = 5
        Observacion = 6
        mensajeWeb = 7
        IdPresentacion = 8
        Recetas = 9
        Recaudado = 10
        ACargoOS = 11
        Bonificacion = 12
        Total = 13
        CodFacaf_Farm = 14
        CodPlan = 15
        PorcenPlan = 16
        'CodPlan = 14
        'PorcenPlan = 13
    End Enum


    'Dim farmacias As DataTable
    'Dim dt As DataTable

    'Public Sub New(farmacias As DataTable)

    '    ' Esta llamada es exigida por el diseñador.
    '    InitializeComponent()

    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    '    Me.farmacias = farmacias

    'End Sub

    Private Sub frmAgregarCheques_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dtPeriodo As New DataTable
        With dtPeriodo
            .Columns.Add("DisplayMember")
            .Columns.Add("ValueMember")

            Dim row1 As DataRow = .NewRow()
            row1("DisplayMember") = "MENSUAL"
            row1("ValueMember") = "0"
            .Rows.Add(row1)

            Dim row2 As DataRow = .NewRow()
            row2("DisplayMember") = "1° Q"
            row2("ValueMember") = "1"
            .Rows.Add(row2)

            Dim row3 As DataRow = .NewRow()
            row3("DisplayMember") = "2° Q"
            row3("ValueMember") = "2"
            .Rows.Add(row3)
        End With

        With cmbPeriodo
            .DataSource = dtPeriodo
            .DisplayMember = "DisplayMember"
            .ValueMember = "ValueMember"
        End With

    End Sub

    Private Sub btnListo_Click(sender As Object, e As EventArgs) Handles btnListo.Click

        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet
        Dim idObrasSocial = frmPresentaciones.cmbObraSocial.SelectedValue

        'variables para el txt
        Dim obraSocial = frmPresentaciones.cmbObraSocial.Text
        Dim Periodo = cmbPeriodo.SelectedValue
        Dim codPlan, nombrePlan, porcentajePlan, CodFacaf_OS
        Dim recetas, impTot, impACargoOs As Decimal
        Dim strRecetas, strImpTot, strImpACargoOs, strporcentajePlan, strCodPlan, farmacia, centroFarmacias,
        mes, año, strPeriodo As String

        Dim StrFileInformes As String
        Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, $"SELECT CodFacaf AS 'CodFacaf_OS' FROM ObrasSociales WHERE id = {idObrasSocial}")
        CodFacaf_OS = ds.Tables(0).Rows(0).Item(0).ToString
        ds.Dispose()

        'Obra Social - Mes  Año
        'Obra Social - Quincena Mes Año

        mes = getMes(txtAAMM.Text)
        año = getAño(txtAAMM.Text)
        strPeriodo = IIf(cmbPeriodo.Text = "MENSUAL", "", cmbPeriodo.Text)

        saveFileDialog1.FileName = $"{obraSocial} - {strPeriodo} {mes} {año}"
        saveFileDialog1.Filter = "txt files (*.txt)|*.txt"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        centroFarmacias = "Centro de Prop.de Farmacias V.MERC."

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            myStream = saveFileDialog1.OpenFile()
            StrFileInformes = saveFileDialog1.FileName
            myStream.Close()
            obraSocial = CStr(obraSocial)


            Dim objStreamWriter As New StreamWriter(StrFileInformes) 'Pass the file path and the file name to the StreamWriter constructor.
            If (myStream IsNot Nothing) Then

                For Each grdrow As DataGridViewRow In frmPresentaciones.grdItems.Rows
                    'Conversiones
                    If grdrow.Visible = True Then
                        nombrePlan = grdrow.Cells(ColumnasDelGridItems.Plan).Value
                        farmacia = grdrow.Cells(ColumnasDelGridItems.Nombre).Value

                        codPlan = IIf(grdrow.Cells(ColumnasDelGridItems.CodPlan).Value = "" Or grdrow.Cells(ColumnasDelGridItems.CodPlan).Value Is Nothing, "00", grdrow.Cells(ColumnasDelGridItems.CodPlan).Value)
                        codPlan = Integer.Parse(codPlan, NumberStyles.AllowDecimalPoint)
                        strCodPlan = Format(codPlan, "00")

                        porcentajePlan = IIf(grdrow.Cells(ColumnasDelGridItems.PorcenPlan).Value = "" Or grdrow.Cells(ColumnasDelGridItems.PorcenPlan).Value Is Nothing, "00", grdrow.Cells(ColumnasDelGridItems.PorcenPlan).Value)
                        porcentajePlan = porcentajePlan * 100
                        porcentajePlan = Decimal.Parse(porcentajePlan, NumberStyles.AllowThousands)
                        strporcentajePlan = Format(porcentajePlan, "000000")

                        recetas = grdrow.Cells(ColumnasDelGridItems.Recetas).Value
                        strRecetas = Format(Integer.Parse(recetas), "000000")

                        impTot = grdrow.Cells(ColumnasDelGridItems.Recaudado).Value
                        impTot = impTot * 100
                        impTot = Decimal.Parse(impTot, NumberStyles.AllowDecimalPoint)
                        strImpTot = Format(impTot, "000000000000")

                        impACargoOs = grdrow.Cells(ColumnasDelGridItems.ACargoOS).Value
                        impACargoOs = impACargoOs * 100
                        impACargoOs = Decimal.Parse(impACargoOs, NumberStyles.AllowDecimalPoint)
                        strImpACargoOs = Format(impACargoOs, "000000000000")
                        '                       
                        'Armado de txt
                        objStreamWriter.WriteLine($"{grdrow.Cells(ColumnasDelGridItems.CodFacaf_Farm).Value}{CodFacaf_OS.PadLeft(3)}{obraSocial.PadRight(40)}{strCodPlan}{nombrePlan.PadRight(30)}{strporcentajePlan}{(Periodo.ToString + txtAAMM.Text)}{farmacia.PadRight(40)}000016{centroFarmacias.PadRight(50)}{strRecetas}{strImpTot}{strImpACargoOs}")
                        objStreamWriter.WriteLine()
                    End If
                Next
                MsgBox("Txt generado con éxito!", MsgBoxStyle.Information, "Atención")
                'Close the file.
                objStreamWriter.Close()
                Me.Close()

                'myStream.Close()
            End If
        End If




    End Sub

    Private Function getMes(ByVal periodo As String) As String
        Dim mes, strMes As String
        mes = periodo.Substring(2, 2)

        Select Case mes
            Case "01"
                strMes = "ENERO"
                Return strMes
            Case "02"
                strMes = "FEBRERO"
                Return strMes
            Case "03"
                strMes = "MARZO"
                Return strMes
            Case "04"
                strMes = "ABRIL"
                Return strMes
            Case "05"
                strMes = "MAYO"
                Return strMes
            Case "06"
                strMes = "JUNIO"
                Return strMes
            Case "07"
                strMes = "JULIO"
                Return strMes
            Case "08"
                strMes = "AGOSTO"
                Return strMes
            Case "09"
                strMes = "SEPTIEMBRE"
                Return strMes
            Case "10"
                strMes = "OCTUBRE"
                Return strMes
            Case "11"
                strMes = "NOVIEMBRE"
                Return strMes
            Case "12"
                strMes = "DICIEMBRE"
                Return strMes
        End Select



    End Function

    Private Function getAño(ByVal periodo As String) As String
        Dim año As String
        año = periodo.Substring(0, 2)

        Return "20" + año

    End Function

    Private Sub frmGenerarTxtPrescam_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmPresentaciones.btnActualizar_Click(sender, e)
    End Sub
End Class