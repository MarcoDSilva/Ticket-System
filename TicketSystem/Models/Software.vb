Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Software")>
Partial Public Class Software
    Public Sub New()
        Ticket = New HashSet(Of Ticket)()
    End Sub

    <Key>
    Public Property ID_software As Integer

    <Required>
    <StringLength(100)>
    Public Property nome As String

    Public Property dat_hor As Date

    Public Overridable Property Ticket As ICollection(Of Ticket)
End Class
