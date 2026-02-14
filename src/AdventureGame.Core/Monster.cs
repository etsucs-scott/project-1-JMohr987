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
        enemy.TakeDamage(damage);
    }

    public void TakeDamage(int d)
    {
        Health -= d;
    }

    public int Health {get; private set;}

    private int damage = 10;

}

