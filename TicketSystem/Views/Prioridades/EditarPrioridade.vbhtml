@ModelType TicketSystem.Prioridade
@Code
    ViewData("Title") = "Edição de prioridades"
    Dim idParaApagar = Model.ID_prioridade
End Code

@Using (Html.BeginForm)
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(modelPrio) modelPrio.ID_prioridade)

    'form da view
    @<div class="container container-fluid">
        <!-- elementos de edição-->
        <div class="row" style="padding:10px;">
            <div class="col">
                <h4 class="font-italic font-weight-bold">Prioridade</h4>
            </div>
            <div class="col">
                <h4 class="text-center font-italic font-weight-bold">Edição</h4>
            </div>
        </div>

        <!-- elemento onde a prioridade é editada e submissão da mesmo -->
        <div class="row" id="editaPrioridade">

            <!-- dados do form -->
            <div class="col">
                <section>
                    @Html.LabelFor(Function(modelPrio) modelPrio.descricao)
                    @Html.EditorFor(Function(modelPrio) modelPrio.descricao, New With {.HtmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(modelPrio) modelPrio.descricao, "", New With {.class = "text-danger"})
                </section>
            </div>

            <!-- botões crud-->
            <div id="btnsEditarTickets" class="col">
                <ul class="listaBtns">
                    <li><input type="submit" value="Guardar" class="btn btn-success" /></li>
                    <li>
                        <button type="button" class="btn btn-primary btn-danger" data-toggle="modal" data-target="#verificaModal">
                            Apagar
                        </button>
                    </li>
                    <li>
                        <button type="button" class="btn btn-info" onclick="location.href='@Url.Action("CriaPrioridade", "Prioridades")'">
                            Novo
                        </button>
                    </li>
                    <li>
                        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Prioridades")'">
                            Voltar
                        </button>
                    </li>
                </ul>
            </div>
        </div>



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
                                onclick="location.href ='@Url.Action("ApagarPrioridade", "Prioridades", New With {.ID_prioridade = idParaApagar})'">
                            Apagar
                        </button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
End Using

