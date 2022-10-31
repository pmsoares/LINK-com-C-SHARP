Module Module1

  Sub Main()
    Console.WriteLine("Pilha  C# 1.0")
    Dim pilha = New PilhaInteiros()
    pilha.Push(1)
    pilha.Push(2)
    pilha.Push(3)
    While pilha.TotalElementos <> 0
      Console.WriteLine(pilha.Pop())
    End While

    Console.WriteLine("Pilha genérica C# 1.0")
    Dim pilhaGenerica = New PilhaGenéricaCSharp1()
    pilhaGenerica.Push(1)
    pilhaGenerica.Push(2)
    pilhaGenerica.Push(3)
    While pilhaGenerica.TotalElementos <> 0
      Console.WriteLine(CInt(pilhaGenerica.Pop()))
    End While

    Console.WriteLine("Pilha genérica C# 2.0")
    Dim pilhaGenericaCSharp2 = New Pilha(Of Integer)()
    pilhaGenericaCSharp2.Push(1)
    pilhaGenericaCSharp2.Push(2)
    pilhaGenericaCSharp2.Push(3)
    While pilhaGenericaCSharp2.TotalElementos <> 0
      Console.WriteLine(pilhaGenericaCSharp2.Pop())
    End While
  End Sub

  

End Module
