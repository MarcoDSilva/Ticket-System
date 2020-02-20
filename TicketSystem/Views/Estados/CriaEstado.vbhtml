@ModelType TicketSystem.Estado
@Code
    ViewData("Title") = "Criação de estados"
End Code


<div class="container">
    <h4>Inserir novo estado de resolução</h4>

    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-horizontal">
            <div class="form-group">
                <p>
                    @Html.LabelFor(Function(modelEst) Model.descricao, New With {.class = "form-check-label"})
                    @Html.TextBoxFor(Function(modelEst) Model.descricao, New With {.class = "form-control"})
                </p>
            </div>
            <input type="submit" name="submit" value="inserir registo" class="btn btn-primary" />
            <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Estados")'">
                Voltar
            </button>
        </div>
    End Using

</div>