@ModelType IEnumerable(Of TicketSystem.VM_TecnicoRole)
@Code
    ViewData("Title") = "Técnicos"
End Code

<h2>Listagem Tecnicos</h2>

<table class="table table-hover">
    <tr>
        <th>@Html.DisplayNameFor(Function(modelTec) modelTec.ID_tecnico)
        <th>@Html.DisplayNameFor(Function(modelTec) modelTec.nome)</th>
        <th>@Html.DisplayNameFor(Function(modelTec) modelTec.email)</th>
        <th>@Html.DisplayNameFor(Function(modelTec) modelTec.ID_role)</th>
        <th>@Html.DisplayNameFor(Function(modelTec) modelTec.dat_hor)</th>
    </tr>

    @For Each tecnico In Model
        @<tr>
            <td>@Html.DisplayFor(Function(modelTec) tecnico.ID_tecnico)</td>
            <td>@Html.DisplayFor(Function(modelTec) tecnico.nome)</td>
            <td>@Html.DisplayFor(Function(modelTec) tecnico.email)</td>
            <td>@Html.DisplayFor(Function(modelTec) tecnico.ID_role)</td>
            <td>@Html.DisplayFor(Function(modelTec) tecnico.dat_hor)</td>
            <td>@Html.ActionLink("Detalhes", "EditarTecnico", New With {.ID_tecnico = tecnico.ID_tecnico})</td>
        </tr>
    Next
</table>
<button type="button" class="btn btn-primary" onclick="location.href='@Url.Action("CriaTecnico", "Tecnicos")'">
    Novo Registo
</button>