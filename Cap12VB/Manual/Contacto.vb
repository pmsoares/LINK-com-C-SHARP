Imports System.Data.Linq
Imports System.Data.Linq.Mapping

Namespace LINQToSQL.Manual
  <Table(Name:="Contactos")> _
  <InheritanceMapping(Code:=0, Type:=GetType(Telefone), IsDefault:=True)> _
  <InheritanceMapping(Code:=1, Type:=GetType(Email))> _
  Public Class Contacto
    Private _IdContacto As Integer
    <Column(IsPrimaryKey:=True, IsDbGenerated:=True, DbType:="INT NOT NULL IDENTITY", AutoSync:=AutoSync.OnInsert)> _
    Public Property IdContacto() As Integer
      Get
        Return _IdContacto
      End Get
      Set(ByVal value As Integer)
        _IdContacto = value
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
    Private _Valor As String
    <Column()> _
    Public Property Valor() As String
      Get
        Return _Valor
      End Get
      Set(ByVal value As String)
        _Valor = value
      End Set
    End Property
    Private _TipoContacto As Integer
    <Column(Name:="Tipo", IsDiscriminator:=True)> _
    Public Property TipoContacto() As Integer
      Get
        Return _TipoContacto
      End Get
      Set(ByVal value As Integer)
        _TipoContacto = value
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


  Public Class Telefone
    Inherits Contacto
  End Class

  Public Class Email
    Inherits Contacto
  End Class
End Namespace

