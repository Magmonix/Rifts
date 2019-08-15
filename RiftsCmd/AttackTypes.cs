using System;

namespace RiftsCmd
{
    class AttackTypes
    {
        public static int MagicAttacks()
        {
            Console.Clear();
            Console.WriteLine("You currently have " + Stats.currentPPE + " PPE, " + Stats.currentISP + " ISP, and " + Stats.currentDarkPoints + " Dark Points");
            Console.WriteLine("Which spell do you want to cast?");
            Console.WriteLine("1: Air Blast");
            Console.WriteLine("9: Return to Combat Menu");
            string input = Console.ReadLine();
            int inputToInt = int.Parse(input);
            switch (inputToInt)
            {
                case 1:
                    return (Spell_AirBlast()); //TODO: Need to check if we have enough PPE to cast the spell before we call the function
                case 9:
                    Combat.CombatMenu();
                    break;
                default:

                    break;
            }
            return(0);
        }

        public static void PhysicalAttacks()
        {
            
        }

        public static int Spell_AirBlast()
        {
            int dicedmg = 90;
            for (int i = 0; i < 108; i++)
            {
                int roll = DiceRoll.RollD6();
                dicedmg += roll;
            }
            Stats.currentPPE -= 8;
            return (dicedmg);
        }

        public static void Physical_Whip()
        {

        }
    }
}
