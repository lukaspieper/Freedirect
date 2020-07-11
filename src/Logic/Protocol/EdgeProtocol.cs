using System.Diagnostics;
using Logic.ApplicationData;
using Logic.SearchEngineReplacing;

namespace Logic.Protocol
{
    internal class EdgeProtocol : IProtocol
    {
        public string Scheme { get; } = "microsoft-edge";
        internal string Url { private get; set; }

        public void PrepareStart(AppDataEntity dataEntity)
        {
            if (!UrlIsBingSearch()) return;

            var searchEngineName = dataEntity.SearchEngineName;
            var finder = new SearchEngineFinder(searchEngineName);
            var searchEngine = finder.GetSelectedSearchEngine();

            if (searchEngine is null) return;

            Url = Url.Replace("https://www.bing.com/search?q=", searchEngine.Address);
        }

        private bool UrlIsBingSearch()
        {
            var result = false;

            if (Url.StartsWith("https://www.bing.com/search?q="))
            {
                result = true;
            }            
            else if (Url.StartsWith("http://www.bing.com/search?q="))
            {
                //Replacing the search engine only works with https://www.bing.com/search?q=
                Url = Url.Replace("http://www.bing.com/search?q=", "https://www.bing.com/search?q=");
                result = true;
            }

            return result;
        }

        public void Start()
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = Url,
                UseShellExecute = true
            };
            Process.Start(processStartInfo);
        }
    }
}