using PLC.Domain.PLC;
using System;

namespace PLC.Domain.Types
{
    class Word : IType
    {
        private readonly IPLCCommunication _pLCComunication;
        private readonly int _dbNumber;
        private readonly int _wordNumber;

        public Word(IPLCCommunication pLCComunication,
                    int dbNumber,
                    int wordNumber)
        {
            _pLCComunication = pLCComunication;
            _dbNumber = dbNumber;
            _wordNumber = wordNumber;
        }
        public string Symbol => "W";

        public string Value => (string)_pLCComunication.Read($"DB{_dbNumber}.DB{Symbol}{_wordNumber}");

        public void SetValue(object value)
        {
            if (!value.GetType().Equals(typeof(string)))
                throw new ApplicationException("The informed type is not a string");
            _pLCComunication.Write($"DB{_dbNumber}.DB{Symbol}{_wordNumber}", value);
            
        }
    }
}
