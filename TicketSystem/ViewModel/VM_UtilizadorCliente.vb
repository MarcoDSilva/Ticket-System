Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class VM_UtilizadorCliente


    <Display(Name:="ID")>
    Public Property ID_utilizador As Integer

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

    <Display(Name:="Cliente")>
    Public Property ID_cliente As String

    <Display(Name:="Ultima actualização")>
    Public Property dat_hor As Date
End Class
