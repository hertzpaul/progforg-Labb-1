namespace classes
{
    

class Entity{
    public int x {get; set;}
    public int y {get; set;}
    public char symbol {get; set;}

    public  Entity(int x, int y, char symbol){
        this.x = x;
        this.y = y;
        this.symbol = symbol;
    }
        public virtual void Interact(Entity otherEntity)
        {

        }
}

class Player : Creature{
    public Player (int x, int y, int speed, int strength, int health, int stamina, char symbol) : base(x, y, speed, strength, health, stamina, symbol){

    }
        public override void Interact(Entity otherEntity)
        {
            
        }

    }

class Creature : Entity {

    int strength {get; set;} 
    int health {get; set;}
    int stamina {get; set;}
    int speed {get; set;}

    public Creature(int x, int y, int speed, int strength, int health, int stamina, char symbol) : base(x,y,symbol) {
        this.speed = speed;
        this.strength = strength;
        this.health = health;
        this.stamina = stamina;
    }
        public override void Interact(Entity otherEntity)
        {
            
        }

    }

class Items : Entity{

    public Items(int x, int y, char symbol) : base(x,y,symbol) {

    }
}
}