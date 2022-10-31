using System;

namespace Cap4CSharp 
{
    delegate void AvisaUtilizador(string msg);

    class ImpressoraMensagens 
    {
        public void MostraMensagem(string msg) 
        {
            Console.WriteLine(msg);
        }

    }
}
