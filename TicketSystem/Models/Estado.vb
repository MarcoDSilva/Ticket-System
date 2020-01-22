Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Estado")>
Partial Public Class Estado
    <Key>
    Public Property ID_estado As Integer

    <Required>
    <StringLength(100)>
    Public Property descricao As String

    Public Property dat_hor As Date

    Public Overridable Property Ticket As Ticket
End Class
