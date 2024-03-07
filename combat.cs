namespace classes;

class Combat
{
    public static void StartCombat(Player player, Creature enemy)
    {
        Console.WriteLine("A wild enemy appeared!");
        while (player.IsAlive && enemy.IsAlive)
        {
            PlayerAttack(player, enemy);
            if (!enemy.IsAlive)
            {
                Console.WriteLine("You defeated the enemy!");
                break;
            }

            EnemyAttack(player, enemy);
            if (!player.IsAlive)
            {
                Console.WriteLine("You are defeated by the enemy!");
                break;
            }



            /*int playerDamage = player.Attack();
            enemy.TakeDamage(playerDamage);
            Console.WriteLine("\nYou dealt " + playerDamage + " damage to the enemy!");
            Console.WriteLine("The enemy's health is " + enemy.Health);

            if (!enemy.IsAlive)
            {
                Console.WriteLine("You defeated the enemy!");
                break;
            }

            int enemyDamage = enemy.Attack();
            player.TakeDamage(enemyDamage);
            Console.WriteLine("The enemy dealt " + enemyDamage + " damage to the you!");
            Console.WriteLine("Your health is " + player.Health);

            if (!player.IsAlive)
            {
                Console.WriteLine("You are defeated by the enemy!");
                break;
            }*/
        }
    }

    private static void PlayerAttack(Player player, Creature enemy)
    {

        bool attackMeue = true;

        do
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Normal Attack");
            Console.WriteLine("2. Special Attack 1");
            Console.WriteLine("3. Special Attack 2");

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();
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
        }

        while (attackMeue);
    }

    private static void EnemyAttack(Player player, Creature enemy)
    {
        int damage = enemy.Attack();
        //int damage = ((Boss)enemy).calculateDamage();

        player.TakeDamage(damage);
        Console.WriteLine("\nThe enemy dealt " + damage + " damage to you!");
        Console.WriteLine("Your health is " + player.Health);
    }
}