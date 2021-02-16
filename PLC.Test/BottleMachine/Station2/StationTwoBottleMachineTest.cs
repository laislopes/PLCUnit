using System;
using System.Collections.Generic;
using PLC.Domain;
using PLCUnit.Domain.PLC;
using Xunit;

namespace PLC.Test.BottleMachine
{
    [Collection("Serial")]
    public class StationTwoBottleMachineTest : IDisposable
    {
        private static ProgrammableLogicController _plc;

        public StationTwoBottleMachineTest()
        {
            var plcCommunication = PLCFactory.GetPLCS71500("127.0.0.1");
            _plc = new ProgrammableLogicController(plcCommunication);
            _plc.MapBitVariable("Sensor2", 2, 0, 2)
                .MapBitVariable("Engine1", 4, 0, 1)
                .MapBitVariable("Engine2", 4, 0, 2);
        }

        // O motor da Estação 2 deve ser ligado quando o Sensor 2 identifica a garrafa
        [Fact]
        public void ShouldTurnOnEngineTwoWhenSensorTwoDetectsTheBottle()
        {
            //Setup
            SetEngineAs(false);
            IList<bool> engineStatus = new List<bool>();

            //Test
            _plc.SetValueByTag("Engine1", true);
            _plc.SetValueByTag("Sensor2", true);
            engineStatus.Add(Convert.ToBoolean(_plc.GetValueByTag("Engine2")));
            _plc.SetValueByTag("Sensor2", false);
            engineStatus.Add(Convert.ToBoolean(_plc.GetValueByTag("Engine2")));

            //Assert
            Assert.All(engineStatus, status => Assert.True(status));
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

        /* 
         * O motor da Estação 2 não deve ser ligado, quando o Sensor 2 identifica a garrafa 
         * e o motor da Estação 1 está desligado
        */
        [Fact]
        public void ShouldNotTurnOnEngineTwoWhenEngineOneIsDisableAndSensorTwoDetectsTheBottle()
        {
            //Setup
            SetEngineAs(false);

            _plc.SetValueByTag("Engine1", false);
            _plc.SetValueByTag("Sensor2", true);

            //Test
            var engineStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine2"));

            //Assert
            Assert.False(engineStatus);

        }

        //[Fact]
        //public void ShouldNotTurnOnEngineWhenExistsMoreThanOneBottleInCycle()
        //{
        //    //Setup
        //    SetEngineAs(false);
        //    _plc.SetValueByTag("Sensor1", true);

        //    //Test
        //    _plc.SetValueByTag("Sensor2", true);

        //    //Assert
        //    var engineStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine2"));
        //    Assert.False(engineStatus);

        //}

        void SetEngineAs(bool status)
        {
            var currentStatus = Convert.ToBoolean(_plc.GetValueByTag("Engine2"));
            if (currentStatus != status)
                _plc.SetValueByTag("Engine2", status);
        }

        void Reset()
        {
            _plc.SetValueByTag("Sensor2", false)
            .SetValueByTag("Engine1", false)
            .SetValueByTag("Engine2", false);
        }

        public void Dispose()
        {
            Reset();
            _plc.Dispose();
        }
    }
}
