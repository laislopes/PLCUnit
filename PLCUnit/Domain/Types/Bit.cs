using PLC.Domain.PLC;
using System;

namespace PLC.Domain.Types
{
    /// <summary>
    /// The <c>Bit</c> is a <paramref name="IType"/> concret implementation.
    /// </summary>
    /// <remarks>
    /// This class defines the Symbol, Reading and Writing of a Bit variable.
    /// </remarks>
    public class Bit : IType
    {
        public string Symbol => "X";


        private readonly IPLCCommunication _pLCComunication;
        private readonly int _dbNumber;
        private readonly int _byteNumber;
        private readonly int _bitNumber;

        /// <summary>
        /// Constructor of the Bit Class.
        /// </summary>
        /// <param name="pLCComunication">PLCCommunication Interface</param>
        /// <param name="dbNumber">PLC Data Block number</param>
        /// <param name="byteNumber">PLC Data Block Byte number</param>
        /// <param name="bitNumber">PLC Data Block Bit number</param>
        public Bit(IPLCCommunication pLCComunication,
                    int dbNumber,
                    int byteNumber,
                    int bitNumber)
        {
            _pLCComunication = pLCComunication;
            _dbNumber = dbNumber;
            _byteNumber = byteNumber;
            _bitNumber = bitNumber;
        }

        /// <summary>
        /// Defines the Reading of a Bit variable.
        /// </summary>
        public string Value => _pLCComunication.Read($"DB{_dbNumber}.DB{Symbol}{_byteNumber}.{_bitNumber}").ToString();

        /// <summary>
        /// Defines the Writing of a Bit variable.
        /// </summary>
        /// <param name="value">The variable value</param>
        public void SetValue(object value)
        {
            if (!value.GetType().Equals(typeof(bool)))
                throw new ApplicationException("The informed type is not a bool");
            _pLCComunication.Write($"DB{_dbNumber}.DB{Symbol}{_byteNumber}.{_bitNumber}", (bool)value);

        }
    }
}
