@ModelType IEnumerable(Of TicketSystem.VM_EventoTecnico)

@Code
    ViewData("Title") = "Eventos"
End Code

<h2>Listar eventos</h2>

<Table class="table table-hover table-sm">
    <tr>
    <th>@Html.DisplayNameFor(Function(modelEv) modelEv.ID_evento)</th>
        <th>@Html.DisplayNameFor(Function(modelEv) modelEv.descricao)</th>
        <th>@Html.DisplayNameFor(Function(modelEv) modelEv.ID_tecnico)</th>
        <th>@Html.DisplayNameFor(Function(modelEv) modelEv.dataAbertura)</th>
        <th>@Html.DisplayNameFor(Function(modelEv) modelEv.dataFecho)</th>
        <th>@Html.DisplayNameFor(Function(modelEv) modelEv.ID_ticket)</th>
        <th>@Html.DisplayNameFor(Function(modelEv) modelEv.dat_hor)</th>
    </tr>

    @For Each evento In Model
        @<tr>
            <td>@Html.DisplayFor(Function(modelEv) evento.ID_evento)</td>
            <td>@Html.DisplayFor(Function(modelEv) evento.descricao)</td>
            <td>@Html.DisplayFor(Function(modelEv) evento.ID_tecnico)</td>
            <td>@Html.DisplayFor(Function(modelEv) evento.dataAbertura)</td>
            <td>@Html.DisplayFor(Function(modelEv) evento.dataFecho)</td>
            <td>@Html.DisplayFor(Function(modelEv) evento.ID_ticket)</td>
            <td>@Html.DisplayFor(Function(modelEv) evento.dat_hor)</td>
            <td>@Html.ActionLink("Detalhes", "EditarEvento", New With {.ID_evento = evento.ID_evento})</td>
        </tr>
    Next
 </table>

<button type="button" class="btn btn-primary" onclick="location.href='@Url.Action("CriaEvento", "Eventos")'">
    Novo Registo
</button>


