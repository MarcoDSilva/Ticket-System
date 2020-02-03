Imports System.Web.Mvc

Namespace Controllers
    Public Class TicketsController
        Inherits Controller

        ' GET: Tickets
        Function Index() As ActionResult
            Return View()
        End Function

        'GET:
        Function CriaTicket() As ActionResult
            Return View()
        End Function

        'POST:
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function CriaTicket(ticketParams As Ticket) As ActionResult


            Return View()
        End Function

        'GET:
        Function EditarTicket(ID_ticket As Integer) As ActionResult

        End Function

        'POST:
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function EditarTicket(ticketParams As Ticket) As ActionResult

        End Function

        'POST
        Function ApagarTicket() As ActionResult

        End Function



    End Class
End Namespace