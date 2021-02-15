using PLC.Domain.PLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCUnit.Domain.PLC
{
    public static class PLCFactory
    {
        public static IPLCCommunication GetPLC71500(string ip)
            => new PLCS71500(ip);
    }
}
