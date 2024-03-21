namespace classes;

class Items : Entity
{
    //public variabel för att lagra namn
    public string Name;

    //konstruktor för att skapa en ny Items
    public Items(string name, int x, int y, char symbol) : base(x, y, symbol)
    {
        //instansierar egenskaperna för Items
        this.Name = name;
    }
    public virtual void Interact(Player player)
    {

    }
}
