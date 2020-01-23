@ModelType IEnumerable(Of TicketSystem.Problema)

@Code
    ViewData("Title") = "Index"
End Code

<h2>Listagem de problemas</h2>


<table class="table">
    <tr>
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
            @Html.ActionLink("Editar", "EditarProblema", New With {.ID_problema = problem.ID_problema}) |
        </td>
    </tr>
Next
    
</table>