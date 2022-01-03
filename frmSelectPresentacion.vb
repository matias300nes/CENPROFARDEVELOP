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
            Dim Sql = $"exec spPresentaciones_Select_All @estado = '{cmbEstado.Text.Replace(" ", "")}', @eliminado = 0"

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

    Private Sub llenarCmbEstados()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, " select distinct [estado] as Estado from Presentaciones where estado = 'PRESENTADO' or estado = 'PAGO PARCIAL'")
            ds.Dispose()

            With Me.cmbEstado
                .DataSource = ds.Tables(0).DefaultView
                .DisplayMember = "estado"
                '.ValueMember = "ID"
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
                '.SelectedIndex = "ID"
            End With

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub frmNuevaLiquidacion_Load(sender As Object, e As EventArgs) Handles Me.Load
        LlenarGrilla()
        llenarCmbEstados()
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
                frmLiquidaciones.chkAgrupado.Checked = chkAgrupar.Checked

                Dim sqlDetalle As String
                Dim sqlConceptos As String

                ''Llenado de items detalle en frmLiquidaciones
                If chkAgrupar.Checked Then
                    sqlDetalle = $"
                        select 
                            null					as IdLiquidacion_det,	-- 0
                            -1						as IdPresentacion_det,	-- 1
                            pd.IdFarmacia			as IdFarmacia,			-- 2
                            ROW_NUMBER() OVER(order by f. nombre) as nº,	-- 3
                            f.Codigo				AS CodigoFarmacia,		-- 4
                            f.nombre				As Farmacia,			-- 5
                            null					As IdLiquidacion,		-- 6
                            sum(pd.recetas)			as Recetas,				-- 7
                            sum(pd.Recaudado)		as Recaudado,			-- 8
                            sum(pd.AcargoOS)		as 'A Cargo Os',		-- 9
                            0.00					as 'Recetas A',			-- 10
                            0.00					as 'Recaudado A',		-- 11
                            0.00					as 'A Cargo OS A',		-- 12
                            sum(pd.Bonificacion)	as Bonificación			-- 13
                        from Presentaciones_det pd
                        join Farmacias f on f.ID = pd.IdFarmacia
                        where pd.IdPresentacion = { .Cells(GridCols.ID).Value}
                        group by			
                            pd.IdFarmacia,
                            f.Codigo,
                            f.nombre
                    "
                    sqlConceptos = $"
                        select 
		                    null				as ID,
		                    ROW_NUMBER() OVER(order by f. nombre)as IdDetalle,
		                    pd.IdFarmacia		as IdFarmacia,
		                    'A Cargo OS'		as detalle,
		                    sum(pd.AcargoOS)	as valor,
                            'insert'			as estado,
                                0				as edit
	                    from Presentaciones_det pd
		                    join Farmacias f on f.ID = pd.IdFarmacia
	                    where pd.IdPresentacion = { .Cells(GridCols.ID).Value}
	                    group by
		                    pd.IdFarmacia,
		                    f.Nombre
                    "
                Else
                    sqlDetalle = $"
                        select
		                        null					as IdLiquidacion_det,	-- 0
		                        pd.ID					as IdPresentacion_det,	-- 1
		                        pd.IdFarmacia			as IdFarmacia,			-- 2
		                        ROW_NUMBER() OVER(order by f. nombre) as nº,	-- 3
		                        f.Codigo				AS CodigoFarmacia,		-- 4
		                        f.nombre				As Farmacia,			-- 5
		                        null					As IdLiquidacion,		-- 6
		                        pd.recetas				as Recetas,				-- 7
		                        pd.Recaudado			as Recaudado,			-- 8
		                        pd.AcargoOS				as 'A Cargo Os',		-- 9
		                        0.00					as 'Recetas A',			-- 10
		                        0.00					as 'Recaudado A',		-- 11
		                        0.00					as 'A Cargo OS A',		-- 12
		                        pd.Bonificacion			as Bonificación			-- 13
	
                        from Presentaciones_det pd
                        join Farmacias f on f.ID = pd.IdFarmacia
                        where pd.IdPresentacion = { .Cells(GridCols.ID).Value}
                    "
                    sqlConceptos = $"
                        select 
		                    null			as ID,
		                    ROW_NUMBER() OVER(order by f. nombre)as IdDetalle,
		                    pd.IdFarmacia		as IdFarmacia,
		                    'A Cargo OS'	as detalle,
		                    pd.AcargoOS		as valor,
                            'insert'        as estado,
                                0           as edit
	                    from Presentaciones_det pd
		                    join Farmacias f on f.ID = pd.IdFarmacia
	                    where pd.IdPresentacion = { .Cells(GridCols.ID).Value}
                    "
                End If




                frmLiquidaciones.Presentacion_request(SqlDetalle, sqlConceptos)
            End With



            Me.Dispose()
            Me.Close()
        Else
            MsgBox("Seleccione una presentación para poder continuar.")
        End If
    End Sub

    Private Sub chkAgrupar_CheckedChanged(sender As Object, e As EventArgs) Handles chkAgrupar.CheckedChanged

    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        LlenarGrilla()
    End Sub
End Class