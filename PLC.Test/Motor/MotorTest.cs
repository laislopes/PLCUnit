using System;
using PLC.Domain;
using Xunit;

namespace PLC.Test.Motor
{
    public class MotorTest : IDisposable
    {
        private static ProgrammingLogicController _plc;

        public MotorTest()
        {
            _plc = new ProgrammingLogicController("127.0.0.1");
            _plc.MapBitVariable("BotaoLigaMotor", 2, 0, 0)
                .MapBitVariable("Motor", 4, 0, 0);
        }

        [Fact]
        public void ShouldTurnOffMotorWhenPressPowerButtonAndMotorIsTurnedOn()
        {
            //Setup
            SetMotorAs(true);

            //Test
            _plc.SetValueByTag("BotaoLigaMotor", false);

            //Assert
            var motorStatus = Convert.ToBoolean(_plc.GetValueByTag("Motor"));
            Assert.False(motorStatus);

        }

        [Fact]
        public void ShouldTurnOnMotorWhenPressPowerButtonAndMotorIsTurnedOff()
        {
            //Setup
            SetMotorAs(false);

            //Test
            _plc.SetValueByTag("BotaoLigaMotor", true);

            //Assert
            var motorStatus = Convert.ToBoolean(_plc.GetValueByTag("Motor"));
            Assert.True(motorStatus);

        }

        public void SetMotorAs(bool status)
        {
            var currentStatus = Convert.ToBoolean(_plc.GetValueByTag("Motor"));
            if (currentStatus != status)
                _plc.SetValueByTag("BotaoLigaMotor", status);
        }

        public void Dispose()
        {
            _plc.Dispose();
        }
    }
}
