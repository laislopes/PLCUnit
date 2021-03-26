using PLC.Domain.PLC;
using PLC.Domain.Types;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PLC.Domain
{
    /// <summary>
    /// The <c>ProgrammableLogicController</c> is the main class of PLCUnit.
    /// </summary>
    /// <remarks>
    /// This class estabilishes the communication with PLC, maps, writes and reads variables.
    /// </remarks>
    public class ProgrammableLogicController : IDisposable
    {
        private readonly IPLCCommunication _plc;
        private readonly IDictionary<string, IType> _types;

        /// <summary>
        /// Opens the communication with PLC and initializes the <paramref name="_types"/> variables list.
        /// </summary>
        /// <param name="pLcCommunication">An unique name to the variable</param>
        public ProgrammableLogicController(IPLCCommunication pLcCommunication)
        {
            _types = new Dictionary<string, IType>();
            _plc = pLcCommunication;
            _plc.Open();
            Console.WriteLine("Conexão com CLP estabelecida com sucesso!");
        }

        /// <summary>
        /// Maps variables of Bit type from PLC to PLCUnit.
        /// </summary>
        /// <param name="tag">An unique name to the variable</param>
        /// <param name="dbNumber">PLC Data Block number</param>
        /// <param name="byteNumber">PLC Data Block Byte number</param>
        /// <param name="bitNumber">PLC Data Block Bit number</param>
        public ProgrammableLogicController MapBitVariable(string tag,
                                                   int dbNumber,
                                                   int byteNumber,
                                                   int bitNumber)
        {

            _types.Add(tag, new Bit(_plc, dbNumber, byteNumber, bitNumber));
            return this;
        }

        /// <summary>
        /// Reads variable value from PLC.
        /// </summary>
        /// <param name="tag">An unique name to the variable</param>
        public string GetValueByTag(string tag)
        {
            var returnValue = _types[tag].Value;
            Console.WriteLine($"O dispositivo {tag} está {GetTextFromBoolean(returnValue)}");
            return returnValue;
        }

        /// <summary>
        /// Writes variable value in PLC.
        /// </summary>
        /// <param name="tag">An unique name to the variable</param>
        /// <param name="value">The variable value</param>
        public ProgrammableLogicController SetValueByTag(string tag, object value)
        {
            Console.WriteLine($"O dispositivo {tag} será {GetTextFromBoolean(value)}");
            _types[tag].SetValue(value);
            Thread.Sleep(50);
            return this;
        }

        /// <summary>
        /// Converts a boolean value to text.
        /// </summary>
        /// <param name="value">The boolean variable value</param>
        private string GetTextFromBoolean(object value)
        {
            return (Convert.ToBoolean(value) ? "Ligado" : "Desligado");
        }

        /// <summary>
        /// Closes the communication with PLC.
        /// </summary>
        public void Dispose()
        {

            _plc.Close();
            Console.WriteLine("Conexão com CLP encerrada com sucesso!");
        }
    }
}
