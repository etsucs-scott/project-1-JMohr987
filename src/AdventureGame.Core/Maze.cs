namespace AdventureGame.Core;

public class Maze
{
    //uses the TileType Enum (all types of space) for the maze as none of the objects need to be stored directly in the maze
    //This makes checking types of tiles much easier
    //Creates the walls in the constructor because walls are constant throughout generations.
    public Maze()
    {
        mazeArray = new TileType[MazeLength,MazeLength];
        rnd = new Random();

        for (int i = 0; i < MazeLength; i++)
        {
            mazeArray[0,i] = TileType.Wall;
        }
        for (int i = 1; i < MazeLength - 1; i++)
        {
            mazeArray[i,0] = TileType.Wall;
            mazeArray[i,MazeLength - 1] = TileType.Wall;
        }
        for (int i = 0; i < MazeLength; i++)
        {
            mazeArray[MazeLength - 1,i] = TileType.Wall;
        }

    }

    //Uses special functions to make each tile have different probablilites
    //Makes sure there is a proper amount of each tile
    public void Generate()
    {
        for (int i = 1; i < MazeLength - 1; i++)
        {
            for (int j = 1; j < MazeLength - 1; j++)
            {
                if (j == 1 || i == MazeLength - 2) // This allows for a path through the maze
                {
                    mazeArray[i,j] = NonWallRandom();
                }
                else
                {
                    mazeArray[i,j] = WallRandom();
                }
            }
        }
        mazeArray[1,1] = TileType.Player;
        mazeArray[10,10] = TileType.Exit;
    }

    //This random function guarentees the maze to be possible
    //Is called on tiles that are part of the guarenteed path to exit
    private TileType NonWallRandom()
    {
        int number = rnd.Next(0,100);

        if(number < 80)
        {
            return TileType.Empty;
        }
        else if (number >= 80 && number < 90)
        {
            return TileType.Monster;
        }
        else if (number >= 90 && number < 95)
        {
            return TileType.Weapon;
        }
        else
        {
            return TileType.Potion;
        }
    }

    //Randomly Generates tile types for the maze
    //Each has a different probablility to the maze makes sense
    //There should be more empty spaces than monsters!
    //Same as last other function but with walls
    private TileType WallRandom()
    {
        int number = rnd.Next(0,100);

        if(number < 50)
        {
            return TileType.Empty;
        }
        else if (number >= 50 && number < 80)
        {
            return TileType.Wall;
        }
        else if (number >= 80 && number < 90)
        {
            return TileType.Monster;
        }
        else if (number >= 90 && number < 95)
        {
            return TileType.Weapon;
        }
        else
        {
            return TileType.Potion;
        }
    }
    
    public void PrintMaze()
    {
        for (int i = 0; i < MazeLength; i++)
        {
            for (int j = 0; j < MazeLength; j++)
            {
                switch (mazeArray[i,j])
                {
                    case TileType.Player:
                        Console.Write("@");
                        break;
                    case TileType.Exit:
                        Console.Write("E");
                        break;
                    case TileType.Wall:
                        Console.Write("#");
                        break;
                    case TileType.Empty:
                        Console.Write(".");
                        break;
                    case TileType.Monster:
                        Console.Write("M");
                        break;
                    case TileType.Weapon:
                        Console.Write("W");
                        break;
                    case TileType.Potion:
                        Console.Write("P");
                        break;
                }
            }
            Console.WriteLine("");
        }
    }




    private Random rnd;
    public TileType[,] mazeArray;
    private const int MazeLength = 12;
}
