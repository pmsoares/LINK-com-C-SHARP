using System;
using System.Collections;
using System.Collections.Generic;

namespace Cap3CSharp 
{
    public sealed class PilhaComBlocosIteracao<T> : IEnumerable<T>
    {
        private const int _capacidadeInicial = 10;
        private T[] _array = new T[_capacidadeInicial];
        private int _numeroElementos = 0;
        
        public IEnumerator<T> GetEnumerator() 
        {
            for (int i = _numeroElementos-1; i >= 0; i--)  
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
        {
            return GetEnumerator();
        }

        public int TotalElementos 
        {
            get { return _numeroElementos; }
        }

        public T Pop() 
        {
            VerificaEstadoPilhaParaLeitura();
            T elem = _array[--_numeroElementos];
            _array[_numeroElementos] = default(T);
            return elem;
        }

        private void VerificaEstadoPilhaParaLeitura() 
        {
            if (TotalElementos == 0) 
            {
                throw new InvalidOperationException(
                  "Não pode executar esta operação sobre uma stack vazia.");
            }
        }
        public void Push(T elem) 
        {
            if (_array.Length == _numeroElementos) 
            {
                AumentaTamanhoArray();
            }
            _array[_numeroElementos++] = elem;
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

