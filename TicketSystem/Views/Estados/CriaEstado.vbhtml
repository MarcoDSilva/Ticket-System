﻿@ModelType TicketSystem.Estado
@Code
    ViewData("Title") = "Criação de estados"
End Code


@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="container container-fluid" style="padding-top:15px;">

        <!-- form criação-->
        <div class="row">
            <div class="col">
                <h4 class="font-italic font-weight-bold">Novo Estado</h4>

                <section>
                    @Html.LabelFor(Function(modelEst) Model.descricao, New With {.class = "form-check-label"})
                    @Html.TextBoxFor(Function(modelEst) Model.descricao, New With {.class = "form-control"})
                </section>
            </div>

            <!-- botões CRUD -->
            <div id="btnsEditarTickets" class="col">
                <h4 class="text-center font-italic font-weight-bold">Edição</h4>

                <ul class="listaBtns">
                    <li>
                        <input type="submit" name="submit" value="inserir estado" Class="btn btn-success" />
                    </li>
                    <li>
                        <button type="button" Class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Estados")'">
                            Voltar
                        </button>
                    </li>
                </ul>
            </div>
        </div>

    </div>
End Using

