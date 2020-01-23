@ModelType TicketSystem.Software
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Apagar Softwares</h2>

<h3>De certeza que vai querer apagar o software em questão?</h3>
<div>
    <h4>Software</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.nome)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.nome)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.dat_hor)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.dat_hor)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Voltar para listagem", "Index")
        </div>
    End Using
</div>
