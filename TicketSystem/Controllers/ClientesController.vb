Imports System.Web.Mvc
Imports System.Net

Namespace Controllers
    Public Class ClientesController
        Inherits Controller

        'tabela conexao á bd
        Dim conectaBD As New Manipula_TCliente

        ' GET: Clientes
        Function Index() As ActionResult
            Return View(LeituraDados($"SELECT * FROM Cliente;").AsEnumerable)
        End Function

        'GET : Formulário
        Function CriaCliente()
            Return View()
        End Function

        'POST
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function CriaCliente(nome As String, contacto As String, email As String, empresa As String,
                             ID_utilizador As String)
            If String.IsNullOrEmpty(nome) Then
                Return View()
            Else
                'valores temporarios até redesenhar a viewmodel
                If ID_utilizador.ToString().Equals("") Then
                    conectaBD.AdicionarCliente(nome, contacto, email, empresa, "null")
                Else
                    conectaBD.AdicionarCliente(nome, contacto, email, empresa, Convert.ToInt32(ID_utilizador))
                End If
            End If
            Return RedirectToAction("Index")
        End Function

        'GET: 
        Function EditarCliente(ID_cliente As Integer)
            If IsNothing(ID_cliente) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadGateway)
            Else
                Return View(LeituraDados($"SELECT * FROM Cliente WHERE ID_cliente = {ID_cliente}").First())
            End If
            Return RedirectToAction("Index")
        End Function

        'POST
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function EditarCliente(nome As String, contacto As String, email As String, empresa As String,
                             ID_utilizador As Integer?, ID_cliente As Integer)
            Return View()
        End Function

        ''' <summary>
        ''' Método interno utilizado para ler dados da bd
        ''' </summary>
        ''' <param name="query"></param>
        ''' <returns></returns>
        Function LeituraDados(query As String) As List(Of Cliente)

            Dim tabelaDados As DataTable = conectaBD.LeituraTabela(query)
            Dim listagemClientes As List(Of Cliente) = New List(Of Cliente)

            'fazemos um ciclo, que vai iterar por cada elemento que recebenos da base de dados
            'criamos um novo objecto do tipo Cliente, onde atribuimos os dados da iteração actual
            'e no fim após a atribuição desses dados, inserimos numa List(a) de Clientes, o qual usamos para retornar os dados
            For Each item In tabelaDados.AsEnumerable
                Dim cli As New Cliente
                cli.ID_cliente = item(0)
                cli.nome = item(1)
                cli.contacto = item(2)
                cli.email = item(3)
                cli.empresa = item(4)

                'verifica se o ID do utilizador é nulo, e caso o seja, passa um nulo para o cli
                'caso contrário, atribui-lhe o ID 
                If item(5).Equals(DBNull.Value) Then
                    cli.ID_utilizador = Nothing
                Else
                    cli.ID_utilizador = item(5)
                End If

                cli.dat_hor = item(6)
                listagemClientes.Add(cli)
            Next

            Return listagemClientes
        End Function
    End Class
End Namespace