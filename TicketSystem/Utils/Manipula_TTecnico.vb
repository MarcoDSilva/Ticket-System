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

        If LeituraTabela(email).Rows(0).ToString() = "" Then
            ExecutaComandos(comando)
            Return 1
        Else
            Return 0
        End If

        'ExecutaComandos(comando)
        ''se tudo correr bem, devolvemos 1 para confirmar no controlo que foi sucesso
        'Return 1
    End Function

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
    ''' 
    ''' </summary>
    ''' <param name="email"></param>
    ''' <returns></returns>
    Public Function VerificaEmail(email As String) As DataTable

        'conexao e comando para termos acesso e podermos enviar a query para a base de dados
        Dim conexao As New SqlConnection(Conector.stringConnection)
        Dim comando As SqlCommand = conexao.CreateCommand()

        Dim query As String = $"SELECT email 
                                FROM Tecnico
                                WHERE email = '@malito'"

        comando.Parameters.AddWithValue("@malito", email)
        comando.CommandText() = query
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
