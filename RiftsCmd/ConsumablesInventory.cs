using System;

namespace RiftsCmd
{
    class ConsumablesInventory
    {
        public string Name { get; set; }
        public int Charges { get; set; }
        public bool Used { get; set; }
        public ConsumablesInventory(string name, int charges, bool used)
        {
            Name = name;
            Charges = charges;
            Used = used;
        }

        public static ConsumablesInventory magicDBL = new ConsumablesInventory("Magic Doubler", 0, false);
        public static ConsumablesInventory magicRangeDBL = new ConsumablesInventory("Magic Range Doubler", 0, false);
        public static ConsumablesInventory magicDurDBL = new ConsumablesInventory("Magic Duration Doubler", 0, false);
        public static ConsumablesInventory magicRangeTimesTen = new ConsumablesInventory("Magic Range x10", 0, false);
        public static ConsumablesInventory magicMinusOneCrit = new ConsumablesInventory("Magic Crit -1", 0, false);
        public static ConsumablesInventory magicMinusTwoCrit = new ConsumablesInventory("Magic Crit -2", 0, false);
        public static ConsumablesInventory magicPlusThreeStrike = new ConsumablesInventory("Magic Strike +3", 0, false);
        public static ConsumablesInventory physicalSoulGauntletPlusThreeDmgPerLevel = new ConsumablesInventory("Soul Gauntlet +3Dmg/Level", 0, false);


        public static void SetConsumablesInv()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Set the values for each consumable");
                Console.Write(magicDBL.Name + ": ");
                string input = Console.ReadLine();
                int inputToInt = int.Parse(input);
                magicDBL.Charges = inputToInt;

                Console.Write(magicRangeDBL.Name + ": ");
                input = Console.ReadLine();
                inputToInt = int.Parse(input);
                magicRangeDBL.Charges = inputToInt;

                Console.Write(magicDurDBL.Name + ": ");
                input = Console.ReadLine();
                inputToInt = int.Parse(input);
                magicDurDBL.Charges = inputToInt;

                Console.Write(magicRangeTimesTen.Name + ": ");
                input = Console.ReadLine();
                inputToInt = int.Parse(input);
                magicRangeTimesTen.Charges = inputToInt;

                Console.Write(magicMinusOneCrit.Name + ": ");
                input = Console.ReadLine();
                inputToInt = int.Parse(input);
                magicMinusOneCrit.Charges = inputToInt;

                Console.Write(magicMinusTwoCrit.Name + ": ");
                input = Console.ReadLine();
                inputToInt = int.Parse(input);
                magicMinusTwoCrit.Charges = inputToInt;

                Console.Write(magicPlusThreeStrike.Name + ": ");
                input = Console.ReadLine();
                inputToInt = int.Parse(input);
                magicPlusThreeStrike.Charges = inputToInt;

                Console.Write(physicalSoulGauntletPlusThreeDmgPerLevel.Name + ": ");
                input = Console.ReadLine();
                inputToInt = int.Parse(input);
                physicalSoulGauntletPlusThreeDmgPerLevel.Charges = inputToInt;
            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter a valid option");
                Console.WriteLine("Press the Enter key to continue...");
                Console.ReadLine();
            }

        }

        public static void ViewConsumablesInv()
        {
            Console.Clear();
            Console.WriteLine("Here is your current consumables count:");
            Console.WriteLine("{0} has {1} charge(s)", magicDBL.Name, magicDBL.Charges);
            Console.WriteLine("{0} has {1} charge(s)", magicRangeDBL.Name, magicRangeDBL.Charges);
            Console.WriteLine("{0} has {1} charge(s)", magicDurDBL.Name, magicDurDBL.Charges);
            Console.WriteLine("{0} has {1} charge(s)", magicRangeTimesTen.Name, magicRangeTimesTen.Charges);
            Console.WriteLine("{0} has {1} charge(s)", magicMinusOneCrit.Name, magicMinusOneCrit.Charges);
            Console.WriteLine("{0} has {1} charge(s)", magicMinusTwoCrit.Name, magicMinusTwoCrit.Charges);
            Console.WriteLine("{0} has {1} charge(s)", magicPlusThreeStrike.Name, magicPlusThreeStrike.Charges);
            Console.WriteLine("{0} has {1} charge(s)", physicalSoulGauntletPlusThreeDmgPerLevel.Name, physicalSoulGauntletPlusThreeDmgPerLevel.Charges);
            Console.WriteLine("Press the Enter key to continue");
            Console.ReadLine();
        }

        public static void EditConsumablesInv()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Which consumable would you like to edit the quantity of?");
                Console.WriteLine("1: {0} ({1})", magicDBL.Name, magicDBL.Charges);
                Console.WriteLine("2: {0} ({1})", magicRangeDBL.Name, magicRangeDBL.Charges);
                Console.WriteLine("3: {0} ({1})", magicDurDBL.Name, magicDurDBL.Charges);
                Console.WriteLine("4: {0} ({1})", magicRangeTimesTen.Name, magicRangeTimesTen.Charges);
                Console.WriteLine("5: {0} ({1})", magicMinusOneCrit.Name, magicMinusOneCrit.Charges);
                Console.WriteLine("6: {0} ({1})", magicMinusTwoCrit.Name, magicMinusTwoCrit.Charges);
                Console.WriteLine("7: {0} ({1})", magicPlusThreeStrike.Name, magicPlusThreeStrike.Charges);
                Console.WriteLine("8: {0} ({1})", physicalSoulGauntletPlusThreeDmgPerLevel.Name, physicalSoulGauntletPlusThreeDmgPerLevel.Charges);
                Console.WriteLine("9: Return to Main Menu");
                string input = Console.ReadLine();
                int inputToInt = int.Parse(input);
                switch (inputToInt)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("What is the new quantity for {0}?", magicDBL.Name);
                        Console.Write("New Amount of Charges: ");
                        input = Console.ReadLine();
                        inputToInt = int.Parse(input);
                        magicDBL.Charges = inputToInt;
                        EditConsumablesInv();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("What is the new quantity for {0}?", magicRangeDBL.Name);
                        Console.Write("New Amount of Charges: ");
                        input = Console.ReadLine();
                        inputToInt = int.Parse(input);
                        magicRangeDBL.Charges = inputToInt;
                        EditConsumablesInv();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("What is the new quantity for {0}?", magicDurDBL.Name);
                        Console.Write("New Amount of Charges: ");
                        input = Console.ReadLine();
                        inputToInt = int.Parse(input);
                        magicDurDBL.Charges = inputToInt;
                        EditConsumablesInv();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("What is the new quantity for {0}?", magicRangeTimesTen.Name);
                        Console.Write("New Amount of Charges: ");
                        input = Console.ReadLine();
                        inputToInt = int.Parse(input);
                        magicRangeTimesTen.Charges = inputToInt;
                        EditConsumablesInv();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("What is the new quantity for {0}?", magicMinusOneCrit.Name);
                        Console.Write("New Amount of Charges: ");
                        input = Console.ReadLine();
                        inputToInt = int.Parse(input);
                        magicMinusOneCrit.Charges = inputToInt;
                        EditConsumablesInv();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("What is the new quantity for {0}?", magicMinusTwoCrit.Name);
                        Console.Write("New Amount of Charges: ");
                        input = Console.ReadLine();
                        inputToInt = int.Parse(input);
                        magicMinusTwoCrit.Charges = inputToInt;
                        EditConsumablesInv();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("What is the new quantity for {0}?", magicPlusThreeStrike.Name);
                        Console.Write("New Amount of Charges: ");
                        input = Console.ReadLine();
                        inputToInt = int.Parse(input);
                        magicPlusThreeStrike.Charges = inputToInt;
                        EditConsumablesInv();
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("What is the new quantity for {0}?", physicalSoulGauntletPlusThreeDmgPerLevel.Name);
                        Console.Write("New Amount of Charges: ");
                        input = Console.ReadLine();
                        inputToInt = int.Parse(input);
                        physicalSoulGauntletPlusThreeDmgPerLevel.Charges = inputToInt;
                        EditConsumablesInv();
                        break;
                    case 9:
                        MainApp.MainMenu();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter a valid option");
                Console.WriteLine("Press the Enter key to continue...");
                Console.ReadLine();
            }
        }
           

        public static void ConsumablesCheck()
        {
            try
            {

                bool again = true;
                while (again)
                {
                    Console.Clear();
                    Console.WriteLine("Which consumables are you using?");
                    Console.WriteLine("1: Magic Doubler");
                    Console.WriteLine("2: Magic Range Doubler");
                    Console.WriteLine("3: Magic Duration Doubler");
                    Console.WriteLine("4: Magic Range x10");
                    Console.WriteLine("5: Magic -1 Crit");
                    Console.WriteLine("6: Magic -2 Crit");
                    Console.WriteLine("7: Magic +3 Strike");
                    Console.WriteLine("8: Soul Gauntlet +3Dmg/Level");
                    Console.WriteLine("9: None/Done");
                    string input = Console.ReadLine();
                    int inputToInt = int.Parse(input);
                    switch (inputToInt)
                    {
                        case 1:
                            if (magicDBL.Used == true)
                            {
                                Console.WriteLine("You have already used this consumable this attack round!");
                                Console.WriteLine("Press the Enter key to continue");
                                Console.ReadLine();
                                break;
                            }
                            magicDBL.Used = true;
                            magicDBL.Charges -= 1;
                            break;
                        case 2:
                            if (magicRangeDBL.Used == true)
                            {
                                Console.WriteLine("You have already used this consumable this attack round!");
                                Console.WriteLine("Press the Enter key to continue");
                                Console.ReadLine();
                                break;
                            }
                            magicRangeDBL.Used = true;
                            magicRangeDBL.Charges -= 1;
                            break;
                        case 3:
                            if (magicDurDBL.Used == true)
                            {
                                Console.WriteLine("You have already used this consumable this attack round!");
                                Console.WriteLine("Press the Enter key to continue");
                                Console.ReadLine();
                                break;
                            }
                            magicDurDBL.Used = true;
                            magicDurDBL.Charges -= 1;
                            break;
                        case 4:
                            if (magicMinusOneCrit.Used == true)
                            {
                                Console.WriteLine("You have already used this consumable this attack round!");
                                Console.WriteLine("Press the Enter key to continue");
                                Console.ReadLine();
                                break;
                            }
                            magicMinusOneCrit.Used = true;
                            magicMinusOneCrit.Charges -= 1;
                            break;
                        case 5:
                            if (magicMinusOneCrit.Used == true)
                            {
                                Console.WriteLine("You have already used this consumable this attack round!");
                                Console.WriteLine("Press the Enter key to continue");
                                Console.ReadLine();
                                break;
                            }
                            magicMinusOneCrit.Used = true;
                            magicMinusOneCrit.Charges -= 1;
                            break;
                        case 6:
                            if (magicMinusTwoCrit.Used == true)
                            {
                                Console.WriteLine("You have already used this consumable this attack round!");
                                Console.WriteLine("Press the Enter key to continue");
                                Console.ReadLine();
                                break;
                            }
                            magicMinusTwoCrit.Used = true;
                            magicMinusTwoCrit.Charges -= 1;
                            break;
                        case 7:
                            if (magicPlusThreeStrike.Used == true)
                            {
                                Console.WriteLine("You have already used this consumable this attack round!");
                                Console.WriteLine("Press the Enter key to continue");
                                Console.ReadLine();
                                break;
                            }
                            magicPlusThreeStrike.Used = true;
                            magicPlusThreeStrike.Charges -= 1;
                            break;
                        case 8:
                            if (physicalSoulGauntletPlusThreeDmgPerLevel.Used == true)
                            {
                                Console.WriteLine("You have already used this consumable this attack round!");
                                Console.WriteLine("Press the Enter key to continue");
                                Console.ReadLine();
                                break;
                            }
                            physicalSoulGauntletPlusThreeDmgPerLevel.Used = true;
                            physicalSoulGauntletPlusThreeDmgPerLevel.Charges -= 1;
                            break;
                        case 9:
                            again = false;
                            break;
                    }

                }
                return;
            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter a valid option");
                Console.WriteLine("Press the Enter key to continue...");
                Console.ReadLine();
            }
        }
    }
}