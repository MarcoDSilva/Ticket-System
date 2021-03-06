﻿@ModelType IEnumerable(Of TicketSystem.Origem)
@Code
    ViewData("Title") = "Origem"
End Code

<div class="container container-fluid">

    <h2 class="font-italic font-weight-bold">Listagem Origem</h2>

    <table id="tabelaEventos" class="table table-hover table-sm table-responsive table-bordered">
        <tr class="thead-dark">
            <th>@Html.DisplayNameFor(Function(modelOrig) modelOrig.ID_origem)</th>
            <th>@Html.DisplayNameFor(Function(modelOrig) modelOrig.descricao)</th>
            <th>@Html.DisplayNameFor(Function(modelOrig) modelOrig.dat_hor)</th>
        </tr>

        @For Each origem In Model
            @<tr onclick="location.href='@Url.Action("EditarOrigem", "Origens", New With {.ID_origem = origem.ID_origem})'" class = "clickableCell"}>
                <td>@Html.DisplayFor(Function(modelOrig) origem.ID_origem)</td>
                <td>@Html.DisplayFor(Function(modelOrig) origem.descricao)</td>
                <td>@Html.DisplayFor(Function(modelOrig) origem.dat_hor)</td>
            </tr>
        Next
    </table>

    <button type="button" class="btn btn-primary" onclick="location.href='@Url.Action("CriaOrigem", "Origens")'">
        Novo Registo
    </button>
</div>