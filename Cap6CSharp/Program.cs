using System;

namespace Cap6CSharp 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            InicializacaoPreCSharp3();

            InicializacaoPosCSharp3();

            InicializacaoPosCSharp3CasoEspecial();
        }

        private static void InicializacaoPosCSharp3CasoEspecial()
        {
            //consultar livro para perceber porque 
            //propriedade Contacto tem de ser de leitura/escrita
            //e pq e necessario criar contacto
            var aluno = new AlunoComContacto
            {
                Nome = "Luis",
                Morada = "Morada",
                Contacto = new Contacto{ Telefone = "123123123", Telemovel = "123123122" }
            }; 
            ImprimeAluno( aluno );
            
            var contacto = aluno.Contacto;
            Console.WriteLine("Telefone: {0} --- Telemovel: {1}",contacto.Telemovel, contacto.Telemovel);
        }

        private static void InicializacaoPosCSharp3()
        {
            var aluno = new Aluno { Nome = "Luis", Morada = "Fx" };
            ImprimeAluno(aluno);
        }

        private static void InicializacaoPreCSharp3()
        {
            var aluno = new Aluno();
            aluno.Nome = "Luis";
            aluno.Morada = "Fx";
            ImprimeAluno(aluno);
        }

        private static void ImprimeAluno(Aluno aluno)
        {
            Console.WriteLine("Nome: {0} --- Morada: {1}", aluno.Nome, aluno.Morada);
        }
    }
}
