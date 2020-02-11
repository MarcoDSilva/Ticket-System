@ModelType TicketSystem.Login
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
                <button type="button" class="btn btn-primary">Novo Registo</button>
                <button type="button" class="btn btn-warning">Recuperar Password</button>
            </div>
        Else
            If Session("LoginErrado") = 1 Then
                @<div class="form-group justify-content-center">
                    @Html.LabelFor(Function(log) log.email, New With {.class = "form-label"})
                    @Html.TextBoxFor(Function(log) log.email, New With {.class = "form-control"})

                    @Html.LabelFor(Function(log) log.password, New With {.class = "form-label"})
                    @Html.EditorFor(Function(log) log.password, New With {.HtmlAttributes = New With {.class = "form-control"}})<br />
                    <input type="submit" class="btn btn-secondary" value="login" />
                    <button type="button" class="btn btn-primary">Novo Registo</button>
                    <button type="button" class="btn btn-warning">Recuperar Password</button>
                    <label class="text-danger">Password ou utilizador errado</label>
                </div>
            Else
                @<p>Bem vindo @Session("Nome")</p>

                If Session("Administrador") = 1 Then
                    @<p>O seu cargo é administrador!</p>
                Else
                    @<p>O seu cargo é técnico ou utilizador</p>
                End If
            End If
        End If
    End Using

</div>