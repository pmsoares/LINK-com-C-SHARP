Module Module1

    Sub Main()
    InicializacaoPreCSharp3()

    InicializacaoPosCSharp3()

    InicializacaoPosCSharp3CasoEspecial()
    End Sub

  Sub InicializacaoPosCSharp3CasoEspecial()
    'consultar livro para perceber porque 
    'propriedade Contacto tem de ser de leitura/escrita
    'e pq e necessario criar contacto

    Dim aluno = New AlunoComContacto With _
      {.Nome = "Luis", .Morada = "Funchal", _
       .Contacto = New Contacto With {.Telefone = "123123123", .Telemovel = "123123123"}}
    ImprimeAluno(aluno)

    Dim contacto = aluno.Contacto
    Console.WriteLine("Telefone: {0} --- Telemovel: {1}", contacto.Telemovel, contacto.Telemovel)
  End Sub

  Sub InicializacaoPosCSharp3()
    Dim aluno = New Aluno With {.Nome = "Luis", .Morada = "Funchal"}
    ImprimeAluno(aluno)
  End Sub

  Sub InicializacaoPreCSharp3()
    Dim aluno = New Aluno()
    aluno.Nome = "Luis"
    aluno.Morada = "Fx"
    ImprimeAluno(aluno)
  End Sub

  Sub ImprimeAluno(ByVal aluno As Aluno)
    Console.WriteLine("Nome: {0} --- Morada: {1}", aluno.Nome, aluno.Morada)
  End Sub

End Module
