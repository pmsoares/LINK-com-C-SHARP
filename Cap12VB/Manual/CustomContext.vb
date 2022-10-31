Imports System.Collections.Generic
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Reflection

Namespace LINQToSQL.Manual
  Public Class CustomContext
    Inherits DataContext
    Public Sub New(ByVal connectionString As String)
      MyBase.New(connectionString)
    End Sub

    <[Function](Name:="dbo.ObtemContactos")> _
    Public Function ObtemContactosEstudantes() As IEnumerable(Of InfoEstudante)
      Dim aux = ExecuteMethodCall(Me, DirectCast((MethodBase.GetCurrentMethod()), MethodInfo))
      Return DirectCast((aux.ReturnValue), IEnumerable(Of InfoEstudante))
    End Function

    <[Function](Name:="dbo.ObtemContactosDoEstudante")> _
    Public Function ObtemContactosDoEstudante(<Parameter(Name:="id")> ByVal id As Integer) As IEnumerable(Of InfoEstudante)
      Dim aux = ExecuteMethodCall(Me, DirectCast((MethodBase.GetCurrentMethod()), MethodInfo), id)
      Return DirectCast((aux.ReturnValue), IEnumerable(Of InfoEstudante))
    End Function
  End Class


  Public Class InfoEstudante
    Private _Nome As String
    Public Property Nome() As String
      Get
        Return _Nome
      End Get
      Set(ByVal value As String)
        _Nome = value
      End Set
    End Property
    Private _Contacto As String

    <Column(Name:="Valor")> _
    Public Property Contacto() As String
      Get
        Return _Contacto
      End Get
      Set(ByVal value As String)
        _Contacto = value
      End Set
    End Property
  End Class
End Namespace
