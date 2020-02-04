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

        'GET:
        Function CriaTicket() As ActionResult
            Return View()
        End Function

        'POST:
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function CriaTicket(ticketParams As Ticket) As ActionResult

            Return View()
        End Function

        'GET:
        Function EditarTicket(ID_ticket As Integer) As ActionResult
            Return View()

        End Function

        'POST:
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function EditarTicket(ticketParams As Ticket) As ActionResult
            Return View()

        End Function

        'POST
        Function ApagarTicket(ID_ticket As Integer) As ActionResult
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
    End Class
End Namespace