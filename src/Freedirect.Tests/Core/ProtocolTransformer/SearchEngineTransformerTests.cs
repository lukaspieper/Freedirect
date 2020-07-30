using System;
using Freedirect.Core.ApplicationData;
using Freedirect.Core.Protocol;
using Freedirect.Core.ProtocolTransformer;
using Xunit;

namespace Freedirect.Tests.Core.ProtocolTransformer
{
    public class SearchEngineTransformerTests
    {
        private const string Query = "example+query";

        [Theory]
        [InlineData("https://example.com/search?q=")]
        [InlineData("https://www.startpage.com/do/dsearch?query=")]
        public void Transform_ReturnsTransformedProtocol(string searchEngineAddress)
        {
            var uri = new Uri($"https://www.bing.com/search?q={Query}");
            var uriProtocol = new UriProtocol(uri);
            var searchEngine = new SearchEngine("Search engine", searchEngineAddress);
            var searchEngineTransformer = new SearchEngineTransformer(uriProtocol, searchEngine);

            var transformedProtocol = searchEngineTransformer.Transform();

            Assert.Equal(searchEngineAddress + Query, (transformedProtocol as UriProtocol)?.Uri.AbsoluteUri);
        }

        [Fact]
        public void Transform_SearchEngineIsNull_ReturnsBingUrl()
        {
            var uri = new Uri($"https://www.bing.com/search?q={Query}");
            var uriProtocol = new UriProtocol(uri);
            var searchEngineTransformer = new SearchEngineTransformer(uriProtocol, null);

            var transformedProtocol = searchEngineTransformer.Transform();

            Assert.Equal($"https://www.bing.com/search?q={Query}", (transformedProtocol as UriProtocol)?.Uri.AbsoluteUri);
        }

        [Fact]
        public void Transform_HttpBecomesHttps()
        {
            var uri = new Uri($"http://www.bing.com/search?q={Query}");
            var uriProtocol = new UriProtocol(uri);
            var searchEngineTransformer = new SearchEngineTransformer(uriProtocol, null);

            var transformedProtocol = searchEngineTransformer.Transform();

            Assert.Equal($"https://www.bing.com/search?q={Query}", (transformedProtocol as UriProtocol)?.Uri.AbsoluteUri);
        }
    }
}