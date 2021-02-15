using System;
using PLC.Domain;
using PLC.Domain.PLC;
using PLCUnit.Domain.PLC;
using Xunit;

namespace PLC.Test.Engine
{
    public class EngineTest : IDisposable
    {
        private static ProgrammableLogicController _plc;

        public EngineTest()
        {
            var plcCommunication = PLCFactory.GetPLC71500("127.0.0.1");
            _plc = new ProgrammableLogicController(plcCommunication);
            _plc.MapBitVariable("StartButton", 2, 0, 0)
                .MapBitVariable("Engine", 4, 0, 0);
        }

        [Fact]
        public void ShouldTurnOffEngineWhenPressPowerButtonAndEngineIsTurnedOn()
        {
            //Setup
            SetEngineAs(true);

            //Test
            _plc.SetValueByTag("StartButton", false);

            //Assert
            var engineStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine"));
            Assert.False(engineStatus);

        }

        [Fact]
        public void ShouldTurnOnEngineWhenPressPowerButtonAndEngineIsTurnedOff()
        {
            //Setup
            SetEngineAs(false);

            //Test
            _plc.SetValueByTag("StartButton", true);

            //Assert
            var engineStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine"));
            Assert.True(engineStatus);

        }

        void SetEngineAs(bool status)
        {
            var currentStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine"));
            if (currentStatus != status)
                _plc.SetValueByTag("StartButton", status);
        }

        public void Dispose()
        {
            _plc.Dispose();
        }
    }
}
