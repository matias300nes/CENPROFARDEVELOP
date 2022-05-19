﻿Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Utiles.Util

Public Class frmPresentacionesAgregarItem
    Dim idObraSocial As Long
    Public Sub New(idObraSocial As Long)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.idObraSocial = idObraSocial
    End Sub

#Region "Funciones y procedimientos"

    Private Sub LlenarCmbFarmacia()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, $" SELECT ID, NOMBRE FROM FARMACIAS WHERE ELIMINADO = 0")
            ds.Dispose()

            With cmbFarmacias
                .DataSource = ds.Tables(0).DefaultView
                .DisplayMember = "NOMBRE"
                .ValueMember = "ID"
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con KAIZEN Software Factory a través del correo soporte@kaizensoftware.com.ar", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub LlenarCmbPlanes()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, $" SELECT p.id as Id, p.nombre as Nombre 
                                                                            FROM Planes p 
                                                                            INNER JOIN ObrasSociales_Planes osp ON osp.IdPlan = p.Id 
                                                                            WHERE osp.IdObraSocial = {idObraSocial} AND p.eliminado = 0")
            ds.Dispose()

            With cmbPlanes
                .DataSource = ds.Tables(0).DefaultView
                .DisplayMember = "NOMBRE"
                .ValueMember = "ID"
            End With

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con KAIZEN Software Factory a través del correo soporte@kaizensoftware.com.ar", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Sub

    Private Function checkForm() As Boolean
        If cmbFarmacias.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar una farmacia para poder continuar.",
              "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbFarmacias.Focus()
            Return False
        End If

        If txtRecetas.Text = "" Then
            MessageBox.Show("Debe ingresar la cantidad de recetas para poder continuar.",
              "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRecetas.Focus()
            Return False
        End If

        If txtImpRecaudado.Text = "" Then
            MessageBox.Show("Debe ingresar el imp.100% o recaudado para poder continuar.",
              "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtImpRecaudado.Focus()
            Return False
        End If

        If txtImpACargoOs.Text = "" Then
            MessageBox.Show("Debe ingresar el imp. a cargo OS para poder continuar.",
              "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtImpACargoOs.Focus()
            Return False
        End If

        If Decimal.Parse(txtImpACargoOs.Text) > Decimal.Parse(txtImpRecaudado.Text) Then
            MessageBox.Show("El imp. a cargo OS no puede ser mayor que el imp. 100%.",
              "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtImpACargoOs.Focus()
            Return False
        End If

        If txtBonificacion.Text = "" Then
            MessageBox.Show("Debe ingresar la bonificación para poder continuar. Ingrese 0 en caso de no tenerla.",
              "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBonificacion.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub cleanForm()

        cmbFarmacias.SelectedItem = Nothing
        cmbPlanes.SelectedItem = Nothing
        txtRecetas.Text = ""
        txtImpRecaudado.Text = ""
        txtImpACargoOs.Text = ""
        txtBonificacion.Text = ""
        txtObservacion.Text = ""
        txtMensajeWeb.Text = ""
        lblTotal.Text = 0

        cmbFarmacias.Focus()
    End Sub

#End Region

#Region "Eventos"

    Private Sub PresentacionesAgregarItem_Load(sender As Object, e As EventArgs) Handles Me.Load
        LlenarCmbFarmacia()
        LlenarCmbPlanes()
        cleanForm()
    End Sub

    Private Sub PresentacionesAgregarItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter 'nuevo
                btnAgregar.PerformClick()

            Case Keys.Escape
                btnCerrar.PerformClick()
        End Select
    End Sub

    Private Sub txtImpRecaudado_LostFocus(sender As Object, e As EventArgs) Handles txtImpRecaudado.LostFocus
        If txtImpRecaudado.Text <> "" Then
            txtImpRecaudado.Text = String.Format("{0:N2}", Decimal.Parse(txtImpRecaudado.Text))
        End If
    End Sub

    Private Sub txtImpACargoOs_LostFocus(sender As Object, e As EventArgs) Handles txtImpACargoOs.LostFocus
        If txtImpACargoOs.Text <> "" Then
            Dim subtotal As Decimal = 0
            Dim aCargoOS As Decimal = Decimal.Parse(txtImpACargoOs.Text)
            Dim Bonificacion As Decimal = 0
            If txtBonificacion.Text <> "" Then
                Bonificacion = Decimal.Parse(txtBonificacion.Text)
            End If
            subtotal = aCargoOS - Bonificacion
            lblTotal.Text = String.Format("{0:N2}", Math.Round(subtotal, 2))
            txtImpACargoOs.Text = String.Format("{0:N2}", aCargoOS)
        End If
    End Sub

    Private Sub txtBonificacion_LostFocus(sender As Object, e As EventArgs) Handles txtBonificacion.LostFocus
        If txtBonificacion.Text <> "" And txtImpACargoOs.Text <> "" And txtImpACargoOs.Text <> "0" Then
            Dim subtotal As Decimal
            Dim AcargoOS = Decimal.Parse(txtImpACargoOs.Text)
            Dim impBonificacion = Decimal.Parse(txtBonificacion.Text)

            subtotal = Decimal.Parse(txtImpACargoOs.Text) - impBonificacion
            txtBonificacion.Text = String.Format("{0:N2}", Decimal.Parse(txtBonificacion.Text))
            lblTotal.Text = String.Format("{0:N2}", subtotal)
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If checkForm() Then
            frmPresentaciones.newItem(
                nombre:=cmbFarmacias.Text,
                idFarmacia:=cmbFarmacias.SelectedValue,
                idPlan:=cmbPlanes.SelectedValue,
                plan:=cmbPlanes.Text,
                recetas:=Integer.Parse(txtRecetas.Text),
                recaudado:=Decimal.Parse(txtImpRecaudado.Text),
                aCargoOS:=Decimal.Parse(txtImpACargoOs.Text),
                bonificacion:=Decimal.Parse(txtBonificacion.Text),
                observacion:=txtObservacion.Text,
                mensajeWeb:=txtMensajeWeb.Text
            )
            cleanForm()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
        Me.Close()
    End Sub

#End Region
End Class