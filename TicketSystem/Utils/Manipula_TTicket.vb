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
    Public Sub CriaTicket(ID_tecnico As Integer, ID_software As Integer, ID_cliente As Integer, ID_problema As Integer,
                          descricao As String, dataAbertura As String, dataFecho As String, tempoPrevisto As Integer,
                          tempoTotal As Integer, ID_estado As Integer, ID_prioridade As Integer, ID_utilizador As Integer,
                          ID_origem As Integer)

        Dim query As String

        query = $"INSERT INTO Ticket VALUES({ID_tecnico},{ID_software}, {ID_cliente},
                 {ID_problema}, @desc, @dat_init, @dat_end, 
                 {tempoPrevisto}, {tempoTotal}, {ID_estado}, {ID_prioridade}, 
                 @user, {ID_origem}, CURRENT_TIMESTAMP)"

        Dim comando As New SqlCommand(query, conexao)

        'as verificações de dados vão ser utilizadas com os parametros que estão na query
        'evitando assim, varias montagens da query em si

        'caso não tenha sido inserida descrição por algum motivo, lançamos para a bd
        'uma string a dizer que nunca foi inserida nenhuma (pode ser depois alterado na view)
        If String.IsNullOrEmpty(descricao) Then
            comando.Parameters.AddWithValue("@desc", "Descrição não inserida")
        Else
            comando.Parameters.AddWithValue("@desc", descricao)
        End If

        'condicionais para verificar a data de abertura do ticket
        If dataAbertura.Equals("CURRENT_TIMESTAMP") Then
            comando.Parameters.AddWithValue("@dat_init", DateTime.Now.ToString("MM-dd-yyyy H:mm:ss"))
        Else
            comando.Parameters.AddWithValue("@dat_init", dataAbertura)
        End If

        'condicionais para verificar a data de fecho do ticket
        If dataFecho.Equals("null") Then
            comando.Parameters.AddWithValue("@dat_end", DBNull.Value)
        Else
            comando.Parameters.AddWithValue("@dat_end", dataFecho)
        End If

        'verificar se o ticket tem um utilizador correspondente ao mesmo
        If ID_utilizador.Equals(0) Then
            comando.Parameters.AddWithValue("@user", DBNull.Value)
        Else
            comando.Parameters.AddWithValue("@user", ID_utilizador)
        End If

        ExecutaComandos(comando)

    End Sub

    Public Sub EditaTicket(ID_tecnico As Integer, ID_software As Integer, ID_cliente As Integer, ID_problema As Integer,
                          descricao As String, dataAbertura As String, dataFecho As String, tempoPrevisto As Integer,
                          tempoTotal As Integer, ID_estado As Integer, ID_prioridade As Integer, ID_utilizador As Integer,
                          ID_origem As Integer, ID_ticket As Integer)
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
