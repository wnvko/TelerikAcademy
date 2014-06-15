using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        private IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards
        {
            get
            {
                return this.cards;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Cards list cannot be null");
                }
                if (value.Count <= 0)
                {
                    throw new ArgumentOutOfRangeException("Cards in hand cannot be zero or less.");
                }

                this.cards = value;
            }
        }

        public override string ToString()
        {
            StringBuilder cardsToString = new StringBuilder();
            foreach (var card in this.Cards)
            {
                cardsToString.Append(card.ToString());
                cardsToString.Append(string.Empty);
            }

            return cardsToString.ToString().TrimEnd();
        }
    }
}