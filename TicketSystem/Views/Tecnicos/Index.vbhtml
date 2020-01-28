@ModelType IEnumerable(Of TicketSystem.Tecnico)
@Code
    ViewData("Title") = "Index"
End Code

<h2>Listagem Tecnicos</h2>

<table class="table">
    <tr>
        <th>@Html.DisplayNameFor(Function(modelTec) modelTec.ID_tecnico)
        <th>@Html.DisplayNameFor(Function(modelTec) modelTec.nome)</th>
        <th>@Html.DisplayNameFor(Function(modelTec) modelTec.email)</th>
        <th>@Html.DisplayNameFor(Function(modelTec) modelTec.dat_hor)</th>
    </tr>

    @For Each tecnico In Model
        @<tr>
            <td>@Html.DisplayFor(Function(modelTec) tecnico.ID_tecnico)</td>
            <td>@Html.DisplayFor(Function(modelTec) tecnico.nome)</td>
            <td>@Html.DisplayFor(Function(modelTec) tecnico.email)</td>
            <td>@Html.DisplayFor(Function(modelTec) tecnico.dat_hor)</td>
        </tr>
    Next
</table>
<button type="button" class="btn btn-primary" onclick="location.href='@Url.Action("CriaTecnico", "Tecnicos")'">
    Novo Registo
</button>