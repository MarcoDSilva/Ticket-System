Imports System.Data.SqlClient

Public Class ObterDados

    ''' <summary>
    ''' 'metodo para conectar À base de dados para conexões em SQL
    ''' </summary>
    ''' <param name="query"></param>
    ''' <returns></returns>
    Public Function LeituraTabela(query As String) As DataTable

        'conexao e comando para termos acesso e podermos enviar a query para a base de dados
        Dim conexao As New SqlConnection(Conector.stringConnection)
        Dim comando As SqlCommand = conexao.CreateCommand()

        comando.CommandText() = query
        conexao.Open()

        'para onde a informação vai ser recebida e atribuida
        Dim recetor As New SqlDataAdapter(comando)
        Dim dados As New DataTable()

        recetor.Fill(dados)
        conexao.Close()
        Return dados
    End Function
End Class
