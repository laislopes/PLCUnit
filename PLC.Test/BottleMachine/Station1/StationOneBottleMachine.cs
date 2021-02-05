using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLC.Domain;

namespace PLC.Test.BottleMachine
{
    [TestClass]
    public class StationOneBottleMachine
    {
        private static ProgrammingLogicController _plc;

        [TestInitialize]
        public void Setup()
        {
            _plc = new ProgrammingLogicController("127.0.0.1");
            _plc.MapBitVariable("Sensor1", 2, 0, 1)
            .MapBitVariable("Motor1", 4, 0, 1);
        }

        [TestMethod]
        public void ShouldTurnOnStationOneMotorWhenSensorOneIsActive()
        {
            S
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            _plc.Dispose();
        }
    }
}
