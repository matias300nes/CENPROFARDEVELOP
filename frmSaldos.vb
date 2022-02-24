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
        RazonSocial = 3
        Nombre = 4
        PreferenciaPago = 5
        Saldo = 6
        Cuit = 7
        Telefono = 8
        Email = 9
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

            ''cambiar width
            .Columns(grdFarmaciaCols.Seleccion).Width = 50
            .Columns(grdFarmaciaCols.Codigo).Width = 70
            '.Columns(grdFarmaciaCols.Nombre).Width = 200
            .Columns(grdFarmaciaCols.PreferenciaPago).Width = 70
            .Columns(grdFarmaciaCols.Saldo).Width = 100

            .Columns(grdFarmaciaCols.Saldo).DefaultCellStyle.Format = "c"

            ''Bloqueo la edicion para todas las columnas
            For Each col As DataGridViewColumn In .Columns
                If col.Index <> .Columns(grdFarmaciaCols.Seleccion).Index Then
                    col.ReadOnly = True
                End If
            Next
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
        Dim sql As String = $"exec HistorialCta_SelectByIdFarmacia @IdFarmacia = {txtID.Text}"
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
        For Each row As DataGridViewRow In grdFarmacia.Rows
            If row.Cells(grdFarmaciaCols.Seleccion).Value = True Then
                Return True
            End If
        Next
        Return False
    End Function

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

            Dim AgregarCheques As New frmAgregarCheques(dv.ToTable())
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
    End Sub

#End Region
End Class