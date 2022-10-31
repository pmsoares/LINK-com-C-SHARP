Imports System.Text
Imports System.Reflection
Imports System.Linq.Expressions
Imports Cap14VB.Live.Search

Public Class VisitanteArvore
  Private _criterio As StringBuilder
  Private _urls As List(Of String)
  Private ReadOnly _appId As String
  Private _type As SourceType

  Public Sub New(ByVal appId As String, ByVal type As SourceType)
    _appId = appId
    _type = type
  End Sub

  Private Sub Inicializa()
    _criterio = New StringBuilder()
    _urls = New List(Of String)()
  End Sub

  Public Function TraduzArvore(ByVal expression As Expression) As SearchRequest
    Inicializa()
    VisitaNo(expression)
    Return ConverteEmSearchRequest()
  End Function

  Private Function ConverteEmSearchRequest() As SearchRequest
    Dim request = New SearchRequest()

    Return request
  End Function

  Private Function ConstroiQuery() As String
    If _urls.Count = 0 Then
      Return _criterio.ToString()
    End If
    Dim total = String.Concat(_criterio.ToString(), " (SITE: ", String.Join(" OR ", _urls.ToArray()), ")")
    Return total
  End Function

  Public Sub VisitaNo(ByVal expression As Expression)
    If expression.NodeType = ExpressionType.Equal Then
      VisitaIgualdade(DirectCast(expression, BinaryExpression))
    ElseIf expression.NodeType = ExpressionType.[AndAlso] Then
      VisitaAndAlso(DirectCast(expression, BinaryExpression))
    ElseIf TypeOf expression Is MethodCallExpression Then
      VisitaInvocacaoMetodo(DirectCast(expression, MethodCallExpression))
    ElseIf expression.NodeType = ExpressionType.Constant Then
      'apenas para permitir o funcionamento do metodo CreateQuery
    ElseIf TypeOf expression Is LambdaExpression Then
      VisitaNo(DirectCast(expression, LambdaExpression).Body)
    Else
      Throw New NotSupportedException("Este tipo de expressão não é suportada na versão actual")
    End If
  End Sub

  Private Sub VisitaAndAlso(ByVal expression As BinaryExpression)
    Dim expressaoEsquerda = expression.Left
    Dim expressaoDireita = expression.Right
    VisitaNo(expressaoEsquerda)
    VisitaNo(expressaoDireita)
  End Sub

  Private Sub VisitaInvocacaoMetodo(ByVal expression As MethodCallExpression)
    If String.Compare(expression.Method.Name, "Where") = 0 Then
      VisitaNo(DirectCast(expression.Arguments(1), UnaryExpression).Operand)
      Exit Sub
    End If
    Throw New NotSupportedException(String.Format("Método {0} não é suportado nesta versão", expression.Method.Name))
  End Sub

  Private Sub VisitaIgualdade(ByVal expression As BinaryExpression)
    Dim ladoEsquerdo = expression.Left
    If ladoEsquerdo.IsMemberAccess() Then
      Dim membro = DirectCast(ladoEsquerdo, MemberExpression).Member
      Dim value = ObtemValorExpressaoDireita(expression.Right)
      If String.Compare(membro.Name, "Titulo") = 0 Then
        If _criterio.Length <> 0 Then
          _criterio.Append(" AND ")
        End If
        _criterio.AppendFormat(" {0} ", value)
        Exit Sub
      End If
      If [String].Compare(membro.Name, "Url") = 0 Then
        _urls.Add(value)
        Exit Sub
      End If
      Throw New NotSupportedException("Esta propriedade não pode ser usada nesta pesquisa")
    End If
  End Sub

  Private Function ObtemValorExpressaoDireita(ByVal right As Expression) As String
    If right.NodeType = ExpressionType.Constant Then
      Return DirectCast(right, ConstantExpression).Value.ToString()
    End If
    If right.NodeType = ExpressionType.MemberAccess Then
      Return DirectCast(ObtemValorMembro(DirectCast(right, MemberExpression)), String)
    End If
    Throw New NotSupportedException()
  End Function

  Private Function ObtemValorMembro(ByVal memberExpression As MemberExpression) As Object
    Dim memberInfo As MemberInfo
    Dim obj As Object
    If TypeOf memberExpression.Member Is FieldInfo AndAlso DirectCast(memberExpression.Member, FieldInfo).IsStatic Then
      Dim fld = DirectCast(memberExpression.Member, FieldInfo)
      Return fld.GetValue(Nothing)
    End If
    If TypeOf memberExpression.Expression Is ConstantExpression Then
      obj = DirectCast(memberExpression.Expression, ConstantExpression).Value
    ElseIf TypeOf memberExpression.Expression Is MemberExpression Then
      obj = ObtemValorMembro(DirectCast(memberExpression.Expression, MemberExpression))
    Else
      Throw New NotSupportedException("Expression type not supported: " & memberExpression.Expression.[GetType]().FullName)
    End If
    memberInfo = memberExpression.Member
    If TypeOf memberInfo Is PropertyInfo Then
      Dim [property] = DirectCast(memberInfo, PropertyInfo)
      Return [property].GetValue(obj, Nothing)
    End If
    If TypeOf memberInfo Is FieldInfo Then
      Dim field = DirectCast(memberInfo, FieldInfo)
      Return field.GetValue(obj)
    End If
    Throw New NotSupportedException("MemberInfo type not supported: " & memberInfo.[GetType]().FullName)
  End Function
End Class
