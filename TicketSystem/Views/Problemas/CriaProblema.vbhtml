@ModelType TicketSystem.Problema
@Code
    ViewData("Title") = "Criar problema"
End Code

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="container container-fluid" style="padding-top:15px;">        
        <!-- form criação-->
        <div class="row">
            <div class="col">
                <h4 class="font-italic font-weight-bold">Novo problema</h4>

                <section>
                    @Html.LabelFor(Function(ModelProb) ModelProb.descricao)
                    @Html.TextBoxFor(Function(ModelProb) ModelProb.descricao, New With {.class = "form-control"})
                </section>
            </div>
            <!-- botões CRUD -->
            <div id="btnsEditarTickets" class="col">
                <h4 class="text-center font-italic font-weight-bold">Edição</h4>

                <ul class="listaBtns">
                    <li>
                        <input type="submit" name="submit" value="inserir problema" class="btn btn-success" />
                    </li>
                    <li>
                        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Problemas")'">
                            Voltar
                        </button>
                    </li>
                </ul>
            </div>
        </div>
    </div>

End Using




