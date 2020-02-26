Imports System.Web.Mvc
Imports System.Net

Namespace Controllers
    Public Class ClientesController
        Inherits Controller

        'tabela conexao á bd
        Dim conectaBD As New Manipula_TCliente

        ' GET: Clientes
        'A Query está com um left join pois queremos incluir os valores nulos 
        'que provém do utilizador(caso o cliente não tenha nenhum utilizador associado)
        Function Index() As ActionResult
            BloqueiaUtilizadores()
            Return View(LeituraDados($"SELECT c.ID_cliente, c.nome, c.contacto, c.email, c.empresa, u.nome, c.dat_hor 
                                      FROM Cliente c
                                      LEFT JOIN Utilizador u
                                      ON c.ID_utilizador = u.ID_utilizador").AsEnumerable)
        End Function

        'GET : Formulário
        Function CriaCliente() As ActionResult
            BloqueiaUtilizadores()
            ViewBag.utilizadores = New SelectList(conectaBD.ListaUtilizadores(), "ID_utilizador", "nome")
            Return View()
        End Function

        'POST - Envia a informação recebida para a bd
        'Temos uma condicional que verifica se o utilizador escolhido é alguém que já existe na bd ou não
        'Tem que alterar também a bd do utilizador para ambos ficarem interligados (TO DO)
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function CriaCliente(nome As String, contacto As String, email As String, empresa As String,
                             ID_utilizador As Integer) As ActionResult
            BloqueiaUtilizadores()

            If String.IsNullOrEmpty(nome) Then
                Return View()
            Else
                'valores temporarios até redesenhar a viewmodel
                If ID_utilizador.Equals(0) Then
                    conectaBD.AdicionarCliente(nome, contacto, email, empresa, "null")
                Else
                    conectaBD.AdicionarCliente(nome, contacto, email, empresa, Convert.ToInt32(ID_utilizador))
                End If
            End If
            Return RedirectToAction("Index")
        End Function

        'GET: 
        Function EditarCliente(ID_cliente As Integer) As ActionResult
            BloqueiaUtilizadores()
            If IsNothing(ID_cliente) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadGateway)
            Else
                ViewBag.utilizador = New SelectList(conectaBD.ListaUtilizadores(), "ID_utilizador", "nome")

                Return View(LeituraDados($"SELECT * FROM Cliente WHERE ID_cliente = {ID_cliente}").First())
            End If

            Return RedirectToAction("Index")
        End Function

        'POST
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function EditarCliente(nome As String, contacto As String, email As String, empresa As String,
                             ID_cliente As Integer) As ActionResult
            BloqueiaUtilizadores()
            If IsNothing(ID_cliente) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadGateway)
            Else
                'com o utilizador está escondido de momento, temos de comentar fora a lógica
                'If ID_utilizador.Equals(0) Or IsNothing(ID_utilizador) Then
                '    conectaBD.EditarCliente(nome, contacto, email, empresa, "null", ID_cliente)
                'Else
                '    conectaBD.EditarCliente(nome, contacto, email, empresa, ID_utilizador, ID_cliente)
                'End If
                conectaBD.EditarCliente(nome, contacto, email, empresa, "null", ID_cliente)
            End If

            Return RedirectToAction("Index")
        End Function

        'Apaga o cliente corrrespondente ao id recebido
        Function ApagarCliente(ID_cliente As Integer) As ActionResult
            BloqueiaUtilizadores()
            If IsNothing(ID_cliente) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            Else
                conectaBD.ApagarCliente(ID_cliente)
            End If
            Return RedirectToAction("Index")
        End Function


        ''' <summary>
        ''' Método interno utilizado para ler dados da bd
        ''' </summary>
        ''' <param name="query"></param>
        ''' <returns></returns>
        Function LeituraDados(query As String) As List(Of VM_ClienteUtilizador)

            Dim tabelaDados As DataTable = conectaBD.LeituraTabela(query)
            Dim listagemClientes As List(Of VM_ClienteUtilizador) = New List(Of VM_ClienteUtilizador)

            'fazemos um ciclo, que vai iterar por cada elemento que recebenos da base de dados
            'criamos um novo objecto do tipo Cliente, onde atribuimos os dados da iteração actual
            'e no fim após a atribuição desses dados, inserimos numa List(a) de Clientes, o qual usamos para retornar os dados
            For Each item In tabelaDados.AsEnumerable
                Dim cli As New VM_ClienteUtilizador
                cli.ID_cliente = item(0)
                cli.nome = item(1)
                cli.contacto = item(2)
                cli.email = item(3)
                cli.empresa = item(4)

                'verifica se o ID do utilizador é nulo, e caso o seja, passa um nulo para o cli
                'caso contrário, atribui-lhe o ID 
                If item(5).Equals(DBNull.Value) Then
                    cli.ID_utilizador = "Sem utilizador"
                Else
                    cli.ID_utilizador = item(5)
                End If

                cli.dat_hor = item(6)
                listagemClientes.Add(cli)
            Next
            Return listagemClientes
        End Function

        Private Sub BloqueiaUtilizadores()
            If String.IsNullOrEmpty((Session("Nome"))) Or Session("Inativo") = 1 Then
                Response.Redirect("~/Logins/Index")
            End If
        End Sub
    End Class
End Namespace