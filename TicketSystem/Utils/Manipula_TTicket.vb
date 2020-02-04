Imports System.Data.SqlClient
Public Class Manipula_TTicket
    Inherits ObterDados

    'conexao ja feita com a sc
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)

    ''' <summary>
    ''' Criação de um novo ticket
    ''' </summary>
    ''' <param name="ticket"></param>
    Public Sub CriaTicket(ID_tecnico As Integer, ID_software As Integer, ID_cliente As Integer, ID_problema As Integer, descricao As String,
                          dataAbertura As String, dataFecho As String, tempoPrevisto As Integer, tempoTotal As Integer, ID_estado As Integer,
                          ID_prioridade As Integer, ID_utilizador As Integer, ID_origem As Integer)
        Dim query As String

        query = $"INSERT INTO Ticket VALUES({ID_tecnico},{ID_software}, {ID_cliente},
                 {ID_problema}, @desc, {dataAbertura}, {dataFecho}, 
                 {tempoPrevisto}, {tempoTotal}, {ID_estado}, {ID_prioridade},
                 {ID_utilizador},{ID_origem}, CURRENT_TIMESTAMP)"

        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@desc", {descricao})

        ExecutaComandos(comando)

    End Sub

    Public Sub EditaTicket()
        Dim query As String
    End Sub

    Public Sub ApagaTicket(ID_ticket As Integer)
        Dim query As String = $"DELETE FROM Ticket WHERE ID_ticket = {ID_ticket}"
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
