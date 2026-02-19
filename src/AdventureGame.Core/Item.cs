namespace AdventureGame.Core;

//Along with Pickup, it has a Name attribute since every item needs a name for the pickup method
public abstract class Item
{
    public abstract void Pickup();

    public string Name {get; protected set;}
}
