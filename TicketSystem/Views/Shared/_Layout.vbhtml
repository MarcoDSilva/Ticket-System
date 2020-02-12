@Code
    Dim dataDia As DateTime = DateTime.Now
    Dim mensagem As String
    If dataDia.Hour > 6 And dataDia.Hour < 12 Then
        mensagem = "Bom dia"
    Else
        If dataDia.Hour > 12 And dataDia.Hour < 18 Then
            mensagem = "Boa tarde"
        Else
            mensagem = "Boa Noite"
        End If
    End If
End Code

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Ticket System - @ViewBag.Title</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    <nav class="navbar navbar-dark bg-dark shadow-sm navbar-expand-lg">
        <div class="container">
            <a class="navbar-brand" href="#">
                @Html.ActionLink("Ticket System", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item">@Html.ActionLink("Home", "Index", "Home", New With {.area = ""}, New With {.class = "nav-link"})</li>
                </ul>
                <!--Drop down das listagens -->
                <div class="dropdown show">

                    @If Not String.IsNullOrEmpty((Session("Nome"))) Then
                        @<a Class="btn btn-secondary btn-sm dropdown-toggle bg-dark" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Listagens
                        </a>
                        @<div Class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                            <a Class="dropdown-item">@Html.ActionLink("Software", "Index", "Softwares", New With {.area = ""}, New With {.class = "nav-link"})</a>
                            <a Class="dropdown-item">@Html.ActionLink("Problemas", "Index", "Problemas", New With {.area = ""}, New With {.class = "nav-link"})</a>
                            <a Class="dropdown-item">@Html.ActionLink("Estados", "Index", "Estados", New With {.area = ""}, New With {.class = "nav-link"})</a>
                            <a Class="dropdown-item">@Html.ActionLink("Prioridades", "Index", "Prioridades", New With {.area = ""}, New With {.class = "nav-link"})</a>
                            <a Class="dropdown-item">@Html.ActionLink("Origens", "Index", "Origens", New With {.area = ""}, New With {.class = "nav-link"})</a>
                            <a Class="dropdown-item">@Html.ActionLink("Tecnicos", "Index", "Tecnicos", New With {.area = ""}, New With {.class = "nav-link"})</a>
                            <a Class="dropdown-item">@Html.ActionLink("Eventos", "Index", "Eventos", New With {.area = ""}, New With {.class = "nav-link"})</a>
                            <a Class="dropdown-item">@Html.ActionLink("Clientes", "Index", "Clientes", New With {.area = ""}, New With {.class = "nav-link"})</a>
                            <a Class="dropdown-item">@Html.ActionLink("Utilizadores", "Index", "Utilizadores", New With {.area = ""}, New With {.class = "nav-link"})</a>
                            <a Class="dropdown-item">@Html.ActionLink("Tickets", "Index", "Tickets", New With {.area = ""}, New With {.class = "nav-link"})</a>
                        </div>
                    End If

                </div>
            </div>
            @If Session("Login") = 1 And Session("LoginErrado") = 0 Then
                @<div class="form-check-inline">
                    <p class="text-white font-weight-bold">@mensagem, @Session("Nome") - @Session("Email")</p>
                    <div class="btn-group-sm" role="group" style="margin-left:20px;">
                        <button id="groupLogins" type="button" class="btn btn-secondary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Opções
                        </button>
                        <div class="dropdown-menu align-content-end" aria-labelledby="groupLogins">
                            <a class="dropdown-item" href="#">Alterar Password</a>
                            <a class="dropdown-item" href="#" onclick="location.href='@Url.Action("Logout", "Logins")'">Logout</a>
                        </div>
                    </div>
                </div>
            End If


        </div>
        
    </nav>
    <div Class="container body-content dark">
        @RenderBody()
        <footer class="card-footer">
            <p>&copy; @DateTime.Now.Year - Ticket System by ms</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
