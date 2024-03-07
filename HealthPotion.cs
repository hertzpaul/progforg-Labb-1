namespace classes;

class HealthPotion : Items
{
    private int healingAmount;

    public HealthPotion(string name, int healingAmount, int x, int y, char symbol) : base(name, x, y, symbol)
    {
        this.healingAmount = healingAmount;
    }

    public override void Interact(Player player)
    {
        player.Health += healingAmount;
        //Console.WriteLine("You picked up a HealthPotion!");
    }

    public int HealingAmount
    {
        get { return healingAmount; }
        set { healingAmount = value; }
    }
}
