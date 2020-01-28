@ModelType TicketSystem.Tecnico
@Code
    ViewData("Title") = "EditarTecnico"
    Dim idParaApagar = Model.ID_tecnico
End Code

<h2>Editar técnico</h2>

<div class="form-horizontal">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(modelTec) modelTec.ID_tecnico)

        'form
        @<div class="form-group">
            <div class="col-md-12">
                <p>
                    @Html.LabelFor(Function(modelTec) modelTec.nome)
                    @Html.TextBoxFor(Function(modelTec) modelTec.nome)
                    @Html.ValidationMessageFor(Function(modelTec) modelTec.nome, "", New With {.class = "text-danger"})
                </p>
                <p>
                    @Html.LabelFor(Function(modelTec) modelTec.email)
                    @Html.TextBoxFor(Function(modelTec) modelTec.email)
                    @Html.ValidationMessageFor(Function(modelTec) modelTec.email, "", New With {.class = "text-danger"})
                </p>
            </div>
        <input type="submit" value="Guardar" class="btn btn-success" />
    </div>

    End Using

</div>
