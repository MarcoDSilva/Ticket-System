@ModelType TicketSystem.Cliente
@Code
    ViewData("Title") = "Criação De Cliente"
End Code




<h4>Criação de cliente</h4>
@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @<div class="form-group">
        <p>
            @Html.LabelFor(Function(modelCli) modelCli.nome, New With {.class = "form-check-label"})
            @Html.TextBoxFor(Function(modelCli) modelCli.nome, New With {.class = "form-control"})
        </p>
        <p>
            @Html.LabelFor(Function(modelCli) modelCli.contacto, New With {.class = "form-check-label"})
            @Html.TextBoxFor(Function(modelCli) modelCli.contacto, New With {.class = "form-control"})
        </p>
        <p>
            @Html.LabelFor(Function(modelCli) modelCli.email, New With {.class = "form-check-label"})
            @Html.TextBoxFor(Function(modelCli) modelCli.email, New With {.class = "form-control"})
        </p>
        <p>
            @Html.LabelFor(Function(modelCli) modelCli.empresa, New With {.class = "form-check-label"})
            @Html.TextBoxFor(Function(modelCli) modelCli.empresa, New With {.class = "form-control"})
        </p>
        <p>
            @Html.LabelFor(Function(modelCli) modelCli.ID_utilizador, New With {.class = "form-check-label"})
            @Html.DropDownList("ID_utilizador", DirectCast(ViewBag.utilizadores, SelectList), New With {.class = "form-control"})
            <button type="button" class="btn btn-secondary btn-sm" onclick="location.href='#'">Criar utilizador</button>

        </p>
        <input type="submit" class="btn btn-primary" value="Enviar" />
        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Clientes")'">
            Voltar
        </button>
    </div>

End Using


