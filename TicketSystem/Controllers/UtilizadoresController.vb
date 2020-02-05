Imports System.Net
Imports System.Web.Mvc

Namespace Controllers
    Public Class UtilizadoresController
        Inherits Controller

        'tabela com conexao á bd
        Dim conectaBD As New Manipula_TUtilizador

        ' GET: Utilizadores
        Function Index() As ActionResult
            Return View(LeituraDados("SELECT u.ID_utilizador, u.nome, u.contacto, u.email, c.nome, u.dat_hor
                                      FROM Utilizador u
                                      LEFT JOIN Cliente c	
                                      ON u.ID_utilizador = c.ID_utilizador;"))
        End Function

        'GET: Criação de utilizadores
        Function CriaUtilizador() As ActionResult
            ViewBag.clientes = New SelectList(ListaClientes(), "ID_cliente", "nome")
            Return View()
        End Function

        'POST: enviar informação de novo utilizador para a bd
        'Envia null caso não seja selecionado nenhum utilizador (por pré-definição, adicionei como id 0 um elemento "Sem utilizador")
        'Caso contrário, envia a informação como ela vem
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function CriaUtilizador(nome As String, contacto As String, email As String, ID_cliente As Integer) As ActionResult

            If String.IsNullOrEmpty(nome) Or String.IsNullOrEmpty(contacto) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadGateway)
            Else
                If ID_cliente.Equals(0) Then
                    conectaBD.AdicionaUtilizador(nome, contacto, email, "null")
                Else
                    conectaBD.AdicionaUtilizador(nome, contacto, email, ID_cliente)
                End If
            End If

            Return RedirectToAction("Index")
        End Function

        'GET: Informação para editar o utilizador
        Function EditarUtilizador(ID_utilizador As Integer) As ActionResult
            If IsNothing(ID_utilizador) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            Else
                ViewBag.clientes = New SelectList(ListaClientes(), "ID_cliente", "nome")
                Return View(LeituraDados($"SELECT * FROM Utilizador WHERE ID_utilizador = {ID_utilizador}").First())
            End If

            Return RedirectToAction("Index")
        End Function

        'POST: Edita o utilizador com as informações passadas
        ' Se o ID do cliente for 0 (valor pré-definição que demonstra que não existe um cliente associado aquele utilizador)
        'envia null para a db (ou a classe que a controla)
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function EditarUtilizador(ID_utilizador As Integer, nome As String, contacto As String, email As String, ID_cliente As Integer?) As ActionResult
            If IsNothing(ID_utilizador) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            Else
                If ID_cliente.Equals(0) Then
                    conectaBD.EditarUtilizador(ID_utilizador, nome, contacto, email, "null")
                Else
                    conectaBD.EditarUtilizador(ID_utilizador, nome, contacto, email, ID_cliente.ToString())
                End If
            End If
            Return RedirectToAction("Index")
        End Function


        'Apagar utilizador consoante o ID
        Function ApagarUtilizador(ID_utilizador As Integer) As ActionResult
            If IsNothing(ID_utilizador) Then
                Return New HttpStatusCodeResult(HttpStatusCode.Forbidden)
            Else
                conectaBD.ApagaUtilizador(ID_utilizador)
            End If
            Return RedirectToAction("Index")
        End Function

        ''' <summary>
        ''' Método interno utilizado para ler dados da bd
        ''' </summary>
        ''' <param name="query"></param>
        ''' <returns></returns>
        Function LeituraDados(query As String) As List(Of VM_UtilizadorCliente)

            Dim tabelaDados As DataTable = conectaBD.LeituraTabela(query)
            Dim listagemUtilizadores As List(Of VM_UtilizadorCliente) = New List(Of VM_UtilizadorCliente)

            'fazemos um ciclo, que vai iterar por cada elemento que recebenos da base de dados
            'criamos um novo objecto do tipo user, onde atribuimos os dados da iteração actual
            'e no fim após a atribuição desses dados, inserimos numa List(a) de users, o qual usamos para retornar os dados
            For Each item In tabelaDados.AsEnumerable
                Dim user As New VM_UtilizadorCliente
                user.ID_utilizador = item(0)
                user.nome = item(1)
                user.contacto = item(2)
                user.email = item(3)

                'verifica se o valor que vem da bd é nulo
                If item(4).Equals(DBNull.Value) Then
                    user.ID_cliente = "Sem Cliente"
                Else
                    user.ID_cliente = item(4)
                End If

                user.dat_hor = item(5)

                listagemUtilizadores.Add(user)
            Next
            Return listagemUtilizadores
        End Function

        ''' <summary>
        ''' Retorna uma lista de Clientes, só com o ID e nome.
        ''' Retorna também um "Sem utilizador" na posição 0, visto que o valor pode ser nulo.
        ''' </summary>
        ''' <returns></returns>
        Public Function ListaClientes() As List(Of Cliente)
            Dim tabelaClientes As DataTable = conectaBD.LeituraTabela("SELECT ID_cliente, nome FROM Cliente;")
            Dim listagemClientes As List(Of Cliente) = New List(Of Cliente)

            'adicionar o "sem utilizador" na lista
            Dim extra As New Cliente
            extra.ID_cliente = 0
            extra.nome = "Sem Utilizador"
            listagemClientes.Add(extra)

            'ir buscar a informação da bd e adicionar na listagem
            For Each item In tabelaClientes.AsEnumerable
                Dim cli As New Cliente
                cli.ID_cliente = item(0)
                cli.nome = item(1)

                listagemClientes.Add(cli)
            Next

            Return listagemClientes
        End Function

    End Class
End Namespace