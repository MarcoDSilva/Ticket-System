Imports System.Data.SqlClient

Public Class Manipula_TProblema
    Inherits ObterDados

    'inserir a conexao como uma propriedade da classe que só pode ser utilizada como leitura e não alterada
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)


    ''' <summary>
    ''' método para inserir dados após proceder à conexão à bd
    ''' eventualmente -poderá- lançar erro caso a execução da query falhe
    ''' </summary>
    ''' <param name="problema"></param>
    Public Sub InserirNovoProblema(problema As String)
        Dim query As String = $"Insert into Problema values (@prob, CURRENT_TIMESTAMP);"

        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@prob", problema)

        conexao.Open()
        comando.ExecuteNonQuery()
        comando.Parameters.Clear()
        conexao.Close()

    End Sub

    ''' <summary>
    ''' método para actualizar os dados da bd
    ''' eventualmente -poderá- lançar erro caso a execução da query falhe
    ''' </summary>
    ''' <param name="problema"></param>
    Public Sub ActualizarProblema(problema As String, ID_Problema As Integer)
        Dim query As String = $"UPDATE Problema 
                                SET descricao = '@desc', dat_hor = CURRENT_TIMESTAMP 
                                WHERE ID_problema = {ID_Problema};"

        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@desc", problema) 'substituir ("sanitizing") do problema

        conexao.Open()
        comando.ExecuteNonQuery()
        comando.Parameters.Clear()
        conexao.Close()
    End Sub

    ''' <summary>
    ''' método para apagar o elemento pretendido na bd
    ''' eventualmente -poderá- lançar erro caso a execução da query falhe
    ''' </summary>
    ''' <param name="ID_problema"></param>
    Public Sub ApagarProblema(ID_problema As Integer)
        Dim query As String = $"DELETE FROM Problema
                                WHERE ID_problema = {ID_problema}"

        Dim comando As New SqlCommand(query, conexao)
        conexao.Open()
        comando.ExecuteNonQuery()
        comando.Parameters.Clear()
        conexao.Close()

    End Sub

End Class
