namespace classes;

class Creature : Entity
{
    //Egenskaper för Creature-klassen
    int strength { get; set; }
    int health { get; set; }
    int stamina { get; set; }
    int speed { get; set; }

    //Konstruktor för att skapa en ny Creature
    public Creature(int x, int y, int speed, int strength, int health, int stamina, char symbol) : base(x, y, symbol)
    {
        //Instansierar egenskaperna för Creature
        this.speed = speed;
        this.strength = strength;
        this.health = health;
        this.stamina = stamina;
    }

    public override void Interact(Entity otherEntity)
    {

    }

    //Virtuell metod för att utföra attacken
    public virtual int Attack()
    {

        //Genererar ett slumptal mellan 0 och 100 för att simulera en attack
        Random random = new Random();
        int randomNumber = random.Next(0, 101);
        int result;

        //Kontrollerar om siffran är mindre än 80, returnerar strength
        if (randomNumber < 80)
        {
            result = strength;
        }
        //Kontrollerar om siffran är större än 80, returnerar strength + 5
        else
        {
            result = strength + 5;
        }
        //Returnerar resultat
        return (result);
    }

    //Metod för att ta emot skada
    public virtual void TakeDamage(int damage)
    {
        //Minskar varelsens health baserat på mottagen damage
        health -= damage;
    }

    //Egenskaper för att kontrollera om varelsen fortfarande är levande
    public bool IsAlive
    {
        //Returnerar true om health är större än 0
        get { return health > 0; }
    }

    //Egenskaper för att hämta och sätta varelsens health
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    //Egenskaper för att hämta och sätta varelsens strength
    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }

    //Egenskaper för att hämta och sätta varelsens stamina
    public int Stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }
}
