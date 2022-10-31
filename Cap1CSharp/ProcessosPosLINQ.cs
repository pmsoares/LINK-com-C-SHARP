using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Cap1CSharp 
{
    public class ProcessosPosLINQ 
    {
        public IEnumerable<Process> ImprimeProcessos()
        {
            var processos = from p in Process.GetProcesses()
                            where p.ProcessName.StartsWith("w")
                            select p;
            return processos;
        }
    }
}
