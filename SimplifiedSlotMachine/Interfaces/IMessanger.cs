namespace SimplifiedSlotMachine.Interfaces
{
    public interface IMessanger
    {
        double ReceiveMessage();
        void SendMessage(string message);
    }
}