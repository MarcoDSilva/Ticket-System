Imports System.Web.Mvc
Imports System.Net

Namespace Controllers
    Public Class TecnicosController
        Inherits Controller

        Dim conectaBD As New Manipula_TTecnico

        ' GET: Tecnicos
        Function Index() As ActionResult
            Return View(LeituraDados($"SELECT * FROM Tecnico;"))
        End Function

        'GET
        Function CriaTecnico() As ActionResult
            Return View()
        End Function

        'POST
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function CriaTecnico(nome As String, email As String) As ActionResult
            If String.IsNullOrEmpty(nome) Or String.IsNullOrEmpty(email) Then
                Return View()
            Else
                conectaBD.AdicionaTecnico(nome, email)
            End If
            Return RedirectToAction("Index")
        End Function

        'GET:
        Function EditarTecnico(ID_tecnico As Integer?) As ActionResult
            Return View(LeituraDados($"SELECT * FROM Tecnico WHERE ID_tecnico = {ID_tecnico}").First())
        End Function

        'POST:
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function EditarTecnico(nome As String, email As String, ID_tecnico As Integer?) As ActionResult
            If String.IsNullOrEmpty(nome) Or String.IsNullOrEmpty(email) Or ID_tecnico.HasValue.Equals(False) Then
                Return View()
            Else
                conectaBD.EditaTecnico(nome, email, ID_tecnico)
            End If
            Return RedirectToAction("Index")
        End Function

        'Apaga o tecnico que corresponde ao ID enviado
        Function ApagarTecnico(ID_tecnico As Integer?) As ActionResult
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
        Function LeituraDados(query As String) As List(Of Tecnico)

            Dim tabelaDados As DataTable = conectaBD.LeituraTabela(query)
            Dim listagemTecnicos As List(Of Tecnico) = New List(Of Tecnico)

            'fazemos um ciclo, que vai iterar por cada elemento que recebenos da base de dados
            'criamos um novo objecto do tipo Tecnico, onde atribuimos os dados da iteração actual
            'e no fim após a atribuição desses dados, inserimos numa List(a) de Tecnicos, o qual usamos para retornar os dados
            For Each item In tabelaDados.AsEnumerable
                Dim tec As New Tecnico()

                tec.ID_tecnico = item(0)
                tec.nome = item(1)
                tec.email = item(2)
                tec.dat_hor = item(3)

                listagemTecnicos.Add(tec)
            Next

            Return listagemTecnicos
        End Function

    End Class
End Namespace