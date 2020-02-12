Imports System.Web.Mvc
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
            Else
                Session("Login") = 1

                Dim tecnicoLogado As New VM_TecnicoLogin()
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
                    Session("Email") = tecnicoLogado.Email.ToString()
                    Session("Nome") = tecnicoLogado.Nome.ToString()
                End If
            End If

            Return View()
        End Function

        'GET:
        Function CriarLogin() As ActionResult
            'If String.IsNullOrEmpty((Session("Nome"))) Or Session("Administrador") <> 1 Then
            '    Response.Redirect("~/Logins/Index")
            'End If
            Return View()
        End Function

        'POST:
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function CriarLogin(Login As Login) As ActionResult
            Session("NovoLogin") = 0
            ' Session("NovoLoginErro") = 0

            'If String.IsNullOrEmpty((Session("Nome"))) Or Session("Administrador") <> 1 Then
            '    Response.Redirect("~/Logins/Index")
            'End If
            If ModelState.IsValid() Then
                'testa valores na bd a ver se os mesmos funcionam e se este valor de retorno realmente funciona
            End If

            Return View(Login)
        End Function

        ''' <summary>
        ''' Reset em todas as sessões do login
        ''' </summary>
        ''' <returns></returns>
        Function Logout() As ActionResult
            Session("Administrador") = 0
            Session("LoginErrado") = 0
            Session("Login") = 0
            Session("Email") = ""
            Session("Nome") = ""

            Return Redirect("~/Home/Index")
        End Function

        Function RecuperaPassword(email As String) As ActionResult
            'procurar na bd correspondente ao email
            'se encontrado, dar ordem de reset (para o email)
            'se não encontrado, dar aviso de email não valido
            Return View()
        End Function

        Private Sub BloqueiaUtilizadores()
            If String.IsNullOrEmpty((Session("Nome"))) Or Session("Administrador") <> 1 Then
                Response.Redirect("~/Logins/Index")
            End If
        End Sub

    End Class
End Namespace