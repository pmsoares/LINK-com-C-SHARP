Public Enum TipoContacto
  Telefone
  Email
End Enum

Public MustInherit Class Contacto
  Private _Valor As String
  Public Property Valor() As String
    Get
      Return _Valor
    End Get
    Set(ByVal value As String)
      _Valor = value
    End Set
  End Property
  Public MustOverride ReadOnly Property TipoContacto() As TipoContacto
End Class

Public Class Telefone
  Inherits Contacto
  Public Overloads Overrides ReadOnly Property TipoContacto() As TipoContacto
    Get
      Return TipoContacto.Telefone
    End Get
  End Property
End Class

Public Class Email
  Inherits Contacto
  Public Overloads Overrides ReadOnly Property TipoContacto() As TipoContacto
    Get
      Return TipoContacto.Email
    End Get
  End Property
End Class
