@ModelType TicketSystem.VM_UtilizadorCliente
@Code
    ViewData("Title") = "Criação de utilizador"
End Code


@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="container container-fluid" style="padding:15px;">  

    <!--form criação-->
    <div class="row">
        <div class="col">
            <h4 class="font-italic font-weight-bold">Novo Utilizador</h4>

            <section>
                @Html.LabelFor(Function(modelUtil) modelUtil.nome, New With {.class = "form-check-label"})
                @Html.TextBoxFor(Function(modelUtil) modelUtil.nome, New With {.class = "form-control"})
            </section>
            <section>
                @Html.LabelFor(Function(modelUtil) modelUtil.contacto, New With {.class = "form-check-label"})
                @Html.TextBoxFor(Function(modelUtil) modelUtil.contacto, New With {.class = "form-control"})
            </section>
            <section>
                @Html.LabelFor(Function(modelUtil) modelUtil.email, New With {.class = "form-check-label"})
                @Html.TextBoxFor(Function(modelUtil) modelUtil.email, New With {.class = "form-control"})
            </section>
            <section>
                @Html.LabelFor(Function(modelUtil) modelUtil.ID_cliente, New With {.Class = "form-check-label"})
                @Html.DropDownList("ID_cliente", DirectCast(ViewBag.clientes, SelectList), New With {.class = "form-control"})
                <button type="button" class="btn btn-secondary btn-sm" onclick="location.href='#'">Criar Cliente</button>

            </section>
        </div>

        <!-- butões CRUD -->
        <div id="btnsEditarTickets" class="col">
            <h4 class="text-center font-italic font-weight-bold">Edição</h4>

            <ul class="listaBtns">
                <li>
                    <input type="submit" Class="btn btn-success" value="Inserir Utilizador" />
                </li>
                <li>
                    <button type="button" Class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Utilizadores")'">
                        Voltar
                    </button>
                </li>
            </ul>
        </div>
    </div>    
</div>
End Using
