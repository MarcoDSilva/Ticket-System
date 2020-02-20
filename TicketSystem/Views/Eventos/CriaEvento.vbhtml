﻿@ModelType TicketSystem.Evento
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

<h4>Criar evento</h4>
@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @<div class="form-group">
        <h4>Evento</h4>
        <div class="col-md-12">
            <p>
                @Html.LabelFor(Function(modelEve) modelEve.descricao, New With {.class = "form-check-label"})
                @Html.TextBoxFor(Function(modelEve) modelEve.descricao, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(modelEve) modelEve.descricao)
            </p>
            <p>
                @Html.LabelFor(Function(modelEve) modelEve.ID_tecnico, New With {.class = "form-check-label"})
                @Html.DropDownList("ID_tecnico", DirectCast(ViewBag.tecnico, SelectList), New With {.class = "form-control"})
            </p>
            <p>
                @Html.LabelFor(Function(modelEve) modelEve.dataAbertura, New With {.class = "form-check-label"})
                <input type="date" name="dataAbertura" value="dataAbertura" id="dataAbertura" class="form-control" />
            </p>
            <p>
                @Html.LabelFor(Function(modelEve) modelEve.dataFecho, New With {.class = "form-check-label"})
                <input type="date" name="dataFecho" value="dataFecho" id="dataFecho" class="form-control" />
            </p>
            <p>
                @Html.LabelFor(Function(modelEve) modelEve.ID_ticket, New With {.class = "form-check-label"})

                @If ticketNum.Equals(False) Then
                    @Html.TextBox("ID_ticket", idTicket, Nothing, htmlAttributes:=New With {.readonly = "true"})
                Else
                    @Html.DropDownList("ID_ticket", DirectCast(ViewBag.tickets, SelectList), New With {.class = "form-control"})
                End If

            </p>
        </div>

        <input type="submit" class="btn btn-primary" onclick="location.href='@Url.Action("CriaEvento", "Eventos")'" value="Inserir Registo" />
        <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Eventos")'">
            Voltar
        </button>

    </div>
End Using

