using SimplifiedSlotMachine.Cards;
using SimplifiedSlotMachine.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SimplifiedSlotMachine
{
    public class SlotMachine
    {
        private readonly IAccountManager _accountManager;
        private readonly IMessangerService _messangerService;
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly Card _card;
        private readonly int _numberOfSymbols;
        private readonly int _numberOfLines;

        public SlotMachine(IAccountManager accountManager, 
                            IMessangerService messangerService,
                            IRandomNumberGenerator randomNumberGenerator,
                            Card card,
                            int numberOfSymbols, 
                            int numberOfLines)
        {
            this._accountManager = accountManager;
            this._messangerService = messangerService;
            this._numberOfSymbols = numberOfSymbols;
            this._numberOfLines = numberOfLines;
            this._randomNumberGenerator = randomNumberGenerator;
            this._card = card;
        }

        public void DepositIntoAccount()
        {
            while (true)
            {
                if (this._accountManager.Deposit(this._messangerService.AskForDeposit()))
                {
                    break;
                }
                else
                {
                    this._messangerService.SendInvalidAmountMessage();
                }
            }
        }

        public void StartGame() 
        {
            var balance = this._accountManager.GetBalance();

            while (balance  > Constants.ZERO_DOUBLE_VALUE)
            {
                var stake = this._messangerService.AskForStake();

                if (stake <= Constants.ZERO_DOUBLE_VALUE ||
                    stake > balance)
                {
                    this._messangerService.SendInvalidAmountMessage();
                }
                else
                {
                    RunSlots(stake);
                    this._messangerService.SendCurrentBalanceMessage(this._accountManager.GetBalance());
                }

                balance = this._accountManager.GetBalance();
            }

            this._messangerService.SendGameOverMessage();
        }

        public void RunSlots(double stake)
        {
            this._accountManager.Withdraw(stake);
            var lines = this.GenerateLines();
            var coefficient = this.CalculateCoefficient(lines);

            foreach(var line in lines)
            {
                this._messangerService.SendLineMessage(line);
            }

            if (coefficient > Constants.ZERO_DOUBLE_VALUE)
            {
                this._accountManager.Deposit(coefficient * stake);
                this._messangerService.SendWinMessage(coefficient * stake);
            }
            else
            {
                this._messangerService.SendLostMessage();
            }
        }

        public double CalculateCoefficient(List<List<Card>> lines)
        {
            var coefficient = Constants.ZERO_DOUBLE_VALUE;

            foreach (var line in lines)
            {
                var notWildCards = line.Where(x => x is WildCard == false);

                if (notWildCards.All(x => x.Symbol == notWildCards.First().Symbol))
                {
                    coefficient += notWildCards.Sum(x => x.Coeficient);
                }
            }

            return coefficient;
        }

        public List<List<Card>> GenerateLines()
        {
            var lines = new List<List<Card>>();

            for (int i = 0; i < this._numberOfLines; i++)
            {
                lines.Add(this.GenerateSingleLine());
            }

            return lines;
        }

        public List<Card> GenerateSingleLine()
        {
            var line = new List<Card>();
            var chance = 0;

            for (int i = 0; i < this._numberOfSymbols; i++)
            {
                chance = this._randomNumberGenerator.GetRandomPercentage();

                this._card.ShowCard(line, chance);
            }

            return line;
        }
    }
}
