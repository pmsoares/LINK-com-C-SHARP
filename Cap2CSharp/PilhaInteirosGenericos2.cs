using System;

namespace Cap2CSharp
{
    public sealed class Pilha<T> 
    {
        private const int _capacidadeInicial = 10;
        private T[] _array = new T[_capacidadeInicial];
        private int _numeroElementos = 0;
        
        public int TotalElementos 
        {
            get { return _numeroElementos; }
        }
        
        public T Pop() 
        {
            VerificaEstadoPilhaParaLeitura();
            T numero = _array[--_numeroElementos];
            _array[_numeroElementos] = default(T);
            return numero;
        }

        private void VerificaEstadoPilhaParaLeitura() 
        {
            if (TotalElementos == 0) 
            {
                throw new InvalidOperationException(
                    "Não pode executar esta operação sobre uma stack vazia.");
            }
        }

        public void Push(T numero) 
        {
            if (_array.Length == _numeroElementos) 
            {
                AumentaTamanhoArray();
            }
            _array[_numeroElementos++] = numero;
        }

        private void AumentaTamanhoArray() 
        {
            T[] novoArray = new T[_array.Length * 2];
            Array.Copy(_array, novoArray, _array.Length);
            _array = novoArray;
        }

        public T Peek() 
        {
            VerificaEstadoPilhaParaLeitura();
            return _array[_numeroElementos - 1];
        }
    }
}