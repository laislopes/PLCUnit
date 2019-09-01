namespace S7Example.Domain.Types
{
    public interface IType
    {
        string Symbol { get; }
        string Value { get; }
        void SetValue(object value);
    }
}
