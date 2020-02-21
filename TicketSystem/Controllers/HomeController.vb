Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private conectaBD As New ObterDados

    'GET:
    Function Index() As ActionResult

        If String.IsNullOrEmpty((Session("Nome"))) Then
            Response.Redirect("~/Logins/Index")
        End If

        'As viewbags recebem o resultado da query, que é convertida num enumerable e depois chamado a primeira célula, do primeiro resultado do mesmo
        ViewBag.totalTickets = conectaBD.LeituraTabela("SELECT COUNT(*) FROM Ticket;").AsEnumerable().First().Item(0)

        ViewBag.ticketsConcluidos = conectaBD.LeituraTabela("SELECT COUNT(*) FROM Ticket t 
                                                            WHERE t.ID_estado = 6;").AsEnumerable().First().Item(0)

        ViewBag.ticketsNovos = conectaBD.LeituraTabela("SELECT COUNT(*) FROM Ticket t 
                                                            WHERE t.ID_estado = 2").AsEnumerable().First().Item(0)

        ViewBag.ticketsNaoConcluidos = conectaBD.LeituraTabela("SELECT COUNT(*) FROM Ticket t 
                                                            WHERE t.ID_estado <> 6").AsEnumerable().First().Item(0)

        ViewBag.ticketsAnoActual = conectaBD.LeituraTabela($"SELECT COUNT(*) FROM Ticket t 
                                                            WHERE Year(t.dataAbertura) = '{DateTime.Now.Year.ToString()}';").
                                                            AsEnumerable().First().Item(0)

        ViewBag.ticketsMesActual = conectaBD.LeituraTabela($"SELECT COUNT(*) FROM Ticket t 
                                                            WHERE Year(t.dataAbertura) = '{DateTime.Now.Month.ToString()}';").
                                                            AsEnumerable().First().Item(0)

        Return View()
    End Function

End Class
