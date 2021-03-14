using S7.Net;

namespace PLC.Domain.PLC
{
    /// <summary>
    /// The <c>PLCS71500</c> class is a S71500 CPU model concret implementation.
    /// </summary>
    /// <remarks>
    /// This class can configures <paramref name="ip"/>, rack and slot from S71500 CPU model.
    /// </remarks>
    public class PLCS71500 : Plc, IPLCCommunication
    {

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <remarks>
        /// Passes the <paramref name="ip"/> to base constructor from <c>Plc</c> class of S7 .Net library.
        /// </remarks>
        /// <param name="ip">IP of PLC in string format</param>
        public PLCS71500(string ip)
            : base(CpuType.S71500, ip, 0, 1)
        {
        }
    }
}


