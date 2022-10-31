using System;

namespace Cap2CSharp
{
    public sealed class PilhaGenéricaCSharp1
    {
        private const int _capacidadeInicial = 10;
        private object[] _arrayElementos = new object[_capacidadeInicial];
        private int _numeroElementos;
        
        public int TotalElementos 
        {
            get { return _numeroElementos; }
        }

        public object Pop() 
        {
            VerificaEstadoPilhaParaLeitura();
            object numero = _arrayElementos[--_numeroElementos];
            _arrayElementos[_numeroElementos] = default(int);
            return numero;
        }

        private void VerificaEstadoPilhaParaLeitura() 
        {
            if (TotalElementos == 0) 
            {
                throw new InvalidOperationException(
                    "Não pode executar esta operação sobre uma pilha vazia.");
            }
        }

        public void Push(object numero) 
        {
            if (_arrayElementos.Length == _numeroElementos) 
            {
                AumentaTamanhoArray();
            }
            _arrayElementos[_numeroElementos++] = numero;
        }

        private void AumentaTamanhoArray() 
        {
            var novoArray = new object[_arrayElementos.Length * 2];
            Array.Copy(_arrayElementos, novoArray,
                       _arrayElementos.Length);
            _arrayElementos = novoArray;
        }

        public object Peek() 
        {
            VerificaEstadoPilhaParaLeitura();
            return _arrayElementos[_numeroElementos - 1];
        }
    }
}