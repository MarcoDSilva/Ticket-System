@ModelType TicketSystem.VM_Ticket
@Code
    ViewData("Title") = "Edição de Ticket"

    Dim eventoNovo As New Evento

    Dim dataFinal As String
    Dim dataInicial = Model.dataAbertura.ToString("yyyy-MM-dd")
    Dim ticketID = Model.ID_ticket

    If IsNothing(Model.dataFecho) Then
        dataFinal = ""
    Else
        dataFinal = Model.dataFecho.Value.ToString("yyyy-MM-dd")
    End If
End Code

@Using (Html.BeginForm("EditarTicket", "Tickets"))
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(ticket) ticket.ID_ticket)
    'form edição

    @<div class="container">
            <h2>Edição Ticket</h2>
            <div>
                <section>
                    <ul class="nav nav-tabs col-sm-12" id="myTab" role="tablist">
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

                <div class="tab-content" id="myTabContent">
                    <div class="tab-pane fade show active" id="detalhes" role="tabpanel" aria-labelledby="detalhes-tab">
                        <div class="col-sm-4">
                            @Html.LabelFor(Function(ticket) ticket.ID_software, New With {.class = "form-check-label"})
                            @Html.DropDownList("ID_software", DirectCast(ViewBag.software, SelectList), New With {.class = "form-control"})
                        </div>
                        <div class="col-sm-4">
                            @Html.LabelFor(Function(ticket) ticket.ID_cliente, New With {.class = "form-check-label"})
                            @Html.DropDownList("ID_cliente", DirectCast(ViewBag.cliente, SelectList), New With {.class = "form-control"})
                        </div>
                        <div class="col-sm-4">
                            @Html.LabelFor(Function(ticket) ticket.ID_problema, New With {.class = "form-check-label"})
                            @Html.DropDownList("ID_problema", DirectCast(ViewBag.problema, SelectList), New With {.class = "form-control"})
                        </div>
                        <div class="col-sm-8">
                            @Html.LabelFor(Function(ticket) ticket.descricao, New With {.class = "form-check-label"})
                            @Html.TextAreaFor(Function(ticket) ticket.descricao, 10, 100, New With {.class = "form-control descricaoTicket"})
                        </div>
                    </div>

                    <section class="tab-pane fade" id="datas" role="tabpanel" aria-labelledby="datas-tab">
                        <div class="col-sm-4">
                            @Html.LabelFor(Function(ticket) ticket.dataAbertura, New With {.class = "form-check-label"})
                            <input type="date" name="dataAbertura" value="@dataInicial" id="@Model.dataAbertura" class="form-control" />
                            @Html.LabelFor(Function(ticket) ticket.dataFecho, New With {.class = "form-check-label"})
                            <input type="date" name="dataFecho" value="@dataFinal" id="dataFecho" class="form-control" />
                        </div>

                        <div class="col-sm-4">
                            @Html.LabelFor(Function(ticket) ticket.tempoPrevisto, New With {.class = "form-check-label"})
                            @Html.TextBoxFor(Function(ticket) ticket.tempoPrevisto, New With {.class = "form-control"})
                        </div>
                        <div class="col-sm-4">
                            @Html.LabelFor(Function(ticket) ticket.tempoTotal, New With {.class = "form-check-label"})
                            @Html.TextBoxFor(Function(ticket) ticket.tempoTotal, New With {.class = "form-control"})
                        </div>
                    </section>
                    <section class="tab-pane fade" id="contact" role="tabpanel" aria-labelledby="contact-tab">

                        <div class="col-sm-4">
                            @Html.LabelFor(Function(ticket) ticket.ID_estado, New With {.class = "form-check-label"})
                            @Html.DropDownList("ID_estado", DirectCast(ViewBag.estado, SelectList), New With {.class = "form-control"})
                        </div>
                        <div class="col-sm-4">
                            @Html.LabelFor(Function(ticket) ticket.ID_prioridade, New With {.class = "form-check-label"})
                            @Html.DropDownList("ID_prioridade", DirectCast(ViewBag.prioridade, SelectList), New With {.class = "form-control"})
                        </div>

                        <div class="col-sm-4">
                            @Html.LabelFor(Function(ticket) ticket.ID_origem, New With {.class = "form-check-label"})
                            @Html.DropDownList("ID_origem", DirectCast(ViewBag.origem, SelectList), New With {.class = "form-control"})
                        </div>
                    </section>
                </div>
            </div>

            <div id="btnsEditarTickets">
                <h3>Edição:</h3>

                <section class="btnEditarTicket">
                    <input type="submit" class="btn btn-success" value="Guardar" name="Enviar" />
                </section>

                <section class="btnEditarTicket">
                    <button type="button" class="btn btn-primary btn-danger" data-toggle="modal" data-target="#modalApagarRegisto">
                        Apagar
                    </button>
                </section>

                <section class="btnEditarTicket">
                    <button type="button" class="btn btn-info" onclick="location.href='@Url.Action("CriaTicket", "Tickets")'">
                        Novo Ticket
                    </button>
                </section>

                <section class="btnEditarTicket">
                    <button type="button" class="btn btn-primary btn-warning" data-toggle="modal" data-target="#modalNovoEvento">
                        Eventos
                    </button>

                </section>

                <section class="btnEditarTicket">
                    <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Tickets")'">
                        Voltar
                    </button>
                </section>
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
                                onclick="location.href ='@Url.Action("ApagarTicket", "Tickets", New With {.ID_ticket = Model.ID_ticket})'">
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


