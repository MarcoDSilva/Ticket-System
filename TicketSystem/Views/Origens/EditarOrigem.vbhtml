@ModelType TicketSystem.Origem
@Code
    ViewData("Title") = "Edição de origem"
    Dim idParaApagar = Model.ID_origem
End Code


@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    'form da view
    @<div class="container">
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(modelOrig) modelOrig.ID_origem)
         <div class="row">
             <h2>Editar origem</h2>
         </div>
        <!-- form edição, modelo row e cols para a organização -->
        <div class="row">
            <div class="col" style="width:100%;height:100vh;overflow:auto;background-color:lightgray;">
                @Html.LabelFor(Function(modelOrig) modelOrig.descricao)
                @Html.EditorFor(Function(modelOrig) modelOrig.descricao, New With {.HtmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(modelOrig) modelOrig.descricao, "", New With {.class = "text-danger"})
            </div>

            <div id="btnsEditarTickets" class="col">
               
                <ul class="listaBtns">
                    <li>
                        <h3>Edição:</h3>
                    </li>
                    <li><input type="submit" class="btn btn-success" value="Guardar" /></li>
                    <li>
                        <button type="button" class="btn btn-primary btn-danger" data-toggle="modal" data-target="#verificaModal" id="apagarino">
                            Apagar
                        </button>
                    </li>
                    <li>
                        <button type="button" class="btn btn-info" onclick="location.href='@Url.Action("CriaOrigem", "Origens")'">
                            Novo
                        </button>
                    </li>
                    <li>
                        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Origens")'">
                            Voltar
                        </button>
                    </li>
                </ul>
            </div>
        </div>

        <!-- butões com as operações respectivas do formulário de edição -->
        <div id="editaOrigens">
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
                                    onclick="location.href ='@Url.Action("ApagarOrigem", "Origens", New With {.ID_Origem = idParaApagar})'">
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

