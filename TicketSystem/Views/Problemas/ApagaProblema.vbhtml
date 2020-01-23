@ModelType TicketSystem.Problema
@Code
    ViewData("Title") = "ApagaProblema"
    Dim idParaApagar = Model.ID_problema
    Dim apagar As String
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

                <form action="/" method="post">
                    <input type="submit" value="apagar" class="btn btn-default" OnClientClick="alert('Do you want to cancel ?');" />
                    @Html.ActionLink("Voltar atrás", "Index")
                </form>
            </dd>
        </dl>
    </div>
End Using


