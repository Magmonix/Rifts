using System;

namespace RiftsCmd
{
    class Combat
    {
        public static int atks;



        public static void InitCombat()
        {
            atks = Stats.atk;
        }
        public static void CombatMenu()
        {
            Console.Clear();
            Console.WriteLine(Stats.name + ", you currently have " + atks + " attack(s).");
            Console.WriteLine("Are you going to attack or defend?");
            Console.WriteLine("1: Attack");
            Console.WriteLine("2: Defend");
            Console.WriteLine("3: Back to Main Menu");
            string input = Console.ReadLine();
            int inputToInt = int.Parse(input);
            switch (inputToInt)
            {
                case 1:
                    Attack();
                    break;
                case 2:
                    Defend();
                    break;
                case 3:
                    MainApp.MainMenu();
                    break;
                default:
                    Console.WriteLine("You must make a valid selection");
                    Console.ReadKey();
                    CombatMenu();
                    break;

            }
        }

        public static void Attack()
        {
            //Need atks, crit, dmg, d20, consumables
        }

        public static void Defend()
        {
            int d20;
            Console.Clear();
            Console.WriteLine("Are you going to Dodge or Parry?");
            Console.WriteLine("1: Parry");
            Console.WriteLine("2: Dodge");
            Console.WriteLine("3: Back to Main Menu");
            string input = Console.ReadLine();
            int inputToInt = int.Parse(input);
            switch (inputToInt)
            {
                case 1:
                    Console.WriteLine("Are you rolling at -6?");
                    Console.Write("Y/N: ");
                    char answer =  char.Parse(Console.ReadLine());
                    if (answer == 'Y')
                    {
                        d20 = DiceRoll.RollD20();
                        Console.WriteLine(d20 + Stats.parry - 6);
                        Console.Read();
                        CombatMenu();
                        break;
                    }
                    else
                    {
                        d20 = DiceRoll.RollD20();
                        Console.WriteLine(d20 + Stats.parry);
                        Console.Read();
                        CombatMenu();
                        break;
                    }
                case 2:
                    d20 = DiceRoll.RollD20();
                    Console.WriteLine(d20 + Stats.dodge);
                    atks--;
                    Console.Read();
                    CombatMenu();
                    break;
                case 3:
                    MainApp.MainMenu();
                    break;
                default:
                    Console.WriteLine("You must make a valid selection");
                    Console.ReadKey();
                    CombatMenu();
                    break;
            }
                

        }
    }
}
