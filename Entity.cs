namespace classes;

abstract class Entity
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