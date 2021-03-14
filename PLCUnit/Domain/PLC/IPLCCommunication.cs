namespace PLC.Domain.PLC
{
    /// <summary>
    /// The <c>IPLCCommunication</c> interface represents the basics PLC communication operations.
    /// </summary>
    /// <remarks>
    /// This interface defines the contract to Write, Read, Close and Open operations in communication with PLC.
    /// </remarks>
    public interface IPLCCommunication
    {
        /// <summary>
        /// Writes data into PLC.
        /// </summary>
        /// <param name="address">Variable absolute address of the PLC in string format</param>
        /// <param name="value">Variable value of the PLC in object type</param>
        void Write(string address, object value);

        /// <summary>
        /// Reads data from PLC.
        /// </summary>
        /// <param name="address">Variable absolute address of the PLC in string format</param>
        object Read(string address);

        /// <summary>
        /// Closes communication with PLC.
        /// </summary>
        void Close();


        /// <summary>
        /// Opens communication with PLC.
        /// </summary>
        void Open();
    }
}
