@ModelType TicketSystem.VM_ClienteUtilizador
@Code
    ViewData("Title") = "Edição de clientes"
End Code

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(cli) cli.ID_cliente)

    @<div class="container container-fluid">

        <!-- form edição -->
        <!-- elemento onde a prioridade é editada e submissão da mesmo -->
        <div class="row" id="editaPrioridade">

            <!-- dados do form -->
            <div class="col">
                <h4 class="font-italic font-weight-bold">Clientes</h4>

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

            <!-- butões CRUD -->
            <div id="btnsEditarTickets" class="col">
                <h4 class="text-center font-italic font-weight-bold">Edição</h4>

                <ul class="listaBtns">
                    <li> <input type="submit" value="Guardar" class="btn btn-success" /></li>
                    <li>
                        <button type="button" class="btn btn-primary btn-danger" data-toggle="modal" data-target="#verificaModal">
                            Apagar
                        </button>
                    </li>
                    <li>
                        <button type="button" class="btn btn-info" onclick="location.href='@Url.Action("CriaCliente", "Clientes")'">
                            Novo
                        </button>
                    </li>
                    <li>
                        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Clientes")'">
                            Voltar
                        </button>
                    </li>
                </ul>
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
