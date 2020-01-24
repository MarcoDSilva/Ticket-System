@ModelType TicketSystem.Problema
@Code
    ViewData("Title") = "ApagaProblema"
    Dim idParaApagar = Model.ID_problema

End Code

<h2>Confirmação de apagar</h2>

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
            <dt>Confirma que quer apagar este registo?</dt>
            <dd>
                    @Html.ActionLink("Apagar definitivamente", "ConfirmaApaga", New With {.ID_problema = idParaApagar})
                    @Html.ActionLink("Voltar atrás", "Index")               
            </dd>
        </dl>
    </div>


End Using


