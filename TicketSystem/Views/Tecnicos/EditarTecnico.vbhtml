@ModelType TicketSystem.Tecnico
@Code
    ViewData("Title") = "EditarTecnico"
    Dim idParaApagar = Model.ID_tecnico
End Code

<h2>Editar técnico</h2>

<div class="form-horizontal">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(modelTec) modelTec.ID_tecnico)

        'form
        @<div class="form-group">
            <div class="col-md-12">
                <p>
                    @Html.LabelFor(Function(modelTec) modelTec.nome)
                    @Html.TextBoxFor(Function(modelTec) modelTec.nome)
                    @Html.ValidationMessageFor(Function(modelTec) modelTec.nome, "", New With {.class = "text-danger"})
                </p>
                <p>
                    @Html.LabelFor(Function(modelTec) modelTec.email)
                    @Html.TextBoxFor(Function(modelTec) modelTec.email)
                    @Html.ValidationMessageFor(Function(modelTec) modelTec.email, "", New With {.class = "text-danger"})
                </p>
            </div>
            <input type="submit" value="Guardar" class="btn btn-success" />
        </div>
    End Using

    <!-- butões com as operações respectivas do formulário de edição -->
    <div id="editaTecnico" class="form-group">
        <button type="button" class="btn btn-primary btn-danger" data-toggle="modal" data-target="#verificaModal">
            Apagar
        </button>
        <button type="button" class="btn btn-info" onclick="location.href='@Url.Action("CriaTecnico", "Tecnicos")'">
            Novo
        </button>
        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Tecnicos")'">
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
                                onclick="location.href ='@Url.Action("ApagarTecnico", "Tecnicos", New With {.ID_tecnico = idParaApagar})'">
                            Apagar
                        </button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</div>
