'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class sp_Consumos_Select_All_Result
    Public Property ID As Long
    Public Property Nro_OCA As Nullable(Of Long)
    Public Property Estado As String
    Public Property Fecha As Nullable(Of Date)
    Public Property SubTotal As Nullable(Of Decimal)
    Public Property IVA As Nullable(Of Decimal)
    Public Property MontoIva As Nullable(Of Decimal)
    Public Property Total As Nullable(Of Decimal)
    Public Property IdCliente As Long
    Public Property Cliente As String
    Public Property userVendedor As Nullable(Of Long)
    Public Property Vendedor As String
    Public Property Nota As String
    Public Property Eliminado As Nullable(Of Boolean)
    Public Property Cerrado As Nullable(Of Boolean)
    Public Property NroPresup As String
    Public Property Cancelado As Nullable(Of Boolean)
    Public Property Presupuesto As Nullable(Of Boolean)
    Public Property NroOCAbiertaAsociado As String

End Class
