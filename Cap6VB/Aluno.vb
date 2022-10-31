Public Class Aluno
  Private _nome As String
  Private _morada As String

  Public Property Nome() As String
    Get
      Return _nome
    End Get
    Set(ByVal value As String)
      _nome = value
    End Set
  End Property

  Public Property Morada() As String
    Get
      Return _morada
    End Get
    Set(ByVal value As String)
      _morada = value
    End Set
  End Property
End Class

