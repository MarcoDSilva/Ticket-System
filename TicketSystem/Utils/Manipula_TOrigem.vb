Imports System.Data.SqlClient

Public Class Manipula_TOrigem
    Inherits ObterDados

    'conexao da SC
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)

    Public Sub AdicionarOrigem(descricao As String)
        Dim query As String = "INSERT INTO Origem VALUES (@org, CURRENT_TIMESTAMP);"
        Dim comando As New SqlCommand(query, conexao)

        comando.Parameters.AddWithValue("@org", descricao)
        ExecutaComandos(comando)
    End Sub

    Public Sub EditarOrigem(descricao As String, ID_origem As Integer)
        Dim query As String = $"UPDATE Origem SET origem = @org , dat_hor = CURRENT_TIMESTAMP WHERE ID_origem = {ID_origem};"
        Dim comando As New SqlCommand(query, conexao)

        comando.Parameters.AddWithValue("@org", descricao)
        ExecutaComandos(comando)
    End Sub

    Public Sub ApagarOrigem(ID_origem As Integer)
        Dim query As String = $"DELETE FROM Origem WHERE ID_origem = {ID_origem};"
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

End Class
