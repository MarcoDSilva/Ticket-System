﻿<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Ticket System</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Ticket System", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>@Html.ActionLink("Home", "Index", "Home", New With {.area = ""}, New With {.Class = "navbar-brand"})</li>
                    <li>@Html.ActionLink("About", "About", "Home", New With {.area = ""}, New With {.Class = "navbar-brand"})</li>
                    <li>@Html.ActionLink("Contact", "Contact", "Home", New With {.area = ""}, New With {.Class = "navbar-brand"})</li>
                    <li>@Html.ActionLink("Software", "Index", "Softwares")</li>
                    <li>@Html.ActionLink("Problemas", "Index", "Problemas")</li>
                    <li>@Html.ActionLink("Estados", "Index", "Estados")</li>
                    <li>@Html.ActionLink("Prioridades", "Index", "Prioridades")</li>
                    <li>@Html.ActionLink("Origens", "Index", "Origens")</li>
                    <li>@Html.ActionLink("Tecnicos", "Index", "Tecnicos")</li>
                </ul>

            </div>
        </div>
    </div>
    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
                        <p>&copy; @DateTime.Now.Year - Ticket System by ms</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
