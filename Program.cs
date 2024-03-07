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
        Console.WriteLine("\nPlayers will be marked as 'P' on the board. Items will be marked as 'H', 'X', 'S' and monsters will be marked as 'E'");
        Console.WriteLine("\nThe boss will be marked as 'B'");
        Console.WriteLine("\nItem marked as 'H' will be a health potion, which will be consumed when used");
        Console.WriteLine("\nItem marked as 'S' will be a stamina potion, which will be consumed when used. Stamina is used to preform special attacks");
        Console.WriteLine("\nItem marked as 'X' will be a weapon, which will be equipped when used");
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
        Creature enemy1 = GenerateCreature(2, 8, 30, 11, 'E');
        Creature enemy2 = GenerateCreature(2, 5, 30, 15, 'E');
        Creature enemy3 = GenerateCreature(2, 7, 30, 11, 'E');
        Creature enemy4 = GenerateCreature(2, 5, 30, 11, 'E');
        Creature enemyBoss = GenerateCreature(1, 12, 50, 20, 'B');



        Sword sword1 = GenerateSword(5, "Excalibur", 'X');
        HealthPotion healthPotion1 = GenerateHealthPotion(25, "HealthPotion", 'H');
        HealthPotion healthPotion2 = GenerateHealthPotion(25, "HealthPotion", 'H');
        StaminaPotion staminaPotion1 = GenerateStaminaPotion(15, "StaminaPotion", 'S');

        // Items item1 = GenerateItems("Staff");
        // Items item2 = GenerateItems("Sword");

        // Entity[] entities = { player1, enemy1, enemy2, item1, item2 };

        Entity[] entities = { player1, enemy1, enemy2, enemy3, enemy4, enemyBoss, sword1, healthPotion1, healthPotion2, staminaPotion1, };

        AddEntityToGameBoard(player1);
        AddEntityToGameBoard(enemy1);
        AddEntityToGameBoard(enemy2);
        AddEntityToGameBoard(enemy3);
        AddEntityToGameBoard(enemy4);
        AddEntityToGameBoard(enemyBoss);


        AddEntityToGameBoard(sword1);
        AddEntityToGameBoard(healthPotion1);
        AddEntityToGameBoard(healthPotion2);
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

            if (ConsoleKey.C == keyinfo.Key)
            {
                Console.WriteLine("Enter the index of the item you want to use");
                int index = int.Parse(Console.ReadLine()) - 1;
                player1.ConsumeItem(index);
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

    static Creature GenerateCreature(int speed, int strength, int health, int stamina, char symbol)
    {
        int x = GenerateRandomXLocation();
        int y = GenerateRandomYLocation();
        return new Creature(x, y, speed, strength, health, stamina, symbol);
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
        Console.Clear();
        Console.WriteLine("-------------------*****-------------------");
        Console.WriteLine("Move with the arrow keys");
        Console.WriteLine("\nPress 'I' to see your inventory");
        Console.WriteLine("\nPress 'C' to consume an item");
        Console.WriteLine("-------------------*****-------------------");
        Console.WriteLine("");

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