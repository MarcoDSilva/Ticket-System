@ModelType IEnumerable(Of TicketSystem.Software)
@Code
ViewData("Title") = "Index"
End Code

<h2>Listagem Softwares</h2>

<p>
    @Html.ActionLink("Criar novo", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.nome)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.dat_hor)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.nome)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.dat_hor)
        </td>
        <td>
            @Html.ActionLink("Editar", "Edit", New With {.id = item.ID_software}) |
            @Html.ActionLink("Detailhes", "Details", New With {.id = item.ID_software}) |
            @Html.ActionLink("Apagar", "Delete", New With {.id = item.ID_software})
        </td>
    </tr>
Next

</table>
