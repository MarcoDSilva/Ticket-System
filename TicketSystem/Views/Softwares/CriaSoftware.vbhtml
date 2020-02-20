@ModelType TicketSystem.Software
@Code
    ViewData("Title") = "Criação de software"
End Code


<h4>Adição novo software</h4>
@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @<div class="form-horizontal">
        <div class="form-group">
            <p>
                @Html.LabelFor(Function(modelSoft) modelSoft.nome)
                @Html.TextBoxFor(Function(modelSoft) modelSoft.nome, New With {.class = "form-control"})
            </p>
        </div>
        <input type="submit" name="submit" value="Inserir" class="btn btn-primary" />
        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Softwares")'">
            Voltar
        </button>
    </div>
End Using



