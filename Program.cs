namespace classes;

class Program
{
    //Deklaration av spelplanen, slumpgenerator och ryggsäcken
    static char[,] gameBoard = new char[12, 22];
    static Random random = new Random();
    static public List<Items> backPack = new List<Items>();

    //Enmum för olika attacktyper
    public enum AttackType
    {
        Normal,
        Special1,
        Special2

    }

    //Main-metoden för spelprogrammet
    static void Main(string[] args)
    {
        //Bool för att kontrollera om man är i menyn eller inte
        bool inMainMenu = true;

        //Loop för huvudmenyn
        do
        {
            //Startmeny och information
            Console.Clear();
            Console.WriteLine("---------------*****---------------");
            Console.WriteLine("Welcome to SalesAdventure3000!");
            Console.WriteLine("---------------*****---------------");
            Console.WriteLine("\nPress '1' to start the game\nPress '2' to read the game info and instructions\nPress 'Escape' to quit the game");

            //Läser av indata från användaren
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
            //Loopar tills man inte är i menyn
        } while (inMainMenu);
    }

    //Metod för att visa spelinformationen
    static void GameInfo()
    {
        //Skriver ut spelinformationen och instruktionerna
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

    //Metod för att starta spelet
    static void StartGame()
    {
        //Skapar spelare och fiender med olika attribut och positioner
        Player player1 = GeneratePlayer(4, 10, 50, 20);
        Creature enemy1 = GenerateCreature(2, 8, 30, 11, 'E');
        Creature enemy2 = GenerateCreature(2, 5, 30, 15, 'E');
        Creature enemy3 = GenerateCreature(2, 7, 30, 11, 'E');
        Creature enemy4 = GenerateCreature(2, 5, 30, 11, 'E');
        Creature enemyBoss = GenerateCreature(1, 12, 50, 20, 'B');

        //Skapar olika typer av items 
        Sword sword1 = GenerateSword(5, "Excalibur", 'X');
        HealthPotion healthPotion1 = GenerateHealthPotion(25, "HealthPotion", 'H');
        HealthPotion healthPotion2 = GenerateHealthPotion(25, "HealthPotion", 'H');
        StaminaPotion staminaPotion1 = GenerateStaminaPotion(15, "StaminaPotion", 'S');

        //Skapar en array med alla olika entiteter
        Entity[] entities = { player1, enemy1, enemy2, enemy3, enemy4, enemyBoss, sword1, healthPotion1, healthPotion2, staminaPotion1, };

        //Lägger till alla entiteter i spelplanen
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

        //Inleder interationen mellan spelare och den första fienden
        enemy1.Interact(player1);

        //Startar spelet genom att rita upp spelplanen
        DrawGameBoard();

        //Loop för spelet
        ConsoleKeyInfo keyInfo;
        do
        {
            //Läser av indata från användaren och flyttar spelaren efter det
            keyInfo = Console.ReadKey(true);
            player1.HandleMovement(keyInfo.Key, gameBoard, entities);
            DrawGameBoard();

            //Kontrollerar om spelarens health är noll, isåfall avslutas spelet
            if (player1.Health <= 0)
            {
                Console.WriteLine("You died!");
                Console.WriteLine("Game Over! Press 'Enter' to return");
                Console.ReadLine();
                Environment.Exit(0);
            }

            //Läser av om man vill öppna backpack eller om man vill använda items
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
            //Loopar tills man inte trycker på escape
        } while (keyInfo.Key != ConsoleKey.Escape);

    }

    //Metod för att lägga till en entitet i spelplanen
    static void AddEntityToGameBoard(Entity entity)
    {
        gameBoard[entity.x, entity.y] = entity.symbol;
    }

    //Metod för att generera en slumpmässig x-kordinat
    static int GenerateRandomXLocation()
    {
        return random.Next(12);
    }

    //Meodd för att generera en slumpmässig y-kordinat
    static int GenerateRandomYLocation()
    {
        return random.Next(22);
    }

    //Metod för att generera spelare
    static Player GeneratePlayer(int speed, int strength, int health, int stamina)
    {
        int x = GenerateRandomXLocation();
        int y = GenerateRandomYLocation();
        return new Player(x, y, speed, strength, health, stamina, 'P');
    }

    //Metod för att generera fiende
    static Creature GenerateCreature(int speed, int strength, int health, int stamina, char symbol)
    {
        int x = GenerateRandomXLocation();
        int y = GenerateRandomYLocation();
        return new Creature(x, y, speed, strength, health, stamina, symbol);
    }

    //Metod för att generera items
    static Items GenerateItems(string name)
    {
        int x = GenerateRandomXLocation();
        int y = GenerateRandomYLocation();
        return new Items(name, x, y, 'I');
    }

    //Metod för att generera sword
    static Sword GenerateSword(int swordDamage, string name, char symbol)
    {
        int x = GenerateRandomXLocation();
        int y = GenerateRandomYLocation();
        return new Sword(swordDamage, name, x, y, symbol);
    }

    //Metod för att generera health potion
    static HealthPotion GenerateHealthPotion(int healingAmount, string name, char symbol)
    {
        int x = GenerateRandomXLocation();
        int y = GenerateRandomYLocation();
        return new HealthPotion(name, healingAmount, x, y, symbol);
    }

    //Metod för att generera stamina potion
    static StaminaPotion GenerateStaminaPotion(int staminaRecoverAmount, string name, char symbol)
    {
        int x = GenerateRandomXLocation();
        int y = GenerateRandomYLocation();
        return new StaminaPotion(staminaRecoverAmount, name, x, y, symbol);
    }

    //Metod för att visa inventory/Backpack
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

    //Metod för att rita ut spelplanen
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
