@ModelType IEnumerable(Of TicketSystem.Software)
@Code
    ViewData("Title") = "Softwares"
End Code


<div class="container container-fluid">
    <h2 class="font-italic font-weight-bold">Listagem softwares</h2>

    <table id="tabelaEventos" class="table table-hover table-sm table-responsive">
        <tr class="thead-dark">
            <th>@Html.DisplayNameFor(Function(modelSoft) modelSoft.ID_software)</th>
            <th>@Html.DisplayNameFor(Function(modelSoft) modelSoft.nome)</th>
            <th>@Html.DisplayNameFor(Function(modelSoft) modelSoft.dat_hor)</th>
        </tr>

        @For Each software In Model
            @<tr onclick="location.href='@Url.Action("EditarSoftware", "Softwares", New With {.ID_software = software.ID_software})'" class="clickableCell">
                <td>@Html.DisplayFor(Function(modelSoft) software.ID_software)</td>
                <td>@Html.DisplayFor(Function(modelSoft) software.nome)</td>
                <td>@Html.DisplayFor(Function(modelSoft) software.dat_hor)</td>
            </tr>

        Next
    </table>

    <button type="button" class="btn btn-primary" onclick="location.href='@Url.Action("CriaSoftware", "Softwares")'">
        Novo Registo
    </button>

</div>