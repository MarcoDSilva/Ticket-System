Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Ticket")>
Partial Public Class Ticket
    Public Sub New()
        Evento = New HashSet(Of Evento)()
    End Sub

    <Key>
    <Display(Name:="ID")>
    Public Property ID_ticket As Integer

    <Display(Name:="Tecnico")>
    Public Property ID_tecnico As Integer

    <Display(Name:="Software")>
    Public Property ID_software As Integer

    <Display(Name:="Cliente")>
    Public Property ID_cliente As Integer

    <Display(Name:="Problema")>
    Public Property ID_problema As Integer

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
    Public Property ID_estado As Integer

    <Display(Name:="Prioridade")>
    Public Property ID_prioridade As Integer

    <Display(Name:="Utilizador")>
    Public Property ID_utilizador As Integer?

    <Display(Name:="Origem")>
    Public Property ID_origem As Integer

    <Display(Name:="Ultima actualização")>
    Public Property dat_hor As Date

    'tabelas que correspondem ao ticket
    Public Overridable Property Cliente As Cliente

    Public Overridable Property Estado As Estado

    Public Overridable Property Evento As ICollection(Of Evento)

    Public Overridable Property Origem As Origem

    Public Overridable Property Prioridade As Prioridade

    Public Overridable Property Problema As Problema

    Public Overridable Property Software As Software

    Public Overridable Property Tecnico As Tecnico

    Public Overridable Property Utilizador As Utilizador
End Class
