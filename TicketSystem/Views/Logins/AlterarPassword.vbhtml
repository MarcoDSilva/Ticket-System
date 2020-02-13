@ModelType TicketSystem.Tecnico
@Code
    ViewData("Title") = "Alterar Password"
End Code

<div class="container-fluid align-self-center">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(modelTec) modelTec.ID_tecnico)

        @<div class="form-group">
            <h2>Alteração de password</h2>
                <div class="form-group">
                    @Html.Label("Introduza password antiga:", New With {.class = "form-text"})
                    @Html.Editor("passwordAntiga", New With {.HtmlAttributes = New With {.class = "form-control", .type = "password"}})
                    @Html.ValidationMessageFor(Function(modelTec) modelTec.password, "", New With {.class = "text-danger"})
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(modelTec) modelTec.password)
                    @Html.EditorFor(Function(modelTec) modelTec.password, New With {.HtmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(modelTec) modelTec.password, "", New With {.class = "text-danger"})
                </div>

                @If Session("PasswordErrada") = 1 Then
                    @<small id="erro" class="form-text text-danger">Password introduzida não é igual à actual!</small>
                End If
            <input type="submit" value="Guardar" class="btn btn-success" />
        </div>
    End Using
</div>