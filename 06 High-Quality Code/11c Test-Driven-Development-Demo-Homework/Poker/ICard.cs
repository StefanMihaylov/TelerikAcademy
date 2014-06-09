namespace Poker
{
    using Poker.Enum;

    public interface ICard
    {
        CardFaceEnum Face { get; }

        CardSuitEnum Suit { get; }

        string ToString();
    }
}
