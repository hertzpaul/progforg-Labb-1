namespace classes;

class StaminaPotion : Items
{
    private int staminaRecoverAmount;

    public StaminaPotion(int staminaRecoverAmount, string name, int x, int y, char symbol) : base(name, x, y, symbol)
    {
        this.staminaRecoverAmount = staminaRecoverAmount;
    }

    public override void Interact(Player player)
    {
        player.Stamina += staminaRecoverAmount;
        //Console.WriteLine("You picked up a StaminaPotion!");
    }

    public int StaminaRecoverAmount
    {
        get { return staminaRecoverAmount; }
        set { staminaRecoverAmount = value; }
    }
}
