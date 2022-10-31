Imports System

Public NotInheritable Class Pilha(Of T)
  Private Const _capacidadeInicial As Integer = 10
  Private _array As T() = New T(_capacidadeInicial - 1) {}
  Private _numeroElementos As Integer = 0

  Public ReadOnly Property TotalElementos() As Integer
    Get
      Return _numeroElementos
    End Get
  End Property

  Public Function Pop() As T
    VerificaEstadoPilhaParaLeitura()
    Dim numero As T = _array(System.Threading.Interlocked.Decrement(_numeroElementos))
    _array(_numeroElementos) = Nothing
    Return numero
  End Function

  Private Sub VerificaEstadoPilhaParaLeitura()
    If TotalElementos = 0 Then
      Throw New InvalidOperationException("Não pode executar esta operação sobre uma stack vazia.")
    End If
  End Sub

  Public Sub Push(ByVal numero As T)
    If _array.Length = _numeroElementos Then
      AumentaTamanhoArray()
    End If
    _array(System.Math.Max(System.Threading.Interlocked.Increment(_numeroElementos), _numeroElementos - 1)) = numero
  End Sub

  Private Sub AumentaTamanhoArray()
    Dim novoArray As T() = New T(_array.Length * 2 - 1) {}
    Array.Copy(_array, novoArray, _array.Length)
    _array = novoArray
  End Sub

  Public Function Peek() As T
    VerificaEstadoPilhaParaLeitura()
    Return _array(_numeroElementos - 1)
  End Function
End Class