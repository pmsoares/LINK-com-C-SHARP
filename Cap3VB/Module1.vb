Module Module1

    Sub Main()
    Dim pilhaSemBlocoIteracao = New Pilha(Of Integer)()
    pilhaSemBlocoIteracao.Push(1)
    pilhaSemBlocoIteracao.Push(2)
    pilhaSemBlocoIteracao.Push(3)

    For Each numero As Integer In pilhaSemBlocoIteracao
      Console.WriteLine(numero)
    Next

    End Sub

End Module
