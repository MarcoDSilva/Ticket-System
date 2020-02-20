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

<h2>Edição Ticket</h2>

@Using (Html.BeginForm("EditarTicket", "Tickets"))
    @Html.AntiForgeryToken()

    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(ticket) ticket.ID_ticket)
    'form edição
    @<div class="form-inline">
    <div class="row">
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
        <div class="col-sm-4">
            @Html.LabelFor(Function(ticket) ticket.dataAbertura, New With {.class = "form-check-label"})
            <input type="date" name="dataAbertura" value="@dataInicial" id="@Model.dataAbertura" class="form-control" />
            @Html.LabelFor(Function(ticket) ticket.dataFecho, New With {.class = "form-check-label"})
            <input type="date" name="dataFecho" value="@dataFinal" id="dataFecho" class="form-control" />
        </div>

        <div style="float:left;">
            @Html.LabelFor(Function(ticket) ticket.tempoPrevisto, New With {.class = "form-check-label"})
            @Html.TextBoxFor(Function(ticket) ticket.tempoPrevisto, New With {.class = "form-control"})
        </div>
        <div>
            @Html.LabelFor(Function(ticket) ticket.tempoTotal, New With {.class = "form-check-label"})
            @Html.TextBoxFor(Function(ticket) ticket.tempoTotal, New With {.class = "form-control"})
        </div>
        <div class="col-sm-4">
            @Html.LabelFor(Function(ticket) ticket.ID_estado, New With {.class = "form-check-label"})
            @Html.DropDownList("ID_estado", DirectCast(ViewBag.estado, SelectList), New With {.class = "form-control"})
        </div>
        <div class="col-sm-4">
            @Html.LabelFor(Function(ticket) ticket.ID_prioridade, New With {.class = "form-check-label"})
            @Html.DropDownList("ID_prioridade", DirectCast(ViewBag.prioridade, SelectList), New With {.class = "form-control"})
        </div>
        <div class="col-sm-4">
            @Html.LabelFor(Function(ticket) ticket.ID_utilizador, New With {.class = "form-check-label"})
            @Html.DropDownList("ID_utilizador", DirectCast(ViewBag.utilizador, SelectList), New With {.class = "form-control"})
        </div>
        <div class="col-sm-4">
            @Html.LabelFor(Function(ticket) ticket.ID_origem, New With {.class = "form-check-label"})
            @Html.DropDownList("ID_origem", DirectCast(ViewBag.origem, SelectList), New With {.class = "form-control"})
        </div>

        <div id="btnsEditarTickets">
            <input type="submit" class="btn btn-success" value="Guardar" name="Enviar" />
            <button type="button" class="btn btn-primary btn-danger" data-toggle="modal" data-target="#modalApagarRegisto">
                Apagar
            </button>
            <button type="button" class="btn btn-info" onclick="location.href='@Url.Action("CriaTicket", "Tickets")'">
                Novo Ticket
            </button>

            @*linktext,actionName, controllerName,routevalue,htmlAttribute*@
            @*@Html.ActionLink("CriaEvento", "CriaEvento", "Eventos", New With {.ID_ticket = Model.ID_ticket},
                htmlAttributes:=New With {.class = "btn btn-warning", .type = "button", .data_toggle = "modal", .data_target = "#modalNovoEvento"})*@

            <button type="button" class="btn btn-primary btn-warning" data-toggle="modal" data-target="#modalNovoEvento">
                Eventos
            </button>

            <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Tickets")'">
                Voltar
            </button>

        </div>

    </div>
</div>


    'butões com as operações respectivas do formulário de edição
    @<div id="editaTicket">       
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

                    @*<div class="modal-body">
                            <label for="descricao">Descrição:</label>
                            @Html.TextBoxFor(Function(d) d.descricao, Nothing, htmlAttributes:=New With {.placeHolder = "Inserir Descrição", .class = "form-control", .name = "descricao", .id = "descricao"})
                            <Label class="form-check-label" for="ID_tecnico">Técnico:</Label>
                            @Html.DropDownListFor(Function(a) a.ID_tecnico, DirectCast(ViewBag.tecnico, SelectList), "", htmlAttributes:=New With {.class = "form-control", .name = "ID_tecnico"})

                            <Label class="form-check-label" for="dataAbertura">Data Abertura</Label>
                            <input type="date" name="dataAbertura" id="@eventoNovo.dataAbertura" class="form-control" />

                            <Label class="form-check-label" for="dataFecho">Data Fecho</Label>
                            <input type="date" name="dataFecho" id="@eventoNovo.dataFecho" class="form-control" />

                            @Html.ActionLink("Enviar", "CriaEvento", "Eventos", New With {.descricao = "descricao",
                                     .ID_tecnico = Model.ID_tecnico, .dataAbertura = Model.dataAbertura,
                                          .dataFecho = Model.dataFecho, .ID_ticket = ticketID},
                                             htmlAttributes:=New With {.class = "btn btn-primary"})

                            @Html.ActionLink("TestaEvento", "TestaEvento", New With {.descricao_evento = "evento",
                                .ID_tecnicoEvento = "evento", .dataAberturaEvento = Html.Value("dataAberturaEvento"),
                                .dataFechoEvento = Html.Value("dataFechoEvento"), .ID_ticket = ticketID},
                                htmlAttributes:=New With {.class = "btn btn-primary", .type = "submit"})
                        </div>*@
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

End Using


@*<script type="text/javascript">
    var NovoEvento = function() {
        var descricao = document.getElementById('Evento.descricao').value;
        var tecnico = document.getElementById('Evento.tecnico').value;

        var dataAbertura = document.getElementById('Evento.dataAbertura').value;
        var dataFecho =document.getElementById('Evento.dataFecho').value;
        var ticketID = @ticketID;

        console.log(descricao, "e ", tecnico, "e " , dataAbertura, "e ", dataFecho, " e " , ticketID);

        $.ajax({
            type: "POST",
            url: '@Url.Action("TestaJSON", "Tickets")',
            data: {
                descricao : "descricao",
                tecnico: "tecnico",
                dataAbertura: "dataAbertura",
                dataFecho: "dataFecho",
                ID_ticket: "ticketID"
            },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert("Foi inserido " + data.descricao + " com sucesso");
                console.log("sucesso");
            },
            error: function (data) {
                alert("falhou");
                console.log("erro");
            }
        });
    }
    </script>*@


