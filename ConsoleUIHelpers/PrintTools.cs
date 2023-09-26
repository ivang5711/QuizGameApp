using System;
using System.Diagnostics;

namespace ConsoleUIHelpers
{
    public class PrintTools
    {
        /// <summary>
        /// Draws a line of dash symbols of length 31.
        /// </summary>
        public void DrawLine()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Process p = Process.GetCurrentProcess();
                PerformanceCounter parent = new PerformanceCounter("Process", "Creating Process ID", p.ProcessName);
                int ppid = (int)parent.NextValue();

                if (Process.GetProcessById(ppid).ProcessName == "powershell")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }

            string tmp = new string('-', 31);
            Console.WriteLine(tmp);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// draws a line of dash symbols of a specified length
        /// </summary>
        /// <param name="length">returns nothing if the length is null</param>
        public void DrawLine(int? length)
        {
            int size;
            if (length == null)
            {
                return;
            }
            else
            {
                size = Convert.ToInt32(length);
            }

            string tmp = new string('-', size);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Process p = Process.GetCurrentProcess();
                PerformanceCounter parent = new PerformanceCounter("Process", "Creating Process ID", p.ProcessName);
                int ppid = (int)parent.NextValue();

                if (Process.GetProcessById(ppid).ProcessName == "powershell")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }

            Console.WriteLine(tmp);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Encloses a menu number in square brackets of a grey color.
        /// </summary>
        /// <param name="number">Takes an int as an input</param>
        public void MenuItem(int number)
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
        public void Fullscreen()
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
        public void AnyKey()
        {
            string text = "Press any key to continue...";
            PrintGrey(text);
            Console.ReadKey();
        }

        /// <summary>
        /// Prints the text provided with grey color.
        /// </summary>
        /// <param name="text">Checks if the string text is null, empty or whitespace and returns nothing in such case.</param>
        public void PrintGrey(string text)
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
        public void HelloBeep()
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
        public void BuyBeep()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Console.Beep(800, 150);
                Console.Beep(400, 100);
                Console.Beep(800, 150);
                Console.Beep(400, 100);
            }
        }
    }
}