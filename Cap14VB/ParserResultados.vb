Imports Cap14VB.Live.Search

Public Class ParserResultados
  Implements IEnumerable(Of Resultado)
  Private ReadOnly _results As IEnumerable(Of Result)

  Public Sub New(ByVal results As IEnumerable(Of Result))
    _results = results
  End Sub

  Public Function GetEnumeratorImpl() As IEnumerator(Of Resultado) Implements IEnumerable(Of Resultado).GetEnumerator
    Return GetEnumerator()
  End Function

  Public Function GetEnumerator() As IEnumerator(Of Resultado)
    Return _results.GetEnumerator()
  End Function

  Public Function GetEnumeratorImpl2() As IEnumerator Implements IEnumerable.GetEnumerator
    Return GetEnumerator()
  End Function
End Class
