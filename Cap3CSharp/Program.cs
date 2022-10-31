using System;

namespace Cap3CSharp 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            var pilhaSemBlocoIteracao = new Pilha<int>();
            pilhaSemBlocoIteracao.Push(1);
            pilhaSemBlocoIteracao.Push(2);
            pilhaSemBlocoIteracao.Push(3);

            foreach (int numero in pilhaSemBlocoIteracao) {
                Console.WriteLine(numero);
            }

            var pilhaComBlocoIteracao = new PilhaComBlocosIteracao<int>();
            pilhaComBlocoIteracao.Push(1);
            pilhaComBlocoIteracao.Push(2);
            pilhaComBlocoIteracao.Push(3);
        
            foreach (int numero in pilhaComBlocoIteracao)
            {
                Console.WriteLine(numero);
            }
        }
    }
}
