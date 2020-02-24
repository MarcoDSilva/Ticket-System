Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private conectaBD As New ObterDados

    'GET:
    Function Index() As ActionResult

        If String.IsNullOrEmpty((Session("Nome"))) Then
            Response.Redirect("~/Logins/Index")
        End If

        CriaViewBags()
        Dim viewModel As New VM_TicketEventosHomePage With {
            .Evento = LeituraDadosEvento($"SELECT * FROM evento e WHERE e.dataFecho IS NULL
                                                            AND e.ID_tecnico = {Session("ID_tecnico")}").ToList(),
            .Ticket = LeituraDadosTicket($"SELECT * FROM Ticket t WHERE t.ID_estado = 2 ").ToList()
        }

        Return View(viewModel)
    End Function

    ''' <summary>
    ''' ViewBags com as queries necessárias para as estatisticas na homepage de apresentação ao utilizador
    ''' </summary>
    Public Sub CriaViewBags()
        'As viewbags recebem o resultado da query, que é convertida num enumerable e depois chamado a primeira célula, do primeiro resultado do mesmo
        ViewBag.totalTickets = conectaBD.LeituraTabela("SELECT COUNT(*) FROM Ticket;").AsEnumerable().First().Item(0)

        ViewBag.ticketsConcluidos = conectaBD.LeituraTabela("SELECT COUNT(*) FROM Ticket t 
                                                            WHERE t.ID_estado = 6;").AsEnumerable().First().Item(0)

        ViewBag.ticketsNovos = conectaBD.LeituraTabela("SELECT COUNT(*) FROM Ticket t 
                                                            WHERE t.ID_estado = 2").AsEnumerable().First().Item(0)

        ViewBag.ticketsNaoConcluidos = conectaBD.LeituraTabela("SELECT COUNT(*) FROM Ticket t 
                                                            WHERE t.ID_estado <> 6").AsEnumerable().First().Item(0)

        ViewBag.ticketsAnoActual = conectaBD.LeituraTabela($"SELECT COUNT(*) FROM Ticket t 
                                                            WHERE Year(t.dataAbertura) = '{DateTime.Now.Year.ToString()}';").
                                                            AsEnumerable().First().Item(0)

        ViewBag.ticketsMesActual = conectaBD.LeituraTabela($"SELECT COUNT(*) FROM Ticket t 
                                                            WHERE Year(t.dataAbertura) = '{DateTime.Now.Month.ToString()}';").
                                                            AsEnumerable().First().Item(0)

        ViewBag.eventosAtribuidos = conectaBD.LeituraTabela($"SELECT COUNT(*) FROM 
                                                            evento e WHERE e.dataFecho IS NULL
                                                            AND e.ID_tecnico = {Session("ID_tecnico")}").AsEnumerable().First().Item(0)
    End Sub

    ''' <summary>
    ''' Método interno utilizado para ler dados da bd
    ''' </summary>
    ''' <param name="query"></param>
    ''' <returns></returns>
    Private Function LeituraDadosTicket(query As String) As List(Of VM_Ticket)

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
    ''' Método interno utilizado para ler dados da bd
    ''' </summary>
    ''' <param name="query"></param>
    ''' <returns></returns>
    Private Function LeituraDadosEvento(query As String) As List(Of VM_EventoTecnico)

        Dim tabelaDados As DataTable = conectaBD.LeituraTabela(query)
        Dim listagemEventos As New List(Of VM_EventoTecnico)

        'fazemos um ciclo, que vai iterar por cada elemento que recebenos da base de dados
        'criamos um novo objecto do tipo Evento, onde atribuimos os dados da iteração actual
        'e no fim após a atribuição desses dados, inserimos numa List(a) de Eventos, o qual usamos para retornar os dados
        For Each item In tabelaDados.AsEnumerable
            Dim ev As New VM_EventoTecnico()

            ev.ID_evento = item(0)
            ev.descricao = item(1)
            ev.ID_tecnico = item(2)
            ev.dataAbertura = item(3)

            If item(4).Equals(DBNull.Value) Then
                ev.dataFecho = Nothing
            Else
                ev.dataFecho = item(4)
            End If

            ev.ID_ticket = item(5)
            ev.dat_hor = item(6)

            listagemEventos.Add(ev)
        Next

        Return listagemEventos
    End Function

End Class
