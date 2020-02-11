Imports System.Web.Mvc
Imports System.Security.Authentication
Imports System.Security.Cryptography.SHA256
Imports System.Security.Claims


Namespace Controllers
    Public Class LoginsController
        Inherits Controller

        Private conectaBD As New ManuseiaLogin

        ' GET: Logins
        Function Index() As ActionResult
            If 1 = 1 Then
                Session("login") = "Josefina"
                Session("key") = 0

            Else
                Session("login") = "ERRO"
                Session("key") = 1
            End If

            Return View()
        End Function


        'POST:
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Index(email As String, password As String) As ActionResult


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