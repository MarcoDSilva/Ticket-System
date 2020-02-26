@ModelType IEnumerable(Of TicketSystem.Prioridade)
@Code
    ViewData("Title") = "Prioridades"
End Code

<div class="container">
    <h2 class="font-italic font-weight-bold">Listar Prioridades</h2>

    <table id="tabelaEventos" class="table table-hover table-sm table-responsive">
        <tr class="thead-dark">
            <th>@Html.DisplayNameFor(Function(modelPrio) modelPrio.ID_prioridade)</th>
            <th>@Html.DisplayNameFor(Function(modelPrio) modelPrio.descricao)</th>
            <th>@Html.DisplayNameFor(Function(modelPrio) modelPrio.dat_hor)</th>
        </tr>

        @For Each prioridade In Model
            @<tr onclick="location.href='@Url.Action("EditarPrioridade", "Prioridades", New With {.ID_prioridade = prioridade.ID_prioridade})'" class="clickableCell">
                <td>@Html.DisplayFor(Function(modelPrio) prioridade.ID_prioridade)</td>
                <td>@Html.DisplayFor(Function(modelPrio) prioridade.descricao)</td>
                <td>@Html.DisplayFor(Function(modelPrio) prioridade.dat_hor)</td>
            </tr>
        Next
    </table>

    <button type="button" class="btn btn-primary" onclick="location.href='@Url.Action("CriaPrioridade", "Prioridades")'">
        Novo Registo
    </button>

</div>
