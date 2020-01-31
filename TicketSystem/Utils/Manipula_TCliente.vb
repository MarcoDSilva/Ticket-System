Imports System.Data.SqlClient
Public Class Manipula_TCliente
    Inherits ObterDados

    'conexao ja feita com a sc
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)


    ''' <summary>
    ''' Adiciona novo cliente na bd.
    ''' </summary>
    ''' <param name="nome"></param>
    ''' <param name="contacto"></param>
    ''' <param name="email"></param>
    ''' <param name="empresa"></param>
    ''' <param name="ID_utilizador"></param>
    Private Sub AdicionarCliente(nome As String, contacto As String, email As String, empresa As String,
                                 ID_utilizador As Integer?)

        Dim query As String = $"INSERT INTO Cliente VALUES (@user, @contact, @malito, @company, {ID_utilizador})"
        Dim comando As New SqlCommand(query, conexao)

        comando.Parameters.AddWithValue("@user", nome)
        comando.Parameters.AddWithValue("@contact", contacto)
        comando.Parameters.AddWithValue("@malito", email)
        comando.Parameters.AddWithValue("@company", empresa)

        ExecutaComandos(comando)
    End Sub

    ''' <summary>
    ''' Edita o cliente
    ''' </summary>
    ''' <param name="nome"></param>
    ''' <param name="contacto"></param>
    ''' <param name="email"></param>
    ''' <param name="empresa"></param>
    ''' <param name="ID_utilizador"></param>
    ''' <param name="ID_cliente"></param>
    Private Sub EditarCliente(nome As String, contacto As String, email As String, empresa As String,
                              ID_utilizador As Integer?, ID_cliente As Integer)
        Dim query As String = $"UPDATE Cliente SET nome = @name, contacto = @contact, email = @malito, 
                               empresa = @company, ID_utilizador = {ID_utilizador}
                               WHERE ID_cliente = {ID_cliente}"

        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@user", nome)
        comando.Parameters.AddWithValue("@contact", contacto)
        comando.Parameters.AddWithValue("@malito", email)
        comando.Parameters.AddWithValue("@company", empresa)

        ExecutaComandos(comando)
    End Sub

    ''' <summary>
    ''' Apaga o cliente correspondente ao ID passado
    ''' </summary>
    ''' <param name="ID_cliente"></param>
    Private Sub ApagarCliente(ID_cliente As Integer)

        Dim query As String = $"DELETE FROM Cliente WHERE ID_cliente = {ID_cliente}"
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
