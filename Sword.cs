namespace classes;

class Sword : Items
{
    //privata variabler för att lagra swordDamage och equipped
    private int swordDamage;
    private bool equipped;

    //Konstruktor för att skapa en ny Sword
    public Sword(int swordDamage, string name, int x, int y, char symbol) : base(name, x, y, symbol)
    {
        //instansierar egenskaperna för Sword och sätter equipped till false
        this.swordDamage = swordDamage;
        equipped = false;
    }

    //Override-metod för interation med player
    public override void Interact(Player player)
    {

        //Kontrollerar om sword inte är equipped, ökar spelarens strength med swordDamage
        if (!equipped)
        {
            player.Strength += swordDamage;
            equipped = true;
            Console.WriteLine("You equipped Excalibur!");
        }
        //Kontrollerar om sword är equipped, minskar spelarens strength med swordDamage
        else
        {
            player.Strength -= swordDamage;
            equipped = false;
            Console.WriteLine("You unequipped Excalibur!");
        }
    }

    //Egenskaper för att hämta och sätta swordDamage
    public int SwordExtraDamage
    {
        get { return swordDamage; }
        set { swordDamage = value; }
    }
}
