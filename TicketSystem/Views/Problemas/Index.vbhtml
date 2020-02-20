@ModelType IEnumerable(Of TicketSystem.Problema)

@Code
    ViewData("Title") = "Problema"
End Code

<h2>Listagem de problemas</h2>


<table class="table table-hover table-sm">
    <tr class="thead-dark">
        <th>@Html.DisplayNameFor(Function(model) model.ID_problema)</th>
        <th>@Html.DisplayNameFor(Function(model) model.descricao)</th>
        <th>@Html.DisplayNameFor(Function(model) model.dat_hor)</th>
    </tr>

    @For Each problem In Model
        @<tr>
            <td>@Html.DisplayFor(Function(modelproblem) problem.ID_problema)</td>
            <td>@Html.DisplayFor(Function(modelproblem) problem.descricao)</td>
            <td>@Html.DisplayFor(Function(modelproblem) problem.dat_hor)</td>
            <td>
                @Html.ActionLink("Detalhes", "EditarProblema", New With {.ID_problema = problem.ID_problema})
            </td>
        </tr>
    Next
</table>
<button type="button" class="btn btn-primary" onclick="location.href='@Url.Action("CriaProblema", "Problemas")'">
    Novo Registo
</button>
