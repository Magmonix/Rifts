using System;

namespace RiftsCmd
{
    class AttackTypes
    {
        public static int MagicAttacks(bool magicDBL)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("You currently have " + Stats.currentPPE.CurrentValue + " PPE, " + Stats.currentISP.CurrentValue + " ISP, and " + Stats.currentDarkPoints.CurrentValue + " Dark Points");
                Console.WriteLine("Which spell do you want to cast?");
                Console.WriteLine("1: Air Blast");
                Console.WriteLine("9: Refund consumable charges and return to Combat Menu");
                string input = Console.ReadLine();
                int inputToInt = int.Parse(input);
                switch (inputToInt)
                {
                    case 1:
                        if (Stats.currentPPE.CurrentValue <= 8)//TODO: We should be checking a PPE/ISP cost value and not a static value
                        {
                            Console.Clear();
                            Console.WriteLine("You do not have enough PPE to cast this spell");
                            Console.WriteLine("Press the Enter key to continue");
                            Console.ReadLine();
                            Combat.CombatMenu();
                        }
                        return (Spell_AirBlast(magicDBL));
                    case 9:
                        ConsumablesReset();
                        Combat.CombatMenu();
                        break;
                    default:

                        break;
                }
                return (0);
            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter a valid option");
                Console.WriteLine("Press the Enter key to continue...");
                Console.ReadLine();
                return (0);
            }
            
        }

        public static int PhysicalAttacks(bool SoulGauntletPlusThreeDmgPerLevel)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Which weapon do you want to use?");
                Console.WriteLine("1: Whip");
                Console.WriteLine("9: Refund consumable charges and return to Combat Menu");
                string input = Console.ReadLine();
                int inputToInt = int.Parse(input);
                switch (inputToInt)
                {
                    case 1:
                        return (Whip(SoulGauntletPlusThreeDmgPerLevel));
                    case 9:
                        ConsumablesReset();
                        Combat.CombatMenu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("You must make a valid selection");
                        Console.WriteLine("Press the Enter key to continue...");
                        Console.ReadLine();
                        break;
                }
                return (0);
            }
            catch (FormatException)
            {
                Console.WriteLine("You must make a valid selection");
                Console.WriteLine("Press the Enter key to continue...");
                Console.ReadLine();
                return (0);
            }

        }









        public static int Spell_AirBlast(bool magicDBL) //TODO: Work in variables and get rid of static values
        {
            int basedmg = 90;
            if (magicDBL == true)
            {
                for (int i = 0; i < 162; i++)
                {
                    int roll = DiceRoll.RollD6();
                    basedmg += roll;
                }
            }
            else
            {
                for (int i = 0; i < 108; i++)
                {
                    int roll = DiceRoll.RollD6();
                    basedmg += roll;
                }
            }
            Stats.currentPPE.CurrentValue -= 8;
            return (basedmg);
        }

        public static int Whip(bool SoulGauntletPlusThreeDmgPerLevel)
        {
            int basedmg = 0;
            for (int i = 0; i < 10; i++)
            {
                int roll = DiceRoll.RollD6();
                basedmg += roll;
            }
            if (SoulGauntletPlusThreeDmgPerLevel == true)
            {
                basedmg += (3 * int.Parse(Stats.sheetLevel.Value));
            }
            return (basedmg);

        }

        public static void ConsumablesReset()
        {
            if (ConsumablesInventory.magicDBL.Used == true)
            {
                ConsumablesInventory.magicDBL.Charges += 1;
            }
            if (ConsumablesInventory.magicDurDBL.Used == true)
            {
                ConsumablesInventory.magicDurDBL.Charges += 1;
            }
            if (ConsumablesInventory.magicMinusOneCrit.Used == true)
            {
                ConsumablesInventory.magicMinusOneCrit.Charges += 1;
            }
            if (ConsumablesInventory.magicMinusTwoCrit.Used == true)
            {
                ConsumablesInventory.magicMinusTwoCrit.Charges += 1;
            }
            if (ConsumablesInventory.magicPlusThreeStrike.Used == true)
            {
                ConsumablesInventory.magicPlusThreeStrike.Charges += 1;
            }
            if (ConsumablesInventory.magicRangeDBL.Used == true)
            {
                ConsumablesInventory.magicRangeDBL.Charges += 1;
            }
            if (ConsumablesInventory.magicRangeTimesTen.Used == true)
            {
                ConsumablesInventory.magicRangeTimesTen.Charges += 1;
            }
        }
    }
}
