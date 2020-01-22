Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Origem")>
Partial Public Class Origem
    <Key>
    Public Property ID_origem As Integer

    <Required>
    <StringLength(100)>
    Public Property descricao As String

    Public Property dat_hor As Date

    Public Overridable Property Ticket As Ticket
End Class
