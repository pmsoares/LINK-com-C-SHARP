Public Class Morada
  Private _Rua As String
  Public Property Rua() As String
    Get
      Return _Rua
    End Get
    Set(ByVal value As String)
      _Rua = value
    End Set
  End Property
  Private _CodigoPostal As String
  Public Property CodigoPostal() As String
    Get
      Return _CodigoPostal
    End Get
    Set(ByVal value As String)
      _CodigoPostal = value
    End Set
  End Property
End Class
