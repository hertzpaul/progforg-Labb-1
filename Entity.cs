namespace classes;

abstract class Entity
{
    //Egenskaper för Entity-klassen, possition och symbol
    public int x { get; set; }
    public int y { get; set; }
    public char symbol { get; set; }

    //Konstruktor för att skapa en ny Entity
    public Entity(int x, int y, char symbol)
    {
        //Instansierar egenskaperna för Entity
        this.x = x;
        this.y = y;
        this.symbol = symbol;
    }
    public virtual void Interact(Entity otherEntity)
    {

    }
}
