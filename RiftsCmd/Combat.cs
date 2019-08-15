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
            bool isCrit = false;
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
                    int dmg = AttackTypes.MagicAttacks();
                    Consumables.ConsumablesCheck();
                    if (magicalAtks > 0)
                    {
                        magicalAtks -= 1;
                    }
                    else
                    {
                        allAtks -= 1;
                    }
                    int d20 = DiceRoll.RollD20();
                    //TODO: Add strike buffs here
                    Console.Clear();
                    Console.WriteLine("You rolled a " + d20 + " for a total of " + (d20 + Stats.currentStrike));
                    //TODO: Remove Strike buffs here
                    //TODO: Add crit buffs here
                    if (d20 >= Stats.currentCrit)
                    {
                        Console.Clear();
                        Console.WriteLine("You crit with a roll of " + d20 + "!!!!");
                        isCrit = true;
                    }
                    //TODO: Remove crit buffs here
                    Console.WriteLine("Did you hit?");
                    Console.WriteLine("1: Yes");
                    Console.WriteLine("2: No");
                    input = Console.ReadLine();
                    inputToInt = int.Parse(input);
                    Boolean again = true;
                    while (again)
                    {
                        again = false;
                        switch (inputToInt)
                        {
                            case 1:
                                Console.Clear();
                                if (isCrit == true)
                                {
                                    Console.WriteLine("Did you crit for full damage?");
                                    Console.WriteLine("1: Yes");
                                    Console.WriteLine("2: No");
                                    input = Console.ReadLine();
                                    inputToInt = int.Parse(input);
                                    switch (inputToInt)
                                    {
                                        case 1:
                                            Console.WriteLine("You critically hit for " + (dmg * 2) + " damage!");
                                            Console.ReadLine();
                                            //TODO: Add validation step so user can't accidentally skip this page
                                            CombatMenu();
                                            break;
                                        case 2:
                                            Console.WriteLine("You hit for " + dmg + " damage!");
                                            Console.ReadLine();
                                            //TODO: Add validation step so user can't accidentally skip this page
                                            CombatMenu();
                                            break;
                                        default:
                                            Console.Clear();
                                            Console.WriteLine("You must enter a valid input of 1 or 2");
                                            Console.ReadLine();
                                            again = true;
                                            break;
                                    }
                                }
                                Console.WriteLine("You hit for " + dmg + " damage!");
                                Console.ReadLine();
                                //TODO: Add validation step so user can't accidentally skip this page
                                CombatMenu();
                                break;
                            case 2:
                                CombatMenu();
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("You must enter a valid input of 1 or 2");
                                Console.ReadLine();
                                again = true;
                                break;
                        }
                    }
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
                    //TODO: Follow the format of the magic attack logic
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
            Console.WriteLine("3: Back to Combat Menu");
            string input = Console.ReadLine();
            int inputToInt = int.Parse(input);
            switch (inputToInt)
            {
                case 1:
                    Console.WriteLine("Are you rolling at -6?");
                    Console.WriteLine("1: Yes");
                    Console.WriteLine("2: No");
                    char answer = char.Parse(Console.ReadLine());
                    if (answer == '1') //TODO: Change to switch/case
                    {
                        d20 = DiceRoll.RollD20();
                        Console.Clear();
                        Console.WriteLine("You attempt to parry...");
                        Console.WriteLine("You roll " + d20 + " for a total of " + (d20 + Stats.currentParry - 6));
                        Console.ReadLine();
                        Console.WriteLine("Were you hit?");
                        Console.WriteLine("1: Yes");
                        Console.WriteLine("2: No");
                        answer = char.Parse(Console.ReadLine());
                        if (answer == '1') //TODO: Change to switch/case
                        {
                            Console.WriteLine("How much damage did you take?");
                            string damageTaken = Console.ReadLine();
                            int damageTakenToInt = int.Parse(damageTaken); //TODO: TRY CATCH
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
                        Console.Clear();
                        Console.WriteLine("You attempt to parry...");
                        Console.WriteLine("You roll " + d20 + " for a total of " + (d20 + Stats.currentParry));
                        Console.ReadLine();
                        Console.WriteLine("Were you hit?");
                        Console.WriteLine("1: Yes");
                        Console.WriteLine("2: No");
                        answer = char.Parse(Console.ReadLine());
                        if (answer == '1') //TODO: Change to switch/case
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
                    Console.Clear();
                    Console.WriteLine("You attempt to dodge...");
                    Console.WriteLine("You roll " + d20 + " for a total of " + (d20 + Stats.currentDodge));
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
                    Console.WriteLine("1: Yes");
                    Console.WriteLine("2: No");
                    answer = char.Parse(Console.ReadLine());
                    if (answer == '1') //TODO: Change to switch/case
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
                    CombatMenu();
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
