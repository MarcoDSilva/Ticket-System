Imports System.Data.SqlClient

Public Class Manipula_TEstado
    Inherits ObterDados

    'Comando já com a String Conection pronta para utilizar nos métodos abaixo
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)

    ''' <summary>
    ''' Insere um novo tipo de estado na bd
    ''' </summary>
    ''' <param name="estado"></param>
    Public Sub InserirNovoEstado(estado As String)
        Dim query As String = "Insert into Estado values(@new, CURRENT_TIMESTAMP);"
        Dim comando As New SqlCommand(query, conexao)

        comando.Parameters.AddWithValue("@new", estado)

        ExecutaComandos(comando)
    End Sub

    ''' <summary>
    ''' Edita um tipo de estado na bd, recebendo o estado e o ID do estado a editar
    ''' </summary>
    ''' <param name="estado"></param>
    ''' <param name="ID_estado"></param>
    Public Sub EditarEstado(estado As String, ID_estado As Integer)
        Dim query As String = $"UPDATE Estado SET descricao = @edit, dat_hor = CURRENT_TIMESTAMP WHERE ID_estado = {ID_estado};"
        Dim comando As New SqlCommand(query, conexao)

        comando.Parameters.AddWithValue("@edit", estado)
        ExecutaComandos(comando)
    End Sub

    ''' <summary>
    ''' Apaga o tipo de estado selecionado
    ''' </summary>
    ''' <param name="ID_estado"></param>
    Public Sub ApagarEstado(ID_estado As Integer)
        Dim query As String = $"DELETE FROM Estado WHERE ID_estado = {ID_estado};"
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
