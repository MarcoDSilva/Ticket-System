Imports System.Data.SqlClient

Public Class Manipula_TTecnico
    Inherits ObterDados

    'conecta SC
    Dim conexao As New SqlConnection(Conector.stringConnection)

    Public Sub AdicionaTecnico(nome As String, email As String)
        Dim query As String = "INSERT INTO Tecnico Values (@tecn, @malito, CURRENT_TIMESTAMP)"
        Dim comando As New SqlCommand(query, conexao)

        comando.Parameters.AddWithValue("@tecn", nome)
        comando.Parameters.AddWithValue("@malito", email)
        ExecutaComandos(comando)

    End Sub

    Public Sub EditaTecnico(nome As String, email As String, ID_tecnico As Integer)
        Dim query As String = $"UPDATE Tecnico SET nome = @tecn, email = @malito, dat_hor = CURRENT_TIMESTAMP WHERE ID_tecnico = {ID_tecnico};"
        Dim comando As New SqlCommand(query, conexao)

        comando.Parameters.AddWithValue("@tecn", nome)
        comando.Parameters.AddWithValue("@malito", email)
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


End Class
