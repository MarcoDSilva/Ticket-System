Imports System.Data.SqlClient

Public Class Manipula_TEvento
    Inherits ObterDados

    'conexao ja feita com a sc
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)

    Public Sub AdicionaEvento(descricao As String, ID_tecnico As Integer, dataAbertura As DateTime, dataFecho As DateTime)

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
