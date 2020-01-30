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
                    @Html.TextBoxFor(Function(modelEve) modelEve.descricao)
                </p>
                <p>
                    @Html.LabelFor(Function(modelEve) modelEve.ID_tecnico)
                    @Html.DropDownList("ID_tecnico", DirectCast(ViewBag.tecnico, SelectList))
                </p>
                <p>
                    @Html.LabelFor(Function(modelEve) modelEve.dataAbertura)
                    <input type="date" name="dataAbertura" value="dataAbertura" id="dataAbertura" />
                </p>
                <p>
                    @Html.LabelFor(Function(modelEve) modelEve.dataFecho)
                    <input type="date" name="dataFecho" value="dataFecho" id="dataFecho" />
                </p>
                <p>
                    @Html.LabelFor(Function(modelEve) modelEve.ID_ticket)
                    @Html.DropDownList("ID_ticket", DirectCast(ViewBag.tickets, SelectList))
                </p>
            </div>

            <input type="submit" class="btn btn-primary" onclick="location.href='@Url.Action("CriaEvento", "Eventos")'" value="Inserir Registo" />
        </div>
    End Using


</div>
