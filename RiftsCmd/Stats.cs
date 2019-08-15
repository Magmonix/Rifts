using System;

namespace RiftsCmd
{
    class Stats
    {
        public static string[] stats = new string[14];
        public static string name;
        public static int strike;
        public static int parry;
        public static int dodge;
        public static int crit;
        public static int allAtk;
        public static int magicalAtk;
        public static int physicalAtk;
        public static int MDC;
        public static int forceField;
        public static int armor;
        public static int PPE;
        public static int ISP;
        public static int darkPoints;
        public static int currentStrike;
        public static int currentParry;
        public static int currentDodge;
        public static int currentCrit;
        public static int currentAllAtk;
        public static int currentMagicalAtk;
        public static int currentPhysicalAtk;
        public static int currentMDC;
        public static int currentForceField;
        public static int currentArmor;
        public static int currentPPE;
        public static int currentISP;
        public static int currentDarkPoints;



        public static void CreateOrViewCharacter()
        {
            if (String.IsNullOrEmpty(stats[0]) == true) //Create Character
            {
                Console.Clear();
                stats = GetStats();
                InitializeStats();
                OutputStats(name, strike, parry, dodge, crit, allAtk, magicalAtk, physicalAtk, MDC, forceField, armor, PPE, ISP, darkPoints);
                MainApp.Main();
            }
            else //View Stats
            {
                Console.Clear();
                ReinitializeStats();
                OutputStats(name, strike, parry, dodge, crit, allAtk, magicalAtk, physicalAtk, MDC, forceField, armor, PPE, ISP, darkPoints);
                MainApp.Main();
            }
        }

        public static void EditStats()
        {
            //TODO: Add exception for a character not existing. Should we ask to redirect user to CreateOrViewCharacter()?

            Console.Clear();
            Console.WriteLine("Which stat do you want to edit?");
            Console.WriteLine("1: Name");
            Console.WriteLine("2: Strike");
            Console.WriteLine("3: Parry");
            Console.WriteLine("4: Dodge");
            Console.WriteLine("5: Crit");
            Console.WriteLine("6: All Attacks");
            Console.WriteLine("7: Magical Attacks");
            Console.WriteLine("8: Physical Attacks");
            Console.WriteLine("9: MDC");
            Console.WriteLine("10: ForceField");
            Console.WriteLine("11: Armor");
            Console.WriteLine("12: PPE");
            Console.WriteLine("13: ISP");
            Console.WriteLine("14: Dark Points");
            string input = Console.ReadLine();
            int inputToInt = int.Parse(input);
            switch (inputToInt)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("What is the new Name?");
                    stats[0] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("What is the new Strike?");
                    stats[1] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("What is the new Parry?");
                    stats[2] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("What is the new Dodge?");
                    stats[3] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("What is the new Crit?");
                    stats[4] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("What is the new All Attacks?");
                    stats[5] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;                
                case 7:
                    Console.Clear();
                    Console.WriteLine("What is the new Magical Attacks?");
                    stats[6] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("What is the new Physical Attacks?");
                    stats[7] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 9:
                    Console.Clear();
                    Console.WriteLine("What is the new MDC?");
                    stats[8] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 10:
                    Console.Clear();
                    Console.WriteLine("What is the new Force Field?");
                    stats[9] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 11:
                    Console.Clear();
                    Console.WriteLine("What is the new Armor?");
                    stats[10] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 12:
                    Console.Clear();
                    Console.WriteLine("What is the new PPE?");
                    stats[11] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 13:
                    Console.Clear();
                    Console.WriteLine("What is the new ISP?");
                    stats[12] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 14:
                    Console.Clear();
                    Console.WriteLine("What is the new Dark Points?");
                    stats[13] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                default:
                    Console.WriteLine("You must make a valid selection");
                    Console.ReadLine();
                    MainApp.Main();
                    break;

            }


        }

        public static void OutputStats(string name, int strike, int parry, int dodge, 
                                        int crit, int allAtk, int magicalAtk, int physicalAtk, int MDC, int forceField, 
                                        int armor, int PPE, int ISP, int darkPoints)
        {
            Console.Clear();
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Strike: " + strike);
            Console.WriteLine("Parry: " + parry);
            Console.WriteLine("Dodge: " + dodge);
            Console.WriteLine("Crit: " + crit);
            Console.WriteLine("All Atk's: " + allAtk);
            Console.WriteLine("Magic Atk's: " + magicalAtk);
            Console.WriteLine("Physical Atk's: " + physicalAtk);
            Console.WriteLine("MDC: " + MDC);
            Console.WriteLine("Force Field: " + forceField);
            Console.WriteLine("Armor: " + armor);
            Console.WriteLine("PPE: " + PPE);
            Console.WriteLine("ISP: " + ISP);
            Console.WriteLine("Dark Points: " + darkPoints);
            Console.ReadLine();
        }

        public static void InitializeStats()
        {
            name = stats[0];
            strike = int.Parse(stats[1]);
            parry = int.Parse(stats[2]);
            dodge = int.Parse(stats[3]);
            crit = int.Parse(stats[4]);
            allAtk = int.Parse(stats[5]);
            magicalAtk = int.Parse(stats[6]);
            physicalAtk = int.Parse(stats[7]);
            MDC = int.Parse(stats[8]);
            forceField = int.Parse(stats[9]);
            armor = int.Parse(stats[10]);
            PPE = int.Parse(stats[11]);
            ISP = int.Parse(stats[12]);
            darkPoints = int.Parse(stats[13]);
            currentStrike = int.Parse(stats[1]);
            currentParry = int.Parse(stats[2]);
            currentDodge = int.Parse(stats[3]);
            currentCrit = int.Parse(stats[4]);
            currentAllAtk = int.Parse(stats[5]);
            currentMagicalAtk = int.Parse(stats[6]);
            currentPhysicalAtk = int.Parse(stats[7]);
            currentMDC = int.Parse(stats[8]);
            currentForceField = int.Parse(stats[9]);
            currentArmor = int.Parse(stats[10]);
            currentPPE = int.Parse(stats[11]);
            currentISP = int.Parse(stats[12]);
            currentDarkPoints = int.Parse(stats[13]);
        }
        public static void ReinitializeStats()
        {
            name = stats[0];
            strike = int.Parse(stats[1]);
            parry = int.Parse(stats[2]);
            dodge = int.Parse(stats[3]);
            crit = int.Parse(stats[4]);
            allAtk = int.Parse(stats[5]);
            magicalAtk = int.Parse(stats[6]);
            physicalAtk = int.Parse(stats[7]);
            MDC = int.Parse(stats[8]);
            forceField = int.Parse(stats[9]);
            armor = int.Parse(stats[10]);
            PPE = int.Parse(stats[11]);
            ISP = int.Parse(stats[12]);
            darkPoints = int.Parse(stats[13]);
        }

        public static string[] GetStats() //Run each of the gets and save the returns to a string array
        {
            stats[0] = GetName();
            stats[1] = GetStrike();
            stats[2] = GetParry();
            stats[3] = GetDodge();
            stats[4] = GetCrit();
            stats[5] = GetAllAtk();
            stats[6] = GetMagicalAtk();
            stats[7] = GetPhysicalAtk();
            stats[8] = GetMDC();
            stats[9] = GetForceField();
            stats[10] = GetArmor();
            stats[11] = GetPPE();
            stats[12]= GetISP();
            stats[13]= GetDarkPoints();
            return (stats);
        }

        //This region is the legwork of stats input
        #region GETSTATS
        public static string GetName()
        {
            Console.Write("Input Character name: ");
            string name = Console.ReadLine();
            return (name);
        }
        public static string GetStrike()
        {
            Console.Write("Input Strike: ");
            string strike = Console.ReadLine();
            return (strike);
        }
        public static string GetParry()
        {
            Console.Write("Input Parry: ");
            string parry = Console.ReadLine();
            return (parry);
        }
        public static string GetDodge()
        {
            Console.Write("Input Dodge: ");
            string dodge = Console.ReadLine();
            return (dodge);
        }
        public static string GetCrit()
        {
            Console.Write("Input Crit: ");
            string crit = Console.ReadLine();
            return (crit);
        }
        public static string GetAllAtk()
        {
            Console.Write("Input All Atk: ");
            string atk = Console.ReadLine();
            return (atk);
        }
        public static string GetMagicalAtk()
        {
            Console.Write("Input Magical Atk: ");
            string atk = Console.ReadLine();
            return (atk);
        }        
        public static string GetPhysicalAtk()
        {
            Console.Write("Input Physical Atk: ");
            string atk = Console.ReadLine();
            return (atk);
        }
        public static string GetMDC()
        {
            Console.Write("Input MDC: ");
            string mdc = Console.ReadLine();
            return (mdc);
        }
        public static string GetForceField()
        {
            Console.Write("Input ForceField: ");
            string forceField = Console.ReadLine();
            return (forceField);
        }
        public static string GetArmor()
        {
            Console.Write("Input Armor: ");
            string armor = Console.ReadLine();
            return (armor);
        }
        public static string GetPPE()
        {
            Console.Write("Input PPE: ");
            string ppe = Console.ReadLine();
            return (ppe);
        }
        public static string GetISP()
        {
            Console.Write("Input ISP: ");
            string isp = Console.ReadLine();
            return (isp);
        }
        public static string GetDarkPoints()
        {
            Console.Write("Input Dark Points: ");
            string darkPoints = Console.ReadLine();
            return (darkPoints);
        }
        #endregion
    }
}