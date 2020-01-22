Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Utilizador")>
Partial Public Class Utilizador
    Public Sub New()
        Cliente = New HashSet(Of Cliente)()
    End Sub

    <Key>
    Public Property ID_utilizador As Integer

    <Required>
    <StringLength(100)>
    Public Property nome As String

    <Required>
    <StringLength(50)>
    Public Property contacto As String

    <Required>
    <StringLength(255)>
    Public Property email As String

    Public Property ID_cliente As Integer

    Public Property dat_hor As Date

    Public Overridable Property Cliente As ICollection(Of Cliente)

    Public Overridable Property Cliente1 As Cliente

    Public Overridable Property Ticket As Ticket
End Class
