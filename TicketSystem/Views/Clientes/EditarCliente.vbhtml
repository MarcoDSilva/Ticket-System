@ModelType TicketSystem.VM_ClienteUtilizador
@Code
    ViewData("Title") = "Edição de clientes"
End Code


<div class="container">
    <h2>Edição de cliente</h2>

    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="row">
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @Html.HiddenFor(Function(cli) cli.ID_cliente)

            <!-- form edição -->
            <div class="col">
                <section>
                    @Html.LabelFor(Function(cli) cli.nome, New With {.class = "form-check-label"})
                    @Html.EditorFor(Function(cli) cli.nome, New With {.HtmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(cli) cli.nome, "", New With {.class = "text-danger"})
                </section>
                <section>
                    @Html.LabelFor(Function(cli) cli.contacto, New With {.class = "form-check-label"})
                    @Html.EditorFor(Function(cli) cli.contacto, New With {.HtmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(cli) cli.contacto, "", New With {.class = "text-danger"})
                </section>
                <section>
                    @Html.LabelFor(Function(cli) cli.email, New With {.class = "form-check-label"})
                    @Html.EditorFor(Function(cli) cli.email, New With {.HtmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(cli) cli.email, "", New With {.class = "text-danger"})
                </section>
                <section>
                    @Html.LabelFor(Function(cli) cli.empresa, New With {.class = "form-check-label"})
                    @Html.EditorFor(Function(cli) cli.empresa, New With {.HtmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(cli) cli.empresa, "", New With {.class = "text-danger"})
                </section>
                @*<section>
                        @Html.LabelFor(Function(cli) cli.ID_utilizador, New With {.class = "form-check-label"})
                        @Html.EditorFor(Function(cli) cli.ID_utilizador, New With {.HtmlAttributes = New With {.class = "form-control"}})
                        @Html.DropDownList("ID_utilizador", DirectCast(ViewBag.utilizador, SelectList), New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(cli) cli.ID_utilizador, "", New With {.class = "text-danger"})

                        <button type="button" class="btn btn-secondary btn-sm" onclick="location.href='#'">Criar utilizador</button>
                    </section>*@
            </div>

            <div class="col">
                <!-- butões de operações -->
                <input type="submit" value="Guardar" class="btn btn-success" />

                <button type="button" class="btn btn-primary btn-danger" data-toggle="modal" data-target="#verificaModal">
                    Apagar
                </button>
                <button type="button" class="btn btn-info" onclick="location.href='@Url.Action("CriaCliente", "Clientes")'">
                    Novo
                </button>
                <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Clientes")'">
                    Voltar
                </button>
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
                                        onclick="location.href ='@Url.Action("ApagarCliente", "Clientes", New With {.ID_cliente = Model.ID_cliente})'">
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