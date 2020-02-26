@ModelType TicketSystem.Evento
@Code
    ViewData("Title") = "Criação de eventos"

    Dim ticketNum As Boolean = False
    Dim idTicket As Integer

    'tentamos obter por request qual é o ticket que está a tentar associar um evento
    'se conseguirmos obter um número, é porque temos associação então enviamos o número e deixamos a flag a false
    'caso contrário, passamos a flag a true e mostramos uma combobox com opções.
    Try
        idTicket = Request.Params.Item("ID_ticket")

        If idTicket = 0 Then
            ticketNum = True
        End If

    Catch ex As Exception
        ticketNum = True
    End Try
End Code


@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="container container-fluid">
        <div class="row" style="padding:10px;">
            <div class="col">
                <h4 class="font-italic font-weight-bold">Novo Evento</h4>
            </div>
            <div class="col">
                <h4 class="text-center font-italic font-weight-bold">Edição</h4>
            </div>
        </div>

        <!--form criação-->
        <div class="row">
            <div class="col">
                <section>
                    @Html.LabelFor(Function(modelEve) modelEve.descricao, New With {.class = "form-check-label descricaoTicket"})
                    @Html.TextAreaFor(Function(modelEve) modelEve.descricao, 10, 100, New With {.class = "form-control descricaoTicket",
                                                .placeHolder = "Insira a descrição aqui"})
                    @Html.ValidationMessageFor(Function(modelEve) modelEve.descricao)
                </section>

                <section>
                    @Html.LabelFor(Function(modelEve) modelEve.ID_tecnico, New With {.class = "form-check-label"})
                    @Html.DropDownList("ID_tecnico", DirectCast(ViewBag.tecnico, SelectList), New With {.class = "form-control"})
                </section>

                <section>
                    @Html.LabelFor(Function(modelEve) modelEve.dataAbertura, New With {.class = "form-check-label"})
                    <input type="date" name="dataAbertura" value="dataAbertura" id="dataAbertura" class="form-control" />
                </section>

                <section>
                    @Html.LabelFor(Function(modelEve) modelEve.dataFecho, New With {.class = "form-check-label"})
                    <input type="date" name="dataFecho" value="dataFecho" id="dataFecho" class="form-control" />
                </section>

                <section>
                    @Html.LabelFor(Function(modelEve) modelEve.ID_ticket, New With {.class = "form-check-label"})

                    @If ticketNum.Equals(False) Then
                        @Html.TextBox("ID_ticket", idTicket, Nothing, htmlAttributes:=New With {.readonly = "true"})
                    Else
                        @Html.DropDownList("ID_ticket", DirectCast(ViewBag.tickets, SelectList), New With {.class = "form-control"})
                    End If
                </section>
                <section>
                    <p>TODO: mostrar aqui o ticket que corresponde ao ID selecionado para visualização</p>
                </section>
            </div>
            <!-- botões CRUD -->
            <div id="btnsEditarTickets" class="col">
                <ul class="listaBtns">
                    <li>
                        <input type="submit" class="btn btn-success" onclick="location.href='@Url.Action("CriaEvento", "Eventos")'" value="Inserir Evento" />

                    </li>
                    <li>
                        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Eventos")'">
                            Voltar
                        </button>
                    </li>
                </ul>
            </div>
        </div>
    </div>
End Using

