namespace SimplifiedSlotMachine.Cards
{
    public class AppleCard : Card
    {
        public AppleCard(Card nextCard) : base(nextCard)
        {
            this.Symbol = 'A';
            this.Coeficient = 0.4;
            this._probabilityLowLimit = 55;
            this._probabilityHighLimit = 100;
        }
    }
}
