using Logic.Protocol;

namespace Logic.ProtocolParsing
{
    internal interface IProtocolParser
    {
        void Parse();
        IProtocol GetProtocol();
    }
}