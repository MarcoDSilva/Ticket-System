@ModelType TicketSystem.Tecnico
@Code
    ViewData("Title") = "Login Page"
End Code

<div class="container-fluid align-self-center">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        @<h2>Logins</h2>

        If Session("Login") = 0 And Session("LoginErrado") = 0 Then
            @<div class="form-group">
                <div class="form-group row">
                    @Html.LabelFor(Function(log) log.email, New With {.class = "col-sm-2 col-form-label"})
                    @Html.TextBoxFor(Function(log) log.email, New With {.class = "form-control", .placeholder = "Email"})
                </div>
                <div class="form-group row">
                    @Html.LabelFor(Function(log) log.password, New With {.class = "col-sm-2 col-form-label"})
                    @Html.EditorFor(Function(log) log.password, New With {.HtmlAttributes = New With {.class = "form-control", .placeholder = "Password"}})<br />
                </div>
                <input type="submit" class="btn btn-secondary" value="login" />
                <button type="button" class="btn btn-warning">Recuperar Password</button>
            </div>
        Else
            If Session("LoginErrado") = 1 Then
                @<div class="form-group justify-content-center">
                    <div class="form-group row">
                        @Html.LabelFor(Function(log) log.email, New With {.class = "col-sm-2 col-form-label"})
                        @Html.TextBoxFor(Function(log) log.email, New With {.class = "form-control", .placeholder = "Email"})
                    </div>
                    <div class="form-group row">
                        @Html.LabelFor(Function(log) log.password, New With {.class = "col-sm-2 col-form-label"})
                        @Html.EditorFor(Function(log) log.password, New With {.HtmlAttributes = New With {.class = "form-control", .placeholder = "Password"}})<br />
                    </div>
                    <input type="submit" class="btn btn-secondary" value="login" />
                    <button type="button" class="btn btn-warning">Recuperar Password</button>
                    <small id="erro" class="form-text text-danger">Password ou utilizador errado</small>
                </div>
            Else
                Response.Redirect("~/Home/Index")
            End If
        End If
    End Using

</div>