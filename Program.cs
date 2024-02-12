using classes;

class Program
{
    static char[,] gameBoard = new char[12, 22];
    static void Main(string[] args)
    {
        Player player1 = new Player(0,0, 2, 4, 10, 10, 'P');
        Creature enemy1 = new Creature(10, 16, 2, 5, 10, 10, 'E');
        Items item1 = new Items(7, 6, 'I');

        

        AddEntityToGameBoard(player1);
        AddEntityToGameBoard(enemy1);
        AddEntityToGameBoard(item1);

        enemy1.Interact(player1);
        item1.Interact(player1);

        DrawGameBoard();


    }

    static void AddEntityToGameBoard(Entity entity)
    {
        gameBoard[entity.x, entity.y] = entity.symbol;
    }

    static void DrawGameBoard()
{
    for (int i = 0; i < gameBoard.GetLength(0); i++)
    {
        for (int j = 0; j < gameBoard.GetLength(1); j++)
        {
            if (gameBoard[i, j] == '\0')
            {
                Console.Write("- ");
            }
            else
            {
                Console.Write(gameBoard[i, j] + " ");
            }
        }
        Console.WriteLine();
    }
}
}