Imports System
Imports System.Linq.Expressions

Public Class TesteExpressoes
  Public Sub TestaExpressao()
    Console.WriteLine("Utilização delegate Func")
    Dim duplicador As Func(Of Integer, Integer) = Function(x) x * 2
    Console.WriteLine("Execução da expressão: {0}", duplicador(2))

    Console.WriteLine("Utilização de árvores expressões")
    Dim arvore As Expression(Of Func(Of Integer, Integer)) = Function(x) x * 2
    ' Número de parâmetros
    Console.WriteLine("Número parâmetros: {0}", arvore.Parameters.Count)
    For Each parameter In arvore.Parameters
      ' Tipo (int, float, etc.)
      Console.WriteLine("Tipo: {0}", parameter.Type)
      ' Nome
      Console.WriteLine("Nome: {0}", parameter.Name)
      ' Tipo de nó de expressão
      Console.WriteLine("Tipo nó: {0}", parameter.NodeType)
    Next
    ' Corpo
    Console.WriteLine("Corpo: {0}", arvore.Body)
    ' Tipo de expressão do corpo
    Console.WriteLine("Tipo Corpo: {0}", arvore.Body.NodeType)
    ' Lado esquerdo da expressão
    Console.WriteLine("Esquerda: {0}", DirectCast(arvore.Body, BinaryExpression).Left)
    ' Lado direito da expressão
    Console.WriteLine("Direita: {0}", DirectCast(arvore.Body, BinaryExpression).Right)

  End Sub
End Class