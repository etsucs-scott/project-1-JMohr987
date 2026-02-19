namespace AdventureGame.Core;

//Health is part of the constructor to easily add potions that heal different amounts of damage
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
