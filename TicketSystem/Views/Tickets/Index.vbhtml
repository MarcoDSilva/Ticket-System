@ModelType IEnumerable(Of TicketSystem.VM_Ticket)
@Code
    ViewData("Title") = "Listagem tickets"
End Code

    <div class="container">


        @Using (Html.BeginForm())
            @<div class="filtros_ticket">
                <label> Filtrar por data - </label>
                <span> Decrescente :          </span> @Html.RadioButton("ordem", "decrescente", False)
                <span> Crescente :       </span> @Html.RadioButton("ordem", "crescente", False)
            </div>
        End Using


        <table class="table table-hover table-sm" id="tabelaTickets">
            <tr class="thead-dark">
                <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_ticket)</th>
                <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_tecnico)</th>
                <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_software)</th>
                <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_cliente)</th>
                <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_problema)</th>
                <th>@Html.DisplayNameFor(Function(ticket) ticket.descricao)</th>
                <th>@Html.DisplayNameFor(Function(ticket) ticket.dataAbertura)</th>
                <th>@Html.DisplayNameFor(Function(ticket) ticket.dataFecho)</th>
                <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_estado)</th>
                <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_prioridade)</th>
                <th>@Html.DisplayNameFor(Function(ticket) ticket.ID_origem)</th>
                <th>@Html.DisplayNameFor(Function(ticket) ticket.dat_hor)</th>

                @*<th>@Html.DisplayNameFor(Function(ticket) ticket.ID_utilizador)</th>*@
                @*<th>@Html.DisplayNameFor(Function(ticket) ticket.tempoPrevisto)</th>
                <th>@Html.DisplayNameFor(Function(ticket) ticket.tempoTotal)</th>*@
            </tr>

            @For Each ticket In Model
                @<tr onclick="location.href='@Url.Action("EditarTicket", "Tickets", New With {.ID_ticket = ticket.ID_ticket})'" class="clickableCell">

                    <td>@Html.DisplayFor(Function(modelT) ticket.ID_ticket)</td>
                    <td>@Html.DisplayFor(Function(modelT) ticket.ID_tecnico)</td>
                    <td>@Html.DisplayFor(Function(modelT) ticket.ID_software)</td>
                    <td>@Html.DisplayFor(Function(modelT) ticket.ID_cliente)</td>
                    <td>@Html.DisplayFor(Function(modelT) ticket.ID_problema)</td>

                    <!-- substrings na descrição para evitar mais que X elementos na descrição -->
                    @If ticket.descricao.Length > 24 Then
                        Dim descCortada = ticket.descricao.Substring(0, 22)

                        @<td>@descCortada</td>
                    Else
                        @<td>@Html.DisplayFor(Function(modelT) ticket.descricao)</td>
                    End If

                    <td>@Html.DisplayFor(Function(modelT) ticket.dataAbertura)</td>
                    <td>@Html.DisplayFor(Function(modelT) ticket.dataFecho)</td>


                    <!-- Atribuição de cores para os estados-->
                    @If ticket.ID_estado = "Finalizado" Then
                        @<td class="text-success">@Html.DisplayFor(Function(modelT) ticket.ID_estado)</td>

                    ElseIf ticket.ID_estado = "Actualizado" Then
                        @<td class="text-primary">@Html.DisplayFor(Function(modelT) ticket.ID_estado)</td>

                    ElseIf ticket.ID_estado = "Pendente" Then
                        @<td class="text-danger">@Html.DisplayFor(Function(modelT) ticket.ID_estado)</td>

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
                        @<td class="text-warning font-weight-bold">@Html.DisplayFor(Function(modelT) ticket.ID_prioridade)</td>

                    End If


                    <td>@Html.DisplayFor(Function(modelT) ticket.ID_origem)</td>
                    <td>@Html.DisplayFor(Function(modelT) ticket.dat_hor)</td>

                    @*<td>@Html.DisplayFor(Function(modelT) ticket.ID_utilizador)</td>*@
                    @*<td>@Html.DisplayFor(Function(modelT) ticket.tempoPrevisto)</td>
                    <td>@Html.DisplayFor(Function(modelT) ticket.tempoTotal)</td>*@

                    @*<td>@Html.ActionLink("Detalhes", "EditarTicket", New With {.ID_ticket = ticket.ID_ticket})</td>*@

                </tr>
            Next
        </table>
        <button type="button" class="btn btn-success" onclick="location.href='@Url.Action("CriaTicket", "Tickets")'">
            Novo Registo
        </button>
    </div>
