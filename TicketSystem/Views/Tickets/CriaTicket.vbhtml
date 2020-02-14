@ModelType TicketSystem.Ticket
@Code
    ViewData("Title") = "Criação de ticket"

    Dim tempoActual = Date.Today.ToString("yyyy-MM-dd")

End Code


<div class="container">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()


        @<div class="form-group">
            <h2>Criação de ticket</h2>
   
            @Html.HiddenFor(Function(ticket) ticket.ID_ticket)
            <div class="col-md-12">               
                <p>
                    @Html.LabelFor(Function(ticket) ticket.ID_software, New With {.class = "form-check-label"})
                    @Html.DropDownList("ID_software", DirectCast(ViewBag.software, SelectList), New With {.class = "form-control"})
                </p>
                <p>
                    @Html.LabelFor(Function(ticket) ticket.Cliente, New With {.class = "form-check-label"})
                    @Html.DropDownList("ID_cliente", DirectCast(ViewBag.cliente, SelectList), New With {.class = "form-control"})
                </p>
                <p>
                    @Html.LabelFor(Function(ticket) ticket.Problema, New With {.class = "form-check-label"})
                    @Html.DropDownList("ID_problema", DirectCast(ViewBag.problema, SelectList), New With {.class = "form-control"})
                </p>
                <p>
                    @Html.LabelFor(Function(ticket) ticket.descricao, New With {.class = "form-check-label"})
                    @Html.TextAreaFor(Function(ticket) ticket.descricao, New With {.class = "form-control", .placeholder = "Insira a descrição aqui"})
                </p>
                <p>
                    @Html.LabelFor(Function(ticket) ticket.dataAbertura, New With {.class = "form-check-label"})
                    <input type="date" name="dataAbertura" value="@tempoActual" id="dataAbertura" class="form-control" />
                </p>
                <p>
                    @Html.LabelFor(Function(ticket) ticket.dataFecho, New With {.class = "form-check-label"})
                    <input type="date" name="dataFecho" id="dataFecho" class="form-control" />
                </p>
                <p>
                    @Html.LabelFor(Function(ticket) ticket.tempoPrevisto, New With {.class = "form-check-label"})
                    @Html.TextBoxFor(Function(ticket) ticket.tempoPrevisto, New With {.class = "form-control", .Value = "0"})
                </p>
                <p>
                    @Html.LabelFor(Function(ticket) ticket.tempoTotal, New With {.class = "form-check-label"})
                    @Html.TextBoxFor(Function(ticket) ticket.tempoTotal, New With {.class = "form-control", .Value = "0"})
                </p>
                <p>
                    @Html.LabelFor(Function(ticket) ticket.ID_estado, New With {.class = "form-check-label"})
                    @Html.DropDownList("ID_estado", DirectCast(ViewBag.estado, SelectList), New With {.class = "form-control"})
                </p>
                <p>
                    @Html.LabelFor(Function(ticket) ticket.ID_prioridade, New With {.class = "form-check-label"})
                    @Html.DropDownList("ID_prioridade", DirectCast(ViewBag.prioridade, SelectList), New With {.class = "form-control"})
                </p>
                <p>
                    @Html.LabelFor(Function(ticket) ticket.ID_utilizador, New With {.class = "form-check-label"})
                    @Html.DropDownList("ID_utilizador", DirectCast(ViewBag.utilizador, SelectList), New With {.class = "form-control"})
                </p>
                <p>
                    @Html.LabelFor(Function(ticket) ticket.ID_origem, New With {.class = "form-check-label"})
                    @Html.DropDownList("ID_origem", DirectCast(ViewBag.origem, SelectList), New With {.class = "form-control"})
                </p>

                <input type="submit" class="btn btn-primary" value="Enviar Dados" />
            </div>
        </div>
    End Using
</div>