using PLC.Domain.PLC;
using System;

namespace PLC.Domain.Types
{
    /// <summary>
    /// The <c>Word</c> is a <paramref name="IType"/> concret implementation.
    /// </summary>
    /// <remarks>
    /// This class defines the Symbol, Reading and Writing of a Word variable.
    /// </remarks>
    class Word : IType
    {
        private readonly IPLCCommunication _pLCComunication;
        private readonly int _dbNumber;
        private readonly int _wordNumber;

        /// <summary>
        /// Constructor of the Word Class.
        /// </summary>
        /// <param name="pLCComunication">PLCCommunication Interface</param>
        /// <param name="dbNumber">PLC Data Block number</param>
        /// <param name="wordNumber">PLC Data Block Word number</param>
        public Word(IPLCCommunication pLCComunication,
                    int dbNumber,
                    int wordNumber)
        {
            _pLCComunication = pLCComunication;
            _dbNumber = dbNumber;
            _wordNumber = wordNumber;
        }
        public string Symbol => "W";

        /// <summary>
        /// Defines the Reading of a Word variable.
        /// </summary>
        public string Value => (string)_pLCComunication.Read($"DB{_dbNumber}.DB{Symbol}{_wordNumber}");

        /// <summary>
        /// Defines the Writing of a Word variable.
        /// </summary>
        /// <param name="value">The variable value</param>
        public void SetValue(object value)
        {
            if (!value.GetType().Equals(typeof(string)))
                throw new ApplicationException("The informed type is not a string");
            _pLCComunication.Write($"DB{_dbNumber}.DB{Symbol}{_wordNumber}", value);
            
        }
    }
}
