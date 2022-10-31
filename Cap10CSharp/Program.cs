using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToObjects
{
    class Program
    {
        private static Disciplina Portugues = new Disciplina { Nome = "Portugues", Descricao= "Disciplina que apresenta fundamentos de Portugues" };
        private static Disciplina Ingles = new Disciplina { Nome = "Ingles", Descricao = "Disciplina que apresenta fundamentos de Ingles" };
        private static Disciplina Informatica = new Disciplina { Nome = "Informatica", Descricao = "Disciplina de informatica" };
        private static Disciplina Matematica = new Disciplina { Nome = "Matematica", Descricao = "Apresenta fundamentos matematica" };
        private static Disciplina Frances = new Disciplina { Nome = "Francês", Descricao = "Apresenta fundamentos francês" };

        private static Estudante Estudante1 = new Estudante
        {
            Nome = "Luis",
            IdTurma = 1,
            Morada = new Morada { CodigoPostal = "9100 - Funchal", Rua = "Rua Sao Pedro" },
            Contactos = new List<Contacto>{ new Email{ Valor = "luis@livrolinq.pt"}},
            Disciplinas = new List<Disciplina>{ Portugues, Ingles, Informatica }
        };

        private static Estudante Estudante2 = new Estudante
        {
            Nome = "Paulo",
            IdTurma = 2,
            Morada = new Morada { CodigoPostal = "1100 - Lisboa", Rua = "Rua do Rossio" },
            Contactos = new List<Contacto> { new Email { Valor = "paulo@livrolinq.pt" }, new Telefone{ Valor = "123123123"} },
            Disciplinas = new List<Disciplina> { Portugues, Matematica, Informatica }
        };

        private static Estudante Estudante3 = new Estudante
        {
            Nome = "Joana",
            IdTurma = 1,
            Morada = new Morada { CodigoPostal = "1100 - Lisboa", Rua = "Rua do Rossio" },
            Contactos = new List<Contacto> { new Email { Valor = "joana@livrolinq.pt" } },
            Disciplinas = new List<Disciplina> { Ingles, Matematica, Informatica }
        };

        private static Estudante Estudante4 = new Estudante
        {
            Nome = "Paula",
            IdTurma = 2,
            Morada = new Morada { CodigoPostal = "1100 - Lisboa", Rua = "Rua do Rossio" },
            Contactos = new List<Contacto> { new Email { Valor = "paula@livrolinq.pt" }, new Telefone{ Valor = "121212121" } },
            Disciplinas = new List<Disciplina> { Portugues, Matematica, Informatica }
        };

        private static Estudante Estudante5 = new Estudante
        {
            Nome = "Rita",
            IdTurma = 1,
            Morada = new Morada { CodigoPostal = "1100 - Lisboa", Rua = "Rua do Rossio" },
            Contactos = new List<Contacto> { new Email { Valor = "rita@livrolinq.pt" } },
            Disciplinas = new List<Disciplina> { Portugues, Matematica, Informatica }
        };

        private static Estudante Estudante6 = new Estudante
        {
            Nome = "Luisa",
            IdTurma = 2,
            Morada = new Morada { CodigoPostal = "4100 - Porto", Rua = "Rua da Ribeira" },
            Disciplinas = new List<Disciplina> { Portugues, Matematica, Informatica }
        };

        public static List<Disciplina> Disciplinas = new List<Disciplina>
        {
            Portugues,
            Ingles,
            Matematica,
            Informatica,
            Frances
        };

        public static List<Estudante> Estudantes = new List<Estudante>
        {
            Estudante1,
            Estudante2,
            Estudante3,
            Estudante4,
            Estudante5,
            Estudante6
        };

        private static Turma Turma1 = new Turma { IdTurma = 1, Designacao = "Turma 1" };
        private static Turma Turma2 = new Turma { IdTurma = 2, Designacao = "Turma 2" };
        private static Turma Turma3 = new Turma { IdTurma = 3, Designacao = "Turma 3" };
        private static List<Turma> Turmas = new List<Turma> { Turma1, Turma2, Turma3 };


        static void ListaTodasDisciplinas()
        {
            var todasDisciplinas = from d in Disciplinas
                                   select d;
            Console.WriteLine(todasDisciplinas.GetType());
            foreach(var disc in todasDisciplinas )
            {
                Console.WriteLine(disc.Nome);
            }
        }

        static void ListaTodasDisciplinasComMetodosExtensao()
        {
            var todasDisciplinas = Disciplinas.Select(d => d);
            Console.WriteLine(todasDisciplinas.GetType());
            foreach (var disc in todasDisciplinas)
            {
                Console.WriteLine(disc.Nome);
            }
        }

        static void ListaApenasNomesDeDisciplinas()
        {
            var apenasNomes = from d in Disciplinas
                              select d.Nome;

            foreach(var disc in apenasNomes )
            {
                Console.WriteLine( "Tipo: {0}---Valor: {1}", disc.GetType(), disc);
            }
        }

        static void ListaNomesDisciplinasComNovoTipo()
        {
            var novoTipo = from d in Disciplinas
                           select new {NomeDisciplina = d.Nome};

            foreach (var disc in novoTipo)
            {
                Console.WriteLine("Tipo: {0}---Valor: {1}", disc.GetType(), disc);
            }
        }

        static void ListaNomesDisciplinasComNovoTipoInvocacaoMetodos()
        {
            var novoTipo = Disciplinas.Select(d => new {NomeDisciplina = d.Nome});

            foreach (var disc in novoTipo)
            {
                Console.WriteLine("Tipo: {0}---Valor: {1}", disc.GetType(), disc);
            }
        }

        static void ListaAlunosMatriculadosEmInformatica()
        {
            var alunosInformatica = from e in Estudantes
                                    where e.Disciplinas.Contains(Informatica)
                                    select e;

            foreach (var estudante in alunosInformatica)
            {
                Console.WriteLine( "Nome: {0} ", estudante.Nome);
            }
        }

        static void ListaAlunosMatriculadosEmInformaticaInvocacaoMetodos()
        {
            var alunosInformatica = Estudantes
                .Where(e => e.Disciplinas.Contains(Informatica))
                .Select(e => e);

            foreach (var estudante in alunosInformatica)
            {
                Console.WriteLine("Nome: {0} ", estudante.Nome);
            }
        }

        static void ListaAlunosMatriculadosEmInformaticaContidosSubconjuntoTresAlunos()
        {
            var primeirosAlunos = Estudantes
                                  .Where( (est, index) => est.Disciplinas.Contains(Informatica) && index < 3 )
                                  .Select( e => e);
            foreach(var aluno in primeirosAlunos)
            {
                Console.WriteLine( "Nome: {0}", aluno.Nome);
            }
        }

        static void ListaDisciplinasAlunosQueEstaoEmMatematica1()
        {
            var disciplinas = from e in Estudantes
                         where e.Disciplinas.Contains(Matematica)
                         select e.Disciplinas;

            foreach(var disc in disciplinas )
            {
                Console.WriteLine(disc.GetType());
            }
        }

        static void ListaDisciplinasAlunosQueEstaoEmMatematica2()
        {
            var disciplinas = from e in Estudantes
                              where e.Disciplinas.Contains(Matematica)
                                from d in e.Disciplinas
                                select d;

            foreach (var d in disciplinas)
            {
                Console.WriteLine("Tipo: {0}, Nome: {1}", d.GetType(), d.Nome);
            }
        }

        static void ListaDisciplinasAlunosQueEstaoEmMatematica2ComIncovacaoMetodo()
        {
            var disciplinas = Estudantes
                                .Where(e => e.Disciplinas.Contains(Matematica))
                                .SelectMany(e => e.Disciplinas);
            foreach (var d in disciplinas)
            {
                Console.WriteLine("Tipo: {0}, Nome: {1}", d.GetType(), d.Nome);
            }
        }

        static void ListaDisciplinasAlunosQueEstaoEmMatematicaComProjeccao()
        {
            var disciplinas = Estudantes.Where(e => e.Disciplinas.Contains(Matematica))
                .SelectMany(
                e => e.Disciplinas,
                (e, d) => new { NomeAluno = e.Nome, NomeDisciplina=d.Nome} );

            foreach (var d in disciplinas)
            {
                Console.WriteLine("Aluno: {0}, Disciplina: {1}", d.NomeAluno, d.NomeDisciplina);
            }
        }

        static void ListaEstudantesOrdenados()
        {
            var estudantes = from e in Estudantes
                             orderby e.Nome
                             select e;

            foreach(var e in estudantes)
            {
                Console.WriteLine( "Nome: {0}", e.Nome);
            }
        }

        static void ListaEstudantesOrdenadosComInvocacaoMetodo()
        {
            var estudantes = Estudantes.OrderBy(e => e.Nome).Select(e => e);
            foreach (var e in estudantes)
            {
                Console.WriteLine("Nome: {0}", e.Nome);
            }
        }

        static void ListaEstudantesOrdenadosDecrescente()
        {
            var estudantes = from e in Estudantes
                             orderby e.Nome descending 
                             select e;

            foreach (var e in estudantes)
            {
                Console.WriteLine("Nome: {0}", e.Nome);
            }
        }

        static void ListaEstudantesOrdenadosDecrescenteComInvocacaoMetodo()
        {
            var estudantes = Estudantes.OrderByDescending(e => e.Nome).Select(e => e);

            foreach (var e in estudantes)
            {
                Console.WriteLine("Nome: {0}", e.Nome);
            }
        }

        static void ListaEstudantesOrdenadosPorNomeEMorada()
        {
            var estudantes = from e in Estudantes
                             orderby e.Nome, e.Morada
                             select e;
            foreach (var e in estudantes)
            {
                Console.WriteLine("Nome: {0}", e.Nome);
            }
        }

        static void InverteListaEstundantesOrdenadosPorNomeeMorada()
        {
            var estudantes = Estudantes
                .OrderBy(e => e.Nome)
                .ThenBy(e => e.Morada)
                .Reverse();

            foreach (var e in estudantes)
            {
                Console.WriteLine("Nome: {0}", e.Nome);
            }
        }

        static void InverteListaEstundantesOrdenadosPorNomeeMoradaComLINQ()
        {
            var estudantes = (
                                from e in Estudantes 
                                orderby e.Nome, e.Morada
                                select e
                                  ).Reverse();

            foreach (var e in estudantes)
            {
                Console.WriteLine("Nome: {0}", e.Nome);
            }
        }

        static void AgrupaItensPorCodigoPostal()
        {
            var estudantes = from e in Estudantes
                             group e by e.Morada.CodigoPostal;

            foreach( var e in estudantes)
            {
                Console.WriteLine( "Chave: {0}", e.Key );
                foreach( var estudante in e)
                {
                    Console.WriteLine("Nome: {0}", estudante.Nome);
                }
            }
        }

        static void AgrupaItensPorCodigoPostalComInvocacaoMetodo()
        {
            var estudantes = Estudantes.GroupBy(e => e.Morada.CodigoPostal);

            foreach (var e in estudantes)
            {
                Console.WriteLine("Chave: {0}", e.Key);
                foreach (var estudante in e)
                {
                    Console.WriteLine("Nome: {0}", estudante.Nome);
                }
            }
        }

        static void AgrupaItensPorCodigoPostalComNovoElemento()
        {
            var estudantes = from e in Estudantes
                             group new {e.Nome} by e.Morada.CodigoPostal;
                             

            foreach (var e in estudantes)
            {
                Console.WriteLine("Chave: {0}", e.Key);
                foreach (var estudante in e)
                {
                    Console.WriteLine("Nome: {0}", estudante.Nome);
                }
            }
        }

        static void AgrupaItensPorCodigoPostalComNovoElementoEInvocacaoMetodo()
        {
            var estudantes = Estudantes
                .GroupBy(e => e.Morada.CodigoPostal,e => new {Nome = e.Nome});


            foreach (var e in estudantes)
            {
                Console.WriteLine("Chave: {0}", e.Key);
                foreach (var estudante in e)
                {
                    Console.WriteLine("Nome: {0}", estudante.Nome);
                }
            }
        }

        static void JuntaAlunosETurmas()
        {
            var alunosTurmas = from e in Estudantes
                                    join t in Turmas
                                        on e.IdTurma equals t.IdTurma
                                    select new {NomeAluno = e.Nome, NomeTurma = t.Designacao};

            foreach(var ad in alunosTurmas)
            {
                Console.WriteLine("Aluno: {0}, Turma: {1}", ad.NomeAluno, ad.NomeTurma);
            }
        }

        static void JuntaAlunosETurmasComInvocacaoMetodos()
        {
            var alunosTurmas = Estudantes
                                .Join(
                                        Turmas,  //segunda colecção
                                        e => e.IdTurma, //seleccionar elemento da primeira coleccção
                                        t => t.IdTurma,  //seleccionar elemento da segundao colecção
                                        (e, t) => new { NomeAluno = e.Nome, NomeDisciplina = t.Designacao } ); //projecção}

            foreach (var ad in alunosTurmas)
            {
                Console.WriteLine("Aluno: {0}, Turma: {1}", ad.NomeAluno, ad.NomeDisciplina);
            }
        }

        static void JuntaTodasTurmasComAlunos()
        {
            var turmasAlunos = from t in Turmas
                               join e in Estudantes
                                   on t.IdTurma equals e.IdTurma
                                   into TodasTurmas
                               select new {NomeTurma = t.Designacao, Alunos = TodasTurmas};

            foreach (var aux in turmasAlunos)
            {
                Console.WriteLine("Turma: {0}", aux.NomeTurma);
                foreach(var aluno in aux.Alunos)
                {
                    Console.WriteLine("\tAluno: {0}", aluno.Nome);
                }
            }
                                    
        }

        static void JuntaTodasTurmasComAlunosComInvocacaoMetodo()
        {
            var turmasAlunos = Turmas
                                .GroupJoin(
                                        Estudantes,
                                        t => t.IdTurma,
                                        e => e.IdTurma,
                                        (t, e) => new {NomeTurma = t.Designacao, Alunos = e}
                                       );
        
            foreach (var aux in turmasAlunos)
            {
                Console.WriteLine("Turma: {0}", aux.NomeTurma);
                foreach (var aluno in aux.Alunos)
                {
                    Console.WriteLine("\tAluno: {0}", aluno.Nome);
                }
            }

        }


        static void CalculaAlunoMaximo()
        {
            var maximo = (from e in Estudantes select e.Nome).Max();

            Console.WriteLine(maximo);
        }

        static void CalculaAlunoMaximoComTipoAnonimo()
        {
            var maximo = (from e in Estudantes select new { Nome = e.Nome}).Max( anon => anon.Nome);

            Console.WriteLine(maximo);
        }

        static void ContaEstudantes()
        {
            var total = (
                            from e in Estudantes 
                            where e.Disciplinas.Contains(Matematica)
                            select e
                        ).Count();

            Console.WriteLine(total);
        }

        static void ContaNumeroTotalInscricoes()
        {
            var total =
                (
                    from e in Estudantes
                    from d in e.Disciplinas
                    select d
                ).Count();

            Console.WriteLine(total);
        }


        static void ListaDisciplinasSemRepetidos()
        {
            var disciplinas = (
                                  from e in Estudantes
                                  from d in e.Disciplinas
                                  select d
                              ).Distinct();

            foreach(var d in disciplinas)
            {
                Console.WriteLine(d.Nome);
            }
        }

        static void JuntaListaDisciplinasDeInscritosComTodasDisciplinas()
        {
            var disciplinasAlunos = (
                                  from e in Estudantes
                                  from d in e.Disciplinas
                                  select d
                              ).Distinct();
            var uniao = disciplinasAlunos.Union(Disciplinas);
            foreach (var d in uniao)
            {
                Console.WriteLine(d.Nome);
            }
        }

        static void ObtemIntercepcaoEntreDisciplinasDePrimeiroESegundoAlunos()
        {
            var disciplinasPrimeiro = Estudante1.Disciplinas;
            var disciplinasSegundo = Estudante2.Disciplinas;

            var interseccao = disciplinasPrimeiro.Intersect(disciplinasSegundo);
            foreach(var disc in interseccao)
            {
                Console.WriteLine(disc.Nome);
            }
        }

        static void ObtemDisciplinasPrimeiroNaoComunsAoSegundo()
        {
            var disciplinasPrimeiro = Estudante1.Disciplinas;
            var disciplinasSegundo = Estudante2.Disciplinas;

            var discPrimeiro = disciplinasPrimeiro.Except(disciplinasSegundo);
            foreach (var disc in discPrimeiro)
            {
                Console.WriteLine(disc.Nome);
            }
        }

        static void ObtemPrimeiroDisciplinaComecadaPorM()
        {
            var primeira = Disciplinas.First(d => d.Nome.StartsWith("M"));
            Console.WriteLine(primeira.Nome);
        }

        static void ObtemPrimeiroDisciplinaComecadaPorV()
        {
            var primeira = Disciplinas.FirstOrDefault(d => d.Nome.StartsWith("V"));
            Console.WriteLine(primeira==null);
        }

        static void ObtemPrimeirasDuasDisciplinasOrdenadasPorNome()
        {
            var disciplinas = Disciplinas
                                .OrderBy(d => d.Nome)
                                .Take(2);
            foreach(var d in disciplinas)
            {
                Console.WriteLine(d.Nome);
            }
        }

        static void ObtemAlunosInscritosEmMaisDeDuasDisciplinas()
        {
            var alunos = Estudantes.TakeWhile(e => e.Disciplinas.Count > 2);
            foreach (var a in alunos)
            {
                Console.WriteLine(a.Nome);
            }
        }

        static void DemonstraUsoLet() 
        {
            var alunos = from t in Turmas
                         let numeroAlunos = (from e in Estudantes
                                         where e.IdTurma == t.IdTurma
                                         select e).Count()
                         select new { Turma = t.Designacao, NumeroAlunos = numeroAlunos};
            foreach (var a in alunos) {
                Console.WriteLine("{0} - {1}", a.Turma, a.NumeroAlunos);
            }
        }

        static void DemonstraUsoLetComInvocacaoMetodo() {
            var alunos = Turmas.Select(
                t => new { Turma = t, NumeroAlunos = Estudantes.Where(e => e.IdTurma == t.IdTurma).Count() });
            foreach (var a in alunos) {
                Console.WriteLine("{0} - {1}", a.Turma, a.NumeroAlunos);
            }
        }

        static void CriaSnapshot()
        {
            var alunos = Estudantes.ToList().Where(e => e.Disciplinas.Count == 1);
            Console.WriteLine(alunos.Count());

            Estudantes.Add(new Estudante
                               {
                                   Nome = "Novo",
                                   Disciplinas = new List<Disciplina>
                                                     {
                                                         Matematica
                                                     },
                                   Contactos = new List<Contacto>(),
                                   IdTurma = 1,
                                   Morada = new Morada {CodigoPostal = "9100 - Funchal", Rua = "Centro"}
                               });
            Console.WriteLine(alunos.Count());
        }

        static void CriaSnapshoptEmDicionario()
        {
            var dicDisciplinas = Disciplinas.ToDictionary(d => d.Nome);

            foreach( var item in dicDisciplinas)
            {
                Console.WriteLine( "Chave: {0} --- Valor: {1}", item.Key, item.Value);
            }
        }
        static void CriaSnapshotComToLookup()
        {
            var aux = (from e in Estudantes
                       from d in e.Disciplinas
                       select new{ Estudante = e, Disciplina = d})
                .ToLookup(d => d.Disciplina.Nome);

            foreach( var a in aux)
            {
                Console.WriteLine("Disciplina: {0}", a.Key);
                foreach(var est in a)
                {
                    Console.WriteLine( "Nome aluno: {0}", est.Estudante.Nome);
                }
            }
        }

        private static ArrayList Estudantes2 = new ArrayList(){ Estudante1, Estudante2};
        static void SeleccionaPrimeiroEstudanteDeEstudantes2()
        {
            var estudantes = (from Estudante e in Estudantes2
                              select e).Take(1);

            foreach(var est in estudantes)
            {
                Console.WriteLine( "Nome: {0}", est.Nome);
            }
        }


        static void SeleccionaPrimeiroEstudanteDeEstudantes2ComInvocaocaMetodo()
        {
            var estudantes = Estudantes.Cast<Estudante>().Take(1);

            foreach (var est in estudantes)
            {
                Console.WriteLine("Nome: {0}", est.Nome);
            }
        }

        static void IlustraRange()
        {
            var posicoes = Enumerable.Range(1, 3);

            var tresPrimeirosEstudantes = posicoes.
                SelectMany(
                    p => (Estudantes.Where((e, i) => i == p))
                );

            foreach(var aux in tresPrimeirosEstudantes)
            {
                Console.WriteLine( "Nome: {0}", aux.Nome);
            }
        }

        static void IlustraRepeat()
        {
            var novosEstudantes = Enumerable.Repeat(Estudante1, 2);
            foreach(var estudante in novosEstudantes)
            {
                Console.WriteLine( "Nome: {0}", estudante.Nome);
            }
        }

        static void IlustraRepeatComColeccoes()
        {
            var novosEstudantes = Enumerable.Repeat(Estudantes, 2).SelectMany( e => e);
            foreach (var estudante in novosEstudantes)
            {
                Console.WriteLine("Nome: {0}", estudante.Nome);
            }
        }
        
        static void Main(string[] args)
        {
            ListaTodasDisciplinas();
            ListaTodasDisciplinasComMetodosExtensao();
            ListaApenasNomesDeDisciplinas();
            ListaNomesDisciplinasComNovoTipo();
            ListaNomesDisciplinasComNovoTipoInvocacaoMetodos();
            ListaAlunosMatriculadosEmInformatica();
            ListaAlunosMatriculadosEmInformaticaInvocacaoMetodos();
            ListaAlunosMatriculadosEmInformaticaContidosSubconjuntoTresAlunos();
            ListaDisciplinasAlunosQueEstaoEmMatematica1();
            ListaDisciplinasAlunosQueEstaoEmMatematica2();
            ListaDisciplinasAlunosQueEstaoEmMatematica2ComIncovacaoMetodo();
            ListaDisciplinasAlunosQueEstaoEmMatematicaComProjeccao();
            ListaEstudantesOrdenados();
            ListaEstudantesOrdenadosDecrescente();
            ListaEstudantesOrdenadosPorNomeEMorada();

            InverteListaEstundantesOrdenadosPorNomeeMorada();
            InverteListaEstundantesOrdenadosPorNomeeMoradaComLINQ();

            AgrupaItensPorCodigoPostal();

            AgrupaItensPorCodigoPostalComInvocacaoMetodo();
        AgrupaItensPorCodigoPostalComNovoElemento();
            AgrupaItensPorCodigoPostalComNovoElementoEInvocacaoMetodo();

            JuntaAlunosETurmas();
            

            JuntaAlunosETurmasComInvocacaoMetodos();
            JuntaTodasTurmasComAlunos();
            JuntaTodasTurmasComAlunosComInvocacaoMetodo();

            CalculaAlunoMaximo();
            CalculaAlunoMaximoComTipoAnonimo();

            ContaEstudantes();
            ContaNumeroTotalInscricoes();

            ListaDisciplinasSemRepetidos();
            JuntaListaDisciplinasDeInscritosComTodasDisciplinas();
            ObtemIntercepcaoEntreDisciplinasDePrimeiroESegundoAlunos();
            ObtemDisciplinasPrimeiroNaoComunsAoSegundo();
         ObtemPrimeiroDisciplinaComecadaPorM();
            ObtemPrimeiroDisciplinaComecadaPorV();


            ObtemPrimeirasDuasDisciplinasOrdenadasPorNome();
            ObtemAlunosInscritosEmMaisDeDuasDisciplinas();
            CriaSnapshot();        
            CriaSnapshoptEmDicionario();

            CriaSnapshotComToLookup();
        SeleccionaPrimeiroEstudanteDeEstudantes2();
            SeleccionaPrimeiroEstudanteDeEstudantes2ComInvocaocaMetodo();
            IlustraRange();

            IlustraRepeat();
            IlustraRepeatComColeccoes();
            DemonstraUsoLet();
        }




    }
}
