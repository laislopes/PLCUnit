using System;
using System.Collections.Generic;
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
        public void ShouldTurnOnEngineOneWhenSensorOneDetectsTheBottle()
        {
            //Setup
            SetEngineAs(false);
            IList<bool> engineStatus = new List<bool>();

            //Test
            _plc.SetValueByTag("Sensor1", true);
            engineStatus.Add(Convert.ToBoolean(_plc.GetValueByTag("Engine1")));
            _plc.SetValueByTag("Sensor1", false);
            engineStatus.Add(Convert.ToBoolean(_plc.GetValueByTag("Engine1")));

            //Assert
            Assert.All(engineStatus, status => Assert.True(status));
        }

        [Fact]
        public void ShouldNotTurnOnEngineOneWhenSensorOneDoesNotDetectTheBottle()
        {
            //Setup
            SetEngineAs(false);

            //Test
            _plc.SetValueByTag("Sensor1", false);

            //Assert
            var engineStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine1"));
            Assert.False(engineStatus);
        }

        //[Fact]
        //public void ShouldNotTurnOnEngineWhenExistsMoreThanOneBottleInCycle()
        //{
        //    //Setup
        //    SetEngineAs(false);
        //    _plc.SetValueByTag("Sensor2", true);

        //    //Test
        //    _plc.SetValueByTag("Sensor1", true);

        //    //Assert
        //    var engineStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine1"));
        //    Assert.False(engineStatus);
        //}

        void SetEngineAs(bool status)
        {
            var currentStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine1"));
            if (currentStatus != status)
                _plc.SetValueByTag("Engine1", status);
        }

        void Reset()
        {
            _plc.SetValueByTag("Sensor1", false)
            .SetValueByTag("Sensor2", false)
            .SetValueByTag("Engine1", false);
        }

        public void Dispose()
        {
            Reset();
            _plc.Dispose();
        }
    }
}
