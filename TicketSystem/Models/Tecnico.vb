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
    Public Property ID_tecnico As Integer

    <Required>
    <StringLength(100)>
    Public Property nome As String

    <Required>
    <StringLength(255)>
    Public Property email As String

    Public Property dat_hor As Date

    Public Overridable Property Evento As ICollection(Of Evento)

    Public Overridable Property Ticket As ICollection(Of Ticket)
End Class
