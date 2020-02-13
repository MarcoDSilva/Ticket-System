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
    Public Sub ResetPassword(email As String)
    End Sub

    'função para alterar pw/email/user
    Public Function AlterarPassword(ID_tecnico As Integer, email As String,
                                    passwordActual As String, passwordNova As String) As Integer

        Dim query As String = "SELECT ID_tecnico FROM Tecnico
                               WHERE password = @pass AND email = @malito"

        Dim passwordAntigaValidada = ValidarEdicaoPassword(ID_tecnico, email, passwordActual, passwordNova)

        If passwordAntigaValidada = 1 Then
            Return 1
        Else
            Return 0
        End If

    End Function

    ''' <summary>
    ''' ler dados do login, como é por parametros, esta é apenas utilizada nesta classe
    ''' </summary>
    ''' <param name="password"></param>
    ''' <param name="email"></param>
    ''' <returns></returns>
    Private Function LeituraTabela(password As String, email As String) As Tecnico

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

    ''' <summary>
    ''' Valida a password para ser editada.
    ''' Começamos por comparar a password actual com a que nos foi enviada, 
    ''' se o login(email e pw) corresponderem, procedemos a receber o ID desse utilizador.
    ''' Comparamos o ID do utilizador que retiramos, comparamos com o ID do user
    ''' que está a tentar alterar a password, e se correspondem, alteramos a password
    ''' </summary>
    ''' <param name="ID_tecnico"></param>
    ''' <param name="email"></param>
    ''' <param name="passwordActual"></param>
    ''' <param name="passwordNova"></param>
    ''' <returns></returns>
    Private Function ValidarEdicaoPassword(ID_tecnico As Integer, email As String,
                                           passwordActual As String, passwordNova As String) As Integer

        Dim idEncontrado = 0
        Dim passwordValidada = 0
        Dim query As String = $"SELECT ID_tecnico FROM Tecnico WHERE email = @malito
                                AND password = @pass"

        Using conexao As New SqlConnection(Conector.stringConnection)
            Dim comando As New SqlCommand(query, conexao)
            comando.Parameters.AddWithValue("@malito", email)
            comando.Parameters.AddWithValue("@pass", passwordActual)

            Try
                conexao.Open()
                idEncontrado = Convert.ToInt32(comando.ExecuteScalar())

                If idEncontrado = ID_tecnico Then
                    Dim queryNova = $"UPDATE Tecnico SET password = @passNova WHERE ID_tecnico = {ID_tecnico}"

                    Dim comandoActualizaPw As New SqlCommand(queryNova, conexao)
                    comandoActualizaPw.Parameters.AddWithValue("@passNova", passwordNova)

                    conexao.Open()


                    passwordValidada = comandoActualizaPw.ExecuteNonQuery()
                    comandoActualizaPw.Parameters.Clear()
                    conexao.Close()
                End If

            Catch ex As Exception
                'não temos conexão, ou outros erros
            End Try
            comando.Parameters.Clear()
        End Using

        Return passwordValidada
    End Function

End Class
