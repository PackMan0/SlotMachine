namespace SimplifiedSlotMachine.Cards
{
    public class WildCard : Card
    {
        public WildCard(Card nextCard) : base(nextCard)
        {
            this.Symbol = '*';
            this.Coeficient = 0.0;
            this._probabilityLowLimit = 0;
            this._probabilityHighLimit = 5;
        }
    }
}
