@ModelType TicketSystem.Prioridade
@Code
    ViewData("Title") = "Criação de prioridades"
End Code


@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="container container-fluid">

        <div class="row" style="padding:10px;">
            <div class="col">
                <h4 class="font-italic font-weight-bold">Nova Prioridade</h4>
            </div>
            <div class="col">
                <h4 class="text-center font-italic font-weight-bold">Edição</h4>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <section>
                    @Html.LabelFor(Function(modelPrio) modelPrio.descricao)
                    @Html.TextBoxFor(Function(modelPrio) modelPrio.descricao, New With {.class = "form-control"})
                </section>
            </div>

            <!-- botões CRUD -->
            <div id="btnsEditarTickets" class="col">
                <ul class="listaBtns">
                    <li>
                        <input type="submit" value="Inserir Pioridade" class="btn btn-success" />
                    </li>
                    <li>
                        <button type="button" class="btn btn-secondary"
                                onclick="location.href='@Url.Action("Index", "Prioridades")'">
                            Voltar
                        </button>
                    </li>
                </ul>
            </div>
        </div>
    </div>
End Using


