using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Freedirect.Core;

namespace Freedirect.Application.Settings
{
    internal class SearchEnginesProvider : ISearchEnginesProvider
    {
        internal SearchEnginesProvider()
        {
            var jsonFilePath = GetSearchEnginesJsonFilePath();
            var json = File.ReadAllText(jsonFilePath);

            SearchEngines = JsonSerializer.Deserialize<List<SearchEngine>>(json);
        }

        public List<SearchEngine> SearchEngines { get; }

        public SearchEngine GetSearchEngineByName(string searchEngineName)
        {
            return SearchEngines.FirstOrDefault(searchEngine => searchEngine.Name == searchEngineName && searchEngine.Address != null);
        }

        private string GetSearchEnginesJsonFilePath()
        {
            var executableFilePath = Assembly.GetExecutingAssembly().Location;
            var executableFile = new FileInfo(executableFilePath);

            var dataDirectory = executableFile.Directory?.GetDirectories("Resources").FirstOrDefault();
            return dataDirectory?.GetFiles("SearchEngines.json").FirstOrDefault()?.FullName;
        }
    }
}