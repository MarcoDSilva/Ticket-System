Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Evento")>
Partial Public Class Evento
    Public Sub New()
        Ticket1 = New HashSet(Of Ticket)()
    End Sub

    <Key>
    Public Property ID_evento As Integer

    <Column(TypeName:="text")>
    <Required>
    Public Property descricao As String

    Public Property ID_tecnico As Integer

    Public Property dataAbertura As Date

    Public Property dataFecho As Date

    Public Property ID_ticket As Integer

    Public Property dat_hor As Date

    Public Overridable Property Tecnico As Tecnico

    Public Overridable Property Ticket As Ticket

    Public Overridable Property Ticket1 As ICollection(Of Ticket)
End Class
