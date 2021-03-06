﻿using System;
using Freedirect.Application.Settings;
using Freedirect.Core;

namespace Freedirect.Application
{
    internal class UriService
    {
        private readonly IUserSettingsProvider _userSettingsProvider = new UserSettingsProvider();
        private readonly ISearchEnginesProvider _searchEnginesProvider = new SearchEnginesProvider();

        internal void TransformAndRunUri(Uri uri)
        {
            var protocolHandler = new ProtocolHandler();

            protocolHandler.ExtractProtocol(uri);

            var searchEngineName = _userSettingsProvider.UserSettings.SelectedSearchEngine;
            var searchEngine = _searchEnginesProvider.GetSearchEngineByName(searchEngineName);

            if (searchEngine is not null)
            {
                protocolHandler.TransformProtocol(searchEngine);
                protocolHandler.StartProtocol();
            }
        }
    }
}