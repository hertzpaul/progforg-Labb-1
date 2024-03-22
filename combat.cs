namespace classes;

class Combat
{
    //Metoden startar striden mellan enemy och spelaren
    public static void StartCombat(Player player, Creature enemy)
    {
        //Skriver ut att en enemy har dykt upp
        Console.WriteLine("A wild enemy appeared!");

        //Loopar så länge spelaren och enemy är levande
        while (player.IsAlive && enemy.IsAlive)
        {
            //Låter spelaren utföra sin attack genom PlayerAttack-metoden
            PlayerAttack(player, enemy);

            //Kontrollerar om enemy är levande
            if (!enemy.IsAlive)
            {
                Console.WriteLine("You defeated the enemy!");
                break;
            }

            //Låter enemy utföra sin attack genom EnemyAttack-metoden
            EnemyAttack(player, enemy);

            //Kontrollerar om spelaren är levande
            if (!player.IsAlive)
            {
                Console.WriteLine("You are defeated by the enemy!");
                break;
            }
        }
    }

    //Metoden hanterar spelarens olika attackval under striden
    private static void PlayerAttack(Player player, Creature enemy)
    {

        //Kontrollerar om spelaren fortsätter att välja attackalternativ
        bool attackMeue = true;

        //Loopar tills man trycker på en giltig tangent
        do
        {
            //Skriver ut vilka attackalternativ som finns
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Normal Attack");
            Console.WriteLine("2. Special Attack 1");
            Console.WriteLine("3. Special Attack 2");

            //Läser av vilken tangent som trycks
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();

            //Dem olika attackmetoderna beroder på vilken tangent som trycks
            switch (keyInfo.KeyChar)
            {
                case '1':
                    attackMeue = false;
                    player.NormalAttack(enemy);
                    break;
                case '2':
                    attackMeue = false;
                    player.Special1(enemy);
                    break;
                case '3':
                    attackMeue = false;
                    player.Special2(enemy);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

            //Loopar tills spelaren inte längre vill attackera
        } while (attackMeue);
    }

    //Metoden hanterar enemyns attackval under striden
    private static void EnemyAttack(Player player, Creature enemy)
    {
        //Beräknar skadan som enemy gör genom att anropa Attack-metoden
        int damage = enemy.Attack();

        //Beräknar skadan på spelaren genom att anropa TakeDamage-metoden
        player.TakeDamage(damage);
        Console.WriteLine("\nThe enemy dealt " + damage + " damage to you!");
        Console.WriteLine("Your health is " + player.Health);
    }
}
