@ModelType TicketSystem.Origem
@Code
    ViewData("Title") = "Edição de origem"
    Dim idParaApagar = Model.ID_origem
End Code


@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    'form da view
    @<div class="container-fluid">
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(modelOrig) modelOrig.ID_origem)
         <div class="row" style="padding:10px;">
             <div class="col">
                 <h4 class="font-italic font-weight-bold">Origem</h4>
             </div>
             <div class="col">
                 <h4 class="text-center font-italic font-weight-bold">Edição</h4>
             </div>
         </div>
        <!-- form edição, modelo row e cols para a organização -->
         <div class="row" style="padding:10px;">
             <div class="col" id="contentorEdicao">
                 <ul class="nav nav-tabs" id="myTab" role="tablist">
                     <li class="nav-item">
                         <a class="nav-link active btn" id="detalhes-tab" data-toggle="tab" href="#detalhes" role="tab" aria-controls="detalhes" aria-selected="true">Base</a>
                     </li>
                 </ul>
                 <section class="conteudo">
                     @Html.LabelFor(Function(modelOrig) modelOrig.descricao, New With {.class = "form-text"})
                     @Html.EditorFor(Function(modelOrig) modelOrig.descricao, New With {.HtmlAttributes = New With {.class = "form-control", .style = "max-width:200px;"}})
                     @Html.ValidationMessageFor(Function(modelOrig) modelOrig.descricao, "", New With {.class = "text-danger"})
                 </section>
             </div>
                 <div id="btnsEditarTickets" class="col">
                     <ul class="listaBtns">
                         <li>
                             <input type="submit" class="btn btn-success" value="Guardar" />
                         </li>
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

