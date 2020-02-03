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
            <th>@Html.DisplayFor(Function(modelT) ticket.ID_tecnico)</th>
            <th>@Html.DisplayFor(Function(modelT) ticket.ID_software)</th>
            <th>@Html.DisplayFor(Function(modelT) ticket.ID_cliente)</th>
            <th>@Html.DisplayFor(Function(modelT) ticket.ID_problema)</th>
            <th>@Html.DisplayFor(Function(modelT) ticket.descricao)</th>
            <th>@Html.DisplayFor(Function(modelT) ticket.dataAbertura)</th>
            <th>@Html.DisplayFor(Function(modelT) ticket.dataFecho)</th>
            <th>@Html.DisplayFor(Function(modelT) ticket.tempoPrevisto)</th>
            <th>@Html.DisplayFor(Function(modelT) ticket.tempoTotal)</th>
            <th>@Html.DisplayFor(Function(modelT) ticket.ID_estado)</th>
            <th>@Html.DisplayFor(Function(modelT) ticket.ID_prioridade)</th>
            <th>@Html.DisplayFor(Function(modelT) ticket.ID_utilizador)</th>
            <th>@Html.DisplayFor(Function(modelT) ticket.ID_origem)</th>
            <th>@Html.DisplayFor(Function(modelT) ticket.dat_hor)</th>

            <td>@Html.ActionLink("Detalhes", "EditarEvento", New With {.ID_ticket = ticket.ID_ticket})</td>
        </tr>
    Next
</table>

<button type="button" class="btn btn-primary" onclick="location.href='@Url.Action("CriaTicket", "Tickets")'">
    Novo Registo
</button>


