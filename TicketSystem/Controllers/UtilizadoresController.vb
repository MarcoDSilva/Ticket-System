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



        'GET: 
        Function EditaUtilizador(ID_utilizador As Integer) As ActionResult

        End Function

        'POST:
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function EditarUtilizador(ID_utilizador As Integer, nome As String, contacto As String, email As String, cliente As String) As ActionResult

        End Function


        'Apagar u
        Function ApagarUtilizador(ID_utilizador) As ActionResult

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

        'Listagem para trocar o ID dos clientes por uma dropdown com o respectivo nome
        'adicionado um extra para aparecer "Sem clientes" para podermos enviar NULL para a bd
        Function ListaClientes() As List(Of Cliente)
            Dim tabelaClientes As DataTable = conectaBD.LeituraTabela("SELECT * FROM Cliente;")
            Dim listagemClientes As List(Of Cliente) = New List(Of Cliente)

            'adicionar o "sem utilizador" na lista
            Dim extra As New Cliente
            extra.ID_utilizador = 0
            extra.nome = "Sem Utilizador"
            listagemClientes.Add(extra)

            'ir buscar a informação da bd e adicionar na listagem
            For Each item In tabelaClientes.AsEnumerable
                Dim c As New Cliente
                c.ID_cliente = item(0)
                c.nome = item(1)

                listagemClientes.Add(c)
            Next

            Return listagemClientes
        End Function


    End Class
End Namespace