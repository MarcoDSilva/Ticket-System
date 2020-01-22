Imports System.Data.SqlClient

Public Class ManipulaDados

    'placeholder de string conection que será utilizada para a conexão À bd. A mesma pode ser escondida numa outra classe com método static para mais segurança...
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
    ''' <param name="problema"></param>
    Public Sub InserirNovoProblema(problema As String)
        Dim query As String = $"Insert into Problema values (@prob, CURRENT_TIMESTAMP);"

        Dim conexao As New SqlConnection(stringConnection)
        Dim comando As New SqlCommand(query, conexao)

        conexao.Open()
        comando.Parameters.AddWithValue("@prob", problema)

        'retorna o número de linhas afetadas, caso não haja nenhuma retorna -1
        comando.ExecuteNonQuery()
        comando.Parameters.Clear()
        conexao.Close()

    End Sub

    Public Sub ActualizarProblema(problema As String)

    End Sub

End Class
