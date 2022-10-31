using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Cap1CSharp 
{
    class Program 
    {

        static void Main(string[] args) 
        {
            Console.WriteLine("Lista processos sem LINQ:");
            var processosAntesLINQ = new ProcessosAntesLINQ().ImprimeProcessos();
            ImprimeProcessosDaLista(processosAntesLINQ);
            Console.WriteLine("Lista processos com LINQ:");
            var processosPosLINQ = new ProcessosPosLINQ().ImprimeProcessos();
            ImprimeProcessosDaLista(processosPosLINQ);
        }

        private static void ImprimeProcessosDaLista(IEnumerable<Process> processosAntesLINQ)
        {
            foreach (var processo in processosAntesLINQ)
            {
                Console.WriteLine(processo.ProcessName);
            }
        }
    }
}
