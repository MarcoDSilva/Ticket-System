@ModelType TicketSystem.Login
@Code
    ViewData("Title") = "Login Page"

    Dim administrador = Session("Administrador")
    Dim loginEfetuado = Session("Login")
    Dim loginFalhado = Session("LoginErrado")
    Dim emailUtilizador = Session("Email")
End Code

<h2>Logins</h2>

<div class="container-fluid">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        If loginEfetuado = 0 And loginFalhado = 0 Then
            @<div class="form-group">
                @Html.LabelFor(Function(log) log.email, New With {.class = "form-label"})
                @Html.TextBoxFor(Function(log) log.email, New With {.class = "form-control"})

                @Html.LabelFor(Function(log) log.password, New With {.class = "form-label"})
                @Html.EditorFor(Function(log) log.password, New With {.HtmlAttributes = New With {.class = "form-control"}})<br />
                <input type="submit" class="btn btn-secondary" value="login" />
                <button type="button" class="btn btn-primary">Novo Registo</button>
                <button type="button" class="btn btn-warning">Recuperar Password</button>
            </div>
        Else
            If loginFalhado = 1 Then
                @<div class="form-group">
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
                @<p>Bem vindo @emailUtilizador</p>

                If administrador = 1 Then
                    @<p>O seu cargo é administrador!</p>
                Else
                    @<p>O seu cargo é técnico ou utilizador</p>
                End If
            End If
        End If
    End Using

</div>