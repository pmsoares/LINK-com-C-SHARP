Public Module StringExtensions
  <System.Runtime.CompilerServices.Extension()> _
  Public Function IsEmptyAfterTrim(ByVal str As String) As Boolean
    Dim aux As String = str
    If aux Is Nothing Then
      Return True
    End If
    Return String.IsNullOrEmpty(str.Trim())
  End Function
End Module
