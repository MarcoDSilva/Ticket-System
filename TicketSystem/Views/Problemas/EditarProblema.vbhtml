@ModelType TicketSystem.Problema
@Code
    ViewData("Title") = "EditarProblema"
    Dim idParaApagar = Model.ID_problema
    Dim confirmaApagar = False
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
        </dl>
    </div>
End Using


<div id="editaProblemas">
    <button type="button" class="btn btn-primary btn-danger" data-toggle="modal" data-target="#verificaModal">
        Apagar
    </button>
    <button type="button" class="btn btn-success" onclick="location.href='@Url.Action("CriaProblema", "Problemas")'">
        Novo Registo
    </button>
    <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Problemas")'">
        Voltar
    </button>
</div>

<!-- Modal -->
<div class="modal fade" id="verificaModal" tabindex="-1" role="dialog" aria-labelledby="modalApagar" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="modalApagar">Confirmação</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">Pretende mesmo apagar este problema? Esta operação não é reversivel!</div>
            <div class="modal-footer">
                <button type="button" class="btn btn-primary" data-dismiss="modal"
                        onclick="location.href =
                        '@Url.Action("ConfirmaApaga", "Problemas", New With {.ID_problema = idParaApagar})'">
                    Apagar
                </button>
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>