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
        for (int i = 0; i <= 41; i ++)
        {
            Console.WriteLine((_deckPiles).DrawCards(2));
        }

        foreach (var player in _players)
        {
            Console.WriteLine($"{player.Name} has {player.Chips} chips.");
        }

        return false;
    }
}