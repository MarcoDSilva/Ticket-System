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

<div class="container">
    <h2>@DateTime.Now.ToLongDateString()</h2>
    <p>@mensagem @Session("Nome")</p>

    @If Session("Administrador") = 1 Then
        @<p>O seu cargo é administrador!</p>
    Else
        @<p>O seu cargo é técnico/a</p>
    End If
</div>


@If Session("Inativo") = 1 Then
    @<p>A sua conta esta desactivada de momento. Por favor contacte o administrador do software.</p>
Else
    @<div class="container">
        <div id="estatisticasBasicasTickets">

            <div class="estatisticasFlexItem">
                <img src="~/img/folder.svg" alt="" width="32" height="32" title="icon">
                <Label> Total de tickets: @ViewBag.totalTickets</Label>
            </div>

            <div class="estatisticasFlexItem">
                <img src="~/img/alert-square.svg" alt="" width="32" height="32" title="icon">
                <p> Tickets não finalizados: @ViewBag.ticketsNaoConcluidos</p>
            </div>

            <div class="estatisticasFlexItem">
                <img src="~/img/envelope-open.svg" alt="" width="32" height="32" title="icon">
                <p> Abertos no Mês corrente: @ViewBag.ticketsAnoActual</p>
            </div>

            <div class="estatisticasFlexItem">
                <img src="~/img/envelope.svg" alt="" width="32" height="32" title="icon">
                <p> Tickets Resolvidos: @ViewBag.ticketsConcluidos</p>
            </div>

            <div class="estatisticasFlexItem">
                <img src="~/img/inbox-fill.svg" alt="" width="32" height="32" title="icon">
                <p> Tickets do ano corrente: @ViewBag.ticketsAnoActual</p>
            </div>

            <div class="estatisticasFlexItem">
                <img src="~/img/info.svg" alt="" width="32" height="32" title="icon">
                <p> Número de tickets novos: @ViewBag.ticketsNovos</p>
            </div>

        </div>

        <!--tickets abertos -->
        <div id="ticketsIndex">
            <table class="table table-striped table-hover table-sm table-responsive">
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

        <!--eventos atribuidos-->
        <div id="ticketsIndex">
            <table class="table table-striped table-hover table-sm table-responsive">
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
                <caption>Eventos atribuidos ao utilizador</caption>
            </table>

        </div>
    </div>


End If


