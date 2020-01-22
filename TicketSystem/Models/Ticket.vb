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
    Public Property ID_ticket As Integer

    Public Property ID_tecnico As Integer

    Public Property ID_software As Integer

    Public Property ID_cliente As Integer

    Public Property ID_problema As Integer

    <Column(TypeName:="text")>
    <Required>
    Public Property descricao As String

    Public Property dataAbertura As Date

    Public Property dataFecho As Date

    Public Property tempoPrevisto As Integer

    Public Property tempoTotal As Integer

    Public Property ID_estado As Integer

    Public Property ID_evento As Integer

    Public Property ID_prioridade As Integer

    Public Property ID_utilizador As Integer

    Public Property ID_origem As Integer

    Public Property dat_hor As Date

    Public Overridable Property Cliente As Cliente

    Public Overridable Property Estado As Estado

    Public Overridable Property Evento As ICollection(Of Evento)

    Public Overridable Property Evento1 As Evento

    Public Overridable Property Origem As Origem

    Public Overridable Property Prioridade As Prioridade

    Public Overridable Property Problema As Problema

    Public Overridable Property Software As Software

    Public Overridable Property Tecnico As Tecnico

    Public Overridable Property Utilizador As Utilizador
End Class
