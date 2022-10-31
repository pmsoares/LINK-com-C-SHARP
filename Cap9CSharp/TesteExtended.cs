using System;

namespace Cap9CSharp
{
    public static class TesteExtended
    {
        public static void Imprime( this Teste instancia, int valor )
        {
            Console.WriteLine( "Extendido: {0}", valor );
        }
    }
}