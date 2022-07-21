Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Utiles.Util

Public Class frmPresentacionesAgregarItem
    Dim idObraSocial As Long
    Dim ObraSocial As String
    Dim PorcentajeOS As Decimal
    Dim selectedRow As DataGridViewRow
    Dim updating As Boolean
    Dim rdbChecked As RadioButton

    Enum grdCols
        ID = 0
        IdFarmacia = 1
        CodigoFarmacia = 2
        Nombre = 3
        IdPlan = 4
        Plan = 5
        Observacion = 6
        mensajeWeb = 7
        IdPresentacion = 8
        Recetas = 9
        Recaudado = 10
        ACargoOS = 11
        Bonificacion = 12
        Total = 13
        CodFacaf_Farm = 14
        CodPlan = 15
        PorcenPlan = 16
    End Enum

    Public Sub New(idObraSocial As Long, ByRef selectedRow As DataGridViewRow)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.idObraSocial = idObraSocial

        Me.updating = IIf(selectedRow IsNot Nothing, True, False)

        If updating Then
            lblInfo.Text = "MODIFICACIÓN"
            btnAgregar.Text = "Modificar (Enter)"
        Else
            lblInfo.Text = "NUEVA"
            btnAgregar.Text = "Agregar (Enter)"
        End If
        Me.selectedRow = selectedRow
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

    Private Sub GetOsData()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, $"SELECT ID, Nombre, Bonificacion as Porcentaje FROM ObrasSociales WHERE id = {idObraSocial}")
            ds.Dispose()

            Me.ObraSocial = ds.Tables(0).Rows(0)("Nombre")
            Me.PorcentajeOS = ds.Tables(0).Rows(0)("Porcentaje")

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

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, $" SELECT p.id as Id, p.Nombre, p.Porcentaje as Porcentaje
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

        If Decimal.Parse(txtBonificacion.Text) > Decimal.Parse(txtImpACargoOs.Text) Then
            MessageBox.Show("La bonificación no puede ser mayor que el imp. a cargo OS.",
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
        cleanPorcentajeControls()
        btnCleanPlan.Visible = False
        cmbFarmacias.Focus()
    End Sub

    ''prellenar formulario con datos (usado en modificacion)
    Private Sub fillForm(idFarmacia As Long,
                         recetas As Integer,
                         recaudado As Decimal,
                         aCargoOS As Decimal,
                         bonificacion As Decimal,
                         idPlan As Long,
                         observacion As String,
                         mensajeWeb As String)

        cmbFarmacias.SelectedValue = idFarmacia
        cmbPlanes.SelectedValue = idPlan
        txtRecetas.Text = recetas
        txtImpRecaudado.Text = String.Format("{0:N2}", recaudado)
        txtImpACargoOs.Text = String.Format("{0:N2}", aCargoOS)
        txtBonificacion.Text = String.Format("{0:N2}", bonificacion)
        txtObservacion.Text = observacion
        txtMensajeWeb.Text = mensajeWeb

        Dim subtotal = aCargoOS - bonificacion
        lblTotal.Text = String.Format("{0:N2}", subtotal)
    End Sub

    Private Function calcularBonificacion(NombrePorcentaje As String, porcentaje As Decimal, rdbName As String)
        If porcentaje > 0.00 And porcentaje <= 100 Then
            lblNombrePorcentaje.Text = NombrePorcentaje
            txtPorcentaje.Text = porcentaje

            If rdbName = rdbACargoOS.Name And txtImpACargoOs.Text <> "" Then

                txtBonificacion.Text = String.Format("{0:N2}", Decimal.Parse(txtImpACargoOs.Text) * (porcentaje / 100))

                lblTotal.Text = String.Format("{0:N2}", Math.Round(
                                              Decimal.Parse(txtImpACargoOs.Text) - Decimal.Parse(txtBonificacion.Text), 2))

            ElseIf rdbName = rdbRecaudado.Name And txtImpRecaudado.Text <> "" Then

                txtBonificacion.Text = String.Format("{0:N2}", Decimal.Parse(txtImpRecaudado.Text) * (porcentaje / 100))

                If txtImpACargoOs.Text <> "" Then
                    lblTotal.Text = String.Format("{0:N2}", Math.Round(
                              Decimal.Parse(txtImpACargoOs.Text) - Decimal.Parse(txtBonificacion.Text), 2))
                End If


            End If
        End If
    End Function

    Private Sub cleanPorcentajeControls()
        txtPorcentaje.Text = ""
        lblNombrePorcentaje.Text = ""
    End Sub

#End Region

#Region "Eventos"

    Private Sub PresentacionesAgregarItem_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetOsData()
        LlenarCmbFarmacia()
        LlenarCmbPlanes()

        rdbChecked = rdbACargoOS

        If updating Then
            fillForm(
                idFarmacia:=selectedRow.Cells(grdCols.IdFarmacia).Value,
                recetas:=selectedRow.Cells(grdCols.Recetas).Value,
                recaudado:=selectedRow.Cells(grdCols.Recaudado).Value,
                aCargoOS:=selectedRow.Cells(grdCols.ACargoOS).Value,
                bonificacion:=selectedRow.Cells(grdCols.Bonificacion).Value,
                idPlan:=IIf(selectedRow.Cells(grdCols.IdPlan).Value <> "", selectedRow.Cells(grdCols.IdPlan).Value, Nothing),
                observacion:=selectedRow.Cells(grdCols.Observacion).Value,
                mensajeWeb:=selectedRow.Cells(grdCols.mensajeWeb).Value
            )

            cmbFarmacias.Enabled = False
        Else
            cleanForm()
        End If
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

            If cmbPlanes.SelectedItem IsNot Nothing Then
                calcularBonificacion(cmbPlanes.SelectedItem.row(1), cmbPlanes.SelectedItem.row(2), rdbChecked.Name)
            Else
                calcularBonificacion(ObraSocial, PorcentajeOS, rdbChecked.Name)
            End If
        End If
    End Sub

    Private Sub txtImpACargoOs_LostFocus(sender As Object, e As EventArgs) Handles txtImpACargoOs.LostFocus
        If txtImpACargoOs.Text <> "" Then
            Dim subtotal As Decimal = 0
            Dim aCargoOS As Decimal = Decimal.Parse(txtImpACargoOs.Text)

            If cmbPlanes.SelectedItem IsNot Nothing Then
                calcularBonificacion(cmbPlanes.SelectedItem.row(1), cmbPlanes.SelectedItem.row(2), rdbChecked.Name)
            Else
                calcularBonificacion(ObraSocial, PorcentajeOS, rdbChecked.Name)
            End If

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
            If updating Then
                If MessageBox.Show("¿Está seguro que desea modificar la farmacia seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If

                With selectedRow
                    .Cells(grdCols.Nombre).Value = cmbFarmacias.Text
                    .Cells(grdCols.IdFarmacia).Value = cmbFarmacias.SelectedValue
                    .Cells(grdCols.Recetas).Value = Integer.Parse(txtRecetas.Text)
                    .Cells(grdCols.Recaudado).Value = Decimal.Parse(txtImpRecaudado.Text)
                    .Cells(grdCols.ACargoOS).Value = Decimal.Parse(txtImpACargoOs.Text)
                    .Cells(grdCols.Bonificacion).Value = Decimal.Parse(txtBonificacion.Text)
                    .Cells(grdCols.IdPlan).Value = cmbPlanes.SelectedValue
                    .Cells(grdCols.Plan).Value = cmbPlanes.Text
                    .Cells(grdCols.Observacion).Value = txtObservacion.Text
                    .Cells(grdCols.mensajeWeb).Value = txtMensajeWeb.Text
                    .Cells(grdCols.Total).Value = Decimal.Parse(txtImpACargoOs.Text) - Decimal.Parse(txtBonificacion.Text)
                End With

                frmPresentaciones.CalcularTotales()

                Me.Dispose()
                Me.Close()
            ElseIf Not updating Then
                ''add new item
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
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnCleanPlan_Click(sender As Object, e As EventArgs) Handles btnCleanPlan.Click
        cmbPlanes.SelectedItem = Nothing
        btnCleanPlan.Visible = False
        calcularBonificacion(ObraSocial, PorcentajeOS, rdbChecked.Name)

    End Sub

    Private Sub cmbPlanes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPlanes.SelectedIndexChanged
        If cmbPlanes.SelectedItem IsNot Nothing Then
            btnCleanPlan.Visible = True

            If cmbPlanes.SelectedItem IsNot Nothing Then
                calcularBonificacion(cmbPlanes.SelectedItem.row(1), cmbPlanes.SelectedItem.row(2), rdbChecked.Name)
            Else
                calcularBonificacion(ObraSocial, PorcentajeOS, rdbChecked.Name)
            End If
        End If
    End Sub

    Private Sub rdbRecaudado_CheckedChanged(sender As Object, e As EventArgs) Handles rdbRecaudado.CheckedChanged
        If rdbRecaudado.Checked Then
            rdbChecked = rdbRecaudado

            If cmbPlanes.SelectedItem IsNot Nothing Then
                calcularBonificacion(cmbPlanes.SelectedItem.row(1), cmbPlanes.SelectedItem.row(2), rdbRecaudado.Name)
            Else
                calcularBonificacion(ObraSocial, PorcentajeOS, rdbRecaudado.Name)
            End If
        End If

    End Sub

    Private Sub rdbACargoOS_CheckedChanged(sender As Object, e As EventArgs) Handles rdbACargoOS.CheckedChanged
        If rdbACargoOS.Checked Then
            rdbChecked = rdbACargoOS

            If cmbPlanes.SelectedItem IsNot Nothing Then
                calcularBonificacion(cmbPlanes.SelectedItem.row(1), cmbPlanes.SelectedItem.row(2), rdbACargoOS.Name)
            Else
                calcularBonificacion(ObraSocial, PorcentajeOS, rdbACargoOS.Name)
            End If
        End If

    End Sub

    Private Sub txtBonificacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBonificacion.KeyDown
        If e.KeyCode <> Keys.Enter And e.KeyCode <> Keys.Tab Then
            cleanPorcentajeControls()
        End If
    End Sub



#End Region
End Class