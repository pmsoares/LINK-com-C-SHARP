using System;
using System.Data.Linq;
using System.Linq;
using System.Transactions;
using LINQToSQL.Manual;

namespace LINQToSQL
{
    internal class Program
    {
        private const string ConnectionString =
            @"data source=.\sqlexpress2008;initial catalog=turmas; user id=sa; password=sqladmin";

        //const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Turmas;Integrated Security=True";
        private static void ImprimeTodasAsDisciplinas()
        {
            using (var contexto = new DataContext(ConnectionString))
            {
                contexto.Log = Console.Out;
                var tabelaDisciplinas = contexto.GetTable<Disciplina>();
                var todasDisciplinas = from disc in tabelaDisciplinas
                                       select disc;
                foreach (var d in todasDisciplinas)
                {
                    Console.WriteLine(d.Designacao);
                }
            }
        }

        private static void ImprimeAlunosEMoradas()
        {
            using (var contexto = new DataContext(ConnectionString))
            {
                contexto.Log = Console.Out;
                var tabelaMoradas = contexto.GetTable<Morada>();
                var tabelaEstudantes = contexto.GetTable<Estudante>();
                var informacaoSobreAluno = from est in tabelaEstudantes
                                           join mor in tabelaMoradas on est.IdEstudante equals mor.IdEstudante
                                           select new {est.Nome, mor.Rua};
                foreach (var d in informacaoSobreAluno)
                {
                    Console.WriteLine("{0} - {1}", d.Nome, d.Rua);
                }
            }
        }

        private static void ImprimeAlunosEDisciplinas()
        {
            using (var contexto = new DataContext(ConnectionString))
            {
                contexto.Log = Console.Out;
                var tabelaDisciplinas = contexto.GetTable<Disciplina>();
                var tabelaDisciplinasEstudantes = contexto.GetTable<DisciplinasEstudantes>();
                var tabelaEstudantes = contexto.GetTable<Estudante>();
                var disciplinasEstudantes = from disc in tabelaDisciplinas
                                            join discest in tabelaDisciplinasEstudantes
                                                on disc.IdDisciplina equals discest.IdDisciplina
                                            join est in tabelaEstudantes
                                                on discest.IdEstudante equals est.IdEstudante
                                            orderby est.Nome
                                            select new {disc.Designacao, est.Nome};

                foreach (var de in disciplinasEstudantes)
                {
                    Console.WriteLine("{0} - {1}", de.Nome, de.Designacao);
                }
            }
        }

        private static void ImprimeMoradaComRelacionamentoOO()
        {
            using (var contexto = new DataContext(ConnectionString))
            {
                contexto.DeferredLoadingEnabled = false;
                contexto.Log = Console.Out;
                var tabelaEstudantes = contexto.GetTable<Estudante>();
                var info = from est in tabelaEstudantes
                           //select new { est.Nome, est.Morada.Rua };
                           select est;
                foreach (var e in info)
                {
                    if (e.Morada == null) continue;
                    Console.WriteLine("{0} - {1}", e.Nome, e.Morada.Rua);
                }
            }
        }

        private static void ImprimeContactosComRelacionamentoOO()
        {
            using (var contexto = new DataContext(ConnectionString))
            {
                contexto.Log = Console.Out;
                var tabelaEstudantes = contexto.GetTable<Estudante>();
                var info = from est in tabelaEstudantes
                           select est;
                foreach (var res in info)
                {
                    Console.WriteLine(res.Nome);
                    foreach (var ct in res.Contactos)
                    {
                        Console.WriteLine("\t{0}", ct.Valor);
                    }
                }
            }
        }

        private static void ImprimeContactosComRelacionamentoOOShape()
        {
            using (var contexto = new DataContext(ConnectionString))
            {
                contexto.Log = Console.Out;
                var shape = new DataLoadOptions();
                shape.LoadWith<Estudante>(e => e.Contactos);
                contexto.LoadOptions = shape;

                var tabelaEstudantes = contexto.GetTable<Estudante>();
                var info = from est in tabelaEstudantes
                           select est;
                foreach (var res in info)
                {
                    Console.WriteLine(res.Nome);
                    foreach (var ct in res.Contactos)
                    {
                        Console.WriteLine("\t{0}", ct.Valor);
                    }
                }
            }
        }

        private static void ImprimeContactosComRelacionamentoOOShapeAssociate()
        {
            using (var contexto = new DataContext(ConnectionString))
            {
                contexto.Log = Console.Out;
                var shape = new DataLoadOptions();
                shape.AssociateWith<Estudante>(e => e.Contactos.Where(c => c.TipoContacto == 0));
                contexto.LoadOptions = shape;

                var tabelaEstudantes = contexto.GetTable<Estudante>();
                var info = from est in tabelaEstudantes
                           select est;
                foreach (var res in info)
                {
                    Console.WriteLine(res.Nome);
                    foreach (var ct in res.Contactos)
                    {
                        Console.WriteLine("\t{0}", ct.Valor);
                    }
                }
            }
        }

        private static void CarregaDisciplinasDoEstudanteLuis()
        {
            using (var contexto = new DataContext(ConnectionString))
            {
                contexto.Log = Console.Out;
                var tabelaEstudantes = contexto.GetTable<Estudante>();
                var estudante = from est in tabelaEstudantes
                                where est.Nome.Contains("Luis")
                                select est;
                var disciplinasLuis = estudante.First().Disciplinas;
                foreach (var disc in disciplinasLuis)
                {
                    Console.WriteLine(disc.Designacao);
                }
            }
        }

        private static void CarregaTelefones()
        {
            using (var contexto = new DataContext(ConnectionString))
            {
                contexto.Log = Console.Out;
                var tabelaEstudantes = contexto.GetTable<Estudante>();
                var telefones = from est in tabelaEstudantes
                                from cont in est.Contactos
                                where cont is Telefone
                                select new {est.Nome, cont.Valor};
                foreach (var tel in telefones)
                {
                    Console.WriteLine("{0} - {1}", tel.Nome, tel.Valor);
                }
            }
        }

        private static void UsaSp()
        {
            using (var contexto = new CustomContext(ConnectionString))
            {
                contexto.Log = Console.Out;
                var contactos = contexto.ObtemContactosEstudantes();
                foreach (var c in contactos)
                {
                    Console.WriteLine("{0} - {1}", c.Nome, c.Contacto);
                }
            }
        }

        private static void UsaSpComID()
        {
            using (var contexto = new CustomContext(ConnectionString))
            {
                contexto.Log = Console.Out;
                var contactos = contexto.ObtemContactosDoEstudante(1);
                foreach (var c in contactos)
                {
                    Console.WriteLine("{0} - {1}", c.Nome, c.Contacto);
                }
            }
        }

        private static void Compiled()
        {
            using (var context = new DataContext(ConnectionString))
            {
                context.Log = Console.Out;
                var tabelaEstudantes = context.GetTable<Estudante>();
                var compiled = CompiledQuery.Compile(
                    (DataContext ctx) => (from est in tabelaEstudantes select est));

                var results = compiled(context);
                foreach (var est in results)
                {
                    Console.WriteLine(est.Nome);
                }
            }
        }

        private static void CriaNovaDisciplina()
        {
            using (var context = new DataContext(ConnectionString))
            {
                context.Log = Console.Out;
                var tabelaDisciplinas = context.GetTable<Disciplina>();
                var novaDisciplina = new Disciplina {Designacao = "História"};
                tabelaDisciplinas.InsertOnSubmit(novaDisciplina);
                context.SubmitChanges();
            }
        }

        private static void AdicionaContacto()
        {
            using (var context = new DataContext(ConnectionString))
            {
                context.Log = Console.Out;
                var tabelaEstudantes = context.GetTable<Estudante>();
                var options = new DataLoadOptions();
                options.LoadWith<Estudante>(e => e.Contactos);
                context.LoadOptions = options;
                var contacto = new Telefone {Valor = "123111111"};
                var estudante = tabelaEstudantes.Where(e => e.Nome.Contains("Luis")).First();
                contacto.IdEstudante = estudante.IdEstudante;
                estudante.Contactos.Add(contacto);
                context.SubmitChanges();
            }
        }

        private static void ModificaNome()
        {
            Estudante estudante;

            using (var contextoLeitura = new DataContext(ConnectionString))
            {
                contextoLeitura.Log = Console.Out;
                var tabelaEstudantes = contextoLeitura.GetTable<Estudante>();
                estudante = tabelaEstudantes.Where(e => e.IdEstudante == 1).First();
            }
            estudante.Detach();
            estudante.Nome = "Luis Abreu";
            using (var contextoGravacao = new DataContext(ConnectionString))
            {
                contextoGravacao.Log = Console.Out;
                contextoGravacao.GetTable<Estudante>().Attach(estudante, true);
                contextoGravacao.SubmitChanges();
            }
        }


        private static void ModificaContacto()
        {
            using (var contexto = new DataContext(ConnectionString))
            {
                contexto.Log = Console.Out;
                var tabelaContactos = contexto.GetTable<Contacto>();
                var contacto = tabelaContactos.First();
                contacto.Valor = "999881888";
                contexto.Log = Console.Out;
                contexto.SubmitChanges();
            }
        }

        private static void EliminaContacto()
        {
            using (var contexto = new DataContext(ConnectionString))
            {
                contexto.Log = Console.Out;
                var tabelaContactos = contexto.GetTable<Contacto>();
                var contacto = tabelaContactos.First();
                tabelaContactos.DeleteOnSubmit(contacto);
                contexto.SubmitChanges();
            }
        }

        private static void EliminaMoradaDeAluno()
        {
            //transaction scope para fazer rollback...
            using (var scope = new TransactionScope())
            {
                using (var contexto = new DataContext(ConnectionString))
                {
                    contexto.Log = Console.Out;
                    var options = new DataLoadOptions();
                    options.LoadWith<Estudante>(e => e.Morada);
                    var tabelaEstudantes = contexto.GetTable<Estudante>();
                    var estudante = tabelaEstudantes.First();
                    estudante.Morada.Estudante = null;
                    contexto.SubmitChanges();
                }
            }
        }
     

        private static void EliminaMoradaDeAlunoComTransaccao()
        {
            using (var scope = new TransactionScope())
            {
                using (var contexto = new DataContext(ConnectionString))
                {
                    contexto.Log = Console.Out;
                    var moradas = contexto.GetTable<Morada>();
                    var morada = moradas.First();
                    moradas.DeleteOnSubmit(morada);
                    contexto.SubmitChanges();
                    foreach (var e in moradas)
                    {
                        Console.WriteLine(e.IdEstudante);
                    }
                }
            }
            Console.WriteLine("-----");
            using (var contexto = new DataContext(ConnectionString))
            {
                contexto.Log = Console.Out;
                var moradas = contexto.GetTable<Morada>();
                foreach (var e in moradas)
                {
                    Console.WriteLine(e.IdEstudante);
                }
            }
        }

        private static void Main(string[] args)
        {
            Console.Title = "LINQ Com C# - Capítulo 12";

            //EliminaMoradaDeAlunoComTransaccao();
            ImprimeTodasAsDisciplinas();
            ImprimeAlunosEMoradas();
            ImprimeAlunosEDisciplinas();
            ImprimeMoradaComRelacionamentoOO();
            ImprimeContactosComRelacionamentoOO();
            ImprimeContactosComRelacionamentoOOShape();
            ImprimeContactosComRelacionamentoOOShapeAssociate();
            CarregaDisciplinasDoEstudanteLuis();
            CarregaTelefones();
            UsaSpComID();
            Compiled();
            CriaNovaDisciplina();
            AdicionaContacto();
            ModificaNome();
            ModificaContacto();

            EliminaContacto();

            EliminaMoradaDeAluno();
            ImprimeMoradaComRelacionamentoOO();

        }


        /*
         static void Main(string[] args)
        {
            //string connectionString = Settings.Default.File3;
            string connectionString = @"data source=.\sqlexpress2008;initial catalog=dummy; user id=sa; password=sqladmin";

            try
            {
                if ((args != null) && (args.Length > 0))
                {
                    connectionString = args[0];
                    connectionString = Settings.Default[connectionString] as string;
                }

                using (TurmasDataContext dc = new TurmasDataContext(connectionString))
                {
                    dc.Log = Console.Out;

                    if (dc.DatabaseExists())
                    {
                        dc.DeleteDatabase();
                    }

                    dc.CreateDatabase();

                    // Disciplinas
                    Disciplina portugues = new Disciplina
                        {
                            Nome = "Portugues",
                            Descricao = "Disciplina que apresenta fundamentos de Portugues"
                        };
                    dc.Disciplinas.InsertOnSubmit(portugues);

                    Disciplina ingles = new Disciplina
                        {
                            Nome = "Ingles",
                            Descricao = "Disciplina que apresenta fundamentos de Ingles"
                        };
                    dc.Disciplinas.InsertOnSubmit(ingles);

                    Disciplina informatica = new Disciplina
                        {
                            Nome = "Informatica",
                            Descricao = "Disciplina de informatica"
                        };
                    dc.Disciplinas.InsertOnSubmit(informatica);

                    Disciplina matematica = new Disciplina
                        {
                            Nome = "Matematica",
                            Descricao = "Apresenta fundamentos matematica"
                        };
                    dc.Disciplinas.InsertOnSubmit(matematica);

                    //Estudantes

                    Estudante luis = new Estudante
                        {
                            Nome = "Luis",
                            Morada = new Morada
                            {
                                CodigoPostal = "9100 - Funchal",
                                Rua = "Rua Sao Pedro"
                            },
                            Contactos = new EntitySet<Contacto> 
                            {
                                new Email
                                {
                                    Valor = "luis@livrolinq.pt" 
                                } 
                            }
                        };
                    dc.Estudantes.InsertOnSubmit(luis);

                    Estudante paulo = new Estudante
                        {
                            Nome = "Paulo",
                            Morada = new Morada
                            {
                                CodigoPostal = "1100 - Lisboa",
                                Rua = "Rua do Rossio"
                            },
                            Contactos = new EntitySet<Contacto>
                            {
                                new Email
                                {
                                    Valor = "paulo@livrolinq.pt"
                                },
                                new Telefone
                                {
                                    Valor = "123123123"
                                }
                            }
                        };
                    dc.Estudantes.InsertOnSubmit(paulo);

                    Estudante joana = new Estudante
                        {
                            Nome = "Joana",
                            Morada = new Morada
                            {
                                CodigoPostal = "1100 - Lisboa",
                                Rua = "Rua do Rossio"
                            },
                            Contactos = new EntitySet<Contacto>
                            {
                                new Email
                                {
                                    Valor = "joana@livrolinq.pt"
                                }
                            }
                        };
                    dc.Estudantes.InsertOnSubmit(joana);

                    Estudante paula = new Estudante
                        {
                            Nome = "Paula",
                            Morada = new Morada
                            {
                                CodigoPostal = "1100 - Lisboa",
                                Rua = "Rua do Rossio"
                            },
                            Contactos = new EntitySet<Contacto>
                            {
                                new Email
                                {
                                    Valor = "paula@livrolinq.pt"
                                },
                                new Telefone
                                {
                                    Valor = "121212121"
                                }
                            }
                        };
                    dc.Estudantes.InsertOnSubmit(paula);

                    Estudante rita = new Estudante
                        {
                            Nome = "Rita",
                            Morada = new Morada
                            {
                                CodigoPostal = "1100 - Lisboa",
                                Rua = "Rua do Rossio"
                            },
                            Contactos = new EntitySet<Contacto>
                            {
                                new Email
                                { 
                                    Valor = "rita@livrolinq.pt"
                                }
                            }
                        };
                    dc.Estudantes.InsertOnSubmit(rita);

                    Estudante luisa = new Estudante
                        {
                            Nome = "Luisa",
                            Morada = new Morada
                            {
                                CodigoPostal = "4100 - Porto",
                                Rua = "Rua da Ribeira"
                            }
                        };
                    dc.Estudantes.InsertOnSubmit(luisa);

                    // Turmas
                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = luis, Disciplina = portugues });
                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = luis, Disciplina = ingles });
                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = luis, Disciplina = informatica });

                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = paulo, Disciplina = portugues });
                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = paulo, Disciplina = matematica });
                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = paulo, Disciplina = informatica });

                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = joana, Disciplina = ingles });
                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = joana, Disciplina = matematica });
                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = joana, Disciplina = informatica });

                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = paula, Disciplina = portugues });
                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = paula, Disciplina = matematica });
                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = paula, Disciplina = informatica });

                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = rita, Disciplina = portugues });
                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = rita, Disciplina = matematica });
                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = rita, Disciplina = informatica });

                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = luisa, Disciplina = portugues });
                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = luisa, Disciplina = matematica });
                    dc.EstudanteDisciplinas.InsertOnSubmit(new EstudanteDisciplina { Estudante = luisa, Disciplina = informatica });

                    dc.SubmitChanges();
                }

                using (TurmasDataContext dc = new TurmasDataContext(connectionString))
                {
                    dc.Log = Console.Out;

                    var loadOptions = new DataLoadOptions();
                    loadOptions.LoadWith<Estudante>(e => e.Morada);
                    loadOptions.LoadWith<Estudante>(e => e.Contactos);
                    loadOptions.LoadWith<Estudante>(e => e.Disciplinas);
                    //loadOptions.AssociateWith<Estudante>(e => e.Disciplinas.Where(ed => ed.Disciplina.Nome == ed.NomeDisciplina));
                    loadOptions.LoadWith<Disciplina>(d => d.Estudantes);
                    dc.LoadOptions = loadOptions;

                    Console.WriteLine("==========");
                    Console.WriteLine("Estudantes");
                    Console.WriteLine();
                    Console.WriteLine("----------");

                    var estudantes = from estudante in dc.Estudantes
                                     select estudante;

                    foreach (var estudante in estudantes)
                    {
                        Console.WriteLine();
                        Console.WriteLine("       Nome: {0}", estudante.Nome);

                        Console.WriteLine("     Morada:");
                        Console.WriteLine("                       Rua: {0}", estudante.Morada.Rua);
                        Console.WriteLine("             Código Postal: {0}", estudante.Morada.CodigoPostal);

                        Console.WriteLine("  Contactos:");
                        foreach (var contacto in estudante.Contactos)
                        {
                            switch (contacto.Tipo)
                            {
                                case 0:
                                    Console.Write("              Telefone: ");
                                    break;
                                case 1:
                                    Console.Write("                e-mail: ");
                                    break;
                                default:
                                    Console.Write("             ?????????: ");
                                    break;
                            }
                            Console.WriteLine(contacto.Valor);
                        }

                        Console.WriteLine("Disciplinas:");
                        foreach (var disciplina in estudante.Disciplinas)
                        {
                            Console.WriteLine("             {0,11}: {1}", disciplina.Disciplina.Nome, disciplina.Disciplina.Descricao);
                        }

                        Console.WriteLine("----------");
                    }

                    Console.WriteLine("==========");
                    Console.WriteLine("Disciplinas");
                    Console.WriteLine();
                    Console.WriteLine("----------");

                    var disciplinas = from disciplina in dc.Disciplinas
                                      select disciplina;

                    foreach (var disciplina in disciplinas)
                    {
                        Console.WriteLine();
                        Console.WriteLine("       Nome: {0}", disciplina.Nome);
                        Console.WriteLine("  Descricao: {0}", disciplina.Descricao);

                        Console.WriteLine(" Estudantes:");
                        foreach (var estudante in disciplina.Estudantes)
                        {
                            Console.WriteLine("             {0,6}: {1}", estudante.Estudante.Nome, estudante.Estudante.Morada.CodigoPostal);
                        }

                        Console.WriteLine("----------");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Write("Message: ");
                Console.WriteLine(ex.Message);

                Console.Write("Line Number: ");
                Console.WriteLine(ex.LineNumber);

                Console.Write("Error Code: 0x");
                Console.WriteLine(ex.ErrorCode.ToString("X8"));

                Console.Write("Error Number: ");
                Console.WriteLine(ex.Number);

                Console.Write("Severity Level: ");
                Console.WriteLine(ex.Class);

                Console.Write("Errors: ");
                Console.WriteLine(ex.Errors);

                Console.Write("Procedure: ");
                Console.WriteLine(ex.Procedure);

                Console.Write("Server: ");
                Console.WriteLine(ex.Server);

                Console.Write("Source: ");
                Console.WriteLine(ex.Source);

                Console.Write("State: ");
                Console.WriteLine(ex.State);

                Console.Write("Connection String: ");
                Console.WriteLine(connectionString);

                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }*/
    }
}