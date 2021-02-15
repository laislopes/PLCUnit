using PLC.Domain.PLC;
using PLC.Domain.Types;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PLC.Domain
{
    public class ProgrammableLogicController : IDisposable
    {
        private readonly IPLCCommunication _plc;
        private readonly IDictionary<string, IType> _types;

        public ProgrammableLogicController(string destinationHost)
        {
            _types = new Dictionary<string, IType>();
            _plc = new PLCS71500(destinationHost);
            _plc.Open();
            Console.WriteLine("Conexão com CLP estabelecida com sucesso!");
        }

        public ProgrammableLogicController MapBitVariable(string tag,
                                                   int dbNumber,
                                                   int byteNumber,
                                                   int bitNumber)
        {

            _types.Add(tag, new Bit(_plc, dbNumber, byteNumber, bitNumber));
            return this;
        }
        public string GetValueByTag(string tag)
        {
            var returnValue = _types[tag].Value;
            Console.WriteLine($"O dispositivo {tag} está {GetTextFromBoolean(returnValue)}");
            return returnValue;
        }

        public ProgrammableLogicController SetValueByTag(string tag, object value)
        {
            Console.WriteLine($"O dispositivo {tag} será {GetTextFromBoolean(value)}");
            _types[tag].SetValue(value);
            Thread.Sleep(50);
            return this;
        }

        private string GetTextFromBoolean(object value)
        {
            return (Convert.ToBoolean(value) ? "Ligado" : "Desligado");
        }

        public void Dispose()
        {

            _plc.Close();
            Console.WriteLine("Conexão com CLP encerrada com sucesso!");
        }
    }
}
