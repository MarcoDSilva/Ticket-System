Imports System.Web.Mvc
Imports System.Net

Namespace Controllers
    Public Class TecnicosController
        Inherits Controller

        Dim conectaBD As New Manipula_TTecnico

        ' GET: Tecnicos
        Function Index() As ActionResult
            BloqueiaUtilizadores()
            Return View(LeituraDados($"SELECT t.ID_tecnico, t.nome,t.email,r.descricao, t.dat_hor 
                                     FROM Tecnico t
                                     INNER JOIN Role r on t.ID_role = r.ID_role;"))
        End Function

        'GET
        Function CriaTecnico() As ActionResult
            'BloqueiaUtilizadores()

            Return View()
        End Function

        'POST
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function CriaTecnico(nome As String, email As String) As ActionResult
            BloqueiaUtilizadores()

            If String.IsNullOrEmpty(nome) Or String.IsNullOrEmpty(email) Then
                Return View()
            Else
                conectaBD.AdicionaTecnico(nome, email)
            End If
            Return RedirectToAction("Index")
        End Function

        'GET:
        Function EditarTecnico(ID_tecnico As Integer?) As ActionResult
            BloqueiaUtilizadores()
            ViewBag.roles = New SelectList(conectaBD.ListaRoles(), "ID_role", "descricao")

            Return View(LeituraDados($"SELECT ID_tecnico,nome,email,ID_role, dat_hor 
                                     FROM Tecnico 
                                     WHERE ID_tecnico = {ID_tecnico}").First())
        End Function

        'POST:
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function EditarTecnico(nome As String, email As String, ID_tecnico As Integer?) As ActionResult
            BloqueiaUtilizadores()
            If String.IsNullOrEmpty(nome) Or String.IsNullOrEmpty(email) Or ID_tecnico.HasValue.Equals(False) Then
                Return View()
            Else
                conectaBD.EditaTecnico(nome, email, ID_tecnico)
            End If
            Return RedirectToAction("Index")
        End Function

        'Apaga o tecnico que corresponde ao ID enviado
        Function ApagarTecnico(ID_tecnico As Integer?) As ActionResult
            BloqueiaUtilizadores()
            If IsNothing(ID_tecnico) Then
                Return New HttpStatusCodeResult(HttpStatusCode.Forbidden)
            Else
                conectaBD.ApagaTecnico(ID_tecnico)
            End If
            Return RedirectToAction("Index")
        End Function


        ''' <summary>
        ''' Método interno utilizado para ler dados da bd
        ''' </summary>
        ''' <param name="query"></param>
        ''' <returns></returns>
        Function LeituraDados(query As String) As List(Of VM_TecnicoRole)
            Dim tabelaDados As DataTable = conectaBD.LeituraTabela(query)
            Dim listagemTecnicos As List(Of VM_TecnicoRole) = New List(Of VM_TecnicoRole)

            'fazemos um ciclo, que vai iterar por cada elemento que recebenos da base de dados
            'criamos um novo objecto do tipo Tecnico, onde atribuimos os dados da iteração actual
            'e no fim após a atribuição desses dados, inserimos numa List(a) de Tecnicos, o qual usamos para retornar os dados
            For Each item In tabelaDados.AsEnumerable
                Dim tec As New VM_TecnicoRole()

                tec.ID_tecnico = item(0)
                tec.nome = item(1)
                tec.email = item(2)
                tec.ID_role = item(3)
                tec.dat_hor = item(4)

                listagemTecnicos.Add(tec)
            Next

            Return listagemTecnicos
        End Function

        Private Sub BloqueiaUtilizadores()
            If String.IsNullOrEmpty((Session("Nome"))) Or Session("Administrador") <> 1 Then
                Response.Redirect("~/Logins/Index")
            End If
        End Sub

    End Class
End Namespace