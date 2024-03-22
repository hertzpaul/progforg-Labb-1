namespace classes;

class HealthPotion : Items
{
    //privat variabel för att lagra healingAmount 
    private int healingAmount;

    //Konstruktor för att skapa en ny HealthPotion
    public HealthPotion(string name, int healingAmount, int x, int y, char symbol) : base(name, x, y, symbol)
    {
        //instansierar egenskaperna för HealthPotion
        this.healingAmount = healingAmount;
    }

    //override-metod för interation med player
    public override void Interact(Player player)
    {
        //Ökar spelarens health med healingAmount
        player.Health += healingAmount;
    }

    //Egenskaper för att hämta och ställa in healingAmount
    public int HealingAmount
    {
        get { return healingAmount; }
        set { healingAmount = value; }
    }
}
