using Freedirect.Core.Protocol;

namespace Freedirect.Core.ProtocolParsing
{
    internal interface IProtocolParser
    {
        void Parse();
        IProtocol GetProtocol();
    }
}