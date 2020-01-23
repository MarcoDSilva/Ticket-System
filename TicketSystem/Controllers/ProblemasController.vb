Imports System.Web.Mvc

Namespace Controllers
    Public Class ProblemasController
        Inherits Controller

        Private db As New TicketSystemDBContext
        Private conectaBD As New Manipula_TProblema

        ' GET: Listagem da tabela dos problemas
        Function Index() As ActionResult

            Dim listagemProblemas = db.Problema.ToList
            Return View(listagemProblemas)
        End Function

        'GET : Problemas/CriaProblema
        Function CriaProblema() As ActionResult
            Return View()
        End Function

        'POST: criar um novo registo na tabela dos problemas
        'verifica se foi introduzido algum valor na view e se foi tenta actualizar a base de dados e reencaminha para a view da listagem
        'caso contrário retorna a view actual da inserção de novos problemas
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function CriaProblema(descricao As String) As ActionResult

            If String.IsNullOrEmpty(descricao).Equals(False) Then
                conectaBD.InserirNovoProblema(descricao)
            Else
                Return View()
            End If

            Return RedirectToAction("Index")
        End Function

        'POST: recebe a nova descrição e o id do problema a actualizar
        Function EditarProblema(ID_problema As Integer)
            If IsNothing(ID_problema) Then
                Return View()
            Else
                Dim problemas As Problema = db.Problema.Find(ID_problema)
                Return View(problemas)
            End If

            Return RedirectToAction("Index")
        End Function


        '<HttpPost()>
        '<ValidateAntiForgeryToken>
        'Function ActualizaProblema(descricao As String, ID_problema As Integer) As ActionResult

        '    Return RedirectToAction("Index")
        'End Function


        'POST: recebe o ID do problema que o utilizador pretende apagar
        Function ApagaProblema() As ActionResult
            Return View()
        End Function

        'POST: recebe o ID do problema que o utilizador pretende apagar
        'algumas verificações extras podem ter de ser efetuadas aqui
        Function ApagaProblema(ID_problema As Integer) As ActionResult
            Return RedirectToAction("Index")
        End Function



    End Class
End Namespace