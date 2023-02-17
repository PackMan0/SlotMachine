namespace SimplifiedSlotMachine.Cards
{
    public class PineappleCard : Card
    { 
        public PineappleCard(Card nextCard) : base(nextCard)
        {
            this.Symbol = 'P';
            this.Coeficient = 0.0;
            this._probabilityLowLimit = 5;
            this._probabilityHighLimit = 20;
        }
    }
}
