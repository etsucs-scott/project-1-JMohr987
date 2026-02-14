AdventureGame.Core.Player p1 = new AdventureGame.Core.Player();
AdventureGame.Core.Player p2 = new AdventureGame.Core.Player();

Console.WriteLine($"Before attack {p2.Health}");

p1.Attack(p2);

Console.WriteLine($"After attack {p2.Health}");

AdventureGame.Core.Weapon w1 = new AdventureGame.Core.Weapon("Axe", 2);

p1.PickupItem(w1);

Console.WriteLine($"wList count: {p1.weaponList.Count}");

AdventureGame.Core.Weapon w2 = new AdventureGame.Core.Weapon("Axe", 10);

p1.PickupItem(w2);

Console.WriteLine($"Before attack {p2.Health}");

p1.Attack(p2);

Console.WriteLine($"After attack {p2.Health}");


AdventureGame.Core.Weapon w3 = new AdventureGame.Core.Weapon("Axe", 5);

p1.PickupItem(w3);

Console.WriteLine($"Before attack {p2.Health}");

p1.Attack(p2);

Console.WriteLine($"After attack {p2.Health}");


AdventureGame.Core.Monster m = new AdventureGame.Core.Monster();

Console.WriteLine($"M health: {m.Health}");

p1.Attack(m);
m.Attack(p2);
Console.WriteLine($"M health: {m.Health}");
Console.WriteLine($"After attack {p2.Health}");

p2.TakePotion();
Console.WriteLine($"After potion {p2.Health}");

