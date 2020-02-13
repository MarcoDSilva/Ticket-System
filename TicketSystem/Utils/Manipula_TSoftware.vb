Imports System.Data.SqlClient

Public Class Manipula_TSoftware
    Inherits ObterDados

    'conexao já com a connection string
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)

    Public Sub AdicionaSoftware(software As String)
        Dim query As String = "INSERT INTO Software VALUES (@soft, CURRENT_TIMESTAMP);"
        Dim comando As New SqlCommand(query, conexao)

        comando.Parameters.AddWithValue("@soft", software)
        ExecutaComandos(comando)
    End Sub

    Public Sub EditarSoftware(software As String, ID_software As Integer)
        Dim query As String = $"UPDATE Software SET nome = @soft, dat_hor = CURRENT_TIMESTAMP WHERE ID_software = {ID_software};"
        Dim comando As New SqlCommand(query, conexao)

        comando.Parameters.AddWithValue("@soft", software)
        ExecutaComandos(comando)
    End Sub

    Public Sub ApagarSoftware(ID_software As Integer)
        Dim query As String = $"DELETE FROM Software WHERE ID_software = {ID_software};"
        Dim comando As New SqlCommand(query, conexao)

        ExecutaComandos(comando)

    End Sub

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
