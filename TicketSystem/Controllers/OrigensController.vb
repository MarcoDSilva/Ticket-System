Imports System.Web.Mvc

Namespace Controllers
    Public Class OrigensController
        Inherits Controller

        'conexao com a bd/tabela origem
        Private conectaBD As New Manipula_TOrigem

        ' GET: Origens
        Function Index() As ActionResult
            Return View(LeituraDados("SELECT * FROM Origem;"))
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