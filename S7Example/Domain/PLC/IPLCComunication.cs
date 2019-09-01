namespace S7Example.Domain.PLC
{
    public interface IPLCComunication
    {
        void Write(string address, object value);
        object Read(string address);
        void Close();
        void Open();
    }
}
