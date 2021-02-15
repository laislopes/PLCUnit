using S7.Net;
using S7.Net.Types;
using PLC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var plc = new ProgrammableLogicController("127.0.0.1"))
            {
                plc.MapBitVariable("BotaoLigaMotor", 2, 0, 0)
                   .MapBitVariable("Motor", 2, 0, 1)
                   .SetValueByTag("BotaoLigaMotor", false)
                   .GetValueByTag("Motor");
            }
        }

    }
}
