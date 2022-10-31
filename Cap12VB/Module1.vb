Imports System.Data.Linq
Imports Cap12VB.LINQToSQL.Manual
Imports System.Transactions

Module Module1
  Private Const ConnectionString As String = "data source=.\sqlexpress2008;initial catalog=turmas; user id=sa; password=sqladmin"

  Sub Main()
    Console.Title = "LINQ Com C# - Capítulo 12"

    'EliminaMoradaDeAlunoComTransaccao();
    ImprimeTodasAsDisciplinas()
    ImprimeAlunosEMoradas()
    ImprimeAlunosEDisciplinas()
    ImprimeMoradaComRelacionamentoOO()
    ImprimeContactosComRelacionamentoOO()
    ImprimeContactosComRelacionamentoOOShape()
    ImprimeContactosComRelacionamentoOOShapeAssociate()
    CarregaDisciplinasDoEstudanteLuis()
    CarregaTelefones()
    UsaSpComID()
    Compiled()
    CriaNovaDisciplina()
    AdicionaContacto()
    ModificaNome()
    ModificaContacto()

    EliminaContacto()

    EliminaMoradaDeAluno()
    ImprimeMoradaComRelacionamentoOO()

  End Sub

  Private Sub ImprimeTodasAsDisciplinas()
    Using contexto = New DataContext(ConnectionString)
      contexto.Log = Console.Out
      Dim tabelaDisciplinas = contexto.GetTable(Of Disciplina)()
      Dim todasDisciplinas = From disc In tabelaDisciplinas _
          Select disc
      For Each d In todasDisciplinas
        Console.WriteLine(d.Designacao)
      Next
    End Using
  End Sub
  Private Sub ImprimeAlunosEMoradas()
    Using contexto = New DataContext(ConnectionString)
      contexto.Log = Console.Out
      Dim tabelaMoradas = contexto.GetTable(Of Morada)()
      Dim tabelaEstudantes = contexto.GetTable(Of Estudante)()
      Dim informacaoSobreAluno = From est In tabelaEstudantes _
          Join mor In tabelaMoradas On est.IdEstudante Equals mor.IdEstudante _
          Select New With {est.Nome, mor.Rua}
      For Each d In informacaoSobreAluno
        Console.WriteLine("{0} - {1}", d.Nome, d.Rua)
      Next
    End Using
  End Sub

  Private Sub ImprimeAlunosEDisciplinas()
    Using contexto = New DataContext(ConnectionString)
      contexto.Log = Console.Out
      Dim tabelaDisciplinas = contexto.GetTable(Of Disciplina)()
      Dim tabelaDisciplinasEstudantes = contexto.GetTable(Of DisciplinasEstudantes)()
      Dim tabelaEstudantes = contexto.GetTable(Of Estudante)()
      Dim disciplinasEstudantes = From disc In tabelaDisciplinas _
          Join discest In tabelaDisciplinasEstudantes On disc.IdDisciplina Equals discest.IdDisciplina _
          Join est In tabelaEstudantes On discest.IdEstudante Equals est.IdEstudante _
          Order By est.Nome _
          Select New With {disc.Designacao, est.Nome}

      For Each de In DisciplinasEstudantes
        Console.WriteLine("{0} - {1}", de.Nome, de.Designacao)
      Next
    End Using
  End Sub

  Private Sub ImprimeMoradaComRelacionamentoOO()
    Using contexto = New DataContext(ConnectionString)
      contexto.DeferredLoadingEnabled = False
      contexto.Log = Console.Out
      Dim tabelaEstudantes = contexto.GetTable(Of Estudante)()
      'select new { est.Nome, est.Morada.Rua };
      Dim info = From est In tabelaEstudantes _
          Select est
      For Each e In info
        If e.Morada Is Nothing Then
          Continue For
        End If
        Console.WriteLine("{0} - {1}", e.Nome, e.Morada.Rua)
      Next
    End Using
  End Sub

  Private Sub ImprimeContactosComRelacionamentoOO()
    Using contexto = New DataContext(ConnectionString)
      contexto.Log = Console.Out
      Dim tabelaEstudantes = contexto.GetTable(Of Estudante)()
      Dim info = From est In tabelaEstudantes _
          Select est
      For Each res In info
        Console.WriteLine(res.Nome)
        For Each ct In res.Contactos
          Console.WriteLine(vbTab & "{0}", ct.Valor)
        Next
      Next
    End Using
  End Sub

  Private Sub ImprimeContactosComRelacionamentoOOShape()
    Using contexto = New DataContext(ConnectionString)
      contexto.Log = Console.Out
      Dim shape = New DataLoadOptions()
      shape.LoadWith(Of Estudante)(Function(e) e.Contactos)
      contexto.LoadOptions = shape

      Dim tabelaEstudantes = contexto.GetTable(Of Estudante)()
      Dim info = From est In tabelaEstudantes _
          Select est
      For Each res In info
        Console.WriteLine(res.Nome)
        For Each ct In res.Contactos
          Console.WriteLine(vbTab & "{0}", ct.Valor)
        Next
      Next
    End Using
  End Sub

  Private Sub ImprimeContactosComRelacionamentoOOShapeAssociate()
    Using contexto = New DataContext(ConnectionString)
      contexto.Log = Console.Out
      Dim shape = New DataLoadOptions()
      shape.AssociateWith(Of Estudante)(Function(e) e.Contactos.Where(Function(c) c.TipoContacto = 0))
      contexto.LoadOptions = shape

      Dim tabelaEstudantes = contexto.GetTable(Of Estudante)()
      Dim info = From est In tabelaEstudantes _
          Select est
      For Each res In info
        Console.WriteLine(res.Nome)
        For Each ct In res.Contactos
          Console.WriteLine(vbTab & "{0}", ct.Valor)
        Next
      Next
    End Using
  End Sub

  Private Sub CarregaDisciplinasDoEstudanteLuis()
    Using contexto = New DataContext(ConnectionString)
      contexto.Log = Console.Out
      Dim tabelaEstudantes = contexto.GetTable(Of Estudante)()
      Dim estudante = From est In tabelaEstudantes _
          Where est.Nome.Contains("Luis") _
          Select est
      Dim disciplinasLuis = estudante.First().Disciplinas
      For Each disc In disciplinasLuis
        Console.WriteLine(disc.Designacao)
      Next
    End Using
  End Sub

  Private Sub CarregaTelefones()
    Using contexto = New DataContext(ConnectionString)
      contexto.Log = Console.Out
      Dim tabelaEstudantes = contexto.GetTable(Of Estudante)()
      Dim telefones = From est In tabelaEstudantes _
          From cont In est.Contactos _
          Where TypeOf cont Is Telefone _
          Select New With {est.Nome, cont.Valor}
      For Each tel In telefones
        Console.WriteLine("{0} - {1}", tel.Nome, tel.Valor)
      Next
    End Using
  End Sub

  Private Sub UsaSp()
    Using contexto = New CustomContext(ConnectionString)
      contexto.Log = Console.Out
      Dim contactos = contexto.ObtemContactosEstudantes()
      For Each c In contactos
        Console.WriteLine("{0} - {1}", c.Nome, c.Contacto)
      Next
    End Using
  End Sub

  Private Sub UsaSpComID()
    Using contexto = New CustomContext(ConnectionString)
      contexto.Log = Console.Out
      Dim contactos = contexto.ObtemContactosDoEstudante(1)
      For Each c In contactos
        Console.WriteLine("{0} - {1}", c.Nome, c.Contacto)
      Next
    End Using
  End Sub

  Private Sub Compiled()
    Using context = New DataContext(ConnectionString)
      context.Log = Console.Out
      Dim tabelaEstudantes = context.GetTable(Of Estudante)()
      Dim compiled = CompiledQuery.Compile(Function(ctx As DataContext) (From est In tabelaEstudantes _
          Select est))

      Dim results = compiled(context)
      For Each est In results
        Console.WriteLine(est.Nome)
      Next
    End Using
  End Sub

  Private Sub CriaNovaDisciplina()
    Using context = New DataContext(ConnectionString)
      context.Log = Console.Out
      Dim tabelaDisciplinas = context.GetTable(Of Disciplina)()
      Dim novaDisciplina = New Disciplina() With {.Designacao = "História"}
      tabelaDisciplinas.InsertOnSubmit(novaDisciplina)
      context.SubmitChanges()
    End Using
  End Sub

  Private Sub AdicionaContacto()
    Using context = New DataContext(ConnectionString)
      context.Log = Console.Out
      Dim tabelaEstudantes = context.GetTable(Of Estudante)()
      Dim options = New DataLoadOptions()
      options.LoadWith(Of Estudante)(Function(e) e.Contactos)
      context.LoadOptions = options
      Dim contacto = New Telefone() With {.Valor = "123111111"}
      Dim estudante = tabelaEstudantes.Where(Function(e) e.Nome.Contains("Luis")).First()
      contacto.IdEstudante = estudante.IdEstudante
      estudante.Contactos.Add(contacto)
      context.SubmitChanges()
    End Using
  End Sub

  Private Sub ModificaNome()
    Dim estudante As Estudante

    Using contextoLeitura = New DataContext(ConnectionString)
      contextoLeitura.Log = Console.Out
      Dim tabelaEstudantes = contextoLeitura.GetTable(Of Estudante)()
      estudante = tabelaEstudantes.Where(Function(e) e.IdEstudante = 1).First()
    End Using
    estudante.Detach()
    estudante.Nome = "Luis Abreu"
    Using contextoGravacao = New DataContext(ConnectionString)
      contextoGravacao.Log = Console.Out
      contextoGravacao.GetTable(Of Estudante)().Attach(estudante, True)
      contextoGravacao.SubmitChanges()
    End Using
  End Sub


  Private Sub ModificaContacto()
    Using contexto = New DataContext(ConnectionString)
      contexto.Log = Console.Out
      Dim tabelaContactos = contexto.GetTable(Of Contacto)()
      Dim contacto = tabelaContactos.First()
      contacto.Valor = "999881888"
      contexto.Log = Console.Out
      contexto.SubmitChanges()
    End Using
  End Sub

  Private Sub EliminaContacto()
    Using contexto = New DataContext(ConnectionString)
      contexto.Log = Console.Out
      Dim tabelaContactos = contexto.GetTable(Of Contacto)()
      Dim contacto = tabelaContactos.First()
      tabelaContactos.DeleteOnSubmit(contacto)
      contexto.SubmitChanges()
    End Using
  End Sub

  Private Sub EliminaMoradaDeAluno()
    'transaction scope para fazer rollback...
    Using scope = New TransactionScope()
      Using contexto = New DataContext(ConnectionString)
        contexto.Log = Console.Out
        Dim options = New DataLoadOptions()
        options.LoadWith(Of Estudante)(Function(e) e.Morada)
        Dim tabelaEstudantes = contexto.GetTable(Of Estudante)()
        Dim estudante = tabelaEstudantes.First()
        estudante.Morada.Estudante = Nothing
        contexto.SubmitChanges()
      End Using
    End Using
  End Sub


  Private Sub EliminaMoradaDeAlunoComTransaccao()
    Using scope = New TransactionScope()
      Using contexto = New DataContext(ConnectionString)
        contexto.Log = Console.Out
        Dim moradas = contexto.GetTable(Of Morada)()
        Dim morada = moradas.First()
        moradas.DeleteOnSubmit(morada)
        contexto.SubmitChanges()
        For Each e In moradas
          Console.WriteLine(e.IdEstudante)
        Next
      End Using
    End Using
    Console.WriteLine("-----")
    Using contexto = New DataContext(ConnectionString)
      contexto.Log = Console.Out
      Dim moradas = contexto.GetTable(Of Morada)()
      For Each e In moradas
        Console.WriteLine(e.IdEstudante)
      Next
    End Using
  End Sub



End Module
