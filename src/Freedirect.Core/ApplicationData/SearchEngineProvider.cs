using System.Collections.Generic;

namespace Freedirect.Core.ApplicationData
{
    public class SearchEngineProvider
    {
        public List<SearchEngine> SearchEngines { get; }

        public SearchEngineProvider()
        {
            SearchEngines = new List<SearchEngine>()
            {
                //Bing is listed for the UI, of course it does not need to be replaced
                new SearchEngine("Bing", null),
                new SearchEngine("Google", "https://www.google.com/search?q="),
                new SearchEngine("DuckDuckGo", "https://duckduckgo.com/?q="),
                new SearchEngine("Yahoo", "https://search.yahoo.com/search?p="),
                new SearchEngine("Qwant", "https://www.qwant.com/?q="),
                new SearchEngine("Startpage", "https://www.startpage.com/do/search?&query=")
            };
        }
    }
}