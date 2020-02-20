@ModelType TicketSystem.VM_TecnicoRole

@Code
    ViewData("Title") = "Criação de técnico"
End Code

<h4>Adicionar novo Tecnico</h4>
@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

    @<div class="form-group">
        <p>
            @Html.LabelFor(Function(modelTec) modelTec.nome)
            @Html.TextBoxFor(Function(modelTec) modelTec.nome, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(modelTec) modelTec.nome, "", New With {.class = "text-danger"})
        </p>
        <p>
            @Html.LabelFor(Function(modelTec) modelTec.email)
            @Html.TextBoxFor(Function(modelTec) modelTec.email, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(modelTec) modelTec.email, "", New With {.class = "text-danger"})
        </p>
        <p>
            @Html.LabelFor(Function(modelTec) modelTec.ID_role)
            @Html.DropDownList("ID_role", DirectCast(ViewBag.roles, SelectList), New With {.class = "form-control"})
        </p>
        @If Session("EmailExiste") = 1 Then
            @<small id="erro" class="form-text text-danger">Email já existente na base de dados!</small>
        End If
        <input type="submit" class="btn btn-primary" value="Inserir Registo" />
        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Tecnicos")'">
            Voltar
        </button>
    </div>
End Using


