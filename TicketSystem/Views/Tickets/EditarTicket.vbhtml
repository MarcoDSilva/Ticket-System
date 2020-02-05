@ModelType TicketSystem.VM_Ticket
@Code
    ViewData("Title") = "EditarTicket"

    Dim dataFinal As String
    Dim dataInicial = Model.dataAbertura.ToString("yyyy-MM-dd")

    If IsNothing(Model.dataFecho) Then
        dataFinal = ""
    Else
        dataFinal = Model.dataFecho.Value.ToString("yyyy-MM-dd")
    End If
End Code

<h2>Edição Ticket</h2>

<div class="form-group">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken

        @<div class="col-form-label">
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @Html.HiddenFor(Function(ticket) ticket.ID_ticket)

            <!-- form edição -->
            <div class="form-group">
                <div class="col-md-12">
                    <p>
                        @Html.LabelFor(Function(ticket) ticket.ID_tecnico, New With {.class = "form-check-label"})
                        @Html.DropDownList("ID_tecnico", DirectCast(ViewBag.tecnico, SelectList), New With {.class = "form-control"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(ticket) ticket.ID_software, New With {.class = "form-check-label"})
                        @Html.DropDownList("ID_software", DirectCast(ViewBag.software, SelectList), New With {.class = "form-control"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(ticket) ticket.ID_cliente, New With {.class = "form-check-label"})
                        @Html.DropDownList("ID_cliente", DirectCast(ViewBag.cliente, SelectList), New With {.class = "form-control"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(ticket) ticket.ID_problema, New With {.class = "form-check-label"})
                        @Html.DropDownList("ID_problema", DirectCast(ViewBag.problema, SelectList), New With {.class = "form-control"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(ticket) ticket.descricao, New With {.class = "form-check-label"})
                        @Html.TextAreaFor(Function(ticket) ticket.descricao, New With {.class = "form-control"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(ticket) ticket.dataAbertura, New With {.class = "form-check-label"})
                        <input type="date" name="dataAbertura" value="@dataInicial" id="dataAbertura" class="form-control" />
                    </p>
                    <p>
                        @Html.LabelFor(Function(ticket) ticket.dataFecho, New With {.class = "form-check-label"})
                        <input type="date" name="dataFecho" value="@dataFinal" id="dataFecho" class="form-control" />
                    </p>
                    <p>
                        @Html.LabelFor(Function(ticket) ticket.tempoPrevisto, New With {.class = "form-check-label"})
                        @Html.TextBoxFor(Function(ticket) ticket.tempoPrevisto, New With {.class = "form-control"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(ticket) ticket.tempoTotal, New With {.class = "form-check-label"})
                        @Html.TextBoxFor(Function(ticket) ticket.tempoTotal, New With {.class = "form-control"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(ticket) ticket.ID_estado, New With {.class = "form-check-label"})
                        @Html.DropDownList("ID_estado", DirectCast(ViewBag.estado, SelectList), New With {.class = "form-control"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(ticket) ticket.ID_prioridade, New With {.class = "form-check-label"})
                        @Html.DropDownList("ID_prioridade", DirectCast(ViewBag.prioridade, SelectList), New With {.class = "form-control"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(ticket) ticket.ID_utilizador, New With {.class = "form-check-label"})
                        @Html.DropDownList("ID_utilizador", DirectCast(ViewBag.utilizador, SelectList), New With {.class = "form-control"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(ticket) ticket.ID_origem, New With {.class = "form-check-label"})
                        @Html.DropDownList("ID_origem", DirectCast(ViewBag.origem, SelectList), New With {.class = "form-control"})
                    </p>
                    <input type="submit" class="btn btn-success" value="Guardar" name="Enviar" />
                </div>
            </div>


            <!-- butões com as operações respectivas do formulário de edição -->
            <div id="editaTicket" class="form-group">
                <button type="button" class="btn btn-primary btn-danger" data-toggle="modal" data-target="#verificaModal">
                    Apagar
                </button>
                <button type="button" class="btn btn-info" onclick="location.href='@Url.Action("CriaTicket", "Tickets")'">
                    Novo
                </button>
                <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Tickets")'">
                    Voltar
                </button>

                <!-- Opções do Modal para confirmação do apagamento do registo -->
                <div class="modal fade" id="verificaModal" tabindex="-1" role="dialog" aria-labelledby="modalApagar" aria-hidden="true">
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
            </div>

        </div>
    End Using
</div>
