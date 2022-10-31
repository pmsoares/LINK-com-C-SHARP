Module Module1

    Sub Main()
    Dim i = 10
    Console.WriteLine("i: {0} -- type:{1}", i, i.[GetType]().Name)
    Dim aluno = New Aluno("José", "Funchal", 20)
    Console.WriteLine("aluno: {0} -- type:{1}", aluno, aluno.[GetType]().Name)

    Dim a1 = New Integer() {1, 2}
    For Each a In a1
      Console.WriteLine(a)
    Next

    Dim a2 = New String(,) {{"Luis", "Paulo"}, {"João", "Marco"}}
    For Each a In a2
      Console.WriteLine(a)
    Next

    End Sub

End Module
