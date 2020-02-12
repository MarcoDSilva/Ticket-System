Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Role")>
Partial Public Class Role
    Public Sub New()
        Tecnico = New HashSet(Of Tecnico)()
    End Sub

    <Key>
    <Display(Name:="ID")>
    Public Property ID_role As Integer

    <Display(Name:="Descrição")>
    <StringLength(100)>
    Public Property descricao As String

    <Display(Name:="Ultima Actualização")>
    Public Property dat_hor As Date

    'um role pode pertencer a vários Técnicos
    Public Overridable Property Tecnico As ICollection(Of Tecnico)
End Class
