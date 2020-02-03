Imports System.Web.Mvc

Namespace Controllers
    Public Class UtilizadoresController
        Inherits Controller

        'tabela conexao á bd
        Dim conectaBD = New Manipula_TCliente

        ' GET: Utilizadores
        Function Index() As ActionResult
            Return View(LeituraDados("SELECT u.ID_utilizador, u.nome, u.contacto, u.email, c.nome, u.dat_hor
                                      FROM Utilizador u
                                      LEFT JOIN Cliente c	
                                      ON u.ID_utilizador = c.ID_utilizador;"))
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

    End Class
End Namespace