Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Utiles.Util

Public Class frmSaldos

#Region "enums"
    Enum grdFarmaciaCols
        ID = 0
        Codigo = 1
        RazonSocial = 2
        Nombre = 3
        PreferenciaPago = 4
        Saldo = 5
        Cuit = 6
        Telefono = 7
        Email = 8
    End Enum

    Enum grdHistorialCols
        ID = 0
        Fecha = 1
        Detalle = 2
        Debito = 3
        Credito = 4
        Total = 5
        Saldo =6
    End Enum
#End Region

#Region "Funciones y procedimientos"
    Private Sub setStyles()
        With grdFarmacia
            ''ocultar columnas
            .Columns(grdFarmaciaCols.ID).Visible = False
            .Columns(grdFarmaciaCols.Cuit).Visible = False
            .Columns(grdFarmaciaCols.Telefono).Visible = False
            .Columns(grdFarmaciaCols.Email).Visible = False

            ''cambiar width
            .Columns(grdFarmaciaCols.Codigo).Width = 70
            '.Columns(grdFarmaciaCols.Nombre).Width = 200
            .Columns(grdFarmaciaCols.PreferenciaPago).Width = 70
            .Columns(grdFarmaciaCols.Saldo).Width = 100
        End With

        With grdHistorial
            .Columns(grdHistorialCols.ID).Visible = False

            .Columns(grdHistorialCols.Fecha).Width = 70
            .Columns(grdHistorialCols.Detalle).Width = 200
        End With

        For Each column As DataGridViewColumn In grdHistorial.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Dim dtFarmacias As DataTable
    Private Sub requestGrdData()
        Dim connection As SqlClient.SqlConnection = Nothing
        dtFarmacias = New DataTable()
        Dim sql As String = "exec spSaldos_Select_All @Eliminado = 0"
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim cmd As New SqlCommand(sql, connection)
        Dim da As New SqlDataAdapter(cmd)

        da.Fill(dtFarmacias)

        grdFarmacia.DataSource = dtFarmacias

        'grdFarmacia.RowHeadersVisible = False
    End Sub

    Private Sub requestGrdItemsData()

    End Sub
#End Region

#Region "Eventos"
    Private Sub frmSaldos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        requestGrdData()

        setStyles()
    End Sub

    Private Sub grdFarmacia_SelectionChanged(sender As Object, e As EventArgs) Handles grdFarmacia.SelectionChanged

        If grdFarmacia.CurrentRow IsNot Nothing Then
            If grdFarmacia.CurrentRow.Cells(0).Value.ToString <> txtID.Text Then
                txtID.Text = grdFarmacia.CurrentRow.Cells(0).Value
            End If
        End If
    End Sub

    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim dt As New DataTable()
        Dim sql As String = $"exec HistorialCta_SelectByIdFarmacia @IdFarmacia = {txtID.Text}"
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)

            Dim cmd As New SqlCommand(sql, connection)
            Dim da As New SqlDataAdapter(cmd)

            da.Fill(dt)

            grdHistorial.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ''buscador
        Dim dv As New DataView(dtFarmacias)
        dv.RowFilter = $"[Rázon Social] LIKE '%{txtBuscar.Text}%' or Farmacia LIKE '%{txtBuscar.Text}%'"
        grdFarmacia.DataSource = dv

    End Sub

#End Region
End Class