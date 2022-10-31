Imports System.Linq.Expressions
Imports Cap14VB.Live.Search

Public Class LiveSearchContext
  Public Web As Query(Of Resultado)

  Public News As Query(Of Resultado)

  Public Sub New(ByVal liveKey As String)
    Web = New Query(Of Resultado)(New LiveProvider(liveKey, Live.Search.SourceType.Web))
    News = New Query(Of Resultado)(New LiveProvider(liveKey, Live.Search.SourceType.News))
  End Sub
End Class
