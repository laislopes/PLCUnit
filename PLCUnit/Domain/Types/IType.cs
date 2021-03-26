namespace PLC.Domain.Types
{
    /// <summary>
    /// The <c>IType</c> Interface represents the Type of variable from PLC.
    /// </summary>
    /// <remarks>
    /// This interface defines the contract to Write, Read, Close and Open operations in communication with PLC.
    /// </remarks>
    public interface IType
    {
        /// <summary>
        /// Defines the Address Symbol of the variable from PLC.
        /// </summary>
        string Symbol { get; }

        /// <summary>
        /// Defines the Reading of the variable.
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Defines the Writing of the variable.
        /// </summary>
       /// <param name="value">The variable value</param>
        void SetValue(object value);
    }
}
