Imports Cap14VB.Live.Search
Imports System.Linq.Expressions

Public Class LiveProvider
  Inherits QueryProvider
  Private _liveKey As String
  Private _type As SourceType
  Public Sub New(ByVal liveKey As String, ByVal type As SourceType)
    _liveKey = liveKey
    _type = type
  End Sub

  Public Overloads Overrides Function GetQueryText(ByVal expression As Expression) As String
    Return Translate(expression).TranslateToText()
  End Function

  Public Overloads Overrides Function Execute(ByVal expression As Expression) As Object
    Dim request = Translate(expression)
    Dim response = New LiveWebHelper().GetResultsFromLive(request)
    Dim items = response.Responses(0).Results
    Return New ParserResultados(items)
  End Function

  Private Function Translate(ByVal expression As Expression) As SearchRequest
    Return New VisitanteArvore(_liveKey, _type).TraduzArvore(expression)
  End Function
End Class
