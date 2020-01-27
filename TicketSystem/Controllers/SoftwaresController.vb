Imports System.Web.Mvc
Imports System.Net

Namespace Controllers
    Public Class SoftwaresController
        Inherits Controller

        Private conectaBD As New Manipula_TSoftware

        ' GET: Softwares
        Function Index() As ActionResult
            Return View(LeituraDados("SELECT * FROM Software;"))
        End Function

        'GET: Softwares/EditarSoftware/ID_Software
        ''' <summary>
        ''' Recebe como input o software para procurar, e devolve-o com campos de edição
        ''' </summary>
        ''' <param name="ID_software"></param>
        ''' <returns></returns>
        Function EditarSoftware(ID_software As Integer) As ActionResult
            If IsNothing(ID_software) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            Else
                Dim software = LeituraDados($"SELECT * FROM Software WHERE ID_software = {ID_software};").First()
                Return View(software)
            End If
        End Function

        'POST: Actualizar o software se os parametros estiverem corretos
        ''' <summary>
        ''' Após o software ter sido enviado no campo de edição, faz as validações correspondentes
        ''' para actualizar o mesmo
        ''' </summary>
        ''' <param name="ID_software"></param>
        ''' <param name="nome"></param>
        ''' <returns></returns>
        <HttpPost()>
        Function EditarSoftware(ID_software As Integer, nome As String) As ActionResult
            If IsNothing(ID_software) Or String.IsNullOrEmpty(nome) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            Else
                Dim software = LeituraDados($"SELECT * FROM Software WHERE ID_software = {ID_software};").First()
                If software.ID_software.Equals(ID_software) Then
                    conectaBD.EditarSoftware(nome, ID_software)
                End If
            End If

            Return RedirectToAction("Index")
        End Function

        ''' <summary>
        ''' Cria um novo software
        ''' </summary>
        ''' <param name="nome"></param>
        ''' <returns></returns>
        Function CriaSoftware(nome As String) As ActionResult
            If String.IsNullOrEmpty(nome) Then
                Return View()
            Else
                conectaBD.AdicionaSoftware(nome)
                Return RedirectToAction("Index")
            End If

        End Function

        ''' <summary>
        ''' Apaga o software escolhido pelo utilizador
        ''' </summary>
        ''' <param name="ID_software"></param>
        ''' <returns></returns>
        Function ApagarSoftware(ID_software As Integer) As ActionResult
            If IsNothing(ID_software) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            Else
                conectaBD.ApagarSoftware(ID_software)
            End If
            Return RedirectToAction("Index")
        End Function


        ''' <summary>
        ''' Método interno utilizado para ler dados da bd
        ''' </summary>
        ''' <param name="query"></param>
        ''' <returns></returns>
        Function LeituraDados(query As String) As List(Of Software)

            Dim tabelaDados As DataTable = conectaBD.LeituraTabela(query)
            Dim listagemSoftware As List(Of Software) = New List(Of Software)

            'fazemos um ciclo, que vai iterar por cada elemento que recebenos da base de dados
            'criamos um novo objecto do tipo Softwares, onde atribuimos os dados da iteração actual
            'e no fim após a atribuição desses dados, inserimos numa List(a) de Softwares, o qual usamos para retornar os dados
            For Each item In tabelaDados.AsEnumerable
                Dim est As New Software()
                est.ID_software = item(0)
                est.nome = item(1)
                est.dat_hor = item(2)
                listagemSoftware.Add(est)
            Next

            Return listagemSoftware
        End Function

    End Class
End Namespace