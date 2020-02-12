Imports System.Data.SqlClient

Public Class ManuseiaLogin

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
    Public Function Login(password As String, email As String) As VM_TecnicoLogin
        Dim query As String = $"SELECT t.ID_tecnico, t.nome, l.email , l.ID_role
                                FROM Tecnico as t
                                INNER JOIN Login l ON t.ID_login = l.ID_login
                                WHERE l.password = @pass
                                AND l.email = @malito"

        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@pass", password)
        comando.Parameters.AddWithValue("@malito", email)
        conexao.Open()

        If comando.ExecuteReader().Read() Then

            Dim tecnicos = LeituraTabela(password, email)
            Dim log As New VM_TecnicoLogin
            For Each tecnico In tecnicos.AsEnumerable()
                log.ID_tecnico = tecnico(0)
                log.Nome = tecnico(1)
                log.Email = tecnico(2)
                log.ID_role = tecnico(3)
            Next
            comando.Parameters.Clear()
            conexao.Close()
            Return log
        Else
            conexao.Close()
            Return Nothing
        End If
    End Function

    'função para obter login
    Private Function CriarLogin(email As String, password As String)
        Dim query As String
        query = $"INSERT INTO LOGIN values (@malito, @pass, 2, CURRENT_TIMESTAMP);"

        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@pass", password)
        comando.Parameters.AddWithValue("@malito", email)



        Return 0
        'se X, lançar erro email existente
        'se Y, lançar sucesso
        'se Z, lançar outro tipo de erro não relacionado com a bd
    End Function

    'função para dar ordem de reset na pw
    Private Function ResetPassword(email As String)
    End Function

    'função para alterar pw/email/user
    Private Function AlterarPassword(ID_login As Integer, email As String, password As String)
    End Function

    ''' <summary>
    ''' ler dados do login, como é por parametros, esta é apenas utilizada nesta classe
    ''' </summary>
    ''' <param name="password"></param>
    ''' <param name="email"></param>
    ''' <returns></returns>
    Public Function LeituraTabela(password As String, email As String) As DataTable

        'conexao e comando para termos acesso e podermos enviar a query para a base de dados
        Dim conexao As New SqlConnection(Conector.stringConnection)
        Dim comando As SqlCommand = conexao.CreateCommand()

        Dim query As String = $"SELECT t.ID_tecnico, t.nome, l.email , l.ID_role
                                FROM Tecnico as t
                                INNER JOIN Login l ON t.ID_login = l.ID_login
                                WHERE l.password = @pass
                                AND l.email = @malito"

        comando.Parameters.AddWithValue("@pass", password)
        comando.Parameters.AddWithValue("@malito", email)

        comando.CommandText() = Query
        conexao.Open()

        'para onde a informação vai ser recebida e atribuida
        Dim recetor As New SqlDataAdapter(comando)
        Dim dados As New DataTable()

        recetor.Fill(dados)
        comando.Parameters.Clear()
        conexao.Close()
        Return dados
    End Function
End Class
