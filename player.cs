namespace classes;

class Player : Creature
{
    // private List<Items> backPack;
    public Player(int x, int y, int speed, int strength, int health, int stamina, char symbol) : base(x, y, speed, strength, health, stamina, symbol)
    {
        // backPack = new List<Items>();
    }
    public override void Interact(Entity otherEntity)
    {
    }

    public void HandleMovement(ConsoleKey key, char[,] gameBoard, Entity[] entities)
    {
        int newX = x;
        int newY = y;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                newX--;
                break;
            case ConsoleKey.DownArrow:
                newX++;
                break;
            case ConsoleKey.LeftArrow:
                newY--;
                break;
            case ConsoleKey.RightArrow:
                newY++;
                break;
            default:
                return;
        }
        try
        {
            if (newX < 0 || newX >= gameBoard.GetLength(0) || newY < 0 || newY >= gameBoard.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("Cannot move outside the bounds of the game board.");
            }

            foreach (Entity entity in entities)
            {

                if (entity is Items && entity.x == newX && entity.y == newY)
                {
                    AddToBackpack((Items)entity);
                    break;
                }
            }

            gameBoard[x, y] = '\0';
            x = newX;
            y = newY;
            gameBoard[x, y] = symbol;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public void AddToBackpack(Items item)
    {
        Program.backPack.Add(item);
        Console.WriteLine("You collected a item.");
    }
}