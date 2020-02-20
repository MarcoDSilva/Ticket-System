@ModelType TicketSystem.Problema
@Code
    ViewData("Title") = "Criar problema"
End Code


<h4>Inserir novo tipo de problema</h4>
@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <div class="form-group">
            <p>
                @Html.LabelFor(Function(ModelProb) ModelProb.descricao)
                @Html.TextBoxFor(Function(ModelProb) ModelProb.descricao, New With {.class = "form-control"})
            </p>
        </div>
        <input type="submit" name="submit" value="inserir registo" class="btn btn-primary" />
        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Problemas")'">
            Voltar
        </button>
    </div>

End Using




