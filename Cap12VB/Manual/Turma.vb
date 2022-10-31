Imports System.Data.Linq.Mapping

Namespace LINQToSQL.Manual
  <Table(Name:="Turmas")> _
  Public Class Turma
    Private _IdTurma As Integer
    <Column(IsPrimaryKey:=True, IsDbGenerated:=True, DbType:="INT NOT NULL IDENTITY", AutoSync:=AutoSync.OnInsert)> _
    Public Property IdTurma() As Integer
      Get
        Return _IdTurma
      End Get
      Set(ByVal value As Integer)
        _IdTurma = value
      End Set
    End Property
    Private _Designacao As String
    <Column()> _
    Public Property Designacao() As String
      Get
        Return _Designacao
      End Get
      Set(ByVal value As String)
        _Designacao = value
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
  End Class
End Namespace

