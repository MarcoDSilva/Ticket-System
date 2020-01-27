@ModelType TicketSystem.Estado
@Code
    ViewData("Title") = "EditarEstado"
    Dim idParaApagar = Model.ID_estado
End Code

<h2>Editar o tipo do estado</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()


    @<div class="form-horizontal">
        <h4>Modo de edição</h4>
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(modelEst) modelEst.ID_estado)

        <!-- form onde o estado será editado-->
        <div class="form-group">
            <div class="col-md-12">
                @Html.LabelFor(Function(modelEst) modelEst.descricao)
                @Html.TextAreaFor(Function(modelEst) modelEst.descricao, New With {.class = "class-control"})
            </div>
        </div>

    </div>
End Using
