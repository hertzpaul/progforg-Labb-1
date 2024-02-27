namespace classes;

class Items : Entity
{
    public string Name;
    public Items(string name, int x, int y, char symbol) : base(x, y, symbol)
    {
        this.Name = name;
    }
    public virtual void Interact(Player player)
    {
        
    }
}