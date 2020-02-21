@ModelType TicketSystem.Ticket
@Code
    ViewData("Title") = "Criação de ticket"

    Dim tempoActual = Date.Today.ToString("yyyy-MM-dd")

End Code

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="container" id="criaTicket">
        <h4>Criação de ticket</h4>

        @Html.HiddenFor(Function(ticket) ticket.ID_ticket)
     <div class="row row-no-gutters">
         <ul class="nav nav-tabs col-sm-12" id="myTab" role="tablist">
             <li class="nav-item">
                 <a class="nav-link active btn" id="detalhes-tab" data-toggle="tab" href="#detalhes" role="tab"
                    aria-controls="detalhes" aria-selected="true">Detalhes do ticket</a>
             </li>
             <li class="nav-item">
                 <a class="nav-link" id="profile-tab" data-toggle="tab" href="#datas" role="tab"
                    aria-controls="datas" aria-selected="false">Datas e Tempos</a>
             </li>
             <li class="nav-item">
                 <a class="nav-link" id="misc-tab" data-toggle="tab" href="#misc" role="tab"
                    aria-controls="misc" aria-selected="false">misc.</a>
             </li>
         </ul>


         <div class="tab-content" id="myTabContent">
             <div class="tab-pane fade show active" id="detalhes" role="tabpanel" aria-labelledby="detalhes-tab">
                 <section>
                     @Html.LabelFor(Function(ticket) ticket.ID_software, New With {.class = "form-check-label"})
                     @Html.DropDownList("ID_software", DirectCast(ViewBag.software, SelectList), New With {.class = "form-control"})
                 </section>
                 <section>
                     @Html.LabelFor(Function(ticket) ticket.Cliente, New With {.class = "form-check-label"})
                     @Html.DropDownList("ID_cliente", DirectCast(ViewBag.cliente, SelectList), New With {.class = "form-control"})
                 </section>
                 <section>
                     @Html.LabelFor(Function(ticket) ticket.Problema, New With {.class = "form-check-label"})
                     @Html.DropDownList("ID_problema", DirectCast(ViewBag.problema, SelectList), New With {.class = "form-control"})
                 </section>
                 <section id="descricaoTicket">
                     <div class="col-sm-8">
                         @Html.LabelFor(Function(ticket) ticket.descricao, New With {.class = "form-check-label"})
                         @Html.TextAreaFor(Function(ticket) ticket.descricao, 10, 100, New With {.Class = "form-control descricaoTicket", .placeholder = "Insira a descrição aqui"})
                     </div>
                 </section>
             </div>

             <div class="tab-pane fade" id="datas" role="tabpanel" aria-labelledby="datas-tab">
                 <div id="datasTicket">
                     <section>
                         @Html.LabelFor(Function(ticket) ticket.dataAbertura, New With {.class = "form-check-label"})
                         <input type="date" name="dataAbertura" value="@tempoActual" id="dataAbertura" class="form-control" />
                     </section>
                     <section>
                         @Html.LabelFor(Function(ticket) ticket.dataFecho, New With {.class = "form-check-label"})
                         <input type="date" name="dataFecho" id="dataFecho" class="form-control" />
                     </section>

                     <section>
                         @Html.LabelFor(Function(ticket) ticket.tempoPrevisto, New With {.class = "form-check-label"})
                         @Html.TextBoxFor(Function(ticket) ticket.tempoPrevisto, New With {.class = "form-control", .Value = "0"})
                     </section>
                     <section>
                         @Html.LabelFor(Function(ticket) ticket.tempoTotal, New With {.class = "form-check-label"})
                         @Html.TextBoxFor(Function(ticket) ticket.tempoTotal, New With {.class = "form-control", .Value = "0"})
                     </section>
                 </div>
             </div>

             <div class="tab-pane fade" id="misc" role="tabpanel" aria-labelledby="misc-tab">
                 <section>
                     @Html.LabelFor(Function(ticket) ticket.ID_estado, New With {.class = "form-check-label"})
                     @Html.DropDownList("ID_estado", DirectCast(ViewBag.estado, SelectList), New With {.class = "form-control"})
                 </section>
                 <section>
                     @Html.LabelFor(Function(ticket) ticket.ID_prioridade, New With {.class = "form-check-label"})
                     @Html.DropDownList("ID_prioridade", DirectCast(ViewBag.prioridade, SelectList), New With {.class = "form-control"})
                 </section>
                 @*<div class="col-sm-4">
                @Html.LabelFor(Function(ticket) ticket.ID_utilizador, New With {.class = "form-check-label"})
                @Html.DropDownList("ID_utilizador", DirectCast(ViewBag.utilizador, SelectList), New With {.class = "form-control"})
            </div>*@
                 <section>
                     @Html.LabelFor(Function(ticket) ticket.ID_origem, New With {.class = "form-check-label"})
                     @Html.DropDownList("ID_origem", DirectCast(ViewBag.origem, SelectList), New With {.class = "form-control"})
                 </section>

             </div>
         </div>






       
        

         <div class="col-sm-12" style="padding-top:15px;">
             <input type="submit" class="btn btn-primary" value="Enviar Dados" />
             @Html.ActionLink("Voltar", "Index", Nothing, htmlAttributes:=New With {.class = "btn btn-secondary"})

         </div>
     </div>
    </div>
End Using
