using System;

namespace RiftsCmd
{
    class Stats
    {
        //TODO: Move this to a character sheet class
        public string Stat { get; set; }
        public string Value { get; set; }
        public Stats(string stat, string value)
        {
            Stat = stat;
            Value = value;
        }
        public static Stats sheetName = new Stats("Character Name", "");
        public static Stats sheetLevel = new Stats("Level", "");
        public static Stats sheetStrike = new Stats("Strike", "");
        public static Stats sheetParry = new Stats("Parry", "");
        public static Stats sheetDodge = new Stats("Dodge", "");
        public static Stats sheetCrit = new Stats("Critical Strike", "");
        public static Stats sheetAllAtk = new Stats("All Attacks", "");
        public static Stats sheetMagicalAtk = new Stats("Magical Attacks", "");
        public static Stats sheetPhysicalAtk = new Stats("Physical Attacks", "");
        public static Stats sheetMdc = new Stats("MDC", "");
        public static Stats sheetForceField = new Stats("Force Field", "");
        public static Stats sheetArmor = new Stats("Armor", "");
        public static Stats sheetPpe = new Stats("PPE", "");
        public static Stats sheetIsp = new Stats("ISP", "");
        public static Stats sheetDarkPoints = new Stats("Dark Points", "");


        public string CurrentStat { get; set; }
        public int CurrentValue { get; set; }
        public Stats(string currentStat, int currentValue)
        {
            CurrentStat = currentStat;
            CurrentValue = currentValue;
        }
        public static Stats currentRelativeSpellLevel = new Stats("Relative Spell Level", 0);
        public static Stats currentStrike = new Stats("Strike", 0);
        public static Stats currentParry = new Stats("Parry", 0);
        public static Stats currentDodge = new Stats("Dodge", 0);
        public static Stats currentCrit = new Stats("Critical Strike", 0);
        public static Stats currentAllAtk = new Stats("All Attacks", 0);
        public static Stats currentMagicalAtk = new Stats("Magical Attacks", 0);
        public static Stats currentPhysicalAtk = new Stats("Physical Attacks", 0);
        public static Stats currentMDC = new Stats("MDC", 0);
        public static Stats currentForceField = new Stats("Force Field", 0);
        public static Stats currentArmor = new Stats("Armor", 0);
        public static Stats currentPPE = new Stats("PPE", 0);
        public static Stats currentISP = new Stats("ISP", 0);
        public static Stats currentDarkPoints = new Stats("Dark Points", 0);



        public static void CreateOrViewCharacter()
        {
            if (String.IsNullOrEmpty(sheetName.Value) == true)
            {
                Console.Clear();
                CreateCharacter();
                InitializeNewCharacter();
                MainApp.Main();
            }
            else
            {
                ViewStats();
                MainApp.Main();
            }
        }

        public static void EditSheetStats()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Which character sheet stat do you want to edit?");
                Console.WriteLine("1: Name");
                Console.WriteLine("2: Level");
                Console.WriteLine("3: Strike");
                Console.WriteLine("4: Parry");
                Console.WriteLine("5: Dodge");
                Console.WriteLine("6: Crit");
                Console.WriteLine("7: All Attacks");
                Console.WriteLine("8: Magical Attacks");
                Console.WriteLine("9: Physical Attacks");
                Console.WriteLine("10: MDC");
                Console.WriteLine("11: ForceField");
                Console.WriteLine("12: Armor");
                Console.WriteLine("13: PPE");
                Console.WriteLine("14: ISP");
                Console.WriteLine("15: Dark Points");
                string input = Console.ReadLine();
                int inputToInt = int.Parse(input);
                switch (inputToInt)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("What is the new Name?");
                        Stats.sheetName.Value = Console.ReadLine();
                        CreateOrViewCharacter();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("What is the new Level?");
                        Stats.sheetLevel.Value = Console.ReadLine();
                        CreateOrViewCharacter();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("What is the new Strike?");
                        Stats.sheetStrike.Value = Console.ReadLine();
                        CreateOrViewCharacter();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("What is the new Parry?");
                        Stats.sheetParry.Value = Console.ReadLine();
                        CreateOrViewCharacter();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("What is the new Dodge?");
                        Stats.sheetDodge.Value = Console.ReadLine();
                        CreateOrViewCharacter();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("What is the new Critical Strike?");
                        Stats.sheetCrit.Value = Console.ReadLine();
                        CreateOrViewCharacter();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("What is the new All Attacks?");
                        Stats.sheetAllAtk.Value = Console.ReadLine();
                        CreateOrViewCharacter();
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("What is the new Magical Attacks?");
                        Stats.sheetMagicalAtk.Value = Console.ReadLine();
                        CreateOrViewCharacter();
                        break;
                    case 9:
                        Console.Clear();
                        Console.WriteLine("What is the new Physical Attacks?");
                        Stats.sheetPhysicalAtk.Value = Console.ReadLine();
                        CreateOrViewCharacter();
                        break;
                    case 10:
                        Console.Clear();
                        Console.WriteLine("What is the new MDC?");
                        Stats.sheetMdc.Value = Console.ReadLine();
                        CreateOrViewCharacter();
                        break;
                    case 11:
                        Console.Clear();
                        Console.WriteLine("What is the new Force Field?");
                        Stats.sheetForceField.Value = Console.ReadLine();
                        CreateOrViewCharacter();
                        break;
                    case 12:
                        Console.Clear();
                        Console.WriteLine("What is the new Armor?");
                        Stats.sheetArmor.Value = Console.ReadLine();
                        CreateOrViewCharacter();
                        break;
                    case 13:
                        Console.Clear();
                        Console.WriteLine("What is the new PPE?");
                        Stats.sheetPpe.Value = Console.ReadLine();
                        CreateOrViewCharacter();
                        break;
                    case 14:
                        Console.Clear();
                        Console.WriteLine("What is the new ISP?");
                        Stats.sheetIsp.Value = Console.ReadLine();
                        CreateOrViewCharacter();
                        break;
                    case 15:
                        Console.Clear();
                        Console.WriteLine("What is the new Dark Points?");
                        Stats.sheetDarkPoints.Value = Console.ReadLine();
                        CreateOrViewCharacter();
                        break;
                    case 16:
                        MainApp.MainMenu();
                        break;
                    default:
                        Console.WriteLine("You must make a valid selection");
                        Console.WriteLine("Press the Enter key to continue...");
                        Console.ReadLine();
                        MainApp.Main();
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

 
        public static void ViewStats()
        {
            Console.Clear();
            Console.WriteLine("Here are your character sheet stats:");
            Console.WriteLine("Your {0} is {1}", Stats.sheetName.Stat, Stats.sheetName.Value);
            Console.WriteLine("Your {0} is {1}", Stats.sheetLevel.Stat, Stats.sheetLevel.Value);
            Console.WriteLine("Your {0} is {1}", Stats.sheetStrike.Stat, Stats.sheetStrike.Value);
            Console.WriteLine("Your {0} is {1}", Stats.sheetParry.Stat, Stats.sheetParry.Value);
            Console.WriteLine("Your {0} is {1}", Stats.sheetDodge.Stat, Stats.sheetDodge.Value);
            Console.WriteLine("Your {0} is {1}", Stats.sheetCrit.Stat, Stats.sheetCrit.Value);
            Console.WriteLine("Your {0} is {1}", Stats.sheetAllAtk.Stat, Stats.sheetAllAtk.Value);
            Console.WriteLine("Your {0} is {1}", Stats.sheetMagicalAtk.Stat, Stats.sheetMagicalAtk.Value);
            Console.WriteLine("Your {0} is {1}", Stats.sheetPhysicalAtk.Stat, Stats.sheetPhysicalAtk.Value);
            Console.WriteLine("Your {0} is {1}", Stats.sheetMdc.Stat, Stats.sheetMdc.Value);
            Console.WriteLine("Your {0} is {1}", Stats.sheetForceField.Stat, Stats.sheetForceField.Value);
            Console.WriteLine("Your {0} is {1}", Stats.sheetArmor.Stat, Stats.sheetArmor.Value);
            Console.WriteLine("Your {0} is {1}", Stats.sheetPpe.Stat, Stats.sheetPpe.Value);
            Console.WriteLine("Your {0} is {1}", Stats.sheetIsp.Stat, Stats.sheetIsp.Value);
            Console.WriteLine("Your {0} is {1}", Stats.sheetDarkPoints.Stat, Stats.sheetDarkPoints.Value);
            Console.WriteLine("Press the Enter key to continue");
            Console.ReadLine();
        }

        public static void CreateCharacter()
        {
            Console.Clear();
            Console.Write("Input {0}: ", Stats.sheetName.Stat);
            Stats.sheetName.Value = Console.ReadLine();
            Console.Write("Input {0}: ", Stats.sheetLevel.Stat);
            Stats.sheetLevel.Value = Console.ReadLine();
            Console.Write("Input {0}: ", Stats.sheetStrike.Stat);
            Stats.sheetStrike.Value = Console.ReadLine();
            Console.Write("Input {0}: ", Stats.sheetParry.Stat);
            Stats.sheetParry.Value = Console.ReadLine();
            Console.Write("Input {0}: ", Stats.sheetDodge.Stat);
            Stats.sheetDodge.Value = Console.ReadLine();
            Console.Write("Input {0}: ", Stats.sheetCrit.Stat);
            Stats.sheetCrit.Value = Console.ReadLine();
            Console.Write("Input {0}: ", Stats.sheetAllAtk.Stat);
            Stats.sheetAllAtk.Value = Console.ReadLine();
            Console.Write("Input {0}: ", Stats.sheetMagicalAtk.Stat);
            Stats.sheetMagicalAtk.Value = Console.ReadLine();
            Console.Write("Input {0}: ", Stats.sheetPhysicalAtk.Stat);
            Stats.sheetPhysicalAtk.Value = Console.ReadLine();
            Console.Write("Input {0}: ", Stats.sheetMdc.Stat);
            Stats.sheetMdc.Value = Console.ReadLine();
            Console.Write("Input {0}: ", Stats.sheetForceField.Stat);
            Stats.sheetForceField.Value = Console.ReadLine();
            Console.Write("Input {0}: ", Stats.sheetArmor.Stat);
            Stats.sheetArmor.Value = Console.ReadLine();
            Console.Write("Input {0}: ", Stats.sheetPpe.Stat);
            Stats.sheetPpe.Value = Console.ReadLine();
            Console.Write("Input {0}: ", Stats.sheetIsp.Stat);
            Stats.sheetIsp.Value = Console.ReadLine();
            Console.Write("Input {0}: ", Stats.sheetDarkPoints.Stat);
            Stats.sheetDarkPoints.Value = Console.ReadLine();
        }

        public static void InitializeNewCharacter()
        {
            try
            {
            Stats.currentRelativeSpellLevel.CurrentValue = int.Parse(Stats.sheetLevel.Value);
            Stats.currentStrike.CurrentValue = int.Parse(Stats.sheetStrike.Value);
            Stats.currentParry.CurrentValue = int.Parse(Stats.sheetParry.Value);
            Stats.currentDodge.CurrentValue = int.Parse(Stats.sheetDodge.Value);
            Stats.currentCrit.CurrentValue = int.Parse(Stats.sheetCrit.Value);
            Stats.currentAllAtk.CurrentValue = int.Parse(Stats.sheetAllAtk.Value);
            Stats.currentMagicalAtk.CurrentValue = int.Parse(Stats.sheetMagicalAtk.Value);
            Stats.currentPhysicalAtk.CurrentValue = int.Parse(Stats.sheetPhysicalAtk.Value);
            Stats.currentMDC.CurrentValue = int.Parse(Stats.sheetMdc.Value);
            Stats.currentForceField.CurrentValue = int.Parse(Stats.sheetForceField.Value);
            Stats.currentArmor.CurrentValue = int.Parse(Stats.sheetArmor.Value);
            Stats.currentPPE.CurrentValue = int.Parse(Stats.sheetPpe.Value);
            Stats.currentISP.CurrentValue = int.Parse(Stats.sheetIsp.Value);
            Stats.currentDarkPoints.CurrentValue = int.Parse(Stats.sheetDarkPoints.Value);
            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter whole numbers for your character's stats...");
                Stats.sheetName.Value = "";
                Console.WriteLine("Press the Enter key to continue...");
                Console.ReadLine();
                CreateOrViewCharacter();
            }
        }
    }
}