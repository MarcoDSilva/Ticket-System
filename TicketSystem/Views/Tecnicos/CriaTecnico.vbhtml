@ModelType TicketSystem.Tecnico

@Code
    ViewData("Title") = "CriaTecnico"
End Code

<h2>Adicionar novo Tecnico</h2>

<div class="form-horizontal">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-group">
    <p>
        @Html.LabelFor(Function(modelTec) modelTec.nome)
        @Html.TextBoxFor(Function(modelTec) modelTec.nome, New With {.class = "form-control"})
    </p>
    <p>
        @Html.LabelFor(Function(modelTec) modelTec.email)
        @Html.TextBoxFor(Function(modelTec) modelTec.email, New With {.class = "form-control"})
    </p>
    <input type="submit" class="btn btn-primary" value="Inserir Registo" />
    <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Tecnicos")'">
        Voltar
    </button>
</div>
    End Using
</div>

