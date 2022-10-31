Public Class Estudante
  Private _Nome As String
  Public Property Nome() As String
    Get
      Return _Nome
    End Get
    Set(ByVal value As String)
      _Nome = value
    End Set
  End Property
  Private _Morada As Morada
  Public Property Morada() As Morada
    Get
      Return _Morada
    End Get
    Set(ByVal value As Morada)
      _Morada = value
    End Set
  End Property
  Private _IdTurma As Int32
  Public Property IdTurma() As Int32
    Get
      Return _IdTurma
    End Get
    Set(ByVal value As Int32)
      _IdTurma = value
    End Set
  End Property

  Private _Contactos As IList(Of Contacto)
  Public Property Contactos() As IList(Of Contacto)
    Get
      Return _Contactos
    End Get
    Set(ByVal value As IList(Of Contacto))
      _Contactos = value
    End Set
  End Property
  Private _Disciplinas As IList(Of Disciplina)
  Public Property Disciplinas() As IList(Of Disciplina)
    Get
      Return _Disciplinas
    End Get
    Set(ByVal value As IList(Of Disciplina))
      _Disciplinas = value
    End Set
  End Property
End Class
