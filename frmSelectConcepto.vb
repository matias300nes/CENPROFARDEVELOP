﻿Imports Microsoft.ApplicationBlocks.Data
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

Public Class frmSelectConcepto

    Enum GridCols
        ID = 0
        Codigo = 1
        Fecha = 2
        IdObraSocial = 3
        ObraSocial = 4
        Periodo = 5
        Estado = 6
        Total = 7
        Observaciones = 8
    End Enum

    Private Sub LlenarGrilla()
        Dim dtPresentaciones As New DataTable
        Dim connection = Nothing
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
            ''Detalle de liquidacion
            Dim Sql = $"exec spConceptos_Select_Valor @eliminado = 0"

            Dim cmd As New SqlCommand(Sql, connection)
            Dim da As New SqlDataAdapter(cmd)

            da.Fill(dtPresentaciones)

            grdConceptos.DataSource = dtPresentaciones
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
        If grdConceptos.CurrentRow IsNot Nothing Then
            ''Llenado de labels en frmLiquidaciones
            With grdConceptos.CurrentRow
                frmLiquidaciones.txtIdPresentacion.Text = .Cells(GridCols.ID).Value
                frmLiquidaciones.lblPresentacionCodigo.Text = IIf(.Cells(GridCols.Codigo).Value Is DBNull.Value, "", .Cells(GridCols.Codigo).Value)
                frmLiquidaciones.lblObraSocial.Text = IIf(.Cells(GridCols.ObraSocial).Value Is DBNull.Value, "", .Cells(GridCols.ObraSocial).Value)
                frmLiquidaciones.lblObservacion.Text = IIf(.Cells(GridCols.Observaciones).Value Is DBNull.Value, "", .Cells(GridCols.Observaciones).Value)
                frmLiquidaciones.lblPeriodo_presentacion.Text = IIf(.Cells(GridCols.Periodo).Value Is DBNull.Value, "", .Cells(GridCols.Periodo).Value)
                frmLiquidaciones.lblFecha_presentacion.Text = IIf(.Cells(GridCols.Fecha).Value Is DBNull.Value, "", .Cells(GridCols.Fecha).Value)
                frmLiquidaciones.lblStatus.Text = IIf(.Cells(GridCols.Estado).Value Is DBNull.Value, "", .Cells(GridCols.Estado).Value)
                frmLiquidaciones.btnExcelWindow.Enabled = True
                frmLiquidaciones.btnLiquidar.Enabled = True
                Dim sqlDetalle As String
                Dim sqlConceptos As String

                'sqlDetalle = $"exec spNuevaLiquidacionDetalle_Select @agrupado = {chkAgrupar.Checked}, @idpresentacion = { .Cells(GridCols.ID).Value}"
                'sqlConceptos = $"exec spNuevaLiquidacionConceptos_Select @agrupado = {chkAgrupar.Checked}, @idpresentacion = { .Cells(GridCols.ID).Value}"
                sqlConceptos = Nothing

                frmLiquidaciones.Presentacion_request(sqlDetalle, sqlConceptos)
            End With

            Me.Dispose()
            Me.Close()
        Else
            MsgBox("Seleccione una presentación para poder continuar.")
        End If
    End Sub

    Private Sub chkAgrupar_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs)
        LlenarGrilla()
    End Sub

    'Private Sub grdPresentaciones_SelectionChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grdPresentaciones.SelectionChanged
    '    Dim connection As SqlClient.SqlConnection = Nothing
    '    Dim ds As Data.DataSet

    '    Try
    '        connection = SqlHelper.GetConnection(ConnStringSEI)
    '    Catch ex As Exception
    '        MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Sub
    '    End Try

    '    Try

    '        ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, " select distinct [estado] as Estado from Presentaciones where estado = 'PRESENTADO' or estado = 'PAGO PARCIAL'")
    '        ds.Dispose()

    '        With Me.cmbEstado
    '            .DataSource = ds.Tables(0).DefaultView
    '            .DisplayMember = "estado"
    '            '.ValueMember = "ID"
    '            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '            .AutoCompleteSource = AutoCompleteSource.ListItems
    '            '.SelectedIndex = "ID"
    '        End With

    '    Catch ex As Exception
    '        Dim errMessage As String = ""
    '        Dim tempException As Exception = ex

    '        While (Not tempException Is Nothing)
    '            errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
    '            tempException = tempException.InnerException
    '        End While

    '        MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
    '          + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
    '          "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        If Not connection Is Nothing Then
    '            CType(connection, IDisposable).Dispose()
    '        End If
    '    End Try
    'End Sub
End Class