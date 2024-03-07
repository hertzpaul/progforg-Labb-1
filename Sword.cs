namespace classes;

class Sword : Items
{
    private int swordDamage;

    private bool equipped;

    public Sword(int swordDamage, string name, int x, int y, char symbol) : base(name, x, y, symbol)
    {
        this.swordDamage = swordDamage;
        equipped = false;
    }

    public override void Interact(Player player)
    {

        if (!equipped)
        {
            player.Strength += swordDamage;
            equipped = true;
            Console.WriteLine("You equipped Excalibur!");
        }
        else
        {
            player.Strength -= swordDamage;
            equipped = false;
            Console.WriteLine("You unequipped Excalibur!");
        }
        //Console.WriteLine("You picked up Excalibur!");
    }

    public int SwordExtraDamage
    {
        get { return swordDamage; }
        set { swordDamage = value; }
    }
}
