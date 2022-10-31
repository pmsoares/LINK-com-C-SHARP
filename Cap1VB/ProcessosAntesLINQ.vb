Imports System.Collections.Generic
Imports System.Diagnostics

Public Class ProcessosAntesLINQ
  Public Function ImprimeProcessos() As IEnumerable(Of Process)
    Dim processos As New List(Of Process)()
    For Each p As Process In Process.GetProcesses()
      If p.ProcessName.StartsWith("w") Then
        processos.Add(p)
      End If
    Next
    Return processos
  End Function
End Class