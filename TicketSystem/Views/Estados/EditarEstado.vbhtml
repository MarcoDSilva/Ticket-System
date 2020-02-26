@ModelType TicketSystem.Estado
@Code
    ViewData("Title") = "Edição de estados"
    Dim idParaApagar = Model.ID_estado
End Code


@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(modelEst) modelEst.ID_estado)

    @<div class="container container-fluid" style="margin-top:15px;">

        <!-- form onde o estado será editado-->    
        <div class="row">
            <div class="col">
                <h4 class="font-italic font-weight-bold">Estado</h4>

                <section>
                    @Html.LabelFor(Function(modelEst) modelEst.descricao)
                    @Html.EditorFor(Function(modelEst) modelEst.descricao, New With {.HtmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(modelEst) modelEst.descricao, "", New With {.class = "text-danger"})
                </section>
            </div>

            <div id="btnsEditarTickets" class="col">
                <h4 class="text-center font-italic font-weight-bold">Edição</h4>

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
                        <button type="button" class="btn btn-info" onclick="location.href='@Url.Action("CriaEstado", "Estados")'">
                            Novo
                        </button>
                    </li>
                    <li>
                        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Estados")'">
                            Voltar
                        </button>
                    </li>
                </ul>
            </div>
        </div>

        <!-- butões com as operações respectivas do formulário de edição -->
        <div id="editaEstados" class="form-group">

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
                        '@Url.Action("ApagarEstado", "Estados", New With {.ID_estado = idParaApagar})'">
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
