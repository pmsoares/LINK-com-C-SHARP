Public NotInheritable Class Resultado
  Private _Titulo As String
  Public Property Titulo() As String
    Get
      Return _Titulo
    End Get
    Set(ByVal value As String)
      _Titulo = value
    End Set
  End Property
  Private _Url As String
  Public Property Url() As String
    Get
      Return _Url
    End Get
    Set(ByVal value As String)
      _Url = value
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
