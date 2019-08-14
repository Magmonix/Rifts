using System;

namespace RiftsCmd
{
    class Stats
    {
        public static string[] stats = new string[12];
        public static string name;
        public static int strike;
        public static int parry;
        public static int dodge;
        public static int crit;
        public static int atk;
        public static int MDC;
        public static int forceField;
        public static int armor;
        public static int PPE;
        public static int ISP;
        public static int darkPoints;



        public static void CreateOrViewCharacter()
        {
            if (String.IsNullOrEmpty(stats[0]) == true) //Create Character
            {
                Console.Clear();
                stats = GetStats(); //Get the character's stats
                ReinitializeStats();
                OutputStats(name, strike, parry, dodge, crit, atk, MDC, forceField, armor, PPE, ISP, darkPoints); //Output these stats to the console
                MainApp.Main();
            }
            else //View Created Character's Stats
            {
                Console.Clear();
                ReinitializeStats();
                OutputStats(name, strike, parry, dodge, crit, atk, MDC, forceField, armor, PPE, ISP, darkPoints);
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
            Console.WriteLine("6: ATK");
            Console.WriteLine("7: MDC");
            Console.WriteLine("8: ForceField");
            Console.WriteLine("9: Armor");
            Console.WriteLine("10: PPE");
            Console.WriteLine("11: ISP");
            Console.WriteLine("12: Dark Points");
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
                    Console.WriteLine("What is the new ATK?");
                    stats[5] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("What is the new MDC?");
                    stats[6] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("What is the new Force Field?");
                    stats[7] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 9:
                    Console.Clear();
                    Console.WriteLine("What is the new Armor?");
                    stats[8] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 10:
                    Console.Clear();
                    Console.WriteLine("What is the new PPE?");
                    stats[9] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 11:
                    Console.Clear();
                    Console.WriteLine("What is the new ISP?");
                    stats[10] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                case 12:
                    Console.Clear();
                    Console.WriteLine("What is the new Dark Points?");
                    stats[11] = Console.ReadLine();
                    CreateOrViewCharacter();
                    break;
                default:
                    Console.WriteLine("You must make a valid selection");
                    Console.ReadKey();
                    MainApp.Main();
                    break;

            }


        }

        public static void OutputStats(string name, int strike, int parry, int dodge, 
                                        int crit, int atk, int MDC, int forceField, 
                                        int armor, int PPE, int ISP, int darkPoints)
        {
            Console.Clear();
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Strike: " + strike);
            Console.WriteLine("Parry: " + parry);
            Console.WriteLine("Dodge: " + dodge);
            Console.WriteLine("Crit: " + crit);
            Console.WriteLine("ATK's: " + atk);
            Console.WriteLine("MDC: " + MDC);
            Console.WriteLine("Force Field: " + forceField);
            Console.WriteLine("Armor: " + armor);
            Console.WriteLine("PPE: " + PPE);
            Console.WriteLine("ISP: " + ISP);
            Console.WriteLine("Dark Points: " + darkPoints);
            Console.ReadLine();
        }

        public static void ReinitializeStats()
        {
            name = stats[0]; //Save each stat as its own variable so we don't have to know that stats[0] is the name, etc.
            strike = int.Parse(stats[1]);
            parry = int.Parse(stats[2]);
            dodge = int.Parse(stats[3]);
            crit = int.Parse(stats[4]);
            atk = int.Parse(stats[5]);
            MDC = int.Parse(stats[6]);
            forceField = int.Parse(stats[7]);
            armor = int.Parse(stats[8]);
            PPE = int.Parse(stats[9]);
            ISP = int.Parse(stats[10]);
            darkPoints = int.Parse(stats[11]);
        }

        public static string[] GetStats() //Run each of the gets and save the returns to a string array
        {
            stats[0] = GetName();
            stats[1] = GetStrike();
            stats[2] = GetParry();
            stats[3] = GetDodge();
            stats[4] = GetCrit();
            stats[5] = GetAtk();
            stats[6] = GetMDC();
            stats[7] = GetForceField();
            stats[8] = GetArmor();
            stats[9] = GetPPE();
            stats[10]= GetISP();
            stats[11]= GetDarkPoints();
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
        public static string GetAtk()
        {
            Console.Write("Input Atk: ");
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
