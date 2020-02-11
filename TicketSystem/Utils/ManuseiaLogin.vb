Imports System.Data.SqlClient

Public Class ManuseiaLogin
    Inherits ObterDados

    'Comando já com a String Conection pronta para utilizar nos métodos abaixo
    Private ReadOnly conexao As New SqlConnection(Conector.stringConnection)

    'função para criar login/pw
    Public Function Login(password As String, email As String)
        Dim query As String = "SELECT t.nome, l.email , r.descricao
                                FROM Tecnico as t
                                INNER JOIN Login l ON t.ID_login = l.ID_login
                                INNER JOIN Role r ON l.ID_role = r.ID_role
                                WHERE l.password = @pass
                                AND l.email = @malito;"

        Dim comando As New SqlCommand(query, conexao)
        comando.Parameters.AddWithValue("@pass", password)
        comando.Parameters.AddWithValue("@malito", email)

        conexao.Open()
        Dim loginEncontrado = comando.ExecuteNonQuery()
        comando.Parameters.Clear()
        conexao.Close()

        'se valor de X for positivo, criar objeto , adicionar os dados,e retornar como login válido
        If loginEncontrado = 1 Then
            'objecto com pessoa
            'return objeto pessoa
        Else
            'return nulo
        End If
        'controlador faz então a gestão desse utilizador, passa as cookies/sessions para a view


    End Function

    'função para obter login

    'função para dar ordem de reset na pw

    'função para alterar pw/email/user


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
