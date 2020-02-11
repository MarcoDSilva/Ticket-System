﻿Imports System.Web.Mvc
Imports System.Security.Authentication
Imports System.Security.Cryptography.SHA256
Imports System.Security.Claims
Imports System.Net

Namespace Controllers
    Public Class LoginsController
        Inherits Controller

        Private conectaBD As New ManuseiaLogin

        ' GET: Logins
        Function Index() As ActionResult
            Return View()
        End Function


        'POST: Recebe os dados para validação do login.
        'Se o role equivaler a admin , passamos a informação que é admin e desbloqueamos as views
        'de administração, caso contrário, mostramos ou a informação normal, ou nenhuma se falhou o login 
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Index(email As String, password As String) As ActionResult

            If String.IsNullOrEmpty(email) Or String.IsNullOrEmpty(password) Then
                Session("LoginErrado") = 1
                Session("Login") = 1
                'Session("Email") = Nothing
                'Session("Administrador") = 0
            Else
                Session("Login") = 1

                Dim tecnicoLogado As New Login()
                tecnicoLogado = conectaBD.Login(password, email)

                If IsNothing(tecnicoLogado) Then
                    Session("LoginErrado") = 1
                Else

                    If tecnicoLogado.ID_role = 1 Then
                        Session("Administrador") = 1
                    Else
                        Session("Administrador") = 0
                    End If

                    Session("LoginErrado") = 0
                    Session("Login") = 1
                    Session("Email") = tecnicoLogado.email.ToString()
                End If
            End If

            Return View()
        End Function

        Function CriarLogin() As ActionResult
            Return View()
        End Function

        Function Login() As ActionResult

        End Function

        Function Logout() As ActionResult

        End Function
    End Class
End Namespace