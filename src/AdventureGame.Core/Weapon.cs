namespace AdventureGame.Core;

public class Weapon : Item
{
    //Same as potion, damage in constructer to make weapons do different amounts of damage easily
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
