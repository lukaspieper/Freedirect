using Freedirect.Core.Protocol;

namespace Freedirect.Core.ProtocolExtractor
{
    internal interface IProtocolExtractor
    {
        IProtocol Parse();
    }
}