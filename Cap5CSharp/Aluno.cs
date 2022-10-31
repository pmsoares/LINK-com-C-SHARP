using System;

namespace Cap5CSharp 
{
    public class Aluno 
    {
        public Aluno(string nome, string morada, int idade)
        {
            Nome = nome;
            Morada = morada;
            Idade = idade;
        }

        public String Nome { get; set; }
        public String Morada { get; set; }
        public Int32 Idade { get; set; }

        public override string ToString() {
            return string.Concat(Nome, "-", Morada, "-", Idade);
        }
    }
}
