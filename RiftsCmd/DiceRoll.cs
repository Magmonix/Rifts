using System;

namespace RiftsCmd
{
    class DiceRoll
    {
        static Random rng = new Random();

        //This code was being used for testing purposes
        //public static void DiceMain() 
        //{
        //    Console.Clear();
        //    Console.WriteLine("What dice would you like to roll?");
        //    Console.WriteLine("1: D4");
        //    Console.WriteLine("2: D6");
        //    Console.WriteLine("3: D8");
        //    Console.WriteLine("4: D10");
        //    Console.WriteLine("5: D12");
        //    Console.WriteLine("6: D20");
        //    Console.WriteLine("7: Percentile");
        //    string choice = Console.ReadLine();
        //    int choiceToInt = int.Parse(choice);
        //    switch (choiceToInt)
        //    {
        //        case 1:
        //            RollD4();
        //            break;
        //        case 2:
        //            RollD6();
        //            break;
        //        case 3:
        //            RollD8();
        //            break;
        //        case 4:
        //            RollD10();
        //            break;
        //        case 5:
        //            RollD12();
        //            break;
        //        case 6:
        //            RollD20();
        //            break;
        //        case 7:
        //            RollPercentile();
        //            break;
        //        default:
        //            Console.WriteLine("You must make a valid selection");
        //            Console.ReadLine();
        //            DiceMain();
        //            break;
        //    }
        //} 

        #region Roll Dice
        public static int RollD4()
        {
            //int inputToInt = 0;
            int d4 = rng.Next(1, 5);
            //Sample Code
            /*while (inputToInt != d4)
            {
                Console.Clear();
                Console.WriteLine("Your d4 rolled to: " + d4);
                Console.WriteLine("Enter what you rolled to continue...");
                string input = Console.ReadLine();
                inputToInt = int.Parse(input);
            }*/ 
            //Sample Code
            return (d4);
        }

        public static int RollD6()
        {
            int d6 = rng.Next(1, 7);
            return (d6);
        }

        public static int RollD8()
        {

            int d8 = rng.Next(1, 9);
            return (d8);
        }

        public static int RollD10()
        {
            int d10 = rng.Next(1, 11);
            return (d10);
        }

        public static int RollD12()
        {
            int d12 = rng.Next(1, 13);
            return (d12);
        }

        public static int RollD20()
        {
            int d20 = rng.Next(1, 21);
            return (d20);
        }

        public static int RollPercentile()
        {
            int dPercentile = rng.Next(1, 101);
            return (dPercentile);
        }
        #endregion
    }
}