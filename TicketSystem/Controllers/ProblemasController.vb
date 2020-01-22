Imports System.Web.Mvc

Namespace Controllers
    Public Class ProblemasController
        Inherits Controller

        Private db As New TicketSystemDBContext

        ' GET: Problemas
        Function Index() As ActionResult

            Dim listagemProblemas = db.Problema.ToList

            Return View(listagemProblemas)
        End Function
    End Class
End Namespace