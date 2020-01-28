﻿Imports System.Web.Mvc
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

        'GET
        Function EditaOrigem(ID_origem As Integer)
            If IsNothing(ID_origem) Then
                Return New HttpStatusCodeResult(HttpStatusCode.Forbidden)
            Else
                Return View()
            End If
        End Function

        'POST
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function EditaOrigem(ID_origem As Integer, descricao As String)

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