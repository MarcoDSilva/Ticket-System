@ModelType TicketSystem.VM_TicketEventosHomePage
@Code
    ViewData("Title") = "Menu principal"
    Dim dataDia = DateTime.Now.Hour
    Dim mensagem As String
    If Convert.ToInt16(dataDia) >= 6 And Convert.ToInt16(dataDia) <= 12 Then
        mensagem = "Bom dia"
    Else
        If Convert.ToInt16(dataDia) > 12 And Convert.ToInt16(dataDia) <= 18 Then
            mensagem = "Boa tarde"
        Else
            mensagem = "Boa Noite"
        End If
    End If
End Code

<div class="container">
    <h2>@DateTime.Now.ToLongDateString()</h2>
    <p>@mensagem @Session("Nome")</p>

    @If Session("Administrador") = 1 Then
        @<p>O seu cargo é administrador!</p>
    Else
        @<p>O seu cargo é técnico/a</p>
    End If
</div>


@If Session("Inativo") = 1 Then
    @<div class="container">
        <p>A sua conta esta desactivada de momento. Por favor contacte o administrador do software.</p>
    </div>
Else
    @<div class="container">
        <div id="estatisticasBasicasTickets">

            <section class="estatisticasFlexItem">
                <img src="~/img/folder.svg" alt="" width="32" height="32" title="icon">
                <Label> Total de tickets: @ViewBag.totalTickets</Label>
            </section>

            <section class="estatisticasFlexItem">
                <img src="~/img/alert-square.svg" alt="" width="32" height="32" title="icon">
                <p> Tickets não finalizados: @ViewBag.ticketsNaoConcluidos</p>
            </section>

            <section class="estatisticasFlexItem">
                <img src="~/img/envelope-open.svg" alt="" width="32" height="32" title="icon">
                <p> Abertos no Mês corrente: @ViewBag.ticketsAnoActual</p>
            </section>

            <section class="estatisticasFlexItem">
                <img src="~/img/envelope.svg" alt="" width="32" height="32" title="icon">
                <p> Tickets Resolvidos: @ViewBag.ticketsConcluidos</p>
            </section>

            <section class="estatisticasFlexItem">
                <img src="~/img/inbox-fill.svg" alt="" width="32" height="32" title="icon">
                <p> Tickets do ano corrente: @ViewBag.ticketsAnoActual</p>
            </section>

            <section class="estatisticasFlexItem">
                <img src="~/img/info.svg" alt="" width="32" height="32" title="icon">
                <p> Número de tickets novos: @ViewBag.ticketsNovos</p>
            </section>

            <section class="estatisticasFlexItem">
                <img src="~/img/info.svg" alt="" width="32" height="32" title="icon">
                <p> Eventos para o técnico: @ViewBag.eventosAtribuidos</p>
            </section>

        </div>

        <!--tickets abertos -->
        <div id="ticketsIndex">
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
                    @<tr>
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
                <caption>Tickets Abertos</caption>
            </table>
        </div>

        <!--eventos atribuidos-->
        <div id="ticketsIndex">
            <table class="table table-striped table-hover table-sm table-responsive">
                <tr class="thead-dark">
                    <th>@Html.LabelFor(Function(model) model.Evento.First.ID_evento)</th>
                    <th> @Html.LabelFor(Function(model) model.Evento.First.ID_tecnico)</th>
                    <th> @Html.LabelFor(Function(model) model.Evento.First.descricao)</th>
                    <th> @Html.LabelFor(Function(model) model.Evento.First.ID_ticket)</th>
                    <th> @Html.LabelFor(Function(model) model.Evento.First.dataAbertura)</th>
                </tr>
                @For Each evento In Model.Evento
                    @<tr>
                        <td>@Html.DisplayFor(Function(model) evento.ID_evento)</td>
                        <td>@Html.DisplayFor(Function(model) evento.ID_tecnico)</td>
                        <td>@Html.DisplayFor(Function(model) evento.descricao)</td>
                        <td>@Html.DisplayFor(Function(model) evento.ID_ticket)</td>
                        <td>@Html.DisplayFor(Function(model) evento.dataAbertura)</td>
                    </tr>
                Next

                <caption>Eventos atribuidos ao utilizador</caption>
            </table>

        </div>
    </div>
End If


