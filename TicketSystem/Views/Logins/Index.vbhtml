@ModelType TicketSystem.Login
@Code
    ViewData("Title") = "Login Page"

    'Dim sessao = Session("login")
    Dim sessao = Nothing
    Dim chaveSessao = Session("key")
End Code

<h2>Logins</h2>

<div class="container-fluid">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        If IsNothing(sessao) Then
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
            If sessao.Equals("ERRO") Then
                @<div class="form-group">
                    <div class="col-form-label">Email: </div> <br />
                    <input type="text" class="form-control" size="10" />
                    <div class="col-form-label">Password:</div>    <br />
                    <input type="password" class="form-control" size="10" />
                    <input type="submit" class="btn btn-secondary" value="login" />
                    <label class="text-danger">Password ou utilizador errado</label>
                </div>
            Else
                @<p>Sessão tem valor e é @Session("login").ToString()</p>

                If chaveSessao.Equals(1) Then
                    @<p>O seu cargo é administrador!</p>
                Else
                    @<p>O seu cargo é técnico ou utilizador</p>
                End If
            End If
        End If
    End Using

</div>