@ModelType TicketSystem.VM_UtilizadorCliente
@Code
    ViewData("Title") = "Edição de Utilizador"
End Code

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(Utilizador) Utilizador.ID_utilizador)

    @<div class="container container-fluid" style="padding-top:15px;">

        <!-- elemento onde a prioridade é editada e submissão da mesmo -->
        <div class="row" id="editaSoftware">
            <!-- dados do form -->
            <div class="col">
                <h4 class="font-italic font-weight-bold">Utilizadores</h4>

                <section>
                    @Html.LabelFor(Function(Utilizador) Utilizador.nome, New With {.class = "form-check-label"})
                    @Html.EditorFor(Function(Utilizador) Utilizador.nome, New With {.HtmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(Utilizador) Utilizador.nome, "", New With {.class = "text-danger"})
                </section>
                <section>
                    @Html.LabelFor(Function(Utilizador) Utilizador.contacto, New With {.class = "form-check-label"})
                    @Html.EditorFor(Function(Utilizador) Utilizador.contacto, New With {.HtmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(Utilizador) Utilizador.contacto, "", New With {.class = "text-danger"})
                </section>
                <section>
                    @Html.LabelFor(Function(Utilizador) Utilizador.email, New With {.class = "form-check-label"})
                    @Html.EditorFor(Function(Utilizador) Utilizador.email, New With {.HtmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(Utilizador) Utilizador.email, "", New With {.class = "text-danger"})
                </section>
                <section>
                    @Html.LabelFor(Function(Utilizador) Utilizador.ID_cliente, New With {.class = "form-check-label"})
                    @Html.DropDownList("ID_cliente", DirectCast(ViewBag.clientes, SelectList), New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(Utilizador) Utilizador.ID_cliente, "", New With {.class = "text-danger"})

                    <button type="button" class="btn btn-secondary btn-sm" onclick="location.href='#'">Criar cliente</button>
                </section>
            </div>
            <!-- botões CRUD -->
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
                        <button type="button" class="btn btn-info" onclic="location.href='@Url.Action("CriaUtilizador", "Utilizadores")'">
                            Novo
                        </button>
                    </li>
                    <li>
                        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Utilizadores")'">
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
                                onclick="location.href ='@Url.Action("ApagarUtilizador", "Utilizadores", New With {.ID_utilizador = Model.ID_utilizador})'">
                            Apagar
                        </button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

End Using



