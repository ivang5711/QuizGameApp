using System;
using System.Diagnostics;

namespace ConsoleUIHelpersLibrary
{
    /// <summary>
    /// Utility Class to support Console User Interface
    /// </summary>
    public static class PrintTools
    {
        private static readonly ConsoleColor consoleColor = InitPrintTools();

        private static ConsoleColor InitPrintTools()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                PerformanceCounter parent = new PerformanceCounter("Process", "Creating Process ID", Process.GetCurrentProcess().ProcessName);
                int ppid = (int)parent.NextValue();
                if (Process.GetProcessById(ppid).ProcessName == "powershell")
                {
                    return ConsoleColor.Yellow;
                }
            }

            return ConsoleColor.DarkYellow;
        }

        /// <summary>
        /// Sets a title of the Conole window
        /// </summary>
        /// <param name="title"></param>
        public static void SetConsoleWindowTitle(string title) => Console.Title = title;

        /// <summary>
        /// draws a line of dash symbols of a specified length
        /// </summary>
        /// <param name="length">returns nothing if the length is null</param>
        public static void DrawLine(int length = 0)
        {
            if (length == 0)
            {
                return;
            }

            int size = length;

            Console.ForegroundColor = consoleColor;
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
        /// Asks for an answer
        /// </summary>
        /// <param name="length">length of the longest question</param>
        /// <param name="leftMargin">Cursor Left position</param>
        public static void AskForAnswer()
        {
            Console.Clear();
            Fullscreen();
            int leftMargin = (Console.WindowWidth - 16) / 2;
            Console.CursorTop = (Console.WindowHeight / 2) - 4;
            Console.CursorTop++;
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Enter an answer: ");
            Console.CursorLeft = leftMargin;
            DrawLine(16);
            Console.CursorTop++;
            Console.CursorLeft = leftMargin;
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
            Console.CursorTop++;
            Console.CursorLeft = leftMargin;
            AnyKey();
            Console.CursorLeft = leftMargin;
            Console.ResetColor();
            Console.Clear();
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
    }
}