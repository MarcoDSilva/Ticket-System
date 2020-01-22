Imports System.Data.SqlClient

Public Class ManipulaDados


    Private stringConnection = "Data Source=DESKTOP-L69QEGS\SQLEXPRESS;
                            Initial Catalog=TicketSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;
                            TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

    ''' <summary>
    ''' 'metodo para conectar À base de dados para conexões em SQL
    ''' </summary>
    ''' <param name="query"></param>
    ''' <returns></returns>
    Public Function Conectar(query As String) As DataTable

        'conexao e comando para termos acesso e podermos enviar a query para a base de dados
        Dim conexao As New SqlConnection(stringConnection)
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

    ''' <summary>
    ''' método para inserir dados após proceder à conexão à bd
    ''' </summary>
    ''' <param name="query"></param>
    Public Sub Inserir(query As String)

    End Sub

End Class
