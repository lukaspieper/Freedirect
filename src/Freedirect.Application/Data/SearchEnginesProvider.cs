﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Freedirect.Core;

namespace Freedirect.Application.Data
{
    internal class SearchEnginesProvider
    {
        internal SearchEnginesProvider()
        {
            var jsonFilePath = GetSearchEnginesJsonFilePath();
            var json = File.ReadAllText(jsonFilePath);

            SearchEngines = JsonSerializer.Deserialize<List<SearchEngine>>(json);
        }

        internal List<SearchEngine> SearchEngines { get; }

        internal SearchEngine GetSearchEngineByName(string searchEngineName)
        {
            return SearchEngines.FirstOrDefault(searchEngine => searchEngine.Name == searchEngineName && searchEngine.Address != null);
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