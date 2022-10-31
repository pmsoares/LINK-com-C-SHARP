Public Module TesteExtended

  <System.Runtime.CompilerServices.Extension()> _
  Public Sub Imprime(ByVal instancia As Teste, ByVal valor As Integer)
    Console.WriteLine("Extendido: {0}", valor)
  End Sub
End Module
