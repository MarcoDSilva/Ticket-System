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

<div id="estatisticasBasicasTickets" class="container">
    <div class="row">
        <div class="col-md-4 col-sm-2">
            <div class="icones_estatisticas">
                <img src="~/img/folder.svg" alt="" width="32" height="32" title="icon">
            </div>
            <div class="texto_estatistica">
                <label>Tickets totais: x</label>
            </div>
        </div>
        <div class="col-md-4 col-sm-2">
            <p>Número de tickets por concluir: x</p>
        </div>
        <div class="col-md-4 col-sm-2">
            <p>Número de tickets do mes actual: x</p>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4  col-sm-2">
            <p>Número de tickets finalizados: x</p>
        </div>
        <div class="col-md-4 col-sm-2">
            <p>Número de tickets do ano actual: x</p>
        </div>
        <div class="col-md-4 col-sm-2">
            <p>Número de tickets novos: x</p>
        </div>
    </div>
</div>

<div id="ticketsIndex">
    <table class="table table-sm table-striped table-hover table-responsive">
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

