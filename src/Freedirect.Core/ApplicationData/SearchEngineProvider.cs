using System.Collections.Generic;

namespace Freedirect.Core.ApplicationData
{
    public class SearchEngineProvider
    {
        public List<SearchEngineEntity> SearchEngines { get; }

        public SearchEngineProvider()
        {
            SearchEngines = new List<SearchEngineEntity>()
            {
                //Bing is listed for the UI, of course it does not need to be replaced
                new SearchEngineEntity("Bing", null),
                new SearchEngineEntity("Google", "https://www.google.com/search?q="),
                new SearchEngineEntity("DuckDuckGo", "https://duckduckgo.com/?q="),
                new SearchEngineEntity("Yahoo", "https://search.yahoo.com/search?p="),
                new SearchEngineEntity("Qwant", "https://www.qwant.com/?q="),
                new SearchEngineEntity("Startpage", "https://www.startpage.com/do/search?&query=")
            };
        }
    }
}