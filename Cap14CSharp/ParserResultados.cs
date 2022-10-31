using System.Collections;
using System.Collections.Generic;
using Cap14CSharp;
using Cap14CSharp.Live.Search;

namespace Cap14CSharp
{
    public class ParserResultados : IEnumerable<Resultado>
    {
        private readonly IEnumerable<Result> _results;

        public ParserResultados(IEnumerable<Result> results )
        {
            _results = results;
        }

        public IEnumerator<Resultado> GetEnumerator()
        {
            foreach (var item in _results)
            {
                yield return new Resultado{Descricao = item.Description , Titulo = item.Title, Url = item.Url};
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}