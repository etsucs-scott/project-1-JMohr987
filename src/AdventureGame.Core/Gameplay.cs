namespace AdventureGame.Core;

public class Gameplay
{
    public Gameplay(ref Maze m, ref Player p)
    {
        maze = m;
        MainPlayer = p;
        PlayerX = 1;
        PlayerY = 1;
        rnd = new Random();
    }

    public void MovePlayer()
    {
        ConsoleKey key = Console.ReadKey().Key;
            
        switch (key)
        {
            case ConsoleKey.UpArrow:
                if(maze.mazeArray[PlayerY - 1, PlayerX] == TileType.Wall)
                {
                    return;
                }

                maze.mazeArray[PlayerY, PlayerX] = TileType.Empty;
                PlayerY -= 1;
                //maze.mazeArray[PlayerY, PlayerX] = TileType.Player;
                return;
            case ConsoleKey.DownArrow:
                if(maze.mazeArray[PlayerY + 1, PlayerX] == TileType.Wall)
                {
                    return;
                }

                maze.mazeArray[PlayerY, PlayerX] = TileType.Empty;
                PlayerY += 1;
                //maze.mazeArray[PlayerY, PlayerX] = TileType.Player;
                return;
            case ConsoleKey.RightArrow:
                if(maze.mazeArray[PlayerY, PlayerX + 1] == TileType.Wall)
                {
                    return;
                }

                maze.mazeArray[PlayerY, PlayerX] = TileType.Empty;
                PlayerX += 1;
                //maze.mazeArray[PlayerY, PlayerX] = TileType.Player;
                return;
            case ConsoleKey.LeftArrow:
                if(maze.mazeArray[PlayerY, PlayerX - 1] == TileType.Wall)
                {
                    return;
                }

                maze.mazeArray[PlayerY, PlayerX] = TileType.Empty;
                PlayerX -= 1;
                //maze.mazeArray[PlayerY, PlayerX] = TileType.Player;
                return;
            case ConsoleKey.Z:
                MainPlayer.TakePotion();
                return;
        }
    }

    public bool HandleSpace()
    {
        switch (maze.mazeArray[PlayerY,PlayerX])
        {
            case TileType.Potion:
                MainPlayer.PickupItem(new Potion("Health Potion", 20)); 
                maze.mazeArray[PlayerY, PlayerX] = TileType.Player;
                break;
            case TileType.Weapon:
                int number = rnd.Next(0,3); 
                switch (number)
                {
                    case 0:
                        MainPlayer.PickupItem(new Weapon("Axe", rnd.Next(1,21))); 
                        break;
                    case 1:
                        MainPlayer.PickupItem(new Weapon("Spear", rnd.Next(1,21))); 
                        break;
                    case 2:
                        MainPlayer.PickupItem(new Weapon("Sword", rnd.Next(1,21))); 
                        break;

                break;
                }
                maze.mazeArray[PlayerY, PlayerX] = TileType.Player;
                break;
            case TileType.Monster:
                bool isWin = Battle();
                if (isWin)
                {
                    maze.mazeArray[PlayerY, PlayerX] = TileType.Player;
                }
                return isWin;
            case TileType.Empty:
                maze.mazeArray[PlayerY, PlayerX] = TileType.Player;
                break;
            case TileType.Exit:
                return false;
        }
        return true;
    }

    public bool Battle()
    {
        Monster monster = new Monster();
        while (true)
        {
            MainPlayer.Attack(monster);
            if(monster.Health <= 0)
            {
                Console.WriteLine("You Win!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return true;
            }

            monster.Attack(MainPlayer);
            if(MainPlayer.Health <= 0)
            {
                Console.WriteLine("You Lose...");
                Console.WriteLine("Press any key to continue...");
                return false;
            }
        }
    }



        

    public Maze maze;
    public int PlayerX;
    public int PlayerY;
    public Player MainPlayer {get; private set;}
    private Random rnd;

}
