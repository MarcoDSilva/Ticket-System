@ModelType TicketSystem.Problema
@Code
    ViewData("Title") = "EditarProblema"
End Code

<h2>Edição de Problema</h2>

<div>
    <h4>Problema teste</h4>

    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(Modelprob) Modelprob.ID_problema)
        </dt>
            <dd>
                @Html.DisplayFor(Function(Modelprob) Modelprob.ID_problema)
            </dd>
        <dt>
            @Html.DisplayFor(Function(Modelprob) Modelprob.descricao)
        </dt>
            <dd>
                @Html.DisplayFor(Function(Modelprob) Modelprob.descricao)
            </dd>
        
        
    </dl>

</div>
