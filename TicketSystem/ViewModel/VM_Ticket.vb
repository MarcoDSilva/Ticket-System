Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

''' <summary>
''' A VM é utilizada para poder mostrar em string o correspondente dos ids na view, caso contrário 
''' dá erro na view por incompatibilidade de tipo. (enquanto não se achar melhor solução, fica esta)
''' </summary>

Public Class VM_Ticket
    <Key>
    <Display(Name:="ID")>
    Public Property ID_ticket As Integer

    <Display(Name:="Tecnico")>
    Public Property ID_tecnico As String

    <Display(Name:="Software")>
    Public Property ID_software As String

    <Display(Name:="Cliente")>
    Public Property ID_cliente As String

    <Display(Name:="Problema")>
    Public Property ID_problema As String

    <Display(Name:="Descrição")>
    <Column(TypeName:="text")>
    <Required>
    Public Property descricao As String

    <Display(Name:="Data de abertura")>
    Public Property dataAbertura As Date

    <Display(Name:="Data de fecho")>
    Public Property dataFecho As Date?

    <Display(Name:="Tempo previsto")>
    Public Property tempoPrevisto As Integer

    <Display(Name:="Tempo total")>
    Public Property tempoTotal As Integer

    <Display(Name:="Estado")>
    Public Property ID_estado As String

    <Display(Name:="Prioridade")>
    Public Property ID_prioridade As String

    <Display(Name:="Utilizador")>
    Public Property ID_utilizador As String


    <Display(Name:="Origem")>
    Public Property ID_origem As String

    <Display(Name:="Ultima actualização")>
    Public Property dat_hor As Date
End Class
