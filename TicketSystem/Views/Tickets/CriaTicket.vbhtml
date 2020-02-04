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
                 @Html.DropDownListFor(Function(ticket) ticket.ID_tecnico, DirectCast(ViewBag.tecnico, SelectList), New With {.Class = "form-control"})
             </p>
             <p>
                 @Html.LabelFor(Function(ticket) ticket.ID_software, New With {.class = "form-check-label"})
                 @Html.DropDownListFor(Function(ticket) ticket.ID_software, DirectCast(ViewBag.software, SelectList), New With {.Class = "form-control"})
             </p>
             <p>
                 @Html.LabelFor(Function(ticket) ticket.Cliente, New With {.class = "form-check-label"})
                 @Html.DropDownListFor(Function(ticket) ticket.Cliente, DirectCast(ViewBag.cliente, SelectList), New With {.Class = "form-control"})
             </p>
             <p>
                 @Html.LabelFor(Function(ticket) ticket.Problema, New With {.class = "form-check-label"})
                 @Html.DropDownListFor(Function(ticket) ticket.Problema, DirectCast(ViewBag.problema, SelectList), New With {.Class = "form-control"})
             </p>
             <p>
                 @Html.LabelFor(Function(ticket) ticket.descricao, New With {.class = "form-check-label"})
                 @Html.TextAreaFor(Function(ticket) ticket.descricao, New With {.class = "form-control"})
             </p>
             <p>
                 @Html.LabelFor(Function(ticket) ticket.dataAbertura, New With {.class = "form-check-label"})
                 <input type="date" name="dataAbertura" value="dataAbertura" id="dataAbertura" class="form-control" />
             </p>
             <p>
                 @Html.LabelFor(Function(ticket) ticket.dataFecho, New With {.class = "form-check-label"})
                 <input type="date" name="dataFecho" value="dataFecho" id="dataFecho" class="form-control" />
             </p>
             <p>
                 @Html.LabelFor(Function(ticket) ticket.tempoPrevisto, New With {.class = "form-check-label"})
                 @Html.LabelFor(Function(ticket) ticket.tempoPrevisto, New With {.class = "form-control"})

             </p>


         </div>
        </div>
    End Using
</div>