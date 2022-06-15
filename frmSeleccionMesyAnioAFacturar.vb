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

Public Class frmSeleccionMesyAnioAFacturar

    Dim dtfarmacias As DataTable


    'Public Sub New(dtfarmacias As DataTable)

    '    'Esta llamada es exigida por el diseñador.
    '    InitializeComponent()

    '    'Agregue cualquier inicialización después de la llamada a InitializeComponent().
    '    Me.dtfarmacias = dtfarmacias 'recibo las farmacias seleccionadas

    'End Sub


    Dim dtConceptos_Created As Boolean
    Dim count As Integer = 0
    Dim Permitir As Boolean
    Enum ColumnasDelGrdConceptos
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

    Private Sub asignarTags()
        txtValor.Tag = "7"
    End Sub
    Protected Function ReglasNegocio() As Boolean
        Dim msg As String
        ReglasNegocio = False

        msg = CamposObligatorios(Me.TableLayoutPanel1.Controls)

        If msg <> "" Then
            Beep()
            MsgBox("Falta completar el campo " & msg)
            Exit Function
        End If

        ReglasNegocio = True
    End Function



    Private Sub frmNuevaLiquidacion_Load(sender As Object, e As EventArgs) Handles Me.Load
        asignarTags()
        Permitir = True
    End Sub

    Private Sub requestGrdData(mes As String, anio As String)
        dtfarmacias = New DataTable()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim sql As String = $"exec spComisionCentroPorFarmacia_Select_All @Eliminado = 0, @mes = '{mes}', @anio = '{anio}'"
        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim cmd As New SqlCommand(sql, connection)
        Dim da As New SqlDataAdapter(cmd)

        da.Fill(dtfarmacias)

        frmComisionCenprofarPorFarmacia.grdFarmacia.DataSource = dtfarmacias
        Me.Close()
    End Sub

    Private Sub btnListo_Click(sender As Object, e As EventArgs) Handles btnListo.Click
        ''llamo al sp con los datos de mes y año
        requestGrdData(txtMes.Text, txtAnio.Text)
    End Sub

End Class