﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System.Data

Namespace CPFWebService
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="CPFWebService.WS_CPFSoap")>  _
    Public Interface WS_CPFSoap
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/Sql_Get", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function Sql_Get(ByVal query As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/Sql_Get", ReplyAction:="*")>  _
        Function Sql_GetAsync(ByVal query As String) As System.Threading.Tasks.Task(Of System.Data.DataSet)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/Sql_Set", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function Sql_Set(ByVal query As String) As String
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/Sql_Set", ReplyAction:="*")>  _
        Function Sql_SetAsync(ByVal query As String) As System.Threading.Tasks.Task(Of String)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/Sql_Get_Value", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function Sql_Get_Value(ByVal query As String) As String
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/Sql_Get_Value", ReplyAction:="*")>  _
        Function Sql_Get_ValueAsync(ByVal query As String) As System.Threading.Tasks.Task(Of String)
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface WS_CPFSoapChannel
        Inherits CPFWebService.WS_CPFSoap, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class WS_CPFSoapClient
        Inherits System.ServiceModel.ClientBase(Of CPFWebService.WS_CPFSoap)
        Implements CPFWebService.WS_CPFSoap
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function Sql_Get(ByVal query As String) As System.Data.DataSet Implements CPFWebService.WS_CPFSoap.Sql_Get
            Return MyBase.Channel.Sql_Get(query)
        End Function
        
        Public Function Sql_GetAsync(ByVal query As String) As System.Threading.Tasks.Task(Of System.Data.DataSet) Implements CPFWebService.WS_CPFSoap.Sql_GetAsync
            Return MyBase.Channel.Sql_GetAsync(query)
        End Function
        
        Public Function Sql_Set(ByVal query As String) As String Implements CPFWebService.WS_CPFSoap.Sql_Set
            Return MyBase.Channel.Sql_Set(query)
        End Function
        
        Public Function Sql_SetAsync(ByVal query As String) As System.Threading.Tasks.Task(Of String) Implements CPFWebService.WS_CPFSoap.Sql_SetAsync
            Return MyBase.Channel.Sql_SetAsync(query)
        End Function
        
        Public Function Sql_Get_Value(ByVal query As String) As String Implements CPFWebService.WS_CPFSoap.Sql_Get_Value
            Return MyBase.Channel.Sql_Get_Value(query)
        End Function
        
        Public Function Sql_Get_ValueAsync(ByVal query As String) As System.Threading.Tasks.Task(Of String) Implements CPFWebService.WS_CPFSoap.Sql_Get_ValueAsync
            Return MyBase.Channel.Sql_Get_ValueAsync(query)
        End Function
    End Class
End Namespace