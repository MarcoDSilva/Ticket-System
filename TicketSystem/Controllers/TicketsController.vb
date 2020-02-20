Imports System.Net
Imports System.Web.Mvc

Namespace Controllers
    Public Class TicketsController
        Inherits Controller

        Private conectaBD As New Manipula_TTicket

        ' GET: Tickets
        Function Index(ordem As String, ID_prioridade As String, ID_estado As String, ID_problema As String,
                       ID_software As String, ID_cliente As String, ID_tecnico As String) As ActionResult
            BloqueiaUtilizadores()
            Dim query As String = "SELECT t.ID_ticket, tec.nome, sft.nome, cli.nome, prob.descricao, t.descricao, 
                                      t.dataAbertura, t.dataFecho, t.tempoPrevisto, t.tempoTotal, est.descricao,
                                      prio.descricao, t.ID_utilizador, ori.descricao,t.dat_hor

                                      FROM Ticket t,Tecnico tec, Software sft, Cliente cli, 
                                      Problema prob, Estado est, Prioridade prio,Origem ori

                                      WHERE t.ID_tecnico = tec.ID_tecnico
                                          AND sft.ID_software = t.ID_software
                                          AND cli.ID_cliente = t.ID_cliente
                                          AND prob.ID_problema = t.ID_problema
                                          AND est.ID_estado = t.ID_estado
                                          AND prio.ID_prioridade = t.ID_prioridade
                                          AND ori.ID_origem = t.ID_origem"

            CriaViewBags()

            Dim ordenaPorData = ""

            'adicionar os parametros um a um na lista, caso contrário o if fica gigantesco
            Dim l As New List(Of String)
            l.Add(ordem)
            l.Add(ordem)
            l.Add(ID_estado)
            l.Add(ID_prioridade)
            l.Add(ID_problema)
            l.Add(ID_software)
            l.Add(ID_cliente)
            l.Add(ID_tecnico)

            'função que se não encontrar nenhum elemento com valor, retorna true e podemos devolver à view uma query normal
            If VerificaParams(l) = True Then
                Return View(LeituraDados(query))
            End If

            'filtrar a ordenação para a query
            If (String.IsNullOrEmpty(ordem)) Then
                ordenaPorData = ""
            ElseIf ordem.Equals("decrescente") Then
                ordenaPorData = " ORDER BY dataAbertura desc"
            ElseIf ordem.Equals("crescente") Then
                ordenaPorData = " ORDER BY dataAbertura asc"
            End If

            'verificação se algum dos filtros foi ativos, e adiciona o resultado esperado por cada um à query
            query += IIf(String.IsNullOrEmpty(ID_prioridade),
                                    "", $" AND t.ID_prioridade = {ID_prioridade}")

            query += IIf(String.IsNullOrEmpty(ID_estado),
                                    "", $" AND t.ID_estado = {ID_estado}")

            query += IIf(String.IsNullOrEmpty(ID_problema),
                                    "", $" AND t.ID_problema = {ID_problema}")

            query += IIf(String.IsNullOrEmpty(ID_software),
                                    "", $" AND t.ID_software = {ID_software}")

            query += IIf(String.IsNullOrEmpty(ID_cliente),
                                    "", $" AND t.ID_cliente = {ID_cliente}")

            query += IIf(String.IsNullOrEmpty(ID_tecnico),
                                    "", $" AND t.ID_tecnico = {ID_tecnico}")

            query += ordenaPorData

            Return View(LeituraDados(query))

        End Function

        'GET: Cria a view para criação de tickets. A mesma contém várias dropdownlists que estão a ser alimentadas por viewbags
        Function CriaTicket() As ActionResult
            BloqueiaUtilizadores()
            CriaViewBags()
            Return View()
        End Function

        'POST:
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function CriaTicket(ticketParams As Ticket) As ActionResult
            BloqueiaUtilizadores()
            'variaveis para serem atribuidos valores para a query
            Dim tempoPrevisto, tempoTotal As Integer
            Dim dataAberturaConvertida, dataFechoConvertida As String

            'verificar os tempos
            tempoPrevisto = VerificaTempos(ticketParams.tempoPrevisto)
            tempoTotal = VerificaTempos(ticketParams.tempoTotal)

            dataAberturaConvertida = IIf(ticketParams.dataAbertura.Equals(""),
                                             "CURRENT_TIMESTAMP", ConverteDataHora(ticketParams.dataAbertura))

            dataFechoConvertida = VerificaDataFechoTicket(ticketParams.dataFecho)

            conectaBD.CriaTicket(Session("ID_tecnico"), ticketParams.ID_software, ticketParams.ID_cliente, ticketParams.ID_problema,
                                  ticketParams.descricao, dataAberturaConvertida, dataFechoConvertida, tempoPrevisto,
                                    tempoTotal, ticketParams.ID_estado, ticketParams.ID_prioridade, ticketParams.ID_utilizador, ticketParams.ID_origem)

            Return RedirectToAction("Index")
        End Function

        'GET:
        Function EditarTicket(ID_ticket As Integer?) As ActionResult
            BloqueiaUtilizadores()
            If IsNothing(ID_ticket) Then
                Return New HttpStatusCodeResult(HttpStatusCode.Forbidden)
            Else
                CriaViewBags()

                Return View(LeituraDados($"Select * from Ticket where ID_ticket = {ID_ticket}").First())
            End If
        End Function

        'POST: utiliza a informação recebida do ticket, e actualiza a bd com os mesmos
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function EditarTicket(ticketParams As Ticket) As ActionResult
            BloqueiaUtilizadores()
            If IsNothing(ticketParams.ID_ticket) Then
                Return New HttpStatusCodeResult(HttpStatusCode.Forbidden)
            Else
                Dim queryTicket = LeituraDados($"SELECT * FROM Ticket WHERE ID_Ticket = {ticketParams.ID_ticket}").First()

                'variaveis para serem atribuidos valores para a query
                Dim tempoPrevisto, tempoTotal As Integer
                Dim dataAberturaConvertida, dataFechoConvertida As String

                tempoPrevisto = VerificaTempos(ticketParams.tempoPrevisto)
                tempoTotal = VerificaTempos(ticketParams.tempoTotal)

                dataAberturaConvertida = IIf(String.IsNullOrEmpty(ticketParams.dataAbertura.ToString()),
                                             queryTicket.dataAbertura.ToString("MM-dd-yyyy"), ConverteDataHora(ticketParams.dataAbertura))

                dataFechoConvertida = VerificaDataFechoTicket(ticketParams.dataFecho)

                conectaBD.EditaTicket(Session("ID_tecnico"), ticketParams.ID_software, ticketParams.ID_cliente,
                                      ticketParams.ID_problema, ticketParams.descricao, dataAberturaConvertida, dataFechoConvertida,
                                      tempoPrevisto, tempoTotal, ticketParams.ID_estado, ticketParams.ID_prioridade, ticketParams.ID_utilizador,
                                      ticketParams.ID_origem, ticketParams.ID_ticket)
            End If

            Return RedirectToAction("Index")

        End Function

        'POST - Apagar o ticket 
        Function ApagarTicket(ID_ticket As Integer) As ActionResult
            BloqueiaUtilizadores()
            If IsNothing(ID_ticket) Then
                Return New HttpStatusCodeResult(HttpStatusCode.Forbidden)
            Else
                conectaBD.ApagaTicket(ID_ticket)
            End If
            Return RedirectToAction("Index")

        End Function

        ''' <summary>
        ''' Método interno utilizado para ler dados da bd
        ''' </summary>
        ''' <param name="query"></param>
        ''' <returns></returns>
        Private Function LeituraDados(query As String) As List(Of VM_Ticket)

            Dim tabelaDados As DataTable = conectaBD.LeituraTabela(query)
            Dim listagemTickets As New List(Of VM_Ticket)

            'fazemos um ciclo, que vai iterar por cada elemento que recebenos da base de dados
            'criamos um novo objecto do tipo Ticket, onde atribuimos os dados da iteração actual
            'e no fim após a atribuição desses dados, inserimos numa List(a) de Tickets, o qual usamos para retornar os dados
            For Each item In tabelaDados.AsEnumerable
                Dim tick As New VM_Ticket()

                tick.ID_ticket = item(0)
                tick.ID_tecnico = item(1)
                tick.ID_software = item(2)
                tick.ID_cliente = item(3)
                tick.ID_problema = item(4)
                tick.descricao = item(5)
                tick.dataAbertura = item(6)

                'prevê o caso da data ser nula
                If item(7).Equals(DBNull.Value) Then
                    tick.dataFecho = Nothing
                Else
                    tick.dataFecho = item(7)
                End If

                tick.tempoPrevisto = item(8)
                tick.tempoTotal = item(9)
                tick.ID_estado = item(10)
                tick.ID_prioridade = item(11)

                'prever o caso do utilizador ser não existente
                If item(12).Equals(DBNull.Value) Then
                    tick.ID_utilizador = Nothing
                Else
                    tick.ID_utilizador = item(12)
                End If

                tick.ID_origem = item(13)
                tick.dat_hor = item(14)

                listagemTickets.Add(tick)
            Next

            Return listagemTickets
        End Function

        ''' <summary>
        ''' Método para converter o datetime, adicionar horas/mins/segs e retornar a string já preparada
        ''' para ser adicionada na base de dados (formato MM-dd-yyyy H:mm:ss)
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        Function ConverteDataHora(data As DateTime) As String
            Dim tempoAConverter = data.AddHours(DateTime.Now.Hour).
                       AddSeconds(DateTime.Now.Second).AddMinutes(DateTime.Now.Minute)

            Return DateTime.Parse(tempoAConverter).ToString("MM-dd-yyyy H:mm:ss")

        End Function

        ''' <summary>
        ''' Verifica a data de fecho do ticket e retorna null se não existir data
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        Function VerificaDataFechoTicket(data As DateTime?) As String
            If IsNothing(data).Equals(False) Then
                Return ConverteDataHora(data)
            Else
                Return "null"
            End If
        End Function

        ''' <summary>
        ''' Método que cria as viewBags necessárias para a edição dos campos chave.
        ''' Para evitar repetição de código
        ''' </summary>
        Private Sub CriaViewBags()
            ViewBag.tecnico = New SelectList(conectaBD.ListaTecnicos(), "ID_tecnico", "nome")
            ViewBag.software = New SelectList(conectaBD.ListaSoftwares(), "ID_software", "nome")
            ViewBag.cliente = New SelectList(conectaBD.ListaClientes(), "ID_cliente", "nome")
            ViewBag.problema = New SelectList(conectaBD.ListaProblemas(), "ID_problema", "descricao")
            ViewBag.estado = New SelectList(conectaBD.ListaEstados(), "ID_estado", "descricao")
            ViewBag.prioridade = New SelectList(conectaBD.ListaPrioridades(), "ID_prioridade", "descricao")
            ViewBag.utilizador = New SelectList(conectaBD.ListaUtilizadores(), "ID_utilizador", "nome")
            ViewBag.origem = New SelectList(conectaBD.ListaOrigens(), "ID_origem", "descricao")
        End Sub

        ''' <summary>
        ''' Utilizado para prever o caso dos tempos serem enviados sem terem sido preenchidos
        ''' </summary>
        ''' <param name="tempo"></param>
        ''' <returns></returns>
        Private Function VerificaTempos(tempo As Integer) As Integer
            If (tempo.Equals("")) Then
                Return 0
            Else
                Return tempo
            End If
        End Function

        Private Sub BloqueiaUtilizadores()
            If String.IsNullOrEmpty((Session("Nome"))) Or Session("Inativo") = 1 Then
                Response.Redirect("~/Logins/Index")
            End If
        End Sub

        ''' <summary>
        ''' usada para verificar se a query normal é enviada para o ticket ou não, devido
        ''' a haver imensos parametros
        ''' </summary>
        ''' <param name="lista"></param>
        ''' <returns></returns>
        Private Function VerificaParams(lista As List(Of String))

            Dim flag As Boolean

            For Each item In lista
                If (String.IsNullOrEmpty(item)) Then
                    flag = True
                Else
                    Return False
                End If
            Next
            Return flag
        End Function
    End Class
End Namespace