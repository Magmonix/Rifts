using System;

namespace RiftsCmd
{
    class MainApp
    {

        public static void Main()
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Welcome to the RIFTS Character Sheet Maintainer or RCSM");
                Console.WriteLine("Please choose one of the following options:"); //TODO: Display their character's name if one exists.
                Console.WriteLine("1: Create/View character");
                Console.WriteLine("2: Edit character's stats"); //TODO: If a character exists we should use the character's name instead of "character's".
                Console.WriteLine("3: Enter combat");
                Console.WriteLine("4: Set consumables inventory");
                Console.WriteLine("5: View consumables inventory");
                Console.WriteLine("6: Edit consumables inventory");
                Console.WriteLine("9: Exit Application");
                string choice = Console.ReadLine();
                int choiceToInt = int.Parse(choice);
                switch (choiceToInt)
                {
                    case 1:
                        Stats.CreateOrViewCharacter();
                        break;
                    case 2:
                        if (String.IsNullOrEmpty(Stats.sheetName.Value) == true)
                        {
                            Console.Clear();
                            Console.WriteLine("No character currently exists");
                            Console.WriteLine("Would you like to create a character instead?");
                            Console.WriteLine("1: Yes");
                            Console.WriteLine("2: No");
                            choice = Console.ReadLine();
                            choiceToInt = int.Parse(choice);
                            switch (choiceToInt)
                            {
                                case 1:
                                    Stats.CreateOrViewCharacter();
                                    break;
                                case 2:
                                    Stats.EditSheetStats();
                                    break;
                                default:
                                    Console.WriteLine("You must make a valid selection");
                                    Console.WriteLine("Press the Enter key to continue");
                                    Console.ReadLine();
                                    Main();
                                    break;
                            }
                        }
                        break;
                    case 3:
                        Combat.InitCombat();
                        Combat.CombatMenu();
                        break;
                    case 4:
                        ConsumablesInventory.SetConsumablesInv();
                        MainMenu();
                        break;
                    case 5:
                        ConsumablesInventory.ViewConsumablesInv();
                        MainMenu();
                        break;
                    case 6:
                        ConsumablesInventory.EditConsumablesInv();
                        MainMenu();
                        break;
                    case 9:
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("You must make a valid selection");
                        Console.WriteLine("Press the Enter key to continue");
                        Console.ReadLine();
                        Main();
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
    }
}

