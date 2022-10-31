Module Module1

  Sub Main()
    Query()

  End Sub

  Private Sub Query()
    Dim liveKey = "F8A1EE74E4CD75A9D1B542287A9D868185518B5F"
    Dim liveContext = New LiveSearchContext(liveKey)

    Dim query2 = From item In liveContext.Web _
        Where item.Titulo = "Luis" _
        Select item

    For Each hit In query2
      Console.WriteLine([String].Format("Url: {0}", hit.Url))
      Console.WriteLine([String].Format("Titulo: {0}", hit.Titulo))
      Console.WriteLine([String].Format("Descricao: {0}", hit.Descricao))
      Console.WriteLine("-------------------------")
    Next

    Dim query3 = From item In liveContext.News _
        Where item.Titulo = "Luis" _
        Select item

    For Each hit In query3
      Console.WriteLine([String].Format("Url: {0}", hit.Url))
      Console.WriteLine([String].Format("Titulo: {0}", hit.Titulo))
      Console.WriteLine([String].Format("Descricao: {0}", hit.Descricao))
      Console.WriteLine("-------------------------")
    Next
  End Sub


End Module
