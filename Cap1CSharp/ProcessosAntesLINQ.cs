using System.Collections.Generic;
using System.Diagnostics;

namespace Cap1CSharp 
{
    public class ProcessosAntesLINQ 
    {
        public IEnumerable<Process> ImprimeProcessos()
        {
            List<Process> processos = new List<Process>();
            foreach (Process p in Process.GetProcesses()) 
            {
                if (p.ProcessName.StartsWith("w")) 
                {
                    processos.Add(p);
                }
            }
            return processos;
        }
    }
}
