@ModelType TicketSystem.Software
@Code
    ViewData("Title") = "Details"
End Code

<h2>Detalhes</h2>

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
</div>
<p>
    @Html.ActionLink("Editar", "Edit", New With {.id = Model.ID_software}) |
    @Html.ActionLink("Voltar para listagem", "Index")
</p>
