@ModelType IEnumerable(Of TicketSystem.VM_Ticket)
@Code
    ViewData("Title") = "Index"
End Code

<h2>Listagem de tickets</h2>


<table class="table table-hover">
    <tr>
        <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_ticket)</th>
        <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_tecnico)</th>
        <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_software)</th>
        <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_cliente)</th>
        <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_problema)</th>
        <th>@Html.DisplayNameFor(Function(ticket) ticket.descricao)</th>
        <th>@Html.DisplayNameFor(Function(ticket) ticket.dataAbertura)</th>
        <th>@Html.DisplayNameFor(Function(ticket) ticket.dataFecho)</th>
        <th>@Html.DisplayNameFor(Function(ticket) ticket.tempoPrevisto)</th>
        <th>@Html.DisplayNameFor(Function(ticket) ticket.tempoTotal)</th>
        <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_estado)</th>
        <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_prioridade)</th>
        <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_utilizador)</th>
        <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_origem)</th>
        <th>@Html.DisplayNameFor(Function(ticket) ticket.dat_hor)</th>

    </tr>

    @For Each ticket In Model
        @<tr>
            <td>@Html.DisplayFor(Function(modelT) ticket.ID_ticket)</td>
            <td>@Html.DisplayFor(Function(modelT) ticket.ID_tecnico)</td>
            <td>@Html.DisplayFor(Function(modelT) ticket.ID_software)</td>
            <td>@Html.DisplayFor(Function(modelT) ticket.ID_cliente)</td>
            <td>@Html.DisplayFor(Function(modelT) ticket.ID_problema)</td>
            <td>@Html.DisplayFor(Function(modelT) ticket.descricao)</td>
            <td>@Html.DisplayFor(Function(modelT) ticket.dataAbertura)</td>
            <td>@Html.DisplayFor(Function(modelT) ticket.dataFecho)</td>
            <td>@Html.DisplayFor(Function(modelT) ticket.tempoPrevisto)</td>
            <td>@Html.DisplayFor(Function(modelT) ticket.tempoTotal)</td>
            <td>@Html.DisplayFor(Function(modelT) ticket.ID_estado)</td>
            <td>@Html.DisplayFor(Function(modelT) ticket.ID_prioridade)</td>
            <td>@Html.DisplayFor(Function(modelT) ticket.ID_utilizador)</td>
            <td>@Html.DisplayFor(Function(modelT) ticket.ID_origem)</td>
            <td>@Html.DisplayFor(Function(modelT) ticket.dat_hor)</td>

            <td>@Html.ActionLink("Detalhes", "EditarTicket", New With {.ID_ticket = ticket.ID_ticket})</td>
        </tr>
    Next
</table>

<button type="button" class="btn btn-primary" onclick="location.href='@Url.Action("CriaTicket", "Tickets")'">
    Novo Registo
</button>


