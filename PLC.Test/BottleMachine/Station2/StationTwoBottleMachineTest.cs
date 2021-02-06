using System;
using PLC.Domain;
using Xunit;

namespace PLC.Test.BottleMachine
{
    public class StationTwoBottleMachineTest : IDisposable
    {
        private static ProgrammingLogicController _plc;

        public StationTwoBottleMachineTest()
        {
            _plc = new ProgrammingLogicController("127.0.0.1");
            _plc.MapBitVariable("Sensor1", 2, 0, 1)
                .MapBitVariable("Sensor2", 2, 0, 2)
                .MapBitVariable("Engine2", 4, 0, 2);
        }

        [Fact]
        public void ShouldTurnOnEngineTwoWhenSensorTwoIsActive()
        {
            //Setup
            SetEngineAs(false);

            //Test
            _plc.SetValueByTag("Sensor2", true);

            //Assert
            var engineStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine2"));
            Assert.True(engineStatus);

        }

        [Fact]
        public void ShouldNotTurnOnEngineTwoWhenSensorTwoIsNotActive()
        {
            //Setup
            SetEngineAs(false);

            //Test
            _plc.SetValueByTag("Sensor2", false);

            //Assert
            var engineStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine2"));
            Assert.False(engineStatus);

        }

        [Fact]
        public void ShouldNotTurnOnEngineWhenExistsMoreThanOneBottleInCycle()
        {
            //Setup
            SetEngineAs(false);
            _plc.SetValueByTag("Sensor1", true);

            //Test
            _plc.SetValueByTag("Sensor2", true);

            //Assert
            var engineStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine2"));
            Assert.False(engineStatus);

        }

        void SetEngineAs(bool status)
        {
            var currentStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine2"));
            if (currentStatus != status)
                _plc.SetValueByTag("Sensor2", status);
        }

        // TO DO - Refactoring
        void Reset()
        {
            _plc.SetValueByTag("Sensor1", false);
            _plc.SetValueByTag("Sensor2", false);
            _plc.SetValueByTag("Engine2", false);
        }

        public void Dispose()
        {
            Reset();
            _plc.Dispose();
        }
    }
}
