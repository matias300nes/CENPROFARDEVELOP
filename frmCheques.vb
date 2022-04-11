Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Utiles.Util

Public Class frmCheques

    Dim dtCheques As DataTable

#Region "enums"
    Enum colsCheques
        id = 0
        seleccion = 1
        PagueseA = 2
        FechaEmision = 3
        FechaPago = 4
        Monto = 5
        IdFarmacia = 6
    End Enum

#End Region

#Region "Funciones y procedimientos"
    Private Sub setStyles()
        With grdCheques
            ''ocultar columnas
            .Columns(colsCheques.IdFarmacia).Visible = False

            .Columns(colsCheques.Monto).DefaultCellStyle.Format = "c"

            ''Bloqueo la edicion para todas las columnas
            For Each col As DataGridViewColumn In .Columns
                If col.Index <> .Columns(colsCheques.Seleccion).Index Then
                    col.ReadOnly = True
                End If
            Next

            .AutoResizeColumns()
        End With

    End Sub

    Private Sub requestGrdData()
        dtCheques = New DataTable()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim sql As String = "exec spPagos_Select_All @Tipo = 'CHEQUE'"
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim cmd As New SqlCommand(sql, connection)
        Dim da As New SqlDataAdapter(cmd)

        da.Fill(dtCheques)

        grdCheques.DataSource = dtCheques
    End Sub

    Private Sub requestGrdItemData()
        'Dim connection As SqlClient.SqlConnection = Nothing
        'Dim dt As New DataTable()
        'Dim sql As String = $"exec HistorialCta_SelectByIdFarmacia @IdFarmacia = {txtID.Text}"
        'If txtID.Text <> "" Then
        '    Try
        '        connection = SqlHelper.GetConnection(ConnStringSEI)

        '        Dim cmd As New SqlCommand(sql, connection)
        '        Dim da As New SqlDataAdapter(cmd)

        '        da.Fill(dt)

        '        grdHistorial.DataSource = dt
        '    Catch ex As Exception
        '        MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Exit Sub
        '    End Try
        'End If

    End Sub

    'Friend Sub refreshData()
    '    If grdCheques.CurrentRow IsNot Nothing Then
    '        Dim codigo As String = grdCheques.CurrentRow.Cells(colsCheques.Codigo).Value.ToString
    '        requestGrdData()
    '        For Each row As DataGridViewRow In grdCheques.Rows
    '            If row.Cells(grdFarmaciaCols.Codigo).Value = codigo Then
    '                grdCheques.ClearSelection()
    '                row.Selected = True
    '                grdCheques.CurrentCell = grdCheques.Rows(row.Index).Cells(grdFarmaciaCols.Codigo)
    '                txtID.Text = row.Cells(grdFarmaciaCols.ID).Value
    '            End If
    '        Next
    '    Else
    '        requestGrdData()
    '    End If

    'End Sub

    ''Revisa si almenos un registro tiene un checkbox activado
    Private Function checkSelected() As Boolean
        For Each row As DataRow In dtCheques.Rows
            If row(colsCheques.seleccion) = True Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub countSelected()
        ''refresco la seleccion para impactar datos
        Dim temprow As DataGridViewCell = Nothing
        Dim cant As Integer = 0
        If grdCheques.CurrentCell IsNot Nothing Then
            temprow = grdCheques.CurrentCell
            grdCheques.CurrentCell = Nothing
        End If
        grdCheques.CurrentCell = temprow
        cant = dtCheques.Select($"{dtCheques.Columns(colsCheques.seleccion).ColumnName} = True").Length
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

    Private Sub grdCheques_SelectionChanged(sender As Object, e As EventArgs) Handles grdCheques.SelectionChanged

        If grdCheques.CurrentRow IsNot Nothing Then
            If grdCheques.CurrentRow.Cells(0).Value.ToString <> txtID.Text Then
                txtID.Text = grdCheques.CurrentRow.Cells(0).Value
            End If
        End If

        If grdCheques.SelectedRows.Count > 1 Then
            btnSelection.Text = "Seleccionar marcados"
        Else
            If dtCheques.Select("[Selección] = 1").Length > 0 Then
                btnSelection.Text = "Deseleccionar todo"
            Else
                btnSelection.Text = "Seleccionar todo"
            End If
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ''buscador
        Dim dv As New DataView(dtCheques)
        dv.RowFilter = $"[Paguese a] LIKE '%{txtBuscar.Text}%'"
        grdCheques.DataSource = dv

    End Sub

    'Private Sub btnPago_Click(sender As Object, e As EventArgs)
    '    ''me aseguro de que quede la fila seleccionada
    '    Dim temprow As DataGridViewCell = Nothing
    '    If grdCheques.CurrentCell IsNot Nothing Then
    '        temprow = grdCheques.CurrentCell
    '        grdCheques.CurrentCell = Nothing
    '    End If
    '    grdCheques.CurrentCell = temprow

    '    If checkSelected() Then
    '        Dim dv As New DataView(dtFarmacias)
    '        dv.RowFilter = $"[Selección] = 1"

    '        Dim AgregarCheques As New frmAgregarPagos(dv.ToTable())
    '        AgregarCheques.ShowDialog()
    '    Else
    '        MsgBox("Debe seleccionar al menos una razón social para poder realizar el pago.")
    '    End If

    'End Sub

    Private Sub btnSelection_Click(sender As Object, e As EventArgs) Handles btnSelection.Click
        If btnSelection.Text = "Seleccionar todo" Then
            For Each row As DataGridViewRow In grdCheques.Rows
                row.Cells(colsCheques.seleccion).Value = True
            Next
            btnSelection.Text = "Deseleccionar todo"
        ElseIf btnSelection.Text = "Deseleccionar todo" Then
            For Each row As DataGridViewRow In grdCheques.Rows
                row.Cells(colsCheques.seleccion).Value = False
            Next
            btnSelection.Text = IIf(grdCheques.SelectedRows.Count > 1, "Seleccionar marcados", "Seleccionar todo")
        ElseIf btnSelection.Text = "Seleccionar marcados" Then
            For Each row As DataGridViewRow In grdCheques.SelectedRows
                row.Cells(colsCheques.seleccion).Value = True
            Next
            btnSelection.Text = "Deseleccionar todo"
        End If
        countSelected()
    End Sub


    Private Sub grdCheques_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCheques.CellContentClick
        If e.ColumnIndex = colsCheques.seleccion Then
            countSelected()
        End If
    End Sub

    'Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
    '    Dim reporte As New frmRtpCheques()
    '    reporte.ShowDialog()
    'End Sub


#End Region
End Class