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
        if (otherEntity is Creature)
        {
            Creature enemy = (Creature)otherEntity;
            Console.WriteLine("You attacked the enemy!");
        }
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
                    // HandleMovement som kör interact metoden när player är på samma plats som items
                    if(entity is Sword && entity.x == newX && entity.y == newY)
                    {
                        ((Items)entity).Interact(this);
                    }
                    else if(entity is HealthPotion && entity.x == newX && entity.y == newY)
                    {
                        ((Items)entity).Interact(this);
                    }
                    else if(entity is StaminaPotion && entity.x == newX && entity.y == newY)
                    {
                        ((Items)entity).Interact(this);
                    }
                    //Slutet på det jag la till för handlemovement
                    break;
                }
            }

            foreach (Entity entity in entities)
            {
                if (entity is Creature && entity.x == newX && entity.y == newY)
                {
                    Interact(entity);
                    Combat.StartCombat(this, (Creature)entity);
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

    public void NormalAttack(Creature enemy)
    {
        int damage = Strength;
        enemy.TakeDamage(damage);
        Console.WriteLine("\nYou dealt " + damage + " damage to the enemy!");
        Console.WriteLine("The enemy's health is " + enemy.Health);
    }

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


}