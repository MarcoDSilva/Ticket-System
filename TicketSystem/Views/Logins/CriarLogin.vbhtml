@ModelType TicketSystem.Login
@Code
    ViewData("Title") = "Criação de login"
End Code

    <div class="container-fluid align-self-center">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @Html.HiddenFor(Function(log) log.ID_login)

            @<div class="container">
                <h2>Novo login</h2>

                @If Session("NovoLogin") = 0 Then
                    @<div class="container-fluid form-group">
                        <div class="form-group">
                            @Html.LabelFor(Function(log) log.email, New With {.class = "form-check-label"})
                            @Html.TextBoxFor(Function(log) log.email, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(log) log.email, "", New With {.class = "text-danger"})
                        </div>
                        <div Class="form-group">
                            @Html.LabelFor(Function(log) log.password, New With {.class = "form-check-label"})
                            @Html.TextBoxFor(Function(log) log.password, New With {.class = "form-control", .type = "password"})
                            @Html.ValidationMessageFor(Function(log) log.password, "", New With {.class = "text-danger"})
                        </div>
                        <input type="submit" class="btn btn-primary" value="Enviar" />
                    </div>
                End If

            </div>
        End Using



    </div>