@ModelType TicketSystem.VM_TecnicoRole
@Code
    ViewData("Title") = "Editar técnico"
    Dim idParaApagar = Model.ID_tecnico
End Code


@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(modelTec) modelTec.ID_tecnico)

    'form
    @<div class="container container-fluid" style="padding-top:15px;">
        
        <!--dados -->
        <div class="row">
            <div class="col" id="editaTecnico">
                <h4 class="font-italic font-weight-bold">Tecnicos</h4>

                <section>
                    @Html.LabelFor(Function(modelTec) modelTec.nome)
                    @Html.EditorFor(Function(modelTec) modelTec.nome, New With {.HtmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(modelTec) modelTec.nome, "", New With {.class = "text-danger"})
                </section>
                <section>
                    @Html.LabelFor(Function(modelTec) modelTec.email)
                    @Html.EditorFor(Function(modelTec) modelTec.email, New With {.HtmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(modelTec) modelTec.email, "", New With {.class = "text-danger"})
                </section>
                <section>
                    @Html.LabelFor(Function(modelTec) modelTec.ID_role)
                    @Html.DropDownList("ID_role", DirectCast(ViewBag.roles, SelectList), New With {.class = "form-control"})
                </section>
                @If Session("EmailEditarExiste") = 1 Then
                    @<small id="erro" class="form-text text-danger">Email já existente na base de dados!</small>
                End If
            </div>

            <!-- butões CRUD -->
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
                        <button type="button" class="btn btn-info" onclick="location.href='@Url.Action("CriaTecnico", "Tecnicos")'">
                            Novo
                        </button>
                    </li>
                    <li>
                        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Tecnicos")'">
                            Voltar
                        </button>
                    </li>
                </ul>
            </div>
        </div>
    </div>
End Using

<!-- butões com as operações respectivas do formulário de edição -->
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

