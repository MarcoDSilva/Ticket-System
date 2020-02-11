Public Class HomeController
    Inherits System.Web.Mvc.Controller

    'GET:
    Function Index() As ActionResult
        If String.IsNullOrEmpty((Session("Nome"))) Then
            Response.Redirect("~/Logins/Index")
        End If
        Return View()
    End Function

End Class
