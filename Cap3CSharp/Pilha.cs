using System;
using System.Collections;
using System.Collections.Generic;

namespace Cap3CSharp 
{
    public sealed class Pilha<T> : IEnumerable<T> 
    {
        private const int _capacidadeInicial = 10;
        private T[] _array = new T[_capacidadeInicial];
        private int _numeroElementos = 0;

        public class PilhaEnumerator : IEnumerator<T> 
        {
            private T[] _array;
            private int _index;
            private T _current;
            private Pilha<T> _parent;

            internal PilhaEnumerator(Pilha<T> pilha) 
            {
                _parent = pilha;
                _array = pilha._array;
                _current = default(T);
                _index = -2;
            }

            public T Current 
            {
                get 
                {
                    if (_index < 0) 
                    {
                        throw new InvalidOperationException();
                    }
                    return _current;
                }
            }

            public void Dispose() 
            {
                _index = -1;
            }

            object IEnumerator.Current 
            {
                get { return Current; }
            }

            public bool MoveNext() 
            {
                if (_index == -2) 
                {
                    // movenext chamado pela primeira vez
                    _index = _parent._numeroElementos - 1;
                    if (_index < 0) return false;
                    _current = _array[_index];
                    return true;
                }
                if (--_index < 0) return false;
                _current = _array[_index];
                return true;
            }

            public void Reset() 
            {
                _index = -2;
                _current = default(T);
            }
        }


        public IEnumerator<T> GetEnumerator() 
        {
            return new PilhaEnumerator(this);
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