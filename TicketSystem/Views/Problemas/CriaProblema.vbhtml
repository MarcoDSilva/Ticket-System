﻿@ModelType TicketSystem.Problema
@Code
    ViewData("Title") = "CriaProblema"
End Code

<h2>Inserir novo tipo de problema</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">

    <div class="form-group">
        <p>
            <label>Descrição</label>
            @Html.TextBox("descricao")
        </p>
    </div>
    <input type="submit" name="submit" value="inserir registo" class="btn btn-primary" />
    <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Problemas")'">
        Voltar
    </button>
</div>

End Using
