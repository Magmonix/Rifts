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
            Console.WriteLine("Your current Force Field is: " + Stats.currentForceField);
            Console.WriteLine("Your current Armor is: " + Stats.currentArmor);
            Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
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
                    Console.ReadLine();
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
                    char answer = char.Parse(Console.ReadLine());
                    if (answer == 'Y')
                    {
                        d20 = DiceRoll.RollD20();
                        Console.WriteLine(d20 + Stats.parry - 6);
                        Console.ReadLine();
                        Console.WriteLine("Were you hit?");
                        Console.Write("Y/N: ");
                        answer = char.Parse(Console.ReadLine());
                        if (answer == 'Y')
                        {
                            Console.WriteLine("How much damage did you take?");
                            string damageTaken = Console.ReadLine();
                            int damageTakenToInt = int.Parse(damageTaken);
                            if (Stats.currentForceField == 0)
                            {
                                if (Stats.currentArmor == 0)
                                {
                                    Stats.currentMDC -= damageTakenToInt;
                                    if (Stats.currentMDC <= 0)
                                    {
                                        Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                        Console.WriteLine("You have been incapacitated");
                                        Console.ReadLine();
                                        CombatMenu();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                        Console.ReadLine();
                                        CombatMenu();
                                    }
                                }
                                else
                                {
                                    Stats.currentArmor -= damageTakenToInt;
                                    if (Stats.currentArmor < 0)
                                    {
                                        Stats.currentArmor *= -1;
                                        Stats.currentMDC -= Stats.currentArmor;
                                        Stats.currentArmor = 0;
                                        if (Stats.currentMDC <= 0)
                                        {
                                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                            Console.WriteLine("You have been incapacitated");
                                            Console.ReadLine();
                                            CombatMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Your current Armor is: " + Stats.currentArmor);
                                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                            Console.ReadLine();
                                            CombatMenu();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Stats.currentForceField -= damageTakenToInt;
                                if (Stats.currentForceField < 0)
                                {
                                    Stats.currentForceField *= -1;
                                    Stats.currentArmor -= Stats.currentForceField;
                                    Stats.currentForceField = 0;
                                    if (Stats.currentArmor < 0)
                                    {
                                        Stats.currentArmor *= -1;
                                        Stats.currentMDC -= Stats.currentArmor;
                                        Stats.currentArmor = 0;
                                        if (Stats.currentMDC <= 0)
                                        {
                                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                            Console.WriteLine("You have been incapacitated");
                                            Console.ReadLine();
                                            CombatMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Your current Force Field is: " + Stats.currentForceField);
                                            Console.WriteLine("Your current Armor is: " + Stats.currentArmor);
                                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                            Console.ReadLine();
                                            CombatMenu();
                                        }
                                    }
                                }
                            }
                            Console.WriteLine("Your current Force Field is: " + Stats.currentForceField);
                            Console.WriteLine("Your current Armor is: " + Stats.currentArmor);
                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                            Console.ReadLine();
                            CombatMenu();
                        }
                        else
                        {
                            Console.WriteLine("Your current Force Field is: " + Stats.currentForceField);
                            Console.WriteLine("Your current Armor is: " + Stats.currentArmor);
                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                            Console.ReadLine();
                            CombatMenu();
                        }
                        break;
                    }
                    else
                    {
                        d20 = DiceRoll.RollD20();
                        Console.WriteLine(d20 + Stats.parry);
                        Console.ReadLine();
                        Console.WriteLine("Were you hit?");
                        Console.Write("Y/N: ");
                        answer = char.Parse(Console.ReadLine());
                        if (answer == 'Y')
                        {
                            Console.WriteLine("How much damage did you take?");
                            string damageTaken = Console.ReadLine();
                            int damageTakenToInt = int.Parse(damageTaken);
                            if (Stats.currentForceField == 0)
                            {
                                if (Stats.currentArmor == 0)
                                {
                                    Stats.currentMDC -= damageTakenToInt;
                                    if (Stats.currentMDC <= 0)
                                    {
                                        Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                        Console.WriteLine("You have been incapacitated");
                                        Console.ReadLine();
                                        CombatMenu();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                        Console.ReadLine();
                                        CombatMenu();
                                    }
                                }
                                else
                                {
                                    Stats.currentArmor -= damageTakenToInt;
                                    if (Stats.currentArmor < 0)
                                    {
                                        Stats.currentArmor *= -1;
                                        Stats.currentMDC -= Stats.currentArmor;
                                        Stats.currentArmor = 0;
                                        if (Stats.currentMDC <= 0)
                                        {
                                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                            Console.WriteLine("You have been incapacitated");
                                            Console.ReadLine();
                                            CombatMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Your current Armor is: " + Stats.currentArmor);
                                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                            Console.ReadLine();
                                            CombatMenu();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Stats.currentForceField -= damageTakenToInt;
                                if (Stats.currentForceField < 0)
                                {
                                    Stats.currentForceField *= -1;
                                    Stats.currentArmor -= Stats.currentForceField;
                                    Stats.currentForceField = 0;
                                    if (Stats.currentArmor < 0)
                                    {
                                        Stats.currentArmor *= -1;
                                        Stats.currentMDC -= Stats.currentArmor;
                                        Stats.currentArmor = 0;
                                        if (Stats.currentMDC <= 0)
                                        {
                                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                            Console.WriteLine("You have been incapacitated");
                                            Console.ReadLine();
                                            CombatMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Your current Force Field is: " + Stats.currentForceField);
                                            Console.WriteLine("Your current Armor is: " + Stats.currentArmor);
                                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                            Console.ReadLine();
                                            CombatMenu();
                                        }
                                    }
                                }
                            }
                            Console.WriteLine("Your current Force Field is: " + Stats.currentForceField);
                            Console.WriteLine("Your current Armor is: " + Stats.currentArmor);
                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                            Console.ReadLine();
                            CombatMenu();
                        }
                        else
                        {
                            Console.WriteLine("Your current Force Field is: " + Stats.currentForceField);
                            Console.WriteLine("Your current Armor is: " + Stats.currentArmor);
                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                            Console.ReadLine();
                            CombatMenu();
                        }
                        break;
                    }
                case 2:
                    d20 = DiceRoll.RollD20();
                    Console.WriteLine(d20 + Stats.dodge);
                    atks--;
                    Console.ReadLine();
                    Console.WriteLine("Were you hit?");
                    Console.Write("Y/N: ");
                    answer = char.Parse(Console.ReadLine());
                    if (answer == 'Y')
                    {
                        Console.WriteLine("How much damage did you take?");
                        string damageTaken = Console.ReadLine();
                        int damageTakenToInt = int.Parse(damageTaken);
                        if (Stats.currentForceField == 0)
                        {
                            if (Stats.currentArmor == 0)
                            {
                                Stats.currentMDC -= damageTakenToInt;
                                if (Stats.currentMDC <= 0)
                                {
                                    Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                    Console.WriteLine("You have been incapacitated");
                                    Console.ReadLine();
                                    CombatMenu();
                                }
                                else
                                {
                                    Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                    Console.ReadLine();
                                    CombatMenu();
                                }
                            }
                            else
                            {
                                Stats.currentArmor -= damageTakenToInt;
                                if (Stats.currentArmor < 0)
                                {
                                    Stats.currentArmor *= -1;
                                    Stats.currentMDC -= Stats.currentArmor;
                                    Stats.currentArmor = 0;
                                    if (Stats.currentMDC <= 0)
                                    {
                                        Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                        Console.WriteLine("You have been incapacitated");
                                        Console.ReadLine();
                                        CombatMenu();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Your current Armor is: " + Stats.currentArmor);
                                        Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                        Console.ReadLine();
                                        CombatMenu();
                                    }
                                }
                            }
                        }
                        else
                        {
                            Stats.currentForceField -= damageTakenToInt;
                            if (Stats.currentForceField < 0)
                            {
                                Stats.currentForceField *= -1;
                                Stats.currentArmor -= Stats.currentForceField;
                                Stats.currentForceField = 0;
                                if (Stats.currentArmor < 0)
                                {
                                    Stats.currentArmor *= -1;
                                    Stats.currentMDC -= Stats.currentArmor;
                                    Stats.currentArmor = 0;
                                    if (Stats.currentMDC <= 0)
                                    {
                                        Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                        Console.WriteLine("You have been incapacitated");
                                        Console.ReadLine();
                                        CombatMenu();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Your current Force Field is: " + Stats.currentForceField);
                                        Console.WriteLine("Your current Armor is: " + Stats.currentArmor);
                                        Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                                        Console.ReadLine();
                                        CombatMenu();
                                    }
                                }
                            }
                        }
                        Console.WriteLine("Your current Force Field is: " + Stats.currentForceField);
                        Console.WriteLine("Your current Armor is: " + Stats.currentArmor);
                        Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                        Console.ReadLine();
                        CombatMenu();
                    }
                    else
                    {
                        Console.WriteLine("Your current Force Field is: " + Stats.currentForceField);
                        Console.WriteLine("Your current Armor is: " + Stats.currentArmor);
                        Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
                        Console.ReadLine();
                        CombatMenu();
                    }
                    break;
                case 3:
                    MainApp.MainMenu();
                    break;
                default:
                    Console.WriteLine("You must make a valid selection");
                    Console.ReadLine();
                    CombatMenu();
                    break;
            }
                

        }
    }
}
