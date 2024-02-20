namespace classes;

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