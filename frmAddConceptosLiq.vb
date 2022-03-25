Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Utiles.Util

Public Class frmAddConceptosLiq

    Dim farmaciasConceptos As DataTable
    Dim dtConceptos As DataTable

    Enum colsFarmacias
        ID = 0
        IdPresentacion_det = 1
        IdFarmacia = 2
        nº = 3
        CodigoFarmacia = 4
        Farmacia = 5
        IdLiquidacion = 6
        Recetas = 7
        Recaudado = 8
        ACargoOS = 9
        ACargoOSP = 10
        Final = 11
        RecetasA = 12
        RecaudadoA = 13
        ACargoOSA = 14
        Bonificación = 15
        Total = 16
    End Enum

    Enum colsConceptos
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

    Enum colsFarmaciasConceptos
        nº = 0
        Codigo = 1
        idFarmacia = 2
        Farmacia = 3
        ACargoOS = 4
        Total = 5
        Concepto = 6
        Importe = 7
    End Enum

    Public Sub New(farmacias As DataTable)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim dt As New DataTable()
        dt.Columns.Add("nº", GetType(Integer))
        dt.Columns.Add("Código", GetType(String))
        dt.Columns.Add("IdFarmacia", GetType(Long))
        dt.Columns.Add("Farmacia", GetType(String))
        dt.Columns.Add("A Cargo OS", GetType(Decimal))
        dt.Columns.Add("Subtotal", GetType(Decimal))
        dt.Columns.Add("Concepto", GetType(String))
        dt.Columns.Add("Importe", GetType(Decimal))
        For Each farmacia As DataRow In farmacias.Rows
            Dim newrow As DataRow = dt.NewRow
            newrow(colsFarmaciasConceptos.nº) = farmacia(colsFarmacias.nº)
            newrow(colsFarmaciasConceptos.Codigo) = farmacia(colsFarmacias.CodigoFarmacia)
            newrow(colsFarmaciasConceptos.Farmacia) = farmacia(colsFarmacias.Farmacia)
            'a cargo os?
            If farmacia(colsFarmacias.ACargoOSA) IsNot DBNull.Value Then
                newrow(colsFarmaciasConceptos.ACargoOS) = farmacia(colsFarmacias.ACargoOSA)
            Else
                Dim presentado = farmacia(colsFarmacias.ACargoOS)
                Dim pagado = IIf(farmacia(colsFarmacias.ACargoOSP) Is DBNull.Value, 0, farmacia(colsFarmacias.ACargoOSP))
                newrow(colsFarmaciasConceptos.ACargoOS) = presentado - pagado
            End If

            newrow(colsFarmaciasConceptos.Total) = farmacia(colsFarmacias.Total)
            dt.Rows.Add(newrow)
        Next
        Me.farmaciasConceptos = dt

    End Sub

    Private Sub frmAddConceptosLiq_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtConceptos = New DataTable()
        Dim dt As New DataTable()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim sql As String = "exec spConceptos_Select_All @Eliminado = 0"
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim cmd As New SqlCommand(sql, connection)
        Dim da As New SqlDataAdapter(cmd)

        da.Fill(dt)

        Dim dv As New DataView(dt)
        dv.RowFilter = $"[Pertenece a] = 'LIQUIDACIONES'"

        dtConceptos = dv.Table

        With grdConceptos
            .DataSource = dtConceptos
            .Columns(colsConceptos.Id).Visible = False
            .Columns(colsConceptos.CampoAplicable).Visible = False
            .Columns(colsConceptos.ConceptoPago).Visible = False
            .Columns(colsConceptos.PerteneceA).Visible = False
            .Columns(colsConceptos.TipoDeValor).Visible = False
            .Columns(colsConceptos.Valor).DefaultCellStyle.Format = "0.00'%'"
            .AutoResizeColumns()
        End With
        btnGenerar.Enabled = False

    End Sub

    Private Sub btnAplicarConceptos_Click(sender As Object, e As EventArgs) Handles btnAplicarConceptos.Click
        If grdConceptos.CurrentRow IsNot Nothing Then
            Dim concepto As DataGridViewRow = grdConceptos.CurrentRow
            For Each farmacia As DataRow In farmaciasConceptos.Rows
                farmacia(colsFarmaciasConceptos.Concepto) = concepto.Cells(colsConceptos.Nombre).Value
                If concepto.Cells(colsConceptos.CampoAplicable).Value = "A CARGO OS" Then
                    farmacia(colsFarmaciasConceptos.Importe) = farmacia(colsFarmaciasConceptos.ACargoOS) * (concepto.Cells(colsConceptos.Valor).Value / 100)
                End If
                If concepto.Cells(colsConceptos.CampoAplicable).Value = "TOTAL" Then
                    farmacia(colsFarmaciasConceptos.Importe) = farmacia(colsFarmaciasConceptos.Total) * (concepto.Cells(colsConceptos.Valor).Value / 100)
                End If

            Next

            With grdFarmacias
                .DataSource = Me.farmaciasConceptos
                .Columns(colsFarmaciasConceptos.idFarmacia).Visible = False
                .Columns(colsFarmaciasConceptos.ACargoOS).DefaultCellStyle.Format = "c"
                .Columns(colsFarmaciasConceptos.Total).DefaultCellStyle.Format = "c"
                .Columns(colsFarmaciasConceptos.Importe).DefaultCellStyle.Format = "c"
                .Columns(colsFarmaciasConceptos.ACargoOS).Visible = False
                .Columns(colsFarmaciasConceptos.Total).Visible = False
                .Columns(colsFarmaciasConceptos.Importe).DefaultCellStyle.BackColor = Color.DarkOliveGreen
                .Columns(colsFarmaciasConceptos.Importe).DefaultCellStyle.ForeColor = Color.White
                For Each column As DataGridViewColumn In .Columns
                    column.ReadOnly = True
                Next
                .Columns(colsFarmaciasConceptos.Importe).ReadOnly = False
                .AutoResizeColumns()
            End With
            btnGenerar.Enabled = True
        End If
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click

        Dim dt As New DataTable()
        dt.Columns.Add("ID", GetType(Long))
        dt.Columns.Add("IdDetalle", GetType(Long))
        dt.Columns.Add("IdFarmacia", GetType(String))
        dt.Columns.Add("detalle", GetType(String))
        dt.Columns.Add("valor", GetType(Decimal))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("edit")

        Dim concepto As DataRow
        For Each row As DataRow In farmaciasConceptos.Rows
            concepto = dt.NewRow
            concepto("IdDetalle") = row(colsFarmaciasConceptos.nº)
            concepto("IdFarmacia") = row(colsFarmaciasConceptos.idFarmacia)
            concepto("detalle") = row(colsFarmaciasConceptos.Concepto)
            concepto("valor") = -row(colsFarmaciasConceptos.Importe)
            concepto("edit") = True
            dt.Rows.Add(concepto)
        Next

        For Each item As DataRow In dt.Rows
            frmLiquidaciones.añadirConcepto(item)
        Next

        frmLiquidaciones.UpdateGrdPrincipal()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ''buscador
        Dim dv As New DataView(dtConceptos)
        dv.RowFilter = $"{dtConceptos.Columns(colsConceptos.Nombre).ColumnName} LIKE '%{txtBuscar.Text}%'"
        grdConceptos.DataSource = dv

    End Sub
End Class