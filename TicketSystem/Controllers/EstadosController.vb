Imports System.Net
Imports System.Web.Mvc

Namespace Controllers
    Public Class EstadosController
        Inherits Controller

        'acesso à base de dados pelo context e a edição dos dados da mesma pela conectaBD
        Private db As New TicketSystemDBContext
        Private conectaBD As New Manipula_TEstado

        ' GET: Listagem de Estados
        Function Index() As ActionResult
            Return View(LeituraDados("SELECT * FROM Estado"))
        End Function

        'GET: Estados/CriaEstado
        Function CriaEstado() As ActionResult
            Return View()
        End Function

        'POST: Cria um novo estado consoante a descrição recebida
        'verifica se foi introduzido algum valor e caso tenha sido, procede à criação desse novo estado e reencaminha para a listagem
        'caso contrário reencaminha de volta para a view
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function CriaEstado(descricao As String) As ActionResult

            If IsNothing(descricao) Then
                Return View()
            Else
                conectaBD.InserirNovoEstado(descricao)
            End If

            Return RedirectToAction("Index")
        End Function

        'GET
        Function EditarEstado(ID_estado As Integer) As ActionResult
            Return View()
        End Function

        Function EditarEstado(ID_estado As Integer, descricao As String) As ActionResult
            Return View()
        End Function


        'POST
        Function ApagaEstado(ID_estado As Integer) As ActionResult
            Return View()
        End Function

        ''' <summary>
        ''' Método interno utilizado para ler dados da bd
        ''' </summary>
        ''' <param name="query"></param>
        ''' <returns></returns>
        Function LeituraDados(query As String) As List(Of Estado)

            Dim tabelaDados As DataTable = conectaBD.LeituraTabela(query)
            Dim listagemEstados As List(Of Estado) = New List(Of Estado)

            'fazemos um ciclo, que vai iterar por cada elemento que recebenos da base de dados
            'criamos um novo objecto do tipo Estado, onde atribuimos os dados da iteração actual
            'e no fim após a atribuição desses dados, inserimos numa List(a) de Estados, o qual usamos para retornar os dados
            For Each item In tabelaDados.AsEnumerable
                Dim est As New Estado()
                est.ID_estado = item(0)
                est.descricao = item(1)
                est.dat_hor = item(2)
                listagemEstados.Add(est)
            Next

            Return listagemEstados
        End Function

    End Class
End Namespace