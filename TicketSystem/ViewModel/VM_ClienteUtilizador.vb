Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

'Esta view model foi criada especificamente para poder utilizar o ID do utilizador
'como uma string, para receber o nome do mesmo e atribuir na view, invés do ID


Public Class VM_ClienteUtilizador
    <Key>
    <Display(Name:="ID")>
    Public Property ID_cliente As Integer

    <Display(Name:="Nome")>
    <Required>
    <StringLength(100)>
    Public Property nome As String

    <Display(Name:="Contacto")>
    <Required>
    <StringLength(50)>
    Public Property contacto As String

    <Display(Name:="Email")>
    <Required>
    <StringLength(255)>
    Public Property email As String

    <Display(Name:="Empresa")>
    <Required>
    <StringLength(255)>
    Public Property empresa As String

    <Display(Name:="Utilizador")>
    Public Property ID_utilizador As String

    <Display(Name:="Ultima actualização")>
    Public Property dat_hor As Date
End Class
