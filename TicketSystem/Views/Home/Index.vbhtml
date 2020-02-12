@Code
    ViewData("Title") = "Menu principal"
    Dim dataDia As DateTime = DateTime.Now
    Dim mensagem As String
    If dataDia.Hour > 6 And dataDia.Hour < 12 Then
        mensagem = "Bom dia"
    Else
        If dataDia.Hour > 12 And dataDia.Hour < 18 Then
            mensagem = "Boa tarde"
        Else
            mensagem = "Boa Noite"
        End If
    End If
End Code


<h2>Home</h2>
<div class="container-fluid">

    <p>@mensagem @Session("Nome")</p>

    @If Session("Administrador") = 1 Then
        @<p>O seu cargo é administrador!</p>
    Else
        @<p>O seu cargo é técnico ou utilizador</p>
    End If

</div>


