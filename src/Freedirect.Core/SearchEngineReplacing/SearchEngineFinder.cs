using Freedirect.Core.ApplicationData;

namespace Freedirect.Core.SearchEngineReplacing
{
    internal class SearchEngineFinder
    {
        private readonly string _searchEngineName;

        internal SearchEngineFinder(string searchEngineName)
        {
            _searchEngineName = searchEngineName;
        }

        internal SearchEngine GetSelectedSearchEngine()
        {
            var searchEngineProvider = new SearchEnginesProvider();

            foreach (var searchEngine in searchEngineProvider.GetSearchEngines())
            {
                if (searchEngine.Name != _searchEngineName || searchEngine.Address is null) continue;

                return searchEngine;
            }

            return null;
        }
    }
}