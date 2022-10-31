Public Class Turma
  Private _IdTurma As Int32
  Public Property IdTurma() As Int32
    Get
      Return _IdTurma
    End Get
    Set(ByVal value As Int32)
      _IdTurma = value
    End Set
  End Property
  Private _Designacao As String
  Public Property Designacao() As String
    Get
      Return _Designacao
    End Get
    Set(ByVal value As String)
      _Designacao = value
    End Set
  End Property
End Class
