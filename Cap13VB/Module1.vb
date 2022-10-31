Imports System.Linq

Module Module1

  Sub Main()
    Console.Title = "LINQ Com C# - Capítulo 13"

    Console.ReadLine()

    Console.Clear()

    Figura_13_04()

    Console.ReadLine()

    Console.Clear()

    Figura_13_05()

    Console.ReadLine()
  End Sub
  Private Function NumeroEPar(ByVal n As Integer) As Boolean
    Dim d As Double = 1
    For i As Integer = 0 To 99
      d *= i
    Next

    If n Mod 2 = 0 Then
      Return True
    End If
    Return False
  End Function

  Private Sub Figura_13_04()
    Dim pares = From n In Enumerable.Range(0, 1000000).AsParallel() _
        Where NumeroEPar(n) _
        Select n

    For Each n In pares
      Console.WriteLine(n)
    Next
  End Sub

  Private Sub Figura_13_05()
    Dim pares = From n In Enumerable.Range(0, 1000000).AsParallel().AsOrdered() _
        Where NumeroEPar(n) _
        Select n

    For Each n In pares
      Console.WriteLine(n)
    Next
  End Sub

End Module
