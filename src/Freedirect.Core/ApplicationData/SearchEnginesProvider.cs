using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace Freedirect.Core.ApplicationData
{
    public class SearchEnginesProvider
    {
        public List<SearchEngine> GetSearchEngines()
        {
            var jsonFilePath = GetSearchEnginesJsonFilePath();
            var json = File.ReadAllText(jsonFilePath);

            return JsonSerializer.Deserialize<List<SearchEngine>>(json);
        }

        private string GetSearchEnginesJsonFilePath()
        {
            var executableFilePath = Assembly.GetExecutingAssembly().Location;
            var executableFile = new FileInfo(executableFilePath);

            var dataDirectory = executableFile.Directory?.GetDirectories("Data").FirstOrDefault();
            return dataDirectory?.GetFiles("SearchEngines.json").FirstOrDefault()?.FullName;
        }
    }
}