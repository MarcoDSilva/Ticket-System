@ModelType IEnumerable(Of TicketSystem.VM_ClienteUtilizador)
@Code
    ViewData("Title") = "Clientes"
End Code

<h2>Listagem Clientes</h2>

<table class="table table-hover table-sm table-responsive">
    <tr class="thead-dark">
        <th>@Html.DisplayNameFor(Function(modelCli) modelCli.ID_cliente)</th>
        <th>@Html.DisplayNameFor(Function(modelCli) modelCli.nome)</th>
        <th>@Html.DisplayNameFor(Function(modelCli) modelCli.contacto)</th>
        <th>@Html.DisplayNameFor(Function(modelCli) modelCli.email)</th>
        <th>@Html.DisplayNameFor(Function(modelCli) modelCli.empresa)</th>
        <th>@Html.DisplayNameFor(Function(modelCli) modelCli.ID_utilizador)</th>
        <th>@Html.DisplayNameFor(Function(modelCli) modelCli.dat_hor)</th>
    </tr>

    @For Each cliente In Model
        @<tr>
            <td>@Html.DisplayFor(Function(modelCli) cliente.ID_cliente)</td>
            <td>@Html.DisplayFor(Function(modelCli) cliente.nome)</td>
            <td>@Html.DisplayFor(Function(modelCli) cliente.contacto)</td>
            <td>@Html.DisplayFor(Function(modelCli) cliente.email)</td>
            <td>@Html.DisplayFor(Function(modelCli) cliente.empresa)</td>
            <td>@Html.DisplayFor(Function(modelCli) cliente.ID_utilizador)</td>
            <td>@Html.DisplayFor(Function(modelCli) cliente.dat_hor)</td>
            <td>@Html.ActionLink("Detalhes", "EditarCliente", New With {.ID_cliente = cliente.ID_cliente})</td>
        </tr>
    Next
</table>

<button type="button" class="btn btn-primary" onclick="location.href='@Url.Action("CriaCliente", "Clientes")'">
   Novo Registo
</button>

