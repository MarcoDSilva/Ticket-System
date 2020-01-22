Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Cliente")>
Partial Public Class Cliente
    Public Sub New()
        Ticket = New HashSet(Of Ticket)()
        Utilizador1 = New HashSet(Of Utilizador)()
    End Sub

    <Key>
    Public Property ID_cliente As Integer

    <Required>
    <StringLength(100)>
    Public Property nome As String

    <Required>
    <StringLength(50)>
    Public Property contacto As String

    <Required>
    <StringLength(255)>
    Public Property email As String

    <Required>
    <StringLength(255)>
    Public Property empresa As String

    Public Property ID_utilizador As Integer

    Public Property dat_hor As Date

    Public Overridable Property Utilizador As Utilizador

    Public Overridable Property Ticket As ICollection(Of Ticket)

    Public Overridable Property Utilizador1 As ICollection(Of Utilizador)
End Class
