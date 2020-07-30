using System;
using System.Text.RegularExpressions;
using Freedirect.Core.ApplicationData;
using Freedirect.Core.Protocol;

namespace Freedirect.Core.ProtocolTransformer
{
    internal class SearchEngineTransformer : IProtocolTransformer
    {
        private readonly Regex _searchEngineReplacement = new Regex(@"http[s]?:\/\/www.bing.com\/search\?q=");
        private readonly UriProtocol _protocol;
        private readonly SearchEngine _searchEngine;

        internal SearchEngineTransformer(UriProtocol protocol, SearchEngine searchEngine)
        {
            _protocol = protocol;
            _searchEngine = searchEngine ?? new SearchEngine("Bing", "https://www.bing.com/search?q=");
        }

        public IProtocol Transform()
        {
            var transformedUriString = _searchEngineReplacement.Replace(_protocol.Uri.AbsoluteUri, _searchEngine.Address);
            var transformedUri = new Uri(transformedUriString);

            return new UriProtocol(transformedUri);
        }
    }
}