namespace SimplifiedSlotMachine.Cards
{
    public class BananaCard : Card
    {
        public BananaCard(Card nextCard) : base(nextCard)
        {
            this.Symbol = 'B';
            this.Coeficient = 0.6;
            this._probabilityLowLimit = 20;
            this._probabilityHighLimit = 55;
        }
    }
}
