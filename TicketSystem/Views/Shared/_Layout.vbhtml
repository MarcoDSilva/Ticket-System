<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Ticket System</title>
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
                    <li class="nav-item active">
                    <li class="nav-item">@Html.ActionLink("Home", "Index", "Home", New With {.area = ""}, New With {.class = "nav-link"})</li>
                    <li class="nav-item">@Html.ActionLink("About", "About", "Home", New With {.area = ""}, New With {.class = "nav-link"})</li>
                    <li class="nav-item">@Html.ActionLink("Contact", "Contact", "Home", New With {.area = ""}, New With {.class = "nav-link"})</li>
                    <li class="nav-item">@Html.ActionLink("Software", "Index", "Softwares", New With {.area = ""}, New With {.class = "nav-link"})</li>
                    <li class="nav-item">@Html.ActionLink("Problemas", "Index", "Problemas", New With {.area = ""}, New With {.class = "nav-link"})</li>
                    <li class="nav-item">@Html.ActionLink("Estados", "Index", "Estados", New With {.area = ""}, New With {.class = "nav-link"})</li>
                    <li class="nav-item">@Html.ActionLink("Prioridades", "Index", "Prioridades", New With {.area = ""}, New With {.class = "nav-link"})</li>
                    <li class="nav-item">@Html.ActionLink("Origens", "Index", "Origens", New With {.area = ""}, New With {.class = "nav-link"})</li>
                    <li class="nav-item">@Html.ActionLink("Tecnicos", "Index", "Tecnicos", New With {.area = ""}, New With {.class = "nav-link"})</li>
                    <li class="nav-item">@Html.ActionLink("Eventos", "Index", "Eventos", New With {.area = ""}, New With {.class = "nav-link"})</li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="container body-content dark">
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
