Imports System.Data.SqlClient
Public Class Manipula_TTicket
    Inherits ObterDados

    'conexao ja feita com a sc
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)

    ''' <summary>
    ''' Criação de um novo ticket
    ''' </summary>
    ''' <param name="ticket"></param>
    Public Sub CriaTicket(ticket As Ticket)
        Dim query As String

        query = $"INSERT INTO Ticket VALUES({ticket.ID_tecnico},{ticket.ID_software}, {ticket.ID_cliente},
                 {ticket.ID_problema}, @desc, {ticket.dataAbertura}, {ticket.dataFecho}, 
                 {ticket.tempoPrevisto}, {ticket.tempoTotal}, {ticket.ID_estado}, {ticket.ID_prioridade},
                 {ticket.ID_origem}, CURRENT_TIMESTAMP)"

        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@desc", {ticket.descricao})

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
