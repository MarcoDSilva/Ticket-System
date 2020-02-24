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
    @<p>A sua conta esta desactivada de momento. Por favor contacte o administrador do software.</p>
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
                </tr>
                @For Each ticket In Model.Ticket
                    @<tr>
                        <td>@Html.DisplayFor(Function(model) ticket.ID_ticket)</td>
                        <td>@Html.DisplayFor(Function(model) ticket.ID_tecnico)</td>
                        <td>@Html.DisplayFor(Function(model) ticket.ID_cliente)</td>
                        <td>@Html.DisplayFor(Function(model) ticket.ID_software)</td>
                        <td>@Html.DisplayFor(Function(model) ticket.ID_problema)</td>
                        <td>@Html.DisplayFor(Function(model) ticket.descricao)</td>
                        <td>@Html.DisplayFor(Function(model) ticket.ID_estado)</td>
                    </tr>
                Next
                <caption>Tickets Abertos</caption>
            </table>
        </div>

        <!--eventos atribuidos-->
        <div id = "ticketsIndex" >
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


