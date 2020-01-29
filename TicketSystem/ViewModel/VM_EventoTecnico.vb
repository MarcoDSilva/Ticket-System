Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Public Class VM_EventoTecnico

    'Esta view model foi criada especificamente para poder utilizar o ID do utilizador
    'como uma string, para receber o nome do mesmo e atribuir na view, invés do ID
    '=== pode também ser utilizada para trocar o id do ticket ===

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
