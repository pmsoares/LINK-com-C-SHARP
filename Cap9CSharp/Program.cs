using System;

namespace Cap9CSharp
{
    internal class Program
    {
        private static void Main( string[] args )
        {
            Console.WriteLine("Teste simples de método extensão");
            var myStr = "Luis";
            Console.WriteLine( myStr.IsEmptyAfterTrim() );

            Console.WriteLine( "Teste com overloads" );
            var myTeste = new Teste();
            int valor = 10; // poderiamos ter usado var,
            // mas usamos int para que não restem dúvidas
            myTeste.Imprime(valor);
        }
    }
}