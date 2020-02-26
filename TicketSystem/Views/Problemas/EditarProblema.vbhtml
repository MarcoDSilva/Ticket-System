@ModelType TicketSystem.Problema
@Code
    ViewData("Title") = "Editar problema"
    Dim idParaApagar = Model.ID_problema
End Code

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    'form da view fica abaixo desta div
    @<div class="container-fluid">

        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(Modelprob) Modelprob.ID_problema)
        <div class="row" style="padding:10px;">
            <div class="col">
                <h4 class="font-italic font-weight-bold">Problema</h4>
            </div>
            <div class="col">
                <h4 class="text-center font-italic font-weight-bold">Edição</h4>
            </div>
        </div>
        <!-- elemento onde o problema é editado e submissão do mesmo -->
        <div class="row">
            <div class="col">
                <section>
                    @Html.LabelFor(Function(Modelprob) Modelprob.descricao)
                    @Html.EditorFor(Function(Modelprob) Modelprob.descricao, New With {.HtmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(Modelprob) Modelprob.descricao, "", New With {.class = "text-danger"})
                </section>
            </div>

            <div id="btnsEditarTickets" class="col">
                <ul class="listaBtns">
                    <li>
                        <input type="submit" value="Guardar" class="btn btn-success" />
                    </li>
                    <li>
                        <button type="button" class="btn btn-primary btn-danger" data-toggle="modal" data-target="#verificaModal">
                            Apagar
                        </button>
                    </li>

                    <li>
                        <button type="button" class="btn btn-info" onclick="location.href='@Url.Action("CriaProblema", "Problemas")'">
                            Novo
                        </button>
                    </li>

                    <li>
                        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Problemas")'">
                            Voltar
                        </button>
                    </li>

                </ul>
            </div>
        </div>

        <!-- butões com as operações respectivas do formulário de edição -->
        <div id="editaProblemas" class="form-group">
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

