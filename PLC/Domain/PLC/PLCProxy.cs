using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC.Domain.PLC
{
    class PLCProxy : Plc, IPLCComunication
    {
        public PLCProxy(string ip)
            : base(CpuType.S71500, ip, 0, 1)
        {
        }
    }
}
