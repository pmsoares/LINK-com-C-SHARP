Imports System.Xml.XPath

Module Module1
  Private Sub PrintBasicXml()
    Dim xml = <Turmas>
                <Turma>
                  <Id>2</Id>
                  <Designacao>Turma1</Designacao>
                  <Alunos>
                    <Aluno>
                      <Nome>Luis</Nome>
                      <Morada>
                        <CodigoPostal>9100-Funchal</CodigoPostal>
                        <Rua>Rua São Pedro</Rua>
                      </Morada>
                    </Aluno>
                    <Aluno>
                      <Nome>Joana</Nome>
                      <Morada>
                        <CodigoPostal>1100-Lisboa</CodigoPostal>
                        <Rua>Rua do Rossio</Rua>
                      </Morada>
                    </Aluno>
                    <Aluno>
                      <Nome>Rita</Nome>
                      <Morada>
                        <CodigoPostal>1100-Lisboa</CodigoPostal>
                        <Rua>Rua do Rossio</Rua>
                      </Morada>
                    </Aluno>
                  </Alunos>
                </Turma>
              </Turmas>

    Console.WriteLine(xml)
  End Sub

  Private Sub PrintBasicXmlComNamespace()
    Dim xml = <Turmas xmlns="http://LivroCSharp.pt">
                <Turma>
                  <Id>2</Id>
                  <Designacao>Turma1</Designacao>
                  <Alunos xmlns="">
                    <Aluno>
                      <Nome>Luis</Nome>
                      <Morada>
                        <CodigoPostal>9100-Funchal</CodigoPostal>
                        <Rua>Rua São Pedro</Rua>
                      </Morada>
                    </Aluno>
                    <Aluno xmlns="">
                      <Nome>Joana</Nome>
                      <Morada>
                        <CodigoPostal>1100-Lisboa</CodigoPostal>
                        <Rua>Rua do Rossio</Rua>
                      </Morada>
                    </Aluno>
                    <Aluno xmlns="">
                      <Nome>Rita</Nome>
                      <Morada>
                        <CodigoPostal>1100-Lisboa</CodigoPostal>
                        <Rua>Rua do Rossio</Rua>
                      </Morada>
                    </Aluno>
                  </Alunos>
                </Turma>
              </Turmas>


    Console.WriteLine(xml)
  End Sub

  Sub PrintBasicXmlComNamespaceWithXmlns()
    Dim xml = <l:Turmas xmlns:l="http://LivroCSharp.pt">
                <Turma>
                  <Id>2</Id>
                  <Designacao>Turma1</Designacao>
                  <Alunos xmlns="">
                    <Aluno>
                      <Nome>Luis</Nome>
                      <Morada>
                        <CodigoPostal>9100-Funchal</CodigoPostal>
                        <Rua>Rua São Pedro</Rua>
                      </Morada>
                    </Aluno>
                    <Aluno xmlns="">
                      <Nome>Joana</Nome>
                      <Morada>
                        <CodigoPostal>1100-Lisboa</CodigoPostal>
                        <Rua>Rua do Rossio</Rua>
                      </Morada>
                    </Aluno>
                    <Aluno xmlns="">
                      <Nome>Rita</Nome>
                      <Morada>
                        <CodigoPostal>1100-Lisboa</CodigoPostal>
                        <Rua>Rua do Rossio</Rua>
                      </Morada>
                    </Aluno>
                  </Alunos>
                </Turma>
              </l:Turmas>

    Console.WriteLine(xml)
  End Sub

  Sub PrintBasicXmlComNamespaceWithXmlnsAndAttribute()
    Dim xml = <l:Turmas xmlns:l="http://LivroCSharp.pt" l:data=<%= DateTime.Now %>>
                <Turma>
                  <Id>1</Id>
                  <Designacao>Turma1</Designacao>
                </Turma>
              </l:Turmas>


    Console.WriteLine(xml)
  End Sub

  Sub CriaDocumento()
    Dim xml As New XDocument(New XProcessingInstruction( _
                                          "xml-stylesheet", _
                                          "type=""text/xsl"" href=""folhaEstilho.xsl"""), _
                              <Turmas/>)


    Console.WriteLine(xml)
  End Sub


  Sub CarregaXml()
    Dim xml As XElement = XElement.Load("Turmas.xml")
    Console.WriteLine(xml)
  End Sub

  Sub AddNewElement()
    Dim xml = <l:Turmas xmlns:l="http://LivroCSharp.pt" l:data=<%= DateTime.Now %>>
                <Turma>
                  <Id>1</Id>
                  <Designacao>Turma1</Designacao>
                </Turma>
              </l:Turmas>
         

    Dim node = <innerNode>Hello</innerNode>
    xml.Add(node)
    Console.WriteLine(xml)
  End Sub

  Sub ModificaElemento()
    Dim xml = <l:Turmas xmlns:l="http://LivroCSharp.pt" l:data=<%= DateTime.Now %>>
                <Turma>
                  <Id>1</Id>
                  <Designacao>Turma1</Designacao>
                </Turma>
              </l:Turmas>

    Dim ns As XNamespace = "http://LivroCSharp.pt"
    xml.SetAttributeValue(ns + "data", DateTime.Now.AddDays(1))
    Console.WriteLine(xml)
  End Sub

  Sub SubstituiElemento()
    Dim xml = <l:Turmas xmlns:l="http://LivroCSharp.pt" l:data=<%= DateTime.Now %>>
                <Turma>
                  <Id>1</Id>
                  <Designacao>Turma1</Designacao>
                </Turma>
              </l:Turmas>

    Dim novaTurma = <Turma>
                      <Id>2</Id>
                      <Designacao>Turma2</Designacao>
                    </Turma>

    xml.ReplaceNodes(novaTurma)
    Console.WriteLine(xml)
  End Sub
  Sub SubstituiProprioElemento()
    'semelhante ao anterior, mas neste caso substituimos o proprio no
    'em vez do conteudo do no
    Dim xml = <l:Turmas xmlns:l="http://LivroCSharp.pt" l:data=<%= DateTime.Now %>>
                <Turma>
                  <Id>1</Id>
                  <Designacao>Turma1</Designacao>
                </Turma>
              </l:Turmas>
    Dim novaTurma = <Turma>
                      <Id>2</Id>
                      <Designacao>Turma2</Designacao>
                    </Turma>


    xml.Element("Turma").ReplaceWith(novaTurma)

    Console.WriteLine(xml)
  End Sub
  Sub FiltrarDocumentoXml()
    Dim xml = <l:Turmas xmlns:l="http://LivroCSharp.pt">
                <Turma>
                  <Id>2</Id>
                  <Designacao>Turma1</Designacao>
                  <Alunos xmlns="">
                    <Aluno>
                      <Nome>Luis</Nome>
                      <Morada>
                        <CodigoPostal>9100-Funchal</CodigoPostal>
                        <Rua>Rua São Pedro</Rua>
                      </Morada>
                    </Aluno>
                    <Aluno xmlns="">
                      <Nome>Joana</Nome>
                      <Morada>
                        <CodigoPostal>1100-Lisboa</CodigoPostal>
                        <Rua>Rua do Rossio</Rua>
                      </Morada>
                    </Aluno>
                    <Aluno xmlns="">
                      <Nome>Rita</Nome>
                      <Morada>
                        <CodigoPostal>1100-Lisboa</CodigoPostal>
                        <Rua>Rua do Rossio</Rua>
                      </Morada>
                    </Aluno>
                  </Alunos>
                </Turma>
              </l:Turmas>
           

    Dim alunos = xml.XPathSelectElements("//Aluno")
    For Each aluno In alunos
      Console.WriteLine(aluno)
    Next

  End Sub
  Sub DemonstraLINQ()
    Dim xml = <l:Turmas xmlns:l="http://LivroCSharp.pt">
                <Turma>
                  <Id>2</Id>
                  <Designacao>Turma1</Designacao>
                  <Alunos xmlns="">
                    <Aluno>
                      <Nome>Luis</Nome>
                      <Morada>
                        <CodigoPostal>9100-Funchal</CodigoPostal>
                        <Rua>Rua São Pedro</Rua>
                      </Morada>
                    </Aluno>
                    <Aluno xmlns="">
                      <Nome>Joana</Nome>
                      <Morada>
                        <CodigoPostal>1100-Lisboa</CodigoPostal>
                        <Rua>Rua do Rossio</Rua>
                      </Morada>
                    </Aluno>
                    <Aluno xmlns="">
                      <Nome>Rita</Nome>
                      <Morada>
                        <CodigoPostal>1100-Lisboa</CodigoPostal>
                        <Rua>Rua do Rossio</Rua>
                      </Morada>
                    </Aluno>
                  </Alunos>
                </Turma>
              </l:Turmas>

    Dim novoDoc = <Alunos>
                    <%= From aluno In xml.Descendants("Aluno") _
                      Select New XElement("AlunoDaTurma", aluno.Element("Nome").Value) _
                    %>
                  </Alunos>

    Console.WriteLine(novoDoc)



    Dim listaAlunos = From aluno In xml.XPathSelectElements("//Aluno") _
                              Select New With _
                                         { _
                                             .Nome = CType(aluno.Element("Nome"), String), _
                                             .Morada = String.Concat(CType(aluno.Element("Morada").Element("Rua"), String), "-", CType(aluno.Element("Morada").Element("CodigoPostal"), String)) _
                                         }
    For Each aluno In listaAlunos
      Console.WriteLine("{0} : {1}", aluno.Nome, aluno.Morada)
    Next

  End Sub

  Sub Main()
    PrintBasicXml()
    PrintBasicXmlComNamespace()
    PrintBasicXmlComNamespaceWithXmlns()
    PrintBasicXmlComNamespaceWithXmlnsAndAttribute()
    CriaDocumento()
    CarregaXml()
    AddNewElement()
    ModificaElemento()
    SubstituiElemento()
    SubstituiProprioElemento()
    FiltrarDocumentoXml()
    DemonstraLINQ()
  End Sub

End Module
