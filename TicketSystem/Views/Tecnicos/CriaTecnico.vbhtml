@ModelType TicketSystem.VM_TecnicoRole

@Code
    ViewData("Title") = "Criação de técnico"
End Code


@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

    @<div class="container container-fluid" style="padding-top:15px;">       

        <!-- valores para criar -->
        <div class="row">
            <div class="col">
                <h4 class="font-italic font-weight-bold">Novo Tecnico</h4>
                <section>
                    @Html.LabelFor(Function(modelTec) modelTec.nome)
                    @Html.TextBoxFor(Function(modelTec) modelTec.nome, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(modelTec) modelTec.nome, "", New With {.class = "text-danger"})
                </section>
                <section>
                    @Html.LabelFor(Function(modelTec) modelTec.email)
                    @Html.TextBoxFor(Function(modelTec) modelTec.email, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(modelTec) modelTec.email, "", New With {.class = "text-danger"})
                </section>
                <section>
                    @Html.LabelFor(Function(modelTec) modelTec.ID_role)
                    @Html.DropDownList("ID_role", DirectCast(ViewBag.roles, SelectList), New With {.class = "form-control"})
                </section>
                @If Session("EmailExiste") = 1 Then
                    @<small id="erro" class="form-text text-danger">Email já existente na base de dados!</small>
                End If
            </div>

            <!-- botões CRUD -->
            <div id="btnsEditarTickets" class="col">
                <h4 class="text-center font-italic font-weight-bold">Edição</h4>

                <ul class="listaBtns">
                    <li>
                        <input type="submit" class="btn btn-success" value="Inserir Tecnico" />
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


