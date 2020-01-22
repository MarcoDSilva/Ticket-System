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

            'testar se houve input da view
            'se houve, verificar os dados
            'se dados estiverem direitos, conecta a bd e atualiza
            'senao lançar erro

            'redireciona para a listagem de problemas se inserção for completa corretamente,
            'se não, lança erro e devolve a pagina de inserção

            'Return RedirectToAction("Index")
            Return View()
        End Function

        'POST: criar um novo registo na tabela dos problemas
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function CriaProblema(descricao As String) As ActionResult

            Dim teste As String
            Dim query As String

            If (String.IsNullOrEmpty(descricao)) Then
                ViewBag.tentativa = "empty"
            Else
                teste = descricao
                ViewBag.tentativa = teste
                query = $"Insert into Problemas values ('{descricao}', CURRENT_TIMESTAMP);"

            End If



            'testar se houve input da view
            'se houve, verificar os dados
            'se dados estiverem direitos, conecta a bd e atualiza com o dado enviado e a data actual, com current timestamp ?
            'senao lançar erro

            'redireciona para a listagem de problemas se inserção for completa corretamente,
            'se não, lança erro e devolve a pagina de inserção

            'Return RedirectToAction("Index")
            Return View()
        End Function

    End Class
End Namespace