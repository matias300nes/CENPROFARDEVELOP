Imports Microsoft.ApplicationBlocks.Data
Imports Utiles
Imports Utiles.Util
Imports System.Data.SqlClient
Imports ReportesNet
Imports System.Data.OleDb
Imports System.IO
Imports ExcelDataReader
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.SuperGrid.Style

Public Class frmSelectPlan

    Dim dtConceptos_Created As Boolean
    Dim count As Integer = 0

    Enum ColumnasDelGrdPlanes
        Id = 0
        Codigo = 1
        Nombre = 2
        Porcentaje = 3
    End Enum
    Protected Function ReglasNegocio() As Boolean
        Dim msg As String
        ReglasNegocio = False

        msg = CamposObligatorios(Me.TableLayoutPanel1.Controls)

        If msg <> "" Then
            Beep()
            MsgBox("Falta completar el campo " & msg)
            Exit Function
        End If

        ReglasNegocio = True
    End Function

    Private Sub LlenarGrilla()
        Dim dtConceptos As New DataTable
        Dim connection = Nothing
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
            ''Detalle de liquidacion
            Dim Sql = $"exec spPlanes_Select_All @eliminado = 0"

            Dim cmd As New SqlCommand(Sql, connection)
            Dim da As New SqlDataAdapter(cmd)

            da.Fill(dtConceptos)

            grdPlanes.DataSource = dtConceptos
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Sub

    Private Sub frmNuevaLiquidacion_Load(sender As Object, e As EventArgs) Handles Me.Load
        LlenarGrilla()

        With grdPlanes
            .Columns(ColumnasDelGrdPlanes.Id).Visible = False
            .AutoResizeColumns()
        End With
    End Sub

    Private Sub btnListo_Click(sender As Object, e As EventArgs) Handles btnListo.Click

        If ReglasNegocio() Then

            If grdPlanes.CurrentRow IsNot Nothing Then
                ''Llenado de grdConceptosPanel
                With grdPlanes.CurrentRow

                    Dim id = .Cells(ColumnasDelGrdPlanes.Id).Value
                    Dim codigo = IIf(.Cells(ColumnasDelGrdPlanes.Codigo).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdPlanes.Codigo).Value)
                    Dim nombre = IIf(.Cells(ColumnasDelGrdPlanes.Nombre).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdPlanes.Nombre).Value)
                    Dim porcentaje = IIf(.Cells(ColumnasDelGrdPlanes.Porcentaje).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdPlanes.Porcentaje).Value)

                    frmObraSocial.grdPlanesPanel.Rows.Add(id, codigo, nombre, porcentaje)
                End With


                Me.Dispose()
                Me.Close()

            Else
                MsgBox("Seleccione un plan para poder continuar.")
            End If

        End If



    End Sub
End Class