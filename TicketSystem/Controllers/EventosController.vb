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
        Function CriaEvento() As ActionResult
            Dim leituraTecnicos = conectaBD.LeituraTabela("SELECT * FROM Tecnico").AsEnumerable
            Dim listaTecnicos As New List(Of Tecnico)
            For Each tec In leituraTecnicos
                Dim novo As New Tecnico
                novo.ID_tecnico = tec(0)
                novo.nome = tec(1)
                listaTecnicos.Add(novo)
            Next


            ViewBag.tecnico = New SelectList(listaTecnicos, "ID_tecnico", "nome")
            Return View()
        End Function

        'POST: envia a informação que vem da view para a bd
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function CriaEvento(descricao As String, ID_tecnico As Integer, dataAbertura As DateTime,
                            dataFecho As DateTime, ID_ticket As Integer) As ActionResult

            If IsNothing(ID_tecnico) Or IsNothing(ID_ticket) Then

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

    End Class
End Namespace