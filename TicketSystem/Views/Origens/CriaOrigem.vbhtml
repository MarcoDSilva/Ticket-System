﻿@ModelType TicketSystem.Origem
@Code
    ViewData("Title") = "Criação de origens"
End Code


<h4>Criar nova origem</h4>
@Using (Html.BeginForm())
    @<div Class="form-horizontal">

        @Html.AntiForgeryToken()

        <div class="form-group">
            <p>
                @Html.LabelFor(Function(modelOrig) modelOrig.descricao)
                @Html.TextBoxFor(Function(modelOrig) modelOrig.descricao, New With {.class = "form-control"})
            </p>
        </div>
        <input type="submit" class="btn btn-primary" value="Inserir Registo" />
        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Origens")'">Voltar</button>
    </div>
End Using

