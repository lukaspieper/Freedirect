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

        internal SearchEngineEntity GetSelectedSearchEngine()
        {
            var searchEngineProvider = new SearchEngineProvider();

            foreach (var searchEngine in searchEngineProvider.SearchEngines)
            {
                if (searchEngine.Name != _searchEngineName || searchEngine.Address is null) continue;

                return searchEngine;
            }

            return null;
        }
    }
}