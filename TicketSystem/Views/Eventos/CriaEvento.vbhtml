@ModelType TicketSystem.Evento
@Code
    ViewData("Title") = "CriaEvento"
End Code

<h2>Criar evento</h2>

<div class="form-horizontal">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div Class="form-group">
            <div Class="col-md-12">
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
                    <input placeholder="Selected date" type="text" class="form-control datepicker">
                    
                </p>
                
            </div>
        </div>
    End Using


</div>
