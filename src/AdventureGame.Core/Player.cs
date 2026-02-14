namespace AdventureGame.Core;

public class Player : ICharacter
{
    public Player()
    {
        Health = 100;
        weaponList = new List<Weapon>();
        potionList = new List<Potion>();
        potionList.Add(new Potion("Health Potion", 20));
    }
    public void Attack(ICharacter enemy)
    {
        if(weaponList.Count == 0)
        {
            enemy.TakeDamage(Damage);
            return;
        }

        enemy.TakeDamage(Damage + weaponList[weaponList.Count - 1].Damage);
    }

    public void TakeDamage(int d)
    {
            Health -= d;
    }

    public void PickupItem(Weapon w)
    {
        if (weaponList.Count == 0)
        {
            weaponList.Add(w);
            w.Pickup();
            return;
        }
        
        if (w.Damage > weaponList[weaponList.Count - 1].Damage)
        {
            weaponList.Add(w);
            w.Pickup();
            return;
        }
        
        weaponList.Insert(0, w);
        w.Pickup();
    }

    public void PickupItem(Potion p)
    {
        potionList.Add(p);
    }

    public void TakePotion()
    {
        if (potionList.Count > 0)
        {
            Console.WriteLine("You drank a potion! Health +20!");
            Health += 20;
            potionList.RemoveAt(potionList.Count - 1);
            return;
        }
        Console.WriteLine("No Potions to drink!");
    }

    public List<Weapon> weaponList;

    public List<Potion> potionList;

    public int Health { get; private set; }

    private int Damage = 10;

    private const int MaxHealth = 150;
}
