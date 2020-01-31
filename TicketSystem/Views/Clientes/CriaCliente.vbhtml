@ModelType TicketSystem.Cliente
@Code
    ViewData("Title") = "Criar cliente"
End Code

<h2>Criação de cliente</h2>

<div class="form-group">
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
                @Html.TextBoxFor(Function(modelCli) modelCli.ID_utilizador, New With {.class = "form-control"})
            </p>
            <input type="submit" class="btn btn-primary" value="Enviar" />
            <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Clientes")'">
                Voltar
            </button>
        </div>

    End Using


</div>

