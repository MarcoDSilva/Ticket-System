Imports System.Web.Mvc

Namespace Controllers
    Public Class ProblemasController
        Inherits Controller

        Private db As New TicketSystemDBContext
        Private conectaBD As New Manipula_TProblema

        ' GET: Listagem da tabela dos problemas
        Function Index() As ActionResult

            Dim tabelaDados As DataTable = conectaBD.LeituraTabela("Select * FROM Problema;")
            Dim listagemProblemas As List(Of Problema) = New List(Of Problema)

            For Each item In tabelaDados.AsEnumerable
                Dim p As Problema = New Problema()
                p.ID_problema = item(0)
                p.descricao = item(1)
                p.dat_hor = item(2)
                listagemProblemas.Add(p)
            Next

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

        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function ActualizaProblema(descricao As String, ID_problema As Integer) As ActionResult


            Return RedirectToAction("Index")
        End Function


        'POST: recebe o ID do problema que o utilizador pretende apagar
        'algumas verificações extras podem ter de ser efetuadas aqui
        Function ApagaProblema(ID_problema As Integer?) As ActionResult

            If IsNothing(ID_problema) Then
                Return View()
            Else
                Dim problemas As Problema = db.Problema.Find(ID_problema)
                Return View(problemas)
            End If

        End Function

        <HttpPost()>
        Function ConfirmaApaga(ByVal ID_problema As Integer?, ByVal apagar As String) As ActionResult

            If String.IsNullOrEmpty(apagar) Then
                Dim problemas As Problema = db.Problema.Find(ID_problema)
                Return View(problemas)
            ElseIf apagar.Equals("sim") Then
                conectaBD.ApagarProblema(ID_problema)
                Return RedirectToAction("Index")
            End If

            Return View()
        End Function
    End Class
End Namespace