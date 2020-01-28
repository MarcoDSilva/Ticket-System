Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Origem")>
Partial Public Class Origem
    Public Sub New()
        Ticket = New HashSet(Of Ticket)()
    End Sub

    <Key>
    <Display(Name:="ID")>
    Public Property ID_origem As Integer

    <Display(Name:="Descri��o")>
    <Required>
    <StringLength(100)>
    Public Property descricao As String

    <Display(Name:="Ultima actualiza��o")>
    Public Property dat_hor As Date

    Public Overridable Property Ticket As ICollection(Of Ticket)
End Class
