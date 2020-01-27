@ModelType IEnumerable(Of TicketSystem.Software)
@Code
    ViewData("Title") = "Index"
End Code

<h2>Listagem softwares</h2>

<table class="table">
    <tr>
        <th>@Html.DisplayNameFor(Function(modelSoft) modelSoft.ID_software)</th>
        <th>@Html.DisplayNameFor(Function(modelSoft) modelSoft.nome)</th>
        <th>@Html.DisplayNameFor(Function(modelSoft) modelSoft.dat_hor)</th>
    </tr>

    @For Each software In Model
        @<tr>
            <td>@Html.DisplayFor(Function(modelSoft) software.ID_software)</td>
            <td>@Html.DisplayFor(Function(modelSoft) software.nome)</td>
            <td>@Html.DisplayFor(Function(modelSoft) software.dat_hor)</td>
            <td>@Html.ActionLink("Detalhes", "EditarSoftware", New With {.ID_software = software.ID_software})</td>
        </tr>

    Next
</table>

<button type="button" class="btn btn-primary" onclick="location.href='@Url.Action("CriaSoftware", "Softwares")'">
    Novo Registo
</button>
