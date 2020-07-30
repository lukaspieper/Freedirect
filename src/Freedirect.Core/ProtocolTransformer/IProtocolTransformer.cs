using Freedirect.Core.Protocol;

namespace Freedirect.Core.ProtocolTransformer
{
    internal interface IProtocolTransformer
    {
        IProtocol Transform();
    }
}