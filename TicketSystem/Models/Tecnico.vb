Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Tecnico")>
Partial Public Class Tecnico
    Public Sub New()
        Evento = New HashSet(Of Evento)()
        Ticket = New HashSet(Of Ticket)()
    End Sub

    <Key>
    <Display(Name:="ID")>
    Public Property ID_tecnico As Integer

    <Display(Name:="Nome")>
    <Required>
    <StringLength(100)>
    Public Property nome As String

    <Display(Name:="Email")>
    <Required>
    <StringLength(255)>
    <DataType(DataType.EmailAddress)>
    Public Property email As String

    <DataType(DataType.Password)>
    <Required>
    <Display(Name:="Password")>
    <StringLength(255)>
    Public Property password As String

    <Display(Name:="Role")>
    Public Property ID_role As Integer

    <Display(Name:="Ultima actualiza��o")>
    Public Property dat_hor As Date

    'tabelas a qual o t�cnico faz parte
    Public Overridable Property Evento As ICollection(Of Evento)

    Public Overridable Property Ticket As ICollection(Of Ticket)

    'o login vem da tabela login por precau��o
    Public Overridable Property Role As Role
End Class
