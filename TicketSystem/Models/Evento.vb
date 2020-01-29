Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Evento")>
Partial Public Class Evento

    <Key>
    <Display(Name:="ID")>
    Public Property ID_evento As Integer

    <Display(Name:="Descrição")>
    <Column(TypeName:="text")>
    <Required>
    Public Property descricao As String

    <Display(Name:="Técnico")>
    Public Property ID_tecnico As Integer

    <Display(Name:="Data de abertura")>
    Public Property dataAbertura As Date

    <Display(Name:="Data de fecho")>
    Public Property dataFecho As Date?

    <Display(Name:="Ticket")>
    Public Property ID_ticket As Integer

    <Display(Name:="Ultima actualização")>
    Public Property dat_hor As Date

    'tabelas que faz parte
    Public Overridable Property Tecnico As Tecnico

    Public Overridable Property Ticket As Ticket

End Class
