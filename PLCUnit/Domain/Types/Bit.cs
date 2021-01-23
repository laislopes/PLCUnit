﻿using PLC.Domain.PLC;
using System;

namespace PLC.Domain.Types
{
    public class Bit : IType
    {
        public string Symbol => "X";


        private readonly IPLCComunication _pLCComunication;
        private readonly int _dbNumber;
        private readonly int _byteNumber;
        private readonly int _bitNumber;

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
