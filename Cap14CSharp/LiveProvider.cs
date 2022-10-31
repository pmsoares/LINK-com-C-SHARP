using System.Linq.Expressions;
using Cap14CSharp.Live.Search;
using LINQToLive;

namespace Cap14CSharp
{
    public class LiveProvider : QueryProvider
    {
        private string _liveKey;
        private SourceType _type;
        public LiveProvider(string liveKey, SourceType type)
        {
            _liveKey = liveKey;
            _type = type;
        }

        public override string GetQueryText(Expression expression)
        {
            return Translate(expression).TranslateToText();
        }

        public override object Execute(Expression expression)
        {
            var request = Translate(expression);
            var response = new LiveWebHelper().GetResultsFromLive(request);
            var items = response.Responses[0].Results;
            return new ParserResultados(items);
        }

        private SearchRequest Translate(Expression expression)
        {
            return new VisitanteArvore(_liveKey, _type).TraduzArvore(expression);
        }
    }
}