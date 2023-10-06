using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUIHelpersLibrary
{
    /// <summary>
    /// Utility class to print out the Console User Interface Screens
    /// </summary>
    public static class Screens
    {
        /// <summary>
        /// Prints out the welcome screen with welcome message.
        /// </summary>
        public static void WelcomeScreen(string message)
        {
            Console.Clear();
            Console.ResetColor();
            PrintTools.SetConsoleWindowTitle("Quiz - Welcome!");
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                Console.BufferHeight = Console.LargestWindowHeight;
            }

            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int windowWidthCenter = windowWidth / 2;
            int windowHeightCenter = windowHeight / 2;
            PrintTools.Fullscreen();
            Console.CursorTop = windowHeightCenter - 2;
            string welcome = "Hello and welcome to the \"Quiz\"";
            int leftMargin = windowWidthCenter - welcome.Length / 2;
            Console.CursorLeft = leftMargin;
            Console.WriteLine(welcome);
            Console.CursorTop = windowHeightCenter - 1;
            if (message.Length > welcome.Length)
            {
                Console.CursorLeft = windowWidthCenter - message.Length / 2;
                PrintTools.DrawLine(message.Length);
            }
            else
            {
                Console.CursorLeft = leftMargin;
                PrintTools.DrawLine(30);
            }

            Console.CursorLeft = windowWidthCenter - message.Length / 2;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.CursorTop = windowHeightCenter + 2;
            Console.CursorLeft = leftMargin + 1;
            PrintTools.HelloBeep();
            PrintTools.AnyKey();
            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Prints out Help page
        /// </summary>
        public static void PrintHelp()
        {
            Console.ForegroundColor = ConsoleColor.White;
            string welcomeText = "Welcome to the Quiz help page!";
            Console.WriteLine(welcomeText);
            PrintTools.DrawLine(welcomeText.Length);
            string helpMessage;
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                helpMessage = "The path to an application .exe file to execute.";
            }
            else
            {
                helpMessage = "The path to an application .dll file to execute.";
            }

            PrintTools.PrintGrey("Usage: [path-to-application] [arguments]\n\n");
            PrintTools.PrintGrey("Execute application.\n\n");
            PrintTools.PrintGrey("path-to-application:\n\t");
            PrintTools.PrintGrey(helpMessage + "\n");
            Console.CursorTop += 2;
            string arguments = "Arguments:";
            Console.WriteLine(arguments);
            PrintTools.DrawLine(arguments.Length);
            Console.CursorTop++;
            Console.Write("--help".PadRight(12));
            PrintTools.PrintGrey("shows \"help page\"\n");
            Console.Write("-p".PadRight(12));
            PrintTools.PrintGrey("allows to run the app in persistent mode, so the user data can be loaded and saved\n");
            Console.CursorTop += 2;
            PrintTools.DrawLine(28);
            PrintTools.AnyKey();
            Console.ResetColor();
        }

        /// <summary>
        /// Prints out the menu screen with options to choose from and waits for the user input.
        /// </summary>
        /// <returns>Returns user's menu item choice as an integer value.</returns>
        public static int Menu()
        {
            Console.Clear();
            PrintTools.SetConsoleWindowTitle("Quiz - Main menu");
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int windowWidthCenter = windowWidth / 2;
            int windowHeightCenter = windowHeight / 2;
            int leftMargin = windowWidthCenter - 11;
            int menuNumber;
            PrintTools.Fullscreen();
            Console.CursorTop = windowHeightCenter - 8;
            Console.CursorLeft = windowWidthCenter - 8;
            Console.WriteLine("The \"Quiz\" game");
            Console.CursorLeft = leftMargin;
            PrintTools.DrawLine(21);
            Console.CursorLeft = leftMargin;
            PrintTools.MenuItem(1);
            Console.WriteLine(" Enter users");
            Console.CursorLeft = leftMargin;
            PrintTools.MenuItem(2);
            Console.WriteLine(" Enter questions");
            Console.CursorLeft = leftMargin;
            PrintTools.MenuItem(3);
            Console.WriteLine(" Pick user");
            Console.CursorLeft = leftMargin;
            PrintTools.MenuItem(4);
            Console.WriteLine(" Start quiz");
            Console.CursorLeft = leftMargin;
            PrintTools.MenuItem(5);
            Console.WriteLine(" About");
            Console.CursorLeft = leftMargin;
            PrintTools.MenuItem(6);
            Console.WriteLine(" To welcome screen");
            Console.CursorLeft = leftMargin;
            PrintTools.MenuItem(7);
            Console.WriteLine(" Exit");
            Console.CursorLeft = leftMargin;
            PrintTools.DrawLine(21);
            Console.CursorTop++;
            Console.CursorLeft = windowWidthCenter - 10;
            PrintTools.PrintGrey("Enter menu number: ");
            try
            {
                menuNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                return 0;
            }

            Console.ResetColor();
            Console.Clear();
            return menuNumber;
        }

        /// <summary>
        /// Prints out the Goodbuy screen.
        /// </summary>
        public static void Goodbuy()
        {
            Console.Clear();
            PrintTools.SetConsoleWindowTitle("Quiz - see you soon!");
            ConsoleKeyInfo c;
            do
            {
                int windowWidth = Console.WindowWidth;
                int windowHeight = Console.WindowHeight;
                int windowHeightCenter = windowHeight / 2;
                int windowWidthCenter = windowWidth / 2;
                Console.Clear();
                PrintTools.Fullscreen();
                Console.CursorTop = windowHeightCenter - 2;
                Console.CursorLeft = windowWidthCenter - 14;
                Console.WriteLine("This was Quiz. See you soon!");
                Console.CursorTop = windowHeightCenter - 1;
                Console.CursorLeft = windowWidthCenter - 15;
                PrintTools.DrawLine(31);
                Console.CursorTop = windowHeightCenter + 1;
                Console.CursorLeft = windowWidthCenter - 13;
                PrintTools.PrintGrey("press Esc key to close...");
                c = Console.ReadKey(true);
            } while (c.Key != ConsoleKey.Escape);
            PrintTools.BuyBeep();
            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Prints out credits page with some information about the app and authors.
        /// </summary>
        public static void Credits()
        {
            Console.Clear();
            PrintTools.SetConsoleWindowTitle("Quiz - About");
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int windowWidthCenter = windowWidth / 2;
            int windowHeightCenter = windowHeight / 2;
            int leftMargin = windowWidthCenter - 36;
            PrintTools.Fullscreen();
            Console.CursorTop = windowHeightCenter - 8;
            Console.CursorLeft = leftMargin;
            Console.WriteLine("This app designed to automate the quiz game.\n");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("You can add as many users and questions as you want.\n");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("The app defines a winner by comparing the overall score of each player.\n");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("To load and save your game results as well as users and questions ");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("you can use persistent mode by providing \"-p\" command line argument on start.\n\n");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("You can also get help with \"--help\" command line argument.\n\n");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Have a nice Quiz!");
            Console.CursorLeft = leftMargin;
            PrintTools.DrawLine(77);
            Console.CursorTop = windowHeightCenter + 6;
            leftMargin = windowWidthCenter - 15;
            Console.CursorLeft = leftMargin;
            PrintTools.AnyKey();
            Console.ResetColor();
            Console.Clear();
        }
    }
}
