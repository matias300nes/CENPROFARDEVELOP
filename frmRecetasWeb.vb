Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Utiles.Util

Public Class frmRecetasWeb
    Dim dtRecetasWeb As DataTable
    Dim idObraSocial As Long
    Dim idPeriodo As Long

    Enum grdCols
        Seleccion = 0
        idFarmacia = 1
        Farmacia = 2
        Recetas = 3
        Recaudado = 4
        ACargoOS = 5
    End Enum
    Public Sub New(idObraSocial As Long, idPeriodo As Long)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.idObraSocial = idObraSocial
        Me.idPeriodo = idPeriodo

    End Sub

#Region "Procedimientos"
    Private Sub requestGrdData()
        dtRecetasWeb = New DataTable()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim sql As String = $"
            SELECT
	            cast(0 as bit) as [Selección],
	            rw.IdFarmacia as idFarmacia,
	            f.Nombre as Farmacia,
	            sum(rw.Recetas) as Recetas,
	            sum(rw.Recaudado) as Recaudado,
	            sum(rw.AcargoOS) as [A Cargo OS]
            FROM Recetas_web rw
            JOIN Farmacias f on f.id = rw.IdFarmacia
            WHERE rw.Eliminado = 0 and rw.IdPeriodo = 7 and rw.IdObraSocial = 1
            GROUP BY rw.IdFarmacia, f.Nombre
        "
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim cmd As New SqlCommand(sql, connection)
        Dim da As New SqlDataAdapter(cmd)

        da.Fill(dtRecetasWeb)

        grdRecetasWeb.DataSource = dtRecetasWeb
    End Sub

    Private Sub setStyles()
        With grdRecetasWeb
            ''ocultar columnas
            .Columns(grdCols.idFarmacia).Visible = False

            'Bloqueo la edicion para todas las columnas
            For Each col As DataGridViewColumn In .Columns
                If col.Index <> .Columns(grdCols.Seleccion).Index Then
                    col.ReadOnly = True
                End If
            Next

            .AutoResizeColumns()
        End With
    End Sub
#End Region

#Region "Eventos"
    Private Sub frmRecetasWeb_Load(sender As Object, e As EventArgs) Handles Me.Load
        requestGrdData()
        setStyles()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ''buscador
        Dim dv As New DataView(dtRecetasWeb)
        dv.RowFilter = $"{dtRecetasWeb.Columns(grdCols.Farmacia).ColumnName} LIKE '%{txtBuscar.Text}%'"
        grdRecetasWeb.DataSource = dv

    End Sub

    Private Sub btnListo_Click(sender As Object, e As EventArgs) Handles btnListo.Click

        Dim dv As New DataView(dtRecetasWeb)
        dv.RowFilter = $"{dtRecetasWeb.Columns(grdCols.Seleccion).ColumnName} = 1"
        Dim dtSelected As DataTable = dv.ToTable

        For Each row As DataRow In dtSelected.Rows
            frmPresentaciones.newItem(
                nombre:=row(grdCols.Farmacia),
                idFarmacia:=row(grdCols.idFarmacia),
                idPlan:=Nothing,
                plan:=Nothing,
                recetas:=row(grdCols.Recetas),
                recaudado:=row(grdCols.Recaudado),
                aCargoOS:=row(grdCols.ACargoOS),
                bonificacion:=0,
                observacion:=Nothing,
                mensajeWeb:=Nothing
            )
        Next

        If dtSelected.Rows.Count > 0 Then
            Me.Dispose()
            Me.Close()
        Else
            MessageBox.Show("No seleccionó ningun dato cargado desde la web.",
              "Seleccione recetas", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub
#End Region

End Class