Module Module1

    Sub Main()
    Dim obj = New With {Key .Nome = "Luis", Key .Morada = "Funchal"}
    Dim obj1 = New With {Key .Nome = "Luis", Key .Morada = "Funchal"}
    Console.WriteLine(obj.Equals(obj1))
    Console.WriteLine("{0} - {1}", obj.Nome, obj.Morada)
    Console.WriteLine(obj.GetType())
    End Sub

End Module
