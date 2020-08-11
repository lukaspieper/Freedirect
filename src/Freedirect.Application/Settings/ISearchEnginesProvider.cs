using System.Collections.Generic;
using Freedirect.Core;

namespace Freedirect.Application.Settings
{
    internal interface ISearchEnginesProvider
    {
        List<SearchEngine> SearchEngines { get; }

        SearchEngine GetSearchEngineByName(string searchEngineName);
    }
}