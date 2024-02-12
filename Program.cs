using classes;

class Program
{
    static char[,] gameBoard = new char[10, 10];
    static void Main(string[] args)
    {
        Player player1 = new Player(0,0);
        Creature enemy1 = new Creature(5, 5, 2, 5, 10, 10);
        Items item1 = new Items(3, 2);
        
    }
}