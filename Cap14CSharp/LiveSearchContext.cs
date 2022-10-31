using System;
using Cap14CSharp;
using LINQToLive;

namespace Cap14CSharp
{
    public class LiveSearchContext
    {
        public Query<Resultado> Web;

        public Query<Resultado> News;

        public LiveSearchContext(String liveKey)
        {
            Web = new Query<Resultado>(new LiveProvider(liveKey, Live.Search.SourceType.Web));
            News = new Query<Resultado>(new LiveProvider(liveKey, Live.Search.SourceType.News));
        }
    }
}