using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiftsCmd
{
    class DiceRoll
    {
        static Random rng = new Random();

        public static void DiceMain() 
        {
            Console.Clear();
            Console.WriteLine("What dice would you like to roll?");
            Console.WriteLine("1: D4");
            Console.WriteLine("2: D6");
            Console.WriteLine("3: D8");
            Console.WriteLine("4: D10");
            Console.WriteLine("5: D12");
            Console.WriteLine("6: D20");
            Console.WriteLine("7: Percentile");
            string choice = Console.ReadLine();
            int choiceToInt = int.Parse(choice);
            switch (choiceToInt)
            {
                case 1:
                    RollD4();
                    break;
                case 2:
                    RollD6();
                    break;
                case 3:
                    RollD8();
                    break;
                case 4:
                    RollD10();
                    break;
                case 5:
                    RollD12();
                    break;
                case 6:
                    RollD20();
                    break;
                case 7:
                    RollPercentile();
                    break;
                default:
                    Console.WriteLine("You must make a valid selection");
                    Console.ReadKey();
                    DiceMain();
                    break;
            }
        }

        #region Roll Dice
        public static void RollD4()
        {
            int d4 = rng.Next(1, 5);
            Console.WriteLine("Your d4 rolled to: " + d4);
            Console.ReadLine();
            MainApp.Main();
        }

        public static void RollD6()
        {
            int d6 = rng.Next(1, 7);
            Console.WriteLine("Your d6 rolled to: " + d6);
            Console.ReadLine();
            MainApp.Main();
        }

        public static void RollD8()
        {
            int d8 = rng.Next(1, 9);
            Console.WriteLine("Your d8 rolled to: " + d8);
            Console.ReadLine();
            MainApp.Main();
        }

        public static void RollD10()
        {
            int d10 = rng.Next(1, 11);
            Console.WriteLine("Your d10 rolled to: " + d10);
            Console.ReadLine();
            MainApp.Main();
        }
        
        public static void RollD12()
        {
            int d12 = rng.Next(1, 13);
            Console.WriteLine("Your d12 rolled to: " + d12);
            Console.ReadLine();
            MainApp.Main();
        }
                
        public static void RollD20()
        {
            int d20 = rng.Next(1, 21);
            Console.WriteLine("Your d20 rolled to: " + d20);
            Console.ReadLine();
            MainApp.Main();
        }
                        
        public static void RollPercentile()
        {
            int dPercentile = rng.Next(1, 101);
            Console.WriteLine("Your percentile rolled to: " + dPercentile);
            Console.ReadLine();
            MainApp.Main();
        }
        #endregion
    }
}