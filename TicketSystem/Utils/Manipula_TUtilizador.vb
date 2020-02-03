Imports System.Data.SqlClient
Public Class Manipula_TUtilizador
    Inherits ObterDados

    'conexao ja feita com a sc
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)

    ''' <summary>
    ''' Inserir dados na bd. Condicional para prever caso que o ID_Cliente não tenha atribuição.
    ''' </summary>
    ''' <param name="nome"></param>
    ''' <param name="contacto"></param>
    ''' <param name="email"></param>
    ''' <param name="ID_cliente"></param>
    Public Sub AdicionaUtilizador(nome As String, contacto As String, email As String, ID_cliente As String)
        Dim query As String

        If ID_cliente.Equals("null") Then
            query = $"INSERT INTO Utilizador VALUES(@name, @contact, @malito, NULL, CURRENT_TIMESTAMP)"
        Else
            query = $"INSERT INTO Utilizador VALUEs(@name,@contact,@malito, {ID_cliente}, CURRENT_TIMESTAMP)"
        End If

        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@name", nome)
        comando.Parameters.AddWithValue("@contact", contacto)
        comando.Parameters.AddWithValue("@malito", email)

        ExecutaComandos(comando)

    End Sub

    ''' <summary>
    ''' Edita o utilizador consoante os dados transmitidos da view/controlador
    ''' </summary>
    ''' <param name="ID_utilizador"></param>
    ''' <param name="nome"></param>
    ''' <param name="contacto"></param>
    ''' <param name="email"></param>
    ''' <param name="ID_cliente"></param>
    Public Sub EditaUtilizador(ID_utilizador As Integer, nome As String, contacto As String, email As String, ID_cliente As String)
        Dim query As String

        If ID_cliente.Equals("null") Then
            query = $"UPDATE Utilizador SET nome = @name, contacto = @contact , email = @malito, ID_cliente = NULL, dat_hor = CURRENT_TIMESTAMP
                      WHERE ID_utilizador = {ID_utilizador};"
        Else
            query = $"UPDATE Utilizador SET nome = @name, contacto = @contact, email = @malito, ID_cliente = {ID_cliente}, dat_hor = CURRENT_TIMESTAMP
                      WHERE ID_utilizador = {ID_utilizador};"
        End If

        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@name", nome)
        comando.Parameters.AddWithValue("@contact", contacto)
        comando.Parameters.AddWithValue("@malito", email)

        ExecutaComandos(comando)

    End Sub


    ''' <summary>
    ''' Apaga o utilizador consoante o ID
    ''' </summary>
    ''' <param name="ID_utilizador"></param>
    Public Sub ApagaUtilizador(ID_utilizador As Integer)
        Dim query = $"DELETE FROM Utilizador WHERE ID_utilizador = {ID_utilizador}"
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
