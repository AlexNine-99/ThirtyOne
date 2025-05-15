using ThirtyOne.Src.Actors;

namespace ThirtyOne.Src;

internal class Game
{
    private readonly List<Player> _players;
    private readonly Deck _deck = new();
    private Player _currentPlayer;
    private Player? _knocker;

    public Game()
    {
        _players = [new("Player1"), new("Player2"), new("Player3")];
        _currentPlayer = _players[0];
    }

    public void Start()
    {
        for (int i = 0; i < 3 * _players.Count; i ++)
        {
            _players[i % _players.Count].Cards.Add(_deck.Draw());
        }
        foreach (var player in _players)
        {
            var cardsStr = "";
            foreach (var card in player.Cards)
            {
                cardsStr += $"{card}";
                if (player.Cards.IndexOf(card) != player.Cards.Count - 1)
                {
                    cardsStr += ", ";
                }
            }
            Console.WriteLine($"{player.Name}: {cardsStr}");
        }
        while (Progress());
    }

    private bool Progress()
    {
        return false;
    }
}