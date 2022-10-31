Imports Cap14VB.Live.Search
Imports System.Reflection
Imports System.Text
Imports System.Globalization

Public Module SearchRequestExtender
  
  <System.Runtime.CompilerServices.Extension()> _
  Public Function TranslateToText(ByVal request As SearchRequest) As String
    If request Is Nothing Then
      Return ""
    End If

    Dim builder = New StringBuilder()
    Dim flags = BindingFlags.Instance Or BindingFlags.[Public]
    For Each prop In GetType(SearchRequest).GetProperties(flags)
      builder.AppendFormat("{0}: {1}" & vbLf, prop.Name, prop.GetValue(request, flags, Nothing, Nothing, CultureInfo.InvariantCulture))
    Next
    Return builder.ToString()
  End Function
End Module
