Module Module1

    Sub Main()
    Console.WriteLine("Teste simples de método extensão")
    Dim myStr = "Luis"
    Console.WriteLine(myStr.IsEmptyAfterTrim())

    Console.WriteLine("Teste com overloads")
    Dim myTeste = New Teste()
    Dim valor As Integer = 10
    ' poderiamos ter usado var,
    ' mas usamos int para que não restem dúvidas
    myTeste.Imprime(valor)

    End Sub

End Module
