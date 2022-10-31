using System;
using System.Linq;

namespace LinqComCSharp.Capitulo13
{
    internal class Program
    {
        private static bool NumeroEPar(int n)
        {
            double d = 1;
            for (int i = 0; i < 100; i++)
            {
                d *= i;
            }

            if (n%2 == 0)
            {
                return true;
            }
            return false;
        }

        private static void Figura_13_04()
        {
            var pares = from n in Enumerable.Range(0, 1000000).AsParallel()
                        where NumeroEPar(n)
                        select n;

            foreach (var n in pares)
            {
                Console.WriteLine(n);
            }
        }

        private static void Figura_13_05()
        {
            var pares = from n in Enumerable.Range(0, 1000000).AsParallel().AsOrdered()
                        where NumeroEPar(n)
                        select n;

            foreach (var n in pares)
            {
                Console.WriteLine(n);
            }
        }

        private static void Main(string[] args)
        {
            Console.Title = "LINQ Com C# - Capítulo 13";

            Console.ReadLine();

            Console.Clear();

            Figura_13_04();

            Console.ReadLine();

            Console.Clear();

            Figura_13_05();

            Console.ReadLine();
        }
    }
}