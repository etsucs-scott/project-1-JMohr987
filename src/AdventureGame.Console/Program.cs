AdventureGame.Core.Player p1 = new AdventureGame.Core.Player();
AdventureGame.Core.Maze m = new AdventureGame.Core.Maze();
AdventureGame.Core.Gameplay g = new AdventureGame.Core.Gameplay(ref m, ref p1);

m.Generate();
m.PrintMaze();
Console.WriteLine($"Health: {p1.Health}");
Console.WriteLine($"Potions: {p1.potionList.Count}");

bool go = true;
while (go)
{
   g.MovePlayer(); 
   go = g.HandleSpace();
   Console.Clear();
   m.PrintMaze();
   Console.WriteLine($"Health: {p1.Health}");
   Console.WriteLine($"Potions: {p1.potionList.Count}");
}

if (p1.Health > 0)
{
    Console.WriteLine("You Win!");
}
else
{
    Console.WriteLine("Game Over...");
}
return 0;


