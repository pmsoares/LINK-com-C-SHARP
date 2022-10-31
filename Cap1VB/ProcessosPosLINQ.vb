Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq

Public Class ProcessosPosLINQ
  Public Function ImprimeProcessos() As IEnumerable(Of Process)
    Dim processos = From p In Process.GetProcesses() _
      Where p.ProcessName.StartsWith("w") _
      Select p
    Return processos
  End Function
End Class