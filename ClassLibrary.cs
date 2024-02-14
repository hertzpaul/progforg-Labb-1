namespace classes
{
    class Entity
    {
        public int x { get; set; }
        public int y { get; set; }
        public char symbol { get; set; }

        public Entity(int x, int y, char symbol)
        {
            this.x = x;
            this.y = y;
            this.symbol = symbol;
        }
        public virtual void Interact(Entity otherEntity)
        {

        }
    }

    class Player : Creature
    {
        private List<Items> backPack;
        public Player(int x, int y, int speed, int strength, int health, int stamina, char symbol) : base(x, y, speed, strength, health, stamina, symbol)
        {
            backPack = new List<Items>();
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

                foreach (Entity entity in entities){

                    if (entity is Items && entity.x == newX && entity.y == newY){
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

        public void AddToBackpack(Items item){
            backPack.Add(item);
            Console.WriteLine("You collected a item.");
        }
    }

    class Creature : Entity
    {
        int strength { get; set; }
        int health { get; set; }
        int stamina { get; set; }
        int speed { get; set; }

        public Creature(int x, int y, int speed, int strength, int health, int stamina, char symbol) : base(x, y, symbol)
        {
            this.speed = speed;
            this.strength = strength;
            this.health = health;
            this.stamina = stamina;
        }
        public override void Interact(Entity otherEntity)
        {

        }

    }

    class Items : Entity
    {
        public Items(int x, int y, char symbol) : base(x, y, symbol)
        {

        }
    }
}