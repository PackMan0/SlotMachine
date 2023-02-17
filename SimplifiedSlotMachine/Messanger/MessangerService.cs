using SimplifiedSlotMachine.Cards;
using SimplifiedSlotMachine.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SimplifiedSlotMachine.Messanger
{
    public class MessangerService : IMessangerService
    {
        private readonly IMessanger _messanger;

        public MessangerService(IMessanger messanger)
        {
            _messanger = messanger;
        }

        public double AskForDeposit()
        {
            _messanger.SendMessage("Please deposit money you would like to play with:");

            return _messanger.ReceiveMessage(); ;
        }

        public double AskForStake()
        {
            _messanger.SendMessage("Enter stake amount:");

            return _messanger.ReceiveMessage(); ;
        }

        public void SendInvalidAmountMessage()
        {
            _messanger.SendMessage("Ivalid amount!");
        }

        public void SendCurrentBalanceMessage(double balance)
        {
            _messanger.SendMessage($"Current balane is {balance:N2}");
        }

        public void SendGameOverMessage()
        {
            _messanger.SendMessage("GAME OVER!");
        }

        public void SendWinMessage(double amount)
        {
            _messanger.SendMessage($"You have won: {amount:N2}");
        }

        public void SendLostMessage()
        {
            _messanger.SendMessage("You have lost!");
        }

        public void SendLineMessage(List<Card> line)
        {
            _messanger.SendMessage(string.Join(string.Empty, line.Select(x => x.Symbol)));
        }
    }
}
