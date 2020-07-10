using Logic.ApplicationData;

namespace Logic.Protocol
{
    internal interface IProtocol
    {
        string Scheme { get; }

        void PrepareStart(AppDataEntity dataEntity);
        void Start();
    }
}