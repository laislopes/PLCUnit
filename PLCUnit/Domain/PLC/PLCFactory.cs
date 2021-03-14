using PLC.Domain.PLC;

namespace PLCUnit.Domain.PLC
{
    /// <summary>
    /// The <c>PLCFactory</c> class it's used to configure PLC CPU model and <paramref name="ip"/>.
    /// </summary>
    /// <remarks>
    /// This class can configures S71200 and S71500 CPU models.
    /// </remarks>
    public static class PLCFactory
    {
        /// <summary>
        /// Configures the PLC IP with a S71500 CPU model and returns the concret implementation.
        /// </summary>
        /// <returns>
        /// The <c>PLCS71500</c> class instance.
        /// </returns>
        /// <param name="ip">IP of PLC in string format</param>
        public static IPLCCommunication GetPLCS71500(string ip)
            => new PLCS71500(ip);
    }
}

