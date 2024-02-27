namespace classes;

class Sword : Items
{
    private int swordDamage;

    public Sword(int swordDamage, string name, int x, int y, char symbol): base(name, x, y, symbol)
    {
      this.swordDamage = swordDamage;  
    }

    public override void Interact(Player player)
    {
        player.Strength += swordDamage;
        Console.WriteLine("You picked up Excalibur!");
    }

    public int SwordExtraDamage{
        get{return swordDamage;}
        set{swordDamage = value;}
    }
}
