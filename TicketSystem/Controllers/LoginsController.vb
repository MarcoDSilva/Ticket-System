Namespace Controllers
    Public Class LoginsController
        Inherits Controller

        Private conectaBD As New ManuseiaLogin
        Private lerDados As New ObterDados

        ' GET: Logins
        Function Index() As ActionResult
            Return View()
        End Function


        'POST: Recebe os dados para validação do login.
        'Se o role equivaler a admin , passamos a informação que é admin e desbloqueamos as views
        'de administração, caso contrário, mostramos ou a informação normal, ou nenhuma se falhou o login 
        'Roles na DB -> | 1 - admin | 2 - tecnico | 4 - inactivo
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Index(email As String, password As String) As ActionResult

            If String.IsNullOrEmpty(email) Or String.IsNullOrEmpty(password) Then
                Session("LoginErrado") = 1
                Session("Login") = 1
            Else
                Session("Login") = 1

                Dim tecnicoLogado As New Tecnico()
                tecnicoLogado = conectaBD.Login(password, email)

                If IsNothing(tecnicoLogado) Then
                    Session("LoginErrado") = 1
                Else
                    If tecnicoLogado.ID_role = 1 Then
                        Session("Administrador") = 1
                    Else
                        Session("Administrador") = 0
                    End If

                    If tecnicoLogado.ID_role = 4 Then
                        Session("Inativo") = 1
                    Else
                        Session("Inativo") = 0
                    End If

                    Session("LoginErrado") = 0
                    Session("Login") = 1
                    Session("Email") = tecnicoLogado.email.ToString()
                    Session("Nome") = tecnicoLogado.nome.ToString()
                    Session("ID_tecnico") = tecnicoLogado.ID_tecnico
                End If
            End If

            Return View()
        End Function

        ''' <summary>
        ''' Reset em todas as sessões do login
        ''' </summary>
        ''' <returns></returns>
        Function Logout() As ActionResult
            BloqueiaUtilizadores()
            Session("Administrador") = 0
            Session("LoginErrado") = 0
            Session("Login") = 0
            Session("Email") = ""
            Session("Nome") = ""
            Session("Inativo") = 0
            Session("ID_tecnico") = 0

            Return Redirect("~/Home/Index")
        End Function

        ''' <summary>
        ''' reset na password do user cujo email foi pedido
        ''' </summary>
        ''' <param name="email"></param>
        ''' <returns></returns>
        Function RecuperaPassword(email As String) As ActionResult
            BloqueiaUtilizadores()
            'procurar na bd correspondente ao email
            'se encontrado, dar ordem de reset (para o email)
            'se não encontrado, dar aviso de email não valido
            Return View()
        End Function

        'GET:
        Function AlterarPassword(ID_tecnico As Integer) As ActionResult
            BloqueiaUtilizadores()
            Return View(LeituraDados($"SELECT ID_tecnico, nome FROM Tecnico
                                                  WHERE ID_tecnico = {ID_tecnico}").First())
        End Function

        'POST: 
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function AlterarPassword(tec As Tecnico, passwordAntiga As String) As ActionResult
            BloqueiaUtilizadores()

            If Not ModelState.IsValid() Then
                Return View(tec)
            Else
                If conectaBD.AlterarPassword(tec.ID_tecnico, tec.email, tec.password, passwordAntiga) Then

                End If
            End If

                Return View()
        End Function

        Private Sub BloqueiaUtilizadores()
            If String.IsNullOrEmpty((Session("Nome"))) Or Session("Administrador") <> 1 Or Session("Inativo") = 1 Then
                Response.Redirect("~/Logins/Index")
            End If
        End Sub

        ''' <summary>
        ''' Método interno utilizado para ler dados da bd
        ''' </summary>
        ''' <param name="query"></param>
        ''' <returns></returns>
        Function LeituraDados(query As String) As List(Of Tecnico)
            Dim tabelaDados As DataTable = lerDados.LeituraTabela(query)
            Dim listagemTecnicos As List(Of Tecnico) = New List(Of Tecnico)

            'fazemos um ciclo, que vai iterar por cada elemento que recebenos da base de dados
            'criamos um novo objecto do tipo Tecnico, onde atribuimos os dados da iteração actual
            'e no fim após a atribuição desses dados, inserimos numa List(a) de Tecnicos, o qual usamos para retornar os dados
            For Each item In tabelaDados.AsEnumerable
                Dim tec As New Tecnico()

                tec.ID_tecnico = item(0)
                tec.nome = item(1)
                listagemTecnicos.Add(tec)
            Next

            Return listagemTecnicos
        End Function
    End Class
End Namespace