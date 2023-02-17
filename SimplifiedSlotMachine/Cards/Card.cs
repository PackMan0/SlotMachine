using System.Collections.Generic;

namespace SimplifiedSlotMachine.Cards
{
    public abstract class Card
    {
        public char Symbol { get; protected set; }
        public double Coeficient { get; protected set; }

        protected readonly Card _nextCard;
        protected int _probabilityLowLimit;
        protected int _probabilityHighLimit;

        protected Card(Card nextCard) 
        {
            this._nextCard = nextCard;
        }

        public List<Card> ShowCard(List<Card> line, int chance)
        {

            if (chance > this._probabilityLowLimit &&
                chance <= this._probabilityHighLimit)
            {
                line.Add(this);
                return line;
            }
            else
            {
                return this._nextCard == null ? line : this._nextCard.ShowCard(line, chance);
            }
        }
    }
}
