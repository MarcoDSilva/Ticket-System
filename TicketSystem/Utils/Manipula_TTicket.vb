Imports System.Data.SqlClient
Public Class Manipula_TTicket
    Inherits ObterDados

    'conexao ja feita com a sc
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)

    ''' <summary>
    ''' Criação de um novo ticket. Efectua as verificações necessárias antes de criar o novo registo.
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
    Public Sub CriaTicket(ID_tecnico As Integer, ID_software As Integer, ID_cliente As Integer, ID_problema As Integer,
                          descricao As String, dataAbertura As String, dataFecho As String, tempoPrevisto As Integer,
                          tempoTotal As Integer, ID_estado As Integer, ID_prioridade As Integer, ID_utilizador As Integer,
                          ID_origem As Integer)

        Dim query = $"INSERT INTO Ticket VALUES({ID_tecnico},{ID_software}, {ID_cliente},
                 {ID_problema}, @desc, @dat_init, @dat_end, 
                 {tempoPrevisto}, {tempoTotal}, {ID_estado}, {ID_prioridade}, 
                 @user, {ID_origem}, CURRENT_TIMESTAMP)"

        Dim comando As New SqlCommand(query, conexao)

        comando.Parameters.AddWithValue("@desc", VerificaDescricao(descricao))

        'condicionais para verificar a data de abertura do ticket
        If dataAbertura.Equals("CURRENT_TIMESTAMP") Then
            comando.Parameters.AddWithValue("@dat_init", DateTime.Now.ToString("MM-dd-yyyy H:mm:ss"))
        Else
            comando.Parameters.AddWithValue("@dat_init", dataAbertura)
        End If

        'condicionais para verificar a data de fecho do ticket
        comando.Parameters.AddWithValue("@dat_end", IIf(dataFecho.Equals("null"), DBNull.Value, dataFecho))

        'verificar se o ticket tem um utilizador correspondente ao mesmo
        comando.Parameters.AddWithValue("@user", VerificaUtilizador(ID_utilizador))
        ExecutaComandos(comando)

    End Sub

    ''' <summary>
    ''' Edita a base de dados com os dados recebidos. Efectua X verificações antes de dar a ordem de actualização.
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
    ''' <param name="ID_ticket"></param>
    Public Sub EditaTicket(ID_tecnico As Integer, ID_software As Integer, ID_cliente As Integer, ID_problema As Integer,
                          descricao As String, dataAbertura As String, dataFecho As String, tempoPrevisto As Integer,
                          tempoTotal As Integer, ID_estado As Integer, ID_prioridade As Integer, ID_utilizador As Integer,
                          ID_origem As Integer, ID_ticket As Integer)

        Dim query = $"UPDATE Ticket SET ID_tecnico = {ID_tecnico}, ID_software = {ID_software}, ID_cliente = {ID_cliente}, 
                      ID_problema = {ID_problema}, descricao = @desc, dataAbertura = @data_init, dataFecho = @data_end,
                      tempoPrevisto = {tempoPrevisto}, tempoTotal = {tempoTotal}, ID_estado = {ID_estado},
                      ID_prioridade = {ID_prioridade}, ID_utilizador = @user, ID_origem = {ID_origem}, 
                      dat_hor = CURRENT_TIMESTAMP 
                      WHERE ID_ticket = {ID_ticket};"

        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@desc", VerificaDescricao(descricao))
        comando.Parameters.AddWithValue("@data_init", dataAbertura)
        comando.Parameters.AddWithValue("@data_end", IIf(dataFecho.Equals("null"), DBNull.Value, dataFecho))
        comando.Parameters.AddWithValue("@user", VerificaUtilizador(ID_utilizador))
        ExecutaComandos(comando)
    End Sub

    ''' <summary>
    ''' Apaga o ticket que tenha o ID recebido por parametro.
    ''' </summary>
    ''' <param name="ID_ticket"></param>
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

    ''' <summary>
    ''' Devolve se a descrição foi inserida, ou uma string a dizer que não foi
    ''' </summary>
    ''' <param name="descricao"></param>
    ''' <returns></returns>
    Private Function VerificaDescricao(descricao As String) As String
        If String.IsNullOrEmpty(descricao) Then
            Return "Descrição não inserida"
        Else
            Return descricao
        End If
    End Function

    ''' <summary>
    ''' Retorna se o utilizador foi inserido ou não, devolvendo o ID ou um nulo.
    ''' </summary>
    ''' <param name="ID_utilizador"></param>
    ''' <returns></returns>
    Private Function VerificaUtilizador(ID_utilizador As Integer)

        If ID_utilizador.Equals(0) Then
            Return DBNull.Value
        Else
            Return ID_utilizador
        End If

    End Function

End Class
