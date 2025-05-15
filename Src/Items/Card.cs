namespace ThirtyOne.Src.Items;

internal record Card
{
    public int Rank { get; }
    public Suit Suit { get; }

    public Card(int rank, Suit suit)
    {
        if (rank < 1 || rank > 13)
        {
            throw new Exception($"Cannot create card with rank {rank}");
        }
        Rank = rank;
        Suit = suit;
    }

    public override string ToString()
    {
        string rankStr = Rank switch
        {
            1 => "A",
            11 => "J",
            12 => "Q",
            13 => "K",
            _ => Rank.ToString()
        };
        return $"{rankStr} of {Suit}";
    }
}
