using System;

namespace Poker
{
    public class Card : ICard
    {
        private CardFace face;
        private CardSuit suit;

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face
        {
            get
            {
                return this.face;
            }

            private set
            {
                this.face = value;
            }
        }
        public CardSuit Suit
        {
            get
            {
                return this.suit;
            }

            private set
            {
                this.suit = value;
            }
        }


        public override string ToString()
        {
            string cardName = this.Face.ToString() + " " + this.Suit.ToString();
            return cardName;
        }
    }
}