using System;
using System.Globalization;
using System.Reflection;
using System.Text;
using Cap14CSharp.Live.Search;

namespace Cap14CSharp
{
    public static class SearchRequestExtender {
        public static String TranslateToText(this SearchRequest request) {
            if (request == null) return "";

            var builder = new StringBuilder();
            var flags = BindingFlags.Instance | BindingFlags.Public;
            foreach (var prop in typeof(SearchRequest).GetProperties(flags)) {
                builder.AppendFormat("{0}: {1}\n", prop.Name, 
                                     prop.GetValue(request,flags,null, null, CultureInfo.InvariantCulture));
            }
            return builder.ToString();
        }
    }
}