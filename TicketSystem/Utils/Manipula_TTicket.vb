Imports System.Data.SqlClient
Public Class Manipula_TTicket
    Inherits ObterDados

    'conexao ja feita com a sc
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)

    Public Sub CriaTicket(ticket As Ticket)
        Dim query As String

        query = $"INSERT INTO Ticket VALUES({ticket.ID_tecnico},{ticket.ID_software}, {ticket.ID_cliente},
                 {ticket.ID_problema}, {ticket.descricao}, {ticket.dataAbertura}, {ticket.dataFecho}, 
                 {ticket.tempoPrevisto}, {ticket.tempoTotal}, {ticket.ID_estado}, {ticket.ID_prioridade},
                 {ticket.ID_origem}, CURRENT_TIMESTAMP)"

        query = "INSERT INTO Ticket VALUES(3,2,9,15,
                'vamos testar objetos na oficima', '2020-02-03', 
                 NULL,100,200,2,4,NULL,3,CURRENT_TIMESTAMP);"
    End Sub

    Public Sub EditaTicket()
        Dim query As String
    End Sub

    Public Sub ApagaTicket()

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
