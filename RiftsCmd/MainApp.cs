﻿using System;

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
            Console.Clear();
            Console.WriteLine("Welcome to the RIFTS Character Sheet Maintainer or RCSM");
            Console.WriteLine("Please choose one of the following options:"); //TODO: Display their character's name if one exists.
            Console.WriteLine("1: Create/View Character");
            Console.WriteLine("2: Edit Character's stats");//TODO: If a character exists we should use the character's name instead of "character's".
            Console.WriteLine("3: Enter Combat");
            Console.WriteLine("9: Exit Application");
            string choice = Console.ReadLine();
            int choiceToInt = int.Parse(choice);
            switch (choiceToInt)
            {
                case 1:
                    Stats.CreateOrViewCharacter();
                    break;
                case 2:
                    Stats.EditStats();
                    break;
                case 3:
                    Combat.InitCombat();
                    Combat.CombatMenu();
                    break;
                case 9:
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("You must make a valid selection");
                    Console.ReadLine();
                    Main();
                    break;
            }
        }
    }

}
