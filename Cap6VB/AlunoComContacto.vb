

Public Class AlunoComContacto
  Inherits Aluno
  Private _contacto As Contacto

  Public Property Contacto() As Contacto
    Get
      Return _contacto
    End Get
    Set(ByVal value As Contacto)
      _contacto = value
    End Set
  End Property
End Class