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

    public virtual int Attack()
    {
        return strength;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
    }

    public bool IsAlive
    {
        get { return health > 0; }
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }

    public int Stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }
}