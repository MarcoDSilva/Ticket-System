@ModelType TicketSystem.Cliente
@Code
    ViewData("Title") = "Criação De Cliente"
End Code

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @<div class="container container-fluid" style="padding-top:15px;">
        <!-- form criação-->
        <div class="row">
            <div class="col">
                <h4 class="font-italic font-weight-bold">Novo Cliente</h4>

                <section>
                    @Html.LabelFor(Function(modelCli) modelCli.nome, New With {.class = "form-check-label"})
                    @Html.TextBoxFor(Function(modelCli) modelCli.nome, New With {.class = "form-control"})
                </section>
                <section>
                    @Html.LabelFor(Function(modelCli) modelCli.contacto, New With {.class = "form-check-label"})
                    @Html.TextBoxFor(Function(modelCli) modelCli.contacto, New With {.class = "form-control"})
                </section>
                <section>
                    @Html.LabelFor(Function(modelCli) modelCli.email, New With {.class = "form-check-label"})
                    @Html.TextBoxFor(Function(modelCli) modelCli.email, New With {.class = "form-control"})
                </section>
                <section>
                    @Html.LabelFor(Function(modelCli) modelCli.empresa, New With {.class = "form-check-label"})
                    @Html.TextBoxFor(Function(modelCli) modelCli.empresa, New With {.class = "form-control"})
                </section>
                <section>
                    @Html.LabelFor(Function(modelCli) modelCli.ID_utilizador, New With {.class = "form-check-label"})
                    @Html.DropDownList("ID_utilizador", DirectCast(ViewBag.utilizadores, SelectList), New With {.class = "form-control"})
                    <button type="button" class="btn btn-secondary btn-sm" onclick="location.href='#'">Criar utilizador</button>
                </section>
            </div>

            <!-- botões CRUD -->
            <div id="btnsEditarTickets" class="col">
                <h4 class="text-center font-italic font-weight-bold">Edição</h4>

                <ul class="listaBtns">
                    <li>
                        <input type="submit" class="btn btn-success" value="Novo Cliente" />
                    </li>
                    <li>
                        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Clientes")'">
                            Voltar
                        </button>
                    </li>
                </ul>
            </div>
        </div>
    </div>

End Using


