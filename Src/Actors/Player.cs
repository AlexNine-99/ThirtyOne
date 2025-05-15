using ThirtyOne.Src.Items;

namespace ThirtyOne.Src.Actors;

internal class Player(String name)
{
    public string Name = name;
    public int Chips = 3;
    public List<Card> Cards = [];
}
