Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Problema")>
Partial Public Class Problema
    Public Sub New()
        Ticket = New HashSet(Of Ticket)()
    End Sub

    <Key>
    Public Property ID_problema As Integer

    <Required>
    <StringLength(100)>
    Public Property descricao As String

    Public Property dat_hor As Date

    Public Overridable Property Ticket As ICollection(Of Ticket)
End Class
