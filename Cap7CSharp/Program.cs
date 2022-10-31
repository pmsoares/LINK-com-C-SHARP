using System;

namespace Cap7CSharp
{
    internal class Program
    {
        private static void Main( string[] args )
        {
            var aluno = new Aluno
                            {
                                    Nome = "Luis",
                                    Morada = "Funchal"
                            };
            Console.WriteLine( "Nome: {0} --- Morada: {1}", aluno.Nome, aluno.Morada );
        }
    }
}