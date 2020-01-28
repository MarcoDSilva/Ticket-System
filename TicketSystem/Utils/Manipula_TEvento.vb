Imports System.Data.SqlClient

Public Class Manipula_TEvento
    Inherits ObterDados

    'conexao ja feita com a sc
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)

    Public Sub AdicionaEvento(descricao As String, ID_tecnico As Integer, dataAbertura As DateTime, dataFecho As DateTime, ID_ticket As Integer)
        Dim query As String = $"Insert into Evento Values(@desc, {ID_tecnico},'{dataAbertura}','{dataFecho}',{ID_ticket},CURRENT_TIMESTAMP);"
        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@desc", descricao)
        ExecutaComandos(comando)

    End Sub

    Public Sub EditaEvento(descricao As String, ID_tecnico As Integer, dataAbertura As DateTime, dataFecho As DateTime, ID_ticket As Integer, ID_evento As Integer)
        Dim query As String = $"UPDATE Evento SET descricao = @desc, ID_tecnico = {ID_tecnico}, dataAbertura = {dataAbertura}, 
                                dataFecho = {dataFecho}, ID_ticket = {ID_ticket} WHERE ID_evento = {ID_evento};"
        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@desc", descricao)

        ExecutaComandos(comando)

    End Sub

    Public Sub ApagaEvento(ID_evento As Integer)
        Dim query As String = $"DELETE FROM Evento WHERE ID_evento = {ID_evento}"
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
