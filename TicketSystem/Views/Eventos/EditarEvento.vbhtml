@ModelType TicketSystem.VM_EventoTecnico
@Code
    ViewData("Title") = "EditarEvento"

    Dim dataFinal As String
    Dim dataInicial = Model.dataAbertura.ToString("yyyy-MM-dd")

    If IsNothing(Model.dataFecho) Then
        dataFinal = ""
    Else
        dataFinal = Model.dataFecho.Value.ToString("yyyy-MM-dd")
    End If

End Code

<h2>Edição de evento</h2>

<div class="form-group">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken

        @<div class="col-form-label">
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(modelEv) modelEv.ID_evento)

    <!-- form edição -->
    <div class="form-group">
        <div class="col-md-12">
            <p>
                @Html.LabelFor(Function(modelEv) modelEv.descricao, New With {.class = "form-check-label"})
                @Html.EditorFor(Function(modelEv) modelEv.descricao, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(modelEv) modelEv.descricao, "", New With {.class = "text-danger"})
            </p>
            <p>
                @Html.LabelFor(Function(modelEv) modelEv.ID_tecnico, New With {.class = "form-check-label"})
                @Html.DropDownList("ID_tecnico", DirectCast(ViewBag.tecnico, SelectList), New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(modelEv) modelEv.ID_tecnico, "", New With {.class = "text-danger"})
            </p>
            <p>
                @Html.LabelFor(Function(modelEv) modelEv.dataAbertura, New With {.class = "form-check-label"})
                <input type="date" name="dataAbertura" value="@dataInicial" id="dataAbertura" class="form-control" />
                @Html.ValidationMessageFor(Function(modelEv) modelEv.dataAbertura, "", New With {.class = "text-danger"})
            </p>
            <p>
                @Html.LabelFor(Function(modelEv) modelEv.dataFecho, New With {.class = "form-check-label"})
                <input type="date" name="dataFecho" value="@dataFinal" id="dataFecho" class="form-control" />
                @Html.ValidationMessageFor(Function(modelEv) modelEv.dataFecho, "", New With {.class = "text-danger"})
            </p>
            <input type="submit" class="btn btn-success" value="Guardar" name="Enviar" />
        </div>
    </div>


    <!-- butões com as operações respectivas do formulário de edição -->
    <div id="editaEvento" class="form-group">
        <button type="button" class="btn btn-primary btn-danger" data-toggle="modal" data-target="#verificaModal">
            Apagar
        </button>
        <button type="button" class="btn btn-info" onclick="location.href='@Url.Action("CriaEvento", "Eventos")'">
            Novo
        </button>
        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Eventos")'">
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
                                onclick="location.href ='@Url.Action("ApagarEvento", "Eventos", New With {.ID_evento = Model.ID_evento})'">
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
</div>
