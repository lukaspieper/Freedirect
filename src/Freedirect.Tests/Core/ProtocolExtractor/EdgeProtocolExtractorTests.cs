using System;
using Freedirect.Core.Protocol;
using Freedirect.Core.ProtocolExtractor;
using Xunit;

namespace Freedirect.Tests.Core.ProtocolExtractor
{
    public class EdgeProtocolExtractorTests
    {
        private const string UrlString = "https://example.com/";

        [Fact]
        public void Parse_UrlIsInQuery_ReturnsResult()
        {
            var uri = new Uri($"microsoft-edge:?launchContext1=TimelineActivityId&launchContext2=...&mmx-scid=...&url={UrlString}");
            var edgeProtocolExtractor = new EdgeProtocolExtractor(uri);

            var result = edgeProtocolExtractor.Parse();

            Assert.Equal(UrlString, (result as UriProtocol)?.Uri.AbsoluteUri);
        }

        [Fact]
        public void Parse_QueryWithoutUrl_ReturnsNull()
        {
            var uri = new Uri("microsoft-edge:?launchContext1=TimelineActivityId&launchContext2=...&mmx-scid=...");
            var edgeProtocolExtractor = new EdgeProtocolExtractor(uri);

            var result = edgeProtocolExtractor.Parse();

            Assert.Null(result);
        }

        [Fact]
        public void Parse_UrlIsInLocalPath_ReturnsResult()
        {
            var uri = new Uri($"microsoft-edge:{UrlString}");
            var edgeProtocolExtractor = new EdgeProtocolExtractor(uri);

            var result = edgeProtocolExtractor.Parse();

            Assert.Equal(UrlString, (result as UriProtocol)?.Uri.AbsoluteUri);
        }
    }
}