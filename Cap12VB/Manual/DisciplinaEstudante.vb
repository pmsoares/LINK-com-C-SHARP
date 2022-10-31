Imports System.Data.Linq
Imports System.Data.Linq.Mapping

Namespace LINQToSQL.Manual
  <Table(Name:="DisciplinasEstudantes")> _
  Public Class DisciplinasEstudantes
    Private _IdDisciplinaEstudante As Integer
    <Column(IsPrimaryKey:=True, IsDbGenerated:=True, DbType:="INT NOT NULL IDENTITY", AutoSync:=AutoSync.OnInsert)> _
    Public Property IdDisciplinaEstudante() As Integer
      Get
        Return _IdDisciplinaEstudante
      End Get
      Set(ByVal value As Integer)
        _IdDisciplinaEstudante = value
      End Set
    End Property
    Private _IdDisciplina As Integer
    <Column()> _
    Public Property IdDisciplina() As Integer
      Get
        Return _IdDisciplina
      End Get
      Set(ByVal value As Integer)
        _IdDisciplina = value
      End Set
    End Property
    Private _IdEstudante As Integer
    <Column()> _
    Public Property IdEstudante() As Integer
      Get
        Return _IdEstudante
      End Get
      Set(ByVal value As Integer)
        _IdEstudante = value
      End Set
    End Property

    Private _estudante As EntityRef(Of Estudante)
    <Association(Storage:="_estudante", ThisKey:="IdEstudante", OtherKey:="IdEstudante")> _
    Public Property Estudante() As Estudante
      Get
        Return _estudante.Entity
      End Get
      Set(ByVal value As Estudante)
        _estudante.Entity = value
      End Set
    End Property

    Private _disciplina As EntityRef(Of Disciplina)
    <Association(Storage:="_disciplina", ThisKey:="IdDisciplina", OtherKey:="IdDisciplina")> _
    Public Property Disciplina() As Disciplina
      Get
        Return _disciplina.Entity
      End Get
      Set(ByVal value As Disciplina)
        _disciplina.Entity = value
      End Set
    End Property
  End Class
End Namespace

