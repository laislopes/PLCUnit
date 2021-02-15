namespace PLC.Domain.PLC
{
    public interface IPLCCommunication
    {
        void Write(string address, object value);
        object Read(string address);
        void Close();
        void Open();
    }
}
