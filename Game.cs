using ThirtyOne.Actors;

namespace ThirtyOne;

internal class Game
{
    private readonly List<Player> _players;
    private readonly DeckPiles _deckPiles = new();
    private Player _currentPlayer;
    private Player? _knocker;

    public Game()
    {
        _players = [new("Alex"), new("Ben"), new("Person3")];
        _currentPlayer = _players[0];
    }

    public void Start()
    {
        while (Progress());
    }

    private bool Progress()
    {
        DrawTest();
        foreach (var player in _players)
        {
            _deckPiles.Discard(player.Cards);
        }
        DrawTest();
        return false;
    }

    private void DrawTest()
    {
        for (int i = 0; i < 52; i++)
        {
            var card = _deckPiles.Draw();

            var player = _players[i % _players.Count];
            player.Cards.Add(card);
            Console.WriteLine($"{player.Name} drew {card}");
        }
    }
}