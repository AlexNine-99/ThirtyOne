using ThirtyOne.Items;

namespace ThirtyOne.Actors;

internal class DeckPiles
{
    private List<Card> _drawPile = [];
    private List<Card> _discardPile = [];
    private readonly Random _rng = new();

    public DeckPiles()
    {
        Init();
        Shuffle();
    }

    private void Init()
    {
        ReadOnlySpan<Suit> suits = [Suit.Hearts, Suit.Clubs, Suit.Diamonds, Suit.Spades];
        foreach (var suit in suits)
        {
            for (int rank = 1; rank <= 13; rank++)
            {
                _drawPile.Add(new(rank, suit));
            }
        }
        Shuffle();
        _discardPile.Add(Draw());
    }

    public void Shuffle()
    {
        for (int i = _drawPile.Count - 1; i > 0; i--)
        {
            int j = _rng.Next(i + 1);
            (_drawPile[i], _drawPile[j]) = (_drawPile[j], _drawPile[i]);
        }
    }

    public Card Draw()
    {
        if (_drawPile.Count == 0)
        {
            if (_discardPile.Count == 0)
            {
                throw new Exception("No cards left in the deck.");
            }
            (_drawPile, _discardPile) = (_discardPile, _drawPile);
            Shuffle();
        }
        var card = _drawPile[0];
        _drawPile.RemoveAt(0);
        return card;
    }

    public void Discard(Card card)
    {
        _discardPile.Add(card);
    }

    public void Discard(List<Card> cards)
    {
        _discardPile.AddRange(cards);
    }
}