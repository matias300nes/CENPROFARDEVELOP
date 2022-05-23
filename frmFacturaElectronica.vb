Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Utiles.Util

Public Class frmFacturaElectronica
    'Declaro las variables que voy a pasarle al frm
    Dim idOrigen As Long

    Public Sub New(idOrigen As Long)

        'Esta llamada es exigida por el diseñador.
        InitializeComponent()

        'Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.idOrigen = idOrigen

    End Sub


    'Varible de transaccion
    Dim tran As SqlClient.SqlTransaction
    Dim conn_del_form As SqlClient.SqlConnection = Nothing

    '-------------------VARIABLES PARA LA AFIP-------------------
    Dim wsfev1 As Object
    Dim WSAA As Object

    'Dim WSAA_Padron As Object

    Dim Path As String
    Dim tra As String, cms As String, ta As String
    Dim wsdl As String, proxy As String, cache As String = ""
    Dim certificado As String, claveprivada As String
    Dim ok, expiracion, tiempoExpirado
    Dim saveTOKEN, saveSING, saveTA As String

    Public concepto, tipo_doc, nro_doc, tipo_cbte, punto_vta,
            cbt_desde, cbt_hasta, imp_total, imp_tot_conc, imp_neto,
            imp_iva, imp_trib, imp_op_ex, fecha_cbte, fecha_venc_pago,
            fecha_serv_desde, fecha_serv_hasta,
            moneda_id, moneda_ctz
    Dim tipo, pto_vta, nro, fecha, cbte_nro
    Dim idIVA, Desc, base_imp, alic, importe
    Dim cae
    'almaceno nro de factura 
    Dim nroFactura
    Dim cae2

    'Variable para asignar el tipo de documento del cliente
    Dim TipoDoc As Integer
    Dim TopeCuit As Integer
    Public ValorCae As String
    Public ValorFac As String
    Public ValorVen As String

    Dim banNota As Integer, bandComp As Integer

    Private Sub btnGenerarFE_Click(sender As Object, e As EventArgs) Handles btnGenerarFE.Click
        Dim importe_iva, importe_subtotal, importe_total
        Dim resbool As Boolean = False
        importe_iva = 0
        importe_subtotal = 0
        importe_total = 0

        If True Then 'preguntar si desea generar la factura, para la obra social
            chkConexion.Checked = ConexionAfip(saveTA, saveTOKEN, saveSING)
            If chkConexion.Checked Then
                'debo comprobar el caso de que eligan tarjeta de credito o tarjeta de debito
                resbool = GenerarFE(sender, e, CInt(cmbTipoComprobante.SelectedValue), CInt(PTOVTA), TipoDoc, txtCuit.Text, importe_iva, importe_subtotal, importe_total, 1, txtID.Text)
                If resbool = False Then
                    MsgBox("No se pudo generar la factura electrónica.", MsgBoxStyle.Critical)
                    Cancelar_Tran()
                    'txtCodigoBarra.Focus()
                    Exit Sub
                Else
                    ValorCae = ""
                    ValorFac = ""
                    ValorVen = ""
                End If
            Else
                MsgBox("Se perdió la conexión con Servidor de AFIP. Por favor intente más tarde", MsgBoxStyle.Information)
                Cancelar_Tran()
                'txtCodigoBarra.Focus()
                Exit Sub
            End If
        Else
            'cierro la transaccion
            Cerrar_Tran()
        End If

        ' cerrar la conexion si está abierta.
        '
        If Not conn_del_form Is Nothing Then
            CType(conn_del_form, IDisposable).Dispose()
        End If

    End Sub

    'VALORES DE REFERENCIA
    Dim ref_email As String, ref_direccion As String


    Dim HOMO As Boolean '= False
    Dim TicketAccesoBool As Boolean '= False
    Dim PTOVTA As String '= False
    Dim CorreoContador As String

    Dim cuitEmpresa As String = ""
    Dim ModoPagoPredefinido As String
    Dim ClienteModificado As Long
    Dim DesdeCmbCliente As Boolean
    '-----------------FIN VARIABLES AFIP----------------------

    Enum TipoComp

        FacturaA = 1
        NotaDebitoA = 2
        NotaCreditoA = 3
        FacturaB = 6
        NotaDebitoB = 7
        NotaCreditoB = 8
        FacturaC = 11
        NotaDebitoC = 12
        NotaCreditoC = 13
        FacturaM = 51
        NotaDebitoM = 52
        NotaCreditoM = 53

    End Enum

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
        'Dim connection As SqlClient.SqlConnection = Nothing
        'Dim dt As New DataTable()
        'Dim sql As String = $"exec spHistorialCta_SelectByIdFarmacia @IdFarmacia = {txtID.Text}"
        'If txtID.Text <> "" Then
        '    Try
        '        connection = SqlHelper.GetConnection(ConnStringSEI)

        '        Dim cmd As New SqlCommand(sql, connection)
        '        Dim da As New SqlDataAdapter(cmd)

        '        da.Fill(dt)

        '        'grdHistorial.DataSource = dt
        '    Catch ex As Exception
        '        MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Exit Sub
        '    End Try
        'End If

    End Sub

    '----------------Funciones Afip--------------------
    Private Sub LlenarcmbCondicionIVA()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT Codigo,Descripcion FROM Responsables WHERE Habilitado = 1  ORDER BY Descripcion")
            ds.Dispose()

            With cmbCondicionIVA
                .DataSource = ds.Tables(0).DefaultView
                .DisplayMember = "Descripcion"
                .ValueMember = "Codigo"
            End With

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se provocó un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub


    Private Sub LlenarcmbComprobantes()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            'If chkNotaCredito.Checked = False Then
            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT Codigo,Descripcion FROM Comprobantes WHERE Habilitado = 1")
                'Else
                '    ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT Codigo,Descripcion FROM Comprobantes WHERE Habilitado = 1")
                'End If
                ds.Dispose()

            With cmbTipoComprobante
                .DataSource = ds.Tables(0).DefaultView
                .DisplayMember = "Descripcion"
                .ValueMember = "Codigo"
            End With

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se provocó un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub LlenarcmbConceptosFE()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT Codigo, UPPER(Descripcion) AS Descripcion FROM ConceptosFE WHERE Habilitado = 1")

            ds.Dispose()

            With cmbConceptosFE
                .DataSource = ds.Tables(0).DefaultView
                .DisplayMember = "Descripcion"
                .ValueMember = "Codigo"
            End With

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se provocó un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub LlenarcmbTipoDocumento()
        Dim connection As SqlClient.SqlConnection = Nothing
        Dim ds As Data.DataSet

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try

            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT Codigo, Descripcion FROM TipoDocumento WHERE Habilitado = 1")

            ds.Dispose()

            With cmbDocTipo
                .DataSource = ds.Tables(0).DefaultView
                .DisplayMember = "Descripcion"
                .ValueMember = "Codigo"
            End With

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se provocó un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub


    Public Function ConexionAfip(ByVal TicketAcceso As Object, ByVal Token As Object, ByVal Sign As Object) As Boolean

        'FACTURA ELECTRONICA
        '
        ' Crear objeto interface Web Service Autenticación y Autorización
        Try
            WSAA = CreateObject("WSAA")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            ' cargar ticket de acceso previo (si no se mantiene WSAA instanciado en memoria)
            If TicketAcceso <> "" Then
                ok = WSAA.AnalizarXml(TicketAcceso)
            End If


            ' Procedimiento para autenticar con AFIP y reutilizar el ticket de acceso
            ' Llamar antes de utilizar WSAA.Token y WSAA.Sign (WSAA debe estar definido a nivel de módulo)
            Dim solicitar

            ' revisar si el ticket es válido y no ha expirado:
            expiracion = WSAA.ObtenerTagXml("expirationTime")
            Debug.Print("Fecha Expiracion ticket: ", expiracion)
            If IsDBNull(expiracion) Then
                solicitar = True                           ' solicitud inicial
            Else
                solicitar = WSAA.Expirado(expiracion)      ' chequear solicitud previa
            End If

            'Reutilizacion de TA 
            If solicitar Then

                tra = WSAA.CreateTRA("wsfe")

                Path = Application.StartupPath + "\AFIP\"
                ' Certificado: certificado es el firmado por la AFIP
                ' ClavePrivada: la clave privada usada para crear el certificado
                If HOMO = True Then
                    certificado = Empresa + "_homo.crt"
                    claveprivada = Empresa + "_homo.key"
                Else
                    certificado = Empresa + ".crt"
                    claveprivada = Empresa + ".key"
                End If

                cms = WSAA.SignTRA(tra, Path + certificado, Path + claveprivada)

                cache = ""
                proxy = ""

                If HOMO = True Then
                    wsdl = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms?wsdl"
                Else
                    wsdl = "https://wsaa.afip.gov.ar/ws/services/LoginCms?wsdl"

                End If

                WSAA.Conectar(cache, wsdl, proxy)
                'ta = WSAA.LoginCMS(cms)
                saveTA = WSAA.LoginCMS(cms)

                ' Obtener las credenciales del ticket de acceso (desde el XML por si no se conserva el objeto WSAA)
                saveTOKEN = WSAA.ObtenerTagXml("token")
                saveSING = WSAA.ObtenerTagXml("sign")

                Dim connection As SqlClient.SqlConnection = Nothing
                Dim ds As Data.DataSet

                Try
                    connection = SqlHelper.GetConnection(ConnStringSEI)
                Catch ex As Exception
                    MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Function
                End Try

                Try
                    ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, "UPDATE Parametros set TicketAcceso = '" & saveTA & "', Token = '" & saveTOKEN & "', Sign = '" & saveSING & "'")
                    ds.Dispose()
                Catch ex As Exception

                End Try


            Else
                Debug.Print("no expirado!", "Reutilizando!")
            End If



            ' Al retornar se puede utilizar token y sign para WSFEv1 o similar
            ' Devuelvo el ticket de acceso (RETURN) para que el programa principal lo almacene si es necesario:

            'MessageBox.Show(ta, "Ticket de Acceso")
            'If TicketAcceso = True Then
            '    MsgBox(ta.ToString)
            'End If

        Catch
            ' Muestro los errores
            If WSAA.Excepcion <> "" Then
                MsgBox(WSAA.Traceback, vbExclamation, WSAA.Excepcion)
                MsgBox(WSAA.Excepcion, vbExclamation, WSAA.Excepcion)
                ConexionAfip = False
                Exit Function
                'Me.Close()
            End If
        End Try

        wsfev1 = CreateObject("WSFEv1")
        wsfev1.LanzarExcepciones = False

        Try

            ' Setear tocken y sing de autorización (pasos previos)
            'wsfev1.Token = WSAA.Token
            'wsfev1.Sign = WSAA.Sign

            'Token = WSAA.Token
            'Sign = WSAA.Sign

            wsfev1.Token = saveTOKEN
            wsfev1.Sign = saveSING

            'Select Case Empresa
            '    Case "ACER"
            '        wsfev1.Cuit = "20146486569" 'homo 20146486569 prod 30708425733
            '    Case "ANCOA"
            '        wsfev1.Cuit = "30673525845" 'homo 20923232371 prod 30673525845
            '    Case "ALBERTO"
            '        wsfev1.Cuit = "20291813128"
            'End Select
            ' CUIT del emisor (debe estar registrado en la AFIP)
            wsfev1.Cuit = cuitEmpresa

            ' Conectar al Servicio Web de Facturación
            proxy = "" ' "usuario:clave@localhost:8000"

            If HOMO = True Then
                wsdl = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx?WSDL"
            Else
                wsdl = "https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL"
            End If

            cache = "" 'Path

            ok = wsfev1.Conectar(cache, wsdl, proxy) ' homologación


            REM ' Llamo a un servicio nulo, para obtener el estado del servidor (opcional)
            Try
                wsfev1.Dummy()
                PicConexion.Image = My.Resources.Green_Ball_icon
            Catch ex As Exception
                PicConexion.Image = My.Resources.Red_Ball_icon
                ConexionAfip = False
                Exit Function
            End Try

            If wsfev1.ErrMsg <> "" Then
                MsgBox(wsfev1.ErrMsg, vbExclamation, "Errores")
                ConexionAfip = False
                Exit Function
            End If

            If wsfev1.Obs <> "" Then
                MsgBox(wsfev1.Obs, vbExclamation, "Observaciones")
                ConexionAfip = False
                Exit Function
            End If

        Catch

            ' Muestro los errores
            If wsfev1.Traceback <> "" Then
                MsgBox(wsfev1.Traceback, vbExclamation, "Error")
                ConexionAfip = False
                Exit Function
            End If

        End Try

        ConexionAfip = True

    End Function

    Public Function GenerarFE(sender As Object, e As EventArgs, ByVal tipo_comprobante As Integer, ByVal punto_venta As Integer, ByVal tipo_documento As Integer, ByVal num_documento As String, ByVal import_iva As String, ByVal subtotal As String, ByVal total As String, ByVal concept As Integer, ByVal IdFactura As Long) As Boolean
        Try


            Dim CaeGenerado As String
            Dim FechaGenerado As String



            tipo_cbte = tipo_comprobante
            ' cbte_nro = "" 'param

            punto_vta = punto_venta 'param

            fecha = Format(dtpFECHA.Value.Date, "yyyyMMdd") 'param
            'concepto en este caso es siempre producto
            concepto = concept 'param
            tipo_doc = tipo_documento 'param
            nro_doc = num_documento 'param

            imp_trib = "0.00"
            imp_op_ex = "0.00"

            'Verifico nro de comp y aumento si es necesario

            cbte_nro = wsfev1.CompUltimoAutorizado(tipo_cbte, punto_vta)

            If cbte_nro = "" Then
                cbte_nro = 0                ' no hay comprobantes emitidos
            Else
                cbte_nro = CLng(cbte_nro) ' convertir a entero largo
            End If


            nroFactura = cbte_nro + 1 'Format(cbte_nro + 1, "0000000000")

            'nro de factura 
            cbt_desde = nroFactura 'param
            cbt_hasta = nroFactura 'param

            ', ByVal num_factura As Integer

            If tipo_cbte = TipoComp.FacturaA Or
                tipo_cbte = TipoComp.NotaDebitoA Or
                tipo_cbte = TipoComp.NotaCreditoA Or
                tipo_cbte = TipoComp.FacturaM Or
                tipo_cbte = TipoComp.NotaDebitoM Or
                tipo_cbte = TipoComp.NotaCreditoM Then

                imp_tot_conc = "0.00"
                imp_neto = FormatNumber(CDec(subtotal), 2) 'param
                imp_neto = Replace(Replace(imp_neto, ".", ""), ",", ".")
            End If

            If tipo_cbte = TipoComp.FacturaB Or
                tipo_cbte = TipoComp.NotaDebitoB Or
                tipo_cbte = TipoComp.NotaDebitoB Or
                tipo_cbte = TipoComp.FacturaC Or
                tipo_cbte = TipoComp.NotaDebitoC Or
             tipo_cbte = TipoComp.NotaCreditoC Then

                imp_tot_conc = FormatNumber(CDbl(subtotal), 2) 'param
                imp_tot_conc = Replace(Replace(imp_tot_conc, ".", ""), ",", ".")
                imp_neto = "0.00"
            End If

            'imp_iva = FormatNumber(CDec(txtIva21.Text) + CDec(txtIva10.Text), 2) 'param
            'imp_iva = Replace(Replace(imp_iva, ".", ""), ",", ".")
            imp_iva = FormatNumber(CDec(import_iva), 2) 'param
            imp_iva = Replace(Replace(imp_iva, ".", ""), ",", ".")

            'imp_total = FormatNumber(CDbl(txtTotal.Text), 2) 'param
            'imp_total = Replace(Replace(imp_total, ".", ""), ",", ".")
            imp_total = FormatNumber(CDbl(total), 2) 'param
            imp_total = Replace(Replace(imp_total, ".", ""), ",", ".")

            fecha_cbte = Format(dtpFECHA.Value.Date, "yyyyMMdd")

            ' Fechas del período del servicio facturado (solo si concepto = 1?)
            If CInt(cmbConceptosFE.SelectedValue) = 2 Or CInt(cmbConceptosFE.SelectedValue) = 3 Then
                If TipoComp.NotaCreditoA Or TipoComp.NotaCreditoB Or TipoComp.NotaDebitoA Or TipoComp.NotaDebitoB Or
                    TipoComp.NotaDebitoM Or TipoComp.NotaDebitoM Then
                    fecha_venc_pago = Format(Today.Date, "yyyyMMdd")
                Else
                    fecha_venc_pago = Format(dtpVtoPago.Value.Date, "yyyyMMdd")
                End If
                fecha_serv_desde = Format(dtpDesde.Value.Date, "yyyyMMdd")
                fecha_serv_hasta = Format(dtpHasta.Value.Date, "yyyyMMdd")
            Else
                fecha_venc_pago = ""
                fecha_serv_desde = ""
                fecha_serv_hasta = ""
            End If

            moneda_id = "PES" : moneda_ctz = "1.000"




            ok = wsfev1.CrearFactura(concepto, tipo_doc, nro_doc, tipo_cbte, punto_vta,
                    cbt_desde, cbt_hasta, imp_total, imp_tot_conc, imp_neto,
                    imp_iva, imp_trib, imp_op_ex, fecha_cbte, fecha_venc_pago,
                    fecha_serv_desde, fecha_serv_hasta,
                    moneda_id, moneda_ctz)

            'Dim i As Integer
            'Dim CantidadFilas As Integer

            'If grdItems.RowCount = 16 Then
            '    CantidadFilas = grdItems.Rows.Count
            'Else
            '    CantidadFilas = grdItems.Rows.Count
            'End If

            'Dim total10 As Decimal
            Dim total21 As Decimal
            'total21 toma el valor del subtotal.
            total21 = subtotal

            ' 1 Factura A
            ' 2 Nota Debito A
            ' 3 Nota Credito A
            ' 51 Factura M
            ' 52 Nota Debito M 
            ' 53 Nota Credito M

            If tipo_cbte = TipoComp.FacturaA Or
                tipo_cbte = TipoComp.NotaDebitoA Or
                tipo_cbte = TipoComp.NotaCreditoA Or
                tipo_cbte = TipoComp.FacturaM Or
                tipo_cbte = TipoComp.NotaDebitoM Or
                tipo_cbte = TipoComp.NotaCreditoM Then

                '' Agrego tasas de IVA 
                'i = 0
                'Do While i < CantidadFilas
                '    If grdItems.Rows(i).Cells(ColumnasDelGridItems.iva).Value = "10,5" Then
                '        total10 += grdItems.Rows(i).Cells(ColumnasDelGridItems.SubTotalProd).Value
                '    End If
                '    If grdItems.Rows(i).Cells(ColumnasDelGridItems.iva).Value = "21,0" Then
                '        total21 += grdItems.Rows(i).Cells(ColumnasDelGridItems.SubTotalProd).Value
                '    End If
                '    i += 1
                'Loop

                'If total10 > 0 Then
                '    idIVA = 4 ' 10.5%
                '    base_imp = FormatNumber(CDbl(total10.ToString), 2) 'param
                '    base_imp = Replace(Replace(base_imp, ".", ""), ",", ".")
                '    importe = FormatNumber(CDbl(txtIva10.Text), 2) 'param
                '    importe = Replace(Replace(importe, ".", ""), ",", ".")
                '    ok = wsfev1.AgregarIva(idIVA, base_imp, importe)
                'End If

                'total21 es el total con iva. el iva esta sin discriminar
                '------------------------DESCOMENTAR SI ES NECESARIO--------------
                '    If total21 > 0 Then
                '        idIVA = 5 ' 21%
                '        base_imp = FormatNumber(CDbl(total21.ToString), 2) 'param
                '        base_imp = Replace(Replace(base_imp, ".", ""), ",", ".")
                '        importe = FormatNumber(CDbl(txtIva21.Text), 2) 'param
                '        importe = Replace(Replace(importe, ".", ""), ",", ".")
                '        ok = wsfev1.AgregarIva(idIVA, base_imp, importe)
                '    End If
                '--------------------------------------------------------------------

                '-----------------CODIGO ANTERIOR MODIFICADO----------------
                If total21 > 0 Then
                    idIVA = 5 '21% codigo que esta en la tabla condicionIVA
                    base_imp = FormatNumber(CDbl(total21.ToString), 2) 'param
                    'base_imp = FormatNumber(CDbl(total21), 2) 'param
                    base_imp = Replace(Replace(base_imp, ".", ""), ",", ".")
                    'importe = FormatNumber(CDbl(imp_iva.ToString), 2) 'param
                    importe = FormatNumber(CDbl(import_iva.ToString), 2) 'param
                    'importe = FormatNumber(CDbl(imp_iva), 2) 'param
                    'importe = imp_iva 'param
                    importe = Replace(Replace(importe, ".", ""), ",", ".")
                    'importe = Replace(importe, ",", ".")
                    ok = wsfev1.AgregarIva(idIVA, base_imp, importe)
                End If
                '------------------------------------------------------------------------
            End If

            ' Agrego los comprobantes asociados: ' solo nc/nd
            'If CInt(tipo_cbte) = "2" Or _
            '    CInt(tipo_cbte) = "3" Or _
            '    CInt(tipo_cbte) = "7" Or _
            '    CInt(tipo_cbte) = "8" Or _
            '    CInt(tipo_cbte) = "52" Or _
            '    CInt(tipo_cbte) = "53" Then
            '    'cambiar la variable que sigue
            '    'tipo toma el valor del nro del tipo de comprobante
            '    'tipo = CInt(CmbComprobantes.SelectedValue)
            '    tipo = tipo_cbte
            '    'pto_vta = PTOVTA
            '    pto_vta = punto_venta
            '    'NroFactura
            '    'nro = CInt(CmbComprobantes.Text)
            '    'nro = num_factura
            '    ok = wsfev1.AgregarCmpAsoc(tipo, pto_vta, nro)
            'End If


            '-----------------------------------------------------------------------------
            'If CInt(cmbTipoComprobante.SelectedValue) = TipoComp.NotaDebitoA Or _
            '    CInt(cmbTipoComprobante.SelectedValue) = TipoComp.NotaCreditoA Or _
            '    CInt(cmbTipoComprobante.SelectedValue) = TipoComp.NotaDebitoB Or _
            '    CInt(cmbTipoComprobante.SelectedValue) = TipoComp.NotaCreditoB Or _
            '    CInt(cmbTipoComprobante.SelectedValue) = TipoComp.NotaDebitoM Or _
            '    CInt(cmbTipoComprobante.SelectedValue) = TipoComp.NotaCreditoM Then
            '    tipo = CInt(CmbComprobantes.SelectedValue)
            '    pto_vta = PTOVTA
            '    nro = CInt(CmbComprobantes.Text)
            '    ok = wsfev1.AgregarCmpAsoc(tipo, pto_vta, nro)
            'End If

            ' Habilito reprocesamiento automático (predeterminado):
            wsfev1.Reprocesar = True

            ' Solicito CAE:
            cae = wsfev1.CAESolicitar()


            Debug.Print("Resultado", wsfev1.Resultado)
            Debug.Print("CAE", wsfev1.CAE)
            Debug.Print("Numero de comprobante:", wsfev1.CbteNro)
            '------------------------------------------------
            'Dim strCadena As String
            'strCadena = wsfev1.f1GuardarTicketAcceso()
            'guardar strCadena en un archivo temporal
            'wsfev1.f1RestaurarTicketAcceso(strCadena)
            '-----------------------------------------------

            'Retorno valor de ok, booleano (comprobar) 
            'Return ok


            If wsfev1.Resultado = "A" Then

                CaeGenerado = wsfev1.CAE.ToString
                FechaGenerado = wsfev1.Vencimiento.ToString

                'ContinuarFactura:
                'Cierro la Transaccion para guardar la Venta para luego realizar el update
                Cerrar_Tran()

                MsgBox("Factura Aceptada" + Chr(13) + "CAE: " + wsfev1.CAE.ToString + Chr(13) + "Vencimiento: " + wsfev1.Vencimiento.ToString)

                Dim CodigoBarra As String
                CodigoBarra = cuitEmpresa.ToString + cmbTipoComprobante.SelectedValue.ToString.PadLeft(2, "00").ToString + punto_vta + CaeGenerado + FechaGenerado
                'CodigoBarra = DigitoVerificador(CodigoBarra)
                Select Case InsertFacturacion_FEAFIP(wsfev1.CAE.ToString, wsfev1.Vencimiento.ToString, CodigoBarra, IdFactura, tipo_comprobante)
                    Case Is <= 0
                        MessageBox.Show("Se produjo un error al insertar el CAE y el vencimiento en el sistema local.", "Control de errores", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select

                'Imprimir(nroFactura, cmbTipoComprobante.Text.ToString)

                ValorCae = wsfev1.CAE.ToString
                ValorFac = PTOVTA.ToString.PadLeft(4, "0000") + "-" + nroFactura.ToString.PadLeft(8, "00000000")
                Dim Fecha As String = wsfev1.Vencimiento.ToString
                Fecha = Fecha.Substring(6, 2) + "/" + Fecha.Substring(4, 2) + "/" + Fecha.Substring(0, 4)
                ValorVen = Fecha

                'cmbTipoComprobante_SelectedIndexChanged(sender, e)

                'band = 0
                'bolModo = False
                'btnActualizar_Click(sender, e)

                'chkEnviarCorreo.Enabled = True

                'SQL = "exec sp_Consumos_Select_All @eliminado = 0"
                'LlenarGrilla()

                'CalcularTotales()

                'grdItems.Enabled = bolModo
                'btnGuardar.Enabled = bolModo
                'Util.MsgStatus(Status1, "El comprobante se generó correctamente.", My.Resources.Resources.ok.ToBitmap)
                'band = 1

                'GestionDePaneles()

                'btnPrevisualizar.Enabled = bolModo
                GenerarFE = True
            Else
                Cancelar_Tran()

                If WSAA.Excepcion <> "" Then
                    ' muestro al usuario solo el mensaje de error, no la traza:
                    MsgBox(WSAA.Excepcion, vbCritical, "Excepción")
                End If

                'Error/obs
                If wsfev1.ErrMsg <> "" Then
                    MsgBox(wsfev1.ErrMsg, vbExclamation, "Errores")
                End If

                If wsfev1.Obs <> "" Then
                    MsgBox(wsfev1.Obs, vbExclamation, "Observaciones")
                End If

                GenerarFE = False
                Exit Function

            End If

            'btnConfirmarPago.Enabled = True


        Catch ex As Exception

            GenerarFE = False

        End Try

    End Function

    Public Function InsertFacturacion_FEAFIP(ByVal numeroCAE As String, ByVal vtoCAE As String, ByVal CodigoBarra As String, ByVal IdFactura As Long, ByVal CodComprobante As Integer) As Integer
        Dim res As Integer = 0

        Dim connection As SqlClient.SqlConnection = Nothing

        Try
            connection = SqlHelper.GetConnection(ConnStringSEI)
        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End Try

        Try
            Try
                Dim param_id As New SqlClient.SqlParameter
                param_id.ParameterName = "@idFacturacion"
                param_id.SqlDbType = SqlDbType.BigInt
                param_id.Value = IdFactura
                param_id.Direction = ParameterDirection.Input

                Dim param_cae As New SqlClient.SqlParameter
                param_cae.ParameterName = "@cae"
                param_cae.SqlDbType = SqlDbType.VarChar
                param_cae.Size = 50
                param_cae.Value = numeroCAE
                param_cae.Direction = ParameterDirection.Input

                Dim param_Venc_CAE As New SqlClient.SqlParameter
                param_Venc_CAE.ParameterName = "@Venc_CAE"
                param_Venc_CAE.SqlDbType = SqlDbType.VarChar
                param_Venc_CAE.Size = 10
                param_Venc_CAE.Value = vtoCAE
                param_Venc_CAE.Direction = ParameterDirection.Input

                Dim param_CodigoBarra As New SqlClient.SqlParameter
                param_CodigoBarra.ParameterName = "@CodigoBarra"
                param_CodigoBarra.SqlDbType = SqlDbType.VarChar
                param_CodigoBarra.Size = 100
                param_CodigoBarra.Value = CodigoBarra
                param_CodigoBarra.Direction = ParameterDirection.Input

                Dim param_ComprobanteNro As New SqlClient.SqlParameter
                param_ComprobanteNro.ParameterName = "@ComprobanteNro"
                param_ComprobanteNro.SqlDbType = SqlDbType.BigInt
                param_ComprobanteNro.Value = nroFactura
                param_ComprobanteNro.Direction = ParameterDirection.Input

                Dim param_ComprobanteTipo As New SqlClient.SqlParameter
                param_ComprobanteTipo.ParameterName = "@ComprobanteTipo"
                param_ComprobanteTipo.SqlDbType = SqlDbType.Int
                param_ComprobanteTipo.Value = CodComprobante
                param_ComprobanteTipo.Direction = ParameterDirection.Input

                Dim param_ConceptoTipo As New SqlClient.SqlParameter
                param_ConceptoTipo.ParameterName = "@ConceptoTipo"
                param_ConceptoTipo.SqlDbType = SqlDbType.Int
                param_ConceptoTipo.Value = 1
                param_ConceptoTipo.Direction = ParameterDirection.Input

                Dim param_res As New SqlClient.SqlParameter
                param_res.ParameterName = "@res"
                param_res.SqlDbType = SqlDbType.Int
                param_res.Value = DBNull.Value
                param_res.Direction = ParameterDirection.InputOutput

                Try
                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "spVentas_Salon_Update_FEAFIP",
                                              param_id, param_cae, param_Venc_CAE, param_CodigoBarra, param_ComprobanteNro, param_ComprobanteTipo, param_ConceptoTipo, param_res)

                    res = param_res.Value

                Catch ex As Exception
                    Throw ex
                End Try

                InsertFacturacion_FEAFIP = res

            Catch ex2 As Exception
                Throw ex2
            Finally

            End Try
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("Se produjo un problema al procesar la información en la Base de Datos, por favor, valide el siguiente mensaje de error: {0}" _
              + Environment.NewLine + "Si el problema persiste contáctese con MercedesIt a través del correo soporte@mercedesit.com", errMessage),
              "Error en la Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Function


    '----------------FIN Funciones Afip--------------------


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

    Private Sub Verificar_Datos()

        'bolpoliticas = False

        '----------------------------------CONTROLO EL TOTAL
        If txtImporte.Text = "" Or CDbl(txtImporte.Text) <= 0 Then
            MsgBox("El Total de la venta realizado no es correcto. Por favor, controle el dato.", MsgBoxStyle.Information, "Atención")
            Exit Sub
        End If
        '---------------------------------CONTROLO DESCUENTO
        'me fijo si se plico un descuento global sin monto
        'If chkDescuentoGlobal.Checked And txtDescuento.Text = "" Then
        '    chkDescuentoGlobal.Checked = False
        'End If

        'control de Responsables y Comprobante
        'If chkDevolucion.Checked = False Then
        If cmbTipoComprobante.SelectedValue.ToString = "001" And cmbCondicionIVA.SelectedValue.ToString <> "1" Then
            MsgBox("La concición de IVA o el tipo de factura seleccionada no es correcto. Por favor, controle el dato.", MsgBoxStyle.Information, "Atención")
            Exit Sub
        Else
            If cmbTipoComprobante.SelectedValue.ToString = "006" And cmbCondicionIVA.SelectedValue.ToString = "1" Then
                MsgBox("La concición de IVA o el tipo de factura seleccionada no es correcto. Por favor, controle el dato.", MsgBoxStyle.Information, "Atención")
                Exit Sub
            End If
        End If
        'Else
        If cmbTipoComprobante.SelectedValue.ToString = "003" And cmbCondicionIVA.SelectedValue.ToString <> "1" Then
            MsgBox("La concición de IVA o el tipo de factura seleccionada no es correcto. Por favor, controle el dato.", MsgBoxStyle.Information, "Atención")
            Exit Sub
        Else
            If cmbTipoComprobante.SelectedValue.ToString = "008" And cmbCondicionIVA.SelectedValue.ToString = "1" Then
                MsgBox("La concición de IVA o el tipo de factura seleccionada no es correcto. Por favor, controle el dato.", MsgBoxStyle.Information, "Atención")
                Exit Sub
            End If
        End If
        'End If

        If cmbCondicionIVA.SelectedValue = "5" And txtCuit.Text = "" Then
            txtCuit.Text = "11111111"
        End If

        '------------------------------controlo datos del cliente
        If cmbTipoComprobante.SelectedValue.ToString = "001" Or cmbTipoComprobante.SelectedValue.ToString = "003" Then
            If txtCuit.Text.Length <> 11 Then
                MsgBox("El nro de CUIT no cumple con el requisito de 11 dígitos. Por favor, controle el dato.", MsgBoxStyle.Information, "Atención")
                txtCuit.Focus()
                Exit Sub
            End If

            If cmbObrasSociales.Text.Length > 30 Or cmbObrasSociales.Text.Length = 0 Then
                MsgBox("El Nombre del cliente no cumple con el requisito de 30 caracteres. Por favor, controle el dato.", MsgBoxStyle.Information, "Atención")
                cmbObrasSociales.Focus()
                Exit Sub
            End If
        End If

        '--------------------------------CONTROLO EL RESTO

        '----------------------------------CONTROLO DATOS DE CLIENTES
        If Not cmbCondicionIVA.Text = "CONSUMIDOR FINAL" Then
            Select Case cmbTipoComprobante.Text
                Case "CUIL"
                    If txtCuit.Text.Length <> 11 Then
                        MsgBox("El nro de CUIL no cumple con el requisito de 11 dígitos. Por favor, controle el dato.", MsgBoxStyle.Information, "Atención")
                        txtCuit.Focus()
                        Exit Sub
                    End If
                Case "CUIT"
                    If txtCuit.Text.Length <> 11 Then
                        MsgBox("El nro de CUIT no cumple con el requisito de 11 dígitos. Por favor, controle el dato.", MsgBoxStyle.Information, "Atención")
                        txtCuit.Focus()
                        Exit Sub
                    End If
                Case "DNI"
                    If txtCuit.Text.Length <> 7 Or txtCuit.Text.Length <> 8 Then
                        MsgBox("El nro de DNI no cumple con el requisito de 8 dígitos. Por favor, controle el dato.", MsgBoxStyle.Information, "Atención")
                        txtCuit.Focus()
                        Exit Sub
                    End If
            End Select
        Else
            If txtCuit.Text <> "" Then
                If txtCuit.Text.Length <> 11 Or txtCuit.Text <> 8 Or txtCuit.Text.Length <> 7 Then
                    MsgBox("El nro de DNI/CUIT no cumple con el requisito de 11 dígitos. Por favor, controle el dato.", MsgBoxStyle.Information, "Atención")
                    txtCuit.Focus()
                    Exit Sub
                End If
            End If
        End If
        '--------------------------CONTROLO GRILLA
        'Dim i As Integer, j As Integer, filas As Integer ', state As Integer

        'Util.MsgStatus(Status1, "Verificando los datos...", My.Resources.Resources.indicator_white)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''Verificar si se terminó de editar la celda...
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'If editando_celda Then
        '    Util.MsgStatus(Status1, "Use [Enter] o [Tab] para salir del modo edición, antes de guardar.", My.Resources.Resources.alert.ToBitmap)
        '    Util.MsgStatus(Status1, "Use [Enter] o [Tab] para salir del modo edición, antes de guardar.", My.Resources.Resources.alert.ToBitmap, True)
        '    Exit Sub
        'End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''verificar que no hay nada en la grilla sin datos
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'j = grdItems.RowCount - 1
        'filas = 0
        'For i = 0 To j
        '    'state = grdItems.Rows.GetRowState(i)
        '    'la fila está vacía ?
        '    If fila_vacia(i) Then
        '        Try
        '            'encotramos una fila vacia...borrarla y ver si hay mas
        '            grdItems.Rows.RemoveAt(i)

        '            j = j - 1 ' se reduce la cantidad de filas en 1
        '            i = i - 1 ' se reduce para recorrer la fila que viene 
        '        Catch ex As Exception
        '        End Try

        '    Else
        '        filas = filas + 1
        '        'idmaterial es valido?
        '        If grdItems.Rows(i).Cells(ColumnasDelGridItems.CodMaterial).Value Is System.DBNull.Value Then
        '            Util.MsgStatus(Status1, "Falta completar el material en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap)
        '            Util.MsgStatus(Status1, "Falta completar el material en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap, True)
        '            Exit Sub
        '        End If
        '        'Descripcion del material es válida ?
        '        If grdItems.Rows(i).Cells(ColumnasDelGridItems.CodMaterial).Value.ToString.ToLower = "No Existe".ToLower Then
        '            Util.MsgStatus(Status1, "El material ingresado no es válido en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap)
        '            Util.MsgStatus(Status1, "El material ingresado no es válido en la fila: " & (i + 1).ToString, My.Resources.Resources.alert.ToBitmap, True)
        '            Exit Sub
        '        End If
        '    End If

        '    'controlo los valores de descuento
        '    If grdItems.Rows(i).Cells(ColumnasDelGridItems.Descuento).Value Is DBNull.Value Then
        '        grdItems.Rows(i).Cells(ColumnasDelGridItems.Descuento).Value = 0
        '    End If

        'Next i


        'If chkDevolucion.Checked Then
        '    txtTotalVista.Text = "-" + txtTotalVista.Text
        '    txtSubtotalVista.Text = "-" + txtSubtotalVista.Text
        '    txtIVAVista.Text = "-" + txtIVAVista.Text
        '    txtTotalOriginal.Text = "-" + txtTotalOriginal.Text
        '    lblValorDescontado.Text = IIf(CDbl(lblValorDescontado.Text) > 0, "-" + lblValorDescontado.Text, lblValorDescontado.Text)
        '    txtContado.Text = IIf(CDbl(txtContado.Text) > 0, "-" + txtContado.Text, txtContado.Text)
        '    txtTarjetas1ImporteFinal.Text = IIf(CDbl(txtTarjetas1ImporteFinal.Text) > 0, "-" + txtTarjetas1ImporteFinal.Text, txtTarjetas1ImporteFinal.Text)
        '    txtTarjetas2ImporteFinal.Text = IIf(CDbl(txtTarjetas2ImporteFinal.Text) > 0, "-" + txtTarjetas2ImporteFinal.Text, txtTarjetas2ImporteFinal.Text)
        'End If

        'bolpoliticas = True

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
        LlenarcmbTipoDocumento()
        LlenarcmbCondicionIVA()
        LlenarcmbComprobantes()

        requestGrdData()
        If txtID.Text <> "" Then
            setStyles()
        End If

        getFieldsParametros()
    End Sub

    Private Sub getFieldsParametros()

        '------------------------------------------------------Parametros
        Dim ds_Equipos As Data.DataSet
        Dim connection As SqlClient.SqlConnection = Nothing
        Try

            connection = SqlHelper.GetConnection(ConnStringSEI)

        Catch ex As Exception
            MessageBox.Show("No se pudo conectar con la Base de Datos. Consulte con su Administrador.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        Try
            ds_Equipos = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT PTOVTA,DescuentoMaximo,TopeFacturacion,NombreEmpresaFactura, ModoPagoPredefinido, CUIT, HOMO, TA,ISNULL(CorreoContador,''), TicketAcceso, Token, Sign FROM PARAMETROS")
            'lblPVI.Text = ds_Equipos.Tables(0).Rows(0).Item(0).ToString
            'PTOVTA = ds_Equipos.Tables(0).Rows(0).Item(0).ToString
            'DescuentoMaximo = ds_Equipos.Tables(0).Rows(0).Item(1).ToString
            'TopePorcenFac = ds_Equipos.Tables(0).Rows(0).Item(2)
            Utiles.Empresa = LTrim(RTrim(ds_Equipos.Tables(0).Rows(0).Item(3)))
            ModoPagoPredefinido = ds_Equipos.Tables(0).Rows(0).Item(4)
            cuitEmpresa = ds_Equipos.Tables(0).Rows(0).Item(5)
            HOMO = CBool(ds_Equipos.Tables(0).Rows(0).Item(6))
            TicketAccesoBool = CBool(ds_Equipos.Tables(0).Rows(0).Item(7))
            CorreoContador = ds_Equipos.Tables(0).Rows(0).Item(8)
            saveTA = ds_Equipos.Tables(0).Rows(0).Item(9)
            saveTOKEN = ds_Equipos.Tables(0).Rows(0).Item(10)
            saveSING = ds_Equipos.Tables(0).Rows(0).Item(11)
            ds_Equipos = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT Codigo FROM Almacenes WHERE Nombre LIKE '%SALON%' ")
            'IDAlmacenSalon = ds_Equipos.Tables(0).Rows(0).Item(0)
            ds_Equipos = SqlHelper.ExecuteDataset(connection, CommandType.Text, "SELECT PtoVta FROM Parametros_PtoVta WHERE NombreEquipo = '" & SystemInformation.ComputerName.ToString.ToUpper & "'")
            'lblPVI.Text = ds_Equipos.Tables(0).Rows(0).Item(0).ToString
            PTOVTA = ds_Equipos.Tables(0).Rows(0).Item(0).ToString
            ds_Equipos.Dispose()
            'BuscarValores_Facturados()
            Me.Text = "Facturación Electrónica - " & Empresa
            lblModo.Visible = HOMO
            pathComprobantesAFIP = path_raiz & "\Comprobantes Facturas - " + Utiles.Empresa + "\"

        Catch ex As Exception
            MessageBox.Show("Se produjo un error al leer los datos de la table Parámetros", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        '------------------AFIP-----------------------
        ' Cambiamos el cursor por el de carga
        Me.Cursor = Cursors.WaitCursor
        If ConexionAfip(saveTA, saveTOKEN, saveSING) = True Then
            PicConexion.Image = My.Resources.Green_Ball_icon
            chkConexion.Checked = True
        Else
            MessageBox.Show("La conexión con el servidor de la AFIP no ha sido exitosa, por favor intente nuevamente mas tarde.", "Error de conexión", MessageBoxButtons.OK)
            PicConexion.Image = My.Resources.Red_Ball_icon
            chkConexion.Checked = False
        End If
        'dejo el cursor en flecha
        Me.Cursor = Cursors.Arrow
        '-----------------------------------------------------------------------------
    End Sub

    Private Function Abrir_Tran(ByRef cnn As SqlClient.SqlConnection) As Boolean
        If tran Is Nothing Then
            Try
                tran = cnn.BeginTransaction
                Abrir_Tran = True
            Catch ex As Exception
                Abrir_Tran = False
                Exit Function
            End Try
        End If
    End Function

    Private Sub Cerrar_Tran()
        'Cierra o finaliza la transaccion
        If Not (tran Is Nothing) Then
            tran.Commit()
            tran.Dispose()
            tran = Nothing
        End If
    End Sub

    Private Sub Cancelar_Tran()
        'Cancela la transaccion
        If Not (tran Is Nothing) Then
            tran.Rollback()
            tran.Dispose()
            tran = Nothing
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

    Private Sub btnPago_Click(sender As Object, e As EventArgs)
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

    Private Sub btnAplicarConceptos_Click(sender As Object, e As EventArgs)

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