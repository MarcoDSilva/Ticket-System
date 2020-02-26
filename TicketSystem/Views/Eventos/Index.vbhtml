@ModelType IEnumerable(Of TicketSystem.VM_EventoTecnico)

@Code
    ViewData("Title") = "Eventos"
End Code

<div class="container">
    <h4 class="font-italic font-weight-bold">Listagem eventos</h4>
    <table class="table table-hover table-sm table-responsive" id="tabelaEventos">
        <tr class="thead-dark">
            <th scope="col">@Html.DisplayNameFor(Function(modelEv) modelEv.ID_evento)</th>
            <th scope="col">@Html.DisplayNameFor(Function(modelEv) modelEv.descricao)</th>
            <th scope="col">@Html.DisplayNameFor(Function(modelEv) modelEv.ID_tecnico)</th>
            <th scope="col">@Html.DisplayNameFor(Function(modelEv) modelEv.dataAbertura)</th>
            <th scope="col">@Html.DisplayNameFor(Function(modelEv) modelEv.dataFecho)</th>
            <th scope="col">@Html.DisplayNameFor(Function(modelEv) modelEv.ID_ticket)</th>
            <th scope="col">@Html.DisplayNameFor(Function(modelEv) modelEv.dat_hor)</th>
        </tr>

        @For Each evento In Model
            @<tr onclick="location.href='@Url.Action("EditarEvento", "Eventos", New With {.ID_evento = evento.ID_evento})'" class="clickableCell">
                <td>@Html.DisplayFor(Function(modelEv) evento.ID_evento)</td>

                <!-- substrings na descrição para evitar mais que X elementos na descrição -->
                @If evento.descricao.Length > 28 Then
                    Dim descCortada = evento.descricao.Substring(0, 25).Insert(25, "...")

                    @<td>@descCortada</td>
                Else
                    @<td>@Html.DisplayFor(Function(modelT) evento.descricao)</td>
                End If

                @*<td>@Html.DisplayFor(Function(modelEv) evento.descricao)</td>*@

                @If evento.ID_tecnico.Length > 15 Then
                    Dim tecCortado = evento.ID_tecnico.Substring(0, 10).Insert(10, "...")

                    @<td>@tecCortado</td>
                Else
                    @<td>@Html.DisplayFor(Function(modelEv) evento.ID_tecnico)</td>
                End If


                @*<td>@Html.DisplayFor(Function(modelEv) evento.ID_tecnico)</td>*@
                <td>@Html.DisplayFor(Function(modelEv) evento.dataAbertura)</td>
                <td>@Html.DisplayFor(Function(modelEv) evento.dataFecho)</td>
                <td>@Html.DisplayFor(Function(modelEv) evento.ID_ticket)</td>
                <td>@Html.DisplayFor(Function(modelEv) evento.dat_hor)</td>
            </tr>
        Next
    </table>
    <button type="button" class="btn btn-primary btn-sm" onclick="location.href='@Url.Action("CriaEvento", "Eventos")'">
        Novo Registo
    </button>
</div>



