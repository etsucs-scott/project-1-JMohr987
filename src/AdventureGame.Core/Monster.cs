namespace AdventureGame.Core;

public class Monster : ICharacter
{

    //Uses random number to get the range of health
    public Monster()
    {
        Random random = new Random();
        Health = random.Next(30, 50);
    }

    public void Attack(ICharacter enemy)
    {

        Console.WriteLine($"Monster attacks for {damage} damage!");
        enemy.TakeDamage(damage);
    }

    public void TakeDamage(int d)
    {
        Health -= d;
        Console.WriteLine($"Monster has {Health} health remaining!");
        Console.ReadKey(); //This read key, also seen in Player class, makes battles flow smoother
    }

    public int Health {get; private set;}

    //This never changes, so it's private;
    private int damage = 10;

}

