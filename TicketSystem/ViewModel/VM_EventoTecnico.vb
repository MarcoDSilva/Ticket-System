Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Public Class VM_EventoTecnico

    <Display(Name:="ID")>
    Public Property ID_evento As Integer

    <Display(Name:="Descrição")>
    <Column(TypeName:="text")>
    <Required>
    Public Property descricao As String

    <Display(Name:="Técnico")>
    Public Property ID_tecnico As String

    <Display(Name:="Data de abertura")>
    Public Property dataAbertura As Date

    <Display(Name:="Data de fecho")>
    Public Property dataFecho As Date

    <Display(Name:="Ticket")>
    Public Property ID_ticket As Integer

    <Display(Name:="Ultima actualização")>
    Public Property dat_hor As Date


End Class
