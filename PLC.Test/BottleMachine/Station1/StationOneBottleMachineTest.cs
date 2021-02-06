using System;
using PLC.Domain;
using Xunit;

namespace PLC.Test.BottleMachine
{
    [Collection("Serial")]
    public class StationOneBottleMachineTest : IDisposable
    {
        private static ProgrammingLogicController _plc;

        public StationOneBottleMachineTest()
        {
            _plc = new ProgrammingLogicController("127.0.0.1");
            _plc.MapBitVariable("Sensor1", 2, 0, 1)
                .MapBitVariable("Sensor2", 2, 0, 2)
                .MapBitVariable("Engine1", 4, 0, 1);
        }

        [Fact]
        public void ShouldTurnOnEngineOneWhenSensorOneIsActive()
        {
            //Setup
            SetEngineAs(false);

            //Test
            _plc.SetValueByTag("Sensor1", true);

            //Assert
            var engineStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine1"));
            Assert.True(engineStatus);

        }

        [Fact]
        public void ShouldNotTurnOnEngineOneWhenSensorOneIsNotActive()
        {
            //Setup
            SetEngineAs(false);

            //Test
            _plc.SetValueByTag("Sensor1", false);

            //Assert
            var engineStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine1"));
            Assert.False(engineStatus);
        }

        [Fact]
        public void ShouldNotTurnOnEngineWhenExistsMoreThanOneBottleInCycle()
        {
            //Setup
            SetEngineAs(false);
            _plc.SetValueByTag("Sensor2", true);

            //Test
            _plc.SetValueByTag("Sensor1", true);

            //Assert
            var engineStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine1"));
            Assert.False(engineStatus);
        }

        void SetEngineAs(bool status)
        {
            var currentStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine1"));
            if (currentStatus != status)
                _plc.SetValueByTag("Sensor1", status);
        }

        // TO DO - Refactoring
        void Reset()
        {
            _plc.SetValueByTag("Sensor1", false);
            _plc.SetValueByTag("Sensor2", false);
            _plc.SetValueByTag("Engine1", false);
        }

        public void Dispose()
        {
            Reset();
            _plc.Dispose();
        }
    }
}
