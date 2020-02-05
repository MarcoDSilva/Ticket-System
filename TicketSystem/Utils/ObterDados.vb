Imports System.Data.SqlClient

Public Class ObterDados
    '============ Classe maioritariamente criada para leituras de dados das tabelas. ==========

    ''' <summary>
    ''' 'metodo para podermos ler/enviar queries de leitura (SQL) para a base de dados.
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

    ''' <summary>
    ''' Retorna uma lista de Técnicos, só ID e nome.
    ''' </summary>
    ''' <returns></returns>
    Public Function ListaTecnicos() As List(Of Tecnico)
        Dim tabelaTecnicos As DataTable = LeituraTabela("SELECT ID_tecnico, nome FROM Tecnico;")
        Dim listagemTecnicos As List(Of Tecnico) = New List(Of Tecnico)

        'ir buscar a informação da bd e adicionar na listagem
        For Each item In tabelaTecnicos.AsEnumerable
            Dim tec As New Tecnico
            tec.ID_tecnico = item(0)
            tec.nome = item(1)

            listagemTecnicos.Add(tec)
        Next

        Return listagemTecnicos
    End Function

    ''' <summary>
    ''' Retorna uma lista de Softwares, só ID e nome.
    ''' </summary>
    ''' <returns></returns>
    Public Function ListaSoftwares() As List(Of Software)
        Dim tabelaSoftware As DataTable = LeituraTabela("SELECT ID_software, nome FROM Software;")
        Dim listagemSoftware As List(Of Software) = New List(Of Software)

        'ir buscar a informação da bd e adicionar na listagem
        For Each item In tabelaSoftware.AsEnumerable
            Dim sft As New Software
            sft.ID_software = item(0)
            sft.nome = item(1)

            listagemSoftware.Add(sft)
        Next

        Return listagemSoftware
    End Function

    ''' <summary>
    ''' Retorna uma lista de Clientes, só com o ID e nome.
    ''' </summary>
    ''' <returns></returns>
    Public Function ListaClientes() As List(Of Cliente)
        Dim tabelaClientes As DataTable = LeituraTabela("SELECT ID_cliente, nome FROM Cliente;")
        Dim listagemClientes As List(Of Cliente) = New List(Of Cliente)

        'ir buscar a informação da bd e adicionar na listagem
        For Each item In tabelaClientes.AsEnumerable
            Dim cli As New Cliente
            cli.ID_cliente = item(0)
            cli.nome = item(1)

            listagemClientes.Add(cli)
        Next

        Return listagemClientes
    End Function

    ''' <summary>
    ''' Retorna uma lista de Problemas, só com o ID e descrição
    ''' </summary>
    ''' <returns></returns>
    Public Function ListaProblemas() As List(Of Problema)
        Dim tabelaProblemas As DataTable = LeituraTabela("SELECT ID_problema, descricao FROM Problema;")
        Dim listagemProblemas As List(Of Problema) = New List(Of Problema)

        'ir buscar a informação da bd e adicionar na listagem
        For Each item In tabelaProblemas.AsEnumerable
            Dim prob As New Problema
            prob.ID_problema = item(0)
            prob.descricao = item(1)

            listagemProblemas.Add(prob)
        Next

        Return listagemProblemas
    End Function

    ''' <summary>
    ''' Retorna uma lista de Estados, só com o ID e descrição.
    ''' </summary>
    ''' <returns></returns>
    Public Function ListaEstados() As List(Of Estado)
        Dim tabelaEstados As DataTable = LeituraTabela("SELECT ID_estado, descricao FROM Estado;")
        Dim listagemEstados As List(Of Estado) = New List(Of Estado)

        'ir buscar a informação da bd e adicionar na listagem
        For Each item In tabelaEstados.AsEnumerable
            Dim est As New Estado
            est.ID_estado = item(0)
            est.descricao = item(1)

            listagemEstados.Add(est)
        Next

        Return listagemEstados
    End Function

    ''' <summary>
    ''' Retorna uma lista de Prioridades, com o campo ID e descrição.
    ''' </summary>
    ''' <returns></returns>
    Public Function ListaPrioridades() As List(Of Prioridade)
        Dim tabelaPrioridades As DataTable = LeituraTabela("SELECT ID_prioridade, descricao FROM Prioridade;")
        Dim listagemPrioridades As List(Of Prioridade) = New List(Of Prioridade)

        'ir buscar a informação da bd e adicionar na listagem
        For Each item In tabelaPrioridades.AsEnumerable
            Dim prio As New Prioridade
            prio.ID_prioridade = item(0)
            prio.descricao = item(1)

            listagemPrioridades.Add(prio)
        Next

        Return listagemPrioridades
    End Function

    ''' <summary>
    ''' Retorna uma lista de Utilizadores, só com o campo ID e nome. 
    ''' Retorna também um "Sem utilizador" na posição 0, visto que o valor pode ser nulo.
    ''' </summary>
    ''' <returns></returns>
    Public Function ListaUtilizadores() As List(Of Utilizador)
        Dim tabelaUtilizadores As DataTable = LeituraTabela("SELECT ID_utilizador, nome FROM Utilizador;")
        Dim listagemUtilizadores As List(Of Utilizador) = New List(Of Utilizador)

        'adicionar o "sem utilizador" na lista
        Dim extra As New Utilizador
        extra.ID_utilizador = 0
        extra.nome = "Sem Utilizador"
        listagemUtilizadores.Add(extra)

        'ir buscar a informação da bd e adicionar na listagem
        For Each item In tabelaUtilizadores.AsEnumerable
            Dim ut As New Utilizador
            ut.ID_utilizador = item(0)
            ut.nome = item(1)

            listagemUtilizadores.Add(ut)
        Next

        Return listagemUtilizadores
    End Function

    ''' <summary>
    ''' Retorna uma lista de Origens, só com o campo ID e descrição.
    ''' </summary>
    ''' <returns></returns>
    Public Function ListaOrigens() As List(Of Origem)
        Dim tabelaOrigens As DataTable = LeituraTabela("SELECT ID_origem, descricao FROM Origem;")
        Dim listagemOrigens As List(Of Origem) = New List(Of Origem)

        'ir buscar a informação da bd e adicionar na listagem
        For Each item In tabelaOrigens.AsEnumerable
            Dim orig As New Origem
            orig.ID_origem = item(0)
            orig.descricao = item(1)
            listagemOrigens.Add(orig)
        Next

        Return listagemOrigens
    End Function

End Class
