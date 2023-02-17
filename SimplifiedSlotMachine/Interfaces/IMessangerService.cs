using SimplifiedSlotMachine.Cards;
using System.Collections.Generic;

namespace SimplifiedSlotMachine.Interfaces
{
    public interface IMessangerService
    {
        double AskForDeposit();
        double AskForStake();
        void SendCurrentBalanceMessage(double balance);
        void SendGameOverMessage();
        void SendInvalidAmountMessage();
        void SendLostMessage();
        void SendWinMessage(double amount);
        void SendLineMessage(List<Card> line);
    }
}