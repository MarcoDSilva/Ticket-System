Imports System.Web.Mvc

Namespace Controllers
    Public Class ClientesController
        Inherits Controller

        'tabela conexao á bd
        Dim conectaBD As New Manipula_TCliente

        ' GET: Clientes
        Function Index() As ActionResult
            Return View(LeituraDados($"SELECT * FROM Cliente;").AsEnumerable)
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