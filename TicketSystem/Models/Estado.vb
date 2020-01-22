Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Estado")>
Partial Public Class Estado
    <Key>
    <Display(Name:="ID")>
    Public Property ID_estado As Integer

    <Display(Name:="Descri��o")>
    <Required>
    <StringLength(100)>
    Public Property descricao As String

    <Display(Name:="Ultima actualiza��o")>
    Public Property dat_hor As Date

    Public Overridable Property Ticket As Ticket
End Class
