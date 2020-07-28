using Freedirect.Core.ApplicationData;

namespace Freedirect.Core.Protocol
{
    internal interface IProtocol
    {
        string Scheme { get; }

        void PrepareStart(UserSettings userSettings);
        void Start();
    }
}