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


    <h2>@DateTime.Now.ToLongDateString()</h2>
    <p>@mensagem @Session("Nome")</p>

    @If Session("Administrador") = 1 Then
        @<p>O seu cargo é administrador!</p>
    Else
        @<p>O seu cargo é técnico/a</p>
    End If

    @If Session("Inativo") = 1 Then
        @<p>A sua conta esta desactivada de momento. Por favor contacte o administrador do software.</p>
    End If

    <div id="ticketsIndex" class="jumbotron">
        <table class="table table-sm table-striped table-hover">
            <tr class="thead-dark">
                <th>ID</th>
                <th>Tecnico</th>
                <th>cliente</th>
                <th>software</th>
                <th>problema</th>
                <th>descrição</th>
                <th>estado</th>
            </tr>
            <tr>
                <td>11</td>
                <td>Lorem </td>
                <td>ipsum </td>
                <td>dolore</td>
                <td>sit</td>
                <td>amet</td>
                <td>consectetur</td>
            </tr>
            <tr>
                <td>411</td>
                <td>Lorem </td>
                <td>ipsum </td>
                <td>dolore</td>
                <td>sit</td>
                <td>amet</td>
                <td>consectetur</td>
            </tr>
            <caption>Tickets Abertos</caption>
        </table>

    </div>

