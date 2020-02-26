Imports System.Globalization
Imports System.Net
Imports System.Web.Mvc

Namespace Controllers
    Public Class EventosController
        Inherits Controller

        'esta instanciação é utilizada para edição sql, apesar de o modelo ser o da view model
        Private ReadOnly conectaBD As New Manipula_TEvento

        ' GET: Eventos
        Function Index() As ActionResult
            BloqueiaUtilizadores()
            Return View(LeituraDados($"SELECT e.ID_evento, e.descricao,t.nome, 
                        e.dataAbertura, e.dataFecho, e.ID_ticket, e.dat_hor 
                        FROM Evento e, Tecnico t
                        WHERE e.ID_tecnico = t.ID_tecnico;"))
        End Function

        'GET: View para criação do evento
        'Neste momento os elementos que vão fazer parte de uma dropbox estão a ser enviados por viewbags
        'ticket é só placeholder, pois irá ser automático
        Function CriaEvento() As ActionResult
            BloqueiaUtilizadores()
            ViewBag.tickets = New SelectList(ListaTickets(), "ID_ticket", "ID_ticket")
            ViewBag.tecnico = New SelectList(conectaBD.ListaTecnicos(), "ID_tecnico", "nome")
            Return View()
        End Function

        ''GET: View que cria o evento, já com o ticket associado de onde foi criado
        'Function CriaEvento(ID_ticket As Integer) As ActionResult
        '    ViewBag.tecnico = New SelectList(conectaBD.ListaTecnicos(), "ID_tecnico", "nome")
        '    Return View()
        'End Function

        'POST: envia a informação que vem da view para a bd
        'Comparamos as datas , e atribuimos ou valor actual ou nulo , para enviar a informação para a bd
        'verificações que vão ficar na view, estão aqui temporariamente, como id_tecnico ou ticket
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function CriaEvento(evento As Evento) As ActionResult
            BloqueiaUtilizadores()
            'se o tecnico ou o ticket estiverem vazio da erro -isto é um placeholder, essa verificação
            'vai ser efectuada na view
            If IsNothing(evento.ID_tecnico) Or IsNothing(evento.ID_ticket) Or String.IsNullOrEmpty(evento.descricao) Then
                Return View()
            Else
                Dim dataAberturaConvertida As String
                Dim dataFechoConvertida As String

                'verificar os valores da dataabertura
                If (String.IsNullOrEmpty(evento.dataAbertura)) Then
                    dataAberturaConvertida = "CURRENT_TIMESTAMP"
                Else
                    dataAberturaConvertida = ConverteDataHora(evento.dataAbertura)
                End If

                'verificar os valores da datafecho
                If IsNothing(evento.dataFecho).Equals(False) Then
                    dataFechoConvertida = ConverteDataHora(evento.dataFecho)
                Else
                    dataFechoConvertida = "null"
                End If

                'adiciona os dados na bd
                conectaBD.AdicionaEvento(evento.descricao, evento.ID_tecnico, dataAberturaConvertida,
                                         dataFechoConvertida, evento.ID_ticket)
            End If

            Return RedirectToAction("Index")
        End Function

        'GET: obter campos para edição dos dados do evento
        Function EditarEvento(ID_evento As Integer) As ActionResult
            BloqueiaUtilizadores()

            Dim viewModel As New VM_TicketEventosHomePage

            viewModel.Evento = LeituraDados($"SELECT e.ID_evento, e.descricao,t.nome, 
                        e.dataAbertura, e.dataFecho, e.ID_ticket, e.dat_hor 
                        FROM Evento e, Tecnico t
                        WHERE e.ID_tecnico = t.ID_tecnico 
                        AND ID_EVENTO = {ID_evento};").ToList()


            viewModel.Ticket = LeituraDadosTicket($"SELECT t.ID_ticket, tec.nome, sft.nome, cli.nome, prob.descricao, t.descricao, 
                                      t.dataAbertura, est.descricao, prio.descricao 

                                      FROM Ticket t,Tecnico tec, Software sft, Cliente cli, 
                                      Problema prob, Estado est, Prioridade prio

                                      WHERE t.ID_tecnico = tec.ID_tecnico
                                          AND sft.ID_software = t.ID_software
                                          AND cli.ID_cliente = t.ID_cliente
                                          AND prob.ID_problema = t.ID_problema
                                          AND est.ID_estado = t.ID_estado
                                          AND prio.ID_prioridade = t.ID_prioridade                                          
                                          AND t.ID_ticket = {viewModel.Evento.First().ID_ticket}").ToList()

            If IsNothing(ID_evento) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadGateway)
            Else
                ViewBag.tecnico = New SelectList(conectaBD.ListaTecnicos(), "ID_tecnico", "nome")

                Return View(viewModel)
            End If
        End Function

        'POST: edita consoante os dados recebidos
        'Antes da edição ser enviada, verificamos as datas enviadas para podermos "limpar" os potenciais
        'erros que podem surgir com as mesmas
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function EditarEvento(evento As Evento) As ActionResult
            BloqueiaUtilizadores()
            If IsNothing(evento.ID_evento) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            Else
                Dim queryEvento = LeituraDados($"SELECT * FROM Evento WHERE ID_evento = {evento.ID_evento}").First()

                Dim dataAberturaConvertida As String
                Dim dataFechoConvertida As String

                'se a data de abertura vier vazia, atribuimos o valor que estava anteriormente
                If (evento.dataAbertura.Equals("")) Then
                    dataAberturaConvertida = queryEvento.dataAbertura.ToString("MM-dd-yyyy")
                Else
                    dataAberturaConvertida = ConverteDataHora(evento.dataAbertura)
                End If

                'se a data de fecho trazer valor, convertemos e enviamos, caso contrário
                'enviamos a string a null, para manipularmos a query para a bd
                If (IsNothing(evento.dataFecho).Equals(False)) Then
                    dataFechoConvertida = ConverteDataHora(evento.dataFecho)
                Else
                    dataFechoConvertida = "null"
                End If

                conectaBD.EditaEvento(evento.ID_evento, evento.descricao, evento.ID_tecnico, dataAberturaConvertida, dataFechoConvertida)

            End If
            Return RedirectToAction("Index")
        End Function

        'Recebe o ID do evento a apagar. Apaga o evento se o encontrar. Redireciona para o index após o mesmo.
        Function ApagarEvento(ID_evento As Integer) As ActionResult
            BloqueiaUtilizadores()
            If IsNothing(ID_evento) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            Else
                conectaBD.ApagaEvento(ID_evento)
            End If
            Return RedirectToAction("Index")
        End Function

        ''' <summary>
        ''' Método interno utilizado para ler dados da bd
        ''' </summary>
        ''' <param name="query"></param>
        ''' <returns></returns>
        Private Function LeituraDados(query As String) As List(Of VM_EventoTecnico)

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

        ''' <summary>
        ''' Método para converter o datetime, adicionar horas/mins/segs e retornar a string já preparada
        ''' para ser adicionada na base de dados (formato MM-dd-yyyy H:mm:ss)
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        Private Function ConverteDataHora(data As DateTime) As String
            Dim tempoAConverter = data.AddHours(DateTime.Now.Hour).
                           AddSeconds(DateTime.Now.Second).AddMinutes(DateTime.Now.Minute)

            Return DateTime.Parse(tempoAConverter).ToString("MM-dd-yyyy H:mm:ss")

        End Function

        'listagem temporaria para preview de tickets
        'vai ser removida quando o ticket for automatico
        Private Function ListaTickets() As List(Of Ticket)
            Dim leituraTickets = conectaBD.LeituraTabela("SELECT ID_ticket FROM Ticket").AsEnumerable
            Dim lista As New List(Of Ticket)

            For Each ticket In leituraTickets
                Dim novo As New Ticket
                novo.ID_ticket = ticket(0)
                lista.Add(novo)
            Next

            Return lista
        End Function

        Private Sub BloqueiaUtilizadores()
            If String.IsNullOrEmpty((Session("Nome"))) Or Session("Inativo") = 1 Then
                Response.Redirect("~/Logins/Index")
            End If
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
                Dim tick As New VM_Ticket With {
                    .ID_ticket = item(0),
                    .ID_tecnico = item(1),
                    .ID_software = item(2),
                    .ID_cliente = item(3),
                    .ID_problema = item(4),
                    .descricao = item(5),
                    .dataAbertura = item(6),
                    .ID_estado = item(7),
                    .ID_prioridade = item(8)
                }
                listagemTickets.Add(tick)
            Next

            Return listagemTickets
        End Function

    End Class
End Namespace