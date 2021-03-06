﻿@ModelType TicketSystem.Tecnico
@Code
    ViewData("Title") = "Login Page"
End Code


@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @<div id="menuLogin">
        @If Session("Login") = 0 And Session("LoginErrado") = 0 Then
            @<div class="container form-group" id="menuLoginForm">
                <h2>Bem vindo!</h2>
                <div class="form-group row">
                    @Html.LabelFor(Function(log) log.email, New With {.class = "col-sm-2 col-form-label"})
                    @Html.TextBoxFor(Function(log) log.email, New With {.class = "form-control loginForm", .placeholder = "Email"})
                </div>
                <div class="form-group row">
                    @Html.LabelFor(Function(log) log.password, New With {.class = "col-sm-2 col-form-label"})
                    @Html.EditorFor(Function(log) log.password, New With {.HtmlAttributes = New With {.class = "form-control loginForm", .placeholder = "Password"}})<br />
                </div>
                <input type="submit" class="btn btn-secondary" value="Login" />
                @Html.ActionLink("Recuperar Password", "RecuperarPassword", Nothing, htmlAttributes:=New With {.class = "btn btn-warning"})
            </div>
        Else
            If Session("LoginErrado") = 1 Then
                @<div class="container form-group" id="menuLoginForm">
                    <h2>Bem vindo!</h2>
                    <div class="form-group row">
                        @Html.LabelFor(Function(log) log.email, New With {.class = "col-sm-2 col-form-label"})
                        @Html.TextBoxFor(Function(log) log.email, New With {.class = "form-control", .placeholder = "Email"})
                    </div>
                    <div class="form-group row">
                        @Html.LabelFor(Function(log) log.password, New With {.class = "col-sm-2 col-form-label"})
                        @Html.EditorFor(Function(log) log.password, New With {.HtmlAttributes = New With {.class = "form-control", .placeholder = "Password"}})<br />
                    </div>
                    <input type="submit" class="btn btn-secondary" value="Login" />
                    @Html.ActionLink("Recuperar Password", "RecuperarPassword", Nothing, htmlAttributes:=New With {.class = "btn btn-warning"})
                    <small id="erro" class="form-text text-danger">Password ou utilizador errado</small>
                </div>
            Else
                Response.Redirect("~/Home/Index")
            End If
        End If
    </div>

End Using