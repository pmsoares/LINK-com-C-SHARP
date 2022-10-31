Imports System

Public NotInheritable Class PilhaGenéricaCSharp1
  Private Const _capacidadeInicial As Integer = 10
  Private _arrayElementos As Object() = New Object(_capacidadeInicial - 1) {}
  Private _numeroElementos As Integer

  Public ReadOnly Property TotalElementos() As Integer
    Get
      Return _numeroElementos
    End Get
  End Property

  Public Function Pop() As Object
    VerificaEstadoPilhaParaLeitura()
    Dim numero As Object = _arrayElementos(System.Threading.Interlocked.Decrement(_numeroElementos))
    _arrayElementos(_numeroElementos) = Nothing
    Return numero
  End Function

  Private Sub VerificaEstadoPilhaParaLeitura()
    If TotalElementos = 0 Then
      Throw New InvalidOperationException("Não pode executar esta operação sobre uma pilha vazia.")
    End If
  End Sub

  Public Sub Push(ByVal numero As Object)
    If _arrayElementos.Length = _numeroElementos Then
      AumentaTamanhoArray()
    End If
    _arrayElementos(System.Math.Max(System.Threading.Interlocked.Increment(_numeroElementos), _numeroElementos - 1)) = numero
  End Sub

  Private Sub AumentaTamanhoArray()
    Dim novoArray = New Object(_arrayElementos.Length * 2 - 1) {}
    Array.Copy(_arrayElementos, novoArray, _arrayElementos.Length)
    _arrayElementos = novoArray
  End Sub

  Public Function Peek() As Object
    VerificaEstadoPilhaParaLeitura()
    Return _arrayElementos(_numeroElementos - 1)
  End Function
End Class