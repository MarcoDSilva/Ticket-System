﻿@Code
    Dim dataDia = DateTime.Now.Hour
    Dim mensagem As String
    If Convert.ToInt16(dataDia) >= 6 And Convert.ToInt16(dataDia) <= 12 Then
        mensagem = "Bom dia"
    Else
        If Convert.ToInt16(dataDia) > 12 And Convert.ToInt16(dataDia) <= 18 Then
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
    <div class="wrapper">

        <!-- NAVBAR -->
        @If Not String.IsNullOrEmpty((Session("Nome"))) Then
            @<nav id="sidebar">
                <div class="sidebar-header">
                    <h3>Menu lateral</h3>
                </div>

                <ul class="list-unstyled components">
                    <li>
                        <a href="#listagensSubmenu" data-toggle="collapse" aria-expanded="false" class="dropdown-toggle">   
                            <img src="~/img/list.svg" alt="" width="32" height="32" title="icon">
                            Listagens
                        </a>
                        <ul class="collapse list-unstyled " id="listagensSubmenu">
                            <li>
                                @Html.ActionLink("Tickets", "Index", "Tickets")
                            </li>
                            <li>
                                @Html.ActionLink("Eventos", "Index", "Eventos")
                            </li>
                        </ul>
                    </li>

                    <li>
                        <a href="#tabelasSubmenu" data-toggle="collapse" aria-expanded="false" class="dropdown-toggle">
                            <img src="~/img/table.svg" alt="" width="32" height="32" title="icon">
                            Tabelas
                        </a>
                        <ul class="collapse list-unstyled" id="tabelasSubmenu">
                            <li>
                                @Html.ActionLink("Tecnicos", "Index", "Tecnicos")
                            </li>
                            <li>
                                @Html.ActionLink("Clientes", "Index", "Clientes")
                            </li>
                            <li>
                                @Html.ActionLink("Origens", "Index", "Origens")
                            </li>
                            <li>
                                @Html.ActionLink("Problemas", "Index", "Problemas")
                            </li>
                            <li>
                                @Html.ActionLink("Estados", "Index", "Estados")
                            </li>
                            <li>
                                @Html.ActionLink("Prioridades", "Index", "Prioridades")
                            </li>
                        </ul>
                    </li>

                    <li>
                        <a href="#gestaoSubmenu" data-toggle="collapse" aria-expanded="false" class="dropdown-toggle">Gestão</a>
                        <ul class="collapse list-unstyled" id="gestaoSubmenu">
                            <li>
                                @Html.ActionLink("Utilizadores", "Index", "Utilizadores")
                            </li>
                            <li>
                                @Html.ActionLink("Tecnicos", "Index", "Tecnicos")
                            </li>
                            <li>
                                @Html.ActionLink("Clientes", "Index", "Clientes")
                            </li>
                        </ul>
                    </li>
                </ul>
            </nav>
        End If

        <!-- MENU DA PÁGINA -->
        <div id="content">
            <nav class="navbar navbar-dark shadow-sm navbar-expand-lg navColor">
                @If Not String.IsNullOrEmpty((Session("Nome"))) Then
                    @<button type="button" id="sidebarCollapse" Class="btn btn-secondary">
                        <i Class="fas fa-align-left"></i>
                        <span Class="navbar-toggler-icon"></span>
                    </button>
                End If

                <a class="navbar-brand" href="#">
                    @Html.ActionLink("Ticket System", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
                </a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                @If Session("Login") = 1 And Session("LoginErrado") = 0 Then
                    @<div class="container">
                        <p class="text-white font-weight-bold">@mensagem, @Session("Nome") - @Session("Email")</p>
                        <div class="btn-group-sm" role="group" style="margin-left:20px;">
                            <button id="groupLogins" type="button" class="btn btn-secondary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Opções
                            </button>
                            <div class="dropdown-menu align-content-end" aria-labelledby="groupLogins">
                                <a class="dropdown-item" href="#" onclick="location.href='@Url.Action("AlterarPassword", "Logins", New With {.ID_tecnico = Session("ID_tecnico")})'">Alterar Password</a>
                                <a class="dropdown-item" href="#" onclick="location.href='@Url.Action("Logout", "Logins")'">Logout</a>
                            </div>
                        </div>
                    </div>
                End If
            </nav>

            <!-- PÁGINA PARA RENDERIZAR DAS VIEWS-->
            <div>
                @RenderBody()
                <footer class="card-footer">
                    <p>&copy; @DateTime.Now.Year - Ticket System by ms</p>
                </footer>
            </div>
        </div>


    </div>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
    <script>
        $(document).ready(function () {

            $('#sidebarCollapse').on('click', function () {
                $('#sidebar').toggleClass('active');
            });

        });
    </script>
</body>
</html>
