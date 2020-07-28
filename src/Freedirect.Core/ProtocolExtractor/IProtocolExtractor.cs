using Freedirect.Core.ProtocolExtractor.Result;

namespace Freedirect.Core.ProtocolExtractor
{
    internal interface IProtocolExtractor
    {
        IProtocolExtractorResult Parse();
    }
}