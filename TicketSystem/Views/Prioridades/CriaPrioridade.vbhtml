@ModelType TicketSystem.Prioridade
@Code
    ViewData("Title") = "CriaPrioridade"
End Code

<h2>Criação de nova prioridade</h2>
@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <div class="form-group">
        <p>
            @Html.LabelFor(Function(modelPrio) modelPrio.descricao)
            @Html.TextBoxFor(Function(modelPrio) modelPrio.descricao, New With {.class = "form-control"})
        </p>
    </div>
    <input type="submit" value="Inserir Registo" class="btn btn-primary" />
    <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Prioridades")'">Voltar</button>
</div>
End Using

