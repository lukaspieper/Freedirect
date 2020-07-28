using System;

namespace Freedirect.Core.ProtocolExtractor.Result
{
    internal class EdgeProtocolExtractorResult : IProtocolExtractorResult
    {
        public EdgeProtocolExtractorResult(Uri url)
        {
            Url = url;
        }

        internal Uri Url { get; }
    }
}