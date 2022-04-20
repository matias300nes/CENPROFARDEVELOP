Imports System.Globalization
Imports System.IO
Imports Microsoft.ApplicationBlocks.Data
Imports Utiles.Util

Public Class frmGenerarTxtPrescam
    Enum ColumnasDelGridItems
        ''NACHO
        ID = 0
        IdFarmacia = 1
        CodigoFarmacia = 2
        Nombre = 3
        IdPlan = 4
        Plan = 5
        IdPresentacion = 6
        Recetas = 7
        Recaudado = 8
        ACargoOS = 9
        Bonificacion = 10
        Total = 11
        CodFacaf = 12
        CodPlan = 13
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
            row2("DisplayMember") = "1° QUINCENA"
            row2("ValueMember") = "1"
            .Rows.Add(row2)

            Dim row3 As DataRow = .NewRow()
            row3("DisplayMember") = "2° QUINCENA"
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


        Dim StrFileInformes As String
        Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "txt files (*.txt)|*.txt"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        'variables para el txt
        Dim obraSocial = frmPresentaciones.cmbObraSocial.Text
        Dim Periodo = cmbPeriodo.SelectedValue
        Dim codPlanSinCero
        Dim recetas, impTot, impACargoOs As Decimal
        Dim strRecetas, strImpTot, strImpACargoOs As String


        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            myStream = saveFileDialog1.OpenFile()
            StrFileInformes = saveFileDialog1.FileName
            myStream.Close()
            Dim objStreamWriter As New StreamWriter(StrFileInformes) 'Pass the file path and the file name to the StreamWriter constructor.
            If (myStream IsNot Nothing) Then

                For Each grdrow As DataGridViewRow In frmPresentaciones.grdItems.Rows
                    'Conversiones
                    codPlanSinCero = grdrow.Cells(ColumnasDelGridItems.CodPlan).Value
                    codPlanSinCero = Integer.Parse(codPlanSinCero)
                    recetas = grdrow.Cells(ColumnasDelGridItems.Recetas).Value
                    strRecetas = Format(Integer.Parse(recetas), "000000")
                    impTot = grdrow.Cells(ColumnasDelGridItems.Recaudado).Value
                    impTot = Integer.Parse(impTot, NumberStyles.AllowDecimalPoint)
                    strImpTot = Format(impTot, "000000000000")
                    impACargoOs = grdrow.Cells(ColumnasDelGridItems.ACargoOS).Value
                    impACargoOs = Integer.Parse(impACargoOs, NumberStyles.AllowDecimalPoint)
                    strImpACargoOs = Format(impACargoOs, "000000000000")

                    'Armado de txt
                    objStreamWriter.WriteLine($"{grdrow.Cells(ColumnasDelGridItems.CodFacaf).Value}{grdrow.Cells(ColumnasDelGridItems.CodPlan).Value}{obraSocial}                       {codPlanSinCero}{grdrow.Cells(ColumnasDelGridItems.Plan).Value}             000000{(Periodo.ToString + txtAAMM.Text)}{grdrow.Cells(ColumnasDelGridItems.Nombre).Value}                                    000016Centro de Prop.de Farmacias V.MERC.               {strRecetas}{strImpTot}{strImpACargoOs}")
                    objStreamWriter.WriteLine()
                Next

                'Close the file.
                objStreamWriter.Close()

                'myStream.Close()
            End If
        End If




    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

    End Sub
End Class