Imports System
Imports Cap1VB



Module Program
  Public Sub Main(ByVal args As String())
    Console.WriteLine("Lista processos sem LINQ:")
    Dim processosAntesLINQ = New ProcessosAntesLINQ().ImprimeProcessos()
    ImprimeProcessosDaLista(processosAntesLINQ)
    Console.WriteLine("Lista processos com LINQ:")
    Dim processosPosLINQ = New ProcessosPosLINQ().ImprimeProcessos()
    ImprimeProcessosDaLista(processosPosLINQ)
  End Sub

  Private Sub ImprimeProcessosDaLista(ByVal processosAntesLINQ As IEnumerable(Of Process))
    For Each processo In processosAntesLINQ
      Console.WriteLine(processo.ProcessName)
    Next
  End Sub
End Module



