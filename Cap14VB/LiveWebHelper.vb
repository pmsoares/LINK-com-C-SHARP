Imports Cap14VB.Live.Search

Public Class LiveWebHelper

  Public Function GetResultsFromLive(ByVal request As SearchRequest) As SearchResponse
    Using service = New MSNSearchService()
      Return service.Search(request)
    End Using
  End Function
End Class
