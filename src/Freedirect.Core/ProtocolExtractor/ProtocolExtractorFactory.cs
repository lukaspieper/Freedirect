using System;

namespace Freedirect.Core.ProtocolExtractor
{
    internal class ProtocolExtractorFactory
    {
        internal IProtocolExtractor CreateCorrespondingProtocolExtractor(Uri uri)
        {
            return uri.Scheme switch
            {
                "microsoft-edge" => new EdgeProtocolExtractor(uri),
                _ => null
            };
        }
    }
}