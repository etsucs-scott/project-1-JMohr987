namespace AdventureGame.Core;

public class Player : ICharacter
{
    //Has a seperate list for weapons and potions to make checking for both easier
    //Sets the defaults for the health and damage. Not const because this may change in a bigger rendition of the game
    public Player()
    {
        Health = 100;
        weaponList = new List<Weapon>();
        potionList = new List<Potion>();
        Damage = 10;
    }

    public void Attack(ICharacter enemy)
    {
        //Will break if trys to access an empty list
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
            Console.ReadKey(); //Makes combat smoother, also seen in monster class
    }

    //Picking up a weapon puts it in the back of the list if it has the highest modifier
    //THis allows for O(1) comparisons when picking up a new weapon and O(1) access to it for attacking
    //This does make the pickup take longer, but that is less important than speed when attack, and only O(n)
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


    //Since all potions heal the same amount, just pushes it to the back
    public void PickupItem(Potion p)
    {
        potionList.Add(p);
        p.Pickup();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    //Similar to picking up a potion
    //Since all potions heal the same, drinking the one at the back has the least amount of time complexity O(1)
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
