Imports System.Linq.Expressions

Public Class Query(Of T)
  Implements IQueryable(Of T)
  Private ReadOnly _provider As QueryProvider
  Private ReadOnly _expression As Expression

  Public Sub New(ByVal provider As QueryProvider)
    If provider Is Nothing Then
      Throw New ArgumentNullException("provider")
    End If
    _provider = provider
    _expression = Expression.Constant(Me)
  End Sub

  Public Sub New(ByVal provider As QueryProvider, ByVal expression As Expression)
    If provider Is Nothing Then
      Throw New ArgumentNullException("provider")
    End If
    If expression Is Nothing Then
      Throw New ArgumentNullException("expression")
    End If
    If Not GetType(IQueryable(Of T)).IsAssignableFrom(expression.Type) Then
      Throw New ArgumentOutOfRangeException("expression")
    End If
    _provider = provider
    _expression = expression
  End Sub

  Public ReadOnly Property Expression() As Expression
    Get
      Return _expression
    End Get
  End Property

  Public ReadOnly Property ExpressionImpl() As Expression Implements IQueryable.Expression
    Get
      Return Expression
    End Get
  End Property

  Private ReadOnly Property ElementType() As Type Implements IQueryable.ElementType
    Get
      Return GetType(T)
    End Get
  End Property

  Private ReadOnly Property Provider() As IQueryProvider Implements IQueryable.Provider
    Get
      Return _provider
    End Get
  End Property

  Public Function GetEnumerator() As IEnumerator(Of T)
    Return DirectCast(_provider.Execute(_expression), IEnumerable(Of T)).GetEnumerator()
  End Function

  Private Function GetEnumeratorImpl() As IEnumerator Implements IEnumerable.GetEnumerator
    Return GetEnumerator()
  End Function

  Public Function GetEnumeratorImpl2() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
    Return GetEnumerator()
  End Function

  Public Overloads Overrides Function ToString() As String
    Return _provider.GetQueryText(_expression)
  End Function
End Class
