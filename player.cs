namespace classes;

class Player : Creature
{
    //Konstruktor för att skapa en ny Player
    public Player(int x, int y, int speed, int strength, int health, int stamina, char symbol) : base(x, y, speed, strength, health, stamina, symbol)
    {

    }

    //Override-metod för interation med Entity
    public override void Interact(Entity otherEntity)
    {
        if (otherEntity is Creature)
        {
            //Om otherEntity är en Creature, starta en attack
            Creature enemy = (Creature)otherEntity;
            Console.WriteLine("You attacked the enemy!");
        }
    }

    //Metod för att hantera användarinput och hur spelaren rör sig på spelplanen
    public void HandleMovement(ConsoleKey key, char[,] gameBoard, Entity[] entities)
    {
        //Variabler för att hålla reda på den nya positionen efter rörelse
        int newX = x;
        int newY = y;

        //Hanterat spelarens rörelse baserat på tangenttryckning
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
            //Kontrollerar om spelarens nya positionen är inom spelplanen
            if (newX < 0 || newX >= gameBoard.GetLength(0) || newY < 0 || newY >= gameBoard.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("Cannot move outside the bounds of the game board.");
            }

            //Interagerar med alla entity på samma position som spelaren
            foreach (Entity entity in entities)
            {
                //Kontrollerar om det finns föremål på samma position som spelaren, läggs det till i backpack
                if (entity is Items && entity.x == newX && entity.y == newY)
                {
                    AddToBackpack((Items)entity);
                    break;
                }
            }

            //Interagerar med alla entity på samma position som spelaren
            foreach (Entity entity in entities)
            {
                //Kontrollerar om det finns en Creature på samma position som spelaren, startar en attack
                if (entity is Creature && entity.x == newX && entity.y == newY)
                {
                    Interact(entity);
                    Combat.StartCombat(this, (Creature)entity);
                    break;
                }
            }

            //Uppdaterar spelarens position på spelplanen
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

    //Metod för lägga till ett item i backpack
    public void AddToBackpack(Items item)
    {
        Program.backPack.Add(item);
        Console.WriteLine("You collected a item.");
    }

    //Metod för att utföra en NormalAttack mot enemy
    public void NormalAttack(Creature enemy)
    {
        int damage = Strength;
        enemy.TakeDamage(damage);
        Console.WriteLine("\nYou dealt " + damage + " damage to the enemy!");
        Console.WriteLine("The enemy's health is " + enemy.Health);
    }

    //Metod för att utföra en Special1 attack mot enemy
    public void Special1(Creature enemy)
    {
        if (Stamina >= 10)
        {
            int damage = Strength + 5;
            enemy.TakeDamage(damage);
            Console.WriteLine("\nYou dealt " + damage + " damage to the enemy!");
            Console.WriteLine("The enemy's health is " + enemy.Health);
            Stamina -= 10;
        }
        else
        {
            Console.WriteLine("You do not have enough stamina to use this special attack.");
        }
    }

    //Metod för att utföra en Special2 attack mot enemy
    public void Special2(Creature enemy)
    {
        if (Stamina >= 15)
        {
            int damage = Strength + 8;
            enemy.TakeDamage(damage);
            Console.WriteLine("\nYou dealt " + damage + " damage to the enemy!");
            Console.WriteLine("The enemy's health is " + enemy.Health);
            Stamina -= 15;
        }
        else
        {
            Console.WriteLine("You do not have enough stamina to use this special attack.");
        }
    }

    //Metod för att konsumera items från backpack 
    public void ConsumeItem(int index)
    {
        //Kontrollerar om index är inom gränserna för backpack
        if (index >= 0 && index < Program.backPack.Count)
        {
            Items itemToConsume = Program.backPack[index];

            //Hanterar hur items ska användas baserat på typ av item
            if (itemToConsume is Sword)
            {
                ((Sword)itemToConsume).Interact(this);
            }
            else if (itemToConsume is HealthPotion)
            {
                ((HealthPotion)itemToConsume).Interact(this);
            }
            else if (itemToConsume is StaminaPotion)
            {
                ((StaminaPotion)itemToConsume).Interact(this);
            }

            //Tar bort healthpotion eller staminapotion om dem har använts
            if (itemToConsume is HealthPotion || itemToConsume is StaminaPotion)
            {
                Program.backPack.RemoveAt(index);
            }

            Console.WriteLine("You used a " + itemToConsume.Name + ".");
        }

        else
        {
            Console.WriteLine("Invalid item index.");
        }
    }
}
