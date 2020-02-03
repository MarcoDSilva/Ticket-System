@ModelType TicketSystem.VM_UtilizadorCliente
@Code
    ViewData("Title") = "Edita Utilizador"
End Code

<h2>Editar Utilizador</h2>

<div class="form-group">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="col-form-label">
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @Html.HiddenFor(Function(Utilizador) Utilizador.ID_utilizador)

            <!-- form edição -->
            <div class="form-group">
                <div class="col-md-12">
                    <p>
                        @Html.LabelFor(Function(Utilizador) Utilizador.nome, New With {.class = "form-check-label"})
                        @Html.EditorFor(Function(Utilizador) Utilizador.nome, New With {.HtmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(Utilizador) Utilizador.nome, "", New With {.class = "text-danger"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(Utilizador) Utilizador.contacto, New With {.class = "form-check-label"})
                        @Html.EditorFor(Function(Utilizador) Utilizador.contacto, New With {.HtmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(Utilizador) Utilizador.contacto, "", New With {.class = "text-danger"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(Utilizador) Utilizador.email, New With {.class = "form-check-label"})
                        @Html.EditorFor(Function(Utilizador) Utilizador.email, New With {.HtmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(Utilizador) Utilizador.email, "", New With {.class = "text-danger"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(Utilizador) Utilizador.ID_cliente, New With {.class = "form-check-label"})
                        @Html.DropDownList("ID_cliente", DirectCast(ViewBag.clientes, SelectList), New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(Utilizador) Utilizador.ID_cliente, "", New With {.class = "text-danger"})

                        <button type="button" class="btn btn-secondary btn-sm" onclick="location.href='#'">Criar cliente</button>
                    </p>

                    <!-- butões de operações -->
                    <input type="submit" value="Guardar" class="btn btn-success" />

                    <button type="button" class="btn btn-primary btn-danger" data-toggle="modal" data-target="#verificaModal">
                        Apagar
                    </button>
                    <button type="button" class="btn btn-info" onclic="location.href='@Url.Action("CriaUtilizador", "Utilizadores")'">
                        Novo
                    </button>
                    <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Utilizadores")'">
                        Voltar
                    </button>
                </div>
            </div>

            <!-- butões com as operações respectivas do formulário de edição -->
            <div id="editaEvento" class="form-group">

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

        </div>
    End Using

</div>

