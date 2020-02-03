Imports System.Web.Mvc

Namespace Controllers
    Public Class TicketsController
        Inherits Controller

        ' GET: Tickets
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace