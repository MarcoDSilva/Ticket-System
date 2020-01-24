Imports System.Net
Imports System.Web.Mvc

Namespace Controllers
    Public Class EstadosController
        Inherits Controller

        Private db As TicketSystemDBContext
        Private conectaBD As Manipula_TEstado

        ' GET: Listagem de Estados
        Function Index() As ActionResult
            Return View()
        End Function

        ''' <summary>
        ''' Método interno utilizado para ler dados da bd
        ''' </summary>
        ''' <param name="query"></param>
        ''' <returns></returns>
        Function LeituraDados(query As String) As List(Of Estado)
            Dim tabelaDados As DataTable = conectaBD.LeituraTabela(query)
            Dim listagemEstados As List(Of Estado) = New List(Of Estado)

            For Each item In tabelaDados.AsEnumerable
                Dim est As New Estado()

            Next
            ' Return listagemProblemas
        End Function

    End Class
End Namespace