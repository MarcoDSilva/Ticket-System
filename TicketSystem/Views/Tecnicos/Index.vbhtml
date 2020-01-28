@ModelType IEnumerable(Of TicketSystem.Tecnico)
@Code
    ViewData("Title") = "Index"
End Code

<h2>Listagem Tecnicos</h2>

<table class="table">
    <tr>
        <th>@Html.DisplayNameFor(Function(modelTec) modelTec.ID_tecnico)<th>
    </tr>

</table>