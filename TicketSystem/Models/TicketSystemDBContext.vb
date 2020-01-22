Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class TicketSystemDBContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=TicketSystemSC")
    End Sub

    'todas as tabelas da base de dados que estão/vão ser manipuladas
    Public Overridable Property Cliente As DbSet(Of Cliente)
    Public Overridable Property Estado As DbSet(Of Estado)
    Public Overridable Property Evento As DbSet(Of Evento)
    Public Overridable Property Origem As DbSet(Of Origem)
    Public Overridable Property Prioridade As DbSet(Of Prioridade)
    Public Overridable Property Problema As DbSet(Of Problema)
    Public Overridable Property Software As DbSet(Of Software)
    Public Overridable Property sysdiagrams As DbSet(Of sysdiagrams)
    Public Overridable Property Tecnico As DbSet(Of Tecnico)
    Public Overridable Property Ticket As DbSet(Of Ticket)
    Public Overridable Property Utilizador As DbSet(Of Utilizador)


    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Cliente)() _
            .HasMany(Function(e) e.Ticket) _
            .WithRequired(Function(e) e.Cliente) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Cliente)() _
            .HasMany(Function(e) e.Utilizador1) _
            .WithRequired(Function(e) e.Cliente1) _
            .HasForeignKey(Function(e) e.ID_cliente) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Estado)() _
            .HasOptional(Function(e) e.Ticket) _
            .WithRequired(Function(e) e.Estado)

        modelBuilder.Entity(Of Evento)() _
            .Property(Function(e) e.descricao) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Evento)() _
            .HasMany(Function(e) e.Ticket1) _
            .WithRequired(Function(e) e.Evento1) _
            .HasForeignKey(Function(e) e.ID_evento) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Origem)() _
            .HasOptional(Function(e) e.Ticket) _
            .WithRequired(Function(e) e.Origem)

        modelBuilder.Entity(Of Prioridade)() _
            .HasMany(Function(e) e.Ticket) _
            .WithRequired(Function(e) e.Prioridade) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Problema)() _
            .HasMany(Function(e) e.Ticket) _
            .WithRequired(Function(e) e.Problema) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Software)() _
            .HasMany(Function(e) e.Ticket) _
            .WithRequired(Function(e) e.Software) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Tecnico)() _
            .HasMany(Function(e) e.Evento) _
            .WithRequired(Function(e) e.Tecnico) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Tecnico)() _
            .HasMany(Function(e) e.Ticket) _
            .WithRequired(Function(e) e.Tecnico) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Ticket)() _
            .Property(Function(e) e.descricao) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Ticket)() _
            .HasMany(Function(e) e.Evento) _
            .WithRequired(Function(e) e.Ticket) _
            .HasForeignKey(Function(e) e.ID_ticket) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Utilizador)() _
            .HasMany(Function(e) e.Cliente) _
            .WithRequired(Function(e) e.Utilizador) _
            .HasForeignKey(Function(e) e.ID_utilizador) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Utilizador)() _
            .HasOptional(Function(e) e.Ticket) _
            .WithRequired(Function(e) e.Utilizador)
    End Sub
End Class
