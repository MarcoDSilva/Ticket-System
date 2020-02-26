@ModelType TicketSystem.VM_TicketEventosHomePage
@Code
    ViewData("Title") = "Edição de Ticket"

    Dim eventoNovo As New Evento

    Dim dataFinal As String
    Dim dataInicial = Model.Ticket.First.dataAbertura.ToString("yyyy-MM-dd")
    Dim ticketID = Model.Ticket.First.ID_ticket

    If IsNothing(Model.Ticket.First.dataFecho) Then
        dataFinal = ""
    Else
        dataFinal = Model.Ticket.First.dataFecho.Value.ToString("yyyy-MM-dd")
    End If
End Code

@Using (Html.BeginForm("EditarTicket", "Tickets"))
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(ticket) ticket.Ticket.First.ID_ticket)
    'form edição

    @<div class="container container-fluid">
         <div class="row" style="padding:10px;">
             <div class="col">
                 <h4 class="font-italic font-weight-bold">Ticket</h4>
             </div>
             <div class="col">
                 <h4 class="text-center font-italic font-weight-bold">Edição</h4>
             </div>
         </div>

       <!-- div de organização, row para conter os elementos, as que são col é para podermos dividir o ratio na página-->
        <div class="row">
            <div class="col">
                <section>
                    <!--"on click" menu strip, para poder mostrar os restantes campos do formulário  -->
                    <ul class="nav nav-tabs" id="myTab" role="tablist">
                        <li class="nav-item">
                            <a class="nav-link active btn" id="detalhes-tab" data-toggle="tab" href="#detalhes" role="tab" aria-controls="detalhes" aria-selected="true">Detalhes do ticket</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="profile-tab" data-toggle="tab" href="#datas" role="tab" aria-controls="datas" aria-selected="false">Datas e Tempos</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="contact-tab" data-toggle="tab" href="#contact" role="tab" aria-controls="contact" aria-selected="false">misc.</a>
                        </li>
                    </ul>
                </section>

                <!-- os varios campos do formulário -->
                <div class="tab-content" id="myTabContent">
                    <section class="tab-pane fade show active" id="detalhes" role="tabpanel" aria-labelledby="detalhes-tab">
                        <div>
                            @Html.LabelFor(Function(ticket) ticket.Ticket.First.ID_software, New With {.class = "form-check-label"})
                            @Html.DropDownList("ID_software", DirectCast(ViewBag.software, SelectList), New With {.class = "form-control"})
                        </div>
                        <div>
                            @Html.LabelFor(Function(ticket) ticket.Ticket.First.ID_cliente, New With {.class = "form-check-label"})
                            @Html.DropDownList("ID_cliente", DirectCast(ViewBag.cliente, SelectList), New With {.class = "form-control"})
                        </div>
                        <div>
                            @Html.LabelFor(Function(ticket) ticket.Ticket.First.ID_problema, New With {.class = "form-check-label"})
                            @Html.DropDownList("ID_problema", DirectCast(ViewBag.problema, SelectList), New With {.class = "form-control"})
                        </div>
                        <div>
                            @Html.LabelFor(Function(ticket) ticket.Ticket.First.descricao, New With {.class = "form-check-label"})
                            @Html.TextAreaFor(Function(ticket) ticket.Ticket.First.descricao, 10, 100, New With {.class = "form-control descricaoTicket"})
                        </div>
                    </section>

                    <section class="tab-pane fade" id="datas" role="tabpanel" aria-labelledby="datas-tab">
                        <div>
                            @Html.LabelFor(Function(ticket) ticket.Ticket.First.dataAbertura, New With {.class = "form-check-label"})
                            <input type="date" name="dataAbertura" value="@dataInicial" id="@Model.Ticket.First.dataAbertura" class="form-control" />
                            @Html.LabelFor(Function(ticket) ticket.Ticket.First.dataFecho, New With {.class = "form-check-label"})
                            <input type="date" name="dataFecho" value="@dataFinal" id="dataFecho" class="form-control" />
                        </div>

                        <div>
                            @Html.LabelFor(Function(ticket) ticket.Ticket.First.tempoPrevisto, New With {.class = "form-check-label"})
                            @Html.TextBoxFor(Function(ticket) ticket.Ticket.First.tempoPrevisto, New With {.class = "form-control"})
                        </div>
                        <div>
                            @Html.LabelFor(Function(ticket) ticket.Ticket.First.tempoTotal, New With {.class = "form-check-label"})
                            @Html.TextBoxFor(Function(ticket) ticket.Ticket.First.tempoTotal, New With {.class = "form-control"})
                        </div>
                    </section>

                    <section class="tab-pane fade " id="contact" role="tabpanel" aria-labelledby="contact-tab">
                        <div>
                            @Html.LabelFor(Function(ticket) ticket.Ticket.First.ID_estado, New With {.class = "form-check-label"})
                            @Html.DropDownList("ID_estado", DirectCast(ViewBag.estado, SelectList), New With {.class = "form-control"})
                        </div>
                        <div>
                            @Html.LabelFor(Function(ticket) ticket.Ticket.First.ID_prioridade, New With {.class = "form-check-label"})
                            @Html.DropDownList("ID_prioridade", DirectCast(ViewBag.prioridade, SelectList), New With {.class = "form-control"})
                        </div>

                        <div>
                            @Html.LabelFor(Function(ticket) ticket.Ticket.First.ID_origem, New With {.class = "form-check-label"})
                            @Html.DropDownList("ID_origem", DirectCast(ViewBag.origem, SelectList), New With {.class = "form-control"})
                        </div>
                    </section>
                </div>
            </div>

            <!-- botões que efetuam as operações crud-->
            <div id="btnsEditarTickets" class="col">
                <ul class="listaBtns">
                    <li>
                        <input type="submit" class="btn btn-success btn-sm" value="Guardar" name="Enviar" />
                    </li>
                    <li>
                        <button type="button" class="btn btn-primary btn-danger btn-sm" data-toggle="modal" data-target="#modalApagarRegisto">
                            Apagar
                        </button>
                    </li>
                    <li>
                        <button type="button" class="btn btn-info btn-sm" onclick="location.href='@Url.Action("CriaTicket", "Tickets")'">
                            Novo Ticket
                        </button>
                    </li>
                    <li>
                        <button type="button" class="btn btn-primary btn-warning btn-sm" data-toggle="modal" data-target="#modalNovoEvento">
                            Eventos
                        </button>
                    </li>
                    <li>
                        <button type="button" class="btn btn-secondary btn-sm" onclick="location.href='@Url.Action("Index", "Tickets")'">
                            Voltar
                        </button>
                    </li>
                </ul>
            </div>
        </div>

        <!--eventos atribuidos-->
        <div class="row">
            <div id="ticketsIndex" class="col">
                <h4 class="font-italic font-weight-bold">Eventos associados.</h4>
                <table class="table table-striped table-hover table-sm table-responsive">
                    <tr class="thead-dark">
                        <th>@Html.LabelFor(Function(model) model.Evento.First.ID_evento)</th>
                        <th> @Html.LabelFor(Function(model) model.Evento.First.ID_tecnico)</th>
                        <th> @Html.LabelFor(Function(model) model.Evento.First.descricao)</th>
                        <th> @Html.LabelFor(Function(model) model.Evento.First.ID_ticket)</th>
                        <th> @Html.LabelFor(Function(model) model.Evento.First.dataAbertura)</th>
                    </tr>
                    @For Each evento In Model.Evento
                        @<tr onclick="location.href='@Url.Action("EditarEvento", "Eventos", New With {.ID_evento = evento.ID_evento})'" class="clickableCell">
                            <td>@Html.DisplayFor(Function(model) evento.ID_evento)</td>
                            <td>@Html.DisplayFor(Function(model) evento.ID_tecnico)</td>
                            <td>@Html.DisplayFor(Function(model) evento.descricao)</td>
                            <td>@Html.DisplayFor(Function(model) evento.ID_ticket)</td>
                            <td>@Html.DisplayFor(Function(model) evento.dataAbertura)</td>
                        </tr>
                    Next
                    <caption>Eventos correspondentes ao ticket</caption>
                </table>
            </div>
        </div>
    </div>

    'butões com as operações respectivas do formulário de edição
    @<section id="editaTicket">
        <!-- Modal para apagar registo -->
        <div class="modal fade" id="modalApagarRegisto" tabindex="-1" role="dialog" aria-labelledby="modalApagar" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="modalApagar">Confirmação</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">Pretende mesmo apagar este problema? Esta operação não é reversivel!</div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal"
                                onclick="location.href ='@Url.Action("ApagarTicket", "Tickets", New With {.ID_ticket = ticketID})'">
                            Apagar
                        </button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal para novo Evento -->
        <div class="modal fade" id="modalNovoEvento" tabindex="-1" role="dialog" aria-labelledby="modalNovoEvento" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="modalEvento">Novo Evento</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>

                    <iframe class="modalbody" src="@Url.Action("CriaEvento", "Eventos", New With {.ID_ticket = ticketID})"
                            style="width:500px;height:500px;"></iframe>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                    </div>
                </div>
            </div>
        </div>
    </section>

End Using


