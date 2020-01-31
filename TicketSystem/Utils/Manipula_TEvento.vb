Imports System.Data.SqlClient

Public Class Manipula_TEvento
    Inherits ObterDados

    'conexao ja feita com a sc
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)


    ''' <summary>
    ''' Adiciona um evento na base de dados.
    ''' Caso o valor da dataFecho não ter sido escolhida, é enviado o valor NULL para a bd.
    ''' </summary>
    ''' <param name="descricao"></param>
    ''' <param name="ID_tecnico"></param>
    ''' <param name="dataAbertura"></param>
    ''' <param name="dataFecho"></param>
    ''' <param name="ID_ticket"></param>
    Public Sub AdicionaEvento(descricao As String, ID_tecnico As Integer,
                              dataAbertura As String, dataFecho As String, ID_ticket As Integer)
        Dim query As String

        'se o dataFecho estiver vazio, enviamos NULL como parametro para a bd
        'caso contrário passamos a data recebida
        'no caso da data de abertura, passamos current_timestamp caso não haja data escolhida
        If String.IsNullOrEmpty(dataFecho) Then

            'retiramos ou adicionamos pelicas dependendo da abertura
            If dataAbertura.Equals("CURRENT_TIMESTAMP") Then
                query = $"Insert into Evento Values(@desc, {ID_tecnico}, 
                        {dataAbertura}, NULL, 
                        {ID_ticket} , CURRENT_TIMESTAMP);"
            Else
                query = $"Insert into Evento Values(@desc, {ID_tecnico}, 
                        '{dataAbertura}', NULL, 
                         {ID_ticket} , CURRENT_TIMESTAMP);"
            End If
        Else
            'retiramos ou adicionamos pelicas dependendo do resultado da abertura
            If dataAbertura.Equals("CURRENT_TIMESTAMP") Then
                query = $"Insert into Evento Values(@desc, {ID_tecnico}, 
                        {dataAbertura}, '{dataFecho}', 
                        {ID_ticket} , CURRENT_TIMESTAMP);"
            Else
                query = $"Insert into Evento Values(@desc, {ID_tecnico}, 
                        '{dataAbertura}', '{dataFecho}', 
                         {ID_ticket} , CURRENT_TIMESTAMP);"
            End If

        End If

        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@desc", descricao)
        ExecutaComandos(comando)

    End Sub

    ''' <summary>
    ''' Actualiza a tabela do evento consoante os registos passados. 
    ''' </summary>
    ''' <param name="ID_evento"></param>
    ''' <param name="descricao"></param>
    ''' <param name="ID_tecnico"></param>
    ''' <param name="dataAbertura"></param>
    ''' <param name="dataFecho"></param>
    Public Sub EditaEvento(ID_evento As Integer, descricao As String, ID_tecnico As Integer, dataAbertura As String, dataFecho As String)
        Dim query As String

        'Se a string enviada pela data fecho for null, a query envia o valor como null
        'caso contrário, enviamos a data que recebemos 
        If dataFecho.Equals("NULL") Then
            query = $"UPDATE Evento SET descricao = @desc, ID_tecnico = {ID_tecnico}, dataAbertura = '{dataAbertura}', 
                                dataFecho = NULL, dat_hor = CURRENT_TIMESTAMP WHERE ID_evento = {ID_evento};"
        Else
            query = $"UPDATE Evento SET descricao = @desc, ID_tecnico = {ID_tecnico}, dataAbertura = '{dataAbertura}', 
                                dataFecho = '{dataFecho}', dat_hor = CURRENT_TIMESTAMP WHERE ID_evento = {ID_evento};"
        End If

        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@desc", descricao)

        ExecutaComandos(comando)

    End Sub

    ''' <summary>
    ''' Apaga o evento correspondente ao ID enviado
    ''' </summary>
    ''' <param name="ID_evento"></param>
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
