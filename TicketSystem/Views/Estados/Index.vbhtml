﻿@ModelType IEnumerable(Of TicketSystem.Estado)
@Code
    ViewData("Title") = "Estados"
End Code

<div class="container container-fluid">

    <h2 class="font-italic font-weight-bold">Lista de Estados</h2>

    <table id="tabelaEventos" class="table table-hover table-sm table-responsive">
        <tr class="thead-dark">
            <th>@Html.DisplayNameFor(Function(modelEst) modelEst.ID_estado)</th>
            <th>@Html.DisplayNameFor(Function(modelEst) modelEst.descricao)</th>
            <th>@Html.DisplayNameFor(Function(modelEst) modelEst.dat_hor)</th>
        </tr>

        @For Each estado In Model
            @<tr onclick="location.href='@Url.Action("EditarEstado", "Estados", New With {.ID_estado = estado.ID_estado})'" class="clickableCell">
                <td>@Html.DisplayFor(Function(modelestado) estado.ID_estado)</td>
                <td>@Html.DisplayFor(Function(modelestado) estado.descricao)</td>
                <td>@Html.DisplayFor(Function(modelestado) estado.dat_hor)</td>
            </tr>
        Next
    </table>

    <button type="button" class="btn btn-primary" onclick="location.href='@Url.Action("CriaEstado", "Estados")'">
        Novo Registo
    </button>

</div>