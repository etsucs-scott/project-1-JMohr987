namespace AdventureGame.Core;

public class Weapon : Item
{
    public Weapon(string n, int d)
    {
        Name = n;
        Damage = d;
    }

    public override void Pickup()
    {
        Console.WriteLine($"You got {Name}");
    }

    public int Damage {get; private set;}

}
