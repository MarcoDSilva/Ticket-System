@ModelType TicketSystem.Software
@Code
    ViewData("Title") = "Criação de software"
End Code

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @<div class="container container-fluid" style="padding-top:15px;">

        <div class="row">
            <div class="col">
                <h4 class="font-italic font-weight-bold">Novo Software</h4>

                <section>
                    @Html.LabelFor(Function(modelSoft) modelSoft.nome)
                    @Html.TextBoxFor(Function(modelSoft) modelSoft.nome, New With {.class = "form-control"})
                </section>
            </div>
            <!-- botões CRUD -->
            <div id="btnsEditarTickets" class="col">
                <h4 class="text-center font-italic font-weight-bold">Edição</h4>

                <ul class="listaBtns">
                    <li>
                        <input type="submit" name="submit" value="Inserir Software" class="btn btn-success" />
                    </li>
                    <li>
                        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Softwares")'">
                            Voltar
                        </button>
                    </li>
                </ul>
            </div>

        </div>

    </div>
End Using



