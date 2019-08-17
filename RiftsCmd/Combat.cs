using System;

namespace RiftsCmd
{
    class Combat
    {

        public static void InitCombat()
        {
            Stats.currentAllAtk.CurrentValue = int.Parse(Stats.sheetAllAtk.Value);
            Stats.currentMagicalAtk.CurrentValue = int.Parse(Stats.sheetMagicalAtk.Value);
            Stats.currentPhysicalAtk.CurrentValue = int.Parse(Stats.sheetPhysicalAtk.Value);
        }

        public static void CombatMenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine(Stats.sheetName.Value + ",");
                Console.WriteLine("You currently have " + Stats.currentAllAtk.CurrentValue + " all attack(s).");
                Console.WriteLine("You currently have " + Stats.currentMagicalAtk.CurrentValue + " magical attack(s).");
                Console.WriteLine("You currently have " + Stats.currentPhysicalAtk.CurrentValue + " non-magical attack(s).");
                Console.WriteLine("Your current Force Field is: " + Stats.currentForceField.CurrentValue);
                Console.WriteLine("Your current Armor is: " + Stats.currentArmor.CurrentValue);
                Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                if ((Stats.currentAllAtk.CurrentValue + Stats.currentMagicalAtk.CurrentValue + Stats.currentPhysicalAtk.CurrentValue) == 0)
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
                            Console.WriteLine("Press the Enter key to continue...");
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
                            Console.WriteLine("Press the Enter key to continue...");
                            Console.ReadLine();
                            CombatMenu();
                            break;

                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("You must make a valid selection");
                Console.WriteLine("Press the Enter key to continue...");
                Console.ReadLine();
            }

        }

        public static void Attack()
        {
            try
            {
                bool answer;
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
                        bool again = true;
                        Console.Clear();
                        Console.WriteLine("Do you want to use consumables?");
                        Console.WriteLine("1: Yes");
                        Console.WriteLine("2: No");
                        input = Console.ReadLine();
                        inputToInt = int.Parse(input);
                        while (again)
                        {
                            again = false;
                            switch (inputToInt)
                            {
                                case 1:
                                    ConsumablesInventory.ConsumablesCheck();
                                    break;
                                case 2:
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("You must make a valid selection");
                                    Console.WriteLine("Press the Enter key to continue");
                                    Console.ReadLine();
                                    again = true;
                                    break;
                            }
                        }
                        int dmg = AttackTypes.MagicAttacks(ConsumablesInventory.magicDBL.Used);
                        ConsumablesInventory.magicDBL.Used = false;
                        if (Stats.currentMagicalAtk.CurrentValue > 0)
                        {
                            Stats.currentMagicalAtk.CurrentValue -= 1;
                        }
                        else
                        {
                            Stats.currentAllAtk.CurrentValue -= 1;
                        }
                        int d20 = DiceRoll.RollD20();
                        if (ConsumablesInventory.magicPlusThreeStrike.Used == true)
                        {
                            Stats.currentStrike.CurrentValue += 3;
                        }
                        if (ConsumablesInventory.magicMinusOneCrit.Used == true)
                        {
                            Stats.currentCrit.CurrentValue -= 1;
                        }
                        if (ConsumablesInventory.magicMinusTwoCrit.Used == true)
                        {
                            Stats.currentCrit.CurrentValue -= 2;
                        }
                        Console.Clear();
                        if (d20 >= Stats.currentCrit.CurrentValue)
                        {
                            Console.Clear();
                            Console.WriteLine("You crit with a roll of " + d20 + "!!!!");
                            isCrit = true;
                        }
                        Console.WriteLine("You rolled a " + d20 + " for a total of " + (d20 + Stats.currentStrike.CurrentValue));
                        if (ConsumablesInventory.magicPlusThreeStrike.Used == true)
                        {
                            Stats.currentStrike.CurrentValue -= 3;
                            ConsumablesInventory.magicPlusThreeStrike.Used = false;
                        }
                        if (ConsumablesInventory.magicMinusOneCrit.Used == true)
                        {
                            Stats.currentCrit.CurrentValue += 1;
                            ConsumablesInventory.magicMinusOneCrit.Used = false;
                        }
                        if (ConsumablesInventory.magicMinusTwoCrit.Used == true)
                        {
                            Stats.currentCrit.CurrentValue += 2;
                            ConsumablesInventory.magicMinusTwoCrit.Used = false;
                        }
                        Console.WriteLine("Did you hit?");
                        Console.WriteLine("1: Yes");
                        Console.WriteLine("2: No");
                        input = Console.ReadLine();
                        inputToInt = int.Parse(input);
                        again = true;
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
                                                answer = false;
                                                while (!answer)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You critically hit for " + (dmg * 2) + " damage!");
                                                    Console.WriteLine("Before you can continue you must enter your dmg");
                                                    input = Console.ReadLine();
                                                    inputToInt = int.Parse(input);
                                                    if (inputToInt == (dmg * 2))
                                                    {
                                                        answer = true;
                                                    }
                                                }
                                                CombatMenu();
                                                break;
                                            case 2:
                                                answer = false;
                                                while (!answer)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You hit for " + dmg + " damage!");
                                                    Console.WriteLine("Before you can continue you must enter your dmg");
                                                    input = Console.ReadLine();
                                                    inputToInt = int.Parse(input);
                                                    if (inputToInt == (dmg))
                                                    {
                                                        answer = true;
                                                    }
                                                }
                                                CombatMenu();
                                                break;
                                            default:
                                                Console.Clear();
                                                Console.WriteLine("You must enter a valid input of 1 or 2");
                                                Console.WriteLine("Press the Enter key to continue");
                                                Console.ReadLine();
                                                again = true;
                                                break;
                                        }
                                    }
                                    answer = false;
                                    while (!answer)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You hit for " + dmg + " damage!");
                                        Console.WriteLine("Before you can continue you must enter your dmg");
                                        input = Console.ReadLine();
                                        inputToInt = int.Parse(input);
                                        if (inputToInt == (dmg))
                                        {
                                            answer = true;
                                        }
                                    }
                                    CombatMenu();
                                    break;
                                case 2:
                                    CombatMenu();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("You must enter a valid input of 1 or 2");
                                    Console.WriteLine("Press the Enter key to continue");
                                    Console.ReadLine();
                                    again = true;
                                    break;
                            }
                        }
                        break;

                    case 2:
                        again = true;
                        Console.Clear();
                        Console.WriteLine("Do you want to use consumables?");
                        Console.WriteLine("1: Yes");
                        Console.WriteLine("2: No");
                        input = Console.ReadLine();
                        inputToInt = int.Parse(input);
                        while (again)
                        {
                            again = false;
                            switch (inputToInt)
                            {
                                case 1:
                                    ConsumablesInventory.ConsumablesCheck();
                                    break;
                                case 2:
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("You must choose a valid value");
                                    Console.WriteLine("Press the Enter key to continue");
                                    Console.ReadLine();
                                    again = true;
                                    break;
                            }
                        }
                        dmg = AttackTypes.PhysicalAttacks(ConsumablesInventory.physicalSoulGauntletPlusThreeDmgPerLevel.Used);
                        ConsumablesInventory.physicalSoulGauntletPlusThreeDmgPerLevel.Used = false;
                        if (Stats.currentPhysicalAtk.CurrentValue > 0)
                        {
                            Stats.currentPhysicalAtk.CurrentValue -= 1;
                        }
                        else
                        {
                            Stats.currentAllAtk.CurrentValue -= 1;
                        }
                        d20 = DiceRoll.RollD20();
                        Console.Clear();
                        if (d20 >= Stats.currentCrit.CurrentValue)
                        {
                            Console.Clear();
                            Console.WriteLine("You crit with a roll of " + d20 + "!!!!");
                            isCrit = true;
                        }
                        Console.WriteLine("You rolled a " + d20 + " for a total of " + (d20 + Stats.currentStrike.CurrentValue));
                        Console.WriteLine("Did you hit?");
                        Console.WriteLine("1: Yes");
                        Console.WriteLine("2: No");
                        input = Console.ReadLine();
                        inputToInt = int.Parse(input);
                        again = true;
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
                                                answer = false;
                                                while (!answer)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You critically hit for " + (dmg * 2) + " damage!");
                                                    Console.WriteLine("Before you can continue you must enter your dmg");
                                                    input = Console.ReadLine();
                                                    inputToInt = int.Parse(input);
                                                    if (inputToInt == (dmg * 2))
                                                    {
                                                        answer = true;
                                                    }
                                                }
                                                CombatMenu();
                                                break;
                                            case 2:
                                                answer = false;
                                                while (!answer)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("You hit for " + dmg + " damage!");
                                                    Console.WriteLine("Before you can continue you must enter your dmg");
                                                    input = Console.ReadLine();
                                                    inputToInt = int.Parse(input);
                                                    if (inputToInt == (dmg))
                                                    {
                                                        answer = true;
                                                    }
                                                }
                                                CombatMenu();
                                                break;
                                            default:
                                                Console.Clear();
                                                Console.WriteLine("You must enter a valid input of 1 or 2");
                                                Console.WriteLine("Press the Enter key to continue");
                                                Console.ReadLine();
                                                again = true;
                                                break;
                                        }
                                    }
                                    answer = false;
                                    while (!answer)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You hit for " + dmg + " damage!");
                                        Console.WriteLine("Before you can continue you must enter your dmg");
                                        input = Console.ReadLine();
                                        inputToInt = int.Parse(input);
                                        if (inputToInt == (dmg))
                                        {
                                            answer = true;
                                        }
                                    }
                                    CombatMenu();
                                    break;
                                case 2:
                                    CombatMenu();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("You must enter a valid input of 1 or 2");
                                    Console.WriteLine("Press the Enter key to continue");
                                    Console.ReadLine();
                                    again = true;
                                    break;
                            }
                        }
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
            catch (FormatException)
            {
                Console.WriteLine("You must make a valid selection");
                Console.WriteLine("Press the Enter key to continue...");
                Console.ReadLine();
            }

        }

        public static void Defend()
        {
            try
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
                        if (answer == '1')
                        {
                            d20 = DiceRoll.RollD20();
                            Console.Clear();
                            Console.WriteLine("You attempt to parry...");
                            Console.WriteLine("You roll " + d20 + " for a total of " + (d20 + Stats.currentParry.CurrentValue - 6));
                            Console.ReadLine();
                            Console.WriteLine("Were you hit?");
                            Console.WriteLine("1: Yes");
                            Console.WriteLine("2: No");
                            answer = char.Parse(Console.ReadLine());
                            if (answer == '1')
                            {
                                Console.WriteLine("How much damage did you take?");
                                string damageTaken = Console.ReadLine();
                                int damageTakenToInt = int.Parse(damageTaken);
                                if (Stats.currentForceField.CurrentValue == 0)
                                {
                                    if (Stats.currentArmor.CurrentValue == 0)
                                    {
                                        Stats.currentMDC.CurrentValue -= damageTakenToInt;
                                        if (Stats.currentMDC.CurrentValue <= 0)
                                        {
                                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                            Console.WriteLine("You have been incapacitated");
                                            Console.ReadLine();
                                            CombatMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                            Console.ReadLine();
                                            CombatMenu();
                                        }
                                    }
                                    else
                                    {
                                        Stats.currentArmor.CurrentValue -= damageTakenToInt;
                                        if (Stats.currentArmor.CurrentValue < 0)
                                        {
                                            Stats.currentArmor.CurrentValue *= -1;
                                            Stats.currentMDC.CurrentValue -= Stats.currentArmor.CurrentValue;
                                            Stats.currentArmor.CurrentValue = 0;
                                            if (Stats.currentMDC.CurrentValue <= 0)
                                            {
                                                Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                                Console.WriteLine("You have been incapacitated");
                                                Console.ReadLine();
                                                CombatMenu();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Your current Armor is: " + Stats.currentArmor.CurrentValue);
                                                Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                                Console.ReadLine();
                                                CombatMenu();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Stats.currentForceField.CurrentValue -= damageTakenToInt;
                                    if (Stats.currentForceField.CurrentValue < 0)
                                    {
                                        Stats.currentForceField.CurrentValue *= -1;
                                        Stats.currentArmor.CurrentValue -= Stats.currentForceField.CurrentValue;
                                        Stats.currentForceField.CurrentValue = 0;
                                        if (Stats.currentArmor.CurrentValue < 0)
                                        {
                                            Stats.currentArmor.CurrentValue *= -1;
                                            Stats.currentMDC.CurrentValue -= Stats.currentArmor.CurrentValue;
                                            Stats.currentArmor.CurrentValue = 0;
                                            if (Stats.currentMDC.CurrentValue <= 0)
                                            {
                                                Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                                Console.WriteLine("You have been incapacitated");
                                                Console.ReadLine();
                                                CombatMenu();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Your current Force Field is: " + Stats.currentForceField.CurrentValue);
                                                Console.WriteLine("Your current Armor is: " + Stats.currentArmor.CurrentValue);
                                                Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                                Console.ReadLine();
                                                CombatMenu();
                                            }
                                        }
                                    }
                                }
                                Console.WriteLine("Your current Force Field is: " + Stats.currentForceField.CurrentValue);
                                Console.WriteLine("Your current Armor is: " + Stats.currentArmor.CurrentValue);
                                Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                Console.ReadLine();
                                CombatMenu();
                            }
                            else
                            {
                                Console.WriteLine("Your current Force Field is: " + Stats.currentForceField.CurrentValue);
                                Console.WriteLine("Your current Armor is: " + Stats.currentArmor.CurrentValue);
                                Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
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
                            Console.WriteLine("You roll " + d20 + " for a total of " + (d20 + Stats.currentParry.CurrentValue));
                            Console.ReadLine();
                            Console.WriteLine("Were you hit?");
                            Console.WriteLine("1: Yes");
                            Console.WriteLine("2: No");
                            answer = char.Parse(Console.ReadLine());
                            if (answer == '1')
                            {
                                Console.WriteLine("How much damage did you take?");
                                string damageTaken = Console.ReadLine();
                                int damageTakenToInt = int.Parse(damageTaken);
                                if (Stats.currentForceField.CurrentValue == 0)
                                {
                                    if (Stats.currentArmor.CurrentValue == 0)
                                    {
                                        Stats.currentMDC.CurrentValue -= damageTakenToInt;
                                        if (Stats.currentMDC.CurrentValue <= 0)
                                        {
                                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                            Console.WriteLine("You have been incapacitated");
                                            Console.ReadLine();
                                            CombatMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                            Console.ReadLine();
                                            CombatMenu();
                                        }
                                    }
                                    else
                                    {
                                        Stats.currentArmor.CurrentValue -= damageTakenToInt;
                                        if (Stats.currentArmor.CurrentValue < 0)
                                        {
                                            Stats.currentArmor.CurrentValue *= -1;
                                            Stats.currentMDC.CurrentValue -= Stats.currentArmor.CurrentValue;
                                            Stats.currentArmor.CurrentValue = 0;
                                            if (Stats.currentMDC.CurrentValue <= 0)
                                            {
                                                Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                                Console.WriteLine("You have been incapacitated");
                                                Console.ReadLine();
                                                CombatMenu();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Your current Armor is: " + Stats.currentArmor.CurrentValue);
                                                Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                                Console.ReadLine();
                                                CombatMenu();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Stats.currentForceField.CurrentValue -= damageTakenToInt;
                                    if (Stats.currentForceField.CurrentValue < 0)
                                    {
                                        Stats.currentForceField.CurrentValue *= -1;
                                        Stats.currentArmor.CurrentValue -= Stats.currentForceField.CurrentValue;
                                        Stats.currentForceField.CurrentValue = 0;
                                        if (Stats.currentArmor.CurrentValue < 0)
                                        {
                                            Stats.currentArmor.CurrentValue *= -1;
                                            Stats.currentMDC.CurrentValue -= Stats.currentArmor.CurrentValue;
                                            Stats.currentArmor.CurrentValue = 0;
                                            if (Stats.currentMDC.CurrentValue <= 0)
                                            {
                                                Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                                Console.WriteLine("You have been incapacitated");
                                                Console.ReadLine();
                                                CombatMenu();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Your current Force Field is: " + Stats.currentForceField.CurrentValue);
                                                Console.WriteLine("Your current Armor is: " + Stats.currentArmor.CurrentValue);
                                                Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                                Console.ReadLine();
                                                CombatMenu();
                                            }
                                        }
                                    }
                                }
                                Console.WriteLine("Your current Force Field is: " + Stats.currentForceField.CurrentValue);
                                Console.WriteLine("Your current Armor is: " + Stats.currentArmor.CurrentValue);
                                Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                Console.ReadLine();
                                CombatMenu();
                            }
                            else
                            {
                                Console.WriteLine("Your current Force Field is: " + Stats.currentForceField.CurrentValue);
                                Console.WriteLine("Your current Armor is: " + Stats.currentArmor.CurrentValue);
                                Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                Console.ReadLine();
                                CombatMenu();
                            }
                            break;
                        }
                    case 2:
                        d20 = DiceRoll.RollD20();
                        Console.Clear();
                        Console.WriteLine("You attempt to dodge...");
                        Console.WriteLine("You roll " + d20 + " for a total of " + (d20 + Stats.currentDodge.CurrentValue));
                        if (Stats.currentPhysicalAtk.CurrentValue > 0)
                        {
                            Stats.currentPhysicalAtk.CurrentValue -= 1;
                        }
                        else
                        {
                            Stats.currentAllAtk.CurrentValue -= 1;
                        }
                        Console.ReadLine();
                        Console.WriteLine("Were you hit?");
                        Console.WriteLine("1: Yes");
                        Console.WriteLine("2: No");
                        answer = char.Parse(Console.ReadLine());
                        if (answer == '1')
                        {
                            Console.WriteLine("How much damage did you take?");
                            string damageTaken = Console.ReadLine();
                            int damageTakenToInt = int.Parse(damageTaken);
                            if (Stats.currentForceField.CurrentValue == 0)
                            {
                                if (Stats.currentArmor.CurrentValue == 0)
                                {
                                    Stats.currentMDC.CurrentValue -= damageTakenToInt;
                                    if (Stats.currentMDC.CurrentValue <= 0)
                                    {
                                        Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                        Console.WriteLine("You have been incapacitated");
                                        Console.ReadLine();
                                        CombatMenu();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                        Console.ReadLine();
                                        CombatMenu();
                                    }
                                }
                                else
                                {
                                    Stats.currentArmor.CurrentValue -= damageTakenToInt;
                                    if (Stats.currentArmor.CurrentValue < 0)
                                    {
                                        Stats.currentArmor.CurrentValue *= -1;
                                        Stats.currentMDC.CurrentValue -= Stats.currentArmor.CurrentValue;
                                        Stats.currentArmor.CurrentValue = 0;
                                        if (Stats.currentMDC.CurrentValue <= 0)
                                        {
                                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                            Console.WriteLine("You have been incapacitated");
                                            Console.ReadLine();
                                            CombatMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Your current Armor is: " + Stats.currentArmor.CurrentValue);
                                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                            Console.ReadLine();
                                            CombatMenu();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Stats.currentForceField.CurrentValue -= damageTakenToInt;
                                if (Stats.currentForceField.CurrentValue < 0)
                                {
                                    Stats.currentForceField.CurrentValue *= -1;
                                    Stats.currentArmor.CurrentValue -= Stats.currentForceField.CurrentValue;
                                    Stats.currentForceField.CurrentValue = 0;
                                    if (Stats.currentArmor.CurrentValue < 0)
                                    {
                                        Stats.currentArmor.CurrentValue *= -1;
                                        Stats.currentMDC.CurrentValue -= Stats.currentArmor.CurrentValue;
                                        Stats.currentArmor.CurrentValue = 0;
                                        if (Stats.currentMDC.CurrentValue <= 0)
                                        {
                                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                            Console.WriteLine("You have been incapacitated");
                                            Console.ReadLine();
                                            CombatMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Your current Force Field is: " + Stats.currentForceField.CurrentValue);
                                            Console.WriteLine("Your current Armor is: " + Stats.currentArmor.CurrentValue);
                                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                                            Console.ReadLine();
                                            CombatMenu();
                                        }
                                    }
                                }
                            }
                            Console.WriteLine("Your current Force Field is: " + Stats.currentForceField.CurrentValue);
                            Console.WriteLine("Your current Armor is: " + Stats.currentArmor.CurrentValue);
                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                            Console.ReadLine();
                            CombatMenu();
                        }
                        else
                        {
                            Console.WriteLine("Your current Force Field is: " + Stats.currentForceField.CurrentValue);
                            Console.WriteLine("Your current Armor is: " + Stats.currentArmor.CurrentValue);
                            Console.WriteLine("Your current MDC is: " + Stats.currentMDC.CurrentValue);
                            Console.ReadLine();
                            CombatMenu();
                        }
                        break;
                    case 3:
                        CombatMenu();
                        break;
                    default:
                        Console.WriteLine("You must make a valid selection");
                        Console.WriteLine("Press the Enter key to continue...");
                        Console.ReadLine();
                        CombatMenu();
                        break;
                }


            }
            catch (FormatException)
            {
                Console.WriteLine("You must make a valid selection");
                Console.WriteLine("Press the Enter key to continue...");
                Console.ReadLine();
            }

        }
    }
}
