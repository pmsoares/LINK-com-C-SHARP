using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

namespace LINQToXML
{
    class Program
    {
        static void PrintBasicXml()
        {
            var xml = new XElement("Turmas",
                    new XElement("Turma",
                        new XElement("Id", 1),
                        new XElement("Designacao", "Turma1"),
                        new XElement("Alunos",
                            new XElement("Aluno",
                                new XElement("Nome", "Luis"),
                                new XElement("Morada",
                                    new XElement("CodigoPostal", "9100 - Funchal"),
                                    new XElement("Rua", "Rua Sao Pedro")
                                    )
                                ),
                            
                            new XElement("Aluno",
                                new XElement("Nome", "Joana"),
                                new XElement("Morada",
                                    new XElement("CodigoPostal", "1100 - Lisboa"),
                                    new XElement("Rua", "Rua do Rossio")
                                    )
                                )
                            ),
                            new XElement("Aluno",
                                new XElement("Nome", "Rita"),
                                new XElement("Morada",
                                    new XElement("CodigoPostal", "1100 - Lisboa"),
                                    new XElement("Rua", "Rua do Rossio")
                                    )
                                )
                            )
                        );

           Console.WriteLine(xml);
                
        }

        static void PrintBasicXmlComNamespace()
        {
            XNamespace ns = "http://LivroCSharp.pt";
            var xml = new XElement(ns + "Turmas",
                    new XElement(ns + "Turma",
                        new XElement("Id", 1),
                        new XElement("Designacao", "Turma1"),
                        new XElement("Alunos",
                            new XElement("Aluno",
                                new XElement("Nome", "Luis"),
                                new XElement("Morada",
                                    new XElement("CodigoPostal", "9100 - Funchal"),
                                    new XElement("Rua", "Rua Sao Pedro")
                                    )
                                ),

                            new XElement("Aluno",
                                new XElement("Nome", "Joana"),
                                new XElement("Morada",
                                    new XElement("CodigoPostal", "1100 - Lisboa"),
                                    new XElement("Rua", "Rua do Rossio")
                                    )
                                )
                            ),
                            new XElement("Aluno",
                                new XElement("Nome", "Rita"),
                                new XElement("Morada",
                                    new XElement("CodigoPostal", "1100 - Lisboa"),
                                    new XElement("Rua", "Rua do Rossio")
                                    )
                                )
                            )
                        );

            
            Console.WriteLine(xml);
        }

        static void PrintBasicXmlComNamespaceWithXmlns()
        {
            XNamespace ns = "http://LivroCSharp.pt";
            var xml = new XElement(ns + "Turmas",
                    new XAttribute( XNamespace.Xmlns + "l",ns),
                    new XElement( "Turma",
                        new XElement("Id", 1),
                        new XElement("Designacao", "Turma1"),
                        new XElement("Alunos",
                            new XElement("Aluno",
                                new XElement("Nome", "Luis"),
                                new XElement("Morada",
                                    new XElement("CodigoPostal", "9100 - Funchal"),
                                    new XElement("Rua", "Rua Sao Pedro")
                                    )
                                ),

                            new XElement("Aluno",
                                new XElement("Nome", "Joana"),
                                new XElement("Morada",
                                    new XElement("CodigoPostal", "1100 - Lisboa"),
                                    new XElement("Rua", "Rua do Rossio")
                                    )
                                )
                            ),
                            new XElement("Aluno",
                                new XElement("Nome", "Rita"),
                                new XElement("Morada",
                                    new XElement("CodigoPostal", "1100 - Lisboa"),
                                    new XElement("Rua", "Rua do Rossio")
                                    )
                                )
                            )
                        );


            Console.WriteLine(xml);
        }

        static void PrintBasicXmlComNamespaceWithXmlnsAndAttribute()
        {
            XNamespace ns = "http://LivroCSharp.pt";
            var xml = new XElement(ns + "Turmas",
                    new XAttribute(XNamespace.Xmlns + "l", ns),
                    new XAttribute(ns+"data", DateTime.Now),
                    new XElement("Turma",
                        new XElement("Id", 1),
                        new XElement("Designacao", "Turma1")
                        )
                    );


            Console.WriteLine(xml);
        }

        static void CriaDocumento()
        {
            var xml = new XDocument(
                                       new XProcessingInstruction(
                                          "xml-stylesheet",
                                          "type=\"text/xsl\" href=\"folhaEstilho.xsl\""),
                                       new XElement("Turmas")
                                      );

           
            Console.WriteLine(xml);
        }

        static void CarregaXml()
        {
            var xml = XElement.Load("Turmas.xml");
            Console.WriteLine(xml);
        }

        static void AddNewElement()
        {
            XNamespace ns = "http://LivroCSharp.pt";
            var xml = new XElement(ns + "Turmas",
                    new XAttribute(XNamespace.Xmlns + "l", ns),
                    new XAttribute(ns + "data", DateTime.Now),
                    new XElement("Turma",
                        new XElement("Id", 1),
                        new XElement("Designacao", "Turma1")
                        )
                    );

            var node = new XElement("InnerNode", "Hello");
            xml.Add(node);
          
            Console.WriteLine(xml);
        }

        static void ModificaElemento()
        {
            XNamespace ns = "http://LivroCSharp.pt";
            var xml = new XElement(ns + "Turmas",
                    new XAttribute(XNamespace.Xmlns + "l", ns),
                    new XAttribute(ns + "data", DateTime.Now),
                    new XElement("Turma",
                        new XElement("Id", 1),
                        new XElement("Designacao", "Turma1")
                        )
                    );

            xml.SetAttributeValue(ns+"data", DateTime.Now.AddDays(1));
            Console.WriteLine(xml);
        }

        static void SubstituiElemento()
        {
            XNamespace ns = "http://LivroCSharp.pt";
            var xml = new XElement(ns + "Turmas",
                    new XAttribute(XNamespace.Xmlns + "l", ns),
                    new XAttribute(ns + "data", DateTime.Now),
                    new XElement("Turma",
                        new XElement("Id", 1),
                        new XElement("Designacao", "Turma1")
                        )
                    );
            var novaTurma = new XElement("Turma",
                                         new XElement("Id", 2),
                                         new XElement("Designacao", "Turma2")
                                );

           
            xml.ReplaceNodes(novaTurma);
            
            Console.WriteLine(xml);
        }

        static void SubstituiProprioElemento()
        {
            XNamespace ns = "http://LivroCSharp.pt";
            var xml = new XElement(ns + "Turmas",
                    new XAttribute(XNamespace.Xmlns + "l", ns),
                    new XAttribute(ns + "data", DateTime.Now),
                    new XElement("Turma",
                        new XElement("Id", 1),
                        new XElement("Designacao", "Turma1")
                        )
                    );
            var novaTurma = new XElement("Turma",
                                         new XElement("Id", 2),
                                         new XElement("Designacao", "Turma2")
                                );


            xml.Element("Turma").ReplaceWith(novaTurma);

            Console.WriteLine(xml);
        }
        static void FiltrarDocumentoXml()
        {
            XNamespace ns = "http://LivroCSharp.pt";
            var xml = new XElement(ns + "Turmas",
                    new XAttribute(XNamespace.Xmlns + "l", ns),
                    new XElement("Turma",
                        new XElement("Id", 1),
                        new XElement("Designacao", "Turma1"),
                        new XElement("Alunos",
                            new XElement("Aluno",
                                new XAttribute("Id", 1),
                                new XAttribute("Idade", 12),
                                new XElement("Nome", "Luis"),
                                new XElement("Morada",
                                    new XElement("CodigoPostal", "9100 - Funchal"),
                                    new XElement("Rua", "Rua Sao Pedro")
                                    )
                                ),

                            new XElement("Aluno",
                                new XAttribute("Id", 1),
                                new XElement("Nome", "Joana"),
                                new XElement("Morada",
                                    new XElement("CodigoPostal", "1100 - Lisboa"),
                                    new XElement("Rua", "Rua do Rossio")
                                    )
                                ),
                           
                            new XElement("Aluno",
                                new XAttribute("Id", 1),
                                new XElement("Nome", "Rita"),
                                new XElement("Morada",
                                    new XElement("CodigoPostal", "1100 - Lisboa"),
                                    new XElement("Rua", "Rua do Rossio")
                                    )
                                )
                            )
                        )
                    );
            
            var alunos = xml.XPathSelectElements("//Aluno");
            
            foreach(var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }
        }

        private static void DemonstraLINQ()
        {
            XNamespace ns = "http://LivroCSharp.pt";
            var xml = new XElement(ns + "Turmas",
                           new XAttribute(XNamespace.Xmlns + "l", ns),
                           new XElement("Turma",
                               new XElement("Id", 1),
                               new XElement("Designacao", "Turma1"),
                               new XElement("Alunos",
                                  new XElement("Aluno",
                                    new XElement("Nome", "Luis"),
                                    new XElement("Morada",
                                    new XElement("CodigoPostal", "9100 - Funchal"),
                                    new XElement("Rua", "Rua Sao Pedro")
                                    )
                                  ),
                                  new XElement("Aluno",
                                    new XElement("Nome", "Joana"),
                                    new XElement("Morada",
                                    new XElement("CodigoPostal", "1100 - Lisboa"),
                                    new XElement("Rua", "Rua do Rossio")
                                    )
                                 ),
                                 new XElement("Aluno",
                                    new XElement("Nome", "Rita"),
                                    new XElement("Morada",
                                    new XElement("CodigoPostal", "1100 - Lisboa"),
                                    new XElement("Rua", "Rua do Rossio")
                                   )
                                 )
                              )
                    )
            );

            var novoDoc = new XElement("Alunos",
                                       from aluno in xml.Descendants("Aluno")
                                       select new XElement("AlunoDaTurma", aluno.Element("Nome").Value)
                );

            Console.WriteLine(novoDoc);


            var listaAlunos = from aluno in xml.XPathSelectElements("//Aluno")
                              select new
                                         {
                                             Nome = (String) aluno.Element("Nome"),
                                             Morada = String.Concat(
                                                  (String) aluno.Element("Morada").Element("Rua"),
                                                  "-",
                                                  (String) aluno.Element("Morada").Element("CodigoPostal")
                                                  )
                                         };
            foreach(var aluno in listaAlunos)
            {
                Console.WriteLine("{0} : {1}", aluno.Nome, aluno.Morada);
            }

        }

        


        static void Main(string[] args)
        {
            PrintBasicXml();
            PrintBasicXmlComNamespace();
            PrintBasicXmlComNamespaceWithXmlns();
            PrintBasicXmlComNamespaceWithXmlnsAndAttribute();
            CriaDocumento();
            CarregaXml();
            AddNewElement();
            ModificaElemento();
            SubstituiElemento();
            SubstituiProprioElemento();
            FiltrarDocumentoXml();
            DemonstraLINQ();
        }
    }
}