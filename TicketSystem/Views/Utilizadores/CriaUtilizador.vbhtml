@ModelType TicketSystem.VM_UtilizadorCliente
@Code
    ViewData("Title") = "CriaUtilizador"
End Code

<h2>Criação de Utilizador</h2>


<div class="form-group">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        @<div class="form-group">
            <p>
                @Html.LabelFor(Function(modelUtil) modelUtil.nome, New With {.class = "form-check-label"})
                @Html.TextBoxFor(Function(modelUtil) modelUtil.nome, New With {.class = "form-control"})
            </p>
            <p>
                @Html.LabelFor(Function(modelUtil) modelUtil.contacto, New With {.class = "form-check-label"})
                @Html.TextBoxFor(Function(modelUtil) modelUtil.contacto, New With {.class = "form-control"})
            </p>
            <p>
                @Html.LabelFor(Function(modelUtil) modelUtil.email, New With {.class = "form-check-label"})
                @Html.TextBoxFor(Function(modelUtil) modelUtil.email, New With {.class = "form-control"})
            </p>
            <p>
                @Html.LabelFor(Function(modelUtil) modelUtil.ID_cliente, New With {.Class = "form-check-label"})
                @Html.DropDownList("ID_cliente", DirectCast(ViewBag.clientes, SelectList), New With {.class = "form-control"})

                <button type="button" class="btn btn-secondary btn-sm" onclick="location.href='#'">Criar utilizador</button>
            </p>
            <input type="submit" class="btn btn-primary" value="Enviar" />
            <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Utilizadores")'">
                Voltar
            </button>
        </div>

    End Using


</div>
