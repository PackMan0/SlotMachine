using SimplifiedSlotMachine.Cards;
using SimplifiedSlotMachine.Messanger;
using System;

namespace SimplifiedSlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var consoleMessanger = new ConsoleMessanger();
            var messangerService = new MessangerService(consoleMessanger);
            var numberGenerator = new RandomNumberGenerator();
            var accountMananger = new AccountManager();
            var appleCard = new AppleCard(null);
            var bananaCard = new BananaCard(appleCard);
            var pineappleCard = new PineappleCard(bananaCard);
            var wildCard = new WildCard(pineappleCard);
            var slotMachine = new SlotMachine(accountMananger,
                                                messangerService,
                                                numberGenerator,
                                                wildCard,
                                                Constants.NUMBER_OF_SLOT_SYMBOLS,
                                                Constants.NUMBER_OF_SLOT_LINES);

            slotMachine.DepositIntoAccount();

            slotMachine.StartGame();
        }
    }
}
