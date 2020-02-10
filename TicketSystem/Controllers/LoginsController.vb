Imports System.Web.Mvc
Imports System.Security.Authentication
Imports System.Security.Cryptography.SHA256
Imports System.Security.Claims


Namespace Controllers
    Public Class LoginsController
        Inherits Controller

        ' GET: Logins
        Function Index() As ActionResult

            If 1 = 1 Then
                Session("login") = "Josefina"
                Session("key") = 0
            Else
                Session("login") = "ERRO"
                Session("key") = 1
            End If

            'Dim u As New HttpCookie("tobias")
            'u.Name = "tobias"
            'u("user") = "toby"
            'u("pw") = "b"
            'u.Secure = True
            'u.Domain = "www.google.pt"
            'u.Value = 1
            'u.Expires.Add(New TimeSpan(0, 20, 0))
            'Response.Cookies.Add(u)
            'TempData("tobias") = "tobias"

            'Session("valor") = "sem valor"

            Return View()
        End Function
    End Class
End Namespace