Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Role")>
Partial Public Class Role
    Public Sub New()
        Login = New HashSet(Of Login)()
    End Sub

    <Key>
    <Display(Name:="ID")>
    Public Property ID_role As Integer

    <Display(Name:="Descrição")>
    <StringLength(100)>
    Public Property descricao As String

    <Display(Name:="Ultima Actualização")>
    Public Property dat_hor As Date

    'um role pode pertencer a vários logins
    Public Overridable Property Login As ICollection(Of Login)
End Class
