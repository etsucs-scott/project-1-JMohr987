namespace AdventureGame.Core;

public class Player : ICharacter
{
    public Player()
    {
        Health = 100;
        weaponList = new List<Weapon>();
        potionList = new List<Potion>();
        Damage = 10;
    }
    public void Attack(ICharacter enemy)
    {
        if(weaponList.Count == 0)
        {
            Console.WriteLine($"Player attacks for {Damage} damage!");
            enemy.TakeDamage(Damage);
            return;
        }

        Console.WriteLine($"Player attacks for {Damage + weaponList[weaponList.Count - 1].Damage} damage!");
        enemy.TakeDamage(Damage + weaponList[weaponList.Count - 1].Damage);
    }

    public void TakeDamage(int d)
    {
            Health -= d;
            Console.WriteLine($"Player has {Health} health remaining!");
            Console.ReadKey();
    }

    public void PickupItem(Weapon w)
    {
        if (weaponList.Count == 0)
        {
            weaponList.Add(w);
            w.Pickup();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }
        
        if (w.Damage > weaponList[weaponList.Count - 1].Damage)
        {
            weaponList.Add(w);
            w.Pickup();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }
        
        weaponList.Insert(0, w);
        w.Pickup();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }



    public void PickupItem(Potion p)
    {
        potionList.Add(p);
        p.Pickup();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void TakePotion()
    {
        if (potionList.Count > 0)
        {
            Console.WriteLine("You drank a potion! Health +20!");
            Health += 20;
            potionList.RemoveAt(potionList.Count - 1);

            if (Health > 150)
            {
                Health = 150;
            }
            return;
        }
        Console.WriteLine("No Potions to drink!");
    }

    public List<Weapon> weaponList;

    public List<Potion> potionList;

    public int Health { get; private set; }

    public int Damage {get; private set;}

    private const int MaxHealth = 150;
}
