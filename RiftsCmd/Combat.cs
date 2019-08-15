using System;

namespace RiftsCmd
{
    class Combat
    {
        public static int magicalAtks;
        public static int physicalAtks;
        public static int allAtks;


        public static void InitCombat()
        {
            allAtks = Stats.allAtk;
            magicalAtks = Stats.magicalAtk;
            physicalAtks = Stats.physicalAtk;
        }

        public static void CombatMenu()
        {
            Console.Clear();
            Console.WriteLine(Stats.name + ",");
            Console.WriteLine("You currently have " + allAtks + " all attack(s).");
            Console.WriteLine("You currently have " + magicalAtks + " magical attack(s).");
            Console.WriteLine("You currently have " + physicalAtks + " non-magical attack(s).");
            Console.WriteLine("Your current Force Field is: " + Stats.currentForceField);
            Console.WriteLine("Your current Armor is: " + Stats.currentArmor);
            Console.WriteLine("Your current MDC is: " + Stats.currentMDC);
            if ((allAtks + magicalAtks + physicalAtks) == 0)
            {
                Console.WriteLine("You currently have no attacks remaining.");
                Console.WriteLine("Would you like to defend or start a new round of combat?");
                Console.WriteLine("1: Defend");
                Console.WriteLine("2: Start a new round of combat");
                Console.WriteLine("3: Back to Main Menu");
                string input = Console.ReadLine();
                int inputToInt = int.Parse(input);
                switch (inputToInt)
                {
                    case 1:
                        Defend();
                        break;
                    case 2:
                        Console.WriteLine("Are you sure you want to start a new round of combat?");
                        Console.WriteLine("1: Yes");
                        Console.WriteLine("2: No");
                        input = Console.ReadLine();
                        inputToInt = int.Parse(input);
                        if (inputToInt == 1)
                        {
                            InitCombat();
                            CombatMenu();
                            break;
                        }
                        else
                        {
                            CombatMenu();
                            break;
                        }
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
            else
            {
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
        }

        public static void Attack()
        {
            Console.Clear();
            Console.WriteLine("Choose your attack type");
            Console.WriteLine("1: Magical");
            Console.WriteLine("2: Physical");
            Console.WriteLine("3: Return to Combat Menu");
            string input = Console.ReadLine();
            int inputToInt = int.Parse(input);
            switch (inputToInt)
            {
                case 1:
                    if (magicalAtks > 0)
                    {
                        magicalAtks -= 1;
                    }
                    else
                    {
                        allAtks -= 1;
                    }
                    Consumables.ConsumablesCheck();
                    //Type of Spell
                    //Roll for hit
                    //D20 check
                    //Check if Hit
                    //Check if Crit
                    //Calculate dmg
                    break;
                case 2:
                    if (physicalAtks > 0)
                    {
                        physicalAtks -= 1;
                    }
                    else
                    {
                        allAtks -= 1;
                    }
                    Consumables.ConsumablesCheck();
                    //Type of Weapon
                    //Roll for hit
                    //D20 check
                    //Check if Hit
                    //Check if Crit
                    //Calculate dmg
                    break;
                case 3:
                    CombatMenu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please make a valid selection");
                    Console.ReadLine();
                    CombatMenu();
                    break;
            }

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
                    if (physicalAtks > 0)
                    {
                        physicalAtks -= 1;
                    }
                    else
                    {
                        allAtks -= 1;
                    }
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
