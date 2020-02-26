@ModelType TicketSystem.VM_TicketEventosHomePage
@Code
    ViewData("Title") = "Edição de eventos"

    Dim dataFinal As String
    Dim dataInicial = Model.Evento.First.dataAbertura.ToString("yyyy-MM-dd")

    If IsNothing(Model.Evento.First.dataFecho) Then
        dataFinal = ""
    Else
        dataFinal = Model.Evento.First.dataFecho.Value.ToString("yyyy-MM-dd")
    End If

End Code

@Using (Html.BeginForm())
    @Html.AntiForgeryToken
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(modelEv) modelEv.Evento.First.ID_evento)

    @<div class="container container-fluid">
    <!-- form edição -->
    <div class="row">
        <div class="col">
            <h4 class="font-italic font-weight-bold">Evento</h4>

            <section>
                @Html.LabelFor(Function(modelEv) modelEv.Evento.First.descricao, New With {.class = "form-check-label"})
                @Html.TextAreaFor(Function(modelEv) modelEv.Evento.First.descricao, 10, 100, New With {.class = "form-control descricaoTicket",
                                     .placeHolder = "Insira a descrição aqui"})
                @Html.ValidationMessageFor(Function(modelEv) modelEv.Evento.First.descricao, "", New With {.class = "text-danger"})
            </section>

            <section>
                @Html.LabelFor(Function(modelEv) modelEv.Evento.First.ID_tecnico, New With {.class = "form-check-label"})
                @Html.DropDownList("ID_tecnico", DirectCast(ViewBag.tecnico, SelectList), New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(modelEv) modelEv.Evento.First.ID_tecnico, "", New With {.class = "text-danger"})
            </section>

            <section>
                @Html.LabelFor(Function(modelEv) modelEv.Evento.First.dataAbertura, New With {.class = "form-check-label"})
                <input type="date" name="dataAbertura" value="@dataInicial" id="dataAbertura" class="form-control" />
                @Html.ValidationMessageFor(Function(modelEv) modelEv.Evento.First.dataAbertura, "", New With {.class = "text-danger"})
            </section>

            <section>
                @Html.LabelFor(Function(modelEv) modelEv.Evento.First.dataFecho, New With {.class = "form-check-label"})
                <input type="date" name="dataFecho" value="@dataFinal" id="dataFecho" class="form-control" />
                @Html.ValidationMessageFor(Function(modelEv) modelEv.Evento.First.dataFecho, "", New With {.class = "text-danger"})
            </section>
        </div>
        <!-- butões com as operações respectivas do formulário de edição -->
        <div id="btnsEditarTickets" class="col">
            <h4 class="text-center font-italic font-weight-bold">Edição</h4>

            <ul class="listaBtns">
                <li>
                    <input type="submit" class="btn btn-success btn-sm" value="Guardar" name="Enviar" />
                </li>
                <li>
                    <button type="button" class="btn btn-sm btn-danger " data-toggle="modal" data-target="#verificaModal">
                        Apagar
                    </button>
                </li>
                <li>
                    <button type="button" class="btn btn-info btn-sm" onclick="location.href='@Url.Action("CriaEvento", "Eventos")'">
                        Novo
                    </button>
                </li>
                <li>
                    <button type="button" class="btn btn-secondary btn-sm" onclick="location.href='@Url.Action("Index", "Eventos")'">
                        Voltar
                    </button>
                </li>
            </ul>
        </div>
    </div>

    <p>Inserir aqui o ticket correspondente com uma viewmodel (VM_TicketEventosHomePage)</p>

    <!--ticket atribuido-->
    <div class="row">
        <div id="ticketsIndex" class="col">
            <h4 class="font-italic font-weight-bold">Ticket associado ao evento.</h4>
            <table class="table table-striped table-hover table-sm table-responsive">
                <tr class="thead-dark">
                    <th>
                        @Html.LabelFor(Function(model) model.Ticket.First.ID_ticket)
                    </th>
                    <th>@Html.LabelFor(Function(model) model.Ticket.First.ID_tecnico)</th>
                    <th>@Html.LabelFor(Function(model) model.Ticket.First.ID_cliente)</th>
                    <th>@Html.LabelFor(Function(model) model.Ticket.First.ID_software)</th>
                    <th>@Html.LabelFor(Function(model) model.Ticket.First.ID_problema)</th>
                    <th>@Html.LabelFor(Function(model) model.Ticket.First.descricao)</th>
                    <th>@Html.LabelFor(Function(model) model.Ticket.First.ID_estado)</th>
                    <th>@Html.LabelFor(Function(model) model.Ticket.First.ID_prioridade)</th>
                </tr>
                @For Each ticket In Model.Ticket
                    @<tr onclick="location.href='@Url.Action("EditarTicket", "Tickets", New With {.ID_ticket = ticket.ID_ticket})'" class="clickableCell">
                        <td>@Html.DisplayFor(Function(model) ticket.ID_ticket)</td>
                        <td>@Html.DisplayFor(Function(model) ticket.ID_tecnico)</td>
                        <td>@Html.DisplayFor(Function(model) ticket.ID_cliente)</td>
                        <td>@Html.DisplayFor(Function(model) ticket.ID_software)</td>
                        <td>@Html.DisplayFor(Function(model) ticket.ID_problema)</td>

                        <!-- substrings na descrição para evitar mais que X elementos na descrição -->
                        @If ticket.descricao.Length > 24 Then
                            Dim descCortada = ticket.descricao.Substring(0, 22).Insert(22, "...")

                            @<td>@descCortada</td>
                        Else
                            @<td>@Html.DisplayFor(Function(model) ticket.descricao)</td>
                        End If

                        <!-- Atribuição de cores para os estados-->
                        @If ticket.ID_estado = "Actualizado" Then
                            @<td class="text-primary">@Html.DisplayFor(Function(modelT) ticket.ID_estado)</td>

                        ElseIf ticket.ID_estado = "Pendente" Then
                            @<td style="color:orangered;">@Html.DisplayFor(Function(modelT) ticket.ID_estado)</td>

                        ElseIf ticket.ID_estado = "Novo" Then
                            @<td class="text-danger font-weight-bolder">@Html.DisplayFor(Function(modelT) ticket.ID_estado)</td>
                        Else
                            @<td>@Html.DisplayFor(Function(modelT) ticket.ID_estado)</td>
                        End If

                        <!--Atribuição de cores para as prioridades-->
                        @If (ticket.ID_prioridade = "Urgente") Then
                            @<td class="text-danger font-weight-bolder">@Html.DisplayFor(Function(modelT) ticket.ID_prioridade)</td>

                        ElseIf (ticket.ID_prioridade = "Baixa") Then
                            @<td class="text-success font-italic">@Html.DisplayFor(Function(modelT) ticket.ID_prioridade)</td>

                        ElseIf (ticket.ID_prioridade = "Elevada") Then
                            @<td class="text-danger">@Html.DisplayFor(Function(modelT) ticket.ID_prioridade)</td>

                        ElseIf (ticket.ID_prioridade = "Média") Then
                            @<td style="color:orangered;">@Html.DisplayFor(Function(modelT) ticket.ID_prioridade)</td>
                        End If
                    </tr>
                Next
                <caption>Ticket que corresponde ao evento</caption>
            </table>
        </div>
    </div>

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
                            onclick="location.href ='@Url.Action("ApagarEvento", "Eventos", New With {.ID_evento = Model.Evento.First.ID_evento})'">
                        Apagar
                    </button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                </div>
            </div>
        </div>
    </div>
</div>
End Using

