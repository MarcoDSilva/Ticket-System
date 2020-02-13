@Code
    ViewData("Title") = "Menu principal"
    Dim dataDia = DateTime.Now.Hour
    Dim mensagem As String
    If Convert.ToInt16(dataDia) >= 6 And Convert.ToInt16(dataDia) <= 12 Then
        mensagem = "Bom dia"
    Else
        If Convert.ToInt16(dataDia) > 12 And Convert.ToInt16(dataDia) <= 18 Then
            mensagem = "Boa tarde"
        Else
            mensagem = "Boa Noite"
        End If
    End If
End Code

<div class="container-fluid">
    <h2>Home</h2>
    <p>@mensagem @Session("Nome")</p>

    @If Session("Administrador") = 1 Then
        @<p>O seu cargo é administrador!</p>
    Else
        @<p>O seu cargo é técnico/a</p>
    End If

    @If Session("Inativo") = 1 Then
        @<p>A sua conta esta desactivada de momento. Por favor contacte o administrador do software.</p>
    End If

</div>


