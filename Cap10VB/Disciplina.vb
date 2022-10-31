Public Class Disciplina
  Private _Nome As String
  Public Property Nome() As String
    Get
      Return _Nome
    End Get
    Set(ByVal value As String)
      _Nome = value
    End Set
  End Property
  Private _Descricao As String
  Public Property Descricao() As String
    Get
      Return _Descricao
    End Get
    Set(ByVal value As String)
      _Descricao = value
    End Set
  End Property
End Class

