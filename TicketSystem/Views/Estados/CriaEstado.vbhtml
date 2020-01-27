@ModelType TicketSystem.Estado
@Code
    ViewData("Title") = "CriaEstado"
End Code

<h2>Inserir novo estado de resolução</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <div class="form-group">
            <p>
                @Html.LabelFor(Function(modelEst) Model.descricao)
                @Html.TextBoxFor(Function(modelEst) Model.descricao)
            </p>
        </div>
        <input type="submit" name="submit" value="inserir registo" class="btn btn-primary" />
        <button type="button" class="btn btn-default" onclick="location.href='@Url.Action("Index", "Estados")'">
            Voltar
        </button>
    </div>
End Using
