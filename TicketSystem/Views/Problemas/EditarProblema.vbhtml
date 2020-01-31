@ModelType TicketSystem.Problema
@Code
    ViewData("Title") = "EditarProblema"
    Dim idParaApagar = Model.ID_problema
End Code

<h2>Tipos de Problema</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    'form da view fica abaixo desta div
    @<div class="form-horizontal">
        <h4>Modo de edição: </h4>
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(Modelprob) Modelprob.ID_problema)

        <!-- elemento onde o problema é editado e submissão do mesmo -->
        <div class="form-group">
            <div class="col-md-12">
                @Html.LabelFor(Function(Modelprob) Modelprob.descricao)
                @Html.EditorFor(Function(Modelprob) Modelprob.descricao, New With {.HtmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(Modelprob) Modelprob.descricao, "", New With {.class = "text-danger"})
                <input type="submit" value="Guardar" class="btn btn-success" />
            </div>
        </div>

        <!-- butões com as operações respectivas do formulário de edição -->
        <div id="editaProblemas" class="form-group">
            <button type="button" class="btn btn-primary btn-danger" data-toggle="modal" data-target="#verificaModal">
                Apagar
            </button>
            <button type="button" class="btn btn-info" onclick="location.href='@Url.Action("CriaProblema", "Problemas")'">
                Novo
            </button>
            <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Problemas")'">
                Voltar
            </button>

            <!-- Opções do Modal para confirmação do apagamento do registo -->
            <div class="modal fade" id="verificaModal" tabindex="-1" role="dialog" aria-labelledby="modalApagar" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
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
        </div>
    </div>
End Using

