namespace AdventureGame.Core;

public class Monster : ICharacter
{

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
        Console.ReadKey();
    }

    public int Health {get; private set;}

    private int damage = 10;

}

