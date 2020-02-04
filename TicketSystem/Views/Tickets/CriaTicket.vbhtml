@ModelType TicketSystem.Ticket
@Code
    ViewData("Title") = "CriaTicket"
End Code

<h2>Criação de ticket</h2>

<div class="form-row">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-group">
            <h4>Tickets</h4>
            @Html.HiddenFor(Function(ticket) ticket.ID_ticket)
            <div class="col-md-12">
                <p>
                    @Html.LabelFor(Function(ticket) ticket.ID_tecnico, New With {.class = "form-check-label"})
                    @Html.TextBoxFor(Function(ticket) ticket.ID_tecnico, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(ticket) ticket.ID_tecnico)
                </p>
            </div>
        </div>
    End Using
</div>