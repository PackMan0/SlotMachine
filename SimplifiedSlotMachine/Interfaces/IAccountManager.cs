namespace SimplifiedSlotMachine.Interfaces
{
    public interface IAccountManager
    {
        bool Deposit(double deposit);
        double GetBalance();
        double Withdraw(double amount);
    }
}