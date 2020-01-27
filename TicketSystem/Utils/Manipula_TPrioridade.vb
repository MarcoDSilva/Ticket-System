Imports System.Data.SqlClient
Public Class Manipula_TPrioridade
    Inherits ObterDados

    'conexao com a StringConnection já atribuida
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)

    ''' <summary>
    ''' insere nova prioridade na tabela
    ''' </summary>
    ''' <param name="descricao"></param>
    Public Sub InserirNovaPrioridade(descricao As String)
        Dim query As String = $"INSERT INTO Prioridade VALUES (@desc, CURRENT_TIMESTAMP);"
        Dim comando As New SqlCommand(query, conexao)

        comando.Parameters.AddWithValue("@desc", descricao)
        ExecutaComandos(comando)

    End Sub

    ''' <summary>
    ''' edita a prioridade que corresponda ao ID enviado
    ''' </summary>
    ''' <param name="descricao"></param>
    ''' <param name="ID_prioridade"></param>
    Public Sub EditarPrioridade(descricao As String, ID_prioridade As Integer)
        Dim query As String = $"UPDATE Prioridade SET descricao = @desc, dat_hor = CURRENT_TIMESTAMP WHERE ID_prioridade = {ID_prioridade};"
        Dim comando As New SqlCommand(query, conexao)

        comando.Parameters.AddWithValue("@desc", descricao)
        ExecutaComandos(comando)
    End Sub

    ''' <summary>
    ''' apaga a prioridade correspondente ao id enviado
    ''' </summary>
    ''' <param name="ID_prioridade"></param>
    Public Sub ApagarPrioridade(ID_prioridade As Integer)
        Dim query As String = $"DELETE FROM Prioridade WHERE ID_prioridade = {ID_prioridade}"
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
