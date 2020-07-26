using Freedirect.Core.ApplicationData;

namespace Freedirect.Core.Protocol
{
    internal interface IProtocol
    {
        string Scheme { get; }

        void PrepareStart(AppData appData);
        void Start();
    }
}