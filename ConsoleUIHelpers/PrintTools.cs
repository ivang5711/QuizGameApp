using System;
using System.Diagnostics;

namespace ConsoleUIHelpers
{
    public static class PrintTools
    {
        /// <summary>
        /// draws a line of dash symbols of a specified length
        /// </summary>
        /// <param name="length">returns nothing if the length is null</param>
        public static void DrawLine(int? length)
        {
            if (length == null)
            {
                return;
            }

            int size = (int)length;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                PerformanceCounter parent = new PerformanceCounter("Process", "Creating Process ID", Process.GetCurrentProcess().ProcessName);
                int ppid = (int)parent.NextValue();
                if (Process.GetProcessById(ppid).ProcessName == "powershell")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }

            Console.WriteLine(new string('-', size));
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Encloses a menu number in square brackets of a grey color.
        /// </summary>
        /// <param name="number">Takes an int as an input</param>
        public static void MenuItem(int number)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            PrintGrey(number.ToString());
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Prints out the message with instructions on how to toggle full screen mode on console.
        /// </summary>
        public static void Fullscreen()
        {
            string text;
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                text = "Press <ALT + Enter> to toggle Full Screen mode";
            }
            else
            {
                text = "Press F11 to toggle Full Screen mode";
            }

            PrintGrey(text);
        }

        /// <summary>
        /// Prints out "Press any key to continue..." message in grey color and waits for a key to be pressed.
        /// </summary>
        public static void AnyKey()
        {
            PrintGrey("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prints the text provided with grey color.
        /// </summary>
        /// <param name="text">Checks if the string text is null, empty or whitespace and returns nothing in such case.</param>
        public static void PrintGrey(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Plays beep sound sequence to represent audio greeting message.
        /// </summary>
        public static void HelloBeep()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Console.Beep(200, 100);
                Console.Beep(400, 100);
                Console.Beep(800, 150);
                Console.Beep(200, 100);
            }
        }

        /// <summary>
        /// Plays beep soubd sequence to represent audio goodbuy message.
        /// </summary>
        public static void BuyBeep()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Console.Beep(800, 150);
                Console.Beep(400, 100);
                Console.Beep(800, 150);
                Console.Beep(400, 100);
            }
        }

        /// <summary>
        /// Prints out the welcome screen with welcome message.
        /// </summary>
        public static void WelcomeScreen(string message)
        {
            Console.Clear();
            Console.Title = "Quiz - Welcome!";
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                Console.BufferHeight = Console.LargestWindowHeight;
            }

            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int windowWidthCenter = windowWidth / 2;
            int windowHeightCenter = windowHeight / 2;
            Fullscreen();
            Console.CursorTop = windowHeightCenter - 2;
            string welcome = "Hello and welcome to the \"Quiz\"";
            int leftMargin = windowWidthCenter - welcome.Length / 2;
            Console.CursorLeft = leftMargin;
            Console.WriteLine(welcome);
            Console.CursorTop = windowHeightCenter - 1;
            if (message.Length > welcome.Length)
            {
                Console.CursorLeft = windowWidthCenter - message.Length / 2;
                DrawLine(message.Length);
            }
            else
            {
                Console.CursorLeft = leftMargin;
                DrawLine(30);
            }

            Console.CursorLeft = windowWidthCenter - message.Length / 2;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.CursorTop = windowHeightCenter + 2;
            Console.CursorLeft = leftMargin + 1;
            HelloBeep();
            AnyKey();
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
            DrawLine(welcomeText.Length);
            string helpMessage;
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                helpMessage = "The path to an application .exe file to execute.";
            }
            else
            {
                helpMessage = "The path to an application .dll file to execute.";
            }

            PrintGrey("Usage: [path-to-application] [arguments]\n\n");
            PrintGrey("Execute application.\n\n");
            PrintGrey("path-to-application:\n\t");
            PrintGrey(helpMessage + "\n");
            Console.WriteLine();
            Console.WriteLine();
            string arguments = "Arguments:";
            Console.WriteLine(arguments);
            DrawLine(arguments.Length);
            Console.WriteLine();
            Console.Write("--help".PadRight(12));
            PrintGrey("shows \"help page\"\n");
            Console.Write("-p".PadRight(12));
            PrintGrey("allows to run the app in persistent mode, so the user data can be loaded and saved\n");
            Console.WriteLine();
            Console.WriteLine();
            DrawLine(28);
            AnyKey();
            Console.ResetColor();
        }

        /// <summary>
        /// Prints out the menu screen with options to choose from and waits for the user input.
        /// </summary>
        /// <returns>Returns user's menu item choice as an integer value.</returns>
        public static int Menu()
        {
            Console.Clear();
            Console.Title = "Quiz - Main menu";
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int windowWidthCenter = windowWidth / 2;
            int windowHeightCenter = windowHeight / 2;
            int leftMargin = windowWidthCenter - 11;
            int menuNumber;
            Fullscreen();
            Console.CursorTop = windowHeightCenter - 8;
            Console.CursorLeft = windowWidthCenter - 8;
            Console.WriteLine("The \"Quiz\" game");
            Console.CursorLeft = leftMargin;
            DrawLine(21);
            Console.CursorLeft = leftMargin;
            MenuItem(1);
            Console.WriteLine(" Enter users");
            Console.CursorLeft = leftMargin;
            MenuItem(2);
            Console.WriteLine(" Enter questions");
            Console.CursorLeft = leftMargin;
            MenuItem(3);
            Console.WriteLine(" Pick user");
            Console.CursorLeft = leftMargin;
            MenuItem(4);
            Console.WriteLine(" Start quiz");
            Console.CursorLeft = leftMargin;
            MenuItem(5);
            Console.WriteLine(" About");
            Console.CursorLeft = leftMargin;
            MenuItem(6);
            Console.WriteLine(" To welcome screen");
            Console.CursorLeft = leftMargin;
            MenuItem(7);
            Console.WriteLine(" Exit");
            Console.CursorLeft = leftMargin;
            DrawLine(21);
            Console.WriteLine();
            Console.CursorLeft = windowWidthCenter - 10;
            PrintGrey("Enter menu number: ");
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
            Console.Title = "Quiz - see you soon!";
            ConsoleKeyInfo c;
            do
            {
                int windowWidth = Console.WindowWidth;
                int windowHeight = Console.WindowHeight;
                int windowHeightCenter = windowHeight / 2;
                int windowWidthCenter = windowWidth / 2;
                Console.Clear();
                Fullscreen();
                Console.CursorTop = windowHeightCenter - 2;
                Console.CursorLeft = windowWidthCenter - 14;
                Console.WriteLine("This was Quiz. See you soon!");
                Console.CursorTop = windowHeightCenter - 1;
                Console.CursorLeft = windowWidthCenter - 15;
                DrawLine(31);
                Console.CursorTop = windowHeightCenter + 1;
                Console.CursorLeft = windowWidthCenter - 13;
                PrintGrey("press Esc key to close...");
                c = Console.ReadKey(true);
            } while (c.Key != ConsoleKey.Escape);
            BuyBeep();
            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Prints out credits page with some information about the app and authors.
        /// </summary>
        public static void Credits()
        {
            Console.Clear();
            Console.Title = "Quiz - About";
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int windowWidthCenter = windowWidth / 2;
            int windowHeightCenter = windowHeight / 2;
            int leftMargin = windowWidthCenter - 36;
            Fullscreen();
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
            DrawLine(77);
            Console.CursorTop = windowHeightCenter + 6;
            leftMargin = windowWidthCenter - 15;
            Console.CursorLeft = leftMargin;
            AnyKey();
            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Asks for an answer
        /// </summary>
        /// <param name="length">length of the longest question</param>
        /// <param name="leftMargin">Cursor Left position</param>
        public static void AskForAnswer()
        {
            Console.Clear();
            Fullscreen();
            int windowHeightCenter = Console.WindowHeight / 2;
            Console.CursorTop = windowHeightCenter - 4;
            Console.WriteLine();
            Console.CursorLeft = (Console.WindowWidth - 16) / 2;
            Console.WriteLine("Enter an answer: ");
            Console.CursorLeft = (Console.WindowWidth - 16) / 2;
            DrawLine(16);
            Console.WriteLine();
            Console.CursorLeft = (Console.WindowWidth - 16) / 2;
        }

        /// <summary>
        /// Prints "You need to enter at least something message"
        /// </summary>
        /// <returns>returns "true" if ESC key pressed</returns>
        public static bool PrintEnterAtLeastSomething(int leftMargin)
        {
            Console.CursorLeft = leftMargin;
            Console.WriteLine("You need to enter at least something");
            Console.CursorLeft = leftMargin;
            Console.Write("Press Esc to exit or Enter to try again...");
            ConsoleKeyInfo c = Console.ReadKey();
            if (c.Key == ConsoleKey.Escape)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Prints a message to ask user to enter at least 1 item
        /// </summary>
        /// <param name="message">The message to print</param>
        /// <param name="leftMargin">cursor left position</param>
        public static void PrintEnterAtLeastOneItem(string message, int leftMargin)
        {
            Console.CursorLeft = (Console.WindowWidth - message.Length) / 2;
            Console.WriteLine(message);
            Console.CursorLeft = (Console.WindowWidth - message.Length) / 2;
            DrawLine(message.Length);
            Console.WriteLine();
            Console.CursorLeft = leftMargin;
            AnyKey();
            Console.CursorLeft = leftMargin;
            Console.ResetColor();
            Console.Clear();
        }
    }
}