Imports System.Data.SqlClient
Public Class Manipula_TTicket
    Inherits ObterDados

    'conexao ja feita com a sc
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)

    ''' <summary>
    ''' Criação de um novo ticket
    ''' </summary>
    ''' <param name="ID_tecnico"></param>
    ''' <param name="ID_software"></param>
    ''' <param name="ID_cliente"></param>
    ''' <param name="ID_problema"></param>
    ''' <param name="descricao"></param>
    ''' <param name="dataAbertura"></param>
    ''' <param name="dataFecho"></param>
    ''' <param name="tempoPrevisto"></param>
    ''' <param name="tempoTotal"></param>
    ''' <param name="ID_estado"></param>
    ''' <param name="ID_prioridade"></param>
    ''' <param name="ID_utilizador"></param>
    ''' <param name="ID_origem"></param>
    Public Sub CriaTicket(ID_tecnico As Integer, ID_software As Integer, ID_cliente As Integer, ID_problema As Integer, descricao As String,
                          dataAbertura As String, dataFecho As String, tempoPrevisto As Integer, tempoTotal As Integer, ID_estado As Integer,
                          ID_prioridade As Integer, ID_utilizador As Integer, ID_origem As Integer)
        Dim query As String

        Dim dataInicio = dataAbertura
        Dim dataFim = dataFecho
        Dim utilizador = ID_utilizador

        If dataFecho.Equals("null") Then

            If dataAbertura.Equals("CURRENT_TIMESTAMP") Then
                query = $"INSERT INTO Ticket VALUES({ID_tecnico},{ID_software},{ID_cliente},
                 {ID_problema}, @desc, CURRENT_TIMESTAMP, NULL, 
                 {tempoPrevisto}, {tempoTotal}, {ID_estado}, {ID_prioridade},
                 {ID_utilizador},{ID_origem}, CURRENT_TIMESTAMP)"

            Else
                query = $"INSERT INTO Ticket VALUES({ID_tecnico},{ID_software},{ID_cliente},
                 {ID_problema}, @desc, {dataAbertura}, NULL, 
                 {tempoPrevisto}, {tempoTotal}, {ID_estado}, {ID_prioridade},
                 {ID_utilizador},{ID_origem}, CURRENT_TIMESTAMP)"
            End If

        Else

            If dataAbertura.Equals("CURRENT_TIMESTAMP") Then
                query = $"INSERT INTO Ticket VALUES({ID_tecnico},{ID_software},{ID_cliente},
                 {ID_problema}, @desc, CURRENT_TIMESTAMP, {dataFecho}, 
                 {tempoPrevisto}, {tempoTotal}, {ID_estado}, {ID_prioridade},
                 {ID_utilizador},{ID_origem}, CURRENT_TIMESTAMP)"

            Else
                query = $"INSERT INTO Ticket VALUES({ID_tecnico},{ID_software},{ID_cliente},
                 {ID_problema}, @desc, {dataAbertura}, {dataFecho}, 
                 {tempoPrevisto}, {tempoTotal}, {ID_estado}, {ID_prioridade},
                 {ID_utilizador},{ID_origem}, CURRENT_TIMESTAMP)"
            End If

        End If

        'query = $"INSERT INTO Ticket VALUES({ID_tecnico},{ID_software}, {ID_cliente},
        '         {ID_problema}, @desc, {dataAbertura}, {dataFecho}, 
        '         {tempoPrevisto}, {tempoTotal}, {ID_estado}, {ID_prioridade},
        '         {ID_utilizador},{ID_origem}, CURRENT_TIMESTAMP)"

        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@desc", {descricao})
        'tentar usar o addwithvalue com as condicionais numna tentativa de ter um código mais limpo, em vez de fazer a query non stop
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
