@Code
    ViewData("Title") = "Recuperar Password"
End Code

<div class="container-fluid">

    <h2>Recuperar Password</h2>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        @If Session("PasswordResetada") = 0 Then
            @<div class="form-group form-inline">
                @Html.TextBox("email", "", htmlAttributes:=New With {.class = "form-control", .type = "email",
                                                                                        .placeholder = "Introduza email"})
                <input type="submit" value="Enviar" class="btn btn-primary" />

                @If Session("RecuperarPassword") = 1 Then
                    @<small id="erro" class="form-text text-danger">Email não introduzido ou não existente na base de dados</small>
                End If
            </div>
        Else
            @<p id="succedido" class="form-text text-success">Password enviada para o endereço de email indicado.</p>
            @<p class="form-text text-danger">Funcionalidade não implementada, só a verificação</p>
        End If
    End Using
</div>
