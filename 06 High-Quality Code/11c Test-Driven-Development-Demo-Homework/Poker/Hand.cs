namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Hand : IHand
    {
        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var card in this.Cards)
            {
                result.Append(card.ToString());
                result.Append(' ');
            }

            return result.ToString().Trim();
        }
    }
}
