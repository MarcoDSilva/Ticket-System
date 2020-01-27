﻿Imports System.Net
Imports System.Web.Mvc

Namespace Controllers
    Public Class PrioridadesController
        Inherits Controller

        'utilizada para fazer a conexão com o SQL e a Tabela na bd
        Private conectaBD As New Manipula_TPrioridade


        ' GET: Prioridades
        Function Index() As ActionResult
            Return View(LeituraDados("SELECT * FROM Prioridade;"))
        End Function


        'GET: prioridades/EditarPrioridade/ID_prioridade
        ''' <summary>
        ''' Recebe como input a prioridade para procurar, e devolve-a com campos de edição
        ''' </summary>
        ''' <param name="ID_prioridade"></param>
        ''' <returns></returns>
        Function EditarPrioridade(ID_prioridade As Integer) As ActionResult
            If IsNothing(ID_prioridade) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            Else
                Dim prioridade = LeituraDados($"SELECT * FROM Prioridade WHERE ID_prioridade = {ID_prioridade};").First()
                Return View(prioridade)
            End If
        End Function

        'POST: Actualizar a prioridade se os parametros estiverem corretos
        ''' <summary>
        ''' Após a prioridade ter sido enviada pelo campo de edição, faz as validações correspondentes
        ''' para actualizar a mesma
        ''' </summary>
        ''' <param name="ID_prioridade"></param>
        ''' <param name="descricao"></param>
        ''' <returns></returns>
        <HttpPost()>
        Function EditarPrioridade(ID_prioridade As Integer, descricao As String) As ActionResult
            If IsNothing(ID_prioridade) Or String.IsNullOrEmpty(descricao) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            Else
                Dim prioridade = LeituraDados($"SELECT * FROM Prioridade WHERE ID_prioridade = {ID_prioridade};").First()
                If prioridade.ID_prioridade.Equals(ID_prioridade) Then
                    conectaBD.EditarPrioridade(descricao, ID_prioridade)
                End If
            End If

            Return RedirectToAction("Index")
        End Function

        ''' <summary>
        ''' Cria uma nova prioridade
        ''' </summary>
        ''' <param name="descricao"></param>
        ''' <returns></returns>
        Function CriaPrioridade(descricao As String) As ActionResult
            If String.IsNullOrEmpty(descricao) Then
                Return View()
            Else
                conectaBD.ApagarPrioridade(descricao)
                Return RedirectToAction("Index")
            End If

        End Function

        ''' <summary>
        ''' Apaga a prioridade escolhido pelo utilizador
        ''' </summary>
        ''' <param name="ID_prioridade"></param>
        ''' <returns></returns>
        Function ApagarPrioridade(ID_prioridade As Integer) As ActionResult
            If IsNothing(ID_prioridade) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            Else
                conectaBD.ApagarPrioridade(ID_prioridade)
            End If
            Return RedirectToAction("Index")
        End Function


        ''' <summary>
        ''' Método interno utilizado para ler dados da bd
        ''' </summary>
        ''' <param name="query"></param>
        ''' <returns></returns>
        Function LeituraDados(query As String) As List(Of Prioridade)

            Dim tabelaDados As DataTable = conectaBD.LeituraTabela(query)
            Dim listagemPrioridades As List(Of Prioridade) = New List(Of Prioridade)

            'fazemos um ciclo, que vai iterar por cada elemento que recebenos da base de dados
            'criamos um novo objecto do tipo Prioridades, onde atribuimos os dados da iteração actual
            'e no fim após a atribuição desses dados, inserimos numa List(a) de Prioridades, o qual usamos para retornar os dados
            For Each item In tabelaDados.AsEnumerable
                Dim prio As New Prioridade()

                prio.ID_prioridade = item(0)
                prio.descricao = item(1)
                prio.dat_hor = item(2)
                listagemPrioridades.Add(prio)
            Next

            Return listagemPrioridades
        End Function
    End Class
End Namespace