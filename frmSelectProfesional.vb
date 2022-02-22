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

Public Class frmSelectProfesional

    Dim dtConceptos_Created As Boolean
    Dim count As Integer = 0
    Enum ColumnasDelGrdConceptos
        Id = 0
        Codigo = 1
        Nombre = 2
        Descripcion = 3
        ConceptoPago = 4
        PerteneceA = 5
        TipoDeValor = 6
        Valor = 7
        CampoAplicable = 8
    End Enum

    Enum ColumnasDelGrdProfesionales
        Id = 0
        Codigo = 1
        Nombre = 2
        Apellido = 3
        Direccion = 4
        Celular = 5
        Email = 6
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
            Dim Sql = $"exec spProfesionales_Select_All @eliminado = 0"

            Dim cmd As New SqlCommand(Sql, connection)
            Dim da As New SqlDataAdapter(cmd)

            da.Fill(dtConceptos)

            grdProfesionales.DataSource = dtConceptos
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
    End Sub

    Private Sub btnListo_Click(sender As Object, e As EventArgs) Handles btnListo.Click

        If ReglasNegocio() Then

            If grdProfesionales.CurrentRow IsNot Nothing Then
                ''Llenado de grdConceptosPanel
                With grdProfesionales.CurrentRow

                    Dim id = .Cells(ColumnasDelGrdProfesionales.Id).Value
                    Dim codigo = IIf(.Cells(ColumnasDelGrdProfesionales.Codigo).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdProfesionales.Codigo).Value)
                    Dim nombre = IIf(.Cells(ColumnasDelGrdProfesionales.Nombre).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdProfesionales.Nombre).Value)
                    Dim apellido = IIf(.Cells(ColumnasDelGrdProfesionales.Apellido).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdProfesionales.Apellido).Value)
                    Dim direccion = IIf(.Cells(ColumnasDelGrdProfesionales.Direccion).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdProfesionales.Direccion).Value)
                    Dim celular = IIf(.Cells(ColumnasDelGrdProfesionales.Celular).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdProfesionales.Celular).Value)
                    Dim email = IIf(.Cells(ColumnasDelGrdProfesionales.Email).Value Is DBNull.Value, "", .Cells(ColumnasDelGrdProfesionales.Email).Value)

                    frmFarmacias_Conceptos.grdProfesionalesPanel.Rows.Add(id, codigo, nombre, apellido, direccion, celular, email)
                End With


                Me.Dispose()
                Me.Close()

            Else
                MsgBox("Seleccione un profesional para poder continuar.")
            End If

        End If



    End Sub


End Class