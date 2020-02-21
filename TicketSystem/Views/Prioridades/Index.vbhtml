﻿@ModelType IEnumerable(Of TicketSystem.Prioridade)
@Code
    ViewData("Title") = "Prioridades"
End Code

<div class="container">
    <h2>Listar Prioridades</h2>

    <table class="table table-hover table-sm table-responsive col-lg-12">
        <tr class="thead-dark">
            <th>@Html.DisplayNameFor(Function(modelPrio) modelPrio.ID_prioridade)</th>
            <th>@Html.DisplayNameFor(Function(modelPrio) modelPrio.descricao)</th>
            <th>@Html.DisplayNameFor(Function(modelPrio) modelPrio.dat_hor)</th>
        </tr>

        @For Each prioridade In Model
            @<tr>
                <td>@Html.DisplayFor(Function(modelPrio) prioridade.ID_prioridade)</td>
                <td>@Html.DisplayFor(Function(modelPrio) prioridade.descricao)</td>
                <td>@Html.DisplayFor(Function(modelPrio) prioridade.dat_hor)</td>
                <td>@Html.ActionLink("Detalhes", "EditarPrioridade", New With {.ID_prioridade = prioridade.ID_prioridade})</td>
            </tr>
        Next
    </table>

    <button type="button" class="btn btn-primary" onclick="location.href='@Url.Action("CriaPrioridade", "Prioridades")'">
        Novo Registo
    </button>

</div>
