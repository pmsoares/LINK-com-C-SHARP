Imports System.Linq
Imports System.Security


Module Module1

  Private Portugues As New Disciplina With {.Nome = "Portugues", .Descricao = "Disciplina que apresenta fundamentos de Portugues"}
  Private Ingles As New Disciplina With {.Nome = "Ingles", .Descricao = "Disciplina que apresenta fundamentos de Ingles"}
  Private Informatica As New Disciplina With {.Nome = "Informatica", .Descricao = "Disciplina de informatica"}
  Private Matematica As New Disciplina With {.Nome = "Matematica", .Descricao = "Apresenta fundamentos matematica"}
  Private Frances As New Disciplina With {.Nome = "Francês", .Descricao = "Apresenta fundamentos francês"}

  Private Estudante1 As New Estudante With _
        { _
            .Nome = "Luis", _
            .IdTurma = 1, _
            .Morada = New Morada With {.CodigoPostal = "9100 - Funchal", .Rua = "Rua Sao Pedro"}, _
            .Contactos = New List(Of Contacto)(New Contacto() {New Email With {.Valor = "luis@livrolinq.pt"}}), _
            .Disciplinas = New List(Of Disciplina)(New Disciplina() {Portugues, Ingles, Informatica}) _
        }
  Private Estudante2 As New Estudante With _
        { _
            .Nome = "Paulo", _
            .IdTurma = 2, _
            .Morada = New Morada With {.CodigoPostal = "1100 - Lisboa", .Rua = "Rua do Rossio"}, _
            .Contactos = New List(Of Contacto)(New Contacto() {New Email With {.Valor = "paulo@livrolinq.pt"}, New Telefone With {.Valor = "123123123"}}), _
            .Disciplinas = New List(Of Disciplina)(New Disciplina() {Portugues, Matematica, Informatica}) _
        }

  Private Estudante3 As New Estudante With _
  { _
      .Nome = "Joana", _
      .IdTurma = 1, _
      .Morada = New Morada With {.CodigoPostal = "1100 - Lisboa", .Rua = "Rua do Rossio"}, _
      .Contactos = New List(Of Contacto)(New Contacto() {New Email With {.Valor = "joana@livrolinq.pt"}}), _
      .Disciplinas = New List(Of Disciplina)(New Disciplina() {Ingles, Matematica, Informatica}) _
  }

  Private Estudante4 As New Estudante With _
  { _
      .Nome = "Paula", _
      .IdTurma = 2, _
      .Morada = New Morada With {.CodigoPostal = "1100 - Lisboa", .Rua = "Rua do Rossio"}, _
      .Contactos = New List(Of Contacto)(New Contacto() {New Email With {.Valor = "paula@livrolinq.pt"}, New Telefone With {.Valor = "121212121"}}), _
      .Disciplinas = New List(Of Disciplina)(New Disciplina() {Portugues, Matematica, Informatica}) _
  }

  Private Estudante5 As New Estudante With _
  { _
      .Nome = "Rita", _
      .IdTurma = 1, _
      .Morada = New Morada With {.CodigoPostal = "1100 - Lisboa", .Rua = "Rua do Rossio"}, _
      .Contactos = New List(Of Contacto)(New Contacto() {New Email With {.Valor = "rita@livrolinq.pt"}}), _
      .Disciplinas = New List(Of Disciplina)(New Disciplina() {Portugues, Ingles}) _
  }

  Private Estudante6 As New Estudante With _
  { _
      .Nome = "Luisa", _
      .IdTurma = 2, _
      .Morada = New Morada With {.CodigoPostal = "4100 - Porto", .Rua = "Rua da Ribeira"}, _
      .Contactos = New List(Of Contacto)(New Contacto() {New Email With {.Valor = "luisa@livrolinq.pt"}}), _
      .Disciplinas = New List(Of Disciplina)(New Disciplina() {Portugues, Matematica, Informatica}) _
  }

  Private Disciplinas As New List(Of Disciplina)(New Disciplina() {Portugues, Ingles, Matematica, Informatica, Frances})
  Private Estudantes As New List(Of Estudante)(New Estudante() {Estudante1, Estudante2, Estudante3, Estudante4, Estudante5, Estudante6})
  Private Turma1 As New Turma With {.IdTurma = 1, .Designacao = "Turma 1"}
  Private Turma2 As New Turma With {.IdTurma = 2, .Designacao = "Turma 2"}
  Private Turma3 As New Turma With {.IdTurma = 3, .Designacao = "Turma 3"}
  Private Turmas As New List(Of Turma)(New Turma() {Turma1, Turma2, Turma3})

  Sub Main()
    ListaTodasDisciplinas()
    ListaTodasDisciplinasComMetodosExtensao()
    ListaApenasNomesDeDisciplinas()
    ListaNomesDisciplinasComNovoTipo()
    ListaNomesDisciplinasComNovoTipoInvocacaoMetodos()
    ListaAlunosMatriculadosEmInformatica()
    ListaAlunosMatriculadosEmInformaticaInvocacaoMetodos()
    ListaAlunosMatriculadosEmInformaticaContidosSubconjuntoTresAlunos()
    ListaDisciplinasAlunosQueEstaoEmMatematica1()
    ListaDisciplinasAlunosQueEstaoEmMatematica2()
    ListaDisciplinasAlunosQueEstaoEmMatematica2ComIncovacaoMetodo()
    ListaDisciplinasAlunosQueEstaoEmMatematicaComProjeccao()
    ListaEstudantesOrdenados()
    ListaEstudantesOrdenadosDecrescente()
    ListaEstudantesOrdenadosPorNomeEMorada()

    InverteListaEstundantesOrdenadosPorNomeeMorada()
    InverteListaEstundantesOrdenadosPorNomeeMoradaComLINQ()

    AgrupaItensPorCodigoPostal()

    AgrupaItensPorCodigoPostalComInvocacaoMetodo()
    AgrupaItensPorCodigoPostalComNovoElemento()
    AgrupaItensPorCodigoPostalComNovoElementoEInvocacaoMetodo()

    JuntaAlunosETurmas()


    JuntaAlunosETurmasComInvocacaoMetodos()
    JuntaTodasTurmasComAlunos()
    JuntaTodasTurmasComAlunosComInvocacaoMetodo()

    CalculaAlunoMaximo()
    CalculaAlunoMaximoComTipoAnonimo()

    ContaEstudantes()
    ContaNumeroTotalInscricoes()

    ListaDisciplinasSemRepetidos()
    JuntaListaDisciplinasDeInscritosComTodasDisciplinas()
    ObtemIntercepcaoEntreDisciplinasDePrimeiroESegundoAlunos()
    ObtemDisciplinasPrimeiroNaoComunsAoSegundo()
    ObtemPrimeiroDisciplinaComecadaPorM()
    ObtemPrimeiroDisciplinaComecadaPorV()


    ObtemPrimeirasDuasDisciplinasOrdenadasPorNome()
    ObtemAlunosInscritosEmMaisDeDuasDisciplinas()
    CriaSnapshot()
    CriaSnapshoptEmDicionario()
    CriaSnapshotComToLookup()

    SeleccionaPrimeiroEstudanteDeEstudantes2()
    SeleccionaPrimeiroEstudanteDeEstudantes2ComInvocaocaMetodo()
    IlustraRange()

    IlustraRepeat()
    IlustraRepeatComColeccoes()
    DemonstraUsoLet()
  End Sub


  Private Sub ListaTodasDisciplinas()
    Dim todasDisciplinas = From d In Disciplinas _
        Select d
    Console.WriteLine(todasDisciplinas.[GetType]())
    For Each disc In todasDisciplinas
      Console.WriteLine(disc.Nome)
    Next
  End Sub

  Private Sub ListaTodasDisciplinasComMetodosExtensao()
    Dim todasDisciplinas = Disciplinas.Select(Function(d) d)
    Console.WriteLine(todasDisciplinas.[GetType]())
    For Each disc In todasDisciplinas
      Console.WriteLine(disc.Nome)
    Next
  End Sub

  Private Sub ListaApenasNomesDeDisciplinas()
    Dim apenasNomes = From d In Disciplinas _
        Select d.Nome

    For Each disc In apenasNomes
      Console.WriteLine("Tipo: {0}---Valor: {1}", disc.GetType(), disc)
    Next
  End Sub

  Private Sub ListaNomesDisciplinasComNovoTipo()
    Dim novoTipo = From d In Disciplinas _
        Select New With {.NomeDisciplina = d.Nome}

    For Each disc In novoTipo
      Console.WriteLine("Tipo: {0}---Valor: {1}", disc.[GetType](), disc)
    Next
  End Sub

  Private Sub ListaNomesDisciplinasComNovoTipoInvocacaoMetodos()
    Dim novoTipo = Disciplinas.Select(Function(d) New With {.NomeDisciplina = d.Nome})

    For Each disc In novoTipo
      Console.WriteLine("Tipo: {0}---Valor: {1}", disc.[GetType](), disc)
    Next
  End Sub

  Private Sub ListaAlunosMatriculadosEmInformatica()
    Dim alunosInformatica = From e In Estudantes _
        Where e.Disciplinas.Contains(Informatica) _
        Select e

    For Each estudante In alunosInformatica
      Console.WriteLine("Nome: {0} ", estudante.Nome)
    Next
  End Sub

  Private Sub ListaAlunosMatriculadosEmInformaticaInvocacaoMetodos()
    Dim alunosInformatica = Estudantes.Where(Function(e) e.Disciplinas.Contains(Informatica)).Select(Function(e) e)

    For Each estudante In alunosInformatica
      Console.WriteLine("Nome: {0} ", estudante.Nome)
    Next
  End Sub

  Private Sub ListaAlunosMatriculadosEmInformaticaContidosSubconjuntoTresAlunos()
    Dim primeirosAlunos = Estudantes.Where(Function(est, index) est.Disciplinas.Contains(Informatica) AndAlso index < 3).Select(Function(e) e)
    For Each aluno In primeirosAlunos
      Console.WriteLine("Nome: {0}", aluno.Nome)
    Next
  End Sub

  Private Sub ListaDisciplinasAlunosQueEstaoEmMatematica1()
    Dim discs = From e In Estudantes _
        Where e.Disciplinas.Contains(Matematica) _
        Select e.Disciplinas

    For Each disc In discs
      Console.WriteLine(disc.[GetType]())
    Next
  End Sub

  Private Sub ListaDisciplinasAlunosQueEstaoEmMatematica2()
    Dim disciplinas = From e In Estudantes _
        Where e.Disciplinas.Contains(Matematica) _
        From d In e.Disciplinas _
        Select d

    For Each d In disciplinas
      Console.WriteLine("Tipo: {0}, Nome: {1}", d.[GetType](), d.Nome)
    Next
  End Sub

  Private Sub ListaDisciplinasAlunosQueEstaoEmMatematica2ComIncovacaoMetodo()
    Dim disciplinas = Estudantes.Where(Function(e) e.Disciplinas.Contains(Matematica)).SelectMany(Function(e) e.Disciplinas)
    For Each d In disciplinas
      Console.WriteLine("Tipo: {0}, Nome: {1}", d.[GetType](), d.Nome)
    Next
  End Sub

  Private Sub ListaDisciplinasAlunosQueEstaoEmMatematicaComProjeccao()
    Dim disciplinas = Estudantes.Where(Function(e) e.Disciplinas.Contains(Matematica)).SelectMany(Function(e) e.Disciplinas, Function(e, d) New With {.NomeAluno = e.Nome, .NomeDisciplina = d.Nome})

    For Each d In disciplinas
      Console.WriteLine("Aluno: {0}, Disciplina: {1}", d.NomeAluno, d.NomeDisciplina)
    Next
  End Sub

  Private Sub ListaEstudantesOrdenados()
    Dim estudantes__1 = From e In Estudantes _
        Order By e.Nome _
        Select e

    For Each e In estudantes__1
      Console.WriteLine("Nome: {0}", e.Nome)
    Next
  End Sub

  Private Sub ListaEstudantesOrdenadosComInvocacaoMetodo()
    Dim estudantes__1 = Estudantes.OrderBy(Function(e) e.Nome).Select(Function(e) e)
    For Each e In estudantes__1
      Console.WriteLine("Nome: {0}", e.Nome)
    Next
  End Sub

  Private Sub ListaEstudantesOrdenadosDecrescente()
    Dim estudantes__1 = From e In Estudantes _
        Order By e.Nome Descending _
        Select e

    For Each e In estudantes__1
      Console.WriteLine("Nome: {0}", e.Nome)
    Next
  End Sub

  Private Sub ListaEstudantesOrdenadosDecrescenteComInvocacaoMetodo()
    Dim estudantes__1 = Estudantes.OrderByDescending(Function(e) e.Nome).Select(Function(e) e)

    For Each e In estudantes__1
      Console.WriteLine("Nome: {0}", e.Nome)
    Next
  End Sub

  Private Sub ListaEstudantesOrdenadosPorNomeEMorada()
    Dim estudantes__1 = From e In Estudantes _
        Order By e.Nome, e.Morada _
        Select e
    For Each e In estudantes__1
      Console.WriteLine("Nome: {0}", e.Nome)
    Next
  End Sub

  Private Sub InverteListaEstundantesOrdenadosPorNomeeMorada()
    Dim estudantes__1 = Estudantes.OrderBy(Function(e) e.Nome).ThenBy(Function(e) e.Morada).Reverse()

    For Each e In estudantes__1
      Console.WriteLine("Nome: {0}", e.Nome)
    Next
  End Sub

  Private Sub InverteListaEstundantesOrdenadosPorNomeeMoradaComLINQ()
    Dim estudantes__1 = (From e In Estudantes _
        Order By e.Nome, e.Morada _
        Select e).Reverse()

    For Each e In estudantes__1
      Console.WriteLine("Nome: {0}", e.Nome)
    Next
  End Sub

  Private Sub AgrupaItensPorCodigoPostal()
    Console.WriteLine("Agrupamento de itens com expressão LINQ")
    Dim estudantes__1 = From e In Estudantes _
        Group e By key = e.Morada.CodigoPostal Into Group _
        Select key = key, Estudantes = Group

    For Each e In estudantes__1
      Console.WriteLine("Chave: {0}", e.key)
      For Each estudante In e.Estudantes
        Console.WriteLine("Nome: {0}", estudante.Nome)
      Next
    Next
  End Sub

  Private Sub AgrupaItensPorCodigoPostalComInvocacaoMetodo()
    Dim estudantes__1 = Estudantes.GroupBy(Function(e) e.Morada.CodigoPostal)

    For Each e In estudantes__1
      Console.WriteLine("Chave: {0}", e.Key)
      For Each estudante In e
        Console.WriteLine("Nome: {0}", estudante.Nome)
      Next
    Next
  End Sub

  Private Sub AgrupaItensPorCodigoPostalComNovoElemento()
    Dim estudantes__1 = From e In Estudantes _
        Group New With {.nome = e.Nome} By key = e.Morada.CodigoPostal Into Group _
        Select New With {.Key = key, .Estudantes = Group}


    For Each e In estudantes__1
      Console.WriteLine("Chave: {0}", e.Key)
      For Each estudante In e.Estudantes
        Console.WriteLine("Nome: {0}", estudante.Nome)
      Next
    Next
  End Sub

  Private Sub AgrupaItensPorCodigoPostalComNovoElementoEInvocacaoMetodo()
    Dim estudantes__1 = Estudantes.GroupBy(Function(e) e.Morada.CodigoPostal, Function(e) New With {e.Nome})


    For Each e In estudantes__1
      Console.WriteLine("Chave: {0}", e.Key)
      For Each estudante In e
        Console.WriteLine("Nome: {0}", estudante.Nome)
      Next
    Next
  End Sub

  Private Sub JuntaAlunosETurmas()
    Dim alunosTurmas = From e In Estudantes _
        Join t In Turmas On e.IdTurma Equals t.IdTurma _
        Select New With {.NomeAluno = e.Nome, .NomeTurma = t.Designacao}

    For Each ad In alunosTurmas
      Console.WriteLine("Aluno: {0}, Turma: {1}", ad.NomeAluno, ad.NomeTurma)
    Next
  End Sub

  Private Sub JuntaAlunosETurmasComInvocacaoMetodos()
    'segunda colecção
    'seleccionar elemento da primeira coleccção
    'seleccionar elemento da segundao colecção
    Dim alunosTurmas = Estudantes.Join(Turmas, Function(e) e.IdTurma, Function(t) t.IdTurma, Function(e, t) New With {.NomeAluno = e.Nome, .NomeTurma = t.Designacao})
    'projecção}
    For Each ad In alunosTurmas
      Console.WriteLine("Aluno: {0}, Turma: {1}", ad.NomeAluno, ad.NomeTurma)
    Next
  End Sub

  Private Sub JuntaTodasTurmasComAlunos()
    Console.WriteLine("Junções hierárquicas com LINQ")
    Dim turmasAlunos = From t In Turmas _
        Group Join e In Estudantes On t.IdTurma Equals e.IdTurma _
          Into Group _
        Select New With {.NomeTurma = t.Designacao, .Alunos = Group}

    For Each aux In turmasAlunos
      Console.WriteLine("Turma: {0}", aux.NomeTurma)
      For Each aluno In aux.Alunos
        Console.WriteLine(vbTab & "Aluno: {0}", aluno.Nome)
      Next
    Next

  End Sub

  Private Sub JuntaTodasTurmasComAlunosComInvocacaoMetodo()
    Dim turmasAlunos = Turmas.GroupJoin(Estudantes, _
                  Function(t) t.IdTurma, Function(e) e.IdTurma, _
                  Function(t, e) New With {.NomeTurma = t.Designacao, .Alunos = e})

    For Each aux In turmasAlunos
      Console.WriteLine("Turma: {0}", aux.NomeTurma)
      For Each aluno In aux.Alunos
        Console.WriteLine(vbTab & "Aluno: {0}", aluno.Nome)
      Next
    Next

  End Sub


  Private Sub CalculaAlunoMaximo()
    Dim maximo = (From e In Estudantes _
        Select e.Nome).Max()

    Console.WriteLine(maximo)
  End Sub

  Private Sub CalculaAlunoMaximoComTipoAnonimo()
    Dim maximo = (From e In Estudantes _
        Select New With {.Nome = e.Nome}).Max(Function(anon) anon.Nome)

    Console.WriteLine(maximo)
  End Sub

  Private Sub ContaEstudantes()
    Dim total = (From e In Estudantes _
        Where e.Disciplinas.Contains(Matematica) _
        Select e).Count()

    Console.WriteLine(total)
  End Sub

  Private Sub ContaNumeroTotalInscricoes()
    Dim total = (From e In Estudantes _
        From d In e.Disciplinas _
        Select d).Count()

    Console.WriteLine(total)
  End Sub


  Private Sub ListaDisciplinasSemRepetidos()
    Dim disciplinas = (From e In Estudantes _
        From d In e.Disciplinas _
        Select d).Distinct()

    For Each d In disciplinas
      Console.WriteLine(d.Nome)
    Next
  End Sub

  Private Sub JuntaListaDisciplinasDeInscritosComTodasDisciplinas()
    Dim disciplinasAlunos = (From e In Estudantes _
        From d In e.Disciplinas _
        Select d).Distinct()
    Dim uniao = disciplinasAlunos.Union(Disciplinas)
    For Each d In uniao
      Console.WriteLine(d.Nome)
    Next
  End Sub

  Private Sub ObtemIntercepcaoEntreDisciplinasDePrimeiroESegundoAlunos()
    Dim disciplinasPrimeiro = Estudante1.Disciplinas
    Dim disciplinasSegundo = Estudante2.Disciplinas

    Dim interseccao = disciplinasPrimeiro.Intersect(disciplinasSegundo)
    For Each disc In interseccao
      Console.WriteLine(disc.Nome)
    Next
  End Sub

  Private Sub ObtemDisciplinasPrimeiroNaoComunsAoSegundo()
    Dim disciplinasPrimeiro = Estudante1.Disciplinas
    Dim disciplinasSegundo = Estudante2.Disciplinas

    Dim discPrimeiro = disciplinasPrimeiro.Except(disciplinasSegundo)
    For Each disc In discPrimeiro
      Console.WriteLine(disc.Nome)
    Next
  End Sub

  Private Sub ObtemPrimeiroDisciplinaComecadaPorM()
    Dim primeira = Disciplinas.First(Function(d) d.Nome.StartsWith("M"))
    Console.WriteLine(primeira.Nome)
  End Sub

  Private Sub ObtemPrimeiroDisciplinaComecadaPorV()
    Dim primeira = Disciplinas.FirstOrDefault(Function(d) d.Nome.StartsWith("V"))
    Console.WriteLine(primeira Is Nothing)
  End Sub

  Private Sub ObtemPrimeirasDuasDisciplinasOrdenadasPorNome()
    Dim disciplinas__1 = Disciplinas.OrderBy(Function(d) d.Nome).Take(2)
    For Each d In disciplinas__1
      Console.WriteLine(d.Nome)
    Next
  End Sub

  Private Sub ObtemAlunosInscritosEmMaisDeDuasDisciplinas()
    Dim alunos = Estudantes.TakeWhile(Function(e) e.Disciplinas.Count > 2)
    For Each a In alunos
      Console.WriteLine(a.Nome)
    Next
  End Sub

  Private Sub DemonstraUsoLet()
    Dim alunos = From t In Turmas _
        Let numeroAlunos = (From e In Estudantes _
            Where e.IdTurma = t.IdTurma _
            Select e).Count() _
        Select New With {.Turma = t.Designacao, .NumeroAlunos = numeroAlunos}
    For Each a In alunos
      Console.WriteLine("{0} - {1}", a.Turma, a.NumeroAlunos)
    Next
  End Sub

  Private Sub DemonstraUsoLetComInvocacaoMetodo()
    Dim alunos = Turmas.Select(Function(t) New With {.Turma = t, .NumeroAlunos = Estudantes.Where(Function(e) e.IdTurma = t.IdTurma).Count()})
    For Each a In alunos
      Console.WriteLine("{0} - {1}", a.Turma, a.NumeroAlunos)
    Next
  End Sub

  Private Sub CriaSnapshot()
    Dim alunos = Estudantes.ToList().Where(Function(e) e.Disciplinas.Count = 1)
    Console.WriteLine(alunos.Count())

    Estudantes.Add(New Estudante With _
                               { _
                                   .Nome = "Novo", _
                                   .Disciplinas = New List(Of Disciplina)(New Disciplina() {Matematica}), _
                                   .Contactos = New List(Of Contacto)(), _
                                   .IdTurma = 1, _
                                   .Morada = New Morada With {.CodigoPostal = "9100 - Funchal", .Rua = "Centro"} _
                               })
    Console.WriteLine(alunos.Count())
  End Sub

  Private Sub CriaSnapshoptEmDicionario()
    Dim dicDisciplinas = Disciplinas.ToDictionary(Function(d) d.Nome)

    For Each item In dicDisciplinas
      Console.WriteLine("Chave: {0} --- Valor: {1}", item.Key, item.Value)
    Next
  End Sub


  Private Sub CriaSnapshotComToLookup()
    Dim aux = (From e In Estudantes _
        From d In e.Disciplinas _
        Select New With {.Estudante = e, .Disciplina = d}).ToLookup(Function(d) d.Disciplina.Nome)


    For Each a In aux
      Console.WriteLine("Disciplina: {0}", a.Key)
      For Each est In a
        Console.WriteLine("Nome aluno: {0}", est.Estudante.Nome)
      Next
    Next
  End Sub

  Private Estudantes2 As New ArrayList()
  Private Sub SeleccionaPrimeiroEstudanteDeEstudantes2()
    Dim estudantes = (From e In Estudantes2 _
        Select e).Take(1)

    For Each est In estudantes
      Console.WriteLine("Nome: {0}", est.Nome)
    Next
  End Sub


  Private Sub SeleccionaPrimeiroEstudanteDeEstudantes2ComInvocaocaMetodo()
    Dim estudantes__1 = Estudantes.Cast(Of Estudante)().Take(1)

    For Each est In estudantes__1
      Console.WriteLine("Nome: {0}", est.Nome)
    Next
  End Sub

  Private Sub IlustraRange()
    Dim posicoes = Enumerable.Range(1, 3)

    Dim tresPrimeirosEstudantes = posicoes.SelectMany(Function(p) (Estudantes.Where(Function(e, i) i = p)))

    For Each aux In tresPrimeirosEstudantes
      Console.WriteLine("Nome: {0}", aux.Nome)
    Next
  End Sub

  Private Sub IlustraRepeat()
    Dim novosEstudantes = Enumerable.Repeat(Estudante1, 2)
    For Each estudante In novosEstudantes
      Console.WriteLine("Nome: {0}", estudante.Nome)
    Next
  End Sub

  Private Sub IlustraRepeatComColeccoes()
    Dim novosEstudantes = Enumerable.Repeat(Estudantes, 2).SelectMany(Function(e) e)
    For Each estudante In novosEstudantes
      Console.WriteLine("Nome: {0}", estudante.Nome)
    Next
  End Sub



End Module
