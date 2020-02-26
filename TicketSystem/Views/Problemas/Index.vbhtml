@ModelType IEnumerable(Of TicketSystem.Problema)

@Code
    ViewData("Title") = "Problema"
End Code

<div class="container container-fluid">

    <h2 class="font-italic font-weight-bold">Listagem de problemas</h2>

    <table id="tabelaEventos" class="table table-hover table-sm table-responsive">
        <tr class="thead-dark">
            <th>@Html.DisplayNameFor(Function(model) model.ID_problema)</th>
            <th>@Html.DisplayNameFor(Function(model) model.descricao)</th>
            <th>@Html.DisplayNameFor(Function(model) model.dat_hor)</th>
        </tr>

        @For Each problem In Model
            @<tr onclick="location.href='@Url.Action("EditarProblema", "Problemas", New With {.ID_problema = problem.ID_problema})'" class="clickableCell">
                <td>@Html.DisplayFor(Function(modelproblem) problem.ID_problema)</td>
                <td>@Html.DisplayFor(Function(modelproblem) problem.descricao)</td>
                <td>@Html.DisplayFor(Function(modelproblem) problem.dat_hor)</td>
            </tr>
        Next
    </table>
    <button type="button" class="btn btn-primary" onclick="location.href='@Url.Action("CriaProblema", "Problemas")'">
        Novo Registo
    </button>

</div>