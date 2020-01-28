Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Utilizador")>
Partial Public Class Utilizador
    Public Sub New()
        Cliente = New HashSet(Of Cliente)()
        Ticket = New HashSet(Of Ticket)()
    End Sub

    <Key>
    <Display(Name:="ID")>
    Public Property ID_utilizador As Integer

    <Display(Name:="Nome")>
    <Required>
    <StringLength(100)>
    Public Property nome As String

    <Display(Name:="Contacto")>
    <Required>
    <StringLength(50)>
    Public Property contacto As String

    <Display(Name:="Email")>
    <Required>
    <StringLength(255)>
    Public Property email As String

    <Display(Name:="Cliente")>
    Public Property ID_cliente As Integer?

    <Display(Name:="Ultima actualização")>
    Public Property dat_hor As Date

    'faz parte da tabela clientes e tickets, contém também o cliente
    Public Overridable Property Cliente As ICollection(Of Cliente)

    Public Overridable Property Cliente1 As Cliente

    Public Overridable Property Ticket As ICollection(Of Ticket)
End Class
