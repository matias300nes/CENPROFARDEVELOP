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

Public Class frmSelectRazonSocial
    Dim count As Integer = 0
    Dim dtRazonesSociales As New DataTable

    Enum grdColumns
        ID = 0
        Codigo = 1
        RazonSocial = 2
        PreferenciaPago = 3
        Cbu = 4
        Cuit = 5
        NroCuenta = 6
        Banco = 7
        Email = 8
        Celular = 9
        Domicilio = 10
        IdLocalidad = 11
        IdProvincia = 12
        Localidad = 13
        Provincia = 14
    End Enum

    Private Sub LlenarGrilla()
        Dim connection = Nothing
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
            ''Detalle de liquidacion
            Dim Sql = $"exec spRazonesSociales_Select_All @eliminado = 0"

            Dim cmd As New SqlCommand(Sql, connection)
            Dim da As New SqlDataAdapter(cmd)

            da.Fill(dtRazonesSociales)

            grdRazonSocial.DataSource = dtRazonesSociales
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

        With grdRazonSocial
            .Columns(grdColumns.ID).Visible = False

            .Columns(grdColumns.Domicilio).Visible = False
            .Columns(grdColumns.IdLocalidad).Visible = False
            .Columns(grdColumns.IdProvincia).Visible = False
            .Columns(grdColumns.Provincia).Visible = False
            .Columns(grdColumns.Localidad).Visible = False

            .Columns(grdColumns.Celular).Visible = False
            .Columns(grdColumns.Banco).Visible = False
            .Columns(grdColumns.PreferenciaPago).Visible = False
            .Columns(grdColumns.NroCuenta).Visible = False
            .Columns(grdColumns.Celular).Visible = False
            .Columns(grdColumns.Cbu).Visible = False

            .AutoResizeColumns()
        End With
    End Sub

    Private Sub btnListo_Click(sender As Object, e As EventArgs) Handles btnListo.Click

        If grdRazonSocial.CurrentRow IsNot Nothing Then
            Dim idRazonSocial As Double
            Dim RazonSocial As String
            Dim tipopago As String
            ''Llenado de grdConceptosPanel
            With grdRazonSocial.CurrentRow
                idRazonSocial = .Cells(grdColumns.ID).Value
                RazonSocial = .Cells(grdColumns.RazonSocial).Value
                tipopago = .Cells(grdColumns.PreferenciaPago).Value
            End With

            frmFarmacias_Conceptos.txtIdRazonSocial.Text = idRazonSocial
            frmFarmacias_Conceptos.txtRazonSocial.Text = RazonSocial
            frmFarmacias_Conceptos.cmbPreferenciaPago.SelectedValue = tipopago

            Me.Dispose()
            Me.Close()

        Else
            MsgBox("Seleccione una razón social para poder continuar.")
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ''buscador
        Dim dv As New DataView(dtRazonesSociales)
        dv.RowFilter = $"[{dtRazonesSociales.Columns(grdColumns.RazonSocial).ColumnName}] LIKE '%{txtBuscar.Text}%'"
        grdRazonSocial.DataSource = dv
    End Sub
End Class