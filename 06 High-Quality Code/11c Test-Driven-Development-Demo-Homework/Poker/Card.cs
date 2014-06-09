namespace Poker
{
    using System;
    using System.Collections.Generic;
    using Poker.Enum;

    public class Card : ICard
    {
        public Card(CardFaceEnum face, CardSuitEnum suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFaceEnum Face { get; private set; }

        public CardSuitEnum Suit { get; private set; }

        public override string ToString()
        {
            var face = (int)this.Face;
            string faceAsString = face.ToString();
            if (face == 11)
            {
                faceAsString = "J";
            }
            else if (face == 12)
            {
                faceAsString = "Q";
            }
            else if (face == 13)
            {
                faceAsString = "K";
            }
            else if (face == 14)
            {
                faceAsString = "A";
            }

            string suit = string.Empty;
            switch ((int)this.Suit)
            {
                case 1:
                    suit = "♣";
                    break;
                case 2:
                    suit = "♦";
                    break;
                case 3:
                    suit = "♥";
                    break;
                case 4:
                    suit = "♠";
                    break;
            }

            return faceAsString + suit;

            // return this.Face.ToString() + " of " + ((char)this.Suit);
        }

        public override int GetHashCode()
        {
            return (((int)this.Face) * 10) + ((int)this.Suit);
        }

        public override bool Equals(object obj)
        {
            Card otherCard = obj as Card;
            if (otherCard == null)
            {
                return false;
            }

            return this.Face.Equals(otherCard.Face) &&
                   this.Suit.Equals(otherCard.Suit);
        }
    }
}
