Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Origem")>
Partial Public Class Origem
    <Key>
    <Display(Name:="ID")>
    Public Property ID_origem As Integer

    <Display(Name:="Descrição")>
    <Required>
    <StringLength(100)>
    Public Property descricao As String

    <Display(Name:="Ultima actualização")>
    Public Property dat_hor As Date

    Public Overridable Property Ticket As Ticket
End Class
