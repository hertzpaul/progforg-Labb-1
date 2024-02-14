using classes;

class Program
{
    static char[,] gameBoard = new char[12, 22];
    static void Main(string[] args)
    {
        bool inMainMenu = true;

        do
        {
            Console.Clear();
            Console.WriteLine("---------------*****---------------");
            Console.WriteLine("Welcome to SalesAdventure3000!");
            Console.WriteLine("---------------*****---------------");
            Console.WriteLine("\nPress '1' to start the game\nPress '2' to read the game info and instructions\nPress 'Escape' to quit the game");
            
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch(keyInfo.KeyChar)
            {
                case '1':
                inMainMenu = false;
                StartGame();
                break;
                case '2':
                GameInfo();
                break;
                case (char)ConsoleKey.Escape:
                Environment.Exit(0);
                break;
                default:
                Console.WriteLine("Invalid input");
                break;
            }

        }while (inMainMenu);

    }
    static void GameInfo()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------------------------------*******---------------------------------------------------------------");
        Console.WriteLine("\nSo you chose to be a pleb and read the gameinfo");
        Console.WriteLine("\nThis game is a combat game where you as a player will need to pickup items in order to challenge various monsters on the board");
        Console.WriteLine("\nPlayers will be marked as 'P' on the board. Items will be marked as 'I' and monsters will be marked as 'E'");
        Console.WriteLine("\nTo pickup items you will need to stand on the same position as the item");
        Console.WriteLine("\nSome items will be needed to equipped and some will be consumed on use.");
        Console.WriteLine("\nTo challenge and fight monsters you will need to stand in the same spot as the monster to initiate combat");
        Console.WriteLine("\nTo move around the board you will use Arrow keys");
        Console.WriteLine("----------------------------------------------------------------*******---------------------------------------------------------------");
        Console.WriteLine("\nPress 'Enter' to return to Main Menu");
        Console.ReadLine();
    }

    static void StartGame()
    {
        Player player1 = new Player(0, 0, 2, 4, 10, 50, 'P');
        Creature enemy1 = new Creature(10, 16, 2, 15, 30, 10, 'E');
        Creature enemy2 = new Creature(7, 18, 2, 15, 20, 10, 'E');
        Items item1 = new Items(7, 6, 'I');
        Items item2 = new Items(2, 14, 'I');

        Entity[] entities = {player1, enemy1, enemy2, item1, item2};

        AddEntityToGameBoard(player1);
        AddEntityToGameBoard(enemy1);
        AddEntityToGameBoard(enemy2);
        AddEntityToGameBoard(item1);
        AddEntityToGameBoard(item2);

        enemy1.Interact(player1);
        item1.Interact(player1);

        DrawGameBoard();

        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);
            player1.HandleMovement(keyInfo.Key, gameBoard, entities);
            DrawGameBoard();
        } while (keyInfo.Key != ConsoleKey.Escape);
    }

    static void AddEntityToGameBoard(Entity entity)
    {
        gameBoard[entity.x, entity.y] = entity.symbol;
    }

    static void DrawGameBoard()
    {
        Console.Clear();
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                if (gameBoard[i, j] == '\0')
                {
                    Console.Write("- ");
                }
                else
                {
                    Console.Write(gameBoard[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}