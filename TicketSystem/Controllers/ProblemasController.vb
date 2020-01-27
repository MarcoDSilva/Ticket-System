Imports System.Net
Imports System.Web.Mvc

Namespace Controllers
    Public Class ProblemasController
        Inherits Controller

        Private conectaBD As New Manipula_TProblema

        ' GET: Listagem da tabela dos problemas
        Function Index() As ActionResult
            Return View(LeituraDados("Select * From Problema;"))
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


        'GET: recebe a nova descrição e o id do problema a actualizar
        Function EditarProblema(ID_problema As Integer) As ActionResult
            If IsNothing(ID_problema) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            Else
                Dim problema = LeituraDados($"SELECT * FROM Problema WHERE ID_problema = {ID_problema};").First()
                Return View(problema)
            End If
        End Function

        'POST: com a informação que recebe dos dados, actualiza os campos respectivos na bd
        <HttpPost()>
        Function EditarProblema(ID_problema As Integer?, descricao As String) As ActionResult
            Dim problema = LeituraDados($"Select * From Problema WHERE ID_problema = {ID_problema};").First()

            If IsNothing(ID_problema) Or String.IsNullOrEmpty(descricao) Then
                Return New HttpStatusCodeResult(HttpStatusCode.MethodNotAllowed)
            Else
                If problema.ID_problema.Equals(ID_problema) Then
                    conectaBD.ActualizarProblema(descricao, ID_problema)
                End If
            End If

            Return RedirectToAction("Index")
        End Function

        'Recebe o ID do elemento a apagar após a confirmação do utilizador , caso haja tentativa de acesso
        'a este controlo sem um ID especifico, a ideia para o futuro é lançar um erro de acesso
       Function ConfirmaApaga(ID_problema As Integer?) As ActionResult

            If IsNothing(ID_problema) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            ElseIf ID_problema.HasValue Then
                conectaBD.ApagarProblema(ID_problema)
            End If

            Return RedirectToAction("Index")
        End Function

        ''' <summary>
        ''' Método interno à classe, para poder fazer queries de leitura da bd
        ''' Recebe uma datatable da query feita à bd, e devolve a mesma num formato List(obj Problema)
        ''' </summary>
        ''' <param name="query"></param>
        ''' <returns></returns>
        Function LeituraDados(query As String) As List(Of Problema)
            Dim tabelaDados As DataTable = conectaBD.LeituraTabela(query)
            Dim listagemProblemas As List(Of Problema) = New List(Of Problema)

            'fazemos um ciclo, que vai iterar por cada elemento que recebenos da base de dados
            'criamos um novo objecto do tipo Problema, onde atribuimos os dados da iteração actual
            'e no fim após a atribuição desses dados, inserimos numa List(a) de Problemas, o qual usamos para retornar os dados
            For Each item In tabelaDados.AsEnumerable
                Dim p As Problema = New Problema()
                p.ID_problema = item(0)
                p.descricao = item(1)
                p.dat_hor = item(2)
                listagemProblemas.Add(p)
            Next
            Return listagemProblemas
        End Function

    End Class
End Namespace