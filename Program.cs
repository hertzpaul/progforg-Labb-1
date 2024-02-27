namespace classes;

class Program
{
    static char[,] gameBoard = new char[12, 22];
    static Random random = new Random();
    static public List<Items> backPack = new List<Items>();
    public enum AttackType
    {
        Normal,
        Special1,
        Special2

    }
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
            switch (keyInfo.KeyChar)
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
                case 'i':
                    inMainMenu = false;
                    ShowInventory(backPack);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

        } while (inMainMenu);

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
        Player player1 = GeneratePlayer(4, 10, 50, 20);
        Creature enemy1 = GenerateCreature(2, 8, 30, 11);
        Creature enemy2 = GenerateCreature(2, 5, 30, 15);
        Creature enemy3 = GenerateCreature(2, 7, 30, 11);
        Creature enemy4 = GenerateCreature(2, 5, 30, 11);


        Sword sword1 = GenerateSword(5, "Excalibur", 'I');
        HealthPotion healthPotion1 = GenerateHealthPotion(25, "HealthPotion", 'I');
        StaminaPotion staminaPotion1 = GenerateStaminaPotion(15, "StaminaPotion", 'I');

        // Items item1 = GenerateItems("Staff");
        // Items item2 = GenerateItems("Sword");

        // Entity[] entities = { player1, enemy1, enemy2, item1, item2 };

        Entity[] entities = { player1, enemy1, enemy2, sword1, healthPotion1, staminaPotion1, };

        AddEntityToGameBoard(player1);
        AddEntityToGameBoard(enemy1);
        AddEntityToGameBoard(enemy2);
        AddEntityToGameBoard(enemy3);
        AddEntityToGameBoard(enemy4);

        AddEntityToGameBoard(sword1);
        AddEntityToGameBoard(healthPotion1);
        AddEntityToGameBoard(staminaPotion1);
        // AddEntityToGameBoard(item1);
        // AddEntityToGameBoard(item2);

        enemy1.Interact(player1);
        
        // item1.Interact(player1);

        DrawGameBoard();


        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);
            player1.HandleMovement(keyInfo.Key, gameBoard, entities);
            DrawGameBoard();
            if (player1.Health <= 0)
            {
                Console.WriteLine("You died!");
                Console.WriteLine("Game Over! Press 'Enter' to return");
                Console.ReadLine();
                Environment.Exit(0);
            }

            ConsoleKeyInfo keyinfo = Console.ReadKey(true);
            if (keyinfo.Key == ConsoleKey.I)
            {
                ShowInventory(backPack);
            }

        } while (keyInfo.Key != ConsoleKey.Escape);

    }

    static void AddEntityToGameBoard(Entity entity)
    {
        gameBoard[entity.x, entity.y] = entity.symbol;
    }

    static int GenerateRandomXLocation()
    {
        return random.Next(12);
    }

    static int GenerateRandomYLocation()
    {
        return random.Next(22);
    }

    static Player GeneratePlayer(int speed, int strength, int health, int stamina)
    {
        int x = GenerateRandomXLocation();
        int y = GenerateRandomYLocation();
        return new Player(x, y, speed, strength, health, stamina, 'P');
    }

    static Creature GenerateCreature(int speed, int strength, int health, int stamina)
    {
        int x = GenerateRandomXLocation();
        int y = GenerateRandomYLocation();
        return new Creature(x, y, speed, strength, health, stamina, 'E');
    }

    static Items GenerateItems(string name)
    {
        int x = GenerateRandomXLocation();
        int y = GenerateRandomYLocation();
        return new Items(name, x, y, 'I');
    }

    static Sword GenerateSword(int swordDamage, string name, char symbol)
    {
        int x = GenerateRandomXLocation();
        int y = GenerateRandomYLocation();
        return new Sword(swordDamage, name, x, y, symbol);
    }

    static HealthPotion GenerateHealthPotion(int healingAmount, string name, char symbol)
    {
        int x = GenerateRandomXLocation();
        int y = GenerateRandomYLocation();
        return new HealthPotion(name, healingAmount, x, y, symbol);
    }

    static StaminaPotion GenerateStaminaPotion(int staminaRecoverAmount, string name, char symbol)
    {
        int x = GenerateRandomXLocation();
        int y = GenerateRandomYLocation();
        return new StaminaPotion(staminaRecoverAmount, name, x, y, symbol);
    }

    static void ShowInventory(List<Items> backPack)
    {
        Console.WriteLine("BackPack: ");
        int itemCount = backPack.Count();
        foreach (Items item in backPack)
        {
            Console.WriteLine("Item: " + item.Name);
        }
        Console.WriteLine("Total amount of items: " + itemCount);
    }

    static void DrawGameBoard()
    {
        //Console.Clear();

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