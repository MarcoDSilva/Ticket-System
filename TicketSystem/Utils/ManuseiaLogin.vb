Imports System.Data.SqlClient

Public Class ManuseiaLogin
    Inherits ObterDados

    'Comando já com a String Conection pronta para utilizar nos métodos abaixo
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)

    ''' <summary>
    ''' A ideia do método login, é receber os parametros, verifica se existe correspondência
    ''' e efetua as operações correspondentes caso encontre um login.
    ''' Se não encontrar, devolve valor nulo.
    ''' </summary>
    ''' <param name="password"></param>
    ''' <param name="email"></param>
    ''' <returns></returns>
    Public Function Login(password As String, email As String) As Login
        Dim query As String = "SELECT t.nome, l.email , l.ID_role
                                FROM Tecnico as t
                                INNER JOIN Login l ON t.ID_login = l.ID_login
                                WHERE l.password = @pass
                                AND l.email = @malito;"

        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@pass", password)
        comando.Parameters.AddWithValue("@malito", email)
        conexao.Open()

        'Verificamos se a query afecta alguma row. (ou seja, que o mail/password combo é válido)
        Dim loginEncontrado As SqlDataReader

        loginEncontrado = comando.ExecuteReader()
        'comando.ExecuteNonQuery()
        'comando.Parameters.Clear()


        'Se os dados de login forem corretos , então criamos um objeto com o ID do tecnico
        'o seu role e o email, caso contrário, devolvemos nulo
        If loginEncontrado.Read() Then

            Dim obterTecnico = LeituraTabela(query)
            Dim log As New Login

            For Each tecnico In obterTecnico.AsEnumerable()
                log.ID_login = tecnico(0)
                log.email = tecnico(1)
                log.ID_role = tecnico(3)
            Next
            conexao.Close()
            Return log
        Else
            conexao.Close()
            Return Nothing
        End If
    End Function

    'função para obter login

    'função para dar ordem de reset na pw

    'função para alterar pw/email/user


    ''' <summary>
    ''' Método que executa os comandos/queries a serem executadas na base de dados
    ''' Utilizado apenas para evitar repetição no código
    ''' </summary>
    ''' <param name="comando"></param>
    Private Sub ExecutaComandos(comando As SqlCommand)
        conexao.Open()
        comando.ExecuteNonQuery()
        comando.Parameters.Clear()
        conexao.Close()
    End Sub
End Class
