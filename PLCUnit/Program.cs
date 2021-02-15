using PLC.Domain;
using PLC.Domain.PLC;

namespace PLC
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var plc = new ProgrammableLogicController(new PLCS71500("127.0.0.1")))
            {
                plc.MapBitVariable("BotaoLigaMotor", 2, 0, 0)
                   .MapBitVariable("Motor", 2, 0, 1)
                   .SetValueByTag("BotaoLigaMotor", false)
                   .GetValueByTag("Motor");
            }
        }

    }
}
