using System;

namespace Cap8CSharp
{
    internal class Program
    {
        private static void Main( string[] args )
        {
            var obj = new
                          {
                                  Nome = "Luis",
                                  Morada = "Funchal"
                          };
            Console.WriteLine( "{0} - {1}", obj.Nome, obj.Morada );
            Console.WriteLine( obj.GetType() );
        }
    }
}