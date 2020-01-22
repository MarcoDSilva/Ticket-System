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

            'verifica se foi introduzido algum valor na view e se foi tenta actualizar a base de dados e reencaminha para a view da listagem
            'caso contrário retorna a view actual da inserção de novos problemas

            If String.IsNullOrEmpty(descricao).Equals(False) Then
                ViewBag.sucesso = "done"
                ViewBag.tentativa = $"{descricao} inserido com sucesso"
                conectaBD.InserirNovoProblema(descricao)
            Else
                Return View()
            End If

            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace