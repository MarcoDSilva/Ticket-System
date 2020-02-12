@ModelType TicketSystem.Login
@Code
    ViewData("Title") = "Criação de login"
End Code

<div class="container-fluid align-self-center">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        @Html.HiddenFor(Function(log) log.ID_login)

        @<div class="container">
            <h2>Novo login</h2>
            <div class="form-group">
                @Html.LabelFor(Function(log) log.email, New With {.class = "form-check-label"})
                @Html.TextBoxFor(Function(log) log.email, New With {.class = "form-control"})
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(log) log.password, New With {.class = "form-check-label"})
                @Html.TextBoxFor(Function(log) log.password, New With {.class = "form-control", .type = "password"})
            </div>
            <input type="submit" class="btn btn-primary" value="Enviar"/>
        </div>
    End Using



</div>