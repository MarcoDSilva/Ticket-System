@ModelType IEnumerable(Of TicketSystem.VM_UtilizadorCliente)
@Code
    ViewData("Title") = "Utilizadores"
End Code


<div class="container container-fluid">

    <h2 class="font-italic font-weight-bold">Listagem Utilizadores</h2>

    <table id="tabelaEventos" class="table table-hover table-sm table-responsive">
        <tr class="thead-dark">
            <th>@Html.DisplayNameFor(Function(modelUser) modelUser.ID_utilizador)</th>
            <th>@Html.DisplayNameFor(Function(modelUser) modelUser.nome)</th>
            <th>@Html.DisplayNameFor(Function(modelUser) modelUser.contacto)</th>
            <th>@Html.DisplayNameFor(Function(modelUser) modelUser.email)</th>
            <th>@Html.DisplayNameFor(Function(modelUser) modelUser.ID_cliente)</th>
            <th>@Html.DisplayNameFor(Function(modelUser) modelUser.dat_hor)</th>
        </tr>

        @For Each utilizador In Model
            @<tr onclick="location.href='@Url.Action("EditarUtilizador", "Utilizadores", New With {.ID_utilizador = utilizador.ID_utilizador})'" class="clickableCell">

                <td>@Html.DisplayFor(Function(modelutilizador) utilizador.ID_utilizador)</td>
                <td>@Html.DisplayFor(Function(modelutilizador) utilizador.nome)</td>
                <td>@Html.DisplayFor(Function(modelutilizador) utilizador.contacto)</td>
                <td>@Html.DisplayFor(Function(modelutilizador) utilizador.email)</td>
                <td>@Html.DisplayFor(Function(modelutilizador) utilizador.ID_cliente)</td>
                <td>@Html.DisplayFor(Function(modelutilizador) utilizador.dat_hor)</td>
            </tr>
        Next
    </table>

    <button type="button" class="btn btn-primary" onclick="location.href='@Url.Action("CriaUtilizador", "Utilizadores")'">
        Novo Registo
    </button>

</div>
