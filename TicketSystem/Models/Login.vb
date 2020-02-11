Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Login")>
Partial Public Class Login

    <Key>
    <Display(Name:="ID")>
    Public Property ID_login As Integer

    <Required>
    <Display(Name:="E-mail de acesso")>
    <StringLength(255)>
    <DataType(DataType.EmailAddress)>
    Public Property email As String

    <DataType(DataType.Password)>
    <Required>
    <Display(Name:="Password")>
    <StringLength(255)>
    Public Property password As String

    <Display(Name:="Role")>
    Public Property ID_role As Integer

    <Display(Name:="Ultima actualização")>
    Public Property dat_hor As Date

    'um login tem um role
    Public Overridable Property Role As Role

    'um login pertence a um tecnico
    Public Overridable Property Tecnico As Tecnico

End Class
