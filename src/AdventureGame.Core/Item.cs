namespace AdventureGame.Core;

public abstract class Item
{
    public abstract void Pickup();

    public string Name {get; protected set;}
}
