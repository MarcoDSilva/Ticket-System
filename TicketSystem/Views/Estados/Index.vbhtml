@ModelType IEnumerable(Of TicketSystem.Estado)
@Code
    ViewData("Title") = "Estados"
End Code

<h2>Lista de Estados</h2>

<table class="table table-hover table-sm table-responsive">
    <tr class="thead-dark">
        <th>@Html.DisplayNameFor(Function(modelEst) modelEst.ID_estado)</th>
        <th>@Html.DisplayNameFor(Function(modelEst) modelEst.descricao)</th>
        <th>@Html.DisplayNameFor(Function(modelEst) modelEst.dat_hor)</th>
    </tr>

    @For Each estado In Model
        @<tr>
            <td>@Html.DisplayFor(Function(modelestado) estado.ID_estado)</td>
            <td>@Html.DisplayFor(Function(modelestado) estado.descricao)</td>
            <td>@Html.DisplayFor(Function(modelestado) estado.dat_hor)</td>
            <td>@Html.ActionLink("Detalhes", "EditarEstado", New With {.ID_estado = estado.ID_estado})</td>
        </tr>
    Next
</table>

<button type="button" class="btn btn-primary" onclick="location.href='@Url.Action("CriaEstado", "Estados")'">
    Novo Registo
</button>
