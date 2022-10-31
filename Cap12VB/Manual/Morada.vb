Imports System.Data.Linq
Imports System.Data.Linq.Mapping

Namespace LINQToSQL.Manual
  <Table(Name:="Moradas")> _
  Public Class Morada
    Private _IdMorada As Integer
    <Column(IsPrimaryKey:=True, IsDbGenerated:=True, DbType:="INT NOT NULL IDENTITY", AutoSync:=AutoSync.OnInsert)> _
    Public Property IdMorada() As Integer
      Get
        Return _IdMorada
      End Get
      Set(ByVal value As Integer)
        _IdMorada = value
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
    Private _Rua As String
    <Column()> _
    Public Property Rua() As String
      Get
        Return _Rua
      End Get
      Set(ByVal value As String)
        _Rua = value
      End Set
    End Property
    Private _CodigoPostal As String
    <Column()> _
    Public Property CodigoPostal() As String
      Get
        Return _CodigoPostal
      End Get
      Set(ByVal value As String)
        _CodigoPostal = value
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

    Private _estudante As EntityRef(Of Estudante)
    <Association(Storage:="_estudante", ThisKey:="IdEstudante", OtherKey:="IdEstudante", IsUnique:=True, IsForeignKey:=True, DeleteOnNull:=True)> _
    Public Property Estudante() As Estudante
      Get
        Return _estudante.Entity
      End Get
      Set(ByVal value As Estudante)
        _estudante.Entity = value
      End Set
    End Property
  End Class
End Namespace

