Imports System.Data.SqlClient

Public Class Manipula_TTecnico
    Inherits ObterDados

    'conecta SC
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)

    Public Function AdicionaTecnico(nome As String, email As String, ID_role As Integer) As Integer
        Dim query As String = $"INSERT INTO Tecnico Values (@tecn, @malito, 'password',
                                {ID_role}, CURRENT_TIMESTAMP)"

        Dim comando As New SqlCommand(query, conexao)

        comando.Parameters.AddWithValue("@tecn", nome)
        comando.Parameters.AddWithValue("@malito", email)

        'se email foi encontrado o método retorna 1, portanto
        'podemos avançar com a inserção do novo técnico, 
        'e devolvemos a mesma informação para o controlador poder confirmar a inserção
        If VerificaEmail(email) = 1 Then
            ExecutaComandos(comando)
            Return 1
        Else
            Return 0
        End If
    End Function

    ''' <summary>
    ''' Editar os valores actuais do técnico.
    ''' Se email for repetido, a actualização falha.
    ''' </summary>
    ''' <param name="nome"></param>
    ''' <param name="email"></param>
    ''' <param name="ID_role"></param>
    ''' <param name="ID_tecnico"></param>
    Public Sub EditaTecnico(nome As String, email As String, ID_role As Integer, ID_tecnico As Integer)
        Dim query As String = $"UPDATE Tecnico SET nome = @tecn, email = @malito, ID_role = {ID_role}, 
                                dat_hor = CURRENT_TIMESTAMP
                                WHERE ID_tecnico = {ID_tecnico};"
        Dim comando As New SqlCommand(query, conexao)

        comando.Parameters.AddWithValue("@tecn", nome)
        comando.Parameters.AddWithValue("@malito", email)

        'VERIFICAR SE EMAIL EXISTE, SE SIM, DEVOLVER ERRO
        ExecutaComandos(comando)

    End Sub

    ''' <summary>
    ''' Apagar o técnico pelo ID do mesmo
    ''' </summary>
    ''' <param name="ID_tecnico"></param>
    Public Sub ApagaTecnico(ID_tecnico As Integer)
        Dim query As String = $"DELETE FROM Tecnico WHERE ID_tecnico = {ID_tecnico}"
        Dim comando As New SqlCommand(query, conexao)
        ExecutaComandos(comando)
    End Sub

    ''' <summary>
    ''' Método que executa os comandos/queries a serem executadas na base de dados
    ''' Utilizado apenas para evitar repetição no código
    ''' </summary>
    ''' <param name="comando"></param>
    Public Sub ExecutaComandos(comando As SqlCommand)
        conexao.Open()
        comando.ExecuteNonQuery()
        comando.Parameters.Clear()
        conexao.Close()
    End Sub


    ''' <summary>
    ''' Procedemos À execução de um scalar, onde vai buscar exactamente o primeiro campo da query
    ''' Devolvemos 1 se encontrado (pois será o resultado da query) ou 0 caso não seja
    ''' </summary>
    ''' <param name="email"></param>
    ''' <returns></returns>
    Public Function VerificaEmail(email As String) As Integer

        Dim emailEncontrado = 0
        Dim query As String = $"SELECT count(email)
                                FROM Tecnico
                                WHERE email = '@malito'"

        Using conexao As New SqlConnection(Conector.stringConnection)
            Dim comando As New SqlCommand(query, conexao)
            comando.Parameters.AddWithValue("@malito", email)
            Try
                conexao.Open()
                emailEncontrado = Convert.ToInt32(comando.ExecuteScalar())
            Catch ex As Exception
                'não temos conexão, ou outros erros
            End Try
        End Using

        Return emailEncontrado
    End Function
End Class
