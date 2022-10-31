Imports System

Public Class Aluno
  Public Sub New(ByVal nome__1 As String, ByVal morada__2 As String, ByVal idade__3 As Integer)
    Nome = nome__1
    Morada = morada__2
    Idade = idade__3
  End Sub

  Private _Nome As String
  Public Property Nome() As String
    Get
      Return _Nome
    End Get
    Set(ByVal value As String)
      _Nome = value
    End Set
  End Property
  Private _Morada As String
  Public Property Morada() As String
    Get
      Return _Morada
    End Get
    Set(ByVal value As String)
      _Morada = value
    End Set
  End Property
  Private _Idade As Int32
  Public Property Idade() As Int32
    Get
      Return _Idade
    End Get
    Set(ByVal value As Int32)
      _Idade = value
    End Set
  End Property

  Public Overloads Overrides Function ToString() As String
    Return String.Concat(Nome, "-", Morada, "-", Idade)
  End Function
End Class