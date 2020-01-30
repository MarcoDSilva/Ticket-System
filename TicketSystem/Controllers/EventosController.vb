Imports System.Globalization
Imports System.Net
Imports System.Web.Mvc

Namespace Controllers
    Public Class EventosController
        Inherits Controller

        'esta instanciação é utilizada para edição sql, apesar de o modelo ser o da view model
        Private ReadOnly conectaBD As New Manipula_TEvento

        'O EDITAR PODE SER PRECISO A TABELA EVENTO NORMAL(?)

        ' GET: Eventos
        Function Index() As ActionResult
            Return View(LeituraDados($"SELECT e.ID_evento, e.descricao,t.nome, 
                        e.dataAbertura, e.dataFecho, e.ID_ticket, e.dat_hor 
                        FROM Evento e, Tecnico t
                        WHERE e.ID_tecnico = t.ID_tecnico;"))
        End Function

        'GET: View para criação do evento
        'Neste momento os elementos que vão fazer parte de uma dropbox estão a ser enviados por ticket
        'ticket é só placeholder, pois não faz sentido ser escolhida, mais vale ser automatica
        Function CriaEvento() As ActionResult
            ViewBag.tickets = New SelectList(ListaTickets(), "ID_ticket", "ID_ticket")
            ViewBag.tecnico = New SelectList(ListaFuncionarios(), "ID_tecnico", "nome")
            Return View()
        End Function

        'POST: envia a informação que vem da view para a bd
        'o ticket pode ser automatico , vindo do ID do ticket principal do qual o mesmo surgiu
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function CriaEvento(descricao As String, ID_tecnico As Integer,
                            dataFecho As String, ID_ticket As Integer) As ActionResult

            If IsNothing(ID_tecnico) Or IsNothing(ID_ticket) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            Else
                If IsNothing(dataFecho) Then
                    conectaBD.AdicionaEvento(descricao, ID_tecnico, "CURRENT_TIMESTAMP", ID_ticket)
                Else

                    'converter a string para tipo data, parse para o tipo datetime, e cultura nula
                    'depois voltamos a converter a data para o formato em que a mesma está a sair da view
                    Dim novaData As DateTime = DateTime.ParseExact(dataFecho, "yyyy-MM-dd", Nothing)
                    conectaBD.AdicionaEvento(descricao, ID_tecnico, novaData.ToString("MM-dd-yyyy"), ID_ticket)
                End If
                Return RedirectToAction("Index")
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
            'criamos um novo objecto do tipo Tecnico, onde atribuimos os dados da iteração actual
            'e no fim após a atribuição desses dados, inserimos numa List(a) de Tecnicos, o qual usamos para retornar os dados
            For Each item In tabelaDados.AsEnumerable
                Dim ev As New VM_EventoTecnico()

                ev.ID_evento = item(0)
                ev.descricao = item(1)
                ev.ID_tecnico = item(2)
                ev.dataAbertura = item(3)
                ev.dataFecho = item(4)
                ev.ID_ticket = item(5)
                ev.dat_hor = item(6)

                listagemEventos.Add(ev)
            Next

            Return listagemEventos
        End Function

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