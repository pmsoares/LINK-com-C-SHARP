Imports System.Collections.Generic
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq

Namespace LINQToSQL.Manual
  <Table(Name:="Estudantes")> _
  Public Class Estudante
    Private _IdEstudante As Integer
    <Column(IsPrimaryKey:=True, IsDbGenerated:=True, DbType:="INT NOT NULL IDENTITY", AutoSync:=AutoSync.OnInsert)> _
    Public Property IdEstudante() As Integer
      Get
        Return _IdEstudante
      End Get
      Set(ByVal value As Integer)
        _IdEstudante = value
      End Set
    End Property
    Private _Nome As String
    <Column()> _
    Public Property Nome() As String
      Get
        Return _Nome
      End Get
      Set(ByVal value As String)
        _Nome = value
      End Set
    End Property
    Private _Versao As Byte()
    <Column(IsVersion:=True)> _
    Public Property Versao() As Byte()
      Get
        Return _Versao
      End Get
      Set(ByVal value As Byte())
        _Versao = value
      End Set
    End Property

    Private _morada As EntityRef(Of Morada)
    <Association(Storage:="_morada", ThisKey:="IdEstudante", OtherKey:="IdEstudante")> _
    Public Property Morada() As Morada
      Get
        Return _morada.Entity
      End Get
      Set(ByVal value As Morada)
        _morada.Entity = value
      End Set
    End Property

    

    Private _contactos As EntitySet(Of Contacto)
    <Association(Storage:="_contactos", OtherKey:="IdEstudante", ThisKey:="IdEstudante")> _
    Public Property Contactos() As IList(Of Contacto)
      Get
        Return _contactos
      End Get
      Set(ByVal value As IList(Of Contacto))
        _contactos.Assign(value)
      End Set
    End Property

    <Association(ThisKey:="IdEstudante", OtherKey:="IdEstudante")> _
    Private DisciplinasEstudantes As EntitySet(Of DisciplinasEstudantes)
    Public ReadOnly Property Disciplinas() As IEnumerable(Of Disciplina)
      Get
        Return DisciplinasEstudantes.[Select](Function(d) d.Disciplina)
      End Get
    End Property

    Public Sub Detach()
      _morada = Nothing
      _contactos = New EntitySet(Of Contacto)()
      DisciplinasEstudantes = New EntitySet(Of DisciplinasEstudantes)()
    End Sub
  End Class




End Namespace

