using PLC.Domain.PLC;

namespace PLCUnit.Domain.PLC
{
    public static class PLCFactory
    {
        public static IPLCCommunication GetPLC71500(string ip)
            => new PLCS71500(ip);
    }
}
