Imports System.Web.Mvc
Imports System.Net
Namespace Controllers
    Public Class OrigensController
        Inherits Controller

        'conexao com a bd/tabela origem
        Private conectaBD As New Manipula_TOrigem

        ' GET: Origens
        Function Index() As ActionResult
            Return View(LeituraDados("SELECT * FROM Origem;"))
        End Function

        'GET: 
        Function CriaOrigem() As ActionResult
            Return View()
        End Function

        'POST
        'Recebe o input e cria nova descrição, ou mantém a página na view pré-definida
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function CriaOrigem(descricao As String) As ActionResult
            If String.IsNullOrEmpty(descricao) Then
                Return View()
            Else
                conectaBD.AdicionarOrigem(descricao)
            End If
            Return RedirectToAction("Index")
        End Function

        'GET - obtem a view para editar os dados correspondentes
        Function EditarOrigem(ID_origem As Integer)
            If IsNothing(ID_origem) Then
                Return New HttpStatusCodeResult(HttpStatusCode.Forbidden)
            Else
                Return View(LeituraDados($"Select * from Origem WHERE ID_origem = {ID_origem}").First())
            End If
        End Function

        'POST
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function EditarOrigem(ID_origem As Integer, descricao As String)
            If IsNothing(ID_origem) Or String.IsNullOrEmpty(descricao) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadGateway)
            Else
                Dim origem = LeituraDados($"SELECT * FROM Origem where ID_origem = {ID_origem}").First()
                If origem.ID_origem.Equals(ID_origem) Then
                    conectaBD.EditarOrigem(descricao, ID_origem)
                End If
                Return RedirectToAction("Index")
            End If
        End Function

        ''' <summary>
        ''' Apaga a origem consoante o id ser válido
        ''' </summary>
        ''' <param name="ID_origem"></param>
        ''' <returns></returns>
        Function ApagarOrigem(ID_origem As Integer)
            If IsNothing(ID_origem) Then
                Return New HttpStatusCodeResult(HttpStatusCode.Forbidden)
            Else
                Dim origem = LeituraDados($"SELECT * FROM Origem WHERE ID_origem = {ID_origem}").First()
                If origem.ID_origem.Equals(ID_origem) Then
                    conectaBD.ApagarOrigem(ID_origem)
                End If
            End If
            Return RedirectToAction("Index")
        End Function


        ''' <summary>
        ''' Método interno utilizado para ler dados da bd
        ''' </summary>
        ''' <param name="query"></param>
        ''' <returns></returns>
        Function LeituraDados(query As String) As List(Of Origem)

            Dim tabelaDados As DataTable = conectaBD.LeituraTabela(query)
            Dim listagemOrigens As List(Of Origem) = New List(Of Origem)

            'fazemos um ciclo, que vai iterar por cada elemento que recebenos da base de dados
            'criamos um novo objecto do tipo Prioridades, onde atribuimos os dados da iteração actual
            'e no fim após a atribuição desses dados, inserimos numa List(a) de Prioridades, o qual usamos para retornar os dados
            For Each item In tabelaDados.AsEnumerable
                Dim org As New Origem()

                org.ID_origem = item(0)
                org.descricao = item(1)
                org.dat_hor = item(2)

                listagemOrigens.Add(org)
            Next

            Return listagemOrigens
        End Function
    End Class
End Namespace