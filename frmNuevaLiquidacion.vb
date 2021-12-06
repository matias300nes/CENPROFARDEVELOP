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

Public Class frmNuevaLiquidacion

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
            Dim Sql = $"exec spPresentaciones_Select_All @estado = 'PENDIENTES', @eliminado = 0"

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
	                            pd.id				as ID,			   -- 0
	                            pd.IdFarmacia		As IdFarmacia,	   -- 1
	                            f.Codigo			AS CodigoFarmacia, -- 2
	                            f.nombre			As Farmacia,       -- 3
	                            null            	As IdLiquidacion,  -- 4
	                            pd.recetas			as Recetas,        -- 5
	                            pd.Recaudado		as Recaudado,	   -- 6
	                            pd.AcargoOS			as 'A Cargo Os',   -- 7
	                            null				as 'Recetas A',	   -- 8
	                            null				as 'Recaudado A',  -- 9
	                            null				as 'A Cargo OS A', -- 10
	                            pd.Bonificacion		as Bonificación	   -- 11
	
                            from Presentaciones_det pd
                            join Farmacias f on f.ID = pd.IdFarmacia
                            where IdPresentacion = { .Cells(GridCols.ID).Value}"

                Dim sqlConceptos = $"select 
		                                null			as ID,
		                                ID				as IdDetalle,
		                                IdFarmacia		as IdFarmacia,
		                                'A Cargo OS'	as detalle,
		                                AcargoOS		as valor,
                                        'insert'         as estado

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