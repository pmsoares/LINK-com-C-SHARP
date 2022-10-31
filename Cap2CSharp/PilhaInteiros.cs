using System;

namespace Cap2CSharp
{
    public sealed class PilhaInteiros 
    {
        private const int _capacidadeInicial = 10;
        private int[] _arrayElementos = new int[_capacidadeInicial];
        private int _numeroElementos = 0;
        
        public int TotalElementos 
        {
            get { return _numeroElementos; }
        }
        
        public int Pop() 
        {
            VerificaEstadoPilhaParaLeitura();
            int numero = _arrayElementos [--_numeroElementos];
            _arrayElementos [_numeroElementos] = default(int);
            return numero;
        }
        
        private void VerificaEstadoPilhaParaLeitura() 
        {
            if (TotalElementos == 0) {
                throw new InvalidOperationException(
                    "Não pode executar esta operação sobre uma pilha vazia.");
            }
        }
        
        public void Push(int numero) 
        {
            if (_arrayElementos.Length == _numeroElementos) 
            {
                AumentaTamanhoArray();
            }
            _arrayElementos[_numeroElementos++] = numero;
        }

        private void AumentaTamanhoArray() 
        {
            int[] novoArray = new int[_arrayElementos.Length*2];
            Array.Copy(_arrayElementos, novoArray, 
                       _arrayElementos.Length);
            _arrayElementos = novoArray;
        }

        public int Peek() 
        {
            VerificaEstadoPilhaParaLeitura();
            return _arrayElementos[_numeroElementos - 1];
        }
    }
}