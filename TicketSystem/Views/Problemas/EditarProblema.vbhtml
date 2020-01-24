@ModelType TicketSystem.Problema
@Code
    ViewData("Title") = "EditarProblema"
    Dim idParaApagar = Model.ID_problema
End Code

<h2>Edição de Problema</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @<div class="form-horizontal">
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
            <dt>Edição</dt>
            <dd>
                @Html.ActionLink("Apagar", "ApagaProblema", New With {.ID_problema = idParaApagar}) |
                @Html.ActionLink("Novo Registo", "CriaProblema") |
                @Html.ActionLink("Voltar para o inicio", "Index")
            </dd>
        </dl>
    </div>
End Using
