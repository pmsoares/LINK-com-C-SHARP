using System;

namespace Cap2CSharp {
    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("Pilha  C# 1.0");
            var pilha = new PilhaInteiros();
            pilha.Push(1);
            pilha.Push(2);
            pilha.Push(3);
            while (pilha.TotalElementos != 0)
            {
                Console.WriteLine(pilha.Pop());
            }

            Console.WriteLine("Pilha genérica C# 1.0");
            var pilhaGenerica = new PilhaGenéricaCSharp1();
            pilhaGenerica.Push(1);
            pilhaGenerica.Push(2);
            pilhaGenerica.Push(3);
            while (pilhaGenerica.TotalElementos != 0) 
            {
                Console.WriteLine((int)pilhaGenerica.Pop());
            }
            
            Console.WriteLine("Pilha genérica C# 2.0");
            var pilhaGenericaCSharp2 = new Pilha<int>();
            pilhaGenericaCSharp2.Push(1);
            pilhaGenericaCSharp2.Push(2);
            pilhaGenericaCSharp2.Push(3);
            while (pilhaGenericaCSharp2.TotalElementos != 0) 
            {
                Console.WriteLine(pilhaGenericaCSharp2.Pop());
            }
        }
    }
}
