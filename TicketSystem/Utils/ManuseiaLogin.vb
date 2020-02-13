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
    Public Function Login(password As String, email As String) As Tecnico

        Dim query As String = $"SELECT t.ID_tecnico, t.nome, t.email, t.ID_role
                                FROM Tecnico as t
                                WHERE t.password = @pass
                                AND t.email = @malito"

        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@pass", password)
        comando.Parameters.AddWithValue("@malito", email)
        conexao.Open()

        If comando.ExecuteReader().Read() Then
            Dim tecnicos = LeituraTabela(password, email)

            comando.Parameters.Clear()
            conexao.Close()

            Return tecnicos
        Else
            conexao.Close()
            Return Nothing
        End If
    End Function



    'função para dar ordem de reset na pw
    Private Function ResetPassword(email As String)
    End Function

    'função para alterar pw/email/user
    Private Function AlterarPassword(ID_tecnico As Integer, email As String, password As String)
    End Function

    ''' <summary>
    ''' ler dados do login, como é por parametros, esta é apenas utilizada nesta classe
    ''' </summary>
    ''' <param name="password"></param>
    ''' <param name="email"></param>
    ''' <returns></returns>
    Public Function LeituraTabela(password As String, email As String) As Tecnico

        Dim query As String = $"SELECT t.ID_tecnico, t.nome, t.email, t.ID_role
                                FROM Tecnico as t
                                WHERE t.password = @pass
                                AND t.email = @malito"

        Using conexao As New SqlConnection(Conector.stringConnection)
            Dim comando As New SqlCommand(query, conexao)
            comando.Parameters.AddWithValue("@pass", password)
            comando.Parameters.AddWithValue("@malito", email)

            conexao.Open()
            Dim leituraDados As SqlDataReader = comando.ExecuteReader()
            Dim tecnicoEncontrado As New Tecnico

            While leituraDados.Read()
                tecnicoEncontrado.ID_tecnico = leituraDados.Item(0)
                tecnicoEncontrado.nome = leituraDados.Item(1)
                tecnicoEncontrado.email = leituraDados.Item(2)
                tecnicoEncontrado.ID_role = leituraDados.Item(3)
            End While

            Return tecnicoEncontrado
        End Using
    End Function
End Class
