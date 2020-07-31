using System;
using Freedirect.Application.Data;
using Freedirect.Application.UserSettings;
using Freedirect.Core;

namespace Freedirect.Application
{
    internal class UriService
    {
        private readonly UserSettingsProvider _userSettingsProvider = new UserSettingsProvider();
        private readonly SearchEnginesProvider _searchEnginesProvider = new SearchEnginesProvider();

        internal void TransformAndRunUri(Uri uri)
        {
            var protocolFacade = new ProtocolFacade();

            protocolFacade.ExtractProtocol(uri);

            var searchEngineName = _userSettingsProvider.UserSettings.SelectedSearchEngine;
            var searchEngine = _searchEnginesProvider.GetSearchEngineByName(searchEngineName);
            protocolFacade.TransformProtocol(searchEngine);

            protocolFacade.StartProtocol();
        }
    }
}