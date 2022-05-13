Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Utiles.Util

Public Class frmSaldos

    Dim dtFarmacias As DataTable

#Region "enums"
    Enum grdFarmaciaCols
        ID = 0
        Seleccion = 1
        Codigo = 2
        Nombre = 3
        IdRazonSocial = 4
        RazonSocial = 5
        Cuit = 6
        CBU = 7
        Banco = 8
        NroCta = 9
        Sociedad = 10
        PreferenciaPago = 11
        Saldo = 12
        Telefono = 13
        Email = 14
    End Enum

    Enum grdHistorialCols
        ID = 0
        Fecha = 1
        Detalle = 2
        Debito = 3
        Credito = 4
        Total = 5
        Saldo = 6
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
            .Columns(grdFarmaciaCols.IdRazonSocial).Visible = False
            .Columns(grdFarmaciaCols.CBU).Visible = False
            .Columns(grdFarmaciaCols.NroCta).Visible = False
            .Columns(grdFarmaciaCols.Banco).Visible = False
            .Columns(grdFarmaciaCols.Sociedad).Visible = False


            ''cambiar width
            '.Columns(grdFarmaciaCols.Seleccion).Width = 50
            '.Columns(grdFarmaciaCols.Codigo).Width = 70
            ''.Columns(grdFarmaciaCols.Nombre).Width = 200
            '.Columns(grdFarmaciaCols.PreferenciaPago).Width = 70
            '.Columns(grdFarmaciaCols.Saldo).Width = 100

            .Columns(grdFarmaciaCols.Saldo).DefaultCellStyle.Format = "c"

            ''Bloqueo la edicion para todas las columnas
            For Each col As DataGridViewColumn In .Columns
                If col.Index <> .Columns(grdFarmaciaCols.Seleccion).Index Then
                    col.ReadOnly = True
                End If
            Next

            .AutoResizeColumns()
        End With

        With grdHistorial
            .Columns(grdHistorialCols.ID).Visible = False

            .Columns(grdHistorialCols.Fecha).Width = 70
            .Columns(grdHistorialCols.Detalle).Width = 200

            .Columns(grdHistorialCols.Fecha).DefaultCellStyle.Format = "d"
            .Columns(grdHistorialCols.Credito).DefaultCellStyle.Format = "c"
            .Columns(grdHistorialCols.Debito).DefaultCellStyle.Format = "c"
            .Columns(grdHistorialCols.Total).DefaultCellStyle.Format = "c"
            .Columns(grdHistorialCols.Saldo).DefaultCellStyle.Format = "c"
        End With


        For Each column As DataGridViewColumn In grdHistorial.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub requestGrdData()
        dtFarmacias = New DataTable()
        Dim connection As SqlClient.SqlConnection = Nothing
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
    End Sub

    Private Sub requestGrdItemData()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim dt As New DataTable()
        Dim sql As String = $"exec spHistorialCta_SelectByIdFarmacia @IdFarmacia = {txtID.Text}"
        If txtID.Text <> "" Then
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
        End If

    End Sub

    Friend Sub refreshData()
        txtID.Text = ""
        If grdFarmacia.CurrentRow IsNot Nothing Then
            Dim codigo As String = grdFarmacia.CurrentRow.Cells(grdFarmaciaCols.Codigo).Value.ToString
            requestGrdData()
            For Each row As DataGridViewRow In grdFarmacia.Rows
                If row.Cells(grdFarmaciaCols.Codigo).Value = codigo Then
                    grdFarmacia.ClearSelection()
                    row.Selected = True
                    grdFarmacia.CurrentCell = grdFarmacia.Rows(row.Index).Cells(grdFarmaciaCols.Codigo)
                    txtID.Text = row.Cells(grdFarmaciaCols.ID).Value
                End If
            Next
        Else
            requestGrdData()
        End If

    End Sub

    ''Revisa si almenos un registro tiene un checkbox activado
    Private Function checkSelected() As Boolean
        For Each row As DataRow In dtFarmacias.Rows
            If row(grdFarmaciaCols.Seleccion) = True Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub countSelected()
        ''refresco la seleccion para impactar datos
        Dim temprow As DataGridViewCell = Nothing
        Dim cant As Integer = 0
        If grdFarmacia.CurrentCell IsNot Nothing Then
            temprow = grdFarmacia.CurrentCell
            grdFarmacia.CurrentCell = Nothing
        End If
        grdFarmacia.CurrentCell = temprow
        cant = dtFarmacias.Select($"{dtFarmacias.Columns(grdFarmaciaCols.Seleccion).ColumnName} = True").Length
        lblSeleccionados.Text = cant.ToString + IIf(cant <> 1, " Seleccionados", " Seleccionado")
    End Sub

#End Region

#Region "Eventos"
    Private Sub frmSaldos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        requestGrdData()
        If txtID.Text <> "" Then
            setStyles()
        End If

    End Sub

    Private Sub grdFarmacia_SelectionChanged(sender As Object, e As EventArgs) Handles grdFarmacia.SelectionChanged

        If grdFarmacia.CurrentRow IsNot Nothing Then
            If grdFarmacia.CurrentRow.Cells(0).Value.ToString <> txtID.Text Then
                txtID.Text = grdFarmacia.CurrentRow.Cells(0).Value
            End If
        End If

        If grdFarmacia.SelectedRows.Count > 1 Then
            btnSelection.Text = "Seleccionar marcados"
        Else
            If dtFarmacias.Select("[Selección] = 1").Length > 0 Then
                btnSelection.Text = "Deseleccionar todo"
            Else
                btnSelection.Text = "Seleccionar todo"
            End If
        End If
    End Sub



    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged
        requestGrdItemData()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ''buscador
        Dim dv As New DataView(dtFarmacias)
        dv.RowFilter = $"[Rázon Social] LIKE '%{txtBuscar.Text}%' or Farmacia LIKE '%{txtBuscar.Text}%'"
        grdFarmacia.DataSource = dv

    End Sub

    Private Sub btnPago_Click(sender As Object, e As EventArgs) Handles btnPago.Click
        ''me aseguro de que quede la fila seleccionada
        Dim temprow As DataGridViewCell = Nothing
        If grdFarmacia.CurrentCell IsNot Nothing Then
            temprow = grdFarmacia.CurrentCell
            grdFarmacia.CurrentCell = Nothing
        End If
        grdFarmacia.CurrentCell = temprow

        If checkSelected() Then
            Dim dv As New DataView(dtFarmacias)
            dv.RowFilter = $"[Selección] = 1"

            Dim AgregarCheques As New frmAgregarPagos(dv.ToTable())
            AgregarCheques.ShowDialog()
        Else
            MsgBox("Debe seleccionar al menos una razón social para poder realizar el pago.")
        End If

    End Sub

    Private Sub btnSelection_Click(sender As Object, e As EventArgs) Handles btnSelection.Click
        If btnSelection.Text = "Seleccionar todo" Then
            For Each row As DataGridViewRow In grdFarmacia.Rows
                row.Cells(grdFarmaciaCols.Seleccion).Value = True
            Next
            btnSelection.Text = "Deseleccionar todo"
        ElseIf btnSelection.Text = "Deseleccionar todo" Then
            For Each row As DataGridViewRow In grdFarmacia.Rows
                row.Cells(grdFarmaciaCols.Seleccion).Value = False
            Next
            btnSelection.Text = IIf(grdFarmacia.SelectedRows.Count > 1, "Seleccionar marcados", "Seleccionar todo")
        ElseIf btnSelection.Text = "Seleccionar marcados" Then
            For Each row As DataGridViewRow In grdFarmacia.SelectedRows
                row.Cells(grdFarmaciaCols.Seleccion).Value = True
            Next
            btnSelection.Text = "Deseleccionar todo"
        End If
        countSelected()
    End Sub

    Private Sub btnAplicarConceptos_Click(sender As Object, e As EventArgs) Handles btnAplicarConceptos.Click

        ''me aseguro de que quede la fila seleccionada
        Dim temprow As DataGridViewCell = Nothing
        If grdFarmacia.CurrentCell IsNot Nothing Then
            temprow = grdFarmacia.CurrentCell
            grdFarmacia.CurrentCell = Nothing
        End If
        grdFarmacia.CurrentCell = temprow

        If checkSelected() Then
            Dim dv As New DataView(dtFarmacias)
            dv.RowFilter = $"[Selección] = 1"

            Dim AplicarConceptos As New frmAplicarConceptos(dv.ToTable())
            AplicarConceptos.ShowDialog()
        Else
            MsgBox("Debe seleccionar al menos una razón social para poder aplicar conceptos.")
        End If
    End Sub

    Private Sub grdFarmacia_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdFarmacia.CellContentClick
        If e.ColumnIndex = grdFarmaciaCols.Seleccion Then
            countSelected()
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        '"08-05-2022 15:00"
        '"09-05-2022 15:56:00"
        '20137
        If checkSelected() Then
            Dim dv As New DataView(dtFarmacias)
            dv.RowFilter = $"[Selección] = 1"

            dv.ToTable()

            For Each rowDt As DataRow In dv.ToTable().Rows
                Dim frmRptSaldos As New frmRptSaldos(rowDt(grdFarmaciaCols.ID), dtpFechaInicio.Value, dtpFechaFin.Value)
                frmRptSaldos.ShowDialog()
            Next

            'Dim frmRptSaldos As New frmRptSaldos(20137, "08-05-2022 15:00", "09-05-2022 15:56:00")
            'frmRptSaldos.ShowDialog()

            'Dim AgregarCheques As New frmAgregarPagos(dv.ToTable())
            'AgregarCheques.ShowDialog()
        Else
            MsgBox("Debe seleccionar al menos una razón social para poder realizar el pago.")
        End If


    End Sub

    'Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
    '    Dim reporte As New frmRtpCheques()
    '    reporte.ShowDialog()
    'End Sub

#End Region
End Class