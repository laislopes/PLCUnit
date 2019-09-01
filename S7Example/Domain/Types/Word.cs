using S7Example.Domain.PLC;
using System;

namespace S7Example.Domain.Types
{
    class Word : IType
    {
        private IPLCComunication _pLCComunication;
        private int _dbNumber;
        private int _wordNumber;

        public Word(IPLCComunication pLCComunication,
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
