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
    <link href="https://fonts.googleapis.com/css?family=Raleway:400,500i,800&display=swap" rel="stylesheet">
    <link href="~/img/kanban-fill.svg" rel="shortcut icon" type="image/svg"/>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    <div class="wrapper">

        <!-- NAVBAR -->
        @If Not String.IsNullOrEmpty((Session("Nome"))) And Not Session("Inativo") = 1 Then
            @<nav id="sidebar">
                <div class="sidebar-header">
                    <a onclick="location.href='@Url.Action("Index", "Home")'" class="logo" href="#">Ticket System</a>
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
                                @Html.ActionLink("Origens", "Index", "Origens")
                            </li>
                            <li>
                                @Html.ActionLink("Problemas", "Index", "Problemas")
                            </li>
                            @If Session("Administrador") = 1 Then
                                @<li>
                                    @Html.ActionLink("Estados", "Index", "Estados")
                                </li>
                            End If
                            <li>
                                @Html.ActionLink("Prioridades", "Index", "Prioridades")
                            </li>
                            <li>
                                @Html.ActionLink("Softwares", "Index", "Softwares")
                            </li>
                        </ul>
                    </li>

                    <li>
                        <a href="#gestaoSubmenu" data-toggle="collapse" aria-expanded="false" class="dropdown-toggle">
                            <img src="~/img/tools.svg" alt="" width="32" height="32" title="icon">
                            Gestão
                        </a>
                        <ul class="collapse list-unstyled" id="gestaoSubmenu">
                            <li>
                                @Html.ActionLink("Clientes", "Index", "Clientes")
                            </li>

                            @If Session("Administrador") = 1 Then
                                @<li>
                                    @Html.ActionLink("Tecnicos", "Index", "Tecnicos")
                                </li>
                                @<li>
                                    @Html.ActionLink("Utilizadores", "Index", "Utilizadores")
                                </li>
                            End If
                        </ul>
                    </li>
                </ul>
            </nav>
        End If

        <!-- navbar DA PÁGINA -->
    <div id="content">
        @If Not String.IsNullOrEmpty((Session("Nome"))) Then

            @<nav class="navbar navbar-dark shadow-sm navbar-expand-lg navColor">
                <button type="button" id="sidebarCollapse" class="btn btn-sm btnHamburguer">
                    <span class="navbar-toggler-icon"></span>
                </button>
                @If Session("Login") = 1 And Session("LoginErrado") = 0 Then
                    @<div class="container-fluid">
                            <span class="text-white font-weight-bold">@mensagem, @Session("Nome") | @Session("Email")</span>
                            <div class="btn-group-sm" role="group">
                                <button id="groupLogins" type="button" class="btn btnOpcoesMenu dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    Opções
                                </button>
                                <div class="dropdown-menu" style="right:0 !important;" aria-labelledby="groupLogins">
                                    <a class="dropdown-item" href="#" onclick="location.href='@Url.Action("AlterarPassword", "Logins", New With {.ID_tecnico = Session("ID_tecnico")})'">Alterar Password</a>
                                    <a class="dropdown-item" href="#" onclick="location.href='@Url.Action("Logout", "Logins")'">Logout</a>
                                </div>
                            </div>
                        </div>
                End If
            </nav>
        End If
        <!-- PÁGINA PARA RENDERIZAR DAS VIEWS-->
        @If String.IsNullOrEmpty((Session("Nome"))) Then
            @<div class="">
                @RenderBody()
                @*<footer class="card-footer">
                    <p>&copy; @DateTime.Now.Year - Ticket System by ms</p>
                </footer>*@
            </div>
        Else
            @<div class="background">
                @RenderBody()
                @*<footer class="card-footer">
                    <p>&copy; @DateTime.Now.Year - Ticket System by ms</p>
                </footer>*@
            </div>
        End If
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
