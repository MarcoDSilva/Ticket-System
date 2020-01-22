Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports TicketSystem

Namespace Controllers
    Public Class SoftwaresController
        Inherits System.Web.Mvc.Controller

        Private db As New TicketSystemDBContext

        ' GET: Softwares
        Function Index() As ActionResult
            Return View(db.Software.ToList())
        End Function

        ' GET: Softwares/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim software As Software = db.Software.Find(id)
            If IsNothing(software) Then
                Return HttpNotFound()
            End If
            Return View(software)
        End Function

        ' GET: Softwares/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Softwares/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID_software,nome,dat_hor")> ByVal software As Software) As ActionResult
            If ModelState.IsValid Then
                db.Software.Add(software)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(software)
        End Function

        ' GET: Softwares/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim software As Software = db.Software.Find(id)
            If IsNothing(software) Then
                Return HttpNotFound()
            End If
            Return View(software)
        End Function

        ' POST: Softwares/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID_software,nome,dat_hor")> ByVal software As Software) As ActionResult
            If ModelState.IsValid Then
                db.Entry(software).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(software)
        End Function

        ' GET: Softwares/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim software As Software = db.Software.Find(id)
            If IsNothing(software) Then
                Return HttpNotFound()
            End If
            Return View(software)
        End Function

        ' POST: Softwares/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim software As Software = db.Software.Find(id)
            db.Software.Remove(software)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
