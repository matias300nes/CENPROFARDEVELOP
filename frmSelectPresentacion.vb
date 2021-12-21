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

Public Class frmSelectPresentacion

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
            Dim Sql = $"exec spPresentaciones_Select_All @estado = 'PENDIENTE', @eliminado = 0"

            Dim cmd As New SqlCommand(Sql, connection)
            Dim da As New SqlDataAdapter(cmd)

            da.Fill(dtPresentaciones)

            grdPresentaciones.DataSource = dtPresentaciones
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
        If grdPresentaciones.CurrentRow IsNot Nothing Then
            ''Llenado de labels en frmLiquidaciones
            With grdPresentaciones.CurrentRow
                frmLiquidaciones.txtIdPresentacion.Text = .Cells(GridCols.ID).Value
                frmLiquidaciones.lblPresentacionCodigo.Text = IIf(.Cells(GridCols.Codigo).Value Is DBNull.Value, "", .Cells(GridCols.Codigo).Value)
                frmLiquidaciones.lblObraSocial.Text = IIf(.Cells(GridCols.ObraSocial).Value Is DBNull.Value, "", .Cells(GridCols.ObraSocial).Value)
                frmLiquidaciones.lblObservacion.Text = IIf(.Cells(GridCols.Observaciones).Value Is DBNull.Value, "", .Cells(GridCols.Observaciones).Value)
                frmLiquidaciones.lblPeriodo_presentacion.Text = IIf(.Cells(GridCols.Periodo).Value Is DBNull.Value, "", .Cells(GridCols.Periodo).Value)
                frmLiquidaciones.lblFecha_presentacion.Text = IIf(.Cells(GridCols.Fecha).Value Is DBNull.Value, "", .Cells(GridCols.Fecha).Value)
                frmLiquidaciones.lblStatus_presentacion.Text = IIf(.Cells(GridCols.Estado).Value Is DBNull.Value, "", .Cells(GridCols.Estado).Value)

                ''Llenado de items detalle en frmLiquidaciones
                Dim SqlDetalle = $"select
                                null                as IdLiquidacion_det,-- 0
	                            pd.id				as ID,			     -- 1
	                            pd.IdFarmacia		As IdFarmacia,	     -- 2
	                            f.Codigo			AS CodigoFarmacia,   -- 3
	                            f.nombre			As Farmacia,         -- 4
	                            null            	As IdLiquidacion,    -- 5
	                            pd.recetas			as Recetas,          -- 6
	                            pd.Recaudado		as Recaudado,	     -- 7
	                            pd.AcargoOS			as 'A Cargo Os',     -- 8
	                            0.00				as 'Recetas A',	     -- 9
	                            0.00				as 'Recaudado A',    -- 10
	                            0.00				as 'A Cargo OS A',   -- 11
	                            pd.Bonificacion		as Bonificación	     -- 12
	
                            from Presentaciones_det pd
                            join Farmacias f on f.ID = pd.IdFarmacia
                            where IdPresentacion = { .Cells(GridCols.ID).Value}"

                Dim sqlConceptos = $"select 
		                                null			as ID,
		                                ID				as IdDetalle,
		                                IdFarmacia		as IdFarmacia,
		                                'A Cargo OS'	as detalle,
		                                AcargoOS		as valor,
                                        'insert'        as estado,
                                            0           as edit
	                                from Presentaciones_det
	                                where IdPresentacion = { .Cells(GridCols.ID).Value}"

                frmLiquidaciones.Presentacion_request(SqlDetalle, sqlConceptos)
            End With



            Me.Dispose()
            Me.Close()
        Else
            MsgBox("Seleccione una presentación para poder continuar.")
        End If
    End Sub
End Class