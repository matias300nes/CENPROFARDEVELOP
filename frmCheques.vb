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
        FechaCreacion = 3
        FechaEmision = 4
        FechaPago = 5
        Monto = 6
        IdFarmacia = 7
    End Enum

#End Region

#Region "Funciones y procedimientos"
    Private Sub setStyles()
        With grdCheques
            ''ocultar columnas
            .Columns(colsCheques.IdFarmacia).Visible = False
            .Columns(colsCheques.id).Visible = False

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

    Public Function Money2Text(ByVal value As Double) As String
        Dim intPart As Double = Math.Truncate(value)
        Dim decPart As Double = Math.Round((value - intPart) * 100)
        Dim word As String = Num2Text(intPart) + " CON " + Num2Text(decPart) + " CENTAVOS"
        Return word
    End Function

    Public Function Num2Text(ByVal value As Double) As String

        Select Case value
            Case 0
                Num2Text = "CERO"
            Case 1
                Num2Text = "UN"
            Case 2
                Num2Text = "DOS"
            Case 3
                Num2Text = "TRES"
            Case 4
                Num2Text = "CUATRO"
            Case 5
                Num2Text = "CINCO"
            Case 6
                Num2Text = "SEIS"
            Case 7
                Num2Text = "SIETE"
            Case 8
                Num2Text = "OCHO"
            Case 9
                Num2Text = "NUEVE"
            Case 10
                Num2Text = "DIEZ"
            Case 11
                Num2Text = "ONCE"
            Case 12
                Num2Text = "DOCE"
            Case 13
                Num2Text = "TRECE"
            Case 14
                Num2Text = "CATORCE"
            Case 15
                Num2Text = "QUINCE"
            Case Is < 20
                Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20
                Num2Text = "VEINTE"
            Case Is < 30
                Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30
                Num2Text = "TREINTA"
            Case 40
                Num2Text = "CUARENTA"
            Case 50
                Num2Text = "CINCUENTA"
            Case 60
                Num2Text = "SESENTA"
            Case 70
                Num2Text = "SETENTA"
            Case 80
                Num2Text = "OCHENTA"
            Case 90
                Num2Text = "NOVENTA"
            Case Is < 100
                Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100
                Num2Text = "CIEN"
            Case Is < 200
                Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800
                Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500
                Num2Text = "QUINIENTOS"
            Case 700
                Num2Text = "SETECIENTOS"
            Case 900
                Num2Text = "NOVECIENTOS"
            Case Is < 1000
                Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000
                Num2Text = "MIL"
            Case Is < 2000
                Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000
                Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000
                Num2Text = "UN MILLON"
            Case Is < 2000000
                Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0#
                Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0#
                Num2Text = "UN BILLON"
            Case Is < 2000000000000.0#
                Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else
                Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select

    End Function

#End Region

#Region "Eventos"
    Private Sub frmSaldos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        requestGrdData()
        If txtID.Text <> "" Then
            setStyles()
        End If
        dtpDesde.CustomFormat = "--/--/----"
        dtpHasta.CustomFormat = "--/--/----"
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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        ''me aseguro de que quede la fila seleccionada
        Dim temprow As DataGridViewCell = Nothing
        If grdCheques.CurrentCell IsNot Nothing Then
            temprow = grdCheques.CurrentCell
            grdCheques.CurrentCell = Nothing
        End If
        grdCheques.CurrentCell = temprow

        If checkSelected() Then
            Dim dv As New DataView(dtCheques)
            dv.RowFilter = $"[Selección] = 1"

            Dim AgregarCheques As New frmRtpCheques(dv.ToTable())
            AgregarCheques.ShowDialog()
        Else
            MsgBox("Debe seleccionar al menos un cheque para poder imprimir.")
        End If
    End Sub

    Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged
        dtpDesde.CustomFormat = "dd/MM/yyyy"
        filtrarporfecha()
    End Sub

    Private Sub dtpHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpHasta.ValueChanged
        dtpHasta.CustomFormat = "dd/MM/yyyy"
        filtrarporfecha()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        dtpDesde.CustomFormat = "--/--/----"
        dtpHasta.CustomFormat = "--/--/----"
        txtBuscar.Text = ""
        btnLimpiar.Visible = False
        grdCheques.DataSource = dtCheques
    End Sub

    Private Sub filtrarporfecha()
        ''buscador
        If dtCheques IsNot Nothing And dtpDesde.CustomFormat = "dd/MM/yyyy" And dtpHasta.CustomFormat = "dd/MM/yyyy" Then
            Dim dv As New DataView(dtCheques)
            dv.RowFilter = $"
                [{dtCheques.Columns(colsCheques.FechaCreacion).ColumnName}] >= '{dtpDesde.Value}'
                AND [{dtCheques.Columns(colsCheques.FechaCreacion).ColumnName}] <= '{dtpHasta.Value}'
            "
            grdCheques.DataSource = dv
            btnLimpiar.Visible = True
        End If

    End Sub

#End Region
End Class