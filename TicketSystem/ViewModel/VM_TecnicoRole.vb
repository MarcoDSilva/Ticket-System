Imports System.ComponentModel.DataAnnotations

Public Class VM_TecnicoRole

    <Display(Name:="ID")>
    Public Property ID_tecnico As Integer

    <Display(Name:="Nome")>
    <Required>
    <StringLength(100)>
    Public Property nome As String

    <Display(Name:="Email")>
    <Required>
    <StringLength(255)>
    <DataType(DataType.EmailAddress)>
    Public Property email As String

    <Display(Name:="Role")>
    Public Property ID_role As String

    <Display(Name:="Ultima actualização")>
    Public Property dat_hor As Date

End Class
