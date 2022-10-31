Imports System

Class ImpressoraMensagens
  Public Sub MostraMensagem(ByVal msg As String)
    Console.WriteLine(msg)
  End Sub
End Class

Delegate Sub AvisaUtilizador(ByVal msg As String)