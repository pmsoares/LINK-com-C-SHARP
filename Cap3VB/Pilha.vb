Imports System
Imports System.Collections


Public NotInheritable Class Pilha(Of T)
  Implements IEnumerable(Of T)
  Private Const _capacidadeInicial As Integer = 10
  Private _array As T() = New T(_capacidadeInicial - 1) {}
  Private _numeroElementos As Integer = 0

  Public Class PilhaEnumerator
    Implements IEnumerator(Of T)
    Private _array As T()
    Private _index As Integer
    Private _current As T
    Private _parent As Pilha(Of T)

    Friend Sub New(ByVal pilha As Pilha(Of T))
      _parent = pilha
      _array = pilha._array
      _current = Nothing
      _index = -2
    End Sub


    Public Sub Dispose() Implements IEnumerator(Of T).Dispose
      _index = -1
    End Sub

    Private ReadOnly Property CurrentOld() As Object Implements IEnumerator.Current
      Get
        Return Current
      End Get
    End Property


    Private ReadOnly Property Current() As T Implements IEnumerator(Of T).Current
      Get
        If _index < 0 Then
          Throw New InvalidOperationException()
        End If
        Return _current
      End Get
    End Property

    Public Function MoveNext() As Boolean Implements IEnumerator(Of T).MoveNext
      If _index = -2 Then
        ' movenext chamado pela primeira vez
        _index = _parent._numeroElementos
        If _index < 0 Then
          Return False
        End If
        _current = _array(_index)
        Return True
      End If
      If System.Threading.Interlocked.Decrement(_index) <= 0 Then
        Return False
      End If
      _current = _array(_index)
      Return True
    End Function

    Public Sub Reset() Implements IEnumerator(Of T).Reset
      _index = -2
      _current = Nothing
    End Sub
  End Class


  Public Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
    Return New PilhaEnumerator(Me)
  End Function

  Private Function GetEnumerator2() As IEnumerator Implements IEnumerable.GetEnumerator
    Return GetEnumerator()
  End Function

  Public ReadOnly Property TotalElementos() As Integer
    Get
      Return _numeroElementos
    End Get
  End Property

  Public Function Pop() As T
    VerificaEstadoPilhaParaLeitura()
    Dim elem As T = _array(System.Threading.Interlocked.Decrement(_numeroElementos))
    _array(_numeroElementos) = Nothing
    Return elem
  End Function

  Private Sub VerificaEstadoPilhaParaLeitura()
    If TotalElementos = 0 Then
      Throw New InvalidOperationException("Não pode executar esta operação sobre uma stack vazia.")
    End If
  End Sub
  Public Sub Push(ByVal elem As T)
    If _array.Length = _numeroElementos Then
      AumentaTamanhoArray()
    End If
    _array(System.Math.Max(System.Threading.Interlocked.Increment(_numeroElementos), _numeroElementos - 1)) = elem
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
