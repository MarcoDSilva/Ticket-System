Imports System.Net
Imports System.Web.Mvc

Namespace Controllers
    Public Class TicketsController
        Inherits Controller

        Dim conectaBD As New Manipula_TTicket

        ' GET: Tickets
        Function Index() As ActionResult

            Return View(LeituraDados("SELECT t.ID_ticket, tec.nome, sft.nome, cli.nome, prob.descricao, t.descricao, 
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
                                          AND ori.ID_origem = t.ID_origem
                                    "))
        End Function

        'GET: Cria a view para criação de tickets. A mesma contém várias dropdownlists que estão a ser alimentadas por viewbags
        Function CriaTicket() As ActionResult
            ViewBag.tecnico = New SelectList(conectaBD.ListaTecnicos(), "ID_tecnico", "nome")
            ViewBag.software = New SelectList(conectaBD.ListaSoftwares(), "ID_software", "nome")
            ViewBag.cliente = New SelectList(conectaBD.ListaClientes(), "ID_cliente", "nome")
            ViewBag.problema = New SelectList(conectaBD.ListaProblemas(), "ID_problema", "descricao")
            ViewBag.estado = New SelectList(conectaBD.ListaEstados(), "ID_estado", "descricao")
            ViewBag.prioridade = New SelectList(conectaBD.ListaPrioridades(), "ID_prioridade", "descricao")
            ViewBag.utilizador = New SelectList(conectaBD.ListaUtilizadores(), "ID_utilizador", "nome")
            ViewBag.origem = New SelectList(conectaBD.ListaOrigens(), "ID_origem", "descricao")
            Return View()
        End Function

        'POST:
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function CriaTicket(ticketParams As Ticket) As ActionResult

            Dim dataAberturaConvertida As String
            Dim dataFechoConvertida As String

            'verificar os tempos
            If (ticketParams.tempoPrevisto.Equals("")) Then
                ticketParams.tempoPrevisto = 0
            End If

            If (ticketParams.tempoTotal.Equals("")) Then
                ticketParams.tempoTotal = 0
            End If

            'verificar os valores da dataabertura
            If (IsNothing(ticketParams.dataAbertura)) Then
                dataAberturaConvertida = "CURRENT_TIMESTAMP"
            Else
                dataAberturaConvertida = ConverteDataHora(ticketParams.dataAbertura)
            End If

            'verificar os valores da datafecho
            If IsNothing(ticketParams.dataFecho).Equals(False) Then
                dataFechoConvertida = ""
            Else
                dataFechoConvertida = ConverteDataHora(ticketParams.dataFecho.Value)
            End If

            'verificar utilizador
            If IsNothing(ticketParams.ID_utilizador) Then
                ticketParams.ID_utilizador = Nothing
            End If

            conectaBD.CriaTicket(ticketParams.ID_tecnico, ticketParams.ID_software, ticketParams.ID_cliente, ticketParams.ID_problema,
                                  ticketParams.descricao, dataAberturaConvertida, dataFechoConvertida, ticketParams.tempoPrevisto,
                                    ticketParams.tempoTotal, ticketParams.ID_estado, ticketParams.ID_prioridade, ticketParams.ID_utilizador, ticketParams.ID_origem)

            Return RedirectToAction("Index")
        End Function

        'GET: Recebe a informação do ticket para o mesmo ser editado
        Function EditarTicket(ID_ticket As Integer) As ActionResult
            Return View()

        End Function

        'POST: utiliza a informação recebida do ticket, e actualiza a bd com os mesmos
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function EditarTicket(ticketParams As Ticket) As ActionResult
            Return View()

        End Function

        'POST - Apagar o ticket 
        Function ApagarTicket(ID_ticket As Integer) As ActionResult
            If IsNothing(ID_ticket) Then
                Return New HttpStatusCodeResult(HttpStatusCode.Forbidden)
            Else
                conectaBD.ApagaTicket(ID_ticket)
            End If
            Return View()

        End Function

        ''' <summary>
        ''' Método interno utilizado para ler dados da bd
        ''' </summary>
        ''' <param name="query"></param>
        ''' <returns></returns>
        Function LeituraDados(query As String) As List(Of VM_Ticket)

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

    End Class
End Namespace