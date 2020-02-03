Imports System.Data.SqlClient


Namespace Controllers
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
        Public Sub AdicionarCliente(nome As String, contacto As String, email As String, empresa As String,
                                         ID_utilizador As String)

            Dim query As String

            If ID_utilizador.Equals("null") Then
                query = $"INSERT INTO Cliente VALUES (@user, @contact, @malito, @company, NULL,CURRENT_TIMESTAMP);"
            Else
                query = $"INSERT INTO Cliente VALUES (@user, @contact, @malito, @company, {ID_utilizador}, CURRENT_TIMESTAMP);"
            End If

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
        Public Sub EditarCliente(nome As String, contacto As String, email As String, empresa As String,
                                      ID_utilizador As String, ID_cliente As Integer)
            Dim query As String

            'se recebermos um nulo do controlador, enviamos o valor null para a bd
            'caso contrário, utilizamos esse id como valor para o utilizador
            If ID_utilizador.Equals("null") Then
                query = $"UPDATE Cliente SET nome = @name, contacto = @contact, email = @malito, 
                               empresa = @company, ID_utilizador = NULL
                               WHERE ID_cliente = {ID_cliente};"
            Else
                query = $"UPDATE Cliente SET nome = @name, contacto = @contact, email = @malito, 
                               empresa = @company, ID_utilizador = {ID_utilizador}
                               WHERE ID_cliente = {ID_cliente};"
            End If

            Dim comando As New SqlCommand(query, conexao)

            comando.Parameters.AddWithValue("name", nome)
            comando.Parameters.AddWithValue("@contact", contacto)
            comando.Parameters.AddWithValue("@malito", email)
            comando.Parameters.AddWithValue("@company", empresa)

            ExecutaComandos(comando)
        End Sub

        ''' <summary>
        ''' Apaga o cliente correspondente ao ID passado
        ''' </summary>
        ''' <param name="ID_cliente"></param>
        Public Sub ApagarCliente(ID_cliente As Integer)

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

End Namespace