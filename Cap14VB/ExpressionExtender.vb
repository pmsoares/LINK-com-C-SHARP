Imports System.Linq.Expressions

Public Module ExpressionExtender
  
  <System.Runtime.CompilerServices.Extension()> _
  Public Function IsMemberAccess(ByVal expression As Expression) As Boolean
    If expression Is Nothing Then
      Return False
    End If
    Return expression.NodeType = ExpressionType.MemberAccess
  End Function
End Module
