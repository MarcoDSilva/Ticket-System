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
            Return View(LeituraDados($"SELECT e.ID_evento, e.descricao,t.nome, 
                        e.dataAbertura, e.dataFecho, e.ID_ticket, e.dat_hor 
                        FROM Evento e, Tecnico t
                        WHERE e.ID_tecnico = t.ID_tecnico;"))
        End Function

        'GET: View para criação do evento
        'Neste momento os elementos que vão fazer parte de uma dropbox estão a ser enviados por viewbags
        'ticket é só placeholder, pois irá ser automático
        Function CriaEvento() As ActionResult
            ViewBag.tickets = New SelectList(ListaTickets(), "ID_ticket", "ID_ticket")
            ViewBag.tecnico = New SelectList(ListaFuncionarios(), "ID_tecnico", "nome")
            Return View()
        End Function

        'POST: envia a informação que vem da view para a bd
        'Comparamos as datas , e atribuimos ou valor actual ou nulo , para enviar a informação para a bd
        'verificações que vão ficar na view, estão aqui temporariamente, como id_tecnico ou ticket
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function CriaEvento(descricao As String, ID_tecnico As Integer, dataAbertura As String,
                            dataFecho As String, ID_ticket As Integer) As ActionResult

            'se o tecnico ou o ticket estiverem vazio da erro -isto é um placeholder, essa verificação
            'vai ser efectuada na view
            If IsNothing(ID_tecnico) Or IsNothing(ID_ticket) Or String.IsNullOrEmpty(descricao) Then

            Else
                Dim dataAberturaConvertida As String
                Dim dataFechoConvertida As String

                'verificar os valores da dataabertura
                If (String.IsNullOrEmpty(dataAbertura)) Then
                    dataAberturaConvertida = "CURRENT_TIMESTAMP"
                Else
                    dataAberturaConvertida = DateTime.ParseExact(dataAbertura, "yyyy-MM-dd", Nothing).ToString("MM-dd-yyyy")
                End If

                'verificar os valores da datafecho
                If (String.IsNullOrEmpty(dataFecho).Equals(False)) Then
                    dataFechoConvertida = DateTime.ParseExact(dataFecho, "yyyy-MM-dd", Nothing).ToString("MM-dd-yyyy")
                Else
                    dataFechoConvertida = ""
                End If

                'adiciona os dados na bd
                conectaBD.AdicionaEvento(descricao, ID_tecnico, dataAberturaConvertida,
                                         dataFechoConvertida, ID_ticket)
            End If

            Return RedirectToAction("Index")
        End Function

        'GET: obter campos para edição dos dados do evento
        Function EditarEvento(ID_evento As Integer) As ActionResult
            If IsNothing(ID_evento) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadGateway)
            Else
                ViewBag.tecnico = New SelectList(ListaFuncionarios(), "ID_tecnico", "nome")

                Return View(LeituraDados($"SELECT e.ID_evento, e.descricao,t.nome, 
                        e.dataAbertura, e.dataFecho, e.ID_ticket, e.dat_hor 
                        FROM Evento e, Tecnico t
                        WHERE e.ID_tecnico = t.ID_tecnico 
                        AND ID_EVENTO = {ID_evento};").First())
            End If
        End Function

        'POST: edita consoante os dados recebidos
        'Antes da edição ser enviada, verificamos as datas enviadas para podermos "limpar" os potenciais
        'erros que podem surgir com as mesmas
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function EditarEvento(ID_evento As Integer, descricao As String, ID_tecnico As Integer, dataAbertura As String,
                              dataFecho As String) As ActionResult

            If IsNothing(ID_evento) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            Else
                Dim evento = LeituraDados($"SELECT * FROM Evento WHERE ID_evento = {ID_evento}").First()

                If evento.ID_evento.Equals(ID_evento) Then
                    Dim dataAberturaConvertida As String
                    Dim dataFechoConvertida As String

                    'se a data de abertura vier vazia, atribuimos o valor que estava anteriormente
                    If (dataAbertura.Equals("")) Then
                        dataAberturaConvertida = evento.dataAbertura.ToString("MM-dd-yyyy")
                    Else
                        dataAberturaConvertida = DateTime.ParseExact(dataAbertura, "yyyy-MM-dd", Nothing).ToString("MM-dd-yyyy")
                    End If

                    'se a data de fecho trazer valor, convertemos e enviamos, caso contrário
                    'enviamos a string a null, para manipularmos a query para a bd
                    If (String.IsNullOrEmpty(dataFecho).Equals(False)) Then
                        dataFechoConvertida = DateTime.ParseExact(dataFecho, "yyyy-MM-dd", Nothing).ToString("MM-dd-yyyy")
                    Else
                        dataFechoConvertida = "NULL"
                    End If

                    conectaBD.EditaEvento(ID_evento, descricao, ID_tecnico, dataAberturaConvertida, dataFechoConvertida)
                End If

            End If
            Return RedirectToAction("Index")
        End Function

        'Recebe o ID do evento a apagar. Apaga o evento se o encontrar. Redireciona para o index após o mesmo.
        Function ApagarEvento(ID_evento As Integer) As ActionResult
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
        Function LeituraDados(query As String) As List(Of VM_EventoTecnico)

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

        'listagem de funcionários para a dropbox
        Function ListaFuncionarios() As List(Of Tecnico)
            Dim leituraTecnicos = conectaBD.LeituraTabela("SELECT * FROM Tecnico").AsEnumerable
            Dim listaTecnicos As New List(Of Tecnico)

            For Each tec In leituraTecnicos
                Dim novo As New Tecnico
                novo.ID_tecnico = tec(0)
                novo.nome = tec(1)
                listaTecnicos.Add(novo)
            Next

            Return listaTecnicos
        End Function

        'listagem temporaria para preview de tickets
        'vai ser removida quando o ticket for automatico
        Function ListaTickets() As List(Of Ticket)
            Dim leituraTickets = conectaBD.LeituraTabela("SELECT * FROM Ticket").AsEnumerable
            Dim lista As New List(Of Ticket)

            For Each ticket In leituraTickets
                Dim novo As New Ticket
                novo.ID_ticket = ticket(0)
                lista.Add(novo)
            Next

            Return lista
        End Function

    End Class
End Namespace