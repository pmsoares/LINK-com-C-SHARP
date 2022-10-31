Imports System.Reflection
Imports System.Linq.Expressions


Public MustInherit Class QueryProvider
  Implements IQueryProvider
  Private Function CreateQuery(Of S)(ByVal expression As Expression) As IQueryable(Of S) Implements IQueryProvider.CreateQuery
    Return New Query(Of S)(Me, expression)
  End Function


  Private Function CreateQuery(ByVal expression As Expression) As IQueryable Implements IQueryProvider.CreateQuery
    Dim elementType = TypeSystem.GetElementType(expression.Type)
    Try
      Return DirectCast(Activator.CreateInstance(GetType(Query(Of )).MakeGenericType(elementType), New Object() {Me, expression}), IQueryable)
    Catch tie As TargetInvocationException
      Throw tie.InnerException
    End Try
  End Function

  Private Function Execute(Of S)(ByVal expression As Expression) As S Implements IQueryProvider.Execute
    Return DirectCast(Execute(expression), S)
  End Function


  Private Function ExecuteImpl2(ByVal expression As Expression) As Object Implements IQueryProvider.Execute
    Return Execute(expression)
  End Function

  Public MustOverride Function GetQueryText(ByVal expression As Expression) As String
  Public MustOverride Function Execute(ByVal expression As Expression) As Object
End Class
