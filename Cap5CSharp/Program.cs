using System;

namespace Cap5CSharp 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            var i = 10;
            Console.WriteLine("i: {0} -- type:{1}", i, i.GetType().Name);
            var aluno = new Aluno("José", "Funchal", 20);
            Console.WriteLine("aluno: {0} -- type:{1}", aluno, aluno.GetType().Name);

            var a1 = new[] { 1, 2 };
            foreach (var a in a1)
            {
                Console.WriteLine(a);
            }

            var a2 = new[,] { { "Luis", "Paulo" }, { "João", "Marco" } };
            foreach (var a in a2) 
            {
                Console.WriteLine(a);
            }

        }
    }
}
