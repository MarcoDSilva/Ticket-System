Imports System.Web.Mvc

Namespace Controllers
    Public Class ProblemasController
        Inherits Controller

        Private db As New TicketSystemDBContext
        Private conectaBD As New ManipulaDados

        ' GET: Problemas
        Function Index() As ActionResult

            Dim listagemProblemas = db.Problema.ToList

            Return View(listagemProblemas)
        End Function

        'GET : Problemas/CriaProblema
        Function CriaProblema() As ActionResult
            Return View()
        End Function

        'POST: criar um novo registo na tabela dos problemas
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function CriaProblema(descricao As String) As ActionResult

            If (String.IsNullOrEmpty(descricao)) Then
                ViewBag.tentativa = "empty"
            Else
                ViewBag.sucesso = "done"
                ViewBag.tentativa = $"{descricao} inserido com sucesso"

                conectaBD.InserirNovoProblema(descricao)
            End If
            'Return RedirectToAction("Index")
            Return View()
        End Function

    End Class
End Namespace