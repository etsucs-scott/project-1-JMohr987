namespace AdventureGame.Core;

public class Potion : Item
{
    public Potion(string n, int h)
    {
        Name = n;
        Health = h;
    }

    public override void Pickup()
    {
        Console.WriteLine($"You got {Name}");
    }

    public int Health {get; private set;}

}
