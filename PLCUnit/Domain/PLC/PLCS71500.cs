using S7.Net;

namespace PLC.Domain.PLC
{
    public class PLCS71500 : Plc, IPLCCommunication
    {


        public PLCS71500(string ip)
            : base(CpuType.S71500, ip, 0, 1)
        {
        }
    }
}


