using System;

namespace RiftsCmd
{
    class DiceRoll
    {
        static Random rng = new Random();
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