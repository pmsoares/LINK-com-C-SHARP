using Cap14CSharp.Live.Search;

namespace Cap14CSharp
{
    public class LiveWebHelper
    {

        public SearchResponse GetResultsFromLive(SearchRequest request)
        {
            using (var service = new MSNSearchService())
            {
                return service.Search(request);
            }
        }
    }
}