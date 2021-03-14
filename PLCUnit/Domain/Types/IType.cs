namespace PLC.Domain.Types
{
    public interface IType
    {
        string Symbol { get; }
        string Value { get; }
        void SetValue(object value);
    }
}
