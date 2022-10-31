using System;

namespace Cap4CSharp 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            UsaImpressoraMensagens();

            UsaMetodoAnonimo();

            UsaMetodoAnonimo2();

            UsaExpressoesLambda();

            TestaArvoreExpressoes();
        }

        private static void TestaArvoreExpressoes()
        {
            new TesteExpressoes().TestaExpressao();
        }

        private static void UsaExpressoesLambda()
        {
            Console.WriteLine("Utilização expressões Lambda");
            int i = 0;
            AvisaUtilizador metodo = msg => Console.WriteLine(msg);
            do 
            {
                string aux = Console.ReadLine();
                if (int.TryParse(aux, out i)) 
                {
                    metodo(aux);
                }
            } 
            while (i > 0);
        }

        private static void UsaMetodoAnonimo2()
        {
            Console.WriteLine("Utilização método anónimo C# 2.0: utilização variável externa");
            int i = 0;
            AvisaUtilizador metodo = delegate { Console.WriteLine(i); };
            do 
            {
                string aux = Console.ReadLine();
                if (int.TryParse(aux, out i)) 
                {
                    metodo(aux);
                }
            } 
            while (i > 0);
        }

        private static void UsaMetodoAnonimo()
        {
            Console.WriteLine("Utilização método anónimo C# 2.0");
            int i = 0;
            AvisaUtilizador metodo = delegate(string msg) { 
                                        Console.WriteLine(msg); 
                                     };
            do 
            {
                string aux = Console.ReadLine();
                if (int.TryParse(aux, out i)) 
                {
                    metodo(aux);
                }
            } 
            while (i > 0);
        }

        private static void UsaImpressoraMensagens()
        {
            Console.WriteLine("Utilização classe Impressora Mensagens");
            int i = 0;
            var impressora = new ImpressoraMensagens();
            AvisaUtilizador metodo = impressora.MostraMensagem;
            do 
            {
                string aux = Console.ReadLine();
                if (int.TryParse(aux, out i)) 
                {
                    metodo(aux);
                }
            } 
            while (i > 0);
        }
    }
}
