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
    <Display(Name:="ID")>
    Public Property ID_software As Integer

    <Display(Name:="Software")>
    <Required>
    <StringLength(100)>
    Public Property nome As String

    <Display(Name:="Ultima actualização")>
    Public Property dat_hor As Date

    'faz parte da tabela ticket
    Public Overridable Property Ticket As ICollection(Of Ticket)
End Class
