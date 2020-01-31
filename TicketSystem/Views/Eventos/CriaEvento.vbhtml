@ModelType TicketSystem.Evento
@Code
    ViewData("Title") = "CriaEvento"
End Code

<h2>Criar evento</h2>

<div class="form-horizontal">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        @<div class="form-group">
            <h4>Evento</h4>
            <div class="col-md-12">
                <p>
                    @Html.LabelFor(Function(modelEve) modelEve.descricao)
                    @Html.TextBoxFor(Function(modelEve) modelEve.descricao, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(modelEve) modelEve.descricao)
                </p>
                <p>
                    @Html.LabelFor(Function(modelEve) modelEve.ID_tecnico)
                    @Html.DropDownList("ID_tecnico", DirectCast(ViewBag.tecnico, SelectList), New With {.class = "form-control"})
                </p>
                <p>
                    @Html.LabelFor(Function(modelEve) modelEve.dataAbertura)
                    <input type="date" name="dataAbertura" value="dataAbertura" id="dataAbertura" class="form-control" />
                </p>
                <p>
                    @Html.LabelFor(Function(modelEve) modelEve.dataFecho)
                    <input type="date" name="dataFecho" value="dataFecho" id="dataFecho" class="form-control" />
                </p>
                <p>
                    @Html.LabelFor(Function(modelEve) modelEve.ID_ticket)
                    @Html.DropDownList("ID_ticket", DirectCast(ViewBag.tickets, SelectList), New With {.class = "form-control"})
                </p>
            </div>

            <input type="submit" class="btn btn-primary" onclick="location.href='@Url.Action("CriaEvento", "Eventos")'" value="Inserir Registo" />
            <button type="button" class="btn btn-secondary" onclick="location.href='@Url.Action("Index", "Eventos")'">
                Voltar
            </button>

        </div>
    End Using

</div>
