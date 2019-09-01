using S7Example.Domain.PLC;
using S7Example.Domain.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace S7Example.Domain
{
    public class ProgrammingLogicController : IDisposable
    {
        private IPLCComunication _plc;
        private IDictionary<string, IType> _types;

        public ProgrammingLogicController(string destinationHost)
        {
            _types = new Dictionary<string, IType>();
            _plc = new PLCProxy(destinationHost);
            _plc.Open();
            Console.WriteLine("Conexão com CLP estabelecida com sucesso!");
        }

        public ProgrammingLogicController MapBitVariable(string tag,
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

        public ProgrammingLogicController SetValueByTag(string tag, object value)
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
