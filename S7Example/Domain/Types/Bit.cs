using S7Example.Domain.PLC;
using System;

namespace S7Example.Domain.Types
{
    public class Bit : IType
    {
        public string Symbol => "X";


        private IPLCComunication _pLCComunication;
        private int _dbNumber;
        private int _byteNumber;
        private int _bitNumber;

        public Bit(IPLCComunication pLCComunication,
                    int dbNumber,
                    int byteNumber,
                    int bitNumber)
        {
            _pLCComunication = pLCComunication;
            _dbNumber = dbNumber;
            _byteNumber = byteNumber;
            _bitNumber = bitNumber;
        }

        public string Value => _pLCComunication.Read($"DB{_dbNumber}.DB{Symbol}{_byteNumber}.{_bitNumber}").ToString();

        public void SetValue(object value)
        {
            if (!value.GetType().Equals(typeof(bool)))
                throw new ApplicationException("The informed type is not a bool");
            _pLCComunication.Write($"DB{_dbNumber}.DB{Symbol}{_byteNumber}.{_bitNumber}", (bool)value);

        }
    }
}
