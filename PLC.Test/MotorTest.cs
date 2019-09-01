using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLC.Domain;

namespace PLC.Teste
{
    [TestClass]
    public class UnitTest1
    {
        private static ProgrammingLogicController _plc;

        [TestInitialize]
        public void Setup()
        {
            _plc = new ProgrammingLogicController("127.0.0.1");
            _plc.MapBitVariable("BotaoLigaMotor", 2, 0, 0)
                .MapBitVariable("Motor", 2, 0, 1);
        }

        [TestMethod]
        public void ShouldTurnOffMotorWhenPressPowerButtonAndMotorIsTurnedOn()
        {
            //Setup
            SetMotorAs(true);

            //Test
            _plc.SetValueByTag("BotaoLigaMotor", false);

            //Assert
            var motorStatus = Convert.ToBoolean(_plc.GetValueByTag("Motor"));
            Assert.IsFalse(motorStatus);

        }
        [TestMethod]
        public void ShouldTurnOnMotorWhenPressPowerButtonAndMotorIsTurnedOff()
        {
            //Setup
            SetMotorAs(false);

            //Test
            _plc.SetValueByTag("BotaoLigaMotor", true);

            //Assert
            var motorStatus = Convert.ToBoolean(_plc.GetValueByTag("Motor"));
            Assert.IsTrue(motorStatus);

        }

        public void SetMotorAs(bool status)
        {
            var currentStatus = Convert.ToBoolean(_plc.GetValueByTag("Motor"));
            if (currentStatus != status)
                _plc.SetValueByTag("BotaoLigaMotor", status);
        }
        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            _plc.Dispose();
        }
    }
}
