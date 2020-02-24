@ModelType IEnumerable(Of TicketSystem.VM_Ticket)
@Code
    ViewData("Title") = "Listagem tickets"
End Code

@Using (Html.BeginForm())
    'filtros neste form para melhor leitura nos tickets
    @Html.AntiForgeryToken()
    @<section class="filtros_ticket container container-fluid container-md">
        <h4>Listagem tickets</h4>
        <div>
            @Html.RadioButton("ordem", "decrescente", False, htmlAttributes:=New With {.onchange = "this.form.submit();"}) <label>Data Abertura Decrescente</label>
            @Html.RadioButton("ordem", "crescente", False, htmlAttributes:=New With {.onchange = "this.form.submit();"}) <label> Data Abertura Crescente</label>
            @Html.RadioButton("ordem", "", False, htmlAttributes:=New With {.onchange = "this.form.submit();"}) <label>por ID crescente</label>
        </div>

        <div class="form-check-inline">
            <label>Filtrar por prioridad    e </label>
            @Html.DropDownList("ID_prioridade", DirectCast(ViewBag.prioridade, SelectList), "",
                            htmlAttributes:=New With {.class = "form-control", .onchange = "this.form.submit();"})
        </div>

        <div class="form-check-inline">
            <label>Filtrar por estado:</label>
            @Html.DropDownList("ID_estado", DirectCast(ViewBag.estado, SelectList), "",
                    htmlAttributes:=New With {.class = "form-control", .onchange = "this.form.submit();"})
        </div>

    </section>
End Using

<div class="container container-fluid container-md">
    <table class="table table-hover table-sm table-responsive" id="tabelaTickets">
        <tr class="thead-dark">
            <th scope="col">@Html.DisplayNameFor(Function(ticket) ticket.ID_ticket)</th>
            <th scope="col">@Html.DisplayNameFor(Function(ticket) ticket.ID_tecnico)</th>
            <th scope="col">@Html.DisplayNameFor(Function(ticket) ticket.ID_software)</th>
            <th scope="col">@Html.DisplayNameFor(Function(ticket) ticket.ID_cliente)</th>
            <th scope="col">@Html.DisplayNameFor(Function(ticket) ticket.ID_problema)</th>
            <th scope="col">@Html.DisplayNameFor(Function(ticket) ticket.descricao)</th>
            <th scope="col">@Html.DisplayNameFor(Function(ticket) ticket.dataAbertura)</th>
            <th scope="col">@Html.DisplayNameFor(Function(ticket) ticket.dataFecho)</th>
            <th scope="col">@Html.DisplayNameFor(Function(ticket) ticket.ID_estado)</th>
            <th scope="col">@Html.DisplayNameFor(Function(ticket) ticket.ID_prioridade)</th>
            <th scope="col">@Html.DisplayNameFor(Function(ticket) ticket.ID_origem)</th>
            <th scope="col">@Html.DisplayNameFor(Function(ticket) ticket.dat_hor)</th>
        </tr>
        @Using (Html.BeginForm())
            @<tr class="camposPesquisaTicket">
                <td>@Html.TextBox("ID_ticket", "", htmlAttributes:=New With {.style = "max-width:35px;", .class = "form-control borderForm", .onchange = "this.form.submit();"})</td>
                <td>@Html.TextBox("nome_tecnico", "", htmlAttributes:=New With {.style = "max-width:60px;", .class = "form-control borderForm", .onchange = "this.form.submit();"})</td>
                <td>@Html.TextBox("nome_software", "", htmlAttributes:=New With {.style = "max-width:60px;", .class = "form-control borderForm", .onchange = "this.form.submit();"})</td>
                <td>@Html.TextBox("nome_cliente", "", htmlAttributes:=New With {.style = "max-width:60px;", .class = "form-control borderForm", .onchange = "this.form.submit();"})</td>
                <td>@Html.TextBox("desc_problema", "", htmlAttributes:=New With {.style = "max-width:60px;", .class = "form-control borderForm", .onchange = "this.form.submit();"})</td>
                <td>@Html.TextBox("descricao", "", htmlAttributes:=New With {.style = "max-width:140px;", .class = "form-control borderForm", .onchange = "this.form.submit();"})</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>@Html.TextBox("origem", "", htmlAttributes:=New With {.style = "max-width:60px;", .class = "form-control borderForm", .onchange = "this.form.submit();"})</td>
                <td></td>
            </tr>
        End Using

        @For Each ticket In Model
            @<tr onclick="location.href='@Url.Action("EditarTicket", "Tickets", New With {.ID_ticket = ticket.ID_ticket})'" class="clickableCell">

                <td>@Html.DisplayFor(Function(modelT) ticket.ID_ticket)</td>
                <td>@Html.DisplayFor(Function(modelT) ticket.ID_tecnico)</td>
                <td>@Html.DisplayFor(Function(modelT) ticket.ID_software)</td>
                <td>@Html.DisplayFor(Function(modelT) ticket.ID_cliente)</td>
                <td>@Html.DisplayFor(Function(modelT) ticket.ID_problema)</td>

                <!-- substrings na descrição para evitar mais que X elementos na descrição -->
                @If ticket.descricao.Length > 24 Then
                    Dim descCortada = ticket.descricao.Substring(0, 22).Insert(22, "...")
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

                <td>@Html.DisplayFor(Function(modelT) ticket.ID_origem)</td>
                <td>@Html.DisplayFor(Function(modelT) ticket.dat_hor)</td>

                @*<td>@Html.ActionLink("Detalhes", "EditarTicket", New With {.ID_ticket = ticket.ID_ticket})</td>*@

            </tr>
        Next
    </table>
    <button type="button" class="btn btn-primary btn-sm" onclick="location.href='@Url.Action("CriaTicket", "Tickets")'">
        Novo Registo
    </button>
</div>

