@Code
    ViewData("Title") = "CriarLogin"

    If Session("Administrador") <> 1 Then
        Response.Redirect("~/Home/Index")
    End If
End Code

<h2>Criar Novo Técnico</h2>

