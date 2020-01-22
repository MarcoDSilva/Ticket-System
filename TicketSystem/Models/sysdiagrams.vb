Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class sysdiagrams
    <Required>
    <StringLength(128)>
    Public Property name As String

    Public Property principal_id As Integer

    <Key>
    Public Property diagram_id As Integer

    Public Property version As Integer?

    Public Property definition As Byte()
End Class
