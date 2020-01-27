@ModelType TicketSystem.Estado
@Code
    ViewData("Title") = "EditarEstado"
    Dim idParaApagar = Model.ID_estado
End Code

<h2>Editar o tipo do estado</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()


    @<div class="form-horizontal">
        <h4>Modo de edição</h4>
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(modelEst) modelEst.ID_estado)

        <!-- form onde o estado será editado-->
        <div class="form-group">
            <div class="col-md-12">
                @Html.LabelFor(Function(modelEst) modelEst.descricao)
                @Html.EditorFor(Function(modelEst) modelEst.descricao, New With {.class = "class-control"})
                @Html.ValidationMessageFor(Function(modelEst) modelEst.descricao, "", New With {.class = "text-danger"})
                <input type="submit" value="Guardar" class="btn btn-success" />
            </div>
        </div>

        <!-- butões com as operações respectivas do formulário de edição -->
        <div id="editaEstados" class="form-group">
            <button type="button" class="btn btn-primary btn-danger" data-toggle="modal" data-target="#verificaModal">
                Apagar
            </button>
            <button type="button" class="btn btn-info" onclick="location.href='@Url.Action("CriaEstado", "Estados")'">
                Novo
            </button>
            <button type="button" class="btn btn-default" onclick="location.href='@Url.Action("Index", "Estados")'">
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
