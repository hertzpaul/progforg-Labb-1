namespace classes;

class StaminaPotion : Items
{
    //privat variabel för att lagra staminaRecoverAmount
    private int staminaRecoverAmount;

    //Konstruktor för att skapa StaminaPotion
    public StaminaPotion(int staminaRecoverAmount, string name, int x, int y, char symbol) : base(name, x, y, symbol)
    {
        //instansierar egenskaperna för StaminaPotion
        this.staminaRecoverAmount = staminaRecoverAmount;
    }

    //Override-metod för interation med player
    public override void Interact(Player player)
    {
        //Ökar spelarens stamina med staminaRecoverAmount
        player.Stamina += staminaRecoverAmount;
    }

    //Egenskaper för att hämta och sätta staminaRecoverAmount
    public int StaminaRecoverAmount
    {
        get { return staminaRecoverAmount; }
        set { staminaRecoverAmount = value; }
    }
}
